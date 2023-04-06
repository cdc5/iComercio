using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iComercio.Models
{
    public class Empleado
    {
        public int? EmpleadoID { get; set; }
        public string Legajo { get; set; }
        
        public int? Usuarioid { get; set; }
        public virtual Usuario Usuario { get; set; }
                
        public string Domicilio { get; set; }
        public decimal? Sueldo { get; set; }
        public string Fotografia { get; set; }
        public string Mail { get; set; }
        public string Tel { get; set; }

        public int? DepartamentoID { get; set; }
        public virtual Departamento Departamento { get; set; }
        
        public int? EmpresaID { get; set; }
        public virtual Empresa Empresa { get; set; }

        public int? ComercioID { get; set; }
        public Comercio Comercio { get; set; }

        public int? CargoID { get; set; }
        public Cargo Cargo { get; set; }
                
        public int? EstadoId { get; set; }
        public Estado Estado { get; set; }

        public int? PersonaID { get; set; }
        public Persona Persona { get; set; }

        public int? TipoEmpleadoID { get; set; }
        public TipoEmpleado TipoEmpleado { get; set; }

    }
}
