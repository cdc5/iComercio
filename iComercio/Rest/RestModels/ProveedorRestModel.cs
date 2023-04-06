using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iComercio.DAL;
using iComercio.Auxiliar;
using iComercio.Models;

namespace iComercio.Rest.RestModels
{
    public class ProveedorRestModel
    {
        public int? ProveedorID { get; set; }
        public int? ProveedorIDRemoto { get; set; }
        public string NombreFantasia { get; set; }
        public string RazonSocial { get; set; }
        public string Cuit { get; set; }
        public string IngresosBrutos { get; set; }
        public string Domicilio { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public string Descripcion { get; set; }
        public int? LocalidadID { get; set; }
        public virtual Localidad Localidad { get; set; }
        public int? ProvinciaID { get; set; }
        public virtual Provincia Provincia { get; set; }
        public int? PaisId { get; set; }
        public virtual Pais Pais { get; set; }
        public string Cp { get; set; }
        public string Fax { get; set; }
        public string Mail1 { get; set; }
        public string Mail2 { get; set; }
        public string Mail3 { get; set; }
        public string Web1 { get; set; }
        public string Web2 { get; set; }
        public string Tel3 { get; set; }
        public string Web3 { get; set; }
        public string CodigoContable { get; set; }
        public virtual ObservableListSource<ProveedorSucursalRestModel> Sucursales { get; set; }
        public int EstadoID { get; set; }
        public virtual Estado Estado { get; set; }
        public virtual ObservableListSource<ConceptoGastoProveedorRestModel> ConceptoGastosProveedor { get; set; }
        public int? CondIva { get; set; }
        public DateTime FechaAlta { get; set; }
    }
}
