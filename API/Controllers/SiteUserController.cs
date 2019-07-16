using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class SiteUserController : ApiController
    {
        private SHS2Entities db = new SHS2Entities();
        // GET: api/SiteUser
        public IEnumerable<string> Get()
        {


            return new string[] { "value1", "value2" };
        }

        // GET: api/SiteUser/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/SiteUser
        public IHttpActionResult Post([FromBody]User siteUser)
        {
            var luser = new User();
            var luser1 = from a in db.Users
                         where a.Name == siteUser.Name && a.Active == true && a.Pass == siteUser.Pass 
                         select a;
            var myuser = luser1.ToList();
            luser.Role1 = myuser.ElementAt(0).Role1;
            return Ok(luser);
        }

        // PUT: api/SiteUser/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SiteUser/5
        public void Delete(int id)
        {
        }
    }
}
