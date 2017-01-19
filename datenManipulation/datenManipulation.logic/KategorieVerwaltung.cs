using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datenManipulation.logic
{
    public class KategorieVerwaltung
    {

        public static List<Kategorie> Laden()
        {
            List<Kategorie> alleKategorien = null;

            try
            {
                using (var context = new dbTestITIN20Entities())
                {
                    alleKategorien = context.AlleKategorien.ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return alleKategorien;
        }

        public static bool Anlegen(string bezeichnung)
        {
            bool erfolgreich = false;

            if (string.IsNullOrEmpty(bezeichnung))
            {
                throw new ArgumentNullException(nameof(bezeichnung));
            }
            else
            {
                try
                {
                    using (var context = new dbTestITIN20Entities())
                    {
                        Kategorie neueKategorie = new Kategorie()
                        {
                            Bezeichnung = bezeichnung
                        };
                        context.AlleKategorien.Add(neueKategorie);
                        int betroffeneZeilen = context.SaveChanges();

                        erfolgreich = betroffeneZeilen > 0;
                    }
                }
                catch (Exception ex)
                {
                    // protokolliere Fehler

                    throw;
                }
            }

            return erfolgreich;
        }
    }
}
