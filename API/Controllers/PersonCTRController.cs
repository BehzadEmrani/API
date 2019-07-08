using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace API.Controllers
{
    public class PersonCTRController : ApiController
    {

        private SHS2Entities db = new SHS2Entities();
        // GET: api/PersonCTR
        public IEnumerable<Person> Get()
        {
            var luser1 = from a in db.Person
                         select a;
            var myuser = luser1.ToList();


            return myuser;
        }

        // GET: api/PersonCTR/5
        public string Get(int id)
        {
            return "value";
        }




        [HttpPost]
        // POST: api/SiteUser
        public IHttpActionResult Post([FromBody]Person test)
        {

            Person a = new Person();
            a.Name = test.Name;
            a.NationalId = test.NationalId;
            a.Age = test.PersonalCode;
            a.PersonalCode = test.PersonalCode;
            a.PhoneNumber = test.PhoneNumber;
            a.UserName = test.UserName;
            a.Password = test.Password;

            db.Person.Add(a);
            db.SaveChangesAsync();
            return Ok(test);
        }




        // PUT: api/PersonCTR/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/PersonCTR/5
        public void Delete(int id)
        {
        }
    }
}
