using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iComercio.Models;
using iComercio.Auxiliar;

namespace iComercio.DAL
{
    public class UnitOfWork : IUnitOfWork,IDisposable
    {
        private ComercioContext context = new ComercioContext(ConnectionStrings.GetDecryptedConnectionString("ComercioContext"));
        
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
        private IGenericRepository<Empresa>empresaRepository;
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

        public IGenericRepository<Empresa> Empresa
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

        public IGenericRepository<Comercio> Comercio
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


        public IGenericRepository<ConceptoFondos> ConceptoFondos
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

        public IGenericRepository<SolicitudFondo> SolicitudFondos
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

        public IGenericRepository<Estado> Estado
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

        public IGenericRepository<TipoSolicitud> TipoSolicitud
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

        public IGenericRepository<Operacion> Operacion
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

        public IGenericRepository<EstadoTransmision> EstadoTransmision
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

        public IGenericRepository<Transmision> Transmision
        {
            get
            {

                if (this.transmisionRepository  == null)
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

        public void Save()
        {
            context.SaveChanges();
        }

        
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
