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
