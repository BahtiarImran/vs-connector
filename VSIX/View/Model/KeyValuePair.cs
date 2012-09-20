﻿#region Copyright © 2011, 2012 ThoughtWorks, Inc.

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

#endregion

namespace ThoughtWorks.VisualStudio
{
    /// <summary>
    /// Describes a key/value pair for project name and identifier
    /// </summary>
    public class KeyValuePair
    {
        /// <summary>
        /// Key
        /// </summary>
        public string Key { get; private set; }

        /// <summary>
        /// Value
        /// </summary>
        public string Value { get; private set; }

        /// <summary>
        /// Constructs a new KeyValuePair
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public KeyValuePair(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }
}