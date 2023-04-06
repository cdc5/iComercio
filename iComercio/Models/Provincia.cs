using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iComercio.Auxiliar;

namespace iComercio.Models
{
    public class Provincia
    {
        public int? ProvinciaID { get; set; }
        public int? PaisId { get; set; }
        public virtual Pais Pais { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string CodIso { get; set; }
        public string DirImaEscudo { get; set; }
        public string CodTel { get; set; }
        public decimal? X { get; set; }
        public decimal? Y { get; set; }
        public virtual ObservableListSource<Localidad> Localidades { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
