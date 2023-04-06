using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iComercio.Rest.RestModels
{
    public class CuentaCorrienteRestModel
    {
        public long? CuentaCorrienteID { get; set; }
        public int? EmpresaID { get; set; }
        public int? ComercioID { get; set; }
        public long? IDRemoto { get; set; }
        public int? TipoMovimientoID { get; set; }
        public DateTime Fecha { get; set; }
        public long? SolicitudFondoID { get; set; }
        public int? CreditoID { get; set; }
        public int? CuotaID { get; set; }
        public int? CobranzaID { get; set; }
        public int? NotaCDID { get; set; }
        public long? TransferenciaDepositoID { get; set; }
        public int? ReciboID { get; set; }
        public decimal Importe { get; set; }
        public int? GestionID { get; set; }
        public DateTime FechaAviso { get; set; }
        public int? CreditoNro { get; set; }
        public int? GastoID { get; set; }
        public int? PagoID { get; set; }
        
    }
}
