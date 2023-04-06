using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iComercio.Models;

namespace iComercio.ViewModels
{
    public class CreditoCobranzaViewModel
    {
        public Credito Credito { get; set; }
        public List<Cobranza> Cobranzas {get;set;}
    }
}
