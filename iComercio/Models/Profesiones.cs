using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iComercio.DAL;
using iComercio.Auxiliar;

namespace iComercio.Models
{
    public class Profesion
    {
        public string ProfesionID { get; set; }
        public string Nombre { get; set; }
        public string ProfesionPadreID { get; set; }
        public virtual Profesion ProfesionPadre { get; set; }

        public virtual ObservableListSource<Profesion> SubProfesiones { get; set; }

        public override string ToString()
        {
            return ProfesionID + "-" + Nombre;
        }


    }
}
