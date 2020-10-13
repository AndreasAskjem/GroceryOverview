using GroceryOverviewLibrary;
using GroceryOverviewLibrary.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
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

            SearchTextBox.TextChanged -= new EventHandler(SearchTextBox_TextChanged);
            SearchTextBox.Text = "Search  ";
            SearchTextBox.ForeColor = Color.Gray;
            SearchTextBox.TextChanged += new EventHandler(SearchTextBox_TextChanged);
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
            BuildEmail();


            
            //ShoppingListForm shoppingList = new ShoppingListForm();
            //shoppingList.ShowDialog();

            //string fromAddress = GlobalConfig.AppKeyLookup("senderEmail");
        }

        private void BuildEmail()
        {
            List<ProductModel> allProducts = GlobalConfig.Connection.GetAllProducts();
            List<ProductModel> productsNeedingRefill = new List<ProductModel>();

            allProducts.ForEach(product =>
            {
                if (product.NeedsRefill)
                {
                    productsNeedingRefill.Add(product);
                }
            });

            StringBuilder body = new StringBuilder();

            productsNeedingRefill.ForEach(product => body.AppendLine(product.Name));
            


            EmailLogic.SendEmail(GlobalConfig.AppKeyLookup("recieverEmail"), $"Shopping List - {DateTime.UtcNow.Date:d}", body.ToString());
        }

        private void TagDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox tagDropDown = (ComboBox)sender;
            SelectedTag = (TagModel)tagDropDown.SelectedValue;

            UpdateProductsForSelectedTag();

            SearchTextBox.TextChanged -= new EventHandler(SearchTextBox_TextChanged);
            SearchTextBox.Text = "Search  ";
            SearchTextBox.ForeColor = Color.Gray;
            SearchTextBox.TextChanged += new EventHandler(SearchTextBox_TextChanged);
        }

        //TODO - Change other ListBoxes to use DrawItem.
        //TODO - Change NeedsRefill from bool to in with values 0/1/2 (too little/running low/enough)?
        //Need to change the database and ProductModel too if I do that.
        //TODO - Error handeling for failing to connect to database?


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

            if(listBox.Items.Count < 1){ return; } // Avoids crash when ListBox is empty.

            ProductModel listBoxItem = (ProductModel)listBox.Items[e.Index];

            Color backgroundColor = listBoxItem.NeedsRefill ? Color.MistyRose : Color.LightGreen;

            ListBoxTools.DrawListBox(e, listBoxItem, backgroundColor, Brushes.Black);
        }


        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            
            if(SearchTextBox.Text == "") {
                UpdateProductsForSelectedTag();
                return;
            }

            Products = GlobalConfig.Connection.GetProductsBySearch(SearchTextBox.Text);

            WireUpProducts();
            return;
        }


        // This function is taken from here:
        // https://social.msdn.microsoft.com/Forums/windows/en-US/894d0814-dcf1-4cd6-9cca-2c6239794442/list-box-tooltip
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
                toolTip.SetToolTip(ProductsListBox, string.Empty);
            }
        }

        private void SearchTextBox_Enter(object sender, EventArgs e)
        {
            var x = SearchTextBox.Focused;


            if (SearchTextBox.Text == "Search  ")
            {
                SearchTextBox.TextChanged -= new EventHandler(SearchTextBox_TextChanged);

                SearchTextBox.Text = "";
                SearchTextBox.ForeColor = Color.Black;

                SearchTextBox.TextChanged += new EventHandler(SearchTextBox_TextChanged);
            }
        }

        private void SearchTextBox_Leave(object sender, EventArgs e)
        {
            if (SearchTextBox.Text == "")
            {
                SearchTextBox.TextChanged -= new EventHandler(SearchTextBox_TextChanged);
                SearchTextBox.Text = "Search  ";
                SearchTextBox.ForeColor = Color.Gray;
                SearchTextBox.TextChanged += new EventHandler(SearchTextBox_TextChanged);
            }
        }

        private void ShowNeedsRefill_CheckedChanged(object sender, EventArgs e)
        {
            var x = (CheckBox)sender;
            var isChecked = x.Checked;

            List<ProductModel> allProducts = GlobalConfig.Connection.GetAllProducts();
            List<ProductModel> productsNeedingRefill = new List<ProductModel>();

            if (isChecked)
            {
                allProducts.ForEach(product =>
                {
                    if (product.NeedsRefill)
                    {
                        productsNeedingRefill.Add(product);
                    }
                });
                Products = productsNeedingRefill;
            }
            else
            {
                Products = allProducts;
            }
            WireUpProducts();
        }
    }
}
