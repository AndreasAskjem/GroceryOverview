using System;
using System.Collections.Generic;
using System.Text;

namespace GroceryOverviewLibrary.Models
{
    public class ProductModel : IInput
    {
        /// <summary>
        /// Unique identifier for the product.
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Name of product.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// States whether or not the product needs a refill.
        /// </summary>
        public bool NeedsRefill { get; set; }

        /// <summary>
        /// A List of all tags that are currently associated with the tag.
        /// </summary>
        public List<TagModel> Tags { get { return GlobalConfig.Connection.GetTagsBelongingToProduct(this); } }

        /// <summary>
        /// Returns associated tags as a string.
        /// </summary>
        public string ToolTip { get { return ConvertTagsToString(); } }

        private string ConvertTagsToString()
        {
            string x = "";

            for(int i=0; i<Tags.Count; i++)
            {
                TagModel tag = Tags[i];
                if (i < Tags.Count - 1)
                {
                    x += tag.Name;
                    x += ", ";
                }
                else
                {
                    x += tag.Name;
                }
            }

            return x;
        }


        /// <summary>
        /// The displayed text to use for ListBoxes.
        /// </summary>
        public string DisplayName { get; set; }

        public ProductModel() { }
        public ProductModel(string productName)
        {
            Name = productName;
        }

        public void SetDisplayName()
        {
            string x = NeedsRefill ? "☐" : "🗹";
            DisplayName = $"{x} {Name}";
        }
        public void SetDisplayName(bool belongsToTag)
        {
            string x = belongsToTag ? "🗹" : "☐";
            DisplayName = $"{x} {Name}";
        }
    }
}
