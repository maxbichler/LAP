using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace log4net.demo
{
    public class BenutzerVerwaltung
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static bool Anmelden()
        {
            log.Info("Anmelden()");
            return true;

        }
        public static bool Abmelden()
        {
            log.Info("Abmelden()");
            return true;
        
        }

        public static List<Benutzer> Laden()
        {
            log.Info("Laden()");
            List<Benutzer> alleBenutzer = new List<Benutzer>();
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    alleBenutzer.Add(new Benutzer()
                    {
                        Vorname = "max" + i,
                        Nachname = "muster" + i
                    });
                }
            }
            catch (Exception ex)
            {
                log.Error("Fehler in Laden()", ex);

                if (ex.InnerException!=null)
                {
                    log.Error("Fehler in Laden() - (inner)", ex.InnerException);
                }
            }
            
          
            return alleBenutzer;
        }
    }

    public class Benutzer
    {
        public string Vorname { get; set; }

        public string Nachname { get; set; }
    }
}

