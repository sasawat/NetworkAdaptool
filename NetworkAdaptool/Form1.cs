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
        NetworkAdapter naSelectedAdapter;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            log("Discovering Network Adapters...");
            NetworkAdapter[] netadapters = NetworkAdapter.getNetworkAdapters();
            List<string> names = new List<string>();
            lbxAdapters.Items.AddRange(netadapters);
            log("Done.");

            //Make sure all the controls are disabled until an item is selected
            btnApplyIPV4.Enabled = false;
            btnDisable.Enabled = false;
            btnDisableEnable.Enabled = false;
            btnEnable.Enabled = false;
            btnRelease.Enabled = false;
            btnReleaseRenew.Enabled = false;
            btnReloadIPV4.Enabled = false;
            btnRenew.Enabled = false;
            btnSaveIPV4Profile.Enabled = false;
            tbxDefaultGateway.Enabled = false;
            tbxDNS1.Enabled = false;
            tbxDNS2.Enabled = false;
            tbxIPAddr.Enabled = false;
            tbxSubnetMask.Enabled = false;
            rbtnAutoDNS.Enabled = false;
            rbtnDHCP.Enabled = false;
            rbtnStaticDNS.Enabled = false;
            rbtnStaticIP.Enabled = false;
        }

        private void lbxAdapters_SelectedIndexChanged(object sender, EventArgs e)
        {
            NetworkAdapter naSelected = (NetworkAdapter)lbxAdapters.SelectedItem;

            //Make sure the NetworkAdapter is up to date
            naSelected.refreshManagementObjects();

            naSelectedAdapter = naSelected;

            populateAdapterInfo();
            populateIPV4Settings();

            //Enable buttons and stuff
            if (btnSaveIPV4Profile.Enabled == false)
            {
                btnApplyIPV4.Enabled = true;
                btnDisable.Enabled = true;
                btnDisableEnable.Enabled = true;
                btnEnable.Enabled = true;
                btnRelease.Enabled = true;
                btnReleaseRenew.Enabled = true;
                btnReloadIPV4.Enabled = true;
                btnRenew.Enabled = true;
                btnSaveIPV4Profile.Enabled = true;
                tbxDefaultGateway.Enabled = true;
                tbxDNS1.Enabled = true;
                tbxDNS2.Enabled = true;
                tbxIPAddr.Enabled = true;
                tbxSubnetMask.Enabled =true;
                rbtnAutoDNS.Enabled = true;
                rbtnDHCP.Enabled = true;
                rbtnStaticDNS.Enabled = true;
                rbtnStaticIP.Enabled = true;
            }
            
        }

        /// <summary>
        /// Fills the textboxes associated with Adapter Information
        /// </summary>
        private void populateAdapterInfo()
        {
            log("Populating Adapter Information...");
            tbxAdapterName.Text = naSelectedAdapter.strName;
            tbxAdapterType.Text = naSelectedAdapter.strAdapterType;
            tbxAdapterStatus.Text = naSelectedAdapter.strNetConnectionStatus;
            tbxAdapterMACAddr.Text = naSelectedAdapter.strMACAddr;
            tbxIsPhysical.Text = naSelectedAdapter.isPhysicalAdapter ? "Yes" : "No";
            tbxNetConnectionID.Text = naSelectedAdapter.strNetConnectionID;
            log("Done");
        }

        /// <summary>
        /// Fills the textboxes and radio buttons associated with IPV4 configuration
        /// </summary>
        private void populateIPV4Settings()
        {
            log("Reading IPV4 Settings...");
            if (!naSelectedAdapter.isEnabled)
            {
                log("WARNING: Adapter Disabled, no IPV4 settings.");
                return;
            }
            tbxIPAddr.Text = naSelectedAdapter.strIpAddr;
            tbxSubnetMask.Text = naSelectedAdapter.strSubnetMask;
            tbxDefaultGateway.Text = naSelectedAdapter.strDefaultGateway;
            if (!naSelectedAdapter.isDHCPEnabled)
            {
                rbtnStaticIP.Checked = true;
            }
            else
            {
                rbtnDHCP.Checked = true;
            }
            rbtnStaticDNS.Checked = true;
            tbxDNS1.Text = naSelectedAdapter.strDNS1;
            tbxDNS2.Text = naSelectedAdapter.strDNS2;
            //Cannot check whether we want static or auto DNS so we just static
            rbtnStaticDNS.Checked = true;
            log("Done.");
        }

        /// <summary>
        /// Appends message to the log textbox followed by a newline
        /// </summary>
        /// <param name="strMessage">message to append</param>
        public void log(string strMessage)
        {
            tbxLog.Text += strMessage + "\r\n";
            tbxLog.Select(tbxLog.Text.Length, 0);
            tbxLog.ScrollToCaret();
        }

        private void btnEnable_Click(object sender, EventArgs e)
        {
            log("Enabling Adapter...");
            if (naSelectedAdapter.isHwOn)
            {
                log("ERROR: Adapter Already Enabled");
                return;
            }
            naSelectedAdapter.enableAdapter();
            while (!naSelectedAdapter.isHwOn)
            {
                naSelectedAdapter.refreshManagementObjects();
            }
            log("Done.");

        }

        private void btnDisable_Click(object sender, EventArgs e)
        {
            log("Disabling Adapter...");
            if (!naSelectedAdapter.isHwOn)
            {
                log("ERROR: Adapter Already Disabled");
                return;
            }
            naSelectedAdapter.disableAdapter();
            while (naSelectedAdapter.isHwOn)
            {
                naSelectedAdapter.refreshManagementObjects();
            }
            log("Done.");
        }

        private void btnDisableEnable_Click(object sender, EventArgs e)
        {
            log("Disabling Adapter...");
            if (!naSelectedAdapter.isHwOn)
            {
                log("ERROR: Adapter Already Disabled.");
                return;
            }
            naSelectedAdapter.disableAdapter();
            while (naSelectedAdapter.isHwOn)
            {
                naSelectedAdapter.refreshManagementObjects();
            }
            log("Done.");
            log("Re-enabling Adapter...");
            naSelectedAdapter.enableAdapter();
            while (!naSelectedAdapter.isHwOn)
            {
                naSelectedAdapter.refreshManagementObjects();
            }
            log("Done.");
        }

        private void btnRefreshAdapterList_Click(object sender, EventArgs e)
        {
            log("Discovering Network Adapters...");
            NetworkAdapter[] netadapters = NetworkAdapter.getNetworkAdapters();
            List<string> names = new List<string>();
            lbxAdapters.Items.Clear();
            lbxAdapters.Items.AddRange(netadapters);
            log("Done.");

            //Make sure all the controls are disabled until an item is selected
            btnApplyIPV4.Enabled = false;
            btnDisable.Enabled = false;
            btnDisableEnable.Enabled = false;
            btnEnable.Enabled = false;
            btnRelease.Enabled = false;
            btnReleaseRenew.Enabled = false;
            btnReloadIPV4.Enabled = false;
            btnRenew.Enabled = false;
            btnSaveIPV4Profile.Enabled = false;
            tbxDefaultGateway.Enabled = false;
            tbxDNS1.Enabled = false;
            tbxDNS2.Enabled = false;
            tbxIPAddr.Enabled = false;
            tbxSubnetMask.Enabled = false;
            rbtnAutoDNS.Enabled = false;
            rbtnDHCP.Enabled = false;
            rbtnStaticDNS.Enabled = false;
            rbtnStaticIP.Enabled = false;

            //Clear the text
            tbxAdapterName.Text = "";
            tbxAdapterType.Text = "";
            tbxAdapterStatus.Text = "";
            tbxAdapterMACAddr.Text = "";
            tbxIsPhysical.Text = "";
            tbxNetConnectionID.Text = "";
            tbxIPAddr.Text = "";
            tbxSubnetMask.Text = "";
            tbxDefaultGateway.Text = ""; 
            tbxDNS1.Text = "";
            tbxDNS2.Text = "";
        }

        private void btnApplyIPV4_Click(object sender, EventArgs e)
        {
            if(
                !(
                isIP(tbxIPAddr.Text) &&
                isIP(tbxDNS1.Text) &&
                isIP(tbxDNS2.Text) &&
                isIP(tbxDefaultGateway.Text) &&
                isIP(tbxSubnetMask.Text) &&
                (rbtnDHCP.Checked || rbtnStaticIP.Checked) &&
                (rbtnAutoDNS.Checked || rbtnStaticDNS.Checked)
                )
                )
            {
                //A little error message for the user
                MessageBox.Show("Invalid Input. Please Make sure that:\r\n" + 
                    "\t1. IP Address, DNS, and Default Gateway are valid IPV4 Addresses.\r\n" + 
                    "\t2. Subnet Mask is mask format, not CIDR.\r\n" +
                    "\t3. that you have selected automatic or static IP Address and DNS.");
                log("Invalid IPV4 Settings.");
                return;
            }
            
            //Refresh our network adapter ManagementObjects just in case. Things, can, like change.
            naSelectedAdapter.refreshManagementObjects();

            log("Applying IPV4 Settings...");
            //IP Address settings
            if(rbtnDHCP.Checked)
            {
                naSelectedAdapter.enableDHCP();
            }
            else
            {
                naSelectedAdapter.setStaticIP(tbxIPAddr.Text, tbxSubnetMask.Text);
                naSelectedAdapter.setDefaultGateway(tbxDefaultGateway.Text);
            }

            //DNS Settings
            if(rbtnAutoDNS.Checked)
            {
                naSelectedAdapter.setDNSServerDynamic();
            }
            else
            {
                naSelectedAdapter.setDNSServers(new string[] { tbxDNS1.Text, tbxDNS2.Text });
            }

            //Refresh the IP settings info. Wait a second for the settings to take hold as well.
            System.Threading.Thread.Sleep(1000);
            naSelectedAdapter.refreshManagementObjects();
            populateIPV4Settings();
            log("Done.");
        }

        /// <summary>
        /// Checks whether or not a string is a valid IPV4 address
        /// </summary>
        /// <param name="strMaybeIp"></param>
        /// <returns>true if the string given represents a valid IPV4 address</returns>
        private static bool isIP(string strMaybeIp)
        {
            //I know that I should be doing this using Regular Expressions.
            //But I also know that I don't know Regular Expressions. 
            //All I can do is hope for this guy to swing in from the sky http://xkcd.com/208/

            int iStartPos = 0;
            int iEndPos = 0;
            int iLen = 0;

            for (int i = 0; i < 3; i++)
            {
                //Make sure there is a dot like somewhere
                if ((iEndPos = strMaybeIp.IndexOf(".",iStartPos)) == -1)
                {
                    return false;
                }
                iLen = iEndPos - iStartPos;
                try
                {
                    //Make sure we have a valid number between dots
                    if (int.Parse(strMaybeIp.Substring(iStartPos, iLen)) > 255)
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    //Wasn't even a number. Lame.
                    return false;
                }
                iStartPos = iEndPos + 1;
            }
            try
            {
                //Make sure we have a valid number after the last dot
                if (int.Parse(strMaybeIp.Substring(iEndPos+1)) > 255)
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                //Wasn't even a number. Lame.
                return false;
            }

            return true;
        }

        private void btnReloadIPV4_Click(object sender, EventArgs e)
        {
            naSelectedAdapter.refreshManagementObjects();
            populateIPV4Settings();
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            log("Releasing DHCP Lease...");
            naSelectedAdapter.refreshManagementObjects();
            naSelectedAdapter.releaseDHCP();
            log("Done.");
            naSelectedAdapter.refreshManagementObjects();
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            log("Renewing DHCP Lease...");
            naSelectedAdapter.refreshManagementObjects();
            naSelectedAdapter.renewDHCP();
            log("Done.");
            naSelectedAdapter.refreshManagementObjects();
        }

        private void btnReleaseRenew_Click(object sender, EventArgs e)
        {
            log("Releasing DHCP Lease...");
            naSelectedAdapter.refreshManagementObjects();
            naSelectedAdapter.releaseDHCP();
            log("Done.");
            log("Renewing DHCP Lease...");
            naSelectedAdapter.refreshManagementObjects();
            naSelectedAdapter.renewDHCP();
            log("Done.");
            naSelectedAdapter.refreshManagementObjects();
        }


    }
}
