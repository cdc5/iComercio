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
using Credin;
using iComercio.Auxiliar;
using iComercio.Rest.RestModels;
using System.Threading;
using System.Threading.Tasks;


namespace iComercio.Forms
{
    public partial class frmActualizaciones : FRM
    {
        Comercio ComerBusca;
        private System.Threading.Timer timerRefresh;
        int tiempo=30000;
        int CantRegs = 500;

        public frmActualizaciones()
        {
            InitializeComponent();
        }

        public frmActualizaciones(Principal p, BusinessLayer bl):base(p,bl)
        {
            InitializeComponent();
        }       

        private void frmActualizaciones_Load(object sender, EventArgs e)
        {
            RecargarEmpYComercio(false);
            CargarComercios();
            CargarLog(CantRegs);
            timerRefresh = new System.Threading.Timer(timerRefreshTick, null, tiempo, Timeout.Infinite);
        }

        private async void timerRefreshTick(Object stateInfo)
        {
            //return;
            CargarLog(CantRegs);
            timerRefresh.Change(tiempo, Timeout.Infinite); // Esta sentencia reinicia el timer, que fue instanciado como one-shot
        }

        private void CargarLog(int cant)
        {
            lbLog.DataSource = null;
            lbLog.DataSource = bl.Get<Log>(Com.EmpresaID,null, o => o.OrderByDescending(c => c.LogID), "", cant).ToList();
            lbLog.ValueMember = "LogID";
            lbLog.DisplayMember = "sLog";
        }

        private void CargarComercios()
        {
            List<Comercio> comers = bl.GetComercios(BaseID);
            Utilidades.CargarCombo(cmbComercio, comers, "NumeroYNombre", "ComercioID",1);
            //Utilidades.CargarCombo(cmbComercio2, comers, "NumeroYNombre", "ComercioID", 1);
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
           lbLog.DataSource = await bl.ProcesarInfoAct(Com,ComerBusca, dtpDesde.Value, dtpHasta.Value);
        }

        private void cmbComercio_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComerBusca =(Comercio)cmbComercio.SelectedItem;
            if (ComerBusca == null)
            {
                MessageBox.Show("Debe elegir un comercio");
            }
        }

        private async void btnXCredito_Click(object sender, EventArgs e)
        {
            int cred = System.Convert.ToInt32(txtCredito.Text);
            lbLogCred.DataSource = await bl.ProcesarInfoAct(Com, ComerBusca, cred);
        }

        private void cmbComercio2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComerBusca = (Comercio)cmbComercio.SelectedItem;
            if (ComerBusca == null)
            {
                MessageBox.Show("Debe elegir un comercio");
            }
        }

        private async void btnAuto_Click(object sender, EventArgs e)
        {
            List<Comercio> comers = new List<Comercio>();
            comers.Add(Com);
            lbLogAuto.DataSource = await bl.ProcesarInfoActAuto(Com, comers, dtpDesde.Value, dtpHasta.Value);
        }

        private void xtabControl_TabIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void xtabControl_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (e.Page.Name == "xTabPagePorFecha")
            {
                groupControl1.Controls.Add(this.lblComercio);
                groupControl1.Controls.Add(this.cmbComercio);
            }
            else if (e.Page.Name == "xTabPagePorCredito")
            {
                groupControl2.Controls.Add(this.lblComercio);
                groupControl2.Controls.Add(this.cmbComercio);
            }
            else if (e.Page.Name == "xTabPageAuto")
            {
                grpConf.Controls.Add(this.lblComercio);
                grpConf.Controls.Add(this.cmbComercio);
                grpConf.Controls.Add(this.lblDesde);
                grpConf.Controls.Add(this.dtpDesde);
                grpConf.Controls.Add(this.lblHasta);
                grpConf.Controls.Add(this.dtpHasta);                
            }




        }

        private void btnAuto_Click_1(object sender, EventArgs e)
        {

        }

        private void txtAct_TextChanged(object sender, EventArgs e)
        {
            bool result = int.TryParse(txtAct.Text, out tiempo);
            if (result)
                tiempo = tiempo * 1000;
        }

        private void txtAct_KeyPress(object sender, KeyPressEventArgs e)
        {
            Formato.Solonumeros(e, true);
        }

        private void txtCantRegs_TextChanged(object sender, EventArgs e)
        {
            bool result = int.TryParse(txtCantRegs.Text, out CantRegs);               
        }

        private void txtCantRegs_KeyPress(object sender, KeyPressEventArgs e)
        {
            Formato.Solonumeros(e, true);
        }

       

        
    }
}
