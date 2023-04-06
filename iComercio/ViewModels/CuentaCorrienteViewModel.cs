using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iComercio.ViewModels
{
    public class CuentaCorrienteViewModel
    {
        public DateTime fecha { get; set; }
        public int MovimientoID { get; set; }
        public string Movimiento { get; set; }
        public decimal? Debe { get; set; }
        public decimal? Haber { get; set; }
        public decimal? Saldo { get; set; }
        public int Orden { get; set; } 
    }
}
