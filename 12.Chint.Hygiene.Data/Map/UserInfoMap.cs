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
    public class UserInfoMap : EntityTypeConfiguration<tb_UserTemperatureInfo>
    {
        public UserInfoMap()
        {
            //主键
            this.HasKey(t => t.Id);
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            //长度
            this.Property(t => t.openid).IsRequired().HasMaxLength(32);
            //表
            this.ToTable("tb_UserTemperatureInfo");
            this.HasRequired(t => t.User)
    .WithMany(t=>t.infos)
    .HasForeignKey(t => t.openid)
    .WillCascadeOnDelete(false);
        }
    }
}
