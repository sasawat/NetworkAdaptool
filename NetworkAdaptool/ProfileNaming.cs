using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetworkAdaptool
{
    public partial class ProfileNaming : Form
    {
        public string result;

        public ProfileNaming()
        {
            InitializeComponent();
        }

        private void btnLetsGo_Click(object sender, EventArgs e)
        {
            if (tbxProfileName.Text == "PROFILE CREATION CANCELED")
            {
                MessageBox.Show("Invalid profile name, please choose something else");
                return;
            }
            result = tbxProfileName.Text;
            this.Close();
        }

        private void ProfileNaming_Load(object sender, EventArgs e)
        {
            result = "PROFILE CREATION CANCELED";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
