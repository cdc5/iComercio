using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iComercio.Models
{
    public class ClaseDato
    {
        //Esta clase es para clases  de telefono,domicilio,mail , de cliente o empresa en principio
        public int ClaseDatoID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
