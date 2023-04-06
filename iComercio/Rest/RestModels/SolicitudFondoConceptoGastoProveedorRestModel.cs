using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iComercio.Models;

namespace iComercio.Rest.RestModels
{
    public class SolicitudFondoConceptoGastosProveedorRestModel
    {
        public int? ComercioID { get; set; }
        public int? EmpresaID { get; set; }
        public long? SolicitudFondoID { get; set; }
        public int? ConceptoGastosProveedorID { get; set; }
        public int? ProveedorID { get; set; }
        public int? ConceptoGastoID { get; set; }
        public decimal? Importe { get; set; }
        public string Detalle { get; set; }
    }
}

