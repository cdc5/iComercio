using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iComercio.Models
{
    public  class CuentaCorrienteDiaria
    {
        //public DateTime Fecha { get; set; }
        //public decimal Debe { get; set; }
        //public decimal Haber { get; set; }
        //public decimal SaldoDiario { get; set; }
        //public decimal Saldo { get; set; }
        public decimal Arrastre { get; set; }
        public List<CuentaCorrienteDiariaMovs> Movimientos { get; set; }
        //public List<CuentaCorrienteMovsAgrup> MovimientosDebe { get; set; }
        //public List<CuentaCorrienteMovsAgrup> MovimientosHaber { get; set; }
        //public bool provisorios { get; set; }
        
        public CuentaCorrienteDiaria()
        {
            Movimientos = new List<CuentaCorrienteDiariaMovs>();
        }
    }
}
