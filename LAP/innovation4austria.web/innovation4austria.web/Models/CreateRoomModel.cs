using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace innovation4austria.web.Models
{
    public class CreateRoomModel
    {
        public int ID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Pflichtfeld")]
        public int Facility_ID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Pflichtfeld")]
        [StringLength(50)]
        public string Description { get; set; }

        public bool Booked { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Pflichtfeld")]
        public decimal Price { get; set; }
    }
}