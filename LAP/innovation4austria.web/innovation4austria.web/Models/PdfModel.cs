using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace innovation4austria.web.Models
{
    public class PdfModel
    {
        public int Id { get; set; }

        public DateTime Billdate { get; set; }

        public List<BookingDetailModel> Bookingdetails { get; set; }

        public decimal Price { get; set; }
    }
}