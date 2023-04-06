using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iComercio.ViewModels
{
    public class Respuesta 
    {
        public String  Id { get; set; }
        public Consulta Consulta { get; set; }
        public ParteXML ParteXML { get; set; }
        public ParteHTML ParteHTML { get; set; }
       }
    public class Consulta
    {

        public string FEC { get; set; }
        public string ServidorWeb { get; set; }
        public string Tipo { get; set; }
        public string CodCliente { get; set; }
        public string NroConsulta { get; set; }
        public string ConsCDA { get; set; }
        public string ConsSoloDoc { get; set; }
        public string ConsDatosAdicionales { get; set; }
        public ConsultaXML ConsultaXML { get; set; }
        public ConsultaHTML ConsultaHTML { get; set; }
        public Resultado Resultado { get; set; }
        
    }

    public class ConsultaXML
    {
        public string Doc { get; set; }
        public RZ RZ { get; set; }
        public string Filtro { get; set; }
        public string Setup { get; set; }
        public string MaxResp { get; set; }
     }

    public class RZ
    {
        public string Value { get; set; }
    }


    public class ConsultaHTML
    {
        public string Doc { get; set; }
        public string RZ { get; set; }
        public string Filtro { get; set; }
        public string MaxResp { get; set; }
    }

    public class Resultado
    {
        public string EstadoOk { get; set; }
        public string IdNovedad { get; set; }
        public string Novedad { get; set; }
    }

    public class ParteXML 
    {
        public string Value { get; set; }
    }

    public class ParteHTML 
    {
        public string Value { get; set; }
    }




}
