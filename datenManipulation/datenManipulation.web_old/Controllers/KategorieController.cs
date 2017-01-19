using datenManipulation.logic;
using datenManipulation.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace datenManipulation.web.Controllers
{
    public class KategorieController : Controller
    {
        [HttpGet]
        public ActionResult Anlegen()
        {

            return View();
        }

        [HttpPost]
        /// Prüfe ob das ForgeryToken mitgeschickt wurde
        /// Fehlt dieses gibt es einen Fehler
        [ValidateAntiForgeryToken]
        public ActionResult Anlegen(KategorieAnlegenModel model)
        {
            if (ModelState.IsValid)
            {
                bool erfolgreich = KategorieVerwaltung.Anlegen(model.Bezeichnung);

                if (erfolgreich)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(model);
        }
    }
}