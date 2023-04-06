using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iComercio.DAL;
using iComercio.Auxiliar;
using iComercio.Models;

namespace iComercio.Rest.RestModels
{
    public class ConceptoGastoProveedorRestModel
    {
        public int? ConceptoGastosProveedorID { get; set; }

        public int? ConceptoGastosID { get; set; }
        public virtual ConceptoGastos ConceptoGastos { get; set; }

        public int? ProveedorID { get; set; }
        public virtual Proveedor Proveedor { get; set; }

        public int? ProveedorSucursalID { get; set; }
        public virtual ProveedorSucursal ProveedorSucursal { get; set; }

        public int? Periodicidad { get; set; }

        public int EstadoID { get; set; }
        public virtual Estado Estado { get; set; }
    }
}
