using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Library.Helper;
using Common.Library.Model;

namespace Common.Library
{
    /// <summary>
    /// 全局控制
    /// </summary>
    public class GlobalSwitch
    {
        #region 当前启动的程序
        public static string RunProjectNowStr = "";
        #endregion
        #region 当前系统所使用的缓存
        /// <summary>
        /// 默认缓存
        /// </summary>
        public static CacheType CacheType { get; } = CacheType.SystemCache;
        #endregion
        #region Rides缓存设置
        /// <summary>
        /// Rides缓存链接字段，若为null则只能使用系统默认缓存，若有且可用则系统可以使用双缓存系统
        /// </summary>
        public static string RedisConfig { get; } = "127.0.0.1:6379,password=hex19950319" /*"localhost:6379,password=123456"*/;
        #endregion

        #region 默认数据库连接、最大尝试次数、最大超时时间秒
        /// <summary>
        /// 系统默认数据库连接
        /// </summary>
        public static SqlConnection defaultconn = new DbHelper().connPortal;
        /// <summary>
        /// 最大尝试连接次数
        /// </summary>
        public static int maxRetry = 3;
        /// <summary>
        /// 尝试连接默认最长时间
        /// </summary>
        public static int maxOuttime = 5000;
        #endregion

        #region 可运行的项目

        /// <summary>
        /// 可运行项目列表
        /// </summary>
        public static List<ProjectType> RunProject = new List<ProjectType>() { ProjectType.Train, ProjectType.Test, ProjectType.Leave, ProjectType.WG };
        #endregion

    }
}
