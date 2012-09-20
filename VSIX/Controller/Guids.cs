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

namespace ThoughtWorks.VisualStudio
{
    /// <summary>
    /// This class is used only to expose the list of Guids used by this package.
    /// This list of guids must match the set of Guids used inside the VSCT file.
    /// </summary>
    internal static class GuidsList
    {
        // Now define the list of guids as public static members.
        public static readonly Guid GuidTwVscPackage = new Guid("{D00EB40D-F709-49C6-B43F-D7910D730883}");
        public static readonly Guid GuidTwVscCmdSet = new Guid("{927BC402-45CF-43E5-BD57-B3A2A5B4D343}");
        public static readonly Guid GuidOutputWindowFrame = new Guid("{09CD66EE-C3A1-4C58-BD78-AF51833FFD44}");
    }
}