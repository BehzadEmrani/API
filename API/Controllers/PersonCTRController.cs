using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using HttpPostAttribute = System.Web.Mvc.HttpPostAttribute;


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
        public IHttpActionResult Post([FromBody]Person siteUser)
        {






            // /////////////////////
            var luser = new Person();
            var luser1 = from b in db.Person
                         where b.UserName == siteUser.UserName
                         select b;




            if (luser1.ToList().Count == 0)
            {




                Person a = new Person();


                // a.LastName = siteUser.LastName;
                a.NationalId = siteUser.NationalId;


                var person1 = from b in db.Person
                              where b.NationalId == siteUser.NationalId
                              select b;
                if (person1.ToList().Count == 0)
                {

                    if (siteUser.LastName != "" && siteUser.Name != "" && siteUser.Age !=0 && siteUser.PersonalCode !=0 &&
                        siteUser.PhoneNumber !=0 && siteUser.UserName != "" && siteUser.Password != "" && siteUser.NationalId!=0)
                    {
                        a.LastName = siteUser.LastName;
                        a.Name = siteUser.Name;
                        a.Age = siteUser.Age;
                        a.PersonalCode = siteUser.PersonalCode;
                        a.PhoneNumber = siteUser.PhoneNumber;
                        a.UserName = siteUser.UserName;
                        a.Password = siteUser.Password;
                        a.OldNI = siteUser.NationalId;
                        a.Active = true;
                    }




                    db.Person.Add(a);
                    db.SaveChangesAsync();
                    return Ok(siteUser);
                      



                }
                else
                {
                    luser.UserName = "Registered";
                    return Ok(luser);
                }
            }
            else
            {
                luser.UserName = "Repeated";
                return Ok(luser);
            }


        }



        // PUT: api/PersonCTR/5----- Edit Person
        public void Put([FromBody]Person siteUser)
        {



            Person luser = db.Person.Single(course => course.OldNI == siteUser.OldNI);


            //if (siteUser.LastName != "" && siteUser.Name != "" && siteUser.Age != 0 && siteUser.PersonalCode !=0 &&
            //    siteUser.PhoneNumber !=0 && siteUser.UserName != "" && siteUser.Password != "" && siteUser.NationalId !=0)
            //{


                luser.LastName = siteUser.LastName;
                luser.Name = siteUser.Name;
                luser.Age = Convert.ToInt32(siteUser.PersonalCode);
                luser.PersonalCode = siteUser.PersonalCode;
                luser.PhoneNumber = siteUser.PhoneNumber;
                luser.UserName = siteUser.UserName;
                luser.Password = siteUser.Password;
                luser.Active = siteUser.Active;
                luser.NationalId = siteUser.NationalId;
                luser.OldNI = siteUser.NationalId;

                //  }


                db.SaveChangesAsync();
            //}


        }

        // DELETE: api/PersonCTR/5
        public void Delete(int id)
        {
            Person luser = db.Person.Single( course => course.NationalId  == id );
            luser.Active = false;
            db.SaveChangesAsync();
        }
    }
}

