using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iComercio.Models;


namespace iComercio.Rest.RestModels
{
    public class InfoActRestModel : ITransmitible
    {
        public DateTime Desde { get; set; }
        public DateTime Hasta { get; set; }
        public int ComercioBusqueda { get; set; }
        public int ComercioBusquedaEmpId { get; set; }
        public int? CreditoID { get; set; }
        public List<ClienteRestModel> Clientes { get; set; }
        public List<CreditoRestModel> Creditos { get; set; }
        public List<CreditoAnuladoRestModel> CreditosAnulados { get; set; }
        public List<CobranzaRestModel> Cobranzas { get; set; }
        public List<NotasCDRestModel> NotasCD { get; set; }
        public List<RefinanciacionRestModel> Refinanciaciones { get; set; }
        public List<RefinanciacionRestModel> RefinanciacionesAnuladas { get; set; }
        public List<RefinanciacionCobranzaRestModel> RefinanciacionesCobranzas { get; set; }
        
        
        public Dictionary<string, Object> ApiParam(Comercio com)
        {
            Dictionary<string, Object> ApiParam = new Dictionary<string, object>();
            ApiParam.Add("EmpresaID", com.EmpresaID);
            ApiParam.Add("ComercioID", com.ComercioID);
            ApiParam.Add("ComerBuscaEmpID", ComercioBusquedaEmpId);
            ApiParam.Add("ComerBuscaID", ComercioBusqueda);
            ApiParam.Add("FechaDesde", this.Desde.ToString("yyyy-MM-dd"));
            ApiParam.Add("FechaHasta", this.Hasta.ToString("yyyy-MM-dd"));
            ApiParam.Add("CreditoID", CreditoID);
            return ApiParam;
        }

       

        public void ApiActualizarDesdeRemoto(BusinessLayer bl, object c)
        {

        }

        public InfoTransmision InfoTransmision()
        {
            return new InfoTransmision(this.Desde.ToString(), this.Hasta.ToString());
        }
    }
}
