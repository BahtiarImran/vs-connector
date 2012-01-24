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
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Xml.Linq;
using ThoughtWorksCoreLib;

namespace ThoughtWorks.VisualStudio
{
    /// <summary>
    /// Interaction logic for CardListWindow.xaml
    /// </summary>
    public partial class CardListWindow
    {
        private readonly XElement _cardList;
        internal string SelectedCardName { get; private set; }
        internal string SelectedCardNumber { get; private set; }
        internal bool Cancelled = true;

        internal CardListWindow(XElement cardList)
        {
            _cardList = cardList;
            SelectedCardNumber = "0";
            InitializeComponent();
        }

        private void OnWindowIsInitialized(object sender, EventArgs e)
        {
            Debug.Assert(_cardList != null,"CardListWindow._cardList has not been initialized.");
            var cards = new SortedList<int, CardItem>();
            try
            {
                _cardList.Elements("result").ToList().ForEach(c => cards.Add(int.Parse(c.Element("number").Value as string), 
                    new CardItem { Number = c.Element("number").Value, Name = "(" + c.Element("type").Value + ") " + c.Element("name").Value }));

            }
            catch (Exception ex)
            {
                TraceLog.Exception(new StackFrame().GetMethod().Name, ex);
                MessageBox.Show(
                    string.Format("Encountered an error parsing the list of cards received from Mingle.\n\n{0}",
                                  ex.Message));
            } 
            
            this.list.DataContext = cards.Values;
            this.list.ItemsSource = cards.Values;
            this.list.SelectedValuePath = "Number";
        }

        private void OnListSelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (null == list.SelectedValue)
            {
                Cancelled = true;
                Close();
            }

            SelectedCardNumber = list.SelectedValue as string;
            SelectedCardName = (list.SelectedItem as CardItem).Name;

        }

        private void OnListMouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (null == list.SelectedValue)
            {
                Cancelled = true;
            }

            Cancelled = false;
            Close();
        }

}
    /// <summary>
    /// Describes a card's name and number
    /// </summary>
    public class CardItem
    {
        /// <summary>
        /// Card name
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// Card number
        /// </summary>
        public string Name { get; set; }
    }
}
