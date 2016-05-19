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

// This file contains the class used to load the .ini language file from a given path. Depends on LanguageInformation.cs.


using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using System.IO;

using AMS.Profile;      // Allows for .ini file manipulation
using LanguageInformation;  

namespace LanguageLoader
{
    public class LanguageLoader
    {
        #region Variables

        private Profile LanguageINI;

        public LanguageInformation.General general = new LanguageInformation.General();
        public LanguageInformation.LanguageFile languageFile = new LanguageInformation.LanguageFile();
        public LanguageInformation.MainContextMenu mainContextMenu = new LanguageInformation.MainContextMenu();
        public LanguageInformation.HelpAbout helpAbout = new LanguageInformation.HelpAbout();
        public LanguageInformation.ErrorMessages errorMessages = new LanguageInformation.ErrorMessages();

        #endregion

        #region Constructor & Private Methods

        /// <summary>    
        /// Loads the language information from the given FilePath.
        /// The language data is accessed by going to the public structs in this class.
        /// The structs will return "?????" if it cannot find valid language data.
        /// </summary>  
        public LanguageLoader(String FilePath)
        {
            if (!File.Exists(FilePath))
            {
                MessageBox.Show(@"Language file: " + FilePath + @" is missing." + "\r" + @"Please replace the language file.", "Circle Dock");
            }

            LanguageINI = new Ini(FilePath);

            LoadLanguageData();
        }

        public void LoadLanguageData()
        {
            loadGeneral();
            loadLanguageFile();
            loadMainContextMenu();
            loadHelpAbout();
            loadErrorMessages();
        }

        public void LoadLanguageDataFromNewFile(String FilePath)
        {
            LanguageINI = new Ini(FilePath);
            LoadLanguageData();
        }

        private String GetEntry(String Section, String EntryName)
        {
            String languageEntry = null;

            try
            {
                languageEntry = (String)LanguageINI.GetValue(Section, EntryName);
            }
            catch (Exception)
            { }

            if (languageEntry != null)
                return languageEntry;
            else
            {
                try
                {
                    LanguageINI.SetValue(Section, EntryName, @"?????");
                }
                catch (Exception)
                { }
                return @"?????";
            }
        }

        #endregion

        #region Load Each Section for LanguageInformation

        private void loadGeneral()
        {
            general.customDesktopLogo = GetEntry("General", "customDesktopLogo");
            general.customDesktopLogoSettings = GetEntry("General", "customDesktopLogoSettings");

            // Select Images tab
            general.selectImages = GetEntry("General", "selectImages");
            general.changeImageFolder = GetEntry("General", "changeImageFolder");
            general.refreshImageList = GetEntry("General", "refreshImageList");
            general.instructions = GetEntry("General", "instructions");
            general.instruction1 = GetEntry("General", "instruction1");
            general.instruction2 = GetEntry("General", "instruction2");
            general.instruction3 = GetEntry("General", "instruction3");
            general.instruction4 = GetEntry("General", "instruction4");
            general.instruction5 = GetEntry("General", "instruction5");
            general.helpabout = GetEntry("General", "helpabout");

            // Location tab
            general.location = GetEntry("General", "location");
            general.zLevel = GetEntry("General", "zLevel");
            general.topmost = GetEntry("General", "topmost");
            general.normal = GetEntry("General", "normal");
            general.alwaysOnBottom = GetEntry("General", "alwaysOnBottom");
            general.multiMonitorDisplayModes = GetEntry("General", "multiMonitorDisplayModes");
            general.allSame = GetEntry("General", "allSame");
            general.primaryOnly = GetEntry("General", "primaryOnly");
            general.allButPrimary = GetEntry("General", "allButPrimary");
            general.virtualMonitor = GetEntry("General", "virtualMonitor");
            general.displayLocation = GetEntry("General", "displayLocation");
            general.centre = GetEntry("General", "centre");
            general.bottomLeft = GetEntry("General", "bottomLeft");
            general.bottomMiddle = GetEntry("General", "bottomMiddle");
            general.bottomRight = GetEntry("General", "bottomRight");
            general.leftMiddle = GetEntry("General", "leftMiddle");
            general.displayAtLocationOffset = GetEntry("General", "displayAtLocationOffset");
            general.topLeft = GetEntry("General", "topLeft");
            general.topMiddle = GetEntry("General", "topMiddle");
            general.topRight = GetEntry("General", "topRight");
            general.rightMiddle = GetEntry("General", "rightMiddle");
            general.locationOffset = GetEntry("General", "locationOffset");
            general.xCoordinate = GetEntry("General", "xCoordinate");
            general.yCoordinate = GetEntry("General", "yCoordinate");

            // Size tab
            general.size = GetEntry("General", "size");
            general.scaleImagesByFactorOf = GetEntry("General", "scaleImagesByFactorOf");

            // Animation/Graphics tab
            general.animationAndGraphics = GetEntry("General", "animationAndGraphics");
            general.framesPerSecond = GetEntry("General", "framesPerSecond");
            general.delayBetweenAnimationsSeconds = GetEntry("General", "delayBetweenAnimationsSeconds");
            general.opacity = GetEntry("General", "opacity");

            // Language tab
            general.language = GetEntry("General", "language");
            general.createdBy = GetEntry("General", "createdBy");

            // Drop Folder tab
             general.dropFolder = GetEntry("General", "dropFolder");
             general.useAsDropFolderWithExplanation = GetEntry("General", "useAsDropFolderWithExplanation");
             general.folderName = GetEntry("General", "folderName");
             general.folderPath = GetEntry("General", "folderPath");
             general.browse = GetEntry("General", "browse");
        }

        private void loadLanguageFile()
        {
            languageFile.intendedForProgramVersion = GetEntry("LanguageFile", "intendedForProgramVersion");
            languageFile.languageFileVersion = GetEntry("LanguageFile", "languageFileVersion");
            languageFile.languageName = GetEntry("LanguageFile", "languageName");
            languageFile.fileAuthor = GetEntry("LanguageFile", "fileAuthor");
        }

        private void loadMainContextMenu()
        {
            mainContextMenu.quit = GetEntry("MainContextMenu", "quit");
            mainContextMenu.helpabout = GetEntry("MainContextMenu", "helpabout");
            mainContextMenu.settings = GetEntry("MainContextMenu", "settings");
            mainContextMenu.hideLogo = GetEntry("MainContextMenu", "hideLogo");
            mainContextMenu.dropFolderMode = GetEntry("MainContextMenu", "dropFolderMode");
            mainContextMenu.disableMovement = GetEntry("MainContextMenu", "disableMovement");
        }

        public void loadHelpAbout()
        {
            helpAbout.aboutWindowTitle = GetEntry("helpAbout", "aboutWindowTitle");
            helpAbout.officialSupportForum = GetEntry("helpAbout", "officialSupportForum");
            helpAbout.officialWebsite = GetEntry("helpAbout", "officialWebsite");
            helpAbout.donateProjectDevelopment = GetEntry("helpAbout", "donateProjectDevelopment");
            helpAbout.emailAuthor = GetEntry("helpAbout", "emailAuthor");
            helpAbout.programDescription = GetEntry("helpAbout", "programDescription");
        }

        public void loadErrorMessages()
        {
            errorMessages.customDesktopLogo = GetEntry("errorMessages", "Custom Desktop Logo");
            errorMessages.usingTooMuchMemoryContinueQuestion = GetEntry("errorMessages", "usingTooMuchMemoryContinueQuestion");
            errorMessages.folderDoesNotExist = GetEntry("errorMessages", "folderDoesNotExist");
        }

        #endregion
    }
}
