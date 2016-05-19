// Custom Desktop Logo 2.0 - By: 2008 Eric Wong
// September 20th, 2008
// Custom Desktop Logo is open source software licensed under GNU GENERAL PUBLIC LICENSE V3. 
// Use it as you wish, but you must share your source code under the terms of use of the license.

// Uses AMS.Profile from http://www.codeproject.com/KB/cs/readwritexmlini.aspx for .ini file operations (Open source, non-specific license)
// Uses hotkey selector component from http://www.codeproject.com/KB/miscctrl/systemhotkey.aspx (Open source, non-specific license)

// This file contains the alpha blending methods that allow for good looking graphics generated from a .PNG image.

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace PerPixelAlphaForms
{
    /// <summary>
    /// This is the basic class that other dock items/objects inherits. 
    /// Essentially, it contains methods that manage the setting of the image bitmaps to be displayed.
    /// </summary>
    public class BrowserObjectForm : Form
    {
        private Bitmap _previousBitmap = new Bitmap(1, 1);

        #region Constructor

        #region Windows Form Designer generated code

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
        }

        #endregion

        /// <summary> 
        /// PerPixelAlpha is the basis of alpha blended logo objects.
        /// </summary>
        public BrowserObjectForm()
        {
            InitializeComponent();
            
            FormBorderStyle = FormBorderStyle.None;
            ShowInTaskbar = false;
            AllowDrop = false;
            
            EnableDoubleBuffering();
            StartPosition = FormStartPosition.Manual;
        }

        /// <summary>
        ///  Enable double-buffering
        /// </summary>
        public void EnableDoubleBuffering()
        {
            // Set the value of the double-buffering style bits to true.
            DoubleBuffered = true;
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint |
                            ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();
        }

        #endregion

        /// <summary>
        /// Allows us to set the window styles at creation time to allow for widget type objects.
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;

                //Set the form to be a layered type to allow for alpha blended graphics and makes it a toolwindow type to 
                //remove it from the taskbar and Alt-Tab list.
                cp.ExStyle = Constants.WindowExStyles.WS_EX_LAYERED | Constants.WindowExStyles.WS_EX_TOOLWINDOW;// | Constants.WindowExStyles.WS_EX_NOACTIVATE;

                cp.Style = unchecked((int)0xD4000000);

                return cp;
            }
        }

        #region Alpha Blending

        /// <summary> 
        /// Changes the current bitmap shown in the form with a custom opacity level and alpha blending.  Here is where all happens!
        /// The size of the bitmap drawn is equal to the size of the given "bitmap".
        /// </summary>
        /// <param name="bitmap">The bitmap must be 32ppp with alpha-channel. This is a referenced parameter. Do not dispose of the bitmap before setting this to null.</param>
        public void SetBitmap(Bitmap bitmap)
        {
            IntPtr hBitmap = IntPtr.Zero;
            IntPtr oldBitmap = IntPtr.Zero;
            IntPtr screenDc = Win32.GetDC(IntPtr.Zero);
            IntPtr memDc = Win32.CreateCompatibleDC(screenDc);

            try
            {
                // TODO - disposing of old bitmap, and ensuring old one is valid
                if (bitmap == null)
                {
                    _previousBitmap = new Bitmap(1, 1);
                }
                else
                {
                    _previousBitmap.Dispose();
                    _previousBitmap = bitmap;
                }


                try
                {
                    hBitmap = _previousBitmap.GetHbitmap(Color.FromArgb(0));
                }
                catch (Exception)
                {
                    _previousBitmap = new Bitmap(1, 1);
                    hBitmap = _previousBitmap.GetHbitmap(Color.FromArgb(0));
                }

                oldBitmap = Win32.SelectObject(memDc, hBitmap);

                Size size = new Size(_previousBitmap.Width, _previousBitmap.Height);

                Point pointSource = new Point(0, 0);

                Win32.BLENDFUNCTION blend = new Win32.BLENDFUNCTION();
                blend.BlendOp = 0;
                blend.BlendFlags = 0;

                blend.SourceConstantAlpha = 255;
                blend.AlphaFormat = 1;

                Point topPos = new Point(0, 0);
                Win32.UpdateLayeredWindow(Handle, screenDc, ref topPos, ref size, memDc, ref pointSource, 0, ref blend, Win32.ULW_ALPHA);

            }
            catch (Exception e)
            {
                Console.WriteLine("setbitmap error");
                Console.WriteLine(e);
            }
            finally
            {
                Win32.ReleaseDC(IntPtr.Zero, screenDc);
                if (hBitmap != IntPtr.Zero)
                {
                    Win32.SelectObject(memDc, oldBitmap);
                    Win32.DeleteObject(hBitmap);
                }
                Win32.DeleteDC(memDc);
            }
        }

        #endregion
    }

    #region "API"

    public class Win32
    {
        public struct BLENDFUNCTION
        {
            public byte BlendOp;

            public byte BlendFlags;

            public byte SourceConstantAlpha;

            public byte AlphaFormat;

        }

        public const int ULW_ALPHA = 2;

        public const byte AC_SRC_OVER = 0;

        public const byte AC_SRC_ALPHA = 1;


        [DllImportAttribute("user32.dll")]
        public extern static bool UpdateLayeredWindow(IntPtr handle, IntPtr hdcDst, ref Point pptDst, ref Size psize, IntPtr hdcSrc, ref Point pprSrc, int crKey, ref BLENDFUNCTION pblend, int dwFlags);

        [DllImportAttribute("user32.dll")]
        public extern static IntPtr GetDC(IntPtr handle);

        [DllImportAttribute("user32.dll", ExactSpelling = true)]
        public extern static int ReleaseDC(IntPtr handle, IntPtr hDC);

        [DllImportAttribute("gdi32.dll")]
        public extern static IntPtr CreateCompatibleDC(IntPtr hDC);

        [DllImportAttribute("gdi32.dll")]
        public extern static bool DeleteDC(IntPtr hdc);

        [DllImportAttribute("gdi32.dll")]
        public extern static IntPtr SelectObject(IntPtr hDC, IntPtr hObject);

        [DllImportAttribute("gdi32.dll")]
        public extern static bool DeleteObject(IntPtr hObject);
    }

    #endregion
}