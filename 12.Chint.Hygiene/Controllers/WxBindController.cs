using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using _12.Chint.Hygiene.Data;
using _12.Chint.Hygiene.Entity;

namespace _12.Chint.Hygiene.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class WxBindController : ApiController
    {
        private HygieneContext db = new HygieneContext();

        // GET: api/WxBind
        public IQueryable<tb_User> GetUsers()
        {
            return db.Users;
        }

        // GET: api/WxBind/5
        [HttpGet]
        [ResponseType(typeof(tb_User))]
        public IHttpActionResult IsBindWx(string id)
        {
            var tb_User = db.Users.Where(wx => wx.openid == id);//Find(id);
            if (tb_User.Count()==0)
            {
                return Ok("请绑定微信！");
            }
            return Ok(tb_User.ToList());
        }
        // GET: api/WxBind/BindWx
        [HttpPost]
        [ResponseType(typeof(tb_User))]
        public IHttpActionResult BindWx(tb_User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return Ok("绑定成功！");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tb_UserExists(string id)
        {
            return db.Users.Count(e => e.openid == id) > 0;
        }
    }
}