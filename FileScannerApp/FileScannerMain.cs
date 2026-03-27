using FileScannerApp;
using FileScannerApp.Services;
using System;
using System.IO;
using System.Windows.Forms;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
                    var files = FileScanner.Scan(dialog.SelectedPath);

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
            string folder = selectedPath;

            using (var scanForm = new ScanOptionsForm(folder))
            {
                if (scanForm.ShowDialog() == DialogResult.OK)
                {
                    string selected = scanForm.SelectedFolder;

                    await StartScanAsync(selected);
                }
            }
        }

        private async Task StartScanAsync(string folder)
        {
            toolStripStatusLabel3.Text = "Skanowanie w toku...";
            toolStripStatusLabel4.Text = "";

            var files = db.GetFiles($"Path LIKE '{folder}%'");

            if (files.Count == 0)
            {
                MessageBox.Show("Brak plików do skanowania!");
                return;
            }

            int scanId = db.CreateScan(folder, files.Count);
            int threatsFound = 0;

            toolStripProgressBar1.Visible = true;
            toolStripProgressBar1.Minimum = 0;
            toolStripProgressBar1.Maximum = files.Count;
            toolStripProgressBar1.Value = 0;

            toolStripStatusLabel3.Text = "Skanowanie...";
            toolStripStatusLabel4.Text = "";

            for (int i = 0; i < files.Count; i++)
            {
                var file = files[i];

                try
                {
                    string json = await scanService.ScanFileAsync(file.Path);

                    if (json.Contains("malicious"))
                        threatsFound++;

                    db.SaveScanResult(scanId, file.Id, "Completed", json);
                }
                catch (Exception ex)
                {
                    db.SaveScanResult(scanId, file.Id, "Error", ex.Message);
                }

                
                toolStripProgressBar1.Value = i + 1;
                toolStripStatusLabel3.Text = $"Skanowanie: {i + 1}/{files.Count}";
                toolStripStatusLabel4.Text = file.Name;

                
            }

            db.UpdateScanResults(scanId, threatsFound, "Completed");

            toolStripProgressBar1.Value = toolStripProgressBar1.Maximum;
            toolStripStatusLabel3.Text = "Skan zakończony";

            var result = MessageBox.Show($"Znaleziono {threatsFound} zagrożeń","Skan zakończony",MessageBoxButtons.OK);

            if (result == DialogResult.OK)
            {
                toolStripProgressBar1.Visible = false;
                toolStripStatusLabel3.Text = "";
                toolStripStatusLabel4.Text = "";

                var resultsForm = new ScanResultsForm(scanId);
                resultsForm.Show();
            }

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
    }
}
