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
            this.SuspendLayout();
            // 
            // TransparentObject
            // 
            
            this.ClientSize = new Size(1, 1);
            this.Name = "TransparentObject";
            this.ResumeLayout(false);
        }

        #endregion

        #region Constructor

        private readonly ChromiumWebBrowser browser;
        private readonly System.Timers.Timer timer;

        /// <summary> 
        /// Create an alpha blended form with a transparent background.
        /// </summary>
        public LogoObject()
        {
            InitializeComponent();
            AllowDrop = false;
            this.Show();
            SetBitmap(new Bitmap(1,1));
            SetZLevel();
            SetTransparencyToInput();

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
                SetBitmap(bitmap);
            }
        }

        public void SetZLevel()
        {
            Pinvoke.Win32.SetWindowPos(Handle, (IntPtr)Pinvoke.Win32.HWND_TOPMOST, 0, 0, 0, 0, Pinvoke.Win32.SWP_NOMOVE | Pinvoke.Win32.SWP_NOSIZE
                | Pinvoke.Win32.SWP_NOACTIVATE | Pinvoke.Win32.SWP_NOOWNERZORDER | Pinvoke.Win32.SWP_NOREDRAW | Pinvoke.Win32.SWP_NOSENDCHANGING);
        }

        public void SetTransparencyToInput()
        {
            Pinvoke.Win32.SetWindowLong(this.Handle, Constants.GWLConstants.GWL_EXSTYLE, Constants.WindowExStyles.WS_EX_LAYERED | Constants.WindowExStyles.WS_EX_TOOLWINDOW | Constants.WindowExStyles.WS_EX_TRANSPARENT);
        }
        
        #endregion
    }

}
