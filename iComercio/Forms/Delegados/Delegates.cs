using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iComercio.Delegados
{
   // public delegate void ActualizarBarraDeEstadoDelegado(string value);

    public delegate void DelegadoDecimal(decimal val);

    public class MensajeEventArgs : EventArgs
    {
        public string mensaje { get; set; }
        public int ValorProgressBar { get; set; }
       
        public MensajeEventArgs(String mens):base()
        {
            mensaje = mens;
        }

        public MensajeEventArgs(int ValorProgressBar)
            : base()
        {
            this.ValorProgressBar = ValorProgressBar;
        }
    }

    


}
