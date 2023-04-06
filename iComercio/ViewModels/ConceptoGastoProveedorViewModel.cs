using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iComercio.Models;

namespace iComercio.ViewModels
{
    public class ConceptoGastoProveedorViewModel
    {
        public ConceptoGastosProveedor Cgp {get;set;}
        public string Nombre {get;set;}
        public int? Periodicidad {get;set;}
        public string Estado { get; set; }                                                                                    
    }
}
