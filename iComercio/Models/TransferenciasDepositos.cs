using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iComercio.Models
{
    public class TransferenciasDepositos : ITransmitible
    {
        public int EmpresaID { get; set; }
        public virtual Empresa Empresa { get; set; }
        public long TransferenciasDepositosID { get; set; }
        public long? TransferenciasDepositosIDRemoto { get; set; }
        public string NumTransferencia { get; set; }
        public decimal? Importe { get; set; }
        public DateTime? Fecha { get; set; }
        public decimal? Costo { get; set; }
        public string Notas { get; set; }
        
        public int? CuentaOrigenEmpresaID { get; set; }
        public int? CuentaOrigenCbID { get; set; }
        public virtual CuentaBancaria CuentaOrigen {get;set;}

        public int? CuentaDestinoEmpresaID { get; set; }
        public int? CuentaDestinoCbID { get; set; }
        public virtual CuentaBancaria CuentaDestino {get;set;}

        public int? ChequeEmpID { get; set; }
        public int? ChequeCbID { get; set; }
        public string ChequeNumChequera { get; set; }
        public string ChequeNumCheque { get; set; }
        public virtual Cheque cheque {get;set;}

        
        public int? MedioDePagoID { get; set; }
        public virtual MedioDePago MedioDePago { get; set; }
        
        public int? MonedaID { get; set; }
        public virtual Moneda Moneda { get; set; }

        public int? EmpleadoRegistradorEmpresaID { get; set; }
        public int? EmpleadoRegistradorPersonaID { get; set; }
        public virtual Empleado EmpleadoRegistrador { get; set; }
        
        public int? ComercioEmpresaID { get; set; }
        public virtual Empresa ComercioEmpresa { get; set; }
        
        public int? ComercioID { get; set; }
        public virtual Comercio Comercio { get; set; }
        
        public int? PersonaId { get; set; }
        public virtual Persona Persona { get; set; }

        public int? ProveedorSucursalID { get; set; }
        public int? ProveedorID { get; set; }    
        public virtual ProveedorSucursal  ProveedorSucursal{ get; set; }

        public string Host { get; set; }
        public int UsuarioID { get; set; }
        public virtual Usuario Usuario { get; set; }

        public int? TipoTransferenciaDepositoID { get; set; }
        public virtual TipoTransferenciaDeposito TipoTransferenciaDeposito { get; set; }

        public int EstadoID { get; set; }
        public virtual Estado Estado { get; set; }

        public InfoTransmision InfoTransmision()
        {
            return new InfoTransmision(EmpresaID.ToString(), TransferenciasDepositosID.ToString());
        }

        public Dictionary<string, Object> ApiParam(Comercio com)
        {
            Dictionary<string, Object> ApiParam = new Dictionary<string, object>();
            ApiParam.Add("EmpresaID", this.EmpresaID);
            ApiParam.Add("TransferenciasDepositosID", this.TransferenciasDepositosID);
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
