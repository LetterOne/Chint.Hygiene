using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using _12.Chint.Hygiene.Entity;

namespace _12.Chint.Hygiene.Data.Map
{
    public class UserMap: EntityTypeConfiguration<tb_User>
    {
        public UserMap()
        {
            //主键
            this.HasKey(t => t.openid);
            //长度
            this.Property(t => t.openid).IsRequired().HasMaxLength(32);
            //表
            this.ToTable("tb_User");

        }
    }
}
