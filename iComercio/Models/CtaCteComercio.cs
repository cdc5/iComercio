using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iComercio.Models
{
    public class CtaCteComercio
    {
        public int Ano { get; set; }
        public int Mes { get; set; }
        public int dia { get; set; }

        public int tpm_id { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public decimal SaldoMovFin { get; set; }
        public decimal SaldoMovCom { get; set; }
    }
}
