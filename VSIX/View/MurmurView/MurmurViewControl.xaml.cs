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
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using ThoughtWorksCoreLib;

namespace ThoughtWorks.VisualStudio
{
    /// <summary>
    /// Interaction logic for MurmurViewControl.xaml
    /// </summary>
    public partial class MurmurViewControl : UserControl
    {
        protected ViewModel Model { get; set; }

        /// <summary>
        /// Constructs a new MurmurViewControl
        /// </summary>
        /// <param name="model">ViewModel object</param>
        public MurmurViewControl()
        {
            InitializeComponent();
        }

        private void OnClickButtonMurmur(object sender, RoutedEventArgs e)
        {
            var murmur = string.Format(CultureInfo.InvariantCulture, "murmur[body]={0}", murmurText.Text);
            try
            {
                Model.Mingle.Post(MingleSettings.Project, "/murmurs.xml", new Collection<string> { murmur });
                murmursList.ItemsSource = Model.GetMurmurs();
            }
            catch (Exception ex)
            {
                TraceLog.Exception(new StackFrame().GetMethod().Name, ex);
                MessageBox.Show(ex.Message);
            }
        }

        private void OnMurmurViewControlInitialized(object sender, EventArgs e)
        {
            CheckSettings();
            
            Model = new ViewModel(MingleSettings.Host, MingleSettings.Login, MingleSettings.Password);
            
            if (string.IsNullOrEmpty(MingleSettings.Project))
            {
                MessageBox.Show("Please open Mingle Explorer and select a project before opening the murmurs window.");
                return;
            }

            Model.SelectProject(MingleSettings.Project);

            murmursList.ItemsSource = Model.GetMurmurs();

        }

        /// <summary>
        /// Check settings and ask user to supply missing settings. 
        /// </summary>
        private static void CheckSettings()
        {
            if (!string.IsNullOrWhiteSpace(MingleSettings.Login) &&
                !string.IsNullOrEmpty(MingleSettings.Password) &&
                !string.IsNullOrWhiteSpace(MingleSettings.Host))
            {
                return;
            }

            var svc = new SettingsViewControl();
            svc.ShowDialog();
        }

    }
}
