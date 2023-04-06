using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iComercio.Models;

namespace iComercio.ViewModels
{
    class NuevaSolicitudFondoViewModel
    {
        public decimal? importe { get; set; }
        public DateTime? FechaPago { get; set; }
        public int? TipoSolicitudID { get; set; }
        public virtual TipoSolicitud TipoSolicitud { get; set; }
        public int? ConceptoFondosID { get; set; }
        public virtual ConceptoFondos ConceptoFondos { get; set; }
    }
}
