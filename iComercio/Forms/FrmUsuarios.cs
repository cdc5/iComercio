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
    public partial class FrmUsuarios : FRM
    {
        BindingSource usuarioBindingSource;

        public FrmUsuarios()
        {
            InitializeComponent();
        }

        public FrmUsuarios(Principal p, RestApi ra)
            : base(p, ra)
        {
            InitializeComponent();
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            usuarioBindingSource = new BindingSource();
            CustomizeGrid(dgvUsuarios);
            Actualizar();
            
        }

        private void CustomizeGrid(DataGridView dgv)
        {
            CustomizeColumns(dgv);
        }

        private void CustomizeColumns(DataGridView dgv)
        {
             dgv.AutoGenerateColumns = false;
        }



        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CerrarConConfirmacion();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            bl.Grabar();
        }

        private void dgvUsuarios_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Usuario usu = (Usuario)dgvUsuarios.Rows[e.RowIndex].DataBoundItem;
            if (usu != null)
            {
                FrmUsuario frmUsuario = new FrmUsuario(p, bl, usu);
                frmUsuario.ShowDialog();
                Actualizar();
            }
            
        }

        private void Actualizar()
        {
            //usuarioBindingSource.DataSource = null;
            //usuarioBindingSource.ResetBindings(false);
            usuarioBindingSource.DataSource = bl.UsuarioBindingList();
            dgvUsuarios.DataSource = usuarioBindingSource;
            dgvUsuarios.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvUsuarios_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            bl.Grabar();
        }

        private void dgvUsuarios_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[4].Value = DateTime.Now.Date;
        }

    }
}
