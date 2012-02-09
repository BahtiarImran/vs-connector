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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ThoughtWorksCoreLib;

namespace ThoughtWorks.VisualStudio
{
    /// <summary>
    /// Interaction logic for CardListWindow.xaml
    /// </summary>
    public partial class CardListWindow
    {
        internal string SelectedCardName { get; private set; }
        internal string SelectedCardNumber { get; private set; }
        internal bool Cancelled = true;
        private readonly ViewModel _model;
        private readonly string _propertyLabel;

        /// <summary>
        /// Constructs a new CardListWindow
        /// </summary>
        /// <param name="model"></param>
        /// <param name="propertyLabel"></param>
        internal CardListWindow(ViewModel model, string propertyLabel)
        {
            SelectedCardNumber = "0";
            _model = model;
            _propertyLabel = propertyLabel;
            InitializeComponent();
        }

        /// <summary>
        /// Invoked after the window is intitialized 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowIsInitialized(object sender, EventArgs e)
        {
            try
            {
                _model.CardTypesDictionary.Keys.ToList().ForEach(k => AddCheckBox(k));
            }
            catch (Exception ex)
            {
                TraceLog.Exception(new StackFrame().GetMethod().Name, ex);
                AlertUser(ex);
            }
        }

        /// <summary>
        /// Add a check box to the UI
        /// </summary>
        /// <param name="k"></param>
        /// <returns></returns>
        private int AddCheckBox(string k)
        {
            var checkBox = new CheckBox {Content = k};
            checkBox.Checked += OnCardTypeCheckBoxChecked;
            checkBox.Unchecked += OnCardTypeCheckBoxChecked;
            if (k.Equals(_propertyLabel)) checkBox.IsChecked = true;
            SearchForCards();
            return cardTypes.Children.Add(checkBox);
        }

        /// <summary>
        /// Event handler invoked when the user checks a check box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCardTypeCheckBoxChecked(object sender, RoutedEventArgs e)
        {
            try
            {
                Cursor = Cursors.Wait;
                SearchForCards();
            }
            finally
            {
                Cursor = Cursors.Arrow;
            }
        }

        /// <summary>
        /// Event handler invoked when an item in the list is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnListSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (null == list.SelectedValue)
            {
                Cancelled = true;
                Close();
            }

            SelectedCardNumber = list.SelectedValue as string;
            SelectedCardName = (list.SelectedItem as CardListItem).Name;
        }

        /// <summary>
        /// Event handler invoked when an item in the list is committed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnListMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (null == list.SelectedValue)
            {
                return;
            }

            SelectedCardNumber = list.SelectedValue.ToString();
            Cancelled = false;
            Close();

        }

        /// <summary>
        /// Search for cards matching the list-indicated criteria
        /// </summary>
        private void SearchForCards()
        {
            var cards = new SortedList<int, CardListItem>();
            var types = new Collection<string>();

            foreach (
                CheckBox item in cardTypes.Children.Cast<CheckBox>().Where(item => Convert.ToBoolean(item.IsChecked)))
                types.Add(item.Content.ToString());

            if (types.Count == 0)
            {
                list.ItemsSource = cards.Values;
                return;
            }

            try
            {
                Cursor = Cursors.Wait;
                _model.GetCardList(types).ToList().ForEach(c => cards.Add(c.Number, c));
                list.DataContext = cards.Values;
                list.ItemsSource = cards.Values;
                list.SelectedValuePath = "Number";
            }
            catch (Exception ex)
            {
                TraceLog.Exception(new StackFrame().GetMethod().Name, ex);
                AlertUser(ex);
            }
            finally
            {
                Cursor = Cursors.Arrow;
            }
        }

        /// <summary>
        /// Display a message to the user
        /// </summary>
        /// <param name="ex"></param>
        private static void AlertUser(Exception ex)
        {
            string msg = ex.InnerException.Data.Count > 0
                             ? string.Format("{0}\n\n\r{1}", ex.Message, ex.InnerException.Data["url"])
                             : ex.Message;
            MessageBox.Show(msg, VisualStudio.Resources.MingleExtensionTitle);
        }
    }
}