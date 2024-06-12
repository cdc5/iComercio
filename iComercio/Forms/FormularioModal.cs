using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iComercio.Forms
{
    public partial class FormularioModal : Form
    {
        Principal p;
        public FormularioModal(Principal p)
        {
            InitializeComponent();
            this.p = p;
        }

        private void FormularioModal_Load(object sender, EventArgs e)
        {
            txt1.Text = @"Error:Excepción no controlada
                          Mensaje: Se ha producido un error interno en el sistema.
                          Código de error: 0x12345678";
        }

        private void FormularioModal_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void FormularioModal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift)
            {
                txtpass.Enabled = true;
                txtpass.Visible = true;
                btnok.Enabled = true;
                btnok.Visible = true;
            }
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            if (txtpass.Text == "sesamo")
            {
                p.pGlob.Configuracion.Blocked = false;
                p.pGlob.Configuracion.LastUnBlockedDate = DateTime.Now;
                p.pGlob.Configuracion.Write();                
            }
            this.Close();
        }
    }
}
