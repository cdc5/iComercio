using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using iComercio.Rest.RestModels;


namespace iComercio.Models
{
    public class ConceptoGastosProveedor: ITransmitible
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


        /*Transmision*/
       
        public string EntidadID()
        {
            return ConceptoGastosProveedorID.ToString();
        }

        public string EntidadID2()
        {
            return null;
        }

        public string EntidadID3()
        {
            return null;
        }

        public InfoTransmision InfoTransmision()
        {
            return new InfoTransmision(ConceptoGastosProveedorID.Value.ToString()); 
        }

        public Dictionary<string, Object> ApiParam(Comercio com)
        {
            Dictionary<string, Object> ApiParam = new Dictionary<string, object>();
            ApiParam.Add("empID", com.EmpresaID);
            ApiParam.Add("comID", com.ComercioID);
            ApiParam.Add("ConceptoGastosProveedorID", this.ConceptoGastosProveedorID);
            return ApiParam;
        }

        public void ApiActualizarDesdeRemoto(BusinessLayer bl, object c)
        {
            //Cliente cli = (Cliente)c;
            //this.Documento = cli.Documento;
            //this.TipoDocumentoID = cli.TipoDocumentoID;
            bl.Actualizar<ConceptoGastosProveedor>((ConceptoGastosProveedor)c);
        }

        public String Nombre { get { return ToString(); } }
        public override string ToString()
        {
            string razon = Proveedor != null && !String.IsNullOrEmpty(Proveedor.RazonSocial) ? Proveedor.RazonSocial : String.Empty;
            string nombre = ConceptoGastos != null && !String.IsNullOrEmpty(ConceptoGastos.Nombre) ? ConceptoGastos.Nombre : String.Empty;
            return String.Format("{0}-{1}", nombre, razon);
        }

        public Expression<Func<Transmision, bool>> ExpresionDeBusqueda(Transmision tran, Operacion op)
        {
            return null;
        }
        
       
    }
}
