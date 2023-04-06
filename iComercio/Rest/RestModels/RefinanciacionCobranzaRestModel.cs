using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iComercio.Rest.RestModels
{
    public class RefinanciacionCobranzaRestModel
    {
        public int RefinanciacionCobranzaID { get; set; }
        public int RefinanciacionCuotaID { get; set; }
        public int RefinanciacionID { get; set; }
        public int CreditoID { get; set; }
        public int ComercioID { get; set; } //AComercio
        public int EmpresaID { get; set; }
        public int Documento { get; set; }
        public string TipoDocumentoID { get; set; }
        public decimal ImportePago { get; set; } //Importe pagado total de la cobranza aimppago
        public decimal ImportePagoPunitorios { get; set; }  // aimppuni
        //public decimal Interes { get; set; } //es el interes de la cobranza aimppinte
        public decimal PunitoriosCalc { get; set; } //son los punitorios calculados  apunicalc
        public DateTime FechaPago { get; set; } //afechapago
        public DateTime FechaVencimiento { get; set; } //afechavenci
        public string TipoPagoID { get; set; } //apago
        public bool PagoRev { get; set; } //apagorev
        public DateTime FechaRev { get; set; } //porboni
        public int GestionID { get; set; } //Agestion quien lo cobro comercio,abogado,cobrador
        public int? RefinanciacionCobranzaIDRev { get; set; }

       


    }
}
