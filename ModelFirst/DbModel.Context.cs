﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ModelFirst
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CalaTestEntities : DbContext
    {
        public CalaTestEntities()
            : base("name=CalaTestEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Comanda> Comandas { get; set; }
        public virtual DbSet<ComandaDetalle> ComandaDetalles { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
    }
}
