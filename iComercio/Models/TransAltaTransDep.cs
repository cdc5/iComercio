using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iComercio.Rest.RestModels;
using AutoMapper;


namespace iComercio.Models
{
    class TransAltaTransDep : Operacion
    {
        public TransAltaTransDep()             
         {
         }


        public TransAltaTransDep(int OperacionID, string Nombre, string Descripcion) :
                                     base(OperacionID,Nombre,Descripcion)
         {
           
         }

         public async override Task<bool> Enviar(BusinessLayer bl, Transmision tran)
        {
            AltaTransDepRestModel atdrm = DatosAltaTransDep(bl, tran);
            return await this.PostConCC<AltaTransDepRestModel>(bl, tran, atdrm);
         }

         public AltaTransDepRestModel DatosAltaTransDep(BusinessLayer bl, Transmision tran)
         {
             TransferenciasDepositos TransDep = null;
             TransferenciasDepositosRestModel TransDepRM = null;
             int EmpresaID = System.Convert.ToInt32(tran.EntidadID);
             int TransDepID = System.Convert.ToInt32(tran.EntidadID2);

             TransDep = bl.Get<TransferenciasDepositos>(EmpresaID,td => td.EmpresaID == EmpresaID && td.TransferenciasDepositosID == TransDepID).SingleOrDefault();
             if (TransDep != null)
                TransDepRM = Mapper.Map<TransferenciasDepositos, TransferenciasDepositosRestModel>(TransDep);

             AltaTransDepRestModel atdrm = new AltaTransDepRestModel(TransDepRM, null);
             return atdrm;        
             
         }
    }
}
