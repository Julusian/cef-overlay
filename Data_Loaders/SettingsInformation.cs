// Circle Dock 0.9.2 - Copyright 2008 Eric Wong
// Circle Dock is open source software licensed under GNU GENERAL PUBLIC LICENSE V3. See included Licence.txt file.
// http://circledock.wikidot.com
// VideoInPicture@gmail.com

// This file contains the structs used to hold the settings information for the dock.

using System;
using System.Collections.Generic;
using CustomDesktopLogo;

/// <summary>
/// The namespace SettingsInformation is a collection of structs that is used to hold the general dock settings for Circle Dock.
/// It is used by SettingsLoader to load the general settings from an Config.ini file and allow the program to access the data.
/// The settings are loaded from the Config.ini file into memory to allow for faster performance.
/// Individual dock item settings are dealt with DockItemsInformation and DockItemSettingsLoader.
/// </summary>
namespace SettingsInformation
{
    public struct LogoProperties
    {
        /// <summary>
        /// File path to the image for the LogoProperties.
        /// </summary>
        public string path;

        public MultiMonitorDisplayModes multiMonitorDisplayMode;
    }
    
}
