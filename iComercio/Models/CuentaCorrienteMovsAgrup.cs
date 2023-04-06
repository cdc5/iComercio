using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iComercio.Models
{
    public class CuentaCorrienteMovsAgrup
    {
        public int TipoMovimientoID {get;set;}
        public string Nombre {get;set;}
        public DateTime? Fecha {get;set;}
        public decimal? SaldoMov {get;set;}

        public CuentaCorrienteMovsAgrup()
        {
          
        }

        public CuentaCorrienteMovsAgrup(int TipoMovimientoID, string Nombre, DateTime Fecha, decimal SaldoMov)
        {
            this.TipoMovimientoID = TipoMovimientoID;
            this.Nombre = Nombre;
            this.Fecha = Fecha;
            this.SaldoMov = SaldoMov;
        }
    }
}
