using innovation4austria.dataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace innovation4austria.logic
{
    public class BookingAdministration
    {
        public static List<bookings> GetBookings()
        {
            List<bookings> allBookings = null;
            try
            {
                using (var context = new ITIN20LAPEntities())
                {
                    allBookings = context.bookings.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return allBookings;
        }
        public static List<bookingdetails> GetBookingDetails()
        {
            List<bookingdetails> allBookingDetails = null;
            try
            {
                using (var context = new ITIN20LAPEntities())
                {
                    allBookingDetails = context.bookingdetails.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return allBookingDetails;
        }
    }
}
