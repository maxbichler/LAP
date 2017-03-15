using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace innovation4austria.web.Models
{
    public class CreateRoomModel
    {
        public int ID { get; set; }

        public int Facility_ID { get; set; }

        public string Description { get; set; }
    }
}