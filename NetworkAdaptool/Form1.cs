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
            lbxAdapters.Items.AddRange(netadapters);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((NetworkAdapter)lbxAdapters.SelectedItem).enable();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ((NetworkAdapter)lbxAdapters.SelectedItem).disable();
        }

        private void lbxAdapters_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Repopulate all the fields
            NetworkAdapter naSelected = (NetworkAdapter)lbxAdapters.SelectedItem;

            log("Populating Adapter Information");
            tbxAdapterName.Text = naSelected.strName;
            tbxAdapterType.Text = naSelected.strAdapterType;
            tbxAdapterStatus.Text = naSelected.strNetConnectionStatus;
            tbxAdapterMACAddr.Text = naSelected.strMACAddr;
            tbxIsPhysical.Text = naSelected.isPhysicalAdapter ? "Yes" : "No";
            tbxNetConnectionID.Text = naSelected.strNetConnectionID;

            reloadIPV4Settings(naSelected);
        }

        private void reloadIPV4Settings(NetworkAdapter na)
        {
            log("Reading IPV4 Settings");
            if (!na.isEnabled)
            {
                log("Adapter Disabled, no IPV4 settings");
                return;
            }
            tbxIPAddr.Text = na.strIpAddr;
            tbxSubnetMask.Text = na.strSubnetMask;
            tbxDefaultGateway.Text = na.strDefaultGateway;
            if(na.isDHCPEnabled)
            {
                rbtnStaticIP.Checked = true;
            }else
            {
                rbtnDHCP.Checked = true;
            }
            rbtnStaticDNS.Checked = true;
            tbxDNS1.Text = na.strDNS1;
            tbxDNS2.Text = na.strDNS2;
            //Cannot check whether we want static or auto DNS so we just static
            rbtnStaticDNS.Checked = true; 
        }

        public void log(string strMessage)
        {
            tbxLog.Text += strMessage + "\n";
        }
    }
}
