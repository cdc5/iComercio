using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iComercio.Rest.RestModels
{
    public class FFRestModel
    {
        public int EmpresaID { get; set; }
        public int ComercioID { get; set; }
        public int FFID { get; set; }
        public DateTime Fecha { get; set; }
        public decimal PendienteReposicionSemAnt { get; set; }
        public decimal Remanente { get; set; }
        public decimal TotalGastos { get; set; }
        public decimal MontoFF { get; set; }
        public decimal Repuesto { get; set; }
        public string Notas { get; set; }
        public decimal AReponer { get; set; }
        public bool Pagado{ get; set; }
        public long? SolicitudFondoID { get; set; }
        public virtual SolicitudFondoRestModel SolicitudFondoRestModel { get; set; }
        public virtual List<FFDetalleRestModel> Items { get; set; }
        public int EstadoID { get; set; }

    }
}
