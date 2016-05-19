// Custom Desktop Logo 1.0 - By: 2008 Eric Wong
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

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System.Text;


namespace MemoryManagement
{    
    public static class MemoryUtility    
    {        
        private static volatile bool _enabled = true; 
       
        // Requires user to be running as an Administrator
        public static void ClearUnusedMemory()        
        {
            if (!_enabled)
                return;
            try
            {
                if (Environment.OSVersion.Platform >= PlatformID.Win32NT)
                {
                    Pinvoke.Win32.SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
                }
                else
                {
                    _enabled = false;
                }
            }
            catch
            {
                //Some users won't have permission to adjust their working set.               
                _enabled = false;
            }       
        }    
    }
}