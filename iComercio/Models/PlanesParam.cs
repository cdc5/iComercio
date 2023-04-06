using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iComercio.Models
{
    public class PlanesParam
    {
        // va nro de comercio????
        // va nro de empresa????
        public int PlanesParamId { get; set; }
        public int Desde { get; set; }
        public int Hasta { get; set; }
        public int Valor { get; set; }
        public string Param1 { get; set; }  //Param
        public string Param2 { get; set; }  //Que
        public int Orden { get; set; }
    }
}
