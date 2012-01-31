using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThoughtWorks.VisualStudio
{
    /// <summary>
    /// Describes a card's name, number and type
    /// </summary>
    public class CardListItem
    {
        /// <summary>
        /// Card name
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        /// Card number
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Card type name
        /// </summary>
        public string TypeName { get; set; }
    }
}
