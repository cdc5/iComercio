using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iComercio.Models
{
    public class CuentaCorrienteSaldos
    {
        public DateTime Fecha { get; set; }
        public decimal SumaAviso { get; set; }
        public decimal SumaAvisoBajas { get; set; }
        public decimal SumaCobranzas { get; set; }
        public decimal SumaNotasCD { get; set; }
        public decimal SumaDepositosFinan { get; set; }
        public decimal SumaDepositosComer { get; set; }
        public decimal SumaCompensaciones { get; set; }
        public decimal SumaRecibosProvisoriosFinan { get; set; }
        public decimal SumaRecibosProvisoriosComer { get; set; }
        public decimal SaldoAvisos { get; set; }
        public decimal SaldoCobranzas { get; set; }
        public decimal Saldo { get; set; }
        
    }
}
