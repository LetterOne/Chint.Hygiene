using System;
using Common.Library.Model;
using System.Runtime.Caching;
namespace Common.Library.Cache
{
    public class SystemCache : CacheBase
    {
        public override bool ContainsKey(string key)
        {
            return MemoryCache.Default.Contains(key);
        }

        public override object GetCache(string key)
        {
            return MemoryCache.Default.Get(key);
        }

        public override T GetCache<T>(string key)
        {
            return (T)GetCache(key);
        }

        public override void RemoveCache(string key)
        {
            MemoryCache.Default.Remove(key);
        }

        public override void SetCache(string key, object value)
        {
            MemoryCache.Default.Set(key, value, new CacheItemPolicy());
        }

        public override void SetCache(string key, object value, TimeSpan timeout)
        {
            SetCache(key, value, timeout, ExpireType.Absolute);
        }

        public override void SetCache(string key, object value, TimeSpan timeout, ExpireType expireType)
        {
            switch (expireType)
            {
                case ExpireType.Absolute:
                    MemoryCache.Default.Set(key, value, new DateTimeOffset(DateTime.Now + timeout));
                    break;
                case ExpireType.Relative:
                    CacheItemPolicy a = new CacheItemPolicy();
                    a.SlidingExpiration = timeout;
                    MemoryCache.Default.Set(key, value, a);
                    break;
                default:
                    throw new Exception("请指定缓存过期类型！");
            }
        }

        public override void SetKeyExpire(string key, TimeSpan expire)
        {
            var value = GetCache(key);
            SetCache(key, value, expire);
        }
    }
}
