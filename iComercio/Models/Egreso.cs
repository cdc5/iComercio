using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iComercio.Models
{
    class Egreso : ClaseMovimiento
    {
         public override int Modificador { get { return -1; } set { } }

         public Egreso()
             : base()
         {

         }

        public Egreso(int ClaseMovimientoID, string Nombre, string Descripcion)
            : base(ClaseMovimientoID, Nombre, Descripcion)
        {
            
        }

    }
}
