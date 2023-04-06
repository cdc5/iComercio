using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using iComercio.DAL;
using iComercio.Auxiliar;
using iComercio.Rest.RestModels;

namespace iComercio.Models
{
    public class RefinanciacionCuota:ITransmitible
    {
        public int RefinanciacionCuotaID { get; set; }
        public int RefinanciacionID { get; set; }
        public virtual Refinanciacion Refinanciacion { get; set; }
        public int CreditoID { get; set; }
        public int ComercioID { get; set; }
        public virtual Comercio Comercio { get; set; }
        public int EmpresaID { get; set; }
        public virtual Empresa Empresa { get; set; }
        public int Documento { get; set; } //kdocumento
        public string TipoDocumentoID { get; set; } //CodDocu
        public virtual Cliente Cliente { get; set; }        
        //public string TipoCuotaID { get; set; }
        //public virtual TipoCuota TipoCuota { get; set; }      
        public int CantidadCuotas  { get; set; }
        public decimal Importe { get; set; } //es el importe total de la cuota
        //public decimal Interes { get; set; } //es el interes de la cuota
        public decimal ImportePago { get; set; }
        public decimal ImportePagoPunitorios { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public DateTime? FechaUltimoPago { get; set; }
        public ObservableListSource<RefinanciacionCobranza> RefinanciacionesCobranzas { get; set; }

        public decimal Deuda
        {
            get { return Importe - ImportePago; }
            set { }
        }

        /*Transmision*/
       
        public InfoTransmision InfoTransmision()
        {
            return new InfoTransmision(EmpresaID.ToString(), ComercioID.ToString(), CreditoID.ToString(), RefinanciacionID.ToString(), RefinanciacionCuotaID.ToString());
        }

        public Dictionary<string, Object> ApiParam(Comercio com)
        {
            Dictionary<string, Object> ApiParam = new Dictionary<string, object>();
            ApiParam.Add("EmpresaID", this.EmpresaID);
            ApiParam.Add("ComercioID", this.ComercioID);
            ApiParam.Add("CreditoID", this.CreditoID);
            ApiParam.Add("RefinanciacionID", this.RefinanciacionID);
            ApiParam.Add("RefinanciacionCuotaID", this.RefinanciacionCuotaID);
            return ApiParam;
        }

        public void ApiActualizarDesdeRemoto(BusinessLayer bl, object c)
        {
        
        }


    }
}
