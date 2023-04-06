using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iComercio.Models
{
    public class CuentaCorrienteComun
    {
        public DateTime Fecha { get; set; }
        public decimal Debe { get; set; }
        public decimal Haber { get; set; }
        public decimal SaldoDiario { get; set; }
        public decimal Saldo { get; set; }
        public List<String> MovimientosDebe { get; set; }
        public List<String> MovimientosHaber { get; set; }
        public bool provisorios { get; set; }
        
        public CuentaCorrienteComun()
        {
            MovimientosDebe = new List<string>();
            MovimientosHaber = new List<string>();
        }
    }
}
