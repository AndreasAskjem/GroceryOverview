namespace GroceryOverviewUI
{
    partial class ShoppingListForm
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
            this.TagDropDown = new System.Windows.Forms.ComboBox();
            this.ProductListBoxLable = new System.Windows.Forms.Label();
            this.ProductsListBox = new System.Windows.Forms.ListBox();
            this.SendToEmailButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TagDropDown
            // 
            this.TagDropDown.FormattingEnabled = true;
            this.TagDropDown.Location = new System.Drawing.Point(13, 12);
            this.TagDropDown.Name = "TagDropDown";
            this.TagDropDown.Size = new System.Drawing.Size(371, 38);
            this.TagDropDown.TabIndex = 3;
            // 
            // ProductListBoxLable
            // 
            this.ProductListBoxLable.AutoSize = true;
            this.ProductListBoxLable.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductListBoxLable.Location = new System.Drawing.Point(156, 68);
            this.ProductListBoxLable.Name = "ProductListBoxLable";
            this.ProductListBoxLable.Size = new System.Drawing.Size(71, 21);
            this.ProductListBoxLable.TabIndex = 11;
            this.ProductListBoxLable.Text = "Products";
            // 
            // ProductsListBox
            // 
            this.ProductsListBox.FormattingEnabled = true;
            this.ProductsListBox.ItemHeight = 30;
            this.ProductsListBox.Location = new System.Drawing.Point(13, 92);
            this.ProductsListBox.Name = "ProductsListBox";
            this.ProductsListBox.Size = new System.Drawing.Size(372, 574);
            this.ProductsListBox.TabIndex = 10;
            // 
            // SendToEmailButton
            // 
            this.SendToEmailButton.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SendToEmailButton.Location = new System.Drawing.Point(13, 676);
            this.SendToEmailButton.Name = "SendToEmailButton";
            this.SendToEmailButton.Size = new System.Drawing.Size(370, 57);
            this.SendToEmailButton.TabIndex = 12;
            this.SendToEmailButton.Text = "Send To E-Mail";
            this.SendToEmailButton.UseVisualStyleBackColor = true;
            // 
            // ShoppingListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 736);
            this.Controls.Add(this.SendToEmailButton);
            this.Controls.Add(this.ProductListBoxLable);
            this.Controls.Add(this.ProductsListBox);
            this.Controls.Add(this.TagDropDown);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "ShoppingListForm";
            this.Text = "Shopping List";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox TagDropDown;
        private System.Windows.Forms.Label ProductListBoxLable;
        private System.Windows.Forms.ListBox ProductsListBox;
        private System.Windows.Forms.Button SendToEmailButton;
    }
}