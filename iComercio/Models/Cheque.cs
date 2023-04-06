using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iComercio.Models
{
    public class Cheque
    {
        public int? EmpresaID { get; set; }
       /* public virtual Empresa Empresa { get; set; }*/
        
        public int? CuentaBancariaID{ get; set; }
     /*   public virtual CuentaBancaria CuentaBancaria { get; set; }*/

        public string ChequeraID { get; set; }
        public virtual Chequera Chequera { get; set; }
        
        public string ChequeID { get; set; }
        
        public decimal? Monto { get; set; }

        public int? TipoChequeID { get; set; }
        public virtual TipoCheque TipoCheque { get; set; }
        
        public int? EstadoID { get; set; }
        public Estado Estado { get; set; }


        public string sCheque
        {
            get
            {
                if (Chequera != null)
                    return String.Format("{0}-{1}", Chequera.ToString(), ChequeID);
                return ChequeID;
            }
            set { ;}
        }


        public override string ToString()
        {
            return sCheque;
        }
    }
}
