using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iComercio.Rest.RestModels;

namespace iComercio.Models
{
    public class InfoCliente
    {
        public Cliente Cliente { get; set; }
        public Camara Camara { get; set; }
        public List<CreditoRestModel> CreditosMorosos { get; set; }
    }
}
