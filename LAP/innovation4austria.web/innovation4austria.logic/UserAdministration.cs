using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using innovation4austria.dataAccess;

namespace innovation4austria.logic
{
    public class UserAdministration
    {
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
    }
}
