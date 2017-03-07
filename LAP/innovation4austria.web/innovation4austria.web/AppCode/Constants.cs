using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace innovation4austria.web.AppCode
{
    public class Constants
    {
        public class Messages
        {
            public const string WARNING = "warning";
            public const string ERROR = "error";
            public const string SUCCESS = "success";
            public const string SaveSuccess = "Ihre Änderungen wurden erfolgreich gespeichert!";
            public const string SaveError = "Fehler beim Speichern Ihrer Änderungen!";
            public const string ProfileDataInvalid = "Ungültige Daten beim Ändern Ihres Profils!";
            public const string ProfilePassInvalid = "Ungültige Daten beim Ändern Ihres Passworts!";
            public const string CompanyDataInvalid = "Firmen Daten ungültig!";
        }

        public class Roles
        {
            public const string INNOVATION4AUSTRIA = "innovation4austria";
            public const string STARTUP = "startup";
        }
    }
}