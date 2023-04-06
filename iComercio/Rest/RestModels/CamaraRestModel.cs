using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iComercio.Rest.RestModels
{
    public class CamaraRestModel
    {
        public List<string> Entidades { get; set; }

        public CamaraRestModel()
        {

        }

        public CamaraRestModel(List<string> Entidades)
        {
            this.Entidades = Entidades;
        }
    }
}
