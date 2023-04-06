using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using iComercio.Rest;
using iComercio.Rest.RestModels;
using iComercio.Models;
using iComercio.Delegados;
using iComercio.ViewModels;
using iComercio.Auxiliar;
using Credin;
using iComercio.DAL;


namespace iComercio.Forms
{
    public partial class FrmOpciones : FRM
    {
        private const int MultiplicadorTiempoEnvio = 1000;
        Impresora Impresora;
        TipoImpresion TipoImpresion;
        String LlevaM = "";

        public FrmOpciones()
        {
            InitializeComponent();
        }
         
        public FrmOpciones(Principal p, RestApi ra): base(p, ra)
        {
            InitializeComponent();
            RecargarEmpYComercio(false);
        }

         
        private void Configuracion_Load(object sender, EventArgs e)
        {
            ConfigurarOpenFileDialogParaCarpeta(ofd);
            CargarRutas();
            CrearNodos();
            Utilidades.CargarComboGeneric<MetodoFuncionamiento>(cmbLlevaMor, bl.GetMetodosFuncionamiento(), "Nombre", "MetodoFuncionamientoID");
            CargarConfiguracionesEnControles();
            CargarImpresoras();
            CargarTiposImpresiones();
            CargarEmpresas();
            CargarComercios();
            CargarComerciosActs();
            Recorre_Formulario(this);
            //Marca_Comercio();
        }

        private void CargarComerciosActs()
        {
            lbComers.DataSource = bl.Get<Comercio>(Com.EmpresaID, c => c.Actualiza.Value).ToList();
            lbComers.ValueMember = "ComercioID";
            lbComers.DisplayMember = "NumeroYNombre";
        }        

        public void CargarComercios()
        {
            bsComercio.DataSource = bl.Get<Comercio>().ToList();
            dgvComer.DataSource = bsComercio;
            //Marca_Comercio();
        }
        private void Marca_Comercio()
        {
            lblErrorComer.Visible = false;
            lblErrorComer.Text = "";
            int nCant = 0;
            for(int n = 0; n <= dgvComer.Rows.Count -1; n++)
            {
                if(Convert.ToBoolean( dgvComer.Rows[n].Cells[2].Value)) //.ToString() == "")
                {
                    dgvComer.Rows[n].DefaultCellStyle.BackColor = Color.LightGray;
                    nCant++;
                }
            }
            if(nCant != 1)
            {
                lblErrorComer.Text = "ERROR en comercios: hay mas de un principal";
                lblErrorComer.Visible = true;
            }
        }
        public void CargarEmpresas()
        {
            bsEmpresa.DataSource = bl.Get<Empresa>().ToList();
            dgvEmpresa.DataSource = bsEmpresa;
        }

        private void ConfigurarOpenFileDialogParaCarpeta(OpenFileDialog ofd) {
            ofd.ValidateNames = false;
            ofd.CheckFileExists = false;
            ofd.CheckPathExists = true;
            ofd.FileName = ""; //esto es para que permita seleccionar carpetas. Ponemos cualquier patron que no se encuentre
        }

        private void CargarConfiguracionesEnControles()
        {
            txtUrlConexion.Text = bl.pGlob.Configuracion.RestUrlConexion;
            nudPeriodoEnvio.Value = bl.pGlob.Configuracion.TiempoEnvioTransmisiones / MultiplicadorTiempoEnvio;
            nudPeriodoActSolfon.Value = bl.pGlob.Configuracion.TiempoActualizacionSolicitarFondos / MultiplicadorTiempoEnvio;
            nudPeriodoEnvioRev.Value = bl.pGlob.Configuracion.TiempoEnvioRevisiones / MultiplicadorTiempoEnvio;
            nudPeriodoEnvioNov.Value = bl.pGlob.Configuracion.TiempoEnvioNovedades / MultiplicadorTiempoEnvio;
            nudReintentos.Value = bl.pGlob.Configuracion.ReintentosTransmisiones;
            nudReintentosSol.Value = bl.pGlob.Configuracion.ReintentosTransmisionesSol;
            nudReintentosErr.Value = bl.pGlob.Configuracion.ReintentosTransmisionesErr;
            chkTransHab.Checked = bl.pGlob.Configuracion.TransmisionHabilitada;
            chkTransHabM.Checked = bl.pGlob.Configuracion.TransmisionHabilitadaM;
            nudDiasSolfon.Value = bl.pGlob.Configuracion.solfonDiasParaAtras;
            nudDiasRev.Value = bl.pGlob.Configuracion.diasRevisionesParaAtras;
       
            txtTitulo.Text = bl.pGlob.Configuracion.Titulo;
            txtFinancia.Text = bl.pGlob.Configuracion.Financia;
            txtAltaTribunales.Text = bl.pGlob.Configuracion.AltaTribunales;
            txtAltaLugar.Text = bl.pGlob.Configuracion.AltaLugar;
            txtNumCredInicial.Text = "1";
            chkImprimirComprobantes.Checked = bl.pGlob.Configuracion.ImprimirComprobantes;
            chkImprimirCompCob.Checked = bl.pGlob.Configuracion.ImprimirComprobantesCob;
            chkImpCobTalonCom.Checked = bl.pGlob.Configuracion.ImprimirCobTalonComercio;
            chkImprimirCredTalonCom.Checked = bl.pGlob.Configuracion.ImprimirCredTalonComercio;

            

            txtMaxMontoMen.Text = bl.pGlob.Configuracion.MaxMontoMensual.ToString();
            txtMontoFF.Text = bl.pGlob.Configuracion.MontoFF.ToString();

            txtMinHReduxIndex.Text = bl.pGlob.Configuracion.MinIndiceHRedux.ToString();
            txtMinWReduxIndex.Text = bl.pGlob.Configuracion.MinIndiceWRedux.ToString();
            txtMinFontReduxIndex.Text = bl.pGlob.Configuracion.MinIndiceFontRedux.ToString();

            /*Test*/
            txtUrlConexionTest.Text = bl.pGlob.Configuracion.TestRestUrlConexion;
            chkTestMode.Checked = bl.pGlob.Configuracion.TestMode;

            chkAutAltas.Checked  = bl.pGlob.Configuracion.AutenticaAltaCredito;
            chkAutCob.Checked = bl.pGlob.Configuracion.AutenticaCobranza;

            /**M**/
            txtURLConexionM.Text = bl.pGlob.Configuracion.RestUrlConexionM;
            txtMontoMax.Text = bl.pGlob.Configuracion.nLlevaMorMax.ToString();
            txtPorcentFinan.Text = bl.pGlob.Configuracion.nLlevaMorPorcentFinan.ToString();
            cmbLlevaMor.SelectedItem = ((List<MetodoFuncionamiento>)cmbLlevaMor.DataSource).Find(t => t.MetodoFuncionamientoID == bl.pGlob.Configuracion.cLlevaMor);
            /**M**/



            //Acts
            chkPropio.Checked = bl.pGlob.Configuracion.bPropio;
            chkActComercio.Checked = bl.pGlob.Configuracion.bActComercios ;
            chkHabilitarAct.Checked = bl.pGlob.Configuracion.bActHabilitada;
            nudPerActs.Value =  bl.pGlob.Configuracion.TiempoActs / MultiplicadorTiempoEnvio;
            rbEF.Checked =  bl.pGlob.Configuracion.bActEF;
            rbDesde.Checked = bl.pGlob.Configuracion.bActDesde;
            dtpActDesde.Value = bl.pGlob.Configuracion.ActDesde;
            dtpActHasta.Value =  bl.pGlob.Configuracion.ActHasta;

            //Acts Log
            nudRegsLog.Value = bl.pGlob.Configuracion.RegsLog;
            nudImpBoni.Value = bl.pGlob.Configuracion.CantImpBoni;

            //BD

            txtNombreBD.Text = bl.pGlob.Configuracion.NombreBD;
            txtNombreBDMig.Text = bl.pGlob.Configuracion.NombreBDMig;


            txtArreglo1.Text = bl.pGlob.Configuracion.dArreglo01.ToString();//edu20211207
            txtArreglo2.Text = bl.pGlob.Configuracion.dArreglo02.ToString();//edu20211207
            txtArreglo3.Text = bl.pGlob.Configuracion.dArreglo03.ToString();//edu20211207
            txtArregloMeses.Text = bl.pGlob.Configuracion.nArregloMeses.ToString();//edu20211207

            txtRedondeo.Text = bl.pGlob.Configuracion.nRedondeo.ToString();

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            switch (e.Node.Name)
            {
                case "conexion":
                    tltc.SelectTab("tabConexion");
                    break;
                case "rutas":
                    tltc.SelectTab("tabRutas");
                    break;
                case "Impresoras":
                    tltc.SelectTab("tabImpresoras");
                    break;
                case "Impresiones":
                    tltc.SelectTab("tabImpresiones");
                    break;
                case "Opciones2":
                    tltc.SelectTab("tabM");
                    break;
                case "Test":
                    tltc.SelectTab("tabTest");
                    break;
                case "Permisos":
                    tltc.SelectTab("tabPermisos");
                    break;
                case "Comercios":
                    tltc.SelectTab("tabComercios");
                    Marca_Comercio();
                    break;
                case "Empresas":
                    tltc.SelectTab("tabEmpresas");
                    break;
                case "Pantalla":
                    tltc.SelectTab("tabPantalla");
                    break;
                case "Actualizaciones":
                    tltc.SelectTab("tabActualizaciones");
                    break;
                case "FTP":
                    tltc.SelectTab("tabFTP");
                    break;
                case "Porcentajes":
                    tltc.SelectTab("tabPorcentajes");
                    break;
                default:
                    tltc.SelectTab("tabOtro");
                    break;
            }
        }

        private void treeView1_Click(object sender, EventArgs e)
        {
            
        }

        private void CrearNodos()
        {
            TreeNode tnConex;
            TreeNode tnRutas;
            TreeNode tnOtro;
            TreeNode tnImpresoras;
            TreeNode tnImpresiones; 
            TreeNode tnTest;
            TreeNode tnPermisos;
            TreeNode tnComercios;
            TreeNode tnEmpresas;
            TreeNode tnPantalla;
            TreeNode tnActualizaciones;
            TreeNode tnFTP;
            TreeNode tnPorcentajes;

            if(p.usu.GetPermisosNombres().Contains("Admin"))
            {
                tnConex = new TreeNode("Conexión");
                tnConex.Name = "conexion";
                trv.Nodes.Insert(0,tnConex);
                //trv.Nodes.Add(tnConex);

                tnRutas = new TreeNode("Rutas");
                tnRutas.Name = "rutas";
                trv.Nodes.Insert(1, tnRutas);
                //trv.Nodes.Add(tnRutas);

                tnOtro = new TreeNode("Otro");
                tnOtro.Name = "otro";
                trv.Nodes.Insert(2, tnOtro);
                //trv.Nodes.Add(tnOtro);
                               

                tnImpresiones = new TreeNode("Impresiones");
                tnImpresiones.Name = "Impresiones";
                //trv.Nodes.Insert(4, tnImpresiones);
                trv.Nodes.Add(tnImpresiones);

                tnTest = new TreeNode("Test");
                tnTest.Name = "Test";
                trv.Nodes.Insert(5, tnTest);
                //trv.Nodes.Add(tnTest);

                tnPermisos = new TreeNode("Permisos");
                tnPermisos.Name = "Permisos";
                trv.Nodes.Insert(6, tnPermisos);
                //trv.Nodes.Add(tnPermisos);

                tnComercios = new TreeNode("Comercios");
                tnComercios.Name = "Comercios";
                trv.Nodes.Insert(7, tnComercios);
                //trv.Nodes.Add(tnComercios);

                tnEmpresas = new TreeNode("Empresas");
                tnEmpresas.Name = "Empresas";
                trv.Nodes.Insert(8, tnEmpresas);
                //trv.Nodes.Add(tnEmpresas);

                tnPantalla = new TreeNode("Pantalla");
                tnPantalla.Name = "Pantalla";
                trv.Nodes.Insert(9, tnPantalla);
                //trv.Nodes.Add(tnPantalla);

                tnActualizaciones = new TreeNode("Actualizaciones");
                tnActualizaciones.Name = "Actualizaciones";
                trv.Nodes.Insert(10, tnActualizaciones);
                //trv.Nodes.Add(tnActualizaciones);


            }

            tnImpresoras = new TreeNode("Impresoras");
            tnImpresoras.Name = "Impresoras";
            //trv.Nodes.Insert(3, tnImpresoras);
            trv.Nodes.Add(tnImpresoras);
            
            if (p.usu.GetPermisosNombres().Contains("Admin"))
            {
                tnFTP = new TreeNode("FTP");
                tnFTP.Name = "FTP";
                trv.Nodes.Insert(11, tnFTP);
                
                tnPorcentajes = new TreeNode("Porcentajes");
                tnPorcentajes.Name = "Porcentajes";
                trv.Nodes.Insert(12, tnPorcentajes);            }
        }

        private void CargarImpresoras()
        {
            bsImpresoras.DataSource = GetNombresImpresoras();
            dgvImpresoras.DataSource = bsImpresoras;            
        }

        private void CargarTiposImpresiones()
        {
            dgvTipoImpresion.DataSource = bl.Get<TipoImpresion>();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            GuardarConfiguracion();
            this.Close();
        }

        private void GuardarConfiguracion()
        {
            //Conexión
            bl.pGlob.Configuracion.RestUrlConexion = txtUrlConexion.Text;
            bl.pGlob.Configuracion.TiempoEnvioTransmisiones = System.Convert.ToInt32(nudPeriodoEnvio.Value) * MultiplicadorTiempoEnvio;
            bl.pGlob.Configuracion.TiempoActualizacionSolicitarFondos = System.Convert.ToInt32(nudPeriodoActSolfon.Value) * MultiplicadorTiempoEnvio;
            bl.pGlob.Configuracion.TiempoEnvioRevisiones = System.Convert.ToInt32(nudPeriodoEnvioRev.Value) * MultiplicadorTiempoEnvio;
            bl.pGlob.Configuracion.TiempoEnvioNovedades = System.Convert.ToInt32(nudPeriodoEnvioNov.Value) * MultiplicadorTiempoEnvio;
            bl.pGlob.Configuracion.TransmisionHabilitada = chkTransHab.Checked;
            bl.pGlob.Configuracion.TransmisionHabilitadaM = chkTransHabM.Checked;
            bl.pGlob.Configuracion.ReintentosTransmisiones = System.Convert.ToInt32(nudReintentos.Value);
            bl.pGlob.Configuracion.ReintentosTransmisionesSol = System.Convert.ToInt32(nudReintentosSol.Value);
            bl.pGlob.Configuracion.ReintentosTransmisionesErr = System.Convert.ToInt32(nudReintentosErr.Value);
            bl.pGlob.Configuracion.solfonDiasParaAtras = System.Convert.ToInt32(nudDiasSolfon.Value);
            bl.pGlob.Configuracion.diasRevisionesParaAtras = System.Convert.ToInt32(nudDiasRev.Value);

            //Rutas
            bl.pGlob.ConfLocal.rutaPdfAutorizacionRetCob = txtRutaAutRetCob.Text;
            bl.pGlob.ConfLocal.rutaPdfAutorizacionExtBan = txtRutaAutExtBan.Text;
            bl.pGlob.ConfLocal.rutaPdfAutorizacionGuardado = txtAutGuardado.Text;

            bl.pGlob.Configuracion.rutaScriptBD = txtScriptBd.Text;
            bl.pGlob.Configuracion.rutaImagenes = txtImagenes.Text;
            bl.pGlob.Configuracion.rutaFotos= txtFotos.Text;
            bl.pGlob.Configuracion.rutaComprIma = txtCompr.Text;
            bl.pGlob.Configuracion.rutaSolicitudes = txtSolicitudes.Text; //edunvo202112
            bl.pGlob.Configuracion.ScanSolicitudes = chkSolicitudes.Checked;//edunvo202112



            // FTP //

            //bl.pGlob.Configuracion.ftpServer = txtFTPServer.Text;
            //bl.pGlob.Configuracion.ftpUsu = txtFTPUsu.Text;
            //bl.pGlob.Configuracion.ftpClave = txtFTPClave.Text;

            //bl.pGlob.Configuracion.rutaFTPImagenes = txtFTPImacli.Text;
            //bl.pGlob.Configuracion.rutaFTPFotos = txtFTPFotos.Text;
            //bl.pGlob.Configuracion.rutaFTPComrp = txtFTPCompr.Text;


            bl.pGlob.Configuracion.Titulo = txtTitulo.Text;
            bl.pGlob.Configuracion.Financia = txtFinancia.Text;
            bl.pGlob.Configuracion.AltaLugar = txtAltaLugar.Text;
            bl.pGlob.Configuracion.AltaTribunales = txtAltaTribunales.Text;

            /* sufijos y prefijos archivos */
            bl.pGlob.Configuracion.suf_sol1 = "_SOL_01";
            bl.pGlob.Configuracion.suf_sol2 = "_SOL_02";
            bl.pGlob.Configuracion.suf_sol3 = "_SOL_03";

            bl.pGlob.Configuracion.suf_ser1 = "_SER_01";
            bl.pGlob.Configuracion.suf_ser2 = "_SER_02";
            bl.pGlob.Configuracion.suf_ser3 = "_SER_03";

            bl.pGlob.Configuracion.suf_otr1 = "_OTR_01";
            bl.pGlob.Configuracion.suf_otr2 = "_OTR_02";
            bl.pGlob.Configuracion.suf_otr3 = "_OTR_03";

            bl.pGlob.Configuracion.suf_doc1 = "_DOC_01";
            bl.pGlob.Configuracion.suf_doc2 = "_DOC_02";
            bl.pGlob.Configuracion.suf_doc3 = "_DOC_03";

            bl.pGlob.Configuracion.suf_rec1 = "_REC_01";
            bl.pGlob.Configuracion.suf_rec2 = "_REC_02";
            bl.pGlob.Configuracion.suf_rec3 = "_REC_03";

            bl.pGlob.Configuracion.suf_fir1 = "_FIR_01";
            bl.pGlob.Configuracion.suf_fir2 = "_FIR_02";
            bl.pGlob.Configuracion.suf_fir3 = "_FIR_03";


            bl.pGlob.Configuracion.NumCredInicial = System.Convert.ToInt32(txtNumCredInicial.Text);
            bl.pGlob.Configuracion.ImprimirComprobantes = chkImprimirComprobantes.Checked;
            bl.pGlob.Configuracion.ImprimirComprobantesCob = chkImprimirCompCob.Checked;
            bl.pGlob.Configuracion.ImprimirCobTalonComercio = chkImpCobTalonCom.Checked;
            bl.pGlob.Configuracion.ImprimirCredTalonComercio = chkImprimirCredTalonCom.Checked;
            bl.pGlob.Configuracion.MaxMontoMensual = System.Convert.ToDecimal(txtMaxMontoMen.Text);

            bl.pGlob.Configuracion.AutenticaAltaCredito = chkAutAltas.Checked;
            bl.pGlob.Configuracion.AutenticaCobranza = chkAutCob.Checked;

            bl.pGlob.Configuracion.MontoFF = System.Convert.ToInt32(txtMontoFF.Text);

            bl.pGlob.Configuracion.MinIndiceHRedux = (float)System.Convert.ToDouble(txtMinHReduxIndex.Text);
            bl.pGlob.Configuracion.MinIndiceWRedux = (float)System.Convert.ToDouble(txtMinWReduxIndex.Text);
            bl.pGlob.Configuracion.MinIndiceFontRedux = (float)System.Convert.ToDouble(txtMinFontReduxIndex.Text);

            /*Test*/
            bl.pGlob.Configuracion.TestRestUrlConexion = txtUrlConexionTest.Text;
            bl.pGlob.Configuracion.TestMode = chkTestMode.Checked;
                        
            /**M**/
            bl.pGlob.Configuracion.RestUrlConexionM = txtURLConexionM.Text;
            bl.pGlob.Configuracion.nLlevaMorPorcentFinan = System.Convert.ToInt32(txtPorcentFinan.Text);
            bl.pGlob.Configuracion.nLlevaMorMax = System.Convert.ToInt32(txtMontoMax.Text);
            bl.pGlob.Configuracion.cLlevaMor = LlevaM;
            bl.pGlob.Configuracion.rutaComprImaMor = txtComprM.Text;
            bl.pGlob.Configuracion.rutaSolicitudesMor = txtSolicitudesM.Text; //edunvo202112
            bl.pGlob.Configuracion.rutaFTPComrpMor = txtFTPComprM.Text;
            bl.pGlob.Configuracion.rutaFTPSolicitudesMor = txtFTPSolicitudesM.Text;

            /**M**/

            //Acts
            bl.pGlob.Configuracion.bPropio = chkPropio.Checked;
            bl.pGlob.Configuracion.bActComercios = chkActComercio.Checked;
            bl.pGlob.Configuracion.bActHabilitada = chkHabilitarAct.Checked;
            bl.pGlob.Configuracion.TiempoActs = System.Convert.ToInt32(nudPerActs.Value) * MultiplicadorTiempoEnvio;
            bl.pGlob.Configuracion.bActEF = rbEF.Checked;
            bl.pGlob.Configuracion.bActDesde = rbDesde.Checked;
            bl.pGlob.Configuracion.ActDesde = dtpActDesde.Value;
            bl.pGlob.Configuracion.ActHasta = dtpActHasta.Value;

            bl.pGlob.Configuracion.RegsLog = System.Convert.ToInt32(nudRegsLog.Value);
            bl.pGlob.Configuracion.CantImpBoni = System.Convert.ToInt32(nudImpBoni.Value);

            // FTP //
            bl.pGlob.Configuracion.ftpServer = txtFTPServer.Text; 
            bl.pGlob.Configuracion.ftpUsu = txtFTPUsu.Text; 
            bl.pGlob.Configuracion.ftpClave = txtFTPClave.Text; 

            bl.pGlob.Configuracion.rutaFTPImagenes = txtFTPImacli.Text;
            bl.pGlob.Configuracion.rutaFTPFotos = txtFTPFotos.Text; 
            bl.pGlob.Configuracion.rutaFTPComrp = txtFTPCompr.Text;
            bl.pGlob.Configuracion.rutaFTPSolicitudes = txtFTPSolicitudes.Text;

            //BD
            bl.pGlob.Configuracion.NombreBD = txtNombreBD.Text;
            bl.pGlob.Configuracion.NombreBDMig = txtNombreBDMig.Text;

            //porcentajes
            bl.pGlob.Configuracion.dArreglo01 = Convert.ToDecimal(txtArreglo1.Text);//edu20211207
            bl.pGlob.Configuracion.dArreglo02 = Convert.ToDecimal(txtArreglo2.Text);//edu20211207
            bl.pGlob.Configuracion.dArreglo03 = Convert.ToDecimal(txtArreglo3.Text);//edu20211207
            bl.pGlob.Configuracion.nArregloMeses = Convert.ToInt32(txtArregloMeses.Text);//edu20211207

            bl.pGlob.Configuracion.nRedondeo = Convert.ToInt32(txtRedondeo.Text);

            bl.pGlob.Configuracion.Write();
            bl.pGlob.ConfLocal.Write();


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(Properties.Resources.AdvertenciaCerrando, Properties.Resources.Advertencia,
                                             MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        
        private List<Impresora> GetNombresImpresoras()
        {
            List<Impresora> impresoras = new List<Impresora>();
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                impresoras.Add(new Impresora { Nombre = printer });
            }
            return impresoras;
        }

        
        //private void GetImpresoras()
        //{
        //    var printerQuery = new ManagementObjectSearcher("SELECT * from Win32_Printer");1
        //    foreach (var printer in printerQuery.Get())
        //    {
        //        var name = printer.GetPropertyValue("Name");
        //        var status = printer.GetPropertyValue("Status");
        //        var isDefault = printer.GetPropertyValue("Default");
        //        var isNetworkPrinter = printer.GetPropertyValue("Network");

        //        Console.WriteLine("{0} (Status: {1}, Default: {2}, Network: {3}",
        //                    name, status, isDefault, isNetworkPrinter);
        //    }
        //}

        private void FrmConfiguracion_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void tabConexion_Click(object sender, EventArgs e)
        {

        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            bl.GenerarDatosMaestros();
        }

        private void btnRutaAutorizaciones_Click(object sender, EventArgs e)
        {
            LeerRuta(txtRutaAutRetCob);
        }

        private void LeerRuta(TextBox txt)
        {
            DialogResult result = ofd.ShowDialog();
            if (result == DialogResult.OK) 
            {
                txt.Text = ofd.FileName;
            }
        }

        private void LeerRutaCarpeta(TextBox txt)
        {
            DialogResult result = ofd.ShowDialog();
            if (result == DialogResult.OK) 
            {
                txt.Text = System.IO.Path.GetDirectoryName(ofd.FileName); ;
            }
            Console.WriteLine(result); 
        }

        private void CargarRutas()
        {
            txtRutaAutRetCob.Text = bl.pGlob.ConfLocal.rutaPdfAutorizacionRetCob;
            txtRutaAutExtBan.Text = bl.pGlob.ConfLocal.rutaPdfAutorizacionExtBan;
            txtAutGuardado.Text = bl.pGlob.ConfLocal.rutaPdfAutorizacionGuardado;
            txtScriptBd.Text = bl.pGlob.Configuracion.rutaScriptBD;
            txtImagenes.Text = bl.pGlob.Configuracion.rutaImagenes;
            txtFotos.Text = bl.pGlob.Configuracion.rutaFotos;
            txtCompr.Text = bl.pGlob.Configuracion.rutaComprIma;

            // FTP //

            txtFTPServer.Text = bl.pGlob.Configuracion.ftpServer;
            txtFTPUsu.Text = bl.pGlob.Configuracion.ftpUsu;
            txtFTPClave.Text = bl.pGlob.Configuracion.ftpClave;

            txtFTPImacli.Text = bl.pGlob.Configuracion.rutaFTPImagenes;
            txtFTPFotos.Text = bl.pGlob.Configuracion.rutaFTPFotos;
            txtFTPCompr.Text = bl.pGlob.Configuracion.rutaFTPComrp;
            txtFTPSolicitudes.Text = bl.pGlob.Configuracion.rutaFTPSolicitudes;
            txtSolicitudes.Text = bl.pGlob.Configuracion.rutaSolicitudes; //edunvo202112
            chkSolicitudes.Checked = bl.pGlob.Configuracion.ScanSolicitudes;//edunvo202112

            txtComprM.Text = bl.pGlob.Configuracion.rutaComprImaMor;
            txtSolicitudesM.Text = bl.pGlob.Configuracion.rutaSolicitudesMor;
            txtFTPComprM.Text = bl.pGlob.Configuracion.rutaFTPComrpMor;
            txtFTPSolicitudesM.Text = bl.pGlob.Configuracion.rutaFTPSolicitudesMor;
        }

        private void btnRutaAutExtBan_Click(object sender, EventArgs e)
        {
            LeerRuta(txtRutaAutExtBan);
        }

        private void btnRutaAutGuardado_Click(object sender, EventArgs e)
        {
            LeerRutaCarpeta(txtAutGuardado);
        }

        private void btnRutaScriptBD_Click(object sender, EventArgs e)
        {
            LeerRuta(txtScriptBd);
        }

        private void btnRutaImagenes_Click(object sender, EventArgs e)
        {
            LeerRutaCarpeta(txtImagenes);
        }

        private void btnRutaFotos_Click(object sender, EventArgs e)
        {
            LeerRutaCarpeta(txtFotos);
        }

        private void txtImagenes_TextChanged(object sender, EventArgs e)
        {

        }

       

        private void dgvTipoImpresion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvTipoImpresion_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dgvTipoImpresion_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DefinirImpresoraTipoImpresion((TipoImpresion)dgvTipoImpresion.SelectedRows[0].DataBoundItem);
            }
        }

        private void DefinirImpresoraTipoImpresion(TipoImpresion t)
        {
            if (dgvTipoImpresion.SelectedRows.Count > 0)
            {
                TipoImpresion = t;
                if (TipoImpresion != null && Impresora != null)
                {
                    TipoImpresion.Impresora = Impresora.Nombre;
                    bl.Actualizar<TipoImpresion>(TipoImpresion);
                    CargarTiposImpresiones();
                }

            }
        }


        private void dgvImpresoras_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (dgvImpresoras.SelectedRows.Count > 0)
                {
                    Impresora = (Impresora)dgvImpresoras.SelectedRows[0].DataBoundItem;
                }
            }
        }

        private void dgvImpresoras_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void txtRutaAutRetCob_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNumCredInicial_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmOpciones_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                if (e.Shift)
                {
                    CargarM();
                }
            }
           
        }

        private void FrmOpciones_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void CargarM()
        {
            TreeNode tnM;
            tnM = new TreeNode("Opciones 2");
            tnM.Name = "Opciones2";
            trv.Nodes.Add(tnM);
            trv.SelectedNode = tnM;
        }


        private void cmbLlevaMor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLlevaMor.SelectedItem != null)
                LlevaM =((MetodoFuncionamiento)cmbLlevaMor.SelectedItem).MetodoFuncionamientoID;
        }

        private void chkTransHab_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnGrabarComercios_Click(object sender, EventArgs e)
        {
            bl.Grabar(BaseID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bl.Grabar(BaseID);
        }

        private void chkImprimirCompCob_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkImprimirComprobantes_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void grbCobranza_Enter(object sender, EventArgs e)
        {

        }

        private void chkImpCobTalonCom_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tabPantalla_Click(object sender, EventArgs e)
        {

        }

        private void nudPeriodoActSolfon_ValueChanged(object sender, EventArgs e)
        {

        }

        private void tabImpresoras_Click(object sender, EventArgs e)
        {

        }

        private void btnTodos_Click(object sender, EventArgs e)
        {
            foreach (TipoImpresion t in (List<TipoImpresion>)dgvTipoImpresion.DataSource)
            {
                DefinirImpresoraTipoImpresion(t);
            }
        }

        private void tltc_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPage Tab = tltc.SelectedTab;
            if (Tab.Name == "tabActualizaciones")
            {
                CargarComerciosActs();                   

            }
        }

        private void rbEF_CheckedChanged(object sender, EventArgs e)
        {
            if (rbEF.Checked)
            {
                dtpActHasta.Enabled = true;
                dtpActHasta.Visible = true;
            }
        }

        private void rbDesde_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDesde.Checked)
            {
                dtpActHasta.Enabled = false;
                dtpActHasta.Visible = false;
            }            
        }

        private void tabActualizaciones_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminarRegistros_Click(object sender, EventArgs e)
        {

            DialogResult dr = MessageBox.Show("Advertencia", "Se Eliminarán registros del log de actualización, ¿desea continuar?", MessageBoxButtons.YesNo);
            if (dr == System.Windows.Forms.DialogResult.Yes)
            {
                using (ComercioContext cf = new ComercioContext())
                {
                    string sql = @"Delete from log where LogID not in (Select top " + nudRegsElim.Value.ToString() + "l2.logID from Log l2 order by l2.LogID desc)";
                    cf.Database.ExecuteSqlCommand(sql);
                }
                MessageBox.Show("Se han Eliminado los registros");
            }
        }

        private void bsComercio_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void btnRutaCompr_Click(object sender, EventArgs e)
        {
            LeerRutaCarpeta(txtCompr);  
        }

        private void grpArreglo_Enter(object sender, EventArgs e)
        {

        }

        private void txtArregloMeses_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRutaSolicitudes_Click(object sender, EventArgs e)
        {
            LeerRutaCarpeta(txtSolicitudes);
        }

        private void btnRutaComprM_Click(object sender, EventArgs e)
        {
            LeerRutaCarpeta(txtComprM);
        }

        private void btnRutaSolicitudesM_Click(object sender, EventArgs e)
        {
            LeerRutaCarpeta(txtSolicitudesM);
        }

        private void tabM_Click(object sender, EventArgs e)
        {

        }
    }
}
