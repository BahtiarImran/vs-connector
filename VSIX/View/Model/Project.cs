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

using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using ThoughtWorksMingleLib;

namespace ThoughtWorks.VisualStudio
{
    /// <summary>
    /// IProject interface for a Mingle project
    /// </summary>
    public interface IProject
    {
        /// <summary>
        /// Return cards from Mingle
        /// </summary>
        /// <param name="filters">Filters to be applied to the query</param>
        /// <returns></returns>
        CardsCollection GetCards(Collection<string> filters);

        /// <summary>
        /// Gets the card types for this project
        /// </summary>
        /// <returns></returns>
        CardTypesDictionary CardTypesDictionary { get; }

        /// <summary>
        /// Gets the transitions for this project
        /// </summary>
        /// <returns></returns>
        TransitionsCollection TransitionsCollection { get; }

        /// <summary>
        /// Gets the team members for this project
        /// </summary>
        /// <returns></returns>
        TeamMemberDictionary TeamMemberDictionary { get; }

        /// <summary>
        /// Gets the property definitions for this project
        /// </summary>
        /// <returns></returns>
        CardPropertiesDictionary PropertyDictionaryDefinitions { get; }

        /// <summary>
        /// Gets the favorites for this project
        /// </summary>
        /// <returns></returns>
        FavoritesDictionary GetFavoritesDictionary { get; }

        /// <summary>
        /// Get the list of property definitions for properties that are not restricted to transition-only
        /// </summary>
        /// <param name="transitionOnly"></param>
        /// <returns></returns>
        Hashtable GetCardValuedProperties(bool transitionOnly);

        /// <summary>
        /// Geven a card number get the card type
        /// </summary>
        /// <param name="cardNumber"></param>
        /// <returns></returns>
        string GetCardType(string cardNumber);

        /// <summary>
        /// Returns card of the type indicated by cardType
        /// </summary>
        /// <param name="cardTypeName">Card_type of cards to be returned</param>
        /// <returns></returns>
        CardsCollection GetCardsOfType(string cardTypeName);

        /// <summary>
        /// Execute an MQL request and return results in a MingleCardCollection
        /// </summary>
        /// <param name="mql">MQL query string</param>
        /// <returns>MingleCardCollection</returns>
        /// <exception cref="System.Exception">May throw an exception bubbling up from below</exception>
        XElement ExecMql(string mql);

        /// <summary>
        /// Returns a MingleCardCollection for a view 
        /// </summary>
        /// <param name="name">Name of the view (favorite)</param>
        /// <returns></returns>
        CardsCollection GetView(string name);

        /// <summary>
        /// Creates a new card
        /// </summary>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        Card CreateCard(string type, string name);

        /// <summary>
        /// The project identifier
        /// </summary>
        string ProjectId { get; }

        /// <summary>
        /// Sends a murmur to Mingle
        /// </summary>
        /// <param name="murmur"></param>
        void SendMurmur(string murmur);

        /// <summary>
        /// Returns murmur history from Mingle
        /// </summary>
        /// <returns></returns>
        IEnumerable<Murmur> Murmurs { get; }
    }

    /// <summary>
    /// Models a MingleProject for the ViewModel
    /// </summary>
    public class Project : IProject
    {
        private readonly IMingleServer _mingle;
        private readonly IMingleProject _project;
        private readonly ViewModel _model;

        internal IMingleProject MingleProject
        {
            get { return _project; }
        }

        /// <summary>
        /// Constructs a new Mingle Project object
        /// </summary>
        /// <param name="project"></param>
        /// <param name="model"></param>
        internal Project(string project, ViewModel model)
        {
            _mingle = model.Mingle;
            _project = _mingle.GetProject(project);
            _model = model;
        }

        /// <summary>
        /// Wraps MingleProject.GetCards(filters)
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        public CardsCollection GetCards(Collection<string> filters)
        {
            var cards = new CardsCollection(_project, _model);
            _project.GetCards(filters).ToList().ForEach(c => cards.Add(new Card(c, _model)));
            return cards;
        }

        /// <summary>
        /// Returns CardTypes collection 
        /// </summary>
        public CardTypesDictionary CardTypesDictionary
        {
            get
            {
                var cardTypes = new CardTypesDictionary();
                MingleProject.GetCardTypes().ToList().ForEach(ct => cardTypes.Add(ct.Name, new CardType(ct)));
                return cardTypes;
            }
        }

        /// <summary>
        /// Returns a Transitions collection
        /// </summary>
        public TransitionsCollection TransitionsCollection
        {
            get
            {
                var transitions = new TransitionsCollection(MingleProject);
                MingleProject.GetTransitions().ToList().ForEach(t => transitions.Add(new Transition(t.Value)));
                return transitions;
            }
        }

        /// <summary>
        /// Returns a Team collection
        /// </summary>
        public TeamMemberDictionary TeamMemberDictionary
        {
            get
            {
                var team = new TeamMemberDictionary();
                MingleProject.GetTeam().ToList().ForEach(t => team.Add(t.Key, new TeamMember(_model, t.Value)));
                return team;
            }
        }

        /// <summary>
        /// Returns a CardPropertiesDictionary collection
        /// </summary>
        public CardPropertiesDictionary PropertyDictionaryDefinitions
        {
            get
            {
                var cardProperties = new CardPropertiesDictionary();
                MingleProject.GetProperties().ToList().ForEach(
                    p => cardProperties.Add(p.Key, new CardProperty(_model, p.Value, null)));
                return cardProperties;
            }
        }

        /// <summary>
        /// Returns a Hashtable of CardProperty
        /// </summary>
        /// <param name="transitionOnly"></param>
        /// <returns></returns>
        public Hashtable GetCardValuedProperties(bool transitionOnly)
        {
            return MingleProject.GetCardValuedProperties(transitionOnly);
        }

        /// <summary>
        /// Returns the CardType name of a card identified by cardNumber
        /// </summary>
        /// <param name="cardNumber"></param>
        /// <returns></returns>
        public string GetCardType(string cardNumber)
        {
            return MingleProject.GetCardType(cardNumber);
        }

        /// <summary>
        /// Returns a CardsCollection collection of cards of type
        /// </summary>
        /// <param name="cardTypeName"></param>
        /// <returns></returns>
        public CardsCollection GetCardsOfType(string cardTypeName)
        {
            var cards = new CardsCollection(MingleProject, _model);
            MingleProject.GetCardsOfType(cardTypeName).ToList().ForEach(c => cards.Add(new Card(c, _model)));
            return cards;
        }

        /// <summary>
        /// Calls the execute_mql API and returns an XElement of results
        /// </summary>
        /// <param name="mql"></param>
        /// <returns></returns>
        public XElement ExecMql(string mql)
        {
            return MingleProject.ExecMql(mql);
        }

        /// <summary>
        /// Returns a CardsCollection collection for cards for view of name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public CardsCollection GetView(string name)
        {
            var cards = new CardsCollection(MingleProject, _model);
            MingleProject.GetView(name).ToList().ForEach(c => cards.Add(new Card(c, _model)));
            return cards;
        }

        /// <summary>
        /// Get the Favorites for a project of type CardListView
        /// </summary>
        /// <returns></returns>
        public FavoritesDictionary GetFavoritesDictionary
        {
            get
            {
                var favorites = new FavoritesDictionary();
                MingleProject.GetFavorites().ToList().Where(
                    f => string.CompareOrdinal(f.Value.FavoritedType, "CardListView") == 0).
                    ToList().ForEach(f => favorites.Add(f.Key, new Favorite(f.Value)));
                return favorites;
            }
        }

        /// <summary>
        /// 
        /// 
        /// Create a new card
        /// </summary>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public Card CreateCard(string type, string name)
        {
            return new Card(MingleProject.CreateCard(type, name), _model);
        }

        /// <summary>
        /// Id (not the name) of a Mingle project
        /// </summary>
        public string ProjectId
        {
            get { return _model.ProjectId; }
        }

        /// <summary>
        /// Sends a murmur to Mingle
        /// </summary>
        /// <param name="murmur"></param>
        public void SendMurmur(string murmur)
        {
            MingleProject.SendMurmur(murmur);
        }

        /// <summary>
        /// Returns murmur history from Mingle
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Murmur> Murmurs
        {
            get
            {
                var murmurs = new List<Murmur>();
                MingleProject.GetMurmurs().ToList().ForEach(
                    m =>
                    murmurs.Add(new Murmur(m.JabberName, m.LoginName, m.CreatedAt.ToString(CultureInfo.InvariantCulture),
                                           m.Body)));
                return murmurs;
            }
        }
    }
}