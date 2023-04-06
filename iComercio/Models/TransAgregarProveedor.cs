using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iComercio.Models
{
    public class TransAgregarProveedor:Operacion
    {

        public TransAgregarProveedor(){}
        
        public TransAgregarProveedor(int OperacionID, string Nombre, string Descripcion) :base(OperacionID, Nombre, Descripcion){}

        public async override Task<bool> Enviar(BusinessLayer bl, Transmision tran)
        {
            Proveedor prov = bl.Get<Proveedor>(tran.EmpresaID,p => p.ProveedorID == System.Convert.ToInt32(tran.EntidadID)).FirstOrDefault();
            if (prov != null)
            {
                var prove = await bl.TransmitirAgregarProveedor(prov,bl.pGlob.Comercio);
                if (prove.ProveedorID != null)
                { 
                    prov.ProveedorIDRemoto = prove.ProveedorIDRemoto;
                    bl.Actualizar<Proveedor>(prov);
                    return true;
                }
            }
            return false;
        }

  

    }
}
