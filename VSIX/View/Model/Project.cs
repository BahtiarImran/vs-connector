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
        Cards GetCards(Collection<string> filters);

        /// <summary>
        /// Gets the card types for this project
        /// </summary>
        /// <returns></returns>
        CardTypes GetCardTypes();

        /// <summary>
        /// Gets the transitions for this project
        /// </summary>
        /// <returns></returns>
        Transitions GetTransitions();

        /// <summary>
        /// Gets the team members for this project
        /// </summary>
        /// <returns></returns>
        Team GetTeam();

        /// <summary>
        /// Gets the property definitions for this project
        /// </summary>
        /// <returns></returns>
        CardProperties GetPropertyDefinitions();

        /// <summary>
        /// Gets the favorites for this project
        /// </summary>
        /// <returns></returns>
        Favorites GetFavorites();

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
        /// <param name="cardType">Card_type of cards to be returned</param>
        /// <param name="forceRead">Force cache to be filled. If false then data from the cache is returned.</param>
        /// <returns></returns>
        Cards GetCardsOfType(string cardType);

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
        Cards GetView(string name);

        /// <summary>
        /// Given a macro, return the renderable HTML
        /// </summary>
        /// <param name="macro">Macro text</param>
        /// <returns>HTML</returns>
        string RunMacro(string macro);

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
        /// Property definitions for this project
        /// </summary>
        CardProperties PropertyDefinitions { get; }

        /// <summary>
        /// Transition collection for this project
        /// </summary>
        Transitions Transitions { get; }

        /// <summary>
        /// Sends a murmur to Mingle
        /// </summary>
        /// <param name="murmur"></param>
        void SendMurmur(string murmur);

        /// <summary>
        /// Returns murmur history from Mingle
        /// </summary>
        /// <returns></returns>
        IEnumerable<Murmur> GetMurmurs();
    }

    /// <summary>
    /// Models a MingleProject for the ViewModel
    /// </summary>
    public class Project : IProject
    {
        private readonly IMingleServer _mingle;
        private readonly IMingleProject _project;
        private readonly ViewModel _model;

        internal IMingleProject MingleProject { get { return _project; } }

        /// <summary>
        /// Constructs a new Mingle Project object
        /// </summary>
        /// <param name="project"></param>
        /// <param name="model"></param>
        public Project(string project, ViewModel model)
        {
            _mingle = model.Mingle;
            _project = _mingle.GetProject(project);
            _model = model;
        }

        public Cards GetCards(Collection<string> filters)
        {
            var cards = new Cards(_project, _model);
            _project.GetCards(filters).ToList().ForEach(c => cards.Add(new Card(c, _model)));
            return cards;
        }

        public CardTypes GetCardTypes()
        {
            var cardTypes = new CardTypes(_model, MingleProject);
            MingleProject.GetCardTypes().ToList().ForEach(ct => cardTypes.Add(ct.Name, ct));
            return cardTypes;
        }

        public Transitions GetTransitions()
        {
            var transitions = new Transitions(MingleProject);
            MingleProject.GetTransitions().ToList().ForEach(t => transitions.Add(new Transition(t.Value)));
            return transitions;
        }

        public Team GetTeam()
        {
            var team = new Team(_model, MingleProject);
            MingleProject.GetTeam().ToList().ForEach(t => team.Add(t.Key, new TeamMember(_model, t.Value)));
            return team;
        }

        public CardProperties GetPropertyDefinitions()
        { 
            var cardProperties = new CardProperties(_model, MingleProject);
            MingleProject.GetProperties().ToList().ForEach(p => cardProperties.Add(p.Key, new CardProperty(_model, p.Value, null)));
            return cardProperties;
        }

        public Hashtable GetCardValuedProperties(bool transitionOnly)
        {
            return MingleProject.GetCardValuedProperties(transitionOnly);
        }

        public string GetCardType(string cardNumber)
        {
            return MingleProject.GetCardType(cardNumber);
        }

        public Cards GetCardsOfType(string type)
        {
            var cards = new Cards(MingleProject, _model);
            MingleProject.GetCardsOfType(type).ToList().ForEach(c => cards.Add(new Card(c, _model)));
            return cards;
        }

        //public Cards GetIndirectCardsByTypeName(string cardType, bool forceRead)
        //{
        //    var filters = new Collection<string>{"page=all"};
        //    MingleProject.GetIndirectCardsByTypeName(cardType, forceRead).ToList().ForEach(c => filters.Add(new MingleFilter("Type", "is", c).FilterFormatString));
        //    var cards = new Cards(MingleProject, _model);
        //    MingleProject.GetCards(filters).ToList().ForEach(c => cards.Add(new Card(c, _model)));
        //    return cards;
        //}

        public XElement ExecMql(string mql)
        {
            return MingleProject.ExecMql(mql);
        }

        public Cards GetView(string name)
        {
            var cards = new Cards(MingleProject, _model);
            MingleProject.GetView(name).ToList().ForEach(c => cards.Add(new Card(c, _model)));
            return cards;
        }

        public string RunMacro(string macro)
        {
            return MingleProject.RunMacro(macro);
        }

        /// <summary>
        /// Get the Favorites for a project of type CardListView
        /// </summary>
        /// <returns></returns>
        public Favorites GetFavorites()
        {
            var favorites = new Favorites();
            MingleProject.GetFavorites().ToList().Where(f => f.Value.FavoritedType.CompareTo("CardListView") == 0).
                ToList().ForEach(f => favorites.Add(f.Key, new Favorite(f.Value)));
            return favorites;
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

        public string ProjectId
        {
            get { return _model.ProjectId; }
        }

        public CardProperties PropertyDefinitions
        {
            get 
            { 
                var properties = new CardProperties(_model, this.MingleProject); 
                MingleProject.GetProperties().ToList().ForEach(p => properties.Add(p.Key, new CardProperty(_model, p.Value, null)));
                return properties;
            }
        }

        public Transitions Transitions
        {
            get { throw new NotImplementedException(); }
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
        public IEnumerable<Murmur> GetMurmurs()
        {
            var murmurs = new List<Murmur>();
            MingleProject.GetMurmurs().ToList().ForEach(m => murmurs.Add(new Murmur(m.Body, m.CreatedAt.ToString(CultureInfo.InvariantCulture), m.AuthorName)));
            return murmurs;
        }

        public IMingleServer Mingle
        {
            get { throw new NotImplementedException(); }
        }
    }
}