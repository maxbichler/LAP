using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace innovation4austria.web.Models
{
    public class FilterFurnishingModel
    {
        public int Id { get; set; }

        [Display(Name = "Ausstattung")]
        public string Description { get; set; }
    }
}