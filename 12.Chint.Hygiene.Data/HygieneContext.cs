using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using _12.Chint.Hygiene.Entity;
using _12.Chint.Hygiene.Data.Map;

namespace _12.Chint.Hygiene.Data
{
    public class HygieneContext : DbContext
    {
        public DbSet<tb_User> Users { get; set; }
        public DbSet<tb_UserTemperatureInfo> UserInfo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserInfoMap());
            modelBuilder.Configurations.Add(new UserMap());
        }
    }
}
