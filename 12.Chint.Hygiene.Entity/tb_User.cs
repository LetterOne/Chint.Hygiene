using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Chint.Hygiene.Entity
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class tb_User
    {
        public tb_User()
        {
            infos = new HashSet<tb_UserTemperatureInfo>();
        }
        /// <summary>
        /// 微信ID
        /// </summary>
        public string openid { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 认证时间
        /// </summary>
        public DateTime Authentication { get; set; }
        /// <summary>
        /// 所在部门
        /// </summary>
        public string Department{ get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 所在公司
        /// </summary>
        public string Company { get; set; }
        /// <summary>
        /// 卡号
        /// </summary>
        public string UserId { get; set; }
        public virtual ICollection<tb_UserTemperatureInfo> infos { get; set; }
    }
}
