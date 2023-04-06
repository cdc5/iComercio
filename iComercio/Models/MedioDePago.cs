using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iComercio.Models
{
    public class MedioDePago
    {
        public int? MedioDePagoID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
                
        public static MedioDePago efectivo { get; set; }
        public static MedioDePago cheque { get; set; }
        public static MedioDePago transferenciaBancaria { get; set; }

        public const string sEfectivo = "Efectivo";
        public const string sCheque = "Cheque";
        public const string sTransferenciaBancaria = "Transferencia Bancaria";

        public override string ToString()
        {
            return Nombre;
        }
    }
}
