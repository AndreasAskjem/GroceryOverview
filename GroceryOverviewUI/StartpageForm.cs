using GroceryOverviewLibrary;
using GroceryOverviewLibrary.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GroceryOverviewUI
{
    public partial class StartpageForm : Form
    {
        private List<TagModel> _tags { get; set; }
        private List<TagModel> Tags
        {
            get { return _tags; }
            set
            {
                var tagList = value;

                TagModel unselected = new TagModel();
                unselected.Name = GlobalConfig.DropdownDefaultText();
                tagList.Insert(0, unselected);

                _tags = tagList;
            }
        }
        private List<ProductModel> Products { get; set; }
        private BindingSource ProductsBindingSource = new BindingSource();

        private TagModel SelectedTag { get; set; }


        public StartpageForm()
        {
            InitializeComponent();

            GetDataFromDatabase();

            WireUpTags();
            WireUpProducts();
        }

        private void GetDataFromDatabase()
        {
            Tags = GlobalConfig.Connection.GetTags();
            Products = GlobalConfig.Connection.GetAllProducts();
        }

        private void WireUpTags()
        {
            TagDropDown.DataSource = Tags;
            TagDropDown.DisplayMember = nameof(TagModel.Name);

        }

        private void WireUpProducts()
        {
            //Stops SelectedIndexChanged from doing anything when the listbox is changed by the code.
            ProductsListBox.SelectedIndexChanged -= new EventHandler(ProductsListBox_SelectedIndexChanged);
            //Stops the ListBox from scrolling to the top when changed.
            int topIndex = ProductsListBox.TopIndex;

            Products.ForEach(p => p.SetDisplayName());

            ProductsBindingSource.DataSource = Products;
            ProductsListBox.DataSource = ProductsBindingSource;
            ProductsListBox.DisplayMember = nameof(ProductModel.DisplayName);
            ProductsBindingSource.ResetBindings(false);
            ProductsListBox.ClearSelected();

            ProductsListBox.TopIndex = topIndex;
            ProductsListBox.SelectedIndexChanged += new EventHandler(ProductsListBox_SelectedIndexChanged);
        }


        private void StartpageForm_Load(object sender, EventArgs e) { }

        private void ProductsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProductModel clickedProduct = (ProductModel)ProductsListBox.SelectedValue;
            int index = ProductsListBox.SelectedIndex;
            ProductModel updatedProduct = GlobalConfig.Connection.ToggleProductNeedsRefill(clickedProduct);
            Products[index] = updatedProduct;
            
            WireUpProducts();
        }

        private void EditProductsButton_Click(object sender, EventArgs e)
        {
            EditProductsForm editProducts = new EditProductsForm();
            editProducts.ShowDialog();

            GetDataFromDatabase();
            UpdateProductsForSelectedTag();
        }

        private void EditTagsButton_Click(object sender, EventArgs e)
        {
            EditTagsForm editTags = new EditTagsForm();
            editTags.ShowDialog();

            GetDataFromDatabase();
            WireUpTags();
        }

        private void ShoppingListButton_Click(object sender, EventArgs e)
        {
            ShoppingListForm shoppingList = new ShoppingListForm();
            shoppingList.ShowDialog();
        }



        private void TagDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox tagDropDown = (ComboBox)sender;

            SelectedTag = (TagModel)tagDropDown.SelectedValue;


            UpdateProductsForSelectedTag();
        }

        private void UpdateProductsForSelectedTag()
        {
            if (SelectedTag.Name == GlobalConfig.DropdownDefaultText())
            {
                GetDataFromDatabase();
            }
            else
            {
                Products = GlobalConfig.Connection.GetProductsFilteredByTag(SelectedTag);
            }
            WireUpProducts();
        }
    }
}
