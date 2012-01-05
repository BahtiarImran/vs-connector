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
        public MingleCard MingleCard { get; private set; }
        public ViewModel Model { get; set; }
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
        public int Number { get { return MingleCard.Number; } set { MingleCard.Number = value; } }
        public string Name { get { return MingleCard.Name; } set { MingleCard.Name = value; } }
        public int Id { get { return MingleCard.Id; } set { MingleCard.Id = value; } }
        public string Url { get { return MingleCard.Url; } set {  } }
        public string Description { get { return MingleCard.Description; } set { MingleCard.Description = value; } }
        public string RenderedDescription { get { return MingleCard.RenderedDescription; } }
        public string CardType { get { return MingleCard.Type; } set { MingleCard.Type = value; } }
        public string CardTypeUrl { get { return MingleCard.CardTypeUrl; } set { MingleCard.CardTypeUrl = value; } }
        public string ProjectName { get { return MingleCard.ProjectName; } set { MingleCard.ProjectName = value; } }
        public string ProjectId { get { return MingleCard.ProjectId; } set { MingleCard.ProjectId = value; } }
        public string ProjectUrl { get { return MingleCard.ProjectUrl; } set { MingleCard.ProjectUrl = value; } }
        public string Version { get { return MingleCard.Version; } set { MingleCard.Version = value; } }
        public int ProjectCardRank { get { return MingleCard.ProjectCardRank; } set { MingleCard.ProjectCardRank = value; } }
        public DateTime CreatedOn { get { return MingleCard.CreatedOn; } set { MingleCard.CreatedOn = value; } }
        public DateTime ModifiedOn { get { return MingleCard.ModifiedOn; } set { MingleCard.ModifiedOn = value; } }
        public string ModifiedByLogin { get { return MingleCard.ModifiedByLogin; } set { MingleCard.ModifiedByLogin = value; } }
        public string ModifiedByName { get { return MingleCard.ModifiedByName; } set { MingleCard.ModifiedByName = value; } }
        public string ModifiedByUrl { get { return MingleCard.ModifiedByUrl; } set { MingleCard.ModifiedByUrl = value; } }
        public string CreatedByLogin { get { return MingleCard.CreatedByLogin; } set { MingleCard.CreatedByLogin = value; } }
        public string CreatedByName { get { return MingleCard.CreatedByName; } set { MingleCard.CreatedByName = value; } }
        public string CreatedByUrl { get { return MingleCard.CreatedByUrl; } set { MingleCard.CreatedByUrl = value; } }
        public Dictionary<string, CardProperty> Properties
        {
            get
            {
                if (_propertiesCache.Count > 0) return _propertiesCache;
                MingleCard.CardProperties.ToList().ForEach(p => _propertiesCache.
                                                                    Add(p.Key, new CardProperty(Model, p.Value.PropertyDefinition, p.Value.Value)));
                return _propertiesCache;
            }
        }
        public IEnumerable<Transition> Transitions 
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
        public void AddCardAttributeFilterToPostData(string name, string value)
        {
            MingleCard.PostData.Add(string.Format("card[{0}]={1}", name, value).Trim());
        }

        /// <summary>
        /// Add a Property name/value to the PostData
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void AddPropertyFilterToPostData(string name, string value)
        {
            MingleCard.PostData.Add(String.Format("card[properties][][name]={0}", name).Trim());
            MingleCard.PostData.Add(String.Format("card[properties][][value]={0}", value).Trim());
        }

        /// <summary>
        /// Update the card
        /// </summary>
        public void Update()
        {
            MingleCard.Update();
        }

        /// <summary>
        /// Set the value of a card property
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public void SetPropertyOrAttributValue(string name, string value)
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
        public void ClearPostData()
        {
            MingleCard.PostData.Clear();
        }
    }
}