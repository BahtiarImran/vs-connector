using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace ThoughtWorks.VisualStudio
{
    public class CardComment
    {
        public string Comment { get; private set; }
        public string Name { get; private set; }
        public string Date { get; private set; }
        public CardComment(string comment, string name, string date)
        {
            Comment = comment;
            Name = name;
            Date = Convert.ToDateTime(date).ToString(CultureInfo.InvariantCulture);
        }
    }
}
