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

        [Required(ErrorMessage = "Pflichtfeld", AllowEmptyStrings = false)]
        [Display(Name = "Email")]
        [StringLength(50)]
        [EmailAddress(ErrorMessage = "Der Eingegebene Wert ist keine Email Adresse")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Pflichtfeld", AllowEmptyStrings = false)]
        [Display(Name = "Vorname")]
        [StringLength(50)]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Pflichtfeld", AllowEmptyStrings = false)]
        [Display(Name = "Nachname")]
        [StringLength(50)]
        public string Lastname { get; set; }

        [Display(Name = "Neues Passwort")]
        [Required(ErrorMessage = "Pflichtfeld", AllowEmptyStrings = false)]
        [StringLength(24, ErrorMessage = "8-24 Zeichen", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Display(Name = "Neues Passwort wiederholen")]
        [Required(ErrorMessage = "Pflichtfeld", AllowEmptyStrings = false)]
        [StringLength(24, ErrorMessage = "8-24 Zeichen", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Passwörter stimmen nicht überein!")]
        public string Pass2{ get; set; }
    }
}