using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iComercio.Models;

namespace iComercio.Rest.RestModels
{
    public class AltaCobranzaRestModel: ITransmitibleCC
    {
        public CobranzaRestModel CobranzaRM { get; set; }
        public CuotaRestModel CuotaRM { get; set; }
        public NotasCDRestModel NotasCDRM { get; set; }
        public ImputacionCuentaCorrienteRestModel ImputacionCC { get; set; }

        

        public AltaCobranzaRestModel()
        {

        }

        public AltaCobranzaRestModel(CobranzaRestModel CobranzaRM, CuotaRestModel CuotaRM, NotasCDRestModel NotasCDRM, ImputacionCuentaCorrienteRestModel ImputacionCC)
        {
            this.CobranzaRM = CobranzaRM;
            this.CuotaRM = CuotaRM;
            this.NotasCDRM = NotasCDRM;
            this.ImputacionCC = ImputacionCC;
        }

        public Dictionary<string, Object> ApiParam(Comercio com)
        {
            Dictionary<string, Object> ApiParam = new Dictionary<string, object>();
            ApiParam.Add("EmpresaID", this.CobranzaRM.EmpresaID);
            ApiParam.Add("ComercioID", this.CobranzaRM.ComercioID);
            ApiParam.Add("CreditoID", this.CobranzaRM.CreditoID);
            ApiParam.Add("CuotaID", this.CobranzaRM.CuotaID);
            ApiParam.Add("CobranzaID", this.CobranzaRM.CobranzaID);
            return ApiParam;
        }

        public void ApiActualizarCCDesdeRemoto(BusinessLayer bl, ImputacionCuentaCorrienteRestModel iccRM)
        {
            bl.ActualizarCCDesdeRemoto(iccRM);
        }

        public void ApiActualizarDesdeRemoto(BusinessLayer bl,object c)
        {
            AltaCobranzaRestModel acrm = (AltaCobranzaRestModel)c;
            ApiActualizarCCDesdeRemoto(bl, acrm.ImputacionCC);
        }

        public InfoTransmision InfoTransmision()
        {
            return new InfoTransmision(this.CobranzaRM.EmpresaID.ToString(),
                                       this.CobranzaRM.ComercioID.ToString(),
                                       this.CobranzaRM.CreditoID.ToString(),
                                       this.CobranzaRM.CuotaID.ToString(),
                                       this.CobranzaRM.CobranzaID.ToString());
        }

    }
}
