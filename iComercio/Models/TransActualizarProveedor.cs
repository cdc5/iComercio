using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iComercio.Models
{
    public class TransActualizarProveedor:Operacion
    {
        public TransActualizarProveedor(){}

        public TransActualizarProveedor(int OperacionID, string Nombre, string Descripcion) : base(OperacionID, Nombre, Descripcion) { }

        public async override Task<bool> Enviar(BusinessLayer bl, Transmision tran)
        {
            Proveedor prov = bl.Get<Proveedor>(p => p.ProveedorID == System.Convert.ToInt32(tran.EntidadID)).FirstOrDefault();
            if (prov != null)
            {
                var prove = await bl.TransmitirActualizarProveedor(prov,bl.pGlob.Comercio);
                if (prove.ProveedorID != null)
                { 
                    bl.Actualizar<Proveedor>(prov);
                    return true;
                }
            }
            return false;
        }

     
    }
}
