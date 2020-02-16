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
    /// 端口基础操作类
    /// </summary>
    public class PortHelper
    {
        /// <summary>
        /// 判断当前端口是否被占用
        /// </summary>
        /// <returns>true表示占用，false表示没有占用</returns>
        public static bool IsPortUse(int port, PortType type)
        {
            bool flag = false;
            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
            IPEndPoint[] ipendpoints = null;
            switch (type)
            {
                case PortType.TCP:
                    ipendpoints = properties.GetActiveTcpListeners();
                    break;
                case PortType.UDP:
                    ipendpoints = properties.GetActiveUdpListeners();
                    break;
                default:
                    break;
            }
            foreach (var ipendpoint in ipendpoints)
            {
                if (ipendpoint.Port == port)
                {
                    flag = true;
                }
            }
            return flag;
        }
    }
}
