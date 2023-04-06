using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iComercio.Models;

namespace iComercio.Rest.RestModels
{
    public class BajaRefinanciacionRestModel:ITransmitible
    {
        public RefinanciacionRestModel Refinanciacion { get; set; }
        
        public Dictionary<string, Object> ApiParam(Comercio com)
        {
            Dictionary<string, Object> ApiParam = new Dictionary<string, object>();
            ApiParam.Add("EmpresaID", this.Refinanciacion.EmpresaID);
            ApiParam.Add("ComercioID", this.Refinanciacion.ComercioID);
            ApiParam.Add("CreditoID", this.Refinanciacion.CreditoID);
            ApiParam.Add("RefinanciacionID", this.Refinanciacion.RefinanciacionID);
            return ApiParam;
        }

                
        public void ApiActualizarDesdeRemoto(BusinessLayer bl, object c)
        {

        }

        public InfoTransmision InfoTransmision()
        {
            return new InfoTransmision(this.Refinanciacion.EmpresaID.ToString(),
                                       this.Refinanciacion.ComercioID.ToString(),
                                       this.Refinanciacion.CreditoID.ToString());
        }
    }
}
