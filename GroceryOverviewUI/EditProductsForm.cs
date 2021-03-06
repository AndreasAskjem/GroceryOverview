﻿using GroceryOverviewLibrary;
using GroceryOverviewLibrary.DataAccess;
using GroceryOverviewLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GroceryOverviewUI
{
    public partial class EditProductsForm : Form
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

        private TagModel SelectedTag { get; set; }


        public EditProductsForm()
        {
            InitializeComponent();

            GetDataFromDatabase();

            WireUpTags();
            WireUpProducts();
        }

        private void GetDataFromDatabase()
        {
            Tags = GlobalConfig.Connection.GetAllTags();
            Products = GlobalConfig.Connection.GetAllProducts();
        }

        private void WireUpTags()
        {
            TagDropDown.DataSource = Tags;
            TagDropDown.DisplayMember = nameof(TagModel.Name);
        }

        private void WireUpProducts()
        {
            EditProductsListBox.SelectedIndexChanged -= new EventHandler(EditProductsListBox_SelectedIndexChanged);
            int topIndex = EditProductsListBox.TopIndex;

            //Products.ForEach(p => p.SetDisplayName());

            ProductsBindingSource.DataSource = Products;
            EditProductsListBox.DataSource = ProductsBindingSource;
            //EditProductsListBox.DisplayMember = nameof(ProductModel.DisplayName);
            ProductsBindingSource.ResetBindings(false);
            EditProductsListBox.ClearSelected();

            EditProductsListBox.TopIndex = topIndex;
            EditProductsListBox.SelectedIndexChanged += new EventHandler(EditProductsListBox_SelectedIndexChanged);
        }

        private void AddProductButton_Click(object sender, EventArgs e)
        {
            AddProductFromTextBox();
        }
        private void ProductNameInputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddProductFromTextBox();
            }
        }

        private void AddProductFromTextBox()
        {
            // Returns empty string if input is acceptable, and an error message if not.
            string validationResult = ValidateTextInput.ProductName(ProductNameInputTextBox.Text, Products);

            ProductModel newProduct = new ProductModel(ProductNameInputTextBox.Text);

            if (validationResult == "")
            {
                GlobalConfig.Connection.AddProduct(newProduct);

                EditTagsOfProduct editTagsOfProduct = new EditTagsOfProduct(newProduct);
                editTagsOfProduct.ShowDialog();

            }
            else
            {
                MessageBox.Show(validationResult, "Invalid name");
                return;
            }

            
            ProductNameInputTextBox.Text = "";

            GetDataFromDatabase();
            UpdateListBoxForSelectedTag();
        }

        private void EditProductsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProductModel clickedProduct = (ProductModel)EditProductsListBox.SelectedValue;
            if (clickedProduct == null) { return; }

            EditTagsOfProduct editTagsOfProduct = new EditTagsOfProduct(clickedProduct);
            editTagsOfProduct.ShowDialog();

            WireUpProducts();
        }

        private void TagDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox tagDropDown = (ComboBox)sender;

            SelectedTag = (TagModel)tagDropDown.SelectedValue;

            UpdateListBoxForSelectedTag();
        }

        private void UpdateListBoxForSelectedTag()
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

        private void EditProductsListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            ListBox listBox = (ListBox)sender;

            ProductModel listBoxItem = (ProductModel)listBox.Items[e.Index];

            Color backgroundColor = listBoxItem.NeedsRefill ? Color.MistyRose : Color.LightGreen;

            ListBoxTools.DrawListBox(e, listBoxItem, backgroundColor, Brushes.Black);
        }
    }
}