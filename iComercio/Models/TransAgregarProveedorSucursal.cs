using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iComercio.Models
{
    public class TransAgregarProveedorSucursal : Operacion
    {
        public TransAgregarProveedorSucursal() { }

        public TransAgregarProveedorSucursal(int OperacionID, string Nombre, string Descripcion) : base(OperacionID, Nombre, Descripcion) { }

        public async override Task<bool> Enviar(BusinessLayer bl, Transmision tran)
        {
            ProveedorSucursal provSuc = bl.Get<ProveedorSucursal>(tran.EmpresaID,p => p.ProveedorSucursalID == System.Convert.ToInt32(tran.EntidadID) && p.ProveedorID == System.Convert.ToInt32(tran.EntidadID2)).FirstOrDefault();
            if (provSuc.Proveedor.ProveedorIDRemoto != null)
            {
            if (provSuc != null)
                {
                    var prove = await bl.TransmitirAgregarSucursalProveedor(provSuc, bl.pGlob.Comercio);
                    if (prove.ProveedorSucursalID != null)
                    {
                        provSuc.ProveedorSucursalIDRemoto = prove.ProveedorSucursalIDRemoto;
                        bl.Actualizar<ProveedorSucursal>(provSuc);
                        return true;
                    }
                }
            }
            return false;
        }

      
    }
}
