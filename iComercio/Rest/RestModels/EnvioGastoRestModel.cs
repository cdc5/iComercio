using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iComercio.Models;

namespace iComercio.Rest.RestModels
{
    public class EnvioGastoRestModel : ITransmitibleCC
    {
        public GastoRestModel GastoRM { get; set; }
        public ImputacionCuentaCorrienteRestModel ImputacionCC { get; set; }

        public EnvioGastoRestModel()
        {

        }

        public EnvioGastoRestModel(GastoRestModel GastoRM, ImputacionCuentaCorrienteRestModel ImputacionCC)
        {
            this.GastoRM = GastoRM;
            this.ImputacionCC = ImputacionCC;
        }

        public Dictionary<string, Object> ApiParam(Comercio com)
        {
            Dictionary<string, Object> ApiParam = new Dictionary<string, object>();
            ApiParam.Add("EmpresaID", this.GastoRM.EmpresaID);
            ApiParam.Add("ComercioID", this.GastoRM.ComercioID);
            ApiParam.Add("GastoID", this.GastoRM.GastoID);
            return ApiParam;
        }

        public void ApiActualizarCCDesdeRemoto(BusinessLayer bl, ImputacionCuentaCorrienteRestModel iccRM)
        {
            bl.ActualizarCCDesdeRemoto(iccRM);
        }

        public void ApiActualizarDesdeRemoto(BusinessLayer bl,object c)
        {
            EnvioGastoRestModel acrm = (EnvioGastoRestModel)c;
            ApiActualizarCCDesdeRemoto(bl, acrm.ImputacionCC);
        }

        public InfoTransmision InfoTransmision()
        {
            return new InfoTransmision(this.GastoRM.GastoID.ToString());
        }
    }
}
