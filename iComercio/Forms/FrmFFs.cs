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
using Credin;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using AutoMapper;

namespace iComercio.Forms
{
    public partial class FrmFFs : FRM
    {
        List<int> filasMod = new List<int>();
        FF ff;
        FFDetalle FFDetalle;
        Estado Estado;

        public FrmFFs()
        {
            InitializeComponent();
        }

        public FrmFFs(Principal p): base(p)
        {
            InitializeComponent();
            this.BackColor = ColorBackColorFrm;
            Recorre_Formulario(this);
        }

        private void FrmFFs_Load(object sender, EventArgs e)
        {
            RecargarEmpYComercio(false);
            Utilidades.CargarComboGeneric<Estado>(cmbEstado, bl.GetEstadosVigenteAnulado(Com.EmpresaID).ToList(), "Nombre", "EstadoID");
            Buscar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            DateTime Desde = dtpDesde.Value;
            DateTime Hasta = dtpHasta.Value;
            Desde = Desde.Date;
            Hasta = Hasta.Date.AddDays(1).AddTicks(-1);

            if (txtID.Text != String.Empty)
            {
                int ID = System.Convert.ToInt32(txtID.Text);
                dgv.DataSource = bl.Get<FF>(BaseID, c => c.EmpresaID == BaseID && c.ComercioID == Com.ComercioID
                                            && c.FFID == ID && c.EstadoID == Estado.EstadoID);
            }
            else
                dgv.DataSource = bl.Get<FF>(BaseID, c => c.EmpresaID == BaseID && c.ComercioID == Com.ComercioID
                                            && c.Fecha >= Desde && c.Fecha <= Hasta && c.EstadoID == Estado.EstadoID);
            gridView1.BestFitColumns();

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            GridView View = sender as GridView;
            int rHandle = View.FocusedRowHandle;
            ff = (FF)View.GetRow(rHandle);
            AbrirFF(ff);
        }
        private void AbrirFF(FF ff)
        {
            FrmFF frmFF = new FrmFF(p, bl, ff);
            frmFF.Show();
        }

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            Estado = (Estado)cmbEstado.SelectedItem;
        }
        
    }
}
