using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iComercio.Models
{
    public class CuentaCorrienteDetalle
    {
        public List<CuentaCorrienteMovs> MovimientosDebe { get; set; }
        public List<CuentaCorrienteMovs> MovimientosHaber { get; set; }

        public CuentaCorrienteDetalle()
        {
            MovimientosDebe = new List<CuentaCorrienteMovs>();
            MovimientosHaber = new List<CuentaCorrienteMovs>();
        }
    }
}
