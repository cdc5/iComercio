using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iComercio.Models;
using iComercio.Rest.RestModels;

namespace iComercio.Rest.RestModels
{
    public class AltaPagoAnticipadoRestModel:ITransmitibleCC
    {
        public List<AltaCobranzaRestModel> CobranzasRM { get; set; }
        public List<NotasCDRestModel> NotasCDRM { get; set; }
        public ImputacionCuentaCorrienteRestModel ImputacionCC { get; set; }

        public Dictionary<string, Object> ApiParam(Comercio com)
        {
            Dictionary<string, Object> ApiParam = new Dictionary<string, object>();
            ApiParam.Add("EmpresaID", this.CobranzasRM.FirstOrDefault().CobranzaRM.EmpresaID);
            ApiParam.Add("ComercioID", this.CobranzasRM.FirstOrDefault().CobranzaRM.ComercioID);
            ApiParam.Add("CreditoID", this.CobranzasRM.FirstOrDefault().CobranzaRM.CreditoID);
            return ApiParam;
        }

        public AltaPagoAnticipadoRestModel()
        {
            CobranzasRM = new List<AltaCobranzaRestModel>();
            NotasCDRM = new List<NotasCDRestModel>();
        }

        public void ApiActualizarCCDesdeRemoto(BusinessLayer bl, ImputacionCuentaCorrienteRestModel iccRM)
        {
            bl.ActualizarCCDesdeRemoto(iccRM);
        }

        public void ApiActualizarDesdeRemoto(BusinessLayer bl, object c)
        {
            AltaPagoAnticipadoRestModel acrm = (AltaPagoAnticipadoRestModel)c;
            ApiActualizarCCDesdeRemoto(bl, acrm.ImputacionCC);
        }

        /*Transmision*/
        

        public InfoTransmision InfoTransmision()
        {
            return new InfoTransmision(this.CobranzasRM.FirstOrDefault().CobranzaRM.EmpresaID.ToString(),
                                       this.CobranzasRM.FirstOrDefault().CobranzaRM.ComercioID.ToString(),
                                       this.CobranzasRM.FirstOrDefault().CobranzaRM.CreditoID.ToString());
        }
    }
}
