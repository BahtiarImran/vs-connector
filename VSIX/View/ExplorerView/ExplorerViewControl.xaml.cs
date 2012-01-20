#region Copyright © 2010, 2011, 2012 ThoughtWorks, Inc.
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
		    try
		    {
                Model = new ViewModel(MingleSettings.Host, MingleSettings.Login, MingleSettings.Password);
                BindProjectList();
            }
		    catch (Exception ex)
		    {
                TraceLog.Exception(new StackFrame().GetMethod().Name, ex);
                MessageBox.Show(ex.Message, "Mingle");
                return;
            }
			comboProjects.SelectedValue = Model.ProjectId;
		}
		#endregion

		#region OnComboProjectsSelectionChanged
		private void OnProjectSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (e.AddedItems.Count <= 0) return;
			var item = (e.AddedItems[0] as KeyValuePair).Value;

			try
			{
				this.Cursor = Cursors.Wait;

				if (Model.SelectProject(item))
				{
					BindCardTypes();
					BindExplorerTrees();
                }
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Mingle");
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
					{
						try 
						{
							if (!new SettingsViewControl().ShowDialog() == true) 
								break;
							
							Model = new ViewModel(MingleSettings.Host, MingleSettings.Login, MingleSettings.Password);
							BindProjectList();
							ClearTrees();
						}
						catch (Exception ex)
						{
							TraceLog.Exception(new StackFrame().GetMethod().Name, ex);
							MessageBox.Show(ex.Message, "Mingle");
						}

						break;
					}

				case "buttonRefresh":
					{
						try
						{
							this.Cursor = Cursors.Wait;
							BindAll();
						}
						catch (Exception ex)
						{
							TraceLog.Exception(new StackFrame().GetMethod().Name, ex);
							MessageBox.Show(ex.Message, "Mingle");
						}
						finally
						{
							this.Cursor = Cursors.Arrow;
						}

						break;
					}

				case "buttonFeedback":
					{
						var feedback = new FeedbackViewControl();
						feedback.ShowDialog();
						feedback.Dispose();
						break;
					}

				case "buttonNewCard":
					{
						try
						{
							this.Cursor = Cursors.Wait;
							ShowCardViewToolWindow(Model.CreateCard(cardTypes.SelectedValue.ToString(), "new card"));
						}
						catch (Exception ex)
						{
							TraceLog.Exception(new StackFrame().GetMethod().Name, ex);
							MessageBox.Show(ex.Message, "Mingle");
						}
						finally
						{
							this.Cursor = Cursors.Arrow;
						}
	 
						break;
					}

				case "buttonGetCard":
					{
						if (!string.IsNullOrEmpty(card.Text) && Convert.ToInt32(card.Text, CultureInfo.CurrentCulture) > 0)
							ShowCardViewToolWindow(Convert.ToInt32(card.Text, CultureInfo.CurrentCulture));
						break;
					}
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
					item.Items.Add(c.Value.Formatted);
			}
			catch (Exception ex)
			{
				TraceLog.Exception(new StackFrame().GetMethod().Name, ex);
				MessageBox.Show(ex.Message, "Mingle");
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
				if (!sender.GetType().Name.Equals("TreeViewItem")) return;
				TreeViewItem itemContainer = null;
				GetTreeItemContainerAndValue(sender as TreeViewItem, out itemContainer, out itemValue);
				if (null == itemContainer) return;
				if (string.IsNullOrEmpty(itemValue)) return;

			}
			catch (Exception ex)
			{
				TraceLog.Exception(new StackFrame().GetMethod().Name, ex);
				MessageBox.Show(ex.Message, "Mingle");
				return;
			}
			finally
			{
				this.Cursor = Cursors.Arrow;
			}

			var cardNo = int.Parse(itemValue.Split('-')[0]);
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

		#region Data Binding
		private void BindAll()
		{
			try
			{
				BindProjectList();
				BindExplorerTrees();
				comboProjects.SelectedValue = Model.ProjectId;
			}
			catch (Exception ex)
			{
				TraceLog.Exception(new StackFrame().GetMethod().Name, ex);
				throw;
			}
		}

		/// <summary>
		/// Get list of projects
		/// </summary>
		private void BindProjectList()
		{
			try
			{
				comboProjects.ItemsSource = Model.ProjectList.Values;
				comboProjects.DisplayMemberPath = "Key";
				comboProjects.SelectedValuePath = "Value";

			}
			catch (Exception ex)
			{
				TraceLog.Exception(new StackFrame().GetMethod().Name, ex);
				throw;
			}
		}

		private void BindExplorerTrees()
		{
			try
			{
				BindFavorites();
				BindTeamMembers();

			}
			catch (Exception ex)
			{
				TraceLog.Exception(new StackFrame().GetMethod().Name, ex);
				throw;
			}
		}

		/// <summary>
		/// Bind card types
		/// </summary>
		private void BindCardTypes()
		{
			try
			{
				cardTypes.ItemsSource = Model.CardTypes.Values;
				cardTypes.DisplayMemberPath = "Name";
				cardTypes.SelectedValuePath = "Name";
				if (Model.CardTypes.Count > 0)
					cardTypes.SelectedIndex = 0;

			}
			catch (Exception ex)
			{
				TraceLog.Exception(new StackFrame().GetMethod().Name, ex);
				throw;
			}
		}

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
			catch (Exception ex)
			{
				TraceLog.Exception(new StackFrame().GetMethod().Name, ex);
				throw;
			}
			finally
			{
				this.Cursor = Cursors.Arrow;
			}
		}

		/// <summary>
		/// Dind list of team members
		/// </summary>
		private void BindTeamMembers()
		{
			try
			{
				this.Cursor = Cursors.Wait;
				teamTree.Items.Clear();
				foreach (var m in Model.Team.Values)
					teamTree.Items.Add(m.Name);

			}
			catch (Exception ex)
			{
				TraceLog.Exception(new StackFrame().GetMethod().Name, ex);
				throw;
			}
			finally
			{
				this.Cursor = Cursors.Arrow;
			}
		}
		
		/// <summary>
		/// Clear the contents of the trees
		/// </summary>
		private void ClearTrees()
		{
			favoritesTree.ItemsSource = null;
			teamTree.Items.Clear();
		}

		#endregion

	}
}