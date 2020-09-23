namespace GroceryOverviewUI
{
    partial class EditProductsOfTag
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
            this.OkayButton = new System.Windows.Forms.Button();
            this.DeleteTagButton = new System.Windows.Forms.Button();
            this.ProductListBoxLable = new System.Windows.Forms.Label();
            this.ProductsListBox = new System.Windows.Forms.ListBox();
            this.EditingTagLable = new System.Windows.Forms.Label();
            this.EditingTextLable = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // OkayButton
            // 
            this.OkayButton.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OkayButton.Location = new System.Drawing.Point(201, 671);
            this.OkayButton.Name = "OkayButton";
            this.OkayButton.Size = new System.Drawing.Size(185, 57);
            this.OkayButton.TabIndex = 18;
            this.OkayButton.Text = "Okay";
            this.OkayButton.UseVisualStyleBackColor = true;
            this.OkayButton.Click += new System.EventHandler(this.OkayButton_Click);
            // 
            // DeleteTagButton
            // 
            this.DeleteTagButton.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteTagButton.Location = new System.Drawing.Point(10, 671);
            this.DeleteTagButton.Name = "DeleteTagButton";
            this.DeleteTagButton.Size = new System.Drawing.Size(185, 57);
            this.DeleteTagButton.TabIndex = 17;
            this.DeleteTagButton.Text = "Delete";
            this.DeleteTagButton.UseVisualStyleBackColor = true;
            this.DeleteTagButton.Click += new System.EventHandler(this.DeleteTagButton_Click);
            // 
            // ProductListBoxLable
            // 
            this.ProductListBoxLable.AutoSize = true;
            this.ProductListBoxLable.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductListBoxLable.Location = new System.Drawing.Point(172, 64);
            this.ProductListBoxLable.Name = "ProductListBoxLable";
            this.ProductListBoxLable.Size = new System.Drawing.Size(71, 21);
            this.ProductListBoxLable.TabIndex = 16;
            this.ProductListBoxLable.Text = "Products";
            // 
            // ProductsListBox
            // 
            this.ProductsListBox.FormattingEnabled = true;
            this.ProductsListBox.ItemHeight = 30;
            this.ProductsListBox.Location = new System.Drawing.Point(10, 91);
            this.ProductsListBox.Name = "ProductsListBox";
            this.ProductsListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.ProductsListBox.Size = new System.Drawing.Size(372, 574);
            this.ProductsListBox.TabIndex = 15;
            this.ProductsListBox.SelectedIndexChanged += new System.EventHandler(this.ProductsListBox_SelectedIndexChanged);
            // 
            // EditingTagLable
            // 
            this.EditingTagLable.AutoSize = true;
            this.EditingTagLable.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditingTagLable.Location = new System.Drawing.Point(111, 9);
            this.EditingTagLable.Name = "EditingTagLable";
            this.EditingTagLable.Size = new System.Drawing.Size(172, 37);
            this.EditingTagLable.TabIndex = 14;
            this.EditingTagLable.Text = "<Tag Name>";
            // 
            // EditingTextLable
            // 
            this.EditingTextLable.AutoSize = true;
            this.EditingTextLable.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditingTextLable.Location = new System.Drawing.Point(10, 9);
            this.EditingTextLable.Name = "EditingTextLable";
            this.EditingTextLable.Size = new System.Drawing.Size(107, 37);
            this.EditingTextLable.TabIndex = 13;
            this.EditingTextLable.Text = "Editing:";
            // 
            // EditProductsOfTag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 736);
            this.Controls.Add(this.OkayButton);
            this.Controls.Add(this.DeleteTagButton);
            this.Controls.Add(this.ProductListBoxLable);
            this.Controls.Add(this.ProductsListBox);
            this.Controls.Add(this.EditingTagLable);
            this.Controls.Add(this.EditingTextLable);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "EditProductsOfTag";
            this.Text = "EditProductsOfTag";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OkayButton;
        private System.Windows.Forms.Button DeleteTagButton;
        private System.Windows.Forms.Label ProductListBoxLable;
        private System.Windows.Forms.ListBox ProductsListBox;
        private System.Windows.Forms.Label EditingTagLable;
        private System.Windows.Forms.Label EditingTextLable;
    }
}