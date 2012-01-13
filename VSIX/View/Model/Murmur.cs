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
using System.Globalization;

namespace ThoughtWorks.VisualStudio
{
    /// <summary>
    /// Models a murmur for Mingle Extension
    /// </summary>
    public class Murmur
    {
        /// <summary>
        /// Name fo the sender of the murmur
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Date the murmur was sent
        /// </summary>
        public string Date { get; private set; }
        /// <summary>
        /// Body of the murmur
        /// </summary>
        public string Body { get; private set; }
        /// <summary>
        /// Constructs a new murmur
        /// </summary>
        /// <param name="name"></param>
        /// <param name="date"></param>
        /// <param name="body"></param>
        public Murmur (string name, string date, string body)
        {
            Name = name;
            Date = Convert.ToDateTime(date).ToString(CultureInfo.InvariantCulture);
            Body = body;
        }
    }
}
