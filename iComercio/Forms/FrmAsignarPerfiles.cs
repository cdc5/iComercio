using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using iComercio.Models;
using iComercio.DAL;
using iComercio.Auxiliar;
using iComercio.Presenters;
using iComercio.ViewModels;
using iComercio.Rest;


namespace iComercio.Forms
{
    public partial class FrmAsignarPerfiles : FRM
    {

        BindingSource usuarioBindingSource;
        BindingSource perfilBindingSource = new BindingSource();
        BindingSource perfilAsigBindingSource;

        Usuario usu;

        public FrmAsignarPerfiles(): base()
        {
            InitializeComponent();
       
            
        }

        public FrmAsignarPerfiles(Principal p, RestApi ra)
            : base(p, ra)
        {
            InitializeComponent();
       
            
        }

        
        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            usuarioBindingSource = new BindingSource();
            usuarioBindingSource.DataSource = bl.GetUsuarios(null, null, "Perfiles");
            dgvUsuarios.DataSource = usuarioBindingSource;
            perfilAsigBindingSource = new BindingSource(usuarioBindingSource, "Perfiles");
            lbPerfilesAsig.DataSource = perfilAsigBindingSource;
            lbPerfilesAsig.DisplayMember = "descripcion";
                      
        }

        private void btnAsignarPerfil_Click(object sender, EventArgs e)
        {
            Perfil per = (Perfil)lbPerfiles.SelectedItem;
            bl.AsignarPerfilAUsuario(usu, per);
            perfilBindingSource.RemoveCurrent();
            
   
        }

        private void dgvUsuarios_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
             usu = (Usuario)dgvUsuarios.Rows[e.RowIndex].DataBoundItem;
             perfilBindingSource.DataSource = bl.GetPerfilesPosiblesParaAsignar(usu);
             lbPerfiles.DataSource = perfilBindingSource;
             lbPerfiles.DisplayMember = "descripcion";
         }

         private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
         {

         }

         private void btnGrabar_Click_1(object sender, EventArgs e)
         {
             bl.Grabar();
             CerrarConConfirmacion();
         }

         private void btnQuitarPerfil_Click(object sender, EventArgs e)
         {
             Perfil per = (Perfil)lbPerfilesAsig.SelectedItem;
             bl.QuitarPerfilAUsuario(usu, per);
             perfilBindingSource.Add(per);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CerrarConMensajeDeAdvertencia();
        }

        private void grbUsuarios_Enter(object sender, EventArgs e)
        {

        }

     
    }
}
