using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iComercio.Models
{
    public class Items
    {
        public int ItemId { get; set; }
        public Factura Factura
        {
            //get {return Factura.ObtenerFactura(this);}
            get;
            set;
        }

        public override string ToString()
        {
          return Factura.FacturaID.ToString() + ItemId.ToString();
        }

        public static List<Items> ObtenerItems(Factura fact)
        {
            return fact.items;
        }

    }
}
