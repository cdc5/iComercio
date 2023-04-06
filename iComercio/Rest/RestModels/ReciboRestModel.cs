using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iComercio.Rest.RestModels
{
    public class ReciboRestModel
    {
        public int ReciboID { get; set; }
        public int? ReciboIDRemoto { get; set; }
        public DateTime? Fecha { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public int ComercioID { get; set; }
        public int EmpresaID { get; set; }
        public decimal Importe { get; set; }
        public int Comprobante { get; set; }
        public string Notas { get; set; }
        public int TipoMovimientoID { get; set; }
        public int? TransferenciasDepositosEmpId { get; set; }
        public long? TransferenciasDepositosID { get; set; }
        public long? SolicitudFondoID { get; set; }
        public decimal? Imputado { get; set; }
        public bool? Migrado { get; set; }
        public bool? Conformado { get; set; }
        public string Host { get; set; }
        public int UsuarioID { get; set; }
        public int EstadoID { get; set; }
        public int? ComercioAdheridoComercioID { get; set; }
        public int? ComercioAdheridoEmpresaID { get; set; }
        public int? ReciboIDAnula { get; set; }  
        public int? CobranzaID { get; set; }
        public int? CreditoID { get; set; }
        public int? CuotaID { get; set; }

        /* Para enviar el usuario por nombre de usuario, y no ID que son distintos en cliente y servidor*/
        public string NombreUsuario { get; set; }
    }
}
