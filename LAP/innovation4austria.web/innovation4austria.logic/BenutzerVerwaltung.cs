using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using innovation4austria.dataAccess;

namespace innovation4austria.logic
{
    class BenutzerVerwaltung
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
    }
}
