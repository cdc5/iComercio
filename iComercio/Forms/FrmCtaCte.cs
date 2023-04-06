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

namespace iComercio.Forms
{
    public partial class FrmCtaCte : FRM
    {
        public FrmCtaCte()
        {
            InitializeComponent();
        }

        public FrmCtaCte(Principal p, RestApi ra)
            : base(p, ra)
        {
            InitializeComponent();
           
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgv.DataSource = bl.ObtenerCuentaCorriente(bl.pGlob.Comercio, dtpDesde.Value, dtpHasta.Value);
            //dgv.DataSource = bl.ObtenerSaldoCuentaCorrienteHasta(bl.pGlob.Comercio, DateTime.Now);
        }

        private void grbMovimientos_Enter(object sender, EventArgs e)
        {

        }
    }
}
