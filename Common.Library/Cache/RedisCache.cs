using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Library.Extention;
using Common.Library.Model;
using StackExchange.Redis;

namespace Common.Library.Cache
{
    public class RedisCache : CacheBase
    {
        private ConnectionMultiplexer _redisConnection { get; }
        private IDatabase _db { get => _redisConnection.GetDatabase(_databaseIndex); }
        private int _databaseIndex { get; }
        /// <summary>
        /// Redis初始化
        /// </summary>
        /// <param name="config">连接字符ip:port,password=</param>
        /// <param name="databaseIndex">默认为0</param>
        public RedisCache(string config, int databaseIndex = 0)
        {
            _databaseIndex = databaseIndex;
            _redisConnection = ConnectionMultiplexer.Connect(config);
        }
        /// <summary>
        /// 判断键是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public override bool ContainsKey(string key)
        {
            return _db.KeyExists(key);
        }
        /// <summary>
        /// 获取键的值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public override object GetCache(string key)
        {
            object value = null;
            var redisValue = _db.StringGet(key);
            if (!redisValue.HasValue)
                return null;
            ValueInfoEntry valueEntry = redisValue.ToString().ToObject<ValueInfoEntry>();
            if (valueEntry.TypeName == typeof(string).FullName)
                value = valueEntry.Value;
            else
                value = valueEntry.Value.ToObject(Type.GetType(valueEntry.TypeName));

            if (valueEntry.ExpireTime != null && valueEntry.ExpireType == ExpireType.Relative)
                SetKeyExpire(key, valueEntry.ExpireTime.Value);

            return value;
        }
        /// <summary>
        /// 获取键的值并转换对应的对象
        /// </summary>
        /// <typeparam name="T">Key</typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public override T GetCache<T>(string key)
        {
            return (T)GetCache(key);
        }

        public override void RemoveCache(string key)
        {
            _db.KeyDelete(key);
        }

        public override void SetCache(string key, object value)
        {
            _SetCache(key, value, null, null);
        }

        public override void SetCache(string key, object value, TimeSpan timeout)
        {
            _SetCache(key, value, timeout, ExpireType.Absolute);
        }

        public override void SetCache(string key, object value, TimeSpan timeout, ExpireType expireType)
        {
            _SetCache(key, value, timeout, expireType);
        }

        public override void SetKeyExpire(string key, TimeSpan expire)
        {
            _db.KeyExpire(key, expire);
        }
        private void _SetCache(string key, object value, TimeSpan? timeout, ExpireType? expireType)
        {
            string jsonStr = string.Empty;
            if (value is string)
                jsonStr = value as string;
            else
                jsonStr = value.ToJson();

            ValueInfoEntry entry = new ValueInfoEntry
            {
                Value = jsonStr,
                TypeName = value.GetType().FullName,
                ExpireTime = timeout,
                ExpireType = expireType
            };

            string theValue = entry.ToJson();
            if (timeout == null)
                _db.StringSet(key, theValue);
            else
                _db.StringSet(key, theValue, timeout);
        }
    }
}
