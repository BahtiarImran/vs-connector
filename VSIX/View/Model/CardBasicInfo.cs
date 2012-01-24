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

using System.Globalization;

namespace ThoughtWorks.VisualStudio
{
    /// <summary>
    /// Supports a formatted string for listing cards in "number - (type) name" format
    /// </summary>
    public class CardBasicInfo
    {
        /// <summary>
        /// Card number
        /// </summary>
        public string Number { get; private set; }
        /// <summary>
        /// Card type
        /// </summary>
        public string Type { get; private set; }
        /// <summary>
        /// Card name
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Formatted card information
        /// </summary>
        public string Formatted
        {
            get { return string.Format(CultureInfo.InvariantCulture, "{0} - ({1}) {2}", Number, Type, Name); }
        }

        /// <summary>
        /// Constructs a basic card info object
        /// </summary>
        /// <param name="number"></param>
        /// <param name="type"></param>
        /// <param name="name"></param>
        public CardBasicInfo(int number, string type, string name)
        {
            Number = number.ToString(CultureInfo.InvariantCulture);
            Type = type;
            Name = name;
        }
    }
}
