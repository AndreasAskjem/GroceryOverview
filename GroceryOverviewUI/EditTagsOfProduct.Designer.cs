namespace GroceryOverviewUI
{
    partial class EditTagsOfProduct
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
            this.EditingTextLable = new System.Windows.Forms.Label();
            this.EditingProductLable = new System.Windows.Forms.Label();
            this.TagListBoxLable = new System.Windows.Forms.Label();
            this.TagsListBox = new System.Windows.Forms.ListBox();
            this.DeleteProductButton = new System.Windows.Forms.Button();
            this.OkayButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // EditingTextLable
            // 
            this.EditingTextLable.AutoSize = true;
            this.EditingTextLable.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditingTextLable.Location = new System.Drawing.Point(12, 9);
            this.EditingTextLable.Name = "EditingTextLable";
            this.EditingTextLable.Size = new System.Drawing.Size(107, 37);
            this.EditingTextLable.TabIndex = 1;
            this.EditingTextLable.Text = "Editing:";
            // 
            // EditingProductLable
            // 
            this.EditingProductLable.AutoSize = true;
            this.EditingProductLable.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditingProductLable.Location = new System.Drawing.Point(113, 9);
            this.EditingProductLable.Name = "EditingProductLable";
            this.EditingProductLable.Size = new System.Drawing.Size(223, 37);
            this.EditingProductLable.TabIndex = 2;
            this.EditingProductLable.Text = "<Product Name>";
            // 
            // TagListBoxLable
            // 
            this.TagListBoxLable.AutoSize = true;
            this.TagListBoxLable.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TagListBoxLable.Location = new System.Drawing.Point(174, 64);
            this.TagListBoxLable.Name = "TagListBoxLable";
            this.TagListBoxLable.Size = new System.Drawing.Size(40, 21);
            this.TagListBoxLable.TabIndex = 10;
            this.TagListBoxLable.Text = "Tags";
            // 
            // TagsListBox
            // 
            this.TagsListBox.FormattingEnabled = true;
            this.TagsListBox.ItemHeight = 30;
            this.TagsListBox.Location = new System.Drawing.Point(12, 91);
            this.TagsListBox.Name = "TagsListBox";
            this.TagsListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.TagsListBox.Size = new System.Drawing.Size(372, 574);
            this.TagsListBox.TabIndex = 9;
            this.TagsListBox.SelectedIndexChanged += new System.EventHandler(this.TagsListBox_SelectedIndexChanged);
            // 
            // DeleteProductButton
            // 
            this.DeleteProductButton.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteProductButton.Location = new System.Drawing.Point(12, 671);
            this.DeleteProductButton.Name = "DeleteProductButton";
            this.DeleteProductButton.Size = new System.Drawing.Size(185, 57);
            this.DeleteProductButton.TabIndex = 11;
            this.DeleteProductButton.Text = "Delete";
            this.DeleteProductButton.UseVisualStyleBackColor = true;
            this.DeleteProductButton.Click += new System.EventHandler(this.DeleteProductButton_Click);
            // 
            // OkayButton
            // 
            this.OkayButton.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OkayButton.Location = new System.Drawing.Point(203, 671);
            this.OkayButton.Name = "OkayButton";
            this.OkayButton.Size = new System.Drawing.Size(185, 57);
            this.OkayButton.TabIndex = 12;
            this.OkayButton.Text = "Okay";
            this.OkayButton.UseVisualStyleBackColor = true;
            this.OkayButton.Click += new System.EventHandler(this.OkayButton_Click);
            // 
            // EditTagsOfProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 736);
            this.Controls.Add(this.OkayButton);
            this.Controls.Add(this.DeleteProductButton);
            this.Controls.Add(this.TagListBoxLable);
            this.Controls.Add(this.TagsListBox);
            this.Controls.Add(this.EditingProductLable);
            this.Controls.Add(this.EditingTextLable);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "EditTagsOfProduct";
            this.Text = "Edit Tags Of Product";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label EditingTextLable;
        private System.Windows.Forms.Label EditingProductLable;
        private System.Windows.Forms.Label TagListBoxLable;
        private System.Windows.Forms.ListBox TagsListBox;
        private System.Windows.Forms.Button DeleteProductButton;
        private System.Windows.Forms.Button OkayButton;
    }
}