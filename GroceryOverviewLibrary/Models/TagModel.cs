using System;
using System.Collections.Generic;
using System.Text;

namespace GroceryOverviewLibrary.Models
{
    public class TagModel : IInput
    {
        /// <summary>
        /// Identifier of tag.
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Name of the tag.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Displayed text when viewed in ListBoxes.
        /// </summary>
        public string ListBoxName { get; set; }

        public TagModel()
        {

        }
        public TagModel(string name)
        {
            Name = name;
        }

        public void SetListBoxName(bool isSelected)
        {
            string x = isSelected ? "🗹" : "☐";
            ListBoxName = $"{x} {Name}";
        }
    }
}