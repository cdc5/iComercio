using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iComercio.Models
{
    public class Estado
    {
        public int EstadoID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public int? TipoEstadoID { get; set; }
        public virtual TipoEstado TipoEstado { get; set; }
        
        public string est_color { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
