using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iComercio.Models
{
    public class SolicitarFondos
    {
        public InfoObjetivos infoObjetivos { get; set; }
        public List<SolicitudFondo> SolicitudesDeFondos { get; set; }
    }
}
