using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace innovation4austria.web.Models
{
    public class FilterModel
    {
        [Display(Name = "Start Datum")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Datum")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Gebäude")]
        public string Facility { get; set; }

        [Display(Name = "Ausstattung")]
        public string Furnishing { get; set; }

        [Display(Name = "Preis")]
        public decimal Price { get; set; }
    }
}