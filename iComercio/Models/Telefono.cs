using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iComercio.Models
{
    public class Telefono
    {
        public int TelefonoID { get; set; }
        public string CodArea { get; set; }
        public string Numero { get; set; }
        public bool? esCelular { get; set; }
        public int EstadoID  {get; set; }
        public Estado Estado { get; set; }
        public int ClaseDatoID { get; set; }
        public ClaseDato ClaseDato { get; set; }
        public int Documento { get; set; }
        public string TipoDocumentoID { get; set; }
        public Cliente Cliente { get; set; }
        public int? EmpresaID { get; set; }
        public int? ComercioID { get; set; }
        public DateTime Fecha { get; set; }
        public string Nota { get; set; }
        public int? UsuarioID { get; set; } //usuario
        public virtual Usuario Usuario { get; set; } //Usuario
        public string PcComer { get; set; } //PC_comer

        public string TelefonoCompleto
        {
            get { return string.Format("{0} {1}", CodArea, Numero); }
            set { ;}
        }
        
    }
}
