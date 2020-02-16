using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Library.Cache
{
    /// <summary>
    /// 缓存类
    /// </summary>
    public class CacheHelper
    {
        static CacheHelper()
        {
            SystemCache = new SystemCache();
            if (!string.IsNullOrWhiteSpace(GlobalSwitch.RedisConfig))
            {

                try
                {
                    RedisCache = new RedisCache(GlobalSwitch.RedisConfig);
                }
                catch (Exception)
                {

                    throw new Exception("RedisCache初始化失败，请联系管理人员！");
                }
            }
            switch (GlobalSwitch.CacheType)
            {
                case Model.CacheType.SystemCache:
                    Cache = SystemCache;
                    break;
                case Model.CacheType.RedisCache:
                    Cache = RedisCache;
                    break;
                default:
                    throw new Exception("暂不支持的缓存类型！");
            }
        }
        /// <summary>
        /// 指定使用系统缓存
        /// </summary>
        public static SystemCache SystemCache { get; }
        /// <summary>
        /// 指定使用Redis缓存
        /// </summary>
        public static RedisCache RedisCache { get; }
        /// <summary>
        /// 使用全局变量设置的默认缓存，一般为SystemCache
        /// </summary>
        public static CacheBase Cache { get; }
    }
}
