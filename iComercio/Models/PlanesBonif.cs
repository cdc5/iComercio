using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iComercio.Models
{
    public class PlanesBonif
    {
        public string PlanesBonifID { get; set; }                   // pasar a int
        public string PlanesTipoID { get; set; }                     // cambiar PlanesTipoID
        public int EmpresaID { get; set; }
        public virtual Empresa Empresa { get; set; }
        public int ComercioID { get; set; }
        public virtual Comercio Comercio { get; set; }
        // va nro de comercio????
        // va nro de empresa????

        public string TipoBoni { get; set; }                      // C: cuota  V:Valornominal
        public decimal PorBoni { get; set; }                         // porcentaje de descuento
        public int Cuotas_D { get; set; }                           // Filtro de cuotas
        public int Cuotas_H { get; set; }
        public string TipoCuota { get; set; }                       // NO HACE FALTA YA ESTA EN PLANESTIPO  SACAR
        public int nMora { get; set; }                               // dias de mora para anular la boni
        public DateTime FechaAlta { get; set; }
        public DateTime FechaVenci { get; set; }
        public int UsuarioID { get; set; }
        public virtual Usuario Usuario { get; set; } //Usuario
        public string UsuarioPC { get; set; }  
    }
}
