using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iComercio.Rest.RestModels;
using AutoMapper;

namespace iComercio.Models
{
    public class TransAltaCredito : Operacion
    {
        public TransAltaCredito()             
         {
         }


        public TransAltaCredito(int OperacionID, string Nombre, string Descripcion) :
                                     base(OperacionID,Nombre,Descripcion)
         {
           
         }

         public async override Task<bool> Enviar(BusinessLayer bl, Transmision tran)
         {
             int EmpresaID = System.Convert.ToInt32(tran.EntidadID);
             int ComercioID = System.Convert.ToInt32(tran.EntidadID2);
             int CreditoID = System.Convert.ToInt32(tran.EntidadID3);
             Credito cred = bl.Get<Credito>(EmpresaID,c => c.CreditoID == CreditoID 
                            && c.EmpresaID == EmpresaID && c.ComercioID == ComercioID).FirstOrDefault();
             CreditoRestModel credRm = Mapper.Map<Credito, CreditoRestModel>(cred);
            
            //Usuario usuGenerador = bl.Get<Usuario>(EmpresaID, u => u.UsuarioID == cred.UsuarioID).FirstOrDefault();
            //if (usuGenerador != null)
            //    credRm.NombreUsuario = usuGenerador.usuario;

            //TransImputacionCC ticc = new TransImputacionCC();
            //ImputacionCuentaCorrienteRestModel iccrm = ticc.DatosImputacionCuentaCorriente(bl,tran);
            AltaCreditoRestModel acrm = new AltaCreditoRestModel(credRm,null);
             return await this.PostConCC<AltaCreditoRestModel>(bl, tran, acrm);
             //return await this.Post<Credito, CreditoRestModel>(bl, tran, ent);
         }       
    }
}
