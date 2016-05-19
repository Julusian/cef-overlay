// Custom Desktop Logo 2.2 - By: 2008 Eric Wong
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
        
    }

}
