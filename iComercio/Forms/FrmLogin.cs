using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iComercio.Models;
using iComercio.DAL;
using iComercio.Auxiliar;
using iComercio.Presenters;
using iComercio.ViewModels;
using iComercio.Rest;

namespace iComercio.Forms
{
    public partial class FrmLogin : FRM
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        public FrmLogin(Principal p):base(p)
        {
            InitializeComponent();
            if (Console.CapsLock) lblCap.Visible = true; else lblCap.Visible = false;
            // ConfigurarSkin();
        }
        
        private void ConfigurarSkin()
        {
            Configura_Colores(bl.pGlob.Comercio.EmpresaID);
            Recorre_Formulario(this);           
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            this.AcceptButton = cmdAceptar;
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            AutenticarUsuario(txtUsuario.Text, txtPass.Text);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            p.usu = null;
            this.Close();
        }

        private void AutenticarUsuario(string usuario,string pass)
        {
            Usuario usu = bl.AutenticarUsuario(usuario,pass);
            if (usu == null)
            {
                MessageBox.Show(Properties.Resources.ErrorDeAccesoMensaje, Properties.Resources.ErrorDeAcceso,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsuario.Text = String.Empty;
                txtPass.Text = String.Empty;
            }
            else
            {
                p.usu = usu;
                this.Close();
            }
            
        }

        private void FrmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (Console.CapsLock) lblCap.Visible = true; else lblCap.Visible = false;
        }
    }
}
