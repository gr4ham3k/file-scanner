namespace FileScannerApp
{
    partial class RenameForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RenameForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPattern = new System.Windows.Forms.TextBox();
            this.changeFolderBtn = new System.Windows.Forms.Button();
            this.textBoxFolder = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listBoxTokens = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.radioCopy = new System.Windows.Forms.RadioButton();
            this.radioMove = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(662, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rename files";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(12, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(662, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Pattern";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxPattern
            // 
            this.textBoxPattern.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxPattern.Location = new System.Drawing.Point(261, 160);
            this.textBoxPattern.Name = "textBoxPattern";
            this.textBoxPattern.Size = new System.Drawing.Size(167, 23);
            this.textBoxPattern.TabIndex = 2;
            this.textBoxPattern.Text = "{name}_{counter}";
            // 
            // changeFolderBtn
            // 
            this.changeFolderBtn.Image = ((System.Drawing.Image)(resources.GetObject("changeFolderBtn.Image")));
            this.changeFolderBtn.Location = new System.Drawing.Point(443, 93);
            this.changeFolderBtn.Name = "changeFolderBtn";
            this.changeFolderBtn.Size = new System.Drawing.Size(25, 23);
            this.changeFolderBtn.TabIndex = 13;
            this.changeFolderBtn.UseVisualStyleBackColor = true;
            this.changeFolderBtn.Click += new System.EventHandler(this.changeFolderBtn_Click);
            // 
            // textBoxFolder
            // 
            this.textBoxFolder.Enabled = false;
            this.textBoxFolder.Location = new System.Drawing.Point(250, 93);
            this.textBoxFolder.Name = "textBoxFolder";
            this.textBoxFolder.Size = new System.Drawing.Size(187, 22);
            this.textBoxFolder.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(12, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(662, 23);
            this.label3.TabIndex = 14;
            this.label3.Text = "Folder";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listBoxTokens
            // 
            this.listBoxTokens.FormattingEnabled = true;
            this.listBoxTokens.ItemHeight = 16;
            this.listBoxTokens.Items.AddRange(new object[] {
            "{name}",
            "{ext}",
            "{date}",
            "{counter}"});
            this.listBoxTokens.Location = new System.Drawing.Point(293, 226);
            this.listBoxTokens.Name = "listBoxTokens";
            this.listBoxTokens.Size = new System.Drawing.Size(120, 84);
            this.listBoxTokens.TabIndex = 15;
            this.listBoxTokens.DoubleClick += new System.EventHandler(this.listBoxTokens_DoubleClick);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(13, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(662, 23);
            this.label4.TabIndex = 16;
            this.label4.Text = "Tokens";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radioCopy
            // 
            this.radioCopy.AutoSize = true;
            this.radioCopy.Location = new System.Drawing.Point(297, 379);
            this.radioCopy.Name = "radioCopy";
            this.radioCopy.Size = new System.Drawing.Size(111, 20);
            this.radioCopy.TabIndex = 23;
            this.radioCopy.TabStop = true;
            this.radioCopy.Text = "UPPERCASE";
            this.radioCopy.UseVisualStyleBackColor = true;
            // 
            // radioMove
            // 
            this.radioMove.AutoSize = true;
            this.radioMove.Checked = true;
            this.radioMove.Location = new System.Drawing.Point(297, 353);
            this.radioMove.Name = "radioMove";
            this.radioMove.Size = new System.Drawing.Size(90, 20);
            this.radioMove.TabIndex = 22;
            this.radioMove.TabStop = true;
            this.radioMove.Text = "lowercase";
            this.radioMove.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(297, 405);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(87, 20);
            this.radioButton1.TabIndex = 24;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Capitalize";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(12, 323);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(662, 23);
            this.label5.TabIndex = 25;
            this.label5.Text = "Options";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(18, 483);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(657, 229);
            this.dataGridView1.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(12, 446);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(662, 23);
            this.label6.TabIndex = 27;
            this.label6.Text = "Preview";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(362, 736);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 32);
            this.button3.TabIndex = 29;
            this.button3.Text = "Cancel";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(267, 736);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(89, 32);
            this.button2.TabIndex = 28;
            this.button2.Text = "Rename";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // RenameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 809);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.radioCopy);
            this.Controls.Add(this.radioMove);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listBoxTokens);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.changeFolderBtn);
            this.Controls.Add(this.textBoxFolder);
            this.Controls.Add(this.textBoxPattern);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "RenameForm";
            this.Text = "RenameForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPattern;
        private System.Windows.Forms.Button changeFolderBtn;
        private System.Windows.Forms.TextBox textBoxFolder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBoxTokens;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radioCopy;
        private System.Windows.Forms.RadioButton radioMove;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
    }
}