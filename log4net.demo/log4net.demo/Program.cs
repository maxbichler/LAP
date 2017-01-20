using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using log4net;
using log4net.Config;

namespace log4net.demo
{
    class Program
    {
        static void Main(string[] args)
        {
            /// die Einstellungen aus dem Config-File
            /// sollen für log4net übernommen werden!
            XmlConfigurator.Configure();

            /// erzeuge einen Log-Manager
            ///     Name beliebig - sinnvoll wäre natürlich ein sprechender zb. Klassen-Name
            ILog log = LogManager.GetLogger("hallo Welt");

            /// Prokotolliere einen Eintrag vom Level
            ///     Debug
            ///     Info
            ///     Warn
            ///     Error
            log.Debug("debug meldung");

            log.Info("info meldung");

            log.Warn("warn meldung");

            log.Error("error meldung");

            /// Fake-Aufrufe um Protokollierung aus diesen Methoden einzusehene
            BenutzerVerwaltung.Anmelden();
            BenutzerVerwaltung.Abmelden();
            BenutzerVerwaltung.Laden();
        }

        
    }
}
