using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iComercio.Models
{
    public class Ingreso : ClaseMovimiento
    {
        public override int Modificador { get { return 1; } set { } }

        public Ingreso()
            : base()
        {

        }


        public Ingreso(int ClaseMovimientoID, string Nombre, string Descripcion)
            : base(ClaseMovimientoID, Nombre, Descripcion)
        {
            
        }
    }
}
