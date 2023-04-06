using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iComercio.Models;
using iComercio.DAL;
using iComercio.Auxiliar;

namespace iComercio.Rest.RestModels
{
    public class CreditoAvalRestModel
    {
        public int CreditoAvalID { get; set; }
        public int CreditoID { get; set; }
        public int ComercioID { get; set; }
        public int EmpresaID { get; set; }
        public int TipoAvalID { get; set; }
        public int? UsuarioID { get; set; } //usuAval
        
    }
}
