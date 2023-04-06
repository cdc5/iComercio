using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iComercio.Auxiliar;

namespace iComercio.Models
{
    public class Pais
    {
        public int? PaisID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int? CodIsoNumerico { get; set; }
        public string CodIso2 { get; set; }
        public string CodIso3 { get; set; }
        public string DirImaBandera { get; set; }
        public string CodTel { get; set; }
        public decimal? X { get; set; }
        public decimal? Y { get; set; }
        public virtual ObservableListSource<Provincia> Provincias { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
