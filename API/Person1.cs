using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace API
{
    public class Person1
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public string NationalId { get; set; }
        public string Age { get; set; }
        public string PersonalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}