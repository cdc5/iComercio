using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace iComercio.Models
{
    public class TransActualizarConceptoGastos:Operacion
    {
        public TransActualizarConceptoGastos(){}

        public TransActualizarConceptoGastos(int OperacionID, string Nombre, string Descripcion) : base(OperacionID, Nombre, Descripcion) { }

        public async override Task<bool> Enviar(BusinessLayer bl, Transmision tran)
        {
            ConceptoGastos cgp = bl.Get<ConceptoGastos>(tran.EmpresaID,c => c.ConceptoGastosID == System.Convert.ToInt32(tran.EntidadID)).FirstOrDefault();
            if (cgp != null)
            {
                var cgps = await bl.TransmitirActualizarConceptoGasto(cgp, bl.pGlob.Comercio);
                if (cgps.ConceptoGastosID != null)
                { 
                   return true;
                }
            }
            return false;
        }

       
    }
}
