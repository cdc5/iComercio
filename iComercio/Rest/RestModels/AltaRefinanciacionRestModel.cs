using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iComercio.Models;
using iComercio.Rest.RestModels;

namespace iComercio.Rest.RestModels
{
    public class AltaRefinanciacionRestModel :ITransmitibleCC
    {
        public CreditoRestModel CreditoActRM { get; set; }
        public RefinanciacionRestModel RefinanciacionNuevaRM { get; set; }
        public List<RefinanciacionCuotaRestModel> RefinanciacionCuotasNuevasRM { get; set; }
        public CuotaRestModel CuotaActRM { get; set; }
        public CobranzaRestModel CobranzaNuevaRM { get; set; }
        public ImputacionCuentaCorrienteRestModel ImputacionCC { get; set; }

        public AltaRefinanciacionRestModel()
        {
            RefinanciacionCuotasNuevasRM = new List<RefinanciacionCuotaRestModel>();
        }

        public Dictionary<string, Object> ApiParam(Comercio com)
        {
            Dictionary<string, Object> ApiParam = new Dictionary<string, object>();
            ApiParam.Add("EmpresaID", this.RefinanciacionNuevaRM.EmpresaID);
            ApiParam.Add("ComercioID", this.RefinanciacionNuevaRM.ComercioID);
            ApiParam.Add("CreditoID", this.RefinanciacionNuevaRM.CreditoID);
            ApiParam.Add("RefinanciacionID", this.RefinanciacionNuevaRM.RefinanciacionID);
            return ApiParam;
        }

        public void ApiActualizarCCDesdeRemoto(BusinessLayer bl, ImputacionCuentaCorrienteRestModel iccRM)
        {
            bl.ActualizarCCDesdeRemoto(iccRM);
        }

        public void ApiActualizarDesdeRemoto(BusinessLayer bl, object c)
        {
            AltaRefinanciacionRestModel acrm = (AltaRefinanciacionRestModel)c;
            ApiActualizarCCDesdeRemoto(bl, acrm.ImputacionCC);
        }

        /*Transmision*/
        


        public InfoTransmision InfoTransmision()
        {
            return new InfoTransmision(this.RefinanciacionNuevaRM.EmpresaID.ToString(),
                                       this.RefinanciacionNuevaRM.ComercioID.ToString(),
                                       this.RefinanciacionNuevaRM.CreditoID.ToString(),
                                       this.RefinanciacionNuevaRM.RefinanciacionID.ToString());
        }

    }
}
