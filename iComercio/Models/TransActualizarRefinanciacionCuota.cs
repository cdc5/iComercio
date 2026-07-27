using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iComercio.Rest.RestModels;

namespace iComercio.Models
{
    public class TransActualizarRefinanciacionCuota:Operacion
    {
         public TransActualizarRefinanciacionCuota()             
         {
         }


         public TransActualizarRefinanciacionCuota(int OperacionID, string Nombre, string Descripcion) :
                                     base(OperacionID,Nombre,Descripcion)
         {
           
         }

         public async override Task<bool> Enviar(BusinessLayer bl, Transmision tran)
         {
             // El dato real viaja embebido en la transmisión TransAltaRefinanciacionCobranza
             // hermana (misma cuota, misma transacción de origen); acá no hay nada más que
             // enviar, solo confirmar la transmisión para que no quede reintentando siempre.
             return true;
         }
    }
}
