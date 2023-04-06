using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iComercio.Models;
using iComercio.Rest.RestModels;

namespace iComercio.Rest.RestModels
{
    public class BajaRefinanciacionCobranzaRestModel:ITransmitibleCC
    {
        public RefinanciacionCuotaRestModel RefiCuotaAct { get; set; }
        public RefinanciacionCobranzaRestModel RefiCobranzaNueva { get; set; }
        public RefinanciacionCobranzaRestModel RefiCobranzaAct { get; set; }
        public List<BajaCobranzaRestModel> BajasCobranzas { get; set; }
        public ImputacionCuentaCorrienteRestModel ImputacionCC { get; set; }
        //CuotaRestModel CuotaAct { get; set; }
        //CobranzaRestModel CobranzaNueva { get; set; }
        //CobranzaRestModel CobranzaMod { get; set; }

        

        public BajaRefinanciacionCobranzaRestModel()
        {
           
        }

        public BajaRefinanciacionCobranzaRestModel(RefinanciacionCuotaRestModel RefiCuotaAct, RefinanciacionCobranzaRestModel RefiCobranzaNueva,
                                                   RefinanciacionCobranzaRestModel RefiCobranzaAct, List<BajaCobranzaRestModel> BajasCobranzas)
        {
            this.RefiCuotaAct = RefiCuotaAct;
            this.RefiCobranzaNueva = RefiCobranzaNueva;
            this.RefiCobranzaAct =  RefiCobranzaAct;
            this.BajasCobranzas = BajasCobranzas;
          
        }

        /*Transmision*/
        


        public Dictionary<string, Object> ApiParam(Comercio com)
        {
            Dictionary<string, Object> ApiParam = new Dictionary<string, object>();
            ApiParam.Add("EmpresaID", this.RefiCobranzaNueva.EmpresaID);
            ApiParam.Add("ComercioID", this.RefiCobranzaNueva.ComercioID);
            ApiParam.Add("CreditoID", this.RefiCobranzaNueva.CreditoID);
            ApiParam.Add("RefinanciacionID", this.RefiCobranzaNueva.RefinanciacionID);
            ApiParam.Add("RefinanciacionCuotaID", this.RefiCobranzaNueva.RefinanciacionCuotaID);
            ApiParam.Add("RefinanciacionCobranzaID", this.RefiCobranzaNueva.RefinanciacionCobranzaID);
            return ApiParam;
        }


        public void ApiActualizarCCDesdeRemoto(BusinessLayer bl, ImputacionCuentaCorrienteRestModel iccRM)
        {
            bl.ActualizarCCDesdeRemoto(iccRM);
        }

        public void ApiActualizarDesdeRemoto(BusinessLayer bl, object c)
        {
            BajaRefinanciacionCobranzaRestModel acrm = (BajaRefinanciacionCobranzaRestModel)c;
            ApiActualizarCCDesdeRemoto(bl, acrm.ImputacionCC);
        }

        public InfoTransmision InfoTransmision()
        {
            return new InfoTransmision(this.RefiCobranzaNueva.EmpresaID.ToString(),
                                       this.RefiCobranzaNueva.ComercioID.ToString(),
                                       this.RefiCobranzaNueva.CreditoID.ToString(),
                                       this.RefiCobranzaNueva.RefinanciacionID.ToString(),
                                       this.RefiCobranzaNueva.RefinanciacionCuotaID.ToString(),
                                       this.RefiCobranzaNueva.RefinanciacionCobranzaID.ToString());
        }
    }
}
