using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iComercio.Models
{
    public class TipoAnulacion
    {
        public string TipoAnulacionID { get; set; }
        // public string Nombre { get; set; } 
        public string Descripcion { get; set; }
        public string QueAnula { get; set; }     // A=ALTA, C=cOBRANZAS, ETC
    }
}
