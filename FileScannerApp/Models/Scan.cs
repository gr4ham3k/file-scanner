using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileScannerApp.Models
{
    public class Scan
    {
        private int Id {  get; set; }
        private DateTime ScanDate { get; set; }
        private string ScanPath { get; set; }
        private int FilesCount { get; set; }
        private int ThreatsFound {  get; set; }
        private string Status { get; set; }

    }
}
