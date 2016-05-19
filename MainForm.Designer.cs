namespace CustomDesktopLogo
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainFormContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dropFolderModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideLogosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainFormTrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.settingsTabControl = new System.Windows.Forms.TabControl();
            this.selectImagesTabPage = new System.Windows.Forms.TabPage();
            this.refreshImageListButton = new System.Windows.Forms.Button();
            this.selectImagesInstructionsLabel = new System.Windows.Forms.Label();
            this.changeImagesButton = new System.Windows.Forms.Button();
            this.imagesListBox = new System.Windows.Forms.ListBox();
            this.locationTabPage = new System.Windows.Forms.TabPage();
            this.multiMonitorDisplayModsGroupBox = new System.Windows.Forms.GroupBox();
            this.virtualMonitorRadioButton = new System.Windows.Forms.RadioButton();
            this.allButPrimaryRadioButton = new System.Windows.Forms.RadioButton();
            this.primaryOnlyRadioButton = new System.Windows.Forms.RadioButton();
            this.allSameRadioButton = new System.Windows.Forms.RadioButton();
            this.sizeTabPage = new System.Windows.Forms.TabPage();
            this.animationTabPage = new System.Windows.Forms.TabPage();
            this.LanguageTabPage = new System.Windows.Forms.TabPage();
            this.dropFolderTab = new System.Windows.Forms.TabPage();
            this.useAsDropFolderCheckBox = new System.Windows.Forms.CheckBox();
            this.filePathsDataGridView = new System.Windows.Forms.DataGridView();
            this.folderName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.folderPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.browseButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.TargetFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.filePathsContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyMoveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.test1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.test2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderPathsFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.MainFormContextMenuStrip.SuspendLayout();
            this.settingsTabControl.SuspendLayout();
            this.selectImagesTabPage.SuspendLayout();
            this.locationTabPage.SuspendLayout();
            this.multiMonitorDisplayModsGroupBox.SuspendLayout();
            this.sizeTabPage.SuspendLayout();
            this.animationTabPage.SuspendLayout();
            this.LanguageTabPage.SuspendLayout();
            this.dropFolderTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.filePathsDataGridView)).BeginInit();
            this.filePathsContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainFormContextMenuStrip
            // 
            this.MainFormContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dropFolderModeToolStripMenuItem,
            this.hideLogosToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.MainFormContextMenuStrip.Name = "MainFormContextMenuStrip";
            this.MainFormContextMenuStrip.Size = new System.Drawing.Size(174, 136);
            this.MainFormContextMenuStrip.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.MainFormContextMenuStrip_Closed);
            this.MainFormContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.MainFormContextMenuStrip_Opening);
            // 
            // dropFolderModeToolStripMenuItem
            // 
            this.dropFolderModeToolStripMenuItem.CheckOnClick = true;
            this.dropFolderModeToolStripMenuItem.Name = "dropFolderModeToolStripMenuItem";
            this.dropFolderModeToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.dropFolderModeToolStripMenuItem.Text = "Drop Folder Mode";
            this.dropFolderModeToolStripMenuItem.Click += new System.EventHandler(this.dropFolderModeToolStripMenuItem_Click);
            // 
            // hideLogosToolStripMenuItem
            // 
            this.hideLogosToolStripMenuItem.CheckOnClick = true;
            this.hideLogosToolStripMenuItem.Name = "hideLogosToolStripMenuItem";
            this.hideLogosToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.hideLogosToolStripMenuItem.Text = "Hide Logos";
            this.hideLogosToolStripMenuItem.Click += new System.EventHandler(this.hideLogosToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // MainFormTrayIcon
            // 
            this.MainFormTrayIcon.ContextMenuStrip = this.MainFormContextMenuStrip;
            this.MainFormTrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("MainFormTrayIcon.Icon")));
            this.MainFormTrayIcon.Visible = true;
            this.MainFormTrayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MainFormTrayIcon_MouseDoubleClick);
            // 
            // settingsTabControl
            // 
            this.settingsTabControl.Controls.Add(this.selectImagesTabPage);
            this.settingsTabControl.Controls.Add(this.locationTabPage);
            this.settingsTabControl.Controls.Add(this.sizeTabPage);
            this.settingsTabControl.Controls.Add(this.animationTabPage);
            this.settingsTabControl.Controls.Add(this.LanguageTabPage);
            this.settingsTabControl.Controls.Add(this.dropFolderTab);
            this.settingsTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settingsTabControl.Location = new System.Drawing.Point(0, 0);
            this.settingsTabControl.Name = "settingsTabControl";
            this.settingsTabControl.SelectedIndex = 0;
            this.settingsTabControl.Size = new System.Drawing.Size(528, 552);
            this.settingsTabControl.TabIndex = 1;
            // 
            // selectImagesTabPage
            // 
            this.selectImagesTabPage.Controls.Add(this.refreshImageListButton);
            this.selectImagesTabPage.Controls.Add(this.selectImagesInstructionsLabel);
            this.selectImagesTabPage.Controls.Add(this.changeImagesButton);
            this.selectImagesTabPage.Controls.Add(this.imagesListBox);
            this.selectImagesTabPage.Location = new System.Drawing.Point(4, 22);
            this.selectImagesTabPage.Name = "selectImagesTabPage";
            this.selectImagesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.selectImagesTabPage.Size = new System.Drawing.Size(520, 526);
            this.selectImagesTabPage.TabIndex = 0;
            this.selectImagesTabPage.Text = "Select Images";
            this.selectImagesTabPage.UseVisualStyleBackColor = true;
            // 
            // refreshImageListButton
            // 
            this.refreshImageListButton.Location = new System.Drawing.Point(280, 204);
            this.refreshImageListButton.Name = "refreshImageListButton";
            this.refreshImageListButton.Size = new System.Drawing.Size(232, 44);
            this.refreshImageListButton.TabIndex = 3;
            this.refreshImageListButton.Text = "Refresh Image List";
            this.refreshImageListButton.UseVisualStyleBackColor = true;
            this.refreshImageListButton.Click += new System.EventHandler(this.refreshImageListButton_Click);
            // 
            // selectImagesInstructionsLabel
            // 
            this.selectImagesInstructionsLabel.Location = new System.Drawing.Point(8, 273);
            this.selectImagesInstructionsLabel.Name = "selectImagesInstructionsLabel";
            this.selectImagesInstructionsLabel.Size = new System.Drawing.Size(504, 210);
            this.selectImagesInstructionsLabel.TabIndex = 2;
            this.selectImagesInstructionsLabel.Text = resources.GetString("selectImagesInstructionsLabel.Text");
            // 
            // changeImagesButton
            // 
            this.changeImagesButton.Location = new System.Drawing.Point(8, 204);
            this.changeImagesButton.Name = "changeImagesButton";
            this.changeImagesButton.Size = new System.Drawing.Size(232, 44);
            this.changeImagesButton.TabIndex = 1;
            this.changeImagesButton.Text = "Change Image Folder";
            this.changeImagesButton.UseVisualStyleBackColor = true;
            this.changeImagesButton.Click += new System.EventHandler(this.changeImagesButton_Click);
            // 
            // imagesListBox
            // 
            this.imagesListBox.FormattingEnabled = true;
            this.imagesListBox.HorizontalScrollbar = true;
            this.imagesListBox.Location = new System.Drawing.Point(8, 16);
            this.imagesListBox.Name = "imagesListBox";
            this.imagesListBox.Size = new System.Drawing.Size(504, 173);
            this.imagesListBox.TabIndex = 0;
            // 
            // locationTabPage
            // 
            this.locationTabPage.Controls.Add(this.multiMonitorDisplayModsGroupBox);
            this.locationTabPage.Location = new System.Drawing.Point(4, 22);
            this.locationTabPage.Name = "locationTabPage";
            this.locationTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.locationTabPage.Size = new System.Drawing.Size(520, 526);
            this.locationTabPage.TabIndex = 1;
            this.locationTabPage.Text = "Location";
            this.locationTabPage.UseVisualStyleBackColor = true;
            // 
            // multiMonitorDisplayModsGroupBox
            // 
            this.multiMonitorDisplayModsGroupBox.Controls.Add(this.virtualMonitorRadioButton);
            this.multiMonitorDisplayModsGroupBox.Controls.Add(this.allButPrimaryRadioButton);
            this.multiMonitorDisplayModsGroupBox.Controls.Add(this.primaryOnlyRadioButton);
            this.multiMonitorDisplayModsGroupBox.Controls.Add(this.allSameRadioButton);
            this.multiMonitorDisplayModsGroupBox.Location = new System.Drawing.Point(202, 11);
            this.multiMonitorDisplayModsGroupBox.Name = "multiMonitorDisplayModsGroupBox";
            this.multiMonitorDisplayModsGroupBox.Size = new System.Drawing.Size(295, 120);
            this.multiMonitorDisplayModsGroupBox.TabIndex = 2;
            this.multiMonitorDisplayModsGroupBox.TabStop = false;
            this.multiMonitorDisplayModsGroupBox.Text = "Multi-Monitor Display Modes";
            // 
            // virtualMonitorRadioButton
            // 
            this.virtualMonitorRadioButton.Location = new System.Drawing.Point(146, 62);
            this.virtualMonitorRadioButton.Name = "virtualMonitorRadioButton";
            this.virtualMonitorRadioButton.Size = new System.Drawing.Size(134, 37);
            this.virtualMonitorRadioButton.TabIndex = 4;
            this.virtualMonitorRadioButton.TabStop = true;
            this.virtualMonitorRadioButton.Text = "Virtual Monitor";
            this.virtualMonitorRadioButton.UseVisualStyleBackColor = true;
            this.virtualMonitorRadioButton.CheckedChanged += new System.EventHandler(this.virtualMonitorRadioButton_CheckedChanged);
            // 
            // allButPrimaryRadioButton
            // 
            this.allButPrimaryRadioButton.Location = new System.Drawing.Point(146, 19);
            this.allButPrimaryRadioButton.Name = "allButPrimaryRadioButton";
            this.allButPrimaryRadioButton.Size = new System.Drawing.Size(134, 37);
            this.allButPrimaryRadioButton.TabIndex = 3;
            this.allButPrimaryRadioButton.TabStop = true;
            this.allButPrimaryRadioButton.Text = "All But Primary";
            this.allButPrimaryRadioButton.UseVisualStyleBackColor = true;
            this.allButPrimaryRadioButton.CheckedChanged += new System.EventHandler(this.allButPrimaryRadioButton_CheckedChanged);
            // 
            // primaryOnlyRadioButton
            // 
            this.primaryOnlyRadioButton.Location = new System.Drawing.Point(6, 62);
            this.primaryOnlyRadioButton.Name = "primaryOnlyRadioButton";
            this.primaryOnlyRadioButton.Size = new System.Drawing.Size(134, 37);
            this.primaryOnlyRadioButton.TabIndex = 2;
            this.primaryOnlyRadioButton.TabStop = true;
            this.primaryOnlyRadioButton.Text = "Primary Only";
            this.primaryOnlyRadioButton.UseVisualStyleBackColor = true;
            this.primaryOnlyRadioButton.CheckedChanged += new System.EventHandler(this.primaryOnlyRadioButton_CheckedChanged);
            // 
            // allSameRadioButton
            // 
            this.allSameRadioButton.Location = new System.Drawing.Point(6, 19);
            this.allSameRadioButton.Name = "allSameRadioButton";
            this.allSameRadioButton.Size = new System.Drawing.Size(134, 37);
            this.allSameRadioButton.TabIndex = 1;
            this.allSameRadioButton.TabStop = true;
            this.allSameRadioButton.Text = "All Same";
            this.allSameRadioButton.UseVisualStyleBackColor = true;
            this.allSameRadioButton.CheckedChanged += new System.EventHandler(this.allSameRadioButton_CheckedChanged);
            // 
            // sizeTabPage
            // 
            this.sizeTabPage.Location = new System.Drawing.Point(4, 22);
            this.sizeTabPage.Name = "sizeTabPage";
            this.sizeTabPage.Size = new System.Drawing.Size(520, 526);
            this.sizeTabPage.TabIndex = 3;
            this.sizeTabPage.Text = "Size";
            this.sizeTabPage.UseVisualStyleBackColor = true;
            this.sizeTabPage.Click += new System.EventHandler(this.sizeTabPage_Click);
            // 
            // animationTabPage
            // 
            this.animationTabPage.Location = new System.Drawing.Point(4, 22);
            this.animationTabPage.Name = "animationTabPage";
            this.animationTabPage.Size = new System.Drawing.Size(520, 526);
            this.animationTabPage.TabIndex = 2;
            this.animationTabPage.Text = "Animation / Graphics";
            this.animationTabPage.UseVisualStyleBackColor = true;
            // 
            // LanguageTabPage
            // 
            this.LanguageTabPage.Location = new System.Drawing.Point(4, 22);
            this.LanguageTabPage.Name = "LanguageTabPage";
            this.LanguageTabPage.Size = new System.Drawing.Size(520, 526);
            this.LanguageTabPage.TabIndex = 5;
            this.LanguageTabPage.Text = "Language";
            this.LanguageTabPage.UseVisualStyleBackColor = true;
            // 
            // dropFolderTab
            // 
            this.dropFolderTab.Controls.Add(this.useAsDropFolderCheckBox);
            this.dropFolderTab.Controls.Add(this.filePathsDataGridView);
            this.dropFolderTab.Location = new System.Drawing.Point(4, 22);
            this.dropFolderTab.Name = "dropFolderTab";
            this.dropFolderTab.Size = new System.Drawing.Size(520, 526);
            this.dropFolderTab.TabIndex = 6;
            this.dropFolderTab.Text = "Drop Folder";
            this.dropFolderTab.UseVisualStyleBackColor = true;
            // 
            // useAsDropFolderCheckBox
            // 
            this.useAsDropFolderCheckBox.AutoSize = true;
            this.useAsDropFolderCheckBox.Location = new System.Drawing.Point(16, 11);
            this.useAsDropFolderCheckBox.Name = "useAsDropFolderCheckBox";
            this.useAsDropFolderCheckBox.Size = new System.Drawing.Size(313, 17);
            this.useAsDropFolderCheckBox.TabIndex = 1;
            this.useAsDropFolderCheckBox.Text = "Use Logo as a Drop Folder (Responds to Input, Drag && Drop)";
            this.useAsDropFolderCheckBox.UseVisualStyleBackColor = true;
            this.useAsDropFolderCheckBox.CheckedChanged += new System.EventHandler(this.useAsDropFolderCheckBox_CheckedChanged);
            // 
            // filePathsDataGridView
            // 
            this.filePathsDataGridView.AllowUserToAddRows = false;
            this.filePathsDataGridView.AllowUserToDeleteRows = false;
            this.filePathsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.filePathsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.folderName,
            this.folderPath,
            this.browseButton});
            this.filePathsDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.filePathsDataGridView.Location = new System.Drawing.Point(0, 54);
            this.filePathsDataGridView.Name = "filePathsDataGridView";
            this.filePathsDataGridView.RowHeadersVisible = false;
            this.filePathsDataGridView.Size = new System.Drawing.Size(520, 472);
            this.filePathsDataGridView.TabIndex = 0;
            this.filePathsDataGridView.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.filePathsDataGridView_RowLeave);
            this.filePathsDataGridView.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.filePathsDataGridView_RowValidated);
            this.filePathsDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.filePathsDataGridView_CellContentClick);
            // 
            // folderName
            // 
            this.folderName.HeaderText = "Folder Name";
            this.folderName.Name = "folderName";
            this.folderName.Width = 150;
            // 
            // folderPath
            // 
            this.folderPath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.folderPath.HeaderText = "Folder Path";
            this.folderPath.Name = "folderPath";
            // 
            // browseButton
            // 
            this.browseButton.HeaderText = "Browse";
            this.browseButton.Name = "browseButton";
            this.browseButton.ReadOnly = true;
            this.browseButton.Text = ".....";
            this.browseButton.Width = 75;
            // 
            // TargetFolderBrowserDialog
            // 
            this.TargetFolderBrowserDialog.ShowNewFolderButton = false;
            // 
            // filePathsContextMenuStrip
            // 
            this.filePathsContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyMoveToolStripMenuItem1,
            this.test1ToolStripMenuItem,
            this.test2ToolStripMenuItem});
            this.filePathsContextMenuStrip.Name = "filePathsContextMenuStrip";
            this.filePathsContextMenuStrip.Size = new System.Drawing.Size(147, 70);
            this.filePathsContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.filePathsContextMenuStrip_Opening);
            // 
            // copyMoveToolStripMenuItem1
            // 
            this.copyMoveToolStripMenuItem1.Enabled = false;
            this.copyMoveToolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.copyMoveToolStripMenuItem1.Name = "copyMoveToolStripMenuItem1";
            this.copyMoveToolStripMenuItem1.Size = new System.Drawing.Size(146, 22);
            this.copyMoveToolStripMenuItem1.Text = "Copy/Move";
            // 
            // test1ToolStripMenuItem
            // 
            this.test1ToolStripMenuItem.Name = "test1ToolStripMenuItem";
            this.test1ToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.test1ToolStripMenuItem.Tag = "C:\\";
            this.test1ToolStripMenuItem.Text = "Test 1";
            this.test1ToolStripMenuItem.Click += new System.EventHandler(this.filePathToolStripMenuItem_Click);
            // 
            // test2ToolStripMenuItem
            // 
            this.test2ToolStripMenuItem.Name = "test2ToolStripMenuItem";
            this.test2ToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.test2ToolStripMenuItem.Tag = "D:\\";
            this.test2ToolStripMenuItem.Text = "Test 2";
            this.test2ToolStripMenuItem.Click += new System.EventHandler(this.filePathToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(528, 552);
            this.Controls.Add(this.settingsTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Opacity = 0;
            this.ShowInTaskbar = false;
            this.Text = "DropFolder";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.MainFormContextMenuStrip.ResumeLayout(false);
            this.settingsTabControl.ResumeLayout(false);
            this.selectImagesTabPage.ResumeLayout(false);
            this.locationTabPage.ResumeLayout(false);
            this.multiMonitorDisplayModsGroupBox.ResumeLayout(false);
            this.sizeTabPage.ResumeLayout(false);
            this.animationTabPage.ResumeLayout(false);
            this.LanguageTabPage.ResumeLayout(false);
            this.dropFolderTab.ResumeLayout(false);
            this.dropFolderTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.filePathsDataGridView)).EndInit();
            this.filePathsContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip MainFormContextMenuStrip;
        private System.Windows.Forms.NotifyIcon MainFormTrayIcon;
        private System.Windows.Forms.TabControl settingsTabControl;
        private System.Windows.Forms.TabPage selectImagesTabPage;
        private System.Windows.Forms.TabPage locationTabPage;
        private System.Windows.Forms.ListBox imagesListBox;
        private System.Windows.Forms.Button changeImagesButton;
        private System.Windows.Forms.TabPage animationTabPage;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.GroupBox multiMonitorDisplayModsGroupBox;
        private System.Windows.Forms.TabPage sizeTabPage;
        private System.Windows.Forms.RadioButton virtualMonitorRadioButton;
        private System.Windows.Forms.RadioButton allButPrimaryRadioButton;
        private System.Windows.Forms.RadioButton primaryOnlyRadioButton;
        private System.Windows.Forms.RadioButton allSameRadioButton;
        private System.Windows.Forms.Label selectImagesInstructionsLabel;
        private System.Windows.Forms.Button refreshImageListButton;
        private System.Windows.Forms.TabPage LanguageTabPage;
        private System.Windows.Forms.ToolStripMenuItem hideLogosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog TargetFolderBrowserDialog;
        private System.Windows.Forms.TabPage dropFolderTab;
        private System.Windows.Forms.DataGridView filePathsDataGridView;
        private System.Windows.Forms.ContextMenuStrip filePathsContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem test1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem test2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyMoveToolStripMenuItem1;
        private System.Windows.Forms.DataGridViewTextBoxColumn folderName;
        private System.Windows.Forms.DataGridViewTextBoxColumn folderPath;
        private System.Windows.Forms.DataGridViewButtonColumn browseButton;
        private System.Windows.Forms.FolderBrowserDialog folderPathsFolderBrowserDialog;
        private System.Windows.Forms.CheckBox useAsDropFolderCheckBox;
        private System.Windows.Forms.ToolStripMenuItem dropFolderModeToolStripMenuItem;
    }
}