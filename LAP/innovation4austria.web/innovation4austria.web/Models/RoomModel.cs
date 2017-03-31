using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace innovation4austria.web.Models
{
    public class RoomModel
    {
        public int ID { get; set; }

        public int Facility_ID { get; set; }

        public string Facility_Name { get; set; }

        public string Description { get; set; }

        public bool Booked { get; set; }
        public string Gebucht { get; set; }


        public decimal Price { get; set; }
    }
}