﻿//
// Copyright © ThoughtWorks Studios 2011
//
using System;
using System.Runtime.InteropServices;
using System.Security;

namespace ThoughtWorks.VisualStudio
{
	/// <summary>
	/// This class supports persistance of user and application settings. 
	/// </summary>
	public static class MingleSettings 
	{
		private static readonly Properties.Settings Settings = new Properties.Settings();

		/// <summary>
		/// The host URL to use for Mingle
		/// </summary>
		public static string Host
		{
			get { return Settings.MingleHost; }
			set
			{
				Settings.MingleHost = value; 
				Settings.Save();
			}
		}

		/// <summary>
		/// Mingle login name
		/// </summary>
		public static string Login
		{
			get { return Settings.MingleUser; }
			set
			{
				Settings.MingleUser = value; 
				Settings.Save();
			}
		}

		/// <summary>
		/// Password as a String
		/// </summary>
		public static string Password
		{
			get
			{
				return Settings.MinglePassword;
			}
			set
			{
				Settings.MinglePassword = value; 
				Settings.Save();
			}
		}

		/// <summary>
		/// Mingle project ID
		/// </summary>
		public static string Project
		{
			get { return Settings.MingleProject; }
			set 
			{ 
				Settings.MingleProject = value;
				Settings.Save();
			}
		}

		/// <summary>
		/// Password encoded as a SecureString
		/// </summary>
		public static string SecurePassword
		{
			get { return Settings.MinglePassword; }
		}

		/// <summary>
		/// Sets all Mingle settings at once
		/// </summary>
		/// <param name="host"></param>
		/// <param name="login"></param>
		/// <param name="password"></param>
		public static void Set(string host, string login, string password)
		{
			Host = host;
			Login = login;
			Password = password;
		}

		#region SecureString conversion
        //        /// <summary>
        ///// Converts String to SecureString
        ///// </summary>
        ///// <param name="text"></param>
        ///// <returns></returns>
        //private static SecureString ConvertStringToSecureString(string text)
        //{
        //    var ss = new SecureString();
        //    foreach (var c in text.ToCharArray())
        //    {
        //        ss.AppendChar(c);
        //    }
        //    return ss;
        //}

        ///// <summary>
        ///// Converts a SecureString to String
        ///// </summary>
        ///// <param name="secureString"></param>
        ///// <returns>The password as a string or if the conversion fails then an empty string is returned.</returns>
        //private static string ConvertSecureStringToString(SecureString secureString)
        //{
        //    if (null == secureString)
        //    {
        //        secureString = new SecureString();
        //    }

        //    var unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);
        //    try
        //    {
        //        return Marshal.PtrToStringUni(unmanagedString);
        //    }
        //    catch (Exception)
        //    {
        //        return string.Empty;
        //    }
        //    finally
        //    {
        //        Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
        //    }
 
        //}
		#endregion
	}
}
