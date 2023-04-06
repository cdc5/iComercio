using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iComercio.Models;

namespace iComercio.Models
{
    public class RecibosYTransferencias
    {
        public List<TransferenciasDepositos> TdRm { get; set; }
        public List<Recibo> Rrm { get; set; }
    }
}
