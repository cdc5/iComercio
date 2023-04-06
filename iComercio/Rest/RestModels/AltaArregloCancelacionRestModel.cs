using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iComercio.Models;

namespace iComercio.Rest.RestModels
{
    public class AltaArregloCancelacionRestModel:ITransmitibleCC
    {
        public List<AltaCobranzaRestModel> CobranzasRM { get; set; }
        public ImputacionCuentaCorrienteRestModel ImputacionCC { get; set; }

        public AltaArregloCancelacionRestModel()
        {
            CobranzasRM = new List<AltaCobranzaRestModel>();
        }
        
        public Dictionary<string, Object> ApiParam(Comercio com)
        {
            Dictionary<string, Object> ApiParam = new Dictionary<string, object>();
            ApiParam.Add("EmpresaID", this.CobranzasRM.FirstOrDefault().CobranzaRM.EmpresaID);
            ApiParam.Add("ComercioID", this.CobranzasRM.FirstOrDefault().CobranzaRM.ComercioID);
            ApiParam.Add("CreditoID", this.CobranzasRM.FirstOrDefault().CobranzaRM.CreditoID);            
            return ApiParam;
        }

        public void ApiActualizarCCDesdeRemoto(BusinessLayer bl, ImputacionCuentaCorrienteRestModel iccRM)
        {
            bl.ActualizarCCDesdeRemoto(iccRM);
        }

        public void ApiActualizarDesdeRemoto(BusinessLayer bl, object c)
        {
            AltaArregloCancelacionRestModel acrm = (AltaArregloCancelacionRestModel)c;
            ApiActualizarCCDesdeRemoto(bl, acrm.ImputacionCC);
        }

        public InfoTransmision InfoTransmision()
        {
            return new InfoTransmision(this.CobranzasRM.FirstOrDefault().CobranzaRM.EmpresaID.ToString(),
                                       this.CobranzasRM.FirstOrDefault().CobranzaRM.ComercioID.ToString(),
                                       this.CobranzasRM.FirstOrDefault().CobranzaRM.CreditoID.ToString());
        }
    }
}
