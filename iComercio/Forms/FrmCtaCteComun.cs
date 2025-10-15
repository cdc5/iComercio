using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iComercio.Models;
using iComercio.Auxiliar;
using DevExpress.XtraGrid.Views.Grid;
using Credin;
using iComercio.Rest;
using iComercio.Rest.RestModels;
using iComercio.Models;
using iComercio.Delegados;
using iComercio.ViewModels;
using iComercio.Auxiliar;


namespace iComercio.Forms
{
    public partial class FrmCtaCteComun : FRM
    {
        public event EventHandler<MensajeEventArgs> actualizarBarraDeEstado;
        public event EventHandler actualizarBarraDeEstadoListo;

        private RestApi ra;
        Comercio comer;

        public FrmCtaCteComun():base()
        {
            InitializeComponent();
        }

        public FrmCtaCteComun(Principal p,RestApi ra,RestApi raM): base(p)
        {
            bl = new BusinessLayer(ra, raM);
            InitializeComponent();
        }


        private void FrmCtaCteComun_Load(object sender, EventArgs e)
        {
            lblMor.Visible = false;
            RecargarEmpYComercio(lblMor.Visible);
            InicializarControles();
            Buscar();
        }

        private void InicializarControles()
        {
            
            Utilidades.CargarComboGeneric<Comercio>(cmbComercio, Com, "Nombre", "ComercioID");
            dtpDesde.Value = DateTime.Now.Date.AddDays(-7);           
                      
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            List<CuentaCorrienteComun> lccc = bl.CuentaCorriente(comer.EmpresaID, comer.ComercioID, dtpDesde.Value, dtpHasta.Value);
            CuentaCorrienteComun ccc = lccc[lccc.Count - 1];
            dgv.DataSource = lccc;
            ActualizarTotales(ccc);
        }

        private void ActualizarTotales(CuentaCorrienteComun ccc)
        {
            DateTime Hoy = DateTime.Now;
            DateTime Ayer = Hoy.AddDays(-1);
            decimal saldo = ccc.Saldo;
            decimal retCap = bl.RetenidoPorCap(comer);
            decimal retFF = bl.RetenidoPorFF(comer);
            decimal AutorizadoVenta = bl.AutorizadoAVender(comer);
            decimal AutorizadoAyer = bl.AutorizadoAVender(comer, Ayer);
            decimal AutorizadoHoy = bl.AutorizadoAVender(comer,Hoy);
            decimal disp = saldo - retCap - retFF;
            decimal DisponibleParaVenta = bl.DisponibleVenta(comer, Hoy);
            lblSaldoV.Text = saldo.ToString("00.00");
            lblRetCapV.Text = retCap.ToString("00.00");
            lblRetFFV.Text = retFF.ToString("00.00");
            lblAutVentaV.Text = AutorizadoVenta.ToString("00.00");
            lblAutVentaAyerV.Text = AutorizadoAyer.ToString("00.00");
            lblAutVentaHoyV.Text = AutorizadoHoy.ToString("00.00");
            lblDispVentaV.Text = DisponibleParaVenta.ToString("00.00");

        }


        private void cmbComercio_SelectedIndexChanged(object sender, EventArgs e)
        {
            comer = (Comercio)cmbComercio.SelectedItem;
        }

        private void cuentaCorrienteComunBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                string Fecha = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Fecha"]);
                if (Fecha == DateTime.Now.ToShortDateString())
                {
                    e.Appearance.BackColor = Color.AliceBlue;
                    e.Appearance.BackColor2 = Color.LightBlue;
                }
                else
                {
                    bool provi = (bool)View.GetRowCellValue(e.RowHandle, View.Columns["provisorios"]);
                    if (provi)
                    {
                        e.Appearance.BackColor = Color.AliceBlue;
                        e.Appearance.BackColor2 = Color.LightBlue;
                    }
                }
            }
        }

        private void btnAgregarMovimiento_Click(object sender, EventArgs e)
        {
            frmRecibos frmRec = new frmRecibos(p, bl, lblMor.Visible);
            frmRec.ShowDialog();
            Buscar();
        }

        private void btnAct_Click(object sender, EventArgs e)
        {
            ActualizarRecibosYTransferenciasCentral(comer,dtpDesde.Value,dtpHasta.Value,null);
        }

        public async void ActualizarRecibosYTransferenciasCentral(Comercio com, DateTime fechaDesde, DateTime fechaHasta, Estado est)
        {
            MensajeEventArgs me = new MensajeEventArgs("Cargando");
            actualizarBarraDeEstado(this, me);

            RecibosYTransferencias ryt = await bl.ActualizarRecibosYTransferenciasCentral(com, fechaDesde, fechaHasta, null);
            bl.CompararYActualizarRecibosYTransferenciasCentral(com, fechaDesde, fechaHasta, ryt);

            //infoObjetivosBindingSource.DataSource = sfvm.infoObjetivos;
            ////dgvSolicitudesFondos.DataSource = sfvm.SolicitudesDeFondos;
            ////object solfons = await ra.GetSolicitudesFondosAsync(com,fechaDesde,fechaHasta,est);
            //BuscarSolicitudes();
            Buscar();
            actualizarBarraDeEstadoListo(this, EventArgs.Empty);
        }

        private void grpTotales_Paint(object sender, PaintEventArgs e)
        {

        }

        private void grbCtaCte_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblDispVentaV_Click(object sender, EventArgs e)
        {

        }

        private void FrmCtaCteComun_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                if (e.Shift)
                {
                    if (bl.LlevaM())
                    {
                        if (lblMor.Visible) return;
                        lblMor.Visible = true;
                        RecargarEmpYComercio(lblMor.Visible);
                        InicializarControles();
                        Buscar();
                    }
                }
            }
        }

        private void FrmCtaCteComun_KeyPress(object sender, KeyPressEventArgs e)
        {
            MessageBox.Show(e.KeyChar.ToString());
        }
    }
}
