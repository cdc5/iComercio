using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iComercio.Models
{
    public class Comercio
    {
        public int ComercioID { get; set; }

        public int EmpresaID { get; set; }
        public virtual Empresa Empresa { get; set; }
        
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Domicilio { get; set; }
        public string Barrio { get; set; }
        
        public int? TipoComercioID { get; set; }
        public virtual TipoComercio TipoComercio { get; set; }
            
        public int? LocalidadID { get; set; }
        public Localidad Localidad { get; set; } //locId,proId,paiId

        public int? ProvinciaID { get; set; }
        public virtual Provincia Provincia { get; set; } // provincia,pais
        
        public int? PaisId { get; set; }
        public virtual Pais Pais { get; set; }  //pais id
        

        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public int? Recorrido { get; set; }
        public string Cuit { get; set; }
        public string Mail1 { get; set; }
        public string Mail2 { get; set; }
        public string CodPromo { get; set; }
        public decimal? PorPromo { get; set; }
        public bool? PagaBanco { get; set; }
        public int? Venci { get; set; }
        public int? Corte { get; set; }
        public bool? Habilitado { get; set; }
        public decimal? Por30 { get; set; }
        public decimal? Por30M { get; set; }
        public string Clave { get; set; }
        public bool? Compu { get; set; }
        public string Fanta { get; set; }
        public string Categoria { get; set; }
        public int? Tolerancia { get; set; }
        public int? NumCredito { get; set; }
        public int? NumCliente { get; set; }
        public int? NumRendi { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public DateTime? FechaPRendi { get; set; }
        public int? Contacto1ID { get; set; }
        public virtual Persona Contacto1 { get; set; } // provincia,pais
        public int? Contacto2ID { get; set; }
        public virtual Persona Contacto2 { get; set; } // provincia,pais
        public int? Titular1ID { get; set; }
        public virtual Persona Titular1 { get; set; } // provincia,pais
        public int? Titular2ID { get; set; }
        public virtual Persona Titular2 { get; set; } // provincia,pais
        public string Rubro { get; set; }
        public int? CanLoc { get; set; }
        public int? CanPer { get; set; }
        public int? CanVid { get; set; }
        public string CtaDep { get; set; }
        public string ForPag { get; set; }
        public string OrdCheq { get; set; }
        public string PerFinan { get; set; }
        public int? LlevaGar { get; set; }
        public string Notas { get; set; }
        public int? Cuenta { get; set; }
        public decimal? CredPri { get; set; }
        public decimal? CredSeg { get; set; }
        public int? Consolid { get; set; }
        public bool? Trab { get; set; }
        public bool? Refinancia { get; set; }
        public decimal? IntRef { get; set; }
        public decimal? IntAde { get; set; }
        public decimal? IntArr { get; set; }
        public int? CantCuoArr { get; set; }
        public decimal? PorSueldo { get; set; }
        public bool? Llp { get; set; }
        public bool? Pm { get; set; }
        public decimal? ImpCi { get; set; }
        public DateTime? FechaCi { get; set; }
        public decimal? ImpCiVta { get; set; }
        public DateTime? CiVtaFecha { get; set; }

        public bool Principal { get; set; }                      
        public bool PuedeCobrar { get; set; }                   
        public bool? Actualiza { get; set; }

        public int? ToleranciaBoni { get; set; }

        public string NumeroYNombre { get { return GetNumeroYNombre(); } set { ;} }
     
        private string GetNumeroYNombre()
        {
            return string.Format("{0}-{1}", ComercioID, Nombre);
        }
        public override string ToString()
        {
            return Nombre;
        }
        
        
    }
}
