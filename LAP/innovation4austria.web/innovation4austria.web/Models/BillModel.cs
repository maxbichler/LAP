using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace innovation4austria.web.Models
{
    public class BillModel
    {
        public int ID { get; set; }

        public DateTime Date { get; set; }

        public int Company_ID { get; set; }
    }
}