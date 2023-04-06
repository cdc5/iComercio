using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iComercio.Rest.RestModels;
using System.Threading.Tasks;
using AutoMapper;
namespace iComercio.Models
{
    public class TransBajaGasto:Operacion
    {
         public TransBajaGasto()             
         {
         }

         public TransBajaGasto(int OperacionID, string Nombre, string Descripcion) :
                                     base(OperacionID,Nombre,Descripcion)
         {
           
         }

         public async override Task<bool> Enviar(BusinessLayer bl, Transmision tran)
         {
             EnvioGastoRestModel aFFrm = DatosBajaGasto(bl, tran);
             return await this.DeleteConCC<EnvioGastoRestModel>(bl, tran, aFFrm);
         }

         public EnvioGastoRestModel DatosBajaGasto(BusinessLayer bl, Transmision tran)
         {
             int EmpresaID = System.Convert.ToInt32(tran.EmpresaID);
             int ComercioID = System.Convert.ToInt32(tran.ComercioID);
             int GastoID = System.Convert.ToInt32(tran.EntidadID);

             Gasto Gasto = bl.Get<Gasto>(EmpresaID, c => c.GastoID == GastoID && c.EmpresaID == EmpresaID && c.ComercioID == ComercioID).FirstOrDefault();
             GastoRestModel ffRm = Mapper.Map<Gasto, GastoRestModel>(Gasto);
             EnvioGastoRestModel effRm = new EnvioGastoRestModel(ffRm, null);
             return effRm;
         }
    }
}
