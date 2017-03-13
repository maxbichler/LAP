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

        [Required(ErrorMessage = "Pflichtfeld", AllowEmptyStrings = false)]
        [Display(Name = "Email")]
        [StringLength(50)]
        [EmailAddress(ErrorMessage = "Der Eingegebene Wert ist keine Email Adresse")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Pflichtfeld", AllowEmptyStrings = false)]
        [StringLength(50)]
        [Display(Name = "Vorname")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Pflichtfeld", AllowEmptyStrings = false)]
        [StringLength(50)]
        [Display(Name = "Nachname")]
        public string Lastname { get; set; }

        public bool Active { get; set; }
    }
}