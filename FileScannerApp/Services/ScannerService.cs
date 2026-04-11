using FileScannerApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FileScannerApp.Services
{
    using System.Net.Http;
    using System.Security.Cryptography;
    using System.Security.Policy;
    using System.Text.Json;
    using System.Threading.Tasks;

    public class ScanService
    {
        private readonly string apiKey;
        private static readonly HttpClient client = new HttpClient();

        public ScanService(string apiKey)
        {
            this.apiKey = apiKey;
        }

        public string CalculateSHA256(string filePath)
        {
            using (var sha256 = SHA256.Create())
            {
                using (var stream = File.OpenRead(filePath))
                {
                    var hash = sha256.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }


        public async Task<string> GetFileReportAsync(string fileHash)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://www.virustotal.com/api/v3/files/{fileHash}"),
                Headers =
                {
                    { "x-apikey", apiKey },
                    { "accept", "application/json" }
                }
            };

            using (var response = await client.SendAsync(request))
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    return null;

                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}