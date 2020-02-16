using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Chint.Hygiene.Entity
{
    public class tb_UserTemperatureInfo
    {
        public int Id { get; set; }
        /// <summary>
        /// 微信Openid
        /// </summary>
        public string openid { get; set; }
        /// <summary>
        /// 统计时间
        /// </summary>
        public DateTime CountDate { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 温度
        /// </summary>
        public decimal Temperature { get; set; } 
        /// <summary>
        /// 备注：一般保存身体健康状态
        /// </summary>
        public string Remark { get; set; }
        
        /// <summary>
        /// 导航属性
        /// </summary>
        public virtual tb_User User { get; set; }
    }
}
