using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Library.Model
{
    /// <summary>
    /// 缓存类型
    /// </summary>
    public enum CacheType
    {
        /// <summary>
        /// 系统缓存
        /// </summary>
        SystemCache,

        /// <summary>
        /// Redis缓存
        /// </summary>
        RedisCache
    }
}
