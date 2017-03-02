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

            model.CompanyUsers = new List<ProfileDataModel>();
            foreach (var companyUser in companyUsers)
            {
                model.CompanyUsers.Add(new ProfileDataModel()
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
    }
}