#region Copyright © 2011, 2012 ThoughtWorks, Inc.

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
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ThoughtWorks.VisualStudio
{
    /// <summary>
    /// Models card_types for the view
    /// </summary>
    [Serializable]
    public class CardTypesDictionary : Dictionary<string, CardType>
    {
        /// <summary>
        /// Constructs a new card type
        /// </summary>
        public CardTypesDictionary()
        {
        }

        /// <summary>
        /// Serialization constructor
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected CardTypesDictionary(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}