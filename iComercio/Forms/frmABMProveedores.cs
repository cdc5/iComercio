using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iComercio.Rest;
using iComercio.Rest.RestModels;
using iComercio.Models;
using iComercio.Delegados;
using iComercio.ViewModels;
using iComercio.Auxiliar;
using Credin;


namespace iComercio.Forms
{
    public partial class frmABMProveedores : FRM
    {
      
        private Proveedor prov = new Proveedor();
        private bool bActualiza;
        private Pais pais;
        private Provincia provincia;
        private Localidad localidad;
        ConceptoGastos cg;
        ConceptoGastosProveedor cgpSel;
        int periodicidad;

        private bool bPasa;

        public frmABMProveedores()
        {
            InitializeComponent();
        }

        private void RecargarDatos()
        {
            this.bl = new BusinessLayer();
            if (prov != null)
            {
                prov = bl.GetProveedores(p => p.ProveedorID == prov.ProveedorID).Single();
            }
        }

        public frmABMProveedores(Principal p,BusinessLayer bl)
            : base(p, bl.ra)
        {
            InitializeComponent();
            this.bl = bl;
            proveedorBindingSource.DataSource = prov;
        }

        public frmABMProveedores(Principal p, BusinessLayer bl,  Proveedor prov)
            : base(p, bl.ra)
        {
            InitializeComponent();
            this.prov = prov;
            this.bl = bl;
            this.bActualiza = true;
            proveedorBindingSource.DataSource = bl.GetProveedorByID(prov.ProveedorID);
            btnNuevaSucursal.Enabled = true;
            proveedorIDLabel.Text = Convert.ToString(prov.ProveedorID);
            grbProveedor.Text = "Código de Proveedor:  " + proveedorIDLabel.Text;
            
            
        }

        private void btnNuevaSucursal_Click(object sender, EventArgs e)
        {
            frmABMProveedoresSucursales frmProvSuc = new frmABMProveedoresSucursales(p, bl,prov);
            frmProvSuc.ShowDialog();
            RecargarSucursales();            
        }

        private void RecargarSucursales()
        {
            //RecargarDatos();
            dgvSucursales.AutoGenerateColumns = false;
            dgvSucursales.DataSource = bl.GetProveedorSucursalesLogico(prov);
        }

        private void frmABMProveedores_Load(object sender, EventArgs e)
        {
            grbProveedor.BackColor = Color.Transparent;
            paisComboBox.DataSource = bl.GetPaises(null,null,"Provincias.Localidades");
            LedoyFormaAlGrid(dgvSucursales);
            if (prov.ProveedorID == null)
                {
                    btnNuevaSucursal.Enabled = false;
                    proveedorIDLabel.Text = "";
                    btnEliminar.Enabled = false;
                    grbProveedor.Text = "";
                    btnAgregarConceptoGasto.Enabled = false;
                    btnQuitarConcepto.Enabled = false;
                }
            RecargarSucursales();
            RecargarCg();
            RecargarCgp();
        }

        private void RecargarCg()
        {
            Utilidades.CargarCombo(cmbConceptoGasto, bl.GetConceptosGastoNoEn(prov.ConceptoGastosProveedor), "Nombre", "ConceptoGastosID",0);
        }

        private void RecargarCgp()
        {
            dgvCgp.AutoGenerateColumns = false; 
            dgvCgp.DataSource = prov.ConceptoGastosProveedor.
                                Where(x=>x.EstadoID != bl.pGlob.ConceptoGastoProveedorEliminado.EstadoID).
                                Select(x => new ConceptoGastoProveedorViewModel{ Cgp = x,
                                                                               Nombre=x.ConceptoGastos.Nombre,
                                                                               Periodicidad = x.Periodicidad,
                                                                               Estado = x.Estado.Nombre}).ToList();

            //usuarioBindingSource = new BindingSource();
            //usuarioBindingSource.DataSource = bl.GetUsuarios(null, null, "Perfiles");
            //dgvUsuarios.DataSource = usuarioBindingSource;
            //perfilAsigBindingSource = 
            //lbPerfilesAsig.DataSource = perfilAsigBindingSource;
            //lbPerfilesAsig.DisplayMember = "nombre";
        }

        private void ValidoParaGrabar()
            {
                //string micadena;
                if (razonSocialTextBox.Text == "")
                {
                    bPasa = false;
                    MessageBox.Show("El nombre no puede quedar vacio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (mail1TextBox.Text != "")
                    {
                        if (mail1TextBox.Text.IndexOf("@") == -1)
                        {
                            bPasa = false;
                            MessageBox.Show("El mail está mal", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                       
                    }
                if (mail2TextBox.Text != "")
                {
                    if (mail2TextBox.Text.IndexOf("@") == -1)
                    {
                        bPasa = false;
                        MessageBox.Show("El mail está mal", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                }
        }

        private async void btnGrabar_Click(object sender, EventArgs e) 
        {
            bPasa = true;
            ValidoParaGrabar();
            if (bPasa)
            { 
                prov.PaisId = pais.PaisID;
                prov.ProvinciaID = provincia.ProvinciaID;
                prov.LocalidadID = localidad.LocalidadID;
                
                if (!bActualiza)
                {
                    prov.EstadoID = bl.pGlob.ProveedorInicial.EstadoID;
                    bl.AgregaProveedor(prov);
                    bl.TransmisionAgregarProveedor(prov, bl.pGlob.Comercio);
                    Alertas.MensajeOKOnly(Properties.Resources.ProveedorAgregado, Properties.Resources.ProveedorAgregadoTitulo);
                    bActualiza = true;
                    btnNuevaSucursal.Enabled = true;
                    btnEliminar.Enabled = true;
                    proveedorIDLabel.Text = Convert.ToString(prov.ProveedorID);
                    grbProveedor.Text = "Código de Proveedor:  " + proveedorIDLabel.Text;
                    prov = bl.GetProveedorByID(prov.ProveedorID);
                }
                else
                {
                    bl.ActualizarProveedor(prov);
                    bl.TransmisionActualizarProveedor(prov, bl.pGlob.Comercio);
                    Alertas.MensajeOKOnly(Properties.Resources.ProveedorModificado, Properties.Resources.ProveedorModificadoTitulo);                        
                }        
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (prov.Sucursales.Any())
                {
                    Alertas.AlertaDeEliminacion("Debe eliminar las sucursales primero");
                }
                else if (Alertas.AlertaDeEliminacion())
                {
                    {
                        bl.BorrarProveedorLogico(prov);
                        bl.TransmisionEliminarProveedor(prov, bl.pGlob.Comercio);
                        Alertas.MensajeOKOnly(Properties.Resources.ProveedorEliminado, Properties.Resources.ProveedorEliminadoTitulo);
                        bActualiza = false;
                        this.Close();
                    }
                }
        }

        private void paisComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            pais = (Pais)paisComboBox.SelectedItem;
            provinciaComboBox.DataSource = null;
            localidadComboBox.DataSource = null;
            if (pais != null)
                Utilidades.CargarCombo(provinciaComboBox, pais.Provincias, "Nombre", "ProvinciaID",0);
        }

        private void provinciaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            provincia = (Provincia)provinciaComboBox.SelectedItem;
            localidadComboBox.DataSource = null;
            if (provincia != null)
                Utilidades.CargarCombo(localidadComboBox, provincia.Localidades, "Nombre", "ProvinciaID",0);
        }

        private void localidadComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            localidad = (Localidad)localidadComboBox.SelectedItem;
        }

        private void dgvSucursales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvSucursales_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvSucursales_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ProveedorSucursal suc = (ProveedorSucursal)dgvSucursales.Rows[e.RowIndex].DataBoundItem;
            frmABMProveedoresSucursales frmABMP = new frmABMProveedoresSucursales(p, this.bl, suc);
            frmABMP.ShowDialog();
           // bl.ProveedorRecargar(prov);
            RecargarSucursales();
            
        }
        private void LedoyFormaAlGrid(DataGridView datagrid1)
        {
            datagrid1.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold);
            datagrid1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            datagrid1.ColumnHeadersHeight = 40;
            datagrid1.RowHeadersWidth = 30;

            datagrid1.RowsDefaultCellStyle.BackColor = Color.LightSteelBlue;
            datagrid1.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            datagrid1.RowsDefaultCellStyle.SelectionBackColor = Color.Blue;

            datagrid1.BorderStyle = BorderStyle.Fixed3D;
            datagrid1.AllowUserToAddRows = false;
            datagrid1.AllowUserToDeleteRows = false;
            datagrid1.AllowUserToOrderColumns = true;
            datagrid1.ReadOnly = true;
            datagrid1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            datagrid1.MultiSelect = false;

            datagrid1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            datagrid1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            datagrid1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            datagrid1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            datagrid1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            datagrid1.Columns[0].Width = 40;
            datagrid1.Columns[1].Width = 170;
            datagrid1.Columns[2].Width = 170;
            datagrid1.Columns[3].Width = 170;
           // datagrid1.Columns[5].Width = 200;

            datagrid1.RowsDefaultCellStyle.Font = new Font("Tahoma", 8);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void telefono1TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Formato.Solonumeros(e, true);

        }
        //private void Solonumeros(KeyPressEventArgs aa, Boolean bguion)
        //{

        //    if (bguion)
        //    {
        //        if (!(char.IsNumber(aa.KeyChar)) && (aa.KeyChar != (char)Keys.Back) && (aa.KeyChar != 45))
        //        {
        //            MessageBox.Show("Solo se permiten números y guión", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //            aa.Handled = true;
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        if (!(char.IsNumber(aa.KeyChar)) && (aa.KeyChar != (char)Keys.Back))
        //        {
        //            MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //            aa.Handled = true;
        //            return;
        //        }
        //    }



        //}

        private void telefono1TextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void telefono2TextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void telefono2TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Formato.Solonumeros(e, true);
        }

        private void cuitTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Formato.Solonumeros(e, true);
        }

        private void ingresosBrutosTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Formato.Solonumeros(e, true);
        }

        private void codigoContableTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Formato.Solonumeros(e, true);
        }

        private void grbDenominacion_Enter(object sender, EventArgs e)
        {

        }

        private void grbProveedor_Enter(object sender, EventArgs e)
        {

        }

        private void cmbConceptoGasto_SelectedIndexChanged(object sender, EventArgs e)
        {
            cg =(ConceptoGastos)cmbConceptoGasto.SelectedItem;
        }

        private void btnAgregarConceptoGasto_Click(object sender, EventArgs e)
        {
            ConceptoGastosProveedor cgp = new ConceptoGastosProveedor();
            cgp.Proveedor = prov;
            cgp.ConceptoGastos = cg;
            cgp.Estado = bl.pGlob.ConceptoGastoProveedorInicial;
            cgp.Periodicidad = Periodicidad();
            prov.ConceptoGastosProveedor.Add(cgp);
            bl.ActualizarProveedor(prov);
            bl.TransmisionAgregarConceptoGastosProveedor(cgp, bl.pGlob.Comercio);
            RecargarCg();
            RecargarCgp();
        }

        private int Periodicidad()
        {
            if (rbDiaria.Checked)
                periodicidad = 1;
            else if (rbSemanal.Checked)
                periodicidad = 7;
            else if (rbMensual.Checked)
                periodicidad = 30;
            else if (rbOtro.Checked)
                periodicidad = Int32.Parse(txtPeriodicidad.Text);
            return periodicidad;
        }
        private void rbDiaria_CheckedChanged(object sender, EventArgs e)
        {


        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (cgpSel != null)
            {
                //bl.BorrarConceptoGastoProveedorLogico(cgpSel);
                //prov.ConceptoGastosProveedor.Remove(cgpSel);
                bl.BorrarConceptoGastoProveedorLogico(cgpSel);
                bl.TransmisionEliminarConceptoGastosProveedor(cgpSel, bl.pGlob.Comercio);
                RecargarCg();
                RecargarCgp();
            }
            else
            {
                Auxiliar.Alertas.MensajeOKOnly(Properties.Resources.Advertencia, Properties.Resources.SeleccionarGastoProveedor);
            }
        }

        private void dgvCgp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cgpSel = ((ConceptoGastoProveedorViewModel)dgvCgp.Rows[e.RowIndex].DataBoundItem).Cgp;
            cgpSel.Proveedor = prov;
        }

        private void grbAgregarCgp_Enter(object sender, EventArgs e)
        {

        }
              
    }
}
