using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iComercio.Rest.RestModels;

namespace iComercio.Models
{
    public class TransActualizarCliente:Operacion
    {
         public TransActualizarCliente()             
         {
         }


          public TransActualizarCliente(int OperacionID, string Nombre, string Descripcion) :
                                     base(OperacionID,Nombre,Descripcion)
         {
           
         }

         public async override Task<bool> Enviar(BusinessLayer bl, Transmision tran)
         {
             int dni = System.Convert.ToInt32(tran.EntidadID);
             ITransmitible ent = bl.Get<Cliente>(tran.EmpresaID,c => c.Documento == dni && c.TipoDocumentoID == tran.EntidadID2).FirstOrDefault();
             return await this.Put<Cliente, ClienteRestModel>(bl, tran,ent);
         }       
    }
}
