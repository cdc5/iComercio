using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iComercio.ViewModels;
using iComercio.Auxiliar;
using Credin;


namespace iComercio.Models
{
    public class SolicitudFondo : ITransmitible
    {
        public long? SolicitudFondoID { get; set; }
        public long? SolicitudFondoIDRemoto { get; set; }
        public DateTime? FechaPago { get ; set ; }
        //public DateTime? FechaPago { get { return DateTime.SpecifyKind(fechaPago.Value, DateTimeKind.Utc); } set { fechaPago = value; ;} }
        public string FechaPagoSF { get { return Formato.Fecha(FechaPago.Value);} set{;} }
        public DateTime? FechaRealizacion { get; set; }
        public decimal? Importe { get; set; }
        public string Motivo { get; set; }
        public int? LiquidacionID { get; set; }
        public DateTime? FechaDispComienzo { get; set; }
        public DateTime? FechaDispFinal { get; set; }
        
        public int? GeneradoPorComercioID { get; set; }
        public virtual Comercio GeneradoPorComercio { get; set; }

        public int? GeneradoPorDepartamentoID { get; set; }
        public virtual Departamento GeneradoPorDepartamento { get; set; }

        public int? MedioDePagoID { get; set; }
        public virtual MedioDePago MedioDePago { get; set; }

        public int? ConceptoFondosID { get; set; }
        public virtual ConceptoFondos ConceptoFondos { get; set; }

        public int? ComercioID { get; set; }
        public virtual Comercio Comercio {get; set; }


        public int? EmpresaID { get; set; }
        public virtual Empresa Empresa {get;set;}

        public int? TransferenciasDepositosEmpId { get; set; }
        public long? TransferenciasDepositosID { get; set; }
        public virtual TransferenciasDepositos TransferenciasDepositos { get; set; } //empId e ID


        public int? ClaseCuentaBancariaID { get; set; }
        public int? CuentaBancariaID { get; set; }
        public string NumChequera { get; set; }
        public string NumCheque { get; set; }
        public virtual Cheque Cheque { get; set; } //chequera, cb,ccb, cheque

        public int? EstadoID { get; set; }
        public virtual Estado Estado { get; set; }
                
        public int? MonedaID { get; set; }
        public virtual Moneda Moneda { get; set; }
       
        
        public int? OrdenDePago { get; set; }
        //public virtual OrdenDePago OrdenDePago { get; set; }

               
        public int? TipoSolicitudID { get; set; }
        public virtual TipoSolicitud TipoSolicitud { get; set; }
        
        public DateTime? FechaConfComercio { get; set; }
        public int? EmpleadoConfComercio { get; set; }
        public string notas { get; set; }
        
        public int? EmpleadoSolicitanteID { get; set; }
        public virtual Empleado EmpleadoSolicitante { get; set; } // Busqueda por empId y empleado
        
        public int? EmpleadoRealizadorID { get; set; }
        public virtual Empleado EmpleadoRealizador { get; set; } // Busqueda por empId y empleado

        public string InfoParaRecibos { get { return InfoParaRecs(); } set { ;} }

        
        /*public int? ConceptoGastosProveedorID { get; set; }
        public int? ConceptoGastosID { get; set; }
        public int? ProveedorSucursalID { get; set; }
        public int? ProveedorID { get; set; }*/
        public virtual ObservableListSource<SolicitudFondoConceptoGastosProveedor> SolicitudFondoConceptoGastosProveedor { get; set; }
        


        public int? CajaID { get; set; } /*Recordar que despues caja se va a asignar automaticamente, ahora esta hecho como pasamanos para poder mostrar numero de caja*/

        public int? AvisoDePagoID { get; set; }
        public virtual AvisoDePago AvisoDePago { get; set; }

        private string InfoParaRecs()
        {
            return String.Format("Solicitud:{0} - {1} - {2:0.00} - {3}", SolicitudFondoIDRemoto, FechaPagoSF, Importe, ConceptoFondos.Nombre);
        }
        
        
      
        public SolicitudFondo()
        {
            SolicitudFondoConceptoGastosProveedor = new ObservableListSource<SolicitudFondoConceptoGastosProveedor>();
        }

        public SolicitudFondo(int EmpresaID,int ComercioID, DateTime? FechaPago, decimal? Importe,int? EstadoID,
                             int? TipoSolicitudID, int? MedioDePagoID, int? ConceptoFondosID, int? MonedaID ,
                             int? GeneradoPorComercioID = null, int? GeneradoPorDepartamentoID = null, 
                             int? EmpleadoSolicitanteID = null, int? EmpleadoRealizadorID = null,string Motivo = null,
                             DateTime? FechaDispComienzo = null, DateTime? FechaDispFinal = null, 
                             int? TransferenciasDepositosEmpId = null, long? TransferenciasDepositosID = null,
                             int? ClaseCuentaBancariaID = null, int? CuentaBancariaID = null, string NumChequera = null, string NumCheque = null,
                              int? OrdenDePago = null, DateTime? FechaConfComercio = null, int? EmpleadoConfComercio = null,
                             string notas = null)
        {
            this.EmpresaID = EmpresaID;
            this.ComercioID = ComercioID;
            this.FechaPago = FechaPago;
            this.FechaRealizacion = DateTime.Now;
            this.Importe = Importe;
            this.EstadoID = EstadoID;
            this.MedioDePagoID = MedioDePagoID;
            this.ConceptoFondosID = ConceptoFondosID;
            this.TipoSolicitudID = TipoSolicitudID;
            this.FechaDispComienzo = FechaDispComienzo;
            this.FechaDispFinal = FechaDispFinal;
            this.Motivo = Motivo;
            this.LiquidacionID = LiquidacionID;            
            this.GeneradoPorComercioID = GeneradoPorComercioID;
            this.GeneradoPorDepartamentoID = GeneradoPorDepartamentoID;            
            this.TransferenciasDepositosEmpId = TransferenciasDepositosEmpId;
            this.TransferenciasDepositosID= TransferenciasDepositosID;
            this.ClaseCuentaBancariaID = ClaseCuentaBancariaID;
            this.CuentaBancariaID = CuentaBancariaID;
            this.NumChequera= NumChequera;
            this.NumCheque = NumCheque;
            this.MonedaID = MonedaID;
            this.OrdenDePago = OrdenDePago;            
            this.FechaConfComercio =FechaConfComercio;
            this.EmpleadoConfComercio = EmpleadoConfComercio;
            this.notas = notas;
            this.EmpleadoSolicitanteID = EmpleadoSolicitanteID;
            this.EmpleadoRealizadorID = EmpleadoRealizadorID;          
        }

        public SolicitudFondo ActualizarConDatosDeServidor(SolicitudFondo sf)
        {
            if (this.SolicitudFondoID.Equals(sf.SolicitudFondoID))
            {
                this.Motivo = sf.Motivo;
                this.FechaDispComienzo = sf.FechaDispComienzo;
                this.Importe = sf.Importe;
                this.FechaPago = sf.FechaPago;
                this.FechaDispFinal = sf.FechaDispFinal;
                this.GeneradoPorComercioID = sf.GeneradoPorComercioID;
                this.GeneradoPorDepartamentoID =sf.GeneradoPorDepartamentoID;
                this.MedioDePagoID = sf.MedioDePagoID;
                this.ConceptoFondosID = sf.ConceptoFondosID;
                this.ClaseCuentaBancariaID = sf.ClaseCuentaBancariaID;
                this.CuentaBancariaID =sf.CuentaBancariaID;
                this.NumChequera = sf.NumChequera;
                this.NumCheque = sf.NumCheque;
                this.EstadoID = sf.EstadoID;
                this.OrdenDePago = sf.OrdenDePago;
                this.notas = sf.notas;
                return this;
            }
            return null;
        }
        
        public override string ToString()
        {
            return DetalleSolFon();
        }

        public string DetalleSolFon()
        {
           return string.Format("{0} - {1} - $ {2} - {3}", FechaPago, ConceptoFondos.Nombre, Importe,TipoSolicitud.Nombre);
        }

        public string sDetalleSolFon
        {
            get {return DetalleSolFon();} 
            set {;}
            
        }

        /*Transmision*/
        public string EntidadID()
        {
            return EmpresaID.ToString();
        }

        public string EntidadID2()
        {
            return ComercioID.ToString();
        }

        public string EntidadID3()
        {
            return SolicitudFondoID.ToString();
        }

        public InfoTransmision InfoTransmision()
        {
            return new InfoTransmision(EntidadID3());
        }

        public Dictionary<string, Object> ApiParam(Comercio com)
        {
            Dictionary<string, Object> ApiParam = new Dictionary<string, object>();
            ApiParam.Add("EmpresaID", this.EmpresaID);
            ApiParam.Add("ComercioID", this.ComercioID);
            ApiParam.Add("SolicitudFondoID", this.SolicitudFondoID);
            return ApiParam;
        }

        public void ApiActualizarDesdeRemoto(BusinessLayer bl, object c)
        {
            //Cliente cli = (Cliente)c;
            //this.Documento = cli.Documento;
            //this.TipoDocumentoID = cli.TipoDocumentoID;
            //bl.Actualizar<Credito>((Credito)c);
        }

    }
}
