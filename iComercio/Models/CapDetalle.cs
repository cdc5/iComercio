using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iComercio.Models
{
    public class CapDetalle
    {
        public int EmpresaID { get; set; }
        public int ComercioID { get; set; }
        public int CapID { get; set; }
        public virtual Cap Cap { get; set; }
        public int CapDetalleID { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public decimal Importe { get; set; }
        public string Detalle { get; set; }
        public decimal ImportePago { get; set; }
        public bool Finalizado { get; set; }

        public virtual List<Pago> Pagos { get; set; }

        public decimal PendientePago 
        {
            get { return Importe-ImportePago;}
            set { ;}
        }

        public string DetallCapDescripcion()
        {
            return string.Format("CAP:{0}- Item:{1} - {2} - Importe:${3} - Pago:${4}", CapID,CapDetalleID,FechaVencimiento, Importe, ImportePago);
        }

        public string sDetalleCapDescripcion
        {
            get { return DetallCapDescripcion(); }
            set { ;}
        }
    }
}
