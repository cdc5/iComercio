using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iComercio.Models
{
    class Validar
    {
            public static void SoloNumeros(KeyPressEventArgs pE)
            {
                if (char.IsDigit(pE.KeyChar))
                {
                    pE.Handled = false;
                }
                else if (char.IsControl(pE.KeyChar))
                {
                    pE.Handled = false;
                }
                else
                {
                    pE.Handled = true;
                }
            }

            public static void SoloMoneda(KeyPressEventArgs pE)
            {
                if (char.IsDigit(pE.KeyChar))
                {
                    pE.Handled = false;
                }
                else if (pE.KeyChar.Equals('.') || pE.KeyChar.Equals(','))
                {
                    pE.KeyChar = ',';
                    pE.Handled = false;
                }
                else if (char.IsControl(pE.KeyChar))
                {
                    pE.Handled = false;
                }
                else
                {
                    pE.Handled = true;
                }
            }


            public static void SoloLetras(KeyPressEventArgs pE)
            {
                if (Char.IsLetter(pE.KeyChar))
                {
                    pE.Handled = false;
                }
                else if (Char.IsControl(pE.KeyChar))
                {
                    pE.Handled = false;
                }
                else if (Char.IsSeparator(pE.KeyChar))
                {
                    pE.Handled = false;
                }
                else
                {
                    pE.Handled = true;
                }
            }
    }
}
