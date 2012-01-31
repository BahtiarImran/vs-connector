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

        internal CardListWindow(ViewModel model)
        {
            SelectedCardNumber = "0";
            _model = model;
            InitializeComponent();
        }

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

        private int AddCheckBox(string k)
        {
            var checkBox = new CheckBox {Content = k};
            checkBox.Checked += OnCardTypeCheckBoxChecked;
            checkBox.Unchecked += OnCardTypeCheckBoxChecked;
            return cardTypes.Children.Add(checkBox);
        }

        private void OnCardTypeCheckBoxChecked(object sender, RoutedEventArgs e)
        {
            SearchForCards();
        }

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

        private void OnListMouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (null == list.SelectedValue)
            {
                Cancelled = true;
            }
            else
            {
                SelectedCardNumber = list.SelectedValue.ToString();
            }
            Cancelled = false;
            Close();
        }

        private void SearchForCards()
        {
            var cards = new SortedList<int, CardListItem>();
            var types = new Collection<string>();

            foreach (var item in cardTypes.Children.Cast<CheckBox>().Where(item => Convert.ToBoolean(item.IsChecked)))
                types.Add(item.Content.ToString());

            try
            {
                Cursor = System.Windows.Input.Cursors.Wait;
                _model.GetCardList(types).ToList().ForEach(c => cards.Add(c.Number, c));
                this.list.DataContext = cards.Values;
                this.list.ItemsSource = cards.Values;
                this.list.SelectedValuePath = "Number";
            }
            catch (Exception ex)
            {
                TraceLog.Exception(new StackFrame().GetMethod().Name, ex);
                AlertUser(ex);
            }
            finally
            {
                Cursor = System.Windows.Input.Cursors.Arrow;
            }
        }

        private static void AlertUser(Exception ex)
        {
            var msg = ex.InnerException.Data.Count > 0
                          ? string.Format("{0}\n\n\r{1}", ex.Message, ex.InnerException.Data["url"])
                          : ex.Message;
            MessageBox.Show(msg, VisualStudio.Resources.MingleExtensionTitle);
        }

    }
}
