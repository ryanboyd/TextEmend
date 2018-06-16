namespace WindowsFormsApplication1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.BgWorker = new System.ComponentModel.BackgroundWorker();
            this.ScanSubfolderCheckbox = new System.Windows.Forms.CheckBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.FolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.FilenameLabel = new System.Windows.Forms.Label();
            this.EncodingDropdown = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CompactWhitespaceCheckbox = new System.Windows.Forms.CheckBox();
            this.CaseSensitiveCheckbox = new System.Windows.Forms.CheckBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.LoadDictionaryButton = new System.Windows.Forms.Button();
            this.saveOutputDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.DataGridPreview = new System.Windows.Forms.DataGridView();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // BgWorker
            // 
            this.BgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BgWorkerClean_DoWork);
            this.BgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BgWorker_RunWorkerCompleted);
            // 
            // ScanSubfolderCheckbox
            // 
            this.ScanSubfolderCheckbox.AutoSize = true;
            this.ScanSubfolderCheckbox.Location = new System.Drawing.Point(6, 85);
            this.ScanSubfolderCheckbox.Name = "ScanSubfolderCheckbox";
            this.ScanSubfolderCheckbox.Size = new System.Drawing.Size(131, 20);
            this.ScanSubfolderCheckbox.TabIndex = 2;
            this.ScanSubfolderCheckbox.Text = "Scan subfolders?";
            this.ScanSubfolderCheckbox.UseVisualStyleBackColor = true;
            // 
            // StartButton
            // 
            this.StartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartButton.Location = new System.Drawing.Point(512, 241);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(152, 32);
            this.StartButton.TabIndex = 3;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // FolderBrowser
            // 
            this.FolderBrowser.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.FolderBrowser.ShowNewFolderButton = false;
            // 
            // FilenameLabel
            // 
            this.FilenameLabel.AutoEllipsis = true;
            this.FilenameLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FilenameLabel.Location = new System.Drawing.Point(458, 287);
            this.FilenameLabel.Name = "FilenameLabel";
            this.FilenameLabel.Size = new System.Drawing.Size(260, 15);
            this.FilenameLabel.TabIndex = 6;
            this.FilenameLabel.Text = "Waiting to process texts...";
            this.FilenameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EncodingDropdown
            // 
            this.EncodingDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EncodingDropdown.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EncodingDropdown.FormattingEnabled = true;
            this.EncodingDropdown.Location = new System.Drawing.Point(6, 47);
            this.EncodingDropdown.Name = "EncodingDropdown";
            this.EncodingDropdown.Size = new System.Drawing.Size(248, 23);
            this.EncodingDropdown.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(203, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Encoding of RegEx List && Text Files:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CompactWhitespaceCheckbox);
            this.groupBox2.Controls.Add(this.CaseSensitiveCheckbox);
            this.groupBox2.Controls.Add(this.EncodingDropdown);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.ScanSubfolderCheckbox);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(458, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(260, 177);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Text Reading Controls";
            // 
            // CompactWhitespaceCheckbox
            // 
            this.CompactWhitespaceCheckbox.AutoSize = true;
            this.CompactWhitespaceCheckbox.Checked = true;
            this.CompactWhitespaceCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CompactWhitespaceCheckbox.Location = new System.Drawing.Point(6, 137);
            this.CompactWhitespaceCheckbox.Name = "CompactWhitespaceCheckbox";
            this.CompactWhitespaceCheckbox.Size = new System.Drawing.Size(156, 20);
            this.CompactWhitespaceCheckbox.TabIndex = 12;
            this.CompactWhitespaceCheckbox.Text = "Compact Whitespace";
            this.CompactWhitespaceCheckbox.UseVisualStyleBackColor = true;
            // 
            // CaseSensitiveCheckbox
            // 
            this.CaseSensitiveCheckbox.AutoSize = true;
            this.CaseSensitiveCheckbox.Checked = true;
            this.CaseSensitiveCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CaseSensitiveCheckbox.Location = new System.Drawing.Point(6, 111);
            this.CaseSensitiveCheckbox.Name = "CaseSensitiveCheckbox";
            this.CaseSensitiveCheckbox.Size = new System.Drawing.Size(181, 20);
            this.CaseSensitiveCheckbox.TabIndex = 11;
            this.CaseSensitiveCheckbox.Text = "Case sensitive RegExes?";
            this.CaseSensitiveCheckbox.UseVisualStyleBackColor = true;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "RegEx List.txt";
            this.openFileDialog.Filter = "TextEmend RegEx List|*.txt";
            // 
            // LoadDictionaryButton
            // 
            this.LoadDictionaryButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadDictionaryButton.Location = new System.Drawing.Point(512, 203);
            this.LoadDictionaryButton.Name = "LoadDictionaryButton";
            this.LoadDictionaryButton.Size = new System.Drawing.Size(152, 32);
            this.LoadDictionaryButton.TabIndex = 20;
            this.LoadDictionaryButton.Text = "Load RegEx List";
            this.LoadDictionaryButton.UseVisualStyleBackColor = true;
            this.LoadDictionaryButton.Click += new System.EventHandler(this.LoadDictionaryButton_Click);
            // 
            // DataGridPreview
            // 
            this.DataGridPreview.AllowUserToAddRows = false;
            this.DataGridPreview.AllowUserToDeleteRows = false;
            this.DataGridPreview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridPreview.Location = new System.Drawing.Point(13, 12);
            this.DataGridPreview.Name = "DataGridPreview";
            this.DataGridPreview.ReadOnly = true;
            this.DataGridPreview.RowHeadersVisible = false;
            this.DataGridPreview.Size = new System.Drawing.Size(420, 290);
            this.DataGridPreview.TabIndex = 21;
            this.DataGridPreview.VirtualMode = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSalmon;
            this.ClientSize = new System.Drawing.Size(734, 311);
            this.Controls.Add(this.DataGridPreview);
            this.Controls.Add(this.LoadDictionaryButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.FilenameLabel);
            this.Controls.Add(this.StartButton);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(750, 350);
            this.MinimumSize = new System.Drawing.Size(750, 350);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TextEmend";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridPreview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker BgWorker;
        private System.Windows.Forms.CheckBox ScanSubfolderCheckbox;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowser;
        private System.Windows.Forms.Label FilenameLabel;
        private System.Windows.Forms.ComboBox EncodingDropdown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button LoadDictionaryButton;
        private System.Windows.Forms.FolderBrowserDialog saveOutputDialog;
        private System.Windows.Forms.CheckBox CaseSensitiveCheckbox;
        private System.Windows.Forms.CheckBox CompactWhitespaceCheckbox;
        private System.Windows.Forms.DataGridView DataGridPreview;
    }
}

