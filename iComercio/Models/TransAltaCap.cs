using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iComercio.Rest.RestModels;
using AutoMapper;

namespace iComercio.Models
{
    public class TransAltaCap : Operacion
    {
        public TransAltaCap()             
         {
         }


        public TransAltaCap(int OperacionID, string Nombre, string Descripcion) :
                                     base(OperacionID,Nombre,Descripcion)
         {
           
         }

         public async override Task<bool> Enviar(BusinessLayer bl, Transmision tran)
         {
             EnvioCapRestModel aFFrm = DatosAltaCAP(bl, tran);
             return await this.PostConCC<EnvioCapRestModel>(bl, tran, aFFrm);
         }

         public EnvioCapRestModel DatosAltaCAP(BusinessLayer bl, Transmision tran)
         {
             int EmpresaID = System.Convert.ToInt32(tran.EmpresaID);
             int ComercioID = System.Convert.ToInt32(tran.ComercioID);
             int CapID = System.Convert.ToInt32(tran.EntidadID);

             Cap Cap = bl.Get<Cap>(EmpresaID, c => c.CapID == CapID && c.EmpresaID == EmpresaID && c.ComercioID == ComercioID).FirstOrDefault();
             CapRestModel CapRm = Mapper.Map<Cap, CapRestModel>(Cap);
             EnvioCapRestModel eCapRm = new EnvioCapRestModel(CapRm, null);
             return eCapRm;
         }
    }
}
