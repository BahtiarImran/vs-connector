#region Copyright © 2010, 2011,2012, 2013 ThoughtWorks, Inc.

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

using ThoughtWorksMingleLib;

namespace ThoughtWorks.VisualStudio
{
    /// <summary>
    /// Models a Mingle card type
    /// </summary>
    public class CardType
    {
        private readonly MingleCardType _cardType;

        /// <summary>
        /// Constructs a new CardType
        /// </summary>
        /// <param name="cardType">A MingleCardType object</param>
        public CardType(MingleCardType cardType)
        {
            _cardType = cardType;
        }

        /// <summary>
        /// Card type name
        /// </summary>
        public string Name
        {
            get { return _cardType.Name; }
        }
    }
}