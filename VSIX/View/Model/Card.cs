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
using System.Linq;
using ThoughtWorksMingleLib;

namespace ThoughtWorks.VisualStudio
{
    /// <summary>
    /// A Card with buffering the consumer from MingleCard
    /// </summary>
    public class Card
    {
        /// <summary>
        /// Base MingleCard object
        /// </summary>
        internal MingleCard MingleCard { get; private set; }
        internal ViewModel Model { get; set; }
        private readonly Dictionary<string, CardProperty> _propertiesCache  = new Dictionary<string, CardProperty>();

        public Card(ViewModel model)
        {
            Model = model;
        }

        /// <summary>
        /// Constructs a new Card and sets the MingleCard
        /// </summary>
        /// <param name="mingleCard"></param>
        /// <param name="model"></param>
        public Card(MingleCard mingleCard, ViewModel model)
        {
            MingleCard = mingleCard;
            Model = model;
        }

        public object Value { get; set; }
        internal int Number { get { return MingleCard.Number; } set { MingleCard.Number = value; } }
        internal string Name { get { return MingleCard.Name; } set { MingleCard.Name = value; } }
        internal int Id { get { return MingleCard.Id; } set { MingleCard.Id = value; } }
        internal string Url { get { return MingleCard.Url; } set {  } }
        internal string Description { get { return MingleCard.Description; } set { MingleCard.Description = value; } }
        internal string RenderedDescription { get { return MingleCard.RenderedDescription; } }
        internal string CardType { get { return MingleCard.Type; } set { MingleCard.Type = value; } }
        internal string CardTypeUrl { get { return MingleCard.CardTypeUrl; } set { MingleCard.CardTypeUrl = value; } }
        internal string ProjectName { get { return MingleCard.ProjectName; } set { MingleCard.ProjectName = value; } }
        internal string ProjectId { get { return MingleCard.ProjectId; } set { MingleCard.ProjectId = value; } }
        internal string ProjectUrl { get { return MingleCard.ProjectUrl; } set { MingleCard.ProjectUrl = value; } }
        internal string Version { get { return MingleCard.Version; } set { MingleCard.Version = value; } }
        internal int ProjectCardRank { get { return MingleCard.ProjectCardRank; } set { MingleCard.ProjectCardRank = value; } }
        internal DateTime CreatedOn { get { return MingleCard.CreatedOn; } set { MingleCard.CreatedOn = value; } }
        internal DateTime ModifiedOn { get { return MingleCard.ModifiedOn; } set { MingleCard.ModifiedOn = value; } }
        internal string ModifiedByLogin { get { return MingleCard.ModifiedByLogin; } set { MingleCard.ModifiedByLogin = value; } }
        internal string ModifiedByName { get { return MingleCard.ModifiedByName; } set { MingleCard.ModifiedByName = value; } }
        internal string ModifiedByUrl { get { return MingleCard.ModifiedByUrl; } set { MingleCard.ModifiedByUrl = value; } }
        internal string CreatedByLogin { get { return MingleCard.CreatedByLogin; } set { MingleCard.CreatedByLogin = value; } }
        internal string CreatedByName { get { return MingleCard.CreatedByName; } set { MingleCard.CreatedByName = value; } }
        internal string CreatedByUrl { get { return MingleCard.CreatedByUrl; } set { MingleCard.CreatedByUrl = value; } }
        internal Dictionary<string, CardProperty> Properties
        {
            get
            {
                if (_propertiesCache.Count > 0) return _propertiesCache;
                MingleCard.CardProperties.ToList().ForEach(p => _propertiesCache.
                                                                    Add(p.Key, new CardProperty(Model, p.Value.PropertyDefinition, p.Value.Value)));
                return _propertiesCache;
            }
        }
        internal IEnumerable<Transition> Transitions 
        { 
            get
            {
                return Model.Transitions.Where(tr => tr.CardTypeName == MingleCard.Type).ToList();
            } 
            set { }
        }

        /// <summary>
        /// Add a card Attribute name/value to the PostData
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        internal void AddCardAttributeFilterToPostData(string name, string value)
        {
            MingleCard.PostData.Add(string.Format("card[{0}]={1}", name, value).Trim());
        }

        /// <summary>
        /// Add a Property name/value to the PostData
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        internal void AddPropertyFilterToPostData(string name, string value)
        {
            MingleCard.PostData.Add(String.Format("card[properties][][name]={0}", name).Trim());
            MingleCard.PostData.Add(String.Format("card[properties][][value]={0}", value).Trim());
        }

        /// <summary>
        /// Update the card
        /// </summary>
        internal void Update()
        {
            MingleCard.Update();
        }

        /// <summary>
        /// Set the value of a card property
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        internal void SetPropertyOrAttributValue(string name, string value)
        {
            var isProperty = Properties.ContainsKey(name);

            switch (isProperty)
            {
                case true:
                    AddPropertyFilterToPostData(name, value);
                    break;

                case false:
                    AddCardAttributeFilterToPostData(name, value);
                    break;
            }

        }

        /// <summary>
        /// Clears the PostData collection
        /// </summary>
        internal void ClearPostData()
        {
            MingleCard.PostData.Clear();
        }
    }
}