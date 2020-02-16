using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Common.Library.Helper
{
    /// <summary>
    /// 写入日志，采用第三方日志框架
    /// </summary>
    public class LogHelper
    {
        private static Logger mylogger = LogManager.GetCurrentClassLogger();


        public static void Write(string log)
        {
            mylogger.Log(LogLevel.Info, log);
        }

    }
}
