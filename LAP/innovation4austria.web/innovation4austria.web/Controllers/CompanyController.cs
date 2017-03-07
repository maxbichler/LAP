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
    public class CompanyController : Controller
    {
        // GET: Company
        [HttpGet]
        public ActionResult Index()
        {
            List<companies> allCompanies = CompanyAdministration.GetCompanies();
            List<CompanyModel> model = new List<CompanyModel>();

            if (User.IsInRole("admin"))
            {
                foreach (var company in allCompanies)
                {
                    model.Add(new CompanyModel()
                    {
                        ID = company.id,
                        CompanyName = company.companyname,
                        Number = company.number,
                        Street = company.street,
                        Zip = company.zip,
                        City = company.city
                    });
                }
            }
            else if (User.IsInRole("User"))
            {
                foreach (var company in allCompanies)
                {
                    if (CompanyAdministration.IsUserInCompany(User.Identity.Name, company.id))
                    {
                        model.Add(new CompanyModel()
                        {
                            ID = company.id,
                            CompanyName = company.companyname,
                            Number = company.number,
                            Street = company.street,
                            Zip = company.zip,
                            City = company.city
                        });
                    }
                }
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            // lade Daten aus logic
            companies company = CompanyAdministration.GetCompany(id);
            List<portalusers> companyUsers = UserAdministration.GetCompanyUsers(id);

            CompanyDetailModel model = new CompanyDetailModel();

            model.Company = new CompanyModel()
            {
                ID = company.id,
                CompanyName = company.companyname,
                Zip = company.zip,
                Street = company.street,
                City = company.city
            };

            model.Portalusers = new List<ProfileDataModel>();
            foreach (var companyUser in companyUsers)
            {
                model.Portalusers.Add(new ProfileDataModel()
                {
                    ID = companyUser.id,
                    Firstname = companyUser.firstname,
                    Lastname = companyUser.lastname,
                    Active = companyUser.active,
                    Email = companyUser.email
                });
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveDetail(CompanyModel model)
        {
            if (ModelState.IsValid)
            {
                if (CompanyAdministration.SaveCompanyData(model.ID, model.CompanyName, model.Street, model.Number, model.Zip, model.City))
                {
                    TempData[Constants.Messages.SUCCESS] = Constants.Messages.SaveSuccess;
                }
                else
                {
                    TempData[Constants.Messages.ERROR] = Constants.Messages.SaveError;
                }
            }
            else
            {
                TempData[Constants.Messages.WARNING] = Constants.Messages.CompanyDataInvalid;
            }

            return RedirectToAction("Detail", new { id = model.ID });
        }

        [HttpGet]
        public ActionResult Employee(int id = 0)
        {
            if (id <= 0)
                return HttpNotFound("Invalid Employee ID");

            // Daten von der Datenbank
            portalusers employe = UserAdministration.GetEmploye(id);
            EmployeModel model = new EmployeModel();

            // ummappen von der applikation auf die Datenbank
            model.EmployeData = new EmployeDataModel()
            {
                ID_Company = employe.company_id,
                Email = employe.email,
                Firstname = employe.firstname,
                Lastname = employe.lastname,
                Active = employe.active
            };


        

            return View(model);
        }
    }
}