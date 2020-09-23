using GroceryOverviewLibrary;
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
    public partial class EditProductsOfTag : Form
    {
        private TagModel ClickedTag { get; set; }
        private List<ProductModel> AllProducts { get; set; }
        private List<ProductModel> SelectedProducts { get; set; }
        public EditProductsOfTag(TagModel clickedTag)
        {
            InitializeComponent();

            ClickedTag = clickedTag;
            EditingTagLable.Text = ClickedTag.Name;

            GetDataFromDatabase();
            WireUpProducts();
        }

        private void GetDataFromDatabase()
        {
            AllProducts = GlobalConfig.Connection.GetAllProducts();
            SelectedProducts = GlobalConfig.Connection.GetProductsFilteredByTag(ClickedTag);
        }

        private void WireUpProducts()
        {
            ProductsListBox.SelectedIndexChanged -= new EventHandler(ProductsListBox_SelectedIndexChanged);

            AllProducts.ForEach(product => product.SetDisplayName(true));
            for(int i=0; i<AllProducts.Count; i++)
            {
                var index = SelectedProducts.FindIndex(selectedProduct => selectedProduct.id == AllProducts[i].id);
                bool isInSelectedProducts = index >= 0;
                AllProducts[i].SetDisplayName(isInSelectedProducts);
            }

            ProductsListBox.DataSource = AllProducts;
            ProductsListBox.DisplayMember = nameof(ProductModel.DisplayName);
            ProductsListBox.ClearSelected();

            ProductsListBox.SelectedIndexChanged += new EventHandler(ProductsListBox_SelectedIndexChanged);
        }

        private void ProductsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProductModel clickedProduct = (ProductModel)ProductsListBox.SelectedValue;
            GlobalConfig.Connection.ToggleProductTagRelation(clickedProduct, ClickedTag);

            GetDataFromDatabase();
            WireUpProducts();
        }
    

    private void DeleteTagButton_Click(object sender, EventArgs e)
        {
            GlobalConfig.Connection.DeleteTag(ClickedTag);
            Close();
        }

        private void OkayButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
