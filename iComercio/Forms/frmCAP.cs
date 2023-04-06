using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iComercio.Models;
using iComercio.Rest;
using Credin;
using DevExpress.XtraGrid.Views;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;


namespace iComercio.Forms
{
    public partial class FrmCap : FRM
    {
        bool Actualiza;
        Cap Cap;
        List<CapDetalle> CapDetalles;
        ConceptoFondos ConFon;

        public FrmCap()
        {
            InitializeComponent();
        }

        public FrmCap(Principal p):base(p)
        {
            InitializeComponent();
            Inicializar();
            Cap = new Cap();
            CapDetalles = new List<CapDetalle>();
            Cap.Items = CapDetalles;
            CargarControles(Cap);
            Actualiza = false;
        }

        public FrmCap(Principal p,BusinessLayer bl,Cap Cap): base(p,bl)
        {
            InitializeComponent();
            Inicializar();
            this.Cap = Cap;
            CargarControles(Cap);
            Utilidades.HabilitarControles(false, cmbConcepto, grvDetalles,txtNotas, btnGrabar, dtpFecha);      
        }

        private void Inicializar()
        {
            RecargarEmpYComercio(false);
            Configura_Controles();            
        }

        private void CargarControles(Cap cap)
        {
            capBindingSource.DataSource = cap;
            capDetalleBindingSource.DataSource = cap.Items;
            grvDetalles.DataSource = capDetalleBindingSource;
            Utilidades.CargarComboGeneric<ConceptoFondos>(cmbConcepto, bl.GetConceptosFondos().ToList(), "CapID", "Nombre");
            if (cap.SolicitudFondo != null && cap.SolicitudFondo.ConceptoFondos != null)
                cmbConcepto.SelectedIndex = cmbConcepto.Items.IndexOf(cap.SolicitudFondo.ConceptoFondos);            
        }
        
        private void Configura_Controles()
        {
            this.BackColor = ColorBackColorFrm;
            Recorre_Formulario(this);
        }

        

        private void FrmCap_Load(object sender, EventArgs e)
        {

        }

        private void groupControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            CargarCap();
            bl.GrabarCap(Com, Cap, Actualiza);
            if (!Actualiza)
                MessageBox.Show("CAP Registrado");
            else
                MessageBox.Show("CAP Modificado");
            this.Close();
        }
        
        private void CargarCap()
        {
            Cap.EmpresaID = Com.EmpresaID;
            Cap.ComercioID = Com.ComercioID;
            Cap.Total = (decimal)gridView1.Columns["Importe"].SummaryItem.SummaryValue;
            Cap.Fecha = dtpFecha.Value;
            Cap.EstadoID = bl.pGlob.Vigente.EstadoID;
            Cap.Notas = txtNotas.Text;
            if (Cap.SolicitudFondo == null)
            {
                SolicitudFondo solfon = new SolicitudFondo(Cap.EmpresaID, Cap.ComercioID, Cap.Fecha, Cap.Total,
                                                           bl.pGlob.SolicitudFondoPendResolCap.EstadoID,
                                                           bl.pGlob.tsCap.TipoSolicitudID, ConFon.MedioDePagoID,
                                                           ConFon.ConceptoFondosID,bl.pGlob.Peso.MonedaID, Cap.ComercioID);
                Cap.SolicitudFondo = solfon;
            }
            else
            {
                Cap.SolicitudFondo.FechaPago = Cap.Fecha;
                Cap.SolicitudFondo.Importe = Cap.Total;
                Cap.SolicitudFondo.ConceptoFondosID = ConFon.ConceptoFondosID;
            }
                
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            bl.EliminarCap(Com, Cap);
            MessageBox.Show("Cap Eliminado");
        }
        

        private void gridView1_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            GridView view = sender as GridView;
            view.SetRowCellValue(e.RowHandle, "FechaVencimiento", DateTime.Now.Date);
        }

        private void cmbConcepto_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConFon = (ConceptoFondos)cmbConcepto.SelectedItem;
        }

        private void grvDetalles_Click(object sender, EventArgs e)
        {

        }

        private void grvDetalles_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {

        }

       

    }
}
