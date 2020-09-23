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
        private List<TagModel> SelectedTags { get; set; }

        public EditTagsOfProduct(ProductModel clickedProduct)
        {
            InitializeComponent();

            ClickedProduct = clickedProduct;
            EditingProductLable.Text = ClickedProduct.Name;

            GetDataFromDatabase();
            WireUpTags();
        }

        private void GetDataFromDatabase()
        {
            AllTags = GlobalConfig.Connection.GetTags();
            SelectedTags = GlobalConfig.Connection.GetTagsBelongingToProduct(ClickedProduct);
        }

        private void WireUpTags()
        {
            TagsListBox.SelectedIndexChanged -= new EventHandler(TagsListBox_SelectedIndexChanged);

            AllTags.ForEach(tag => tag.SetListBoxName(true));
            for(int i=0; i<AllTags.Count; i++)
            {
                var index = SelectedTags.FindIndex(selectedTag => selectedTag.id == AllTags[i].id);
                bool isInSelectedTags = index >= 0;
                AllTags[i].SetListBoxName(isInSelectedTags);
            }

            TagsListBox.DataSource = AllTags;
            TagsListBox.DisplayMember = nameof(TagModel.ListBoxName);


            TagsListBox.ClearSelected();
            TagsListBox.SelectedIndexChanged += new EventHandler(TagsListBox_SelectedIndexChanged);
            //TODO - Take a closer look if something can be simplified or improved here.
        }



        private void TagsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            TagModel clickedTag = (TagModel)TagsListBox.SelectedValue;
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
    }
}
