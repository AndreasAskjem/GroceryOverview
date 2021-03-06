﻿using GroceryOverviewLibrary;
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
    public partial class EditTagsOfProduct : Form
    {
        private ProductModel ClickedProduct { get; set; }
        private List<TagModel> AllTags { get; set; }
        private BindingSource AllTagsBindingSource = new BindingSource();
        private List<TagModel> SelectedTags { get; set; }

        public EditTagsOfProduct(ProductModel clickedProduct)
        {
            InitializeComponent();

            ClickedProduct = clickedProduct;
            EditingProductLable.Text = ClickedProduct.Name;
            SetButtonText();

            GetDataFromDatabase();
            WireUpTags();
        }

        private void GetDataFromDatabase()
        {
            AllTags = GlobalConfig.Connection.GetAllTags();
            SelectedTags = GlobalConfig.Connection.GetTagsBelongingToProduct(ClickedProduct);
        }

        private void WireUpTags()
        {
            TagsListBox.SelectedIndexChanged -= new EventHandler(TagsListBox_SelectedIndexChanged);
            int topIndex = TagsListBox.TopIndex;

            for(int i=0; i<AllTags.Count; i++)
            {
                var index = SelectedTags.FindIndex(selectedTag => selectedTag.id == AllTags[i].id);
                bool isInSelectedTags = index >= 0;
                AllTags[i].SetListBoxName(isInSelectedTags);
            }

            AllTagsBindingSource.DataSource = AllTags;
            TagsListBox.DataSource = AllTagsBindingSource;
            TagsListBox.DisplayMember = nameof(TagModel.ListBoxName);
            AllTagsBindingSource.ResetBindings(false);
            TagsListBox.ClearSelected();

            TagsListBox.TopIndex = topIndex;
            TagsListBox.SelectedIndexChanged += new EventHandler(TagsListBox_SelectedIndexChanged);
        }

        private void SetButtonText()
        {
            ToggleNeedsRefillButton.Text = ClickedProduct.NeedsRefill ? "✘" : "✔";
        }


        private void TagsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            TagModel clickedTag = (TagModel)TagsListBox.SelectedValue;
            if (clickedTag == null) { return; }
            GlobalConfig.Connection.ToggleProductTagRelation(ClickedProduct, clickedTag);

            GetDataFromDatabase();
            WireUpTags();
        }

        private void DeleteProductButton_Click(object sender, EventArgs e)
        {
            GlobalConfig.Connection.DeleteProduct(ClickedProduct);
            Close();
        }

        private void OkayButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ToggleNeedsRefillButton_Click(object sender, EventArgs e)
        {
            GlobalConfig.Connection.ToggleProductNeedsRefill(ClickedProduct);
            SetButtonText();
            //TODO - Improve visual
        }
    }
}
