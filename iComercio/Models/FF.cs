using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iComercio.Models
{
    public class FF :ITransmitible
    {
        public int EmpresaID { get; set; }
        public virtual Empresa Empresa { get; set; }
        public int ComercioID { get; set; }
        public virtual Comercio Comercio { get; set; }
        public int FFID { get; set; }
        public DateTime Fecha { get; set; }
        public decimal PendienteReposicionSemAnt { get; set; }
        public decimal Remanente { get; set; }
        public decimal TotalGastos { get; set; }
        public decimal MontoFF { get; set; }
        public decimal Repuesto { get; set; }
        public string Notas { get; set; }
        public int EstadoID { get; set; }
        public virtual Estado Estado { get; set; }

        public decimal AReponer 
        {
            get { return TotalGastos + PendienteReposicionSemAnt ;}
            set { ;} 
        }

        public bool Pagado
        {
            get {return (AReponer == Repuesto);}
            set { ;} 
        }

        public long? SolicitudFondoID { get; set; }
        public virtual SolicitudFondo SolicitudFondo { get; set; }
        public virtual List<FFDetalle> Items { get; set; }

        public Dictionary<string, Object> ApiParam(Comercio com)
        {
            Dictionary<string, Object> ApiParam = new Dictionary<string, object>();
            ApiParam.Add("EmpresaID", this.EmpresaID);
            ApiParam.Add("ComercioID", this.ComercioID);
            ApiParam.Add("FFID", this.FFID);
            return ApiParam;
        }

        public void ApiActualizarDesdeRemoto(BusinessLayer bl, object c)
        {

        }

        public InfoTransmision InfoTransmision()
        {
            return new InfoTransmision(this.FFID.ToString());
        }

        public string FFDescripcion()
        {
            return string.Format("FF:{0}- Item:{1} - {2} - Total:${3}", FFID, Fecha, TotalGastos);
        }
        public string sFFDescripcion
        {
            get { return FFDescripcion(); }
            set { ;}

        }
       
    }
}
