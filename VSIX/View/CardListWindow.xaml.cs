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

namespace ThoughtWorks.VisualStudio
{
    /// <summary>
    /// Interaction logic for CardListWindow.xaml
    /// </summary>
    public partial class CardListWindow : Window
    {
        private readonly XElement _cardList;
        public string SelectedCardName { get; private set; }
        public int SelectedCardNumber { get; private set; }

        public CardListWindow(XElement cardList)
        {
            _cardList = cardList;
            InitializeComponent();
        }

        private void OnWindowIsInitialized(object sender, EventArgs e)
        {
            Debug.Assert(_cardList != null,"CardListWindow._cardList has not been initialized.");
            var cards = new SortedList<string, CardItem>();
            _cardList.Elements("result").ToList().ForEach(c => cards.Add(c.Element("number").Value, new CardItem{Number=c.Element("number").Value, Name=c.Element("name").Value}));
            this.list.DataContext = cards.Values;
            this.list.ItemsSource = cards.Values;
            this.list.SelectedValuePath = "Number";
        }

        private void OnSelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            SelectedCardNumber = null == list.SelectedValue ? 0 : int.Parse(list.SelectedValue as string);
            SelectedCardName = null == list.SelectedItem ? string.Empty :  (list.SelectedItem as CardItem).Name;
            Close();
        }
    }

    public class CardItem
    {
        public string Number { get; set; }
        public string Name { get; set; }
    }
}
