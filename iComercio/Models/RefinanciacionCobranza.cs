using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iComercio.Rest.RestModels;

namespace iComercio.Models
{
    public class RefinanciacionCobranza:ITransmitible
    {
        public int RefinanciacionCobranzaID { get; set; }
        public int RefinanciacionCuotaID { get; set; }
        public virtual RefinanciacionCuota RefinanciacionCuota { get; set; }
        public int RefinanciacionID { get; set; }
        public virtual Refinanciacion Refinanciacion { get; set; }
        public int CreditoID { get; set; }
        public int ComercioID { get; set; } //AComercio
        public virtual Comercio Comercio { get; set; }
        public int EmpresaID { get; set; }
        public virtual Empresa Empresa { get; set; }
        public int Documento { get; set; }
        public string TipoDocumentoID { get; set; }
        public virtual Cliente Cliente { get; set; }


        public decimal ImportePago { get; set; } //Importe pagado total de la cobranza aimppago
        public decimal ImportePagoPunitorios { get; set; }  // aimppuni
        public decimal PunitoriosCalc { get; set; } //son los punitorios calculados  apunicalc
        public DateTime FechaPago { get; set; } //afechapago
        public DateTime FechaVencimiento { get; set; } //afechavenci
        public string TipoPagoID { get; set; } //apago
        public virtual TipoPago TipoPago { get; set; }

        public bool PagoRev { get; set; } //apagorev
        public DateTime? FechaRev { get; set; }                     //***edu
        public int? RefinanciacionCobranzaIDRev { get; set; }        

        public int GestionID { get; set; } //Agestion quien lo cobro comercio,abogado,cobrador
        public virtual Comercio Gestion { get; set; }

        /*Transmision*/
      
        public InfoTransmision InfoTransmision()
        {
            return new InfoTransmision(EmpresaID.ToString(), ComercioID.ToString(), CreditoID.ToString(), RefinanciacionID.ToString(), RefinanciacionCuotaID.ToString(), RefinanciacionCobranzaID.ToString());
        }

        public Dictionary<string, Object> ApiParam(Comercio com)
        {
            Dictionary<string, Object> ApiParam = new Dictionary<string, object>();
            ApiParam.Add("EmpresaID", this.EmpresaID);
            ApiParam.Add("ComercioID", this.ComercioID);
            ApiParam.Add("CreditoID", this.CreditoID);
            ApiParam.Add("RefinanciacionID", this.RefinanciacionID);
            ApiParam.Add("RefinanciacionCuotaID", this.RefinanciacionCuotaID);
            ApiParam.Add("RefinanciacionCobranzaID", this.RefinanciacionCobranzaID);
            return ApiParam;
        }

        public void ApiActualizarDesdeRemoto(BusinessLayer bl, object c)
        {

        }

    }
}
