﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace iComercio.DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ComerFinanEntities : DbContext
    {
        public ComerFinanEntities()
            : base("name=ComerFinanEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Bajas> Bajas { get; set; }
        public virtual DbSet<Notas> Notas { get; set; }
        public virtual DbSet<RefiBaja> RefiBaja { get; set; }
        public virtual DbSet<RefiCobra> RefiCobra { get; set; }
        public virtual DbSet<RefiCuotas> RefiCuotas { get; set; }
        public virtual DbSet<Refinan> Refinan { get; set; }
        public virtual DbSet<CobranzasANT> Cobranzas { get; set; }
        public virtual DbSet<CreditosANT> Creditos { get; set; }
        public virtual DbSet<CuotasANT> Cuotas { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
    }
}
