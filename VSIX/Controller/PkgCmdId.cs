//
//Copyright 2011 ThoughtWorks, Inc.
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

namespace ThoughtWorks.VisualStudio
{
    /// <summary>
    /// This class is used to expose the list of the IDs of the commands implemented
    /// by this package. This list of IDs must match the set of IDs defined inside the
    /// Buttons section of the VSCT file.
    /// </summary>
    internal static class PkgCmdId
    {
        // Now define the list a set of public static members.
        public const int SettingsWindow = 0x2001;
        public const int CardListWindow = 0x2002;
        public const int CmdidTwCardsFilteredCommand = 0x2003;
        public const int PipelinePropertiesListWindow = 0x2004;
        public const int MingleExplorer = 0x2005;
        public const int CmdidTwNewCardCommand = 0x2006;
    }
}