using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iComercio.Auxiliar;

namespace iComercio.Models
{
    public class CuentaBancaria
    {
        public int? EmpresaID { get; set; }
        public virtual Empresa Empresa { get; set; }

        public int? CuentaBancariaID { get; set; }
        public string NumCuenta { get; set; }
        public string Cbu { get; set; }
        public string Descripcion { get; set; }
        public string Notas { get; set; }
        public DateTime? FechaAlta { get; set; }

        public virtual ObservableListSource<Chequera> Chequeras { get; set; } //banId,bansucId

        public int? ComercioID { get; set; }
        public virtual Comercio comercio { get; set; } //banId,bansucId

        public int? ClaseCuentaBancariaID { get; set; }
        public virtual ClaseCuentaBancaria ClaseCuentaBancaria { get; set; }

        public int? TipoCuentaBancariaID { get; set; }
        public virtual TipoCuentaBancaria TipoCuentasBancarias { get; set; } 
        
        public int? SucursalBancoID { get; set; }
        public virtual SucursalBanco SucursalBanco { get; set; } //banId,bansucId
                    
        public int? BancoID { get; set; }
        public virtual Banco Banco { get; set; }
        
        public int? MonedaID { get; set; }
        public virtual Moneda moneda { get; set; } //banId,bansucId

        public bool EmiteCheque { get; set; }
                
        public string CuentaContable { get; set; }

        public int? EstadoID { get; set; }
        public virtual Estado Estado { get; set; }

        public int? PersonaID { get; set; }
        public virtual Persona Persona { get; set; }
                
        public int? prov_id { get; set; }
        public virtual Proveedor Proveedor { get; set; }
        public int? provsuc_id { get; set; }
        public virtual ProveedorSucursal ProveedorSucursal { get; set; }

        public bool DebitoDirecto { get; set; }

        public int orden { get; set; }

        public string sCuentaBancaria 
        {
            get
            {
                if (SucursalBanco != null)
                    return String.Format("{0}-{1}", NumCuenta, SucursalBanco.ToString());
                else if (Banco != null)
                    return String.Format("{0}-{1}", NumCuenta, Banco.ToString());
                else
                    return String.Format("{0}", NumCuenta);
            }
            set { ;}
        }

        public override string ToString()
        {
            return sCuentaBancaria;
        }
        

    }
}
