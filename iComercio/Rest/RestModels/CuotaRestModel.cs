using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iComercio.Rest.RestModels
{
    public class CuotaRestModel
    {
        public int CuotaID { get; set; }
        public int CreditoID { get; set; }
        public int ComercioID { get; set; }
        public int EmpresaID { get; set; }
        public int Documento { get; set; }
        public string TipoDocumentoID { get; set; }
        public decimal Importe { get; set; }
        public decimal Interes { get; set; }
        public decimal ImportePago { get; set; }
        public decimal ImportePagoPunitorios { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public DateTime? FechaUltimoPago { get; set; }
        //public string TipoPagoID { get; set; }
        public string TipoCuotaID { get; set; }
        public int? CantidadCuotas { get; set; }
        //public int? TipoBonificacionID { get; set; }
        //public DateTime? PorcentajeBonificacion { get; set; }
        public decimal ValorBonificacion { get; set; }
        public decimal? Deuda { get; set; }

        public virtual List<CobranzaRestModel> Cobranzas { get; set; }
        public virtual List<NotaRestModel> Notas { get; set; }
    }
}
