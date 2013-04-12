#region Copyright © 2010, 2011,2012, 2013 ThoughtWorks, Inc.

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

#endregion

using ThoughtWorksMingleLib;

namespace ThoughtWorks.VisualStudio
{
    /// <summary>
    /// Models a Mingle favorite/view
    /// </summary>
    public class Favorite
    {
        private readonly MingleFavorite _favorite;

        /// <summary>
        /// Constructs a new Favorite
        /// </summary>
        /// <param name="favorite"></param>
        public Favorite(MingleFavorite favorite)
        {
            _favorite = favorite;
        }

        /// <summary>
        /// Name of the favorite or view
        /// </summary>
        public string Name
        {
            get { return _favorite.Name; }
        }

        /// <summary>
        /// Type of Favorite
        /// </summary>
        public string FavoriteType
        {
            get { return _favorite.FavoritedType; }
        }
    }
}