using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iComercio.Rest.RestModels;
using AutoMapper;


namespace iComercio.Models
{
    public class TransAltaRefinanciacionCobranza:Operacion
    {
         public TransAltaRefinanciacionCobranza()             
         {
         }


         public TransAltaRefinanciacionCobranza(int OperacionID, string Nombre, string Descripcion) :
                                     base(OperacionID,Nombre,Descripcion)
         {
           
         }

         public async override Task<bool> Enviar(BusinessLayer bl, Transmision tran)
         {
             AltaRefinanciacionCobranzaRestModel AltaRefinanciacionCobranzaRestModel = new AltaRefinanciacionCobranzaRestModel();
             CobranzaRestModel crm;
             Cobranza cob;
             RefinanciacionCuota RefiCuota;
             RefinanciacionCuotaRestModel RefiCuotaRM;
             RefinanciacionCobranza RefiCob;
             RefinanciacionCobranzaRestModel RefiCobRM;
             NotasCDRestModel ncdrm;
             NotasCD notacd;

             int EmpresaID;
             int ComercioID;
             int CreditoID;
             int RefinanciacionID;
             int RefinanciacionCuotaID;
             int RefinanciacionCobranzaID;
             int CuotaID;
             int CobranzaID;
             int NotaCDID;

             TransAltaCobranza tacob = new TransAltaCobranza();

             List<Transmision> trans = bl.Get<Transmision>(tran.EmpresaID,t => t.GrupoTransmision == tran.GrupoTransmision && t.TransmisionID != tran.TransmisionID).ToList();
             foreach (Transmision t in trans)
             {
                 if (t.OperacionID == bl.pGlob.TransActualizarRefinanciacionCuota.OperacionID)
                 {
                     EmpresaID = System.Convert.ToInt32(t.EntidadID);
                     ComercioID = System.Convert.ToInt32(t.EntidadID2);
                     CreditoID = System.Convert.ToInt32(t.EntidadID3);
                     RefinanciacionID = System.Convert.ToInt32(t.EntidadID4);
                     RefinanciacionCuotaID = System.Convert.ToInt32(t.EntidadID5);

                     RefiCuota = bl.Get<RefinanciacionCuota>(EmpresaID,c => c.EmpresaID == EmpresaID && c.ComercioID == ComercioID && c.CreditoID == CreditoID
                                            && c.RefinanciacionID == RefinanciacionID && c.RefinanciacionCuotaID == RefinanciacionCuotaID).SingleOrDefault();
                     RefiCuotaRM = Mapper.Map<RefinanciacionCuota, RefinanciacionCuotaRestModel>(RefiCuota);
                     AltaRefinanciacionCobranzaRestModel.RefinanciacionCuotaActRM = RefiCuotaRM;
                 }
                 else if (t.OperacionID == bl.pGlob.TransAltaRefinanciacionCobranza.OperacionID)
                 {
                     EmpresaID = System.Convert.ToInt32(t.EntidadID);
                     ComercioID = System.Convert.ToInt32(t.EntidadID2);
                     CreditoID = System.Convert.ToInt32(t.EntidadID3);
                     RefinanciacionID = System.Convert.ToInt32(t.EntidadID4);
                     RefinanciacionCuotaID = System.Convert.ToInt32(t.EntidadID5);
                     RefinanciacionCobranzaID = System.Convert.ToInt32(t.EntidadID6);

                     RefiCob = bl.Get<RefinanciacionCobranza>(EmpresaID, c => c.EmpresaID == EmpresaID && c.ComercioID == ComercioID && c.CreditoID == CreditoID
                                            && c.RefinanciacionID == RefinanciacionID && c.RefinanciacionCuotaID == RefinanciacionCuotaID 
                                            && c.RefinanciacionCobranzaID == RefinanciacionCobranzaID).SingleOrDefault();
                     RefiCobRM = Mapper.Map<RefinanciacionCobranza, RefinanciacionCobranzaRestModel>(RefiCob);
                     AltaRefinanciacionCobranzaRestModel.RefinanciacionCobranzaNuevaRM=RefiCobRM;
                 }
                 else if (t.OperacionID == bl.pGlob.TransAltaCobranza.OperacionID)
                 {
                     AltaCobranzaRestModel acrm = tacob.DatosAltaCobranza(bl, t);
                     AltaRefinanciacionCobranzaRestModel.CobranzasRM.Add(acrm);
                 }
             }
             return await this.PostConCC<AltaRefinanciacionCobranzaRestModel>(bl, tran, AltaRefinanciacionCobranzaRestModel);
         }    
    }
}
