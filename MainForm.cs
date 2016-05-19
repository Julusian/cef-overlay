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
using System.Windows.Forms;
using System.IO;

using CefSharp;
using CEFOverlay.Util;
using CEFOverlay.Settings;
using Hook;


namespace CEFOverlay
{
    public partial class MainForm : Form
    {
        #region Variables

        // The directory and file names used to store the resources for the program.
        static readonly string systemFilesDirectoryName = @"System";
        static readonly string settingsDirectoryName = @"Settings";
        static readonly string configINIFileName = @"Config.ini";

        /// <summary>
        /// The general settings for the program.
        /// </summary>
        public static SettingsLoader settingsINI;

        /// <summary>
        /// The list of all the logos currently active.
        /// </summary>
        static List<BrowserObject> allLogos = new List<BrowserObject>();
        
        static Hooks windowsHook = new Hooks();

        // These delegates enables asynchronous calls 
        delegate void ShowHideCallback();
        delegate void CloseLogoCallback();

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
            settingsINI = new SettingsLoader(Application.StartupPath + Path.DirectorySeparatorChar + systemFilesDirectoryName +
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
            loadLogos();
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
            
            allLogos.Add(new BrowserObject());

            hideLogosToolStripMenuItem.Checked = false;
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
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Select(true, true);
                this.Hide();
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
            
            // Location tab
            locationTabPage.Text = "Locations";
        }
        
        #endregion
        
    }

}
