using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iComercio.Models
{
    public class ParametrosGlobales
    {
        public Configuracion Configuracion { get; set; }
        public ConfiguracionLocal ConfLocal { get; set; }
        public Empresa Empresa { get; set; }
        public Comercio Comercio { get; set; }
        public int EmpresaID { get; set; }
        public int ComercioID { get; set; }

       
        public EstadoTransmision Enviado { get; set; }
        public EstadoTransmision PendienteDeEnvio { get; set; }
        public EstadoTransmision Recibido { get; set; }
        public EstadoTransmision Erronea { get; set; }
        public EstadoTransmision EnvioEnGrupo { get; set; }
        public EstadoTransmision RevisadaSistema { get; set; }


        public TipoEstado TeEstadoCuentasBancariasEmpleados { get; set; }
        public TipoEstado TeEstadoCuentasBancariasEmpresas { get; set; }
        public TipoEstado TeEstadoChequeras { get; set; }
        public TipoEstado TeEstadoMensajes { get; set; }
        public TipoEstado TeEstadoAlertas { get; set; }
        public TipoEstado TeEstadoSolicitudesFondos { get; set; }
        public TipoEstado TeEstadoAutorizaciones { get; set; }
        public TipoEstado TeEstadoOrdenesDePago { get; set; }
        public TipoEstado TeEstadoEmpleados { get; set; }
        public TipoEstado TeEstadoUsuarios { get; set; }
        public TipoEstado TeEstadoCreditos { get; set; }
        public TipoEstado TeEstadoCheques { get; set; }
        public TipoEstado TeEstadoProveedores { get; set; }
        public TipoEstado TeEstadoProveedoresSucursales { get; set; }
        public TipoEstado TeEstadoConceptoGastos { get; set; }
        public TipoEstado TeEstadoConceptoGastosProveedor { get; set; }
        public TipoEstado TeEstadoCliente { get; set; }
        public TipoEstado TeEstadoGeneral { get; set; }
        public TipoEstado TeEstadoOrdenPago { get; set; }
        public TipoEstado TeEstadoRecibo { get; set; }
        public TipoEstado TeEstadoTransferenciaDeposito { get; set; }


        public Estado SolicitudFondoInicial { get; set; }
        public Estado SolicitudFondoPendResolTesoreria { get; set; }
        public Estado SolicitudFondoRechazadaTesoreria { get; set; }
        public Estado SolicitudFondoPendResolGerencia { get; set; }
        public Estado SolicitudFondoAutorizadaGerencia { get; set; }
        public Estado SolicitudFondoRechazadaGerencia { get; set; }
        public Estado SolicitudFondoAutorizada { get; set; }
        public Estado SolicitudFondoConfirmada { get; set; }
        public Estado SolicitudFondoConfirmadaYFonRet { get; set; }
        public Estado SolicitudFondoAnulada { get; set; }
        public Estado SolicitudFondoAutorizadaEnCAP { get; set; }
        public Estado SolicitudFondoRechazadoEnCAP { get; set; }
        public Estado SolicitudFondoPendResolCap { get; set; }

        public Estado SolicitudFondoAutorizadaEnSecAut { get; set; }
        public Estado SolicitudFondoRechazadoEnSecAut { get; set; }
        public Estado SolicitudFondoPendResolSecAut { get; set; }


        public Estado AutorizacionAceptada { get; set; }
        public Estado AutorizacionEnEspera { get; set; }
        public Estado AutorizacionRechazada { get; set; }
        public Estado AutorizacionAnulada { get; set; }
        public Estado AutorizacionConformada { get; set; }
      

        public Estado ProveedorInicial { get; set; }
        public Estado ProveedorAutorizado { get; set; }
        public Estado ProveedorHabilitado { get; set; }
        public Estado ProveedorInhabilitado { get; set; }
        public Estado ProveedorEliminado { get; set; }

        public Estado ProveedorSucursalInicial { get; set; }
        public Estado ProveedorSucursalAutorizada { get; set; }
        public Estado ProveedorSucursalHabilitada { get; set; }
        public Estado ProveedorSucursalInhabilitada { get; set; }
        public Estado ProveedorSucursalEliminada { get; set; }

        public Estado ConceptoGastoInicial { get; set; }
        public Estado ConceptoGastoAutorizado { get; set; }
        public Estado ConceptoGastoHabilitado { get; set; }
        public Estado ConceptoGastoInhabilitado { get; set; }
        public Estado ConceptoGastoEliminado { get; set; }

        public Estado ConceptoGastoProveedorInicial { get; set; }
        public Estado ConceptoGastoProveedorAutorizado { get; set; }
        public Estado ConceptoGastoProveedorHabilitado { get; set; }
        public Estado ConceptoGastoProveedorInhabilitado { get; set; }
        public Estado ConceptoGastoProveedorEliminado { get; set; }

        public Estado ClienteNuevo { get; set; }
        public Estado ClienteRenovador { get; set; }
        public Estado ClienteImportadoSistemaAnterior { get; set; }

        public Estado OPInicial { get; set; }
        public Estado OPAnulada { get; set; }
        public Estado OPPaga { get; set; }
        public Estado OPRechazada { get; set; }
        public Estado OPAutorizada { get; set; }
        
        public Estado Vigente { get; set; }
        public Estado No_Vigente { get; set; }
        public Estado Eliminado { get; set; }
        public Estado Anulado { get; set; }
               
         
        public Estado CredMoroso { get; set; }
        public Estado CredVigente { get; set; }
        public Estado CredEliminado { get; set; }
               
        public Estado ChequeHabilitado { get; set; }
        public Estado ChequeInhabilitado { get; set; }
        public Estado ChequeAnulado { get; set; }
        public Estado ChequeUtilizado { get; set; }

        public Estado Provisorio { get; set; }
        public Estado Confirmado { get; set; }

        public Estado Pendiente { get; set; }
        public Estado Acreditado { get; set; }

        public Pais Argentina { get; set; }

        public ConceptoFondos RetCob { get; set; }
        public ConceptoFondos ExtBan { get; set; }
        public ConceptoFondos RetCobExtBan { get; set; }
        public ConceptoFondos RetValoresARendir { get; set; }

        public Operacion TransEnviarSolicitudDeFondo { get; set; }
        public Operacion TransConfirmarSolicitudDeFondo { get; set; }
        public Operacion TransAgregarProveedor { get; set; }
        public Operacion TransActualizarProveedor { get; set; }
        public Operacion TransEliminarProveedor { get; set; }
        public Operacion TransAgregarSucursalProveedor { get; set; }
        public Operacion TransActualizarSucursalProveedor { get; set; }
        public Operacion TransEliminarSucursalProveedor { get; set; }
        public Operacion TransAgregarConceptoGastos { get; set; }
        public Operacion TransActualizarConceptoGastos { get; set; }
        public Operacion TransEliminarConceptoGastos { get; set; }
        public Operacion TransAgregarConceptoGastosProveedor { get; set; }
        public Operacion TransEliminarConceptoGastosProveedor { get; set; }
        public Operacion TransAgregarCliente { get; set; }
        public Operacion TransActualizarCliente { get; set; }
        public Operacion TransEliminarCliente { get; set; }
        public Operacion TransAltaCredito { get; set; }
        public Operacion TransBajaCredito { get; set; }
        public Operacion TransAltaCobranza { get; set; }
        public Operacion TransAltaNotaCD { get; set; }
        public Operacion TransBajaNotaCD { get; set; }
        public Operacion TransBajaCobranza { get; set; }
        public Operacion TransBajaRefinanciacion { get; set; }
        public Operacion TransBajaRefinanciacionCobranza { get; set; }
        public Operacion TransActualizarRefinanciacionCuota { get; set; }
        public Operacion TransActualizarRefinanciacionCobranza { get; set; }
        public Operacion TransActualizarCuota { get; set; }
        public Operacion TransAgregarCobranza { get; set; }
        public Operacion TransActualizarCobranza { get; set; }
        public Operacion TransAltaArregloCancelacion { get; set; }
        public Operacion TransAltaPagoAnticipado { get; set; }
        public Operacion TransAltaRefinanciacion { get; set; }
        public Operacion TransAltaRefinanciacionCuota { get; set; }
        public Operacion TransAltaRefinanciacionCobranza { get; set; }
        public Operacion TransActualizarCredito { get; set; }
        public Operacion TransPagoAnticipadoNotaCD { get; set; }
        public Operacion TransImputacionCC { get; set; }
        public Operacion TransArchivo { get; set; }
        public Operacion TransAltaRecibo { get; set; }
        public Operacion TransBajaRecibo { get; set; }
        public Operacion TransAltaTransDep { get; set; }
        public Operacion TransControlDiario { get; set; }
        public Operacion TransActualizarSolicitudFondos { get; set; }
        public Operacion TransAltaCobranzas { get; set; }

        public Operacion TransAltaFF { get; set; }
        public Operacion TransBajaFF { get; set; }
        public Operacion TransActualizarFF { get; set; }
        public Operacion TransAltaCap { get; set; }
        public Operacion TransBajaCap { get; set; }
        public Operacion TransActualizarCap { get; set; }
        public Operacion TransAltaPago { get; set; }
        public Operacion TransBajaPago { get; set; }
        public Operacion TransActualizarPago { get; set; }
        public Operacion TransAltaComprobante { get; set; }
        public Operacion TransBajaComprobante { get; set; }
        public Operacion TransActualizarComprobante { get; set; }

        public Operacion TransAltaGasto { get; set; }
        public Operacion TransBajaGasto { get; set; }
        public Operacion TransInfoAct { get; set; }

        
        
 
        public TipoMovimiento TmDescCobCancAnt    { get; set; }
        public TipoMovimiento TmDescCobPromBoni { get; set; }
        public TipoMovimiento TmAnuCobranza { get; set; }
        public TipoMovimiento TmAjuNegCaja { get; set; }
        public TipoMovimiento TmCredOtorEfec { get; set; }
        public TipoMovimiento TmAnuGasCredOtor { get; set; }
        public TipoMovimiento TmAnuDescAnt { get; set; }
        public TipoMovimiento TmRetBcoCaja { get; set; }
        public TipoMovimiento TmAnuRetBcoCaja { get; set; }
        public TipoMovimiento TmRetBcoPropioCaja { get; set; }
        public TipoMovimiento TmAnuRetBcoPropioCaja { get; set; }
        public TipoMovimiento TmCobranza { get; set; }
        public TipoMovimiento TmAjuPosCaja { get; set; }
        public TipoMovimiento TmCobComAdh { get; set; }
        public TipoMovimiento TmGasDescCredOtor { get; set; }
        public TipoMovimiento TmAnuCredOtorEfec { get; set; }
        public TipoMovimiento TmCuotaAdelantada { get; set; }
        public TipoMovimiento TmAnuCuotaAdelantada { get; set; }
        public TipoMovimiento TmCGN { get; set; }
        public TipoMovimiento TmDevChequePropio { get; set; }
        public TipoMovimiento TmDescPunitorio { get; set; }
        public TipoMovimiento TmIntNoCobrados { get; set; }
        public TipoMovimiento TmAjuRedNeg { get; set; }
        public TipoMovimiento TmRec { get; set; }
        public TipoMovimiento TmIntACom { get; set; }
        public TipoMovimiento TmAjuRedPos { get; set; }
        public TipoMovimiento TmTel { get; set; }
        public TipoMovimiento TmVarios { get; set; }
        public TipoMovimiento TmCtaYOrdenValle { get; set; }
        public TipoMovimiento TmDepCobRec { get; set; }
        public TipoMovimiento TmAnuDepCobRec { get; set; }
        public TipoMovimiento TmDepCobComAdh { get; set; }
        public TipoMovimiento TmAnuDepCobComAdh { get; set; }
        public TipoMovimiento TmValDepABco { get; set; }
        public TipoMovimiento TmAnuValDepABco { get; set; }
        public TipoMovimiento TmNC { get; set; }
        public TipoMovimiento TmAnulNC { get; set; }
        public TipoMovimiento TmND { get; set; }
        public TipoMovimiento TmAnulND { get; set; }
        public TipoMovimiento TmAnulDesCobBoni { get; set; }
        public TipoMovimiento TmDepositoCuentaPropia { get; set; }
        public TipoMovimiento TmAnuDepositoCuentaPropia { get; set; }
        public TipoMovimiento TmCompensacion { get; set; }
        public TipoMovimiento TmAnuCompensacion { get; set; }
        public TipoMovimiento TmDepAComer { get; set; }
        public TipoMovimiento TmAnuDepAComer { get; set; }
        public TipoMovimiento TmDepCobComer { get; set; }
        public TipoMovimiento TmAnuDepCobComer { get; set; }
        public TipoMovimiento TmCobPorDebito{ get; set; }
        public TipoMovimiento TmAnuCobPorDebito { get; set; }

        public TipoMovimiento TmGastosFF { get; set; }
        public TipoMovimiento TmAnuGastosFF { get; set; }
        public TipoMovimiento TmGastosCAP { get; set; }
        public TipoMovimiento TmAnuGastosCAP { get; set; }

        public TipoMovimiento TmComisCredOtorEfec { get; set; }//
        public TipoMovimiento TmAnuComisCredOtorEfec { get; set; }//eduardo cambio

        public TipoMovimiento TmCobPorDepBanc { get; set; }
        public TipoMovimiento TmAnuCobPorDepBanc { get; set; }

        public TipoMovimiento TmIngCobComAdh { get; set; }
        public TipoMovimiento TmAnuIngCobComAdh { get; set; }

        public TipoMovimiento TmRetEfecCaja { get; set; }
        public TipoMovimiento TmAnuRetEfecCaja { get; set; }
        
      
        public TipoMovimiento TmNCProv { get; set; }
        public TipoMovimiento TmNDProv { get; set; }
        public TipoMovimiento TmGastosProv { get; set; }
        public TipoMovimiento TmAvisoPagoNegProv { get; set; }
        public TipoMovimiento TmAvisoPagoProv { get; set; }
        public TipoMovimiento TmMinutaProv { get; set; }
        public TipoMovimiento TmReciboProv { get; set; }

        public TipoMovimiento TmDescPuniRefi { get; set; }
        public TipoMovimiento TmAnuDescPuniRefi { get; set; }

        public TipoMovimiento TmPagoCom { get; set; }
        public TipoMovimiento TmAnuPagoCom { get; set; }

        public ClaseMovimiento Ingreso { get; set; }
        public ClaseMovimiento Egreso { get; set; }
        

        public TipoSolicitud tsVenta { get; set; }
        public TipoSolicitud tsVentaAnticipada { get; set; }
        public TipoSolicitud tsCap { get; set; }
        public TipoSolicitud tsFF { get; set; }
        public TipoSolicitud tsDepositoAComercio { get; set; }

        public Moneda Peso { get; set; }

        public ClaseDato DatoCliente { get; set; }
        public ClaseDato DatoEmpresa { get; set; }
        
        public TipoAval AvalSueldo { get; set; }
        public TipoAval AvalCamara { get; set;}
        public TipoAval AvalCredAnt { get; set; }
        public TipoAval AvalRenueva { get; set; }

        public MedioDePago Efectivo { get; set; }
        public MedioDePago Cheque { get; set; }
        public MedioDePago TransferenciaBancaria { get; set; }

        public TipoPago TpaACuenta { get; set; }
        public TipoPago TpaBonificada { get; set; }
        public TipoPago TpaCuota { get; set; }
        public TipoPago TpaAdelantoRefi { get; set; }
        public TipoPago TpaDebitoDirecto { get; set; }
        public TipoPago TpaTarjetaDebito { get; set; }
        public TipoPago TpaTarjetaCredito { get; set; }
        public TipoPago TpaArreglo { get; set; }
        public TipoPago TpaAnulada { get; set; }
        public TipoPago TpaPuniBaja { get; set; }
        public TipoPago TpaPuniQuit { get; set; }
        public TipoPago TpaRefi { get; set; }
        public TipoPago TpaAbogado { get; set; }
        public TipoPago TpaAnticipado { get; set; }
        public TipoPago TpaAgrSis { get; set; }
        

        public TipoComercio TpComercio { get; set; }
        public TipoComercio TpReceptoria { get; set; }
        public TipoComercio TpCobrador { get; set; }
        public TipoComercio TpAbogado { get; set; }
        public TipoComercio TpReceptoriasAntiguas { get; set; }
        public TipoComercio TpComerciosAntiguos { get; set; }
        public TipoComercio TpCasaCentral { get; set; }        

        public TipoTransferenciaDeposito ttdFinanciera { get; set; }
        public TipoTransferenciaDeposito ttdComercio { get; set; }

        public Usuario uSistema { get; set; }

        public string UriCreditos { get; set; }
        public string UriAltaCobranza { get; set; }
        public string UriAltaCobranzas { get; set; }
        public string UriArregloCancelacion { get; set; }
        public string UriPagoAnticipado { get; set; }
        public string UriRefinanciacion { get; set; }
        public string UriRefinanciacionCobranza { get; set; }
        public string UriClientes { get; set; }
        public string UriArchivos { get; set; }
        public string UriRecibos { get; set; }
        public string UriTransDep { get; set; }
        public string UriControlDiario { get; set; }
        public string UriSolicitarFondos { get; set; }
        public string UriSolicitudFondosConceptoGastosProveedor { get; set; }
        public string UriGastos { get; set; }

        public string UriCap { get; set; }
        public string UriFF { get; set; }
        public string UriPago { get; set; }
        public string UriComprobantes { get; set; }
        public string UriInfoAct { get; set; }
        
                
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public const int EstadoVigenteID = 85;
        public const int ClaseDatoClienteID = 1;
        public const int ClaseDatoEmpresaID = 2;


        public TipoImpresion ImpAlta { get; set; }
        public TipoImpresion ImpCobranzas { get; set; }
        public TipoImpresion ImpDebito  { get; set; }

        /*cdcnvo_10022021*/
        public string TipoNotaCredito { get; set; }
        public string TipoNotaDebito { get; set; }
        /**/

        /*M*/
        public MetodoFuncionamiento mfNormal = new MetodoFuncionamiento("N", "Normal");
        public MetodoFuncionamiento mfAutomatico = new MetodoFuncionamiento("A", "Automático");
        public MetodoFuncionamiento mfManual = new MetodoFuncionamiento("M", "Manual");

        public Empresa EmpresaM { get; set; }
        public Comercio ComercioM { get; set; }
        public int EmpresaMID { get; set; }
        public int ComercioMID { get; set; }

        /*M*/
        
        
        public ParametrosGlobales(BusinessLayer bl)
        {
            //Recordar que no se pueden usar llamados de bl que tengan usn dentro de si mismo a parametrosGlobales, sino produciría ciclos
            //try
            //{
                this.Configuracion = new Configuracion();
                Configuracion.Initialize();
                this.ConfLocal = new ConfiguracionLocal();
                ConfLocal.Initialize("iComercio");
                this.Comercio = bl.GetComercios(c => c.Principal == true, null, "Empresa").FirstOrDefault();
                this.Empresa = Comercio.Empresa;
                this.EmpresaID = Empresa.EmpresaID.Value;
                this.ComercioID = Comercio.ComercioID;
                this.Configuracion.NombreBD = "Comercio" + ComercioID.ToString();

                try
                {
                    this.ComercioM = bl.Get<Comercio>(99, c => c.Principal == true, null, "Empresa").FirstOrDefault();
                    if (ComercioM != null)
                    {
                        this.EmpresaM = ComercioM.Empresa;
                        this.EmpresaMID = EmpresaM.EmpresaID.Value;
                        this.ComercioMID = ComercioM.ComercioID;
                    }
                }
                catch (Exception ex)
                {
                    log.Debug("PRIMER INICIO CREANDO BASE COMERCIOPRU");
                }

                this.TeEstadoCuentasBancariasEmpleados  = bl.GetByID<TipoEstado>(1,1);
                this.TeEstadoCuentasBancariasEmpresas = bl.GetByID<TipoEstado>(1, 2);
                this.TeEstadoChequeras = bl.GetByID<TipoEstado>(1, 3);
                this.TeEstadoMensajes = bl.GetByID<TipoEstado>(1, 4);
                this.TeEstadoAlertas = bl.GetByID<TipoEstado>(1, 5);
                this.TeEstadoSolicitudesFondos = bl.GetByID<TipoEstado>(1, 6);
                this.TeEstadoAutorizaciones = bl.GetByID<TipoEstado>(1, 7);
                this.TeEstadoOrdenesDePago = bl.GetByID<TipoEstado>(1, 8);
                this.TeEstadoEmpleados = bl.GetByID<TipoEstado>(1, 9);
                this.TeEstadoUsuarios = bl.GetByID<TipoEstado>(1, 10);
                this.TeEstadoCreditos = bl.GetByID<TipoEstado>(1, 11);
                this.TeEstadoCheques = bl.GetByID<TipoEstado>(1, 12);
                this.TeEstadoProveedores = bl.GetByID<TipoEstado>(1, 13);
                this.TeEstadoProveedoresSucursales = bl.GetByID<TipoEstado>(1, 14);
                this.TeEstadoConceptoGastos = bl.GetByID<TipoEstado>(1, 15);
                this.TeEstadoConceptoGastosProveedor = bl.GetByID<TipoEstado>(1, 16);
                this.TeEstadoCliente = bl.GetByID<TipoEstado>(1, 17);
                this.TeEstadoGeneral = bl.GetByID<TipoEstado>(1, 18);
                this.TeEstadoOrdenPago = bl.GetByID<TipoEstado>(1, 19);
                this.TeEstadoRecibo = bl.GetByID<TipoEstado>(1, 20);
                this.TeEstadoTransferenciaDeposito = bl.GetByID<TipoEstado>(1, 21);                
                    
                this.Enviado = bl.GetEstadoTransmisionByID(1);
                this.PendienteDeEnvio = bl.GetEstadoTransmisionByID(2);
                this.Recibido = bl.GetEstadoTransmisionByID(3);
                this.Erronea = bl.GetEstadoTransmisionByID(4);
                this.EnvioEnGrupo = bl.GetEstadoTransmisionByID(5);
                this.RevisadaSistema = bl.GetEstadoTransmisionByID(6);

                this.SolicitudFondoInicial = bl.GetEstadoByID(21);
                this.SolicitudFondoPendResolTesoreria = bl.GetEstadoByID(22);
                this.SolicitudFondoRechazadaTesoreria = bl.GetEstadoByID(23);
                this.SolicitudFondoPendResolGerencia = bl.GetEstadoByID(24);
                this.SolicitudFondoAutorizadaGerencia = bl.GetEstadoByID(25);
                this.SolicitudFondoRechazadaGerencia = bl.GetEstadoByID(26);
                this.SolicitudFondoAutorizada = bl.GetEstadoByID(28);
                this.SolicitudFondoConfirmada = bl.GetEstadoByID(33);
                this.SolicitudFondoConfirmadaYFonRet = bl.GetEstadoByID(93);
                this.SolicitudFondoAnulada = bl.GetEstadoByID(59);
                this.SolicitudFondoAutorizadaEnCAP = bl.GetEstadoByID(79);
                this.SolicitudFondoRechazadoEnCAP = bl.GetEstadoByID(80);
                this.SolicitudFondoPendResolCap = bl.GetEstadoByID(81);

                this.SolicitudFondoAutorizadaEnSecAut = bl.GetEstadoByID(104);
                this.SolicitudFondoRechazadoEnSecAut = bl.GetEstadoByID(105);
                this.SolicitudFondoPendResolSecAut = bl.GetEstadoByID(106);

                this.AutorizacionAceptada = bl.GetEstadoByID(99);
                this.AutorizacionEnEspera = bl.GetEstadoByID(100);
                this.AutorizacionRechazada = bl.GetEstadoByID(101);
                this.AutorizacionAnulada = bl.GetEstadoByID(102);
                this.AutorizacionConformada = bl.GetEstadoByID(103);


                this.ProveedorInicial = bl.GetEstadoByID(59);
                this.ProveedorAutorizado = bl.GetEstadoByID(60);
                this.ProveedorHabilitado = bl.GetEstadoByID(61);
                this.ProveedorInhabilitado = bl.GetEstadoByID(62);
                this.ProveedorEliminado = bl.GetEstadoByID(63);

                this.ProveedorSucursalInicial = bl.GetEstadoByID(64);
                this.ProveedorSucursalAutorizada = bl.GetEstadoByID(65);
                this.ProveedorSucursalHabilitada = bl.GetEstadoByID(66);
                this.ProveedorSucursalInhabilitada = bl.GetEstadoByID(67);
                this.ProveedorSucursalEliminada = bl.GetEstadoByID(68);

                this.ConceptoGastoInicial = bl.GetEstadoByID(69);
                this.ConceptoGastoAutorizado = bl.GetEstadoByID(70);
                this.ConceptoGastoHabilitado = bl.GetEstadoByID(71);
                this.ConceptoGastoInhabilitado = bl.GetEstadoByID(72);
                this.ConceptoGastoEliminado = bl.GetEstadoByID(73);
            
                this.ConceptoGastoProveedorInicial = bl.GetEstadoByID(74);
                this.ConceptoGastoProveedorAutorizado = bl.GetEstadoByID(75);
                this.ConceptoGastoProveedorHabilitado = bl.GetEstadoByID(76);
                this.ConceptoGastoProveedorInhabilitado = bl.GetEstadoByID(77);
                this.ConceptoGastoProveedorEliminado = bl.GetEstadoByID(78);

                this.ClienteNuevo = bl.GetEstadoByID(82);
                this.ClienteRenovador = bl.GetEstadoByID(83);
                this.ClienteImportadoSistemaAnterior = bl.GetEstadoByID(84);

                this.Vigente = bl.GetEstadoByID(85);
                this.No_Vigente = bl.GetEstadoByID(86);
                this.Eliminado = bl.GetEstadoByID(87);
                this.Anulado = bl.GetEstadoByID(98);

                this.CredMoroso = bl.GetEstadoByID(50);
                this.CredVigente = bl.GetEstadoByID(51);
                this.CredEliminado = bl.GetEstadoByID(52);
              
                
                this.ChequeHabilitado = bl.GetEstadoByID(53);
                this.ChequeInhabilitado = bl.GetEstadoByID(54);
                this.ChequeAnulado = bl.GetEstadoByID(56);
                this.ChequeUtilizado = bl.GetEstadoByID(58);

                this.Provisorio = bl.GetEstadoByID(94);
                this.Confirmado = bl.GetEstadoByID(95);

                this.Pendiente = bl.GetEstadoByID(96);
                this.Acreditado = bl.GetEstadoByID(97);

                this.OPInicial = bl.GetEstadoByID(88);
                this.OPAnulada = bl.GetEstadoByID(89);
                this.OPPaga = bl.GetEstadoByID(90);
                this.OPRechazada = bl.GetEstadoByID(91);
                this.OPAutorizada = bl.GetEstadoByID(92);
                
                this.RetCob = bl.GetConceptoFondoByID(1);
                this.ExtBan = bl.GetConceptoFondoByID(2);
                this.RetValoresARendir = bl.GetConceptoFondoByID(4);

                this.TransEnviarSolicitudDeFondo = bl.GetOperacionByName("TransEnviarSolicitudDeFondo");
                this.TransConfirmarSolicitudDeFondo = bl.GetOperacionByName("TransConfirmarSolicitudDeFondo");
                this.TransAgregarProveedor = bl.GetOperacionByName("TransAgregarProveedor");
                this.TransActualizarProveedor = bl.GetOperacionByName("TransActualizarProveedor");
                this.TransEliminarProveedor = bl.GetOperacionByName("TransEliminarProveedor");
                this.TransAgregarSucursalProveedor = bl.GetOperacionByName("TransAgregarSucursalProveedor");
                this.TransActualizarSucursalProveedor = bl.GetOperacionByName("TransActualizarSucursalProveedor");
                this.TransEliminarSucursalProveedor = bl.GetOperacionByName("TransEliminarSucursalProveedor");
                this.TransAgregarConceptoGastos = bl.GetOperacionByName("TransAgregarConceptoGastos");
                this.TransActualizarConceptoGastos = bl.GetOperacionByName("TransActualizarConceptoGastos");
                this.TransEliminarConceptoGastos = bl.GetOperacionByName("TransEliminarConceptoGastos");
                this.TransAgregarConceptoGastosProveedor = bl.GetOperacionByName("TransAgregarConceptoGastoProveedor");
                this.TransEliminarConceptoGastosProveedor = bl.GetOperacionByName("TransEliminarConceptoGastoProveedor");
                this.TransAgregarCliente = bl.GetOperacionByName("TransAgregarCliente");
                this.TransActualizarCliente = bl.GetOperacionByName("TransActualizarCliente");
                this.TransEliminarCliente = bl.GetOperacionByName("TransEliminarCliente");
                this.TransAltaCredito = bl.GetOperacionByName("TransAltaCredito");
                this.TransBajaCredito = bl.GetOperacionByName("TransBajaCredito");
                this.TransAltaCobranza = bl.GetOperacionByName("TransAltaCobranza");
                this.TransAltaNotaCD = bl.GetOperacionByName("TransAltaNotaCD");
                this.TransBajaNotaCD = bl.GetOperacionByName("TransBajaNotaCD");
                this.TransBajaCobranza = bl.GetOperacionByName("TransBajaCobranza");
                this.TransBajaRefinanciacion = bl.GetOperacionByName("TransBajaRefinanciacion");
                this.TransBajaRefinanciacionCobranza = bl.GetOperacionByName("TransBajaRefinanciacionCobranza");
                this.TransActualizarRefinanciacionCuota = bl.GetOperacionByName("TransActualizarRefinanciacionCuota");
                this.TransActualizarRefinanciacionCobranza = bl.GetOperacionByName("TransActualizarRefinanciacionCobranza");
                this.TransActualizarCuota = bl.GetOperacionByName("TransActualizarCuota");
                this.TransAgregarCobranza = bl.GetOperacionByName("TransAgregarCobranza");
                this.TransActualizarCobranza = bl.GetOperacionByName("TransActualizarCobranza");
                this.TransAltaArregloCancelacion = bl.GetOperacionByName("TransAltaArregloCancelacion");
                this.TransAltaPagoAnticipado = bl.GetOperacionByName("TransAltaPagoAnticipado");
                this.TransAltaRefinanciacion = bl.GetOperacionByName("TransAltaRefinanciacion");
                this.TransAltaRefinanciacionCobranza = bl.GetOperacionByName("TransAltaRefinanciacionCobranza");
                this.TransActualizarCredito = bl.GetOperacionByName("TransActualizarCredito");
                this.TransAltaRefinanciacionCuota = bl.GetOperacionByName("TransAltaRefinanciacionCuota");
                this.TransPagoAnticipadoNotaCD = bl.GetOperacionByName("TransPagoAnticipadoNotaCD");
                this.TransImputacionCC = bl.GetOperacionByName("TransImputacionCC");
                this.TransArchivo = bl.GetOperacionByName("TransArchivo");
                this.TransAltaRecibo = bl.GetOperacionByName("TransAltaRecibo");
                this.TransBajaRecibo = bl.GetOperacionByName("TransBajaRecibo");            
                this.TransAltaTransDep = bl.GetOperacionByName("TransAltaTransDep");
                this.TransControlDiario = bl.GetOperacionByName("TransControlDiario");
                this.TransActualizarSolicitudFondos = bl.GetOperacionByName("TransActualizarSolicitudFondos");
                this.TransAltaFF = bl.GetOperacionByName("TransAltaFF");
                this.TransBajaFF = bl.GetOperacionByName("TransBajaFF");
                this.TransActualizarFF = bl.GetOperacionByName("TransActualizarFF");
                this.TransAltaCap = bl.GetOperacionByName("TransAltaCap");
                this.TransBajaCap = bl.GetOperacionByName("TransBajaCap");
                this.TransActualizarCap = bl.GetOperacionByName("TransActualizarCap");
                this.TransAltaPago = bl.GetOperacionByName("TransAltaPago");
                this.TransBajaPago = bl.GetOperacionByName("TransBajaPago");
                this.TransActualizarPago = bl.GetOperacionByName("TransActualizarPago");
                this.TransAltaComprobante = bl.GetOperacionByName("TransAltaComprobante");
                this.TransBajaComprobante = bl.GetOperacionByName("TransBajaComprobante");
                this.TransActualizarComprobante = bl.GetOperacionByName("TransActualizarComprobante");
                this.TransAltaCobranzas = bl.GetOperacionByName("TransAltaCobranzas");
                this.TransAltaGasto = bl.GetOperacionByName("TransAltaGasto");
                this.TransBajaGasto = bl.GetOperacionByName("TransBajaGasto");
                this.TransInfoAct = bl.GetOperacionByName("TransInfoAct");

                this.Ingreso = new Ingreso(1, "Ingreso", "Ingreso");
                this.Egreso = new Egreso(2, "Egreso", "Egreso");

                this.TmDescCobCancAnt = new TipoMovimiento(11, "Descuento Cobranza por Cancelación Anticipada", "Descuento Cobranza por Cancelación Anticipada", "", 2,Egreso);
                this.TmDescCobPromBoni = new TipoMovimiento(12, "Descuento Cobranza por Promoción Bonificada", "Descuento Cobranza por Promoción Bonificada", "", 2, Egreso);
                this.TmAnuCobranza = new TipoMovimiento(13, "Anulación Cobranza", "Anulación Cobranza", "", 2,Egreso);
                this.TmAjuNegCaja = new TipoMovimiento(14, "Ajuste Negativo Caja", "Ajuste Negativo Caja", "", 2, Egreso);
                this.TmCredOtorEfec = new TipoMovimiento(20, "Créditos Otorgados en Efectivo", "Créditos Otorgados en Efectivo", "", 2, Egreso);
                this.TmAnuGasCredOtor = new TipoMovimiento(21, "Anulación Gastos de Creditos Otorgados", "Anulación Gastos de Creditos Otorgados", "", 2, Egreso);
                this.TmAnuDescAnt = new TipoMovimiento(22, "Anulacion descuento Anticipada", "Anulacion descuento Anticipada", "", 1, Ingreso);
                this.TmRetEfecCaja = new TipoMovimiento(23, "Retiro en efectivo de Caja", "Retiro en efectivo de Caja", "NREC", 2, Egreso, "M", 24);
                this.TmAnuRetEfecCaja = new TipoMovimiento(24, "Anulación Retiro en efectivo de Caja", "Anulación Retiro en efectivo de Caja", "ANREC", 2, Ingreso, "M", 0);

                this.TmNC = new TipoMovimiento(36, "Nota de Crédito", "Nota de Crédito", "", 2, Egreso);
                this.TmAnulNC = new TipoMovimiento(45, "Anulación Nota de Crédito", "Anulación Nota de Crédito", "", 1, Ingreso);
                this.TmND = new TipoMovimiento(37, "Nota de Débito", "Nota de Débito", "", 1, Ingreso);
                this.TmAnulND = new TipoMovimiento(46, "Anulación Nota de Débito", "Anulación Nota de Débito", "", 1, Egreso);
                this.TmAnulDesCobBoni = new TipoMovimiento(47, " Anulación Descuento Cobranza Bonificada", " Anulación Descuento Cobranza Bonificada", "", 1, Ingreso);

                this.TmDepositoCuentaPropia = new TipoMovimiento(48, "Depósito en cuenta Propia", "Depósito en cuenta Propia", "NREC", 1, Egreso);
                this.TmAnuDepositoCuentaPropia = new TipoMovimiento(49, "Anulación Depósito en cuenta Propia", "Anulación Depósito en cuenta Propia", "ANREC", 1, Ingreso);
                this.TmRetBcoPropioCaja = new TipoMovimiento(50, "Retiro de cuenta Propia a Caja", "Retiro de cuenta Propia a Caja", "NREC", 1, Ingreso);
                this.TmAnuRetBcoPropioCaja = new TipoMovimiento(51, "Anulación Retiro de cuenta Propia a Caja", "Anulación de cuenta Propia a Caja", "ANREC", 2, Egreso);
            
                this.TmCobranza = new TipoMovimiento(100, "Cobranza", "Cobranza", "", 1, Ingreso);

                this.TmCobComAdh = new TipoMovimiento(120, "Cobranza de Comercio Adherido", "Cobranza de Comercio Adherido", "", 1, Ingreso);
                this.TmGasDescCredOtor = new TipoMovimiento(200, "Gastos Descontados a Creditos Otorgados", "Gastos Descontados a Creditos Otorgados", "", 1, Ingreso);
                this.TmAnuCredOtorEfec = new TipoMovimiento(201, "Anulación Créditos Otorgados en Efectivo", "Anulación Créditos Otorgados en Efectivo", "", 1, Ingreso);
                //this.TmAnuCredOtorEfec = new TipoMovimiento(210, "Retiro Cobranza para Ventas", "Retiro Cobranza para Ventas", "", 1, Ingreso);
                //this.TmAnuCredOtorEfec = new TipoMovimiento(201, "Retiro Cobranza para Cuentas a Pagar", "Retiro Cobranza para Cuentas a Pagar", "", 1, Ingreso);
                this.TmCuotaAdelantada = new TipoMovimiento(230, "Cuota Adelantada", "Cuota Adelantada", "", 1, Ingreso);
                this.TmAnuCuotaAdelantada = new TipoMovimiento(233, "Anulacion de Cuota Adelantada", "Anulacion de Cuota Adelantada", "", 2, Egreso);
                this.TmCGN = new TipoMovimiento(300, "Cancelación Gs. por nosotros", "Cancelación Gs. por nosotros", "CGN", 2, Egreso);
                this.TmDevChequePropio = new TipoMovimiento(301, "Devolución cheque propio", "Devolución cheque propio", "DCH", 2, Egreso);
                this.TmDescPunitorio = new TipoMovimiento(302, "Descuento punitório", "Descuento punitório", "DCP", 2, Egreso);
                this.TmIntNoCobrados = new TipoMovimiento(303, "Intereses no cobrados", "Intereses no cobrados", "INC", 2, Egreso);
                this.TmAjuRedNeg = new TipoMovimiento(304, "Ajuste redondéo negativo", "Ajuste redondéo negativo", "AR-", 2, Egreso);
                this.TmRec = new TipoMovimiento(305, "Recibo", "Recibo", "REC", 2, Egreso);
                this.TmIntACom = new TipoMovimiento(306, "Intereses a Comercio", "Intereses a Comercio", "INT", 1, Ingreso);
                this.TmAjuRedPos = new TipoMovimiento(307, "Ajuste redondeo positivo", "Ajuste redondeo positivo", "AR+", 1, Ingreso);
                this.TmTel = new TipoMovimiento(308, "Teléfono", "Teléfono", "TEL", 1, Ingreso);
                this.TmVarios = new TipoMovimiento(309, "Varios", "Varios", "VAR", 1, Ingreso);
                this.TmCtaYOrdenValle = new TipoMovimiento(310, "Por Cta y Orden VALLE", "Por Cta y Orden VALLE", "CDV", 1, Ingreso);
               
                this.TmRetBcoCaja = new TipoMovimiento(400, "Retiro de Bco A Caja", "Retiro de Bco A Caja", "NREC", 1, Ingreso);
                this.TmAnuRetBcoCaja = new TipoMovimiento(52, "Anulación Retiro de Bco A Caja", "Anulación Retiro de Bco A Caja", "ANREC", 2, Egreso);
                this.TmDepCobRec = new TipoMovimiento(610, "Depósito Cobranza Receptoría", "Depósito Cobranza Receptoría", "NREC", 2, Egreso);
                this.TmAnuDepCobRec = new TipoMovimiento(611, "Anulación Depósito Cobranza Receptoría", "Anulación Depósito Cobranza Receptoría", "ANREC", 1, Ingreso);
                this.TmDepCobComAdh = new TipoMovimiento(620, "Deposito Cobr. Com Adherido", "Deposito Cobr. Com Adherido", "NREC", 2, Egreso);    
                this.TmAnuDepCobComAdh = new TipoMovimiento(54, "Anulación Deposito Cobr. Com Adherido", "Anulación Deposito Cobr. Com Adherido", "ANREC", 1, Ingreso);
                this.TmValDepABco = new TipoMovimiento(701, "Valores a Depositar a Banco", "Valores a Depositar a Banco", "NREC", 2, Egreso);    
                this.TmAnuValDepABco = new TipoMovimiento(55, "Anulación Valores a Depositar a Banco", "Anulación Valores a Depositar a Banco", "ANREC", 1, Ingreso);
                this.TmCompensacion = new TipoMovimiento(56, "Compensación", "Compensación", "NFIN", 2, Egreso);
                this.TmAnuCompensacion = new TipoMovimiento(57, "Anulación Compensación", "Anulación Compensación", "ANFIN", 1, Ingreso);
                this.TmDepAComer = new TipoMovimiento(58, "Deposito a Comercio", "Deposito a Comercio", "NFIN", 1, Egreso);
                this.TmAnuDepAComer = new TipoMovimiento(59, "Anulacion Deposito a Comercio", "Anulacion Deposito a Comercio", "ANFIN", 1, Ingreso);
                this.TmDepCobComer = new TipoMovimiento(60, "Depósito Cobranza Comercio", "Depósito Cobranza Comercio", "NREC", 2, Egreso);
                this.TmAnuDepCobComer = new TipoMovimiento(61, "Anulación Depósito Cobranza Comercio", "Anulación Depósito Cobranza Comercio", "ANREC", 1, Ingreso);

                this.TmCobPorDebito = new TipoMovimiento(720, "Cobranza por Débito", "Cobranza por Débito", "NREC-FUT", 2, Egreso);
                this.TmAnuCobPorDebito = new TipoMovimiento(722, "Anulación Cobranza por Débito", "Anulación Cobranza por Débito", "ANREC-FUT", 1, Egreso);

                this.TmGastosFF = new TipoMovimiento(810, "Gastos Fondo Fijo", "Gastos Fondo Fijo", "", 2, Egreso );
                this.TmAnuGastosFF = new TipoMovimiento(811, "Anulación Gastos Fondo Fijo", "Anulación Gastos Fondo Fijo", "", 1, Ingreso);

                this.TmGastosCAP = new TipoMovimiento(820, "Gastos Cuentas a Pagar", "Gastos Cuentas a Pagar", "", 2, Egreso);
                this.TmAnuGastosCAP = new TipoMovimiento(821, "Anulación Gastos Cuentas a Pagar", "Anulación Gastos Cuentas a Pagar", "", 1, Ingreso);

                this.TmComisCredOtorEfec = new TipoMovimiento(822, "Comisión Créditos Otorgados en Efectivo", "Comisión Créditos Otorgados en Efectivo", "",2, Egreso);//eduardo cambio
                this.TmAnuComisCredOtorEfec = new TipoMovimiento(823, "Anulación Comisión Créditos Otorgados en Efectivo", "Anulación Comisión Créditos Otorgados en Efectivo", "", 1, Ingreso);//eduardo cambio

                this.TmCobPorDepBanc = new TipoMovimiento(723, "Cobranza por Depósito/Transferencia Bancaria", "Cobranza por Depósito/Transferencia Bancaria", "NREC", 2, Egreso);
                this.TmAnuCobPorDepBanc = new TipoMovimiento(724, "Anulación Cobranza por Depósito/Transferencia Bancaria", "Anulación Cobranza por Depósito/Transferencia Bancaria", "ANREC", 1, Ingreso);

                this.TmIngCobComAdh = new TipoMovimiento(725, "Ingreso Cobranza de comercio Adherido", "Ingreso Cobranza de comercio Adherido", "NREC", 1, Ingreso);
                this.TmAnuIngCobComAdh = new TipoMovimiento(726, "Anulación Ingreso Cobranza de comercio Adherido", "Anulación Ingreso Cobranza de comercio Adherido", "ANREC", 2, Egreso);

               this.TmNCProv = new TipoMovimiento(38, "Nota de Crédito Provisoria", "Nota de Crédito Provisoria", "", 2, Egreso);
               this.TmNDProv = new TipoMovimiento(39, "Nota de Débito Provisoria ", "Nota de Débito Provisoria", "", 1, Ingreso);

               this.TmGastosProv = new TipoMovimiento(40, "Gastos Provisorios", "Gastos Provisorios", "", 2, Egreso);
               this.TmAvisoPagoNegProv = new TipoMovimiento(41, "Aviso de pago negativo provisorio ", "Aviso de pago negativo provisorio", "", 2, Egreso);
               this.TmAvisoPagoProv = new TipoMovimiento(42, "Aviso provisorio", "Aviso provisorio", "", 2, Egreso);
               this.TmMinutaProv = new TipoMovimiento(43, "Minuta provisoria ", "Minuta provisoria", "", 1, Ingreso);
               this.TmReciboProv = new TipoMovimiento(44, "Recibo provisorio", "Recibo provisorio", "", 2, Egreso);
               this.TmAjuPosCaja = new TipoMovimiento(101, "Ajuste Positivo Caja", "Ajuste Positivo Caja", "", 1, Ingreso);

               this.TmDescPuniRefi = new TipoMovimiento(62, "Descuento Punitorios por pago Refinanciación", "Descuento Punitorios por pago Refinanciación", "", 2, Egreso,"S",0);
               this.TmAnuDescPuniRefi = new TipoMovimiento(63, "Anulación Descuento Punitorios por pago Refinanciación", "Anulación Descuento Punitorios por pago Refinanciación", "", 1, Ingreso,"M",62);

               this.TmPagoCom = new TipoMovimiento(727, "Pago A Comercio", "Pago A Comercio", "NREC", 2, Egreso);
               this.TmAnuPagoCom = new TipoMovimiento(728, "Anulación Pago A Comercio", "Anulación Pago A Comercio", "ANREC", 1, Ingreso);

               this.tsVenta = bl.GetTipoSolicitudByID(1);
               this.tsCap = bl.GetTipoSolicitudByID(2);
               this.tsFF = bl.GetTipoSolicitudByID(3);
               this.tsVentaAnticipada = bl.GetTipoSolicitudByID(4);
               this.tsDepositoAComercio = bl.GetTipoSolicitudByID(5);

                this.Peso = bl.GetMonedaByID(1);

                this.DatoCliente = bl.GetClaseDatoByID(1);
                this.DatoEmpresa = bl.GetClaseDatoByID(2);

                this.AvalSueldo = bl.GetByID<TipoAval>(1);
                this.AvalCamara = bl.GetByID<TipoAval>(2);
                this.AvalCredAnt = bl.GetByID<TipoAval>(3);
                this.AvalRenueva = bl.GetByID<TipoAval>(4);

                this.Efectivo = bl.GetByID<MedioDePago>(1);
                this.Cheque = bl.GetByID<MedioDePago>(2);
                this.TransferenciaBancaria = bl.GetByID<MedioDePago>(3);

                this.TpaACuenta = bl.GetByID<TipoPago>("A");
                this.TpaBonificada = bl.GetByID<TipoPago>("B");
                this.TpaCuota = bl.GetByID<TipoPago>("C");
                this.TpaAdelantoRefi = bl.GetByID<TipoPago>("D");
                this.TpaDebitoDirecto = bl.GetByID<TipoPago>("E");
                this.TpaTarjetaDebito = bl.GetByID<TipoPago>("F");
                this.TpaTarjetaCredito = bl.GetByID<TipoPago>("H");  
                this.TpaArreglo = bl.GetByID<TipoPago>("G");  
                this.TpaAnulada = bl.GetByID<TipoPago>("N");
                this.TpaPuniBaja = bl.GetByID<TipoPago>("P");
                this.TpaPuniQuit = bl.GetByID<TipoPago>("Q");
                this.TpaRefi = bl.GetByID<TipoPago>("R");
                this.TpaAbogado = bl.GetByID<TipoPago>("S");
                this.TpaAnticipado = bl.GetByID<TipoPago>("T");
                this.TpaAgrSis = bl.GetByID<TipoPago>("X");
                

                this.TpComercio = bl.GetByID<TipoComercio>(1);
                this.TpReceptoria = bl.GetByID<TipoComercio>(2);
                this.TpCobrador = bl.GetByID<TipoComercio>(3);
                this.TpAbogado = bl.GetByID<TipoComercio>(4);
                this.TpReceptoriasAntiguas = bl.GetByID<TipoComercio>(5);
                this.TpComerciosAntiguos = bl.GetByID<TipoComercio>(6);
                this.TpCasaCentral = bl.GetByID<TipoComercio>(7);

                this.ttdFinanciera = bl.GetByID<TipoTransferenciaDeposito>(1);
                this.ttdComercio = bl.GetByID<TipoTransferenciaDeposito>(2);
                
                
                this.uSistema = new Usuario(0, "Sistema", "Sistema", "Sistema", "********", DateTime.Now, true);

                this.UriCreditos = "api/creditos";
                this.UriAltaCobranza = "api/altaCobranza";
                this.UriAltaCobranzas = "api/altaCobranzas";
                this.UriArregloCancelacion = "api/ArregloCancelacion";
                this.UriClientes = "api/clientes";
                this.UriPagoAnticipado = "api/PagoAnticipado";
                this.UriRefinanciacionCobranza = "api/RefinanciacionCobranza";
                this.UriRefinanciacion = "api/Refinanciacion";
                this.UriArchivos = "api/fileupload2/files2";
                this.UriRecibos = "api/Recibos";
                this.UriTransDep = "api/TransDep";
                this.UriControlDiario = "api/ControlDiario";
                this.UriSolicitarFondos = "api/solicitarFondos";
                this.UriSolicitudFondosConceptoGastosProveedor = "api/SolicitudFondosConceptoGastosProveedor";

                this.UriGastos = "api/Gastos";
                this.UriCap = "api/Cap";
                this.UriFF = "api/FF";
                this.UriPago = "api/Pago";
                this.UriComprobantes = "api/Comprobantes";
                this.UriInfoAct = "api/InfoAct";

                this.ImpAlta = bl.GetByID<TipoImpresion>(1);
                this.ImpCobranzas = bl.GetByID<TipoImpresion>(5);
                this.ImpDebito = bl.GetByID<TipoImpresion>(15);

                this.Argentina = bl.GetByID<Pais>(5);

                /*cdcnvo_10022021*/
                this.TipoNotaCredito = "CREDITO";
                this.TipoNotaDebito  = "DEBITO";
            /**/
            //}
            //catch (Exception ex)
            //{
            //    log.Error(ex.Message, ex);
            //    MessageBox.Show(ex.Message);
            //}


        }
}
}
