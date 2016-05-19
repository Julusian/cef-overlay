﻿// Custom Desktop Logo 2.2 - By: 2008 Eric Wong
// October 18th, 2008
// Custom Desktop Logo is open source software licensed under GNU GENERAL PUBLIC LICENSE V3. 
// Use it as you wish, but you must share your source code under the terms of use of the license.

// Custom Desktop Logo allows you to create custom static and animated logos from PNG images.
// Version 2.0 adds the drop folder capabilities.
// Version 2.2 adds the ability to use Windows default move/copy dialogs and fixes the unicode compatibility.

// Copyright (C) 2008 by Eric Wong. 
// VideoInPicture@gmail.com
// http://customdesktoplogo.wikidot.com
// http://easyunicodepaster.wikidot.com
// http://circledock.wikidot.com
// http://videoinpicture.wikidot.com
// http://webcamsignature.wikidot.com
// http://windowextractor.wikidot.com

// Uses AMS.Profile from http://www.codeproject.com/KB/cs/readwritexmlini.aspx for .ini file operations (Open source, non-specific license)
// Uses hotkey selector component from http://www.codeproject.com/KB/miscctrl/systemhotkey.aspx (Open source, non-specific license)

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;

using CefSharp;
using ImageOperations;
using MemoryManagement;
using Hook;


namespace CustomDesktopLogo
{

    public enum MultiMonitorDisplayModes
    {
        AllSame,
        DisplayOnPrimaryOnly,
        DisplayOnAllButPrimary,
        TreatMonitorsAsOneScreen
    }

    public enum FileLocationActions
    {
        Move,
        Copy,
        Open,
        AddTargetFolder
    }

    public partial class MainForm : Form
    {
        #region Variables

        // The directory and file names used to store the resources for the program.
        static readonly string imagesDirectoryName = @"Images";
        static readonly string systemFilesDirectoryName = @"System";
        static readonly string settingsDirectoryName = @"Settings";
        static readonly string configINIFileName = @"Config.ini";
        static readonly int numFolderPaths = 20;

        /// <summary>
        /// The general settings for the program.
        /// </summary>
        public static SettingsLoader.SettingsLoader settingsINI;

        /// <summary>
        /// The list of all the logos currently active.
        /// </summary>
        static List<LogoObject> allLogos = new List<LogoObject>();

        /// <summary>
        /// Stores all the images used for the logos.
        /// </summary>
        static List<Bitmap> imageBitmaps = new List<Bitmap>();

       
        static bool loaded = false;

        static Hooks windowsHook = new Hooks();

        // These delegates enables asynchronous calls 
        delegate void ShowHideCallback();
        delegate void UpdatePositionsCallback();
        delegate void AnimationCallback();
        delegate void CloseLogoCallback();
        delegate void UpdateSizeOpacityCallback();

        private static MainForm instance;
        public static MainForm Instance
        {
            get
            {
                return instance;
            }
        }

        #endregion

        #region Constructor and Initialization

        static MainForm()
        {
             instance = new MainForm();
        }

        /// <summary>

        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            Control.CheckForIllegalCrossThreadCalls = false;
            checkSystemFoldersExist();

            // Load settings from files
            settingsINI = new SettingsLoader.SettingsLoader(Application.StartupPath + Path.DirectorySeparatorChar + systemFilesDirectoryName +
                Path.DirectorySeparatorChar + settingsDirectoryName + Path.DirectorySeparatorChar + configINIFileName);
            loadLanguage();

            DoubleBuffered = true;

            // We require this hook to correct a Windows bug where a topmost window will become not topmost in some cases
            // when other programs refresh the screen.
            windowsHook.OnForegroundWindowChanged += new OnForegroundWindowChangedDelegate(window_ForegroundChanged);
            GC.KeepAlive(windowsHook);
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            this.Hide();
            this.ShowInTaskbar = true;
            this.Opacity = 1.0;
            MemoryUtility.ClearUnusedMemory();
        }

        private void checkSystemFoldersExist()
        {
            // Make sure the "System" folder exists
            if (!Directory.Exists(Application.StartupPath + Path.DirectorySeparatorChar + systemFilesDirectoryName))
            {
                try
                {
                    Directory.CreateDirectory(Application.StartupPath + Path.DirectorySeparatorChar + systemFilesDirectoryName);
                }
                catch (Exception)
                {
                    MessageBox.Show(Application.StartupPath + Path.DirectorySeparatorChar + systemFilesDirectoryName + @" is missing.", @"Custom Desktop Logo");
                }
            }

            // Make sure the "Images" folder exists
            if (!Directory.Exists(Application.StartupPath + Path.DirectorySeparatorChar + systemFilesDirectoryName + Path.DirectorySeparatorChar
                + imagesDirectoryName))
            {
                try
                {
                    Directory.CreateDirectory(Application.StartupPath + Path.DirectorySeparatorChar + systemFilesDirectoryName + Path.DirectorySeparatorChar
                        + imagesDirectoryName);
                }
                catch (Exception)
                {
                    MessageBox.Show(Application.StartupPath + Path.DirectorySeparatorChar + systemFilesDirectoryName + Path.DirectorySeparatorChar
                        + imagesDirectoryName + @" is missing.", @"Custom Desktop Logo");
                }
            }
            
            // Make sure the "Settings" folder exists
            if (!Directory.Exists(Application.StartupPath + Path.DirectorySeparatorChar + systemFilesDirectoryName + Path.DirectorySeparatorChar
                + settingsDirectoryName))
            {
                try
                {
                    Directory.CreateDirectory(Application.StartupPath + Path.DirectorySeparatorChar + systemFilesDirectoryName + Path.DirectorySeparatorChar
                        + settingsDirectoryName);
                }
                catch (Exception)
                {
                    MessageBox.Show(Application.StartupPath + Path.DirectorySeparatorChar + systemFilesDirectoryName + Path.DirectorySeparatorChar
                        + settingsDirectoryName + @" is missing.", @"Custom Desktop Logo");
                }
            }
        }

        #endregion

        #region Main Methods

        private void MainForm_Load(object sender, EventArgs e)
        {
            MainFormTrayIcon.Visible = true;

            loadLanguage();
            loadImageList();

            switch (settingsINI.LogoProperties.multiMonitorDisplayMode)
            {
                default:
                    allSameRadioButton.Checked = true;
                    break;
            }
            
            TargetFolderBrowserDialog.SelectedPath = Application.StartupPath + Path.DirectorySeparatorChar + systemFilesDirectoryName
                + Path.DirectorySeparatorChar + imagesDirectoryName + Path.DirectorySeparatorChar;

            string[] directoryList = {};

            try
            {
                directoryList = Directory.GetDirectories(Application.StartupPath + Path.DirectorySeparatorChar + systemFilesDirectoryName
                    + Path.DirectorySeparatorChar + imagesDirectoryName + Path.DirectorySeparatorChar);
            }
            catch (Exception)
            { }

            if (directoryList != null && directoryList.Length >= 1)
            {
                TargetFolderBrowserDialog.SelectedPath = directoryList[0];
            }

            // For the Folder Paths tab
            useAsDropFolderCheckBox.Checked = settingsINI.FolderPaths.useAsDropFolder;

            filePathsDataGridView.Rows.Add(numFolderPaths);

            for (int i = 0; i < numFolderPaths; i++)
            {
                filePathsDataGridView[0, i].Value = settingsINI.FolderPaths.folderPaths[i].displayName;
                filePathsDataGridView[1, i].Value = settingsINI.FolderPaths.folderPaths[i].path;
            }

            populateFilePathsContextMenuStrip(this.filePathsContextMenuStrip, FileLocationActions.Copy);

            loaded = true;
        }

        private void loadImageList()
        {
            imagesListBox.Items.Clear();
            imageBitmaps.Clear();

            try
            {
                string[] imageFileDirectory;
                if (settingsINI.LogoProperties.path.StartsWith(@"." + Path.DirectorySeparatorChar))
                    imageFileDirectory = System.IO.Directory.GetFiles(Application.StartupPath + settingsINI.LogoProperties.path.Substring(1));
                else
                    imageFileDirectory = System.IO.Directory.GetFiles(settingsINI.LogoProperties.path);

                int counter = 0;
                foreach (string aFile in imageFileDirectory)
                {
                    if (aFile.ToUpper().EndsWith(@"PNG"))
                    {
                        Bitmap anImage;

                        try
                        {
                            anImage = new Bitmap(aFile);
                            imageBitmaps.Add(anImage);
                            imagesListBox.Items.Add(aFile);
                            counter++;
                        }
                        catch (Exception)
                        { }
                    }

                    // Prevent the program from freezing the computer and taking too much memory.
                    if (counter > 20)
                    {
                        counter = 0;
                        GC.Collect();
                        Pinvoke.Win32.PROCESS_MEMORY_COUNTERS memoryCounter = new Pinvoke.Win32.PROCESS_MEMORY_COUNTERS();
                        Pinvoke.Win32.GetProcessMemoryInfo(Pinvoke.Win32.GetCurrentProcess(), out memoryCounter, Marshal.SizeOf(memoryCounter));

                        if (memoryCounter.WorkingSetSize > 100000000)
                        {
                            if (MessageBox.Show("Too much memory. Continue?", "Error custom logo", MessageBoxButtons.YesNo) == DialogResult.No)
                            {
                                imagesListBox.Items.Clear();
                                imageBitmaps.Clear();
                                GC.Collect();

                                settingsINI.LogoProperties.path = @"";
                                settingsINI.SetEntry("LogoProperties", "path", @"");
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            { 
            }

            if (imageBitmaps.Count <= 0)
                imageBitmaps.Add((Bitmap)FancyText.ImageFromText(@"?????", new Font(System.Drawing.FontFamily.GenericSansSerif, 20, FontStyle.Bold), Color.Black, Color.White, 6, 10));
            
            loadLogos();

            GC.Collect();
            MemoryManagement.MemoryUtility.ClearUnusedMemory();
        }

        private void closeAllLogos()
        {
            for (int i = 0; i < allLogos.Count; i++)
            {
                if (allLogos[i].InvokeRequired)
                {
                    CloseLogoCallback d = new CloseLogoCallback(closeAllLogos);
                    allLogos[i].Invoke(d, new object[] { });
                }
                else
                {
                    allLogos[i].Dispose();
                } 
            }

            allLogos.Clear();
        }

        private void loadLogos()
        {
            closeAllLogos();

            if (imageBitmaps == null || imageBitmaps.Count <= 0)
                return;

            switch (settingsINI.LogoProperties.multiMonitorDisplayMode)
            {
                default:
                    allLogos.Add(new LogoObject(imageBitmaps[0], new Point(0, 0), 255));
                    break;
            }

            hideLogosToolStripMenuItem.Checked = false;

            // Set whether the logos respond to input
            for (int i = 0; allLogos != null && i < allLogos.Count; i++)
            {
                try
                {
                    allLogos[i].SetTransparencyToInput(settingsINI.FolderPaths.useAsDropFolder);
                }
                catch (Exception)
                { }
            }

        }

        private void window_ForegroundChanged(IntPtr hWnd)
        {
            for (int i = 0; allLogos != null && i < allLogos.Count; i++)
            {
                try
                {
                    allLogos[i].SetZLevel();
                }
                catch (Exception)
                { }
            }
        }

        #endregion

        #region Tray Icon Context Menu

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            settingsTabControl.Invalidate();
            this.Show();
            this.BringToFront();
        }

        private void MainFormTrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            settingsTabControl.Invalidate();
            this.Show();
            this.BringToFront();
        }

        public void dropFolderModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            useAsDropFolderCheckBox.Checked = dropFolderModeToolStripMenuItem.Checked;
        }

        public bool useAsDropFolderCheckBoxChecked
        {
            get
            {
                return useAsDropFolderCheckBox.Checked;
            }
            set
            {
                useAsDropFolderCheckBox.Checked = value;
            }
        }

        public void hideLogosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (hideLogosToolStripMenuItem.Checked == true)
            {
                hideAllLogos();
            }
            else
            {
                showAllLogos();
            }
        }

        public bool hideLogosToolStripMenuItemChecked
        {
            get
            {
                return hideLogosToolStripMenuItem.Checked;
            }
            set
            {
                hideLogosToolStripMenuItem.Checked = value;
            }
        }

        private void hideAllLogos()
        {
            for (int i = 0; i < allLogos.Count; i++)
            {
                if (allLogos[i].InvokeRequired)
                {
                    ShowHideCallback d = new ShowHideCallback(hideAllLogos);
                    allLogos[i].Invoke(d, new object[] { });
                }
                else
                {
                    allLogos[i].Hide();
                }
            }
        }

        private void showAllLogos()
        {
            for (int i = 0; i < allLogos.Count; i++)
            {
                if (allLogos[i].InvokeRequired)
                {
                    ShowHideCallback d = new ShowHideCallback(showAllLogos);
                    allLogos[i].Invoke(d, new object[] { });
                }
                else
                {
                    allLogos[i].Show();
                    allLogos[i].WindowState = FormWindowState.Normal;
                    allLogos[i].Show();
                    allLogos[i].BringToFront();
                }
            }
        }

        private void MainFormContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            dropFolderModeToolStripMenuItem.Checked = useAsDropFolderCheckBox.Checked;
            //if (AnimationTimer.Enabled == false)
            //    MemoryUtility.ClearUnusedMemory();
        }

        private void MainFormContextMenuStrip_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
        }

        #endregion

        #region Miscellaneous

        /// <summary>
        /// Finalizes things before closing.
        /// </summary>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
            MainFormTrayIcon.Dispose();
            Environment.Exit(0);
            //closeAllLogos();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Select(true, true);
                this.Hide();

                //if (AnimationTimer.Enabled == false)
                //    MemoryUtility.ClearUnusedMemory();
            }
        }

        #endregion

        #region Language Methods

        private void loadLanguage()
        {
            this.Text = "Custom logo";
            this.MainFormTrayIcon.Text = "Custom logo";

            quitToolStripMenuItem.Text = "Quit";
            hideLogosToolStripMenuItem.Text = "Hide Logo";
            settingsToolStripMenuItem.Text = "Settings";
            dropFolderModeToolStripMenuItem.Text = "Drop mode";

            // Select Images tab
            selectImagesTabPage.Text = "Select images";
            changeImagesButton.Text = "Change folder";
            refreshImageListButton.Text = "Refresh list";
            selectImagesInstructionsLabel.Text = "SELECT";

            // Location tab
            locationTabPage.Text = "Locations";
            multiMonitorDisplayModsGroupBox.Text = "Monitor modes";
            allSameRadioButton.Text = "All same";
            primaryOnlyRadioButton.Text = "Primary only";
            allButPrimaryRadioButton.Text = "All but primary";
            virtualMonitorRadioButton.Text = "Virtual monitor";
            
            // Size tab
            sizeTabPage.Text = "Size";

            // Animation / Graphics tab
            animationTabPage.Text = "Animation";
        }
        
        #endregion

        #region Change Image List

        private void changeImagesButton_Click(object sender, EventArgs e)
        {
            if (loaded == false)
                return;

            if (TargetFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                String NewFilePath;
                if (TargetFolderBrowserDialog.SelectedPath.StartsWith(Application.StartupPath + Path.DirectorySeparatorChar))
                {
                    NewFilePath = @"." + TargetFolderBrowserDialog.SelectedPath.Substring(Application.StartupPath.Length);
                }
                else
                {
                    NewFilePath = TargetFolderBrowserDialog.SelectedPath;
                }

                settingsINI.SetEntry("LogoProperties", "path", NewFilePath);
                settingsINI.LogoProperties.path = NewFilePath;

                loadImageList();
            }
        }

        private void refreshImageListButton_Click(object sender, EventArgs e)
        {
            loadImageList();
        }

        #endregion

        #region Window Level and Multi-Monitor Display Modes
        
        private void allSameRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (loaded == false)
                return;

            if (allSameRadioButton.Checked == false)
                return;

            settingsINI.SetEntry("LogoProperties", "multiMonitorDisplayMode", MultiMonitorDisplayModes.AllSame.ToString());
            settingsINI.LogoProperties.multiMonitorDisplayMode = MultiMonitorDisplayModes.AllSame;

            loadLogos();
        }

        private void allButPrimaryRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (loaded == false)
                return;

            if (allButPrimaryRadioButton.Checked == false)
                return;

            settingsINI.SetEntry("LogoProperties", "multiMonitorDisplayMode", MultiMonitorDisplayModes.DisplayOnAllButPrimary.ToString());
            settingsINI.LogoProperties.multiMonitorDisplayMode = MultiMonitorDisplayModes.DisplayOnAllButPrimary;

            loadLogos();
        }

        private void primaryOnlyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (loaded == false)
                return;

            if (primaryOnlyRadioButton.Checked == false)
                return;

            settingsINI.SetEntry("LogoProperties", "multiMonitorDisplayMode", MultiMonitorDisplayModes.DisplayOnPrimaryOnly.ToString());
            settingsINI.LogoProperties.multiMonitorDisplayMode = MultiMonitorDisplayModes.DisplayOnPrimaryOnly;

            loadLogos();
        }

        private void virtualMonitorRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (loaded == false)
                return;

            if (virtualMonitorRadioButton.Checked == false)
                return;

            settingsINI.SetEntry("LogoProperties", "multiMonitorDisplayMode", MultiMonitorDisplayModes.TreatMonitorsAsOneScreen.ToString());
            settingsINI.LogoProperties.multiMonitorDisplayMode = MultiMonitorDisplayModes.TreatMonitorsAsOneScreen;

            loadLogos();
        }

        #endregion

        #region Animation / Graphics Settings
        
        private void sizeTabPage_Click(object sender, EventArgs e)
        {
            this.Select(true, true);
        }

        #endregion

        public void filePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem sendToolStripMenuItem = (ToolStripMenuItem)sender;

            if (System.IO.Directory.Exists((String)sendToolStripMenuItem.Tag))
            {
                if (action == FileLocationActions.Open)
                {
                    try
                    {
                        System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo((String)sendToolStripMenuItem.Tag);
                        //startInfo.WindowStyle = ProcessWindowStyle.Normal;
                        //startInfo.Arguments = argsParams;
                        startInfo.CreateNoWindow = false;
                        startInfo.ErrorDialog = true;
                        //try
                        //{
                        //    LogoObject senderObject = (LogoObject)sender;
                        //    startInfo.ErrorDialogParentHandle = senderObject.Parent.Handle;
                        //}
                        //catch (Exception)
                        //{
                        //    startInfo.ErrorDialogParentHandle = IntPtr.Zero;
                        //}

                        startInfo.UseShellExecute = true;

                        System.Diagnostics.Process.Start(startInfo);
                    }
                    catch (Exception ee1)
                    {
                    }
                }
                else
                {
                    moveCopyFiles performActionOnFiles = new moveCopyFiles(files, (String)sendToolStripMenuItem.Tag, action);
                    Thread performAction = new Thread(new ThreadStart(performActionOnFiles.performAction));
                    performAction.Start();
                }
            }
            else
            {
                MessageBox.Show((String)sendToolStripMenuItem.Tag + @" :" + "Folder not exist", "Custom logo");
            }
        }

        private void useAsDropFolderCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (loaded == false)
                return;

            settingsINI.FolderPaths.useAsDropFolder = useAsDropFolderCheckBox.Checked;
            settingsINI.SetEntry("FolderPaths", "useAsDropFolder", useAsDropFolderCheckBox.Checked.ToString());

            // Set whether the logos respond to input
            for (int i = 0; allLogos != null && i < allLogos.Count; i++)
            {
                try
                {
                    allLogos[i].SetTransparencyToInput(settingsINI.FolderPaths.useAsDropFolder);
                }
                catch (Exception)
                { }
            }
        }
        

        String[] files = { };
        FileLocationActions action = FileLocationActions.Copy;

        public void moveCopyToFilePathOptions(LogoObject sender, String[] filesList, FileLocationActions fileAction)
        {
            files = filesList;
            action = fileAction;

            populateFilePathsContextMenuStrip(sender.filePathsContextMenuStrip, fileAction);
            sender.Activate();
            sender.showContextMenu();
        }

        public void addTargetFolder(String[] newTargetFolders)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            settingsTabControl.Invalidate();
            settingsTabControl.SelectedTab = dropFolderTab;
            this.BringToFront();

            int index = 0;

            while (index < newTargetFolders.Length && !Directory.Exists(newTargetFolders[index]))
            {
                index++;
            }

            for (int i = 0; i < filePathsDataGridView.RowCount && index < newTargetFolders.Length; i++)
            {
                if ((filePathsDataGridView[0, i].Value == null || filePathsDataGridView[0, i].Value.ToString().Length <= 0) &&
                    (filePathsDataGridView[1, i].Value == null || filePathsDataGridView[1, i].Value.ToString().Length <= 0))
                {
                    filePathsDataGridView[1, i].Value = newTargetFolders[index];
                    DataGridViewCellEventArgs e = new DataGridViewCellEventArgs(1, i);
                    filePathsDataGridView_RowValidated(this, e);
                    index++;

                    while (index < newTargetFolders.Length && !Directory.Exists(newTargetFolders[index]))
                    {
                        index++;
                    }

                    if (index >= newTargetFolders.Length)
                    {                      
                        filePathsDataGridView[1, i].Selected = true;   
                        break;
                    }
                }
            }
        }

        private void filePathsDataGridView_RowLeave(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void filePathsContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            populateFilePathsContextMenuStrip(this.filePathsContextMenuStrip, action);
        }

        public void populateFilePathsContextMenuStrip(ContextMenuStrip aFilePathsContextMenuStrip, FileLocationActions fileAction)
        {
            aFilePathsContextMenuStrip.Items.Clear();

            ToolStripMenuItem copyMoveToolStripMenuItem = new ToolStripMenuItem();
            copyMoveToolStripMenuItem.Name = "newToolStripMenuItem";
            copyMoveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);

            if (action == FileLocationActions.Copy)
                copyMoveToolStripMenuItem.Text = @"Copy To";
            else if (action == FileLocationActions.Move)
                copyMoveToolStripMenuItem.Text = @"Move To";
            else
                copyMoveToolStripMenuItem.Text = @"Open";

            copyMoveToolStripMenuItem.Enabled = false;
            copyMoveToolStripMenuItem.Font = new Font(FontFamily.GenericSansSerif, (float)12, FontStyle.Bold);

            aFilePathsContextMenuStrip.Items.Add(copyMoveToolStripMenuItem);


            for (int i = 0; i < settingsINI.FolderPaths.folderPaths.Count; i++)
            {
                String folderPath = settingsINI.FolderPaths.folderPaths[i].path;
                String displayName = settingsINI.FolderPaths.folderPaths[i].displayName;

                if (folderPath != null && folderPath.Length > 0)
                {
                    ToolStripMenuItem newToolStripMenuItem = new ToolStripMenuItem();
                    newToolStripMenuItem.Name = "newToolStripMenuItem";
                    newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);

                    if (displayName != null && displayName.Length > 0)
                        newToolStripMenuItem.Text = displayName;
                    else
                        newToolStripMenuItem.Text = folderPath;

                    newToolStripMenuItem.Tag = folderPath;

                    newToolStripMenuItem.Click += new System.EventHandler(this.filePathToolStripMenuItem_Click);
                    aFilePathsContextMenuStrip.Items.Add(newToolStripMenuItem);
                }
            }
        }

        private void filePathsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                folderPathsFolderBrowserDialog.SelectedPath = (String)filePathsDataGridView[1, e.RowIndex].Value;

                if (folderPathsFolderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    filePathsDataGridView[1, e.RowIndex].Value = folderPathsFolderBrowserDialog.SelectedPath;

                    filePathsDataGridView_RowValidated(sender, e);

                    //String theSection = @"FolderPaths";
                    //settingsINI.SetEntry(theSection, e.RowIndex.ToString() + @"-FolderPath", filePathsDataGridView[1, e.RowIndex].Value.ToString());
                    //settingsINI.SetEntry(theSection, e.RowIndex.ToString() + @"-DisplayName", filePathsDataGridView[0, e.RowIndex].Value.ToString());

                    //SettingsInformation.FolderPathItem newFolderPathItem = new SettingsInformation.FolderPathItem();
                    //newFolderPathItem.path = settingsINI.GetEntry(theSection, e.RowIndex.ToString() + @"-FolderPath");
                    //newFolderPathItem.displayName = settingsINI.GetEntry(theSection, e.RowIndex.ToString() + @"-DisplayName");
                    //settingsINI.FolderPaths.folderPaths[e.RowIndex] = newFolderPathItem;
                }
            }
        }

        private void filePathsDataGridView_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (filePathsDataGridView[0, e.RowIndex].Value == null)
                filePathsDataGridView[0, e.RowIndex].Value = "";

            if (filePathsDataGridView[1, e.RowIndex].Value == null)
                filePathsDataGridView[1, e.RowIndex].Value = "";

            //Console.WriteLine("Row Index: " + e.RowIndex + filePathsDataGridView[0, e.RowIndex].Value.ToString());

            String theSection = @"FolderPaths";
            settingsINI.SetEntry(theSection, e.RowIndex.ToString() + @"-FolderPath", filePathsDataGridView[1, e.RowIndex].Value.ToString());
            settingsINI.SetEntry(theSection, e.RowIndex.ToString() + @"-DisplayName", filePathsDataGridView[0, e.RowIndex].Value.ToString());

            SettingsInformation.FolderPathItem newFolderPathItem = new SettingsInformation.FolderPathItem();
            newFolderPathItem.path = settingsINI.GetEntry(theSection, e.RowIndex.ToString() + @"-FolderPath");
            newFolderPathItem.displayName = settingsINI.GetEntry(theSection, e.RowIndex.ToString() + @"-DisplayName");
            settingsINI.FolderPaths.folderPaths[e.RowIndex] = newFolderPathItem;
        }
    }

    public class moveCopyFiles
    {
        String[] files = { };
        String destinationFolder = "";
        FileLocationActions action = FileLocationActions.Copy;

        public moveCopyFiles(String[] filesList, String destination, FileLocationActions fileAction)
        {
            files = (String[])filesList.Clone();
            destinationFolder = (String)destination.Clone();
            action = fileAction;
        }

        public void performAction()
        {
            if (destinationFolder[destinationFolder.Length - 1] != Path.DirectorySeparatorChar) destinationFolder += Path.DirectorySeparatorChar;

            if (action == FileLocationActions.Copy)
            {
                StringBuilder filesString = new StringBuilder();
                for (int i = 0; i < files.Length; i++)
                {
                    filesString.Append(files[i] + '\0');
                    
                    // Old Method of copying - no dialogs
                    //if (System.IO.Directory.Exists(files[i]))
                    //{
                    //    copyDirectory(files[i], destinationFolder + Path.GetFileName(files[i]));
                    //}
                    //else if (System.IO.File.Exists(files[i]))
                    //{
                    //    try
                    //    {
                    //        System.IO.File.Copy(files[i], destinationFolder + Path.GetFileName(files[i]), true);
                    //    }
                    //    catch (Exception e)
                    //    {
                    //        Debug.WriteLine("Error copying file: " + e.Message);
                    //    }
                    //}
                }
                shCopyFiles(filesString.ToString(), destinationFolder);
            }
            else
            {
                StringBuilder filesString = new StringBuilder();
                for (int i = 0; i < files.Length; i++)
                {
                    filesString.Append(files[i] + '\0');
                    
                    // Old method of moving - no dialogs
                    //if (System.IO.Directory.Exists(files[i]))
                    //{
                    //    moveDirectory(files[i], destinationFolder + Path.GetFileName(files[i]));
                    //    System.IO.Directory.Delete(files[i]);
                    //}
                    //else if (System.IO.File.Exists(files[i]))
                    //{
                    //    try
                    //    {
                    //        System.IO.File.Copy(files[i], destinationFolder + Path.GetFileName(files[i]), true);
                    //        System.IO.File.Delete(files[i]);
                    //    }
                    //    catch (Exception e)
                    //    {
                    //        Debug.WriteLine("Error moving file: " + e.Message);
                    //    }
                    //}
                }
                shMoveFiles(filesString.ToString(), destinationFolder);
            }
        }

        // Function to copy directory structure recursively
        public void copyDirectory(string Src, string Dst)
        {
            //Application.DoEvents();
            String[] Files;

            if (Dst[Dst.Length - 1] != Path.DirectorySeparatorChar) Dst += Path.DirectorySeparatorChar;
            if (!Directory.Exists(Dst))
            {
                try
                {
                    Directory.CreateDirectory(Dst);
                }
                catch (Exception e)
                {
                    Debug.WriteLine("Error in CreateDirectory function (copyDirectory): " + e.Message);
                }
            }
            Files = Directory.GetFileSystemEntries(Src);
            foreach (string Element in Files)
            {
                // Sub directories
                if (Directory.Exists(Element))
                {
                    copyDirectory(Element, Dst + Path.GetFileName(Element));
                }
                // Files in directory
                else
                {
                    try
                    {
                        File.Copy(Element, Dst + Path.GetFileName(Element), true);
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine("Error in copyDirectory function: " + e.Message);
                    }
                }
            }
        }

        // Function to move directory structure recursively
        public void moveDirectory(string Src, string Dst)
        {
            //Application.DoEvents();
            String[] Files;

            if (Dst[Dst.Length - 1] != Path.DirectorySeparatorChar) Dst += Path.DirectorySeparatorChar;
            if (!Directory.Exists(Dst))
            {
                try
                {
                    Directory.CreateDirectory(Dst);
                }
                catch (Exception e)
                {
                    Debug.WriteLine("Error in CreateDirectory function (copyDirectory): " + e.Message);
                }
            }
            Files = Directory.GetFileSystemEntries(Src);
            foreach (string Element in Files)
            {
                // Sub directories
                if (Directory.Exists(Element))
                {
                    moveDirectory(Element, Dst + Path.GetFileName(Element));
                }
                // Files in directory
                else
                {
                    try
                    {
                        File.Copy(Element, Dst + Path.GetFileName(Element), true);
                        File.Delete(Element);
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine("Error in moveDirectory function: " + e.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Copies the files from source to target, showing the Progress Dialog
        /// </summary>
        /// <param name="sSource">Source from where the File(s) will be copied</param>
        /// <param name="sTarget">Target or Destination</param>
        /// <returns>True or False</returns>
        public void shCopyFiles(string sSource, string sTarget)
        {
            try
            {         
                Pinvoke.Win32.SHFILEOPSTRUCT _ShFile = new Pinvoke.Win32.SHFILEOPSTRUCT();
                _ShFile.wFunc = Pinvoke.Win32.FO_Func.FO_COPY;
                _ShFile.fFlags = (ushort)Pinvoke.Win32.FO_Func.FOF_ALLOWUNDO;
                _ShFile.pFrom = sSource;
                _ShFile.pTo = sTarget;
                Pinvoke.Win32.SHFileOperation(ref _ShFile);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);            
            }         
        }

        /// <summary>
        /// Moves the files from source to target, showing the Progress Dialog
        /// </summary>
        /// <param name="sSource">Source from where the File(s) will be moved</param>
        /// <param name="sTarget">Target or Destination</param>
        /// <returns>True or False</returns>
        public void shMoveFiles(string sSource, string sTarget)
        {
            try
            {
                Pinvoke.Win32.SHFILEOPSTRUCT _ShFile = new Pinvoke.Win32.SHFILEOPSTRUCT();
                _ShFile.wFunc = Pinvoke.Win32.FO_Func.FO_MOVE;
                _ShFile.fFlags = (ushort)Pinvoke.Win32.FO_Func.FOF_ALLOWUNDO;
                _ShFile.pFrom = sSource;
                _ShFile.pTo = sTarget;
                Pinvoke.Win32.SHFileOperation(ref _ShFile);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
    }

}
