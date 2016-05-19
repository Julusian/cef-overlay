using System;
using System.ComponentModel;
using System.Drawing;
using System.Timers;
using CefSharp.OffScreen;
using PerPixelAlphaForms;

namespace CustomDesktopLogo
{
    public class BrowserObject : LogoPerPixelAlphaForm
    {
        #region Windows Form Designer

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components;

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
            components = new Container();
            SuspendLayout();
            // 
            // TransparentObject
            // 
            
            ClientSize = new Size(1, 1);
            Name = "TransparentObject";
            ResumeLayout(false);
        }

        #endregion

        #region Constructor

        private readonly ChromiumWebBrowser _browser;
        private readonly Timer _timer;

        /// <summary> 
        /// Create an alpha blended form with a transparent background.
        /// </summary>
        public BrowserObject()
        {
            InitializeComponent();
            AllowDrop = false;
            Show();
            SetBitmap(new Bitmap(1,1));
            SetZLevel();
            SetTransparencyToInput();

            _timer = new Timer(50);
            _browser = new ChromiumWebBrowser("google.com");
            _timer.Elapsed += NextFrame;
            _timer.AutoReset = true;
            _timer.Enabled = true;
        }

        private void NextFrame(object source, ElapsedEventArgs e)
        {
            //var newBitmap = browser.ScreenshotOrNull();
            Bitmap bitmap = _browser.ScreenshotOrNull();
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

        private void SetTransparencyToInput()
        {
            Pinvoke.Win32.SetWindowLong(Handle, Constants.GWLConstants.GWL_EXSTYLE, Constants.WindowExStyles.WS_EX_LAYERED | Constants.WindowExStyles.WS_EX_TOOLWINDOW | Constants.WindowExStyles.WS_EX_TRANSPARENT);
        }
        
        #endregion
    }
}