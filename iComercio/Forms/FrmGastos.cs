using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iComercio.Rest;                    
using iComercio.Models;                  
using iComercio.DAL;
using iComercio.Auxiliar;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base; //edu202012
using AutoMapper;
using iComercio.Auxiliares;

namespace iComercio.Forms
{
    public partial class frmGastos : FRM 
    {
        Gasto gasto = new Gasto();
        Gasto gastoSel;
        Estado Estado;
         
        public frmGastos()
        {
            InitializeComponent();
        }

        public frmGastos(Principal p, BusinessLayer bl):base(p,bl)
        {
            InitializeComponent();
            bl = new BusinessLayer();
            RecargarEmpYComercio(false);
            Configura_Inicio();
        }

         private void Configura_Inicio()
         {
             Configura_Controles();
         }

         private void Configura_Controles()
         {
             Configura_Colores(bl.pGlob.Comercio.EmpresaID);
             Recorre_Formulario(this);
             this.BackColor = ColorBackColorFrm;
             this.txtImporte.KeyPress += new System.Windows.Forms.KeyPressEventHandler(PuntoAComa_KeyPress);
        }
        
        private void frmGastos_Load(object sender, EventArgs e)
        {
           dtpFecha.Value = DateTime.Now;
           gastoBs.DataSource = gasto;
           ConfigurarFechas();
           CargarEstados();       
           BuscarGastos(dtpDesde.Value, dtpHasta.Value);
        }

        private void CargarEstados()
        {
            Utilidades.CargarCombo(cmbEstado, bl.GetEstadosGenerales(Com.EmpresaID).ToList(), "EstadoID");
        }


        private void ConfigurarFechas()
        {
            dtpFecha.Value = DateTime.Now;
            DateTime? fecha = bl.ObtenerUltimaFechaDeFF(Com);
            if (fecha != null)
                dtpDesde.Value = fecha.Value;
            else
                dtpDesde.Value = DateTime.Now.PrimerDiaDelMes();
            dtpHasta.Value = DateTime.Now;            
        }



        private void BuscarGastos(DateTime Desde,DateTime Hasta)
        {
            DateTime fDesde = Desde.Date;
            DateTime fHasta = Hasta.Date.AddDays(1).AddTicks(-1);
            List<Gasto> gastos = bl.Get<Gasto>(Com.EmpresaID, g => g.EmpresaID == Com.EmpresaID && g.ComercioID == Com.ComercioID
                                 && g.Fecha >= fDesde && g.Fecha <= fHasta && g.EstadoID == Estado.EstadoID ).ToList();
            gastosBS.DataSource =  gastos;
                
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
           BuscarGastos(dtpDesde.Value, dtpHasta.Value);
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
                      
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarGasto())
            {
               gasto.EmpresaID = Com.EmpresaID;
               gasto.ComercioID = Com.ComercioID;
               gasto.EstadoID = bl.pGlob.Vigente.EstadoID;
               gasto.Fecha = dtpFecha.Value;
               bl.AgregarGasto(gasto,Com);
               LimpiarControles();
               gasto = new Gasto();
               gastoBs.DataSource = gasto;
               BuscarGastos(dtpDesde.Value, dtpHasta.Value);
               gasto.Fecha = dtpFecha.Value;
            }
        }

        private void LimpiarControles()
        {
            txtDescripcion.Clear();
            txtImporte.Clear();
            ConfigurarFechas();
        }

        private bool ValidarGasto()
        {
            if (String.IsNullOrEmpty(txtImporte.Text) || txtImporte.Text == "0")
            {
                txtImporte.Focus();
                MessageBox.Show(Properties.Resources.NoMenorOIgual0, Properties.Resources.Error, MessageBoxButtons.OK);
                return false;
            }

            if (String.IsNullOrEmpty(txtDescripcion.Text))
            {
                txtDescripcion.Focus();
                MessageBox.Show(Properties.Resources.NoCampoVacio, Properties.Resources.Error, MessageBoxButtons.OK);
                return false;
            }

            return true;
        }




        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (gastoSel != null)
            {
                bl.EliminarGasto(gastoSel,Com);
                BuscarGastos(dtpDesde.Value, dtpHasta.Value);
            }
            else
            {
                MessageBox.Show("Debe Seleccionar un gasto", Properties.Resources.Error, MessageBoxButtons.OK);
            }
        }

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            Estado =(Estado) cmbEstado.SelectedItem;
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {

        }

        private void gastosBS_CurrentChanged(object sender, EventArgs e)
        {
            //GridView View = sender as GridView;
            //int rHandle = View.FocusedRowHandle;
            //gastoSel = (Gasto)View.GetRow(rHandle);
            //this.Text=            gasto.GastoID.ToString();
        }

        private void gridView1_FocusedRowChanged_1(object sender, FocusedRowChangedEventArgs e)
        {
            object CellValue = gridView1.GetFocusedRowCellValue("GastoID");
            lblGastoID.Text = "0";
            if(CellValue != null)
            {
                lblGastoID.Text = CellValue.ToString();
                GridView View = sender as GridView;
                int rHandle = View.FocusedRowHandle;
                gastoSel = (Gasto)View.GetRow(rHandle);
            }
            string rutaArchivo = RutaArchivo(bl.pGlob.Configuracion.rutaComprIma, "GST", lblGastoID.Text) ;
            //GridView view = (GridView)grid

            //filasQueHanCambiado.Add(view.FocusedRowHandle);
            //view.RefreshRow(view.FocusedRowHandle);

            
            //if(Auxiliares.Utilidades.ExisteArchivo(rutaArchivo))
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
            gridView1.RefreshRow(gridView1.FocusedRowHandle);
        }
        private string RutaArchivo(string cRuta, string cTipo, string nCompr)
        {
            string cArch = "";
            cArch = cTipo + "_" + nCompr + ".Jpg";
            return  String.Format("{0}\\{1}", cRuta, cArch);
        }



        private void btnImagen_Click(object sender, EventArgs e)
        {
            if(lblGastoID.Text != null && lblGastoID.Text != String.Empty && lblGastoID.Text != "0")
            {
                frmScan frmScan = new frmScan(p, bl, Convert.ToInt32(lblGastoID.Text), "GST", "Gasto", false, "GST"); 
                frmScan.MdiParent = Principal.ActiveForm;
                frmScan.Show();
            }
        }

        private void dgv_Click(object sender, EventArgs e)
        {

        }
    }
}
