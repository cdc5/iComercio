using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.ComponentModel;
using System.IO;
using System.Diagnostics;
using System.Data;
using System.Data.Entity;
using System.Reflection;
using iComercio.Auxiliar;
using iComercio.Models;
using System.Configuration;

namespace iComercio.DAL
{
    public class Dal:IDisposable
    {
        public ComercioContext context = new ComercioContext(ConnectionStrings.GetDecryptedConnectionString("ComercioContext"));

        //public Dal(String NombreBase)
        //{
        //    context = new ComercioContext(NombreBase);
        //   // context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        //    // context.Database.Connection.Open();
        //    //// context.Database.Connection.ChangeDatabase("SqlValle");
        //    // context.Database.Connection.ChangeDatabase(NombreBase);
        //    //// context.Database.Connection.ChangeDatabase("SqlAcuatro");           
        //}

        public Dal(string nombrebase)
        {
            var a = ConnectionStrings.Encrypt("a");
            context = new ComercioContext(ConnectionStrings.GetDecryptedConnectionString(nombrebase));
        }

        private IGenericRepository<Configuracion> configuracionRepository;
        private IGenericRepository<Usuario> usuarioRepository;
        private IGenericRepository<Perfil> perfilRepository;
        private IGenericRepository<Permiso> permisoRepository;
        private IGenericRepository<Banco> bancoRepository;
        private IGenericRepository<Cargo> cargoRepository;
        private IGenericRepository<Cheque> chequeRepository;
        private IGenericRepository<Chequera> chequeraRepository;
        private IGenericRepository<ClaseCuentaBancaria> claseCuentaBancariaRepository;
        private IGenericRepository<Comercio> comercioRepository;
        private IGenericRepository<ConceptoFondos> conceptoFondoRepository;
        private IGenericRepository<ConceptoGastosProveedor> conceptoGastoProveedorRepository;
        private IGenericRepository<ConceptoGastos> conceptoGastosRepository;
        private IGenericRepository<ConceptoGastosDepartamento> conceptoGastosDepartamentoRepository;
        private IGenericRepository<CuentaBancaria> cuentaBancariaRepository;
        private IGenericRepository<Departamento> departamentoRepository;
        private IGenericRepository<Empleado> empleadoRepository;
        private IGenericRepository<Empresa> empresaRepository;
        private IGenericRepository<Estado> estadoRepository;
        private IGenericRepository<Localidad> localidadRepository;
        private IGenericRepository<MedioDePago> medioDePagoRepository;
        private IGenericRepository<Moneda> monedaRepository;
        private IGenericRepository<OrdenDePago> ordenDePagoRepository;
        private IGenericRepository<Pais> paisRepository;
        private IGenericRepository<Persona> personaRepository;
        private IGenericRepository<Proveedor> proveedorRepository;
        private IGenericRepository<ProveedorSucursal> proveedorSucursalRepository;
        private IGenericRepository<Provincia> provinciaRepository;
        private IGenericRepository<SolicitudFondo> solicitudFondosRepository;
        private IGenericRepository<SucursalBanco> sucursalBancoRepository;
        private IGenericRepository<TipoCheque> tipoChequeRepository;
        private IGenericRepository<TipoComercio> tipoComercioRepository;
        private IGenericRepository<TipoCuentaBancaria> tipoCuentasBancariasRepository;
        private IGenericRepository<TipoEmpleado> tipoEmpleadoRepository;
        private IGenericRepository<TipoEstado> tipoEstadoRepository;
        private IGenericRepository<TipoDocumento> tiposDocumentoRepository;
        private IGenericRepository<TipoSolicitud> tipoSolicitudRepository;
        private IGenericRepository<TransferenciasDepositos> transferenciasDepositosRepository;
        private IGenericRepository<Operacion> operacionRepository;
        private IGenericRepository<EstadoTransmision> estadoTransmisionRepository;
        private IGenericRepository<Transmision> transmisionRepository;
        private IGenericRepository<Autorizacion> autorizacionRepository;
        private IGenericRepository<CuentaCorriente> cuentaCorrienteRepository;
        private IGenericRepository<Profesion> profesionRepository;
        private IGenericRepository<Sexo> sexoRepository;
        private IGenericRepository<Cliente> clienteRepository;
        private IGenericRepository<ClaseDato> claseDatoRepository;
        private IGenericRepository<TipoComoConocio> tipoComoConocioRepository;

        public IGenericRepository<TipoComoConocio> TipoComoConocioRepository
        {
            get
            {

                if (this.tipoComoConocioRepository == null)
                {
                    this.tipoComoConocioRepository = new GenericRepository<TipoComoConocio>(context);
                }
                return tipoComoConocioRepository;
            }

        }
        public IGenericRepository<ClaseDato> ClaseDatoRepository
        {
            get
            {

                if (this.claseDatoRepository == null)
                {
                    this.claseDatoRepository = new GenericRepository<ClaseDato>(context);
                }
                return claseDatoRepository;
            }
        }
        public IGenericRepository<Cliente> ClienteRepository
        {
            get
            {

                if (this.clienteRepository == null)
                {
                    this.clienteRepository = new GenericRepository<Cliente>(context);
                }
                return clienteRepository;
            }
        }

        
        public IGenericRepository<Sexo> SexoRepository
        {
            get
            {

                if (this.sexoRepository == null)
                {
                    this.sexoRepository = new GenericRepository<Sexo>(context);
                }
                return sexoRepository;
            }
        }

        public IGenericRepository<Profesion> ProfesionRepository
        {
            get
            {

                if (this.profesionRepository == null)
                {
                    this.profesionRepository = new GenericRepository<Profesion>(context);
                }
                return profesionRepository;
            }
        }


        public IGenericRepository<TipoDocumento> TiposDocumentoRepository
        {
            get
            {

                if (this.tiposDocumentoRepository == null)
                {
                    this.tiposDocumentoRepository = new GenericRepository<TipoDocumento>(context);
                }
                return tiposDocumentoRepository;
            }
        }

        public IGenericRepository<Configuracion> ConfiguracionRepository
        {
            get
            {

                if (this.configuracionRepository == null)
                {
                    this.configuracionRepository = new GenericRepository<Configuracion>(context);
                }
                return configuracionRepository;
            }
        }


        public IGenericRepository<Usuario> UsuarioRepository
        {
            get
            {

                if (this.usuarioRepository == null)
                {
                    this.usuarioRepository = new GenericRepository<Usuario>(context);
                }
                return usuarioRepository;
            }
        }

        public IGenericRepository<Perfil> PerfilRepository
        {
            get
            {

                if (this.perfilRepository == null)
                {
                    this.perfilRepository = new GenericRepository<Perfil>(context);
                }
                return perfilRepository;
            }
        }

        public IGenericRepository<Permiso> PermisoRepository
        {
            get
            {

                if (this.permisoRepository == null)
                {
                    this.permisoRepository = new GenericRepository<Permiso>(context);
                }
                return permisoRepository;
            }
        }

        public IGenericRepository<Empresa> EmpresaRepository
        {
            get
            {

                if (this.empresaRepository == null)
                {
                    this.empresaRepository = new GenericRepository<Empresa>(context);
                }
                return empresaRepository;
            }
        }

        public IGenericRepository<Estado> EstadoRepository
        {
            get
            {

                if (this.estadoRepository == null)
                {
                    this.estadoRepository = new GenericRepository<Estado>(context);
                }
                return estadoRepository;
            }
        }


        public IGenericRepository<ConceptoFondos> ConceptoFondosRepository
        {
            get
            {

                if (this.conceptoFondoRepository == null)
                {
                    this.conceptoFondoRepository = new GenericRepository<ConceptoFondos>(context);
                }
                return conceptoFondoRepository;
            }
        }

        public IGenericRepository<SolicitudFondo> SolicitudFondosRepository
        {
            get
            {

                if (this.solicitudFondosRepository == null)
                {
                    this.solicitudFondosRepository = new GenericRepository<SolicitudFondo>(context);
                }
                return solicitudFondosRepository;
            }
        }

      
        public IGenericRepository<TipoSolicitud> TipoSolicitudRepository
        {
            get
            {

                if (this.tipoSolicitudRepository == null)
                {
                    this.tipoSolicitudRepository = new GenericRepository<TipoSolicitud>(context);
                }
                return tipoSolicitudRepository;
            }
        }

        public IGenericRepository<Moneda> MonedaRepository
        {
            get
            {

                if (this.monedaRepository == null)
                {
                    this.monedaRepository = new GenericRepository<Moneda>(context);
                }
                return monedaRepository;
            }
        }

        public IGenericRepository<Operacion> OperacionRepository
        {
            get
            {

                if (this.operacionRepository == null)
                {
                    this.operacionRepository = new GenericRepository<Operacion>(context);
                }
                return operacionRepository;
            }
        }

        public IGenericRepository<EstadoTransmision> EstadoTransmisionRepository
        {
            get
            {

                if (this.estadoTransmisionRepository == null)
                {
                    this.estadoTransmisionRepository = new GenericRepository<EstadoTransmision>(context);
                }
                return estadoTransmisionRepository;
            }
        }

        public IGenericRepository<Transmision> TransmisionRepository
        {
            get
            {

                if (this.transmisionRepository == null)
                {
                    this.transmisionRepository = new GenericRepository<Transmision>(context);
                }
                return transmisionRepository;
            }
        }


        public IGenericRepository<Autorizacion> AutorizacionRepository
        {
            get
            {

                if (this.autorizacionRepository == null)
                {
                    this.autorizacionRepository = new GenericRepository<Autorizacion>(context);
                }
                return autorizacionRepository;
            }
        }

        public IGenericRepository<CuentaCorriente> CuentaCorrienteRepository
        {
            get
            {

                if (this.cuentaCorrienteRepository == null)
                {
                    this.cuentaCorrienteRepository = new GenericRepository<CuentaCorriente>(context);
                }
                return cuentaCorrienteRepository;
            }
        }

        public IGenericRepository<Comercio> ComercioRepository
        {
            get
            {

                if (this.comercioRepository == null)
                {
                    this.comercioRepository = new GenericRepository<Comercio>(context);
                }
                return comercioRepository;
            }
        }

        public IGenericRepository<Proveedor> ProveedorRepository
        {
            get
            {

                if (this.proveedorRepository == null)
                {
                    this.proveedorRepository = new GenericRepository<Proveedor>(context);
                }
                return proveedorRepository;
            }
        }

        public IGenericRepository<ProveedorSucursal> ProveedorSucursalRepository
        {
            get
            {

                if (this.proveedorSucursalRepository == null)
                {
                    this.proveedorSucursalRepository = new GenericRepository<ProveedorSucursal>(context);
                }
                return proveedorSucursalRepository;
            }
        }

        public IGenericRepository<Pais> PaisRepository
        {
            get
            {

                if (this.paisRepository == null)
                {
                    this.paisRepository = new GenericRepository<Pais>(context);
                }
                return paisRepository;
            }
        }

        public IGenericRepository<Provincia> ProvinciaRepository
        {
            get
            {

                if (this.provinciaRepository == null)
                {
                    this.provinciaRepository = new GenericRepository<Provincia>(context);
                }
                return provinciaRepository;
            }
        }

        public IGenericRepository<Localidad> LocalidadRepository
        {
            get
            {

                if (this.localidadRepository == null)
                {
                    this.localidadRepository = new GenericRepository<Localidad>(context);
                }
                return localidadRepository;
            }
        }
        

        public IGenericRepository<ConceptoGastos> ConceptoGastoRepository
        {
            get
            {

                if (this.conceptoGastosRepository == null)
                {
                    this.conceptoGastosRepository = new GenericRepository<ConceptoGastos>(context);
                }
                return conceptoGastosRepository;
            }
        }

        public IGenericRepository<ConceptoGastosProveedor> ConceptoGastoProveedorRepository
        {
            get
            {

                if (this.conceptoGastoProveedorRepository == null)
                {
                    this.conceptoGastoProveedorRepository = new GenericRepository<ConceptoGastosProveedor>(context);
                }
                return conceptoGastoProveedorRepository;
            }
        }


        /*Operaciones Genericas */
        public IEnumerable<TEntity> Get<TEntity>(Expression<Func<TEntity, bool>> filter = null,
                          Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                          string includeProperties = "",int? take = null) where TEntity : class
        {
            IQueryable<TEntity> query = context.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (take != null)
            {
                query = query.Take(take.Value);
            }            
            return query.ToList();            


            //if (orderBy != null)
            //{
            //    return orderBy(query).ToList();
            //}
            //else
            //{
            //    return query.ToList();
            //}
        }

        public IEnumerable<TEntity> GetAsNoTracking<TEntity>(Expression<Func<TEntity, bool>> filter = null,
                        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                        string includeProperties = "", int? take = null) where TEntity : class
        {

            IQueryable<TEntity> query = context.Set<TEntity>().AsNoTracking();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (take != null)
            {
                query = query.Take(take.Value);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        /*Operaciones Genericas */
        //public IEnumerable<TEntity> GetByKeys<TEntity>(params string[] claves) where TEntity : class,ITransmitible
        //{
        //    IQueryable<TEntity> query = context.Set<TEntity>();

        //    if (claves != null )
        //    {
        //        if (claves.Count() > 0)
        //            query = query.Where(e => e.EntidadID() == claves[0]);
        //        if (claves.Count() > 1)
        //            query = query.Where(e => e.EntidadID() == claves[0] && e.EntidadID2() == claves[1]);
        //        if (claves.Count() > 2)
        //            query = query.Where(e => e.EntidadID() == claves[0] && e.EntidadID2() == claves[1] && e.EntidadID3() == claves[2]);
        //    }
        //    return query.ToList();          
        //}

        public TEntity GetByID<TEntity>(object id) where TEntity : class
        {
            DbSet<TEntity> dbSet = context.Set<TEntity>();
            return context.Set<TEntity>().Find(id);
        }

        public void Agregar<TEntity>(TEntity entity) where TEntity : class
        {
            //try
            //{
                DbSet<TEntity> dbSet = context.Set<TEntity>();
                dbSet.Add(entity);
                context.SaveChanges();
            //}
            //catch (DbEntityValidationException e)
            //{
            //    foreach (var eve in e.EntityValidationErrors)
            //    {
            //        Debug.Write("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
            //            eve.Entry.Entity.GetType().Name, eve.Entry.State);
            //        foreach (var ve in eve.ValidationErrors)
            //        {
            //            Console.WriteLine("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
            //    ve.PropertyName,
            //    eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
            //    ve.ErrorMessage);
            //        }
            //    }
            //    throw;
            //}
            //((System.Data.Entity.Validation.DbEntityValidationException)$exception).EntityValidationErrors
        }

        public void Borrar<TEntity>(object id) where TEntity : class
        {
            TEntity entityToDelete = context.Set<TEntity>().Find(id);
            Borrar<TEntity>(entityToDelete);
        }

        public void Borrar<TEntity>(TEntity entityToDelete) where TEntity : class
        {
            DbSet<TEntity> dbSet = context.Set<TEntity>();
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
            context.SaveChanges();
        }

        public void Actualizar<TEntity>(TEntity entityToUpdate) where TEntity : class 
        {
            DbSet<TEntity> dbSet = context.Set<TEntity>();
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Attach<TEntity>(TEntity entityToAttach) where TEntity : class
        {
            DbSet<TEntity> dbSet = context.Set<TEntity>();
            dbSet.Attach(entityToAttach);
        }

        public void Desacoplar<TEntity>(TEntity entity) where TEntity : class
        {
            context.Entry(entity).State = EntityState.Detached;   
        }

        public BindingList<TEntity> ToBindingList<TEntity>() where TEntity : class
        {
            DbSet<TEntity> dbSet = context.Set<TEntity>();
            dbSet.Load();
            return dbSet.Local.ToBindingList();
        }

        public void AgregarBulk<TEntity>(List<TEntity> lista) where TEntity : class
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            foreach (TEntity cli in lista)
            {
                Agregar<TEntity>(cli);
            }
            context.Configuration.AutoDetectChangesEnabled = true;
        }

        public void AgregarRange<TEntity>(List<TEntity> lista) where TEntity : class
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            //Este es el metodo mas rapido de los comparando con los tres anteriores
            //tendria que probar deshabilitaando tambien el autoDetectChangesEnabled
            context.Set<TEntity>().AddRange(lista);
            Save();
            context.Configuration.AutoDetectChangesEnabled = true;
        }
        /****************************************/

        /* Transaccional */
        public void AgregarTransaccional<TEntity>(TEntity entity) where TEntity : class
        {
            DbSet<TEntity> dbSet = context.Set<TEntity>();
            dbSet.Add(entity);
        }

        public void BorrarTransaccional<TEntity>(object id) where TEntity : class
        {
            TEntity entityToDelete = context.Set<TEntity>().Find(id);
            BorrarTransaccional<TEntity>(entityToDelete);
        }

        public void BorrarTransaccional<TEntity>(TEntity entityToDelete) where TEntity : class
        {
            DbSet<TEntity> dbSet = context.Set<TEntity>();
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public void ActualizarTransaccional<TEntity>(TEntity entityToUpdate) where TEntity : class
        {
            DbSet<TEntity> dbSet = context.Set<TEntity>();
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }
        public void ActualizarTransaccional<TEntity>(List<TEntity> lista) where TEntity : class
        {
            DbSet<TEntity> dbSet = context.Set<TEntity>();
            foreach (TEntity entityToUpdate in lista)
            {
                dbSet.Attach(entityToUpdate);
                context.Entry(entityToUpdate).State = EntityState.Modified;
            }           
        }

        public void AgregarRangeTransaccional<TEntity>(List<TEntity> lista) where TEntity : class
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            //Este es el metodo mas rapido de los comparando con los tres anteriores
            //tendria que probar deshabilitaando tambien el autoDetectChangesEnabled
            context.Set<TEntity>().AddRange(lista);
            context.Configuration.AutoDetectChangesEnabled = true;
        }

        public void BorrarRangeTransaccional<TEntity>(List<TEntity> lista) where TEntity : class
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            //Este es el metodo mas rapido de los comparando con los tres anteriores
            //tendria que probar deshabilitaando tambien el autoDetectChangesEnabled
            context.Set<TEntity>().RemoveRange(lista);
            context.Configuration.AutoDetectChangesEnabled = true;
        }

        /****************************************/


        /*BD*/
        public void CargarScriptPaisesProvinciasLocalidades(ComercioContext context, string scriptPath)
        {
           string script = "";
           using (StreamReader reader = new StreamReader(scriptPath))
           {
                script = reader.ReadToEnd();
           }
           script = script.Replace(Environment.NewLine,String.Empty);
           string[] commands = script.Split(new string[] { "GO" }, StringSplitOptions.RemoveEmptyEntries);

           // Iterate the string array and execute each one.
           foreach (string thisCommand in commands)
           {
            context.Database.ExecuteSqlCommand(thisCommand);
           }
        }

        /*cdc_nvo 12102020*/
        public void CargarColumnasCalculadas(ComercioContext context, string scriptPath)
        {
            String script = "ALTER TABLE dbo.Cuota DROP COLUMN Deuda";
            context.Database.ExecuteSqlCommand(script);
            script = "ALTER TABLE dbo.Cuota add Deuda AS(Importe-ImportePago)";
            context.Database.ExecuteSqlCommand(script);
            script = "ALTER TABLE dbo.RefinanciacionCuota DROP COLUMN Deuda";
            context.Database.ExecuteSqlCommand(script);
            script = "ALTER TABLE dbo.RefinanciacionCuota add Deuda AS(Importe-ImportePago)";
            context.Database.ExecuteSqlCommand(script);
            //string[] commands = script.Split(new string[] { "GO" }, StringSplitOptions.RemoveEmptyEntries);
            // Iterate the string array and execute each one.
            //foreach (string thisCommand in commands)
            //{
            //context.Database.ExecuteSqlCommand(thisCommand);
            //}            
        }/**/

        public void CargarScriptPlanesYEstructura(string scriptPath)
        {
            string script = "";
            using (StreamReader reader = new StreamReader(scriptPath))
            {
                script = reader.ReadToEnd();
            }
            script = script.Replace(Environment.NewLine, String.Empty);
            string[] commands = script.Split(new string[] { "GO" }, StringSplitOptions.RemoveEmptyEntries);

            // Iterate the string array and execute each one.
            foreach (string thisCommand in commands)
            {
                context.Database.ExecuteSqlCommand(thisCommand);
            }
        }

        //public void OtrasFormas de cargar()
        //{
        //    //1
        //         // using (var context = new MyDBEntities())
        //       // {
        //       //     var m = context.ExecuteStoreQuery<MyDataObject>("Select * from Person", string.Empty);
        //       //     //Do anything you want to do with 
        //       //     MessageBox.Show(m.Count().ToString());
        //       // }
        //    //2
        //        //var blogNames = context.Database.SqlQuery<string>("SELECT Name FROM dbo.Blogs").ToList();
        //    //3
        //       //var sql = System.IO.File.ReadAllText("SqlScript.sql");
        //        //_context.Database.ExecuteSqlCommand(sql); 
        //    //4
        //        //string result = "";
        //        //using (Stream stream = assembly.GetManifestResourceStream(resourceName))
        //        //{
        //        //    using (StreamReader reader = new StreamReader(stream))
        //        //    {
        //        //        result = reader.ReadToEnd();
        //        //    }
        //        //}
        //        //        }
        //        //string[] commands = result.Split(new string[] { "GO" }, StringSplitOptions.RemoveEmptyEntries);

        //        //YourContext context = new YourContext(); //Instance new Context
        //        //DbConnection conn = context.Database.Connection; // Get Database connection
        //        //ConnectionState initialState = conn.State; // Get Initial connection state
        //        //try
        //        //{
        //        //    if (initialState != ConnectionState.Open)
        //        //        conn.Open();  // open connection if not already open

        //        //    using (DbCommand cmd = conn.CreateCommand())
        //        //    {
        //        //        // Iterate the string array and execute each one.
        //        //        foreach (string thisCommand in commands)
        //        //        {
        //        //            cmd.CommandText = thisCommand;
        //        //            cmd.ExecuteNonQuery();
        //        //        }
        //        //    }
        //        //}
        //        //finally
        //        //{
        //        //    if (initialState != ConnectionState.Open)
        //        //        conn.Close(); // only close connection if not initially open
        //        //}
        //}

        /*TipoComoConocio */
        public IEnumerable<TipoComoConocio> GetTiposComoConocio(Expression<Func<TipoComoConocio, bool>> filter = null,
                                 Func<IQueryable<TipoComoConocio>, IOrderedQueryable<TipoComoConocio>> orderBy = null,
                                 string includeProperties = "")
        {
            return TipoComoConocioRepository.Get(filter, orderBy, includeProperties);
        }

        public TipoComoConocio GetTipoComoConocioByID(object id)
        {
            return TipoComoConocioRepository.GetByID(id);
        }

        public void AgregarTipoComoConocio(TipoComoConocio s)
        {
            TipoComoConocioRepository.Insert(s);
        }

        public void BorrarTipoComoConocio(object id)
        {
            TipoComoConocioRepository.Delete(id);
        }

        public void BorrarTipoComoConocio(TipoComoConocio s)
        {
            TipoComoConocioRepository.Delete(s);
        }

        public void ActualizarTipoComoConocio(TipoComoConocio s)
        {
            TipoComoConocioRepository.Update(s);
        }

        public BindingList<TipoComoConocio> TipoComoConocioBindingList()
        {
            return TipoComoConocioRepository.ToBindingList();
        }

        /*ClaseDato */
        public IEnumerable<ClaseDato> GetClasesDato(Expression<Func<ClaseDato, bool>> filter = null,
                                 Func<IQueryable<ClaseDato>, IOrderedQueryable<ClaseDato>> orderBy = null,
                                 string includeProperties = "")
        {
            return claseDatoRepository.Get(filter, orderBy, includeProperties);
        }

        public ClaseDato GetClaseDatoByID(object id)
        {
            return ClaseDatoRepository.GetByID(id);
        }

        public void AgregarClaseDato(ClaseDato s)
        {
            ClaseDatoRepository.Insert(s);
        }

        public void BorrarClaseDato(object id)
        {
            ClaseDatoRepository.Delete(id);
        }

        public void BorrarClaseDato(ClaseDato s)
        {
            ClaseDatoRepository.Delete(s);
        }

        public void ActualizarClaseDato(ClaseDato s)
        {
            ClaseDatoRepository.Update(s);
        }

        public BindingList<ClaseDato> ClaseDatoBindingList()
        {
            return ClaseDatoRepository.ToBindingList();
        }


        /*Cliente */
        public IEnumerable<Cliente> GetClientes(Expression<Func<Cliente, bool>> filter = null,
                                 Func<IQueryable<Cliente>, IOrderedQueryable<Cliente>> orderBy = null,
                                 string includeProperties = "")
        {
            return ClienteRepository.Get(filter, orderBy, includeProperties);
        }

        public Cliente GetClienteByID(object id)
        {
            return ClienteRepository.GetByID(id);
        }

        public void AgregarCliente(Cliente s)
        {
            ClienteRepository.Insert(s);
        }

        public void BorrarCliente(object id)
        {
            ClienteRepository.Delete(id);
        }

        public void BorrarCliente(Cliente s)
        {
            ClienteRepository.Delete(s);
        }

        public void ActualizarCliente(Cliente s)
        {
            ClienteRepository.Update(s);
        }

        public BindingList<Cliente> ClienteBindingList()
        {
            return ClienteRepository.ToBindingList();
        }


        /*Sexo */
        public IEnumerable<Sexo> GetSexos(Expression<Func<Sexo, bool>> filter = null,
                                 Func<IQueryable<Sexo>, IOrderedQueryable<Sexo>> orderBy = null,
                                 string includeProperties = "")
        {
            return SexoRepository.Get(filter, orderBy, includeProperties);
        }

        public Sexo GetSexoByID(object id)
        {
            return SexoRepository.GetByID(id);
        }

        public void AgregarSexo(Sexo s)
        {
            SexoRepository.Insert(s);
        }

        public void BorrarSexo(object id)
        {
            SexoRepository.Delete(id);
        }

        public void BorrarSexo(Sexo s)
        {
            SexoRepository.Delete(s);
        }

        public void ActualizarSexo(Sexo s)
        {
            SexoRepository.Update(s);
        }

        public BindingList<Sexo> SexoBindingList()
        {
            return SexoRepository.ToBindingList();
        }

        /*Profesiones */
        public IEnumerable<Profesion> GetProfesiones(Expression<Func<Profesion, bool>> filter = null,
                                 Func<IQueryable<Profesion>, IOrderedQueryable<Profesion>> orderBy = null,
                                 string includeProperties = "")
        {
            return ProfesionRepository.Get(filter, orderBy, includeProperties);
        }

        public Profesion GetProfesionByID(object id)
        {
            return ProfesionRepository.GetByID(id);
        }

        public void AgregarProfesion(Profesion p)
        {
            ProfesionRepository.Insert(p);
        }

        public void BorrarProfesion(object id)
        {
            ProfesionRepository.Delete(id);
        }

        public void BorrarProfesion(Profesion p)
        {
            ProfesionRepository.Delete(p);
        }

        public void ActualizarProfesion(Profesion p)
        {
            ProfesionRepository.Update(p);
        }

        public BindingList<Profesion> ProfesionBindingList()
        {
            return ProfesionRepository.ToBindingList();
        }

        

        /*Tipos Documento */
        public IEnumerable<TipoDocumento> GetTiposDocumento(Expression<Func<TipoDocumento, bool>> filter = null,
                                 Func<IQueryable<TipoDocumento>, IOrderedQueryable<TipoDocumento>> orderBy = null,
                                 string includeProperties = "")
        {
            return TiposDocumentoRepository.Get(filter, orderBy, includeProperties);
        }

        public TipoDocumento GetTipoDocumentoByID(object id)
        {
            return TiposDocumentoRepository.GetByID(id);
        }

        public void AgregarTipoDocumento(TipoDocumento td)
        {
            TiposDocumentoRepository.Insert(td);
        }

        public void BorrarTipoDocumento(object id)
        {
            TiposDocumentoRepository.Delete(id);
        }

        public void BorrarTipoDocumento(TipoDocumento td)
        {
            TiposDocumentoRepository.Delete(td);
        }

        public void ActualizarTipoDocumento(TipoDocumento td)
        {
            TiposDocumentoRepository.Update(td);
        }

        public BindingList<TipoDocumento> TiposDocumentoBindingList()
        {
            return TiposDocumentoRepository.ToBindingList();
        }

        /* ConceptoGastosProveedor */
        public IEnumerable<ConceptoGastosProveedor> GetConceptoGastosProveedor(Expression<Func<ConceptoGastosProveedor, bool>> filter = null,
                               Func<IQueryable<ConceptoGastosProveedor>, IOrderedQueryable<ConceptoGastosProveedor>> orderBy = null,
                               string includeProperties = "")
        {
            return ConceptoGastoProveedorRepository.Get(filter, orderBy, includeProperties);
        }

        public ConceptoGastosProveedor ConceptoGastosProveedorByID(object id)
        {
            return ConceptoGastoProveedorRepository.GetByID(id);
        }

        public void AgregarConceptoGastoProveedor(ConceptoGastosProveedor g)
        {
            ConceptoGastoProveedorRepository.Insert(g);
        }

        public void BorrarConceptoGastoProveedor(object id)
        {
            ConceptoGastoProveedorRepository.Delete(id);
            //ProveedorRepository.Delete(id);
        }

        public void BorrarConceptoGastoProveedor(ConceptoGastosProveedor g)
        {
            ConceptoGastoProveedorRepository.Delete(g);
        }
        public void ActualizarConceptoGastoProveedor(ConceptoGastosProveedor g)
        {
            ConceptoGastoProveedorRepository.Update(g);
            //ProveedorRepository.Update(g);
        }

            /* ConceptoGastos */
            public IEnumerable<ConceptoGastos> GetConceptoGastos(Expression<Func<ConceptoGastos, bool>> filter = null,
                                   Func<IQueryable<ConceptoGastos>, IOrderedQueryable<ConceptoGastos>> orderBy = null,
                                   string includeProperties = "")
            {
                return ConceptoGastoRepository.Get(filter, orderBy, includeProperties);
            }

            public ConceptoGastos ConceptoGastosByID(object id)
            {
                return ConceptoGastoRepository.GetByID(id);
            }
        
            public void AgregarConceptoGasto(ConceptoGastos g)
            {
                ConceptoGastoRepository.Insert(g);
            }

            public void BorrarConceptoGasto(object id)
            {
                ConceptoGastoRepository.Delete(id);
                //ProveedorRepository.Delete(id);
            }

            public void BorrarConceptoGasto(ConceptoGastos g)
            {
                ConceptoGastoRepository.Delete(g);
            }
            public void ActualizarConceptoGasto(ConceptoGastos g)
            {
                ConceptoGastoRepository.Update(g);
                //ProveedorRepository.Update(g);
            }

      
        /* Comercios */
        public IEnumerable<Comercio> GetComercios(Expression<Func<Comercio, bool>> filter = null,
                            Func<IQueryable<Comercio>, IOrderedQueryable<Comercio>> orderBy = null,
                            string includeProperties = "")
        {
            return ComercioRepository.Get(filter, orderBy, includeProperties);
        }

        public Comercio GetComercioByID(object id)
        {
            return ComercioRepository.GetByID(id);
        }

        public void AgregarComercio(Comercio com)
        {
            ComercioRepository.Insert(com);
        }

        public void BorrarComercio(object id)
        {
            ComercioRepository.Delete(id);
        }

        public void BorrarComercio(Comercio com)
        {
            ComercioRepository.Delete(com);
        }

        public void ActualizarComercio(Comercio com)
        {
            ComercioRepository.Update(com);
        }

        public BindingList<Comercio> ComercioBindingList()
        {
            return ComercioRepository.ToBindingList();
        }

        /* Usuarios */
        public IEnumerable<Usuario> GetUsuarios(Expression<Func<Usuario, bool>> filter = null,
                               Func<IQueryable<Usuario>, IOrderedQueryable<Usuario>> orderBy = null,
                               string includeProperties = "")
        {
            return UsuarioRepository.Get(filter, orderBy, includeProperties);
        }

        public Usuario GetUsuarioByID(object id)
        {
            return UsuarioRepository.GetByID(id);
        }

        public void AgregarUsuario(Usuario usu)
        {
            UsuarioRepository.Insert(usu);
        }

        public void BorrarUsuario(object id)
        {
            UsuarioRepository.Delete(id);
        }

        public void BorrarUsuario(Usuario usu)
        {
            UsuarioRepository.Delete(usu);
        }

        public void ActualizarUsuario(Usuario usu)
        {
            UsuarioRepository.Update(usu);
        }

        public BindingList<Usuario> UsuarioBindingList()
        {
            return UsuarioRepository.ToBindingList();
        }


        /* Perfiles */
        public IEnumerable<Perfil> GetPerfiles(Expression<Func<Perfil, bool>> filter = null,
                               Func<IQueryable<Perfil>, IOrderedQueryable<Perfil>> orderBy = null,
                               string includeProperties = "")
        {
            return PerfilRepository.Get(filter, orderBy, includeProperties);
        }

        public Perfil GetPerfilByID(object id)
        {
            return PerfilRepository.GetByID(id);
        }

        public void AgregarPerfil(Perfil per)
        {
            PerfilRepository.Insert(per);
        }

        public void BorrarPerfil(object id)
        {
            PerfilRepository.Delete(id);
        }

        public void BorrarPerfil(Perfil per)
        {
            PerfilRepository.Delete(per);
        }

        public void ActualizarPerfil(Perfil per)
        {
            PerfilRepository.Update(per);
        }

        public BindingList<Perfil> PerfilBindingList()
        {
            return PerfilRepository.ToBindingList();
        }

        /* Permisos */

        public IEnumerable<Permiso> GetPermisos(Expression<Func<Permiso, bool>> filter = null,
                               Func<IQueryable<Permiso>, IOrderedQueryable<Permiso>> orderBy = null,
                               string includeProperties = "")
        {
            return PermisoRepository.Get(filter, orderBy, includeProperties);
        }

        public Permiso GetPermisoByID(object id)
        {
            return PermisoRepository.GetByID(id);
        }

        public void AgregarPermiso(Permiso per)
        {
            PermisoRepository.Insert(per);
        }

        public void BorrarPermiso(object id)
        {
            PermisoRepository.Delete(id);
        }

        public void BorrarPermiso(Permiso per)
        {
            PermisoRepository.Delete(per);
        }

        public void ActualizarPermiso(Permiso per)
        {
            PermisoRepository.Update(per);
        }

        public BindingList<Permiso> PermisoBindingList()
        {
            return PermisoRepository.ToBindingList();
        }

        /* Empresas */
        public IEnumerable<Empresa> GetEmpresas(Expression<Func<Empresa, bool>> filter = null,
                               Func<IQueryable<Empresa>, IOrderedQueryable<Empresa>> orderBy = null,
                               string includeProperties = "")
        {
            return EmpresaRepository.Get(filter, orderBy, includeProperties);
        }

        public Empresa GetEmpresasByID(object id)
        {
            return EmpresaRepository.GetByID(id);
        }

        public void AgregarEmpresa(Empresa emp)
        {
            EmpresaRepository.Insert(emp);
        }

        public void BorrarEmpresa(object id)
        {
            EmpresaRepository.Delete(id);
        }

        public void BorrarEmpresa(Empresa emp)
        {
            EmpresaRepository.Delete(emp);
        }

        public void ActualizarEmpresa(Empresa emp)
        {
            EmpresaRepository.Update(emp);
        }

        public BindingList<Empresa> EmpresaBindingList()
        {
            return EmpresaRepository.ToBindingList();
        }

        /* Estado */
        public IEnumerable<Estado> GetEstados(Expression<Func<Estado, bool>> filter = null,
                               Func<IQueryable<Estado>, IOrderedQueryable<Estado>> orderBy = null,
                               string includeProperties = "")
        {
            return estadoRepository.Get(filter, orderBy, includeProperties);
        }

        public Estado GetEstadoByID(object id)
        {
            return EstadoRepository.GetByID(id);
        }

        public void AgregarEstado(Estado est)
        {
            EstadoRepository.Insert(est);
        }

        public void BorrarEstado(object id)
        {
            EstadoRepository.Delete(id);
        }

        public void BorrarEstado(Estado est)
        {
            EstadoRepository.Delete(est);
        }

        public void ActualizarEstado(Estado est)
        {
            EstadoRepository.Update(est);
        }

        public BindingList<Estado> EstadoBindingList()
        {
            return EstadoRepository.ToBindingList();
        }

        /* Conceptos Fondos */
        public IEnumerable<ConceptoFondos> GetConceptosFondos(Expression<Func<ConceptoFondos, bool>> filter = null,
                               Func<IQueryable<ConceptoFondos>, IOrderedQueryable<ConceptoFondos>> orderBy = null,
                               string includeProperties = "")
        {
            return ConceptoFondosRepository.Get(filter, orderBy, includeProperties);
        }

        public ConceptoFondos GetConceptoFondoByID(object id)
        {
            return ConceptoFondosRepository.GetByID(id);
        }

        public void AgregarConceptoFondo(ConceptoFondos cf)
        {
            ConceptoFondosRepository.Insert(cf);
        }

        public void BorrarConceptoFondo(object id)
        {
            ConceptoFondosRepository.Delete(id);
        }

        public void BorrarConceptoFondo(ConceptoFondos cf)
        {
            ConceptoFondosRepository.Delete(cf);
        }

        public void ActualizarConceptoFondo(ConceptoFondos cf)
        {
            ConceptoFondosRepository.Update(cf);
        }

        public BindingList<ConceptoFondos> ConceptoFondosBindingList()
        {
            return ConceptoFondosRepository.ToBindingList();
        }

        /* Tipo Solicitud */
        public IEnumerable<TipoSolicitud> GetTiposSolicitud(Expression<Func<TipoSolicitud, bool>> filter = null,
                               Func<IQueryable<TipoSolicitud>, IOrderedQueryable<TipoSolicitud>> orderBy = null,
                               string includeProperties = "")
        {
            return TipoSolicitudRepository.Get(filter, orderBy, includeProperties);
        }

        public TipoSolicitud GetTipoSolicitudByID(object id)
        {
            return TipoSolicitudRepository.GetByID(id);
        }

        public void AgregarTipoSolicitud(TipoSolicitud ts)
        {
            TipoSolicitudRepository.Insert(ts);
        }

        public void BorrarTipoSolicitud(object id)
        {
            TipoSolicitudRepository.Delete(id);
        }

        public void BorrarTipoSolicitud(TipoSolicitud ts)
        {
            TipoSolicitudRepository.Delete(ts);
        }

        public void ActualizarTipoSolicitud(TipoSolicitud ts)
        {
            TipoSolicitudRepository.Update(ts);
        }

        public BindingList<TipoSolicitud> TipoSolicitudBindingList()
        {
            return TipoSolicitudRepository.ToBindingList();
        }

        /* Moneda */
        public IEnumerable<Moneda> GetMonedas(Expression<Func<Moneda, bool>> filter = null,
                               Func<IQueryable<Moneda>, IOrderedQueryable<Moneda>> orderBy = null,
                               string includeProperties = "")
        {
            return MonedaRepository.Get(filter, orderBy, includeProperties);
        }

        public Moneda GetMonedaByID(object id)
        {
            return MonedaRepository.GetByID(id);
        }

        public void AgregarMoneda(Moneda mon)
        {
            MonedaRepository.Insert(mon);
        }

        public void BorrarMoneda(object id)
        {
            MonedaRepository.Delete(id);
        }

        public void BorrarMoneda(Moneda mon)
        {
            MonedaRepository.Delete(mon);
        }

        public void ActualizarMoneda(Moneda mon)
        {
            MonedaRepository.Update(mon);
        }

        public BindingList<Moneda> MonedaBindingList()
        {
            return MonedaRepository.ToBindingList();
        }

        /* Operacion */
        public IEnumerable<Operacion> GetOperaciones(Expression<Func<Operacion, bool>> filter = null,
                               Func<IQueryable<Operacion>, IOrderedQueryable<Operacion>> orderBy = null,
                               string includeProperties = "")
        {
            return OperacionRepository.Get(filter, orderBy, includeProperties);
        }

        

        public Operacion GetOperacionByID(object id)
        {
            return OperacionRepository.GetByID(id);
        }

        public void AgregarOperacion(Operacion op)
        {
            OperacionRepository.Insert(op);
        }

        public void BorrarOperacion(object id)
        {
            OperacionRepository.Delete(id);
        }

        public void BorrarOperacion(Operacion op)
        {
            OperacionRepository.Delete(op);
        }

        public void ActualizarOperacion(Operacion op)
        {
            OperacionRepository.Update(op);
        }

        public BindingList<Operacion> OperacionBindingList()
        {
            return OperacionRepository.ToBindingList();
        }

        /* Autorizaciones */
        public IEnumerable<Autorizacion> GetAutorizaciones(Expression<Func<Autorizacion, bool>> filter = null,
                              Func<IQueryable<Autorizacion>, IOrderedQueryable<Autorizacion>> orderBy = null,
                              string includeProperties = "")
        {
            return AutorizacionRepository.Get(filter, orderBy, includeProperties);
        }

        public Autorizacion GetAutorizacionByID(object id)
        {
            return AutorizacionRepository.GetByID(id);
        }

        public void AgregarAutorizacion(Autorizacion aut)
        {
            AutorizacionRepository.Insert(aut);
        }

        public void BorrarAutorizacion(object id)
        {
            AutorizacionRepository.Delete(id);
        }

        public void BorrarAutorizacion(Autorizacion aut)
        {
            AutorizacionRepository.Delete(aut);
        }

        public void ActualizarAutorizacion(Autorizacion aut)
        {
            AutorizacionRepository.Update(aut);
        }

        public BindingList<Autorizacion> AutorizacionBindingList()
        {
            return AutorizacionRepository.ToBindingList();
        }

        /* Cuentas Corrientes */

        public IEnumerable<CuentaCorriente> GetCuentasCorrientes(Expression<Func<CuentaCorriente, bool>> filter = null,
                               Func<IQueryable<CuentaCorriente>, IOrderedQueryable<CuentaCorriente>> orderBy = null,
                               string includeProperties = "")
        {
            return CuentaCorrienteRepository.Get(filter, orderBy, includeProperties);
        }

        public CuentaCorriente GetCuentaCorrienteByID(object id)
        {
            return CuentaCorrienteRepository.GetByID(id);
        }

        public void AgregarCuentaCorriente(CuentaCorriente cc)
        {
            CuentaCorrienteRepository.Insert(cc);
        }

        public void BorrarCuentaCorriente(object id)
        {
            CuentaCorrienteRepository.Delete(id);
        }

        public void BorrarCuentaCorriente(CuentaCorriente cc)
        {
            CuentaCorrienteRepository.Delete(cc);
        }

        public void ActualizarCuentaCorriente(CuentaCorriente cc)
        {
            CuentaCorrienteRepository.Update(cc);
        }

        public BindingList<CuentaCorriente> CuentaCorrienteBindingList()
        {
            return CuentaCorrienteRepository.ToBindingList();
        }

       /* EstadoTransmision */
        public IEnumerable<EstadoTransmision> GetEstadosTransmision(Expression<Func<EstadoTransmision, bool>> filter = null,
                               Func<IQueryable<EstadoTransmision>, IOrderedQueryable<EstadoTransmision>> orderBy = null,
                               string includeProperties = "")
        {
            return EstadoTransmisionRepository.Get(filter, orderBy, includeProperties);
        }

        public EstadoTransmision GetEstadoTransmisionByID(object id)
        {
            return EstadoTransmisionRepository.GetByID(id);
        }

        public void AgregarEstadoTransmision(EstadoTransmision et)
        {
            EstadoTransmisionRepository.Insert(et);
        }

        public void BorrarEstadoTransmision(object id)
        {
            EstadoTransmisionRepository.Delete(id);
        }

        public void BorrarEstadoTransmision(EstadoTransmision et)
        {
            EstadoTransmisionRepository.Delete(et);
        }

        public void ActualizarEstadoTransmision(EstadoTransmision et)
        {
            EstadoTransmisionRepository.Update(et);
        }

        public BindingList<EstadoTransmision> EstadoTransmisionBindingList()
        {
            return EstadoTransmisionRepository.ToBindingList();
        }

        /****** Solicitudes de Fondo ***************/
        public IEnumerable<SolicitudFondo> GetSolicitudesDeFondos(Expression<Func<SolicitudFondo, bool>> filter = null,
                               Func<IQueryable<SolicitudFondo>, IOrderedQueryable<SolicitudFondo>> orderBy = null,
                               string includeProperties = "")
        {
            return SolicitudFondosRepository.Get(filter, orderBy, includeProperties);
        }

        public SolicitudFondo GetSolicitudesDeFondosByID(object id)
        {
            return SolicitudFondosRepository.GetByID(id);
        }

        public void AgregarSolicitudesDeFondos(SolicitudFondo solfon)
        {
            SolicitudFondosRepository.Insert(solfon);
        }

        public void BorrarSolicitudesDeFondos(object id)
        {
            SolicitudFondosRepository.Delete(id);
        }

        public void BorrarSolicitudesDeFondos(SolicitudFondo solfon)
        {
            SolicitudFondosRepository.Delete(solfon);
        }

        public void ActualizarSolicitudDeFondos(SolicitudFondo solfon)
        {
            SolicitudFondosRepository.Update(solfon);
        }

        public BindingList<SolicitudFondo> SolicitudesDeFondoBindingList(SolicitudFondo solfon)
        {
            return SolicitudFondosRepository.ToBindingList();
        }

        

        /* Transmision */
        public IEnumerable<Transmision> GetTransmisiones(Expression<Func<Transmision, bool>> filter = null,
                               Func<IQueryable<Transmision>, IOrderedQueryable<Transmision>> orderBy = null,
                               string includeProperties = "")
        {
            
            return TransmisionRepository.Get(filter, orderBy, includeProperties);
        }

        public Transmision GetTransmisionByID(object id)
        {
            return TransmisionRepository.GetByID(id);
        }

        public void AgregarTransmision(Transmision t)
        {
            AgregarTransaccional<Transmision>(t);
            //TransmisionRepository.Insert(t);
        }

        public void BorrarTransmision(object id)
        {
            BorrarTransaccional<Transmision>(id);
           // TransmisionRepository.Delete(id);
        }

        public void BorrarTransmision(Transmision t)
        {
            BorrarTransaccional<Transmision>(t);
            //TransmisionRepository.Delete(t);
        }

        public void ActualizarTransmision(Transmision t)
        {
            ActualizarTransaccional<Transmision>(t);
            //TransmisionRepository.Update(t);
        }


        /* Proveedor */
        public IEnumerable<Proveedor> GetProveedores(Expression<Func<Proveedor, bool>> filter = null,
                               Func<IQueryable<Proveedor>, IOrderedQueryable<Proveedor>> orderBy = null,
                               string includeProperties = "")
        {
            return ProveedorRepository.Get(filter, orderBy, includeProperties);
        }

        public Proveedor GetProveedorByID(object id)
        {
            return ProveedorRepository.GetByID(id);
        }

        public void AgregarProveedor(Proveedor p)
        {
            ProveedorRepository.Insert(p);
        }

        public void BorrarProveedor(object id)
        {
            ProveedorRepository.Delete(id);
        }

        public void BorrarProveedor(Proveedor p)
        {
            ProveedorRepository.Delete(p);
        }

        public void ActualizarProveedor(Proveedor p)
        {
            //context.Entry(p).Property(x => x.ProveedorIDCentral).IsModified = false;
            ProveedorRepository.Update(p);
        }

        public void RecargarProvedor(Proveedor p)
        {
            ProveedorRepository.RecargarEntidad(p);
        }
        public BindingList<Proveedor> ProveedorBindingList()
        {
            return ProveedorRepository.ToBindingList();
        }

        /* Proveedor */
        public IEnumerable<ProveedorSucursal> GetProveedorSucursales(Expression<Func<ProveedorSucursal, bool>> filter = null,
                               Func<IQueryable<ProveedorSucursal>, IOrderedQueryable<ProveedorSucursal>> orderBy = null,
                               string includeProperties = "")
        {
            return ProveedorSucursalRepository.Get(filter, orderBy, includeProperties);
        }

        public ProveedorSucursal GetProveedorSucursalByID(object id)
        {
            return ProveedorSucursalRepository.GetByID(id);
        }

        public void AgregarProveedorSucursal(ProveedorSucursal p)
        {
            ProveedorSucursalRepository.Insert(p);
        }

        public void BorrarProveedorSucursal(object id)
        {
            ProveedorSucursalRepository.Delete(id);
        }

        public void BorrarProveedorSucursal(ProveedorSucursal p)
        {
            ProveedorSucursalRepository.Delete(p);
        }

        public void ActualizarProveedorSucursal(ProveedorSucursal p)
        {
            ProveedorSucursalRepository.Update(p);
        }

        public void ProveedorSucursalBindingList()
        {
            ProveedorSucursalRepository.ToBindingList();
        }


        /* Pais */
        public IEnumerable<Pais> GetPaises(Expression<Func<Pais, bool>> filter = null,
                               Func<IQueryable<Pais>, IOrderedQueryable<Pais>> orderBy = null,
                               string includeProperties = "")
        {
            return PaisRepository.Get(filter, orderBy, includeProperties);
        }

        public Pais GetPaisByID(object id)
        {
            return PaisRepository.GetByID(id);
        }

        public void AgregarPais(Pais pais)
        {
            PaisRepository.Insert(pais);
        }

        public void BorrarPais(object id)
        {
            PaisRepository.Delete(id);
        }

        public void BorrarPais(Pais pais)
        {
            PaisRepository.Delete(pais);
        }

        public void ActualizarPais(Pais pais)
        {
            PaisRepository.Update(pais);
        }

        public BindingList<Pais> PaisBindingList()
        {
            return PaisRepository.ToBindingList();
        }

        /* Provincia */
        public IEnumerable<Provincia> GetProvincias(Expression<Func<Provincia, bool>> filter = null,
                               Func<IQueryable<Provincia>, IOrderedQueryable<Provincia>> orderBy = null,
                               string includeProperties = "")
        {
            return ProvinciaRepository.Get(filter, orderBy, includeProperties);
        }

        public Provincia GetProvinciaByID(object id)
        {
            return ProvinciaRepository.GetByID(id);
        }

        public void AgregarProvincia(Provincia provincia)
        {
            ProvinciaRepository.Insert(provincia);
        }

        public void BorrarProvincia(object id)
        {
            ProvinciaRepository.Delete(id);
        }

        public void BorrarProvincia(Provincia provincia)
        {
            ProvinciaRepository.Delete(provincia);
        }

        public void ActualizarProvincia(Provincia provincia)
        {
            ProvinciaRepository.Update(provincia);
        }

        public BindingList<Provincia> ProvinciaBindingList()
        {
            return ProvinciaRepository.ToBindingList();
        }


        /* Localidad */
        public IEnumerable<Localidad> GetLocalidades(Expression<Func<Localidad, bool>> filter = null,
                               Func<IQueryable<Localidad>, IOrderedQueryable<Localidad>> orderBy = null,
                               string includeProperties = "")
        {
            return LocalidadRepository.Get(filter, orderBy, includeProperties);
        }

        public Localidad GetLocalidadByID(object id)
        {
            return LocalidadRepository.GetByID(id);
        }

        public void AgregarLocalidad(Localidad Localidad)
        {
            LocalidadRepository.Insert(Localidad);
        }

        public void BorrarLocalidad(object id)
        {
            LocalidadRepository.Delete(id);
        }

        public void BorrarLocalidad(Localidad Localidad)
        {
            LocalidadRepository.Delete(Localidad);
        }

        public void ActualizarLocalidad(Localidad Localidad)
        {
            LocalidadRepository.Update(Localidad);
        }

        public BindingList<Localidad> LocalidadBindingList()
        {
            return LocalidadRepository.ToBindingList();
        }

            public void Save()
            {
                try
                { 
                    context.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                {
                    string message ="";
                    Exception raise = dbEx;
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                                message = string.Format("{0}:{1}",
                                validationErrors.Entry.Entity.ToString(),
                                validationError.ErrorMessage);
                            // raise a new exception nesting
                            // the current instance as InnerException
                            raise = new InvalidOperationException(message, raise);
                        }
                    }
                    Alertas.MensajeOKOnly("Hubo Errores en el proceso de migracion", message);
                    throw raise;
                }
                catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException concurrencyException)
                {
                    string Errores;
                    Errores = concurrencyException.Message + Environment.NewLine;
                    //assume just one
                    var dbEntityEntry = concurrencyException.Entries.First();
                    //store wins
                    dbEntityEntry.Reload();
                    //OR client wins
                    var dbPropertyValues = dbEntityEntry.GetDatabaseValues();
                    dbEntityEntry.OriginalValues.SetValues(dbPropertyValues); //orig = db
                    Alertas.MensajeOKOnly("Hubo Errores en el proceso de migracion", Errores);
                }
                catch (System.Data.Entity.Infrastructure.DbUpdateException updateException)
                {
                    string Errores;
                    Errores = updateException.Message + Environment.NewLine;
                    Console.WriteLine(updateException.Message);
                    //often in innerException
                    Exception innerEx = updateException.InnerException;
                    while (innerEx != null)
                    {
                        Debug.WriteLine(innerEx.Message);
                        Console.WriteLine(innerEx.Message);
                        Errores = Errores + innerEx.Message + Environment.NewLine;
                        innerEx = innerEx.InnerException;
                        Alertas.MensajeOKOnly("Hubo Errores en el proceso de migracion", Errores);
                    }
                    //which exceptions does it relate to
                    foreach (var entry in updateException.Entries)
                    {
                        Debug.WriteLine(entry.Entity);
                        Console.WriteLine(entry.Entity + ":");
                        Errores = Errores + entry.Entity + ":" + Environment.NewLine;
                        PropertyInfo[] properties = entry.Entity.GetType().GetProperties();
                        foreach (PropertyInfo property in properties)
                        {
                            object propertyValue = property.GetValue(entry.Entity, null);
                            Console.WriteLine(property.Name + ":" + propertyValue);
                            Errores = Errores + property.Name + ":" + propertyValue + Environment.NewLine;
                        }
                    }
                    Alertas.MensajeOKOnly("Hubo Errores en el proceso de migracion", Errores);
                }
            }





            #region //**edu**

            private IGenericRepository<PlanesTipo> planestipoRepository;
            private IGenericRepository<PlanesDetalle> planesdetalleRepository;
            private IGenericRepository<PlanesVenci> planesvenciRepository;
            private IGenericRepository<PlanesBonif> planesbonifRepository;
            private IGenericRepository<PlanesParam> planesparamRepository;

            private IGenericRepository<Credito> creditoRepository;
            private IGenericRepository<Cobranza> cobranzaRepository;
            private IGenericRepository<Cuota> cuotaRepository;
            private IGenericRepository<NotasCD> notascdRepository;
            private IGenericRepository<Nota> notaRepository;
            private IGenericRepository<Domicilio> domicilioRepository;
            private IGenericRepository<Telefono> telefonoRepository;
            private IGenericRepository<Mail> mailRepository;
            private IGenericRepository<Refinanciacion> refinanciacionRepository;
            private IGenericRepository<RefinanciacionCuota> refinanciacionCuotaRepository;
            private IGenericRepository<RefinanciacionCobranza> refinanciacionCobranzaRepository;

            #endregion //**edu**


            #region //**edu**

            //33333333333333333333333333333333333333333333333333333333333333333333333333333333333333  credito edu*
            public IGenericRepository<Credito> CreditoRepository
            {
                get
                {
                    if (this.creditoRepository == null)
                    {
                        this.creditoRepository = new GenericRepository<Credito>(context);
                    }
                    return creditoRepository;
                }
            }

            public IEnumerable<Credito> GetCreditos(Expression<Func<Credito, bool>> filter = null,
                                     Func<IQueryable<Credito>, IOrderedQueryable<Credito>> orderBy = null,
                                     string includeProperties = "")
            {
                return CreditoRepository.Get(filter, orderBy, includeProperties);
            }                       // ok

            public Credito GetCreditoByID(object id)
            {
                return CreditoRepository.GetByID(id);
            }                       //ok

            public void AgregarCredito(Credito pp)
            {
                CreditoRepository.Insert(pp);
            }                       //ok
            public void BorrarCredito(object id)
            {
                CreditoRepository.Delete(id);
            }                       //ok
            public void BorrarCredito(Credito pp)
            {
                CreditoRepository.Delete(pp);
            }

            public void ActualizarCredito(Credito pp)
            {
                CreditoRepository.Update(pp);
            }                       //ok

            public BindingList<Credito> CreditoBindingList()
            {
                return CreditoRepository.ToBindingList();
            }                       //ok
            //33333333333333333333333333333333333333333333333333333333333333333333333333333333333333  credito edu* FIN
            //33333333333333333333333333333333333333333333333333333333333333333333333333333333333333 RefinanciacionCobranza edu
            public IGenericRepository<RefinanciacionCobranza> RefinanciacionCobranzaRepository
            {
                get
                {
                    if (this.refinanciacionCobranzaRepository == null)
                    {
                        this.refinanciacionCobranzaRepository = new GenericRepository<RefinanciacionCobranza>(context);
                    }
                    return refinanciacionCobranzaRepository;
                }
            }

            public IEnumerable<RefinanciacionCobranza> GetRefinanciacionCobranzas(Expression<Func<RefinanciacionCobranza, bool>> filter = null,
                                     Func<IQueryable<RefinanciacionCobranza>, IOrderedQueryable<RefinanciacionCobranza>> orderBy = null,
                                     string includeProperties = "")
            {
                return RefinanciacionCobranzaRepository.Get(filter, orderBy, includeProperties);
            }                       // ok

            public RefinanciacionCobranza GetRefinanciacionCobranzaByID(object id)
            {
                return RefinanciacionCobranzaRepository.GetByID(id);
            }                       //ok

            public void AgregarRefinanciacionCobranza(RefinanciacionCobranza pp)
            {
                RefinanciacionCobranzaRepository.Insert(pp);
            }                       //ok
            public void BorrarRefinanciacionCobranza(object id)
            {
                RefinanciacionCobranzaRepository.Delete(id);
            }                       //ok
            public void BorrarRefinanciacionCobranza(RefinanciacionCobranza pp)
            {
                RefinanciacionCobranzaRepository.Delete(pp);
            }

            public void ActualizarRefinanciacionCobranza(RefinanciacionCobranza pp)
            {
                RefinanciacionCobranzaRepository.Update(pp);
            }                       //ok

            public BindingList<RefinanciacionCobranza> RefinanciacionCobranzaBindingList()
            {
                return RefinanciacionCobranzaRepository.ToBindingList();
            }                       //ok
            //33333333333333333333333333333333333333333333333333333333333333333333333333333333333333 RefinanciacionCobranza edu edu

            //33333333333333333333333333333333333333333333333333333333333333333333333333333333333333 RefinanciacionCuota edu
            public IGenericRepository<RefinanciacionCuota> RefinanciacionCuotaRepository
            {
                get
                {
                    if (this.refinanciacionCuotaRepository == null)
                    {
                        this.refinanciacionCuotaRepository = new GenericRepository<RefinanciacionCuota>(context);
                    }
                    return refinanciacionCuotaRepository;
                }
            }

            public IEnumerable<RefinanciacionCuota> GetRefinanciacionCuotas(Expression<Func<RefinanciacionCuota, bool>> filter = null,
                                     Func<IQueryable<RefinanciacionCuota>, IOrderedQueryable<RefinanciacionCuota>> orderBy = null,
                                     string includeProperties = "")
            {
                return RefinanciacionCuotaRepository.Get(filter, orderBy, includeProperties);
            }                       // ok

            public RefinanciacionCuota GetRefinanciacionCuotaByID(object id)
            {
                return RefinanciacionCuotaRepository.GetByID(id);
            }                       //ok

            public void AgregarRefinanciacionCuota(RefinanciacionCuota pp)
            {
                RefinanciacionCuotaRepository.Insert(pp);
            }                       //ok
            public void BorrarRefinanciacionCuota(object id)
            {
                RefinanciacionCuotaRepository.Delete(id);
            }                       //ok
            public void BorrarRefinanciacionCuota(RefinanciacionCuota pp)
            {
                RefinanciacionCuotaRepository.Delete(pp);
            }

            public void ActualizarRefinanciacionCuota(RefinanciacionCuota pp)
            {
                RefinanciacionCuotaRepository.Update(pp);
            }                       //ok

            public BindingList<RefinanciacionCuota> RefinanciacionCuotaBindingList()
            {
                return RefinanciacionCuotaRepository.ToBindingList();
            }                       //ok
            //33333333333333333333333333333333333333333333333333333333333333333333333333333333333333 RefinanciacionCuota edu fin

            //33333333333333333333333333333333333333333333333333333333333333333333333333333333333333 Refinanciacion edu
            public IGenericRepository<Refinanciacion> RefinanciacionRepository
            {
                get
                {
                    if (this.refinanciacionRepository == null)
                    {
                        this.refinanciacionRepository = new GenericRepository<Refinanciacion>(context);
                    }
                    return refinanciacionRepository;
                }
            }

            public IEnumerable<Refinanciacion> GetRefinanciaciones(Expression<Func<Refinanciacion, bool>> filter = null,
                                     Func<IQueryable<Refinanciacion>, IOrderedQueryable<Refinanciacion>> orderBy = null,
                                     string includeProperties = "")
            {
                return RefinanciacionRepository.Get(filter, orderBy, includeProperties);
            }                       // ok

            public Refinanciacion GetRefinanciacionByID(object id)
            {
                return RefinanciacionRepository.GetByID(id);
            }                       //ok

            public void AgregarRefinanciacion(Refinanciacion pp)
            {
                RefinanciacionRepository.Insert(pp);
            }                       //ok
            public void BorrarRefinanciacion(object id)
            {
                RefinanciacionRepository.Delete(id);
            }                       //ok
            public void BorrarRefinanciacion(Refinanciacion pp)
            {
                RefinanciacionRepository.Delete(pp);
            }

            public void ActualizarRefinanciacion(Refinanciacion pp)
            {
                RefinanciacionRepository.Update(pp);
            }                       //ok

            public BindingList<Refinanciacion> RefinanciacionBindingList()
            {
                return RefinanciacionRepository.ToBindingList();
            }                       //ok
            //33333333333333333333333333333333333333333333333333333333333333333333333333333333333333 Refinanciacion Refinanciacion edu
            //33333333333333333333333333333333333333333333333333333333333333333333333333333333333333 mail edu
            public IGenericRepository<Mail> MailRepository
            {
                get
                {
                    if (this.mailRepository == null)
                    {
                        this.mailRepository = new GenericRepository<Mail>(context);
                    }
                    return mailRepository;
                }
            }

            public IEnumerable<Mail> GetMails(Expression<Func<Mail, bool>> filter = null,
                                     Func<IQueryable<Mail>, IOrderedQueryable<Mail>> orderBy = null,
                                     string includeProperties = "")
            {
                return MailRepository.Get(filter, orderBy, includeProperties);
            }                       // ok

            public Mail GetMailByID(object id)
            {
                return MailRepository.GetByID(id);
            }                       //ok

            public void AgregarMail(Mail pp)
            {
                MailRepository.Insert(pp);
            }                       //ok
            public void BorrarMail(object id)
            {
                MailRepository.Delete(id);
            }                       //ok
            public void BorrarMail(Mail pp)
            {
                MailRepository.Delete(pp);
            }

            public void ActualizarMail(Mail pp)
            {
                MailRepository.Update(pp);
            }                       //ok

            public BindingList<Mail> MailBindingList()
            {
                return MailRepository.ToBindingList();
            }                       //ok
            //33333333333333333333333333333333333333333333333333333333333333333333333333333333333333 mail edu edu


            //33333333333333333333333333333333333333333333333333333333333333333333333333333333333333 telefonos edu
            public IGenericRepository<Telefono> TelefonoRepository
            {
                get
                {
                    if (this.telefonoRepository == null)
                    {
                        this.telefonoRepository = new GenericRepository<Telefono>(context);
                    }
                    return telefonoRepository;
                }
            }

            public IEnumerable<Telefono> GetTelefonos(Expression<Func<Telefono, bool>> filter = null,
                                     Func<IQueryable<Telefono>, IOrderedQueryable<Telefono>> orderBy = null,
                                     string includeProperties = "")
            {
                return TelefonoRepository.Get(filter, orderBy, includeProperties);
            }                       // ok

            public Telefono GetTelefonoByID(object id)
            {
                return TelefonoRepository.GetByID(id);
            }                       //ok

            public void AgregarTelefono(Telefono pp)
            {
                TelefonoRepository.Insert(pp);
            }                       //ok
            public void BorrarTelefono(object id)
            {
                TelefonoRepository.Delete(id);
            }                       //ok
            public void BorrarTelefono(Telefono pp)
            {
                TelefonoRepository.Delete(pp);
            }

            public void ActualizarTelefono(Telefono pp)
            {
                TelefonoRepository.Update(pp);
            }                       //ok

            public BindingList<Telefono> TelefonoBindingList()
            {
                return TelefonoRepository.ToBindingList();
            }                       //ok
            //33333333333333333333333333333333333333333333333333333333333333333333333333333333333333 telefonos edu edu

            //33333333333333333333333333333333333333333333333333333333333333333333333333333333333333 doicilio edu
            public IGenericRepository<Domicilio> DomicilioRepository
            {
                get
                {
                    if (this.domicilioRepository == null)
                    {
                        this.domicilioRepository = new GenericRepository<Domicilio>(context);
                    }
                    return domicilioRepository;
                }
            }

            public IEnumerable<Domicilio> GetDomicilios(Expression<Func<Domicilio, bool>> filter = null,
                                     Func<IQueryable<Domicilio>, IOrderedQueryable<Domicilio>> orderBy = null,
                                     string includeProperties = "")
            {
                return DomicilioRepository.Get(filter, orderBy, includeProperties);
            }                       // ok

            public Domicilio GetDomicilioByID(object id)
            {
                return DomicilioRepository.GetByID(id);
            }                       //ok

            public void AgregarDomicilio(Domicilio pp)
            {
                DomicilioRepository.Insert(pp);
            }                       //ok
            public void BorrarDomicilio(object id)
            {
                DomicilioRepository.Delete(id);
            }                       //ok
            public void BorrarDomicilio(Domicilio pp)
            {
                DomicilioRepository.Delete(pp);
            }

            public void ActualizarDomicilio(Domicilio pp)
            {
                DomicilioRepository.Update(pp);
            }                       //ok

            public BindingList<Domicilio> DomicilioBindingList()
            {
                return DomicilioRepository.ToBindingList();
            }                       //ok

            //33333333333333333333333333333333333333333333333333333333333333333333333333333333333333 doicilio edu  fin
            //33333333333333333333333333333333333333333333333333333333333333333333333333333333333333  nota edu*
            public IGenericRepository<Nota> NotaRepository
            {
                get
                {
                    if (this.notaRepository == null)
                    {
                        this.notaRepository = new GenericRepository<Nota>(context);
                    }
                    return notaRepository;
                }
            }

            public IEnumerable<Nota> GetNotas(Expression<Func<Nota, bool>> filter = null,
                                     Func<IQueryable<Nota>, IOrderedQueryable<Nota>> orderBy = null,
                                     string includeProperties = "")
            {
                return NotaRepository.Get(filter, orderBy, includeProperties);
            }                       // ok

            public Nota GetNotaByID(object id)
            {
                return NotaRepository.GetByID(id);
            }                       //ok

            public void AgregarNota(Nota pp)
            {
                NotaRepository.Insert(pp);
            }                       //ok
            public void BorrarNota(object id)
            {
                NotaRepository.Delete(id);
            }                       //ok
            public void BorrarNota(Nota pp)
            {
                NotaRepository.Delete(pp);
            }

            public void ActualizarNota(Nota pp)
            {
                NotaRepository.Update(pp);
            }                       //ok

            public BindingList<Nota> NotaBindingList()
            {
                return NotaRepository.ToBindingList();
            }                       //ok
            //33333333333333333333333333333333333333333333333333333333333333333333333333333333333333  Nota edu* FIN


            //33333333333333333333333333333333333333333333333333333333333333333333333333333333333333  notascd edu*
            public IGenericRepository<NotasCD> NotasCDRepository
            {
                get
                {
                    if (this.notascdRepository == null)
                    {
                        this.notascdRepository = new GenericRepository<NotasCD>(context);
                    }
                    return notascdRepository;
                }
            }

            public IEnumerable<NotasCD> GetNotasCD(Expression<Func<NotasCD, bool>> filter = null,
                                     Func<IQueryable<NotasCD>, IOrderedQueryable<NotasCD>> orderBy = null,
                                     string includeProperties = "")
            {
                return NotasCDRepository.Get(filter, orderBy, includeProperties);
            }                       // ok

            public NotasCD GetNotasCDByID(object id)
            {
                return NotasCDRepository.GetByID(id);
            }                       //ok

            public void AgregarNotasCD(NotasCD pp)
            {
                NotasCDRepository.Insert(pp);
            }                       //ok
            public void BorrarNotasCD(object id)
            {
                NotasCDRepository.Delete(id);
            }                       //ok
            public void BorrarNotasCD(NotasCD pp)
            {
                NotasCDRepository.Delete(pp);
            }

            public void ActualizarNotasCD(NotasCD pp)
            {
                NotasCDRepository.Update(pp);
            }                       //ok

            public BindingList<NotasCD> NotasCDBindingList()
            {
                return NotasCDRepository.ToBindingList();
            }                       //ok
            //33333333333333333333333333333333333333333333333333333333333333333333333333333333333333  NOTASCD edu* FIN



            //33333333333333333333333333333333333333333333333333333333333333333333333333333333333333  Cuota edu*
            public IGenericRepository<Cuota> CuotaRepository
            {
                get
                {
                    if (this.cuotaRepository == null)
                    {
                        this.cuotaRepository = new GenericRepository<Cuota>(context);
                    }
                    return cuotaRepository;
                }
            }

            public IEnumerable<Cuota> GetCuotas(Expression<Func<Cuota, bool>> filter = null,
                                     Func<IQueryable<Cuota>, IOrderedQueryable<Cuota>> orderBy = null,
                                     string includeProperties = "")
            {
                return CuotaRepository.Get(filter, orderBy, includeProperties);
            }                       // ok

            public Cuota GetCuotaByID(object id)
            {
                return CuotaRepository.GetByID(id);
            }                       //ok

            public void AgregarCuota(Cuota pp)
            {
                CuotaRepository.Insert(pp);
            }                       //ok
            public void BorrarCuota(object id)
            {
                CuotaRepository.Delete(id);
            }                       //ok
            public void BorrarCuota(Cuota pp)
            {
                CuotaRepository.Delete(pp);
            }

            public void ActualizarCuota(Cuota pp)
            {
                CuotaRepository.Update(pp);
            }                       //ok

            public BindingList<Cuota> CuotaBindingList()
            {
                return CuotaRepository.ToBindingList();
            }                       //ok
            //33333333333333333333333333333333333333333333333333333333333333333333333333333333333333  Cuota edu* FIN



            //33333333333333333333333333333333333333333333333333333333333333333333333333333333333333  cobranzas edu*
            public IGenericRepository<Cobranza> CobranzaRepository
            {
                get
                {
                    if (this.cobranzaRepository == null)
                    {
                        this.cobranzaRepository = new GenericRepository<Cobranza>(context);
                    }
                    return cobranzaRepository;
                }
            }

            public IEnumerable<Cobranza> GetCobranzas(Expression<Func<Cobranza, bool>> filter = null,
                                     Func<IQueryable<Cobranza>, IOrderedQueryable<Cobranza>> orderBy = null,
                                     string includeProperties = "")
            {
                return CobranzaRepository.Get(filter, orderBy, includeProperties);
            }                       // ok

            public Cobranza GetCobranzaByID(object id)
            {
                return CobranzaRepository.GetByID(id);
            }                       //ok

            public void AgregarCobranza(Cobranza pp)
            {
                CobranzaRepository.Insert(pp);
            }                       //ok
            public void BorrarCobranza(object id)
            {
                CobranzaRepository.Delete(id);
            }                       //ok
            public void BorrarCobranza(Cobranza pp)
            {
                CobranzaRepository.Delete(pp);
            }

            public void ActualizarCobranza(Cobranza pp)
            {
                CobranzaRepository.Update(pp);
            }                       //ok

            public BindingList<Cobranza> CobranzaBindingList()
            {
                return CobranzaRepository.ToBindingList();
            }                       //ok
            //33333333333333333333333333333333333333333333333333333333333333333333333333333333333333  cobranzas edu* FIN

            //22222222222222222222222222222222222222222222222222222222222222222222222222222222222222      PlanesTipo  edu*
            public IGenericRepository<PlanesTipo> PlanesTipoRepository
            {
                get
                {
                    if (this.planestipoRepository == null)
                    {
                        this.planestipoRepository = new GenericRepository<PlanesTipo>(context);
                    }
                    return planestipoRepository;
                }
            }

            public IEnumerable<PlanesTipo> GetPlanesTipos(Expression<Func<PlanesTipo, bool>> filter = null,
                                     Func<IQueryable<PlanesTipo>, IOrderedQueryable<PlanesTipo>> orderBy = null,
                                     string includeProperties = "")
            {
                return PlanesTipoRepository.Get(filter, orderBy, includeProperties);
            }                       // ok

            public PlanesTipo GetPlanesTipoByID(object id)
            {
                return PlanesTipoRepository.GetByID(id);
            }                       //ok

            public void AgregarPlanesTipo(PlanesTipo pp)
            {
                PlanesTipoRepository.Insert(pp);
            }                       //ok
            public void BorrarPlanesTipo(object id)
            {
                PlanesTipoRepository.Delete(id);
            }                       //ok
            public void BorrarPlanesTipo(PlanesTipo pp)
            {
                PlanesTipoRepository.Delete(pp);
            }

            public void ActualizarPlanesTipo(PlanesTipo pp)
            {
                PlanesTipoRepository.Update(pp);
            }                       //ok

            public BindingList<PlanesTipo> PlanesTipoBindingList()
            {
                return PlanesTipoRepository.ToBindingList();
            }                       //ok



            //22222222222222222222222222222222222222222222222222222222222222222222222222222222222222      PlanesTipo  edu*  FIN        
            //22222222222222222222222222222222222222222222222222222222222222222222222222222222222222      PlanesDetalle  edu*  
            public IGenericRepository<PlanesDetalle> PlanesDetalleRepository
            {
                get
                {
                    if (this.planesdetalleRepository == null)
                    {
                        this.planesdetalleRepository = new GenericRepository<PlanesDetalle>(context);
                    }
                    return planesdetalleRepository;
                }
            }

            public IEnumerable<PlanesDetalle> GetPlanesDetalles(Expression<Func<PlanesDetalle, bool>> filter = null,
                                    Func<IQueryable<PlanesDetalle>, IOrderedQueryable<PlanesDetalle>> orderBy = null,
                                    string includeProperties = "")
            {
                return PlanesDetalleRepository.Get(filter, orderBy, includeProperties);
            }                       // ok
            public PlanesDetalle GetPlanesDetalleByID(object id)
            {
                return PlanesDetalleRepository.GetByID(id);
            }                       //ok
            public void AgregarPlanesDetalle(PlanesDetalle pp)
            {
                PlanesDetalleRepository.Insert(pp);
            }                       //ok
            public void BorrarPlanesDetalle(object id)
            {
                PlanesDetalleRepository.Delete(id);
            }                       //ok
            public void BorrarPlanesDetalle(PlanesDetalle pp)
            {
                PlanesDetalleRepository.Delete(pp);
            }

            public void ActualizarPlanesDetalle(PlanesDetalle pp)
            {
                PlanesDetalleRepository.Update(pp);
            }                       //ok

            public BindingList<PlanesDetalle> PlanesDetalleBindingList()
            {
                return PlanesDetalleRepository.ToBindingList();
            }

            //22222222222222222222222222222222222222222222222222222222222222222222222222222222222222      PlanesDetalle  edu*  FIN        

            //22222222222222222222222222222222222222222222222222222222222222222222222222222222222222      PlanesVenci  edu*  FIN        
            public IGenericRepository<PlanesVenci> PlanesVenciRepository
            {
                get
                {
                    if (this.planesvenciRepository == null)
                    {
                        this.planesvenciRepository = new GenericRepository<PlanesVenci>(context);
                    }
                    return planesvenciRepository;
                }
            }

            public IEnumerable<PlanesVenci> GetPlanesVencis(Expression<Func<PlanesVenci, bool>> filter = null,
                                   Func<IQueryable<PlanesVenci>, IOrderedQueryable<PlanesVenci>> orderBy = null,
                                   string includeProperties = "")
            {
                return PlanesVenciRepository.Get(filter, orderBy, includeProperties);
            }                       // ok
            public PlanesVenci GetPlanesVenciByID(object id)
            {
                return PlanesVenciRepository.GetByID(id);
            }                       //ok
            public void AgregarPlanesVenci(PlanesVenci pp)
            {
                PlanesVenciRepository.Insert(pp);
            }                       //ok
            public void BorrarPlanesVenci(object id)
            {
                PlanesVenciRepository.Delete(id);
            }                       //ok     

            public void BorrarPlanesVenci(PlanesVenci pp)
            {
                PlanesVenciRepository.Delete(pp);
            }

            public void ActualizarPlanesVenci(PlanesVenci pp)
            {
                PlanesVenciRepository.Update(pp);
            }                       //ok

            public BindingList<PlanesVenci> PlanesVenciBindingList()
            {
                return PlanesVenciRepository.ToBindingList();
            }

            //22222222222222222222222222222222222222222222222222222222222222222222222222222222222222      PlanesVenci  edu*  FIN        
            //22222222222222222222222222222222222222222222222222222222222222222222222222222222222222      PlanesBonif  edu*        
            public IGenericRepository<PlanesBonif> PlanesBonifRepository
            {
                get
                {
                    if (this.planesbonifRepository == null)
                    {
                        this.planesbonifRepository = new GenericRepository<PlanesBonif>(context);
                    }
                    return planesbonifRepository;
                }
            }

            public IEnumerable<PlanesBonif> GetPlanesBonifs(Expression<Func<PlanesBonif, bool>> filter = null,
                                   Func<IQueryable<PlanesBonif>, IOrderedQueryable<PlanesBonif>> orderBy = null,
                                   string includeProperties = "")
            {
                return PlanesBonifRepository.Get(filter, orderBy, includeProperties);
            }                       // ok
            public PlanesBonif GetPlanesBonifByID(object id)
            {
                return PlanesBonifRepository.GetByID(id);
            }                       //ok
            public void AgregarPlanesBonif(PlanesBonif pb)
            {
                PlanesBonifRepository.Insert(pb);
            }                       //ok
            public void BorrarPlanesBonif(object id)
            {
                PlanesBonifRepository.Delete(id);
            }                       //ok     

            public void BorrarPlanesBonif(PlanesBonif pb)
            {
                PlanesBonifRepository.Delete(pb);
            }

            public void ActualizarPlanesBonif(PlanesBonif pb)
            {
                PlanesBonifRepository.Update(pb);
            }                       //ok

            public BindingList<PlanesBonif> PlanesBonifBindingList()
            {
                return PlanesBonifRepository.ToBindingList();
            }

            //22222222222222222222222222222222222222222222222222222222222222222222222222222222222222      PlanesBonif  edu*  FIN        
            //22222222222222222222222222222222222222222222222222222222222222222222222222222222222222      PlanesBonif  edu*        
            public IGenericRepository<PlanesParam> PlanesParamRepository
            {
                get
                {
                    if (this.planesparamRepository == null)
                    {
                        this.planesparamRepository = new GenericRepository<PlanesParam>(context);
                    }
                    return planesparamRepository;
                }
            }

            public IEnumerable<PlanesParam> GetPlanesParams(Expression<Func<PlanesParam, bool>> filter = null,
                                   Func<IQueryable<PlanesParam>, IOrderedQueryable<PlanesParam>> orderBy = null,
                                   string includeProperties = "")
            {
                return PlanesParamRepository.Get(filter, orderBy, includeProperties);
            }                       // ok
            public PlanesParam GetPlanesParamByID(object id)
            {
                return PlanesParamRepository.GetByID(id);
            }                       //ok
            public void AgregarPlanesParam(PlanesParam pb)
            {
                PlanesParamRepository.Insert(pb);
            }                       //ok
            public void BorrarPlanesParam(object id)
            {
                PlanesParamRepository.Delete(id);
            }                       //ok     

            public void BorrarPlanesParam(PlanesParam pb)
            {
                PlanesParamRepository.Delete(pb);
            }

            public void ActualizarPlanesParam(PlanesParam pb)
            {
                PlanesParamRepository.Update(pb);
            }                       //ok

            public BindingList<PlanesParam> PlanesParamBindingList()
            {
                return PlanesParamRepository.ToBindingList();
            }

            //22222222222222222222222222222222222222222222222222222222222222222222222222222222222222      PlanesVenci  edu*  FIN        
            //**edu**  FIN
            #endregion  //**edu**

            private bool disposed = false;
            protected virtual void Dispose(bool disposing)
            {
                if (!this.disposed)
                {
                    if (disposing)
                    {
                        context.Dispose();
                    }
                }
                this.disposed = true;
            }

            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

    }
}
