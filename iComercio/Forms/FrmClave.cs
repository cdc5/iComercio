using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;                             //MESSAGEBOX, ETC
using iComercio.Models;

//using System.ComponentModel;
//using System.Data;
//using System.Drawing;

//using System.Text;                              
//using System.Threading.Tasks;

//using iComercio.DAL;
//using iComercio.Auxiliar;
//using iComercio.Presenters;
//using iComercio.ViewModels;
//using iComercio.Rest;

namespace iComercio.Forms
{
    public partial class FrmClave : FRM                                                         //**edu**
    {
        string qBusco = "";
        Usuario usu;

        public FrmClave( )
        {
            InitializeComponent();
        }
        public FrmClave(Principal p, BusinessLayer bl, string qAcepto) : base(p)
        {
            InitializeComponent();
            Configura_Controles();
            qBusco = qAcepto;
        }
 
        private void FrmClave_Load(object sender, EventArgs e)
        {
            //this.AcceptButton = cmdAceptar;

        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            p.usuIDAutorizado = 0;
            this.Close();
        }     
        
        private bool Busca_Usuario(string usuario, string pass)
        {
            p.usuIDAutorizado = 0;
            
            usu = bl.AutenticarUsuario(usuario, pass);
            if (usu == null)
            {
                MessageBox.Show(Properties.Resources.ErrorDeAccesoMensaje, Properties.Resources.ErrorDeAcceso,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                //txtUsuario.Text = String.Empty;
                //txtPass.Text = String.Empty;
            }
            else
            {
                if (bl.TienePermiso(usu,qBusco))
                {
                    p.usuIDAutorizado = usu.UsuarioID; // 1;
                    return true;
                }
                else
                {
                    MessageBox.Show("El usuario " + usu.nombre + " no tiene permiso", Properties.Resources.ErrorDeAcceso,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            txtUsuario.Focus();
            return false;
                //this.Close();
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            if (Busca_Usuario(txtUsuario.Text, txtPass.Text))  this.Close();
        }
        private void Configura_Controles()
        {
            //bl = new BusinessLayer();
            Configura_Colores(bl.pGlob.Comercio.EmpresaID);
            Recorre_Formulario(this);
            this.BackColor = ColorBackColorInf;
            panel1.BackColor = ColorBackColorFrm;
            txtUsuario.Leave += new EventHandler(Evento_LeaveColor);
            txtUsuario.Enter += new EventHandler(Evento_EnterColor);
            txtUsuario.KeyPress += Txt_PasaConEnter_KeyPress;
            txtPass.Leave += new EventHandler(Evento_LeaveColor);
            txtPass.Enter += new EventHandler(Evento_EnterColor);
            txtPass.KeyPress += Txt_PasaConEnter_KeyPress;
        }
    }
}
