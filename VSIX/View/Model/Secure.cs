//
// Copyright © 2010, 2011 ThoughtWorks, Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License"); 
// you may not use this file except in compliance with the License. 
// You may obtain a copy of the License at:
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software 
// distributed under the License is distributed on an "AS IS" BASIS, 
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
// See the License for the specific language governing permissions and 
// limitations under the License.
//

using System;
using System.Runtime.InteropServices;
using System.Security;

namespace ThoughtWorks.VisualStudio
{
    /// <summary>
    /// A class supporting untility functions for security
    /// </summary>
    public class Secure : IDisposable
    {
        private static SecureString _ss = new SecureString();
        private bool _disposed;

        /// <summary>
        /// Converts a String into a read-only SecureString
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static SecureString GetSecureStringFromString(string value)
        {
            if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("value");

            foreach (var c in value.ToCharArray())
            {
                _ss.AppendChar(c);
            }
            _ss.MakeReadOnly();
            return _ss;
        }

        /// <summary>
        /// Takes a SecureString and returns a String
        /// </summary>
        /// <param name="secureString"></param>
        /// <returns>Empty string if an exception is thrown publicly</returns>
        public static string GetStringFromSecureString(SecureString secureString)
        {
            var unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);
            try
            {
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        virtual protected void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
                if (_ss != null)
                    _ss.Dispose();
                Console.WriteLine(VisualStudio.Resources.SettingsViewControl_Dispose_Object_disposed_);
            }

            _ss = null;
            _disposed = true;
        }

    }
}