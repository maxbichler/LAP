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

        public static bool BookingExist(int month, int year)
        {
            bool bookingExists = false;

            if (month < 1 || month > 12)
            {
                throw new ArgumentException("Monat nicht gültig");
            }
            if (year < 2000 || year > 2020)
            {
                throw new ArgumentException("Jahr muss zwischen 2000 und 2020 liegen");
            }

            DateTime StartDate = new DateTime(year, month, 1);
            DateTime EndDate = StartDate.AddMonths(1).AddDays(-1);

            using (var context = new ITIN20LAPEntities())
            {
                try
                {
                    int bookings = context.bookings.Count(x => x.bookingdetails.Any(y => y.date >= StartDate && y.date <= EndDate));
                    bookingExists = bookings > 0;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return bookingExists;

        }
    }
}
