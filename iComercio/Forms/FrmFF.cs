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
    public partial class FrmFF : FRM
    {
        FF ff;
        List<FFDetalle> FFDetalles;
        ConceptoFondos ConFon;

        public FrmFF()
        {
            InitializeComponent();
        }

        public FrmFF(Principal p):base(p)
        {
            InitializeComponent();
            Inicializar();
            ff = new FF();
            FFDetalles = new List<FFDetalle>();
            ff.Items = FFDetalles;
            CargarControles(ff);
        }

        public FrmFF(Principal p, BusinessLayer bl, FF ff): base(p, bl)
        {
            InitializeComponent();
            Inicializar();
            this.ff = ff;
            CargarControles(ff);
            Utilidades.HabilitarControles(false, cmbConcepto, grvDetalles, txtNotas, btnGrabar, dtpFecha);            
        }

        

        private void Inicializar()
        {
            RecargarEmpYComercio(false);
            Configura_Controles();            
        }

        private void CargarControles(FF ff)
        {
            fFBindingSource.DataSource = ff;
            fFDetalleBindingSource.DataSource = ff.Items;
            lblMontoFFV.Text = bl.pGlob.Configuracion.MontoFF.ToString();
            grvDetalles.DataSource = fFDetalleBindingSource;
            Utilidades.CargarComboGeneric<ConceptoFondos>(cmbConcepto, bl.GetConceptosFondos().ToList(), "FFID", "Nombre");
            if (ff.SolicitudFondo != null && ff.SolicitudFondo.ConceptoFondos != null)
                cmbConcepto.SelectedIndex = cmbConcepto.Items.IndexOf(ff.SolicitudFondo.ConceptoFondos);            
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
           if (CargarFF())
           {
               bl.GrabarFF(Com, ff);
               MessageBox.Show("FF Registrado");
               this.Close();
           }
            
        }

       

        private bool CargarFF()
        {
            ff.EmpresaID = Com.EmpresaID;
            ff.ComercioID = Com.ComercioID;
            ff.TotalGastos = (decimal)gridView1.Columns["Importe"].SummaryItem.SummaryValue;
            ff.MontoFF = bl.pGlob.Configuracion.MontoFF;
            ff.PendienteReposicionSemAnt = bl.FFPendienteReposicion(bl.pGlob.Comercio);
            ff.Fecha = dtpFecha.Value;
            ff.Remanente = ff.MontoFF - ff.TotalGastos;
            ff.EstadoID = bl.pGlob.Vigente.EstadoID;
            ff.Pagado = true;
            ff.Notas = txtNotas.Text;
            
            if (ff.TotalGastos > bl.pGlob.Configuracion.MontoFF)
            {
                MessageBox.Show(String.Format("El total de los gastos no puede superar el Monto Fijo de:{0}", bl.pGlob.Configuracion.MontoFF));
                return false;
            }

            if (ff.SolicitudFondo == null)
            {
                SolicitudFondo solfon = new SolicitudFondo(ff.EmpresaID, ff.ComercioID, ff.Fecha, ff.TotalGastos,
                                                                       bl.pGlob.SolicitudFondoPendResolCap.EstadoID,
                                                                       bl.pGlob.tsFF.TipoSolicitudID, ConFon.MedioDePagoID,
                                                                       ConFon.ConceptoFondosID,bl.pGlob.Peso.MonedaID, ff.ComercioID);
                ff.SolicitudFondo = solfon;
            }
            else
            {
                ff.SolicitudFondo.FechaPago = ff.Fecha;
                ff.SolicitudFondo.Importe = ff.TotalGastos;
                ff.SolicitudFondo.ConceptoFondosID = ConFon.ConceptoFondosID;
            }
            //fFBindingSource.ResetBindings(false);
            return true;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            bl.EliminarFF(Com, ff);
            MessageBox.Show("Cap Eliminado");
        }
        

        private void gridView1_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            GridView view = sender as GridView;
            view.SetRowCellValue(e.RowHandle, "Fecha", DateTime.Now.Date);
            CargarFF();
        }

       

        private void cmbConcepto_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConFon = (ConceptoFondos)cmbConcepto.SelectedItem;
        }

        private void grvDetalles_Click(object sender, EventArgs e)
        {

        }

        private void grpTotales_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelControl6_Click(object sender, EventArgs e)
        {

        }

        private void btnAutoCompletar_Click(object sender, EventArgs e)
        {
            CompletarConGastosDesdeUltimaFechaFF();
        }

        private void CompletarConGastosDesdeUltimaFechaFF()
        {
            fFDetalleBindingSource.DataSource = bl.ObtenerFFDetallesDesdeUltimaFechaFF(Com);
        }

        private void grvDetalles_ProcessGridKey(object sender, KeyEventArgs e)
        {
            var grid = sender as GridControl;
            var view = grid.FocusedView as GridView;
            if (e.KeyData == Keys.Delete)
            {
                view.DeleteSelectedRows();
                e.Handled = true;
            }
        }

    }
}
