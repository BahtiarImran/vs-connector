#region Copyright © 2011, 2012 ThoughtWorks, Inc.

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
        internal ViewModel Model;

        /// <summary>
        /// Constructs a new CardProperty
        /// </summary>
        /// <param name="model"> </param>
        /// <param name="property"></param>
        /// <param name="value"></param>
        public CardProperty(ViewModel model, MinglePropertyDefinition property, string value)
        {
            Model = model;
            _property = property;
            Value = value;
        }

        /// <summary>
        /// Constructs a new CardProperty
        /// </summary>
        /// <param name="model"></param>
        /// <param name="property"></param>
        public CardProperty(ViewModel model, MinglePropertyDefinition property)
        {
            Model = model;
            _property = property;
            Value = string.Empty;
        }

        /// <summary>
        /// List of card_type for this property
        /// </summary>
        public IList<string> CardTypes
        {
            get { return _property.CardTypes.Keys; }
        }

        /// <summary>
        /// Mingle's url for the card describing this property
        /// </summary>
        public string CardUrl
        {
            get { return _property.CardUrl; }
        }

        /// <summary>
        /// Mingle's "column_name" attribute
        /// </summary>
        public string ColumnName
        {
            get { return _property.ColumnName; }
        }

        /// <summary>
        /// Mingle's "data_type" attribute
        /// </summary>
        public string DataType
        {
            get { return _property.DataType; }
        }

        /// <summary>
        /// Mingle's "description" attribute
        /// </summary>
        public string Description
        {
            get { return _property.Description; }
        }

        /// <summary>
        /// Mingle's "hidden" attribute
        /// </summary>
        public bool Hidden
        {
            get { return _property.Hidden; }
        }

        /// <summary>
        /// Mingle's "id" attribute
        /// </summary>
        public int Id
        {
            get { return _property.Id; }
        }

        /// <summary>
        /// Property is a list of cards
        /// </summary>
        public bool IsCardValued
        {
            get { return _property.IsCardValued; }
        }

        /// <summary>
        /// Property is a foruma
        /// </summary>
        public bool IsFormula
        {
            get { return _property.IsFormula; }
        }

        /// <summary>
        /// Property is numeric
        /// </summary>
        public bool IsNumeric
        {
            get { return _property.IsNumeric; }
        }

        /// <summary>
        /// Indicates the property is a list of values in any manner
        /// </summary>
        public bool IsSetValued
        {
            get { return _property.IsSetValued; }
        }

        /// <summary>
        /// Indicates this property is a list of TeamMember
        /// </summary>
        public bool IsTeamValued
        {
            get { return _property.IsTeamValued; }
        }

        /// <summary>
        /// Indicates this property is set only by a transition execution
        /// </summary>
        public bool IsTransitionOnly
        {
            get { return _property.IsTransitionOnly; }
        }

        /// <summary>
        /// Indicates this property is a managed list in Mingle
        /// </summary>
        /// <remarks>The PropertyValueDetails has the list of values</remarks>
        public bool IsManagedListOfScalars
        {
            get
            {
                if (IsCardValued || IsTeamValued) return false;
                return IsSetValued;
            }
        }

        /// <summary>
        /// Property name
        /// </summary>
        public string Name
        {
            get { return _property.Name; }
        }

        /// <summary>
        /// Property position
        /// </summary>
        public int Position
        {
            get { return _property.Position; }
        }

        /// <summary>
        /// Mingle's position attribute
        /// </summary>
        public string ProjectId
        {
            get { return _property.ProjectId; }
        }

        /// <summary>
        /// List of values
        /// </summary>
        public PropertyValuesCollection PropertyValueDetails
        {
            get { return new PropertyValuesCollection(_property.PropertyValueDetails); }
        }

        /// <summary>
        /// Mingle's property_values_description
        /// </summary>
        public string PropertyValuesDescription
        {
            get { return _property.PropertyValuesDescription; }
        }

        /// <summary>
        /// Mingle's Restricted attribute
        /// </summary>
        public bool Restricted
        {
            get { return _property.Restricted; }
        }

        /// <summary>
        /// Value of this property
        /// </summary>
        public object Value { get; set; }
    }
}