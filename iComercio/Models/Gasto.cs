using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iComercio.Models
{
    public class Gasto:ITransmitible
    {
      public int EmpresaID { get; set; }
      public Empresa Empresa { get; set; }
      public int ComercioID { get; set; }
      public Comercio Comercio { get; set; }
      public int GastoID { get; set; }
      public long? SolicitudFondoID { get; set; }
      public SolicitudFondo SolicitudFondo { get; set; }
      public bool Activo { get; set; }
      public decimal Importe { get; set; }
      public string Descripcion { get; set; }
      public int? DepartamentoID { get; set; }
      public Departamento Departamento { get; set; }
      public int? ConceptoGastoID { get; set; }
      public ConceptoGastos ConceptoGastos { get; set; }
      public int? ConceptoGastoProveedorID { get; set; }
      public ConceptoGastosProveedor ConceptoGastosProveedor { get; set; }
      public int? ProveedorID { get; set; }
      public Proveedor Proveedor { get; set; }
      public int? ProveedorSucursalID { get; set; }
      public ProveedorSucursal ProveedorSucursal { get; set; }
      public DateTime Fecha { get; set; }
      public bool Pagado { get; set; }
      public int? EstadoID { get; set; }
      public Estado Estado { get; set; }

      public Dictionary<string, Object> ApiParam(Comercio com)
      {
          Dictionary<string, Object> ApiParam = new Dictionary<string, object>();
          ApiParam.Add("EmpresaID", this.EmpresaID);
          ApiParam.Add("ComercioID", this.ComercioID);
          ApiParam.Add("GastoID", this.GastoID);
          return ApiParam;
      }

      public void ApiActualizarDesdeRemoto(BusinessLayer bl, object c)
      {

      }

      public InfoTransmision InfoTransmision()
      {
          return new InfoTransmision(this.GastoID.ToString());
      }
    }
}
