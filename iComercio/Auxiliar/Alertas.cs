using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iComercio.Auxiliar
{
    public class Alertas
    {
        public static bool AlertaDeEliminacion()
        {
            DialogResult res = MessageBox.Show( Properties.Resources.SeEliminaraElRegistro,Properties.Resources.AlertaDeEliminación, MessageBoxButtons.OKCancel);
            if (res == DialogResult.OK)
                return true;
            else
                return false;

        }

        public static bool AlertaDeEliminacion(string QueQueresDecir)
        {
            DialogResult res = MessageBox.Show(  QueQueresDecir, Properties.Resources.AlertaDeEliminación, MessageBoxButtons.OKCancel);
            if (res == DialogResult.OK)
                return true;
            else
                return false;

        }


        public static void MensajeOKOnly(string titulo,string Mensaje)
        {
            MessageBox.Show(Mensaje, titulo, MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
            
    }
}
