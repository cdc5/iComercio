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
    public partial class FrmCaps : FRM
    {
        List<int> filasMod = new List<int>();
        Cap cap;
        CapDetalle CapDetalle;
        Estado Estado;
        Pago Pago;

        public FrmCaps()
        {
            InitializeComponent();
        }

        public FrmCaps(Principal p):base(p)
        {
            InitializeComponent();
            this.BackColor = ColorBackColorFrm;
            Recorre_Formulario(this);
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
                dgv.DataSource = bl.Get<Cap>(BaseID, c => c.EmpresaID == BaseID && c.ComercioID == Com.ComercioID
                                            && c.CapID == ID && c.EstadoID == Estado.EstadoID);
            }                
            else
                dgv.DataSource = bl.Get<Cap>(BaseID, c => c.EmpresaID == BaseID && c.ComercioID == Com.ComercioID
                                            && c.Fecha >= Desde && c.Fecha <= Hasta && c.EstadoID == Estado.EstadoID);
            gridView1.BestFitColumns();

        }

        private void FrmCaps_Load(object sender, EventArgs e)
        {
            lblCapDetaID.Text = "0";
            RecargarEmpYComercio(false);
            Utilidades.CargarComboGeneric<Estado>(cmbEstado, bl.GetEstadosVigenteAnulado(Com.EmpresaID).ToList(), "Nombre", "EstadoID");
            Buscar();
            btnImagen.Visible = false;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            GridView View = sender as GridView;
            int rHandle = View.FocusedRowHandle;
            cap = (Cap)View.GetRow(rHandle);
            AbrirCap(cap);
        }

        private void AbrirCap(Cap cap)
        {
            FrmCap frmCap = new FrmCap(p, bl,cap);
            frmCap.Show();
        }

        private void dgv_Click(object sender, EventArgs e)
        {
            //this.Text = "kk";
        }

        private void gridView2_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;
            GridColumn colImporte = view.Columns["Importe"];
            GridColumn colImportePago = view.Columns["ImportePago"];
            GridColumn colFinalizado = view.Columns["Finalizado"];

            double Importe = Convert.ToDouble(view.GetRowCellValue(view.FocusedRowHandle, colImporte));
            double ImportePago = Convert.ToDouble(view.GetRowCellValue(view.FocusedRowHandle, colImportePago));
            bool Finalizado = (bool) view.GetRowCellValue(view.FocusedRowHandle, colFinalizado);
            if (!Finalizado)
            {
                if (Importe < ImportePago)
                {
                    view.SetColumnError(colImportePago, "El pago debe ser menor que el Importe del gasto ");
                    view.SetColumnError(null, "Error");
                    e.Valid = false;
                    e.ErrorText = "Error en la fila:" + e.RowHandle;
                }
            }
            
        }

        private void gridView2_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            int fila = (int)e.Row;
            if (!filasMod.Contains(fila))
                filasMod.Add(fila);           

        }

        //esto en grabar
        //public void CargarPago(CapDetalle CapDet)
        //{
        //    if (CapDet != null)
        //    {
        //        CargarPago(CapDet);
        //    }
        //    Pago pago = bl.CapDetalleAPago(CapDet);
        //    bl.Agregar<Pago>(pago);
        //}

        private void btnGrabar_Click(object sender, EventArgs e)
        {

        }

        private void NuevoPago(CapDetalle CapDetalle)
        {
            if (!CapDetalle.Finalizado)
            {
                frmPago frmPago = new frmPago(p, bl, CapDetalle);
                frmPago.ShowDialog();
                FinalizaCap(CapDetalle);
                Buscar();
            }
            else
            {
                MessageBox.Show("El Detalle seleccionado ya se encuentra finalizado", "Error", MessageBoxButtons.OK);
            }
            
        }

        private void FinalizaCap(CapDetalle CapDetalle)
        {
            if (CapDetalle.Cap.Saldo == 0)
            {
                CapDetalle.Cap.Finalizado = true;
                bl.ActualizarTransaccional<Cap>(CapDetalle.Cap);
                bl.Grabar(CapDetalle.EmpresaID);
            }
        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GridView View = sender as GridView;
            int rHandle = View.FocusedRowHandle;
            CapDetalle = (CapDetalle)View.GetRow(rHandle);

            lblCapDetaID.Text = "0";
            //lblCapDetaID.Visible = true;
            //object CellValue = gridView2.GetFocusedRowCellValue("ColDetaId");
            if (CapDetalle != null)
            {
                lblCapDetaID.Text = CapDetalle.CapDetalleID.ToString();// CellValue.ToString();
            }
            string rutaArchivo = RutaArchivo(bl.pGlob.Configuracion.rutaComprIma, "CAP", lblCapDetaID.Text);

            //if (Auxiliares.Utilidades.ExisteArchivo(rutaArchivo))
            if (Auxiliares.Utilidades.EstaArchivo(rutaArchivo))
            {
                btnImagen.BackColor = SystemColors.Control;
                btnImagen.Text = "Ver imagen";
            }
            else
            {
                btnImagen.BackColor = Color.OrangeRed;
                btnImagen.Text = "Scanner";
            }
            btnImagen.Visible = true;
        }
        private string RutaArchivo(string cRuta, string cTipo, string nCompr)
        {
            string cArch = "";
            cArch = cTipo + "_" + nCompr + ".Jpg";
            return String.Format("{0}\\{1}", cRuta, cArch);
        }
        private void btnNuevoPago_Click(object sender, EventArgs e)
        {
            if (CapDetalle != null)
                NuevoPago(CapDetalle);
            else
                MessageBox.Show("Debe Seleccionar un Detalle","Error",MessageBoxButtons.OK);
        }

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            Estado = (Estado)cmbEstado.SelectedItem;    
        }

        private void gridView3_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GridView View = sender as GridView;
            int rHandle = View.FocusedRowHandle;
            Pago = (Pago)View.GetRow(rHandle);
        }

        private void gridView3_DoubleClick(object sender, EventArgs e)
        {
            AbrirPago(Pago); 
        }

        private void AbrirPago(Pago Pago)
        {
            frmPago frmPago = new frmPago(p, bl, Pago);
            frmPago.Show();
        }

        private void gridView2_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            //lblCapDetaID.Visible = false;
            btnImagen.Visible = false;
        }

        private void btnImagen_Click(object sender, EventArgs e)
        {
            if (lblCapDetaID.Text != null && lblCapDetaID.Text != String.Empty && lblCapDetaID.Text != "0")
            {
                frmScan frmScan = new frmScan(p, bl, Convert.ToInt32(lblCapDetaID.Text), "CAP", "CAPS", false, "CAP"); 
                frmScan.MdiParent = Principal.ActiveForm;
                frmScan.Show();
            }
        }
    }
}
