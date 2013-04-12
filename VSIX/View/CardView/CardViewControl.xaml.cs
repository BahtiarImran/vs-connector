#region Copyright © 2010, 2011,2012, 2013 ThoughtWorks, Inc.

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
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.VisualStudio.Shell;
using ThoughtWorksCoreLib;

namespace ThoughtWorks.VisualStudio
{
    /// <summary>
    /// Interaction logic for CardViewControl.xaml
    /// </summary>
    public partial class CardViewControl
    {
        private Card _thisCard;
        private readonly Brush BUTTON_BACKROUND = Brushes.Gainsboro;
        private readonly Thickness BUTTON_MARGIN = new Thickness(4,6,4,0);
        private const int BUTTON_HEIGHT = 24;
        private const string TRANSITION_ICON = @"/ThoughtWorks.VisualStudio;component/Resources/icon-transition.gif";
        
        internal Action RefreshMurmurs { get; set; }

        /// <summary>
        /// Constructs a CardViewControl
        /// </summary>
        internal CardViewControl()
        {
            InitializeComponent();
            detailsTab.Focus();
        }

        #region Bind just one card (called by the ToolWindow when this window is created)

        /// <summary>
        /// Binds the fields of the control to data.
        /// </summary>
        internal void Bind(Card card)
        {
            _thisCard = card;
            Bind();
        }

        #endregion

        #region Bind everything to the WPF window

        /// <summary>
        /// Bind ViewModel to WPF 
        /// </summary>
        internal void Bind()
        {
            Cursor = Cursors.Wait;
            string me = new StackFrame().GetMethod().Name;
            DateTime start = DateTime.Now;
            BindManagedProperties();
            DateTime stop = DateTime.Now;
            TimeSpan elapsed = stop - start;
            TraceLog.WriteLine(me,
                               string.Format(CultureInfo.InvariantCulture, "Elapsed time Bind(): {0}",
                                             elapsed));
            start = DateTime.Now;
            BindPropertyElements();
            stop = DateTime.Now;
            elapsed = stop - start;
            TraceLog.WriteLine(me,
                               string.Format(CultureInfo.InvariantCulture, "Elapsed time Bind(): {0}",
                                             elapsed));
            Cursor = Cursors.Arrow;
        }

        #endregion

        #region Bind managed properties

        /// <summary>
        /// Bind top-level Card properties to the form
        /// </summary>
        private void BindManagedProperties()
        {
            transitionButtons.Children.Clear();

            // Establish the transition toolbar
            if (null != _thisCard.Transitions)
            {
                foreach (var t in _thisCard.Transitions)
                {
                    // transition button
                    var button = new Button
                                     {
                                         ToolTip = VisualStudio.Resources.ClickToMakeTransition,
                                         Background = BUTTON_BACKROUND,
                                         Margin = BUTTON_MARGIN,
                                         Style = Application.Current.Resources["PlainButtonStyle"] as Style,
                                         DataContext = t
                                     };

                    // Text block for the transition nomenclature
                    var text = new TextBlock { Height = BUTTON_HEIGHT, Text = t.Name, Margin = new Thickness(3, 0, 0, 0), VerticalAlignment = VerticalAlignment.Center };

                    var buttonPanel = new StackPanel
                                          {
                                              Orientation = Orientation.Horizontal, 
                                              Height = BUTTON_HEIGHT,
                                              HorizontalAlignment = HorizontalAlignment.Left,
                                              VerticalAlignment = VerticalAlignment.Center
                                          };

                    // align icon and text horizontally
                    buttonPanel.Children.Add(new Image { Source = new BitmapImage(new Uri(TRANSITION_ICON, UriKind.Relative)), Height=20, Width = 20 });
                    buttonPanel.Children.Add(text);

                    // finalize the button
                    button.Content = buttonPanel;
                    button.Click += OnTransitionButtonClick;
                    button.Style = Application.Current.Resources["PlainButtonStyle"] as Style;
                    transitionButtons.Children.Add(button);
                }
            }

            tabs.DataContext = _thisCard;
            cardName.SetBinding(TextBox.TextProperty, "Name");
            cardName.Tag = cardName.Text;
            cardDescription.SetBinding(TextBox.TextProperty, "Description");
            cardDescription.Tag = cardDescription.Text;
            cardType.Text = _thisCard.CardType;
            cardType.IsReadOnly = true;
            cardProjectName.Text = _thisCard.ProjectName;
            cardProjectName.Tag = cardProjectName.Text;
            cardVersion.SetBinding(TextBox.TextProperty, "Version");
            cardVersion.Tag = cardVersion.Text;
            cardRank.SetBinding(TextBox.TextProperty, "Rank");
            cardRank.Tag = cardRank.Text;
            cardCreatedOn.SetBinding(TextBox.TextProperty, "CreatedOn");
            cardCreatedOn.Tag = cardCreatedOn.Text;
            cardCreatedBy.SetBinding(TextBox.TextProperty, "CreatedBy");
            cardCreatedBy.Tag = cardCreatedBy.Text;
            cardModifiedOn.SetBinding(TextBox.TextProperty, "ModifiedOn");
            cardModifiedOn.Tag = cardModifiedOn.Text;
            cardModifiedBy.SetBinding(TextBox.TextProperty, "MofidiedBy");
            cardModifiedBy.Tag = cardModifiedBy.Text;
            descriptionBrowser.Source = new Uri(_thisCard.RenderedDescription);
            commentsList.ItemsSource = _thisCard.Model.GetCommentsForCard(_thisCard.Number);
        }

        #endregion

        #region Bind property elements

        /// <summary>
        /// Bind other properties to the form
        /// </summary>
        private void BindPropertyElements()
        {
            visiblePropertiesPanel.Children.Clear();
            hiddenPropertiesPanel.Children.Clear();

            foreach (CardProperty p in _thisCard.Properties.Values)
            {
                // Load the property

                UIElement element = InnerPanel(p);

                switch (p.Hidden)
                {
                    case true:
                        // We are separating hidden properties so that we can toggle them on and off.
                        hiddenPropertiesPanel.Children.Add(element);
                        break;

                    default:
                        visiblePropertiesPanel.Children.Add(element);
                        break;
                }
            }
        }

        #endregion

        #region Bind Property

        /// <summary>
        /// Binds CardData.PropertyDefinitions list onto the Properties tab
        /// </summary>
        /// <remarks>
        /// Adds elements to the Properties tab dynamically for each property
        /// in the Properties list. Menus and lists of data values are dynamically 
        /// created based on the "type_description" of easch Property.
        /// 
        /// Each Property becomes a horizontal StackPanel member of the propertiesPanel
        /// in the form. Each StackPanel has a Label/[some element] member pair. 
        /// The type of [some element] is determined by the type_description from 
        /// the card itself.
        /// 
        /// The propertiesPanel is a horizontal WrapPanel element so that the 
        /// StackPanel members wrap automatically flowing from left to right.
        /// </remarks>
        internal StackPanel InnerPanel(CardProperty cardProperty)
        {
            return _thisCard.Model.InnerPanel(cardProperty, _thisCard, OnButtonChooseCardClick, OnPropertyTextBoxLostFocus, 
                OnPropertyComboBoxSelectionChanged, OnButtonNotSetClick);
        }

        private void OnPropertyComboBoxSelectionChanged(object sender, RoutedEventArgs e)
        {
            if (!sender.GetType().Name.Equals("ComboBox")) return;
            string me = new StackFrame().GetMethod().Name;
            var cb = sender as ComboBox;
            var property = cb.Tag as CardProperty;
            if (property.IsCardValued) return;
            _thisCard.AddPropertyFilterToPostData((cb.DataContext as CardProperty).Name, cb.SelectedValue as string);
            try
            {
                if (!string.IsNullOrEmpty(cardName.Text))
                    _thisCard.Update();
                else
                    MessageBox.Show(ThoughtWorksCoreLib.Resources.MingleCardNameNullOrEmpty);
            }
            catch (Exception ex)
            {
                TraceLog.Exception(me, ex);
                MessageBox.Show(ex.Message);
            }

            e.Handled = true;
        }

        private void OnButtonChooseCardClick(object sender, RoutedEventArgs e)
        {
            var theSender = sender as Button;
            string propertyName = ((theSender.Tag as TextBox).Tag as CardProperty).Name;

            var w = new CardListWindow(_thisCard.Model, propertyName);
            w.ShowDialog();

            if (w.Cancelled || w.SelectedCardNumber == "0") return;

            _thisCard.SetPropertyOrAttributValue(propertyName, w.SelectedCardNumber);

            try
            {
                _thisCard.Update();
                (theSender.Tag as TextBox).Text = string.Format(CultureInfo.InvariantCulture, "{0} - {1}", w.SelectedCardNumber,
                                                                         w.SelectedCardName);
            }
            catch (Exception ex)
            {
                TraceLog.Exception(new StackFrame().GetMethod().Name, ex);
                MessageBox.Show(ex.Message);
            }
        }

        private static void OnButtonNotSetClick(object sender, RoutedEventArgs e)
        {
            var theSender = sender as Button;
            UIElement box = (theSender.Parent as StackPanel).Children[1];
            switch (box.GetType().Name)
            {
                case "TextBox":
                    (box as TextBox).Text = string.Empty;
                    box.Focus();
                    theSender.Focus();
                    break;

                case "ComboBox":
                    (box as ComboBox).SelectedValue = string.Empty;
                    break;
            }
        }

        #endregion

        #region OnInitialized

        /// <summary>
        /// Fired after the window framework has initialized and before it is loaded and rendered.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnInitialized(object sender, EventArgs e)
        {
            OnShowHiddenPropertiesClicked(null, null);
        }

        #endregion

        #region OnPropertyTextBoxLostFocus

        /// <summary>
        /// Calls MingleCard.Update() to update the card with contents of the text box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPropertyTextBoxLostFocus(object sender, RoutedEventArgs e)
        {
            e.Source = _thisCard;
            string me = new StackFrame().GetMethod().Name;

            var tb = sender as TextBox;
            if (tb.Text == tb.Tag as string)
            {
                e.Handled = true;
                return;
            }
            switch (tb.DataContext.GetType().Name)
            {
                case "Card":
                    // The name of the field is "cardXXXXXX", so we strip the "card" prefix from the
                    // name of the TextBox.
                    _thisCard.AddCardAttributeFilterToPostData(
                        tb.Name.Replace("card", string.Empty).ToLowerInvariant(), tb.Text);
                    break;

                case "CardProperty":
                    // The DataContext of the TextBox is a MinglePropertyDefinition object. So, we
                    // take its name and pass it over to AddPropertyPostData.
                    _thisCard.AddPropertyFilterToPostData((tb.DataContext as CardProperty).Name, tb.Text);
                    break;
            }
            try
            {
                if (!string.IsNullOrEmpty(cardName.Text))
                {
                    _thisCard.Update();
                    descriptionBrowser.Refresh();
                }
                else
                    MessageBox.Show(ThoughtWorksCoreLib.Resources.MingleCardNameNullOrEmpty);
            }
            catch (Exception ex)
            {
                TraceLog.Exception(me, ex);
                MessageBox.Show(ex.Message);
            }

            e.Handled = true;
        }

        #endregion

        #region OnTransitionButtonClick

        /// <summary>
        /// Fired when the Transition button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTransitionButtonClick(object sender, RoutedEventArgs e)
        {
            var b = sender as Button;
            var t = b.DataContext as Transition;
            try
            {
                // First poll for required input


                // POST the transition
                if (t != null && !t.RequireComment)
                {
                    t.Update(_thisCard.Number);
                    Rebind();
                    return;
                }

                var collectComment =
                    new GeneralCommentView(VisualStudio.Resources.TransitionAdmonitionLabel,
                                           VisualStudio.Resources.TransitionCommentRequired,
                                           VisualStudio.Resources.TransitionWindowTitle);

                if (string.IsNullOrEmpty(collectComment.Comment))
                {
                    return;
                }

                // POST the transition
                t.Update(_thisCard.Number);

                // POST the Comment
                string cardComment = string.Format(CultureInfo.InvariantCulture, "comment[content]={0}",
                                                   collectComment.Comment);
                _thisCard.Model.Mingle.Post(MingleSettings.Project, "/cards/" + _thisCard.Number + ".xml",
                                            new Collection<string> {cardComment});

                // Murmur the comment?
                string murmur = string.Format(CultureInfo.InvariantCulture, "murmur[body]={0}", collectComment.Comment);
                _thisCard.Model.Mingle.Post(MingleSettings.Project, "/cards/" + _thisCard.Number + ".xml",
                                            new Collection<string> {murmur});
            }
            catch (Exception ex)
            {
                TraceLog.Exception(new StackFrame().GetMethod().Name, ex);
                MessageBox.Show(string.Format(CultureInfo.CurrentCulture, "{0}\n\r\n\r{1} {2}\n\r\n\r{3}",
                                              VisualStudio.Resources.TransitionCannotBeApplied,
                                              VisualStudio.Resources.TransitionEquals, t.Name, ex.Message));
            }
        }

        #endregion

        #region Rebind

        /// <summary>
        /// Rebinds the CardView to card indicated by _thisCard.Number
        /// </summary>
        private void Rebind()
        {
            if (_thisCard.Number <= 0) return;
            LoadCardFromMingle();
            Bind();
            detailsTab.Focus();
        }

        private void LoadCardFromMingle()
        {
            _thisCard = _thisCard.Model.GetOneCard(_thisCard.Number);
        }

        #endregion

        #region OnShowHiddenProperties

        /// <summary>
        /// Toggles Visibility for Card properties marked as "hidden" in Mingle.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// This only affects the UI. It does not change the "hidden" attribute in Mingle.</remarks>
        private void OnShowHiddenPropertiesClicked(object sender, RoutedEventArgs e)
        {
            hiddenPropertiesPanel.Visibility = Visibility.Hidden;
            if (showHiddenProperties.IsChecked == true)
                hiddenPropertiesPanel.Visibility = Visibility.Visible;
        }

        #endregion

        /// <summary>
        /// The ToolWindowPain
        /// </summary>
        internal ToolWindowPane ToolPane { get; set; }

        /// <summary>
        /// Called when the card name text changes. Sets the window title to be the same as the card name.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCardNameTextChanged(object sender, TextChangedEventArgs e)
        {
            ToolPane.Caption = string.Format(CultureInfo.CurrentCulture, VisualStudio.Resources.CardWindowCaption,
                                             _thisCard.Number, cardName.Text);
        }

        /// <summary>
        /// Called when the card name gets focus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCardNameGotFocus(object sender, RoutedEventArgs e)
        {
            cardName.SelectAll();
        }

        private void OnRenderedDescriptionTabGotFocus(object sender, RoutedEventArgs e)
        {
            descriptionBrowser.Source = new Uri(_thisCard.RenderedDescription);
        }

        private void OnButtonSaveCommentClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                _thisCard.Model.PostComment(_thisCard.Number, comment.Text);
                if (Convert.ToBoolean(murmurComment.IsChecked,CultureInfo.InvariantCulture))
                {
                    _thisCard.Model.SendMurmur(string.Format(CultureInfo.CurrentUICulture,"#{0} {1}", _thisCard.Number, comment.Text));
                    RefreshMurmurs();
                }
                commentsList.ItemsSource = _thisCard.Model.GetCommentsForCard(_thisCard.Number);
                comment.Text = string.Empty;
            }
            catch (Exception ex)
            {
                TraceLog.Exception(new StackFrame().GetMethod().Name, ex);
                MessageBox.Show(ex.Message);
            }
        }
    }
}