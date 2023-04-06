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
    public partial class FrmUsuario : FRM
    {
        private Usuario usu;
        public FrmUsuario()
        {
            InitializeComponent();
        }

        public FrmUsuario(Principal p,BusinessLayer bl, Usuario usu):base (p,bl)
        {
            InitializeComponent();
            CargarUsuario(usu);
        }

        private void CargarUsuario(Usuario usu)
        {
            this.usu = bl.GetUsuarioByID(usu.UsuarioID);
        }

        private void FrmUsuario_Load(object sender, EventArgs e)
        {
            usuarioBindingSource.DataSource = usu;
        }

        private void btnModificarPass_Click(object sender, EventArgs e)
        {
            FrmModificarPass frmModPass = new FrmModificarPass(p,bl, usu);
            frmModPass.ShowDialog();
            //CargarUsuario();
            

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CerrarConMensajeDeAdvertencia();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            bl.ActualizarUsuario(usu);
            CerrarConConfirmacion();
        }

        private void activoCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
