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

using ThoughtWorksMingleLib;

namespace ThoughtWorks.VisualStudio
{
    /// <summary>
    /// A Transition as exposed by the ViewModel
    /// </summary>
    public class Transition
    {
        private readonly MingleTransition _transition;

        /// <summary>
        /// Constructs a new Transition
        /// </summary>
        /// <param name="transition"></param>
        public Transition(MingleTransition transition)
        {
            _transition = transition;
        }

        public string Name { get { return _transition.Name; } set { _transition.Name = value; } }
        public int Id { get { return _transition.Id; } set { _transition.Id = value; } }
        public string Url { get { return _transition.Url; } set { _transition.Url = value; } }
        public bool RequireComment { get { return _transition.RequireComment; } set { _transition.RequireComment = value; } }
        public string CardTypeName { get { return _transition.CardTypeName; } set { _transition.CardTypeName = value; } }
        public string CardTypeUrl { get { return _transition.CardTypeUrl; } set { _transition.CardTypeUrl = value; } }

        /// <summary>
        /// Updates a card with this transition
        /// </summary>
        /// <param name="number"></param>
        public void Update(int number)
        {
            _transition.Update(number);
        }
    }
}