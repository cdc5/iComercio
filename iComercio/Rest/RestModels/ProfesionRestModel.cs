using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iComercio.DAL;
using iComercio.Auxiliar;
using iComercio.Models;

namespace iComercio.Rest.RestModels
{
    public class ProfesionRestModel
    {
        public string ProfesionID { get; set; }
        public string Nombre { get; set; }
        public string ProfesionPadreID { get; set; }
        public virtual ProfesionRestModel ProfesionPadre { get; set; }

        public virtual List<ProfesionRestModel> SubProfesiones { get; set; }
    }
}
