using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iComercio.Auxiliar;

namespace iComercio.Models
{
    public class Chequera
    {
        public int? EmpresaID { get; set; }
        public int? CuentaBancariaID { get; set; }
        public virtual CuentaBancaria CuentaBancaria { get; set; }
        
        public string ChequeraID { get; set; }

        public string NumTalonario { get; set; }
        public string NumDesde { get; set; }
        public string NumHasta { get; set; }
        public string NumProx { get; set; }
        public DateTime? FechaAlta { get; set; }

        public int? EstadoID { get; set; }
        public virtual Estado Estado { get; set; }

        public virtual ObservableListSource<Cheque> Cheques { get; set; }

        public string sChequera 
        {
            get
            {
                return ChequeraID;
            }
            set {;}            
        }

        public override string ToString()
        {
            return sChequera;
        }

    
    }
}
