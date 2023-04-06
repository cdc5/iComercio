using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iComercio.Models
{
    public class CuentaCorrienteDiariaMovs
    {
        public string Nombre { get; set; }
        public List<CuentaCorrienteMovsAgrup> Movimientos { get; set; }
    }
}
