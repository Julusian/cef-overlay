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
using System.Windows.Forms;

using CefSharp;
using Hook;


namespace CEFOverlay
{
    public partial class MainForm : Form
    {
        #region Variables
        
        /// <summary>
        /// The browser client object
        /// </summary>
        private static BrowserObject _browserObject;
        
        static Hooks windowsHook = new Hooks();

        // These delegates enables asynchronous calls 
        delegate void ShowHideCallback();
        delegate void CloseLogoCallback();

        public static MainForm Instance { get; private set; }

        #endregion

        #region Constructor and Initialization

        static MainForm()
        {
             Instance = new MainForm();
        }
        
        public MainForm()
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;
            
            DoubleBuffered = true;

            // We require this hook to correct a Windows bug where a topmost window will become not topmost in some cases
            // when other programs refresh the screen.
            windowsHook.OnForegroundWindowChanged += window_ForegroundChanged;
            GC.KeepAlive(windowsHook);
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            Hide();
            ShowInTaskbar = true;
            Opacity = 1.0;
        }

        #endregion

        #region Main Methods

        private void MainForm_Load(object sender, EventArgs e)
        {
            MainFormTrayIcon.Visible = true;

            LoadFormData();
            
            LoadOverlay();
        }

        private void LoadFormData()
        {
            urlBox.Text = Properties.Settings.Default.url;
        }

        private void SaveFormData()
        {
            Properties.Settings.Default.url = urlBox.Text;

            Properties.Settings.Default.Save();
        }

        private void ResetOverlay()
        {
            if (_browserObject == null)
                return;

            if (_browserObject.InvokeRequired)
            {
                CloseLogoCallback d = new CloseLogoCallback(ResetOverlay);
                _browserObject.Invoke(d, new object[] { });
            }
            else
            {
                _browserObject.Dispose();
            }

            _browserObject = null;
        }

        private void LoadOverlay()
        {
            ResetOverlay();

            _browserObject = new BrowserObject();

            hideOverlayToolStripMenuItem.Checked = false;
        }

        private void window_ForegroundChanged(IntPtr hWnd)
        {
            try
            {
                _browserObject.SetZLevel();
            }
            catch (Exception)
            { }
        }

        #endregion

        #region Tray Icon Context Menu

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            Show();
            BringToFront();
        }

        private void MainFormTrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            Show();
            BringToFront();
        }
        
        private void HideOverlayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowHideOverlay(!hideOverlayToolStripMenuItem.Checked);
        }

        private void RefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _browserObject?.RefreshPage();
        }

        private static void ShowHideOverlay(bool show)
        {
            if (_browserObject.InvokeRequired)
            {
                ShowHideCallback d = () => ShowHideOverlay(show);
                _browserObject.Invoke(d, new object[] { });
                return;
            }

            if (show)
            {
                _browserObject.Show();
                _browserObject.WindowState = FormWindowState.Normal;
                _browserObject.Show();
                _browserObject.BringToFront();
            }
            else
            {
                _browserObject.Hide();
            }
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
            if (WindowState == FormWindowState.Minimized)
            {
                Select(true, true);
                Hide();

                SaveFormData();
            }
        }

        #endregion

    }

}
