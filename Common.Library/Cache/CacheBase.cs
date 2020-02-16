using Common.Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Library.Cache
{
    /// <summary>
    /// 缓存基础方法
    /// </summary>
    public abstract class CacheBase
    {
        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        public abstract void SetCache(string key, object value);
        /// <summary>
        /// 设置缓存
        /// 注：默认过期类型为绝对过期
        /// </summary>
        /// <param name="key">主键</param>
        /// <param name="value">值</param>
        /// <param name="timeout">过期时间间隔</param>
        /// <typeparam name="T">数据类型</typeparam>
        public abstract void SetCache(string key, object value, TimeSpan timeout);
        /// <summary>
        /// 设置缓存
        /// 注：默认过期类型为绝对过期
        /// </summary>
        /// <param name="key">主键</param>
        /// <param name="value">值</param>
        /// <param name="timeout">过期时间间隔</param>
        /// <param name="expireType">过期类型</param>
        /// <typeparam name="T">数据类型</typeparam>
        public abstract void SetCache(string key, object value, TimeSpan timeout, ExpireType expireType);
        /// <summary>
        /// 设置键失效时间
        /// </summary>
        /// <param name="key">键值</param>
        /// <param name="expire">从现在起时间间隔</param>
        public abstract void SetKeyExpire(string key, TimeSpan expire);



        #region 获取缓存

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="key">主键</param>
        public abstract object GetCache(string key);

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="key">主键</param>
        /// <typeparam name="T">数据类型</typeparam>
        public abstract T GetCache<T>(string key) where T : class;

        /// <summary>
        /// 是否存在键值
        /// </summary>
        /// <param name="key">主键</param>
        /// <returns></returns>
        public abstract bool ContainsKey(string key);

        #endregion

        #region 删除缓存

        /// <summary>
        /// 清除缓存
        /// </summary>
        /// <param name="key">主键</param>
        public abstract void RemoveCache(string key);

        #endregion
    }
}
