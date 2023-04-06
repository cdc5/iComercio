using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iComercio.Models;
namespace iComercio.Rest.RestModels
{
    public class InfoClienteRestModel
    {
        public ClienteRestModel Cliente { get; set; }
        public CamaraRestModel Camara { get; set; }
        public List<CreditoRestModel> CreditosMorosos { get; set; }
    }
}
