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
using System.Collections;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Windows;
using ThoughtWorks.VisualStudio.Properties;
using ThoughtWorksCoreLib;

namespace ThoughtWorks.VisualStudio
{
    /// <summary>
    /// Interaction logic for FeedbackView.xaml
    /// </summary>
    public partial class FeedbackViewControl : IDisposable
    {
        private BackgroundWorker _worker;
        private bool _disposed;

        ///<summary>
        /// This control handles the user interface and submission of feedback email.
        ///</summary>
        public FeedbackViewControl()
        {
            InitializeComponent();
            _worker = new BackgroundWorker();
        }

        private void OnButtonCancelClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void OnButtonSubmitClick(object sender, RoutedEventArgs e)
        {
            var mapidata = new Hashtable();

            mapidata.Add("email", emailData);
            mapidata.Add("company", companyData);
            mapidata.Add("defect", bug.IsChecked == true ? true : false);
            mapidata.Add("feature", feature.IsChecked == true ? true : false);
            mapidata.Add("description", descriptionData.Text);
            mapidata.Add("filepath", string.Empty);
            if (attachLog.IsChecked == true)
                mapidata["filepath"] = TraceLog.FilePath;

            // Run the default email client in a separate thread, freeing up
            // Visual Studio for the user.

            //_worker.DoWork += delegate(object s, DoWorkEventArgs args)
            //                      {
            Hashtable data = mapidata; //(Hashtable)args.Argument;
            var mapi = new Mapi();
            foreach (string recipient in Settings.Default.FeedbackEmailRecipients.Split(','))
                mapi.AddRecipientTo(recipient);

            foreach (string email in emailData.Text.Split(','))
                mapi.AddRecipientCc(email);

            string feedbackType = string.Empty;

            if ((bool) data["defect"]) feedbackType = VisualStudio.Resources.FeedbackTypeDefect;
            else if ((bool) data["feature"]) feedbackType = VisualStudio.Resources.FeedbackTypeFeature;

            string subjectLine = string.Format(CultureInfo.CurrentCulture, "TSVC {0} - {1} - {2} ({3})",
                                               Assembly.GetExecutingAssembly().GetName().Version, feedbackType,
                                               ((string) data["description"]).Substring(0,
                                                                                        ((string) data["description"]).
                                                                                            Length > 50
                                                                                            ? 50
                                                                                            : ((string)
                                                                                               data["description"]).
                                                                                                  Length),
                                               companyData.Text);

            if (!string.IsNullOrEmpty((string) data["filepath"]))
                // Attach the log.
                mapi.AddAttachment(TraceLog.FilePath);

            mapi.SendMailPopup(subjectLine, (string) data["description"]);
            //};

            //_worker.RunWorkerAsync(mapidata);

            emailData.Text = string.Empty;
            companyData.Text = string.Empty;
            descriptionData.Text = string.Empty;
            attachLog.IsChecked = true;
            Close();
        }

        private void OnWindowClosing(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(emailData.Text)
                && string.IsNullOrWhiteSpace(companyData.Text)
                && string.IsNullOrWhiteSpace(descriptionData.Text))
            {
                return;
            }

            if (MessageBox.Show(VisualStudio.Resources.FeedbackDataUnsubmittedWarning, Title, MessageBoxButton.YesNo) ==
                MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }

        private void OnWindowInitialized(object sender, EventArgs e)
        {
            Title = VisualStudio.Resources.FeedbackFormTitle;
            emailLabel.Text = VisualStudio.Resources.FeedbackFormEmailLabel;
            companyLabel.Text = VisualStudio.Resources.FeedbackFormCompanyLabel;
            descriptionLabel.Text = VisualStudio.Resources.FeedbackFormDescriptionLabel;
            buttonSubmit.Content = VisualStudio.Resources.SubmitLabel;
            buttonCancel.Content = VisualStudio.Resources.CancelLabel;
            descriptionData.ToolTip = VisualStudio.Resources.FeedbackDescriptionToolTip;
            if (Settings.Default.FeedbackAllowAttachment) return;
            attachLog.Visibility = Visibility.Hidden;
            attachLog.IsChecked = false;
        }

        private void OnEmailDataLostFocus(object sender, RoutedEventArgs e)
        {
            // TODO VALIDATE EMAIL ADDRESSES
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
                if (_worker != null)
                    _worker.Dispose();
                Console.WriteLine(VisualStudio.Resources.SettingsViewControl_Dispose_Object_disposed_);
            }

            _worker = null;
            _disposed = true;
        }
    }
}