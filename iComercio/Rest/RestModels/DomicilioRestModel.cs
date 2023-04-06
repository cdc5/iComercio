using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iComercio.Models;
using iComercio.DAL;
using iComercio.Auxiliar;

namespace iComercio.Rest.RestModels
{
    public class DomicilioRestModel
    {
        public int DomicilioID { get; set; }
        public string Direccion { get; set; }
        public string Numero { get; set; }
        public string Piso { get; set; }
        public string Departamento { get; set; }
        public string Complemento { get; set; }
        public string NotasDomicilio { get; set; } //En este campo se almacenará el campo domicilio proveniente de la base anterior, y cuando sea un registro del sistema nuevo cualquier otra nota accesoria
        public int? LocalidadID { get; set; }
        public int? ProvinciaID { get; set; }
        public int? PaisId { get; set; }
                
        public int ClaseDatoID { get; set; }

        public int EstadoID { get; set; }

        public int? EmpresaID { get; set; }
        public int? ComercioID { get; set; }
        public int Documento { get; set; }
        public string TipoDocumentoID { get; set; }

        public DateTime Fecha { get; set; }
        public int UsuarioID { get; set; } //usuario

        public string PcComer { get; set; } //PC_comer
        public string LocalidadCP { get; set; }
        
    }
}
