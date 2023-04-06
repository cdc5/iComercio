using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iComercio.Rest.RestModels;
using AutoMapper;

namespace iComercio.Models
{
    class TransAltaCobranzas:Operacion
    {
         public TransAltaCobranzas()             
         {
         }


         public TransAltaCobranzas(int OperacionID, string Nombre, string Descripcion) :
                                     base(OperacionID,Nombre,Descripcion)
         {
           
         }

         public async override Task<bool> Enviar(BusinessLayer bl, Transmision tran)
         {
             AltaCobranzasRestModel acrm = DatosAltaCobranzas(bl, tran);
             return await this.PostConCC<AltaCobranzasRestModel>(bl, tran, acrm);
         }

         public AltaCobranzasRestModel DatosAltaCobranzas(BusinessLayer bl, Transmision tran)
         {
             int EmpresaID;
             int ComercioID;
             int CreditoID;
             int CuotaID;
             int CobranzaID;

             AltaCobranzasRestModel acsrm = new AltaCobranzasRestModel();
             AltaCobranzaRestModel acrm;

             TransAltaCobranza tacob = new TransAltaCobranza();

             List<Transmision> trans = bl.Get<Transmision>(tran.EmpresaID,t => t.GrupoTransmision == tran.GrupoTransmision             
                                                               && t.OperacionID != bl.pGlob.TransImputacionCC.OperacionID).ToList();
                 if (trans != null && trans.Count() >= 0)
                 {
                     foreach(Transmision t in trans)
                     {
                         EmpresaID = System.Convert.ToInt32(tran.EntidadID);
                         ComercioID = System.Convert.ToInt32(tran.EntidadID2);
                         CreditoID = System.Convert.ToInt32(tran.EntidadID3);
                         CuotaID = System.Convert.ToInt32(tran.EntidadID4);
                         CobranzaID = System.Convert.ToInt32(tran.EntidadID5);

                         if (t.OperacionID == bl.pGlob.TransAltaCobranzas.OperacionID)
                         {

                             acrm = tacob.DatosAltaCobranza(bl, t);
                             acsrm.AltasCobranzas.Add(acrm);
                         }
                     }                                   
                }
                    return acsrm;
         }
    }
}
