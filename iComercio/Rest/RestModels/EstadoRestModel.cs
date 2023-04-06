using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iComercio.Models;

namespace iComercio.Rest.RestModels
{
    public class EstadoRestModel
    {
        public int? EstadoID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public int? TipoEstadoID { get; set; }
        public virtual TipoEstadoRestModel TipoEstado { get; set; }

        public string est_color { get; set; }

    }
}
