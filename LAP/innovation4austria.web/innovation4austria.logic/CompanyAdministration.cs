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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public static bool IsUserInCompany(string email, int companyId)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentException("Invalid email", nameof(email));
            if (companyId <= 0)
                throw new ArgumentException("Invalid id", nameof(companyId));
            else
            {
                bool success = false;

                try
                {
                    using (var context = new ITIN20LAPEntities())
                    {
                        foreach (var item in context.companies)
                        {
                            if (item.id == companyId)
                            {
                                success = item.portalusers.Any(x => x.email == email); 
                            }
                        }
                    }
                }
                catch (Exception ex)
                {

                    throw;
                }
                return success;
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
