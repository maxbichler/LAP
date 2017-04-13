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

        //public ActionResult CompanyBills()
        //{
        //    int company_id = UserAdministration.GetCompanyIdFromUser(User.Identity.Name);

        //    List<bills> allBills = BillAdministration.GetBills();
        //    List<BillModel> model = new List<BillModel>();

        //    foreach (var bill in allBills)
        //    {
        //        model.Add(new BillModel()
        //        {
        //            ID = bill.id,
        //            Date = bill.date,
        //            Company_ID = bill.company_id
        //        });
        //    }

        //    return new ViewAsPdf(model);
        //}

        [HttpGet]
        public ActionResult Create()
        {
            List<CreateBillModel> model = new List<CreateBillModel>();
            for (DateTime date = new DateTime(DateTime.Now.Year - 1, 1, 1); date <= DateTime.Now.AddMonths(1); date = date.AddMonths(1))
            {
                model.Add(new CreateBillModel()
                {
                    Year = date.Year,
                    Month = (date.Month),
                    IsPaid = BillAdministration.BookingExist(date.Month, date.Year),
                    BookingExist = BillAdministration.BookingExistsInTimePeriod(date.Month, date.Year),
                    SoonestBillDate = new DateTime(date.Year, date.Month, 1).AddMonths(1)
                });
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int month, int year)
        {
            bool success = BillAdministration.CreateBills(month, year);
            
            return RedirectToAction("CreateCompanyBills");
        }
    }
}