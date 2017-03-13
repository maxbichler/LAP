using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace innovation4austria.web.Models
{
    public class CompanyModel
    {
        [Required]
        public int ID { get; set; }

        [Required(ErrorMessage = "Pflichtfeld", AllowEmptyStrings = false)]
        [StringLength(50)]
        [Display(Name = "Firmenname")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Pflichtfeld", AllowEmptyStrings = false)]
        [StringLength(50)]
        [Display(Name = "Postleitzahl")]
        public string Zip { get; set; }

        [Required(ErrorMessage = "Pflichtfeld", AllowEmptyStrings = false)]
        [StringLength(50)]
        [Display(Name = "Stadt")]
        public string City { get; set; }

        [Required(ErrorMessage = "Pflichtfeld", AllowEmptyStrings = false)]
        [StringLength(50)]
        [Display(Name = "Straße")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Pflichtfeld", AllowEmptyStrings = false)]
        [StringLength(50)]
        [Display(Name = "Hausnummer")]
        public string Number { get; set; }
    }
}