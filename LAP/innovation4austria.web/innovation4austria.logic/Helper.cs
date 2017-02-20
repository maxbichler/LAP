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
            var encodePasswort = System.Security.Cryptography.SHA512.Create();
            var encoder = new System.Text.ASCIIEncoding();
            var combined = encoder.GetBytes(value ?? "");
            return encodePasswort.ComputeHash(combined);
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
