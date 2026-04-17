using FileScannerApp.Models;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using FileScannerApp.Services;

namespace FileScannerApp
{
    public partial class HistoryForm : Form
    {
        private OperationLog selectedLog;

        public HistoryForm()
        {
            InitializeComponent();

        }

        private void HistoryForm_Load(object sender, EventArgs e)
        {
            button3.Enabled = false;

            LoadScans();
            LoadOperations();
        }

        private void LoadScans()
        {
            var db = new Database();
            var scans = db.GetAllScansWithFiles();

            treeView1.Nodes.Clear();

            var grouped = scans.GroupBy(s => s.ScanId)
                               .OrderByDescending(g => g.Key);

            foreach (var scanGroup in grouped)
            {
                var first = scanGroup.First();

                string scanText =
                    $"Scan #{first.ScanId} | {first.ScanDate} | {first.FilesCount} files | Threats: {first.ThreatsFound} | {first.ScanStatus}";

                TreeNode scanNode = new TreeNode(scanText);

                foreach (var file in scanGroup)
                {
                    if (file.FileName != null)
                    {
                        string fileText =
                            $"{file.FileName} | Status: {file.FileStatus} | Malicious: {file.Malicious}";

                        scanNode.Nodes.Add(new TreeNode(fileText));
                    }
                }

                scanNode.Expand();
                treeView1.Nodes.Add(scanNode);
            }
        }


        private void LoadOperations()
        {

            var db = new Database();
            var logs = db.GetOperationsLog();

            treeView2.Nodes.Clear();

            foreach (var log in logs)
            {
                string text =
                    $"[{log.OperationDate:yyyy-MM-dd HH:mm}] {log.OperationType} | {log.FileName}";

                TreeNode node = new TreeNode(text)
                {
                    Tag = log
                };

                if (!string.IsNullOrEmpty(log.OldPath) || !string.IsNullOrEmpty(log.NewPath))
                {
                    if (!string.IsNullOrEmpty(log.OldPath))
                        node.Nodes.Add("Old: " + log.OldPath);

                    if (!string.IsNullOrEmpty(log.NewPath))
                        node.Nodes.Add("New: " + log.NewPath);
                }

                treeView2.Nodes.Add(node);
            }
        }


        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            selectedLog = e.Node.Tag as OperationLog;

            button3.Enabled = selectedLog != null && selectedLog.CanUndo;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (selectedLog == null)
                return;

            bool success = false;

            try
            {
                switch (selectedLog.OperationType)
                {
                    case OperationType.Rename:
                    case OperationType.Move:
                        success = UndoService.Undo(selectedLog);
                        break;
                }

                if (success)
                {
                    var db = new Database();
                    db.DeleteOperationLog(selectedLog.Id);

                    MessageBox.Show("Undo completed");
                }
                else
                {
                    MessageBox.Show("Undo failed");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Undo failed: " + ex.Message);
            }

            selectedLog = null;
            button3.Enabled = false;

            LoadOperations();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}