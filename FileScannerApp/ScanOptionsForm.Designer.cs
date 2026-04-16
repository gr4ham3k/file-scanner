namespace FileScannerApp
{
    partial class ScanOptionsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScanOptionsForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxes = new System.Windows.Forms.CheckedListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBoxFolder = new System.Windows.Forms.TextBox();
            this.changeFolderBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(558, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Virus Scan";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(215, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "File types to scan";
            // 
            // checkBoxes
            // 
            this.checkBoxes.BackColor = System.Drawing.SystemColors.Menu;
            this.checkBoxes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkBoxes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkBoxes.FormattingEnabled = true;
            this.checkBoxes.Items.AddRange(new object[] {
            "Executables",
            "Documents",
            "Images",
            "Videos"});
            this.checkBoxes.Location = new System.Drawing.Point(219, 173);
            this.checkBoxes.Name = "checkBoxes";
            this.checkBoxes.Size = new System.Drawing.Size(170, 105);
            this.checkBoxes.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(197, 320);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.startScanBtn_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(278, 320);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBoxFolder
            // 
            this.textBoxFolder.Enabled = false;
            this.textBoxFolder.Location = new System.Drawing.Point(197, 65);
            this.textBoxFolder.Name = "textBoxFolder";
            this.textBoxFolder.Size = new System.Drawing.Size(187, 22);
            this.textBoxFolder.TabIndex = 8;
            // 
            // changeFolderBtn
            // 
            this.changeFolderBtn.Image = ((System.Drawing.Image)(resources.GetObject("changeFolderBtn.Image")));
            this.changeFolderBtn.Location = new System.Drawing.Point(390, 65);
            this.changeFolderBtn.Name = "changeFolderBtn";
            this.changeFolderBtn.Size = new System.Drawing.Size(25, 23);
            this.changeFolderBtn.TabIndex = 9;
            this.changeFolderBtn.UseVisualStyleBackColor = true;
            this.changeFolderBtn.Click += new System.EventHandler(this.changeFolderBtn_Click);
            // 
            // ScanOptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 391);
            this.Controls.Add(this.changeFolderBtn);
            this.Controls.Add(this.textBoxFolder);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBoxes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ScanOptionsForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "ScanOptionsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox checkBoxes;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBoxFolder;
        private System.Windows.Forms.Button changeFolderBtn;
    }
}