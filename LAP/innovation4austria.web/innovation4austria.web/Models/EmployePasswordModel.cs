using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace innovation4austria.web.Models
{
    public class EmployePasswordModel
    {
        public int ID { get; set; }

        [Display(Name = "Altes Passwort")]
        [StringLength(20)]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Display(Name = "Neues Passwort")]
        [StringLength(20)]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Display(Name = "Password wiederholen")]
        [StringLength(20)]
        [DataType(DataType.Password)]
        public string NewPassword2 { get; set; }
    }
}