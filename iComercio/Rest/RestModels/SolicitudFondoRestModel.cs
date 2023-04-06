using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iComercio.Models;

namespace iComercio.Rest.RestModels
{
    public class SolicitudFondoRestModel
    {
        public long? SolicitudFondoID { get; set; }
        public long? SolicitudFondoIDRemoto { get; set; }
        public DateTime? FechaPago { get; set; }
        public DateTime? FechaRealizacion { get; set; }
        public decimal? Importe { get; set; }
        public string Motivo { get; set; }
        public int? LiquidacionID { get; set; }
        public DateTime? FechaDispComienzo { get; set; }
        public DateTime? FechaDispFinal { get; set; }

        public int? GeneradoPorComercioID { get; set; }
        public virtual Comercio GeneradoPorComercio { get; set; }

        public int? GeneradoPorDepartamentoID { get; set; }
        public virtual Departamento GeneradoPorDepartamento { get; set; }

        public int? MedioDePagoID { get; set; }
        public virtual MedioDePago MedioDePago { get; set; }

        public int? ConceptoFondosID { get; set; }
        public virtual ConceptoFondos ConceptoFondos { get; set; }

        public int? ComercioID { get; set; }
        public virtual Comercio Comercio { get; set; }


        public int? EmpresaID { get; set; }
        public virtual Empresa Empresa { get; set; }

        public int? TransferenciasDepositosEmpId { get; set; }
        public long? TransferenciasDepositosID { get; set; }
        public virtual TransferenciasDepositos TransferenciasDepositos { get; set; } //empId e ID


        public int? ClaseCuentaBancariaID { get; set; }
        public int? CuentaBancariaID { get; set; }
        public string NumChequera { get; set; }
        public string NumCheque { get; set; }
        public virtual Cheque Cheque { get; set; } //chequera, cb,ccb, cheque

        public int? EstadoID { get; set; }
        public virtual Estado Estado { get; set; }

        public int? MonedaID { get; set; }
        public virtual Moneda Moneda { get; set; }


        public int? OrdenDePago { get; set; }
        //public virtual OrdenDePago OrdenDePago { get; set; }


        public int? TipoSolicitudID { get; set; }
        public virtual TipoSolicitud TipoSolicitud { get; set; }

        public DateTime? FechaConfComercio { get; set; }
        public int? EmpleadoConfComercio { get; set; }
        public string notas { get; set; }

        public int? EmpleadoSolicitanteID { get; set; }
        public virtual Empleado EmpleadoSolicitante { get; set; } // Busqueda por empId y empleado

        public int? EmpleadoRealizadorID { get; set; }
        public virtual Empleado EmpleadoRealizador { get; set; } // Busqueda por empId y empleado


        //public int? ConceptoGastosProveedorID { get; set; }
        //public int? ConceptoGastosID { get; set; }
        //public int? ProveedorSucursalID { get; set; }
        //public int? ProveedorID { get; set; }
        public virtual List<SolicitudFondoConceptoGastosProveedorRestModel> SolicitudFondoConceptoGastosProveedor { get; set; } // Busqueda por empId y empleado


        public int? CajaID { get; set; }
        public int? AvisoDePagoID { get; set; }
        
    }
}
