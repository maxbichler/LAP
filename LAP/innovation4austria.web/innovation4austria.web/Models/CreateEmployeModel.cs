using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace innovation4austria.web.Models
{
    public class CreateEmployeModel
    {
        public int CompanyID { get; set; }

        [Display(Name = "Email")]
        [StringLength(30)]
        public string Email { get; set; }

        [Display(Name = "Vorname")]
        [StringLength(50)]
        public string Firstname { get; set; }

        [Display(Name = "Nachname")]
        [StringLength(50)]
        public string Lastname { get; set; }

        [Display(Name = "Neues Passwort")]
        [StringLength(20)]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Display(Name = "Passwort wiederholen")]
        [StringLength(20)]
        [DataType(DataType.Password)]
        public string Pass2{ get; set; }
    }
}