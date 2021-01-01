namespace WordCloudGenerator
{
    partial class Main
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.buttonChooseFile = new System.Windows.Forms.Button();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.richTextBoxFiles = new System.Windows.Forms.RichTextBox();
            this.buttonSaveImage = new System.Windows.Forms.Button();
            this.richTextBoxFileSaved = new System.Windows.Forms.RichTextBox();
            this.buttonSelectBlacklist = new System.Windows.Forms.Button();
            this.labelBlacklists = new System.Windows.Forms.Label();
            this.comboBoxBlacklist = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelRight = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelLeft = new System.Windows.Forms.TableLayoutPanel();
            this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanelMain.SuspendLayout();
            this.tableLayoutPanelRight.SuspendLayout();
            this.tableLayoutPanelLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonChooseFile
            // 
            this.buttonChooseFile.Location = new System.Drawing.Point(3, 3);
            this.buttonChooseFile.Name = "buttonChooseFile";
            this.buttonChooseFile.Size = new System.Drawing.Size(154, 23);
            this.buttonChooseFile.TabIndex = 0;
            this.buttonChooseFile.Text = "Datei auswählen";
            this.buttonChooseFile.UseVisualStyleBackColor = true;
            this.buttonChooseFile.Click += new System.EventHandler(this.ButtonChooseFileClick);
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Location = new System.Drawing.Point(3, 33);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(154, 23);
            this.buttonGenerate.TabIndex = 1;
            this.buttonGenerate.Text = "Generiere Wordcloud";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.ButtonGenerateClick);
            // 
            // richTextBoxFiles
            // 
            this.richTextBoxFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxFiles.Location = new System.Drawing.Point(3, 42);
            this.richTextBoxFiles.Name = "richTextBoxFiles";
            this.richTextBoxFiles.ReadOnly = true;
            this.richTextBoxFiles.Size = new System.Drawing.Size(378, 33);
            this.richTextBoxFiles.TabIndex = 2;
            this.richTextBoxFiles.Text = "";
            // 
            // buttonSaveImage
            // 
            this.buttonSaveImage.Location = new System.Drawing.Point(3, 63);
            this.buttonSaveImage.Name = "buttonSaveImage";
            this.buttonSaveImage.Size = new System.Drawing.Size(154, 23);
            this.buttonSaveImage.TabIndex = 3;
            this.buttonSaveImage.Text = "Bild speichern unter";
            this.buttonSaveImage.UseVisualStyleBackColor = true;
            this.buttonSaveImage.Click += new System.EventHandler(this.ButtonSaveImageClick);
            // 
            // richTextBoxFileSaved
            // 
            this.richTextBoxFileSaved.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxFileSaved.Location = new System.Drawing.Point(3, 81);
            this.richTextBoxFileSaved.Name = "richTextBoxFileSaved";
            this.richTextBoxFileSaved.ReadOnly = true;
            this.richTextBoxFileSaved.Size = new System.Drawing.Size(378, 33);
            this.richTextBoxFileSaved.TabIndex = 4;
            this.richTextBoxFileSaved.Text = "";
            // 
            // buttonSelectBlacklist
            // 
            this.buttonSelectBlacklist.Location = new System.Drawing.Point(3, 120);
            this.buttonSelectBlacklist.Name = "buttonSelectBlacklist";
            this.buttonSelectBlacklist.Size = new System.Drawing.Size(154, 23);
            this.buttonSelectBlacklist.TabIndex = 5;
            this.buttonSelectBlacklist.Text = "Blacklists definieren";
            this.buttonSelectBlacklist.UseVisualStyleBackColor = true;
            this.buttonSelectBlacklist.Click += new System.EventHandler(this.ButtonSelectBlacklistClick);
            // 
            // labelBlacklists
            // 
            this.labelBlacklists.AutoSize = true;
            this.labelBlacklists.Location = new System.Drawing.Point(3, 90);
            this.labelBlacklists.Name = "labelBlacklists";
            this.labelBlacklists.Size = new System.Drawing.Size(49, 13);
            this.labelBlacklists.TabIndex = 6;
            this.labelBlacklists.Text = "Blacklist:";
            // 
            // comboBoxBlacklist
            // 
            this.comboBoxBlacklist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBlacklist.FormattingEnabled = true;
            this.comboBoxBlacklist.Location = new System.Drawing.Point(3, 123);
            this.comboBoxBlacklist.Name = "comboBoxBlacklist";
            this.comboBoxBlacklist.Size = new System.Drawing.Size(154, 21);
            this.comboBoxBlacklist.TabIndex = 7;
            this.comboBoxBlacklist.SelectedIndexChanged += new System.EventHandler(this.ComboBoxBlacklistSelectedIndexChanged);
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 2;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelRight, 1, 0);
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelLeft, 0, 0);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 1;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(557, 155);
            this.tableLayoutPanelMain.TabIndex = 8;
            // 
            // tableLayoutPanelRight
            // 
            this.tableLayoutPanelRight.ColumnCount = 1;
            this.tableLayoutPanelRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelRight.Controls.Add(this.buttonSelectBlacklist, 0, 3);
            this.tableLayoutPanelRight.Controls.Add(this.richTextBoxFileSaved, 0, 2);
            this.tableLayoutPanelRight.Controls.Add(this.richTextBoxFiles, 0, 1);
            this.tableLayoutPanelRight.Controls.Add(this.comboBoxLanguage, 0, 0);
            this.tableLayoutPanelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelRight.Location = new System.Drawing.Point(170, 3);
            this.tableLayoutPanelRight.Name = "tableLayoutPanelRight";
            this.tableLayoutPanelRight.RowCount = 4;
            this.tableLayoutPanelRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelRight.Size = new System.Drawing.Size(384, 149);
            this.tableLayoutPanelRight.TabIndex = 9;
            // 
            // tableLayoutPanelLeft
            // 
            this.tableLayoutPanelLeft.ColumnCount = 1;
            this.tableLayoutPanelLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelLeft.Controls.Add(this.buttonChooseFile, 0, 0);
            this.tableLayoutPanelLeft.Controls.Add(this.comboBoxBlacklist, 0, 4);
            this.tableLayoutPanelLeft.Controls.Add(this.buttonGenerate, 0, 1);
            this.tableLayoutPanelLeft.Controls.Add(this.labelBlacklists, 0, 3);
            this.tableLayoutPanelLeft.Controls.Add(this.buttonSaveImage, 0, 2);
            this.tableLayoutPanelLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelLeft.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelLeft.Name = "tableLayoutPanelLeft";
            this.tableLayoutPanelLeft.RowCount = 5;
            this.tableLayoutPanelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelLeft.Size = new System.Drawing.Size(161, 149);
            this.tableLayoutPanelLeft.TabIndex = 9;
            // 
            // comboBoxLanguage
            // 
            this.comboBoxLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLanguage.FormattingEnabled = true;
            this.comboBoxLanguage.Location = new System.Drawing.Point(3, 3);
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            this.comboBoxLanguage.Size = new System.Drawing.Size(121, 21);
            this.comboBoxLanguage.TabIndex = 6;
            this.comboBoxLanguage.SelectedIndexChanged += new System.EventHandler(this.ComboBoxLanguageSelectedIndexChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 155);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(573, 194);
            this.Name = "Main";
            this.Text = "WordCloudGenerator";
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelRight.ResumeLayout(false);
            this.tableLayoutPanelLeft.ResumeLayout(false);
            this.tableLayoutPanelLeft.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonChooseFile;
        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.RichTextBox richTextBoxFiles;
        private System.Windows.Forms.Button buttonSaveImage;
        private System.Windows.Forms.RichTextBox richTextBoxFileSaved;
        private System.Windows.Forms.Button buttonSelectBlacklist;
        private System.Windows.Forms.Label labelBlacklists;
        private System.Windows.Forms.ComboBox comboBoxBlacklist;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelRight;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelLeft;
        private System.Windows.Forms.ComboBox comboBoxLanguage;
    }
}