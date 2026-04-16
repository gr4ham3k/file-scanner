using FileScannerApp;
using FileScannerApp.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace FileScannerApp
{
    public partial class FileScannerMain : Form
    {
        private Database db;
        private string apiKey;
        private ScanService scanService;
        private string selectedPath;
        public FileScannerMain()
        {
            InitializeComponent();

            db = new Database();
            apiKey = Environment.GetEnvironmentVariable("VIRUSTOTAL_API_KEY");
            scanService = new ScanService(apiKey);


        }

        private void FileScannerMain_Load(object sender, EventArgs e)
        {
            var dbFiles = db.GetFiles();
            FolderService.ShowFilesFromDb(filesView, dbFiles);

            UpdateStatus();
        }

        private void filesView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filesView.SelectedItems.Count == 0)
                return;

            string filePath = filesView.SelectedItems[0].Tag.ToString();

            PreviewService.Show(filePath, previewPanel);
            UpdateStatus();



        }


        private void selectFolderBtn_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var files = FileScannerService.Scan(dialog.SelectedPath);

                    selectedPath = dialog.SelectedPath;
                    
                    this.db.SaveFiles(files);

                    var dbFiles = db.GetFiles();
                    FolderService.ShowFilesFromDb(filesView, dbFiles);

                    UpdateStatus();
                }
            }
        }

        private void filesView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
              
                ListViewItem item = filesView.GetItemAt(e.X, e.Y);

                
                if (item != null && item.Selected)
                {
                    contextMenuStrip1.Show(filesView, e.Location);
                }
                else
                {
                    contextMenuStrip1.Hide();
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filesView.SelectedItems.Count == 0)
                return;

            var result = MessageBox.Show(
                $"Na pewno chcesz usunąć {filesView.SelectedItems.Count} plik(ów)?",
                "Potwierdzenie usunięcia",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result != DialogResult.Yes)
                return;

            foreach (ListViewItem item in filesView.SelectedItems)
            {
                string path = item.Tag.ToString();

                try
                {
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Błąd usuwania pliku: " + ex.Message);
                }

                db.DeleteFile(path);
                filesView.Items.Remove(item);
            }
            UpdateStatus();
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int selectedCount = filesView.SelectedItems.Count;

            renameToolStripMenuItem.Enabled = selectedCount == 1;

            deleteToolStripMenuItem.Enabled = selectedCount > 0;
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filesView.SelectedItems.Count != 1)
                return;
            
            
            var item = filesView.SelectedItems[0];
            item.BeginEdit();
            

        }

        private void filesView_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(e.Label))
            {
                e.CancelEdit = true;
                return;
            }

            var item = filesView.Items[e.Item];
            string oldPath = item.Tag.ToString();
            string directory = Path.GetDirectoryName(oldPath);
            string newName = e.Label;
            string newPath = Path.Combine(directory, newName);

            if (File.Exists(newPath))
            {
                MessageBox.Show("Plik o takiej nazwie już istnieje!");
                e.CancelEdit = true;
                return;
            }

            try
            {
                File.Move(oldPath, newPath);
                db.UpdateFilePath(oldPath, newPath);

                item.Tag = newPath; 
                item.SubItems[3].Text = newPath; 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd zmiany nazwy: " + ex.Message);
                e.CancelEdit = true;
            }
        }

        private void Filter_Click(object sender, EventArgs e)
        {
            var button = sender as ToolStripButton;
            var dbFiles = db.GetFiles();

            switch (button.Name)
            {
                case "toolStripMusicBtn":
                    dbFiles = db.GetFiles("Extension IN ('.mp3', '.wav')");
                    FolderService.ShowFilesFromDb(filesView, dbFiles);
                    UpdateStatus();
                    break;

                case "toolStripImagesBtn":
                    dbFiles = db.GetFiles("Extension IN ('.jpg', '.png')");
                    FolderService.ShowFilesFromDb(filesView, dbFiles);
                    UpdateStatus();
                    break;

                case "toolStripDocumentsBtn":
                    dbFiles = db.GetFiles("Extension IN ('.pdf', '.docx', '.txt')");
                    FolderService.ShowFilesFromDb(filesView, dbFiles);
                    UpdateStatus();
                    break;

                case "toolStripVideosBtn":
                    dbFiles = db.GetFiles("Extension IN ('.mp4')");
                    FolderService.ShowFilesFromDb(filesView, dbFiles);
                    UpdateStatus();
                    break;

                default:
                    dbFiles = db.GetFiles();
                    FolderService.ShowFilesFromDb(filesView, dbFiles);
                    UpdateStatus();
                    break;
            }
        }

        private async void scanButtonClick(object sender, EventArgs e)
        {

            using (var scanForm = new ScanOptionsForm(selectedPath))
            {
                if (scanForm.ShowDialog() == DialogResult.OK)
                {
                    this.selectedPath = scanForm.SelectedFolder;

                    var fileTypes = scanForm.FileTypes;

                    var dbFiles = db.GetFiles();
                    FolderService.ShowFilesFromDb(filesView, dbFiles);
                    UpdateStatus();

                    await StartScanAsync(this.selectedPath,fileTypes);
                }
            }
        }

        private async Task StartScanAsync(string folder, List<string> fileTypes)
        {

            var files = db.GetFiles($"Path LIKE '{folder.Replace("'", "''")}%'");

            if (fileTypes != null && fileTypes.Count > 0)
            {
                files = files.Where(f => fileTypes.Contains(f.Extension.ToLower())).ToList();
            }

            if (files.Count == 0)
            {
                MessageBox.Show("No files for scan!");
                return;
            }


            int scanId = db.CreateScan(folder, files.Count);
            int threatsFound = 0;

            toolStripProgressBar1.Visible = true;
            toolStripProgressBar1.Minimum = 0;
            toolStripProgressBar1.Maximum = files.Count;
            toolStripProgressBar1.Value = 0;
            toolStripStatusLabel3.Text = "Scanning...";
            toolStripStatusLabel4.Text = "";

            for (int i = 0; i < files.Count; i++)
            {
                var file = files[i];
                string status = "Completed";
                string json = "";

                if (!File.Exists(file.Path))
                {
                    Console.WriteLine($"Missing: {file.Path}");
                    continue;
                }

                try
                {
                    
                    string fileHash = scanService.CalculateSHA256(file.Path);

                    json = await scanService.GetFileReportAsync(fileHash);

                    if (string.IsNullOrEmpty(json))
                    {
                        status = "Unknown";
                    }
                    else
                    {
                        var doc = JsonDocument.Parse(json);

                        var stats = doc.RootElement
                            .GetProperty("data")
                            .GetProperty("attributes")
                            .GetProperty("last_analysis_stats");

                        int malicious = stats.GetProperty("malicious").GetInt32();

                        if (malicious > 0)
                        {
                            status = "Malicious";
                            threatsFound++;
                        }
                    }

                    db.SaveScanResult(scanId, file.Name, status, json);
                }
                catch (Exception ex)
                {
                    db.SaveScanResult(scanId, file.Name, "Error", ex.Message);
                }

                await Task.Delay(15000);

                toolStripProgressBar1.Value = i + 1;
                toolStripStatusLabel3.Text = $"Scanning: {i + 1}/{files.Count}";
                toolStripStatusLabel4.Text = file.Name;
            }

            db.UpdateScanResults(scanId, threatsFound, "Completed");

            toolStripProgressBar1.Visible = false;
            toolStripStatusLabel3.Text = "Scan completed";
            toolStripStatusLabel4.Text = "";

            MessageBox.Show($"Found {threatsFound} threats", "Scan completed");

            new ScanResultsForm(scanId).Show();
        }

        private void UpdateStatus()
        {
            int all = filesView.Items.Count;
            int selected = filesView.SelectedItems.Count;

            toolStripStatusLabel1.Text = $"Total: {all}";
            toolStripStatusLabel2.Text = $"Selected: {selected}";
        }

        private void historyBtn_Click(object sender, EventArgs e)
        {
            var historyForm = new HistoryForm();
            historyForm.Show();
        }

        private void organizeBtn_Click(object sender, EventArgs e)
        {
            
            var form = new OrganizeForm(selectedPath);

            if (form.ShowDialog() == DialogResult.OK)
            {
                string path = Organizer.OrganizeFiles(
                    form.SelectedFolder,
                    form.SelectedDestination,
                    form.FileTypes,
                    form.Radio,
                    form.Options[0],
                    form.Options[1]
                );

                MessageBox.Show("Pliki zostały pomyślnie zorganizowane!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Diagnostics.Process.Start("explorer.exe", form.SelectedDestination);

            }
        }

        private void renameBtn_Click(object sender, EventArgs e)
        {
            var form = new RenameForm(selectedPath);
            if (form.ShowDialog() == DialogResult.OK)
            {
                selectedPath = form.SelectedFolder;
            }
        }

        private void toolStripRefreshButton_Click(object sender, EventArgs e)
        { 
            if(selectedPath != null)
            {
                var files = FileScannerService.Scan(selectedPath);
                db.SaveFiles(files);

                var showFiles = db.GetFiles();

                FolderService.ShowFilesFromDb(filesView, showFiles);
                UpdateStatus();
            }
            else
            {
                using (FolderBrowserDialog dialog = new FolderBrowserDialog())
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        var files = FileScannerService.Scan(dialog.SelectedPath);

                        selectedPath = dialog.SelectedPath;

                        this.db.SaveFiles(files);

                        var dbFiles = db.GetFiles();
                        FolderService.ShowFilesFromDb(filesView, dbFiles);

                        UpdateStatus();
                    }
                }
            }

            
        }
    }
}
