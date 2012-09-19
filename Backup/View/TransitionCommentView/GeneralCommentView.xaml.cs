//
// Copyright © 2012 ThoughtWorks, Inc.
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

using System.ComponentModel;
using System.Windows;

namespace ThoughtWorks.VisualStudio
{
    /// <summary>
    /// Interaction logic for TransitionCommentView.xaml
    /// </summary>
    public partial class GeneralCommentView
    {
        private readonly string _requiredAdmonition = "";


        ///<summary>
        /// Displays a dialog to collect a comment from a user.
        ///</summary>
        /// <remarks>
        /// </remarks>
        public GeneralCommentView()
        {
            InitializeComponent();
        }

        ///<summary>
        /// Use this class to display a general purpose text/comment collection UI.
        ///</summary>
        /// <remarks>
        /// If the user does not supply data and tries to close this window then a warning dialog is shown
        /// with the requiredAdmonition message. A Yes response cancels the OnWindowClosing event giving the user 
        /// another opportunity to enter a comment. A No response allows the OnWindowClosing event to proceed
        /// and the window closes.
        /// 
        /// It is up to you to collect the resulting Comment from the Comment property and do with it what you will.
        /// </remarks>
        ///<param name="requiredAdmonition">This is the message displayed in a yes/no MessageBox if the user closes the window without supplying any data.</param>
        ///<param name="windowHeading">A message displayed at the top of the form. This this to tell your user what to do.</param>
        ///<param name="windowTitle">The title of the window.</param>
        public GeneralCommentView(string windowHeading, string requiredAdmonition, string windowTitle)
        {
            _requiredAdmonition = requiredAdmonition;
            this.windowHeading.Text = windowHeading;
            Title = windowTitle;
        }

        /// <summary>
        /// Returns the comment from the form.
        /// </summary>
        public string Comment
        {
            get { return comment.Text; }
        }

        ///<summary>
        /// Indicates whether the user is asking to POST this as a Murmur.
        ///</summary>
        public bool Murmur
        {
            get { return murmur.IsChecked != null && murmur.IsChecked.Value; }
        }

        private void OnWindowClosing(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(comment.Text)) return;

            MessageBoxResult result = MessageBox.Show(_requiredAdmonition, Title, MessageBoxButton.YesNo,
                                                      MessageBoxImage.Stop, MessageBoxResult.Yes);

            if (result == MessageBoxResult.No) return;

            e.Cancel = true;
        }
    }
}