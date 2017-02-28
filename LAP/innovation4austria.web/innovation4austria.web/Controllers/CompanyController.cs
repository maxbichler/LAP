﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using innovation4austria.dataAccess;
using innovation4austria.logic;
using innovation4austria.web;
using innovation4austria.web.Models;

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
    }
}