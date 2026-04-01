using FileScannerApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Text.Json;

namespace FileScannerApp
{
    public class Database
    {
        private string dbPath;

        public Database(string dbPath = "database.db")
        {
            this.dbPath = dbPath;
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            var connection = new SQLiteConnection($"Data Source={this.dbPath}");
            connection.Open();
            connection.Close();
        }

        public void SaveFiles(FileInfo[] files)
        {
            using (var connection = new SQLiteConnection($"Data Source={this.dbPath}"))
            {
                connection.Open();

                var clear = new SQLiteCommand("DELETE FROM Files;", connection);
                clear.ExecuteNonQuery();

                foreach (var file in files)
                {
                    var cmd = new SQLiteCommand(@"
                        INSERT INTO Files 
                        (Name, Extension, Path, Size, CreatedDate, ModifiedDate)
                        VALUES 
                        (@name, @ext, @path, @size, @created, @modified);
                        ", connection);

                    cmd.Parameters.AddWithValue("@name", file.Name);
                    cmd.Parameters.AddWithValue("@ext", file.Extension);
                    cmd.Parameters.AddWithValue("@path", file.FullName);
                    cmd.Parameters.AddWithValue("@size", file.Length);
                    cmd.Parameters.AddWithValue("@created", file.CreationTime.ToString());
                    cmd.Parameters.AddWithValue("@modified", file.LastWriteTime.ToString());

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<FileData> GetFiles(string filterQuery = "")
        {
            var list = new List<FileData>();

            using (var connection = new SQLiteConnection($"Data Source={this.dbPath}"))
            {
                connection.Open();

                string query = "SELECT * FROM Files";

                if(!string.IsNullOrEmpty(filterQuery))
                {
                    query += " WHERE " + filterQuery;
                }

                var cmd = new SQLiteCommand(query, connection);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new FileData
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = reader["Name"].ToString(),
                        Extension = reader["Extension"].ToString(),
                        Path = reader["Path"].ToString(),
                        Size = Convert.ToInt64(reader["Size"]),
                        CreatedDate = reader["CreatedDate"].ToString(),
                        ModifiedDate = reader["ModifiedDate"].ToString()
                    });
                }
            }

            return list;
        }

        public int CreateScan(string folderPath, int filesCount)
        {
            using (var connection = new SQLiteConnection($"Data Source={this.dbPath}"))
            {
                connection.Open();

                var cmd = new SQLiteCommand(@"
                    INSERT INTO Scans (ScanDate, ScanPath, FilesCount, ThreatsFound, Status)
                    VALUES (@date, @path, @count, 0, 'InProgress');
                    SELECT last_insert_rowid();
                    ", connection);

                cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString());
                cmd.Parameters.AddWithValue("@path", folderPath);
                cmd.Parameters.AddWithValue("@count", filesCount);

                long scanId = (long)cmd.ExecuteScalar();
                return (int)scanId;
            }
        }

        public void SaveScanResult(int scanId, int fileId, string status, string apiResponse)
        {
            using (var connection = new SQLiteConnection($"Data Source={this.dbPath}"))
            {
                connection.Open();

                var cmd = new SQLiteCommand(@"
                    INSERT INTO ScanResults (ScanId, FileId, Status, ApiResponse)
                    VALUES (@scanId, @fileId, @status, @response);
                ", connection);

                cmd.Parameters.AddWithValue("@scanId", scanId);
                cmd.Parameters.AddWithValue("@fileId", fileId);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@response", apiResponse);

                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateScanResults(int scanId, int threatsFound, string status)
        {
            using (var connection = new SQLiteConnection($"Data Source={this.dbPath}"))
            {
                connection.Open();

                var cmd = new SQLiteCommand(@"
                    UPDATE Scans
                    SET ThreatsFound = @threats, Status = @status
                    WHERE Id = @scanId;
                ", connection);

                cmd.Parameters.AddWithValue("@threats", threatsFound);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@scanId", scanId);

                cmd.ExecuteNonQuery();
            }
        }

        public List<ScanResultView> GetScanResults(int scanId)
        {
            var results = new List<ScanResultView>();

            var connection = new SQLiteConnection($"Data Source={this.dbPath}");
            connection.Open();

            var cmd = new SQLiteCommand(
                "SELECT f.Name, r.Status, r.ApiResponse FROM ScanResults r JOIN Files f ON r.FileId = f.Id WHERE r.ScanId = @scanId",
                connection
            );
            cmd.Parameters.AddWithValue("@scanId", scanId);

            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string fileName = reader.GetString(0);
                string status = reader.GetString(1);
                string json = reader.GetString(2);

                
                int malicious = 0;
                if (!string.IsNullOrEmpty(json))
                {
                    try
                    {
                        var doc = JsonDocument.Parse(json);
                        malicious = doc.RootElement
                                       .GetProperty("data")
                                       .GetProperty("attributes")
                                       .GetProperty("last_analysis_stats")
                                       .GetProperty("malicious")
                                       .GetInt32();
                    }
                    catch
                    {
                        malicious = 0;
                    }
                }

                results.Add(new ScanResultView
                {
                    FileName = fileName,
                    Status = status,
                    Malicious = malicious > 0 ? "Yes" : "No"
                });
            }

            return results;
        }

        public class ScanResultView
        {
            public string FileName { get; set; }
            public string Status { get; set; }
            public string Malicious { get; set; }
        }

        public List<dynamic> GetAllScansWithResults()
        {
            var scans = new List<dynamic>();

            using (var connection = new SQLiteConnection($"Data Source={this.dbPath}"))
            {
                connection.Open();

                var cmd = new SQLiteCommand(@"
                    SELECT s.Id, s.ScanDate, s.ScanPath, s.FilesCount, s.ThreatsFound, s.Status,
                    f.Name, r.Status AS FileStatus, r.ApiResponse
                    FROM Scans s
                    LEFT JOIN ScanResults r ON s.Id = r.ScanId
                    LEFT JOIN Files f ON r.FileId = f.Id
                    ORDER BY s.Id DESC
                    ", connection);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string json = reader.GetString(8);

                        bool isMalicious = json.Contains("malicious");

                        scans.Add(new
                        {
                            ScanId = reader.GetInt32(0),
                            ScanDate = reader.GetString(1),
                            ScanPath = reader.GetString(2),
                            FilesCount = reader.GetInt32(3),
                            ThreatsFound = reader.GetInt32(4),
                            ScanStatus = reader.GetString(5),
                            FileName = reader.IsDBNull(6) ? null : reader.GetString(6),
                            FileStatus = reader.IsDBNull(7) ? null : reader.GetString(7),
                            Malicious = isMalicious ? "Yes" : "No",
                        });
                    }
                }
            }

            return scans;
        }

    }
}