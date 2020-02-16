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
    public class TestController : ApiController
    {
        private HygieneContext db = new HygieneContext();

        // GET: api/Test
        public IQueryable<tb_User> GetUsers()
        {
            return db.Users;
        }

        // GET: api/Test/5
        [ResponseType(typeof(tb_User))]
        public IHttpActionResult Gettb_User(string id)
        {
            tb_User tb_User = db.Users.Find(id);
            if (tb_User == null)
            {
                return NotFound();
            }

            return Ok(tb_User);
        }

        // PUT: api/Test/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puttb_User(string id, tb_User tb_User)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tb_User.openid)
            {
                return BadRequest();
            }

            db.Entry(tb_User).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tb_UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Test
        [ResponseType(typeof(tb_User))]
        public IHttpActionResult Posttb_User(tb_User tb_User)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(tb_User);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tb_User.openid }, tb_User);
        }

        // DELETE: api/Test/5
        [ResponseType(typeof(tb_User))]
        public IHttpActionResult Deletetb_User(string id)
        {
            tb_User tb_User = db.Users.Find(id);
            if (tb_User == null)
            {
                return NotFound();
            }

            db.Users.Remove(tb_User);
            db.SaveChanges();

            return Ok(tb_User);
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