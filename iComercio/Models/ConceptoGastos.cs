using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iComercio.Models
{
    public class ConceptoGastos
    {
        public int? ConceptoGastosID { get; set; }
        public int? ConceptoGastosIDRemoto { get; set; }

        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int EstadoID { get; set; }
        public virtual Estado Estado { get; set; }
        public int? Nivel { get; set; }
        public bool NivelFinal { get; set; }
        public string NombreCompleto
        {
            get { return ToString(); }
            set { ;}
        }

        public int? ConceptoGastoPadreID { get; set; }
        public ConceptoGastos ConceptoGastoPadre { get; set; }

        public override string ToString()
        {
            if (ConceptoGastoPadre != null)
            {
                return String.Format("{0}-{1}", ConceptoGastoPadre.ToString(), Nombre);
            }
            return Nombre;            
        }        
    }
}
