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
        }

        private void WireUpProducts()
        {
            throw new NotImplementedException();

            //TODO - Continue here to fix EditProductsOfTag.
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
