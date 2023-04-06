using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iComercio.Models
{
    public class SolicitudFondoConceptoGastosProveedor
    {
        public int? ComercioID { get; set; }
        public virtual Comercio Comercio { get; set; }
        public int? EmpresaID { get; set; }
        public virtual Empresa Empresa { get; set; }
        public long? SolicitudFondoID { get; set; }
        public SolicitudFondo SolicitudFondo { get; set; }
        public int? ConceptoGastosProveedorID { get; set; }
        public virtual ConceptoGastosProveedor ConceptoGastosProveedor { get; set; }
        public decimal? Importe { get; set; }
        public string Detalle { get; set; }

        public string sConceptoGastosProveedor { get { return ConceptoGastosProveedorNombre(); } set { ;} }
       
        private string ConceptoGastosProveedorNombre()
        {
            if (ConceptoGastosProveedor!= null)
            {
                return ConceptoGastosProveedor.ToString();
            }
            return string.Empty;
        }
    }
}
