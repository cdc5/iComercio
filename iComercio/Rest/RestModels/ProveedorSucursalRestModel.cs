using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iComercio.DAL;
using iComercio.Auxiliar;
using iComercio.Models;

namespace iComercio.Rest.RestModels
{
    public class ProveedorSucursalRestModel
    {
        public int? ProveedorSucursalID { get; set; }
        public int? ProveedorId { get; set; }
        public int? ProveedorSucursalIDRemoto { get; set; }
        public virtual Proveedor Proveedor { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Domicilio { get; set; }
        public int? LocalidadID { get; set; }
        public virtual Localidad Localidad { get; set; }
        public int? ProvinciaID { get; set; }
        public virtual Provincia Provincia { get; set; }
        public int? PaisId { get; set; }
        public virtual Pais Pais { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public string Telefono3 { get; set; }
        public string Mail1 { get; set; }
        public string Mail2 { get; set; }
        public string Mail3 { get; set; }
        public string Fax { get; set; }
        public string Web2 { get; set; }
        public string Web1 { get; set; }
        public string Web3 { get; set; }
        public string Cp { get; set; }
        public int EstadoID { get; set; }
        public virtual Estado Estado { get; set; }
        

    }
}
