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

// This file contains the alpha blending methods that allow for good looking graphics generated from a .PNG image.

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using ImageOperations;

namespace PerPixelAlphaForms
{
     /// <summary>
    /// Creates an alpha blended form for the logo object.
    /// </summary>
    public class LogoPerPixelAlphaForm : PerPixelAlphaForm
    {
        public LogoPerPixelAlphaForm()
        {
        }

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
    }

    /// <summary>
    /// This is the basic class that other dock items/objects inherits. 
    /// Essentially, it contains methods that manage the setting of the image bitmaps to be displayed.
    /// </summary>
    public class PerPixelAlphaForm : Form
    {
        private Point previousLocation = new Point(0, 0);

        public Point _Location
        {
            get
            {
                return previousLocation;
            }
        }

        private int previousOpacity = 255;

        public int _Opacity
        {
            get
            {
                return previousOpacity;
            }
        }

        private Bitmap previousBitmap = new Bitmap(1, 1);

        public Bitmap _Bitmap
        {
            get
            {
                return previousBitmap;
            }
        }

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
        public PerPixelAlphaForm()
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
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint |
                            ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();
        }

        #endregion

        #region Alpha Blending

        /// <summary> 
        /// Changes the current bitmap shown in the form with a custom opacity level and alpha blending.  Here is where all happens!
        /// The size of the bitmap drawn is equal to the size of the given "bitmap".
        /// </summary>
        /// <param name="bitmap">The bitmap must be 32ppp with alpha-channel. This is a referenced parameter. Do not dispose of the bitmap before setting this to null.</param>
        /// <param name="opacity">0-255</param>
        public void SetBitmap(bool setNewBitmap, Bitmap bitmap, bool setNewOpacity, byte opacity, 
            bool setNewPos, int newLeftPos, int newTopPos)
        {
            IntPtr hBitmap = IntPtr.Zero;
            IntPtr oldBitmap = IntPtr.Zero;
            IntPtr screenDc = Win32.GetDC(IntPtr.Zero);
            IntPtr memDc = Win32.CreateCompatibleDC(screenDc);

            try
            {
                if (setNewBitmap)
                {
                    if (bitmap == null)
                    {
                        previousBitmap = new Bitmap(1, 1);
                    }
                    else
                    {
                        previousBitmap.Dispose();
                        previousBitmap = bitmap;
                    }

                }

                try
                {
                    hBitmap = previousBitmap.GetHbitmap(Color.FromArgb(0));
                }
                catch (Exception)
                {
                    previousBitmap = new Bitmap(1, 1);
                    hBitmap = previousBitmap.GetHbitmap(Color.FromArgb(0));
                }

                oldBitmap = Win32.SelectObject(memDc, hBitmap);

                Size size = new Size(previousBitmap.Width, previousBitmap.Height);

                Point pointSource = new Point(0, 0);

                Win32.BLENDFUNCTION blend = new Win32.BLENDFUNCTION();
                blend.BlendOp = 0;
                blend.BlendFlags = 0;

                if (setNewOpacity)
                {
                    blend.SourceConstantAlpha = opacity;
                    previousOpacity = (int)opacity;
                }
                else
                {
                    blend.SourceConstantAlpha = (byte)previousOpacity;
                }

                blend.AlphaFormat = 1;

                if (setNewPos == true)
                {
                    Point topPos = new Point(newLeftPos, newTopPos);
                    previousLocation = topPos;
                    Win32.UpdateLayeredWindow(Handle, screenDc, ref topPos, ref size, memDc, ref pointSource, 0, ref blend, Win32.ULW_ALPHA);
                }
                else
                {
                    Win32.UpdateLayeredWindow(Handle, screenDc, ref previousLocation, ref size, memDc, ref pointSource, 0, ref blend, Win32.ULW_ALPHA);
                }
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
