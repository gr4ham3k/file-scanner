using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileScannerApp
{
    public partial class HistoryForm : Form
    {
        public HistoryForm()
        {
            InitializeComponent();
        }

        private void HistoryForm_Load(object sender, EventArgs e)
        {
            var db = new Database();
            var scans = db.GetAllScansWithFiles();

            treeView1.Nodes.Clear();

            var grouped = scans.GroupBy(s => s.ScanId);

            foreach (var scanGroup in grouped)
            {
                var first = scanGroup.First();
                string scanText = $"Scan #{first.ScanId} | {first.ScanDate} | {first.FilesCount} files | Threats: {first.ThreatsFound} | {first.ScanStatus}";
                TreeNode scanNode = new TreeNode(scanText);

                foreach (var file in scanGroup)
                {
                    if (file.FileName != null)
                    {
                        string fileText = $"{file.FileName} | Status: {file.FileStatus} | Malicious: {file.Malicious}";
                        TreeNode fileNode = new TreeNode(fileText);
                        scanNode.Nodes.Add(fileNode);
                    }
                }

                treeView1.Nodes.Add(scanNode);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
