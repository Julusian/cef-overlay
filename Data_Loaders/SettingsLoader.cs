// Circle Dock 0.9.2 - Copyright 2008 Eric Wong
// Circle Dock is open source software licensed under GNU GENERAL PUBLIC LICENSE V3. See included Licence.txt file.
// http://circledock.wikidot.com
// VideoInPicture@gmail.com

// This file contains the classes used to load the settings information for the dock using the .ini file format
// to allow for high legibility for the end user.

using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;

using AMS.Profile;      // Allows for .ini file manipulation
using SettingsInformation;
using CustomDesktopLogo;

namespace SettingsLoader
{
    /// <summary>    
    /// Loads the global settings for the dock. Does not include the individual settings for the dock items.
    /// Uses the .ini file format.
    /// </summary>  
    public class SettingsLoader
    {
        #region Variables

        /// <summary>    
        /// Allows for .ini file manipulation.
        /// </summary>  
        private Profile SettingsINI;
        private String DataVerifier;

        public SettingsInformation.LogoProperties LogoProperties = new LogoProperties();

        #endregion

        #region Constructor

        /// <summary>        
        /// Loads the global system settings into memory and provides access to the read/write of them.
        /// The reading of the settings should be done using the structs instances declared in this class
        /// for faster access. Reading/writing to the .ini file all the time can lead to low performance.
        /// 
        /// This class is independent of the file version of the .ini file. Bounds checking and automatic repair are done.
        /// </summary>        
        /// <param name="FilePath">System path to the .ini file to where the global settings are stored.</param>        
        public SettingsLoader(String FilePath)
        {
            if (!File.Exists(FilePath))
            {
                MessageBox.Show(@"Config.ini: " + FilePath + @" is missing. Please replace the settings file. Circle Dock will now exit.", "Circle Dock");
                Application.Exit();
            }

            SettingsINI = new Ini(FilePath);

            //string[] sectionNames = SettingsINI.GetSectionNames();
            //for (int i = 0; i < sectionNames.Length; i++)
            //{
            //    Console.WriteLine("section " + i + " : '" + sectionNames[i] + "'");
            //}

            //string[] entryNames = SettingsINI.GetEntryNames("FolderPaths");
            //for (int i = 0; i < entryNames.Length; i++)
            //    Console.WriteLine("entry " + i + " : '" + entryNames[i] + "'");

            //InitializeSettingsInfoStructs();
            SettingsLoaderLoadData();
        }

        #endregion

        #region Methods

        /// <summary>        
        /// Initializes the structs used to store the settings data. Can be used to clear the settings from memory.
        /// </summary>        
        public void InitializeSettingsInfoStructs()
        {
            LogoProperties = new SettingsInformation.LogoProperties();
        }

        /// <summary>        
        /// Loads the global settings from the .ini file into the structs of this class. Can be used to refresh the settings
        /// data from the settings file into memory.
        /// </summary>  
        public void SettingsLoaderLoadData()
        {
            LoadLogoProperties();

        }

        /// <summary>        
        /// Retrieves the setting value at the given Section with the name of EntryName.
        /// </summary>        
        /// <param name="Section">The section in the .ini file to look at.</param>        
        /// <returns>A string representing the setting value or null if not found.</returns> 
        public String GetEntry(String Section, String EntryName)
        {
            return (String)SettingsINI.GetValue(Section, EntryName);
        }

        /// <summary>        
        /// Retrieves all the section names in the settings file.
        /// </summary>               
        /// <returns>A string array containing the section names null if not found.</returns> 
        public String[] GetSectionNames()
        {
            return SettingsINI.GetSectionNames();
        }

        /// <summary>        
        /// Retrieves the all the names of the settings entries under the given Section
        /// </summary>        
        /// <param name="Section">The section in the .ini file to look at.</param>        
        /// <returns>A string array containing all the entry names in the given section or null if not found.</returns> 
        public String[] GetEntryNames(String Section)
        {
            return SettingsINI.GetEntryNames(Section);
        }

        /// <summary>        
        /// Sets the value of a setting.
        /// </summary>        
        /// <param name="Section">The section in the .ini file to write to. It is created if not found.</param>  
        /// <param name="EntryName">The entry name to store the setting value under. It is created if not found.</param>
        /// <param name="Value">A string representing the value to be stored.</param>
        public void SetEntry(String Section, String EntryName, String Value)
        {
            SettingsINI.SetValue(Section, EntryName, Value);
        }

        /// <summary>        
        /// Removes an entry from the settings file.
        /// </summary>        
        /// <param name="Section">The section in the .ini file to search in.</param>  
        /// <param name="EntryName">The entry to remove.</param>
        public void RemoveEntry(String Section, String EntryName)
        {
            SettingsINI.RemoveEntry(Section, EntryName);
        }

        /// <summary>        
        /// Removes an entire section from the settings file, including the entries.
        /// </summary>        
        /// <param name="Section">The section in the .ini file to remove.</param>  
        public void RemoveSection(String Section)
        {
            SettingsINI.RemoveSection(Section);
        }

        #endregion

        #region Load Each Section for LanguageInformation

        private void LoadLogoProperties()
        {
            const String theSection = "LogoProperties";

            #region path

            DataVerifier = null;
            DataVerifier = GetEntry(theSection, "path");

            if (DataVerifier == null)
            {
                DataVerifier = @"";
                SetEntry(theSection, "path", DataVerifier);
            }

            LogoProperties.path = DataVerifier;

            #endregion
            
            #region multiMonitorDisplayMode

            TypeConverter multiMonitorDisplayModeConverter = TypeDescriptor.GetConverter(typeof(MultiMonitorDisplayModes));

            DataVerifier = null;
            DataVerifier = GetEntry(theSection, "multiMonitorDisplayMode");

            if (DataVerifier == null)
            {
                DataVerifier = MultiMonitorDisplayModes.AllSame.ToString();
                SetEntry(theSection, "multiMonitorDisplayMode", DataVerifier);
            }

            try
            {
                LogoProperties.multiMonitorDisplayMode = (MultiMonitorDisplayModes)multiMonitorDisplayModeConverter.ConvertFromString(DataVerifier);
            }
            catch (Exception)
            {
                LogoProperties.multiMonitorDisplayMode = MultiMonitorDisplayModes.AllSame;
                SetEntry(theSection, "multiMonitorDisplayMode", MultiMonitorDisplayModes.AllSame.ToString());
            }

            #endregion
            
        }
        
        #endregion
    }
}
