using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace innovation4austria.web.Models
{
    public class BookingDetailModel
    {
        public int ID { get; set; }

        public int Booking_id { get; set; }

        public DateTime Date { get; set; }

        public int Bill_id { get; set; }

        public decimal Price { get; set; }

        public bool IsPaid { get; set; }

        public string Room { get; set; }
    }
}