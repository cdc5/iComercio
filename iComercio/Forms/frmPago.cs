using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iComercio.Models;
using iComercio.Forms;
using iComercio.Auxiliar;
using Credin;
using iComercio.Delegados;

namespace iComercio.Forms
{
    public partial class frmPago : FRM
    {
        public Pago Pago;
        public CapDetalle CapDetalle;
        public frmCapDetalle objForm;
        //public delegate void DelegadoDecimal(decimal val);
        public event DelegadoDecimal Graba_Pago;
        

        public frmPago()
        {
            InitializeComponent();
        }

        public frmPago(Principal p):base(p)
        {
            InitializeComponent();
        }

        public frmPago(Principal p,BusinessLayer bl,CapDetalle CapDetalle): base(p,bl)
        {
            InitializeComponent();
            Utilidades.HabilitarBotones(false, btnEliminar, btnGrabar);
            this.CapDetalle = CapDetalle;
            CargarInfoCapDetalle(CapDetalle);
        }

        public frmPago(Principal p, BusinessLayer bl, Pago Pago)
            : base(p, bl)
        {
            InitializeComponent();
            Utilidades.HabilitarBotones(false, btnEliminar, btnGrabar);
            this.Pago = Pago;
            CargarInfoPago(this.Pago);
        }

        private void frmPago_Load(object sender, EventArgs e)
        {
            RecargarEmpYComercio(false);
            Configura_Controles();
            lblEstadoV.Text = "";
           
        }

        private void Configura_Controles()
        {
            //Configura_Colores();
            this.BackColor = ColorBackColorFrm;
            Recorre_Formulario(this);
        }

        private void CargarInfoCapDetalle(CapDetalle capDetalle)
        {
            if (CapDetalle != null)
            {
                dtpFechaPago.Value = DateTime.Now;
                Utilidades.CargarComboGeneric<SolicitudFondo>(cmbSolfon, CapDetalle.Cap.SolicitudFondo,"sDetalleSolFon","SolicitudFondoID");
                ////cmbSolfon.SelectedItem = ((List<SolicitudFondo>)cmbSolfon.DataSource).Find(s => s.EmpresaID == CapDetalle.Cap.EmpresaID
                //                                                                           && s.ComercioID == CapDetalle.Cap.ComercioID
                //                                                                           && s.SolicitudFondoID == CapDetalle.Cap.SolicitudFondoID);
                Utilidades.CargarComboGeneric<CapDetalle>(cmbFFCap, CapDetalle, "sDetalleCapDescripcion", "CapDetalleID");
                txtImporte.Text = CapDetalle.PendientePago.ToString();
                CargarPanelDetalle(capDetalle);
                lblEstado.Visible = false;
                lblEstadoV.Visible = false;
            }
        }

        private void CargarInfoPago(Pago pago)
        {
            if (pago != null)
            {
                dtpFechaPago.Value = pago.Fecha;
                Utilidades.CargarComboGeneric<SolicitudFondo>(cmbSolfon, pago.SolicitudFondo, "sDetalleSolFon", "SolicitudFondoID");
                if (pago.FFDetalle != null)
                {
                    Utilidades.CargarComboGeneric<FFDetalle>(cmbFFCap, pago.FFDetalle, "sDetalleFFDescripcion", "FFDetalleID");
                    lblFFCAP.Text = "FF:";
                }
                if (pago.CapDetalle != null)
                {
                    Utilidades.CargarComboGeneric<CapDetalle>(cmbFFCap, pago.CapDetalle, "sDetalleCapDescripcion", "CapDetalleID");
                    lblFFCAP.Text = "CAP:";
                }
                if (pago.Estado != null)
                    lblEstadoV.Text = pago.Estado.Nombre;
                txtImporte.Text = pago.Importe.ToString();
                lblEstado.Visible = true;
                lblEstadoV.Visible = true;
                if (pago.EstadoID != bl.pGlob.Eliminado.EstadoID)
                    Utilidades.HabilitarBotones(true, btnEliminar);
                Utilidades.HabilitarBotones(false, btnGrabar);
                PanelDetalle.Visible = false;
                this.Height = 200;
            }
        }

        private void CargarPanelDetalle(CapDetalle capDetalle)
        {
            PanelDetalle.Visible = true;
            this.Height = 392;
            Utilidades.HabilitarBotones(true, btnGrabar);
            frmCapDetalle objForm = new frmCapDetalle(p, bl,this, CapDetalle);
            AuxiliaresWinForms.FormInPanel(objForm, PanelDetalle);
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            decimal Importe = System.Convert.ToDecimal(txtImporte.Text);
            bl.GrabarPago(Com,CapDetalle, Importe, dtpFechaPago.Value, Graba_Pago);
            
            //if (Importe > CapDetalle.PendientePago)
            //{
            //    MessageBox.Show("No se puede ingresar un importe mayor al importe del detalle pendiente");
            //}
            //else
            //{
            //    Pago = new Pago(CapDetalle.EmpresaID, CapDetalle.ComercioID, CapDetalle.Cap.SolicitudFondoID, 
            //                    CapDetalle.Cap.CapID, CapDetalle.CapDetalleID, null, null, dtpFechaPago.Value, Importe);
            //    bl.AgregarTransaccional<Pago>(Pago);
            //    bl.ImputacionCuentaCorrientePago(Pago, CapDetalle.Cap);
            //    Graba_Pago(Importe);
            //    //CapDetalle.Finalizado = objForm.chkFinalizado
            //    bl.Grabar(CapDetalle.EmpresaID);
            //}
            this.Close();
        }

        void objForm_ActualizarCapDetalleEvent(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        
        private void GrabarPagoCapDetalle(CapDetalle CapDetalle)
        {

        }

        private void PanelDetalle_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            bl.EliminarPago(Com, Pago);
        }

        

    }
}
