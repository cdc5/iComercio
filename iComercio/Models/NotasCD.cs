using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using iComercio.Rest.RestModels;

namespace iComercio.Models
{
    public class NotasCD:ITransmitible
    {
        public int NotaCDID { get; set; }
        public string TipoNota { get; set; }            //CREDITO DEBITO

        public decimal Importe { get; set; }
        public DateTime Fecha { get; set; }

        public int EmpresaID { get; set; }
        public int ComercioID { get; set; }
        public int CreditoID { get; set; }
        public int CuotaID { get; set; }
        public int CobranzaID { get; set; }
        public virtual Cobranza Cobranza { get; set; }

        public int Documento { get; set; }
        public string TipoDocumentoID { get; set; }

        public string Detalle { get; set; }            //notas

        public int GestionID { get; set; }

        public int UsuarioID { get; set; } //usuario
        public virtual Usuario Usuario { get; set; } //Usuario
        public string PcComer { get; set; } //PC_comer
        public string Notas { get; set; }

        /*Transmision*/
        
        public InfoTransmision InfoTransmision()
        {
            return new InfoTransmision(EmpresaID.ToString(), ComercioID.ToString(), CreditoID.ToString(), CuotaID.ToString(), CobranzaID.ToString(),NotaCDID.ToString());
        }

        public Dictionary<string, Object> ApiParam(Comercio com)
        {
            Dictionary<string, Object> ApiParam = new Dictionary<string, object>();
            ApiParam.Add("EmpresaID", this.EmpresaID);
            ApiParam.Add("ComercioID", this.ComercioID);
            ApiParam.Add("CreditoID", this.CreditoID);
            ApiParam.Add("CuotaID", this.CuotaID);
            ApiParam.Add("CobranzaID", this.CobranzaID);
            ApiParam.Add("NotaCDID", this.NotaCDID);
            return ApiParam;
        }

        public void ApiActualizarDesdeRemoto(BusinessLayer bl, object c)
        {
          
        }

        public Expression<Func<Transmision, bool>> ExpresionDeBusqueda(Transmision tran, Operacion op)
        {
            string empID = EmpresaID.ToString();
            string comID = ComercioID.ToString();
            string credID = CreditoID.ToString();
            string cuoID = CuotaID.ToString();
            string cobID = CobranzaID.ToString();
            string ncID = NotaCDID.ToString();
            return t => t.GrupoTransmision == tran.GrupoTransmision && t.OperacionID == op.OperacionID
                  && t.EntidadID == empID && t.EntidadID2 == comID && t.EntidadID3 == credID
                  && t.EntidadID4 == cuoID && t.EntidadID5 == cobID && t.EntidadID6 == ncID;
        }

    }
}
