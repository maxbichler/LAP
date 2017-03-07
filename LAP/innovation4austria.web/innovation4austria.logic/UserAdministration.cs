using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using innovation4austria.dataAccess;
using System.Diagnostics;

namespace innovation4austria.logic
{
    public class UserAdministration
    {
        public enum DataResult
        {
            success,
            fail,
        } 

        public enum PassResult
        {
            success,
            fail,
        }
        /// <summary>
        /// Liefert alle portalusers aus der DB
        /// </summary>
        /// <returns>Liste aller Users</returns>
        public static List<portalusers> AllUsers()
        {
            ITIN20LAPEntities context = new ITIN20LAPEntities();
            List<portalusers> userList = context.portalusers.ToList();
            return userList;
        }
        public static bool CheckLogin(string email, string password)
        {
            bool isValid = false;
            using (var context = new ITIN20LAPEntities())
            {
                var currentUser = context.portalusers.Where(x => x.email == email).FirstOrDefault();

                if (currentUser != null && currentUser.password.SequenceEqual(Helper.ComputeHash(password)))
                {
                    isValid = true;
                }
            }
            return isValid;
        }
        /// <summary>
        /// Überprüft ob Anmeldedaten ok sind
        /// </summary>
        /// <param name="email">Die vergebene Email-Adresse</param>
        /// <param name="passwort">Das vergebene Passwort</param>
        /// <returns>true oder false</returns>
        public static bool Login(string email, string password)
        {
            return Helper.CheckMailAndPass(email, password);
        }

        public static portalusers GetUser(string email)
        {
            portalusers user = null;

            using (var context = new ITIN20LAPEntities())
            {
                try
                {
                    user = context.portalusers.Where(x => x.email == email).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return user;
        }

        public static portalusers GetEmploye (int id)
        {
            portalusers user = null;

            using (var context = new ITIN20LAPEntities())
            {
                try
                {
                    user = context.portalusers.Where(x => x.id == id).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return user;
        }

        public static DataResult SaveProfile(string email, string firstname, string lastname)
        {
            DataResult res = DataResult.fail;
            using (var context = new ITIN20LAPEntities())
            {
                try
                {
                    var currentUser = context.portalusers.Where(x => x.email == email).FirstOrDefault();
                    if (currentUser != null)
                    {
                        if (currentUser.active)
                        {
                            currentUser.firstname = firstname;
                            currentUser.lastname = lastname;
                            context.SaveChanges();
                            res = DataResult.success;
                        }    
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return res;
        }
        public static PassResult ChangePassword(string email, string oldPassword, string newPassword)
        {
            PassResult res = PassResult.fail;
                using (var context = new ITIN20LAPEntities())
                {
                    try
                    {
                        var currentUser = context.portalusers.Where(x => x.email == email).FirstOrDefault();
                        if (currentUser == null || !currentUser.active || !currentUser.password.SequenceEqual(Helper.ComputeHash(oldPassword)) 
                        || !currentUser.password.SequenceEqual(Helper.ComputeHash(oldPassword)))
                        {
                            res = PassResult.fail;
                        }
                        else
                        {
                            currentUser.password = Helper.ComputeHash(newPassword);
                            context.SaveChanges();
                            res = PassResult.success;
                        }
                    }
                    catch (Exception ex)
                    {
                          throw;
                    }
                }
            return res;
        }
        public static List<portalusers> GetCompanyUsers(int companyId)
        {
            List<portalusers> companyUsers = null;

            using (var context = new ITIN20LAPEntities())
            {
                try
                {
                    var company = context.companies.FirstOrDefault(x => x.id == companyId);

                    if (company != null)
                        companyUsers = company.portalusers.ToList();
                    else
                        throw new ArgumentException("Invalid companyId", nameof(companyId));
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return companyUsers;
        }
    }
}

