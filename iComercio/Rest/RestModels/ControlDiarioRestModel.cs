using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iComercio.Models;

namespace iComercio.Rest.RestModels
{
    public class ControlDiarioRestModel : ITransmitible
    {
        public int EmpresaID { get; set; }
        public int ComercioID { get; set; }
        public int ControlDiarioID { get; set; }
        public System.DateTime Fecha { get; set; }
        public int AltasCreditos { get; set; }
        public decimal ValorNominalAltas { get; set; }
        public int BajasCreditos { get; set; }
        public decimal ValorNominalBajas { get; set; }
        public int Cobranzas { get; set; }
        public decimal ImporteCobranzas { get; set; }
        public int BajasCobranzas { get; set; }
        public decimal BajasImporteCobranzas { get; set; }

        /*cdcnvo_10022021*/
        public int NotasCD { get; set; }
        public decimal ImporteNotasCD { get; set; }
        public decimal CtaCteDebe { get; set; }
        public decimal CtaCteHaber { get; set; }
        public decimal CtaCteSaldoDiario { get; set; }
        public decimal CtaCteSaldo { get; set; }
        /**/

        public Dictionary<string, Object> ApiParam(Comercio com)
        {
            Dictionary<string, Object> ApiParam = new Dictionary<string, object>();
            ApiParam.Add("EmpresaID", com.EmpresaID);
            ApiParam.Add("ComercioID", com.ComercioID);
            return ApiParam;
        }

        public void ApiActualizarDesdeRemoto(BusinessLayer bl, object c)
        {

        }

        public InfoTransmision InfoTransmision()
        {
            return new InfoTransmision(this.ControlDiarioID.ToString());
        }
    }
}
