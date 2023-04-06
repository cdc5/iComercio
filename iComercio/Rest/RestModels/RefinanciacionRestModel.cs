using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iComercio.Rest.RestModels
{
    public class RefinanciacionRestModel
    {
        public int RefinanciacionID { get; set; }
        public int CreditoID { get; set; }
        public int ComercioID { get; set; }
        public int EmpresaID { get; set; }
        public int Documento { get; set; } //kdocumento
        public string TipoDocumentoID { get; set; } //CodDocu
        public decimal ValorNominal { get; set; } //kvalornom
        public decimal ValorCuota { get; set; } //kvalorcuota
        public decimal ValorAdelanto { get; set; }
        public DateTime FechaSolicitud { get; set; } //kfechsoli
        public decimal Interes { get; set; } //KInteresImp
        public int CantidadCuotas { get; set; } //kcuotas
        public int UsuarioID { get; set; } //usuAval
        public string PcComer { get; set; } //PC_comer
        public int EstadoID { get; set; }                               //***edu
        public DateTime? FechaCreacion { get; set; }  //fecha de creacion en central
        public List<RefinanciacionCuotaRestModel> RefinanciacionesCuotas { get; set; }
        public DateTime FechaComerAnula { get; set; }

        /* Para enviar el usuario por nombre de usuario, y no ID que son distintos en cliente y servidor*/
        public string NombreUsuario { get; set; }
    }
}
