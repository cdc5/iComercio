using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iComercio.Models
{
    public class MetodoFuncionamiento
    {
        public string MetodoFuncionamientoID { get; set; }
        public string Nombre { get; set; }

        public MetodoFuncionamiento()
        {

        }

        public MetodoFuncionamiento(String MetodoFuncionamientoID, string Nombre)
        {
            this.MetodoFuncionamientoID = MetodoFuncionamientoID;
            this.Nombre = Nombre;
        }
    }
}
