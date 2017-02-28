using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using innovation4austria.dataAccess;

namespace innovation4austria.logic
{
    public class CompanyAdministration
    {
        /// <summary>
        /// Returned eine Liste von ALLEN companies.
        /// </summary>
        /// <returns></returns>
        public static List<companies> GetCompanies()
        {
            List<companies> allCompanies = null;
            try
            {
                using (var context = new ITIN20LAPEntities())
                {
                    allCompanies = context.companies.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return allCompanies;
        }
        /// <summary>
        /// Returned die EINE company mit dieser ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static companies GetCompany(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid id", nameof(id));
            else
            {
                companies company = null;

                try
                {
                    using (var context = new ITIN20LAPEntities())
                    {
                        company = context.companies.FirstOrDefault(x => x.id == id);
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
                return company;
            }
        }

        public static bool SaveCompanyData(int companyId, string companyName, string street, string number, string zip, string city)
        {
            bool result = false;
            using (var context = new ITIN20LAPEntities())
            {
                try
                {
                    companies curCompany = context.companies.FirstOrDefault(x => x.id == companyId);
                    if (curCompany != null)
                    {
                        curCompany.companyname = companyName;
                        curCompany.street = street;
                        curCompany.number = number;
                        curCompany.zip = zip;
                        curCompany.city = city;
                        context.SaveChanges();
                        result = true;
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return result;
        }
    }
}
