using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iComercio.Rest.RestModels;
using AutoMapper;
using System.Threading.Tasks;

namespace iComercio.Models
{
    public class TransImputacionCC:Operacion
    {
        public TransImputacionCC() 
        {

        }

        public TransImputacionCC(int OperacionID, string Nombre, string Descripcion) :
                                     base(OperacionID,Nombre,Descripcion)
         {
           
         }

        public ImputacionCuentaCorrienteRestModel DatosImputacionCuentaCorriente(BusinessLayer bl, Transmision tran)
        {
            int EmpresaID;
            int ComercioID;
            int CuentaCorrienteID;
            CuentaCorriente c;
            CuentaCorrienteRestModel ccrm;
            ImputacionCuentaCorrienteRestModel iccrm = new ImputacionCuentaCorrienteRestModel();
           
            if (tran.GrupoTransmision != null)
            {
                //List<Transmision> trans = bl.Get<Transmision>(t => t.GrupoTransmision == tran.GrupoTransmision
                //                                             && t.OperacionID == bl.pGlob.TransImputacionCC.OperacionID).ToList();

                List<Transmision> trans = bl.Get<Transmision>(tran.EmpresaID, t => t.GrupoTransmision == tran.GrupoTransmision 
                                                            && t.OperacionID == bl.pGlob.TransImputacionCC.OperacionID).ToList();

                if (trans != null && trans.Count() >= 0)
                {
                    foreach (Transmision t in trans)
                    {
                        EmpresaID = System.Convert.ToInt32(t.EntidadID);
                        ComercioID = System.Convert.ToInt32(t.EntidadID2);
                        CuentaCorrienteID = System.Convert.ToInt32(t.EntidadID3);
                        c = bl.Get<CuentaCorriente>(EmpresaID,cc => cc.EmpresaID == EmpresaID && cc.ComercioID == ComercioID && cc.CuentaCorrienteID == CuentaCorrienteID).SingleOrDefault();
                        if (c != null)
                        {
                            ccrm = Mapper.Map<CuentaCorriente, CuentaCorrienteRestModel>(c);
                            iccrm.MovimientosCC.Add(ccrm);
                        }                           
                    }

                }
            }
            return iccrm;            
        }

        public async override Task<bool> Enviar(BusinessLayer bl, Transmision tran)
        {
            return false;
        }    

    }

   
}
