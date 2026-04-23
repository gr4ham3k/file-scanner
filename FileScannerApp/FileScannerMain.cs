using FileScannerApp.Models;
using FileScannerApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace FileScannerApp
{
    public partial class FileScannerMain : Form
    {
        private ScanService scanService;
        private FileOperationsService fileOperationsService;
        private List<FileData> currentFiles;
        private string selectedPath;
        public FileScannerMain()
        {
            InitializeComponent();
            var config = AppConfig.Load();
            Database db = new Database();
            scanService = new ScanService(config,db);
            fileOperationsService = new FileOperationsService(db);
            currentFiles = new List<FileData>();
        }

        private void FileScannerMain_Load(object sender, EventArgs e)
        {

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
                    var fileInfos = FileScannerService.Scan(dialog.SelectedPath);
                    var files = FileScannerService.Map(fileInfos);

                    selectedPath = dialog.SelectedPath;

                    FolderService.ShowFiles(filesView,files);

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
                $"Are you sure you want to delete {filesView.SelectedItems.Count} file(s)?",
                "Confirm delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result != DialogResult.Yes)
                return;

            var items = filesView.SelectedItems.Cast<ListViewItem>().ToList();
            var paths = items.Select(i => i.Tag.ToString()).ToList();

            var (deleted, failed) = fileOperationsService.DeleteFiles(paths);

            foreach (var item in items)
                filesView.Items.Remove(item);

            UpdateStatus();

            MessageBox.Show(
                $"Delete completed.\n\nDeleted: {deleted}\nFailed: {failed}",
                "Delete",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }


        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int selectedCount = filesView.SelectedItems.Count;

            renameToolStripMenuItem.Enabled = selectedCount == 1;

            deleteToolStripMenuItem.Enabled = selectedCount > 0;

            moveToolStripMenuItem.Enabled = selectedCount > 0;
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filesView.SelectedItems.Count != 1)
                return;
            
            
            var item = filesView.SelectedItems[0];
            item.BeginEdit();
            

        }



        private void moveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filesView.SelectedItems.Count == 0)
            {
                MessageBox.Show("No files selected.", "Move", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                var items = filesView.SelectedItems.Cast<ListViewItem>().ToList();

                var paths = items
                    .Where(i => i.Tag != null)
                    .Select(i => i.Tag.ToString())
                    .ToList();

                var (moved, skipped, updatedPaths) =
                    fileOperationsService.MoveFiles(paths, dialog.SelectedPath);

                foreach (var (oldPath, newPath) in updatedPaths)
                {
                    var item = items.FirstOrDefault(i => i.Tag?.ToString() == oldPath);

                    if (item != null)
                    {
                        item.Tag = newPath;

                        if (item.SubItems.Count > 3)
                            item.SubItems[3].Text = newPath;
                    }
                }

                UpdateStatus();

                MessageBox.Show(
                    $"Move completed.\n\nMoved: {moved}\nSkipped: {skipped}",
                    "Move",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        private void filesView_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(e.Label))
            {
                e.CancelEdit = true;
                return;
            }

            var item = filesView.Items[e.Item];
            string oldPath = item.Tag?.ToString();

            if (oldPath == null)
            {
                e.CancelEdit = true;
                return;
            }

            var (success, newPath, error) =
                fileOperationsService.RenameFile(oldPath, e.Label);

            if (!success)
            {
                MessageBox.Show(error);
                e.CancelEdit = true;
                return;
            }

            item.Tag = newPath;
            item.SubItems[3].Text = newPath;
        }



        private void Filter_Click(object sender, EventArgs e)
        {
            var button = sender as ToolStripButton;

            List<FileData> filtered;

            switch (button.Name)
            {
                case "toolStripMusicBtn":
                    filtered = currentFiles
                        .Where(f => f.Extension == ".mp3" || f.Extension == ".wav")
                        .ToList();
                    break;

                case "toolStripImagesBtn":
                    filtered = currentFiles
                        .Where(f => f.Extension == ".jpg" || f.Extension == ".png")
                        .ToList();
                    break;

                case "toolStripDocumentsBtn":
                    filtered = currentFiles
                        .Where(f => f.Extension == ".pdf"
                                 || f.Extension == ".docx"
                                 || f.Extension == ".txt")
                        .ToList();
                    break;

                case "toolStripVideosBtn":
                    filtered = currentFiles
                        .Where(f => f.Extension == ".mp4")
                        .ToList();
                    break;

                default:
                    filtered = currentFiles;
                    break;
            }

            FolderService.ShowFiles(filesView, filtered);
            UpdateStatus();
        }


        private async void scanButtonClick(object sender, EventArgs e)
        {

            using (var scanForm = new ScanOptionsForm(selectedPath))
            {
                if (scanForm.ShowDialog() != DialogResult.OK)
                    return;

                selectedPath = scanForm.SelectedFolder;

                var fileTypes = scanForm.FileTypes;

                var fileInfos = FileScannerService.Scan(selectedPath);
                var files = FileScannerService.Map(fileInfos);

                UpdateStatus();

                int scanId = scanService.CreateScan(selectedPath, files.Count);

                toolStripProgressBar1.Visible = true;
                toolStripProgressBar1.Minimum = 0;
                toolStripProgressBar1.Maximum = files.Count;
                toolStripProgressBar1.Value = 0;

                int result = await scanService.ScanFilesAsync(
                    files,
                    scanId,
                    async progress =>
                    {
                        toolStripProgressBar1.Value = progress.Current;
                        toolStripStatusLabel3.Text = $"Scanning {progress.Current}/{progress.Total}";
                        toolStripStatusLabel4.Text = progress.CurrentFile;

                        await Task.Yield();
                    });

                toolStripProgressBar1.Visible = false;
                toolStripStatusLabel3.Text = "Scan completed";
                toolStripStatusLabel4.Text = "";

                MessageBox.Show($"Found {result} threats", "Scan completed");

                new ScanResultsForm(scanId).Show();
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

        private void organizeBtn_Click(object sender, EventArgs e)
        {
            
            var form = new OrganizeForm(selectedPath);

            if (form.ShowDialog() == DialogResult.OK)
            {
                var fileInfos = FileScannerService.Scan(selectedPath);
                var files = FileScannerService.Map(fileInfos);
                
                string path = Organizer.OrganizeFiles(
                    files,
                    form.SelectedFolder,
                    form.SelectedDestination,
                    form.FileTypes,
                    form.Radio,
                    form.Options.CreateSubfolders,
                    form.Options.OverwriteExisting
                    
                );

                MessageBox.Show("Files organized!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                var fileInfos = FileScannerService.Scan(selectedPath);
                var files = FileScannerService.Map(fileInfos);

                FolderService.ShowFiles(filesView, files);
                UpdateStatus();
            }
            else
            {
                using (FolderBrowserDialog dialog = new FolderBrowserDialog())
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        var fileInfos = FileScannerService.Scan(dialog.SelectedPath);
                        var files = FileScannerService.Map(fileInfos);

                        selectedPath = dialog.SelectedPath;

                        FolderService.ShowFiles(filesView, files);

                        UpdateStatus();
                    }
                }
            }

            
        }


    }
}
