//
// Copyright © ThoughtWorks Studios 2010, 2011
//
using System.Collections.ObjectModel;

namespace ThoughtWorks.VisualStudio.View.Model
{
    internal class Favorite
    {
        internal string Name { get; set; }
        internal ObservableCollection<Card> Cards { get; set; }
    }
}