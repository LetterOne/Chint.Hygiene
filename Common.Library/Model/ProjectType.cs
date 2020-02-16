using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Library.Model
{
    /// <summary>
    /// 项目，每次项目都放在这里
    /// </summary>
    public enum ProjectType
    {
        /// <summary>
        /// 舞钢税票系统，重制版
        /// </summary>
        WG = 0,
        /// <summary>
        /// 研究院年休假控制更新程序
        /// </summary>
        Leave = 1,
        /// <summary>
        /// 12306抢票系统
        /// </summary>
        Train = 2,
        /// <summary>
        /// 测试系统
        /// </summary>
        Test = 999,
    }
}
