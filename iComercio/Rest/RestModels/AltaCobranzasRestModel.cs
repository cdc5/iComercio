using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iComercio.Models;

namespace iComercio.Rest.RestModels
{
    class AltaCobranzasRestModel : ITransmitibleCC
    {
        public List<AltaCobranzaRestModel> AltasCobranzas { get; set; }
        //public List<CobranzaRestModel> CobranzasRM { get; set; }
        //public List<CuotaRestModel> CuotasRM { get; set; }
        //public List<NotasCDRestModel> NotasCDRM { get; set; }
        public ImputacionCuentaCorrienteRestModel ImputacionCC { get; set; }
        

        public AltaCobranzasRestModel()
        {
            AltasCobranzas = new List<AltaCobranzaRestModel>();
            //CobranzasRM = new List<CobranzaRestModel>();
            //CuotasRM = new List<CuotaRestModel>();
            //NotasCDRM = new List<NotasCDRestModel>();
            ImputacionCC = new ImputacionCuentaCorrienteRestModel();
        }

        public AltaCobranzasRestModel(List<AltaCobranzaRestModel> AltasCobranzas,ImputacionCuentaCorrienteRestModel ImputacionCC)
        {
            this.AltasCobranzas = AltasCobranzas;
            //this.CobranzasRM = CobranzaRM;
            //this.CuotasRM = CuotaRM;
            //this.NotasCDRM = NotasCDRM;
            this.ImputacionCC = ImputacionCC;
        }

        public Dictionary<string, Object> ApiParam(Comercio com)
        {
            Dictionary<string, Object> ApiParam = new Dictionary<string, object>();
            ApiParam.Add("EmpresaID", this.AltasCobranzas[0].CobranzaRM.EmpresaID);
            ApiParam.Add("ComercioID", this.AltasCobranzas[0].CobranzaRM.ComercioID);
            ApiParam.Add("CreditoID", this.AltasCobranzas[0].CobranzaRM.CreditoID);
            ApiParam.Add("CuotaID", this.AltasCobranzas[0].CobranzaRM.CuotaID);
            ApiParam.Add("CobranzaID", this.AltasCobranzas[0].CobranzaRM.CobranzaID);
            return ApiParam;
        }

        public void ApiActualizarCCDesdeRemoto(BusinessLayer bl, ImputacionCuentaCorrienteRestModel iccRM)
        {
            bl.ActualizarCCDesdeRemoto(iccRM);
        }

        public void ApiActualizarDesdeRemoto(BusinessLayer bl,object c)
        {
            AltaCobranzasRestModel acrm = (AltaCobranzasRestModel)c;
            ApiActualizarCCDesdeRemoto(bl, acrm.ImputacionCC);
        }

        public InfoTransmision InfoTransmision()
        {
            return new InfoTransmision(this.AltasCobranzas[0].CobranzaRM.EmpresaID.ToString(),
                                       this.AltasCobranzas[0].CobranzaRM.ComercioID.ToString(),
                                       this.AltasCobranzas[0].CobranzaRM.CreditoID.ToString(),
                                       this.AltasCobranzas[0].CobranzaRM.CuotaID.ToString(),
                                       this.AltasCobranzas[0].CobranzaRM.CobranzaID.ToString());
        }
    }
}
