﻿

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
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


public partial class ITIN20LAPEntities : DbContext
{
    public ITIN20LAPEntities()
        : base("name=ITIN20LAPEntities")
    {

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }


    public DbSet<billdetails> billdetails { get; set; }

    public DbSet<bills> bills { get; set; }

    public DbSet<bookingreversals> bookingreversals { get; set; }

    public DbSet<bookings> bookings { get; set; }

    public DbSet<companies> companies { get; set; }

    public DbSet<contacts> contacts { get; set; }

    public DbSet<facilities> facilities { get; set; }

    public DbSet<furnishings> furnishings { get; set; }

    public DbSet<portalroles> portalroles { get; set; }

    public DbSet<portalusers> portalusers { get; set; }

    public DbSet<rooms> rooms { get; set; }

    public DbSet<Log> Log { get; set; }

    public DbSet<roomfurnishings> roomfurnishings { get; set; }

}

}

