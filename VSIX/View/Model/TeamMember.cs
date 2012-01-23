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
    /// An individual Mingle project team member
    /// </summary>
    public class TeamMember : IManagedListItem
    {
        private const string _notSetMember = "<projects_member><user><name>xxxx</name><login>xxxx</login></user></projects_member>";
        private readonly MingleProjectMember _teamMember;
        internal ViewModel Model { get; set; }

        /// <summary>
        /// Constructs a TeamMember
        /// </summary>
        /// <param name="model"></param>
        internal TeamMember(ViewModel model)
        {
            Model = model;
            IsSet = true;
        }

        /// <summary>
        /// Constructs a TeamMember
        /// </summary>
        /// <param name="model"></param>
        /// <param name="set"></param>
        internal TeamMember(ViewModel model, bool set)
        {
            Model = model;
            IsSet = set;
            _teamMember = new MingleProjectMember(_notSetMember.Replace("xxxx", Resources.ItemNotSet));
        }

        /// <summary>
        /// Constructs a new TeamMember
        /// </summary>
        /// <param name="teamMember"></param>
        internal TeamMember(ViewModel model, MingleProjectMember teamMember)
        {
            _teamMember = teamMember;
            Model = model;
        }

        /// <summary>
        /// Login name of the team member
        /// </summary>
        internal string Name { get { return _teamMember.UserName; } }
        /// <summary>
        /// Login name of the team member
        /// </summary>
        internal string Login { get { return _teamMember.UserLogin; } }
        /// <summary>
        /// Indicates whether the team member has administrative privilges
        /// </summary>
        internal bool IsAdmin { get { return _teamMember.ProjectAdmin; } }

        /// <summary>
        /// Indicates that the Team Member is set
        /// </summary>
        public bool IsSet { get; private set; }

    }
}