using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace iComercio.Models
{
    public class TipoImagen
    {
        public int TipoImagenID { get; set; }
        public string Nombre { get; set; }
        public string Sufijo { get; set; }
        public int Orden { get; set; }
    }
}
