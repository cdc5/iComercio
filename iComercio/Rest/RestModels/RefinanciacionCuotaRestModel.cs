using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;


namespace iComercio.Rest.RestModels
{
    public class RefinanciacionCuotaRestModel
    {
        public int RefinanciacionCuotaID { get; set; }
        public int RefinanciacionID { get; set; }
        public int CreditoID { get; set; }
        public int ComercioID { get; set; }
        public int EmpresaID { get; set; }
        public int Documento { get; set; } //kdocumento
        public string TipoDocumentoID { get; set; } //CodDocu
        public int CantidadCuotas { get; set; }
        public decimal Importe { get; set; } //es el importe total de la cuota
        public decimal ImportePago { get; set; }
        public decimal ImportePagoPunitorios { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public DateTime? FechaUltimoPago { get; set; }
        public List<RefinanciacionCobranzaRestModel> RefinanciacionesCobranzas { get; set; }

    }
}
