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
    /// A card comment
    /// </summary>
    public class CardComment
    {
        /// <summary>
        /// Text of the comment
        /// </summary>
        public string Comment { get; private set; }
        /// <summary>
        /// Name of the commenter
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Date of the comment
        /// </summary>
        public string Date { get; private set; }
        /// <summary>
        /// Constructs a new CardComment
        /// </summary>
        /// <param name="comment"></param>
        /// <param name="name"></param>
        /// <param name="date"></param>
        public CardComment(string comment, string name, string date)
        {
            Comment = comment;
            Name = name;
            Date = Convert.ToDateTime(date, CultureInfo.InvariantCulture).ToString(CultureInfo.InvariantCulture);
        }
    }
}
