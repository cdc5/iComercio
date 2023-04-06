using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using iComercio.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;

namespace iComercio.DAL
{
   public class ComercioContext:DbContext
    {
         public ComercioContext() : base()
         {
             
         }

         public ComercioContext(string Base)
            : base("name=" + Base)
        {
            var adapter = (IObjectContextAdapter)this;
            var objectContext = adapter.ObjectContext;
            objectContext.CommandTimeout = 240; //2 minutes
           // Database.SetInitializer<ComercioContext>(null);
        }

         public DbSet<Banco> Bancos { get; set; }
         public DbSet<Cargo> Cargos { get; set; }
         public DbSet<Cheque> Cheques { get; set; }
         public DbSet<Chequera> Chequera { get; set; }
         public DbSet<ClaseCuentaBancaria> ClaseCuentasBancarias { get; set; }
         public DbSet<Comercio> Comercios { get; set; }
         public DbSet<ConceptoFondos> ConceptoFondos { get; set; }
         public DbSet<ConceptoGastosProveedor> ConceptoGastoProveedores { get; set; }
         public DbSet<ConceptoGastos> ConceptoGastos { get; set; }
         public DbSet<ConceptoGastosDepartamento> ConceptoGastosDepartamentos { get; set; }
         public DbSet<CuentaBancaria> CuentasBancarias { get; set; }
         public DbSet<Departamento> Departamentos { get; set; }
         public DbSet<Empleado> Empleados { get; set; }
         public DbSet<Empresa> Empresas { get; set; }
         public DbSet<Estado> Estados { get; set; }
         public DbSet<Localidad> Localidades { get; set; }
         public DbSet<MedioDePago> MediosDePagos { get; set; }
         public DbSet<Moneda> Monedas { get; set; }
         public DbSet<OrdenDePago> OrdenesDePago { get; set; }
         public DbSet<Pais> Paises { get; set; }
         public DbSet<Perfil> Perfiles { get; set; }
         public DbSet<Permiso> Permisos { get; set; }
         public DbSet<Persona> Personas { get; set; }
         public DbSet<Proveedor> Proveedores { get; set; }
         public DbSet<ProveedorSucursal> ProveedoresSucursales { get; set; }
         public DbSet<Provincia> Provincias { get; set; }  
         public DbSet<SolicitudFondo> SolicitudFondos { get; set; }
         public DbSet<SucursalBanco> SucursalesBancos { get; set; }
         public DbSet<TipoCheque> TiposCheques { get; set; }
         public DbSet<TipoComercio> TiposComercios { get; set; }
         public DbSet<TipoCuentaBancaria> TiposCuentasBancarias { get; set; }
         public DbSet<TipoEmpleado> TiposEmpleados { get; set; }
         public DbSet<TipoEstado> TiposEstados { get; set; }
         public DbSet<TipoDocumento> TiposDocumento { get; set; }
         public DbSet<TipoSolicitud> TiposSolicitud { get; set; }
         public DbSet<TransferenciasDepositos> TransferenciasDepositos { get; set; }
         public DbSet<Usuario> Usuarios { get; set; }
         public DbSet<Transmision> Transmisiones { get; set; }
         public DbSet<EstadoTransmision> EstadoTransmisiones { get; set; }
         public DbSet<Operacion> Operaciones { get; set; }
         public DbSet<Autorizacion> Autorizaciones { get; set; }
         public DbSet<Credito> Creditos { get; set; }
         public DbSet<Cuota> Cuotas { get; set; }
         public DbSet<Cobranza> Cobranzas { get; set; }
         public DbSet<ClaseMovimiento> ClasesMovimientos { get; set; }
         public DbSet<TipoMovimiento> TiposMovimientos { get; set; }
         public DbSet<CuentaCorriente> CuentaCorriente { get; set; }
         public DbSet<Profesion> Profesiones { get; set; }
         public DbSet<Sexo> Sexos { get; set; }
         public DbSet<Cliente> Clientes { get; set; }
         public DbSet<ClaseDato> ClasesDato { get; set; }
         public DbSet<TipoComoConocio> TipoComoConocio { get; set; }
         public DbSet<TipoAval> TipoAval { get; set; }
         public DbSet<TipoBonificacion> TipoBonificacion { get; set; }  
         public DbSet<TipoRetencionPlan> TipoRetencionPlan { get; set; }
         public DbSet<TipoCuota> TipoCuota { get; set; }
         public DbSet<TipoPago> TipoPago { get; set; }
         public DbSet<Refinanciacion> Refinanciaciones { get; set; }
         public DbSet<TipoImpresion> TipoImpresion { get; set; }
         public DbSet<CreditoAnulado> CreditoAnulado { get; set; }
         public DbSet<TipoAnulacion> TipoAnulacion { get; set; }
         public DbSet<Recibo> Recibo { get; set; }
         public DbSet<AvisoDePago> AvisoDePago { get; set; }
         public DbSet<NotasCD> NotasCD { get; set; }
         public DbSet<CuentaCorrienteCorte> CorteCuentaCorriente { get; set; }
         public DbSet<TipoTransferenciaDeposito> TipoTransferenciaDeposito { get; set; }
         public DbSet<Nota> Nota { get; set; }
         public DbSet<Telefono> Telefono { get; set; }
         public DbSet<TipoImagen> TipoImagen { get; set; }
         public DbSet<CuentaBancariaCliente> CuentaBancariaCliente { get; set; }
         public DbSet<Log> Logs { get; set; }
       
         protected override void OnModelCreating(DbModelBuilder modelBuilder)
         {
             modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
             
             /* Empresa */
             modelBuilder.Entity<Empresa>().HasKey(e => new { e.EmpresaID });
             modelBuilder.Entity<Empresa>().Property(e => e.EmpresaID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
             modelBuilder.Entity<Empresa>().HasMany(c => c.CuentasBancarias).WithRequired(e => e.Empresa).HasForeignKey(e=> e.EmpresaID);

             /* Cliente */
             modelBuilder.Entity<Cliente>().HasKey(c => new { c.Documento, c.TipoDocumentoID});
             modelBuilder.Entity<Cliente>().HasOptional(c => c.UsuarioModificacion).WithMany().HasForeignKey(c => c.UsuarioModificacionID).WillCascadeOnDelete(false);
             modelBuilder.Entity<Cliente>().HasMany(c => c.Notas).WithOptional().HasForeignKey(c => new { c.Documento,c.TipoDocumentoID });
             modelBuilder.Entity<Cliente>().Property(c => c.FechaAlta).HasColumnType("datetime2");
             modelBuilder.Entity<Cliente>().Property(c => c.FechaAltaTarjeta).HasColumnType("datetime2");
             modelBuilder.Entity<Cliente>().Property(c => c.FechaModificacion).HasColumnType("datetime2");
             modelBuilder.Entity<Cliente>().Property(c => c.FechaNacimiento).HasColumnType("datetime2");
             modelBuilder.Entity<Cliente>().Property(c => c.FechaVencimientoTarjeta).HasColumnType("datetime2");


             modelBuilder.Entity<Cliente>().HasMany(c => c.Creditos).WithRequired(c => c.Cliente).HasForeignKey(c => new { c.Documento, c.TipoDocumentoID }).WillCascadeOnDelete(false); ;
             modelBuilder.Entity<Cliente>().HasMany(c => c.CreditosGar1).WithOptional().HasForeignKey(c => new { c.Garante1, c.TipoDocumentoIDG1 }).WillCascadeOnDelete(false); ;
             modelBuilder.Entity<Cliente>().HasMany(c => c.CreditosGar2).WithOptional().HasForeignKey(c => new { c.Garante2, c.TipoDocumentoIDG2 }).WillCascadeOnDelete(false); ;
             modelBuilder.Entity<Cliente>().HasMany(c => c.CreditosGar3).WithOptional().HasForeignKey(c => new { c.Garante3, c.TipoDocumentoIDG3 }).WillCascadeOnDelete(false); ;
             modelBuilder.Entity<Cliente>().HasMany(c => c.CreditosAdi).WithOptional().HasForeignKey(c => new { c.Adicional, c.TipoDocumentoIDAdi }).WillCascadeOnDelete(false); ;
             modelBuilder.Entity<Cliente>().HasMany(c => c.Refinanciaciones).WithRequired(c => c.Cliente).HasForeignKey(c => new { c.Documento, c.TipoDocumentoID }).WillCascadeOnDelete(false); ;
             modelBuilder.Entity<Cliente>().HasMany(c => c.Mails).WithRequired(c => c.Cliente).HasForeignKey(c => new { c.Documento, c.TipoDocumentoID }).WillCascadeOnDelete(false); ;

             modelBuilder.Entity<Cliente>().HasMany(c => c.CuentasBancariasCliente).WithRequired(c => c.Cliente).HasForeignKey(c => new { c.Documento, c.TipoDocumentoID }).WillCascadeOnDelete(false); 

             modelBuilder.Entity<Cliente>().Ignore(p => p.UltimoDomicilioCliente);
             modelBuilder.Entity<Cliente>().Ignore(p => p.UltimoDomicilioEmpresa);
             modelBuilder.Entity<Cliente>().Ignore(p => p.UltimoTelefonoCliente);
             modelBuilder.Entity<Cliente>().Ignore(p => p.UltimoTelefonoEmpresa);
             modelBuilder.Entity<Cliente>().Ignore(p => p.UltimoMailCliente);
             modelBuilder.Entity<Cliente>().Ignore(p => p.UltimoMailEmpresa);
            modelBuilder.Entity<Cliente>().Ignore(p => p.UltimaNota);

            //Sql("ALTER TABLE dbo.Cuota ADD Deuda AS Importe - ImportePago ");  
            /* Notas */
            modelBuilder.Entity<Nota>().HasKey(c => c.NotaID);

             /* Aviso de pago */
             modelBuilder.Entity<AvisoDePago>().HasKey(a => new { a.EmpresaID, a.ComercioID,a.AvisoDePagoID });
             modelBuilder.Entity<AvisoDePago>().HasMany(a => a.Creditos).WithOptional().HasForeignKey(c => new { c.EmpresaID, c.ComercioID,c.AvisoDePagoID }).WillCascadeOnDelete(false);
             
             /* CuentaCorrienteCorte */
             modelBuilder.Entity<CuentaCorrienteCorte>().HasKey(c => new { c.EmpresaID, c.ComercioID, c.CuentaCorrienteCorteID });
             modelBuilder.Entity<CuentaCorrienteCorte>().Property(c => c.CuentaCorrienteCorteID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
             
                             
             /* Comercio */
             modelBuilder.Entity<Comercio>().HasKey(c => new { c.EmpresaID, c.ComercioID });
             modelBuilder.Entity<Comercio>().HasRequired(c => c.Empresa).WithMany().HasForeignKey(c => c.EmpresaID).WillCascadeOnDelete(false);
             modelBuilder.Entity<Comercio>().Property(c => c.ComercioID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
             modelBuilder.Entity<Comercio>().Property(c => c.EmpresaID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
             modelBuilder.Entity<Comercio>().Property(c => c.Por30).HasPrecision(19, 4);
             modelBuilder.Entity<Comercio>().Property(c => c.Por30M).HasPrecision(19, 4);
             modelBuilder.Entity<Comercio>().Ignore(p => p.NumeroYNombre);
          
             /* Creditos */
             modelBuilder.Entity<Credito>().HasKey(c => new { c.EmpresaID, c.ComercioID, c.CreditoID });
             modelBuilder.Entity<Credito>().HasRequired(c => c.Empresa).WithMany().HasForeignKey(c => c.EmpresaID).WillCascadeOnDelete(false);
             modelBuilder.Entity<Credito>().HasRequired(c => c.Comercio).WithMany().HasForeignKey(c => new { c.EmpresaID, c.ComercioID }).WillCascadeOnDelete(false);
             modelBuilder.Entity<Credito>().HasRequired(c => c.Cliente).WithMany().HasForeignKey(c => new { c.Documento, c.TipoDocumentoID }).WillCascadeOnDelete(false);
             modelBuilder.Entity<Credito>().HasRequired(c => c.Usuario).WithMany().HasForeignKey(c => c.UsuarioID).WillCascadeOnDelete(false);
             //modelBuilder.Entity<Credito>().HasMany(c => c.Avales).WithMany();
                        
                          
             //modelBuilder.Entity<Credito>().HasOptional(c => c.Refinanciacion).WithRequired(c => c.Credito).WillCascadeOnDelete(false);
             modelBuilder.Entity<Credito>().HasOptional(c => c.Abogado).WithMany().HasForeignKey(c => new { c.EmpresaID, c.AbogadoID }).WillCascadeOnDelete(false);
             modelBuilder.Entity<Credito>().HasOptional(c => c.UsuarioAval).WithMany().HasForeignKey(c => c.usuarioAvalID).WillCascadeOnDelete(false);

             modelBuilder.Entity<Credito>().HasOptional(c => c.Gar1).WithMany().HasForeignKey(c => new { c.Garante1, c.TipoDocumentoIDG1 }).WillCascadeOnDelete(false);
             modelBuilder.Entity<Credito>().HasOptional(c => c.Gar2).WithMany().HasForeignKey(c => new { c.Garante2, c.TipoDocumentoIDG2 }).WillCascadeOnDelete(false);
             modelBuilder.Entity<Credito>().HasOptional(c => c.Gar3).WithMany().HasForeignKey(c => new { c.Garante3, c.TipoDocumentoIDG3 }).WillCascadeOnDelete(false);
             modelBuilder.Entity<Credito>().HasOptional(c => c.Adi).WithMany().HasForeignKey(c => new { c.Adicional, c.TipoDocumentoIDAdi }).WillCascadeOnDelete(false);
                         
             
             modelBuilder.Entity<Credito>().Property(c => c.FechaAbogado).HasColumnType("datetime2");
             modelBuilder.Entity<Credito>().Property(c => c.FechaComer).HasColumnType("datetime2");
             modelBuilder.Entity<Credito>().Property(c => c.FechaSolicitud).HasColumnType("datetime2");
             modelBuilder.Entity<Credito>().Property(c => c.FechaAviso).HasColumnType("datetime2");
             modelBuilder.Entity<Credito>().Property(c => c.Comision).HasPrecision(19, 2);
             modelBuilder.Entity<Credito>().Property(c => c.ComisionIncrementoPlan).HasPrecision(19, 2);
             modelBuilder.Entity<Credito>().Property(c => c.ComisionPlan).HasPrecision(19, 2);
             modelBuilder.Entity<Credito>().Property(c => c.Gasto).HasPrecision(19, 2);
             modelBuilder.Entity<Credito>().Property(c => c.GastoPlan).HasPrecision(19, 2);
             modelBuilder.Entity<Credito>().Property(c => c.GastoIncrementoPlan).HasPrecision(19, 2);
             modelBuilder.Entity<Credito>().Property(c => c.IncrementoPlan).HasPrecision(19, 2);
             modelBuilder.Entity<Credito>().Property(c => c.TasaPlan).HasPrecision(19, 2);
             modelBuilder.Entity<Credito>().Property(c => c.ValorCuota).HasPrecision(19, 2);
             modelBuilder.Entity<Credito>().Property(c => c.ValorNominal).HasPrecision(19, 2);
             modelBuilder.Entity<Credito>().Property(c => c.Interes).HasPrecision(19, 2);
             modelBuilder.Entity<Credito>().Property(c => c.PorcentajeBonificacion).HasPrecision(19, 2);
             modelBuilder.Entity<Credito>().Property(c => c.Total).HasPrecision(19, 2);
             modelBuilder.Entity<Credito>().Property(c => c.NombrePlan).HasMaxLength(50);
             modelBuilder.Entity<Credito>().Property(c => c.FechaDesdeDebito).HasColumnType("datetime2");
             modelBuilder.Entity<Credito>().Ignore(p => p.sTotal);
             modelBuilder.Entity<Credito>().Ignore(p => p.sAdelantadaGastos);


            /*Credito Anulado */
            modelBuilder.Entity<CreditoAnulado>().HasKey(c => new { c.EmpresaID, c.ComercioID, c.CreditoAnuladoID });
             modelBuilder.Entity<CreditoAnulado>().Property(c => c.CreditoAnuladoID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
             modelBuilder.Entity<CreditoAnulado>().HasRequired(c => c.Empresa).WithMany().HasForeignKey(c => c.EmpresaID).WillCascadeOnDelete(false);
             modelBuilder.Entity<CreditoAnulado>().HasRequired(c => c.Comercio).WithMany().HasForeignKey(c => new { c.EmpresaID, c.ComercioID }).WillCascadeOnDelete(false);
             modelBuilder.Entity<CreditoAnulado>().HasRequired(c => c.Cliente).WithMany().HasForeignKey(c => new { c.Documento, c.TipoDocumentoID }).WillCascadeOnDelete(false);
             modelBuilder.Entity<CreditoAnulado>().HasRequired(c => c.Usuario).WithMany().HasForeignKey(c => c.UsuarioID).WillCascadeOnDelete(false);

             modelBuilder.Entity<CreditoAnulado>().Property(c => c.FechaAbogado).HasColumnType("datetime2");
             modelBuilder.Entity<CreditoAnulado>().Property(c => c.FechaComer).HasColumnType("datetime2");
             modelBuilder.Entity<CreditoAnulado>().Property(c => c.FechaComercioAnula).HasColumnType("datetime2");
             modelBuilder.Entity<CreditoAnulado>().Property(c => c.FechaSolicitud).HasColumnType("datetime2");
             modelBuilder.Entity<CreditoAnulado>().Property(c => c.FechaAviso).HasColumnType("datetime2");
             modelBuilder.Entity<CreditoAnulado>().Property(c => c.Comision).HasPrecision(19, 2);
             modelBuilder.Entity<CreditoAnulado>().Property(c => c.ComisionIncrementoPlan).HasPrecision(19, 2);
             modelBuilder.Entity<CreditoAnulado>().Property(c => c.ComisionPlan).HasPrecision(19, 2);
             modelBuilder.Entity<CreditoAnulado>().Property(c => c.Gasto).HasPrecision(19, 2);
             modelBuilder.Entity<CreditoAnulado>().Property(c => c.GastoPlan).HasPrecision(19, 2);
             modelBuilder.Entity<CreditoAnulado>().Property(c => c.GastoIncrementoPlan).HasPrecision(19, 2);
             modelBuilder.Entity<CreditoAnulado>().Property(c => c.IncrementoPlan).HasPrecision(19, 2);
             modelBuilder.Entity<CreditoAnulado>().Property(c => c.TasaPlan).HasPrecision(19, 2);
             modelBuilder.Entity<CreditoAnulado>().Property(c => c.ValorCuota).HasPrecision(19, 2);
             modelBuilder.Entity<CreditoAnulado>().Property(c => c.ValorNominal).HasPrecision(19, 2);
             modelBuilder.Entity<CreditoAnulado>().Property(c => c.Interes).HasPrecision(19, 2);
             modelBuilder.Entity<CreditoAnulado>().Property(c => c.PorcentajeBonificacion).HasPrecision(19, 2);
             modelBuilder.Entity<CreditoAnulado>().Property(c => c.Motivo).HasMaxLength(250);
             modelBuilder.Entity<CreditoAnulado>().Property(c => c.NombrePlan).HasMaxLength(50);
             modelBuilder.Entity<CreditoAnulado>().Property(c => c.FechaDesdeDebito).HasColumnType("datetime2");

             /* Cuotas */
             modelBuilder.Entity<Cuota>().HasKey(c => new { c.EmpresaID, c.ComercioID, c.CreditoID, c.CuotaID });
             modelBuilder.Entity<Cuota>().HasRequired(c => c.Credito).WithMany(c => c.Cuotas).HasForeignKey(c => new { c.EmpresaID, c.ComercioID, c.CreditoID }).WillCascadeOnDelete(false);
             modelBuilder.Entity<Cuota>().HasRequired(c => c.Comercio).WithMany().HasForeignKey(c => new { c.EmpresaID, c.ComercioID }).WillCascadeOnDelete(false);
             modelBuilder.Entity<Cuota>().HasRequired(c => c.Empresa).WithMany().HasForeignKey(c => c.EmpresaID).WillCascadeOnDelete(false);
             modelBuilder.Entity<Cuota>().HasRequired(c => c.Cliente).WithMany().HasForeignKey(c => new { c.Documento, c.TipoDocumentoID }).WillCascadeOnDelete(false);
             modelBuilder.Entity<Cuota>().Property(c => c.FechaUltimoPago).HasColumnType("datetime2");
             modelBuilder.Entity<Cuota>().Property(c => c.FechaVencimiento).HasColumnType("datetime2");
             modelBuilder.Entity<Cuota>().Property(c => c.Deuda).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
             //modelBuilder.Entity<Cuota>().Property(c => c.Deuda).HasColumnAnnotation<(DatabaseGeneratedOption.Computed);
              //modelBuilder.Entity<Class>().Property(object => object.property).HasPrecision(12, 10);

             modelBuilder.Entity<Cuota>().Property(c => c.Importe).HasPrecision(19, 2);
             modelBuilder.Entity<Cuota>().Property(c => c.ImportePago).HasPrecision(19, 2);
             modelBuilder.Entity<Cuota>().Property(c => c.ImportePagoPunitorios).HasPrecision(19, 2);
             modelBuilder.Entity<Cuota>().Property(c => c.Interes).HasPrecision(19, 2);
             //modelBuilder.Entity<Cuota>().Property(c => c.PorcentajeBonificacion).HasPrecision(19, 2);
             modelBuilder.Entity<Cuota>().Property(c => c.ValorBonificacion).HasPrecision(19, 2);  //***edu***
             //modelBuilder.Entity<Cuota>().Property(c => c.Deuda).HasPrecision(19, 2);
             



             /* Cobranzas */
             modelBuilder.Entity<Cobranza>().HasKey(c => new { c.EmpresaID, c.ComercioID, c.CreditoID, c.CuotaID, c.CobranzaID });
             modelBuilder.Entity<Cobranza>().HasRequired(c => c.Credito).WithMany(c=>c.Cobranzas).HasForeignKey(c => new { c.EmpresaID, c.ComercioID, c.CreditoID }).WillCascadeOnDelete(false);
             modelBuilder.Entity<Cobranza>().HasRequired(c => c.Cuota).WithMany(c => c.Cobranzas).HasForeignKey(c => new { c.EmpresaID, c.ComercioID, c.CreditoID, c.CuotaID }).WillCascadeOnDelete(false);
             modelBuilder.Entity<Cobranza>().HasRequired(c => c.Comercio).WithMany().HasForeignKey(c => new { c.EmpresaID, c.ComercioID }).WillCascadeOnDelete(false);
             modelBuilder.Entity<Cobranza>().HasRequired(c => c.Empresa).WithMany().HasForeignKey(c => c.EmpresaID).WillCascadeOnDelete(false);
             modelBuilder.Entity<Cobranza>().HasRequired(c => c.Cliente).WithMany().HasForeignKey(c => new { c.Documento, c.TipoDocumentoID }).WillCascadeOnDelete(false);
             

             modelBuilder.Entity<Cobranza>().HasRequired(c => c.Gestion).WithMany().HasForeignKey(c => new { c.EmpresaID, c.ComercioID }).WillCascadeOnDelete(false);
             modelBuilder.Entity<Cobranza>().HasMany(c => c.NotasCD).WithRequired(c=>c.Cobranza).WillCascadeOnDelete(false);
             
             modelBuilder.Entity<Cobranza>().Property(c => c.FechaPago).HasColumnType("datetime2");
             modelBuilder.Entity<Cobranza>().Property(c => c.FechaRev).HasColumnType("datetime2");
             modelBuilder.Entity<Cobranza>().Property(c => c.FechaVencimiento).HasColumnType("datetime2");

             modelBuilder.Entity<Cobranza>().Property(c => c.ImportePago).HasPrecision(19, 2);
             modelBuilder.Entity<Cobranza>().Property(c => c.ImportePagoPunitorios).HasPrecision(19, 2);
             modelBuilder.Entity<Cobranza>().Property(c => c.Interes).HasPrecision(19, 2);
             modelBuilder.Entity<Cobranza>().Property(c => c.PorcentajeBonificacion).HasPrecision(19, 2);
             modelBuilder.Entity<Cobranza>().Property(c => c.PunitoriosCalc).HasPrecision(19, 2);

           

             /* Refinanciacion */
             modelBuilder.Entity<Refinanciacion>().HasKey(c => new { c.EmpresaID, c.ComercioID,c.CreditoID, c.RefinanciacionID });
             //***edu
             modelBuilder.Entity<Refinanciacion>().HasRequired(c => c.Credito).WithMany(c => c.Refinanciaciones).HasForeignKey(c => new { c.EmpresaID, c.ComercioID, c.CreditoID }).WillCascadeOnDelete(false);
             modelBuilder.Entity<Refinanciacion>().HasRequired(c => c.Usuario).WithMany().HasForeignKey(c => c.UsuarioID).WillCascadeOnDelete(false);
             // evita el refinan_cred etc
             //***edu
             modelBuilder.Entity<Refinanciacion>().HasRequired(c => c.Comercio).WithMany().HasForeignKey(c => new { c.EmpresaID, c.ComercioID }).WillCascadeOnDelete(false);
             modelBuilder.Entity<Refinanciacion>().HasRequired(c => c.Empresa).WithMany().HasForeignKey(c => c.EmpresaID).WillCascadeOnDelete(false);
             modelBuilder.Entity<Refinanciacion>().HasRequired(c => c.Cliente).WithMany().HasForeignKey(c => new { c.Documento, c.TipoDocumentoID }).WillCascadeOnDelete(false);
            // modelBuilder.Entity<Refinanciacion>().Property(c => c.FechaComer).HasColumnType("datetime2");
             modelBuilder.Entity<Refinanciacion>().Property(c => c.FechaSolicitud).HasColumnType("datetime2");
             modelBuilder.Entity<Refinanciacion>().Property(c => c.FechaComerAnula).HasColumnType("datetime2");


             //modelBuilder.Entity<Refinanciacion>().Property(c => c.Comision).HasPrecision(19, 2);
             //modelBuilder.Entity<Refinanciacion>().Property(c => c.Gasto).HasPrecision(19, 2);
             modelBuilder.Entity<Refinanciacion>().Property(c => c.Interes).HasPrecision(19, 2);
             modelBuilder.Entity<Refinanciacion>().Property(c => c.ValorCuota).HasPrecision(19, 2);
             modelBuilder.Entity<Refinanciacion>().Property(c => c.ValorNominal).HasPrecision(19, 2);

             /* RefinanciacionCuota */
             modelBuilder.Entity<RefinanciacionCuota>().HasKey(c => new { c.EmpresaID, c.ComercioID,c.CreditoID, c.RefinanciacionID, c.RefinanciacionCuotaID });
             modelBuilder.Entity<RefinanciacionCuota>().HasRequired(c => c.Refinanciacion).WithMany(c => c.RefinanciacionCuotas).HasForeignKey(c => new { c.EmpresaID, c.ComercioID, c.CreditoID, c.RefinanciacionID }).WillCascadeOnDelete(false);
             modelBuilder.Entity<RefinanciacionCuota>().HasRequired(c => c.Comercio).WithMany().HasForeignKey(c => new { c.EmpresaID, c.ComercioID }).WillCascadeOnDelete(false);
             modelBuilder.Entity<RefinanciacionCuota>().HasRequired(c => c.Empresa).WithMany().HasForeignKey(c => c.EmpresaID).WillCascadeOnDelete(false);
             modelBuilder.Entity<RefinanciacionCuota>().HasRequired(c => c.Cliente).WithMany().HasForeignKey(c => new { c.Documento, c.TipoDocumentoID }).WillCascadeOnDelete(false);
             modelBuilder.Entity<RefinanciacionCuota>().Property(c => c.Deuda).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
             //modelBuilder.Entity<RefinanciacionCuota>().HasRequired(c => c.Refinanciacion).WithMany().HasForeignKey(c => new { c.EmpresaID, c.ComercioID, c.CreditoID,c.RefinanciacionID }).WillCascadeOnDelete(false);
             //modelBuilder.Entity<RefinanciacionCuota>().HasRequired(c => c.Refinanciacion).WithMany(c => c.RefinanciacionCuotas).HasForeignKey(c => new { c.EmpresaID, c.ComercioID, c.CreditoID, c.RefinanciacionID }).WillCascadeOnDelete(false);
             
             modelBuilder.Entity<RefinanciacionCuota>().Property(c => c.FechaUltimoPago).HasColumnType("datetime2");
             modelBuilder.Entity<RefinanciacionCuota>().Property(c => c.FechaVencimiento).HasColumnType("datetime2");
             modelBuilder.Entity<RefinanciacionCuota>().Property(c => c.Importe).HasPrecision(19, 2);
             modelBuilder.Entity<RefinanciacionCuota>().Property(c => c.ImportePago).HasPrecision(19, 2);
             modelBuilder.Entity<RefinanciacionCuota>().Property(c => c.ImportePagoPunitorios).HasPrecision(19, 2);

            // modelBuilder.Entity<RefinanciacionCuota>().Property(c => c.Interes).HasPrecision(19, 4);
            

             /* RefinanciacionCobranza */
             modelBuilder.Entity<RefinanciacionCobranza>().HasKey(c => new { c.EmpresaID, c.ComercioID,c.CreditoID, c.RefinanciacionID, c.RefinanciacionCuotaID, c.RefinanciacionCobranzaID });
             //***edu
             modelBuilder.Entity<RefinanciacionCobranza>().HasRequired(c => c.RefinanciacionCuota).WithMany(c => c.RefinanciacionesCobranzas).HasForeignKey(c => new { c.EmpresaID, c.ComercioID, c.CreditoID, c.RefinanciacionID, c.RefinanciacionCuotaID }).WillCascadeOnDelete(false);
             modelBuilder.Entity<RefinanciacionCobranza>().HasRequired(c => c.Gestion).WithMany().HasForeignKey(c => new { c.EmpresaID, c.ComercioID }).WillCascadeOnDelete(false);
             //***edu
             
             modelBuilder.Entity<RefinanciacionCobranza>().HasRequired(c => c.Comercio).WithMany().HasForeignKey(c => new { c.EmpresaID, c.ComercioID }).WillCascadeOnDelete(false);
             modelBuilder.Entity<RefinanciacionCobranza>().HasRequired(c => c.Empresa).WithMany().HasForeignKey(c => c.EmpresaID).WillCascadeOnDelete(false);
             modelBuilder.Entity<RefinanciacionCobranza>().HasRequired(c => c.Cliente).WithMany().HasForeignKey(c => new { c.Documento, c.TipoDocumentoID }).WillCascadeOnDelete(false);
             modelBuilder.Entity<RefinanciacionCobranza>().HasRequired(c => c.Refinanciacion).WithMany().HasForeignKey(c => new { c.EmpresaID, c.ComercioID,c.CreditoID, c.RefinanciacionID }).WillCascadeOnDelete(false);
             
             //modelBuilder.Entity<RefinanciacionCobranza>().HasRequired(c => c.RefinanciacionCuota).WithMany().HasForeignKey(c => new {c.EmpresaID, c.ComercioID,c.CreditoID,c.RefinanciacionID, c.RefinanciacionCuotaID }).WillCascadeOnDelete(false);
             
             modelBuilder.Entity<RefinanciacionCobranza>().Property(c => c.FechaPago).HasColumnType("datetime2");
             modelBuilder.Entity<RefinanciacionCobranza>().Property(c => c.FechaRev).HasColumnType("datetime2");
             modelBuilder.Entity<RefinanciacionCobranza>().Property(c => c.FechaVencimiento).HasColumnType("datetime2");

             modelBuilder.Entity<RefinanciacionCobranza>().Property(c => c.PunitoriosCalc).HasPrecision(19, 2);
             modelBuilder.Entity<RefinanciacionCobranza>().Property(c => c.ImportePago).HasPrecision(19, 2);
             modelBuilder.Entity<RefinanciacionCobranza>().Property(c => c.ImportePagoPunitorios).HasPrecision(19, 2);
           //  modelBuilder.Entity<RefinanciacionCobranza>().Property(c => c.Interes).HasPrecision(19, 4);


             //modelBuilder.Entity<Comercio>().HasRequired(c => c.TipoComercio);

             /* Usuario, perfil y permisos */
             modelBuilder.Entity<Usuario>().HasMany(p => p.Perfiles).WithMany(u => u.Usuarios)
                         .Map(t => t.MapLeftKey("UsuarioID").MapRightKey("PerfilID").ToTable("UsuariosPerfiles"));
             modelBuilder.Entity<Usuario>().Property(s => s.creacion).HasColumnType("datetime2");

             modelBuilder.Entity<Permiso>().HasKey(p => new { p.PermisoID });

             modelBuilder.Entity<Perfil>().HasMany(p => p.Permisos).WithMany(p => p.Perfiles)
                         .Map(t => t.MapLeftKey("PerfilID").MapRightKey("PermisoID").ToTable("PerfilesPermisos"));

             /* Banco */
             modelBuilder.Entity<Banco>().HasKey(b => b.BancoID);
             modelBuilder.Entity<Banco>().Property(c => c.BancoID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
             modelBuilder.Entity<Banco>().Ignore(p => p.sBanco);

             /*Sucursal Banco */
             modelBuilder.Entity<SucursalBanco>().HasKey(b => new { b.BancoID,b.SucursalBancoID });
             modelBuilder.Entity<SucursalBanco>().HasRequired(b => b.Banco).WithMany().HasForeignKey(s=> s.BancoID).WillCascadeOnDelete(false);
             modelBuilder.Entity<SucursalBanco>().Ignore(p => p.sBancoSucursal);

             /* Cargo */
             modelBuilder.Entity<Cargo>().HasKey(c => c.CargoId);

             /* Cuenta Bancaria Cliente */
             modelBuilder.Entity<CuentaBancariaCliente>().HasKey(c => new { c.Documento, c.TipoDocumentoID,c.NumCuentaBancaria });

             /* Cuenta Bancaria */
             modelBuilder.Entity<CuentaBancaria>().HasKey(c => new { c.EmpresaID, c.CuentaBancariaID });
             modelBuilder.Entity<CuentaBancaria>().HasMany(c => c.Chequeras).WithRequired(c => c.CuentaBancaria);
             modelBuilder.Entity<CuentaBancaria>().HasRequired(c => c.SucursalBanco);
             modelBuilder.Entity<CuentaBancaria>().HasRequired(c => c.Banco);
             modelBuilder.Entity<CuentaBancaria>().HasMany(c => c.Chequeras).WithRequired(c => c.CuentaBancaria);
             modelBuilder.Entity<CuentaBancaria>().Ignore(p => p.sCuentaBancaria);

             /* Clase Cuenta Bancaria */
             modelBuilder.Entity<ClaseCuentaBancaria>().HasKey(c => c.ClaseCuentaBancariaID);
             modelBuilder.Entity<ClaseCuentaBancaria>().Property(c => c.ClaseCuentaBancariaID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
             
             /* Tipo Cuenta Bancaria */
             modelBuilder.Entity<TipoCuentaBancaria>().HasKey(c => c.TipoCuentaBancariaID);
             modelBuilder.Entity<TipoCuentaBancaria>().Property(c => c.TipoCuentaBancariaID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

             /* Chequera */
             modelBuilder.Entity<Chequera>().HasKey(c => new { c.EmpresaID, c.CuentaBancariaID, c.ChequeraID });
             modelBuilder.Entity<Chequera>().HasRequired(c => c.CuentaBancaria);
             modelBuilder.Entity<Chequera>().HasMany(c => c.Cheques).WithRequired(c => c.Chequera);
             modelBuilder.Entity<Chequera>().Ignore(p => p.sChequera);
            
             /* Cheque */
            modelBuilder.Entity<Cheque>().HasKey(c => new {c.EmpresaID,c.CuentaBancariaID,c.ChequeraID,c.ChequeID});
            modelBuilder.Entity<Cheque>().HasRequired(c => c.Chequera);
            modelBuilder.Entity<Cheque>().Ignore(p => p.sCheque);

            /*Recibos*/
            modelBuilder.Entity<Recibo>().HasKey(s => new { s.EmpresaID, s.ComercioID, s.ReciboID });
            modelBuilder.Entity<Recibo>().HasRequired(s => s.Empresa).WithMany().HasForeignKey(s => new { s.EmpresaID }).WillCascadeOnDelete(false);
            modelBuilder.Entity<Recibo>().HasRequired(s => s.Comercio).WithMany().HasForeignKey(s => new { s.EmpresaID, s.ComercioID }).WillCascadeOnDelete(false);
            modelBuilder.Entity<Recibo>().HasOptional(s => s.ComercioAdherido).WithMany().HasForeignKey(s => new { s.ComercioAdheridoEmpresaID, s.ComercioAdheridoComercioID }).WillCascadeOnDelete(false);
            modelBuilder.Entity<Recibo>().Property(s => s.ReciboID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Recibo>().Property(s => s.Fecha).HasColumnType("datetime2");
            modelBuilder.Entity<Recibo>().Property(s => s.FechaIngreso).HasColumnType("datetime2");


            /*TransferenciasDepositos*/
            /*Buen ejemplo de configuracion */
            
            modelBuilder.Entity<TransferenciasDepositos>().HasKey(s => new { s.EmpresaID, s.TransferenciasDepositosID });
            modelBuilder.Entity<TransferenciasDepositos>().HasRequired(s => s.Empresa).WithMany().HasForeignKey(s => new { s.EmpresaID }).WillCascadeOnDelete(false);
            modelBuilder.Entity<TransferenciasDepositos>().Property(s => s.TransferenciasDepositosID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<TransferenciasDepositos>().Property(s => s.Fecha).HasColumnType("datetime2");
            modelBuilder.Entity<TransferenciasDepositos>().HasOptional(c => c.CuentaOrigen).WithMany().HasForeignKey(t => new { t.CuentaOrigenEmpresaID,t.CuentaOrigenCbID }).WillCascadeOnDelete(false);
            modelBuilder.Entity<TransferenciasDepositos>().HasOptional(c => c.CuentaDestino).WithMany().HasForeignKey(t => new { t.CuentaDestinoEmpresaID, t.CuentaDestinoCbID }).WillCascadeOnDelete(false);
            modelBuilder.Entity<TransferenciasDepositos>().HasOptional(c => c.cheque).WithMany().HasForeignKey(t => new { t.ChequeEmpID, t.ChequeCbID, t.ChequeNumChequera,t.ChequeNumCheque }).WillCascadeOnDelete(false);
            modelBuilder.Entity<TransferenciasDepositos>().HasOptional(c => c.ProveedorSucursal).WithMany().HasForeignKey(t => new {  t.ProveedorSucursalID }).WillCascadeOnDelete(false);
            modelBuilder.Entity<TransferenciasDepositos>().HasRequired(c => c.Usuario).WithMany().HasForeignKey(t => new { t.UsuarioID }).WillCascadeOnDelete(false);
            //*** Este era bueno tambien: modelBuilder.Entity<TransferenciasDepositos>().HasOptional(x => x.cheque).WithOptionalDependent().Map(x => x.MapKey("ChequeEmpID", "ChequeCbID", "ChequeNumChequera", "ChequeNumCheque"));

             /*Solicitudes de Fondo*/
            modelBuilder.Entity<SolicitudFondo>().HasKey(s => new { s.EmpresaID, s.ComercioID, s.SolicitudFondoID });
            modelBuilder.Entity<SolicitudFondo>().HasRequired(s => s.Empresa).WithMany().HasForeignKey(s => new { s.EmpresaID}).WillCascadeOnDelete(false);
            modelBuilder.Entity<SolicitudFondo>().HasRequired(s => s.Comercio).WithMany().HasForeignKey(s => new { s.EmpresaID, s.ComercioID }).WillCascadeOnDelete(false);
            modelBuilder.Entity<SolicitudFondo>().Property(s => s.SolicitudFondoID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<SolicitudFondo>().HasMany(s => s.SolicitudFondoConceptoGastosProveedor).WithRequired(sc => sc.SolicitudFondo);
            modelBuilder.Entity<SolicitudFondo>().HasOptional(c => c.AvisoDePago).WithMany().HasForeignKey(t => new { t.EmpresaID,t.ComercioID,t.AvisoDePagoID }).WillCascadeOnDelete(false);
            modelBuilder.Entity<SolicitudFondo>().HasOptional(c => c.Cheque).WithMany().HasForeignKey(t => new { t.EmpresaID, t.CuentaBancariaID, t.NumChequera, t.NumCheque }).WillCascadeOnDelete(false);
            modelBuilder.Entity<SolicitudFondo>().HasOptional(c => c.EmpleadoRealizador).WithMany().HasForeignKey(t => t.EmpleadoRealizadorID).WillCascadeOnDelete(false);
            modelBuilder.Entity<SolicitudFondo>().HasOptional(c => c.EmpleadoSolicitante).WithMany().HasForeignKey(t => t.EmpleadoSolicitanteID).WillCascadeOnDelete(false);
            modelBuilder.Entity<SolicitudFondo>().HasRequired(c => c.GeneradoPorComercio).WithMany().HasForeignKey(t => new {t.EmpresaID,t.ComercioID}).WillCascadeOnDelete(false);
            modelBuilder.Entity<SolicitudFondo>().HasOptional(c => c.GeneradoPorDepartamento).WithMany().HasForeignKey(t => t.GeneradoPorDepartamentoID).WillCascadeOnDelete(false);
            //modelBuilder.Entity<SolicitudFondo>().HasOptional(c => c.OrdenDePago).WithMany().HasForeignKey(t => t.OrdenDePagoID).WillCascadeOnDelete(false);

             
             //.WithMany()
            //.Map(m =>
            //{
            //    m.MapLeftKey("EmpresaID","ComercioID","SolicitudFondoID");
            //    m.MapRightKey("ConceptoGastoProveedorID");
            //}); ;
             //modelBuilder.Entity<SolicitudFondo>().HasOptional(s => s.TransferenciasDepositos);
            //Compatibilidad de SQL server
            modelBuilder.Entity<SolicitudFondo>().Property(s => s.FechaPago).HasColumnType("datetime2");
            modelBuilder.Entity<SolicitudFondo>().Property(s => s.FechaRealizacion).HasColumnType("datetime2");
            modelBuilder.Entity<SolicitudFondo>().Property(s => s.FechaDispFinal).HasColumnType("datetime2");
            modelBuilder.Entity<SolicitudFondo>().Property(s => s.FechaDispComienzo).HasColumnType("datetime2");
            modelBuilder.Entity<SolicitudFondo>().Property(s => s.FechaConfComercio).HasColumnType("datetime2");

            modelBuilder.Entity<SolicitudFondo>().Ignore(s => s.InfoParaRecibos);
            modelBuilder.Entity<SolicitudFondo>().Ignore(s => s.sDetalleSolFon);

            
            /* Estado */
            modelBuilder.Entity<Estado>().Property(e => e.EstadoID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
             
             /* Tipo Estado */
            modelBuilder.Entity<TipoEstado>().Property(t => t.TipoEstadoID ).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            
             /* Tipo Solicitud */
            modelBuilder.Entity<TipoSolicitud>().Property(t => t.TipoSolicitudID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
           
             /*Tipo Anulacion*/
            modelBuilder.Entity<TipoAnulacion>().HasKey(c => c.TipoAnulacionID);
            modelBuilder.Entity<TipoAnulacion>().Property(e => e.TipoAnulacionID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<TipoAnulacion>().Property(e => e.TipoAnulacionID).HasColumnType("NVARCHAR").HasMaxLength(2);

            /* Conceptos Fondos */
            modelBuilder.Entity<ConceptoFondos>().HasKey(c => c.ConceptoFondosID);
            modelBuilder.Entity<ConceptoFondos>().Property(c => c.ConceptoFondosID ).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<ConceptoFondos>().HasRequired(c => c.MedioDePago);

            /* Medios de pago */
            modelBuilder.Entity<MedioDePago>().HasKey(m => m.MedioDePagoID);
            modelBuilder.Entity<MedioDePago>().Property(m => m.MedioDePagoID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            /*Operaciones */
            modelBuilder.Entity<Operacion>().HasKey(o => o.OperacionID);
            
            /*Transmisiones */
            modelBuilder.Entity<Transmision>().HasKey(t=>t.TransmisionID);
            //modelBuilder.Entity<Transmision>().HasRequired(t => t.EstadoTransmision).WithMany().HasForeignKey(c => c.EstadoTransmisionID).WillCascadeOnDelete(false);
            modelBuilder.Entity<Transmision>().HasRequired(t => t.Operacion).WithMany().HasForeignKey(o => o.OperacionID).WillCascadeOnDelete(false);
            modelBuilder.Entity<Transmision>().Property(t =>t.Fecha ).HasColumnType("datetime2");

             /* Autorizaciones */
            modelBuilder.Entity<Autorizacion>().HasKey(s => new { s.EmpresaID,s.ComercioID, s.AutorizacionID });
            modelBuilder.Entity<Autorizacion>().HasOptional(a => a.Persona);
            modelBuilder.Entity<Autorizacion>().Property(a => a.Fecha).HasColumnType("datetime2");
            modelBuilder.Entity<Autorizacion>().Property(a => a.SolicitudFondoFechaPago).HasColumnType("datetime2");
            /* Persona */
            modelBuilder.Entity<Persona>().HasKey(p => p.PersonaID);
           
            /* Cuenta Corriente */
            modelBuilder.Entity<CuentaCorriente>().HasKey(s => new { s.EmpresaID, s.ComercioID,s.CuentaCorrienteID});
            modelBuilder.Entity<CuentaCorriente>().Property(s => s.CuentaCorrienteID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<CuentaCorriente>().HasOptional(s => s.TransferenciasDepositos).WithMany().HasForeignKey(c => new { c.EmpresaID, c.TransferenciaDepositoID });
            modelBuilder.Entity<CuentaCorriente>().HasOptional(s => s.Recibo).WithMany().HasForeignKey(c => new { c.EmpresaID, c.GestionID,c.ReciboID });
            

            /* Tipo Movimiento */
            modelBuilder.Entity<TipoMovimiento>().HasKey(t => new { t.TipoMovimientoID });
            modelBuilder.Entity<TipoMovimiento>().Property(t => t.TipoMovimientoID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            
            /* Pais */
            modelBuilder.Entity<Pais>().HasKey(p => new { p.PaisID });
            modelBuilder.Entity<Pais>().HasMany(pro => pro.Provincias).WithRequired(p => p.Pais);
            modelBuilder.Entity<Pais>().Property(p => p.PaisID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

           /*  Provincia */
            modelBuilder.Entity<Provincia>().HasKey(p => new { p.PaisId, p.ProvinciaID });
            modelBuilder.Entity<Provincia>().HasRequired(s => s.Pais).WithMany().HasForeignKey(s => new { s.PaisId }).WillCascadeOnDelete(false);
            modelBuilder.Entity<Provincia>().HasMany(p => p.Localidades).WithRequired(l => l.Provincia).WillCascadeOnDelete(false);
            modelBuilder.Entity<Provincia>().Property(p => p.PaisId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Provincia>().Property(p => p.ProvinciaID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            /* Localidad */
            modelBuilder.Entity<Localidad>().HasKey(p => new { p.PaisId, p.ProvinciaID, p.LocalidadID });
            //modelBuilder.Entity<Localidad>().HasRequired(s => s.Provincia).WithMany().HasForeignKey(s => new {s.PaisId,s.ProvinciaID }).WillCascadeOnDelete(false);
            modelBuilder.Entity<Localidad>().Property(p => p.PaisId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Localidad>().Property(p => p.ProvinciaID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Localidad>().Property(p => p.LocalidadID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            /* Proveedor */
            modelBuilder.Entity<Proveedor>().HasKey(p =>p.ProveedorID);
            modelBuilder.Entity<Proveedor>().Property(p => p.ProveedorID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Proveedor>().Property(p => p.FechaAlta).HasColumnType("datetime2");

            /* ConceptoGastos */
            modelBuilder.Entity<ConceptoGastos>().HasKey(p => p.ConceptoGastosID);
            modelBuilder.Entity<ConceptoGastos>().Property(p => p.ConceptoGastosID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<ConceptoGastos>().Ignore(p => p.NombreCompleto);

            modelBuilder.Entity<ConceptoGastos>().HasOptional(c => c.ConceptoGastoPadre).WithMany().HasForeignKey(cg => cg.ConceptoGastoPadreID);
            /* ConceptoGastosProveedor */
            modelBuilder.Entity<ConceptoGastosProveedor>().HasKey(p => p.ConceptoGastosProveedorID);

            /*Profesiones*/
            modelBuilder.Entity<Profesion>().HasKey(p => p.ProfesionID);
            modelBuilder.Entity<Profesion>().HasOptional(c => c.ProfesionPadre).WithMany(p=>p.SubProfesiones).HasForeignKey(p => p.ProfesionPadreID);
            
            /* Gastos */
            modelBuilder.Entity<Gasto>().HasKey(p => new {p.EmpresaID,p.ComercioID,p.GastoID});
            modelBuilder.Entity<Gasto>().Property(c => c.GastoID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Gasto>().HasOptional(c => c.ConceptoGastos).WithMany().HasForeignKey(p => p.ConceptoGastoID);
            modelBuilder.Entity<Gasto>().HasOptional(c => c.ConceptoGastosProveedor).WithMany().HasForeignKey(p => p.ConceptoGastoProveedorID);
            modelBuilder.Entity<Gasto>().HasOptional(c => c.Proveedor).WithMany().HasForeignKey(p => p.ProveedorID);
            modelBuilder.Entity<Gasto>().HasOptional(c => c.ProveedorSucursal).WithMany().HasForeignKey(p => p.ProveedorSucursalID);
            modelBuilder.Entity<Gasto>().HasOptional(c => c.Departamento).WithMany().HasForeignKey(p => p.DepartamentoID);
            modelBuilder.Entity<Gasto>().HasOptional(c => c.SolicitudFondo).WithMany().HasForeignKey(p => new { p.EmpresaID, p.ComercioID, p.SolicitudFondoID });
            modelBuilder.Entity<Gasto>().Property(c => c.Fecha).HasColumnType("datetime2");
            modelBuilder.Entity<Gasto>().HasRequired(s => s.Empresa).WithMany().HasForeignKey(s => new { s.EmpresaID }).WillCascadeOnDelete(false);
            modelBuilder.Entity<Gasto>().HasRequired(s => s.Comercio).WithMany().HasForeignKey(s => new { s.EmpresaID, s.ComercioID }).WillCascadeOnDelete(false);

            /*Solicitud Fondo Concepto Gastos Proveedor*/
            modelBuilder.Entity<SolicitudFondoConceptoGastosProveedor>().HasKey(s => new { s.EmpresaID, s.ComercioID, s.SolicitudFondoID, s.ConceptoGastosProveedorID });
            modelBuilder.Entity<SolicitudFondoConceptoGastosProveedor>().HasRequired(sc => sc.ConceptoGastosProveedor);

            //TipoBonificacion
            modelBuilder.Entity<TipoBonificacion>().HasKey(t => t.TipoBonificacionID);
            modelBuilder.Entity<TipoBonificacion>().Property(t => t.TipoBonificacionID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);


            // **edu**
            //PlanesTipo
            modelBuilder.Entity<PlanesTipo>().HasKey(t => t.PlanesTipoID);
            modelBuilder.Entity<PlanesTipo>().Property(t => t.PlanesTipoID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<PlanesTipo>().HasRequired(c => c.Empresa).WithMany().HasForeignKey(c => c.EmpresaID).WillCascadeOnDelete(false);
            modelBuilder.Entity<PlanesTipo>().HasRequired(c => c.Comercio).WithMany().HasForeignKey(c => new { c.EmpresaID, c.ComercioID }).WillCascadeOnDelete(false);
            modelBuilder.Entity<PlanesTipo>().Property(p => p.PlanesTipoID).HasMaxLength(20);
            modelBuilder.Entity<PlanesTipo>().Property(p => p.Notas).HasMaxLength(40);
            modelBuilder.Entity<PlanesTipo>().Property(p => p.TipoAV).HasMaxLength(1);
            modelBuilder.Entity<PlanesTipo>().Property(p => p.Inter).HasPrecision(18, 4);
            modelBuilder.Entity<PlanesTipo>().Property(p => p.Inter_Incr).HasPrecision(18, 4);
            
             //PlanesParam
            modelBuilder.Entity<PlanesParam>().HasKey(t => t.PlanesParamId);
            modelBuilder.Entity<PlanesParam>().Property(t => t.PlanesParamId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<PlanesParam>().Property(p => p.Param1).HasMaxLength(40);
            modelBuilder.Entity<PlanesParam>().Property(p => p.Param2).HasMaxLength(40);

            modelBuilder.Entity<PlanesBonif>().HasKey(t => t.PlanesBonifID);
            modelBuilder.Entity<PlanesBonif>().Property(p => p.TipoBoni).HasMaxLength(2);
            modelBuilder.Entity<PlanesBonif>().Property(p => p.TipoCuota).HasMaxLength(1);
            modelBuilder.Entity<PlanesBonif>().Property(p => p.UsuarioPC).HasMaxLength(30);

            modelBuilder.Entity<PlanesVenci>().HasKey(t => t.PlanesVenciID);
            modelBuilder.Entity<PlanesVenci>().Property(p => p.TipoVencimiento).HasMaxLength(3);
            modelBuilder.Entity<PlanesVenci>().Property(p => p.UsuarioPC).HasMaxLength(30);

            modelBuilder.Entity<NotasCD>().HasKey(n => new { n.EmpresaID, n.ComercioID, n.CreditoID, n.CuotaID, n.CobranzaID, n.NotaCDID});
            //***edu***//
             modelBuilder.Entity<NotasCD>().Property(n => n.Notas).HasMaxLength(30);
            
            /* Telefono */
            modelBuilder.Entity<Telefono>().HasKey(t => t.TelefonoID);
            modelBuilder.Entity<Telefono>().Property(t => t.TelefonoID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Telefono>().Property(c => c.Fecha).HasColumnType("datetime2");

             /* Domicilio */
            modelBuilder.Entity<Domicilio>().HasKey(t => t.DomicilioID);
            modelBuilder.Entity<Domicilio>().Property(t => t.DomicilioID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
             //modelBuilder.Entity<Domicilio>().HasRequired(c => c.Localidad); //.WithRequired(c => c.Domicilio).WillCascadeOnDelete(false);
            modelBuilder.Entity<Domicilio>().Property(t => t.TipoDocumentoID).HasMaxLength(3);
            modelBuilder.Entity<Domicilio>().Property(c => c.Fecha).HasColumnType("datetime2");

            /* CreditoAval */
            //***edu***
            modelBuilder.Entity<CreditoAval>().HasKey(c => c.CreditoAvalID);
            modelBuilder.Entity<CreditoAval>().Property(c => c.CreditoAvalID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            /* Mail */
            modelBuilder.Entity<Mail>().HasKey(t => t.MailID);
            modelBuilder.Entity<Mail>().Property(t => t.MailID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Mail>().Property(c => c.Fecha).HasColumnType("datetime2");

            /* Nota */
            modelBuilder.Entity<Nota>().HasKey(t => t.NotaID);
            modelBuilder.Entity<Nota>().Property(t => t.NotaID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Nota>().Property(c => c.Fecha).HasColumnType("datetime2");

            /*Cap*/
            modelBuilder.Entity<Cap>().HasKey(s => new { s.EmpresaID, s.ComercioID, s.CapID });
            modelBuilder.Entity<Cap>().HasMany(s => s.Items).WithRequired(c=>c.Cap);//.HasForeignKey(cd => new { cd.EmpresaID, cd.ComercioID, cd.CapID });
            modelBuilder.Entity<Cap>().HasRequired(s => s.Empresa).WithMany().HasForeignKey(s => new { s.EmpresaID }).WillCascadeOnDelete(false);
            modelBuilder.Entity<Cap>().HasRequired(s => s.Comercio).WithMany().HasForeignKey(s => new { s.EmpresaID, s.ComercioID }).WillCascadeOnDelete(false);
            modelBuilder.Entity<Cap>().Property(s => s.CapID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Cap>().HasOptional(c => c.SolicitudFondo).WithMany().HasForeignKey(c => new { c.EmpresaID, c.ComercioID, c.SolicitudFondoID }).WillCascadeOnDelete(false);
            modelBuilder.Entity<Cap>().Property(p => p.Fecha).HasColumnType("datetime2");
            modelBuilder.Entity<Cap>().Ignore(p => p.sCapDescripcion);

            /*Cap Detalle*/
            modelBuilder.Entity<CapDetalle>().HasKey(s => new { s.EmpresaID, s.ComercioID, s.CapID ,s.CapDetalleID});
            modelBuilder.Entity<CapDetalle>().Property(s => s.CapDetalleID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<CapDetalle>().Property(p => p.FechaVencimiento).HasColumnType("datetime2");
            modelBuilder.Entity<CapDetalle>().Ignore(p => p.sDetalleCapDescripcion);


            /*FF*/
            modelBuilder.Entity<FF>().HasKey(s => new { s.EmpresaID, s.ComercioID, s.FFID });
            modelBuilder.Entity<FF>().HasMany(s => s.Items).WithRequired(s=>s.FF).HasForeignKey(cd => new { cd.EmpresaID, cd.ComercioID, cd.FFID });
            modelBuilder.Entity<FF>().HasRequired(s => s.Empresa).WithMany().HasForeignKey(s => new { s.EmpresaID }).WillCascadeOnDelete(false);
            modelBuilder.Entity<FF>().HasRequired(s => s.Comercio).WithMany().HasForeignKey(s => new { s.EmpresaID, s.ComercioID }).WillCascadeOnDelete(false);
            modelBuilder.Entity<FF>().Property(s => s.FFID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<FF>().HasOptional(c => c.SolicitudFondo).WithMany().HasForeignKey(c => new { c.EmpresaID, c.ComercioID, c.SolicitudFondoID }).WillCascadeOnDelete(false);
            modelBuilder.Entity<FF>().Property(p => p.Fecha).HasColumnType("datetime2");
            modelBuilder.Entity<FF>().Ignore(p => p.sFFDescripcion);

            /*FF Detalle*/
            modelBuilder.Entity<FFDetalle>().HasKey(s => new { s.EmpresaID, s.ComercioID, s.FFID,s.FFDetalleID });
            modelBuilder.Entity<FFDetalle>().Property(s => s.FFDetalleID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<FFDetalle>().Property(p => p.Fecha).HasColumnType("datetime2");
            modelBuilder.Entity<FFDetalle>().Ignore(p => p.sDetalleFFDescripcion); 

            /*Pago*/
            modelBuilder.Entity<Pago>().HasKey(s => new { s.EmpresaID, s.ComercioID, s.PagoID });
            modelBuilder.Entity<Pago>().Property(s => s.PagoID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Pago>().HasRequired(s => s.Empresa).WithMany().HasForeignKey(s => new { s.EmpresaID }).WillCascadeOnDelete(false);
            modelBuilder.Entity<Pago>().HasRequired(s => s.Comercio).WithMany().HasForeignKey(s => new { s.EmpresaID, s.ComercioID }).WillCascadeOnDelete(false);
            modelBuilder.Entity<Pago>().HasOptional(c => c.SolicitudFondo).WithMany().HasForeignKey(c => new { c.EmpresaID, c.ComercioID, c.SolicitudFondoID }).WillCascadeOnDelete(false);
            modelBuilder.Entity<Pago>().HasOptional(c => c.CapDetalle).WithMany(p => p.Pagos).WillCascadeOnDelete(false);
            modelBuilder.Entity<Pago>().HasOptional(c => c.FFDetalle).WithMany(p => p.Pagos).WillCascadeOnDelete(false);
             //modelBuilder.Entity<Pago>().HasOptional(c => c.CapDetalle).WithMany().HasForeignKey(c => new { c.EmpresaID, c.ComercioID, c.CapID, c.CapDetalleID }).WillCascadeOnDelete(false);
            //modelBuilder.Entity<Pago>().HasOptional(c => c.FFDetalle).WithMany().HasForeignKey(c => new { c.EmpresaID, c.ComercioID, c.FFID, c.FFDetalleID }).WillCascadeOnDelete(false);
            modelBuilder.Entity<Pago>().Property(p => p.Fecha).HasColumnType("datetime2");
            modelBuilder.Entity<Pago>().Ignore(p => p.sPagoDescripcion);

            /* Log */
            modelBuilder.Entity<Log>().HasKey(l => new { l.LogID });
            modelBuilder.Entity<Log>().Property(l => l.LogID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Log>().Property(l => l.Fecha).HasColumnType("datetime2");
            modelBuilder.Entity<Log>().Property(l => l.Usuario).HasMaxLength(150);
            modelBuilder.Entity<Log>().Property(l => l.Host).HasMaxLength(150);
            modelBuilder.Entity<Log>().Property(l => l.Tipo).HasMaxLength(150);
            modelBuilder.Entity<Log>().Ignore(l => l.sLog);


             //       modelBuilder.Entity<Producto>()
             //.HasRequired<Categoria>(c => c.Categoria)
             //.WithMany(c => c.Productos)
             //.HasForeignKey(c => c.IdCategoria);

             // edu
                       
         }
       
    }
}
