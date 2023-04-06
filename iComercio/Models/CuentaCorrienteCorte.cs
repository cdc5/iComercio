using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iComercio.Models
{
    public class CuentaCorrienteCorte
    {
        public int EmpresaID { get; set; }
        public int ComercioID { get; set; }
        public int CuentaCorrienteCorteID { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Saldo { get; set; }
    }
}
