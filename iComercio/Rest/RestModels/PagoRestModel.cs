using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iComercio.Rest.RestModels
{
    public class PagoRestModel
    {
        public int EmpresaID { get; set; }
        public int ComercioID { get; set; }
        public int PagoID { get; set; }
        public long? SolicitudFondoID { get; set; }
        public int? CapID { get; set; }
        public int? CapDetalleID { get; set; }
        public int? FFID { get; set; }
        public int? FFDetalleID { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Importe { get; set; }
        public int EstadoID { get; set; }
    }
}
