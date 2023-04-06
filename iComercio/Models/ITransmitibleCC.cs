using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iComercio.Rest.RestModels;

namespace iComercio.Models
{
    public interface ITransmitibleCC:ITransmitible
    {
        ImputacionCuentaCorrienteRestModel ImputacionCC { get; set; }
        void ApiActualizarCCDesdeRemoto(BusinessLayer bl, ImputacionCuentaCorrienteRestModel iccRM);
    }
}
