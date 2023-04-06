using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iComercio.Rest.RestModels;
using AutoMapper;

namespace iComercio.Models
{
    public class TransBajaCobranza:Operacion
    {
         public TransBajaCobranza()             
         {
         }
        
         public TransBajaCobranza(int OperacionID, string Nombre, string Descripcion) :
                                     base(OperacionID,Nombre,Descripcion)
         {
           
         }

         public async override Task<bool> Enviar(BusinessLayer bl, Transmision tran)
         {
             BajaCobranzaRestModel bcrm = DatosBajaCobranza(bl, tran);
             return await this.DeleteConCC<BajaCobranzaRestModel>(bl, tran, bcrm);
         }

         public BajaCobranzaRestModel DatosBajaCobranza(BusinessLayer bl, Transmision tran)
         { 
             NotasCD NotaCD = null;
             NotasCDRestModel NotaCDRm = null;
             Cobranza CobMod = null;
             Cobranza cob = null;
             Cuota cuo = null;

             int EmpresaID;
             int ComercioID;
             int CreditoID;
             int CuotaID;
             int CobranzaID;
             int NotaCDID;

             Transmision transAltaCobranza = bl.Get<Transmision>(tran.EmpresaID,t => t.GrupoTransmision == tran.GrupoTransmision
                                                               && t.TransmisionID != tran.TransmisionID
                                                               && t.OperacionID != bl.pGlob.TransImputacionCC.OperacionID
                                                               && t.OperacionID == bl.pGlob.TransAltaCobranza.OperacionID
                                                               && t.TransmisionID > tran.TransmisionID)//Para que busque la inmediata superior y no alguna repetida anterior
                                                               .OrderBy(t => t.TransmisionID).FirstOrDefault();

             Transmision transActCuota = bl.Get<Transmision>(tran.EmpresaID, t => t.GrupoTransmision == tran.GrupoTransmision
                                                               && t.TransmisionID != tran.TransmisionID
                                                               && t.OperacionID != bl.pGlob.TransImputacionCC.OperacionID
                                                               && t.OperacionID == bl.pGlob.TransActualizarCuota.OperacionID
                                                               && t.TransmisionID > tran.TransmisionID)//Para que busque la inmediata superior y no alguna repetida anterior
                                                               .OrderBy(t => t.TransmisionID).FirstOrDefault();

             Transmision transActCobranza = bl.Get<Transmision>(tran.EmpresaID, t => t.GrupoTransmision == tran.GrupoTransmision
                                                               && t.TransmisionID != tran.TransmisionID
                                                               && t.OperacionID != bl.pGlob.TransImputacionCC.OperacionID
                                                               && t.OperacionID == bl.pGlob.TransActualizarCobranza.OperacionID
                                                               && t.TransmisionID > tran.TransmisionID)//Para que busque la inmediata superior y no alguna repetida anterior
                                                               .OrderBy(t => t.TransmisionID).FirstOrDefault();

             Transmision transNotaCred = bl.Get<Transmision>(tran.EmpresaID, t => t.GrupoTransmision == tran.GrupoTransmision
                                                               && t.TransmisionID != tran.TransmisionID
                                                               && t.OperacionID != bl.pGlob.TransImputacionCC.OperacionID
                                                               && t.OperacionID == bl.pGlob.TransBajaNotaCD.OperacionID
                                                               && t.TransmisionID > tran.TransmisionID)//Para que busque la inmediata superior y no alguna repetida anterior
                                                               .OrderBy(t => t.TransmisionID).FirstOrDefault();

             if (transAltaCobranza != null)
             {
                 EmpresaID = System.Convert.ToInt32(transAltaCobranza.EntidadID);
                 ComercioID = System.Convert.ToInt32(transAltaCobranza.EntidadID2);
                 CreditoID = System.Convert.ToInt32(transAltaCobranza.EntidadID3);
                 CuotaID = System.Convert.ToInt32(transAltaCobranza.EntidadID4);
                 CobranzaID = System.Convert.ToInt32(transAltaCobranza.EntidadID5);

                 cob = bl.Get<Cobranza>(EmpresaID,c => c.CreditoID == CreditoID && c.EmpresaID == EmpresaID && c.ComercioID == ComercioID
                                      && c.CuotaID == CuotaID && c.CobranzaID == CobranzaID).FirstOrDefault();

                 if (transActCuota != null)
                 {
                     cuo = bl.Get<Cuota>(EmpresaID,c => c.CreditoID == CreditoID && c.EmpresaID == EmpresaID && c.ComercioID == ComercioID
                                            && c.CuotaID == CuotaID).FirstOrDefault();
                 }
                 
                 if (transActCobranza != null)
                 {
                     CobranzaID = System.Convert.ToInt32(transActCobranza.EntidadID5);
                     CobMod = bl.Get<Cobranza>(EmpresaID,c => c.CreditoID == CreditoID && c.EmpresaID == EmpresaID && c.ComercioID == ComercioID
                                        && c.CuotaID == CuotaID && c.CobranzaID == CobranzaID).FirstOrDefault();
                 }

                 if (transNotaCred != null)
                 {
                     CobranzaID = System.Convert.ToInt32(transActCobranza.EntidadID5);
                     NotaCDID = System.Convert.ToInt32(transNotaCred.EntidadID6);
                     NotaCD = bl.Get<NotasCD>(EmpresaID,nc => nc.CreditoID == CreditoID && nc.EmpresaID == EmpresaID && nc.ComercioID == ComercioID
                                        && nc.CuotaID == CuotaID && nc.CobranzaID == CobranzaID && nc.NotaCDID == NotaCDID).SingleOrDefault();
                     NotaCDRm = Mapper.Map<NotasCD, NotasCDRestModel>(NotaCD);
                 }
             }
                          
             CobranzaRestModel cobRm = Mapper.Map<Cobranza, CobranzaRestModel>(cob);
             CobranzaRestModel cobModRm = Mapper.Map<Cobranza, CobranzaRestModel>(CobMod);
             CuotaRestModel cuoRm = Mapper.Map<Cuota, CuotaRestModel>(cuo);
             BajaCobranzaRestModel bcrm = new BajaCobranzaRestModel(cuoRm,cobRm,cobModRm,NotaCDRm);
             return bcrm;
         }
    }
}
