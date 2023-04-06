using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iComercio.Models
{
    public class PlanesVenci
    {
        public string PlanesVenciID { get; set; }           //pasar a int

        public string PlanesTipoID { get; set; }         // cambiar PlanesTipoID

        // va nro de comercio????
        // va nro de empresa????


        public bool CambiaFecha { get; set; }           // si permite cambiar la fecha del primer vencimiento
        // esto anula todos los demas campos

        public int DiasPrimerCuota { get; set; }        // 30=un mes (default) 60=dos meses etc.

        public string TipoVencimiento { get; set; }     // * = VenciDia
        // "" = mes calendario (max(dia 28)
        // A1
        // A2
        // A3
        // Z


        public int VenciDia { get; set; }               // dia por default  10
        public int VenciCorte { get; set; }             // si el dia es menor al corte se pasa al mes siguiente
        // 20 por default

        public int Corte1 { get; set; }
        public int VenDia1 { get; set; }
        public int Corte2 { get; set; }
        public int Vendia2 { get; set; }
        public int Vendia3 { get; set; }


        public DateTime FechaAlta { get; set; }
        public DateTime FechaVenci { get; set; }        // no se si hace falta
        public int UsuarioID { get; set; }

        public virtual Usuario Usuario { get; set; } //Usuario
        public string UsuarioPC { get; set; }  
    }
}
