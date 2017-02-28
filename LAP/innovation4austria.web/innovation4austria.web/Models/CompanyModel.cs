using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace innovation4austria.web.Models
{
    public class CompanyModel
    {
        public int ID { get; set; }
        public string CompanyName { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
    }
}