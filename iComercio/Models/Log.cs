using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iComercio.Models
{
    public class Log
    {
        public long LogID {get;set;}
        public DateTime Fecha { get; set; }
        public string Usuario { get; set; }
        public string Host { get; set; }
        public string Mens { get; set; }
        public string Tipo { get; set; }

        public String sLog 
        {
            get
            {
                return String.Format("{0}|{1}|{2}|{3}", LogID, Fecha, Mens, Usuario, Host);
            }
            set { ;}
        }
        
    }
}
