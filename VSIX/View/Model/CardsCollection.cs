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

using System.Collections.ObjectModel;
using System.Linq;
using ThoughtWorksMingleLib;

namespace ThoughtWorks.VisualStudio
{
    /// <summary>
    /// Collection of Cards
    /// </summary>
    public class CardsCollection : ObservableCollection<Card>
    {
        private readonly IMingleProject _project;
        private readonly ViewModel _model;

        /// <summary>
        /// Constructs a Cards collection
        /// </summary>
        /// <param name="project"></param>
        /// <param name="model"></param>
        public CardsCollection(IMingleProject project, ViewModel model)
        {
            _project = project;
            _model = model;
        }

        /// <summary>
        /// Refresh the cache of cards for a Favorite in the ViewModel
        /// </summary>
        /// <param name="view"></param>
        public void RefreshView(string view)
        {
            Clear();
            _project.GetView(view).ToList().ForEach(c => Add(new Card(c, _model)));
        }
    }
}