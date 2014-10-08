using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

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
        public string strName;
        public bool isDynamicIP;
        public bool isDynamicDNS;

        /// <summary>
        /// Creates an IPV4Settings from a bunch of settings for IPV4... 
        /// </summary>
        /// <param name="strIpAddr">IPV4 Address in format "x.x.x.x"</param>
        /// <param name="strSubnetMask">IPV4 Subnet Mask in format "x.x.x.x". NOT CIDR.</param>
        /// <param name="strDNS1">The preferred DNS server in format "x.x.x.x"</param>
        /// <param name="strDNS2">The alternate DNS server in format "x.x.x.x"</param>
        /// <param name="strDefaultGateway">The default gateway in format "x.x.x.x"</param>
        /// <param name="strName">The name for the profile.</param>
        public IPV4Settings(
            string strIpAddr, 
            string strSubnetMask, 
            string strDNS1, 
            string strDNS2, 
            string strDefaultGateway, 
            string strName, 
            bool isDynamicIP, 
            bool isDynamicDNS)
        {
            this.strIpAddr = strIpAddr;
            this.strSubnetMask = strSubnetMask;
            this.strDNS1 = strDNS1;
            this.strDNS2 = strDNS2;
            this.strDefaultGateway = strDefaultGateway;
            this.strName = strName;
            this.isDynamicDNS = isDynamicDNS;
            this.isDynamicIP = isDynamicIP;
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public IPV4Settings(SerializationInfo info, StreamingContext context)
        {
            //Check if right version
            if ((int)info.GetValue("VERSION", typeof(int)) != 1)
            {
                throw new SerializationException("Incorrect Version");
            }

            //Deserialize
            strName = (string)info.GetValue("strName", typeof(string));
            strIpAddr = (string)info.GetValue("strIpAddr", typeof(string));
            strSubnetMask = (string)info.GetValue("strSubnetMask", typeof(string));
            strDNS1 = (string)info.GetValue("strDNS1", typeof(string));
            strDNS2 = (string)info.GetValue("strDNS2", typeof(string));
            strDefaultGateway = (string)info.GetValue("strDefaultGateway", typeof(string));
            isDynamicDNS = info.GetBoolean("isDynamicDNS");
            isDynamicIP = info.GetBoolean("isDynamicIP");
        }

        /// <summary>
        /// Serialization method
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            //Serialize ALL the things
            info.AddValue("VERSION", 1);
            info.AddValue("strIpAddr", strIpAddr, typeof(string));
            info.AddValue("strSubnetMask", strSubnetMask, typeof(string));
            info.AddValue("strDNS1", strDNS1, typeof(string));
            info.AddValue("strDNS2", strDNS2, typeof(string));
            info.AddValue("strDefaultGateway", strDefaultGateway, typeof(string));
            info.AddValue("isDynamicIP", isDynamicIP, typeof(bool));
            info.AddValue("isDynamicDNS", isDynamicDNS, typeof(bool));
            info.AddValue("strName", strName, typeof(string));
        }

        /// <summary>
        /// Serializes the NetworkAdapter into the stream
        /// </summary>
        /// <param name="river">Stream to serialize into</param>
        public void write(Stream river)
        {
            //Make a BinaryFormatter to serialize
            BinaryFormatter boyfriend = new BinaryFormatter();

            //Serialize into the stream 
            boyfriend.Serialize(river, this);
        }

        /// <summary>
        /// Serializes a Dictionary of NetworkAdapters into the stream
        /// </summary>
        /// <param name="river">Stream to serialize into</param>
        /// <param name="dic">Dictionary of network adapters to serialize</param>
        public static void writeLibrary(Stream river, Dictionary<string, IPV4Settings> dic)
        {
            //Make a BinaryFormatter to serialize
            BinaryFormatter boyfriend = new BinaryFormatter();

            //Serialize into the stream 
            boyfriend.Serialize(river, dic);
        }

        /// <summary>
        /// Deserializes a NetworkAdapter from a stream
        /// </summary>
        /// <param name="river"></param>
        /// <returns></returns>
        public static IPV4Settings read(Stream river)
        {
            BinaryFormatter boyfriend = new BinaryFormatter();

            try
            {
                return (IPV4Settings)(boyfriend.Deserialize(river));
            }catch(Exception ex)
            {
                throw new SerializationException("Stream does not contain IPV4Settings");
            }
        }

        /// <summary>
        /// Deserializes a Dictionary of NetworkAdapters from a stream
        /// </summary>
        /// <param name="river"></param>
        /// <returns></returns>
        public static Dictionary<string, IPV4Settings> readLibrary(Stream river)
        {
            BinaryFormatter boyfriend = new BinaryFormatter();

            try
            {
                return (Dictionary<string, IPV4Settings>)(boyfriend.Deserialize(river));
            }
            catch (Exception ex)
            {
                throw new SerializationException("Stream does not contain Dictionary<string, IPV4Settings>");
            }
        }
    }
}
