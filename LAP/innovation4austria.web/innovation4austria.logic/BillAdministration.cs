using innovation4austria.dataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace innovation4austria.logic
{
    public class BillAdministration
    {
        public static List<bills> GetBills()
        {
            List<bills> allBills = null;
            try
            {
                using (var context = new ITIN20LAPEntities())
                {
                    allBills = context.bills.Include("companies").Include("bookingdetails").ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return allBills;
        }

        public static List<bills> GetBillsByCompany(int id)
        {
            List<bills> companybills = null;

            try
            {
                using (var context = new ITIN20LAPEntities())
                {
                    companybills = context.bills.Include("companies").Include("bookingdetails").Where(x => x.company_id == id).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return companybills;
        }

        public static bool BookingExist(int month, int year)
        {
            DateTime startdate = new DateTime(year, month, 1);
            DateTime enddate = startdate.AddMonths(1).AddDays(-1);
            bool exists = false;
            using (var context = new ITIN20LAPEntities())
            {
                try
                {
                    List<bills> allBills = context.bills.Where(x => x.date == startdate && x.date == enddate).ToList();
                    if (allBills.Count() <= 0)
                    {
                        exists = false;
                    }
                    else
                    {
                        exists = true;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return exists;
        }
        public static bool BookingExistsInTimePeriod(int month, int year)
        {
            DateTime startdate = new DateTime(year, month, 1);
            DateTime enddate = startdate.AddMonths(1).AddDays(-1);
            bool exists = false;

            using (var context = new ITIN20LAPEntities())
            {
                try
                {
                    List<bookings> booking = context.bookings.Where(x => x.startdate >= startdate && x.enddate <= enddate).ToList();
                    if (booking == null || booking.Count() <= 0)
                    {
                        exists = false;
                    }
                    else
                    {
                        exists = true;
                    }

                }
                catch (Exception ex)
                {
                    throw;
                }
            }


            return exists;
        }
        public static bool CreateCompanyBills(int company_id, DateTime startdate, DateTime enddate)
        {
            bool erstellenerfolgreich = false;
           
            using (var context = new ITIN20LAPEntities())
            {
                try
                {
                    List<bookingdetails> bd = context.bookingdetails.Where(x => x.date >= startdate && x.date <= enddate && x.bookings.company_id == company_id).ToList();
                    if (bd == null || bd.Count == 0)
                    {
                        throw new ArgumentNullException();
                    }
                    bookings newBooking = new bookings();
                    newBooking.company_id = company_id;
                    newBooking.startdate = startdate;
                    newBooking.enddate = enddate;
                    context.bookings.Add(newBooking);
                    foreach (var item in bd)
                    {
                        newBooking.bookingdetails.Add(item);
                    }
                    context.SaveChanges();

                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return erstellenerfolgreich;
        }
        public static bool CreateBills()
        {

            DateTime end = DateTime.Now.Subtract(new TimeSpan(DateTime.Now.Day, 0, 0, 0));
            DateTime start = new DateTime(end.Year, end.Month, 1);

            DateTime billDate = new DateTime(start.Year, start.Month, start.Day);
            billDate = billDate.AddMonths(1);

            List<bookingdetails> bdList = new List<bookingdetails>();
            bdList = BookingAdministration.GetAllBookingDetails(start, end);
            bdList = bdList.Where(x => x.bill_id == null).ToList();

            try
            {
                using (var context = new ITIN20LAPEntities())
                {
                    if (bdList == null || bdList.Count == 0)
                    {
                        return false;
                    }
                    // prüfe ob schon einmal abrechnungen gemacht wurden
                    if (context.bills.Any(x => x.date.Month == billDate.Month && x.date.Year == billDate.Year))
                    {
                        return false;
                    }
                    else
                    {
                        foreach (var comp in context.companies.Include("bookings"))
                        {
                            if (bdList.Any(x => x.bookings.company_id == comp.id))
                            {

                                bills newBill = new bills();
                                newBill.date = billDate;
                                newBill.company_id = comp.id;
                                context.bills.Add(newBill);

                                //context.SaveChanges();


                                List<bookingdetails> bookingdetails = context.bookingdetails.Where(x => x.bill_id == null && x.bookings.company_id == comp.id && x.date >= start && x.date <= end).ToList();


                                foreach (var bd in bookingdetails)
                                {
                                    if (bd.bill_id == null)
                                    {
                                        bd.bills = newBill;
                                        //bd.bill_id = newBill.id;
                                    }
                                }
                            }
                        }
                    }

                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static bills GetBillById(int id)
        {
            bills foundBill = new bills();

            try
            {
                using (var context = new ITIN20LAPEntities())
                {
                    foreach (var b in context.bills.Include("bookingdetails"))
                    {
                        if (b.id == id)
                        {
                            foundBill = b;
                        }
                    }
                }

                return foundBill;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
