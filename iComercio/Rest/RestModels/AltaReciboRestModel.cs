using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iComercio.Models;
using AutoMapper;

namespace iComercio.Rest.RestModels
{
    public class AltaReciboRestModel : ITransmitibleCC
    {
        public ReciboRestModel ReciboRM { get; set; }
        public AltaTransDepRestModel AltaTranDepRM { get; set; }
        public ImputacionCuentaCorrienteRestModel ImputacionCC { get; set; }

        public AltaReciboRestModel()
        {

        }

        public AltaReciboRestModel(ReciboRestModel ReciboRM, AltaTransDepRestModel AltaTranDepRM, ImputacionCuentaCorrienteRestModel ImputacionCC)
        {
            this.ReciboRM = ReciboRM;
            this.AltaTranDepRM = AltaTranDepRM;
            this.ImputacionCC = ImputacionCC;
        }

        public Dictionary<string, Object> ApiParam(Comercio com)
        {
            Dictionary<string, Object> ApiParam = new Dictionary<string, object>();
            ApiParam.Add("EmpresaID", this.ReciboRM.EmpresaID);
            ApiParam.Add("ComercioID", this.ReciboRM.ComercioID);
            ApiParam.Add("ReciboID", this.ReciboRM.ReciboID);
            return ApiParam;
        }

        public void ApiActualizarCCDesdeRemoto(BusinessLayer bl, ImputacionCuentaCorrienteRestModel iccRM)
        {
            bl.ActualizarCCDesdeRemoto(iccRM);
        }

        public void ApiActualizarDesdeRemoto(BusinessLayer bl,object c)
        {
            AltaReciboRestModel arrm = (AltaReciboRestModel)c;
            Recibo rec = bl.Get<Recibo>(r=> r.EmpresaID == arrm.ReciboRM.EmpresaID && r.ComercioID == arrm.ReciboRM.ComercioID
                                        && r.ReciboID == arrm.ReciboRM.ReciboIDRemoto).SingleOrDefault();
            if (rec != null)
            {
                ApiActualizarCCDesdeRemoto(bl, arrm.ImputacionCC);
                rec.ReciboIDRemoto = arrm.ReciboRM.ReciboID;
                bl.ActualizarTransaccional<Recibo>(rec);
                if (rec.TransferenciasDepositos != null)
                {
                    rec.TransferenciasDepositos.TransferenciasDepositosIDRemoto = arrm.AltaTranDepRM.TransDepRM.TransferenciasDepositosID;
                   // bl.ActualizarTransaccional<TransferenciasDepositos>(rec.TransferenciasDepositos);
                }
                bl.Grabar();
            }
        }

        public InfoTransmision InfoTransmision()
        {
            return new InfoTransmision(this.ReciboRM.EmpresaID.ToString(),
                                       this.ReciboRM.ComercioID.ToString(),
                                       this.ReciboRM.ReciboID.ToString());
        }
    }
}
