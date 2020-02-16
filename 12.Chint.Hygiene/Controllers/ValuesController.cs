using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Common.Library.Cache;

namespace _12.Chint.Hygiene.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            if (CacheHelper.Cache.ContainsKey(id.ToString()))
            {
                return CacheHelper.Cache.GetCache(id.ToString()).ToString(); ;
            }
            else
            {
                CacheHelper.Cache.SetCache(id.ToString(), "你好世界：" + id.ToString());
                return CacheHelper.Cache.GetCache(id.ToString()).ToString(); ;
            }
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
