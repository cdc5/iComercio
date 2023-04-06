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
    public partial class FrmAsignarPermisos : FRM
    {
        BindingSource perfilBindingSource;
        BindingSource permisoBindingSource = new BindingSource();
        BindingSource permisoAsigBindingSource;
        Perfil per;

        public FrmAsignarPermisos()
        {
            InitializeComponent();
        }

        public FrmAsignarPermisos(Principal p,BusinessLayer bl, RestApi ra)
            : base(p,bl, ra)
        {
            InitializeComponent();            

        }



        private void FrmAsignarPermisos_Load(object sender, EventArgs e)
        {
            perfilBindingSource = new BindingSource();
            perfilBindingSource.DataSource = bl.GetPerfiles(null, null, "Permisos");
            dgvPerfiles.DataSource = perfilBindingSource;
            permisoAsigBindingSource = new BindingSource(perfilBindingSource, "Permisos");
            lbPermisosAsig.DataSource = permisoAsigBindingSource;
            lbPermisosAsig.DisplayMember = "descripcion";
        }

        private void btnAsignarPerfil_Click(object sender, EventArgs e)
        {
            Permiso perm = (Permiso)lbPermisos.SelectedItem;
            bl.AsignarPermisoAPerfil(per,perm);
            permisoBindingSource.RemoveCurrent();
            permisoBindingSource.ResetBindings(false);
            permisoAsigBindingSource.ResetBindings(false);
        }

        private void dgvPerfiles_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            per = (Perfil)dgvPerfiles.Rows[e.RowIndex].DataBoundItem;
            permisoBindingSource.DataSource = bl.GetPermisosPosiblesParaAsignar(per);
            lbPermisos.DataSource = permisoBindingSource;
            lbPermisos.DisplayMember = "descripcion";
        }

        private void btnQuitarPerfil_Click(object sender, EventArgs e)
        {
            Permiso perm = (Permiso)lbPermisosAsig.SelectedItem;
            bl.QuitarPermisoAPerfil(per, perm);
            permisoBindingSource.Add(perm);
            permisoBindingSource.ResetBindings(false);
            permisoAsigBindingSource.ResetBindings(false);
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            bl.Grabar();
            p.CargarPermisos(p.usu);
            CerrarConConfirmacion();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CerrarConMensajeDeAdvertencia();
        }
    }
}
