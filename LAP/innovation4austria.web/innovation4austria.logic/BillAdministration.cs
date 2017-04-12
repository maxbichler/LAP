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
                    allBills = context.bills.Include("portalusers").Include("bookingdetails").ToList();
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
                    companybills = context.bills.Include("portalusers").Include("bookingdetails").Where(x => x.company_id == id).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return companybills;
        }
    }
}
