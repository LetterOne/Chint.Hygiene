using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _12.Chint.Hygiene.Entity
{
    public class tb_Org
    {
        public long ID { get; set; }
        public long DeptID { get; set; }
        public string DeptName{ get; set; }
        public string LeaderOpenID { get; set; }
        public string LeaderName { get; set; }
        public string ParentID { get; set; }
    }
}
