using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iComercio.Rest.RestModels
{
    public class CobranzaRestModel
    {
        public int CobranzaID { get; set; }
        public int CuotaID { get; set; }
        public int CreditoID { get; set; }
        public int ComercioID { get; set; }
        public int EmpresaID { get; set; }
        public int? Documento { get; set; }
        public string TipoDocumentoID { get; set; }
        public decimal? ImportePago { get; set; }
        public decimal ImportePagoPunitorios { get; set; }
        public decimal Interes { get; set; }
        public decimal PunitoriosCalc { get; set; }
        public DateTime FechaPago { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string TipoPagoID { get; set; }
        public string TipoBonificacionID { get; set; }
        public decimal? PorcentajeBonificacion { get; set; }
        public bool? PagoRev { get; set; }
        public DateTime? FechaRev { get; set; }
        public int GestionEmpresaID { get; set; }
        public int? GestionID { get; set; }
        public int? RefinanciacionCobranzaID { get; set; }
        public int UsuarioID { get; set; }
        public string PcComer { get; set; }
        public string Motivo { get; set; }   
        public int? CobranzaIDRev { get; set; }

        public virtual List<NotaRestModel> Notas { get; set; }
        public List<NotasCDRestModel> NotasCD { get; set; }
        public string NotasBoni { get; set; }

        /* Para enviar el usuario por nombre de usuario, y no ID que son distintos en cliente y servidor*/
        public string NombreUsuario { get; set; }
    }
}
