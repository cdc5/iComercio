using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iComercio.Models;

namespace iComercio.Rest.RestModels
{
    public class AltaTransDepRestModel : ITransmitibleCC
    {
        
        public TransferenciasDepositosRestModel TransDepRM { get; set; }
        public ImputacionCuentaCorrienteRestModel ImputacionCC { get; set; }

        public AltaTransDepRestModel()
        {

        }

        public AltaTransDepRestModel(TransferenciasDepositosRestModel TransDepRM, ImputacionCuentaCorrienteRestModel ImputacionCC)
        {
            this.TransDepRM = TransDepRM;
            this.ImputacionCC = ImputacionCC;
        }

        public Dictionary<string, Object> ApiParam(Comercio com)
        {
            Dictionary<string, Object> ApiParam = new Dictionary<string, object>();
            ApiParam.Add("EmpresaID", this.TransDepRM.EmpresaID);
            ApiParam.Add("TransferenciaDepositoID", this.TransDepRM.TransferenciasDepositosID);
            return ApiParam;
        }

        public void ApiActualizarCCDesdeRemoto(BusinessLayer bl, ImputacionCuentaCorrienteRestModel iccRM)
        {
            bl.ActualizarCCDesdeRemoto(iccRM);
        }

        public void ApiActualizarDesdeRemoto(BusinessLayer bl,object c)
        {
            AltaTransDepRestModel acrm = (AltaTransDepRestModel)c;
            ApiActualizarCCDesdeRemoto(bl, acrm.ImputacionCC);
        }

        public InfoTransmision InfoTransmision()
        {
            return new InfoTransmision(this.TransDepRM.EmpresaID.ToString(),
                                       this.TransDepRM.TransferenciasDepositosID.ToString());
        }

    }
}
