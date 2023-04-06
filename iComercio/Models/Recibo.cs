using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iComercio.Models
{
    public class Recibo:ITransmitible
    {
        public int ReciboID { get; set; }
        public int? ReciboIDRemoto { get; set; }
        public DateTime? Fecha { get ; set ; }
        public DateTime? FechaIngreso { get; set; }
        public int ComercioID { get; set; }
        public virtual Comercio Comercio { get; set; }
        public int EmpresaID { get; set; }
        public virtual Empresa Empresa { get; set; }
        public decimal Importe { get; set; }
        public int Comprobante { get; set; }
        public string Notas { get; set; }
        public int TipoMovimientoID { get; set; }
        public virtual TipoMovimiento TipoMovimiento { get; set; }
        public int? TransferenciasDepositosEmpId { get; set; }
        public long? TransferenciasDepositosID { get; set; }
        public virtual TransferenciasDepositos TransferenciasDepositos { get; set; } //empId e ID
        public long? SolicitudFondoID { get; set; }
        public virtual SolicitudFondo SolucitudFondo { get; set; }
        public decimal? Imputado { get; set; }
        public bool? Migrado { get; set; }
        public bool? Conformado { get; set; }
        public string Host { get; set; }
        public int  UsuarioID { get; set; }
        public virtual Usuario Usuario { get; set; }
        public int EstadoID { get; set; }
        public virtual Estado Estado { get; set; }

        public int? ComercioAdheridoComercioID { get; set; }
        public int? ComercioAdheridoEmpresaID { get; set; }
        public virtual Comercio ComercioAdherido { get; set; }

        public int? ReciboIDAnula { get; set; }  //eduardo camb
        public int? CobranzaID { get; set; }     //eduardo camb
        public int? CreditoID { get; set; }     
        public int? CuotaID { get; set; }     


        
        public InfoTransmision InfoTransmision()
        {
            return new InfoTransmision(EmpresaID.ToString(), ComercioID.ToString(), ReciboID.ToString());
        }

        public Dictionary<string, Object> ApiParam(Comercio com)
        {
            Dictionary<string, Object> ApiParam = new Dictionary<string, object>();
            ApiParam.Add("EmpresaID", this.EmpresaID);
            ApiParam.Add("ComercioID", this.ComercioID);
            ApiParam.Add("ReciboID", this.ReciboID);
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
