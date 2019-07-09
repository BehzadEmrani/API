using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class AddHardwareController : ApiController
    {
        private SHS2Entities db = new SHS2Entities();



        // GET: api/SiteUser
        public IEnumerable<hardware_information> Get()
        {

            var luser1 = from a in db.Hardware_Information
                         
                         select a;
            var myuser = luser1.ToList();

            return myuser;
        }


        // GET: api/SiteUser/5
        public IEnumerable<server> Get(int id)
        {

            var luser1 = from a in db.server
                         where a.hardware_information_id== id
                         select a;
            var myuser = luser1.ToList();

            return   myuser;
        }

        // POST: api/SiteUser

        [HttpPost]
        public IHttpActionResult Post([FromBody]hardware_information test)
        {
            hardware_information a = new hardware_information();
            a.number = Convert.ToInt32(test.number);
            a.model = test.model;
            a.purchasedate = test.purchasedate;
            a.purchaseorder = test.purchaseorder;
            a.warrantyexpirationdate = test.warrantyexpirationdate;
            a.techsuportinfo = test.techsuportinfo;
            a.os = test.os;
            a.ram = test.ram;
            a.cpu = test.cpu;
            a.cpuspeed = test.cpuspeed;
            a.harddrive = test.harddrive;
            a.videocard = test.videocard;
            a.soundgraphic = test.soundgraphic;
            a.monitor = test.monitor;
            db.Hardware_Information.Add(a);
            db.SaveChangesAsync();
            return Ok(test);

            
        }


    }
}
