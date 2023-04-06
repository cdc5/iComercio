using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iComercio.Models
{
    public class FFDetalle
    {
        public int EmpresaID { get; set; }
        public int ComercioID { get; set; }
        public int FFID { get; set; }
        public int FFDetalleID { get; set; }
        public virtual FF FF { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Importe { get; set; }
        public string Detalle { get; set; }
        public decimal ImportePago { get; set; }

        public virtual List<Pago> Pagos { get; set; }
        
        public string DetalleFFDescripcion()
        {
            return string.Format("FF:{0}- Item:{1} - {2} - Importe:${3} - Pago:${4}", FFID, FFDetalleID, Fecha, Importe, ImportePago);
        }
        public string sDetalleFFDescripcion
        {
            get { return DetalleFFDescripcion(); }
            set { ;}

        }
    }
}
