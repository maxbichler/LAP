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
        [HttpGet]
        public ActionResult RoomDetail(int id)
        {
            List<furnishings> allFurnishings = RoomAdministration.GetFurnishings();
            FurnishingModel model = new FurnishingModel();

            if (User.IsInRole("admin"))
            {
                foreach (var furnishing in allFurnishings)
                {
                    if (id == furnishing.room_id)
                    {
                        id = furnishing.room_id;
                        model.Description = furnishing.description;
                    }
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
                if (RoomAdministration.CreateRoom(model.Facility_ID, model.Description))
                {
                    TempData[Constants.Messages.SUCCESS] = Constants.Messages.SaveSuccess;
                    result = RedirectToAction("Detail", new { id = model.ID });
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