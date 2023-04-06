using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iComercio.Rest.RestModels
{
    public class FFDetalleRestModel
    {
        public int EmpresaID { get; set; }
        public int ComercioID { get; set; }
        public int FFID { get; set; }
        public int FFDetalleID { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Importe { get; set; }
        public string Detalle { get; set; }
        public decimal ImportePago { get; set; }

        public virtual List<PagoRestModel> Pagos { get; set; }
    }
}
