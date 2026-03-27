namespace FileScannerApp
{
    partial class FileScannerMain
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileScannerMain));
            this.filesView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.previewPanel = new System.Windows.Forms.Panel();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.label6 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripAllFilesBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripImagesBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripDocumentsBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripMusicBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripVideosBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.selectFolderBtn = new System.Windows.Forms.ToolStripButton();
            this.scanBtn = new System.Windows.Forms.ToolStripButton();
            this.organizeBtn = new System.Windows.Forms.ToolStripButton();
            this.renameBtn = new System.Windows.Forms.ToolStripButton();
            this.historyBtn = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.previewPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // filesView
            // 
            this.filesView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.filesView.HideSelection = false;
            this.filesView.Location = new System.Drawing.Point(12, 169);
            this.filesView.Name = "filesView";
            this.filesView.Size = new System.Drawing.Size(671, 513);
            this.filesView.TabIndex = 7;
            this.filesView.UseCompatibleStateImageBehavior = false;
            this.filesView.View = System.Windows.Forms.View.Details;
            this.filesView.SelectedIndexChanged += new System.EventHandler(this.filesView_SelectedIndexChanged);
            this.filesView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.filesView_MouseDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Size";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Date";
            this.columnHeader3.Width = 80;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Location";
            this.columnHeader4.Width = 80;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Status";
            // 
            // previewPanel
            // 
            this.previewPanel.Controls.Add(this.axWindowsMediaPlayer1);
            this.previewPanel.Controls.Add(this.label6);
            this.previewPanel.Location = new System.Drawing.Point(689, 169);
            this.previewPanel.Name = "previewPanel";
            this.previewPanel.Size = new System.Drawing.Size(462, 513);
            this.previewPanel.TabIndex = 8;
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(0, 0);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(462, 513);
            this.axWindowsMediaPlayer1.TabIndex = 10;
            this.axWindowsMediaPlayer1.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(206, 231);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "Preview";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripAllFilesBtn,
            this.toolStripImagesBtn,
            this.toolStripDocumentsBtn,
            this.toolStripMusicBtn,
            this.toolStripVideosBtn});
            this.toolStrip1.Location = new System.Drawing.Point(12, 120);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(434, 31);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(51, 24);
            this.toolStripLabel1.Text = "Filters:";
            // 
            // toolStripAllFilesBtn
            // 
            this.toolStripAllFilesBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripAllFilesBtn.Image = ((System.Drawing.Image)(resources.GetObject("toolStripAllFilesBtn.Image")));
            this.toolStripAllFilesBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripAllFilesBtn.Margin = new System.Windows.Forms.Padding(12, 1, 0, 2);
            this.toolStripAllFilesBtn.Name = "toolStripAllFilesBtn";
            this.toolStripAllFilesBtn.Size = new System.Drawing.Size(62, 24);
            this.toolStripAllFilesBtn.Text = "All files";
            this.toolStripAllFilesBtn.Click += new System.EventHandler(this.Filter_Click);
            // 
            // toolStripImagesBtn
            // 
            this.toolStripImagesBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripImagesBtn.Image = ((System.Drawing.Image)(resources.GetObject("toolStripImagesBtn.Image")));
            this.toolStripImagesBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripImagesBtn.Margin = new System.Windows.Forms.Padding(12, 1, 0, 2);
            this.toolStripImagesBtn.Name = "toolStripImagesBtn";
            this.toolStripImagesBtn.Size = new System.Drawing.Size(61, 24);
            this.toolStripImagesBtn.Text = "Images";
            this.toolStripImagesBtn.Click += new System.EventHandler(this.Filter_Click);
            // 
            // toolStripDocumentsBtn
            // 
            this.toolStripDocumentsBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDocumentsBtn.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDocumentsBtn.Image")));
            this.toolStripDocumentsBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDocumentsBtn.Margin = new System.Windows.Forms.Padding(12, 1, 0, 2);
            this.toolStripDocumentsBtn.Name = "toolStripDocumentsBtn";
            this.toolStripDocumentsBtn.Size = new System.Drawing.Size(88, 24);
            this.toolStripDocumentsBtn.Text = "Documents";
            this.toolStripDocumentsBtn.Click += new System.EventHandler(this.Filter_Click);
            // 
            // toolStripMusicBtn
            // 
            this.toolStripMusicBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripMusicBtn.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMusicBtn.Image")));
            this.toolStripMusicBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMusicBtn.Margin = new System.Windows.Forms.Padding(12, 1, 0, 2);
            this.toolStripMusicBtn.Name = "toolStripMusicBtn";
            this.toolStripMusicBtn.Size = new System.Drawing.Size(51, 24);
            this.toolStripMusicBtn.Text = "Music";
            this.toolStripMusicBtn.Click += new System.EventHandler(this.Filter_Click);
            // 
            // toolStripVideosBtn
            // 
            this.toolStripVideosBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripVideosBtn.Image = ((System.Drawing.Image)(resources.GetObject("toolStripVideosBtn.Image")));
            this.toolStripVideosBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripVideosBtn.Margin = new System.Windows.Forms.Padding(12, 1, 0, 2);
            this.toolStripVideosBtn.Name = "toolStripVideosBtn";
            this.toolStripVideosBtn.Size = new System.Drawing.Size(58, 24);
            this.toolStripVideosBtn.Text = "Videos";
            this.toolStripVideosBtn.Click += new System.EventHandler(this.Filter_Click);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(45, 20);
            this.toolStripStatusLabel1.Text = "Total:";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(69, 20);
            this.toolStripStatusLabel2.Text = "Selected:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 727);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1182, 26);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStrip2
            // 
            this.toolStrip2.AutoSize = false;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectFolderBtn,
            this.scanBtn,
            this.organizeBtn,
            this.renameBtn,
            this.historyBtn});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1182, 120);
            this.toolStrip2.Stretch = true;
            this.toolStrip2.TabIndex = 11;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // selectFolderBtn
            // 
            this.selectFolderBtn.AutoSize = false;
            this.selectFolderBtn.Image = ((System.Drawing.Image)(resources.GetObject("selectFolderBtn.Image")));
            this.selectFolderBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.selectFolderBtn.Name = "selectFolderBtn";
            this.selectFolderBtn.Size = new System.Drawing.Size(120, 90);
            this.selectFolderBtn.Text = "Select Folder";
            this.selectFolderBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.selectFolderBtn.Click += new System.EventHandler(this.selectFolderBtn_Click);
            // 
            // scanBtn
            // 
            this.scanBtn.AutoSize = false;
            this.scanBtn.Image = ((System.Drawing.Image)(resources.GetObject("scanBtn.Image")));
            this.scanBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.scanBtn.Name = "scanBtn";
            this.scanBtn.Size = new System.Drawing.Size(120, 90);
            this.scanBtn.Text = "Scan";
            this.scanBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.scanBtn.Click += new System.EventHandler(this.scanButtonClick);
            // 
            // organizeBtn
            // 
            this.organizeBtn.AutoSize = false;
            this.organizeBtn.Image = ((System.Drawing.Image)(resources.GetObject("organizeBtn.Image")));
            this.organizeBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.organizeBtn.Name = "organizeBtn";
            this.organizeBtn.Size = new System.Drawing.Size(120, 90);
            this.organizeBtn.Text = "Organize";
            this.organizeBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // renameBtn
            // 
            this.renameBtn.AutoSize = false;
            this.renameBtn.Image = ((System.Drawing.Image)(resources.GetObject("renameBtn.Image")));
            this.renameBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.renameBtn.Name = "renameBtn";
            this.renameBtn.Size = new System.Drawing.Size(120, 90);
            this.renameBtn.Text = "Rename pattern";
            this.renameBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // historyBtn
            // 
            this.historyBtn.AutoSize = false;
            this.historyBtn.Image = ((System.Drawing.Image)(resources.GetObject("historyBtn.Image")));
            this.historyBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.historyBtn.Name = "historyBtn";
            this.historyBtn.Size = new System.Drawing.Size(120, 90);
            this.historyBtn.Text = "History";
            this.historyBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.historyBtn.Click += new System.EventHandler(this.historyBtn_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.renameToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(133, 52);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(132, 24);
            this.renameToolStripMenuItem.Text = "Rename";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(132, 24);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Margin = new System.Windows.Forms.Padding(12, 4, 0, 2);
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(0, 20);
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 18);
            this.toolStripProgressBar1.Visible = false;
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(0, 20);
            // 
            // FileScannerMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1182, 753);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.previewPanel);
            this.Controls.Add(this.filesView);
            this.Name = "FileScannerMain";
            this.Text = "File Scanner";
            this.Load += new System.EventHandler(this.FileScannerMain_Load);
            this.previewPanel.ResumeLayout(false);
            this.previewPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView filesView;
        private System.Windows.Forms.Panel previewPanel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripAllFilesBtn;
        private System.Windows.Forms.ToolStripButton toolStripImagesBtn;
        private System.Windows.Forms.ToolStripButton toolStripDocumentsBtn;
        private System.Windows.Forms.ToolStripButton toolStripMusicBtn;
        private System.Windows.Forms.ToolStripButton toolStripVideosBtn;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton selectFolderBtn;
        private System.Windows.Forms.ToolStripButton scanBtn;
        private System.Windows.Forms.ToolStripButton organizeBtn;
        private System.Windows.Forms.ToolStripButton renameBtn;
        private System.Windows.Forms.ToolStripButton historyBtn;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
    }
}

