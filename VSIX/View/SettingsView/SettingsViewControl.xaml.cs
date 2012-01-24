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
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using Cursors = System.Windows.Input.Cursors;
using MessageBox = System.Windows.MessageBox;
using MouseEventArgs = System.Windows.Input.MouseEventArgs;

namespace ThoughtWorks.VisualStudio
{
    /// <summary>
    /// Interaction logic for SettingsViewControl.xaml
    /// </summary>
    public partial class SettingsViewControl
    {
        /// <summary>
        /// Constructs a SettingsViewControl
        /// </summary>
        /// <remarks>This is a XAML form.</remarks>
        public SettingsViewControl()
        {
            FormIsDirty = false;
            InitializeComponent();
        }

        private bool AllSettingsHaveData()
        {
            return !string.IsNullOrEmpty(mingleHostTextBox.Text) && !string.IsNullOrEmpty(mingleUserTextBox.Text) && !string.IsNullOrEmpty(minglePasswordBox.Password);
        }

        /// <summary>
        /// Save changes to Settings and close the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSaveClick(object sender, RoutedEventArgs e)
        {
            if (mingleHostTextBox.Text.Substring(mingleHostTextBox.Text.Length - 1, 1).Equals("/"))
                mingleHostTextBox.Text = mingleHostTextBox.Text.Substring(0, mingleHostTextBox.Text.Length - 1);
            MingleSettings.Host = mingleHostTextBox.Text;
            MingleSettings.Login = mingleUserTextBox.Text;
            MingleSettings.Password = minglePasswordBox.Password;
            LogSettings.Trace = true;
            LogSettings.TraceEntryExit = false;
            if (FormIsDirty || AllSettingsHaveData())
            {
                DialogResult = true;
                return;
            }
            Close();
        }

        /// <summary>
        /// Fired when the pointer moves over the Save button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButtonSaveMouseEnter(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        /// <summary>
        /// Fired when the pointer leaves the Save button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButtonSaveMouseLeave(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Arrow;
        }

        /// <summary>
        /// Indicates whether changes have been made to any settings that have not been saved.
        /// </summary>
        internal bool FormIsDirty { get; set; }

        /// <summary>
        /// Fires when any text changes on the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnAnyTextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            FormIsDirty = true;
        }

        /// <summary>
        /// Close the Form. If there are unsaved Settings ask user if they need to be saved.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButtonCloseClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void OnWindowInitialized(object sender, EventArgs e)
        {
            minglePasswordBox.Password = MingleSettings.Password;
            if (string.IsNullOrWhiteSpace(minglePasswordBox.Password)) minglePasswordBox.Focus();
            mingleUserTextBox.Text = MingleSettings.Login;
            if (string.IsNullOrWhiteSpace(mingleUserTextBox.Text)) mingleUserTextBox.Focus();
            mingleHostTextBox.Text = MingleSettings.Host;
            if (string.IsNullOrWhiteSpace(mingleHostTextBox.Text)) mingleHostTextBox.Focus();
            FormIsDirty = false;
        }
    }
}