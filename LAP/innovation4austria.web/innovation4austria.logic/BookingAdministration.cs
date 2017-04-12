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
                throw new ArgumentException("Monat ungültig");
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

        public static bool CreateBooking(int room_id, int company_id, string start, string end)
        {
            bool createSuccess = false;
            var context = new ITIN20LAPEntities();
            DateTime startdate;
            DateTime enddate;
            DateTime.TryParse(start, out startdate);
            DateTime.TryParse(end, out enddate);

            using (context)
            {
                try
                {
                    bookings newBooking = new bookings();
                    if (DateTime.Now <= startdate.AddDays(3))
                    {

                        int days = (enddate - startdate).Days + 1;
                        newBooking.company_id = company_id;
                        newBooking.room_id = room_id;
                        newBooking.startdate = startdate;
                        newBooking.enddate = enddate;
                        newBooking.price = context.rooms.Where(x => x.id == room_id).Select(x => x.price).FirstOrDefault() * days;
                        context.bookings.Add(newBooking);
                        context.SaveChanges();
                        
                        int id = newBooking.id;
                        decimal price = context.rooms.FirstOrDefault(x => x.id == room_id).price;

                        for (int i = 0; i < days; i++)
                        {
                            bookingdetails b = new bookingdetails();
                            b.price = price;
                            DateTime date = startdate.AddDays(i);
                            b.date = date;
                            b.booking_id = id;
                            context.bookingdetails.Add(b);
                        }
                        context.SaveChanges();
                        createSuccess = true;
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return createSuccess;
        }

    }
}
