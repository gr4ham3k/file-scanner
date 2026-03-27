using FileScannerApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;

namespace FileScannerApp.Services
{
    using System.Net.Http;
    using System.Threading.Tasks;

    public class ScanService
    {
        private readonly string apiKey;

        public ScanService(string apiKey)
        {
            this.apiKey = apiKey;
        }

        public async Task<string> ScanFileAsync(string filePath)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("x-apikey", apiKey);

                using (var content = new MultipartFormDataContent())
                {
                    var fileBytes = File.ReadAllBytes(filePath);
                    content.Add(new ByteArrayContent(fileBytes), "file", Path.GetFileName(filePath));

                    var response = await client.PostAsync("https://www.virustotal.com/api/v3/files", content);
                    string json = await response.Content.ReadAsStringAsync();
                    return json;
                }
            }
        }
    }
}