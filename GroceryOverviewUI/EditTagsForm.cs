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
            EditTagsListBox.SelectedIndexChanged -= new EventHandler(EditTagsListBox_SelectedIndexChanged);

            EditTagsListBox.DataSource = Tags;
            EditTagsListBox.DisplayMember = nameof(TagModel.Name);
            EditTagsListBox.ClearSelected();

            EditTagsListBox.SelectedIndexChanged += new EventHandler(EditTagsListBox_SelectedIndexChanged);
        }


        private void AddTagButton_Click(object sender, EventArgs e)
        {
            AddTagFromTexBox();
        }
        private void TagNameInputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddTagFromTexBox();
            }
        }

        private void AddTagFromTexBox()
        {
            string validationResult = ValidateTextInput.TagName(TagNameInputTextBox.Text, Tags);

            if (validationResult == "")
            {
                TagModel newTag = new TagModel(TagNameInputTextBox.Text);
                GlobalConfig.Connection.AddTag(newTag);

                EditProductsOfTag editProductsOfTag = new EditProductsOfTag(newTag);
                editProductsOfTag.ShowDialog();
            }
            else
            {
                MessageBox.Show(validationResult, "Invalid name");
            }

            TagNameInputTextBox.Text = "";

            GetDataFromDatabase();
            WireUpTags();
        }

        private void EditTagsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            TagModel clickedTag = (TagModel)EditTagsListBox.SelectedValue;

            if(clickedTag == null) { return; }

            EditProductsOfTag editProductsOfTag = new EditProductsOfTag(clickedTag);
            editProductsOfTag.ShowDialog();

            GetDataFromDatabase();
            WireUpTags();
        }
    }
}
