using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iComercio.Rest.RestModels
{
    public class CreditoAnuladoRestModel
    {
        public int CreditoAnuladoID { get; set; }
        public int CreditoID { get; set; } //kcredito
        public int ComercioID { get; set; } //kcomercio
        public int EmpresaID { get; set; }
        public int Documento { get; set; } //kdocumento
        public string TipoDocumentoID { get; set; } //CodDocu
        
        public decimal ValorNominal { get; set; } //kvalornom
        public decimal ValorCuota { get; set; } //kvalorcuota
        public DateTime FechaSolicitud { get; set; } //kfechsoli

        public decimal Interes { get; set; } //KInteresImp
        public decimal Gasto { get; set; }  //KGastoImp
        public decimal Comision { get; set; } //KComisionImp

        public int? Garante1 { get; set; } //KGarante1
        public string TipoDocumentoIDG1 { get; set; } //KCodDocuG1
        public int? Garante2 { get; set; } //KGarante2
        public string TipoDocumentoIDG2 { get; set; } //KCodDocuG2
        public int? Garante3 { get; set; } //KGarante3
        public string TipoDocumentoIDG3 { get; set; } //KCodDocuG3
        public int? Adicional { get; set; } //DocuAdi
        public string TipoDocumentoIDAdi { get; set; } //CodAdi

        public bool Avalado { get; set; } //queAvalo hace la funcoin de avalado y es nnnn
        public int? usuarioAvalID { get; set; } //usuAval

        public string TipoCuotaID { get; set; } //ktipcuota
        public int CantidadCuotas { get; set; } //kcuotas
        public int? NroInformeContel { get; set; } //NroInforme

        public int? AbogadoID { get; set; } //kAbogado
        public virtual DateTime FechaAbogado { get; set; }  //kFechaAbo

        public int UsuarioID { get; set; } //usuAval
        public string PcComer { get; set; } //PC_comer
        public DateTime FechaComer { get; set; } //hora_comer

        public string TipoBonificacionID { get; set; } //TipoBoni
        public decimal? PorcentajeBonificacion { get; set; }
        public decimal ValorBonificacion { get; set; }

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
        public int? RefinanciacionID { get; set; } //NroRefinan

        // datos de la anulación
        public int UsuarioIDAnula { get; set; }
        
        public string PcComerAnula { get; set; } //PC_comer
        public DateTime FechaComercioAnula { get; set; } //hora_comer

        public string Motivo { get; set; }

        public string TipoAnulacionID { get; set; }
        public int? AvisoDePagoID { get; set; }
        public int Corte { get; set; }
        public DateTime FechaAviso { get; set; }
        public string NumCuentaBancaria { get; set; }
        public DateTime FechaDesdeDebito { get; set; }

        /* Para enviar el usuario por nombre de usuario, y no ID que son distintos en cliente y servidor*/
        public string NombreUsuario { get; set; }
    }
}
