using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iComercio.Models
{
    public class CuentaBancariaCliente
    {
        public int Documento { get; set; }
        public Cliente Cliente { get; set; }
        public string TipoDocumentoID { get; set; }
        public virtual TipoDocumento TipoDocumento { get; set; }
        public string NumCuentaBancaria { get; set; }
        public string CBU { get; set; }
        public string Alias { get; set; }
        public string Descripcion { get; set; }
        public string Notas { get; set; }
        public DateTime? FechaAlta { get; set; }
        public int? SucursalBancoID { get; set; }
        public virtual SucursalBanco SucursalBanco { get; set; } 
        public int? BancoID { get; set; }
        public virtual Banco Banco { get; set; }
        public int? MonedaID { get; set; }
        public virtual Moneda moneda { get; set; } 
        public int? EstadoID { get; set; }
        public virtual Estado Estado { get; set; }

        public string sCuentaBancaria
        {
            get
            {
                if (SucursalBanco != null)
                    return String.Format("{0}-{1}-{2}",Documento , NumCuentaBancaria, SucursalBanco.ToString());
                else if (Banco != null)
                    return String.Format("{0}-{1}-{2}",Documento, NumCuentaBancaria, Banco.ToString());
                else
                    return String.Format("{0}-{1}",Documento, NumCuentaBancaria);
            }
            set { ;}
        }

        public override string ToString()
        {
            return sCuentaBancaria;
        }
        
    }
}
