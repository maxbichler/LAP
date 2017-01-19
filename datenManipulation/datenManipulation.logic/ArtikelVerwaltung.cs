using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datenManipulation.logic
{
    public class ArtikelVerwaltung
    {
        public static bool Anlegen(string bezeichnung, double preis, int fkKategorie)
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
                        Artikel neuerArtikel = new Artikel()
                        {
                            Bezeichnung = bezeichnung,
                            Preis = (decimal) preis,
                            ID_Kategorie = fkKategorie
                        };
                        context.AlleArtikel.Add(neuerArtikel);
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
