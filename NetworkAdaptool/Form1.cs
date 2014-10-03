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

            foreach(NetworkAdapter netadapter in netadapters)
            {
                names.Add(netadapter.strName);
            }

            listBox1.Items.AddRange(names.ToArray());
        }
    }
}
