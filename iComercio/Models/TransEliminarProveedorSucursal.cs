using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iComercio.Models
{
    public class TransEliminarProveedorSucursal : Operacion
    {
        public TransEliminarProveedorSucursal() { }

        public TransEliminarProveedorSucursal(int OperacionID, string Nombre, string Descripcion) : base(OperacionID, Nombre, Descripcion) { }

        public async override Task<bool> Enviar(BusinessLayer bl, Transmision tran)
        {
            ProveedorSucursal provSuc = bl.Get<ProveedorSucursal>(tran.EmpresaID,p => p.ProveedorSucursalID == System.Convert.ToInt32(tran.EntidadID) && p.ProveedorID == System.Convert.ToInt32(tran.EntidadID2)).FirstOrDefault();
            if (provSuc != null)
            {
                var prove = await bl.TransmitirEliminarProveedorSucursal(provSuc, bl.pGlob.Comercio);
                if (prove != null)
                {
                    bl.Borrar<ProveedorSucursal>(tran.EmpresaID,provSuc);
                    return true;
                }
            }
            return false;
        }

     
    }
    
    
}
