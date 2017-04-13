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
                    List<bookings> booking = context.bookingdetails.Where(x => x.date >= startdate && x.date <= enddate).Select(y => y.bookings).ToList();
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

        public static bool CreateBills(int month, int year)
        {
            bool created = false;
            DateTime startdate = new DateTime(year, month, 1);
            DateTime enddate = startdate.AddMonths(1).AddDays(-1);
            using (var context = new ITIN20LAPEntities())
            {
                try
                {
                    int bills = context.bookings.Where(x => x.startdate == startdate && x.enddate == enddate).Count();
                    if (bills > 0)
                    {
                        created = false;
                    }
                    else
                    {
                        foreach (var company in context.companies)
                        {
                            CreateCompanyBills(company.id, startdate, enddate);
                        }
                        created = true;
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return created;
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
    }
}
