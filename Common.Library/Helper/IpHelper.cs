using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Common.Library.Model;
namespace Common.Library.Helper
{
    /// <summary>
    /// IP基础方法
    /// </summary>
    public class IpHelper
    {
        /// <summary>
        /// 获取当前主机IP
        /// </summary>
        /// <returns>string类型的IP</returns>
        public static string GetCurrentHostIp()
        {
            string AddressIP = "";
            foreach (IPAddress _IPAddress in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (_IPAddress.AddressFamily.ToString() == "InterNetwork")
                {
                    AddressIP = _IPAddress.ToString();
                }
            }
            return AddressIP;
        }

    }
}
