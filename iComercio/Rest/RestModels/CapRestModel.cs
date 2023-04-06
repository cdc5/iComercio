using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iComercio.Rest.RestModels
{
    public class CapRestModel
    {
        public int EmpresaID { get; set; }
        public int ComercioID { get; set; }
        public int CapID { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public string Notas { get; set; }
        public long? SolicitudFondoID { get; set; }
        public virtual SolicitudFondoRestModel SolicitudFondoRestModel { get; set; }
        public decimal Pagado { get; set; }
        public virtual List<CapDetalleRestModel> Items { get; set; }
        public bool Finalizado { get; set; }
        public decimal Saldo { get; set; }
        public int EstadoID { get; set; }

    }
}
