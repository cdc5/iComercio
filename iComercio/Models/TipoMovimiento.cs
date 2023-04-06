using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iComercio.Models
{
    public class TipoMovimiento
    {
        public int TipoMovimientoID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Cod { get; set; }
        public int ClaseMovimientoID { get; set; }
        public virtual ClaseMovimiento ClaseMovimiento { get; set; }

        public string CodInter { get; set; }    
        public int TipoMovIDAnula { get; set; }

        public TipoMovimiento() { }

        public TipoMovimiento(int TipoMovimientoID, string Nombre, string Descripcion, string Cod, int ClaseMovimientoID, ClaseMovimiento ClaseMovimiento, string CodInter = "", int TipoMovIDAnula = 0)
        {
            this.TipoMovimientoID = TipoMovimientoID;
            this.Nombre = Nombre;
            this.Descripcion = Descripcion;
            this.Cod = Cod;
            this.ClaseMovimientoID = ClaseMovimientoID;
            this.ClaseMovimiento = ClaseMovimiento;
            this.CodInter = CodInter;
            this.TipoMovIDAnula = TipoMovIDAnula;
        }



    }
}
