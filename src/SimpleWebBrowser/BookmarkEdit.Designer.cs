namespace Simplewebbroswer
{
	partial class BookmarkEdit
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            nameLabel = new Label();
            urlLabel = new Label();
            nameTextBox = new TextBox();
            editUrlTextBox = new TextBox();
            okButton = new Button();
            cancelButton = new Button();
            SuspendLayout();
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(12, 15);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(49, 20);
            nameLabel.TabIndex = 0;
            nameLabel.Text = "Name";
            // 
            // urlLabel
            // 
            urlLabel.AutoSize = true;
            urlLabel.Location = new Point(12, 55);
            urlLabel.Name = "urlLabel";
            urlLabel.Size = new Size(35, 20);
            urlLabel.TabIndex = 1;
            urlLabel.Text = "URL";
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(80, 12);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(360, 27);
            nameTextBox.TabIndex = 2;
            // 
            // editUrlTextBox
            // 
            editUrlTextBox.Location = new Point(80, 52);
            editUrlTextBox.Name = "editUrlTextBox";
            editUrlTextBox.Size = new Size(360, 27);
            editUrlTextBox.TabIndex = 3;
            // 
            // okButton
            // 
            okButton.Location = new Point(284, 100);
            okButton.Name = "okButton";
            okButton.Size = new Size(75, 29);
            okButton.TabIndex = 4;
            okButton.Text = "OK";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += okButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.DialogResult = DialogResult.Cancel;
            cancelButton.Location = new Point(365, 100);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 29);
            cancelButton.TabIndex = 5;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // BookmarkEdit
            // 
            AcceptButton = okButton;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelButton;
            ClientSize = new Size(452, 141);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            Controls.Add(editUrlTextBox);
            Controls.Add(nameTextBox);
            Controls.Add(urlLabel);
            Controls.Add(nameLabel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "BookmarkEdit";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Edit Bookmark";
            Load += BookmarkEdit_Load;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
		private System.Windows.Forms.Label urlLabel;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Button cancelButton;
		public System.Windows.Forms.TextBox nameTextBox;
		public System.Windows.Forms.TextBox editUrlTextBox;
	}
}
