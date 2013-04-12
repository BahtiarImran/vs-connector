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

using System;
using System.Diagnostics;
using System.Globalization;
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
    [Guid("E818D76B-46CE-42F4-AF85-DF1198A36C6D")]
    internal class CardViewWindowPane : ToolWindowPane
    {
        /// <summary>
        /// Standard constructor for the tool window.
        /// </summary>
        public CardViewWindowPane()
            : base(null)
        {
            try
            {
                base.Content = new CardViewControl();
            }
            catch (Exception e)
            {
                TraceLog.Exception(new StackFrame().GetMethod().Name, e);
                throw;
            }
        }

        /// <summary>
        /// Binds the CardViewControl content of this window to its data.
        /// </summary>
        internal void Bind(Card card, Action refreshMurmurs)
        {
            var window = (CardViewControl) base.Content;

            Caption = string.Format(CultureInfo.CurrentCulture, Resources.CardWindowCaption, card.Number,
                                    card.Name);
            window.Bind(card);
            window.RefreshMurmurs = refreshMurmurs;
        }

        /// <summary>
        /// This is called after our control has been created and sited.
        /// This is a good place to initialize the control with data gathered
        /// from Visual Studio services.
        /// </summary>
        public override void OnToolWindowCreated()
        {
            base.OnToolWindowCreated();
            var window = (CardViewControl) base.Content;
            window.ToolPane = this;
            // Set the text that will appear in the title bar of the tool window.
            // Note that because we need access to the package for localization,
            // we have to wait to do this here. If we used a constant string,
            // we could do this in the constructor.
        }
    }
}