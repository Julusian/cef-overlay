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

// This file contains the structs used to language data for display.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Text;

namespace LanguageInformation
{
    public struct LanguageFile
    {
        public String intendedForProgramVersion;
        public String languageFileVersion;
        public String languageName;
        public String fileAuthor;
    }

    public struct General
    {
        public string customDesktopLogo;
        public string customDesktopLogoSettings;

        // Select Images tab
        public string selectImages;
        public string changeImageFolder;
        public string refreshImageList;
        public string instructions;
        public string instruction1;
        public string instruction2;
        public string instruction3;
        public string instruction4;
        public string instruction5;
        public string helpabout;

        // Location tab
        public string location;
        public string zLevel;
        public string topmost;
        public string normal;
        public string alwaysOnBottom;
        public string multiMonitorDisplayModes;
        public string allSame;
        public string primaryOnly;
        public string allButPrimary;
        public string virtualMonitor;
        public string displayLocation;
        public string centre;
        public string bottomLeft;
        public string bottomMiddle;
        public string bottomRight;
        public string leftMiddle;
        public string displayAtLocationOffset;
        public string topLeft;
        public string topMiddle;
        public string topRight;
        public string rightMiddle;
        public string locationOffset;
        public string xCoordinate;
        public string yCoordinate;

        // Size tab
        public string size;
        public string scaleImagesByFactorOf;

        // Animation/Graphics tab
        public string animationAndGraphics;
        public string framesPerSecond;
        public string delayBetweenAnimationsSeconds;
        public string opacity;

        // Language tab
        public string language;
        public string createdBy;

        // Drop Folder tab
        public string dropFolder;
        public string useAsDropFolderWithExplanation;
        public string folderName;
        public string folderPath;
        public string browse;
    }

    public struct MainContextMenu
    {
        public string quit;
        public string helpabout;
        public string settings;
        public string hideLogo;
        public string dropFolderMode;
        public string disableMovement;
    }

    public struct HelpAbout
    {
        public string aboutWindowTitle;
        public string officialSupportForum;
        public string officialWebsite;
        public string donateProjectDevelopment;
        public string emailAuthor;
        public string programDescription;
    }

    public struct ErrorMessages
    {
        public string customDesktopLogo;
        public string usingTooMuchMemoryContinueQuestion;
        public string folderDoesNotExist;
    }

}
