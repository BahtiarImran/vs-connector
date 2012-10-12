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
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using ThoughtWorksCoreLib;

namespace ThoughtWorks.VisualStudio
{
    /// <summary>
    /// This is the class that implements the package. This is the class that Visual Studio will create
    /// when one of the commands will be selected by the user, and so it can be considered the main
    /// entry point for the integration with the IDE.
    /// Notice that this implementation derives from Microsoft.VisualStudio.Shell.Package that is the
    /// basic implementation of a package provided by the Managed Package Framework (MPF).
    /// </summary>
    [ProvideToolWindow(typeof (CardSetViewWindowPane), Transient = true)]
    [ProvideToolWindow(typeof (CardViewWindowPane), Transient = true)]
    [ProvideToolWindow(typeof (ExplorerViewWindowPane))]
    [ProvideToolWindow(typeof (MurmurViewWindowPane), Transient = true)]
    [ProvideToolWindowVisibility(typeof (CardSetViewWindowPane), /*UICONTEXT_SolutionExists*/
        "E3FCA72F-B3A4-406E-A4AA-1051594D2367")]
    [ProvideToolWindowVisibility(typeof (CardViewWindowPane), /*UICONTEXT_SolutionExists*/
        "59373D4C-3F6C-4031-AF08-D11D4CCFC45B")]
    [ProvideToolWindowVisibility(typeof (ExplorerViewWindowPane), /*UICONTEXT_SolutionExists*/
        "E03D0A03-6B80-48D4-9A61-220CD2033698")]
    [ProvideToolWindowVisibility(typeof (MurmurViewWindowPane), /*UICONTEXT_SolutionExists*/
        "E03D0A03-6B80-48D4-9A61-220CD2033698")]
    [ProvideMenuResource(1000, 1)]
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("Mingle Extension for Visual Studio", "Context-relevant connections to Mingle.",
        "1.1.1")]
    [Guid("D00EB40D-F709-49C6-B43F-D7910D730883")]
    public sealed class TwVscCommandsPackage : Package
    {
        // Cache the Menu Command Service since we will use it multiple times
        private OleMenuCommandService _menuService;

        /// <summary>
        /// Default constructor of the package. This is the constructor that will be used by VS
        /// to create an instance of your package. Inside the constructor you should do only the
        /// more basic initializazion like setting the initial value for some member variable. But
        /// you should never try to use any VS service because this object is not part of VS
        /// environment yet; you should wait and perform this kind of initialization inside the
        /// Initialize method.
        /// </summary>
        public TwVscCommandsPackage()
        {
            TraceLog.Initialize("VsAddIn");
            TraceLog.WriteLine(new StackFrame().GetMethod().Name, "****** LAUNCHING THE EXTENSION ******");
        }

        /// <summary>
        /// Initialization of the package; this is the place where you can put all the initialization
        /// code that relies on services provided by Visual Studio.
        /// </summary>
        protected override void Initialize()
        {
            // Trace the beginning of this method and call the base implementation.
            base.Initialize();

            // Now get the OleCommandService object provided by the MPF; this object is the one
            // responsible for handling the collection of commands implemented by the package.
            var mcs = GetService(typeof (IMenuCommandService)) as OleMenuCommandService;
            if (null == mcs) return;

            // Now create one object derived from MenuCommand for each command defined in
            // the VSCT file and add it to the command service.

            // For each command we have to define its id that is a unique Guid/integer pair.
            //var id = new CommandID(GuidsList.guidTwVscCmdSet, PkgCmdId.CardListWindow);
            //DefineCommandHandler(ShowListOfCards, id);

            var id = new CommandID(GuidsList.GuidTwVscCmdSet, PkgCmdId.MingleExplorer);
            DefineCommandHandler(ShowMingleExplorer, id);
        }

        /// <summary>
        /// Define a command handler.
        /// When the user presses the button corresponding to the CommandID
        /// the EventHandler is called.
        /// </summary>
        /// <param name="id">The CommandID (Guid/ID pair) as defined in the .vsct file</param>
        /// <param name="handler">Method that should be called to implement the command</param>
        /// <returns>The menu command. This can be used to set parameter such as the default visibility once the package is loaded</returns>
        internal OleMenuCommand DefineCommandHandler(EventHandler handler, CommandID id)
        {
            // if the package is zombied, we don't want to add commands
            if (Zombied)
                return null;

            // Make sure we have the service
            if (_menuService == null)
            {
                // Get the OleCommandService object provided by the MPF; this object is the one
                // responsible for handling the collection of commands implemented by the package.
                _menuService = GetService(typeof (IMenuCommandService)) as OleMenuCommandService;
            }
            OleMenuCommand command = null;
            if (null != _menuService)
            {
                // Add the command handler
                command = new OleMenuCommand(handler, id);
                _menuService.AddCommand(command);
            }

            return command;
        }

        #region Commands Actions

        /// <summary>
        /// Event handler called when the user selects the Explorer View command.
        /// </summary>
        /// <param name="caller"></param>
        /// <param name="args"></param>
        internal void ShowMingleExplorer(object caller, EventArgs args)
        {
            try
            {
                TraceLog.WriteLine(new StackFrame().GetMethod().Name, "Creating the Explorer window pane");
                ToolWindowPane window = FindToolWindow(typeof (ExplorerViewWindowPane), 0, true);

                if ((null == window) || (null == window.Frame))
                    throw new NotSupportedException(Resources.CanNotCreateWindow);

                TraceLog.WriteLine(new StackFrame().GetMethod().Name,
                                   "Handing the ViewModel to the ExplorerViewControl window");

                var frame = (IVsWindowFrame) window.Frame;

                ErrorHandler.ThrowOnFailure(frame.Show());
            }
            catch (Exception e)
            {
                TraceLog.Exception(new StackFrame().GetMethod().Name, e);
                MessageBox.Show(e.Message, Resources.MingleExtensionTitle);
            }
        }

        #endregion
    }
}