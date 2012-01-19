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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Linq;
using Mocks;
using ThoughtWorks.VisualStudio;

namespace Tests
{
    class MockViewModel : IViewModel
    {
        private readonly MingleServer _mingle;
        private readonly ViewModel _model;

        /// <summary>
        /// Mocked ViewModel implementing IViewModel
        /// </summary>
        /// <param name="filename">Name of test data file to be passed to Mocks.MingleServer</param>
        public MockViewModel(string filename)
        {
            if (!new FileInfo(filename).Exists) throw new Exception(filename + " is not found");
            _mingle = new MingleServer(filename);
            _model = new ViewModel(_mingle);
        }

        /// <summary>
        /// List of projectid/name pairs sorted by name
        /// </summary>
        public SortedList<string, KeyValuePair> ProjectList
        {
            get { return _model.ProjectList; }
        }

        /// <summary>
        /// Set the value of the current project
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns>False if the projectid is not selectable</returns>
        public bool SelectProject(object projectId)
        {
            return _model.SelectProject(projectId);
        }

        /// <summary>
        /// List of favorites of type "CardListView"
        /// </summary>
        public Favorites Favorites
        {
            get { return _model.Favorites; }
        }

        /// <summary>
        /// List of TeamMember sorted by name
        /// </summary>
        public SortedList<string, TeamMember> Team
        {
            get { return _model.Team; }
        }

        /// <summary>
        /// List of CardTypes
        /// </summary>
        public CardTypes CardTypes
        {
            get { return _model.CardTypes; }
        }

        /// <summary>
        /// List of property definitions
        /// </summary>
        public Dictionary<string, CardProperty> PropertyDefinitions
        {
            get { return _model.PropertyDefinitions; }
        }

        /// <summary>
        /// The project id of the currently selected project
        /// </summary>
        public string ProjectId
        {
            get { return _model.ProjectId; }
        }

        public SortedList<string, CardBasicInfo> GetCardsForFavorite(string view)
        {
            return _model.GetCardsForFavorite(view);
        }

        /// <summary>
        /// Returns a Card
        /// </summary>
        /// <param name="cardNo">Card number</param>
        /// <returns></returns>
        public Card GetOneCard(int cardNo)
        {
            return _model.GetOneCard(cardNo);
        }

        /// <summary>
        /// Colleciton of transitions for the project
        /// </summary>
        public ObservableCollection<Transition> Transitions
        {
            get { return _model.Transitions; }
        }

        /// <summary>
        /// Crates a new card
        /// </summary>
        /// <param name="type">Card type</param>
        /// <param name="name">Card name</param>
        /// <returns>The card htat was created</returns>
        public Card CreateCard(string type, string name)
        {
           return _model.CreateCard(type, name);
        }

        /// <summary>
        /// Returns the selected project
        /// </summary>
        /// <returns></returns>
        public Project Project()
        {
            return _model.Project();
        }

        /// <summary>
        /// Returns all the cards
        /// </summary>
        /// <returns></returns>
        public XElement GetListOfCards()
        {
            return _model.GetListOfCards();
        }

        /// <summary>
        /// Returns cards of a certain type
        /// </summary>
        /// <param name="type">Card type</param>
        /// <returns></returns>
        public Cards GetCardsOfType(string type)
        {
            return _model.GetCardsOfType(type);
        }

        /// <summary>
        /// Posts a comment to a card
        /// </summary>
        /// <param name="number"></param>
        /// <param name="comment"></param>
        public void PostComment(int number, string comment)
        {
            _model.PostComment(number, comment);
        }

        /// <summary>
        /// Gets all the comments for a card
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public IEnumerable<CardComment> GetCommentsForCard(int number)
        {
            return _model.GetCommentsForCard(number);
        }

        /// <summary>
        /// Gets all the murmur history
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Murmur> GetMurmurs()
        {
            return _model.GetMurmurs();
        }
    }
}
