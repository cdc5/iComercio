using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iComercio.Rest.RestModels;
using AutoMapper;

namespace iComercio.Models
{
    public class TransBajaRefinanciacionCobranza : Operacion
    {
        public TransBajaRefinanciacionCobranza()
        {
        }


        public TransBajaRefinanciacionCobranza(int OperacionID, string Nombre, string Descripcion) :
            base(OperacionID, Nombre, Descripcion)
        {

        }

        public async override Task<bool> Enviar(BusinessLayer bl, Transmision tran)
        {
            BajaCobranzaRestModel bcRM = null;
            int EmpresaID;
            EmpresaID = System.Convert.ToInt32(tran.EntidadID);
            List<Transmision> transmis = bl.GetTransmisiones(tran.EmpresaID, t => t.GrupoTransmision == tran.GrupoTransmision
                                                               && t.TransmisionID != tran.TransmisionID
                                                               && t.OperacionID != bl.pGlob.TransImputacionCC.OperacionID)
                                                               .OrderBy(t => t.TransmisionID).ToList();

            List<BajaCobranzaRestModel> lbcRM = new List<BajaCobranzaRestModel>();


            int ComercioID;
            int CreditoID;
            int RefinanciacionID;
            int RefinanciacionCuotaID;
            int RefinanciacionCobranzaID;
            int CuotaID;
            int CobranzaID;

            RefinanciacionCobranza RefiCobraAct = null;
            RefinanciacionCobranza RefiCobraNueva = null;
            RefinanciacionCuota RefiCuotaAct = null;
            Cobranza CobNueva = null;
            Cobranza CobAct = null;
            Cuota CuotaAct = null;

            TransBajaCobranza tbacob = new TransBajaCobranza();

            foreach (Transmision t in transmis)
            {
                EmpresaID = System.Convert.ToInt32(t.EntidadID);
                ComercioID = System.Convert.ToInt32(t.EntidadID2);
                CreditoID = System.Convert.ToInt32(t.EntidadID3);

                if (t.OperacionID == bl.pGlob.TransAltaRefinanciacionCobranza.OperacionID)
                {
                    RefinanciacionID = System.Convert.ToInt32(t.EntidadID4);
                    RefinanciacionCuotaID = System.Convert.ToInt32(t.EntidadID5);
                    RefinanciacionCobranzaID = System.Convert.ToInt32(t.EntidadID6);
                    RefiCobraNueva = bl.Get<RefinanciacionCobranza>(EmpresaID, c => c.CreditoID == CreditoID && c.EmpresaID == tran.EmpresaID
                                                                    && c.ComercioID == tran.ComercioID && c.RefinanciacionID == RefinanciacionID
                                                                    && c.RefinanciacionCuotaID == RefinanciacionCuotaID
                                                                    && c.RefinanciacionCobranzaID == RefinanciacionCobranzaID).FirstOrDefault();

                }

                if (t.OperacionID == bl.pGlob.TransActualizarRefinanciacionCobranza.OperacionID)
                {
                    RefinanciacionID = System.Convert.ToInt32(t.EntidadID4);
                    RefinanciacionCuotaID = System.Convert.ToInt32(t.EntidadID5);
                    RefinanciacionCobranzaID = System.Convert.ToInt32(t.EntidadID6);
                    RefiCobraAct = bl.Get<RefinanciacionCobranza>(EmpresaID, c => c.EmpresaID == EmpresaID
                                                                      && c.ComercioID == ComercioID
                                                                      && c.CreditoID == CreditoID
                                                                      && c.RefinanciacionID == RefinanciacionID
                                                                      && c.RefinanciacionCuotaID == RefinanciacionCuotaID
                                                                      && c.RefinanciacionCobranzaID == RefinanciacionCobranzaID).FirstOrDefault();
                }

                if (t.OperacionID == bl.pGlob.TransActualizarRefinanciacionCuota.OperacionID)
                {
                    RefinanciacionID = System.Convert.ToInt32(t.EntidadID4);
                    RefinanciacionCuotaID = System.Convert.ToInt32(t.EntidadID5);
                    RefiCuotaAct = bl.Get<RefinanciacionCuota>(EmpresaID, c => c.EmpresaID == EmpresaID
                                                                      && c.ComercioID == ComercioID
                                                                      && c.CreditoID == CreditoID
                                                                      && c.RefinanciacionID == RefinanciacionID
                                                                      && c.RefinanciacionCuotaID == RefinanciacionCuotaID).FirstOrDefault();
                }

                if (t.OperacionID == bl.pGlob.TransBajaCobranza.OperacionID)
                {
                    bcRM = tbacob.DatosBajaCobranza(bl, t);
                    lbcRM.Add(bcRM);
                }
            }

            RefinanciacionCuotaRestModel RefiCuotaActRM = Mapper.Map<RefinanciacionCuota, RefinanciacionCuotaRestModel>(RefiCuotaAct);
            RefinanciacionCobranzaRestModel RefiCobraNuevaRM = Mapper.Map<RefinanciacionCobranza, RefinanciacionCobranzaRestModel>(RefiCobraNueva);
            RefinanciacionCobranzaRestModel RefiCobraActRM = Mapper.Map<RefinanciacionCobranza, RefinanciacionCobranzaRestModel>(RefiCobraAct);
            BajaRefinanciacionCobranzaRestModel brcrm = new BajaRefinanciacionCobranzaRestModel(RefiCuotaActRM, RefiCobraNuevaRM, RefiCobraActRM, lbcRM);
            return await this.DeleteConCC<BajaRefinanciacionCobranzaRestModel>(bl, tran, brcrm);
        }
    }
}
