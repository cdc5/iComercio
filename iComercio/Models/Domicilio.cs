using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iComercio.Models
{
    public class Domicilio
    {
        public int DomicilioID { get; set; }
        public string Direccion { get; set; }
        public string Numero { get; set; }
        public string Piso { get; set; }
        public string Departamento { get; set; }
        public string Complemento { get; set; }
        public string NotasDomicilio { get; set; } //En este campo se almacenará el campo domicilio proveniente de la base anterior, y cuando sea un registro del sistema nuevo cualquier otra nota accesoria
        
        public int? LocalidadID { get; set; }
        public virtual Localidad Localidad { get; set; }
        //***edu
        public int? ProvinciaID { get; set; }
        public virtual Provincia Provincia { get; set; } // provincia,pais

        public int? PaisId { get; set; }
        public virtual Pais Pais { get; set; }  //pais id
        //***edu

        public int ClaseDatoID { get; set; }
        public virtual ClaseDato ClaseDato { get; set; }
        public int EstadoID { get; set; }
        public virtual Estado Estado { get; set; }

        public int? EmpresaID { get; set; }
        public int? ComercioID { get; set; }
        public int Documento { get; set; }
        public string TipoDocumentoID { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime Fecha { get; set; }
        public int UsuarioID { get; set; } //usuario
        public virtual Usuario Usuario { get; set; } //Usuario
        public string PcComer { get; set; } //PC_comer

        public string DomicilioCompleto
        {
            get 
            {
                string dir = "";
                string num = "";
                string pis = "";
                string dep = "";
               
                if (Direccion != null)
                {
                    dir = Direccion;
                }
                if (Numero != null)
                {
                    num = Numero;
                }
                if (Piso != null)
                {
                    pis = Piso;
                }
                if (Departamento != null)
                {
                    dep = Departamento;
                }
                return string.Format("{0} {1} {2} {3}", Direccion, Numero, Piso, Departamento); 
            }
            set { ;}
        }
        
    }
}
