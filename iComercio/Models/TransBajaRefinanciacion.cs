using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iComercio.Rest.RestModels;
using AutoMapper;

namespace iComercio.Models
{
    public class TransBajaRefinanciacion : Operacion
    {
        public TransBajaRefinanciacion()             
         {
         }

        public TransBajaRefinanciacion(int OperacionID, string Nombre, string Descripcion) :
                                     base(OperacionID,Nombre,Descripcion)
         {
           
         }

         public async override Task<bool> Enviar(BusinessLayer bl, Transmision tran)
         {
             BajaRefinanciacionRestModel brrm = new BajaRefinanciacionRestModel();

             int EmpresaID = System.Convert.ToInt32(tran.EntidadID);
             int ComercioID = System.Convert.ToInt32(tran.EntidadID2);
             int CreditoID = System.Convert.ToInt32(tran.EntidadID3);
             int RefinanciacionID = System.Convert.ToInt32(tran.EntidadID4);

             Refinanciacion refi = bl.Get<Refinanciacion>(EmpresaID,r => r.EmpresaID == EmpresaID && r.ComercioID == ComercioID && r.CreditoID == CreditoID && r.RefinanciacionID == RefinanciacionID).Single();
             brrm.Refinanciacion = Mapper.Map<Refinanciacion,RefinanciacionRestModel>(refi);

             return await this.Delete<BajaRefinanciacionRestModel>(bl, tran, brrm);
         }

   
    }
}
