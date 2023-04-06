using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using System.Data.Entity;
using iComercio.Rest;
using iComercio.Models;
using iComercio.Delegados;
using iComercio.ViewModels;
using iComercio.Auxiliar;
using Credin;


namespace iComercio.Forms
{
    public partial class frmCAP2 : FRM
    {
        private RestApi ra;
        ConceptoGastos cg;
        ConceptoGastosProveedor cgp;
        SolicitudFondoConceptoGastosProveedor sfcgpg;
        SolicitudFondo sf = new SolicitudFondo();

        public frmCAP2()
        {
            InitializeComponent();
        }

        public frmCAP2(Principal p, RestApi ra): base(p, ra)
        {
            InitializeComponent();
            this.ra = ra;
        }
        

        private void frmCAP_Load(object sender, EventArgs e)
        {
            ObtenerConceptoGastos();
            CargarTiposSolicitud();
            CargarConceptosFondo();
            RecargarDGSolicitudesCap();
        }
        
        private void CargarTiposSolicitud()
        {
            tipoSolicitudComboBox.DataSource = bl.GetTiposSolicitudCap();
            tipoSolicitudComboBox.DisplayMember = "Nombre";
        }

        private void CargarConceptosFondo()
        {
            conceptoFondosComboBox.DataSource = bl.GetConceptosFondos();
            conceptoFondosComboBox.DisplayMember = "Nombre";
        }
        

        private async void btnAgregarSolicitud_Click(object sender, EventArgs e)
        {
            //sf.Importe = System.Convert.ToDecimal(importeTextBox.Text);
            sf.Importe = sf.SolicitudFondoConceptoGastosProveedor.Sum(s => s.Importe);
            sf.EmpresaID = bl.pGlob.Empresa.EmpresaID;
            sf.Empresa = bl.pGlob.Empresa;
            sf.ComercioID = bl.pGlob.Comercio.ComercioID;
            sf.Comercio = bl.pGlob.Comercio;
            sf.FechaPago = fechaPagoDateTimePicker.Value;
            sf.EstadoID = bl.pGlob.SolicitudFondoPendResolCap.EstadoID;
            TipoSolicitud ts = (TipoSolicitud)tipoSolicitudComboBox.SelectedItem;
            ConceptoFondos cf = (ConceptoFondos)conceptoFondosComboBox.SelectedItem;
            sf.TipoSolicitudID = ts.TipoSolicitudID;
            sf.ConceptoFondosID = cf.ConceptoFondosID;
            sf.MedioDePagoID = cf.MedioDePagoID;
            sf.MonedaID = bl.GetPeso().MonedaID;
            bl.AgregarSolicitudesDeFondos(sf); //EF automaticamente popula la clave con la insertada en la base.
            sf = await bl.AgregarTransmisionSolicitudDeFondo(sf);
            RecargarDGSolicitudesCap();
            sf = new SolicitudFondo();
            CargarConceptosGastosProveedor();
            RecargarDGConceptosGastosProveedor();
            
        }

        private void RecargarDGSolicitudesCap()
        {
            dgvCap.AutoGenerateColumns = false;
            dgvCap.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvCap.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvCap.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvCap.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvCap.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvCap.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvCap.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvCap.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvCap.DataSource = bl.GetSolicitudesDeFondosCap();
        }

        private void cmbCg_SelectedIndexChanged(object sender, EventArgs e)
        {
            cg = (ConceptoGastos) cmbCg.SelectedItem;
            if (cg != null)
            {
                CargarConceptosGastosProveedor();
            }
        }

        private void CargarConceptosGastosProveedor()
        {
            List<ConceptoGastosProveedor> cgps = bl.GetConceptoGastosProveedorLogico(c => c.ConceptoGastosID == cg.ConceptoGastosID).ToList();
            if (cgps != null)
            { 
                if (sf.SolicitudFondoConceptoGastosProveedor != null)
                { 
                    cgps = cgps.Where(cx => !sf.SolicitudFondoConceptoGastosProveedor.Any(x => x.ConceptoGastosProveedorID == cx.ConceptoGastosProveedorID)).ToList();
                    cgp = null;
                    Utilidades.CargarCombo(cmbCgp, cgps,null, "ConceptoGastosProveedorID", 0);
                }
            }                
        } 

        private void ObtenerConceptoGastos()
        {
            Utilidades.CargarCombo(cmbCg, bl.GetConceptoGastosLogicoEnNivelFinal().ToList(),"NombreCompleto",  "ConceptoGastosID",0);
        }

        private void cmbCgp_SelectedIndexChanged(object sender, EventArgs e)
        {
            cgp = (ConceptoGastosProveedor)cmbCgp.SelectedItem;
        }

        private void btnAgregarConceptoGasto_Click(object sender, EventArgs e)
        {
            if (cgp != null)
            { 
                SolicitudFondoConceptoGastosProveedor sfcgp = new SolicitudFondoConceptoGastosProveedor();
                //sfcgp.ComercioID = sf.ComercioID;
                //sfcgp.EmpresaID = sf.EmpresaID;
                //sfcgp.SolicitudFondoID = sf.SolicitudFondoID;
                sfcgp.ConceptoGastosProveedorID = cgp.ConceptoGastosProveedorID;
                sfcgp.ConceptoGastosProveedor = cgp; 
                sfcgp.Importe = System.Convert.ToDecimal(txtImporteCgp.Text);
                sfcgp.SolicitudFondo = sf;
                sfcgp.EmpresaID = bl.pGlob.Empresa.EmpresaID;
                sfcgp.Empresa = bl.pGlob.Empresa;
                sfcgp.ComercioID = bl.pGlob.Comercio.ComercioID;
                sfcgp.Comercio = bl.pGlob.Comercio;
                sfcgp.Detalle = txtDetalleGasto.Text;
                sf.SolicitudFondoConceptoGastosProveedor.Add(sfcgp);
                CargarConceptosGastosProveedor();
                RecargarDGConceptosGastosProveedor();
            }
        }

        private void RecargarDGConceptosGastosProveedor()
        {
            dgvCgp.AutoGenerateColumns = false;
            dgvCgp.DataSource = sf.SolicitudFondoConceptoGastosProveedor;
        }

        private void dgvCap_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
           if (e.RowIndex>-1)
            {
                SolicitudFondo sfsel = (SolicitudFondo)dgvCap.Rows[e.RowIndex].DataBoundItem;
                dgvCgpSF.AutoGenerateColumns = false;
                if (sfsel.SolicitudFondoConceptoGastosProveedor != null)
                {
                    dgvCgpSF.DataSource = sfsel.SolicitudFondoConceptoGastosProveedor.ToList();
                }                
            }
        }

        private void btnQuitarConcepto_Click(object sender, EventArgs e)
        {
            if (sfcgpg != null)
            {
                sf.SolicitudFondoConceptoGastosProveedor.Remove(sfcgpg);  
            }
        }

        private void dgvCgp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
               sfcgpg = (SolicitudFondoConceptoGastosProveedor)dgvCgp.Rows[e.RowIndex].DataBoundItem;
            }
        }

        private void dgvCap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvCap_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            AgregarBotonesSegunEstado(dgvCap);
        }

        private void AgregarBotonesSegunEstado(DataGridView dgv)
        {

            foreach (DataGridViewRow dgr in dgv.Rows)
            {
                var item = (SolicitudFondo)dgr.DataBoundItem;
                if (item != null)
                {
                    if (item.EstadoID == bl.pGlob.SolicitudFondoAutorizada.EstadoID
                         && !bl.isSolicitudFondosConfirmadaEnReceptoria(item))
                    {
                        DataGridViewButtonCell btnCell = new DataGridViewButtonCell();
                        btnCell.Value = "Confirmar";
                        dgr.Cells["Confirmar"] = btnCell;
                    }
                    else if (item.EstadoID == bl.pGlob.SolicitudFondoConfirmada.EstadoID)
                    {
                        DataGridViewButtonCell btnCell = new DataGridViewButtonCell();
                        btnCell.Value = "Ver OP";
                        dgr.Cells["OP"] = btnCell;
                    }
                }
            }
        }

        private void grb_Enter(object sender, EventArgs e)
        {

        }
        

      
               
        
    }
}
