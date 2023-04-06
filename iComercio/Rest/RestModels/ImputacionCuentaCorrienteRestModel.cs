using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace iComercio.Rest.RestModels
{
    public class ImputacionCuentaCorrienteRestModel
    {
        public List<CuentaCorrienteRestModel> MovimientosCC { get; set; }

        public  ImputacionCuentaCorrienteRestModel()
        {
            MovimientosCC = new List<CuentaCorrienteRestModel>();
        }
    }
}
