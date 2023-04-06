using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iComercio.Rest.RestModels;
using AutoMapper;


namespace iComercio.Models
{
    public class TransAltaArregloCancelacion:Operacion
    {
        public TransAltaArregloCancelacion()             
         {
         }


        public TransAltaArregloCancelacion(int OperacionID, string Nombre, string Descripcion) :
                                     base(OperacionID,Nombre,Descripcion)
         {
           
         }

         public async override Task<bool> Enviar(BusinessLayer bl, Transmision tran)
         {
             AltaArregloCancelacionRestModel AltaArregloCobranzaRestModelRM = new AltaArregloCancelacionRestModel();
             CobranzaRestModel crm;
             Cobranza cob;
             
             int EmpresaID;
             int ComercioID;
             int CreditoID;
             int CuotaID;
             int CobranzaID;

             TransAltaCobranza tacob = new TransAltaCobranza();

             List<Transmision> trans = bl.Get<Transmision>(tran.EmpresaID, t => t.GrupoTransmision == tran.GrupoTransmision).ToList();
             foreach (Transmision t in trans)
             {
                 if (t.OperacionID == bl.pGlob.TransAltaCobranza.OperacionID)
                 {
                     AltaCobranzaRestModel acrm = tacob.DatosAltaCobranza(bl, t);
                     AltaArregloCobranzaRestModelRM.CobranzasRM.Add(acrm);
                 }   
             }
             return await this.PostConCC<AltaArregloCancelacionRestModel>(bl, tran, AltaArregloCobranzaRestModelRM);
         }       
    }
}
