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
using System.Diagnostics;
using System.Windows;

namespace ThoughtWorks.VisualStudio
{
    /// <summary>
    /// Interaction logic for CardListWindow.xaml
    /// </summary>
    public partial class CardListWindow : Window
    {
        private readonly Cards _cardList;
        public Card SelectedCard { get; private set; }

        public CardListWindow(Cards cardList)
        {
            _cardList = cardList;
            InitializeComponent();
        }

        private void OnWindowIsInitialized(object sender, EventArgs e)
        {
            Debug.Assert(_cardList != null,"CardListWindow._cardList has not been initialized.");
            this.list.DataContext = _cardList;
            this.list.ItemsSource = _cardList;
        }

        private void OnSelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            SelectedCard = list.SelectedValue as Card;
            Close();
        }
    }
}
