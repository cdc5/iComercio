using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iComercio.Rest.RestModels
{
    public class CreditoRestModel
    {
        public int CreditoID { get; set; }
        public int ComercioID { get; set; }
        public int EmpresaID { get; set; }
        public int Documento { get; set; }
        public string TipoDocumentoID { get; set; }
        public decimal ValorNominal { get; set; }
        public decimal ValorCuota { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public decimal Interes { get; set; }
        public decimal Gasto { get; set; }
        public decimal Comision { get; set; }
        public bool? Cancelado { get; set; }
        public int? Garante1 { get; set; }
        public string TipoDocumentoIDG1 { get; set; }
        public int? Garante2 { get; set; }
        public string TipoDocumentoIDG2 { get; set; }
        public int? Garante3 { get; set; }
        public string TipoDocumentoIDG3 { get; set; }
        public int? Adicional { get; set; }
        public string TipoDocumentoIDAdi { get; set; }
        public string Avalado { get; set; }
        public int? usuarioAvalID { get; set; }
        public string UsuarioAvalAnt { get; set; } //Usuario anterior para preservar usuario, a futuro crear usuarios correspondientes  y quitar este campo
        public string TipoCuotaID { get; set; }
        public int CantidadCuotas { get; set; }
        public int? NroInformeContel { get; set; }
        public int? AbogadoID { get; set; }
        public DateTime FechaAbogado { get; set; }
        public int? RefinanciacionID { get; set; }
        public int UsuarioID { get; set; }
        public string UsuarioAnt { get; set; } //Usuario anterior para preservar usuario, a futuro crear usuarios correspondientes  y quitar este campo
        public string PcComer { get; set; }
        public DateTime? FechaComer { get; set; }
        public string TipoBonificacionID { get; set; }
        public decimal? PorcentajeBonificacion { get; set; }
        public decimal? ValorBonificacion { get; set; }
        public decimal TasaPlan { get; set; }
        public decimal IncrementoPlan { get; set; }
        public decimal GastoPlan { get; set; }
        public decimal GastoIncrementoPlan { get; set; }
        public bool GastoFijo { get; set; }
        public decimal ComisionPlan { get; set; }
        public decimal ComisionIncrementoPlan { get; set; }
        public string TipoRetencionPlanID { get; set; }
        public string NombrePlan { get; set; }
        public decimal? Puntaje { get; set; }
        public int DiasVenciPrimerCuota { get; set; } //kVenci
        public int? AvisoDePagoID { get; set; }
        public int Corte { get; set; }
        public DateTime FechaAviso { get; set; }
        public string NumCuentaBancaria { get; set; }
        public DateTime FechaDesdeDebito { get; set; }

        public virtual List<CuotaRestModel> Cuotas { get; set; }
        public virtual List<NotaRestModel> Notas { get; set; }
        public virtual List<RefinanciacionRestModel> Refinanciaciones { get; set; }
        public virtual List<CreditoAvalRestModel> CreditoAvales { get; set; }
        public virtual List<CobranzaRestModel> Cobranzas { get; set; }

        /* Para Mostrar en Info de Mororos*/
        public string EmpresaNombre { get; set; }
        public string ComercioNombre { get; set; }
        public string Garante1Nombre { get; set; }
        public string AdicionalNombre { get; set; }

        /* Para enviar el usuario por nombre de usuario, y no ID que son distintos en cliente y servidor*/
        public string NombreUsuario { get; set; }
    }
}
