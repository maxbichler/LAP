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

        public enum ProfileChangeResult
        {
            Success,
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
                    user = context.portalusers.Include("companies").Include("bookingreversals").Include("portalroles").Include("bills").Where(x => x.email == email).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return user;
        }

        public static portalusers GetEmploye(int id)
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

        public static PassResult ChangePassword(int id, string oldPassword, string newPassword)
        {
            PassResult result = PassResult.fail;

            if (id <= 0)
                throw new ArgumentException($"Invalid {nameof(id)}");
            else if (string.IsNullOrEmpty(newPassword))
                throw new ArgumentNullException(nameof(newPassword));
            else if (string.IsNullOrEmpty(oldPassword))
                throw new ArgumentNullException(nameof(oldPassword));
            else
            {
                using (var context = new ITIN20LAPEntities())
                {
                    try
                    {
                        portalusers curUser = context.portalusers.Where(x => x.id == id).FirstOrDefault();

                        if (curUser == null)
                        {
                            result = PassResult.fail;
                        }
                        else if (!curUser.active)
                        {
                            result = PassResult.fail;
                        }
                        else if (!curUser.password.SequenceEqual(Helper.ComputeHash(oldPassword)))
                        {
                            result = PassResult.fail;
                        }
                        else
                        {
                            curUser.password = Helper.ComputeHash(newPassword);
                            context.SaveChanges();

                            result = PassResult.success;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
            }
            return result;
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

        /// <summary>
        /// Saves new first- and lastname for the given userName
        /// </summary>
        /// <param name="username">the user to change data for</param>
        /// <param name="firstname">new firstname</param>
        /// <param name="lastname">new lastname</param>
        public static ProfileChangeResult SaveEmployeData(int idEmploye, string firstname, string lastname)
        {
            ProfileChangeResult result = ProfileChangeResult.fail;

            if (idEmploye <= 0)
                throw new ArgumentException($"Invalid {nameof(idEmploye)} ");
            if (string.IsNullOrEmpty(firstname))
                throw new ArgumentNullException($"{nameof(firstname)} is null or empty");
            if (string.IsNullOrEmpty(lastname))
                throw new ArgumentNullException($"{nameof(lastname)} is null or empty");

            using (var context = new ITIN20LAPEntities())
            {
                try
                {
                    portalusers currentUser = context.portalusers.FirstOrDefault(x => x.id == idEmploye);
                    if (currentUser != null)
                    {
                        if (currentUser.active)
                        {
                            currentUser.firstname = firstname;
                            currentUser.lastname = lastname;
                            context.SaveChanges();
                            result = ProfileChangeResult.Success;
                        }
                        else
                        {
                            result = ProfileChangeResult.fail;
                        }
                    }
                    else
                    {
                        result = ProfileChangeResult.fail;
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

            return result;
        }

        /// <summary>
        /// lösche benutzer mit der ID
        /// </summary>
        /// <param name="idUser">id for a given company user</param>
        /// <exception cref="Exception">in case data access failed</exception>
        /// <returns>true if deactivation was successfull, otherelse false</returns>
        public static bool DeleteCompanyUser(int idUser)
        {
            bool deleteSuccessful = false;

            try
            {
                portalusers user = null;
                using (var context = new ITIN20LAPEntities())
                {
                    user = context.portalusers.FirstOrDefault(x => x.id == idUser && x.role_id == 2);
                }
                if (user != null)
                {
                    deleteSuccessful = DeactivateUser(user.email);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return deleteSuccessful;
        }

        public static bool DeactivateUser(string email)
        {
            bool success = false;

            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException(nameof(email));
            }
            else
            {
                using (var context = new ITIN20LAPEntities())
                {
                    try
                    {
                        portalusers curUser = context.portalusers.Where(x => x.email == email).FirstOrDefault();

                        if (curUser != null)
                        {
                            curUser.active = false;
                            context.SaveChanges();
                            success = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
            }
            return success;
        }

        /// <summary>
        ///  Erstelle einen Neuen benutzer in der DB mit den angegebenen Daten mit der Rolle Mitarbeiter
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <param name="company_id"></param>
        /// <returns>true falls alles geklappt hat</returns>
        public static bool CreateCompanyUser(string email, string password, string firstname, string lastname, int company_id)
        {
            bool created = false;
            try
            {
                using (var context = new ITIN20LAPEntities())
                {
                    portalusers user = new portalusers()
                    {
                        email = email,
                        password = Helper.ComputeHash(password),
                        firstname = firstname,
                        lastname = lastname,
                        company_id = company_id,
                        role_id = 3, // Mitarbeiter 
                        active = true
                    };
                    context.portalusers.Add(user);
                    context.SaveChanges();
                    created = true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return created;
        }

        public static int GetCompanyIdFromUser(string email)
        {
            portalusers p = null;
            int companyId = 0;
            var context = new ITIN20LAPEntities();

            using (context)
            {
                try
                {
                    p = context.portalusers.FirstOrDefault(x => x.email == email);
                    companyId = context.companies.FirstOrDefault(x => x.id == p.company_id).id;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return companyId;
        }
    }
}

