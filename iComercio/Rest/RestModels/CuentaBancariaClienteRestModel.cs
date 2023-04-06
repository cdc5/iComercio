using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iComercio.Models;
using iComercio.DAL;
using iComercio.Auxiliar;

namespace iComercio.Rest.RestModels
{
    public class CuentaBancariaClienteRestModel
    {
        public int Documento { get; set; }
        public string TipoDocumentoID { get; set; }
        public string NumCuentaBancaria { get; set; }
        public string CBU { get; set; }
        public string Alias { get; set; }
        public string Descripcion { get; set; }
        public string Notas { get; set; }
        public DateTime? FechaAlta { get; set; }
        public int? SucursalBancoID { get; set; }
        public int? BancoID { get; set; }
        public int? MonedaID { get; set; }
        public int? EstadoID { get; set; }
    }
}
