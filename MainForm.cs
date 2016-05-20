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

        private static readonly Hooks windowsHook = new Hooks();

        // These delegates enables asynchronous calls 
        private delegate void ShowHideCallback();
        delegate void CloseOverlayCallback();

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
            windowsHook.OnForegroundWindowChanged += Window_ForegroundChanged;
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

        private static void ResetOverlay()
        {
            if (_browserObject == null)
                return;

            if (_browserObject.InvokeRequired)
            {
                CloseOverlayCallback d = ResetOverlay;
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

        private void Window_ForegroundChanged(IntPtr hWnd)
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
