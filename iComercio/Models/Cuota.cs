using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iComercio.Auxiliar;
using iComercio.Rest.RestModels;


namespace iComercio.Models
{
    public class Cuota:ITransmitible
    {
        public int CuotaID { get; set; }
        public int CreditoID { get; set; }
        public virtual Credito Credito { get; set; }
        public int ComercioID { get; set; }
        public virtual Comercio Comercio { get; set; }
        public int EmpresaID { get; set; }
        public virtual Empresa Empresa { get; set; }
        public int Documento { get; set; }
        public virtual Cliente Cliente { get; set; }
        public string TipoDocumentoID { get; set; } 
        public decimal Importe { get; set; } //es el importe total de la cuota
        public decimal Interes { get; set; } //es el interes de la cuota
        public decimal ImportePago { get; set; }
        public decimal ImportePagoPunitorios { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public DateTime? FechaUltimoPago { get; set; }
        //public string TipoPagoID  { get; set; }
        //public virtual TipoPago TipoPago { get; set; }
        public string TipoCuotaID { get; set; }
        public virtual TipoCuota TipoCuota { get; set; }
        public int CantidadCuotas  { get; set; }
        //public string TipoBonificacionID { get; set; }
        //public virtual TipoBonificacion TipoBonificacion { get; set; }
        //public decimal? PorcentajeBonificacion { get; set; }
        public decimal ValorBonificacion { get; set; }
        public decimal Deuda 
            {
                get { return Importe - ImportePago; }
                private set { /* needed for EF */ }
            }
        public ObservableListSource<Nota> Notas { get; set; }
        public virtual ObservableListSource<Cobranza> Cobranzas { get; set; }


        /*Transmision*/
       

        public InfoTransmision InfoTransmision()
        {
            return new InfoTransmision(EmpresaID.ToString(), ComercioID.ToString(), CreditoID.ToString(), CuotaID.ToString());
        }

        public Dictionary<string, Object> ApiParam(Comercio com)
        {
            Dictionary<string, Object> ApiParam = new Dictionary<string, object>();
            ApiParam.Add("EmpresaID", this.EmpresaID);
            ApiParam.Add("ComercioID", this.ComercioID);
            ApiParam.Add("CreditoID", this.CreditoID);
            ApiParam.Add("CuotaID", this.CuotaID);
            return ApiParam;
        }

        public void ApiActualizarDesdeRemoto(BusinessLayer bl, object c)
        {

        }
        
    }
}
