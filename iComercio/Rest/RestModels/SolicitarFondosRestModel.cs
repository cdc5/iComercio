using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iComercio.Models;


namespace iComercio.Rest.RestModels
{
    public class SolicitarFondosRestModel
    {
        public InfoObjetivos infoObjetivos { get; set; }
        public List<SolicitudFondoRestModel> SolicitudesDeFondos { get; set; }
    }
}
