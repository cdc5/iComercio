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
using iComercio.Forms;
using Credin;

namespace iComercio.Forms
{
    public partial class frmCapDetalle : FRM
    {
        CapDetalle CapDetalle;
        

        public frmCapDetalle()
        {
            InitializeComponent();
        }

        public frmCapDetalle(Principal p):base(p)
        {
            InitializeComponent();
        }

        public frmCapDetalle(Principal p,BusinessLayer bl,frmPago frmPago, CapDetalle CapDetalle): base(p,bl)
        {
            InitializeComponent();
            frmPago.Graba_Pago += frmPago_Graba_Pago;
            this.CapDetalle = CapDetalle;            
        }

        void frmPago_Graba_Pago(decimal Importe)
        {
            ActualizarCapDetalle(Importe);
        }

        private void ActualizarCapDetalle(decimal Importe)
        {
            CapDetalle.ImportePago += Importe;
            CapDetalle.Cap.Pagado += CapDetalle.ImportePago;
            if (CapDetalle.Importe == CapDetalle.ImportePago)
                CapDetalle.Finalizado = true;
            
            bl.ActualizarTransaccional<CapDetalle>(CapDetalle);
            bl.ActualizarTransaccional<Cap>(CapDetalle.Cap);
            bl.Grabar(CapDetalle.EmpresaID);
        }

        private void frmCapDetalle_Load(object sender, EventArgs e)
        {
            capDetalleBindingSource.DataSource = CapDetalle;
            DeshabilitarControles();
        }

        private void DeshabilitarControles()
        {
            Utilidades.HabilitarControles(false,txtDetalle,dtpFecha,txtImporte,txtImportePago);
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {

        }

        private void grpDetalle_Paint(object sender, PaintEventArgs e)
        {

        }

       
        
    }
}
