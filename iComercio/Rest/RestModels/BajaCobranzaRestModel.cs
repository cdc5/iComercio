using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iComercio.Models;
using iComercio.Rest.RestModels;

namespace iComercio.Rest.RestModels
{
    public class BajaCobranzaRestModel:ITransmitibleCC
    {
        public CuotaRestModel CuotaActRM { get; set; }
        public CobranzaRestModel CobranzaNuevaRM { get; set; }
        public CobranzaRestModel CobranzaModRM { get; set; }
        public NotasCDRestModel NotasCDRM { get; set; }
        public ImputacionCuentaCorrienteRestModel ImputacionCC { get; set; }

        public BajaCobranzaRestModel()
        {

        }

        public BajaCobranzaRestModel(CuotaRestModel CuotaActRM, CobranzaRestModel CobranzaNuevaRM,
                                    CobranzaRestModel CobranzaModRM,NotasCDRestModel NotasCDRM)
        {
            this.CuotaActRM = CuotaActRM;
            this.CobranzaNuevaRM = CobranzaNuevaRM;
            this.CobranzaModRM = CobranzaModRM;
            this.NotasCDRM = NotasCDRM;
        }

        public Dictionary<string, Object> ApiParam(Comercio com)
        {
            Dictionary<string, Object> ApiParam = new Dictionary<string, object>();
            ApiParam.Add("EmpresaID", this.CobranzaNuevaRM.EmpresaID);
            ApiParam.Add("ComercioID", this.CobranzaNuevaRM.ComercioID);
            ApiParam.Add("CreditoID", this.CobranzaNuevaRM.CreditoID);
            ApiParam.Add("CuotaID", this.CobranzaNuevaRM.CuotaID);
            ApiParam.Add("CobranzaID", this.CobranzaNuevaRM.CobranzaID);
            return ApiParam;
        }

        public void ApiActualizarCCDesdeRemoto(BusinessLayer bl, ImputacionCuentaCorrienteRestModel iccRM)
        {
            bl.ActualizarCCDesdeRemoto(iccRM);
        }

        public void ApiActualizarDesdeRemoto(BusinessLayer bl, object c)
        {
            BajaCobranzaRestModel acrm = (BajaCobranzaRestModel)c;
            ApiActualizarCCDesdeRemoto(bl, acrm.ImputacionCC);
        }

        /*Transmision*/
       

        public InfoTransmision InfoTransmision()
        {
            return new InfoTransmision(this.CobranzaNuevaRM.EmpresaID.ToString(),
                                       this.CobranzaNuevaRM.ComercioID.ToString(),
                                       this.CobranzaNuevaRM.CreditoID.ToString(),
                                       this.CobranzaNuevaRM.CuotaID.ToString(),
                                       this.CobranzaNuevaRM.CobranzaID.ToString());
        }
    }
}
