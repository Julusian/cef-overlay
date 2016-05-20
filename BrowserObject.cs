using System;
using System.Drawing;
using System.Windows.Forms;
using CefSharp;
using CefSharp.OffScreen;

namespace CEFOverlay
{
    /// <summary>
    ///  Renderable browser object
    /// </summary>
    public class BrowserObject : BrowserObjectForm
    {
        private readonly ChromiumWebBrowser _browser;
        
        public BrowserObject()
        {
            Show();
            SetBitmap(new Bitmap(1,1));
            SetZLevel();
            SetTransparencyToInput();
            
            _browser = new ChromiumWebBrowser(Properties.Settings.Default.url);
            
            Rectangle target = Screen.PrimaryScreen.WorkingArea;
            _browser.Size = new Size(target.Width, target.Height);

            _browser.NewScreenshot += ScreenshotEvent;
        }

        private void ScreenshotEvent(object source, EventArgs e)
        {
            SetBitmap(_browser.ScreenshotOrNull());
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

        public void RefreshPage()
        {
            _browser.Reload();
        }
    }
}