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
        SortedList<string,TeamMember>  Team { get; }
        /// <summary>
        /// List of CardTypes
        /// </summary>
        CardTypesCollection CardTypesCollection { get; }
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