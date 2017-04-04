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
            RoomFilterModel rfm = new RoomFilterModel();
            rfm.Filter = new FilterModel();
            rfm.Rooms = new List<RoomModel>();

            List<rooms> allRooms = RoomAdministration.GetRooms();
            List<RoomModel> model = new List<RoomModel>();

            rfm.Filter.Furnishings = new List<FilterFurnishingModel>();
            List<furnishings> allFurnishings = new List<furnishings>();
            allFurnishings = RoomAdministration.GetFurnishings();

            FilterModel fm = new FilterModel();
            fm.Furnishings = new List<FilterFurnishingModel>();

            if (Session["FilterSession"] != null)
            {
                fm = (FilterModel)Session["FilterSession"];
            }
            else
            {
                foreach (var f in allFurnishings)
                {
                    fm.Furnishings.Add(new FilterFurnishingModel() { Description = f.description, Id = f.id });
                }
                fm.StartDate = DateTime.Now;
                fm.EndDate = DateTime.Now;
            }


            List<rooms> filteredRooms = new List<rooms>();

            if (Session["FilterSession"] != null)
            {
                // Filterlogik aufrufen
                if (fm.Price > 0)
                {
                    allRooms = allRooms.Where(x => x.price <= fm.Price).ToList();
                }

                /// ermittle alle Räume
                /// die zwischen fm.StartDate und fm.EndDate NICHT gebucht sind
                


                if (fm.StartDate > DateTime.Now)
                {
                    // Testen!!
                    allRooms = allRooms.Where(x => x.bookings.Any(y => y.startdate <= fm.StartDate)).ToList();
                }
                if (fm.EndDate > fm.StartDate || fm.EndDate > DateTime.Now)
                {


                    allRooms = allRooms.Where(x => x.bookings.Any(y => y.enddate <= fm.EndDate)).ToList();


                }


                if (!string.IsNullOrEmpty(fm.Facility))
                {
                    allRooms = allRooms.Where(x => x.facilities.facilityname == fm.Facility).ToList();
                }
                if (fm.Furnishings != null /*|| fm.Furnishings.Count > 0*/)
                {
                    // Testen!!
                    allRooms = allRooms.Where(x => x.roomfurnishings.Any(y => fm.Furnishings.Exists(z => z.Id == y.furnishing_id))).ToList();
                }
            }

            if (User.IsInRole("admin"))
            {


                foreach (var room in allRooms)
                {
                    RoomModel rm = new RoomModel();
                    rm.Description = room.description;
                    rm.Facility_ID = room.facility_id;
                    rm.Facility_Name = room.facilities.facilityname;
                    rm.Furnishings = new List<FurnishingModel>();
                    rm.ID = room.id;
                    rm.Price = room.price;

                    List<furnishings> dbFurnishings = new List<furnishings>();
                    dbFurnishings = RoomAdministration.GetFurnishingsByRoomId(room.id);

                    foreach (var f in dbFurnishings)
                    {
                        FurnishingModel furModel = new FurnishingModel();
                        furModel.Description = f.description;
                        furModel.ID = f.id;
                        furModel.Room_ID = room.id;
                        rm.Furnishings.Add(furModel);
                    }

                    model.Add(rm);
                }


            }
            else if (User.Identity.IsAuthenticated)
            {


                foreach (var room in allRooms)
                {
                    RoomModel rm = new RoomModel();
                    rm.Description = room.description;
                    rm.Facility_ID = room.facility_id;
                    rm.Facility_Name = room.facilities.facilityname;
                    rm.Furnishings = new List<FurnishingModel>();
                    rm.ID = room.id;
                    rm.Price = room.price;

                    List<furnishings> dbFurnishings = new List<furnishings>();
                    dbFurnishings = RoomAdministration.GetFurnishingsByRoomId(room.id);

                    foreach (var f in dbFurnishings)
                    {
                        FurnishingModel furModel = new FurnishingModel();
                        furModel.Description = f.description;
                        furModel.ID = f.id;
                        furModel.Room_ID = room.id;
                        rm.Furnishings.Add(furModel);
                    }

                    model.Add(rm);
                }
            }
            rfm.Rooms = model;
            rfm.Filter = fm;
            return View(rfm);
        }

        public ActionResult Reset()
        {
            Session["FilterSession"] = null;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Filter(DateTime startdate, DateTime enddate, string facility, List<int> furnishingId, decimal price)
        {
            //neues FilterModel mit Werten vom Formular befüllen
            FilterModel fm = new FilterModel();
            fm.Furnishings = new List<FilterFurnishingModel>();
            if (facility != null)
            {
                fm.Facility = facility;
            }
            if (furnishingId != null)
            {
                // Befüllen der Furnishings
                List<furnishings> dbFurnishings = new List<furnishings>();
                dbFurnishings = RoomAdministration.GetFurnishings();

                foreach (var f in dbFurnishings)
                {
                    foreach (var id in furnishingId)
                    {
                        if (f.id == id)
                        {
                            fm.Furnishings.Add(new FilterFurnishingModel() { Id = f.id, Description = f.description });
                        }
                    }
                }
            }
            if (furnishingId == null)
            {
                List<furnishings> dbFurnishings = new List<furnishings>();
                dbFurnishings = RoomAdministration.GetFurnishings();

                foreach (var f in dbFurnishings)
                {
                    fm.Furnishings.Add(new FilterFurnishingModel() { Description = f.description, Id = f.id });
                }
            }

            fm.StartDate = startdate;
            fm.EndDate = enddate;
            fm.Price = price;

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
