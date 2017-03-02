using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace innovation4austria.web.Models
{
    public class ProfileDataModel
    {

        public int ID { get; set; }
        public string Email { get; set; }
        [Display(Name = "Vorname")]
        public string Firstname { get; set; }
        [Display(Name = "Nachname")]
        public string Lastname { get; set; }
        public bool Active { get; set; }
    }
}