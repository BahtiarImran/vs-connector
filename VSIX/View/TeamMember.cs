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
    public class TeamMember
    {
        private readonly MingleProjectMember _teamMember;
        public ViewModel Model;

        public TeamMember(ViewModel model)
        {
            Model = model;
        }

        /// <summary>
        /// Constructs a new TeamMember
        /// </summary>
        /// <param name="teamMember"></param>
        public TeamMember(ViewModel model, MingleProjectMember teamMember)
        {
            _teamMember = teamMember;
            Model = model;
        }

        /// <summary>
        /// Login id of the team member
        /// </summary>
        public string Name { get { return _teamMember.UserName; } }
        public string Login { get { return _teamMember.UserLogin; } }
        public bool IsAdmin { get { return _teamMember.ProjectAdmin; } }
    }
}