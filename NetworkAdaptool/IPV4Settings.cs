using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace NetworkAdaptool
{
    [Serializable]
    public class IPV4Settings : ISerializable
    {
        public string strIpAddr;
        public string strSubnetMask;
        public string strDNS1;
        public string strDNS2;
        public string strDefaultGateway;

        public IPV4Settings(string strIpAddr, string strSubnetMask, string strDNS1, string strDNS2, string strDefaultGateway)
        {
            this.strIpAddr = strIpAddr;
            this.strSubnetMask = strSubnetMask;
            this.strDNS1 = strDNS1;
            this.strDNS2 = strDNS2;
            this.strDefaultGateway = strDefaultGateway;
        }

        public IPV4Settings(SerializationInfo info, StreamingContext context)
        {
            //Check if right version
            if ((int)info.GetValue("VERSION", typeof(int)) != 1)
            {
                throw new SerializationException("Incorrect Version");
            }

            //Deserialize
            strIpAddr = (string)info.GetValue("strIpAddr", typeof(string));
            strSubnetMask = (string)info.GetValue("strSubnetMask", typeof(string));
            strDNS1 = (string)info.GetValue("strDNS1", typeof(string));
            strDNS2 = (string)info.GetValue("strDNS2", typeof(string));
            strDefaultGateway = (string)info.GetValue("strDefaultGateway", typeof(string));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            //Serialize ALL the things
            info.AddValue("VERSION", 1);
            info.AddValue("strIpAddr", strIpAddr, typeof(string));
            info.AddValue("strSubnetMask", strSubnetMask, typeof(string));
            info.AddValue("strDNS1", strDNS1, typeof(string));
            info.AddValue("strDNS2", strDNS2, typeof(string));
            info.AddValue("strDefaultGateway", strDefaultGateway, typeof(string));
        }
    }
}
