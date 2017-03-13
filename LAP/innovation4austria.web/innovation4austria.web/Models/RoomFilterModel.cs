using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace innovation4austria.web.Models
{
    public class RoomFilterModel
    {
        [Required(AllowEmptyStrings =false, ErrorMessage = "Pflichtfeld")]
        [DataType(DataType.Date)]
        [Display(Name = "Startdatum")]
        public string Start { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Pflichtfeld")]
        [DataType(DataType.Date)]
        [Display(Name = "Enddatum")]
        public string End { get; set; }

        public List<FurnishingModel> Facilities { get; set; }
    }
}