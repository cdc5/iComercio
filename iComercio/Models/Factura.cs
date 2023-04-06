using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iComercio.Models
{
    public class Factura
    {
        public int FacturaID { get; set; }
        public List<Items>  items 
        {
            //get { return Items.ObtenerItems(this); }
            get  ; 
            set  ;
            
        }
        public static Factura ObtenerFactura(Items item)
        {
            return item.Factura;
        }
    }
}
