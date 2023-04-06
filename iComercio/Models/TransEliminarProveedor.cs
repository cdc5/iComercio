using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iComercio.Models
{
    public class TransEliminarProveedor : Operacion
    {
        public TransEliminarProveedor() { }

        public TransEliminarProveedor(int OperacionID, string Nombre, string Descripcion) : base(OperacionID, Nombre, Descripcion) { }

        public async override Task<bool> Enviar(BusinessLayer bl, Transmision tran)
        {
            Proveedor prov = bl.Get<Proveedor>(tran.EmpresaID,p => p.ProveedorID == System.Convert.ToInt32(tran.EntidadID)).FirstOrDefault();
            if (prov != null)
            {
                var prove = await bl.TransmitirEliminarProveedor(prov, bl.pGlob.Comercio);
                if (prove != null)
                {
                    bl.Borrar<Proveedor>(tran.EmpresaID,prov);
                    return true;
                }
            }
            return false;
        }

 
    }
    
    
}
