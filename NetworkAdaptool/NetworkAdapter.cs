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
                try
                {
                    return ((string[])moAdapterCfg["IPAddress"])[0];
                }
                catch (Exception ex)
                {
                    if (refreshNetworkAdapterConfigurationObject())
                    {
                        return ((string[])moAdapterCfg["IPAddress"])[0];
                    }
                    else
                    {
                        return "";
                    }
                }
            }
            private set { }
        }
        public string strSubnetMask
        {
            get
            {
                try
                {
                    return ((string[])moAdapterCfg["IPSubnet"])[0];
                }
                catch (Exception ex)
                {
                    if (refreshNetworkAdapterConfigurationObject())
                    {
                        return ((string[])moAdapterCfg["IPSubnet"])[0];
                    }
                    else
                    {
                        return "";
                    }
                }
            }
            private set { }
        }
        public string strDefaultGateway
        {
            get
            {
                try
                {
                    return ((string[])moAdapterCfg["DefaultIPGateway"])[0];
                }
                catch (Exception ex)
                {
                    if (refreshNetworkAdapterConfigurationObject())
                    {
                        try
                        {
                            return ((string[])moAdapterCfg["DefaultIPGateway"])[0];
                        }catch(Exception sEx)
                        {
                            return "";
                        }
                    }
                    else
                    {
                        return "";
                    }
                }
            }
            private set { }
        }
        public string strDNS1
        {
            get
            {
                try
                {
                    return ((string[])moAdapterCfg["DNSServerSearchOrder"])[0];
                }
                catch (Exception ex)
                {
                    if (refreshNetworkAdapterConfigurationObject())
                    {
                        try
                        {
                            return ((string[])moAdapterCfg["DNSServerSearchOrder"])[0];
                        }catch(Exception sEx)
                        {
                            return "";
                        }
                    }
                    else
                    {
                        return "";
                    }
                }
            }
            private set { }
        }
        public string strDNS2
        {
            get
            {
                try
                {
                    return ((string[])moAdapterCfg["DNSServerSearchOrder"])[1];
                }
                catch (Exception ex)
                {
                    if (refreshNetworkAdapterConfigurationObject())
                    {
                        try
                        {
                            return ((string[])moAdapterCfg["DNSServerSearchOrder"])[1];
                        }catch(Exception sEx)
                        {
                            return "";
                        }
                    }
                    else
                    {
                        return "";
                    }
                }
            }
            private set { }
        }
        public string strMACAddr
        {
            get
            {
                string retval;
                try
                {
                    retval = (string)this.moAdapter["MACAddress"];
                }
                catch (Exception ex)
                {
                    return "";
                }
                return retval;
            }
            private set
            {

            }
        }
        public string strNetConnectionID
        {
            get
            {
                string retval;
                try
                {
                    retval = (string)this.moAdapter["NetConnectionID"];
                }
                catch (Exception ex)
                {
                    return "";
                }
                return retval;
            }
            private set
            {

            }
        }
        public string strNetConnectionStatus
        {
            get
            {
                UInt16 statuscode;
                try
                {
                    statuscode = (UInt16)this.moAdapter["NetConnectionStatus"];
                }
                catch (Exception ex)
                {
                    return "ManagementObject Error";
                }
                switch(statuscode)
                {
                    case 0:
                        return "Disconnected";
                    case 1:
                        return "Connecting";
                    case 2:
                        return "Connected";
                    case 3:
                        return "Disconnecting";
                    case 4:
                        return "Hardware not present";
                    case 5:
                        return "Hardware disabled";
                    case 6:
                        return "Hardware malfunction";
                    case 7:
                        return "Media disconnected";
                    case 8:
                        return "Authenticating";
                    case 9:
                        return "Authentication succeeded";
                    case 10:
                        return "Authentication failed";
                    case 11:
                        return "Invalid address";
                    case 12:
                        return "Credentials required";
                    default:
                        return "ManagementObject Error";
                }
            }
            private set
            {

            }
        }

        public uint uiInterfaceIndex { get; private set; }

        public bool isHwOn
        {
            get
            {
                UInt16 statuscode;
                try
                {
                    statuscode = (UInt16)this.moAdapter["NetConnectionStatus"];
                }
                catch (Exception ex)
                {
                    return false;
                }
                switch (statuscode)
                {
                    case 1:
                    case 2:
                    case 3:
                    case 7:
                    case 8:
                    case 9:
                    case 10:
                    case 11:
                    case 12:
                        return true;
                    default:
                        return false;
                }
            }
            private set
            {

            }
        }
        public bool isEnabled
        {
            get
            {
                bool retval;
                try{
                    retval = (bool)this.moAdapter["NetEnabled"];
                }catch(Exception ex)
                {
                    return false;
                }
                return retval;
            }
            private set { }
        }
        public bool isDHCPEnabled
        {
            get
            {
                try
                {
                    return (bool)moAdapterCfg["DHCPEnabled"];
                }
                catch (Exception ex)
                {
                    if (refreshNetworkAdapterConfigurationObject())
                    {
                        return (bool)moAdapterCfg["DHCPEnabled"];
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            private set { }
        }
        public bool isPhysicalAdapter
        {
            get
            {
                bool retval;
                try
                {
                    retval = (bool)this.moAdapter["PhysicalAdapter"];
                }
                catch (Exception ex)
                {
                    return false;
                }
                return retval;
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
            this.uiInterfaceIndex = (uint)moAdapter["InterfaceIndex"];
        }

        /// <summary>
        /// Gets all the TCP/IP network adapters on the system. 
        /// </summary>
        /// <returns>An array of NetworkAdapter objects for each IPEnabled NetworkAdapter/Configuration pair on the system</returns>
        public static NetworkAdapter[] getNetworkAdapters()
        {
            List<NetworkAdapter> listAdapters = new List<NetworkAdapter>();

            //Get the network adapters for that are tcp/ip
            ManagementObject[] moArrAdapters = getNetworkAdapterMOs();

            //Win32_NetworkAdapterConfiguration was chosen despite being depreciated for backwards compatibility for Windows 7. 
            //At some point in the future, we should detect whether the application is running on Windows 8, 10, etc.
            ManagementClass mcWin32_NetworkAdapterConfiguration = new ManagementClass("Win32_NetworkAdapterConfiguration");

            //Retrieve the objects that are of the classes specified above
            ManagementObjectCollection mocAdapterCfgCollection = mcWin32_NetworkAdapterConfiguration.GetInstances();

            //Collate the NetworkAdapter objects and the NetworkAdapterConfiguration objects by InterfaceIndex
            foreach (ManagementObject moAdapter in moArrAdapters)
            {
                //Find the correlated NetworkAdapter by use of InterfaceIndex property.
                bool found = false;
                foreach (ManagementObject moAdapterCfg in mocAdapterCfgCollection)
                {
                    if ((uint)moAdapter["InterfaceIndex"] == (uint)moAdapterCfg["InterfaceIndex"])
                    {
                        //Yay~! We found it. Add it to the list and break;.
                        listAdapters.Add(new NetworkAdapter(moAdapter, moAdapterCfg));
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    //Generate an adapter with a null configuration, i.e., it's disabled
                    listAdapters.Add(new NetworkAdapter(moAdapter, null));
                }


            }

            //Convert our list to an array and return it.
            return listAdapters.ToArray();
        }

        /// <summary>
        /// Gets all the Win32_NetworkAdapter objects for TCP/IP network adapters on the system
        /// </summary>
        /// <returns>An array of the ManagementObjects found</returns>
        private static ManagementObject[] getNetworkAdapterMOs()
        {
            List<ManagementObject> listNetworkAdapterMOs = new List<ManagementObject>();

            //Win32_NetworkAdapter was chosen despite being depreciated for backwards compatibility for Windows 7. 
            //At some point in the future, we should detect whether the application is running on Windows 8, 10, etc.
            ManagementClass mcWin32_NetworkAdapter = new ManagementClass("Win32_NetworkAdapter");

            //Retrieve the objects of the Win32_NetworkAdapter class
            ManagementObjectCollection mocAdapterCollection = mcWin32_NetworkAdapter.GetInstances();

            //Get the adapters which are tcp/ip and add them to our list
            foreach (ManagementObject moAdapter in mocAdapterCollection)
            {
                bool enabled;
                    try{
                        enabled = (bool)moAdapter["NetEnabled"];
                    }catch(Exception ex)
                    {
                        enabled = false;
                    }
                //Check that the NetworkAdapterConfiguration is tcp/ip and not Firewire/etc. 
                if (
                    enabled ||
                    ((string)moAdapter["Name"]).Contains("Ethernet") ||
                    ((string)moAdapter["Name"]).Contains("Wireless")
                    )
                {
                    //if so add it
                    listNetworkAdapterMOs.Add(moAdapter);
                }
            }

            return listNetworkAdapterMOs.ToArray();
        }

        /// <summary>
        /// Checks to see whether or not the adapter is enabled or not. 
        /// If the adapter is disable, it sets the adapter config to null and returns false.
        /// If the adapter is enable, it updates the object's adapter config ManagementObject.
        /// </summary>
        /// <returns>true if moAdapterCfg is a valid Win32_NetworkAdapterConfiguration ManagementObject</returns>
        private bool refreshNetworkAdapterConfigurationObject()
        {
            //Check whether the adapter is enabled or not
            //Disabled adapters do not have adapter configuration objects
            if (!this.isEnabled)
            {
                moAdapterCfg = null;
                return false;
            }

            //Win32_NetworkAdapterConfiguration was chosen despite being depreciated for backwards compatibility for Windows 7. 
            //At some point in the future, we should detect whether the application is running on Windows 8, 10, etc.
            ManagementClass mcWin32_NetworkAdapterConfiguration = new ManagementClass("Win32_NetworkAdapterConfiguration");

            //Retrieve the objects that are of the classes specified above
            ManagementObjectCollection mocAdapterCfgCollection = mcWin32_NetworkAdapterConfiguration.GetInstances();

            foreach (ManagementObject moNewAdapterCfg in mocAdapterCfgCollection)
            {
                if ((uint)moAdapter["InterfaceIndex"] == (uint)moNewAdapterCfg["InterfaceIndex"])
                {
                    //Yay~! We found it!
                    moAdapterCfg = moNewAdapterCfg;
                    return true;
                }
            }

            //It's enabled but we couldn't find a configuration. 
            return false;
        }

        /// <summary>
        /// Refreshes the NetworkAdapter's Win32_NetworkAdapter/Configuration ManagementObjects
        /// </summary>
        /// <returns>If a new Win32_NetworkAdapter/Configuration ManagementObjects were found</returns>
        public bool refreshManagementObjects()
        {
            ManagementObject[] moArrNetworkAdapters = getNetworkAdapterMOs();

            foreach(ManagementObject moNetworkAdapter in moArrNetworkAdapters)
            {
                if((uint)moNetworkAdapter["InterfaceIndex"] == this.uiInterfaceIndex)
                {
                    this.moAdapter = moNetworkAdapter;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Sets a static IP
        /// </summary>
        /// <param name="strIp">String containing the IP address to set. Can be IPV4 or IPV6. e.g. "13.37.69.69"</param>
        /// <param name="strSubnetMask">String containing the subnet mask for the IP. Not cidr stuff. e.g. "255.255.255.0</param>
        public void setStaticIP(string strIp, string strSubnetMask)
        {
            if (!isEnabled)
            {
                return;
            }

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
            if (!isEnabled)
            {
                return;
            }

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
            if (!isEnabled)
            {
                return;
            }

            //Enable DHCP has no paramters so we can just call it
            moAdapterCfg.InvokeMethod("EnableDHCP", new object[] { });
        }

        /// <summary>
        /// Release the DHCP Lease ala ipconfig /release
        /// </summary>
        public void releaseDHCP()
        {
            if (!isEnabled)
            {
                return;
            }

            //Release DHCP has no paramters so we can just call it
            moAdapterCfg.InvokeMethod("ReleaseDHCPLease", new object[] { });
        }

        /// <summary>
        /// Renew the DHCP Lease ala ipconfig /renew
        /// </summary>
        public void renewDHCP()
        {
            if (!isEnabled)
            {
                return;
            }

            //Renew DHCP has no paramters so we can just call it
            moAdapterCfg.InvokeMethod("RenewDHCPLease", new object[] { });
        }

        /// <summary>
        /// Tells the network adapter to get the IP address of the DNS server automatically
        /// </summary>
        public void setDNSServerDynamic()
        {
            if (!isEnabled)
            {
                return;
            }

            //Setting DNS server search order with no arguments is dynamically get DNS server address
            moAdapterCfg.InvokeMethod("SetDNSServerSearchOrder", new object[] { });
        }

        /// <summary>
        /// Sets the DNS servers for which the network adapter will query 
        /// </summary>
        /// <param name="strarrIps">Array of strings containing IP addresses of desired DNS servers</param>
        public void setDNSServers(string[] strarrIps)
        {
            if (!isEnabled)
            {
                return;
            }

            //Make a ManagementBaseObject for parameters for the call to SetDNSServerSearchOrder
            ManagementBaseObject mboNewGateway = moAdapterCfg.GetMethodParameters("SetDNSServerSearchOrder");
            mboNewGateway["DNSServerSearchOrder"] = strarrIps;
        }

        /// <summary>
        /// Enables the network adapter
        /// </summary>
        public void enableAdapter()
        {
            //Enable has no paramters so we can just call it
            moAdapter.InvokeMethod("Enable", moAdapter.GetMethodParameters("Enable"), null);
        }

        /// <summary>
        /// Disables the network adapter
        /// </summary>
        public void disableAdapter()
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
