﻿using System;
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
    }
}
