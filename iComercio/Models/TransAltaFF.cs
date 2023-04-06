using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iComercio.Rest.RestModels;
using AutoMapper;

namespace iComercio.Models
{
    public class TransAltaFF:Operacion
    {
          public TransAltaFF()             
         {
         }


         public TransAltaFF(int OperacionID, string Nombre, string Descripcion) :
                                     base(OperacionID,Nombre,Descripcion)
         {
           
         }

         public async override Task<bool> Enviar(BusinessLayer bl, Transmision tran)
         {

             EnvioFFRestModel aFFrm = DatosAltaFF(bl, tran);
             return await this.PostConCC<EnvioFFRestModel>(bl, tran, aFFrm);
         }

         public EnvioFFRestModel DatosAltaFF(BusinessLayer bl, Transmision tran)
         {
             int EmpresaID = System.Convert.ToInt32(tran.EmpresaID);
             int ComercioID = System.Convert.ToInt32(tran.ComercioID);
             int FFID = System.Convert.ToInt32(tran.EntidadID);
             
             FF ff = bl.Get<FF>(EmpresaID,c => c.FFID == FFID && c.EmpresaID == EmpresaID && c.ComercioID == ComercioID).FirstOrDefault();
             FFRestModel ffRm = Mapper.Map<FF, FFRestModel>(ff);
             EnvioFFRestModel effRm = new EnvioFFRestModel(ffRm, null);
             return effRm;
         }
    }
}
