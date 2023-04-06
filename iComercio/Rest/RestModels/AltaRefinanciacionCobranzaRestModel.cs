using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iComercio.Models;
using iComercio.Rest.RestModels;

namespace iComercio.Rest.RestModels
{
    public class AltaRefinanciacionCobranzaRestModel:ITransmitibleCC
    {
        public RefinanciacionCuotaRestModel RefinanciacionCuotaActRM { get; set; }
        public RefinanciacionCobranzaRestModel RefinanciacionCobranzaNuevaRM { get; set; }
        public List<AltaCobranzaRestModel> CobranzasRM { get; set; }
        public ImputacionCuentaCorrienteRestModel ImputacionCC { get; set; }
        
        public AltaRefinanciacionCobranzaRestModel()
        {
            CobranzasRM = new List<AltaCobranzaRestModel>();
        }

        /*Transmision*/
        public Dictionary<string, Object> ApiParam(Comercio com)
        {
            Dictionary<string, Object> ApiParam = new Dictionary<string, object>();
            ApiParam.Add("EmpresaID", this.RefinanciacionCobranzaNuevaRM.EmpresaID);
            ApiParam.Add("ComercioID", this.RefinanciacionCobranzaNuevaRM.ComercioID);
            ApiParam.Add("CreditoID", this.RefinanciacionCobranzaNuevaRM.CreditoID);
            ApiParam.Add("RefinanciacionID", this.RefinanciacionCobranzaNuevaRM.RefinanciacionID);
            return ApiParam;
        }

        public void ApiActualizarCCDesdeRemoto(BusinessLayer bl, ImputacionCuentaCorrienteRestModel iccRM)
        {
            bl.ActualizarCCDesdeRemoto(iccRM);
        }

        public void ApiActualizarDesdeRemoto(BusinessLayer bl, object c)
        {
            AltaRefinanciacionCobranzaRestModel acrm = (AltaRefinanciacionCobranzaRestModel)c;
            ApiActualizarCCDesdeRemoto(bl, acrm.ImputacionCC);
        }

        public InfoTransmision InfoTransmision()
        {
            return new InfoTransmision(this.RefinanciacionCobranzaNuevaRM.EmpresaID.ToString(),
                                       this.RefinanciacionCobranzaNuevaRM.ComercioID.ToString(),
                                       this.RefinanciacionCobranzaNuevaRM.CreditoID.ToString(),
                                       this.RefinanciacionCobranzaNuevaRM.RefinanciacionID.ToString());
        }
    }
}
