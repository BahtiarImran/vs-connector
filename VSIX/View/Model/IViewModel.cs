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
using System.Xml.Linq;

namespace ThoughtWorks.VisualStudio
{
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
        FavoritesDictionary FavoritesDictionary { get; }

        /// <summary>
        /// List of TeamMember sorted by name
        /// </summary>
        SortedList<string, TeamMember> TeamMemberDictionary { get; }

        /// <summary>
        /// List of CardTypes
        /// </summary>
        CardTypesDictionary CardTypesDictionary { get; }

        /// <summary>
        /// List of property definitions
        /// </summary>
        Dictionary<string, CardProperty> PropertyDefinitions { get; }

        /// <summary>
        /// The project id of the currently selected project
        /// </summary>
        string ProjectId { get; }

        /// <summary>
        /// Get list of cards for a Favorite (a.k.a. view)
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
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
        ObservableCollection<Transition> TransitionsCollection { get; }

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
        XElement ListOfCards { get; }

        /// <summary>
        /// Returns cards of a certain type
        /// </summary>
        /// <param name="type">Card type</param>
        /// <returns></returns>
        CardsCollection GetCardsOfType(string type);

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
        ObservableCollection<Murmur> Murmurs { get; }

        /// <summary>
        /// Sends a murmur
        /// </summary>
        /// <param name="murmur"></param>
        void SendMurmur(string murmur);
    }
}