using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iComercio.Rest.RestModels;
using AutoMapper;

namespace iComercio.Models
{
     public class TransAltaPago:Operacion
    {
         public TransAltaPago()             
         {
         }


         public TransAltaPago(int OperacionID, string Nombre, string Descripcion) :
                                     base(OperacionID,Nombre,Descripcion)
         {
           
         }

         public async override Task<bool> Enviar(BusinessLayer bl, Transmision tran)
         {

             EnvioPagoRestModel epRM = DatosAltaPago(bl, tran);
             return await this.PostConCC<EnvioPagoRestModel>(bl, tran, epRM);            
         }

         public EnvioPagoRestModel DatosAltaPago(BusinessLayer bl, Transmision tran)
         {
             int EmpresaID = System.Convert.ToInt32(tran.EmpresaID);
             int ComercioID = System.Convert.ToInt32(tran.ComercioID);
             int PagoID = System.Convert.ToInt32(tran.EntidadID);

             Pago Pago = bl.Get<Pago>(EmpresaID, c => c.PagoID == PagoID && c.EmpresaID == EmpresaID && c.ComercioID == ComercioID).FirstOrDefault();
             PagoRestModel PagoRm = Mapper.Map<Pago, PagoRestModel>(Pago);
             EnvioPagoRestModel ePagoRm = new EnvioPagoRestModel(PagoRm, null);
             return ePagoRm;
         }
    }
}
