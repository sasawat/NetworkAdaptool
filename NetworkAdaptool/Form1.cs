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

            //Make sure all the controls are disabled until an item is selected
            btnApplyIPV4.Enabled = false;
            btnDisable.Enabled = false;
            btnDisableEnable.Enabled = false;
            btnEnable.Enabled = false;
            btnRelease.Enabled = false;
            btnReleaseRenew.Enabled = false;
            btnReleaseRenewAll.Enabled = false;
            btnReloadIPV4.Enabled = false;
            btnRenew.Enabled = false;
            btnSaveIPV4Profile.Enabled = false;
            tbxDefaultGateway.Enabled = false;
            tbxDNS1.Enabled = false;
            tbxDNS2.Enabled = false;
            tbxIPAddr.Enabled = false;
            tbxSubnetMask.Enabled = false;
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

            //Enable buttons and stuff
            if (btnSaveIPV4Profile.Enabled == false)
            {
                log("Enabling settings");
                btnApplyIPV4.Enabled = true;
                btnDisable.Enabled = true;
                btnDisableEnable.Enabled = true;
                btnEnable.Enabled = true;
                btnRelease.Enabled = true;
                btnReleaseRenew.Enabled = true;
                btnReleaseRenewAll.Enabled = true;
                btnReloadIPV4.Enabled = true;
                btnRenew.Enabled = true;
                btnSaveIPV4Profile.Enabled = true;
                tbxDefaultGateway.Enabled = true;
                tbxDNS1.Enabled = true;
                tbxDNS2.Enabled = true;
                tbxIPAddr.Enabled = true;
                tbxSubnetMask.Enabled =true;
            }
            
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
            tbxLog.Text += strMessage + "\r\n";
        }

        private void btnEnable_Click(object sender, EventArgs e)
        {
        }
    }
}
