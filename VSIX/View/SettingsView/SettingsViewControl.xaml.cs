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
            InitializeComponent();
        }

        /// <summary>
        /// Close the Settings Form
        /// </summary>
        /// <remarks>
        /// If the user types any text into any field on the form or changes any setting then they are
        /// asked to save unsaved changes at this point. If they respond "yes" then this event is
        /// canceled.
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowClosing(object sender, CancelEventArgs e)
        {
            DialogResult = false;

            if (!_thereAreUnsavedChangedOnTheForm)
            {
                DialogResult = true;
                return; 
            }
            if (MessageBox.Show(VisualStudio.Resources.SettingsDataIsDirty, Title, MessageBoxButton.YesNo) !=
                MessageBoxResult.Yes)
            {
                e.Cancel = true;
                return; 
            }

            return;
        }

        /// <summary>
        /// Save changes to Settings and close the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSaveClick(object sender, RoutedEventArgs e)
        {
            MingleSettings.Host = mingleHostTextBox.Text;
            MingleSettings.Login = mingleUserTextBox.Text;
            MingleSettings.Password = minglePasswordBox.Password;
            //_settings.GoHost = goHostTextBox.Text;
            //_settings.GoLogin = goUserTextBox.Text;
            //_settings.GoPassword = ConvertStringToSecureString(goPasswordBox.Password);
            LogSettings.Trace = Convert.ToBoolean(enableLogging.IsChecked, CultureInfo.InvariantCulture);
            LogSettings.TraceEntryExit = Convert.ToBoolean(enableEntryExitLogging.IsChecked, CultureInfo.InvariantCulture);
            _thereAreUnsavedChangedOnTheForm = false;
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
        private bool _thereAreUnsavedChangedOnTheForm;

        /// <summary>
        /// Fires when any text changes on the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnAnyTextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            _thereAreUnsavedChangedOnTheForm = true;
        }

        /// <summary>
        /// Close the Form. If there are unsaved Settings ask user if they need to be saved.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButtonCloseClick(object sender, RoutedEventArgs e)
        {
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
            //goHostTextBox.Text = _settings.GoHost;
            //goUserTextBox.Text = _settings.GoLogin;
            //goPasswordBox.Password = ConvertSecureStringToString(_settings.GoPassword);
            radioNoGo.IsChecked = false;
            radio20.IsChecked = false;
            radio21.IsChecked = false;
            enableLogging.IsChecked = Convert.ToBoolean(LogSettings.Trace);
            _thereAreUnsavedChangedOnTheForm = false;
        }
    }
}