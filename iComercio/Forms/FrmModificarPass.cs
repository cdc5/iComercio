using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iComercio.Models;

namespace iComercio.Forms
{
    public partial class FrmModificarPass : FRM
    {
        private Usuario usu;
        public FrmModificarPass()
        {
            InitializeComponent();
        }
        
        public FrmModificarPass(Principal p,BusinessLayer bl, Usuario usu): base(p,bl)
        {
            InitializeComponent();
            this.usu = bl.GetUsuarioByID(usu.UsuarioID);
        }

        private void ModificarPass_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CerrarConMensajeDeAdvertencia();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (txtNuevoPass.Text == txtRepetirPass.Text)
            {
                usu.pass = txtNuevoPass.Text;
                bl.ActualizarUsuario(usu);
                CerrarConConfirmacion();
            }
            else
            {
                MessageBox.Show(Properties.Resources.ContraseñasNoCoinciden,Properties.Resources.Error,
                                MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
