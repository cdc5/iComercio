using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iComercio.Rest.RestModels;
using AutoMapper;


namespace iComercio.Models
{
    public class TransBajaCredito:Operacion
    {
         public TransBajaCredito()             
         {
         }


         public TransBajaCredito(int OperacionID, string Nombre, string Descripcion) :
                                     base(OperacionID,Nombre,Descripcion)
         {
           
         }

         public async override Task<bool> Enviar(BusinessLayer bl, Transmision tran)
         {
             int EmpresaID = System.Convert.ToInt32(tran.EntidadID);
             int ComercioID = System.Convert.ToInt32(tran.EntidadID2);
             int CreditoID = System.Convert.ToInt32(tran.EntidadID3);
             CreditoAnulado ca = bl.Get<CreditoAnulado>(EmpresaID,c => c.CreditoID == CreditoID && c.EmpresaID == EmpresaID 
                                                        && c.ComercioID == ComercioID).FirstOrDefault();
             BajaCreditoRestModel bcrm = new BajaCreditoRestModel();
             bcrm.Credito = Mapper.Map<CreditoAnulado, CreditoAnuladoRestModel>(ca);
             return await this.DeleteConCC<BajaCreditoRestModel>(bl, tran, bcrm);
         }    
    }
}
