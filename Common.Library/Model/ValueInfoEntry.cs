using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Library.Model
{
    /// <summary>
    /// 值信息
    /// </summary>
    public struct ValueInfoEntry
    {
        public string Value { get; set; }
        public string TypeName { get; set; }
        public TimeSpan? ExpireTime { get; set; }
        public ExpireType? ExpireType { get; set; }
    }
}
