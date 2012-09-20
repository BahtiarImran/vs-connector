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

using System.Collections.ObjectModel;
using System.Linq;
using ThoughtWorksMingleLib;

namespace ThoughtWorks.VisualStudio
{
    /// <summary>
    /// A collection of Transitions
    /// </summary>
    public class TransitionsCollection : ObservableCollection<Transition>
    {
        private readonly IMingleProject _project;
        private readonly ViewModel _model;

        /// <summary>
        /// Constructs a new Transitions collection
        /// </summary>
        /// <param name="model"> </param>
        /// <param name="project"></param>
        public TransitionsCollection(ViewModel model, IMingleProject project)
        {
            _project = project;
            _model = model;
        }

        /// <summary>
        /// Refreshes the ViewModel's Transitions cache from the Project
        /// </summary>
        public void Refresh()
        {
            Clear();
            _project.GetTransitions().ToList().ForEach(t => Add(new Transition(_model, t.Value)));
        }
    }
}