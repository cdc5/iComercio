using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iComercio.ViewModels;
using iComercio.Auxiliar;
using Credin;

namespace iComercio.Models
{
    public class AvisoDePago
    {
        public int EmpresaID { get; set; }
        public virtual Empresa Empresa { get; set; }
        public int ComercioID { get; set; }
        public virtual Comercio Comercio { get; set; }
        public int  AvisoDePagoID { get; set; }
        public DateTime FechaPagoAviso { get; set; }
        public decimal Importe { get; set; }
        public decimal Retencion { get; set; }
        public decimal Comision { get; set; }
        public decimal Total { get; set; }
        public decimal Pagado { get; set; }
        public DateTime FechaPagado { get; set; }
        public int CantSolicitudes { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public string Notas { get; set; }

        public virtual ObservableListSource<Credito> Creditos { get; set; }

        public AvisoDePago()
        {

        }

       

        


    }
}
