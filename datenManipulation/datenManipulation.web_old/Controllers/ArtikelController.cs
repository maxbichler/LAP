using datenManipulation.logic;
using datenManipulation.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace datenManipulation.web.Controllers
{
    public class ArtikelController : Controller
    {
        [HttpGet]
        public ActionResult Anlegen()
        {
            /// lade alle kategorien aus der datenbank
            List<Kategorie> alleKategorien = KategorieVerwaltung.Laden();
            /// erzeuge eine leere Liste von KategorieAnzeigeModel für die Oberfläche
            List<KategorieAnzeigeModel> alleAnzeigeKategorien = new List<KategorieAnzeigeModel>();

            /// übertrage alle Werte von den DB Objekten in die Model-Objekte
            foreach (var kategorie in alleKategorien)
            {
                alleAnzeigeKategorien.Add(new KategorieAnzeigeModel()
                {
                    ID = kategorie.ID,
                    Bezeichnung = kategorie.Bezeichnung
                });
            }

            ArtikelAnlegenModel model = new ArtikelAnlegenModel();
            model.AlleKategorien = alleAnzeigeKategorien;

            return View(model);
        }

        [HttpPost]
        public ActionResult Anlegen(ArtikelAnlegenModel model)
        {
            if (ModelState.IsValid)
            {
                bool erfolgreich = ArtikelVerwaltung.Anlegen(model.Bezeichnung, model.Preis, model.ID_Kategorie);

                if (erfolgreich)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Anlegen");
        }
    }
}