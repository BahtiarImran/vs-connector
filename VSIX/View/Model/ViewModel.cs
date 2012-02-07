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
using System.Globalization;
using System.Linq;
using System.Text;
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
        private TeamMemberDictionary _teamMemberDictionaryCache;
        private TeamMemberDictionary _teamMemberDictionaryMlCache;
        private TransitionsCollection _transitionsCollectionCache;
        private CardPropertiesDictionary _propertiesDictionaryCache;
        private CardTypesDictionary _cardTypesDictionaryCache;
        private ObservableCollection<Murmur> _murmursCache;

        #region Constructors
        /// <summary>
        /// Constructs a new ViewModel
        /// </summary>
        /// <param name="host"></param>
        /// <param name="login"></param>
        /// <param name="password"></param>
        public ViewModel(string host, string login, string password)
        {
            Initialize(host, login, password);
        }

        /// <summary>
        /// Testable constructor used to inject a Mingle fixture
        /// </summary>
        /// <param name="mingle"></param>
        internal ViewModel(IMingleServer mingle)
        {
            Mingle = mingle;
        }

        /// <summary>
        /// Constructs a naked ViewModel
        /// </summary>
        internal ViewModel() { } 
        #endregion

        internal void Initialize(string host, string login, string password)
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
        public FavoritesDictionary FavoritesDictionary 
        { 
            get
            {
                var favorites = new FavoritesDictionary();
                new Project(MingleSettings.Project, this).GetFavoritesDictionary.ToList().              /* enumerates favorites from mingle */
                    Where(f => string.CompareOrdinal(f.Value.FavoriteType, "CardListView") == 0).ToList().    /* selects only CardListView favorites */
                    ForEach(f => favorites.Add(f.Key, f.Value));                                  /* populates the ViewModel cache */
                return favorites;
            }
        }

        /// <summary>
        /// Collection of project team members for data binding with XAML
        /// </summary>
        public SortedList<string,TeamMember> TeamMemberDictionary
        {
            get
            {
                if (null != _teamMemberDictionaryCache && _teamMemberDictionaryCache.Count > 0) return _teamMemberDictionaryCache;
                _teamMemberDictionaryCache = Project().TeamMemberDictionary;
                return _teamMemberDictionaryCache;
            }
        }

        /// <summary>
        /// Collection of project team members for data binding with XAML (includes leading element called "item not set")
        /// </summary>
        public SortedList<string, TeamMember> TeamMemberDictionaryAsManagedList
        {
            get
            {
                if (null != _teamMemberDictionaryMlCache && _teamMemberDictionaryMlCache.Count > 0) return _teamMemberDictionaryMlCache;
                _teamMemberDictionaryMlCache = Project().TeamMemberDictionary;
                _teamMemberDictionaryMlCache.Add(Resources.ItemNotSet, new TeamMember(this, false));
                return _teamMemberDictionaryMlCache;
            }
        }
        /// <summary>
        /// Card types
        /// </summary>
        public CardTypesDictionary CardTypesDictionary
        {
            get
            {
                if (null != _cardTypesDictionaryCache && _cardTypesDictionaryCache.Count > 0) return _cardTypesDictionaryCache;
                _cardTypesDictionaryCache = Project().CardTypesDictionary;
                return _cardTypesDictionaryCache;
            }
        }

        /// <summary>
        /// Collection of card properties
        /// </summary>
        public Dictionary<string, CardProperty> PropertyDefinitions
        {
            get
            {
                if (null != _propertiesDictionaryCache && _propertiesDictionaryCache.Count > 0) return _propertiesDictionaryCache;
                _propertiesDictionaryCache = Project().PropertyDictionaryDefinitions;
                return _propertiesDictionaryCache;
            }
        }

        /// <summary>
        /// Project id (not name)
        /// </summary>
        public string ProjectId { get { return MingleSettings.Project; } }

        /// <summary>
        /// Get collection of CardsCollection for a particular favorite
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        public SortedList<string, CardBasicInfo> GetCardsForFavorite(string view)
        {
            var cards = new SortedList<string, CardBasicInfo>();
            Project().GetView(view).ToList().ForEach(c => cards.Add(string.Format(CultureInfo.InvariantCulture, "{0}{1}", c.CardType, c.Name), new CardBasicInfo(c.Number, c.CardType, c.Name)));
            return cards;
        }

        /// <summary>
        /// Returns the card for cardNo
        /// </summary>
        /// <param name="cardNo"></param>
        /// <returns>Card object</returns>
        public Card GetOneCard(int cardNo)
        {
            var cardStr = Mingle.Get(MingleSettings.Project, string.Format(CultureInfo.InvariantCulture, "/cards/{0}.xml", cardNo));
            CurrentCardNumber = cardNo;
            CurrentCard = new Card(new MingleCard(cardStr, Project().MingleProject), this);
            return CurrentCard;
        }

        internal Card CurrentCard { get; private set; }

        internal int CurrentCardNumber { get; set; }

        /// <summary>
        /// Collection of transitions for the project
        /// </summary>
        public ObservableCollection<Transition> TransitionsCollection
        {
            get
            {
                if (null != _transitionsCollectionCache) return _transitionsCollectionCache;
                _transitionsCollectionCache = Project().TransitionsCollection;
                return _transitionsCollectionCache;
            } 
        }

        /// <summary>
        /// Collection of murmurs
        /// </summary>
        public ObservableCollection<Murmur> Murmurs
        {
            get
            {
                
                _murmursCache = new ObservableCollection<Murmur>();
                Project().Murmurs.ToList().ForEach(m => _murmursCache.Add(m));
                return _murmursCache;
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
        public XElement ListOfCards
        {
            get
            {
                return Project().ExecMql("SELECT type, name, number ORDER BY type,name ASC");
            }
        }

        /// <summary>
        /// Gets cards for type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public CardsCollection GetCardsOfType(string type)
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
            var commentData = new Collection<string> { string.Format(CultureInfo.InvariantCulture, "comment[content]={0}", comment) };
            var url = string.Format(CultureInfo.InvariantCulture, "/cards/{0}/comments.xml", number);
            Mingle.Post(ProjectId, url, commentData);
        }

        /// <summary>
        /// Returns comments for a card
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public IEnumerable<CardComment> GetCommentsForCard(int number)
        {
            var url = string.Format(CultureInfo.InvariantCulture, "/cards/{0}/comments.xml", number);
            var comments = new List<CardComment>();
            XElement.Parse(Mingle.Get(ProjectId, url)).Elements("comment").ToList().ForEach(c => comments.Add(
                new CardComment(c.Element("content").Value, c.Element("created_by").Element("name").Value, c.Element("created_at").Value)));
            return comments;
        }

        /// <summary>
        /// Sends a murmur
        /// </summary>
        /// <param name="murmur"></param>
        public void SendMurmur(string murmur)
        {
            Project().SendMurmur(murmur);
        }

        /// <summary>
        /// Given a list of card type names, card number/type/name list
        /// </summary>
        /// <param name="types"></param>
        /// <returns></returns>
        public IEnumerable<CardListItem> GetCardList(IEnumerable<string> types)
        {
            var mql = GetMqlFromCardTypeList(types);
            var list = new List<CardListItem>();
            _project.ExecMql(mql).Elements("result").ToList().ForEach(e => list.Add(new CardListItem
                                                                                        {
                                                                                            Number = int.Parse(e.Element("number").Value),
                                                                                            Name = e.Element("name").Value,
                                                                                            TypeName = e.Element("type").Value
                                                                                        }));
            return list;
        }

        private static string GetMqlFromCardTypeList(IEnumerable<string> types)
        {
            var mql = new StringBuilder("select number, type, name where ");
            foreach (var t in types)
            {
                mql.Append(" type is " + t + " or");
            }
            mql.Remove(mql.Length-3, 3);
            return mql.ToString();
        }
    }

}