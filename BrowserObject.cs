using System;
using System.Drawing;
using System.Timers;
using CefSharp.OffScreen;

namespace CEFOverlay
{
    /// <summary>
    ///  Renderable browser object
    /// </summary>
    public class BrowserObject : BrowserObjectForm
    {
        private readonly ChromiumWebBrowser _browser;
        private readonly Timer _timer;
        
        public BrowserObject()
        {
            Show();
            SetBitmap(new Bitmap(1,1));
            SetZLevel();
            SetTransparencyToInput();

            _timer = new Timer(50);
            _browser = new ChromiumWebBrowser(Properties.Settings.Default.url);
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
            Pinvoke.Win32.SetWindowPos(Handle, (IntPtr) Pinvoke.Win32.HWND_TOPMOST, 0, 0, 0, 0,
                Pinvoke.Win32.SWP_NOMOVE | 
                Pinvoke.Win32.SWP_NOSIZE |
                Pinvoke.Win32.SWP_NOACTIVATE | 
                Pinvoke.Win32.SWP_NOOWNERZORDER | 
                Pinvoke.Win32.SWP_NOREDRAW |
                Pinvoke.Win32.SWP_NOSENDCHANGING);
        }

        private void SetTransparencyToInput()
        {
            Pinvoke.Win32.SetWindowLong(Handle, Constants.GWLConstants.GWL_EXSTYLE,
                Constants.WindowExStyles.WS_EX_LAYERED | 
                Constants.WindowExStyles.WS_EX_TOOLWINDOW |
                Constants.WindowExStyles.WS_EX_TRANSPARENT);
        }
    }
}