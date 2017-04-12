using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace innovation4austria.web.Models
{
    public class BookingModel
    {
        public int ID { get; set; }

        public int Room_id { get; set; }

        public int Portaluser_id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int DateDif { get; set; }

        public double RoomPrice { get; set; }

        public string RoomDescription { get; set; }

        public double EndPrice { get; set; }

        public RoomModel Rooms { get; set; }

        public List<CompanyModel> Companies { get; set; }
    }
}