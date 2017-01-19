using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace datenManipulation.web.Models
{
    public class KategorieAnlegenModel
    {
        [Required(ErrorMessage = "Pflichtfeld", AllowEmptyStrings = false)]
        [StringLength(50,ErrorMessage = "max. 50 Zeichen erlaubt")]
        public string Bezeichnung { get; set; }
    }
}