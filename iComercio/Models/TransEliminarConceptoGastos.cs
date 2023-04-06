using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iComercio.Models
{
    public class TransEliminarConceptoGastos:Operacion
    {
         public TransEliminarConceptoGastos() { }

         public TransEliminarConceptoGastos(int OperacionID, string Nombre, string Descripcion) : base(OperacionID, Nombre, Descripcion) { }

        public async override Task<bool> Enviar(BusinessLayer bl, Transmision tran)
        {
            ConceptoGastos cgp = bl.Get<ConceptoGastos>(tran.EmpresaID,c => c.ConceptoGastosID == System.Convert.ToInt32(tran.EntidadID)).FirstOrDefault();
            if (cgp != null)
            {
                var cgps = await bl.TransmitirEliminarConceptoGasto(cgp, bl.pGlob.Comercio);
                if (cgps != null)
                {
                    bl.Borrar<ConceptoGastos>(tran.EmpresaID,cgp);
                    return true;
                }
            }
            return false;
        }

       
    }
}
