using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iComercio.Models;

namespace iComercio.Rest.RestModels
{
    public class TransferenciasDepositosRestModel 
    {
        public int EmpresaID { get; set; }
        public long TransferenciasDepositosID { get; set; }
        public long? TransferenciasDepositosIDRemoto { get; set; }
        public string NumTransferencia { get; set; }
        public decimal? Importe { get; set; }
        public DateTime? Fecha { get; set; }
        public decimal? Costo { get; set; }
        public string Notas { get; set; }
        public int? CuentaOrigenEmpresaID { get; set; }
        public int? CuentaOrigenCbID { get; set; }
        public int? CuentaDestinoEmpresaID { get; set; }
        public int? CuentaDestinoCbID { get; set; }
        public int? ChequeEmpID { get; set; }
        public int? ChequeCbID { get; set; }
        public string ChequeNumChequera { get; set; }
        public string ChequeNumCheque { get; set; }
        public int? MedioDePagoID { get; set; }
        public int? MonedaID { get; set; }
        public int? EmpleadoRegistradorEmpresaID { get; set; }
        public int? EmpleadoRegistradorPersonaID { get; set; }
        public int? ComercioEmpresaID { get; set; }
        public int? ComercioID { get; set; }
        public int? PersonaID { get; set; }
        public int? ProveedorSucursalID { get; set; }
        public int? ProveedorID { get; set; }
        public string Host { get; set; }
        public int UsuarioID { get; set; }
        public int? TipoTransferenciaDepositoID { get; set; }
        public int EstadoID { get; set; }
        /* Para enviar el usuario por nombre de usuario, y no ID que son distintos en cliente y servidor*/
        public string NombreUsuario { get; set; }

        public Dictionary<string, Object> ApiParam(Comercio com)
        {
            Dictionary<string, Object> ApiParam = new Dictionary<string, object>();
            ApiParam.Add("EmpresaID", this.EmpresaID);
            ApiParam.Add("TransferenciaDepositoID", this.TransferenciasDepositosID);
            return ApiParam;
        }

        public void ApiActualizarDesdeRemoto(BusinessLayer bl,object c)
        {
         
        }

        public InfoTransmision InfoTransmision()
        {
            return new InfoTransmision(this.EmpresaID.ToString(),
                                       this.TransferenciasDepositosID.ToString());
        }
    }
}
