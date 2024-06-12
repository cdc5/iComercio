using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using System.Data.Entity;
using DevExpress.XtraGrid.Views.Grid;
using iComercio.DAL;
using iComercio.Rest;
using iComercio.Models;
using iComercio.Delegados;
using iComercio.ViewModels;
using iComercio.Auxiliar;
using iComercio.Exceptions;
using Credin;


namespace iComercio.Forms
{
    public partial class frmAltaCredito : FRM
    {
        public event EventHandler<MensajeEventArgs> actualizarBarraDeEstado;
        public delegate void actualizarNombreBtn (Button btn, string s);

        actualizarNombreBtn delActBtn;
        private RestApi ra;
        BindingSource profesionesBs = new BindingSource();
        BindingSource complementoBs;
        BindingSource creditosBs =  new BindingSource();
        Cliente cli = null;
        Cliente cliM = null;
        int dni;
        Profesion profesion;
        Profesion Complemento;
        TipoDocumento TipoDocumento;
    
        
        public frmAltaCredito()
        {
            InitializeComponent();
        }

        public frmAltaCredito(Principal p, RestApi ra): base(p, ra)
        {
            InitializeComponent();
            Configura_Controles();
        }

        private void Configura_Controles()
        {
            this.BackColor = ColorBackColorFrm;
            Recorre_Formulario(this);
            xtabDatos.BackColor = ColorBackColorFrm;
            xtabDatos.Appearance.BackColor = ColorBackColorFrm;
            xtabDatos.AppearancePage.HeaderActive.BackColor = ColorBackColorInf;
            xtabDatos.AppearancePage.Header.BackColor = ColorBackColorFrm;
            xtabDatos.AppearancePage.PageClient.BorderColor = ColorBackColorFrm;
            xtabDatos.AppearancePage.PageClient.BackColor = ColorBackColorFrm;
            lblValida.Text = "";
        }
           
        private void frmAltaCredito_Load(object sender, EventArgs e)
        {
            //fitFormToScreen();
            RecargarEmpYComercio(false);
            delActBtn = new actualizarNombreBtn(ActualizarNombreBtn);
            profesionesBs.DataSource = bl.GetProfesionesPadres(BaseID,null, null, "ProfesionPadre");
            complementoBs = new BindingSource(profesionesBs, "SubProfesiones");
            Utilidades.CargarCombo(cmbTipoDni, bl.GetTiposDocumento().ToList(), "TipoDocumentoID", "TipoDocumentoID");
            Utilidades.CargarCombo(cmbProfesion, profesionesBs, "Nombre", "ProfesionID");
            Utilidades.CargarCombo(cmbComplemento, complementoBs, "Nombre", "ProfesionID");
            txtDNI.Focus();
            txtDNI.Select();
        }

        private void grSolCredito_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void cmbProfesion_SelectedIndexChanged(object sender, EventArgs e)
        {
            profesion = (Profesion)cmbProfesion.SelectedItem;
            //complementoBs.DataMember =((Profesion) cmbComplemento.SelectedItem).Nombre;
            
        }

        private void txtDNI_TextChanged(object sender, EventArgs e)
        {

        }
        private void LimpiarCampos()
        {
            cmbProfesion.SelectedIndex = -1;
            cmbComplemento.SelectedIndex = -1;
            cmbTipoDni.SelectedIndex = -1;
            TxtSueldo.Text = "0"; // String.Empty;
            txtValorNominal.Text = "0"; // String.Empty;
            lblCamaraLocal.Text = string.Empty;
            lblCamaraRemota.Text = string.Empty;
            rbSGarante.Checked = true;
            chkAdi.Checked = false;
            clienteBindingSource.DataSource = null;
            infoClienteBindingSource.DataSource = null;
            pbFotoDNI.Image = null;
            lblCamaraLocal.Text = string.Empty;
        }

        private bool ValidarDni(string dni)
        {
            int dniMax = 150000000;
            int iDni;   
            if (String.Empty != dni)
            {
                if (int.TryParse(dni, out iDni))
                {
                    if (iDni >= dniMax)
                    {
                        lblValida.Text = String.Format("No se puede ingresar un dni Mayor a {0}", dniMax);
                            //MessageBox.Show(String.Format("No se puede ingresar un dni Mayor a {0}", dniMax));
                    }
                    else
                        return true;
                }
                else
                {
                    lblValida.Text = String.Format("El formato introducido no es correcto", dniMax);
                    //MessageBox.Show(String.Format("El formato introducido no es correcto", dniMax));
                }
            }          
            return false;
        }


        private void txtDNI_Leave(object sender, EventArgs e)
        {
            lblValida.Text = "";
            if (txtDNI.Text == "" || txtDNI.Text == "0") return;
            if (!bgConsultaClienteRemota.IsBusy)
            {
                if (ValidarDni(txtDNI.Text))
                {
                    //txtDNI.Enabled = false;
                    LimpiarCampos();
                    pbFotoDNI.Image = BuscarImagen(txtDNI.Text);
                    int.TryParse(txtDNI.Text, out dni);
                    ObtenerDatosClientes(dni);
                }
            }
            else
            {
                lblValida.Text = "Obteniendo Datos De Casa Central, por favor espere.";
                //MessageBox.Show("Obteniendo Datos De Casa Central, por favor espere.");
            }
        }

        private Image BuscarImagen(string dni)
        {
            if (dni == "" || dni == "0") return null;
            return bl.BuscarFotosDni(dni);
        }

        private void AutoCompletarDatosCliente(string dni)
        {
            cmbTipoDni.SelectedValue = 1;
        }


        private void CargarProfesion(Profesion pro)
        {
            if (pro != null)
            {
                if (pro.ProfesionPadre != null)
                {
                    cmbProfesion.SelectedIndex = cmbProfesion.Items.IndexOf(cli.Profesion.ProfesionPadre);
                    cmbComplemento.SelectedIndex = cmbComplemento.Items.IndexOf(cli.Profesion);
                }
                else
                {
                    cmbProfesion.SelectedIndex = cmbProfesion.Items.IndexOf(cli.Profesion);
                }
            }
        }

        private void ObtenerDatosClientes(int dni)
        {
            //if (dni == 0) return;
            cli = bl.Get<Cliente>(c => c.Documento == dni).FirstOrDefault();
           
            if (lblMor.Visible) { 
                if (cli == null){
                    bl.Get<Cliente>(bl.pGlob.EmpresaM.EmpresaID.Value, c => c.Documento == dni).FirstOrDefault();
                }
            }

            if ( cli != null)
            {
                cmbTipoDni.SelectedIndex = cmbTipoDni.Items.IndexOf(cli.TipoDocumento);
                CargarProfesion(cli.Profesion);
                // ObtenerCreditos(cli);                
            }
            else
            {
                cli = new Cliente();
                cli.Documento = dni;
                cli.TipoDocumentoID = "DNI";
            }
            ObtenerMorosoEnCamara(dni);

            
            if (bl.pGlob.Configuracion.TransmisionHabilitada)
            {
                //btnAlta.Text = "Cancelar";
                //btnAlta.Text = "Obteniendo Datos De Casa Central";
                bgConsultaClienteRemota.RunWorkerAsync();         
            }
               
        }


        private void ObtenerCreditos(Cliente cli)
        {
            List<Credito> lcred = bl.Get<Credito>(c => c.Documento == cli.Documento && c.TipoDocumentoID == cli.TipoDocumentoID).ToList();
            creditosBs.DataSource = lcred;
            gridCreditos.DataSource = creditosBs;            
        }

        private void ObtenerMorosoEnCamara(int dni)
        {
            List<MorosoEnCamara> lcam = bl.ObtenerMorosoEnCamara(dni, null);
            if( lcam.Count > 0)
            {
                MorosoEnCamara mcam = lcam.First();
                lblCamaraLocal.Text = String.Format("FIGURA EN CAMARA LOCAL: {0} EN {1}", mcam.APNOCA, mcam.nombreEntidad);
                lblCamaraLocal.ForeColor = Color.Red;
            }
            else
            {
                lblCamaraLocal.Text = "No figura en cámara Local";
                lblCamaraLocal.ForeColor = Color.Black;                
            }
        }

        private void ActualizarNombreBtn(Button btn, string text)
        {
            btn.Text = text;
        }

        private void bgConsultaClienteRemota_DoWork(object sender, DoWorkEventArgs e)
        {
            bool EsM = lblMor.Visible;
            Task<InfoCliente> icM = null;
            MensajeEventArgs mens = new MensajeEventArgs("Obteniendo Datos De Casa Central");
            this.Invoke(delActBtn, btnAlta, "Cancelar");
            this.Invoke(actualizarBarraDeEstado, this, mens);
            Task<InfoCliente> ic = bl.ObtenerInfoCliente(bl.pGlob.Configuracion.RestUrlConexion,bl.pGlob.Comercio, cli);
           
            if (EsM)
            {
                icM = bl.ObtenerInfoCliente(bl.pGlob.Configuracion.RestUrlConexion, bl.pGlob.Comercio, cli);
            }


            while (!bgConsultaClienteRemota.CancellationPending && (!ic.IsCompleted || (EsM && !icM.IsCompleted)))
            {
                //System.Threading.Thread.Sleep(1000); // Para dormir al proceso mientras espera, y para que no labure tanto.
            }
            if (bgConsultaClienteRemota.CancellationPending)
            {
                 e.Cancel = true;
                 return;
            }
            if (ic.IsCompleted && (!ic.IsCanceled && !ic.IsFaulted))
            {
                InfoClienteComp icc = new InfoClienteComp();
                icc.ic = ic.Result;
                if (EsM)
                {
                    if (icM.IsCompleted && (!icM.IsCanceled && !icM.IsFaulted))
                        icc.icM = icM.Result;
                    else
                        icc.icM = null;
                }
                e.Result = icc;
            }            
            else
            {
                mens = new MensajeEventArgs("Error Al Obtener Informacion");
                this.Invoke(actualizarBarraDeEstado, this, mens);
                throw new TransmisionException(mens.mensaje);
            }
           
        }

        private void bgConsultaClienteRemota_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MensajeEventArgs mens;
            if (!e.Cancelled )
            {
                if (e.Error != null)
                {
                    mens = new MensajeEventArgs(e.Error.Message);
                    this.Invoke(actualizarBarraDeEstado, this, mens); 
                }
                else
                {
                    mens = new MensajeEventArgs("Datos Obtenidos");
                    this.Invoke(actualizarBarraDeEstado, this, mens);
                    InfoClienteComp ic = (InfoClienteComp)e.Result;
                    CargarDatosConsultaRemota(ic);
                    btnAlta.Enabled = true;
                }
               
            }
            else
            {
                mens = new MensajeEventArgs("Consulta Remota Cancelada");
                this.Invoke(actualizarBarraDeEstado, this, mens); 
            }
            btnAlta.Text = "Alta";
            txtDNI.Enabled = true;
            
        }

        private void CargarDatosConsultaRemota(InfoClienteComp icc)
        {
            if (icc.icM != null && icc.icM.CreditosMorosos != null)
                icc.ic.CreditosMorosos.AddRange(icc.icM.CreditosMorosos);
            infoClienteBindingSource.DataSource = icc.ic;
            if (icc.ic != null)
            {
                ExpandirCreditosMorosos();
                if (icc.ic.Cliente != null)
                    clienteBindingSource.DataSource = icc.ic.Cliente;

                if (icc.ic.Camara != null && icc.ic.Camara.Entidades != null && icc.ic.Camara.Entidades.Count() > 0)
                {
                    lblCamaraRemota.Text = String.Format("FIGURA EN CAMARA REMOTA: {0} ", icc.ic.Camara.ToString());
                    lblCamaraRemota.ForeColor = Color.Red;
                }
                else
                {
                    lblCamaraRemota.Text = "No figura en cámara Remota";
                    lblCamaraRemota.ForeColor = Color.Black;
                }
            }            
           
        }

        private void ExpandirCreditosMorosos()
        {
            GridView view = gridCreditos.FocusedView as GridView;
            int rHandle = view.FocusedRowHandle;
            view.SetMasterRowExpanded(rHandle, !view.GetMasterRowExpanded(rHandle));
        }


        private void clienteBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void grbCamara_Paint(object sender, PaintEventArgs e)
        {

            
        }

      

        private void btnAlta_Click(object sender, EventArgs e)
        {

            if (btnAlta.Text == "Cancelar")
            {
                if (bgConsultaClienteRemota.IsBusy)
                {
                    MensajeEventArgs mens = new MensajeEventArgs("Cancelando");
                    this.Invoke(actualizarBarraDeEstado,this, mens);
                    bgConsultaClienteRemota.CancelAsync();
                }
                else
                {
                    btnAlta.Text = "Alta";
                    txtDNI.Enabled = true;
                }
            }
            else
            {
                DarAlta();
            }
        }

        private void DarAlta()
        {
            string nombre = "";
            string apellido = "";
            decimal sueldo = 0;
            decimal valNom = 0;

            if (cli != null)
            {
                nombre = cli.Nombre;
                apellido = cli.Apellido;
            }

            decimal.TryParse(TxtSueldo.Text, out sueldo);
            decimal.TryParse(txtValorNominal.Text, out valNom);
            if (ValidarDatosParaAlta())
            {
                frmAltaCredito02 frmDarAlta = new frmAltaCredito02(p, this.bl, Convert.ToInt32(txtDNI.Text), cmbTipoDni.Text, 0, apellido, nombre ,
                                                           sueldo, valNom,cmbProfesion.SelectedValue.ToString(), cmbComplemento.SelectedValue.ToString(),
                                                           1, chkAdi.Checked, opGar1.Checked, opGar2.Checked, rbSGarante.Checked, lblMor.Visible, cmbProfesion.Text);
                frmDarAlta.MdiParent = this.MdiParent;
                frmDarAlta.WindowState = FormWindowState.Normal;
                frmDarAlta.Show();
            }           
        }

        private bool ValidarDatosParaAlta()
        {
            lblValida.Text = "";
            if (cmbTipoDni.SelectedItem == null)
            {
                lblValida.Text = "Seleccione un Tipo De Documento";
                cmbTipoDni.Focus();
                //MessageBox.Show("Seleccione un Tipo De Documento","Advertencia",MessageBoxButtons.OK);
                return false;
            }
            if (cmbProfesion.SelectedItem == null)
            {
                lblValida.Text = "Seleccione Profesión";
                cmbProfesion.Focus();
                //MessageBox.Show("Seleccione Profesión", "Advertencia", MessageBoxButtons.OK);
                return false;
            }
            if (cmbComplemento.SelectedItem == null)
            {
                lblValida.Text = "Seleccione Complemento";
                cmbComplemento.Focus();
                //MessageBox.Show("Seleccione Complemento", "Advertencia", MessageBoxButtons.OK);
                return false;
            }
            if (txtValorNominal.Text == "") txtValorNominal.Text = "0";
            if (Convert.ToDecimal(txtValorNominal.Text) == 0)   //if (txtValorNominal.Text == "0" || txtValorNominal.Text == String.Empty)
            {
                lblValida.Text = "Ingrese Valor Nominal";
                txtValorNominal.SelectAll();
                txtValorNominal.Focus();
                //MessageBox.Show("Ingrese Valor Nominal", "Advertencia", MessageBoxButtons.OK);
                return false;
            } 
            if (TxtSueldo.Text == "") TxtSueldo.Text = "0";
            if (Convert.ToDecimal(TxtSueldo.Text) == 0)   //if (TxtSueldo.Text == "0" || TxtSueldo.Text == String.Empty)
            {
                lblValida.Text = "Ingrese Sueldo";
                TxtSueldo.SelectAll();
                TxtSueldo.Focus();

                //MessageBox.Show("Ingrese Sueldo", "Advertencia", MessageBoxButtons.OK);
                return false;
            }

            return true;
        }

        private void cmbTipoDni_SelectedIndexChanged(object sender, EventArgs e)
        {
            TipoDocumento = (TipoDocumento)cmbTipoDni.SelectedItem;
        }

        private void cmbComplemento_SelectedIndexChanged(object sender, EventArgs e)
        {
            Complemento = (Profesion)cmbProfesion.SelectedItem;
        }

        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloNumeros(e);
        }

        private void grbEstado_Paint(object sender, PaintEventArgs e)
        {

        }

        private void infoClienteBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void grSolCredito_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DevExpress.XtraPrinting.XlsxExportOptions xop = new DevExpress.XtraPrinting.XlsxExportOptions();
            //gridView5.ExportToXlsx("C:\\Excel.xlsx");
            //gridView7.ExportToXlsx("C:\\Excel2.xlsx");
            gridView5.OptionsPrint.PrintDetails = true;
            gridView5.OptionsPrint.ExpandAllDetails = true;
            gridControl1.ExportToXlsx("C:\\Excel.xlsx");
        }

        private void frmAltaCredito_KeyDown(object sender, KeyEventArgs e)
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

        private void chkAdicional_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAdi.Checked)
            {
                opGar1.Checked = false;
                opGar2.Checked = false;
            }
            Utilidades.HabilitarControles(!chkAdi.Checked, opGar1, opGar2);
        }

        private void btnGrabaCredito_Click(object sender, EventArgs e)
        {

        }

        private void gridControl1_Click_1(object sender, EventArgs e)
        {

        }

        private void lblValida_Click(object sender, EventArgs e)
        {

        }

        private void cmbTipoDni_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
