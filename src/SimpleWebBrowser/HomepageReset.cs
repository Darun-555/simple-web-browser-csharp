using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Simplewebbroswer
{
    public partial class HomepageReset : Form
    {
        // Initialize dialog and set default dialog results
        public HomepageReset()
        {
            InitializeComponent();
            okButton.DialogResult = DialogResult.OK;
            cancelButton.DialogResult = DialogResult.Cancel;
        }

        // Getting and setting methods to set the new homepage URL
        public string HomePageUrlSetter
        {
            get { return urlTextBoxSetter.Text; }
            set { urlTextBoxSetter.Text = value; }
        }

        private void HomepageReset_Load(object sender, EventArgs e)
        {

        }
    }
}
