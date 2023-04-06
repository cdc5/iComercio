using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iComercio.Rest.RestModels
{
    public class TipoEstadoRestModel
    {
        public int? TipoEstadoID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
