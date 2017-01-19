using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace datenManipulation.web.Models
{
    public class ArtikelAnlegenModel
    {
        [Required(ErrorMessage = "Pflichtfeld", AllowEmptyStrings = false)]
        [StringLength(50,ErrorMessage = "max. 50 Zeichen erlaubt")]
        public string Bezeichnung { get; set; }

        [Required]
        public double Preis { get; set; }

        [Required]
        public int ID_Kategorie { get; set; }

        public List<KategorieAnzeigeModel> AlleKategorien { get; set; }
    }


    public class KategorieAnzeigeModel
    {
        public int ID { get; set; }
        public string Bezeichnung { get; set; }
    }

}