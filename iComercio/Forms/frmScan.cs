using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;
using iComercio.Auxiliar;
using WIA;
using iComercio.Models;                     // modelos(cred, cuot, etc)
using iComercio.DAL;    //<MorosoEnCamara>
using System.Threading.Tasks;
using Credin;
using iComercio.Delegados;

namespace iComercio.Forms
{
    public partial class frmScan : FRM
    {
        string cDonde;
        int nDocumento = 0;
        string cDocumento = "";
        string cNombre = "";
        bool bEsM;
        Color backColorList = Color.White;
        Color fontColor = Color.Empty;
        System.Drawing.Font fontList = new System.Drawing.Font("Verdana", 9F, FontStyle.Regular);
        MemoryStream ms;
        string cNombreImagen;
        string cImagen;
        Dictionary<string, Tuple<string, string>> listIma;
        TimeSpan ts;
        string horatiempo;
        DateTime ahora;
        DateTime luego;
        string cQueScan;

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public event EventHandler<MensajeEventArgs> actualizarBarraDeEstadoEvent;

        frmBarraProgreso bp;
        MensajeEventArgs me = new MensajeEventArgs("Buscando Imágenes");

        string[] cImagenesSoli;//edunvo202112
        int nImagenesSoli = 0;//edunvo202112

        public frmScan(Principal p, BusinessLayer bl, Int32 nDoc, string cDoc, string cNom, bool EsM, string cQueScan) : base(p, bl)
        {
            InitializeComponent();
            nDocumento = nDoc;
            cDocumento = cDoc;
            cNombre = cNom;
            cDonde = cQueScan;
            lblNombCompleto.Visible = false;
            Configura_Inicio();
            this.cQueScan = cQueScan;
            bEsM = EsM;
            lblMor.Visible = bEsM;
        }
        private void GrabaSolicitud()
        {
            string rutaArchivo = lblSoli.Text;
            string nombreArchivo = lblSoli.Text;
            DialogResult dr;
            dr = MessageBox.Show(String.Format("Se guardará la solicitud {0}", listBusca.SelectedItems[0].SubItems[1].Text), "Imagen nueva", MessageBoxButtons.YesNo);
            if (dr == System.Windows.Forms.DialogResult.Yes)
            {
                if (File.Exists(rutaArchivo))
                {
                    dr = MessageBox.Show("Ya existe un archivo con el mismo nombre,¿desea sobrescribirlo?", "Archivo Existente", MessageBoxButtons.YesNo);
                    if (dr == System.Windows.Forms.DialogResult.Yes)
                    { 
                        try
                        {
                            File.Delete(rutaArchivo);
                        }
                        catch (System.IO.IOException)
                        {

                        }
                    }
                    else
                    {
                        return;
                    }
                }
                Graba_Imagen_Nueva(nombreArchivo, rutaArchivo);
                lblSombra.Visible = false;
                panelSoli.Visible = false;
            }
        }
        private void PreparaSolicitudGrabar(string cComer, string cCredito)
        {
            string cArch = "";
            string cArchCompleto = "";
            Ops1.Tag = "";
            Ops2.Tag = "";
            Ops1.Tag = "";
            if (cComer == bl.pGlob.ComercioID.ToString())
            {
                cArch = String.Format("{0}\\{1}", bl.pGlob.Configuracion.rutaSolicitudes, cComer.PadLeft(4, '0') + "_" + cCredito); //+ "_SOL_01.jpg") ;
            }
            else
            {
                cArch = String.Format("{0}\\{1}", bl.pGlob.Configuracion.rutaSolicitudesMor, cComer.PadLeft(4, '0') + "_" + cCredito); // + "_SOL_01.jpg");

            }
            Ops1.Tag = cArch + "_SOL_01.jpg";
            Ops2.Tag = cArch + "_SOL_02.jpg";
            Ops3.Tag = cArch + "_SOL_03.jpg";

            cArchCompleto = cArch + "_SOL_01.jpg";
            if (File.Exists(cArchCompleto) == false)
            {
                Ops1.Checked = true;
            }
            else
            {
                cArchCompleto = cArch + "_SOL_02.jpg";
                if (File.Exists(cArchCompleto) == false)
                {
                    Ops2.Checked = true;
                }
                else
                {
                    cArchCompleto = cArch + "_SOL_03.jpg";
                    if (File.Exists(cArchCompleto) == false)
                    {
                        Ops3.Checked = true;
                    }
                }
            }
            lblSombra.Width = panelSoli.Width;
            lblSombra.Height = panelSoli.Height - 10;
            lblSombra.Top = panelSoli.Top + 15;
            lblSombra.Left = panelSoli.Left + 5;
            lblSombra.Visible = true;
            lblSombra.BringToFront();
            panelSoli.BringToFront();
            panelSoli.Visible = true;
        }


        private bool Esta_Ima_Solicitud(string cCred)
        {
            cImagenesSoli = bl.BuscarSolicitudesImagen(ComID.ToString(), cCred);
            if(cImagenesSoli != null && cImagenesSoli.Length > 0)
            {
                return true;
            }
            return false;
        }
        private string SOlicitud_Nueva(string cComer, string cCredito)
        {
            string cArch = "";
            string cArchCompleto = "";
            if(cComer == bl.pGlob.ComercioID.ToString())
            {
                cArch = String.Format("{0}\\{1}", bl.pGlob.Configuracion.rutaSolicitudes, cComer.PadLeft(4, '0') + "_" + cCredito); //+ "_SOL_01.jpg") ;
            }
            else
            {
                cArch = String.Format("{0}\\{1}", bl.pGlob.Configuracion.rutaSolicitudesMor, cComer.PadLeft(4, '0') + "_" + cCredito); // + "_SOL_01.jpg");

            }
            cArchCompleto = cArch + "_SOL_01.jpg";
            if(File.Exists(cArchCompleto) == false)
            {
                return cArchCompleto;
            }
            else
            {
                cArchCompleto = cArch + "_SOL_02.jpg";
                if(File.Exists(cArchCompleto) == false)
                {
                    return cArchCompleto;
                }
                else
                {
                    cArchCompleto = cArch + "_SOL_03.jpg";
                    if(File.Exists(cArchCompleto) == false)
                    {
                        return cArchCompleto;
                    }
                }
            }

                return "";
        }
        private void Busca_Ima_Solicitud(string cCred, bool bMuestra = false)//edunvo202112
        {
            nImagenesSoli = 0;
            string nombreArchivo = "";
            int nIma1 = 0;
            int nIma2 = 0;
            cImagenesSoli = bl.BuscarSolicitudesImagen(ComID.ToString(), cCred);
            if(bMuestra == false) return;
                if(cImagenesSoli != null && cImagenesSoli.Length > 0)
            {
                nombreArchivo = cImagenesSoli[0];
                lblRuta.Text = nombreArchivo;
                nIma1 = nImagenesSoli + 1;
                nIma2 = cImagenesSoli.Length;
                lblIma.Text = nIma1.ToString() + " / " + nIma2.ToString();
                btnImaAnterior.Visible = true;
                btnImaSiguiente.Visible = true;
                lblIma.Visible = true;
                cImagen = nombreArchivo;
            }
            picIma.Image = bl.BuscarImagen(nombreArchivo);
        }
        private  void Graba_Imagen_Nueva(string nombreArchivo, string rutaArchivo)   //edunvo202112  async
        {
            Image imagen = (Image)pictureScan.Image;
            using(MemoryStream stream = new MemoryStream())
            {
                using(FileStream fs = new FileStream(rutaArchivo, FileMode.Create, FileAccess.ReadWrite))
                {
                    imagen.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] bytes = stream.ToArray();
                    fs.Write(bytes, 0, bytes.Length);
                }
            }
             bl.AgregarTransmisionArchivo(Com, nombreArchivo, rutaArchivo, "Imagenes");
            if(ms != null) ms.Dispose();
           imagen.Dispose();
        }

        public async void BuscaCliente()
        {
            //Task T =  Task.Factory.StartNew(() =>  Llena_Lista());
            //await Llena_Lista();            
            //    PreparaLista();
            bp = new frmBarraProgreso(this.p, "Buscando Imágenes", true);
            bp.Left = 500;
            bp.Top = 500;
            bp.Show(this);
            bp.BringToFront();
            bp.ActualizarBarraProgreso(1);
            //  me.ValorProgressBar = 1; ;
            //  actualizarBarraDeEstadoEvent(this, me);            
            bgLista.RunWorkerAsync();
        }

        private void bgLista_DoWork(object sender, DoWorkEventArgs e)
        {
            //  Llena_Lista();
            listIma = ObtieneNombreImagenes().Result;
        }

        private void ArmaNombArchi()
        {
            string nombreArchivo = cDonde + "_" + lblCliDocu.Text + ".Jpg";
            if(lblMor.Visible == false)
            {
                lblNombCompleto.Text = String.Format("{0}\\{1}", bl.pGlob.Configuracion.rutaComprIma, nombreArchivo);
            }
            else
            {
                lblNombCompleto.Text = String.Format("{0}\\{1}", bl.pGlob.Configuracion.rutaComprImaMor, nombreArchivo);
            }
            if(Auxiliares.Utilidades.EstaArchivo(lblNombCompleto.Text))
            {
                lblNombCompleto.Visible = true;
                Image img = bl.BuscarImagen(lblNombCompleto.Text);
                pictureScan.Image = img;
                pictureScan.SizeMode = PictureBoxSizeMode.StretchImage;
                btnEnvio.Visible = true;
            }
        }
        private void frmScan_Load(object sender, EventArgs e)
        {
            //opDocumento1.Checked = false;
            //opDocumento1.Checked = true;
            RecargarEmpYComercio(bEsM);
            //Muestra_Scaner();
            //ConfigurarPictureBoxes();   
            //Configura_Inicio();
            //Llena_Lista();
            //MessageBox.Show(horatiempo);
            if(cQueScan == "CLIENTE")
            {
                BuscaCliente();
                lblCliDocu.Text = nDocumento.ToString();
                lblCliNombre.Text = cNombre;

            }
            else
            {
                grb.Visible = false;
                grbNombre.Text = "Comprobante";
                label3.Text = "Tipo";
                label2.Text = "Nro.";
                grbScan.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
                this.Width = grbScan.Width + 50;
                grbScan.Left = grbNombre.Left;
                scan.Left = 10;
                grbScan.Top = grbNombre.Top + grbNombre.Height + 5;
                btnGrabar.Left = grbScan.Left + grbScan.Width - btnGrabar.Width;
                scan.Top = grbScan.Top + grbScan.Height + 5;
                btnGrabar.Top = scan.Top;
                lblNombCompleto.Top = scan.Top;
                lblNombCompleto.Left = scan.Left + scan.Width + 5;
                lblCliDocu.Text = nDocumento.ToString();
                lblCliNombre.Text = cNombre;
                btnEnvio.Top = scan.Top;
                btnEnvio.Left = btnGrabar.Left - btnEnvio.Width - 10; // scan.Left + scan.Width + 5;
                btnEnvio.Visible = false;

                btnAcciones.Top = btnEnvio.Top;
                btnAcciones.Left = btnEnvio.Left - btnAcciones.Width - 10;
                btnAcciones.Visible = true;

                ahora = DateTime.Now;
                ArmaNombArchi();
                luego = DateTime.Now;
                ts = luego - ahora;
                horatiempo += " ArmaNombArchi(): " + ts.Seconds;
            }
            grpAcciones.Top = grbScan.Top;
            grpAcciones.Left = grbScan.Left;
            //Muestra_Scaner();
        }

        private void bgLista_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            LlenaLista(listIma);
            // MensajeEventArgs me = new MensajeEventArgs("Buscando Imágenes");
            //me.ValorProgressBar = 100;
            bp.ActualizarBarraProgreso(100);
            bp.Close();
            //this.Invoke(actualizarBarraDeEstadoEvent, this, me);
        }

        private async Task<Dictionary<string, Tuple<string, string>>> ObtieneNombreImagenes()
        {
            Dictionary<String, Tuple<string, string>> listado = new Dictionary<String, Tuple<string, string>>();
            //bool bYaMostro = false;
            string cArch;
            string cArch2;
            string cArchExis = "";
            List<TipoImagen> regImaList;
            Tuple<string, string> item;
            List<string> listaArchs;
            cArch2 = "C" + nDocumento.ToString();
            cArch = string.Format("{0}\\{1}", bl.pGlob.Configuracion.rutaFotos, cArch2);
            listaArchs = bl.EnumerarRutaImagenesDNI(cArch2, bl.pGlob.Configuracion.rutaFotos);
            if(listaArchs != null)
                cArchExis = listaArchs.FirstOrDefault();

            if(!string.IsNullOrEmpty(cArchExis) && cArchExis.Count() > 0)
            {
                item = new Tuple<string, string>("Foto", cArchExis);
                listado.Add("Foto", item);
            }
            regImaList = bl.Get<TipoImagen>(m => m.Nombre != "", o => o.OrderBy(i => i.Orden)).ToList();
            if(regImaList.Count > 0)
            {
                foreach(TipoImagen tima in regImaList)
                {
                    cArchExis = null;
                    cArch = nDocumento.ToString().PadLeft(8, '0');
                    cArch2 = string.Format("{0}{1}", cArch, tima.Sufijo);
                    cArch = string.Format("{0}\\{1}", bl.pGlob.Configuracion.rutaImagenes, cArch2);
                    listaArchs = bl.EnumerarRutaImagenesDNI(cArch2, bl.pGlob.Configuracion.rutaImagenes);
                    if(listaArchs != null)
                        cArchExis = listaArchs.FirstOrDefault();

                    if(cArchExis != null)
                    {
                        {
                            item = new Tuple<string, string>(tima.Nombre, cArchExis);
                            listado.Add(tima.Sufijo, item);
                        }
                    }
                }
            }
            return listado;
        }

        private async Task LlenaLista(Dictionary<String, Tuple<string, string>> listado)
        {
            List<TipoImagen> regImaList;
            listBusca.Items.Clear();
            ListViewItem item;
            fontColor = Color.Empty;
            backColorList = Color.White;
            fontList = new System.Drawing.Font("Verdana", 10F, FontStyle.Regular);

            item = new ListViewItem("0");
            item.SubItems.Add("Foto", fontColor, backColorList, fontList);
            item.SubItems.Add("", fontColor, backColorList, fontList);
            if(listado.ContainsKey("Foto") && listado["Foto"].Item2 != null)
            {
                fontList = new System.Drawing.Font("Verdana", 10F, FontStyle.Bold);
                item.SubItems[1].Font = fontList;
                item.SubItems.Add(listado["Foto"].Item2, fontColor, backColorList, fontList);
            }
            else
                item.SubItems.Add("", fontColor, backColorList, fontList);

            listBusca.Items.Add(item);

            regImaList = bl.Get<TipoImagen>(m => m.Nombre != "", o => o.OrderBy(i => i.Orden)).ToList();
            foreach(TipoImagen tima in regImaList)
            {
                fontList = new System.Drawing.Font("Verdana", 10F, FontStyle.Regular);
                item = new ListViewItem(tima.Orden.ToString());
                item.SubItems.Add(tima.Nombre, fontColor, backColorList, fontList);
                item.SubItems.Add(tima.Sufijo, fontColor, backColorList, fontList);
                bool keyExists = listado.ContainsKey(tima.Sufijo);
                if(keyExists)
                {
                    fontList = new System.Drawing.Font("Verdana", 10F, FontStyle.Bold);
                    item.SubItems[1].Font = fontList;
                    item.SubItems.Add(listado[tima.Sufijo].Item2, fontColor, backColorList, fontList);
                }
                else
                    item.SubItems.Add("", fontColor, backColorList, fontList);
                listBusca.Items.Add(item);
                if(backColorList == Color.White) backColorList = Color.LightSteelBlue; else backColorList = Color.White;
            }

            /////////////////////////edunvo202112
            if(bl.pGlob.Configuracion.ScanSolicitudes)
            {
                List<Credito> regListCre = bl.GetCreditos(BaseID, c => c.ComercioID == Com.ComercioID && c.Documento == nDocumento && c.TipoDocumentoID == cDocumento).ToList();
                if(regListCre.Count > 0)
                {
                    regListCre = regListCre.OrderByDescending(o => o.FechaSolicitud).ToList();
                    foreach(Credito cr in regListCre)
                    {
                        fontList = new System.Drawing.Font("Verdana", 10F, FontStyle.Regular);
                        item = new ListViewItem("SOL".ToString());
                        item.SubItems.Add(cr.CreditoID.ToString(), fontColor, backColorList, fontList);
                        item.SubItems.Add(ComID.ToString(), fontColor, backColorList, fontList);
                        if(Esta_Ima_Solicitud(cr.CreditoID.ToString()))
                        {
                            fontList = new System.Drawing.Font("Verdana", 10F, FontStyle.Bold);
                            item.SubItems[1].Font = fontList;
                            item.SubItems.Add("S", fontColor, backColorList, fontList);
                        }
                        else { 
                            item.SubItems.Add("", fontColor, backColorList, fontList); 
                        }

                        listBusca.Items.Add(item);
                        if(backColorList == Color.White) backColorList = Color.LightSteelBlue; else backColorList = Color.White;
                    }
                }
            }




            /////////////////////////edunvo202112
        }

        //private void PreparaLista()
        //{
        //    List<TipoImagen> regImaList;
        //    listBusca.Items.Clear();
        //    ListViewItem item;
        //    item = new ListViewItem("0");
        //    item.SubItems.Add("Foto", fontColor, backColorList, fontList);
        //    item.SubItems.Add("", fontColor, backColorList, fontList);
        //    listBusca.Items.Add(item);
        //    regImaList = bl.Get<TipoImagen>(m => m.Nombre != "", o => o.OrderBy(i => i.Orden)).ToList();
        //    foreach (TipoImagen tima in regImaList)
        //    {
        //        item = new ListViewItem(tima.Orden.ToString());
        //        item.SubItems.Add(tima.Nombre, fontColor, backColorList, fontList);
        //        item.SubItems.Add(tima.Sufijo, fontColor, backColorList, fontList);
        //        listBusca.Items.Add(item);
        //        if (backColorList == Color.White) backColorList = Color.LightSteelBlue; else backColorList = Color.White;
        //    }

        //}


        //private async Task Llena_Lista()
        //{


        //    bool bYaMostro = false;
        //    string cArch;
        //    string cArch2;
        //    string cArchExis = "";

        //    listBusca.Items.Clear();
        //    ListViewItem item;
        //    List<TipoImagen> regImaList;
        //    //fontList = new System.Drawing.Font("Verdana", 10F, FontStyle.Regular);
        //    fontColor = Color.Empty;
        //    backColorList = Color.White;
        //    //************************* FOTOS
        //    //FOTO
        //    fontList = new System.Drawing.Font("Verdana", 10F, FontStyle.Regular);
        //    item = new ListViewItem("0");
        //    //cArch = "C" + nDocumento.ToString() + ".JPG";
        //    cArch2 = "C" + nDocumento.ToString() + ".JPG";
        //    cArch = string.Format("{0}\\{1}", bl.pGlob.Configuracion.rutaFotos, cArch2);
        //    ahora = DateTime.Now;
        //    //if (File.Exists(cArch))
        //    if(Auxiliares.Utilidades.EstaArchivo(cArch))
        //    {
        //        fontList = new System.Drawing.Font("Verdana", 10F, FontStyle.Bold);
        //        cArchExis = cArch;
        //    }
        //    luego = DateTime.Now;
        //    ts = luego - ahora;
        //    horatiempo += " File.Exists(): " + cArch + ts.Seconds;
        //    item.SubItems.Add("Foto", fontColor, backColorList, fontList);
        //    item.SubItems.Add("", fontColor, backColorList, fontList);
        //    item.SubItems.Add(cArchExis, fontColor, backColorList, fontList);
        //    listBusca.Items.Add(item);

        //    // *************************IMAGENES
        //    backColorList = Color.LightSteelBlue;
        //    ahora = DateTime.Now;
        //    regImaList = bl.Get<TipoImagen>(m=>m.Nombre != "",o=>o.OrderBy(i=>i.Orden)).ToList();
        //    luego = DateTime.Now;
        //    ts = luego - ahora;
        //    horatiempo += " OrdenaTipoImagen(): " + ts.Seconds;
        //    if (regImaList.Count>0)
        //    {
        //        foreach(TipoImagen tima in regImaList)
        //        {
        //            cArchExis = "";
        //            fontList = new System.Drawing.Font("Verdana", 10F, FontStyle.Regular);
        //            item = new ListViewItem(tima.Orden.ToString());
        //            cArch = nDocumento.ToString().PadLeft(8, '0');
        //            //cArch = cArch + tima.Sufijo;
        //            cArch2 = string.Format("{0}{1}.jpg", cArch, tima.Sufijo);

        //            cArch = string.Format("{0}\\{1}", bl.pGlob.Configuracion.rutaImagenes, cArch2);
        //            /* cdc_nvo 07102020 */
        //            //if (File.Exists(cArch))

        //            //if (bl.ExisteImagenDni(nDocumento.ToString().PadLeft(8, '0'), tima.Sufijo))


        //            //var myFilesToProcessInfos = new DirectoryInfo(bl.pGlob.Configuracion.rutaImagenes).EnumerateFileSystemInfos("*", SearchOption.AllDirectories).Where(x => x.Name.Contains(cArch2) /*&& x.CreationTime == your pattern*/);
        //            //foreach (FileInfo fInfo in myFilesToProcessInfos)
        //            //{
        //            //    cNombreImagen = fInfo.FullName;
        //            //    MostrarImagen();
        //            //    bYaMostro = true;
        //            //}



        //            ahora = DateTime.Now;
        //            //Task<string> TraerRuta = bl.TraeRutaImagen(nDocumento.ToString().PadLeft(8, '0'), tima.Sufijo);
        //            //cArchExis = await TraerRuta;

        //            cArchExis = bl.SearchDirectory(bl.pGlob.Configuracion.rutaImagenes, cArch2).FirstOrDefault();

        //            luego = DateTime.Now;
        //            ts = luego - ahora;
        //            horatiempo += " TraeRutaImagen(): " + tima.Nombre + ":" + ts.Seconds;
        //            if (cArchExis != null)
        //            {
        //                fontList = new System.Drawing.Font("Verdana", 10F, FontStyle.Bold);
        //                //cArchExis = cArch;
        //                if (bYaMostro == false)
        //                {
        //                    cNombreImagen = cArch; // cArch2;
        //                    MostrarImagen();
        //                    bYaMostro = true;
        //                }
        //            }
        //            item.SubItems.Add(tima.Nombre, fontColor, backColorList, fontList);
        //            item.SubItems.Add(tima.Sufijo ,fontColor, backColorList, fontList);
        //            item.SubItems.Add(cArchExis, fontColor, backColorList, fontList);
        //            listBusca.Items.Add(item);
        //            if (backColorList == Color.White) backColorList = Color.LightSteelBlue; else backColorList = Color.White;
        //        }
        //    }

        //}

        private void Configura_Inicio()
        {
            Recorre_Formulario(this);
            Configura_Colores(bl.pGlob.Comercio.EmpresaID);
            this.BackColor = ColorBackColorFrm;
            lblSoliTit.BackColor = ColorBackColorInf;
            Configura_Lista();
            Centrar_Control(this, panelSoli);
            lblSoli.Visible = false;
        }
        private void Configura_Lista()
        {

            listBusca.Visible = false;
            listBusca.Columns.Clear();
            listBusca.View = View.Details;
            listBusca.Columns.Add("", 0, HorizontalAlignment.Right);  //
            listBusca.Columns.Add("Imagen", 100, HorizontalAlignment.Left);  //
            listBusca.Columns.Add("", 0, HorizontalAlignment.Right);  //
            listBusca.Columns.Add("", 0, HorizontalAlignment.Right);  //

            //listIma.Columns.Add("Nro", 100, HorizontalAlignment.Right);  //
            listBusca.OwnerDraw = true;
            listBusca.GridLines = false;
            listBusca.FullRowSelect = true;
            listBusca.Visible = true;
        }

        private void ConfigurarPictureBoxes()
        {
            panelScan.AutoScroll = true;
            pictureScan.SizeMode = PictureBoxSizeMode.AutoSize;
        }

        //private void Muestra_Imagenes(int nQue)
        //{
        //    //picFoto.Image = bl.BuscarFotosDni(txtBuscaDoc.Text);
        //    //picFirma.Image = bl.BuscarUnaImagenDni(txtBuscaDoc.Text, "FIR");
        //    //picDocu.Image = bl.BuscarUnaImagenDni(txtBuscaDoc.Text, "DOC_01");
        //    bl = new BusinessLayer();
        //    picIma.Image = null;

        //    switch(nQue)
        //    {
        //        case 1:
        //            picIma.Image = bl.BuscarUnaImagenDni(lblCliDocu.Text , "_SOL_01");
        //            break;
        //    }

        //}
        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void Muestra_Scaner()
        {
            // Clear the ListBox.
            Devices.Items.Clear();

            // Create a DeviceManager instance
            var deviceManager = new DeviceManager();


            // Loop through the list of devices and add the name to the listbox
            for(int i = 1; i <= deviceManager.DeviceInfos.Count; i++)
            {
                //Add the device to the list if it is a scanner
                if(deviceManager.DeviceInfos[i].Type != WiaDeviceType.ScannerDeviceType)
                {
                    continue;
                }
                Devices.Items.Add(new Scanner(deviceManager.DeviceInfos[i]));
            }
        }

        private void scan_Click(object sender, EventArgs e)
        {
            //// Scanner selected?
            //var device = Devices.SelectedItem as Scanner;
            //if (device == null)
            //{
            //    MessageBox.Show("Por favor seleccione un dispositivo", "Advertencia",
            //                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //// Scan
            ////var image = device.ScanFromDevice();

            var image = Scanner.Scan();
            if(image != null)
            {
                var imageBytes = (byte[])image.FileData.get_BinaryData();
                ms = new MemoryStream(imageBytes);
                var img = Image.FromStream(ms);
                pictureScan.Image = img;
                //image.SaveFile(path); 
            }


        }

        //private void opSolicitud1_Click(object sender, EventArgs e)
        //{
        //    Muestra_Imagenes(1);
        //}
        private async void Graba_Imagen()
        {
            //bool bSoliitud = false;
            string nombreArchivo; // = lblRuta.Text;
            string rutaArchivo;
            DialogResult dr;
            if(pictureScan.Image == null) return;
            if(cDonde == "CLIENTE")
            {
                if(listBusca.SelectedItems.Count <= 0)
                {
                    MessageBox.Show("Debe seleccionar un item donde guardar la imágen", "Error", MessageBoxButtons.OK);
                    return;
                }
                nombreArchivo = lblRuta.Text;

                if(listBusca.SelectedItems[0].SubItems[2].Text == Com.ComercioID.ToString())
                {
                    PreparaSolicitudGrabar(ComID.ToString(), listBusca.SelectedItems[0].SubItems[1].Text);
                    return;
                    //rutaArchivo = SOlicitud_Nueva(ComID.ToString(), listBusca.SelectedItems[0].SubItems[1].Text);
                    //if(rutaArchivo == "")
                    //{
                    //    MessageBox.Show("Ya están todas la imágenes del crédito");
                    //    return;
                    //}

                    //dr = MessageBox.Show(String.Format("Se guardará la solicitud {0}", listBusca.SelectedItems[0].SubItems[1].Text), "Imagen nueva", MessageBoxButtons.YesNo);


                }
                else
                {

                
                    dr = MessageBox.Show(String.Format("Se guardará la imágen {0}", listBusca.SelectedItems[0].SubItems[1].Text), "Imagen nueva", MessageBoxButtons.YesNo);

                    if(listBusca.SelectedItems[0].SubItems[1].Text == "Foto")
                    {
                        rutaArchivo = String.Format("{0}\\{1}", bl.pGlob.Configuracion.rutaFotos, nombreArchivo);

                    }
                    else
                    {
                        rutaArchivo = String.Format("{0}\\{1}", bl.pGlob.Configuracion.rutaImagenes, nombreArchivo);
                    }
                }
            }
            else
            {
                nombreArchivo = cDonde + "_" + lblCliDocu.Text + ".Jpg";
                dr = MessageBox.Show(String.Format("Se guardará la imágen {0}", " del " + cNombre), "Imagen nueva", MessageBoxButtons.YesNo);
                if(lblMor.Visible == false)
                {
                    rutaArchivo = String.Format("{0}\\{1}", bl.pGlob.Configuracion.rutaComprIma, nombreArchivo);
                }
                else
                {
                    rutaArchivo = String.Format("{0}\\{1}", bl.pGlob.Configuracion.rutaComprImaMor, nombreArchivo);
                }
                

            }


            if(dr == System.Windows.Forms.DialogResult.Yes)
            {
                if(File.Exists(rutaArchivo))
                {
                    dr = MessageBox.Show("Ya existe un archivo con el mismo nombre,¿desea sobrescribirlo?", "Archivo Existente", MessageBoxButtons.YesNo);
                    if(dr == System.Windows.Forms.DialogResult.Yes)
                    {
                        try
                        {
                            File.Delete(rutaArchivo);
                        }
                        catch(System.IO.IOException)
                        {
                            if(cDonde == "CLIENTE")
                            {
                                rutaArchivo = String.Format("{0}\\{1}.REVISAR", bl.pGlob.Configuracion.rutaImagenes, nombreArchivo);
                            }
                            else
                            {
                                rutaArchivo = String.Format("{0}\\{1}.REVISAR", bl.pGlob.Configuracion.rutaComprIma, nombreArchivo);
                            }
                            log.Debug(String.Format("No se ha podido sobrescribir una imagen, se graba con otro nombre:{0}", nombreArchivo));
                        }
                    }
                }
                Graba_Imagen_Nueva(nombreArchivo, rutaArchivo);

                lblNombCompleto.Text = rutaArchivo;
                btnEnvio.Visible = true;
            }
            pictureScan.Image = null;
            if(cDonde == "CLIENTE")
            {
                BuscaCliente();
                MostrarImagen(rutaArchivo);
            }
            else
            {
                MessageBox.Show("La imágen se grabó " + rutaArchivo);
                ArmaNombArchi();
            }
        }
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            Graba_Imagen();
        }



        private void MostrarImagen(string rutaArchivo)
        {
            try
            {
               
                //string rutaArchivo = cNombreImagen; // string.Format("{0}\\{1}", bl.pGlob.Configuracion.rutaImagenes, cNombreImagen);
                Image img = bl.BuscarImagen(rutaArchivo);
                if(img != null)
                    picIma.Image = img;
                else
                    picIma.Image = null;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al mostrar la imagen:" + cNombreImagen, "Error", MessageBoxButtons.OK);
            }

        }


        private void grb_Paint(object sender, PaintEventArgs e)
        {

        }

        private void grbScan_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listBusca_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sufijo = "";
            btnImaAnterior.Visible = false;//edunvo202112
            btnImaSiguiente.Visible = false;//edunvo202112
            lblIma.Visible=false;//edunvo202112

            string nombreArchivo = nDocumento.ToString().PadLeft(8, '0');
            btnEnvioIma.Visible = false;
            foreach(ListViewItem aa in listBusca.SelectedItems)
            {
                if(aa.Text == "0") scan.Enabled = false; else scan.Enabled = true;

                sufijo = aa.SubItems[2].Text;
                if(aa.SubItems.Count > 3)
                    if(aa.SubItems[3].Text != null)
                        nombreArchivo = aa.SubItems[3].Text;

                if(sufijo == "")
                {
                    picIma.Image = bl.BuscarFotosDni(nDocumento.ToString());
                }
                else if(sufijo == ComID.ToString()) //.ComercioID.ToString())//edunvo202112
                {
                    Busca_Ima_Solicitud(aa.SubItems[1].Text, true);
                    //if(picIma.Image != null) btnEnvioIma.Visible = true;
                    return;
                }
                else
                {
                    picIma.Image = bl.BuscarUnaImagenDni(nDocumento.ToString(), sufijo);

                }
                cImagen = nombreArchivo;
                lblRuta.Text = string.Format("{0}{1}.jpg", nDocumento.ToString().PadLeft(8, '0'), sufijo);
                //if(picIma.Image!= null) btnEnvioIma.Visible = true;

            }
        }

        private void picIma_Click(object sender, EventArgs e)
        {

        }

        private void picIma_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if(picIma.Image != null)
                {
                    Process.Start(cImagen);
                }
            }
            catch { }
        }
        //private void MandaImaDeAUna()
        //{

        //}
        private void btnEnvio_Click(object sender, EventArgs e)
        {
            int nComercio = Com.ComercioID;
            if(cDonde == "CLIENTE")
            {
                int nCant = 0;
                string[,] aArchivos;
                foreach(ListViewItem item in listBusca.Items)
                {
                    if(item.SubItems[3].Text != "")  // && item.SubItems[3].Text != "S")
                    {
                        if(item.SubItems[3].Text == "S")
                        {
                            Busca_Ima_Solicitud(item.SubItems[1].Text, false);
                            if(cImagenesSoli.Length > 0)
                            {
                                nCant = nCant + cImagenesSoli.Length;
                            }
                        }
                        else
                        {
                            nCant++;
                        }
                        
                    }

                }
                aArchivos = new string[nCant, 2];
                nCant = 0;
                foreach(ListViewItem item in listBusca.Items)
                {
                    if(item.SubItems[3].Text != "")  // && item.SubItems[3].Text != "S")
                    {
                        aArchivos[nCant, 0] = item.SubItems[3].Text;
                        if(item.SubItems[0].Text == "0")
                        {
                            aArchivos[nCant, 1] = "//" + bl.pGlob.Configuracion.rutaFTPFotos + "/" + LLena_Ceros(bl.pGlob.ComercioID.ToString(), 4);
                            nCant++;
                        }
                        else
                        {
                            if(item.SubItems[3].Text == "S")
                            {
                                Busca_Ima_Solicitud(item.SubItems[1].Text, false);
                                if(cImagenesSoli.Length > 0)
                                {
                                    for(int n = 0; n < cImagenesSoli.Length; n++)
                                    {
                                        aArchivos[nCant, 0] = cImagenesSoli[n];
                                        if(ComID == bl.pGlob.ComercioID)
                                        {
                                            aArchivos[nCant, 1] = "//" + bl.pGlob.Configuracion.rutaFTPSolicitudes + "/" + LLena_Ceros(Com.ComercioID.ToString(), 4);
                                        }
                                        else
                                        {
                                            aArchivos[nCant, 1] = "//" + bl.pGlob.Configuracion.rutaFTPSolicitudesMor + "/" + LLena_Ceros(Com.ComercioID.ToString(), 4);
                                        }
                                        nCant++;
                                    }

                                }
                            }
                            else
                            {
                                aArchivos[nCant, 1] = "//" + bl.pGlob.Configuracion.rutaFTPImagenes + "/" + LLena_Ceros(bl.pGlob.ComercioID.ToString(), 4);
                                nCant++;
                            }
                        }
                        
                    }
                }

                if(nCant > 0)
                {
                    frmFTPEnvio frmFTP1 = new frmFTPEnvio(p, aArchivos);
                    frmFTP1.Show();
                    frmFTP1.MandaArrayArchivos(nComercio);
                }
                //if(bl.pGlob.Configuracion.ScanSolicitudes)
                //{
                //    aArchivos = new string[nCant, 2];
                //    nCant = 0;
                //    foreach(ListViewItem item in listBusca.Items)
                //    {
                //        if(item.SubItems[3].Text == "S")
                //        {
                //            Busca_Ima_Solicitud(item.SubItems[1].Text, false);
                //            if(cImagenesSoli.Length > 0)
                //            {
                //                nCant = nCant + cImagenesSoli.Length;
                //            }

                //        }
                //    }
                //    aArchivos = new string[nCant, 2];
                //    nCant = 0;
                //    foreach(ListViewItem item in listBusca.Items)
                //    {
                //        if(item.SubItems[3].Text == "S")
                //        {
                //            Busca_Ima_Solicitud(item.SubItems[1].Text, false);
                //            if(cImagenesSoli.Length > 0)
                //            {
                //                for(int n = 0; n < cImagenesSoli.Length; n++)
                //                {
                //                    aArchivos[nCant, 0] = cImagenesSoli[n];
                //                    aArchivos[nCant, 1] = "//" + bl.pGlob.Configuracion.rutaFTPSolicitudes + "/" + LLena_Ceros(bl.pGlob.ComercioID.ToString(), 4);
                //                    nCant++;
                //                }

                //            }
                //        }

                //    }
                //    if(nCant > 0)
                //    {
                //        frmFTPEnvio frmFTP1 = new frmFTPEnvio(p, aArchivos);
                //        frmFTP1.Show();
                //        frmFTP1.MandaArrayArchivos();
                //    }

                //}
            }
            else
            {
                frmFTPEnvio frmFTP = new frmFTPEnvio(p, lblNombCompleto.Text, "//" + bl.pGlob.Configuracion.rutaFTPComrp + "/" + LLena_Ceros(bl.pGlob.ComercioID.ToString(), 4));
                frmFTP.Show();
                frmFTP.MandaArchivo(nComercio);
            }

        }

        private void pictureScan_DoubleClick(object sender, EventArgs e)
        {
            if(cDonde == "CLIENTE") return;
            if(pictureScan.Image != null)
            {
                //Process.Start(bl.pGlob.Configuracion.rutaImagenes + "\\" + cNombreImagen);
                Process.Start(lblNombCompleto.Text);
            }
        }

        private void btnAcciones_Click(object sender, EventArgs e)
        {
            lblDir.Text = "";
            lblAccNombre.Text = "";
            lblAccPath.Text = "";
            LeerRutaCarpeta();
            //picImaNvo.Image = null;
            //grpAcciones.Visible = true;
        }
        private void LeerRutaCarpeta()
        {
            ofd.Filter = "jpg files (*.jpg)|*.jpg";
            DialogResult result = ofd.ShowDialog();
            if(result == DialogResult.OK)
            {
                lblDir.Text = System.IO.Path.GetFullPath(ofd.FileName);
                lblAccNombre.Text = System.IO.Path.GetFileName(ofd.FileName);
                lblAccPath.Text = System.IO.Path.GetDirectoryName(ofd.FileName);
                Image img = bl.BuscarImagen(lblDir.Text);
                if(img != null)
                {
                    pictureScan.Image = img;
                    pictureScan.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                    pictureScan.Image = null;
            }
            Console.WriteLine(result);
        }

        private void btnDir_Click(object sender, EventArgs e)
        {
            LeerRutaCarpeta();
        }

        private void btnAccCerrar_Click(object sender, EventArgs e)
        {
            grpAcciones.Visible = false;
        }

        private void btnAccGrabar_Click(object sender, EventArgs e)
        {
            pictureScan.Image = picImaNvo.Image;
            Graba_Imagen();
            grpAcciones.Visible = false;
            //if(cDonde == "CLIENTE")
            //{

            //}
            //else
            //{

            //}
        }

        private void grbNombre_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnImaAnterior_Click(object sender, EventArgs e)
        {
            if(cImagenesSoli != null && cImagenesSoli.Length > 0)
            {
                if(cImagenesSoli.Length == 1) return;
                int nIma1 = 0;
                int nIma2 = cImagenesSoli.Length;
                if(nImagenesSoli == 0)
                {
                    nImagenesSoli = cImagenesSoli.Length - 1;
                }
                else
                {
                    nImagenesSoli = nImagenesSoli - 1;
                }
                Image ima = bl.BuscarImagen(cImagenesSoli[nImagenesSoli]);
                picIma.Image = ima;
                nIma1 = nImagenesSoli + 1;
                lblIma.Text = nIma1.ToString() + " / " + nIma2.ToString();
                lblRuta.Text = cImagenesSoli[nImagenesSoli];
                cImagen = cImagenesSoli[nImagenesSoli];
            }
        }

        private void btnImaSiguiente_Click(object sender, EventArgs e)
        {

            if(cImagenesSoli != null && cImagenesSoli.Length > 0)
            {
                if(cImagenesSoli.Length == 1) return;
                int nIma1 = 0;
                int nIma2 = cImagenesSoli.Length;
                if(nImagenesSoli == cImagenesSoli.Length - 1)
                {
                    nImagenesSoli = 0;
                }
                else
                {
                    nImagenesSoli++;
                }
                Image ima = bl.BuscarImagen(cImagenesSoli[nImagenesSoli]);
                picIma.Image = ima;
                nIma1 = nImagenesSoli + 1;
                lblIma.Text = nIma1.ToString() + " / " + nIma2.ToString();
                lblRuta.Text = cImagenesSoli[nImagenesSoli];
                cImagen = cImagenesSoli[nImagenesSoli];
            }
        }

        private void btnEnvioIma_Click(object sender, EventArgs e)
        {

        }

        private void btnSoliCancel_Click(object sender, EventArgs e)
        {
            lblSombra.Visible = false;
            panelSoli.Visible = false;
        }

        private void Ops1_CheckedChanged(object sender, EventArgs e)
        {
            lblSoli.Text = Ops1.Tag.ToString();
        }

        private void Ops2_CheckedChanged(object sender, EventArgs e)
        {
            lblSoli.Text = Ops2.Tag.ToString();
        }

        private void Ops3_CheckedChanged(object sender, EventArgs e)
        {
            lblSoli.Text = Ops3.Tag.ToString();
        }

        private void btnSoliGrabar_Click(object sender, EventArgs e)
        {
            GrabaSolicitud();
        }
    }
}
