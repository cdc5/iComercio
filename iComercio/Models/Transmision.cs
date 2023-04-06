using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iComercio.Models
{
   public class Transmision
    {
         public long TransmisionID { get; set; }
         public int OperacionID { get; set; }
         public virtual Operacion Operacion { get; set; } // La operación dictamina que hacer y si buscar entidad 
         public int EstadoTransmisionID { get; set; }
         public virtual EstadoTransmision EstadoTransmision { get; set; } // Es el estado de la transmisión, Enviado, Pendiente
        /* Estos campos son para saber a que entidad ir a buscar para enviar en caso 
         * de ser necesatio, por ejemplo una solicitud de fondo tiene empresa, comercio e
         * ID de solicitud de fondo, mas adelante podrían haber mas */

         public int EmpresaID { get; set; }
         public virtual Empresa Empresa { get; set; }
         public int ComercioID { get; set; }
         public virtual Comercio Comercio { get; set; }
         public string EntidadID { get; set; }
         public string EntidadID2 { get; set; }
         public string EntidadID3 { get; set; }
         public string EntidadID4 { get; set; }
         public string EntidadID5 { get; set; }
         public string EntidadID6 { get; set; }
         public string EntidadID7 { get; set; }
         public DateTime Fecha { get; set; }
         public string[] Claves { get; set; }
         public string RutaApi { get; set; }
         public int? GrupoTransmision { get; set; }
         public int? CantTransmisiones { get; set; }
         public DateTime? UltimaTransmision{ get; set; }
         
         


         public Transmision()
         {
             
         }

        public string[] GetClaves()
         {
             string[] claves = null;
             if (EntidadID != null && EntidadID != string.Empty)
             {   
                 claves = new string[]{EntidadID};
             }

             if (EntidadID2 != null && EntidadID2 != string.Empty)
             {
                claves = new string[] {EntidadID,EntidadID2};
             }

             if (EntidadID3 != null && EntidadID3 != string.Empty)
             {
                 claves = new string[] { EntidadID, EntidadID2,EntidadID3 };
             }

             if (EntidadID4 != null && EntidadID4 != string.Empty)
             {
                 claves = new string[] { EntidadID, EntidadID2, EntidadID3, EntidadID4};
             }

             if (EntidadID5 != null && EntidadID5 != string.Empty)
             {
                 claves = new string[] { EntidadID, EntidadID2, EntidadID3, EntidadID4, EntidadID5};
             }

             if (EntidadID6 != null && EntidadID6 != string.Empty)
             {
                 claves = new string[] { EntidadID, EntidadID2, EntidadID3, EntidadID4, EntidadID5, EntidadID6};
             }
             
             if (EntidadID7 != null && EntidadID7 != string.Empty)
             {
                 claves = new string[] { EntidadID, EntidadID2, EntidadID3, EntidadID4, EntidadID5, EntidadID6, EntidadID7 };
             }
            return claves;
         }
 

         public Transmision(InfoTransmision infoTransmision)
         {
             this.EmpresaID = infoTransmision.Comercio.EmpresaID;
             this.ComercioID = infoTransmision.Comercio.ComercioID;
             this.OperacionID = infoTransmision.Operacion.OperacionID;
             this.EstadoTransmisionID = infoTransmision.EstadoTransmision.EstadoTransmisionID;;
             this.Fecha = DateTime.Now;
             this.RutaApi = infoTransmision.RutaApi;
             Claves = infoTransmision.Claves;
             if (Claves != null)
             {
                 if (Claves.Count() > 0) EntidadID = Claves[0];
                 if (Claves.Count() > 1) EntidadID2 = Claves[1];
                 if (Claves.Count() > 2) EntidadID3 = Claves[2];
                 if (Claves.Count() > 3) EntidadID4 = Claves[3];
                 if (Claves.Count() > 4) EntidadID5 = Claves[4];
                 if (Claves.Count() > 5) EntidadID6 = Claves[5];
                 if (Claves.Count() > 6) EntidadID7 = Claves[6];
             }
         }

       public Transmision(Empresa Empresa, Comercio Comercio,Operacion Operacion, EstadoTransmision EstadoTransmision,string EntidadID,DateTime Fecha)
         {
             this.EmpresaID = Empresa.EmpresaID.Value;
             this.Empresa = Empresa;
             this.Comercio = Comercio;
             this.ComercioID = Comercio.ComercioID;
             this.OperacionID = Operacion.OperacionID;
             this.EstadoTransmisionID = EstadoTransmision.EstadoTransmisionID;
             this.EntidadID = EntidadID;
             this.Fecha = Fecha;
             this.CantTransmisiones = 0;
         }

       public Transmision(Empresa Empresa, Comercio Comercio, Operacion Operacion, EstadoTransmision EstadoTransmision, string EntidadID, string EntidadID2, DateTime Fecha)
       {
           this.EmpresaID = Empresa.EmpresaID.Value;
           this.Empresa = Empresa;
           this.Comercio = Comercio;
           this.ComercioID = Comercio.ComercioID;
           this.OperacionID = Operacion.OperacionID;
           this.EstadoTransmisionID = EstadoTransmision.EstadoTransmisionID;
           this.EntidadID = EntidadID;
           this.EntidadID2 = EntidadID2;
           this.Fecha = Fecha;
           this.CantTransmisiones = 0;
       }

       public Transmision(Empresa Empresa, Comercio Comercio, Operacion Operacion, EstadoTransmision EstadoTransmision, string EntidadID, string EntidadID2, string EntidadID3, DateTime Fecha)
       {
           this.EmpresaID = Empresa.EmpresaID.Value;
           this.Empresa = Empresa;
           this.Comercio = Comercio;
           this.ComercioID = Comercio.ComercioID;
           this.OperacionID = Operacion.OperacionID;
           this.EstadoTransmisionID = EstadoTransmision.EstadoTransmisionID;
           this.EntidadID = EntidadID;
           this.EntidadID2 = EntidadID2;
           this.EntidadID3 = EntidadID3;
           this.Fecha = Fecha;
           this.CantTransmisiones = 0;
       }


    }
}
