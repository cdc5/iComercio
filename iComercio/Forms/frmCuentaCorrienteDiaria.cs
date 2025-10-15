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
using DevExpress.XtraGrid.Views;
using DevExpress.XtraGrid;
using Credin;
using iComercio.Rest;
using iComercio.Rest.RestModels;
using iComercio.Delegados;
using iComercio.ViewModels;



namespace iComercio.Forms
{
    public partial class frmCuentaCorrienteDiaria : FRM
    {
        private RestApi ra;
        private RestApi raM;
        Comercio comer;

        public frmCuentaCorrienteDiaria():base()
        {
            InitializeComponent();
        }

        public frmCuentaCorrienteDiaria(Principal p)
            : base(p)
        {
            bl = new BusinessLayer(ra,raM);
            InitializeComponent();
        }
        
        private void InicializarControles()
        {
            Utilidades.CargarComboGeneric<Comercio>(cmbComercio, Com, "Nombre", "ComercioID");
            dtpDesde.Value = DateTime.Now.Date.AddDays(-7);

        }       

        private void frmCuentaCorrienteDiaria_Load(object sender, EventArgs e)
        {
            RecargarEmpYComercio(false);
            InicializarControles();
            //Buscar();
        }
        private void Buscar()
        {
            CuentaCorrienteDiaria ccd = bl.CuentaCorrienteDiaria(comer.EmpresaID, comer.ComercioID, dtpDesde.Value, dtpDesde.Value);
            bsCCDiaria.DataSource = ccd;
            ExpandAllRows(gridView1);
            ExpandAllRows(gridView2);
            ExpandAllRows(gridView3);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();            
        }

        private void cmbComercio_SelectedIndexChanged(object sender, EventArgs e)
        {
            comer = (Comercio)cmbComercio.SelectedItem;
        }

        public void ExpandAllRows(GridView View)
        {
            View.BeginUpdate();
            try
            {
                int dataRowCount = View.DataRowCount;
                for (int rHandle = 0; rHandle < dataRowCount; rHandle++)
                    View.SetMasterRowExpanded(rHandle, true);
            }
            finally
            {
                View.EndUpdate();
            }
        }

        private void frmCuentaCorrienteDiaria_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                if (e.Shift)
                {
                    if (bl.LlevaM())
                    {
                        lblMor.Visible = true;
                        RecargarEmpYComercio(lblMor.Visible);
                    }
                }
            }
        }
    }
}
