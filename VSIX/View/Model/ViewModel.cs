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
        public bool SelectProject(object projectId)
        {
            var pid = projectId as string;
            if (string.IsNullOrEmpty(pid)) return false;
            MingleSettings.Project = pid;
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
        public SortedList<string,TeamMember> Team
        {
            get
            {
                if (null != _teamCache && _teamCache.Count > 0) return _teamCache;
                _teamCache = Project().GetTeam();
                _teamCache.Add(Resources.ItemNotSet, new TeamMember(this, false));
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
                if (null != _cardTypesCache && _cardTypesCache.Count > 0) return _cardTypesCache;
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
                if (null != _propertiesCache && _propertiesCache.Count > 0) return _propertiesCache;
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
        public SortedList<string, CardBasicInfo> GetCardsForFavorite(string view)
        {
            var cards = new SortedList<string, CardBasicInfo>();
            Project().GetView(view).ToList().ForEach(c => cards.Add(string.Format("{0}{1}", c.CardType, c.Name),new CardBasicInfo(c.Number, c.CardType, c.Name)));
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

        internal Card CurrentCard { get; private set; }

        internal int CurrentCardNumber { get; set; }

        /// <summary>
        /// Collection of transitions for the project
        /// </summary>
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

        /// <summary>
        /// Returns the project object
        /// </summary>
        /// <returns></returns>
        public Project Project()
        {
            return _project;
        }

        /// <summary>
        /// Returns the list of cards in Mingle ordered by type, name
        /// </summary>
        /// <returns></returns>
        public XElement GetListOfCards()
        {
            return Project().ExecMql("SELECT type, name, number ORDER BY type,name ASC");
        }

        /// <summary>
        /// Gets cards for type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public Cards GetCardsOfType(string type)
        {
            return _project.GetCardsOfType(type);
        }

        /// <summary>
        /// Posts a comment to a card 
        /// </summary>
        /// <param name="number"></param>
        /// <param name="comment"></param>
        /// <returns></returns>
        public void PostComment(int number, string comment)
        {
            var commentData = new Collection<string> { string.Format("comment[content]={0}", comment) };
            var url = string.Format("/cards/{0}/comments.xml", number);
            Mingle.Post(ProjectId, url, commentData);
        }

        /// <summary>
        /// Returns comments for a card
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public IEnumerable<CardComment> GetCommentsForCard(int number)
        {
            var url = string.Format("/cards/{0}/comments.xml", number);
            var comments = new List<CardComment>();
            XElement.Parse(Mingle.Get(ProjectId, url)).Elements("comment").ToList().ForEach(c => comments.Add(
                new CardComment(c.Element("content").Value, c.Element("created_by").Element("name").Value, c.Element("created_at").Value)));
            return comments;
        }

        /// <summary>
        /// Get the list of murmurs
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Murmur> GetMurmurs()
        {
            var url = string.Format("/murmurs.xml");
 
            return (from m in XElement.Parse(Mingle.Get(ProjectId, url)).Elements("murmur").ToList()
                    where null != m.Element("author")
                    where null != m.Element("author").Element("name")
                    where null != m.Element("created_at")
                    where null != m.Element("body")
                    let name = m.Element("author").Element("name").Value
                    let date = m.Element("created_at").Value
                    let body = m.Element("body").Value
                    select new Murmur(name, date, body)).ToList();
        }

    }

    /// <summary>
    /// Interface to the ViewModel
    /// </summary>
    public interface IViewModel
    {
        /// <summary>
        /// List of projectid/name pairs sorted by name
        /// </summary>
        SortedList<string, KeyValuePair> ProjectList { get; }
        /// <summary>
        /// Set the value of the current project
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns>False if the projectid is not selectable</returns>
        bool SelectProject(object projectId);
        /// <summary>
        /// List of favorites of type "CardListView"
        /// </summary>
        Favorites Favorites { get; }
        /// <summary>
        /// List of TeamMember sorted by name
        /// </summary>
        SortedList<string,TeamMember>  Team { get; }
        /// <summary>
        /// List of CardTypes
        /// </summary>
        CardTypes CardTypes { get; }
        /// <summary>
        /// List of property definitions
        /// </summary>
        Dictionary<string, CardProperty> PropertyDefinitions { get; }
        /// <summary>
        /// The project id of the currently selected project
        /// </summary>
        string ProjectId { get; }
        SortedList<string, CardBasicInfo> GetCardsForFavorite(string view);
        /// <summary>
        /// Returns a Card
        /// </summary>
        /// <param name="cardNo">Card number</param>
        /// <returns></returns>
        Card GetOneCard(int cardNo);
        /// <summary>
        /// Colleciton of transitions for the project
        /// </summary>
        ObservableCollection<Transition> Transitions { get; }
        /// <summary>
        /// Crates a new card
        /// </summary>
        /// <param name="type">Card type</param>
        /// <param name="name">Card name</param>
        /// <returns>The card htat was created</returns>
        Card CreateCard(string type, string name);
        /// <summary>
        /// Returns the selected project
        /// </summary>
        /// <returns></returns>
        Project Project();
        /// <summary>
        /// Returns all the cards
        /// </summary>
        /// <returns></returns>
        XElement GetListOfCards();
        /// <summary>
        /// Returns cards of a certain type
        /// </summary>
        /// <param name="type">Card type</param>
        /// <returns></returns>
        Cards GetCardsOfType(string type);
        /// <summary>
        /// Posts a comment to a card
        /// </summary>
        /// <param name="number"></param>
        /// <param name="comment"></param>
        void PostComment(int number, string comment);
        /// <summary>
        /// Gets all the comments for a card
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        IEnumerable<CardComment> GetCommentsForCard(int number);
        /// <summary>
        /// Gets all the murmur history
        /// </summary>
        /// <returns></returns>
        IEnumerable<Murmur> GetMurmurs();
    }
}