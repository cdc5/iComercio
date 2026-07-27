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
             // El dato real viaja embebido en la transmisión de baja/alta de cobranza de
             // refinanciación hermana; acá no hay nada más que enviar, solo confirmar la
             // transmisión para que no quede reintentando siempre.
             return true;
         }
    }
}
