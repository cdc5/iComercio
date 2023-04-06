using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iComercio.Models
{
    public class Localidad
    {

        public int? LocalidadID { get; set; }
        public int? ProvinciaID { get; set; }
        public virtual Provincia Provincia { get; set; }
        public int? PaisId { get; set; }
        public virtual Pais Pais { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string CodPostal { get; set; }
        public string CodTel { get; set; }
        public decimal? X { get; set; }
        public decimal? Y { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
