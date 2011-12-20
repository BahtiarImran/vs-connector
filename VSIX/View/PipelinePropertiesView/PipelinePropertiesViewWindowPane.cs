//
// Copyright © ThoughtWorks Studios 2010, 2011
//
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell;
using ThoughtWorksGoLib;
using ThoughtWorksCoreLib;

namespace ThoughtWorks.VisualStudio.View.PipelinePropertiesView
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
    [Guid("595CD62E-AD8B-4B5C-9C3B-36C3C74C4BD1")]
    internal class PipelinePropertiesViewWindowPane : ToolWindowPane
    {
        private readonly PipelinePropertiesSearchViewControl _control;

        /// <summary>
        /// Standard constructor for the tool window.
        /// </summary>
        public PipelinePropertiesViewWindowPane()
            : base(null)
        {
            try
            {
                BitmapResourceID = 101;
                BitmapIndex = 0;
                _control = new PipelinePropertiesSearchViewControl();
                base.Content = _control;
            }
            catch (Exception e)
            {
                TraceLog.Exception(new StackFrame().GetMethod().Name, e);
                throw;
            }
        }

        /// <summary>
        /// Bind data to the ToolPaneWindow's controls
        /// </summary>
        internal void Bind(GoPipelineSearch query)
        {
            _control.Bind(query);
        }

        /// <summary>
        /// This is called after our control has been created and sited.
        /// This is a good place to initialize the control with data gathered
        /// from Visual Studio services.
        /// </summary>
        public override void OnToolWindowCreated()
        {
            base.OnToolWindowCreated();

            // Set the text that will appear in the title bar of the tool window.
            // Note that because we need access to the package for localization,
            // we have to wait to do this here. If we used a constant string,
            // we could do this in the constructor.
            Caption = Resources.GoPipelinePropertiesCaption;
        }
    }
}