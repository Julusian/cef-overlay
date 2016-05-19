/*
 * AMS.Profile Class Library
 * 
 * Written by Alvaro Mendez
 * Copyright (c) 2005. All Rights Reserved.
 * 
 * The AMS.Profile namespace contains interfaces and classes that 
 * allow reading and writing of user-profile data.
 * This file contains the Registry class.
 * 
 * The code is thoroughly documented, however, if you have any questions, 
 * feel free to email me at alvaromendez@consultant.com.  Also, if you 
 * decide to this in a commercial application I would appreciate an email 
 * message letting me know.
 *
 * This code may be used in compiled form in any way you desire. This
 * file may be redistributed unmodified by any means providing it is 
 * not sold for profit without the authors written consent, and 
 * providing that this notice and the authors name and all copyright 
 * notices remains intact. This file and the accompanying source code 
 * may not be hosted on a website or bulletin board without the author's 
 * written permission.
 * 
 * This file is provided "as is" with no expressed or implied warranty.
 * The author accepts no liability for any damage/loss of business that
 * this product may cause.
 *
 * Last Updated: Feb. 17, 2005
 */


using System;
using System.Windows.Forms;
using System.Security;
using Microsoft.Win32;

namespace AMS.Profile
{
	/// <summary>
	///   Profile class that utilizes the Windows Registry to retrieve and save its data. </summary>
	/// <remarks>
	///   By default class this class uses the HKEY_CURRENT_USER root key,
	///   and sets its default subkey based on the CompanyName and ProductName properties of
	///   the Application object.  For the Demo application, the Company name is set to
	///   "AMS" and the product is "ProfileDemo".  So the entire path looks like this:
	/// 
	///   <code>HKEY_CURRENT_USER\Software\AMS\ProfileDemo</code>
	/// 
	///   Each section is then created as a subkey of this location on the registry. </remarks>
	public class Registry : Profile
	{
		// Fields
		private RegistryKey m_rootKey = Microsoft.Win32.Registry.CurrentUser;

		/// <summary>
		///   Initializes a new instance of the Registry class by setting the <see cref="Profile.Name" /> to <see cref="Profile.DefaultName" />. </summary>
		public Registry()
		{
		}

		/// <summary>
		///   Initializes a new instance of the Registry class by setting the <see cref="RootKey" /> and/or <see cref="Profile.Name" />. </summary>
		/// <param name="rootKey">
		///   If not null, this is used to initialize the <see cref="RootKey" /> property. </param>
		/// <param name="subKeyName">
		///   If not null, this is used to initialize the <see cref="Profile.Name" /> property. </param>
		public Registry(RegistryKey rootKey, string subKeyName) :
			base("")
		{
			if (rootKey != null)
				m_rootKey = rootKey;
			if (subKeyName != null)
				Name = subKeyName;
		}

		/// <summary>
		///   Initializes a new instance of the Registry class based on another Registry object. </summary>
		/// <param name="reg">
		///   The Registry object whose properties and events are used to initialize the object being constructed. </param>
		public Registry(Registry reg) :
			base(reg)
		{
			m_rootKey = reg.m_rootKey;
		}

		/// <summary>
		///   Gets the default name sub-key registry path. </summary>
		/// <exception cref="InvalidOperationException">
		///   Application.CompanyName or Application.ProductName are empty.</exception>
		/// <remarks>
		///   This is set to "Software\\" + Application.CompanyName + "\\" + Application.ProductName. </remarks>
		public override string DefaultName
		{
			get
			{
				if (Application.CompanyName == "" || Application.ProductName == "")
					throw new InvalidOperationException("Application.CompanyName and/or Application.ProductName are empty and they're needed for the DefaultName.");
				
				return "Software\\" + Application.CompanyName + "\\" + Application.ProductName;			
			}
		}

		/// <summary>
		///   Retrieves a copy of itself. </summary>
		/// <returns>
		///   The return value is a copy of itself as an object. </returns>
		/// <seealso cref="Profile.CloneReadOnly" />
		public override object Clone()
		{
			return new Registry(this);
		}

		/// <summary>
		///   Gets or sets the root RegistryKey object to use as the base for the <see cref="Profile.Name" />. </summary>
		/// <exception cref="InvalidOperationException">
		///   Setting this property if <see cref="Profile.ReadOnly" /> is true. </exception>
		/// <remarks>
		///   By default, this property is set to Microsoft.Win32.Registry.CurrentUser. 
		///   The <see cref="Profile.Changing" /> event is raised before changing this property.  
		///   If its <see cref="ProfileChangingArgs.Cancel" /> property is set to true, this method 
		///   returns immediately without changing this property.  After the property has been changed, 
		///   the <see cref="Profile.Changed" /> event is raised. </remarks>
		public RegistryKey RootKey
		{
			get 
			{ 
				return m_rootKey; 
			}
			set 
			{ 
				VerifyNotReadOnly();
				if (m_rootKey == value)
					return;
				
				if (!RaiseChangeEvent(true, ProfileChangeType.Other, null, "RootKey", value))
					return;
				
				m_rootKey = value; 
				RaiseChangeEvent(false, ProfileChangeType.Other, null, "RootKey", value);
			}
		}

		/// <summary>
		///   Retrieves a RegistryKey object for the given section. </summary>
		/// <param name="section">
		///   The name of the section to retrieve the key for. </param>
		/// <param name="create">
		///   If true, the key is created if necessary; otherwise it is just opened. </param>
		/// <param name="writable">
		///   If true the key is opened with write access; otherwise it is opened read-only. </param>
		/// <returns>
		///   The return value is a RegistryKey object representing the section's subkey. </returns>
		/// <exception cref="ArgumentException">
		///	  The length of <i>Name\section</i> is longer than 255 characters. </exception>
		/// <exception cref="SecurityException">
		///	  The user does not have RegistryPermission.SetInclude(create, currentKey) or RegistryPermission.SetInclude(open, currentKey) access. </exception>
		/// <exception cref="UnauthorizedAccessException">
		///	  The registry key cannot be written to (for example, it was opened as an unwritable key) </exception>
		/// <remarks>
		///   This method returns a key for the equivalent path: <see cref="RootKey" /> + "\\" + <see cref="Profile.Name" /> + "\\" + section </remarks>
		protected RegistryKey GetSubKey(string section, bool create, bool writable)		
		{
			VerifyName();
			
			string keyName = Name + "\\" + section;

			if (create)
				return m_rootKey.CreateSubKey(keyName);
			return m_rootKey.OpenSubKey(keyName, writable);
		}

		/// <summary>
		///   Sets the value for an entry inside a section. </summary>
		/// <param name="section">
		///   The name of the section that holds the entry. </param>
		/// <param name="entry">
		///   The name of the entry where the value will be set. </param>
		/// <param name="value">
		///   The value to set. If it's null, the entry is removed. </param>
		/// <exception cref="InvalidOperationException">
		///   <see cref="Profile.ReadOnly" /> is true or
		///   <see cref="Profile.Name" /> is null or empty. </exception>
		/// <exception cref="ArgumentNullException">
		///   Either section or entry is null, or 
		///	  the length of <i>Name\section</i> is longer than 255 characters. </exception>
		/// <exception cref="SecurityException">
		///	  The user does not have RegistryPermission.SetInclude(create, currentKey) or RegistryPermission.SetInclude(open, currentKey) access. </exception>
		/// <exception cref="UnauthorizedAccessException">
		///	  The registry key cannot be written to (for example, it was opened as an unwritable key) </exception>
		/// <remarks>
		///   If either the subkey, section, or entry does not exist, it is created.
		///   The <see cref="Profile.Changing" /> event is raised before setting the value.  
		///   If its <see cref="ProfileChangingArgs.Cancel" /> property is set to true, this method 
		///   returns immediately without setting the value.  After the value has been set, 
		///   the <see cref="Profile.Changed" /> event is raised. </remarks>
		/// <seealso cref="GetValue" />
		public override void SetValue(string section, string entry, object value)
		{
			// If the value is null, remove the entry
			if (value == null)
			{
				RemoveEntry(section, entry);
				return;
			}
			
			VerifyNotReadOnly();
			VerifyAndAdjustSection(ref section);
			VerifyAndAdjustEntry(ref entry);
			
			if (!RaiseChangeEvent(true, ProfileChangeType.SetValue, section, entry, value))
				return;
			
			using (RegistryKey subKey = GetSubKey(section, true, true))
				subKey.SetValue(entry, value);
			
			RaiseChangeEvent(false, ProfileChangeType.SetValue, section, entry, value);
		}

		/// <summary>
		///   Retrieves the value of an entry inside a section. </summary>
		/// <param name="section">
		///   The name of the section that holds the entry with the value. </param>
		/// <param name="entry">
		///   The name of the entry where the value is stored. </param>
		/// <returns>
		///   The return value is the entry's value, or null if the entry does not exist. </returns>
		/// <exception cref="ArgumentNullException">
		///   Either section or entry is null, or 
		///	  the length of <i>Name\section</i> is longer than 255 characters. </exception>
		/// <exception cref="SecurityException">
		///	  The user does not have RegistryPermission.SetInclude(delete, currentKey) access. </exception>
		/// <exception cref="UnauthorizedAccessException">
		///	  The registry key cannot be written to (for example, it was opened as an unwritable key) </exception>
		/// <seealso cref="SetValue" />
		/// <seealso cref="Profile.HasEntry" />
		public override object GetValue(string section, string entry)
		{
			VerifyAndAdjustSection(ref section);
			VerifyAndAdjustEntry(ref entry);

			using (RegistryKey subKey = GetSubKey(section, false, false))
				return (subKey == null ? null : subKey.GetValue(entry));
		}

		/// <summary>
		///   Removes an entry from a section. </summary>
		/// <param name="section">
		///   The name of the section that holds the entry. </param>
		/// <param name="entry">
		///   The name of the entry to remove. </param>
		/// <exception cref="InvalidOperationException">
		///   <see cref="Profile.ReadOnly" /> is true. </exception>
		/// <exception cref="ArgumentNullException">
		///   Either section or entry is null, or 
		///	  the length of <i>Name\section</i> is longer than 255 characters. </exception>
		/// <exception cref="SecurityException">
		///	  The user does not have RegistryPermission.SetInclude(create, currentKey) or RegistryPermission.SetInclude(open, currentKey) access. </exception>
		/// <exception cref="UnauthorizedAccessException">
		///	  The registry key cannot be written to (for example, it was opened as an unwritable key) </exception>
		/// <remarks>
		///   The <see cref="Profile.Changing" /> event is raised before removing the entry.  
		///   If its <see cref="ProfileChangingArgs.Cancel" /> property is set to true, this method 
		///   returns immediately without removing the entry.  After the entry has been removed, 
		///   the <see cref="Profile.Changed" /> event is raised. </remarks>
		/// <seealso cref="RemoveSection" />
		public override void RemoveEntry(string section, string entry)
		{
			VerifyNotReadOnly();
			VerifyAndAdjustSection(ref section);
			VerifyAndAdjustEntry(ref entry);
			
			using (RegistryKey subKey = GetSubKey(section, false, true))
			{
				if (subKey != null && subKey.GetValue(entry) != null)
				{
					if (!RaiseChangeEvent(true, ProfileChangeType.RemoveEntry, section, entry, null))
						return;
			
					subKey.DeleteValue(entry, false);
					RaiseChangeEvent(false, ProfileChangeType.RemoveEntry, section, entry, null);
				}
			}	
		}

		/// <summary>
		///   Removes a section. </summary>
		/// <param name="section">
		///   The name of the section to remove. </param>
		/// <exception cref="InvalidOperationException">
		///   <see cref="Profile.ReadOnly" /> is true. </exception>
		/// <exception cref="ArgumentNullException">
		///   section is null or 
		///	  the length of <i>Name\section</i> is longer than 255 characters. </exception>
		/// <exception cref="SecurityException">
		///	  The user does not have RegistryPermission.SetInclude(create, currentKey) or RegistryPermission.SetInclude(open, currentKey) access. </exception>
		/// <exception cref="UnauthorizedAccessException">
		///	  The registry key cannot be written to (for example, it was opened as an unwritable key) </exception>
		/// <remarks>
		///   The <see cref="Profile.Changing" /> event is raised before removing the section.  
		///   If its <see cref="ProfileChangingArgs.Cancel" /> property is set to true, this method 
		///   returns immediately without removing the section.  After the section has been removed, 
		///   the <see cref="Profile.Changed" /> event is raised. </remarks>
		/// <seealso cref="RemoveEntry" />
		public override void RemoveSection(string section)
		{
			VerifyNotReadOnly();
			VerifyName();
			VerifyAndAdjustSection(ref section);
			
			using (RegistryKey key = m_rootKey.OpenSubKey(Name, true))
			{
				if (key != null && HasSection(section))
				{
					if (!RaiseChangeEvent(true, ProfileChangeType.RemoveSection, section, null, null))
						return;
					
					key.DeleteSubKeyTree(section);
					RaiseChangeEvent(false, ProfileChangeType.RemoveSection, section, null, null);
				}
			}	
		}
		
		/// <summary>
		///   Retrieves the names of all the entries inside a section. </summary>
		/// <param name="section">
		///   The name of the section holding the entries. </param>
		/// <exception cref="ArgumentNullException">
		///   section is null or 
		///	  the length of <i>Name\section</i> is longer than 255 characters. </exception>
		/// <exception cref="SecurityException">
		///	  The user does not have RegistryPermission.SetInclude(delete, currentKey) access. </exception>
		/// <exception cref="UnauthorizedAccessException">
		///	  The registry key cannot be written to (for example, it was opened as an unwritable key) </exception>
		/// <returns>
		///   If the section exists, the return value is an array with the names of its entries; 
		///   otherwise it's null. </returns>
		/// <seealso cref="Profile.HasEntry" />
		/// <seealso cref="GetSectionNames" />
		public override string[] GetEntryNames(string section)
		{
			VerifyAndAdjustSection(ref section);

			using (RegistryKey subKey = GetSubKey(section, false, false))
			{
				if (subKey == null)
					return null;
				
				return subKey.GetValueNames();
			}				
		}		

		/// <summary>
		///   Retrieves the names of all the sections. </summary>
		/// <returns>
		///   If the XML file exists, the return value is an array with the names of all the sections;
		///   otherwise it's null. </returns>
		/// <exception cref="ArgumentNullException">
		///	  The length of the section is longer than 255 characters. </exception>
		/// <exception cref="SecurityException">
		///	  The user does not have RegistryPermission.SetInclude(delete, currentKey) access. </exception>
		/// <seealso cref="Profile.HasSection" />
		/// <seealso cref="GetEntryNames" />
		public override string[] GetSectionNames()
		{
			VerifyName();
			
			using (RegistryKey key = m_rootKey.OpenSubKey(Name))
			{
				if (key == null)
					return null;				
				return key.GetSubKeyNames();
			}				
		}		
	}
}
