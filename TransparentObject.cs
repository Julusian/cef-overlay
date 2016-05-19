// Custom Desktop Logo 2.0 - By: 2008 Eric Wong
// September 20th, 2008
// Custom Desktop Logo is open source software licensed under GNU GENERAL PUBLIC LICENSE V3. 
// Use it as you wish, but you must share your source code under the terms of use of the license.

// Custom Desktop Logo allows you to create custom static and animated logos from PNG images.

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

// This file contains the logo object class that we use to create logo objects with in the main form of this program.

using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System.Timers;
using PerPixelAlphaForms;
using CefSharp.OffScreen;

namespace CustomDesktopLogo
{
    public class LogoObject : LogoPerPixelAlphaForm
    {
        #region Windows Form Designer

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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

        private void InitializeComponent()
        {
            this.components = new Container();
            this.filePathsContextMenuStrip = new ContextMenuStrip(components);
            this.filePathsContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // filePathsContextMenuStrip
            // 
            this.filePathsContextMenuStrip.Items.AddRange(new ToolStripItem[] {});
            this.filePathsContextMenuStrip.Opening += filePathsContextMenuStrip_Opening;
            this.filePathsContextMenuStrip.Name = "filePathsContextMenuStrip";
            this.filePathsContextMenuStrip.Size = new Size(153, 70);
            // 
            // TransparentObject
            // 
            
            this.ClientSize = new Size(1, 1);
            this.Name = "TransparentObject";
            this.Activated += LogoObject_Activated;
            this.ContextMenuStrip = filePathsContextMenuStrip;
            this.MouseUp += LogoObject_MouseUp;
            this.filePathsContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
        }
  
        void filePathsContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
        }

        #endregion

        public ContextMenuStrip filePathsContextMenuStrip;

        #region Constructor

        private readonly ChromiumWebBrowser browser;
        private readonly System.Timers.Timer timer;

        /// <summary> 
        /// Create an alpha blended form with a transparent background.
        /// </summary>
        public LogoObject(Bitmap images, Point initialLocation, int initialOpacity)
        {
            InitializeComponent();
            AllowDrop = false;
            this.Show();
            SetBitmap(true, images, true, (byte)initialOpacity, true, initialLocation.X, initialLocation.Y);
            SetZLevel();
            SetTransparencyToInput(MainForm.settingsINI.FolderPaths.useAsDropFolder);

            timer = new System.Timers.Timer(50);
            browser = new ChromiumWebBrowser("google.com");
            timer.Elapsed += UpdateBitmap;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private void UpdateBitmap(Object source, ElapsedEventArgs e)
        {
            //var newBitmap = browser.ScreenshotOrNull();
            var bitmap = browser.ScreenshotOrNull();
            if (bitmap != null)
            {
                SetBitmap(true, bitmap, true, 255, true, 0, 0);
            }
        
        //Console.WriteLine("BITMAP: " + bitmap);
        }

        public void SetZLevel()
        {
            Pinvoke.Win32.SetWindowPos(Handle, (IntPtr)Pinvoke.Win32.HWND_TOPMOST, 0, 0, 0, 0, Pinvoke.Win32.SWP_NOMOVE | Pinvoke.Win32.SWP_NOSIZE
                | Pinvoke.Win32.SWP_NOACTIVATE | Pinvoke.Win32.SWP_NOOWNERZORDER | Pinvoke.Win32.SWP_NOREDRAW | Pinvoke.Win32.SWP_NOSENDCHANGING);
        }

        public void SetTransparencyToInput(bool respond)
        {
            //long originalLong = Pinvoke.Win32.GetWindowLong(this.Handle, Constants.GWLConstants.GWL_EXSTYLE);

            if (respond)
            {
                Pinvoke.Win32.SetWindowLong(this.Handle, Constants.GWLConstants.GWL_EXSTYLE, Constants.WindowExStyles.WS_EX_LAYERED | Constants.WindowExStyles.WS_EX_TOOLWINDOW);
            }
            else
            {
                Pinvoke.Win32.SetWindowLong(this.Handle, Constants.GWLConstants.GWL_EXSTYLE, Constants.WindowExStyles.WS_EX_LAYERED | Constants.WindowExStyles.WS_EX_TOOLWINDOW | Constants.WindowExStyles.WS_EX_TRANSPARENT);
            }
        }

        void LogoObject_Activated(object sender, EventArgs e)
        {
            //SetZLevel(currWindowLevel);
        }
        
        private void filePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem aToolStripMenuItem = (ToolStripMenuItem)sender;

            switch ((String)aToolStripMenuItem.Tag)
            {
                case "HideLogos":
                    MainForm.Instance.hideLogosToolStripMenuItemChecked = aToolStripMenuItem.Checked;
                    MainForm.Instance.hideLogosToolStripMenuItem_Click(this, null);
                    break;
                case "Settings":
                    MainForm.Instance.settingsToolStripMenuItem_Click(this, null);
                    break;
                case "Quit":
                    MainForm.Instance.Close();
                    break;
                default:
                    //do nothing
                    break;
            }
        }
        
        public void showContextMenu()
        {
            this.filePathsContextMenuStrip.Show(MousePosition.X, MousePosition.Y);
            this.filePathsContextMenuStrip.BringToFront();
        }

        void LogoObject_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                filePathsContextMenuStrip.Items.Clear();
                
                ToolStripMenuItem hideLogosToolStripMenuItem = new ToolStripMenuItem();
                hideLogosToolStripMenuItem.Name = "hideLogosToolStripMenuItem";
                hideLogosToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
                hideLogosToolStripMenuItem.Text = "Hide logo";
                hideLogosToolStripMenuItem.Tag = "HideLogos";
                hideLogosToolStripMenuItem.CheckOnClick = true;
                hideLogosToolStripMenuItem.Checked = MainForm.Instance.hideLogosToolStripMenuItemChecked;
                hideLogosToolStripMenuItem.Click += new System.EventHandler(this.filePathToolStripMenuItem_Click);
                filePathsContextMenuStrip.Items.Add(hideLogosToolStripMenuItem);

                ToolStripMenuItem settingsToolStripMenuItem = new ToolStripMenuItem();
                settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
                settingsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
                settingsToolStripMenuItem.Text = "Settings";
                settingsToolStripMenuItem.Tag = "Settings";
                settingsToolStripMenuItem.Click += new System.EventHandler(this.filePathToolStripMenuItem_Click);
                filePathsContextMenuStrip.Items.Add(settingsToolStripMenuItem);

                ToolStripMenuItem helpAboutToolStripMenuItem = new ToolStripMenuItem();
                helpAboutToolStripMenuItem.Name = "helpAboutToolStripMenuItem";
                helpAboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
                helpAboutToolStripMenuItem.Text = "Help/About";
                helpAboutToolStripMenuItem.Tag = "HelpAbout";
                helpAboutToolStripMenuItem.Click += new System.EventHandler(this.filePathToolStripMenuItem_Click);
                filePathsContextMenuStrip.Items.Add(helpAboutToolStripMenuItem);

                ToolStripMenuItem quitToolStripMenuItem = new ToolStripMenuItem();
                quitToolStripMenuItem.Name = "quitToolStripMenuItem";
                quitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
                quitToolStripMenuItem.Text = "Quit";
                quitToolStripMenuItem.Tag = "Quit";
                quitToolStripMenuItem.Click += new System.EventHandler(this.filePathToolStripMenuItem_Click);
                filePathsContextMenuStrip.Items.Add(quitToolStripMenuItem);

                filePathsContextMenuStrip.Show();
                filePathsContextMenuStrip.Left = MousePosition.X;
                filePathsContextMenuStrip.Top = MousePosition.Y;
            }
        }
        #endregion
    }

}
