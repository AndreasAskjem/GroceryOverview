﻿namespace GroceryOverviewUI
{
    partial class EditTagsForm
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
            this.TagNameInputTextBox = new System.Windows.Forms.TextBox();
            this.AddTagButton = new System.Windows.Forms.Button();
            this.EditTagsListBox = new System.Windows.Forms.ListBox();
            this.TagListBoxLable = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TagNameInputTextBox
            // 
            this.TagNameInputTextBox.Location = new System.Drawing.Point(12, 26);
            this.TagNameInputTextBox.Name = "TagNameInputTextBox";
            this.TagNameInputTextBox.Size = new System.Drawing.Size(370, 35);
            this.TagNameInputTextBox.TabIndex = 1;
            this.TagNameInputTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TagNameInputTextBox_KeyDown);
            // 
            // AddTagButton
            // 
            this.AddTagButton.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddTagButton.Location = new System.Drawing.Point(12, 67);
            this.AddTagButton.Name = "AddTagButton";
            this.AddTagButton.Size = new System.Drawing.Size(370, 57);
            this.AddTagButton.TabIndex = 5;
            this.AddTagButton.Text = "Add Tag";
            this.AddTagButton.UseVisualStyleBackColor = true;
            this.AddTagButton.Click += new System.EventHandler(this.AddTagButton_Click);
            // 
            // EditTagsListBox
            // 
            this.EditTagsListBox.FormattingEnabled = true;
            this.EditTagsListBox.ItemHeight = 30;
            this.EditTagsListBox.Location = new System.Drawing.Point(12, 180);
            this.EditTagsListBox.Name = "EditTagsListBox";
            this.EditTagsListBox.Size = new System.Drawing.Size(372, 544);
            this.EditTagsListBox.TabIndex = 7;
            this.EditTagsListBox.SelectedIndexChanged += new System.EventHandler(this.EditTagsListBox_SelectedIndexChanged);
            // 
            // TagListBoxLable
            // 
            this.TagListBoxLable.AutoSize = true;
            this.TagListBoxLable.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TagListBoxLable.Location = new System.Drawing.Point(174, 153);
            this.TagListBoxLable.Name = "TagListBoxLable";
            this.TagListBoxLable.Size = new System.Drawing.Size(40, 21);
            this.TagListBoxLable.TabIndex = 8;
            this.TagListBoxLable.Text = "Tags";
            // 
            // EditTagsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 736);
            this.Controls.Add(this.TagListBoxLable);
            this.Controls.Add(this.EditTagsListBox);
            this.Controls.Add(this.AddTagButton);
            this.Controls.Add(this.TagNameInputTextBox);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "EditTagsForm";
            this.Text = "Edit Tags";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TagNameInputTextBox;
        private System.Windows.Forms.Button AddTagButton;
        private System.Windows.Forms.ListBox EditTagsListBox;
        private System.Windows.Forms.Label TagListBoxLable;
    }
}