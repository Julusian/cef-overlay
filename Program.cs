﻿// Custom Desktop Logo 1.0 - By: 2008 Eric Wong
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

// This file contains the entry point for the application and sets the unhandled exception methods that can be helpful for debugging.
// Only one instance of the program is allowed to run from one folder to prevent two programs from writing into the same settings files at the same time.


using System;
using System.Diagnostics;		
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using CefSharp;
using CustomDesktopLogo.Properties;

namespace CustomDesktopLogo
{
    static class Program
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
            Application.ThreadException += new ThreadExceptionEventHandler(Program_UIThreadException);

            // Set the unhandled exception mode to force all Windows Forms errors to go through
            // our handler.
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            // Add the event handler for handling non-UI thread exceptions to the event. 
            AppDomain.CurrentDomain.UnhandledException +=
                new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

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

                if (true)
                {
                    var architecture = Environment.Is64BitProcess ? "x64" : "x86";
                    settings.BrowserSubprocessPath = "..\\..\\..\\..\\CefSharp.BrowserSubprocess\\bin\\" + architecture + "\\Debug\\CefSharp.BrowserSubprocess.exe";
                }

                /*settings.RegisterScheme(new CefCustomScheme
                {
                    SchemeName = CefSharpSchemeHandlerFactory.SchemeName,
                    SchemeHandlerFactory = new CefSharpSchemeHandlerFactory()
                    //SchemeHandlerFactory = new InMemorySchemeAndResourceHandlerFactory()
                });

                settings.RegisterScheme(new CefCustomScheme
                {
                    SchemeName = CefSharpSchemeHandlerFactory.SchemeNameTest,
                    SchemeHandlerFactory = new CefSharpSchemeHandlerFactory()
                });*/

                //settings.RegisterExtension(new CefExtension("cefsharp/example", Resources.extension));

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

                if (!Cef.Initialize(settings, shutdownOnProcessExit: true, performDependencyCheck: false))
                {
                    throw new Exception("Unable to Initialize Cef");
                }

                return;
            }
        }

        // Handle the UI exceptions by showing a dialog box, and asking the user whether
        // or not they wish to abort execution.
        private static void Program_UIThreadException(object sender, ThreadExceptionEventArgs t)
        {
            DialogResult result = DialogResult.Cancel;
            try
            {
                result = ShowThreadExceptionDialog("Custom Desktop Logo: Windows Forms Error", t.Exception);
            }
            catch
            {
                try
                {
                    MessageBox.Show("Fatal Windows Forms Error",
                        "Custom Desktop Logo", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);
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
                        + exc.Message, "Custom Desktop Logo: Current Domain", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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