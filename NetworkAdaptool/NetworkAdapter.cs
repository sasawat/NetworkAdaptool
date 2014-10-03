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
            foreach(ManagementObject moAdapterCfg in mocAdapterCfgCollection)
            {
                //Check that the NetworkAdapterConfiguration is tcp/ip and not Firewire/etc. 
                if((bool)moAdapterCfg["IPEnabled"])
                {
                    //Find the correlated NetworkAdapter by use of InterfaceIndex property.
                    foreach(ManagementObject moAdapter in mocAdapterCollection)
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
        /// Enables the network adapter
        /// </summary>
        public void enable()
        {
            //Enable has no paramters so we can just call it
            moAdapter.InvokeMethod("Enable", new object[] { });
        }

        /// <summary>
        /// Disables the network adapter
        /// </summary>
        public void disable()
        {
            //Disable has no paramters so we can just call it
            moAdapter.InvokeMethod("Disable", new object[] { });
        }
    }

}
