using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iComercio.Rest.RestModels;

namespace iComercio.Models
{
    class TransActualizarCredito:Operacion
    {
          public TransActualizarCredito()             
         {
         }


          public TransActualizarCredito(int OperacionID, string Nombre, string Descripcion) :
                                     base(OperacionID,Nombre,Descripcion)
         {
           
         }

         public async override Task<bool> Enviar(BusinessLayer bl, Transmision tran)
         {
             return false;
         }     
    }
}
