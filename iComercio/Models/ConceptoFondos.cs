using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iComercio.Auxiliar;

namespace iComercio.Models
{
    public class ConceptoFondos
    {
        public int ConceptoFondosID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int? MedioDePagoID { get; set; }
        public MedioDePago MedioDePago { get; set; }

        public ObservableListSource<Departamento> RequiereValidacionDe { get; set; }
               

        public static ConceptoFondos retCob { get; set; }
        public static ConceptoFondos extBan { get; set; }
        public static ConceptoFondos retFonExtBan { get; set; }
        public static ConceptoFondos retValoresARendir { get; set; }

        const string sRetCob = "Retención de Cobranzas";
        const string sextBan = "Extración bancaria";
        const string sretFonExtBan = "Retención de fondos/Extración bancaria";
        const string sretValARendir = "Retención de Valores a Rendir";

        public override string ToString()
        {
            return Nombre;
        }
    }
}
