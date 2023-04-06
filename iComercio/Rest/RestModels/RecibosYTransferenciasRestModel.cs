using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iComercio.Rest.RestModels
{
    public class RecibosYTransferenciasRestModel
    {
        public List<TransferenciasDepositosRestModel> TdRm { get; set; }
        public List<ReciboRestModel> Rrm { get; set; }
    }
}
