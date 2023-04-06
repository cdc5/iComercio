using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iComercio.Models
{
    public class InfoTransmision
    {
        public Comercio Comercio { get; set; }
        public string[] Claves { get; set; }
        public Operacion Operacion { get; set; }
        public EstadoTransmision EstadoTransmision { get; set; }
        public DateTime Fecha { get; set; }
        public String RutaApi { get; set; }

        public InfoTransmision()
        {

        }

        public InfoTransmision(params string[] Claves)
        {
            this.Claves = Claves;
        }

        public InfoTransmision(Comercio com,Operacion ope,EstadoTransmision est,string RutaApi,params string[] Claves)
        {
            this.Comercio = com;
            this.Operacion = ope;
            this.EstadoTransmision = est;
            this.RutaApi = RutaApi;
            this.Claves = Claves;
        }

      
    }
}
