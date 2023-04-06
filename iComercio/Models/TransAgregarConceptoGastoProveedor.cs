using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iComercio.Models
{
    public class TransAgregarConceptoGastoProveedor:Operacion
    {
        public TransAgregarConceptoGastoProveedor(){}

        public TransAgregarConceptoGastoProveedor(int OperacionID, string Nombre, string Descripcion) : base(OperacionID, Nombre, Descripcion) { }

        public async override Task<bool> Enviar(BusinessLayer bl, Transmision tran)
        {
            ConceptoGastosProveedor cgp = bl.Get<ConceptoGastosProveedor>(c => c.ConceptoGastosProveedorID == System.Convert.ToInt32(tran.EntidadID)).FirstOrDefault();
            if (cgp != null)
            {
                var cgps = await bl.TransmitirAgregarConceptoGastoProveedor(cgp, bl.pGlob.Comercio);
                if (cgps.ConceptoGastosID != null)
                {
                    return true;
                }
            }
            return false;
        }

   
    }
}
