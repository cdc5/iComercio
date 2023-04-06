using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iComercio.Models
{
    public class SucursalBanco
    {

        public int? SucursalBancoID { get; set; }
        public int? BancoID { get; set; }
        public virtual Banco Banco { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Domicilio { get; set; }
        public string Numsuc { get; set; }
        public int? LocalidadID { get; set; }
        public virtual Localidad Localidad { get; set; }
        public int? ProvinciaID { get; set; }
        public virtual Provincia Provincia { get; set; }
        public int? PaisId { get; set; }
        public virtual Pais Pais { get; set; }

        public string sBancoSucursal 
        {
            get
            {
                if (Banco != null)
                    return String.Format("{0}-{1}", Banco.ToString(), Nombre);
                return Nombre;
            }
            set { ;}
        }
        
        public override string ToString()
        {
            return sBancoSucursal;   
        }
    }
}
