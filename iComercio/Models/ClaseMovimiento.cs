using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iComercio.Models
{
    public abstract class ClaseMovimiento
    {
        public int ClaseMovimientoID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public abstract int Modificador { get; set; }

        public ClaseMovimiento() {}

        public ClaseMovimiento(int ClaseMovimientoID, string Nombre, string Descripcion) 
        {
            this.ClaseMovimientoID = ClaseMovimientoID;
            this.Nombre = Nombre;
            this.Descripcion = Descripcion;
        }

        
        

    }
}
