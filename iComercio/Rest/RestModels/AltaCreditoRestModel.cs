using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iComercio.Models;

namespace iComercio.Rest.RestModels
{
    public class AltaCreditoRestModel : ITransmitibleCC
    {
        public CreditoRestModel Credito { get; set; }
        public ImputacionCuentaCorrienteRestModel ImputacionCC { get; set; }

        public AltaCreditoRestModel()
        {

        }

        public AltaCreditoRestModel(CreditoRestModel Credito, ImputacionCuentaCorrienteRestModel ImputacionCC)
        {
            this.Credito = Credito;
            this.ImputacionCC = ImputacionCC;
        }

        public Dictionary<string, Object> ApiParam(Comercio com)
        {
            Dictionary<string, Object> ApiParam = new Dictionary<string, object>();
            ApiParam.Add("EmpresaID", this.Credito.EmpresaID);
            ApiParam.Add("ComercioID", this.Credito.ComercioID);
            ApiParam.Add("CreditoID", this.Credito.CreditoID);
            return ApiParam;
        }

        public void ApiActualizarCCDesdeRemoto(BusinessLayer bl, ImputacionCuentaCorrienteRestModel iccRM)
        {
            bl.ActualizarCCDesdeRemoto(iccRM);
        }

        public void ApiActualizarDesdeRemoto(BusinessLayer bl, object c)
        {
            AltaCreditoRestModel acrm = (AltaCreditoRestModel)c;
            ApiActualizarCCDesdeRemoto(bl, acrm.ImputacionCC);
        }

        public InfoTransmision InfoTransmision()
        {
            return new InfoTransmision(this.Credito.EmpresaID.ToString(),
                                       this.Credito.ComercioID.ToString(),
                                       this.Credito.CreditoID.ToString());
        }
    }
}
