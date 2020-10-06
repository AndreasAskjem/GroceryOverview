﻿using GroceryOverviewLibrary;
using GroceryOverviewLibrary.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
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

                tagList.Insert(0, new TagModel { Name = GlobalConfig.DropdownDefaultText() });

                _tags = tagList;
            }
        }
        private List<ProductModel> Products { get; set; }
        private BindingSource ProductsBindingSource = new BindingSource();

        private List<ProductModel> SearchResult { get; set; }

        private TagModel SelectedTag { get; set; }
        ToolTip toolTip = new ToolTip();


        public StartpageForm()
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
            //Stops SelectedIndexChanged from doing anything when the listbox is changed by the code.
            ProductsListBox.SelectedIndexChanged -= new EventHandler(ProductsListBox_SelectedIndexChanged);
            //Stops the ListBox from scrolling to the top when changed.
            int topIndex = ProductsListBox.TopIndex;

            ProductsBindingSource.DataSource = Products;
            ProductsListBox.DataSource = ProductsBindingSource;
            ProductsBindingSource.ResetBindings(false);
            ProductsListBox.ClearSelected();

            ProductsListBox.TopIndex = topIndex;
            ProductsListBox.SelectedIndexChanged += new EventHandler(ProductsListBox_SelectedIndexChanged);

            //Empties the search box when something else updates the ListBox.
            SearchTextBox.TextChanged -= new EventHandler(SearchTextBox_TextChanged);
            SearchTextBox.Text = "";
            SearchTextBox.TextChanged += new EventHandler(SearchTextBox_TextChanged);
        }


        private void StartpageForm_Load(object sender, EventArgs e) { }

        private void ProductsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProductModel clickedProduct = (ProductModel)ProductsListBox.SelectedValue;
            if(clickedProduct == null) { return; }

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

        //TODO - Change other ListBoxes to use DrawItem.
        //TODO - Change NeedsRefill from bool to in with values 0/1/2 (too little/running low/enough)?
        //Need to change the database and ProductModel too if I do that.
        //TODO - Move most of the DrawItem to an outside function.


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

        // Needs the property DrawMode set to OwnerDrawFixed in order to work.
        private void ProductsListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            ListBox listBox = (ListBox)sender;

            ProductModel listBoxItem = (ProductModel)listBox.Items[e.Index];

            Color backgroundColor = listBoxItem.NeedsRefill ? Color.MistyRose : Color.LightGreen;

            ListBoxTools.DrawListBox(e, listBoxItem, backgroundColor, Brushes.Black);



            /*
            Brush myBrush = Brushes.Black;

            var listBox = (ListBox)sender;
            
            var listBoxItem = (ProductModel)listBox.Items[e.Index];

            var backgroundColor = listBoxItem.NeedsRefill ? Color.MistyRose : Color.LightGreen;

            e = new DrawItemEventArgs(e.Graphics,
                                  e.Font,
                                  e.Bounds,
                                  e.Index,
                                  e.State ^ DrawItemState.None,
                                  e.ForeColor,
                                  backgroundColor);

            e.DrawBackground();
            e.Graphics.DrawString(listBoxItem.Name,
                e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);
            */
        }

        private void DrawListBox(object sender, DrawItemEventArgs e, ProductModel listBoxItem, Color backgroundColor, Brush textColor)
        {
            e = new DrawItemEventArgs(e.Graphics,
                                  e.Font,
                                  e.Bounds,
                                  e.Index,
                                  e.State ^ DrawItemState.None,
                                  e.ForeColor,
                                  backgroundColor);

            e.DrawBackground();
            e.Graphics.DrawString(listBoxItem.Name,
                e.Font, textColor, e.Bounds, StringFormat.GenericDefault);
        }


        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            string searchWord = SearchTextBox.Text;
            if(searchWord == "") {
                UpdateProductsForSelectedTag();
                return;
            } //UpdateForSelectedTag?

            SearchResult = GlobalConfig.Connection.GetProductsBySearch(searchWord);


            ProductsListBox.SelectedIndexChanged -= new EventHandler(ProductsListBox_SelectedIndexChanged);

            ProductsBindingSource.DataSource = SearchResult;
            ProductsListBox.DataSource = ProductsBindingSource;
            ProductsBindingSource.ResetBindings(false);
            ProductsListBox.ClearSelected();

            ProductsListBox.SelectedIndexChanged += new EventHandler(ProductsListBox_SelectedIndexChanged);
        }

        private void ProductsListBox_MouseMove(object sender, MouseEventArgs e)
        {
            int index = ProductsListBox.IndexFromPoint(e.Location);

            if (index != -1 && index < ProductsListBox.Items.Count)
            {
                if (toolTip.GetToolTip(ProductsListBox) != ProductsListBox.Items[index].ToString())
                {   
                    toolTip.SetToolTip(ProductsListBox, ((ProductModel)ProductsListBox.Items[index]).ToolTip);
                }
            }
            else
            {
                toolTip.SetToolTip(this.ProductsListBox, string.Empty);
            }
        }
    }
}
