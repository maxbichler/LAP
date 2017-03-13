using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace innovation4austria.web.Models
{
    public class UserModel
    {
        public int ID { get; set; }
        public int Role_ID { get; set; }

        [Required(ErrorMessage = "Pflichtfeld", AllowEmptyStrings = false)]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Der Eingegebene Wert ist keine Email Adresse")]
        [StringLength(50)]
        public int Email { get; set; }

        [Required(ErrorMessage = "Pflichtfeld", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        [Display(Name = "Passwort")]
        public byte[] Password { get; set; }

        [Required(ErrorMessage = "Pflichtfeld", AllowEmptyStrings = false)]
        [StringLength(50)]
        [Display(Name = "Vorname")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Pflichtfeld", AllowEmptyStrings = false)]
        [StringLength(50)]
        [Display(Name = "Nachname")]
        public string Lastname { get; set; }
    }
}