using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iComercio.DAL;
using iComercio.Auxiliar;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace iComercio.Models
{
    public class CreditoAval
    {
        public int CreditoAvalID { get; set; }
        
        public int CreditoID { get; set; }
        public virtual Credito Credito { get; set; }
        public int ComercioID { get; set; }
        public virtual Comercio Comercio { get; set; }
        public int EmpresaID { get; set; }
        public virtual Empresa Empresa { get; set; }

        public int TipoAvalID { get; set; }
        public virtual TipoAval Tipoaval { get; set; }

        public int UsuarioID { get; set; } //usuAval
        public virtual Usuario Usuario { get; set; } //Usuario
    }
}
