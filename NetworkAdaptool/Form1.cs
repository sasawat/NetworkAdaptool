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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            NetworkAdapter[] netadapters = NetworkAdapter.getNetworkAdapters();
            List<string> names = new List<string>();
            listBox1.Items.AddRange(netadapters);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((NetworkAdapter)listBox1.SelectedItem).enable();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ((NetworkAdapter)listBox1.SelectedItem).disable();
        }
    }
}
