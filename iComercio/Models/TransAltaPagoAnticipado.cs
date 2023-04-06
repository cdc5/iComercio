using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iComercio.Rest.RestModels;
using AutoMapper;

namespace iComercio.Models
{
    public class TransAltaPagoAnticipado : Operacion
    {
        public TransAltaPagoAnticipado()             
         {
         }


        public TransAltaPagoAnticipado(int OperacionID, string Nombre, string Descripcion) :
                                     base(OperacionID,Nombre,Descripcion)
         {
           
         }

         public async override Task<bool> Enviar(BusinessLayer bl, Transmision tran)
         {
             AltaPagoAnticipadoRestModel AltaPagoAnticipadoRestModel = new AltaPagoAnticipadoRestModel();
             CobranzaRestModel crm;
             Cobranza cob;
             NotasCDRestModel ncdrm;
             NotasCD notacd;
             
             int EmpresaID;
             int ComercioID;
             int CreditoID;
             int CuotaID;
             int CobranzaID;
             int NotaCDID;

             TransAltaCobranza tacob = new TransAltaCobranza();

             List<Transmision> trans = bl.Get<Transmision>(tran.EmpresaID, t => t.GrupoTransmision == tran.GrupoTransmision).ToList();
             foreach (Transmision t in trans)
             {
                 if (t.OperacionID == bl.pGlob.TransAltaCobranza.OperacionID)
                 {
                     AltaCobranzaRestModel acrm =  tacob.DatosAltaCobranza(bl, t);
                     AltaPagoAnticipadoRestModel.CobranzasRM.Add(acrm);
                 }
                 else if (t.OperacionID == bl.pGlob.TransPagoAnticipadoNotaCD.OperacionID)
                 {

                     EmpresaID = System.Convert.ToInt32(t.EntidadID);
                     ComercioID = System.Convert.ToInt32(t.EntidadID2);
                     CreditoID = System.Convert.ToInt32(t.EntidadID3);
                     CuotaID = System.Convert.ToInt32(t.EntidadID4);
                     CobranzaID = System.Convert.ToInt32(t.EntidadID5);
                     NotaCDID = System.Convert.ToInt32(t.EntidadID6);

                     notacd = bl.Get<NotasCD>(EmpresaID,c => c.EmpresaID == EmpresaID && c.ComercioID == ComercioID && c.CreditoID == CreditoID
                                           && c.CuotaID == CuotaID && c.CobranzaID == CobranzaID && c.NotaCDID == NotaCDID).SingleOrDefault();
                     ncdrm = Mapper.Map<NotasCD, NotasCDRestModel>(notacd);
                     AltaPagoAnticipadoRestModel.NotasCDRM.Add(ncdrm);
                }
             }
             return await this.PostConCC<AltaPagoAnticipadoRestModel>(bl, tran, AltaPagoAnticipadoRestModel);
         }       

    }
}
