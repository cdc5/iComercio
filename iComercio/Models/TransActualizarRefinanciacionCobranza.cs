using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iComercio.Models
{
    public class TransActualizarRefinanciacionCobranza:Operacion
    {
         public TransActualizarRefinanciacionCobranza()             
         {
         }


         public TransActualizarRefinanciacionCobranza(int OperacionID, string Nombre, string Descripcion) :
                                     base(OperacionID,Nombre,Descripcion)
         {
           
         }

         public async override Task<bool> Enviar(BusinessLayer bl, Transmision tran)
         {
             return false;
         }    
    }
}
