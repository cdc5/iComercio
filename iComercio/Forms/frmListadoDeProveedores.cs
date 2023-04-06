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
    public partial class frmListadoDeProveedores : FRM
    {
        public frmListadoDeProveedores()
        {
            InitializeComponent();
        }

        public frmListadoDeProveedores(Principal p):base(p)
        {
            InitializeComponent();
        }

        private void frmListadoDeProveedores_Load(object sender, EventArgs e)
        {
            ActualizarListado();
            LedoyFormaAlGrid();
            cmbBusca.Items.Add("Razón social");
            cmbBusca.Items.Add("Nombre de fantasía");
            cmbBusca.SelectedIndex = 0;
            cmbBusca.Font = new Font("Tahoma", 10, FontStyle.Bold);
            //  this.Width=Principal.

        }
        private void SeleccionoCmb()
        {
            if (cmbBusca.Text == "Razón social")
            {
                dgvProveedores.DataSource = bl.GetProveedores(pro => pro.RazonSocial.ToLower().Contains(txtNombreProv.Text.ToLower()));
            }
            else
            {
                dgvProveedores.DataSource = bl.GetProveedores(pro => pro.NombreFantasia.ToLower().Contains(txtNombreProv.Text.ToLower()));

            }
        }


        private void txtNombreProv_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtNombreProv.Text))
            {
                 ActualizarListado();
            }
            else
            {
                SeleccionoCmb();
            }

        }

        private void ActualizarListado()
        {
            dgvProveedores.AutoGenerateColumns = false;
            if (String.IsNullOrEmpty(txtNombreProv.Text))
            {
                dgvProveedores.DataSource = bl.GetProveedoresActivos();
                //dgvProveedores.DataSource = bl.GetProveedores();
            }
            else
            {
                SeleccionoCmb();
            }
        }

        private void btnNuevoProveedor_Click(object sender, EventArgs e)
        {
            frmABMProveedores frmABMP = new frmABMProveedores(p,this.bl);
            frmABMP.ShowDialog();
            ActualizarListado();
            
        }

        private void dgvProveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvProveedores_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex>-1)
            {
                Proveedor prov = (Proveedor)dgvProveedores.Rows[e.RowIndex].DataBoundItem;
                frmABMProveedores frmABMP = new frmABMProveedores(p, this.bl,prov);
                frmABMP.ShowDialog();
                ActualizarListado();
            }
        }
 
        private void LedoyFormaAlGrid()
        {
            dgvProveedores.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 10, FontStyle.Bold);
            dgvProveedores.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProveedores.ColumnHeadersDefaultCellStyle.ForeColor = Color.Maroon;

            dgvProveedores.ColumnHeadersHeight = 40;
            dgvProveedores.RowHeadersWidth = 30;

            dgvProveedores.RowHeadersDefaultCellStyle.SelectionBackColor = Color.Blue;

            dgvProveedores.RowsDefaultCellStyle.BackColor = Color.LightSteelBlue;
            dgvProveedores.AlternatingRowsDefaultCellStyle.BackColor =  Color.White;

            dgvProveedores.RowsDefaultCellStyle.SelectionBackColor = Color.Blue;

            dgvProveedores.BorderStyle = BorderStyle.Fixed3D;
            dgvProveedores.AllowUserToAddRows = false;
            dgvProveedores.AllowUserToDeleteRows = false;
            dgvProveedores.AllowUserToOrderColumns = true;
            dgvProveedores.ReadOnly = true;
            dgvProveedores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProveedores.MultiSelect = false;

            dgvProveedores.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProveedores.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvProveedores.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProveedores.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProveedores.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvProveedores.Columns[0].Width = 50;
            dgvProveedores.Columns[1].Width = 200;
            dgvProveedores.Columns[2].Width = 200;
            dgvProveedores.Columns[3].Width = 200;
            //dgvProveedores.Columns[5].Width = 200;

            //dgvProveedores.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 5, FontStyle.Bold);
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {

        }

        private void cmbBusca_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtNombreProv.Text))
            {
                //  ActualizarListado();
            }
            else
            {
                SeleccionoCmb();
            }
        }

        private void grbBuscarProv_Enter(object sender, EventArgs e)
        {

        }
    }
}
