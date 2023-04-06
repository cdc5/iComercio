using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iComercio.Rest.RestModels;

namespace iComercio.Models
{
    public class TransInfoAct : Operacion
    {
        public TransInfoAct()             
         {
         }


        public TransInfoAct(int OperacionID, string Nombre, string Descripcion) :
                                     base(OperacionID,Nombre,Descripcion)
         {
           
         }

         public async override Task<bool> Enviar(BusinessLayer bl, Transmision tran)
         {
             DateTime Desde = System.Convert.ToDateTime(tran.EntidadID);
             DateTime Hasta = System.Convert.ToDateTime(tran.EntidadID2);
             InfoActRestModel iarm = new InfoActRestModel();
             iarm.Desde = Desde;
             iarm.Hasta = Hasta;             
             return await this.Get<InfoActRestModel>(bl, tran, iarm);
         }    
    }
}
