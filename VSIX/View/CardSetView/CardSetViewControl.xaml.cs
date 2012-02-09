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
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using ThoughtWorksCoreLib;
using ThoughtWorksMingleLib;

namespace ThoughtWorks.VisualStudio
{
    /// <summary>
    /// Interaction logic for CardViewControl.xaml
    /// </summary>
    public partial class CardSetViewControl
    {
        private MingleCardCollection _currentCardCollection;

        /// <summary>
        /// Construct a CardSetView View from only this user's Cards
        /// </summary>
        internal CardSetViewControl()
        {
            InitializeComponent();
        }

        #region Bind (list of cards to the grid)

        /// <summary>
        /// Bind data to the form.
        /// </summary>
        /// <remarks>Binds data to the form.</remarks>
        internal void Bind(MingleCardCollection cardCollection)
        {
            //Debug.Assert(null != cardCollection);
            string me = new StackFrame().GetMethod().Name;

            _currentCardCollection = cardCollection;

            // Add columns for base card properties to the grid
            dataGrid.Columns.Clear();
            dataGrid.Columns.Add(NewTextColumn(VisualStudio.Resources.CardNumber, "Number"));
            dataGrid.Columns.Add(NewTextColumn(VisualStudio.Resources.CardName, "Name"));
            dataGrid.Columns.Add(NewTextColumn(VisualStudio.Resources.CardType, "Type"));
            dataGrid.Columns.Add(NewTextColumn(VisualStudio.Resources.CardVersion, "Version"));
            dataGrid.Columns.Add(NewTextColumn(VisualStudio.Resources.CardRank, "Rank"));

            dataGrid.ItemsSource = cardCollection;

            TraceLog.WriteLine(me, "CardSetView window grid has data: " + dataGrid.Items.Count + "cards.");

            if (dataGrid.Items.Count == 0)
                MessageBox.Show(VisualStudio.Resources.CardSetIsEmpty);
        }

        #endregion

        /// <summary>
        /// Used to pass the Package object downstream.
        /// </summary>
        internal Package Package { private get; set; }

        private static DataGridTextColumn NewTextColumn(string name, string binding)
        {
            var col = new DataGridTextColumn
                          {
                              Header = name,
                              Binding = new Binding(binding),
                          };

            if (name == "Name") col.Width = 400;

            return col;
        }

        #region OnMouseDown

        /// <summary>
        /// Handles click events on the grid, whiches raises a list of Transitions in a context menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.RightButton == MouseButtonState.Pressed)
            {
                return;
            }

            if (e.LeftButton == MouseButtonState.Released)
            {
                dataGrid.SelectedItem = dataGrid.CurrentItem;
                return;
            }
        }

        #endregion

        #region OnSelectionChanged

        /// <summary>
        /// Open a CardView for this card
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGrid.CurrentItem == null) return;

            try
            {
                var window =
                    (CardViewWindowPane) Package.FindToolWindow(typeof (CardViewWindowPane), 0, true);

                if ((null == window) || (null == window.Frame))
                    throw new NotSupportedException(VisualStudio.Resources.CanNotCreateWindow);

                window.Caption = VisualStudio.Resources.CardSetWindowTitle.Replace("%%project%%",
                                                                                   _currentCardCollection.ProjectId);
                //window.Bind(dataGrid.CurrentItem as MingleCard, _currentCardCollection);

                var windowFrame = (IVsWindowFrame) window.Frame;
                ErrorHandler.ThrowOnFailure(windowFrame.Show());
            }
            catch (Exception ex)
            {
                TraceLog.Exception(new StackFrame().GetMethod().Name, ex);
                MessageBox.Show(ex.Message);
            }
        }

        #endregion
    }
}