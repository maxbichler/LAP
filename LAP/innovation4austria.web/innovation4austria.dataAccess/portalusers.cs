//------------------------------------------------------------------------------
// <auto-generated>
//    Dieser Code wurde aus einer Vorlage generiert.
//
//    Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten Ihrer Anwendung.
//    Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace innovation4austria.dataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class portalusers
    {
        public portalusers()
        {
            this.bookingreversals = new HashSet<bookingreversals>();
            this.contacts = new HashSet<contacts>();
        }
    
        public int id { get; set; }
        public int role_id { get; set; }
        public int company_id { get; set; }
        public string email { get; set; }
        public byte[] password { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public bool active { get; set; }
    
        public virtual ICollection<bookingreversals> bookingreversals { get; set; }
        public virtual companies companies { get; set; }
        public virtual portalroles portalroles { get; set; }
        public virtual ICollection<contacts> contacts { get; set; }
    }
}
