namespace GroceryOverviewUI
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
            this.HeaderLable = new System.Windows.Forms.Label();
            this.ProductsListBox = new System.Windows.Forms.ListBox();
            this.TagDropDown = new System.Windows.Forms.ComboBox();
            this.ShoppingListButton = new System.Windows.Forms.Button();
            this.EditProductsButton = new System.Windows.Forms.Button();
            this.EditTagsButton = new System.Windows.Forms.Button();
            this.ProductListBoxLable = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // HeaderLable
            // 
            this.HeaderLable.AutoSize = true;
            this.HeaderLable.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeaderLable.Location = new System.Drawing.Point(127, 9);
            this.HeaderLable.Name = "HeaderLable";
            this.HeaderLable.Size = new System.Drawing.Size(127, 37);
            this.HeaderLable.TabIndex = 0;
            this.HeaderLable.Text = "Overview";
            // 
            // ProductsListBox
            // 
            this.ProductsListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ProductsListBox.FormattingEnabled = true;
            this.ProductsListBox.ItemHeight = 30;
            this.ProductsListBox.Location = new System.Drawing.Point(12, 137);
            this.ProductsListBox.Name = "ProductsListBox";
            this.ProductsListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.ProductsListBox.Size = new System.Drawing.Size(372, 394);
            this.ProductsListBox.TabIndex = 1;
            this.ProductsListBox.SelectedIndexChanged += new System.EventHandler(this.ProductsListBox_SelectedIndexChanged);
            this.ProductsListBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ProductsListBox_DrawItem);
            // 
            // TagDropDown
            // 
            this.TagDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TagDropDown.FormattingEnabled = true;
            this.TagDropDown.Location = new System.Drawing.Point(13, 56);
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
            this.ProductListBoxLable.Location = new System.Drawing.Point(166, 113);
            this.ProductListBoxLable.Name = "ProductListBoxLable";
            this.ProductListBoxLable.Size = new System.Drawing.Size(71, 21);
            this.ProductListBoxLable.TabIndex = 9;
            this.ProductListBoxLable.Text = "Products";
            // 
            // StartpageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(396, 736);
            this.Controls.Add(this.ProductListBoxLable);
            this.Controls.Add(this.EditTagsButton);
            this.Controls.Add(this.EditProductsButton);
            this.Controls.Add(this.ShoppingListButton);
            this.Controls.Add(this.TagDropDown);
            this.Controls.Add(this.ProductsListBox);
            this.Controls.Add(this.HeaderLable);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "StartpageForm";
            this.Text = "Grocery Overview";
            this.Load += new System.EventHandler(this.StartpageForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label HeaderLable;
        private System.Windows.Forms.ListBox ProductsListBox;
        private System.Windows.Forms.ComboBox TagDropDown;
        private System.Windows.Forms.Button ShoppingListButton;
        private System.Windows.Forms.Button EditProductsButton;
        private System.Windows.Forms.Button EditTagsButton;
        private System.Windows.Forms.Label ProductListBoxLable;
    }
}

