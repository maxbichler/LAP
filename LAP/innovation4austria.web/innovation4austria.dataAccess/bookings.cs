//------------------------------------------------------------------------------
// <auto-generated>
//    Dieser Code wurde aus einer Vorlage generiert.
//
//    Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten Ihrer Anwendung.
//    Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace innovation4austria.dataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class bookings
    {
        public bookings()
        {
            this.bookingdetails = new HashSet<bookingdetails>();
            this.bookingreversals = new HashSet<bookingreversals>();
        }
    
        public int id { get; set; }
        public int room_id { get; set; }
        public int company_id { get; set; }
        public System.DateTime startdate { get; set; }
        public System.DateTime enddate { get; set; }
        public decimal price { get; set; }
    
        public virtual ICollection<bookingdetails> bookingdetails { get; set; }
        public virtual ICollection<bookingreversals> bookingreversals { get; set; }
        public virtual companies companies { get; set; }
        public virtual rooms rooms { get; set; }
    }
}
