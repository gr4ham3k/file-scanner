using System;
using System.IO;
using System.Net.Http;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace FileScannerApp.Services
{
    public class ScanService
    {
        private readonly string apiKey;
        private readonly HttpClient client;

        public ScanService(string apiKey)
        {
            this.apiKey = apiKey;
            client = new HttpClient();
            client.DefaultRequestHeaders.Add("x-apikey", apiKey);
        }

        public async Task<string> ScanFileAsync(string filePath, string scanMode)
        {
            switch (scanMode)
            {
                case "Quick":
                    return await ScanByHash(filePath);

                case "Deep":
                    return await UploadAndScan(filePath);

                default:
                    return await ScanByHash(filePath);
            }
        }

        private async Task<string> ScanByHash(string filePath)
        {
            string hash = CalculateSHA256(filePath);

            var response = await client.GetAsync($"https://www.virustotal.com/api/v3/files/{hash}");

            if (!response.IsSuccessStatusCode)
            {
                return "NotFound";
            }

            return await response.Content.ReadAsStringAsync();
        }

        private async Task<string> UploadAndScan(string filePath)
        {
            using (var content = new MultipartFormDataContent())
            {
                var fileBytes = File.ReadAllBytes(filePath);
                content.Add(new ByteArrayContent(fileBytes), "file", Path.GetFileName(filePath));

                var response = await client.PostAsync("https://www.virustotal.com/api/v3/files", content);
                return await response.Content.ReadAsStringAsync();
            }
        }

        private string CalculateSHA256(string filePath)
        {
            using (var sha256 = SHA256.Create())
            using (var stream = File.OpenRead(filePath))
            {
                var hash = sha256.ComputeHash(stream);
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }
    }
}