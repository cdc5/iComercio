using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iComercio.Models
{
    public class ConceptoGastosDepartamento
    {
        public int? ConceptoGastosDepartamentoID { get; set; }
        
        public int? ConceptoGastosID { get; set; }
        public virtual ConceptoGastos ConceptoGastos { get; set; }
        
        public int? DepartamentoID { get; set; }
        public virtual Departamento Departamento { get; set; }
        
        public int presupuesto { get; set; }
        public int EstadoID { get; set; }
        public virtual Estado Estado { get; set; }
    }
}
