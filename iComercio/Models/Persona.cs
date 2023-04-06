using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iComercio.Models
{
    public class Persona
    {
        public int? PersonaID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int? Documento { get; set; }
        public string Domicilio { get; set; }
        public string Fotografia { get; set; }

        public int? LocalidadID { get; set; }
        public virtual Localidad Localidad { get; set; }

        public int? ProvinciaID { get; set; }
        public virtual Provincia Provincia { get; set; }

        public int? PaisID { get; set; }
        public virtual Pais Pais { get; set; }
                
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public string Mail1 { get; set; }
        public string Mail2 { get; set; }
        public string Cel { get; set; }
        public int? Edad { get; set; }
        public DateTime? FechaNacimiento { get; set; }

        public string TiposDocumentoID { get; set; }
        public virtual TipoDocumento TiposDocumento { get; set; }
        
    }
}
