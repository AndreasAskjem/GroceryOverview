﻿namespace GroceryOverviewUI
{
    partial class StartpageForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ProductsListBox = new System.Windows.Forms.ListBox();
            this.TagDropDown = new System.Windows.Forms.ComboBox();
            this.ShoppingListButton = new System.Windows.Forms.Button();
            this.EditProductsButton = new System.Windows.Forms.Button();
            this.EditTagsButton = new System.Windows.Forms.Button();
            this.ProductListBoxLable = new System.Windows.Forms.Label();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.SearchLable = new System.Windows.Forms.Label();
            this.ShowNeedsRefill = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // ProductsListBox
            // 
            this.ProductsListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ProductsListBox.FormattingEnabled = true;
            this.ProductsListBox.ItemHeight = 30;
            this.ProductsListBox.Location = new System.Drawing.Point(12, 197);
            this.ProductsListBox.Name = "ProductsListBox";
            this.ProductsListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.ProductsListBox.Size = new System.Drawing.Size(372, 334);
            this.ProductsListBox.TabIndex = 1;
            this.ProductsListBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ProductsListBox_DrawItem);
            this.ProductsListBox.SelectedIndexChanged += new System.EventHandler(this.ProductsListBox_SelectedIndexChanged);
            this.ProductsListBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ProductsListBox_MouseMove);
            // 
            // TagDropDown
            // 
            this.TagDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TagDropDown.FormattingEnabled = true;
            this.TagDropDown.Location = new System.Drawing.Point(14, 12);
            this.TagDropDown.Name = "TagDropDown";
            this.TagDropDown.Size = new System.Drawing.Size(371, 38);
            this.TagDropDown.TabIndex = 2;
            this.TagDropDown.SelectedIndexChanged += new System.EventHandler(this.TagDropDown_SelectedIndexChanged);
            // 
            // ShoppingListButton
            // 
            this.ShoppingListButton.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShoppingListButton.Location = new System.Drawing.Point(14, 542);
            this.ShoppingListButton.Name = "ShoppingListButton";
            this.ShoppingListButton.Size = new System.Drawing.Size(370, 57);
            this.ShoppingListButton.TabIndex = 3;
            this.ShoppingListButton.Text = "Shopping List";
            this.ShoppingListButton.UseVisualStyleBackColor = true;
            this.ShoppingListButton.Click += new System.EventHandler(this.ShoppingListButton_Click);
            // 
            // EditProductsButton
            // 
            this.EditProductsButton.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditProductsButton.Location = new System.Drawing.Point(14, 605);
            this.EditProductsButton.Name = "EditProductsButton";
            this.EditProductsButton.Size = new System.Drawing.Size(370, 57);
            this.EditProductsButton.TabIndex = 4;
            this.EditProductsButton.Text = "Edit Products";
            this.EditProductsButton.UseVisualStyleBackColor = true;
            this.EditProductsButton.Click += new System.EventHandler(this.EditProductsButton_Click);
            // 
            // EditTagsButton
            // 
            this.EditTagsButton.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditTagsButton.Location = new System.Drawing.Point(14, 668);
            this.EditTagsButton.Name = "EditTagsButton";
            this.EditTagsButton.Size = new System.Drawing.Size(370, 57);
            this.EditTagsButton.TabIndex = 5;
            this.EditTagsButton.Text = "Edit Tags";
            this.EditTagsButton.UseVisualStyleBackColor = true;
            this.EditTagsButton.Click += new System.EventHandler(this.EditTagsButton_Click);
            // 
            // ProductListBoxLable
            // 
            this.ProductListBoxLable.AutoSize = true;
            this.ProductListBoxLable.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductListBoxLable.Location = new System.Drawing.Point(159, 176);
            this.ProductListBoxLable.Name = "ProductListBoxLable";
            this.ProductListBoxLable.Size = new System.Drawing.Size(71, 21);
            this.ProductListBoxLable.TabIndex = 9;
            this.ProductListBoxLable.Text = "Products";
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Location = new System.Drawing.Point(14, 91);
            this.SearchTextBox.MaxLength = 50;
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(371, 35);
            this.SearchTextBox.TabIndex = 10;
            this.SearchTextBox.TextChanged += new System.EventHandler(this.SearchTextBox_TextChanged);
            this.SearchTextBox.Enter += new System.EventHandler(this.SearchTextBox_Enter);
            this.SearchTextBox.Leave += new System.EventHandler(this.SearchTextBox_Leave);
            // 
            // SearchLable
            // 
            this.SearchLable.AutoSize = true;
            this.SearchLable.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.SearchLable.Location = new System.Drawing.Point(167, 67);
            this.SearchLable.Name = "SearchLable";
            this.SearchLable.Size = new System.Drawing.Size(57, 21);
            this.SearchLable.TabIndex = 11;
            this.SearchLable.Text = "Search";
            // 
            // ShowNeedsRefill
            // 
            this.ShowNeedsRefill.AutoSize = true;
            this.ShowNeedsRefill.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ShowNeedsRefill.Location = new System.Drawing.Point(14, 132);
            this.ShowNeedsRefill.Name = "ShowNeedsRefill";
            this.ShowNeedsRefill.Size = new System.Drawing.Size(263, 25);
            this.ShowNeedsRefill.TabIndex = 12;
            this.ShowNeedsRefill.Text = "Only show products needing refill";
            this.ShowNeedsRefill.UseVisualStyleBackColor = true;
            this.ShowNeedsRefill.CheckedChanged += new System.EventHandler(this.ShowNeedsRefill_CheckedChanged);
            // 
            // StartpageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(396, 736);
            this.Controls.Add(this.ShowNeedsRefill);
            this.Controls.Add(this.SearchLable);
            this.Controls.Add(this.SearchTextBox);
            this.Controls.Add(this.ProductListBoxLable);
            this.Controls.Add(this.EditTagsButton);
            this.Controls.Add(this.EditProductsButton);
            this.Controls.Add(this.ShoppingListButton);
            this.Controls.Add(this.TagDropDown);
            this.Controls.Add(this.ProductsListBox);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "StartpageForm";
            this.Text = "Grocery Overview";
            this.Load += new System.EventHandler(this.StartpageForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox ProductsListBox;
        private System.Windows.Forms.ComboBox TagDropDown;
        private System.Windows.Forms.Button ShoppingListButton;
        private System.Windows.Forms.Button EditProductsButton;
        private System.Windows.Forms.Button EditTagsButton;
        private System.Windows.Forms.Label ProductListBoxLable;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.Label SearchLable;
        private System.Windows.Forms.CheckBox ShowNeedsRefill;
    }
}

