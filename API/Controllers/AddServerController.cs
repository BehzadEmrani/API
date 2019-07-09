using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class AddServerController : ApiController
    {
        private SHS2Entities db = new SHS2Entities();

        public IEnumerable<hardware_information> Get()
        {

            var luser1 = from a in db.Hardware_Information

                         select a;
            var myuser = luser1.ToList();

            return myuser;
        }




        // GET: api/SiteUser/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/SiteUser






        [HttpPost]
        public IHttpActionResult Post([FromBody]server p)
        {
            server a = new server();
            a.hardware_information_id =p.hardware_information_id;
            a.servername = p.servername;
            a.location = p.location;
            a.serverrole = p.serverrole;
            a.model = p.model;
            a.serialnamber = p.serialnamber;
            a.assesttagnumber = p.assesttagnumber;
            a.datepurchased = p.datepurchased;
            a.purchaseorder = p.purchaseorder;
            a.techsuport = p.techsuport;
           
            db.server.Add(a);
            db.SaveChangesAsync();
            return Ok(p);
        }


    }

}

