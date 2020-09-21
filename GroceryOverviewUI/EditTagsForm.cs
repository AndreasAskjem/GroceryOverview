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
    public partial class EditTagsForm : Form
    {
        private List<TagModel> Tags { get; set; }
        public EditTagsForm()
        {
            InitializeComponent();

            GetDataFromDatabase();

            WireUpTags();
        }

        private void GetDataFromDatabase()
        {
            Tags = GlobalConfig.Connection.GetTags();
        }

        private void WireUpTags()
        {
            EditTagsListBox.DataSource = Tags;
            EditTagsListBox.DisplayMember = nameof(TagModel.Name);
        }


        private void AddTagButton_Click(object sender, EventArgs e)
        {
            string validationResult = ValidateTextInput.TagName(TagNameInputTextBox.Text, Tags);

            if(validationResult == "")
            {
                TagModel tagModel = new TagModel(TagNameInputTextBox.Text);
                GlobalConfig.Connection.AddTag(tagModel);
            }
            else
            {
                MessageBox.Show(validationResult, "Invalid name");
            }

            TagNameInputTextBox.Text = "";
            GetDataFromDatabase();
            WireUpTags();
        }

        private void DeleteTagButton_Click(object sender, EventArgs e)
        {
            TagModel tagModel = (TagModel)EditTagsListBox.SelectedItem;
            GlobalConfig.Connection.DeleteTag(tagModel);

            GetDataFromDatabase();
            WireUpTags();
        }

        //TODO - Add an "Edit connected products" button and make a form similar to EditTagsOfProduct (called EditProductsOfTagForm?).
        //Make the Add tag button open this window.
    }
}
