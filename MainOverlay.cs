using System;
using System.Diagnostics;		
using System.Windows.Forms;
using System.Threading;
using CefSharp;

namespace CEFOverlay
{
    static class MainOverlay
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();

            Application.SetCompatibleTextRenderingDefault(false);

            // Add the event handler for handling UI thread exceptions to the event.
            Application.ThreadException += Program_UIThreadException;

            // Set the unhandled exception mode to force all Windows Forms errors to go through
            // our handler.
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            // Add the event handler for handling non-UI thread exceptions to the event. 
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            //Application.Run(new MainForm());
            if (SingleInstance.SingleApplication.Run(MainForm.Instance))
            {
                var settings = new CefSettings();
                settings.RemoteDebuggingPort = 8088;
                settings.CachePath = "cache";
                settings.MultiThreadedMessageLoop = true;
                settings.WindowlessRenderingEnabled = true;

                // Disable GPU in WPF and Offscreen examples until #1634 has been resolved
                settings.CefCommandLineArgs.Add("disable-gpu", "1");

                settings.CefCommandLineArgs.Add("no-proxy-server", "1");

                var architecture = Environment.Is64BitProcess ? "x64" : "x86";
                settings.BrowserSubprocessPath = "..\\..\\..\\..\\CefSharp.BrowserSubprocess\\bin\\" + architecture + "\\Debug\\CefSharp.BrowserSubprocess.exe";

                settings.FocusedNodeChangedEnabled = true;

                //The Request Context has been initialized, you can now set preferences, like proxy server settings
                Cef.OnContextInitialized = delegate
                {
                    var cookieManager = Cef.GetGlobalCookieManager();
                    cookieManager.SetStoragePath("cookies", true);
                    cookieManager.SetSupportedSchemes("custom");

                    //Dispose of context when finished - preferable not to keep a reference if possible.
                    using (var context = Cef.GetGlobalRequestContext())
                    {
                        string errorMessage;
                        //You can set most preferences using a `.` notation rather than having to create a complex set of dictionaries.
                        //The default is true, you can change to false to disable
                        context.SetPreference("webkit.webprefs.plugins_enabled", true, out errorMessage);
                    }
                };

                if (!Cef.Initialize(settings, true, false))
                {
                    throw new Exception("Unable to Initialize Cef");
                }
                
            }
        }

        // Handle the UI exceptions by showing a dialog box, and asking the user whether
        // or not they wish to abort execution.
        private static void Program_UIThreadException(object sender, ThreadExceptionEventArgs t)
        {
            DialogResult result = DialogResult.Cancel;
            try
            {
                result = ShowThreadExceptionDialog("CEF Overlay: Windows Forms Error", t.Exception);
            }
            catch
            {
                try
                {
                    MessageBox.Show("Fatal Windows Forms Error",
                        "CEF Overlay", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);
                }
                finally
                {
                    Application.Exit();
                }
            }

            // Exits the program when the user clicks Abort.
            if (result == DialogResult.Abort)
                Application.Exit();
        }

        // Handle the UI exceptions by showing a dialog box, and asking the user whether
        // or not they wish to abort execution.
        // NOTE: This exception cannot be kept from terminating the application - it can only 
        // log the event, and inform the user about it. 
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                Exception ex = (Exception)e.ExceptionObject;
                string errorMsg = "An application error occurred. Please contact the adminstrator " +
                    "with the following information:\n\n";

                // Since we can't prevent the app from terminating, log this to the event log.
                if (!EventLog.SourceExists("ThreadException"))
                {
                    EventLog.CreateEventSource("ThreadException", "Application");
                }

                // Create an EventLog instance and assign its source.
                EventLog myLog = new EventLog();
                myLog.Source = "ThreadException";
                myLog.WriteEntry(errorMsg + ex.Message + "\n\nStack Trace:\n" + ex.StackTrace);

                MessageBox.Show("Current Domain Unhandled Exception",
                    errorMsg + ex.Message + "\n\nStack Trace:\n" + ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch (Exception exc)
            {
                try
                {
                    MessageBox.Show("Fatal Non-UI Error. Could not write the error to the event log. Reason: "
                        + exc.Message, "CEF Overlay: Current Domain", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                finally
                {
                    Application.Exit();
                }
            }
        }

        // Creates the error message and displays it.
        private static DialogResult ShowThreadExceptionDialog(string title, Exception e)
        {
            string errorMsg = "An application error occurred. Please contact the adminstrator " +
                "with the following information:\n\n";
            errorMsg = errorMsg + e.Message + "\n\nStack Trace:\n" + e.StackTrace;
            return MessageBox.Show(errorMsg, title, MessageBoxButtons.AbortRetryIgnore,
                MessageBoxIcon.Stop);
        }
    }
}
