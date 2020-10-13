using GroceryOverviewLibrary;
using GroceryOverviewLibrary.Models;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GroceryOverviewUI
{
    public partial class ShoppingListForm : Form
    {
        private List<TagModel> _tags { get; set; }
        private List<TagModel> Tags
        {
            get { return _tags; }
            set
            {
                var tagList = value;

                tagList.Insert(0, new TagModel { Name = GlobalConfig.DropdownDefaultText() });

                _tags = tagList;
            }
        }
        private List<ProductModel> Products { get; set; }
        private BindingSource ProductsBindingSource = new BindingSource();

        private List<ProductModel> SearchResult { get; set; }

        private TagModel SelectedTag { get; set; }

        public ShoppingListForm()
        {
            InitializeComponent();

        }

        private void GetDataFromDatabase()
        {
            Tags = GlobalConfig.Connection.GetAllTags();

            var allProducts = GlobalConfig.Connection.GetAllProducts();
            allProducts.ForEach(product =>
            {
                if (product.NeedsRefill)
                {
                    Products.Add(product);
                }
            });
        }

        private void WireUpTags()
        {
            TagDropDown.DataSource = Tags;
            TagDropDown.DisplayMember = nameof(TagModel.Name);

        }
    }
}
