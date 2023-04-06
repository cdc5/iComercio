using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iComercio.Models;

namespace iComercio.Rest.RestModels
{
    public class GastoRestModel
    {
        public int EmpresaID { get; set; }
        public int ComercioID { get; set; }
        public int GastoID { get; set; }
        public long? SolicitudFondoID { get; set; }
        public bool Activo { get; set; }
        public decimal Importe { get; set; }
        public string Descripcion { get; set; }
        public int? DepartamentoID { get; set; }
        public int? ConceptoGastoID { get; set; }
        public int? ConceptoGastoProveedorID { get; set; }
        public int? ProveedorID { get; set; }
        public int? ProveedorSucursalID { get; set; }
        public DateTime Fecha { get; set; }
        public bool Pagado { get; set; }
        public int? EstadoID { get; set; }
    }
}
