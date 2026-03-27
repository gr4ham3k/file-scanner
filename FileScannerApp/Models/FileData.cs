using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileScannerApp.Models
{
    public class FileData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public string Path { get; set; }
        public long Size { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
    }
}
