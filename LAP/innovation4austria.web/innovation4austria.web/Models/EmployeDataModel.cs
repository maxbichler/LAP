using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace innovation4austria.web.Models
{
    public class EmployeDataModel
    {
        public int ID { get; set; }
        public int ID_Company { get; set; }

        [Display(Name = "Email")]
        [StringLength(50)]
        [Editable(false)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Pflichtfeld", AllowEmptyStrings = false)]
        [Display(Name = "Vorname")]
        [StringLength(50)]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Pflichtfeld", AllowEmptyStrings = false)]
        [Display(Name = "Nachname")]
        [StringLength(50)]
        public string Lastname { get; set; }

        public bool Active { get; set; }
    }
}