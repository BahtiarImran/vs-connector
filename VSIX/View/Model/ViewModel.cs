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
using System.Linq;
using System.Xml.Linq;
using ThoughtWorksMingleLib;

namespace ThoughtWorks.VisualStudio
{

    /// <summary>
    /// Supports the ExplorerViewControl window
    /// </summary>
    public class ViewModel : IViewModel
    {
        internal IMingleServer Mingle { get; set; }
        private Project _project;
        private Team _teamCache;
        private Transitions _transitionsCache;
        private CardProperties _propertiesCache;
        private CardTypes _cardTypesCache;

        public ViewModel(string host, string login, string password)
        {
            Mingle = new MingleServer(host, login, password);
        }

        #region Authentication Section
        internal string Host { get; set; }
        internal string Login { get; set; }
        internal string Password { get; set; }
        #endregion

        /// <summary>
        /// List of Mingle project ids for data binding with XAML
        /// </summary>
        public SortedList<string, KeyValuePair> ProjectList
        {
            get
            {
                var projects = new SortedList<string, KeyValuePair>();
                Mingle.GetProjectList().ToList().ForEach(p => projects.Add(p.Key, new KeyValuePair(p.Key,p.Value)));
                return projects;
            }
        }

        /// <summary>
        /// Set the value of the project
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns>True if projectId is a key in ProjectList, else False</returns>
        public bool SelectProject(string projectId)
        {
            if (string.IsNullOrEmpty(projectId)) return false;
            MingleSettings.Project = projectId;
            _project = new Project(MingleSettings.Project, this);
            return true;
        }

        public bool UsingProjectSavedInSettings()
        {
            if (string.IsNullOrEmpty(MingleSettings.Project)) return false;
            _project = new Project(MingleSettings.Project, this);
            return true;
        }

        /// <summary>
        /// Get the collection of Favorites
        /// </summary>
        public Favorites Favorites 
        { 
            get
            {
                var favorites = new Favorites();
                new Project(MingleSettings.Project, this).GetFavorites().ToList().              /* enumerates favorites from mingle */
                    Where(f => f.Value.FavoriteType.CompareTo("CardListView") == 0).ToList().    /* selects only CardListView favorites */
                    ForEach(f => favorites.Add(f.Key, f.Value));                                  /* populates the ViewModel cache */
                return favorites;
            }
        }

        /// <summary>
        /// Collection of project team members for data binding with XAML
        /// </summary>
        public Hashtable Team
        {
            get
            {
                if (null != _teamCache) return _teamCache;
                _teamCache = Project().GetTeam();
                return _teamCache;
            }
        }

        /// <summary>
        /// Card types
        /// </summary>
        public CardTypes CardTypes
        {
            get
            {
                if (null != _cardTypesCache) return _cardTypesCache;
                _cardTypesCache = Project().GetCardTypes();
                return _cardTypesCache;
            }
        }

        /// <summary>
        /// Collection of card properties
        /// </summary>
        public Dictionary<string, CardProperty> PropertyDefinitions
        {
            get
            {
                if (null != _propertiesCache) return _propertiesCache;
                _propertiesCache = Project().GetPropertyDefinitions();
                return _propertiesCache;
            }
        }

        /// <summary>
        /// Project id (not name)
        /// </summary>
        public string ProjectId { get { return MingleSettings.Project; } }

        /// <summary>
        /// Get collection of Cards for a particular favorite
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        public ObservableCollection<Card> GetCardsForFavorite(string view)
        {
            var cards = new Cards(Project().MingleProject, this);
            cards.RefreshView(view);
            return cards;
        }

        /// <summary>
        /// Returns the card for cardNo
        /// </summary>
        /// <param name="cardNo"></param>
        /// <returns>Card object</returns>
        public Card GetOneCard(int cardNo)
        {
            var cardStr = Mingle.Get(MingleSettings.Project, string.Format("/cards/{0}.xml", cardNo));
            CurrentCardNumber = cardNo;
            CurrentCard = new Card(new MingleCard(cardStr, Project().MingleProject), this);
            return CurrentCard;
        }

        public Card CurrentCard { get; private set; }

        public int CurrentCardNumber { get; set; }

        public ObservableCollection<Transition> Transitions
        {
            get
            {
                if (null != _transitionsCache) return _transitionsCache;
                _transitionsCache = Project().GetTransitions();
                return _transitionsCache;
            } 
        }

        /// <summary>
        /// Creates a new Card
        /// </summary>
        /// <param name="type"></param>
        /// <param name="name">One line card name</param>
        /// <returns></returns>
        public Card CreateCard(string type, string name)
        {
            var card = new Card(Project().MingleProject.CreateCard(type, name), this);
            return card;

        }

        public Project Project()
        {
            return _project;
        }

        public XElement GetListOfCards()
        {

            return Project().ExecMql("select number, name");
        }
    }


    public interface IViewModel
    {
        SortedList<string, KeyValuePair> ProjectList { get; }
        bool SelectProject(string projectId);
        Favorites Favorites { get; }
        Hashtable Team { get; }
        CardTypes CardTypes { get; }
        Dictionary<string, CardProperty> PropertyDefinitions { get; }
        string ProjectId { get; }
        ObservableCollection<Card> GetCardsForFavorite(string view);
        Card GetOneCard(int cardNo);
        Card CurrentCard { get; }
        int CurrentCardNumber { get; }
        ObservableCollection<Transition> Transitions { get; }
        Card CreateCard(string type, string name);
        Project Project();
        XElement GetListOfCards();
    }
}