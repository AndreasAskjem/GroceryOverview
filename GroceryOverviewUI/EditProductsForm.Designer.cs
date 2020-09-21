namespace GroceryOverviewUI
{
    partial class EditProductsForm
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
            this.ProductNameInputTextBox = new System.Windows.Forms.TextBox();
            this.AddProductButton = new System.Windows.Forms.Button();
            this.TagDropDown = new System.Windows.Forms.ComboBox();
            this.EditProductsListBox = new System.Windows.Forms.ListBox();
            this.ProductListBoxLable = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ProductNameInputTextBox
            // 
            this.ProductNameInputTextBox.Location = new System.Drawing.Point(12, 23);
            this.ProductNameInputTextBox.Name = "ProductNameInputTextBox";
            this.ProductNameInputTextBox.Size = new System.Drawing.Size(370, 35);
            this.ProductNameInputTextBox.TabIndex = 0;
            this.ProductNameInputTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ProductNameInputTextBox_KeyDown);
            // 
            // AddProductButton
            // 
            this.AddProductButton.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddProductButton.Location = new System.Drawing.Point(12, 64);
            this.AddProductButton.Name = "AddProductButton";
            this.AddProductButton.Size = new System.Drawing.Size(370, 57);
            this.AddProductButton.TabIndex = 4;
            this.AddProductButton.Text = "Add Product";
            this.AddProductButton.UseVisualStyleBackColor = true;
            this.AddProductButton.Click += new System.EventHandler(this.AddProductButton_Click);
            // 
            // TagDropDown
            // 
            this.TagDropDown.FormattingEnabled = true;
            this.TagDropDown.Location = new System.Drawing.Point(12, 138);
            this.TagDropDown.Name = "TagDropDown";
            this.TagDropDown.Size = new System.Drawing.Size(371, 38);
            this.TagDropDown.TabIndex = 5;
            this.TagDropDown.SelectedIndexChanged += new System.EventHandler(this.TagDropDown_SelectedIndexChanged);
            // 
            // EditProductsListBox
            // 
            this.EditProductsListBox.FormattingEnabled = true;
            this.EditProductsListBox.ItemHeight = 30;
            this.EditProductsListBox.Location = new System.Drawing.Point(11, 210);
            this.EditProductsListBox.Name = "EditProductsListBox";
            this.EditProductsListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.EditProductsListBox.Size = new System.Drawing.Size(372, 514);
            this.EditProductsListBox.TabIndex = 6;
            this.EditProductsListBox.SelectedIndexChanged += new System.EventHandler(this.EditProductsListBox_SelectedIndexChanged);
            // 
            // ProductListBoxLable
            // 
            this.ProductListBoxLable.AutoSize = true;
            this.ProductListBoxLable.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductListBoxLable.Location = new System.Drawing.Point(156, 186);
            this.ProductListBoxLable.Name = "ProductListBoxLable";
            this.ProductListBoxLable.Size = new System.Drawing.Size(71, 21);
            this.ProductListBoxLable.TabIndex = 9;
            this.ProductListBoxLable.Text = "Products";
            // 
            // EditProductsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 736);
            this.Controls.Add(this.ProductListBoxLable);
            this.Controls.Add(this.EditProductsListBox);
            this.Controls.Add(this.TagDropDown);
            this.Controls.Add(this.AddProductButton);
            this.Controls.Add(this.ProductNameInputTextBox);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "EditProductsForm";
            this.Text = "Edit Products";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ProductNameInputTextBox;
        private System.Windows.Forms.Button AddProductButton;
        private System.Windows.Forms.ComboBox TagDropDown;
        private System.Windows.Forms.ListBox EditProductsListBox;
        private System.Windows.Forms.Label ProductListBoxLable;
    }
}