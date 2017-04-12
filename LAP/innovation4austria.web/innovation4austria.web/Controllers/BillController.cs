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

        public ActionResult Bills(int bill_id)
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
    }
}