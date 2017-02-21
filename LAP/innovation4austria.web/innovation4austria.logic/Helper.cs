using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using innovation4austria.dataAccess;
using System.Security.Cryptography;

namespace innovation4austria.logic
{
    public class Helper
    {




        public static byte[] ComputeHash(string value)
        {
            SHA512 hash = SHA512.Create();

            byte[] hashPwd = hash.ComputeHash(Encoding.UTF8.GetBytes(value));

            return hashPwd;
        }

        /// <summary>
        /// Diese Methode vergleicht Email und Passwort mit den Daten in der DB
        /// </summary>
        /// <param name="email">Email-Adresse des Users</param>
        /// <param name="passwort">Passwort aus der Oberfläche</param>
        /// <returns>true oder false</returns>
        public static bool CheckMailAndPass(string email, string passwort)
        {
            ITIN20LAPEntities context = new ITIN20LAPEntities();

            SHA512 hash = SHA512.Create();

            byte[] pw = hash.ComputeHash(Encoding.UTF8.GetBytes(passwort));

            using (context)
            {
                foreach (var u in context.portalusers)
                {
                    if (u.email == email && pw.SequenceEqual(u.password))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

    }
}
