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
                        Description = room.description,
                        Facility_Name = room.facilities.facilityname,
                        Booked = room.booked,
                        Price = room.price
                    });
                }
            }
            else if (User.Identity.IsAuthenticated)
            {
                foreach (var room in allRooms)
                {
                    model.Add(new RoomModel()
                    {
                        ID = room.id,
                        Facility_ID = room.facility_id,
                        Description = room.description,
                        Facility_Name = room.facilities.facilityname,
                        Price = room.price

                    });

                }
            }
            return View(model);
        }

        public ActionResult Filter(FilterModel fm)
        {
            Session["FilterSession"] = fm;


            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult RoomDetail(int id)
        {
            List<furnishings> allFurnishings = RoomAdministration.GetFurnishingsByRoomId(id);
            List<FurnishingModel> model = new List<FurnishingModel>();

            if (User.IsInRole("admin"))
            {
                foreach (var furnishing in allFurnishings)
                {

                    model.Add(new FurnishingModel() { Description = furnishing.description, ID = furnishing.id, Room_ID = id });

                }
            }
            else if (User.Identity.IsAuthenticated)
            {
                foreach (var furnishing in allFurnishings)
                {

                    model.Add(new FurnishingModel() { Description = furnishing.description, ID = furnishing.id, Room_ID = id });

                }
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult CreateRoom(int id)
        {

            CreateRoomModel model = new CreateRoomModel()
            {
                ID = id
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRoom(CreateRoomModel model)
        {
            ActionResult result = View(model);

            if (ModelState.IsValid)
            {
                if (RoomAdministration.CreateRoom(model.Facility_ID, model.Description, model.Price, model.Booked))
                {
                    TempData[Constants.Messages.SUCCESS] = Constants.Messages.SaveSuccess;
                    result = RedirectToAction("Index", new { id = model.ID });
                }
                else
                {
                    TempData[Constants.Messages.ERROR] = Constants.Messages.SaveError;

                }
            }
            else
            {
                TempData[Constants.Messages.WARNING] = Constants.Messages.CreateEmployeInvalid;
            }

            return result;
        }
        [HttpGet]
        public ActionResult CreateFurnishing(int id)
        {

            CreateFurnishingModel model = new CreateFurnishingModel()
            {
                Room_ID = id
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateFurnishing(CreateFurnishingModel model)
        {
            ActionResult result = View(model);

            if (ModelState.IsValid)
            {
                if (RoomAdministration.CreateFurnishing(model.Room_ID, model.Description))
                {
                    TempData[Constants.Messages.SUCCESS] = Constants.Messages.SaveSuccess;
                    result = RedirectToAction("RoomDetail", new { id = model.Room_ID });
                }
                else
                {
                    TempData[Constants.Messages.ERROR] = Constants.Messages.SaveError;

                }
            }
            else
            {
                TempData[Constants.Messages.WARNING] = Constants.Messages.CreateEmployeInvalid;
            }

            return result;
        }
    }
}
