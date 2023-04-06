using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iComercio.Rest.RestModels;
using AutoMapper;

namespace iComercio.Models
{
    public class TransAltaRefinanciacion:Operacion
    {
          public TransAltaRefinanciacion()             
         {
         }


          public TransAltaRefinanciacion(int OperacionID, string Nombre, string Descripcion) :
                                     base(OperacionID,Nombre,Descripcion)
         {
           
         }

         public async override Task<bool> Enviar(BusinessLayer bl, Transmision tran)
         {
             AltaRefinanciacionRestModel AltaRefiRM = new AltaRefinanciacionRestModel();
       
             Credito cred;
             CreditoRestModel credRM;
             CobranzaRestModel CobRM;
             Cobranza Cob;
             Cuota Cuota;
             CuotaRestModel CuotaRM;
             Refinanciacion Refi;
             RefinanciacionRestModel RefiRM;
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


             List<Transmision> trans = bl.Get<Transmision>(tran.EmpresaID,t => t.GrupoTransmision == tran.GrupoTransmision).ToList();
             foreach (Transmision t in trans)
             {
                 if (t.OperacionID == bl.pGlob.TransActualizarCredito.OperacionID)
                 {
                     EmpresaID = System.Convert.ToInt32(t.EntidadID);
                     ComercioID = System.Convert.ToInt32(t.EntidadID2);
                     CreditoID = System.Convert.ToInt32(t.EntidadID3);

                     cred = bl.Get<Credito>(EmpresaID,c => c.EmpresaID == EmpresaID && c.ComercioID == ComercioID && c.CreditoID == CreditoID).SingleOrDefault();
                     credRM = Mapper.Map<Credito, CreditoRestModel>(cred);
                     AltaRefiRM.CreditoActRM = credRM;
                 }
                 else if (t.OperacionID == bl.pGlob.TransAltaRefinanciacion.OperacionID)
                 {
                     EmpresaID = System.Convert.ToInt32(t.EntidadID);
                     ComercioID = System.Convert.ToInt32(t.EntidadID2);
                     CreditoID = System.Convert.ToInt32(t.EntidadID3);
                     RefinanciacionID = System.Convert.ToInt32(t.EntidadID4);

                     Refi = bl.Get<Refinanciacion>(EmpresaID,c => c.EmpresaID == EmpresaID && c.ComercioID == ComercioID && c.CreditoID == CreditoID
                                            && c.RefinanciacionID == RefinanciacionID).SingleOrDefault();
                     RefiRM = Mapper.Map<Refinanciacion, RefinanciacionRestModel>(Refi);
                     AltaRefiRM.RefinanciacionNuevaRM = RefiRM;
                 }
                 else if (t.OperacionID == bl.pGlob.TransAltaRefinanciacionCuota.OperacionID)
                 {
                     EmpresaID = System.Convert.ToInt32(t.EntidadID);
                     ComercioID = System.Convert.ToInt32(t.EntidadID2);
                     CreditoID = System.Convert.ToInt32(t.EntidadID3);
                     RefinanciacionID = System.Convert.ToInt32(t.EntidadID4);
                     RefinanciacionCuotaID = System.Convert.ToInt32(t.EntidadID5);


                     RefiCuota = bl.Get<RefinanciacionCuota>(EmpresaID,c => c.EmpresaID == EmpresaID && c.ComercioID == ComercioID && c.CreditoID == CreditoID
                                            && c.RefinanciacionID == RefinanciacionID && c.RefinanciacionCuotaID == RefinanciacionCuotaID).SingleOrDefault();
                     RefiCuotaRM = Mapper.Map<RefinanciacionCuota, RefinanciacionCuotaRestModel>(RefiCuota);
                     AltaRefiRM.RefinanciacionCuotasNuevasRM.Add(RefiCuotaRM);
                 }
                 else if (t.OperacionID == bl.pGlob.TransActualizarCuota.OperacionID)
                 {
                     EmpresaID = System.Convert.ToInt32(t.EntidadID);
                     ComercioID = System.Convert.ToInt32(t.EntidadID2);
                     CreditoID = System.Convert.ToInt32(t.EntidadID3);
                     CuotaID = System.Convert.ToInt32(t.EntidadID4);
                     Cuota = bl.Get<Cuota>(EmpresaID,c => c.EmpresaID == EmpresaID && c.ComercioID == ComercioID && c.CreditoID == CreditoID
                                            && c.CuotaID == CuotaID).SingleOrDefault();
                     CuotaRM = Mapper.Map<Cuota, CuotaRestModel>(Cuota);
                     AltaRefiRM.CuotaActRM = CuotaRM;
                 }
                 else if (t.OperacionID == bl.pGlob.TransAltaCobranza.OperacionID)
                 {
                     EmpresaID = System.Convert.ToInt32(t.EntidadID);
                     ComercioID = System.Convert.ToInt32(t.EntidadID2);
                     CreditoID = System.Convert.ToInt32(t.EntidadID3);
                     CuotaID = System.Convert.ToInt32(t.EntidadID4);
                     CobranzaID = System.Convert.ToInt32(t.EntidadID5);
                     Cob = bl.Get<Cobranza>(EmpresaID,c => c.EmpresaID == EmpresaID && c.ComercioID == ComercioID && c.CreditoID == CreditoID
                                            && c.CuotaID == CuotaID && c.CobranzaID == CobranzaID).SingleOrDefault();
                     CobRM = Mapper.Map<Cobranza, CobranzaRestModel>(Cob);
                     AltaRefiRM.CobranzaNuevaRM = CobRM;
                 }
             }
             return await this.PostConCC<AltaRefinanciacionRestModel>(bl, tran, AltaRefiRM);
         }    

    }
}
