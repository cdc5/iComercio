using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iComercio.Rest.RestModels;
using AutoMapper;
using iComercio.Rest.RestModels;
using AutoMapper;

namespace iComercio.Models
{
    class TransBajaFF:Operacion
    {
        public TransBajaFF()
            {
            }


        public TransBajaFF(int OperacionID, string Nombre, string Descripcion) :
                base(OperacionID, Nombre, Descripcion)
            {

            }

            public async override Task<bool> Enviar(BusinessLayer bl, Transmision tran)
            {
                EnvioFFRestModel aFFrm = DatosBajaFF(bl, tran);
                return await this.DeleteConCC<EnvioFFRestModel>(bl, tran, aFFrm);
            }

            public EnvioFFRestModel DatosBajaFF(BusinessLayer bl, Transmision tran)
            {
                int EmpresaID = System.Convert.ToInt32(tran.EmpresaID);
                int ComercioID = System.Convert.ToInt32(tran.ComercioID);
                int FFID = System.Convert.ToInt32(tran.EntidadID);

                FF ff = bl.Get<FF>(EmpresaID, c => c.FFID == FFID && c.EmpresaID == EmpresaID && c.ComercioID == ComercioID).FirstOrDefault();
                FFRestModel ffRm = Mapper.Map<FF, FFRestModel>(ff);
                EnvioFFRestModel effRm = new EnvioFFRestModel(ffRm, null);
                return effRm;
            }
    }
}
