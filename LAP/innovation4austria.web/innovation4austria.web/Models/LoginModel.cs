using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using innovation4austria.dataAccess;

namespace innovation4austria.web.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Pflichtfeld", AllowEmptyStrings = false)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Pflichtfeld", AllowEmptyStrings = false)]
        [StringLength(24, ErrorMessage = "8-24 Zeichen", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Angemeldet bleiben")]
        public bool RememberMe { get; set; }

    }
}