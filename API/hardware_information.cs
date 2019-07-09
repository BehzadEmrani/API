using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace API
{
    public class hardware_information
    {
        [Key]
        public int id { get; set; }
        public int number { get; set; }
        public string model { get; set; }
        public string purchasedate { get; set; }
        public string purchaseorder { get; set; }
        public string warrantyexpirationdate { get; set; }
        public string techsuportinfo { get; set; }
        public string os { get; set; }
        public string ram { get; set; }
        public string cpu { get; set; }
        public int cpuspeed { get; set; }
        public string harddrive { get; set; }
        public string videocard { get; set; }
        public string soundgraphic { get; set; }
        public string monitor { get; set; }
        public string biosversion { get; set; }

        public virtual ICollection<server> Servers { get; set; }

        public hardware_information()
        {
            Servers = new List<server>();
        }
    }
}