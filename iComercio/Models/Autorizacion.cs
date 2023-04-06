using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iComercio.Models
{
    public class Autorizacion
    {
        public long? AutorizacionID { get; set; }
        public long? SolicitudFondoID { get; set; }
        public int? EstadoID { get; set; }
        public virtual Estado Estado { get; set; }
        public string Motivo { get; set; }
        public DateTime? Fecha { get; set; }
        public int? EmpresaID { get; set; }
        public virtual Empresa Empresa { get; set; }
        public int? PersonaID { get; set; }
        public virtual Persona Persona { get; set; }
        public int? ComercioID { get; set; }
        public virtual Comercio Comercio { get; set; }


        /* Esto siguiente tiene que ser temporal hasta que se registren las transferenciasDepositos, cuentas bancarias, cheques y demas
         * en el programa, aca en icomercio, por lo pronto se usa esto para transferir los datos de la autorizacion*/
        public string EmpresaNombre { get; set; }
        public string ConceptoFondosNombre { get; set; }
        public string TipoSolicitudNombre { get; set; }
        public string ComercioNombreNum { get; set; }
        public long OrdenDePagoID { get; set; }
        public DateTime SolicitudFondoFechaPago { get; set; }
        public string ChequeNumCheque { get; set; }
        public string CuentaBancaria { get; set; }
        public string CuentaContable { get; set; }
        public decimal Importe { get; set; }
        public string Observaciones { get; set; }
        public string NumCajaImpCont { get; set; }
       
    }
}
