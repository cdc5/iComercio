using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iComercio.Models;
using iComercio.DAL;
using iComercio.Auxiliar;

namespace iComercio.Rest.RestModels
{
    public class TelefonoRestModel
    {
        public int TelefonoID { get; set; }
        public string CodArea { get; set; }
        public string Numero { get; set; }
        public bool? esCelular { get; set; }
        public int EstadoID { get; set; }
        public int ClaseDatoID { get; set; }
        public int Documento { get; set; }
        public string TipoDocumentoID { get; set; }
        public int? EmpresaID { get; set; }
        public int? ComercioID { get; set; }
        public DateTime Fecha { get; set; }
        public string Nota { get; set; }
        public int? UsuarioID { get; set; } //usuario
        public string PcComer { get; set; } //PC_comer
    }
}
