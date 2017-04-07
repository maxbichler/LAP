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
        public static List<furnishings> GetFurnishingsByRoomId(int id)
        {
            List<furnishings> allFurnishings = new List<furnishings>();

            try
            {
                using (var context = new ITIN20LAPEntities())
                {
                    allFurnishings = context.furnishings.Include("roomfurnishings").Where(x => x.roomfurnishings.Any(y => y.room_id == id)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return allFurnishings;
        }

        public static List<furnishings> GetFurnishings()
        {
            List<furnishings> allFurnishings = null;
            try
            {
                using (var context = new ITIN20LAPEntities())
                {
                    allFurnishings = context.furnishings.Include("roomfurnishings").ToList();
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
                    allRooms = context.rooms.Include("facilities").Include("bookings").Include("roomfurnishings").ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return allRooms;
        }

        /// Liefert alle Räume die während start und end NICHT gebucht sind
        public static List<rooms> GetRooms(DateTime startdate, DateTime enddate)
        {
            List<rooms> allRooms = null;
            try
            {
                using (var context = new ITIN20LAPEntities())
                {
                    allRooms = context.rooms.Include("facilities").Include("bookings").Include("roomfurnishings").ToList();

                    var alleGebuchtenRaumIDs = context.bookingdetails.Where(x => x.date >= startdate && x.date <= enddate).Select(x => x.bookings.room_id).ToList();

                    // alle Räume, aber nur die, deren ID NICHT bei den gebuchten Räume dabei ist!!
                    allRooms = allRooms.Where(x => !alleGebuchtenRaumIDs.Contains(x.id)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return allRooms;
        }

        public static bool CreateRoom(int facility_id, string description, decimal price)
        {
            bool created = false;
            try
            {
                using (var context = new ITIN20LAPEntities())
                {
                    rooms room = new rooms()
                    {
                        facility_id = facility_id,
                        description = description,
                        price = price
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

        //public static bool CreateFurnishing(int id, string description)
        //{
        //    bool created = false;
        //    try
        //    {
        //        using (var context = new ITIN20LAPEntities())
        //        {
        //            furnishings furnishing = new furnishings()
        //            {
        //                room_id = id,
        //                description = description
        //            };
        //            context.furnishings.Add(furnishing);
        //            context.SaveChanges();
        //            created = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }

        //    return created;
        //}

        public static bool CreateFurnishing(int roomId, string description)
        {
            bool created = false;
            try
            {
                using (var context = new ITIN20LAPEntities())
                {
                    furnishings f = new furnishings();
                    f.description = description;

                    context.furnishings.Add(f);
                    context.SaveChanges();

                    roomfurnishings rf = new roomfurnishings();
                    rf.furnishing_id = context.furnishings
                        .Where(x => x.description == description)
                        .Select(x => x.id)
                        .FirstOrDefault();
                    rf.room_id = roomId;

                    context.roomfurnishings.Add(rf);
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

        public static rooms GetRoomById(int id)
        {
            rooms room = new rooms();

            try
            {
                using (var context = new ITIN20LAPEntities())
                {
                    room = context.rooms.Include("bookings").Include("facilities").Include("roomfurnishings").Where(x => x.id == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return room;
        }
    }
}
