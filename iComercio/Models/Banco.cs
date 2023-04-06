using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iComercio.Models
{
    public class Banco
    {
        public int? BancoID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public string sBanco 
        {
            get { return Nombre;}
            set { ;} 
        }
    
        public override string ToString()
        {
            return sBanco;
        }
    }

}
