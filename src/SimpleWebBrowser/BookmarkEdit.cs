using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simplewebbroswer
{
    public partial class BookmarkEdit : Form
    {
        public string EditedName { get; private set; }
        public string EditedUrl { get; private set; }

        // Initialize the bookmark edit dialog
        public BookmarkEdit()
        {
            InitializeComponent();
        }

        // Sets the dialog box with the current bookmark values
        public void SetBookmark(string name, string url)
        {
            nameTextBox.Text = name;
            editUrlTextBox.Text = url;
        }

        // Validate and saves changed values
        private void okButton_Click(object sender, EventArgs e)
        {
            var name = nameTextBox.Text?.Trim();
            var url = editUrlTextBox.Text?.Trim();

            if (string.IsNullOrWhiteSpace(url))
            {
                MessageBox.Show(this, "URL cannot be empty.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!url.StartsWith("http://") && !url.StartsWith("https://"))
            {
                url = "https://" + url;
            }

            EditedName = string.IsNullOrWhiteSpace(name) ? url : name;
            EditedUrl = url;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void BookmarkEdit_Load(object sender, EventArgs e)
        {

        }
    }
}
