using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iComercio.Rest.RestModels
{
    public class CapDetalleRestModel
    {
        public int EmpresaID { get; set; }
        public int ComercioID { get; set; }
        public int CapID { get; set; }
        public int CapDetalleID { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public decimal Importe { get; set; }
        public string Detalle { get; set; }
        public decimal ImportePago { get; set; }
        public bool Finalizado { get; set; }
        public virtual List<PagoRestModel> Pagos { get; set; }
        public decimal PendientePago { get; set; }
    }
}
