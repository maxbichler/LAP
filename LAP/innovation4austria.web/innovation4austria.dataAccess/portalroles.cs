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
    
    public partial class portalroles
    {
        public portalroles()
        {
            this.portalusers = new HashSet<portalusers>();
        }
    
        public int id { get; set; }
        public string description { get; set; }
    
        public virtual ICollection<portalusers> portalusers { get; set; }
    }
}