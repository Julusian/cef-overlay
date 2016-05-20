using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CEFOverlay
{
    /// <summary>
    ///  Borderless browser form
    /// </summary>
    public class BrowserObjectForm : Form
    {
        private Bitmap _previousBitmap = new Bitmap(1, 1);
        
        /// <summary> 
        /// PerPixelAlpha is the basis of alpha blended logo objects.
        /// </summary>
        public BrowserObjectForm()
        {
            FormBorderStyle = FormBorderStyle.None;
            ShowInTaskbar = false;
            
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
            if (bitmap == null)
                return;

            IntPtr hBitmap = IntPtr.Zero;
            IntPtr oldBitmap = IntPtr.Zero;
            IntPtr screenDc = Win32.GetDC(IntPtr.Zero);
            IntPtr memDc = Win32.CreateCompatibleDC(screenDc);

            try
            {
                _previousBitmap?.Dispose();
                _previousBitmap = bitmap;

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


        [DllImport("user32.dll")]
        public extern static bool UpdateLayeredWindow(IntPtr handle, IntPtr hdcDst, ref Point pptDst, ref Size psize, IntPtr hdcSrc, ref Point pprSrc, int crKey, ref BLENDFUNCTION pblend, int dwFlags);

        [DllImport("user32.dll")]
        public extern static IntPtr GetDC(IntPtr handle);

        [DllImport("user32.dll", ExactSpelling = true)]
        public extern static int ReleaseDC(IntPtr handle, IntPtr hDC);

        [DllImport("gdi32.dll")]
        public extern static IntPtr CreateCompatibleDC(IntPtr hDC);

        [DllImport("gdi32.dll")]
        public extern static bool DeleteDC(IntPtr hdc);

        [DllImport("gdi32.dll")]
        public extern static IntPtr SelectObject(IntPtr hDC, IntPtr hObject);

        [DllImport("gdi32.dll")]
        public extern static bool DeleteObject(IntPtr hObject);
    }

    #endregion
}
