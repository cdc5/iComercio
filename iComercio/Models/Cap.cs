using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iComercio.Models
{
    public class  Cap:ITransmitible
    {
        public int EmpresaID { get; set; }
        public virtual Empresa Empresa { get; set; }
        public int ComercioID { get; set; }
        public virtual Comercio Comercio { get; set; }
        public int CapID { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public string Notas { get; set; }
        public long? SolicitudFondoID { get; set; }
        public virtual SolicitudFondo SolicitudFondo { get; set; }
        public decimal Pagado { get; set; }
        public virtual List<CapDetalle> Items { get; set; }
        public bool Finalizado { get; set; }
        public int EstadoID { get; set; }
        public virtual Estado Estado { get; set; }


        public decimal Saldo
        {
            get { return Total - Pagado; }
            set {;}
        }

        public string CapDescripcion()
        {
            return string.Format("CAP:{0} - {1} - Total: ${2} - Saldo:{3}", CapID, Fecha, Total,Saldo);
        }

        public string sCapDescripcion
        {
            get { return CapDescripcion(); }
            set { ;}

        }

        public Dictionary<string, Object> ApiParam(Comercio com)
        {
            Dictionary<string, Object> ApiParam = new Dictionary<string, object>();
            ApiParam.Add("EmpresaID", this.EmpresaID);
            ApiParam.Add("ComercioID", this.ComercioID);
            ApiParam.Add("CapID", this.CapID);
            return ApiParam;
        }

        public void ApiActualizarDesdeRemoto(BusinessLayer bl, object c)
        {

        }

        public InfoTransmision InfoTransmision()
        {
            return new InfoTransmision(this.CapID.ToString());
        }
        

        

    }
}
