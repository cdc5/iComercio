using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iComercio.Rest.RestModels;

namespace iComercio.Models
{
    public class TransControlDiario : Operacion
    {
        public TransControlDiario()             
         {
         }


        public TransControlDiario(int OperacionID, string Nombre, string Descripcion) :
                                     base(OperacionID,Nombre,Descripcion)
         {
           
         }

         public async override Task<bool> Enviar(BusinessLayer bl, Transmision tran)
         {
             DateTime Desde = System.Convert.ToDateTime(tran.EntidadID);
             DateTime Hasta = System.Convert.ToDateTime(tran.EntidadID2);
             ControlDiarioRestModel cdrm = bl.GetControlDiario(tran.Comercio, Desde,Hasta);
             return await this.Post<ControlDiarioRestModel>(bl, tran, cdrm);
         }    
    }
}
