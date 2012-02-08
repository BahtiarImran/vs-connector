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
using System.Windows.Media;
using Microsoft.VisualStudio.Shell;
using ThoughtWorks.VisualStudio.Properties;
using ThoughtWorksCoreLib;

namespace ThoughtWorks.VisualStudio
{
    /// <summary>
    /// Interaction logic for CardViewControl.xaml
    /// </summary>
    public partial class CardViewControl
    {
        private Card _thisCard;
        private readonly SolidColorBrush _buttonBackground = new SolidColorBrush(SystemColors.ControlColor);
        private readonly SolidColorBrush _darkThemeBackground = Brushes.Wheat;
        private readonly FontWeight _darkFontWeight = FontWeights.ExtraBlack;
        private readonly FontWeight _normalFontWeight = FontWeights.Normal;
        private readonly Thickness _buttonBorderThickness = new Thickness(0, 0, 0, 0);
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
            var me = new StackFrame().GetMethod().Name;
            var start = DateTime.Now;
            BindManagedProperties();
            var stop = DateTime.Now;
            var elapsed = stop - start;
            TraceLog.WriteLine(me,
                               string.Format(CultureInfo.InvariantCulture, "Elapsed time BindManagedProperties(): {0}", elapsed));
            start = DateTime.Now;
            BindPropertyElements();
            stop = DateTime.Now;
            elapsed = stop - start;
            TraceLog.WriteLine(me,
                               string.Format(CultureInfo.InvariantCulture, "Elapsed time BindPropertyElements(): {0}", elapsed));
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

                    var button = new Button
                    {
                        ToolTip = VisualStudio.Resources.ClickToMakeTransition,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        Margin = new Thickness(4, 4, 4, 4),
                        Height = 24,
                        BorderThickness = _buttonBorderThickness
                    };

                    button.Click += OnTransitionButtonClick;
                    button.DataContext = t;
                    button.SetBinding(ContentProperty, "Name");
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

            foreach (var p in _thisCard.Properties.Values)
            {
                // Load the property

                UIElement element = BindProperty(p);

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
        internal StackPanel BindProperty(CardProperty cardProperty)
        {

            // A StackPanel to hold the label and data controls for a single property. Each property gets one. 
            // The enclosing WrapPanel (see XAML source) handles automatic layout on resize events.
            var panel = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                Margin = new Thickness(6, 6, 0, 0),
                Tag = cardProperty
            };

            var label = new Label
                            {
                                Content = cardProperty.Name,
                                Background = _darkThemeBackground,
                                FontWeight = FontWeights.ExtraBlack
                            };

            // Make labels for hidden properties italic.
            if (cardProperty.Hidden) label.FontStyle = FontStyles.Italic;
            panel.Children.Add(label);

            FrameworkElement uiElement = null;

            switch (cardProperty.IsManagedListOfScalars)
            {
                case false:
                    {
                        if (cardProperty.IsTeamValued)
                        {
                            uiElement = MakeComboBox(cardProperty);
                            panel.Children.Add(uiElement);
                            break;
                        }

                        uiElement = MakeTextBox(cardProperty);

                        panel.Children.Add(uiElement);

                        if (PropertyIsEditable(cardProperty) && cardProperty.IsCardValued)
                        {
                            // Add a 'click to choose' button
                            var a = MakeChooseCardButton(cardProperty);
                            a.Click += OnButtonChooseCardClick;
                            a.Tag = uiElement;
                            panel.Children.Add(a);
                            ValueNotSetButton(cardProperty, panel);
                        }

                        break;
                    }
                case true:
                    { 
                        uiElement = MakeComboBox(cardProperty);
                        panel.Children.Add(uiElement);
                        break;
                    }
            }

            panel.IsEnabled = PropertyIsEditable(cardProperty);
            return panel;
        }

        private Button MakeChooseCardButton(CardProperty cardProperty)
        {
            var a = new Button
                        {
                            Content = "...",
                            ToolTip = "Click to choose a card",
                            Tag = cardProperty,
                            Width = 30,
                            Background = _buttonBackground,
                            BorderThickness = _buttonBorderThickness,

                        };
            return a;
        }

        private bool PropertyIsEditable(CardProperty property)
        {
            return UserIsProjectAdmin() || !property.IsFormula && !property.IsTransitionOnly && !property.PropertyValuesDescription.Equals("Aggregate");
        }

        private TextBox MakeTextBox(CardProperty cardProperty)
        {

            var tb = new TextBox
                         {
                             MinWidth = 50,
                             Name = cardProperty.ColumnName,
                             DataContext = cardProperty,
                             FontWeight = _normalFontWeight
                         };

            var cardinfo = cardProperty.Value as string;
            if (!string.IsNullOrEmpty(cardProperty.Value as string) && cardProperty.IsCardValued)
            {
                var name = _thisCard.Model.GetOneCard(Convert.ToInt32(cardProperty.Value)).Name;
                cardinfo = string.Format("{0} - {1}", cardProperty.Value as string, name);
            }
            tb.Text = cardinfo;
            tb.Tag = cardProperty;

            if (!cardProperty.IsTransitionOnly && !cardProperty.IsFormula)
                tb.LostFocus += OnPropertyTextBoxLostFocus;

            if (cardProperty.IsTransitionOnly || cardProperty.IsFormula)
                tb.Background = Brushes.PapayaWhip;

            return tb;
        }

        private ComboBox MakeComboBox(CardProperty cardProperty)
        {
            var cb = new ComboBox
                         {
                             IsEnabled = !cardProperty.IsTransitionOnly,
                             MinWidth = 50,
                             Name = cardProperty.ColumnName,
                             DataContext = cardProperty,
                             Background = _buttonBackground,
                             BorderThickness = _buttonBorderThickness,
                             FontWeight = _normalFontWeight
                         };

            if (cardProperty.IsTeamValued)
            {
                cb.ItemsSource = _thisCard.Model.TeamMemberDictionaryAsManagedList.Values;
                cb.DisplayMemberPath = "Name";
                cb.SelectedValuePath = "Login";
            }
            else
            {
                cb.ItemsSource = cardProperty.PropertyValueDetails;
            }

            cb.SelectedValue = cardProperty.IsSetValued && !string.IsNullOrEmpty(cardProperty.Value as string) || (!cardProperty.IsManagedListOfScalars && !cardProperty.IsTeamValued) ? cardProperty.Value : VisualStudio.Resources.ItemNotSet;

            cb.Tag = cardProperty;

            if (!cardProperty.IsTransitionOnly && !cardProperty.IsFormula)
                cb.SelectionChanged += OnPropertyComboBoxSelectionChanged;

            cb.IsEnabled = PropertyIsEditable(cardProperty);

            return cb;
        }

        private static Button ValueNotSetButton(CardProperty cardProperty, FrameworkElement control)
        {
            var b = new Button
                        {
                            Content = "X",
                            ToolTip = "Click to leave the value not set",
                            Tag = cardProperty,
                            Width = 30,
                            FontWeight = FontWeights.Normal
                        };

            b.Click += OnButtonNotSetClick;
            b.Tag = control.Tag;
            return b;
        }

        private void OnPropertyComboBoxSelectionChanged(object sender, RoutedEventArgs e)
        {
            if (!sender.GetType().Name.Equals("ComboBox")) return;
            var me = new StackFrame().GetMethod().Name;
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
            var propertyName = (((sender as Button).Tag as TextBox).Tag as CardProperty).Name;

            var w = new CardListWindow(_thisCard.Model, propertyName);
            w.ShowDialog();

            if (w.Cancelled || w.SelectedCardNumber == "0") return;

            _thisCard.SetPropertyOrAttributValue(propertyName, w.SelectedCardNumber);

            try
            {
                _thisCard.Update();
                ((sender as Button).Tag as TextBox).Text = string.Format("{0} - {1}", w.SelectedCardNumber, w.SelectedCardName);
            }
            catch (Exception ex)
            {
                TraceLog.Exception(new StackFrame().GetMethod().Name, ex);
                MessageBox.Show(ex.Message);
            }
        }

        private static void OnButtonNotSetClick(object sender, RoutedEventArgs e)
        {
            var box = ((sender as Button).Parent as StackPanel).Children[1];
            switch(box.GetType().Name)
            {
                case "TextBox":
                    (box as TextBox).Text = string.Empty;
                    box.Focus();
                    (sender as Button).Focus();
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
            if (!Settings.Default.EnablePropertyUpdating) return;
            var me = new StackFrame().GetMethod().Name;
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
                    _thisCard.AddCardAttributeFilterToPostData(tb.Name.Replace("card", string.Empty).ToLowerInvariant(), tb.Text);
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
                var comment = string.Format(CultureInfo.InvariantCulture, "comment[content]={0}", collectComment.Comment);
                _thisCard.Model.Mingle.Post(MingleSettings.Project, "/cards/" + _thisCard.Number + ".xml", new Collection<string> {comment});

                // Murmur the comment?
                var murmur = string.Format(CultureInfo.InvariantCulture, "murmur[body]={0}", collectComment.Comment);
                _thisCard.Model.Mingle.Post(MingleSettings.Project, "/cards/" + _thisCard.Number + ".xml", new Collection<string> { murmur });
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
        /// returns true/false whether the user is an admin on the project
        /// </summary>
        /// <returns></returns>
        private bool UserIsProjectAdmin()
        {
            return (_thisCard.Model.TeamMemberDictionary.ContainsKey(MingleSettings.Login) && (_thisCard.Model.TeamMemberDictionary[MingleSettings.Login] as TeamMember).IsAdmin);
        }

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
            ToolPane.Caption = string.Format(CultureInfo.CurrentCulture, VisualStudio.Resources.CardWindowCaption, _thisCard.Number, cardName.Text);
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
        }

        private void OnButtonSaveCommentClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                _thisCard.Model.PostComment(_thisCard.Number, string.Format("#{0} {1}",_thisCard.Number, comment.Text));
                if (Convert.ToBoolean(murmurComment.IsChecked))
                {
                    _thisCard.Model.SendMurmur(comment.Text);
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