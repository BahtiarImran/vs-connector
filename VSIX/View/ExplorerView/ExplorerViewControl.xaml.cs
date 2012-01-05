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
using System.Windows.Input;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell.Interop;
using ThoughtWorksCoreLib;

namespace ThoughtWorks.VisualStudio
{
    /// <summary>
    /// Interaction logic for ExplorerViewControl.xaml
    /// </summary>
    public partial class ExplorerViewControl
    {
        internal ViewModel Model { get; private set; }

        /// <summary>
        /// XAML form for navigating a Mingle/GO integrated environment 
        /// </summary>
        public ExplorerViewControl()
        {

            InitializeComponent();
            // TODO LOAD TEXT FROM RESOURCES
            committed.Text = VisualStudio.Resources.MessageMurmurCommitted;
            committed.Visibility = Visibility.Hidden;

        }

        #region Bind list of Team members
        /// <summary>
        /// Dind list of team members
        /// </summary>
        private void BindTeamMembers()
        {
            try
            {
                this.Cursor = Cursors.Wait;
                teamTree.Items.Clear();
                foreach (TeamMember m in Model.Team.Values)
                    teamTree.Items.Add(m.Name);

            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        } 
        #endregion

        /// <summary>
        /// Package
        /// </summary>
        internal TwVscCommandsPackage Package { private get; set; }

        /// <summary>
        /// Bind card types
        /// </summary>
        private void BindCardTypes()
        {
            cardTypes.ItemsSource = Model.CardTypes.Values;
            cardTypes.DisplayMemberPath = "Name";
            cardTypes.SelectedValuePath = "Name";
            if (Model.CardTypes.Count > 0)
                cardTypes.SelectedIndex = 0;
        }

        #region Button Click Handler
        /// <summary>
        /// Handle SettingsView from the Explorer window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case "buttonSettings":
                    var ui = new SettingsViewControl();
                    if (Convert.ToBoolean(ui.ShowDialog(), CultureInfo.CurrentCulture))
                        BindAll();
                    break;

                case "buttonRefresh":
                    BindAll();
                    break;

                case "buttonFeedback":
                    var feedback = new FeedbackViewControl();
                    feedback.ShowDialog();
                    feedback.Dispose();
                    break;

                case "buttonNewCard":
                    try
                    {
                        ShowCardViewToolWindow(Model.CreateCard(cardTypes.SelectedValue.ToString(), Model.ProjectId));
                    }
                    catch (Exception ex)
                    {
                        TraceLog.Exception(new StackFrame().GetMethod().Name, ex);
                        MessageBox.Show(ex.Message);
                    }

                    break;

                case "buttonGetCard":
                    if (!string.IsNullOrEmpty(card.Text) && Convert.ToInt32(card.Text, CultureInfo.CurrentCulture) > 0)
                        ShowCardViewToolWindow(Convert.ToInt32(card.Text, CultureInfo.CurrentCulture));
                    break;
            }
        } 
        #endregion

        #region Display one card
        private void ShowCardViewToolWindow(Card mingleCard)
        {
            try
            {
                var window =
                    (CardViewWindowPane)Package.FindToolWindow(typeof(CardViewWindowPane), 0, true);

                if ((null == window) || (null == window.Frame))
                    throw new NotSupportedException(VisualStudio.Resources.CanNotCreateWindow);

                window.Bind(mingleCard);

                var windowFrame = (IVsWindowFrame)window.Frame;
                ErrorHandler.ThrowOnFailure(windowFrame.Show());
            }
            catch (Exception ex)
            {
                TraceLog.Exception(new StackFrame().GetMethod().Name, ex);
                MessageBox.Show(ex.Message.Contains("404")
                                    ? string.Format(CultureInfo.CurrentCulture, "{0} {1}", VisualStudio.Resources.CardNotFound, mingleCard.Number)
                                    : ex.Message);
            }
        }
        /// <summary>
        /// Show the CardView window
        /// </summary>
        /// <param name="cardNumber">for this card number</param>
        private void ShowCardViewToolWindow(int cardNumber)
        {
            try
            {
                var window =
                    (CardViewWindowPane)Package.FindToolWindow(typeof(CardViewWindowPane), 0, true);

                if ((null == window) || (null == window.Frame))
                    throw new NotSupportedException(VisualStudio.Resources.CanNotCreateWindow);

                window.Bind(Model.GetOneCard(cardNumber));

                var windowFrame = (IVsWindowFrame)window.Frame;
                ErrorHandler.ThrowOnFailure(windowFrame.Show());
            }
            catch (Exception ex)
            {
                TraceLog.Exception(new StackFrame().GetMethod().Name, ex);
                MessageBox.Show(ex.Message.Contains("404")
                                    ? string.Format(CultureInfo.CurrentCulture, "{0} {1}", VisualStudio.Resources.CardNotFound, card.Text)
                                    : ex.Message);
            }
        } 
        #endregion

        /// <summary>
        /// Get list of projects
        /// </summary>
        private void BindProjectList()
        {
            Model = new ViewModel(MingleSettings.Host, MingleSettings.Login, MingleSettings.Password);
            comboProjects.ItemsSource = Model.ProjectList.Values;
            comboProjects.DisplayMemberPath = "Key";
            comboProjects.SelectedValuePath = "Value";
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

        #region Tree click event handlers
        /// <summary>
        /// Handles double-click events for 'favorite' nodes in the TreeView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// This event handler is dynamically attached to the top-level favorites node
        /// </remarks>
        private void OnFavoritesTreeItemMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.Wait;
                string itemValue;
                TreeViewItem item = null;
                GetTreeItemContainerAndValue(sender as TreeViewItem, out item, out itemValue);
                if (null == item) return;
                if (string.IsNullOrEmpty(itemValue)) return;
                item.Items.Clear();
                item.MouseDoubleClick += OnFavoritesTreeCardDoubleClick;
                foreach (var c in Model.GetCardsForFavorite(itemValue))
                    item.Items.Add(c.Number + ": " + c.Name);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        /// <summary>
        /// Handles double-click events for 'card' nodes in the TreeView
        /// </summary>
        /// <param name="sender">object (typically a TreeViewItem)</param>
        /// <param name="e">MouseButtonEventArgs</param>
        /// <remarks>
        /// This event handler is dynamically attached to each favorite node 
        /// and thereby overrides the higher level handler on the top-level
        /// favorites node. 
        /// </remarks>
        private void OnFavoritesTreeCardDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string itemValue;

            try
            {
                this.Cursor = Cursors.Wait;
                if (sender.GetType().Name.CompareTo("TreeViewItem") != 0) return;
                TreeViewItem itemContainer = null;
                GetTreeItemContainerAndValue(sender as TreeViewItem, out itemContainer, out itemValue);
                if (null == itemContainer) return;
                if (string.IsNullOrEmpty(itemValue)) return;

            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }

            var cardNo = int.Parse(itemValue.Split(':')[0]);
            ShowCardViewToolWindow(cardNo);

        }

        /// <summary>
        /// Walks the tree and gets the Container object for the selected item
        /// </summary>
        /// <param name="tree"></param>
        /// <param name="itemContainer"></param>
        /// <param name="itemValue"></param>
        private static void GetTreeItemContainerAndValue(ItemsControl tree, out TreeViewItem itemContainer, out string itemValue)
        {
            if (tree == null) throw new ArgumentNullException("tree");
            foreach (var i in tree.Items)
            {
                var thisItem = tree.ItemContainerGenerator.ContainerFromItem(i) as TreeViewItem;
                if (null == thisItem) break;
                if (!thisItem.IsSelected) continue;
                itemContainer = thisItem;
                itemValue = i as string;
                return;
            }

            itemContainer = null;
            itemValue = string.Empty;

        } 
        #endregion
        
        private void OnClickButtonMurmur(object sender, RoutedEventArgs e)
        {
            var murmur = string.Format(CultureInfo.InvariantCulture, "murmur[body]={0}", murmurText.Text);
            try
            {
                Model.Mingle.Post(MingleSettings.Project, "/murmurs.xml", new Collection<string> { murmur });
                committed.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                TraceLog.Exception(new StackFrame().GetMethod().Name, ex);
                MessageBox.Show(ex.Message);
            }
            return;
        }

        private void OnMurmurTextChanged(object sender, TextChangedEventArgs e)
        {
            committed.Visibility = Visibility.Hidden;
        }

        private void OnProjectSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.Wait;
                Model.SelectProject(comboProjects.SelectedValue as string);
                MingleSettings.Project = comboProjects.SelectedValue as string;
                BindExplorerTrees();

            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        #region OnExplorerViewControlInitialized
        /// <summary>
        /// Called after the ExplorerView window is initialized and before it is rendered
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnExplorerViewControlInitialized(object sender, EventArgs e)
        {
            favoritesTree.MouseDoubleClick += OnFavoritesTreeItemMouseDoubleClick;
            CheckSettings();
            BindAll();
        }
        #endregion

        #region refresh and bind all data from Mingle
        private void BindAll()
        {
            try
            {
                BindProjectList();
                BindExplorerTrees();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                TraceLog.Exception(new StackFrame().GetMethod().Name, ex);
            }
        }
        #endregion

        #region Refresh and bind the Explorer tree
        private void BindExplorerTrees()
        {
            if (null == comboProjects.SelectedValue) return;
            BindCardTypes();
            BindFavorites();
            BindTeamMembers();
        }

        #endregion

        #region Bind List of Favorites
        /// <summary>
        /// Bind the Favorites section of the Explorer tree
        /// </summary>
        private void BindFavorites()
        {
            try
            {
                this.Cursor = Cursors.Wait;
                favoritesTree.ItemsSource = null;
                favoritesTree.Items.Clear();
                favoritesTree.ItemsSource = Model.Favorites.Keys;
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }
        #endregion

    }
}