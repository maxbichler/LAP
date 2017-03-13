using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using innovation4austria.dataAccess;

namespace innovation4austria.logic
{
    public class RoomAdministration
    {
        public static List<furnishings> GetFurnishings()
        {
            List<furnishings> allFurnishings = null;
            try
            {
                using (var context = new ITIN20LAPEntities())
                {
                    allFurnishings = context.furnishings.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return allFurnishings;
        }

        public static List<facilities> GetFacilities()
        {
            List<facilities> allFacilities = null;
            try
            {
                using (var context = new ITIN20LAPEntities())
                {
                    allFacilities = context.facilities.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return allFacilities;
        }

        public static List<rooms> GetRooms()
        {
            List<rooms> allRooms = null;
            try
            {
                using (var context = new ITIN20LAPEntities())
                {
                    allRooms = context.rooms.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return allRooms;
        }

        public static bool CreateRoom(int facility_id, string description)
        {
            bool created = false;
            try
            {
                using (var context = new ITIN20LAPEntities())
                {
                    rooms room = new rooms()
                    {
                        facility_id = facility_id,
                        description = description
                    };
                    context.rooms.Add(room);
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
    }
}
