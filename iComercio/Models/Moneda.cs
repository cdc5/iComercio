using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iComercio.Models
{
    public class Moneda
    {
        public int? MonedaID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int? PaisId { get; set; }
        public virtual Pais Pais { get; set; }
        public string mon_simbolo { get; set; }
    }
}
