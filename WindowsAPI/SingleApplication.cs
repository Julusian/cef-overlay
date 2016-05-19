// Circle Dock 0.9.2 - Copyright 2008 Eric Wong
// Circle Dock is open source software licensed under GNU GENERAL PUBLIC LICENSE V3. See included Licence.txt file.
// http://circledock.wikidot.com
// VideoInPicture@gmail.com

// This file contains the helper class that will only enable a single instance of Circle Dock to run per machine.
// Only one instance of Circle Dock is allowed to run at a time. This is to prevent users from running multiple instances from the 
// same folder and corrupting data, causing the program to crash.

// If the user opens up multiple instances of the program, they will automatically close except for the first instance.

using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace SingleInstance
{
	/// <summary>
	/// Summary description for SingleApp.
	/// </summary>
	public class SingleApplication
	{
		public SingleApplication()
		{

		}

		/// <summary>
		/// Imports 
		/// </summary>
		[DllImport("user32.dll")]
		private static extern int ShowWindow(IntPtr hWnd, int nCmdShow);

		[DllImport("user32.dll")]
		private static extern int SetForegroundWindow(IntPtr hWnd);

		[DllImport("user32.dll")]
		private static extern int IsIconic(IntPtr hWnd);

        const int SW_RESTORE = 9;

		/// <summary>
		/// GetCurrentInstanceWindowHandle
		/// </summary>
		/// <returns></returns>
		private static IntPtr GetCurrentInstanceWindowHandle()
		{    
			IntPtr hWnd = IntPtr.Zero;
			Process process = Process.GetCurrentProcess();
			Process[] processes = Process.GetProcessesByName(process.ProcessName);
			foreach(Process _process in processes)
			{
				// Get the first instance that is not this instance, has the
				// same process name and was started from the same file name
				// and location. Also check that the process has a valid
				// window handle in this session to filter out other user's
				// processes.
				if (_process.Id != process.Id &&
					_process.MainModule.FileName == process.MainModule.FileName &&
					_process.MainWindowHandle != IntPtr.Zero)    
				{
					hWnd = _process.MainWindowHandle;
					break;
				}
			}
			return hWnd;
		}
		/// <summary>
		/// SwitchToCurrentInstance
		/// </summary>
		private static void SwitchToCurrentInstance()
		{    
			IntPtr hWnd = GetCurrentInstanceWindowHandle();
			if (hWnd != IntPtr.Zero)    
			{    
				// Restore window if minimised. Do not restore if already in
				// normal or maximised window state, since we don't want to
				// change the current state of the window.

                // UNFINISHED
                // Need to code this function specificially for Circle Dock

                //if (IsIconic(hWnd) != 0)
                //{
                //    ShowWindow(hWnd, SW_RESTORE);
                //}

                //// Set foreground window.
                //SetForegroundWindow(hWnd);
			}
		}

		/// <summary>
		/// Execute a form base application if another instance already running on
		/// the system activate previous one
		/// </summary>
		/// <param name="frmMain">main form</param>
		/// <returns>true if no previous instance is running</returns>
		public static bool Run(System.Windows.Forms.Form frmMain)
		{
			if(IsAlreadyRunning())
			{
				//set focus on previously running app
				SwitchToCurrentInstance();
				return false;
			}

            Application.Run(frmMain);
			return true;
		}

		/// <summary>
		/// for console base application
		/// </summary>
		/// <returns></returns>
		public static bool Run()
		{
			if(IsAlreadyRunning()) 
			{
				return false;
			}
			return true;
		}

		/// <summary>
		/// check if given exe alread running or not
		/// </summary>
		/// <returns>returns true if already running</returns>
		private static bool IsAlreadyRunning()
		{
            int numSameInstance = 0;
            Process[] processlist = Process.GetProcesses();

            foreach (Process theprocess in processlist)
            {
                try
                {
                    if (Application.ExecutablePath.ToUpper() == theprocess.MainModule.FileName.ToUpper())
                    {
                        numSameInstance++;
                    }
                }
                catch (Exception)
                {
                }
            }

            if (numSameInstance > 1)
                return true;
            else
                return false;
		}
	
	}
}
