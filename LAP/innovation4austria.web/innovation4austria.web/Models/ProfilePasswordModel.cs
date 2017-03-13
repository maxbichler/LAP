using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace innovation4austria.web.Models
{
    public class ProfilePasswordModel
    {
        [Display(Name = "Altes Passwort")]
        [Required(ErrorMessage = "Pflichtfeld", AllowEmptyStrings = false)]
        [StringLength(24, ErrorMessage = "8-24 Zeichen", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Display(Name = "Neues Passwort")]
        [Required(ErrorMessage = "Pflichtfeld", AllowEmptyStrings = false)]
        [StringLength(24, ErrorMessage = "8-24 Zeichen", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Display(Name = "Passwort wiederholen")]
        [Required(ErrorMessage = "Pflichtfeld", AllowEmptyStrings = false)]
        [Compare("NewPassword", ErrorMessage = "Passwörter stimmen nicht überein!")]
        [StringLength(24, ErrorMessage = "8-24 Zeichen", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string NewPassword2 { get; set; }
    }
}