using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iComercio.Models
{
    public class EstadoTransmision
    {
        public int EstadoTransmisionID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

       
        public EstadoTransmision()
        {
            
        }

        public EstadoTransmision(int EstadoTransmisionID,string Nombre, string Descripcion)
        {
            this.EstadoTransmisionID = EstadoTransmisionID;
            this.Nombre = Nombre;
            this.Descripcion = Descripcion;
        }
    }
}
