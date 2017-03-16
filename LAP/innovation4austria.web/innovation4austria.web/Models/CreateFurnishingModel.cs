using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace innovation4austria.web.Models
{
    public class CreateFurnishingModel
    {
        public int ID { get; set; }

        [Required]
        public int Room_ID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Pflichtfeld")]
        [StringLength(50)]
        public string Description { get; set; }
    }
}