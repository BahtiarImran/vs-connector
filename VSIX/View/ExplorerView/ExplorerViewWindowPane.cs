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
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell;
using ThoughtWorksCoreLib;

namespace ThoughtWorks.VisualStudio
{
    /// <summary>
    /// This class implements the tool window exposed by this package and hosts a user control.
    ///
    /// In Visual Studio tool windows are composed of a frame (implemented by the shell) and a pane, 
    /// usually implemented by the package implementer.
    ///
    /// This class derives from the ToolWindowPane class provided from the MPF in order to use its 
    /// implementation of the IVsUIElementPane interface.
    /// </summary>
    [Guid("E889901A-32B0-41DB-AFE8-0CA1FA860A58")]
    internal class ExplorerViewWindowPane : ToolWindowPane
    {
        private readonly ExplorerViewControl _control;

        /// <summary>
        /// Standard constructor for the tool window.
        /// </summary>
        public ExplorerViewWindowPane()
            : base(null)
        {
            try
            {
                BitmapResourceID = 101;
                BitmapIndex = 0;
                _control = new ExplorerViewControl();
                base.Content = _control;
            }
            catch (Exception e)
            {
                TraceLog.Exception(new StackFrame().GetMethod().Name, e);
                throw;
            }
        }

        /// <summary>
        /// This is called after our control has been created and sited.
        /// This is a good place to initialize the control with data gathered
        /// from Visual Studio services.
        /// </summary>
        public override void OnToolWindowCreated()
        {
            base.OnToolWindowCreated();
            _control.Package = (TwVscCommandsPackage) Package;
            Caption = Resources.ExplorerViewCaption;
        }
    }
}