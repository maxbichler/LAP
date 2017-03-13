using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using innovation4austria.dataAccess;
using innovation4austria.logic;
using innovation4austria.web;
using innovation4austria.web.Models;
using System.Xml.Linq;
using innovation4austria.web.AppCode;

namespace innovation4austria.web.Controllers
{
    public class RoomController : Controller
    {
        // GET: Room
        public ActionResult Index()
        {
            List<rooms> allRooms = RoomAdministration.GetRooms();
            List<RoomModel> model = new List<RoomModel>();

            if (User.IsInRole("admin"))
            {
                foreach (var room in allRooms)
                {
                    model.Add(new RoomModel()
                    {
                        ID = room.id,
                        Facility_ID = room.facility_id,
                        Description = room.description
                    });
                }
            }
            return View(model);
        }

        public ActionResult RoomDetail()
        {
            List<facilities> allFacilities = RoomAdministration.GetFacilities();
            List<FacilityModel> model = new List<FacilityModel>();

            if (User.IsInRole("admin"))
            {
                foreach (var facility in allFacilities)
                {
                    model.Add(new FacilityModel()
                    {
                        ID = facility.id,
                        FacilityName = facility.facilityname,
                        City = facility.city,
                        Street = facility.street,
                        Zip = facility.zip,
                        Number = facility.number
                    });
                }
            }
            return View(model);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult CreateRoom(CreateRoomModel model)
        //{
        //    ActionResult result = View(model);

        //    if (ModelState.IsValid)
        //    {
        //        if (RoomAdministration.CreateRoom(model.))
        //        {
        //            TempData[Constants.Messages.SUCCESS] = Constants.Messages.SaveSuccess;
        //            result = RedirectToAction("Detail", new { id = model.CompanyID });
        //        }
        //        else
        //        {
        //            TempData[Constants.Messages.ERROR] = Constants.Messages.SaveError;

        //        }
        //    }
        //    else
        //    {
        //        TempData[Constants.Messages.WARNING] = Constants.Messages.CreateEmployeInvalid;
        //    }

        //    return result;
        //}
    }
}