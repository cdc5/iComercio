using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iComercio.Models
{
    public class PlanesDetalle
    {
        public int PlanesDetalleID { get; set; }

        public string PlanesTipoID { get; set; }                     // cambiar PlanesTipoID

        public int EmpresaID { get; set; }
        public virtual Empresa Empresa { get; set; }
        public int ComercioID { get; set; }
        public virtual Comercio Comercio { get; set; }

        public string TipoCuota { get; set; }                       // NO HACE FALTA ya esta en planestipo
        public int Cuotas_D { get; set; }
        public int Cuotas_H { get; set; }

        public bool SiCreditos { get; set; }                        // si filtra por cantidad de créditos
        public int nCreditos_D { get; set; }
        public int nCreditos_H { get; set; }

        public bool SiCancel { get; set; }                          // si filtra por creditos cancelados
        public int nCancel_D { get; set; }
        public int nCancel_H { get; set; }                  // cambiar la A por a

        public bool SiMora { get; set; }                            // si filtra por mora
        public int nMora_D { get; set; }
        public int nMora_H { get; set; }

        public bool SiValor { get; set; }                           // si filtra por valor nominal
        public int nValor_D { get; set; }
        public int nValor_H { get; set; }

        public decimal Monto_max { get; set; }                       // si filtra por valor nominal 
        // 0 para no filtrar

        public DateTime FechaAlta { get; set; }
        public DateTime FechaVenci { get; set; }
        public int UsuarioID { get; set; }
        public virtual Usuario Usuario { get; set; } //Usuario
        public string UsuarioPC { get; set; }  
    }
}
