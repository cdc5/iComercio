using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iComercio.Models
{
    class TransEliminarConceptoGastoProveedor:Operacion
    {
        public TransEliminarConceptoGastoProveedor() { }

        public TransEliminarConceptoGastoProveedor(int OperacionID, string Nombre, string Descripcion) : base(OperacionID, Nombre, Descripcion) { }

        public async override Task<bool> Enviar(BusinessLayer bl, Transmision tran)
        {
            ConceptoGastosProveedor cgp = bl.Get<ConceptoGastosProveedor>(tran.EmpresaID,c => c.ConceptoGastosProveedorID == System.Convert.ToInt32(tran.EntidadID)).FirstOrDefault();
            if (cgp != null)
            {
                var cgps = await bl.TransmitirEliminarConceptoGastoProveedor(cgp, bl.pGlob.Comercio);
                if (cgps != null)
                {
                    bl.Borrar<ConceptoGastosProveedor>(tran.EmpresaID,cgp);
                    return true;
                }
            }
            return false;
        }
       
    }
}
