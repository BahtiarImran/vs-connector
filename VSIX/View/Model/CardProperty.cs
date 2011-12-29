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
using ThoughtWorksMingleLib;

namespace ThoughtWorks.VisualStudio
{
    /// <summary>
    /// A Mingle property_definition
    /// </summary>
    public class CardProperty
    {
        private readonly MinglePropertyDefinition _property;
        public ViewModel Model;

        /// <summary>
        /// Constructs a new CardProperty
        /// </summary>
        /// <param name="property"></param>
        /// <param name="value"></param>
        public CardProperty(ViewModel model, MinglePropertyDefinition property, string value)
        {
            Model = model;
            _property = property;
            Value = value;
        }

        public IList<string> CardTypes { get { return _property.CardTypes.Keys; } }
        public string CardUrl { get { return _property.CardUrl; } }
        public string ColumnName { get { return _property.ColumnName; } }
        public string DataType { get { return _property.DataType; } }
        public string Description { get { return _property.Description; } }
        public bool Hidden { get { return _property.Hidden; } }
        public int Id { get { return _property.Id; } }
        public bool IsCardValued { get { return _property.IsCardValued; } }
        public bool IsFormula { get { return _property.IsFormula; } }
        public bool IsNumeric { get { return _property.IsNumeric; } }
        public bool IsSetValued { get { return _property.IsSetValued; } }
        public bool IsTeamValued { get { return _property.IsTeamValued; } }
        public bool IsTransitionOnly { get { return _property.IsTransitionOnly; } }
        public string Name { get { return _property.Name; } }
        public int Position { get { return _property.Position; } }
        public string ProjectId { get { return _property.ProjectId; } }
        public IList<string> PropertyValueDetails { get { return _property.PropertyValueDetails; } }
        public string PropertyValuesDescription { get { return _property.PropertyValuesDescription; } }
        public bool Restricted { get { return _property.Restricted; } }
        public object Value { get; set; }
    }
}