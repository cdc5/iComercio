using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iComercio.Models;

namespace iComercio.Rest.RestModels
{
    public class EnvioFFRestModel : ITransmitibleCC
    {
        public FFRestModel FFRM { get; set; }
        public ImputacionCuentaCorrienteRestModel ImputacionCC { get; set; }

        public EnvioFFRestModel()
        {

        }

        public EnvioFFRestModel(FFRestModel FFRM, ImputacionCuentaCorrienteRestModel ImputacionCC)
        {
            this.FFRM = FFRM;
            this.ImputacionCC = ImputacionCC;
        }

        public Dictionary<string, Object> ApiParam(Comercio com)
        {
            Dictionary<string, Object> ApiParam = new Dictionary<string, object>();
            ApiParam.Add("EmpresaID", this.FFRM.EmpresaID);
            ApiParam.Add("ComercioID", this.FFRM.ComercioID);
            ApiParam.Add("FFID", this.FFRM.FFID);
            return ApiParam;
        }

        public void ApiActualizarCCDesdeRemoto(BusinessLayer bl, ImputacionCuentaCorrienteRestModel iccRM)
        {
            bl.ActualizarCCDesdeRemoto(iccRM);
        }

        public void ApiActualizarDesdeRemoto(BusinessLayer bl,object c)
        {
            EnvioFFRestModel ecrm = (EnvioFFRestModel)c;
            if (ecrm != null)
            {
                if (ecrm.FFRM != null)
                {
                    FF FF = bl.Get<FF>(ecrm.FFRM.EmpresaID, p => p.EmpresaID == ecrm.FFRM.EmpresaID
                                            && p.ComercioID == ecrm.FFRM.ComercioID && ecrm.FFRM.FFID == p.FFID).Single();
                    FF.SolicitudFondo.SolicitudFondoIDRemoto = ecrm.FFRM.SolicitudFondoID;
                    bl.Actualizar<SolicitudFondo>(FF.SolicitudFondo);
                    //ApiActualizarCCDesdeRemoto(bl, ecrm.ImputacionCC);
                }
            }
        }

        public InfoTransmision InfoTransmision()
        {
            return new InfoTransmision(this.FFRM.FFID.ToString());
        }
    }
}
