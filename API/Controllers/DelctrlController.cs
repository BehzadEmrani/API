using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class DelctrlController : ApiController
    {
        // GET: api/Delctrl
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Delctrl/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Delctrl
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Delctrl/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Delctrl/5
        public void Delete(int id)
        {
        }
    }
}
