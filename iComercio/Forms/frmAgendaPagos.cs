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
    public partial class frmAgendaPagos : FRM
    {
        public frmAgendaPagos()
        {
            InitializeComponent();
        }

        public frmAgendaPagos(Principal p):base()
        {
            InitializeComponent();
            Inicializar();
        }

        private void Inicializar()
        {
            RecargarEmpYComercio(false);
            Configura_Controles();
        }

        private void Configura_Controles()
        {
            this.BackColor = ColorBackColorFrm;
            Recorre_Formulario(this);
        }

        private void frmPagos_Load(object sender, EventArgs e)
        {

        }

        private void ObtenerPendientesDePago()
        {
            List<Pago> PendientesPago = new List<Pago>();
            List<Cap> Caps = bl.CapsPendientes(Com);
        }

        //public List<Pago> CapDetallesAPago(List<CapDetalle> Detalles)
        //{
        //    foreach ()
        //}

        public Pago CapDetalleAPago(CapDetalle CapDetalle)
        {
            Pago pago = new Pago(CapDetalle.EmpresaID,CapDetalle.ComercioID,CapDetalle.Cap.SolicitudFondoID,CapDetalle.CapID,CapDetalle.CapDetalleID,
                                 null,null,DateTime.Now,CapDetalle.Importe,bl.pGlob.Vigente.EstadoID);
            return pago;
        }
    }
}
