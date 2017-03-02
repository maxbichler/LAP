using innovation4austria.dataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace innovation4austria.logic
{
    public class RoleAdministration
    {
        public static List<portalusers> GetRoleUsers(string roleName)
        {
            if (string.IsNullOrEmpty(roleName))
            {
                throw new ArgumentNullException(nameof(roleName));
            }
            else
            {
                List<portalusers> roleUsers = null;

                using (var context = new ITIN20LAPEntities())
                {
                    try
                    {
                        portalroles Role = context.portalroles.Where(x => x.description == roleName).FirstOrDefault();
                        if (Role != null)
                        {
                            roleUsers = Role.portalusers.Where(x => x.active).ToList();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
                return roleUsers;
            }
        }

        public static List<portalroles> GetRoles()
        {
            List<portalroles> roles = null;
            using (var context = new ITIN20LAPEntities())
            {
                try
                {
                    roles = context.portalroles.Where(x => x.active).ToList();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return roles;
        }


        public static portalroles GetUserRole(string email)
        {

            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException(nameof(email));
            }
            else
            {
                portalroles userRole = null;

                using (var context = new ITIN20LAPEntities())
                {
                    try
                    {
                        portalusers currentUser = context.portalusers.Where(x => x.email == email).FirstOrDefault();
                        if (currentUser != null)
                        {
                            userRole = currentUser.portalroles;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
                return userRole;
            }
        }
    }
}

