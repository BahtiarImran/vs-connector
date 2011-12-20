using System.Collections.ObjectModel;
using ThoughtWorksMingleLib;

namespace ThoughtWorks.VisualStudio.View.Model
{
    /// <summary>
    /// An ObservableCollection of favorites that is used to bind to the view
    /// </summary>
    public class Favorites : ObservableCollection<Favorite>
    {

    }
    /// <summary>
    /// Mingle favorite (view)
    /// </summary>
    public class Favorite
    {
        /// <summary>
        /// Name of the favorite
        /// </summary>
        private string _name;
        /// <summary>
        /// Id (not name) of a Mingle project
        /// </summary>
        private string _projectId;
        /// <summary>
        /// Collection of cards for this favorite. Bind the view to this property.
        /// </summary>
        public MingleCardCollection Cards { get; set; }
        /// <summary>
        /// Constructs a new favorite
        /// </summary>
        /// <param name="projectId"> Id (not name) of the project</param>
        /// <param name="favoriteName">Name of the favorite. Corresponds to view=favoriteName on a Mingle GET.</param>
        public Favorite(string projectId, string favoriteName)
        {
            _name = favoriteName;
            _projectId = projectId;
        }
        /// <summary>
        /// We call this method to freshen the Cards property
        /// </summary>
        /// <param name="mingle"></param>
        public void FetchCards(MingleServer mingle)
        {
            Cards = new MingleProject(_projectId, mingle).GetView(_name);
        }

    }
    /// <summary>
    /// Mingle card
    /// </summary>
    public class Card
    {

    }
    
    /// <summary>
    /// Mingle card_type
    /// </summary>
    public class CardType
    {
        public string Name { get; set; }
    }
    /// <summary>
    /// An ObservableCollection of team members that is used to bind to the view
    /// </summary>
    public class CardTypes : ObservableCollection<CardType>
    {

    }

}
