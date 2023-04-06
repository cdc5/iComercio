using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iComercio.Rest.RestModels;
using AutoMapper;

namespace iComercio.Models
{
    public class TransAltaCobranza:Operacion
    {
         public TransAltaCobranza()             
         {
         }


         public TransAltaCobranza(int OperacionID, string Nombre, string Descripcion) :
                                     base(OperacionID,Nombre,Descripcion)
         {
           
         }

         public async override Task<bool> Enviar(BusinessLayer bl, Transmision tran)
         {

             AltaCobranzaRestModel acrm = DatosAltaCobranza(bl, tran);
             return await this.PostConCC<AltaCobranzaRestModel>(bl, tran, acrm);
         }

         public AltaCobranzaRestModel DatosAltaCobranza(BusinessLayer bl, Transmision tran)
         {
             NotasCD NotaCD = null;
             NotasCDRestModel NotaCDRm = null;
             int notaCdId;
             int EmpresaID = System.Convert.ToInt32(tran.EntidadID);
             int ComercioID = System.Convert.ToInt32(tran.EntidadID2);
             int CreditoID = System.Convert.ToInt32(tran.EntidadID3);
             int CuotaID = System.Convert.ToInt32(tran.EntidadID4);
             int CobranzaID = System.Convert.ToInt32(tran.EntidadID5);

             Cobranza cob = bl.Get<Cobranza>(EmpresaID,c => c.CreditoID == CreditoID && c.EmpresaID == EmpresaID && c.ComercioID == ComercioID
                                                 && c.CuotaID == CuotaID && c.CobranzaID == CobranzaID).FirstOrDefault();
             Cuota cuo = bl.Get<Cuota>(EmpresaID,c => c.CreditoID == CreditoID && c.EmpresaID == EmpresaID && c.ComercioID == ComercioID
                                                 && c.CuotaID == CuotaID).FirstOrDefault();

             if (tran.GrupoTransmision != null)
             {
                 
                 List<Transmision> trans = bl.Get<Transmision>(EmpresaID,t => t.GrupoTransmision == tran.GrupoTransmision
                                                               && t.TransmisionID != tran.TransmisionID 
                                                               && t.OperacionID != bl.pGlob.TransImputacionCC.OperacionID).ToList();
                 if (trans != null && trans.Count() >= 0)
                 {
                     foreach(Transmision t in trans)
                     {
                         if (t.OperacionID == bl.pGlob.TransAltaNotaCD.OperacionID)
                         {
                             notaCdId = System.Convert.ToInt32(t.EntidadID6);
                             NotaCD = bl.Get<NotasCD>(EmpresaID,nc => nc.NotaCDID == notaCdId
                                                     && nc.EmpresaID == EmpresaID && nc.ComercioID == ComercioID
                                                     && nc.CreditoID == CreditoID && nc.CuotaID == CuotaID
                                                     && nc.CobranzaID == CobranzaID).SingleOrDefault();
                             if (NotaCD != null)
                                 NotaCDRm = Mapper.Map<NotasCD, NotasCDRestModel>(NotaCD);
                         }
                     }                  
                 }
             }

             CobranzaRestModel cobRm = Mapper.Map<Cobranza, CobranzaRestModel>(cob);
             CuotaRestModel cuoRm = Mapper.Map<Cuota, CuotaRestModel>(cuo);
             AltaCobranzaRestModel acrm = new AltaCobranzaRestModel(cobRm, cuoRm, NotaCDRm, null);
             return acrm;
         }

    }
}
