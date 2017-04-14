using innovation4austria.dataAccess;
using innovation4austria.logic;
using innovation4austria.web.Models;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace innovation4austria.web.Controllers
{
    public class BillController : Controller
    {
        // GET: Bill
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CompanyBills()
        {
            int company_id = UserAdministration.GetCompanyIdFromUser(User.Identity.Name);

            List<bills> allBills = BillAdministration.GetBills();
            List<BillModel> model = new List<BillModel>();

            foreach (var bill in allBills)
            {
                model.Add(new BillModel()
                {
                    ID = bill.id,
                    Date = bill.date,
                    Company_ID = bill.company_id
                });
            }

            return new ViewAsPdf(model);
        }

        //[HttpGet]
        //public ActionResult Create()
        //{
        //    List<CreateBillModel> model = new List<CreateBillModel>();
        //    for (DateTime date = new DateTime(DateTime.Now.Year - 1, 1, 1); date <= DateTime.Now.AddMonths(1); date = date.AddMonths(1))
        //    {
        //        model.Add(new CreateBillModel()
        //        {
        //            Year = date.Year,
        //            Month = (date.Month),
        //            IsPaid = BillAdministration.BookingExist(date.Month, date.Year),
        //            BookingExist = BillAdministration.BookingExistsInTimePeriod(date.Month, date.Year),
        //            SoonestBillDate = new DateTime(date.Year, date.Month, 1).AddMonths(1)
        //        });
        //    }
        //    return View(model);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(int month, int year)
        //{
        //    bool success = BillAdministration.CreateBills(month, year);

        //    return RedirectToAction("CreateCompanyBills");
        //}



        [HttpGet]
        [Authorize(Roles = "User")]
        public ActionResult GeneratePDF(int id)
        {
            // Erstelle PDF für die Rechnung

            bills pdfBill = new bills();
            pdfBill = BillAdministration.GetBillById(id);

            List<bookingdetails> bdList = new List<bookingdetails>();
            bdList = pdfBill.bookingdetails.ToList();

            List<rooms> rList = new List<rooms>();
            rList = RoomAdministration.GetRooms();

            List<bookings> bList = new List<bookings>();
            bList = BookingAdministration.GetBookings();

            PdfModel model = new PdfModel();
            model.Billdate = pdfBill.date;
            model.Id = pdfBill.id;

            decimal totalPrice = 0;

            model.Bookingdetails = new List<BookingDetailModel>();

            foreach (var item in bdList)
            {
                model.Bookingdetails.Add(new BookingDetailModel()
                {
                    ID = item.id,
                    Date = item.date,
                    Price = item.price,
                    Room = (from bd in bdList
                            join b in bList on bd.booking_id equals b.id
                            join r in rList on b.room_id equals r.id
                            where bd.id == item.id
                            select r.description).FirstOrDefault()
                });
                totalPrice += item.price;
            }
        
        model.Price = totalPrice;

            ViewAsPdf viewPdf = new ViewAsPdf("GeneratePDF", model);

                return View("GeneratePDF", model);
    }


        [HttpGet]
        [Authorize(Roles = "User")]
        public ActionAsPdf Download(int id)
        {
            return new ActionAsPdf("GeneratePDF", new { id });
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            // Hier wird die Logik aufgerufen, um die Rechnungen für das vergangene Monat für alle Firmen zu erzeugen
            bool success = BillAdministration.CreateBills();

            if (success)
            {
                TempData[AppCode.Constants.Messages.BillSuccess] = "Rechnungen erfolgreich erstellt!";
                return RedirectToAction("Index", "Home");
            }

            TempData[AppCode.Constants.Messages.ERROR] = "Es ist ein Fehler passiert!";
            return RedirectToAction("Index", "Home");
        }
    }
}