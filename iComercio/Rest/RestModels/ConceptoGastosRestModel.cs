using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iComercio.DAL;
using iComercio.Auxiliar;
using iComercio.Models;


namespace iComercio.Rest.RestModels
{
    public class ConceptoGastosRestModel
    {
        public int? ConceptoGastosID { get; set; }
        public int? ConceptoGastosIDRemoto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int EstadoID { get; set; }
        public virtual Estado Estado { get; set; }
        public int? Nivel { get; set; }
        public bool NivelFinal { get; set; }
        public int? ConceptoGastoPadreID { get; set; }
        public ConceptoGastos ConceptoGastoPadre { get; set; }
    }
}
