using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.IO;
using iComercio.Models;
using iComercio.DAL;
using iComercio.Rest;
using iComercio.Delegados;
using iComercio.Configuration;
using iComercio.Auxiliar;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace iComercio.Forms
{
    public partial class Principal : FRM
    {
        public event EventHandler<MensajeEventArgs> actualizarBarraDeEstadoEvent;
        public event EventHandler<MensajeEventArgs> actualizarBarraDeEstadoListoEvent;
        public event EventHandler<MensajeEventArgs> actualizarBarraDeProgresoEvent;

        /* Formularios */
        private int childFormNumber = 0;
                
        public ParametrosGlobales pGlob { get; set; }
        private BusinessLayer bl { get; set; }
                
        /* Timer */
        private System.Threading.Timer timerTransmisiones;
        private System.Threading.Timer timerNovedades;
        private System.Threading.Timer timerRevisiones;
        private System.Threading.Timer timerActualizaciones;
        private System.Threading.Timer timerBlock;

        /* Conexion */
        public object transmitiendo { get; set; }

        /* Log */
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /* Usuario   */
        public Usuario usu { get; set; }
        public int usuIDAutorizado = 0; // Guarda el ID del usuario autorizado cuando se requiere autorizacion/o del usu que ingresa al sistema cuando no se solicita autorizacion 
        //public Comercio comercio { get; set; }        //**edu**
        public int bPuedeHacerlo = 0;             //**edu**  el ID del usuario que ingresó la clave
                                                 // sirve porej para quien avaló
                                               // 0 cancela
        string QueArregla;
                

        /*Flag para saber si ya se invoco al evento FormClosing*/
        bool YaCerrado = false;
        public string qExporto = "";
        public Principal()
        {
            InitializeComponent();               
        }

        public void  RecargarEmpYComercio(bool EsM)
        {
            BaseID = bl.GetEmpresa(EsM).EmpresaID.Value;
            ComID = bl.GetComercio(EsM).ComercioID;
            Com = bl.GetComercio(EsM);
            Emp = Com.Empresa;
        }

        string desbloq = "";
        private void Principal_KeyDown(object sender, KeyEventArgs e)
        {
            desbloq += e.KeyValue;
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            bl = new BusinessLayer();
            bl.InicializarBases();
            pGlob = bl.GetParametrosGlobales();

            if (pGlob.Configuracion.Blocked??false)
            {
                FormularioModal frmModal = new FormularioModal(this);
                frmModal.ShowDialog();
                if (pGlob.Configuracion.Blocked ?? false)
                    this.Close();                
            }

            ConfigurarSkin();
            log.Info("Icomercio: Iniciando App - " + DateTime.Now.ToString());
            //Hacer bloqueo con Monitor.tryEnter o  deshabilitando el timer dentro del callback, al principio, y volverlo 
            // a habilitar cuando termina el callback
            timerTransmisiones = new System.Threading.Timer(timerTransmisionesTick, null, pGlob.Configuracion.TiempoEnvioTransmisiones, Timeout.Infinite);
            timerNovedades = new System.Threading.Timer(timerNovedadesTick, null, pGlob.Configuracion.TiempoEnvioNovedades, Timeout.Infinite);
            timerRevisiones = new System.Threading.Timer(timerRevisionesTick, null, pGlob.Configuracion.TiempoEnvioRevisiones, Timeout.Infinite);
            timerActualizaciones = new System.Threading.Timer(timerActualizacionesTick, null, pGlob.Configuracion.TiempoActs, Timeout.Infinite);
            timerBlock = new System.Threading.Timer(timerBlockTick, null,30, Timeout.Infinite);
            transmitiendo = new object(); // lockeo para transmision   


            this.actualizarBarraDeEstadoEvent += ActualizarBarraDeEstado;
            this.actualizarBarraDeEstadoListoEvent += ActualizarBarraDeEstadoListo;
            this.actualizarBarraDeProgresoEvent += ActualizarBarraDeProgreso;

            /*Configuraciones */
            /*Thread.CurrentThread.CurrentCulture = new CultureInfo("es-AR");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-AR");*/
            /* Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
             Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;*/
            //MessageBox.Show(Properties.Resources.Idioma);

            MapperConfig.Configurar();
            
            //this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            //D:\Christian\Credin\sistemas\Proyectos\iComercio\iComercio\iComercio
            this.Icon = Properties.Resources.CredinIco;
                        

            RecargarEmpYComercio(false);
            ActualizarBarraDeEstadoVersion();
            ActualizarBarraDeEstadoComercio();
            if (Login())
            {        
                /*Crear RestApi */
                // ra = new RestApi(pGlob.Configuracion.RestUsu, pGlob.Configuracion.RestKey, bl.pGlob.Configuracion.RestUrlConexion);
                bl.ra = new RestApi(usu.usuario, usu.pass, bl.pGlob.Configuracion.RestUrlConexion);
                bl.raM = new RestApi(usu.usuario, usu.pass, bl.pGlob.Configuracion.RestUrlConexion, bl.pGlob.Configuracion.TestRestUrlConexion);
            }
            else
                this.Close();
            Muestra_MenuVta();
        }

        private string ObtenerVersion()
        {
            Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            DateTime buildDate = new DateTime(2000, 1, 1).AddDays(version.Build).AddSeconds(version.Revision * 2);
            string displayableVersion = string.Format("{0} ({1}))",version,buildDate);
            //displayableVersion = $"{version} ({buildDate})"; //Interpolates strings
            return displayableVersion;
        }

        private void ConfigurarSkin()
        {
            
            Configura_Colores(bl.pGlob.Comercio.EmpresaID);
            Recorre_Formulario(this);
            this.BackColor = ColorBackColorFrm;
        }

        private void timerTransmisionesTick(Object stateInfo)
        {
            //return;
            if (usu != null)
            {
                MensajeEventArgs me = new MensajeEventArgs("Enviando...");
              //  actualizarBarraDeEstadoEvent(this, me);
                if (bl.pGlob.Configuracion.TransmisionHabilitada)
                {
                    using (BusinessLayer bla = new BusinessLayer(bl.ra,bl.raM))
                    {
                        bla.RealizarTransmisionesSolicitudes(transmitiendo);
                        //bla.RealizarTransmisionesNovedades(transmitiendo); //ControlDiario
                        bla.RealizarTransmisiones(transmitiendo, pGlob.Empresa.EmpresaID.Value); 
                       // bla.RetransmitirErroneas(transmitiendo);
                        bla.RealizarTransmisionesArchivo(transmitiendo);                        
                    }
                }
                if (bl.pGlob.Configuracion.TransmisionHabilitadaM)
                {
                    var ra = new RestApi(usu.usuario, usu.pass, bl.pGlob.Configuracion.RestUrlConexion, bl.pGlob.Configuracion.TestRestUrlConexion);
                    ra.esEnvioTest = true;
                    using (BusinessLayer bla = new BusinessLayer(ra, bl.raM))
                    {
                        //bla.RealizarTransmisionesSolicitudes(transmitiendo);
                        //bla.RealizarTransmisionesNovedades(transmitiendo); //ControlDiario
                        bla.RealizarTransmisiones(transmitiendo, pGlob.EmpresaM.EmpresaID.Value);
                        // bla.RetransmitirErroneas(transmitiendo);
                        //bla.RealizarTransmisionesArchivo(transmitiendo);
                    }
                }


                //  actualizarBarraDeEstadoListoEvent(this, me);
            }
            timerTransmisiones.Change(pGlob.Configuracion.TiempoEnvioTransmisiones, Timeout.Infinite); // Esta sentencia reinicia el timer, que fue instanciado como one-shot
        }

        private void timerRevisionesTick(Object stateInfo)
        {
            //return;
            if (usu != null)
            {
                MensajeEventArgs me = new MensajeEventArgs("Enviando Revisiones...");
                this.Invoke(actualizarBarraDeEstadoEvent,this, me);
                if (bl.pGlob.Configuracion.TransmisionHabilitada)
                {
                    using (BusinessLayer bla = new BusinessLayer(bl.ra, bl.raM))
                    {
                        bla.RevisarTransmisiones(Com, DateTime.Now.AddDays(-pGlob.Configuracion.diasRevisionesParaAtras), DateTime.Now);
                        bla.RetransmitirErroneas(transmitiendo);
                    }
                }
                this.Invoke(actualizarBarraDeEstadoListoEvent,this, me);
            }
            timerRevisiones.Change(pGlob.Configuracion.TiempoEnvioRevisiones, Timeout.Infinite); // Esta sentencia reinicia el timer, que fue instanciado como one-shot
        }
        private async void timerBlockTick(Object stateInfo)
        {
            int ts;
            if (pGlob.Configuracion.LastUnBlockedDate != null && pGlob.Configuracion.BlockingEnabled)
            {
                ts = (DateTime.Now - pGlob.Configuracion.LastUnBlockedDate.Value).Days;
                if (Math.Abs(ts) > pGlob.Configuracion.DaysToBlock)
                {
                    pGlob.Configuracion.Blocked = true;                    
                    pGlob.Configuracion.Write();
                    this.Close();
                }
            }
            timerBlock.Change(10000, Timeout.Infinite); 
        }

        private async void timerActualizacionesTick(Object stateInfo)
        {
            //return;
            MensajeEventArgs me = new MensajeEventArgs("Acts" + DateTime.Now);
            this.Invoke(actualizarBarraDeEstadoEvent,this, me);
            if (usu != null)
            {                
                if (bl.pGlob.Configuracion.bActHabilitada)
                {
                    me = new MensajeEventArgs("Realizando Actualizaciones..." + DateTime.Now);
                    this.Invoke(actualizarBarraDeEstadoEvent,this, me);
                    using (BusinessLayer bla = new BusinessLayer(bl.ra, bl.raM))
                    {
                       await bla.ActualizarDesdeCentral(Com,usu);
                    }
                    me = new MensajeEventArgs("Actualizaciones Finalizadas" + DateTime.Now);
                    this.Invoke(actualizarBarraDeEstadoListoEvent,this, me);
                }                
            }
            timerActualizaciones.Change(pGlob.Configuracion.TiempoActs, Timeout.Infinite); // Esta sentencia reinicia el timer, que fue instanciado como one-shot
            me = new MensajeEventArgs("" + DateTime.Now);
        }

        private void timerNovedadesTick(Object stateInfo)
        {
            //return;
            if (usu != null)
            {
                if (bl.pGlob.Configuracion.TransmisionHabilitada)
                {
                    MensajeEventArgs me = new MensajeEventArgs("Enviando Novedades...");
                    this.Invoke(actualizarBarraDeEstadoEvent, this, me);
                    using (BusinessLayer bla = new BusinessLayer(bl.ra, bl.raM))
                    {
                        bla.RealizarTransmisionesNovedades(transmitiendo);
                    }
                    this.Invoke(actualizarBarraDeEstadoListoEvent, this, me);
                }
            }
            timerNovedades.Change(pGlob.Configuracion.TiempoEnvioNovedades, Timeout.Infinite); // Esta sentencia reinicia el timer, que fue instanciado como one-shot
        }
        
       private bool Login()
        {
            /*Cargar Login */
            DesHabilitarTodosLosMenues();
            FrmLogin frmlogin = new FrmLogin(this);
            frmlogin.ShowDialog();
            if (usu != null)
            {
                CargarPermisos(usu);
                return true;
            }
            return false;
        }

        public void CargarPermisos(Usuario usu)
       {
           usu = bl.Get<Usuario>(u => u.UsuarioID == usu.UsuarioID).FirstOrDefault();
           var prmi = usu.GetPermisos().Select(p=>p.nombre).ToList();
           ActualizarBarraDeEstadoUsuario(usu);
           HabilitarMenues(usu);
           HabilitarMenuesIconos(usu);
       }

        

        private void DesHabilitarTodosLosMenues()
        {
            for (int i = 0; i < menuStrip.Items.Count; i++)
            {
                ToolStripMenuItem tsi = menuStrip.Items[i] as ToolStripMenuItem;
                if (tsi != null)
                 DesHabilitarMenu(tsi);
            }

            for (int i = 0; i < Toolstrip.Items.Count; i++)
            {
                ToolStripItem tsi = Toolstrip.Items[i] as ToolStripItem;
                if (tsi != null)
                    DesHabilitarMenu(tsi);
            }


            //foreach (ToolStripMenuItem tsi in menuStrip.Items)
            //{
            //    DesHabilitarMenu(tsi);
            //}
            //foreach (ToolStripItem tsi in Toolstrip.Items)
            //{
            //    DesHabilitarMenu(tsi);
            //}
        }

        private void DesHabilitarMenu(ToolStripMenuItem tsmi)
        {
            int i;
            if (tsmi != null)
            {
                for (i = 0; i < tsmi.DropDownItems.Count; i++)
                {
                    ToolStripMenuItem tsi = tsmi.DropDownItems[i] as ToolStripMenuItem;
                    if (tsi != null)
                        DesHabilitarMenu(tsi);
                }
                //foreach (ToolStripMenuItem tsi in tsmi.DropDownItems)
                //{
                //    DesHabilitarMenu(tsi);
                //}
                tsmi.Visible = false;
                tsmi.Enabled = false;
            }
            
           
           
        }

        private void DesHabilitarMenu(ToolStripItem tsmi)
        {
            tsmi.Visible = false;
            tsmi.Enabled = false;
        }

        private void HabilitarMenu(ToolStripMenuItem tsmi)
        {
            //foreach (ToolStripMenuItem tsi in tsmi.DropDownItems)
            //{
            //    HabilitarMenu(tsi);
            //}
            for (int i = 0; i < tsmi.DropDownItems.Count; i++)
            {
                ToolStripMenuItem item = tsmi.DropDownItems[i] as ToolStripMenuItem;
                if (item != null)
                    HabilitarMenu(item);
            }
            tsmi.Visible = true;
            tsmi.Enabled = true;
        }

        private void HabilitarMenu(ToolStripMenuItem tsmi, List<string> permisos)
        {
            if (permisos.Contains(tsmi.Name))
            {
                for (int i = 0; i < tsmi.DropDownItems.Count;i++)
                {
                    ToolStripMenuItem item = tsmi.DropDownItems[i] as ToolStripMenuItem;
                    if (item != null)
                        HabilitarMenu(item, permisos);
                }
                tsmi.Visible = true;
                tsmi.Enabled = true;
             }
        }

        private void HabilitarMenues(Usuario usu)
        {
            List<string> permisos = usu.GetPermisos().Select(p => p.nombre).ToList();
            if (bl.pGlob.Configuracion.BlockedVentas??false)            
                permisos = QuitarMenuVentas(permisos);

            foreach (ToolStripMenuItem tsi in menuStrip.Items)
            {
                HabilitarMenu(tsi,permisos);
            }            
        }

        private List<string> QuitarMenuVentas(List<string> permisos)
        {
            List<string> permisosVentas = new List<string> { "mnuCreditosAlta", "mnuAnulCred", "tsCreditosAlta" };
            var perm = permisos.Where(x => !permisosVentas.Contains(x)).ToList();
            return perm;
        }

        private void HabilitarMenuesIconos(Usuario usu)
        {
            List<string> permisos = usu.GetPermisos().Select(p => p.nombre).ToList();
            if (bl.pGlob.Configuracion.BlockedVentas ?? false)
                permisos = QuitarMenuVentas(permisos);

            foreach (var tsi in Toolstrip.Items)
            {
                if (tsi is ToolStripButton)
                    HabilitarMenu((ToolStripButton)tsi, permisos);
            }
            
            if (tsCreditosAlta.Visible)
                tsSep.Visible = true;
        }

        private void HabilitarMenu(ToolStripButton tsmi, List<string> permisos)
        {
            if (permisos.Contains(tsmi.Name.Replace("ts","mnu")))
            {
                tsmi.Visible = true;
                tsmi.Enabled = true;
            }
        }


        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }       

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void permisosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void helpMenu_Click(object sender, EventArgs e)
        {

        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void solicitarFondosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmABMProveedores frmABMProv = new frmABMProveedores(this, this.bl);
            //frmABMProv.MdiParent = this;
            //frmABMProv.Show();

            FrmSolicitarFondos frmSolFon = new FrmSolicitarFondos(this, bl.ra);
            frmSolFon.MdiParent = this;
            frmSolFon.actualizarBarraDeEstado += ActualizarBarraDeEstado;
            frmSolFon.actualizarBarraDeEstadoListo += ActualizarBarraDeEstadoListo;
            frmSolFon.WindowState = FormWindowState.Maximized;
            frmSolFon.Show();
        }

        /* private void ActualizarBarraDeEstado(string texto)
        {   
            statusStrip.Items[0].Text = texto ;
        }*/
        
        private void ActualizarBarraDeProgreso(object sender, MensajeEventArgs e)
        {
            tspb.Value = e.ValorProgressBar;
        }

        private void ActualizarBarraDeEstado(object sender, MensajeEventArgs e)
        {
            statusStrip.Items[0].Text = e.mensaje;
        }

        private void ActualizarBarraDeEstadoListo(object sender, EventArgs e)
        {
            statusStrip.Items[0].Text = pGlob.Configuracion.BarraDeEstadoListo;
            
        }

        private void ActualizarBarraDeEstadoUsuario(Usuario usu)
        {
            statusStrip.Items["tstlUsuario"].Text = usu.nombre;
        }

        private void ActualizarBarraDeEstadoComercio()
        {
            statusStrip.Items["tstlComercio"].Text = Com.NumeroYNombre + " - PC:" + Environment.MachineName;
        }

        private void ActualizarBarraDeEstadoVersion()
        {
            statusStrip.Items["tslbVersion"].Text = ObtenerVersion();            
        }

        private void pruebaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Prueba p = new Prueba();
            p.Show();
        }

        private void nossisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bl.ConsultaNossis();
        }

        private void configuracionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void asignarPerfilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStripStatusLabel_Click(object sender, EventArgs e)
        {

        }

        private void usuariosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FrmUsuarios frmUsu = new FrmUsuarios(this, bl.ra);
            frmUsu.MdiParent = this;
            frmUsu.WindowState = FormWindowState.Maximized;
            frmUsu.Text = pGlob.Configuracion.frmUsuariosNombre;
            frmUsu.Show();
        }

        private void asignarPerfilesAUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAsignarPerfiles frmUsu = new FrmAsignarPerfiles(this, bl.ra);
            frmUsu.MdiParent = this;
            //frmUsu.WindowState = FormWindowState.Maximized;
            //frmUsu.Text = pGlob.Configuracion.frmUsuariosNombre;
            frmUsu.Show();
        }

        private void permisosToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void opcionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOpciones frmOpc = new FrmOpciones(this, bl.ra);
            frmOpc.ShowDialog();
            frmOpc.MdiParent = this;
            bl.pGlob = frmOpc.bl.pGlob;
            bl.pGlob.Configuracion = frmOpc.bl.pGlob.Configuracion;
        }

        private void mnuPerfiles_Click(object sender, EventArgs e)
        {
            FrmPerfiles frmPerf = new FrmPerfiles(this,bl.ra);
            frmPerf.MdiParent = this;
            frmPerf.Show();
        }

        private void permisosToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            FrmPermisos frmPerm = new FrmPermisos(this, bl.ra);
            frmPerm.MdiParent = this;
            frmPerm.Show();
        }

        private void mnuAsignarPermisosPerfiles_Click(object sender, EventArgs e)
        {
            FrmAsignarPermisos frmAsigPer = new FrmAsignarPermisos(this, bl,bl.ra);
            frmAsigPer.MdiParent = this;
            //frmAsigPer.WindowState = FormWindowState.Maximized;
            frmAsigPer.Show();
        }

        private void cuentaCorrienteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //FrmCtaCte frmCtaCte = new FrmCtaCte(this, bl.ra);
            //frmCtaCte.WindowState = FormWindowState.Maximized;
            //frmCtaCte.Show();
            //frmCtaCte.MdiParent = this;

            FrmCtaCteComun frmCtaCte = new FrmCtaCteComun(this,bl.ra, bl.raM);
            frmCtaCte.MdiParent = this;
            frmCtaCte.WindowState = FormWindowState.Maximized;
            frmCtaCte.Show();
        }

        private async void Principal_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private async void Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (YaCerrado)
            {
                e.Cancel = false;
            }
            else
            {
                YaCerrado = true;
                e.Cancel = true;
                if (bl.pGlob.Configuracion.TransmisionHabilitada)
                {
                    try
                    {
                        bool envioExitoso = await bl.ChequearTransmisionesAntesDeCerrar(transmitiendo);
                        System.Threading.Thread.Sleep(5000);
                    }
                    catch{ }
                }
                this.Close();
            }            
           
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await bl.ChequearTransmisionesAntesDeCerrar(transmitiendo);
        }

        private void listadoDeProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListadoDeProveedores frmLProv = new frmListadoDeProveedores(this);
            frmLProv.MdiParent = this;
            
            frmLProv.TopMost = false;
            frmLProv.Size = new Size(this.Width-200, this.Height-200);
            frmLProv.Top = 10;
            frmLProv.Left = 10;
            frmLProv.Show();
        }

        private void aBMProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmABMProveedores frmABMProv = new frmABMProveedores(this,this.bl);
            frmABMProv.MdiParent = this;
            frmABMProv.Show();
        }

        private void aaaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmABMProveedores frmABMProv = new frmABMProveedores(this, this.bl);
             frmABMProv.MdiParent = this;
           frmABMProv.TopMost = false;

           // frmABMProv.Dock = DockStyle.Fill;
            Size x = new Size(this.Width, this.Height);
            this.ClientSize = x;
            frmABMProv.Show();
        }

        private void mnuProveedores_Click(object sender, EventArgs e)
        {

        }

        private void mnuABM_Click(object sender, EventArgs e)
        {
            
        }

        private void mnuABMConcpGst_Click(object sender, EventArgs e)
        {
            frmConceptoDeGasto frmABMGst = new frmConceptoDeGasto(this, this.bl);
            frmABMGst.MdiParent = this;
            frmABMGst.Show();
        }

        private void cuentasAPagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void mnuCreditosAlta_Click(object sender, EventArgs e)
        {
            AbrirAltaCredito();
        }

        private void mnuBDMigracionClientes_Click(object sender, EventArgs e)
        {
            bl.CargarClientesDesdeComerFinan(bgwImportarDatos);
        }

        private void mnuBDMigracionCreditos_Click(object sender, EventArgs e)
        {
            bgwImportarDatos.RunWorkerAsync();
        }

        private void bgwImportarDatos_DoWork(object sender, DoWorkEventArgs e)
        {
            MensajeEventArgs men = new MensajeEventArgs("Iniciando Importación de datos...");
            this.Invoke(actualizarBarraDeEstadoEvent, this, men);

            DateTime ti = DateTime.Now;
            
            ImportarClientes();
            ImportarCreditos();
            //ImportarRefinanciaciones();
            
            DateTime tf = DateTime.Now;
            TimeSpan t = (tf - ti);
            Alertas.MensajeOKOnly("TIEMPO", "Tardo:" + t.Hours + ":" + t.Minutes + ":" + t.Seconds);
            

            men.mensaje = "Importación de Datos Finalizada ";
            this.Invoke(actualizarBarraDeEstadoEvent, this, men);
        }

        private bool Busca_Permiso(string qq)
        {
            if (bl.pGlob.Configuracion.AutenticaAltaCredito)
            {
                FrmClave frmclave = new FrmClave(this, this.bl, qq);
                frmclave.ShowDialog();
                if (usuIDAutorizado != 0)
                    return true;
                return false;
            }
            else
            {
                usuIDAutorizado = usu.UsuarioID;
                return true;
            }
        }

        private void AbrirAltaCredito()
        {
            if (Busca_Permiso("Altas"))
            {
                if (bl.PuedeDarCredito())
                {
                    frmAltaCredito frmAltaCredito = new frmAltaCredito(this, bl.ra);
                    frmAltaCredito.MdiParent = this;
                    frmAltaCredito.actualizarBarraDeEstado += ActualizarBarraDeEstado;
                    frmAltaCredito.WindowState = FormWindowState.Normal;
                    frmAltaCredito.Show();
                }
            }
            else
            {
                MessageBox.Show("No tiene permiso para dar Altas", "Acceso no autorizado");
            }

           
            
        }

        private void ImportarClientes()
        {
            MensajeEventArgs men = new MensajeEventArgs("Cargando Clientes...");
            this.Invoke(actualizarBarraDeEstadoEvent, this, men);
            bl.CargarClientesDesdeComerFinan(bgwImportarDatos);
            men.mensaje = "Carga de Clientes Finalizada";
            this.Invoke(actualizarBarraDeEstadoEvent, this, men);
            men.ValorProgressBar = 0;
            this.Invoke(actualizarBarraDeProgresoEvent, this, men);
          
        }

        private void ImportarCreditos()
        {
            MensajeEventArgs men = new MensajeEventArgs("Cargando Créditos...");
            this.Invoke(actualizarBarraDeEstadoEvent, this, men);
            bl.CargarCreditosDesdeComerFinan(bgwImportarDatos);
            men.mensaje = "Carga de Créditos Finalizada";
            this.Invoke(actualizarBarraDeEstadoEvent, this, men);
            men.ValorProgressBar = 0;
            this.Invoke(actualizarBarraDeProgresoEvent, this, men);

            men.mensaje = "Cargando Cuotas de créditos...";
            this.Invoke(actualizarBarraDeEstadoEvent, this, men);
            bl.CargarCuotasDesdeComerFinan(bgwImportarDatos);
            men.mensaje = "Carga de Cuotas Finalizada";
            this.Invoke(actualizarBarraDeEstadoEvent, this, men);
            men.ValorProgressBar = 0;
            this.Invoke(actualizarBarraDeProgresoEvent, this, men);

            men.mensaje = "Cargando Cobranzas de créditos...";
            this.Invoke(actualizarBarraDeEstadoEvent, this, men);
            bl.CargarCobranzasDesdeComerFinan(bgwImportarDatos);
            men.mensaje = "Carga de Cobranzas Finalizada";
            this.Invoke(actualizarBarraDeEstadoEvent, this, men);
            men.ValorProgressBar = 0;
            this.Invoke(actualizarBarraDeProgresoEvent, this, men);

            men.mensaje = "Cargando Créditos Anulados...";
            this.Invoke(actualizarBarraDeEstadoEvent, this, men);
            bl.CargarCreditosAnuladosDesdeComerFinan(bgwImportarDatos);
            men.mensaje = "Carga de Créditos Anulados Finalizada";
            this.Invoke(actualizarBarraDeEstadoEvent, this, men);
            men.ValorProgressBar = 0;
            this.Invoke(actualizarBarraDeProgresoEvent, this, men);

            men.mensaje = "Cargando Notas de crédito Anuladas...";
            this.Invoke(actualizarBarraDeEstadoEvent, this, men);
            bl.CargarNotasCDs(bgwImportarDatos);
            men.mensaje = "Carga de Notas de crédito Anuladas Finalizada";
            this.Invoke(actualizarBarraDeEstadoEvent, this, men);
            men.ValorProgressBar = 0;
            this.Invoke(actualizarBarraDeProgresoEvent, this, men);
        }


        private void ImportarRefinanciaciones()
        {
            MensajeEventArgs men = new MensajeEventArgs("Cargando Refinanciaciones...");
            this.Invoke(actualizarBarraDeEstadoEvent, this, men);
            bl.CargarRefinanciacionesDesdeComerFinan(bgwImportarDatos);
            men.mensaje = "Carga de Refinanciaciones Finalizada";
            this.Invoke(actualizarBarraDeEstadoEvent, this, men);
            men.ValorProgressBar = 0;
            this.Invoke(actualizarBarraDeProgresoEvent, this, men);

            men.mensaje = "Cargando Cuotas de refinanciaciones...";
            this.Invoke(actualizarBarraDeEstadoEvent, this, men);
            bl.CargarRefiCuotasDesdeComerFinan(bgwImportarDatos);
            men.mensaje = "Carga de Cuotas de refinanciaciones Finalizada";
            this.Invoke(actualizarBarraDeEstadoEvent, this, men);
            men.ValorProgressBar = 0;
            this.Invoke(actualizarBarraDeProgresoEvent, this, men);
            
            men.mensaje = "Cargando Cobranzas de refinanciaciones...";
            this.Invoke(actualizarBarraDeEstadoEvent, this, men);
            bl.CargarRefiCobranzasDesdeComerFinan(bgwImportarDatos);
            men.mensaje = "Carga de Cobranzas de refinanciaciones";
            this.Invoke(actualizarBarraDeEstadoEvent, this, men);
            men.ValorProgressBar = 0;
            this.Invoke(actualizarBarraDeProgresoEvent, this, men);

            men.mensaje = "Cargando Refinanciaciones Anulados...";
            this.Invoke(actualizarBarraDeEstadoEvent, this, men);
            bl.CargarRefiAnuladasDesdeComerFinan(bgwImportarDatos);
            men.mensaje = "Carga de Refinanciaciones Anulados Finalizada";
            this.Invoke(actualizarBarraDeEstadoEvent, this, men);
            men.ValorProgressBar = 0;
            this.Invoke(actualizarBarraDeProgresoEvent, this, men);

            men.mensaje = "Cargando Refinanciaciones En Creditos";
            this.Invoke(actualizarBarraDeEstadoEvent, this, men);
            bl.ActualizarRefinanciacionesEnCreditos(bgwImportarDatos);
            men.mensaje = "Carga de Refinanciaciones En Creditos";
            this.Invoke(actualizarBarraDeEstadoEvent, this, men);
            men.ValorProgressBar = 0;
            this.Invoke(actualizarBarraDeProgresoEvent, this, men);
            
        }

        private void bgwImportarDatos_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage > 100)
                tspb.Value = 100;
            else
                tspb.Value = e.ProgressPercentage;
            toolStripStatusLabel.Text = e.ProgressPercentage.ToString();
        }

        private void importarCuotasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bgwImportarDatos.RunWorkerAsync();
        }

        private void mnuBDMigracionCobranzas_Click(object sender, EventArgs e)
        {
            bgwImportarDatos.RunWorkerAsync();
        }

        private void mnuPlanes_Click(object sender, EventArgs e)
        {
            
        }

        private void mnuPuntajes_Click(object sender, EventArgs e)
        {
            
        }

        private void mnuCobranzas_Click(object sender, EventArgs e)
        {
            AbrirCobranzas();
        }

        private void AbrirCobranzas()
        {
            frmCobranzaNva frmCob = new frmCobranzaNva(this, bl.ra, false);  // bl.LlevaM());
            frmCob.MdiParent = this;
            frmCob.WindowState = FormWindowState.Normal;
            frmCob.Show();
        }

        private void mnuClientePorNombre_Click(object sender, EventArgs e)
        {
            
        }

        private void AbrirBusquedaPorNombre()
        {
            FrmBuscaCliNombre BuscaPorNombre = new FrmBuscaCliNombre(this, bl.ra);
            BuscaPorNombre.MdiParent = this;
            BuscaPorNombre.WindowState = FormWindowState.Maximized;
            BuscaPorNombre.Show();
        }

        private void mnuClientePorDocumento_Click(object sender, EventArgs e)
        {
            
        }

        private void AbrirBusquedaPorDNI()
        {
            FrmBuscaCliDocumento BuscaPorDocu = new FrmBuscaCliDocumento(this, bl.ra);
            BuscaPorDocu.MdiParent = this;
            BuscaPorDocu.WindowState = FormWindowState.Maximized; //edu202009
            BuscaPorDocu.Show();
        }

        private void mnuClienteModificar_Click(object sender, EventArgs e)
        {
            
        }

        private void mnuClienteNuevo_Click(object sender, EventArgs e)
        {
           
        }

        private void mnuCobranzasConsulta_Click(object sender, EventArgs e)
        {
            
        }

        private void mnuCobranzasAnulacion_Click(object sender, EventArgs e)
        {
            FrmBajaCobranza frmBajCob = new FrmBajaCobranza(this);
            frmBajCob.MdiParent = this;
            frmBajCob.WindowState = FormWindowState.Maximized;
            frmBajCob.Show();
        }

        private void mnuPagare_Click(object sender, EventArgs e)
        {
            frmReportes frmRep = new frmReportes(this);
            frmRep.MdiParent = this;
            frmRep.Show();
        }

        private void btnArchivo_Click(object sender, EventArgs e)
        {
            bl.ra.PostFileAsync(@"c:\casangosta.jpg","casaangosta.jpg","Horarios");
        }

        private void anulaciónDeCréditoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBajaCredito FrmBajaCredito = new FrmBajaCredito(this);
            FrmBajaCredito.MdiParent = this;
            FrmBajaCredito.WindowState = FormWindowState.Normal; // FormWindowState.Maximized;
            FrmBajaCredito.Show();
        }

        private void consultasAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void recibosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRecibos frmRecibos = new frmRecibos(this,bl);
            frmRecibos.MdiParent = this;
            frmRecibos.Show();
        }

        private void cuentaCorrienteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mnuBDMigracionRefinanciaciones_Click(object sender, EventArgs e)
        {
            bgwImportarDatos.RunWorkerAsync();
        }

        private void mnuBDMigracion_Click(object sender, EventArgs e)
        {

        }

        private void importarCréditosAnuladosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bgwImportarDatos.RunWorkerAsync();
        }

        private void tsCreditosAlta_Click(object sender, EventArgs e)
        {
            AbrirAltaCredito();
        }

        private void tsCobranzas_Click(object sender, EventArgs e)
        {
            AbrirCobranzas();
        }

        private void tsClientePorDocumento_Click(object sender, EventArgs e)
        {
            AbrirBusquedaPorDNI();
        }

        private void tsClientePorNombre_Click(object sender, EventArgs e)
        {
            AbrirBusquedaPorNombre();
        }

        private void impresionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReimpresiones frmReImp = new frmReimpresiones(this);
            frmReImp.MdiParent = this;
            frmReImp.WindowState = FormWindowState.Maximized;
            frmReImp.Show();
        }

        private void mnuListados_Click(object sender, EventArgs e)
        {
            frmListados frmListados = new frmListados(this);
            frmListados.MdiParent = this;
            frmListados.WindowState = FormWindowState.Maximized;
            frmListados.Show();
        }

        private void mnuNuevoUsuario_Click(object sender, EventArgs e)
        {

        }

        private void planesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPlanes Planes = new FrmPlanes(this, bl.ra);
            Planes.MdiParent = this;
            Planes.WindowState = FormWindowState.Maximized;
            Planes.Show();
        }

        private void puntajesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPuntaje Puntaje = new FrmPuntaje(this, bl.ra, false); //Hacer para MM despues.el false que sea depende si es M o No
            Puntaje.MdiParent = this;
            Puntaje.WindowState = FormWindowState.Maximized;
            Puntaje.Show();
        }

        private void clientePorNombreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirBusquedaPorNombre();
        }

        private void clientePorDocumentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirBusquedaPorDNI();
        }

        private void modificarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClienteNVO frm = new frmClienteNVO(this, "M", 0, "", false);  
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Normal;
            frm.Show();
        }

        private void nuevoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClienteNVO frm = new frmClienteNVO(this, "N", 0, "", false);
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Normal;
            frm.Show();
        }

        private void cobranzasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConsultaCobranzas frmConCob = new FrmConsultaCobranzas(this, "COBRANZA");
            frmConCob.MdiParent = this;
            frmConCob.WindowState = FormWindowState.Maximized;
            frmConCob.Show();
        }

        private void créditosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConsultaAltas frmConAltas = new FrmConsultaAltas(this, "ALTAS");
            frmConAltas.MdiParent = this;
            frmConAltas.WindowState = FormWindowState.Maximized;
            frmConAltas.Show();
        }

        private void listadosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmListados frmListados = new frmListados(this);
            frmListados.MdiParent = this;
            frmListados.WindowState = FormWindowState.Maximized;
            frmListados.Show();
        }

        private void aBMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCap frmCAP = new FrmCap(this);
            frmCAP.MdiParent = this;
            frmCAP.Show();

            //frmCAP2 frmCAP = new frmCAP2(this, bl.ra);
            //frmCAP.WindowState = FormWindowState.Maximized;
            //frmCAP.Show();
            //frmCAP.MdiParent = this;
        }

        private void listadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCaps frmCAPS = new FrmCaps(this);
            frmCAPS.MdiParent = this;
            frmCAPS.WindowState = FormWindowState.Maximized;
            frmCAPS.Show();
        }

        private void mnuFFABM_Click(object sender, EventArgs e)
        {
            FrmFF frmFF = new FrmFF(this);
            frmFF.MdiParent = this;
            frmFF.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmPago frmFF = new frmPago(this);
            frmFF.MdiParent = this;
            frmFF.Show();
        }

        private void cargarRECDesdeSolfonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void mnuFFListado_Click(object sender, EventArgs e)
        {
            FrmFFs FrmFFs = new FrmFFs(this);
            FrmFFs.MdiParent = this;
            FrmFFs.WindowState = FormWindowState.Maximized;
            FrmFFs.Show();
        }

        private void mnuRefiACred_Click(object sender, EventArgs e)
        {
            MensajeEventArgs men = new MensajeEventArgs("Cargando Refinanciaciones En Créditos...");
            men.mensaje = "Cargando Refinanciaciones En Creditos";
            this.Invoke(actualizarBarraDeEstadoEvent, this, men);
            bl.ActualizarRefinanciacionesEnCreditos(bgwImportarDatos);
            men.mensaje = "Carga de Refinanciaciones En Creditos";
            this.Invoke(actualizarBarraDeEstadoEvent, this, men);
            men.ValorProgressBar = 0;
            this.Invoke(actualizarBarraDeProgresoEvent, this, men);
            men.mensaje = "Listo";
            this.Invoke(actualizarBarraDeEstadoEvent, this, men);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
        }

        private void mnuPlanesConsulta_Click(object sender, EventArgs e)
        {
            FrmPlanesConsulta Puntaje = new FrmPlanesConsulta(this, bl.ra);
            Puntaje.MdiParent = this;
            Puntaje.WindowState = FormWindowState.Maximized;
            Puntaje.Show();
        }

        private void mnuCuentaCorrienteAnulacion_DisplayStyleChanged(object sender, EventArgs e)
        {

        }

        private void mnuCuentaCorrienteAnulacion_Click(object sender, EventArgs e)
        {
            FrmListadoRecibos FrmListadoRecibos = new FrmListadoRecibos(this, bl.ra, "RecAnula");
            FrmListadoRecibos.MdiParent = this;
            FrmListadoRecibos.WindowState = FormWindowState.Maximized;
            FrmListadoRecibos.Show();
        }

        private void mnuCuentaCorrienteComercio_Click(object sender, EventArgs e)
        {
            FrmCtaCteComercio frmCtaCte = new FrmCtaCteComercio(this, bl.ra, bl.raM);
            frmCtaCte.MdiParent = this;
            frmCtaCte.WindowState = FormWindowState.Maximized;
            frmCtaCte.Show();
        }

        private void tslbVersion_Click(object sender, EventArgs e)
        {

        }

        private void mnuGastos_Click(object sender, EventArgs e)
        {
            frmGastos frmGastos = new frmGastos(this,bl);
             frmGastos.MdiParent = this;
           frmGastos.WindowState = FormWindowState.Maximized;
            frmGastos.Show();
        }

        private void mnuTransmisiones_Click(object sender, EventArgs e)
        {
            frmTransmisiones frmTransmisiones = new frmTransmisiones(this, bl);
            frmTransmisiones.MdiParent = this;
            frmTransmisiones.actualizarBarraDeEstado += ActualizarBarraDeEstado;
            frmTransmisiones.actualizarBarraDeEstadoListo += ActualizarBarraDeEstadoListo;
            frmTransmisiones.WindowState = FormWindowState.Maximized;
            frmTransmisiones.Show();
        }

        private void bgwCorregirCuotas_DoWork(object sender, DoWorkEventArgs e)
        {
            MensajeEventArgs men = new MensajeEventArgs("Corrigiendo Cuotas...");
            this.Invoke(actualizarBarraDeEstadoEvent, this, men);
            if (QueArregla == "FechaCuota")
                bl.CorregirFechasDeCuotas(bgwCorregirCuotas, Com.ComercioID);
            if (QueArregla == "ImporteCuota")
                bl.CorregirImporteDeCuotas(bgwCorregirCuotas, Com.ComercioID);
            if (QueArregla == "NumCuotasAdelantadas")
                bl.CorregirNumCuotasAdelantadas(bgwCorregirCuotas, Com.ComercioID);
            men = new MensajeEventArgs("Listo");
            this.Invoke(actualizarBarraDeEstadoEvent, this, men);
        }

        private void bgwCorregirCuotas_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            tspb.Value = e.ProgressPercentage;
        }

        private void mnuArreglarCuotas_Click(object sender, EventArgs e)
        {
            QueArregla = "FechaCuota";
            bgwCorregirCuotas.RunWorkerAsync();
        }

        private void mnuArreglarImporteCuotas_Click(object sender, EventArgs e)
        {
            QueArregla = "ImporteCuota";
            bgwCorregirCuotas.RunWorkerAsync();
        }

        private void mnuCuentaCorrienteDiaria_Click(object sender, EventArgs e)
        {
            frmCuentaCorrienteDiaria frmccd = new frmCuentaCorrienteDiaria(this);
            frmccd.MdiParent = this;
            frmccd.WindowState = FormWindowState.Maximized;
            frmccd.Show();
        }

        private void mnuMensajes_Click(object sender, EventArgs e)
        {
            //frmEnvioMensajes frmMen = new frmEnvioMensajes(this);
            //frmMen.WindowState = FormWindowState.Maximized;
            //frmMen.Show();
            //frmMen.MdiParent = this;
        }

        private void mnuActualizaciones_Click(object sender, EventArgs e)
        {
            frmActualizaciones frmAct = new frmActualizaciones(this,bl);
            frmAct.MdiParent = this;            
            frmAct.WindowState = FormWindowState.Maximized;
            frmAct.Show();
        }

        private void arreglarNumCuotasAdelantadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QueArregla = "NumCuotasAdelantadas";
            bgwCorregirCuotas.RunWorkerAsync();
        }


        private void mnuListCompr_Click(object sender, EventArgs e)
        {
            FrmListadoRecibos FrmListadoRecibos = new FrmListadoRecibos(this, bl.ra, "RECIBOS");
             FrmListadoRecibos.MdiParent = this;
           FrmListadoRecibos.WindowState = FormWindowState.Maximized;
            FrmListadoRecibos.Show();
        }

        private void mnuConfiguracionRevision_Click(object sender, EventArgs e)
        {
            FrmRevision FrmListadoRecibos = new FrmRevision(this,"");
            FrmListadoRecibos.MdiParent = this;
            FrmListadoRecibos.WindowState = FormWindowState.Maximized;
            FrmListadoRecibos.Show();
        }

        private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void mnuVentanaH_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void mnuVentanaV_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void mnuVentanaC_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void mnuVentanaO_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.ArrangeIcons);
        }
        private void Muestra_MenuVta()
        {
            mnuVentana.Enabled = true;
            mnuVentanaC.Enabled = true;
            mnuVentanaH.Enabled = true;
            mnuVentanaV.Enabled = true;
            mnuVentanaO.Enabled = true;

            //mnuVentanaCambiaUsu.Enabled = true;
            mnuVentanaCambiaUsu.Enabled = true;
            //nmuVentanaAcerca.Enabled = true;
            //mnuVentanaCambiaUsu.Enabled = true;

            mnuVentana.Visible = true;
            mnuVentanaC.Visible = true;
            mnuVentanaH.Visible = true;
            mnuVentanaV.Visible = true;
            mnuVentanaO.Visible = true;
            mnuVentanaCambiaUsu.Visible = true;
            //mnuVentanaCambiaUsu.Visible = true;
            //mnuVentanaCambiaUsu.Visible = true;
            //nmuVentanaAcerca.Visible = true;
        }

        private void mnuVentana_Click(object sender, EventArgs e)
        {
            
        }

        private void mnuVentanaCambiaUsu_Click(object sender, EventArgs e)
        {
            Login();
            Muestra_MenuVta();
        }

       
    }
}
