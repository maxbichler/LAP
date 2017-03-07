using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace innovation4austria.web.Models
{
    public class CompanyModel
    {
        [Required]
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        public string CompanyName { get; set; }
        [StringLength(10)]
        public string Zip { get; set; }
        [StringLength(50)]
        public string City { get; set; }
        [StringLength(50)]
        public string Street { get; set; }
        [StringLength(10)]
        public string Number { get; set; }
    }
}