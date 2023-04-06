using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iComercio.Models;

namespace iComercio.Rest.RestModels
{
    public class EnvioCapRestModel : ITransmitibleCC
    {
        public CapRestModel CapRM { get; set; }
        public ImputacionCuentaCorrienteRestModel ImputacionCC { get; set; }

        public EnvioCapRestModel()
        {

        }

        public EnvioCapRestModel(CapRestModel CapRM, ImputacionCuentaCorrienteRestModel ImputacionCC)
        {
            this.CapRM = CapRM;
            this.ImputacionCC = ImputacionCC;
        }

        public Dictionary<string, Object> ApiParam(Comercio com)
        {
            Dictionary<string, Object> ApiParam = new Dictionary<string, object>();
            ApiParam.Add("EmpresaID", this.CapRM.EmpresaID);
            ApiParam.Add("ComercioID", this.CapRM.ComercioID);
            ApiParam.Add("CapID", this.CapRM.CapID);
            return ApiParam;
        }

        public void ApiActualizarCCDesdeRemoto(BusinessLayer bl, ImputacionCuentaCorrienteRestModel iccRM)
        {
            bl.ActualizarCCDesdeRemoto(iccRM);
        }

        public void ApiActualizarDesdeRemoto(BusinessLayer bl, object c)
        {
            EnvioCapRestModel ecrm = (EnvioCapRestModel)c;
            if (ecrm != null)
            {
                if (ecrm.CapRM != null)
                {
                    Cap cap = bl.Get<Cap>(ecrm.CapRM.EmpresaID, p => p.EmpresaID == ecrm.CapRM.EmpresaID
                                            && p.ComercioID == ecrm.CapRM.ComercioID && ecrm.CapRM.CapID == p.CapID).Single();
                    cap.SolicitudFondo.SolicitudFondoIDRemoto = ecrm.CapRM.SolicitudFondoID;
                    bl.Actualizar<SolicitudFondo>(cap.SolicitudFondo);
                    //ApiActualizarCCDesdeRemoto(bl, ecrm.ImputacionCC);
                }
            }
        }

        public InfoTransmision InfoTransmision()
        {
            return new InfoTransmision(this.CapRM.CapID.ToString());
        }
    }
}
