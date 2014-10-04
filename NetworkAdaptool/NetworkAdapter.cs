using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace NetworkAdaptool
{
    /// <summary>
    /// An easy way to manipulate a pair of NetworkAdapter and NetworkAdapterConfiguration Management Objects
    /// </summary>
    class NetworkAdapter
    {
        private ManagementObject moAdapter;
        private ManagementObject moAdapterCfg;

        public string strName { get; private set; }
        public string strAdapterType { get; private set; }
        public string strCaption { get; private set; }
        public string strIpAddr 
        { 
            get
            {
                return (string)moAdapterCfg["IPAddress"];
            }
            private set { }
        }
        public string strSubnetMask
        {
            get
            {
                return (string)moAdapterCfg["SubnetMask"];
            }
            private set { }
        }
        public bool isEnabled
        {
            get 
            {
                return (bool)this.moAdapter["NetEnabled"];
            }
            private set { }
        }
        public bool isDHCPEnabled
        {
            get
            {
                return (bool)moAdapterCfg["DHCPEnabled"];
            }
            private set { }
        }

        private NetworkAdapter(ManagementObject moNetworkAdapater, ManagementObject moNetworkAdapterConfiguration)
        {
            this.moAdapter = moNetworkAdapater;
            this.moAdapterCfg = moNetworkAdapterConfiguration;
            this.strName = (string)this.moAdapter["Name"];
            this.strAdapterType = (string)this.moAdapter["AdapterType"];
            this.strCaption = (string)this.moAdapter["Caption"];
        }

        /// <summary>
        /// Gets all the TCP/IP network adapters on the system. 
        /// </summary>
        /// <returns>An array of NetworkAdapter objects for each IPEnabled NetworkAdapter/Configuration pair on the system</returns>
        public static NetworkAdapter[] getNetworkAdapters()
        {
            List<NetworkAdapter> listAdapters = new List<NetworkAdapter>();

            //Computer System Hardware Classes
            //Win32_NetworkAdapterConfiguration and Win32_NetworkAdapter were chosen despite being depreciated
            //for backwards compatibility for Windows 7. At some point in the future, we should detect whether
            //the application is running on Windows 8, 10, etc. or prior and choose the correct ManagementClass
            ManagementClass mcWin32_NetworkAdapterConfiguration = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementClass mcWin32_NetworkAdapter = new ManagementClass("Win32_NetworkAdapter");

            //Retrieve the objects that are of the classes specified above
            ManagementObjectCollection mocAdapterCfgCollection = mcWin32_NetworkAdapterConfiguration.GetInstances();
            ManagementObjectCollection mocAdapterCollection = mcWin32_NetworkAdapter.GetInstances();

            //Collate the NetworkAdapter objects and the NetworkAdapterConfiguration objects by InterfaceIndex
            foreach(ManagementObject moAdapter in mocAdapterCollection)
            {
                //Check that the NetworkAdapterConfiguration is tcp/ip and not Firewire/etc. 
                string strAdapterType = (string)moAdapter["AdapterType"];
                if(strAdapterType == "Wireless" || 
                    strAdapterType == "Ethernet 802.3" || 
                    strAdapterType == "Wide Area Network (WAN)")
                {
                    //Find the correlated NetworkAdapter by use of InterfaceIndex property.
                    foreach(ManagementObject moAdapterCfg in mocAdapterCfgCollection)
                    {
                        if((uint)moAdapter["InterfaceIndex"] == (uint)moAdapterCfg["InterfaceIndex"])
                        {
                            //Yay~! We found it. Add it to the list and break;.
                            listAdapters.Add(new NetworkAdapter(moAdapter, moAdapterCfg));
                            break;
                        }
                    }
                }
                
            }

            //Convert our list to an array and return it.
            return listAdapters.ToArray();
        }

        /// <summary>
        /// Sets a static IP
        /// </summary>
        /// <param name="strIp">String containing the IP address to set. Can be IPV4 or IPV6. e.g. "13.37.69.69"</param>
        /// <param name="strSubnetMask">String containing the subnet mask for the IP. Not cidr stuff. e.g. "255.255.255.0</param>
        public void setStaticIP(string strIp, string strSubnetMask)
        {
            //Make a ManagementBaseObject for parameters for the call to enable static ip
            ManagementBaseObject mboNewIP = moAdapterCfg.GetMethodParameters("EnableStatic");

            //Set the static ip configuration settings
            mboNewIP["IPAddress"] = new string[] { strIp };
            mboNewIP["SubnetMask"] = new string[] { strSubnetMask };

            //Make the call
            moAdapterCfg.InvokeMethod("EnableStatic", mboNewIP, null);
        }

        /// <summary>
        /// Sets the default gateway
        /// </summary>
        /// <param name="strIp">String containing the IP address of the default gateway. e.g. "13.37.69.254"</param>
        public void setDefaultGateway(string strIp)
        {
            //Make the ManagementBaseOBject for parameters for the call to set gateway
            ManagementBaseObject mboNewGateway = moAdapterCfg.GetMethodParameters("SetGateways");

            //Populate the parameters
            //Cost metric is usually 1 so we'll just go with that.
            mboNewGateway["GatewayCostMetric"] = new UInt16[] { 1 };
            mboNewGateway["DefaultIPGateway"] = new string[] { strIp };

            //Make the call
            moAdapterCfg.InvokeMethod("SetGateways", mboNewGateway, null);
        }

        /// <summary>
        /// Turns on DHCP (i.e., get the ipaddr setting from dhcp server
        /// </summary>
        public void enableDHCP()
        {
            //Enable DHCP has no paramters so we can just call it
            moAdapterCfg.InvokeMethod("EnableDHCP", new object[] { });
        }

        /// <summary>
        /// Release the DHCP Lease ala ipconfig /release
        /// </summary>
        public void releaseDHCP()
        {
            //Release DHCP has no paramters so we can just call it
            moAdapterCfg.InvokeMethod("ReleaseDHCPLease", new object[] { });
        }

        /// <summary>
        /// Renew the DHCP Lease ala ipconfig /renew
        /// </summary>
        public void renewDHCP()
        {
            //Renew DHCP has no paramters so we can just call it
            moAdapterCfg.InvokeMethod("RenewDHCPLease", new object[] { });
        }

        /// <summary>
        /// Tells the network adapter to get the IP address of the DNS server automatically
        /// </summary>
        public void setDNSServerDynamic()
        {
            //Setting DNS server search order with no arguments is dynamically get DNS server address
            moAdapterCfg.InvokeMethod("SetDNSServerSearchOrder", new object[] { });
        }

        /// <summary>
        /// Sets the DNS servers for which the network adapter will query 
        /// </summary>
        /// <param name="strarrIps">Array of strings containing IP addresses of desired DNS servers</param>
        public void setDNSServers(string[] strarrIps)
        {
            //Make a ManagementBaseObject for parameters for the call to SetDNSServerSearchOrder
            ManagementBaseObject mboNewGateway = moAdapterCfg.GetMethodParameters("SetDNSServerSearchOrder");
            mboNewGateway["DNSServerSearchOrder"] = strarrIps;
        }

        /// <summary>
        /// Enables the network adapter
        /// </summary>
        public void enable()
        {
            //Enable has no paramters so we can just call it
            moAdapter.InvokeMethod("Enable", moAdapter.GetMethodParameters("Enable"), null);
        }

        /// <summary>
        /// Disables the network adapter
        /// </summary>
        public void disable()
        {
            //Disable has no paramters so we can just call it
            moAdapter.InvokeMethod("Disable", moAdapter.GetMethodParameters("Disable"), null);
        }

        public override string ToString()
        {
            return strName;
        }
    }

}
