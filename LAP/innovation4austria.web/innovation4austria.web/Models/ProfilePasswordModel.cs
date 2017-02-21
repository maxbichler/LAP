using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace innovation4austria.web.Models
{
    public class ProfilePasswordModel
    {
        [Required(ErrorMessage = "Pflichtfeld", AllowEmptyStrings = false)]
        [StringLength(24, ErrorMessage = "8-24 Zeichen", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Pflichtfeld", AllowEmptyStrings = false)]
        [StringLength(24, ErrorMessage = "8-24 Zeichen", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Pflichtfeld", AllowEmptyStrings = false)]
        [StringLength(24, ErrorMessage = "8-24 Zeichen", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string NewPassword2 { get; set; }
    }
}