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

        public MurmurViewControl(ViewModel model)
        {
            Model = model;
            InitializeComponent();
        }

        private void OnClickButtonMurmur(object sender, RoutedEventArgs e)
        {
            var murmur = string.Format(CultureInfo.InvariantCulture, "murmur[body]={0}", murmurText.Text);
            try
            {
                Model.Mingle.Post(MingleSettings.Project, "/murmurs.xml", new Collection<string> { murmur });
            }
            catch (Exception ex)
            {
                TraceLog.Exception(new StackFrame().GetMethod().Name, ex);
                MessageBox.Show(ex.Message);
            }
        }
    }
}
