using innovation4austria.dataAccess;
using innovation4austria.logic;
using innovation4austria.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace innovation4austria.web.Controllers
{
    public class BookingController : Controller
    {
        // GET: Booking
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Room(int id, string startdate, string enddate)
        {
            //Buchungsmodel anlegen
            BookingModel model = new BookingModel();

            //aktuellen Benutzer anlegen
            portalusers user = new portalusers();
            user = UserAdministration.GetUser(User.Identity.Name);

            //Werte ummappen
            string startString = startdate.Substring(0, 10);
            string endString = enddate.Substring(0, 10);

            //DateTime start = Convert.ToDateTime(startString);
            //DateTime end = Convert.ToDateTime(endString);

            model.StartDate = Convert.ToDateTime(startString);
            model.EndDate = Convert.ToDateTime(endString);

            TimeSpan span = model.EndDate.Subtract(model.StartDate);
            model.DateDif = span.Days + 1;

            rooms dbRoom = new rooms();
            dbRoom = RoomAdministration.GetRoomById(id);

            model.RoomDescription = dbRoom.description;
            model.RoomPrice = (double)dbRoom.price;

            model.EndPrice = model.DateDif * model.RoomPrice;

            return View(model);
        }
        
        public ActionResult RoomBooking(int id, DateTime startdate, DateTime enddate, int room_id)
        {
           

            return View();
        }
   

    }
}
