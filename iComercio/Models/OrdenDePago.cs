using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iComercio.Models
{
    public class OrdenDePago
    {
        public int OrdenDePagoID { get; set; }

        public int? EmpresaID { get; set; }
        public virtual Empresa Empresa { get; set;}

        public DateTime Fecha { get; set; }
        public DateTime fecha_pago {get;set;}

        public decimal importe {get;set;}

        public int? EstadoID { get; set; }
        public virtual Estado Estado { get; set; }

        public int? ConceptoFondosID { get; set; }
        public virtual ConceptoFondos ConceptoFondos { get; set; }
    }
}
