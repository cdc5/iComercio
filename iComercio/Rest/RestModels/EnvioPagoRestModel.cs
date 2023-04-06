using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iComercio.Models;

namespace iComercio.Rest.RestModels
{
    public class EnvioPagoRestModel : ITransmitibleCC
    {
        public PagoRestModel PagoRM { get; set; }
        public ImputacionCuentaCorrienteRestModel ImputacionCC { get; set; }

        public EnvioPagoRestModel()
        {

        }

        public EnvioPagoRestModel(PagoRestModel PagoRM, ImputacionCuentaCorrienteRestModel ImputacionCC)
        {
            this.PagoRM = PagoRM;
            this.ImputacionCC = ImputacionCC;
        }

        public Dictionary<string, Object> ApiParam(Comercio com)
        {
            Dictionary<string, Object> ApiParam = new Dictionary<string, object>();
            ApiParam.Add("EmpresaID", this.PagoRM.EmpresaID);
            ApiParam.Add("ComercioID", this.PagoRM.ComercioID);
            ApiParam.Add("PagoID", this.PagoRM.PagoID);
            return ApiParam;
        }
        public void ApiActualizarCCDesdeRemoto(BusinessLayer bl, ImputacionCuentaCorrienteRestModel iccRM)
        {
            bl.ActualizarCCDesdeRemoto(iccRM);
        }

        public void ApiActualizarDesdeRemoto(BusinessLayer bl,object c)
        {
            EnvioPagoRestModel acrm = (EnvioPagoRestModel)c;
            ApiActualizarCCDesdeRemoto(bl, acrm.ImputacionCC);
        }

        public InfoTransmision InfoTransmision()
        {
            return new InfoTransmision(this.PagoRM.PagoID.ToString());
        }
    }
}
