using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iComercio.Rest.RestModels;
using AutoMapper;

namespace iComercio.Models
{
    public class TransAltaGasto:Operacion
    {
        public TransAltaGasto()             
         {
         }

        public TransAltaGasto(int OperacionID, string Nombre, string Descripcion) :
                                     base(OperacionID,Nombre,Descripcion)
         {
           
         }

        public async override Task<bool> Enviar(BusinessLayer bl, Transmision tran)
        {

            EnvioGastoRestModel eGastoRm = DatosAltaGasto(bl, tran);
            return await this.PostConCC<EnvioGastoRestModel>(bl, tran, eGastoRm);
        }

        public EnvioGastoRestModel DatosAltaGasto(BusinessLayer bl, Transmision tran)
        {
            int EmpresaID = System.Convert.ToInt32(tran.EmpresaID);
            int ComercioID = System.Convert.ToInt32(tran.ComercioID);
            int GastoID = System.Convert.ToInt32(tran.EntidadID);

            Gasto g = bl.Get<Gasto>(EmpresaID, c => c.GastoID == GastoID && c.EmpresaID == EmpresaID && c.ComercioID == ComercioID).FirstOrDefault();
            GastoRestModel GastoRM = Mapper.Map<Gasto, GastoRestModel>(g);
            EnvioGastoRestModel eGastoRm = new EnvioGastoRestModel(GastoRM, null);
            return eGastoRm;
        }

        //public async override Task<bool> Enviar(BusinessLayer bl, Transmision tran)
        //{
        //    AltaReciboRestModel AltaReciboRestModel = new AltaReciboRestModel();

        //    int EmpresaID = System.Convert.ToInt32(tran.EntidadID);
        //    int ComercioID = System.Convert.ToInt32(tran.EntidadID2);
        //    int GastoID = System.Convert.ToInt32(tran.EntidadID3);

        //    TransAltaTransDep tatd = new TransAltaTransDep();
        //    Recibo rec = bl.Get<Recibo>(EmpresaID, c => c.ReciboID == ReciboID && c.EmpresaID == EmpresaID && c.ComercioID == ComercioID).FirstOrDefault();

        //    if (rec != null)
        //    {
        //        AltaReciboRestModel.ReciboRM = Mapper.Map<Recibo, ReciboRestModel>(rec);
        //        if (tran.GrupoTransmision != null)
        //        {
        //            List<Transmision> trans = bl.Get<Transmision>(EmpresaID, t => t.GrupoTransmision == tran.GrupoTransmision
        //                                                          && t.TransmisionID != tran.TransmisionID
        //                                                          && t.OperacionID != bl.pGlob.TransImputacionCC.OperacionID).ToList();
        //            if (trans != null && trans.Count() >= 0)
        //            {
        //                foreach (Transmision t in trans)
        //                {
        //                    if (t.OperacionID == bl.pGlob.TransAltaTransDep.OperacionID)
        //                    {
        //                        AltaTransDepRestModel atdrm = tatd.DatosAltaTransDep(bl, t);
        //                        AltaReciboRestModel.AltaTranDepRM = atdrm;
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    return await this.PostConCC<AltaReciboRestModel>(bl, tran, AltaReciboRestModel);
        //}
    }
}
