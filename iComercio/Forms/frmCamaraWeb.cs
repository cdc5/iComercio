using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using iComercio.Auxiliar;
using iComercio.Models;                   
using AForge.Video;

namespace iComercio.Forms
{
    public partial class frmCamaraWeb : FRM
    {
        public NewFrameEventHandler FrameEventHandler;
        public Video vd;
        int dni;
        string nombre;
        bool EsM;

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public frmCamaraWeb(Principal p,BusinessLayer bl,int dni, string nombre,bool EsM):base(p,bl)
        {
            InitializeComponent();
            this.dni = dni;
            this.nombre = nombre;
            this.EsM = EsM;
        }

        private void frmCamaraWeb_Load(object sender, EventArgs e)
        {
            RecargarEmpYComercio(EsM);
            lblCliNombre.Text = nombre;
            lblCliDocu.Text = dni.ToString();
            vd = new Video();
            FrameEventHandler = new NewFrameEventHandler(VideoNewFrame);
            vd.IniciarDispositivo(0, FrameEventHandler);
            
        }

        private void btnTomarFoto_Click(object sender, EventArgs e)
        {
            vd.IniciarDispositivo(0, FrameEventHandler);
        }

        private string ObtenerNombreArchivo()
        {
            string nombreArchivo = string.Format("{0}{1}.jpg",bl.pGlob.Configuracion.pre_foto, dni);
            return nombreArchivo;
        }
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            string nombreArchivo = ObtenerNombreArchivo();
            string rutaArchivo;
            DialogResult dr = MessageBox.Show(String.Format("Se guardará la Foto para el DNI {0}", dni), "Imagen nueva", MessageBoxButtons.YesNo);
            if (dr == System.Windows.Forms.DialogResult.Yes)
            {
                rutaArchivo = String.Format("{0}\\{1}", bl.pGlob.Configuracion.rutaFotos, nombreArchivo);
                if (File.Exists(rutaArchivo))
                {
                    dr = MessageBox.Show("Ya existe un archivo con el mismo nombre,¿desea sobrescribirlo?", "Archivo Existente");
                    if (dr == System.Windows.Forms.DialogResult.Yes)
                    {
                        try
                        {
                            File.Delete(rutaArchivo);
                        }
                        catch( System.IO.IOException)
                        {
                            rutaArchivo = String.Format("{0}\\{1}.REVISAR", bl.pGlob.Configuracion.rutaImagenes, nombreArchivo);
                            log.Debug(String.Format("No se ha podido sobrescribir una imagen, se graba con otro nombre:{0}", nombreArchivo));
                         }
                    }
                }
                pcbFoto.Image.Save(rutaArchivo, System.Drawing.Imaging.ImageFormat.Jpeg);
                bl.AgregarTransmisionArchivo(Com, nombreArchivo, rutaArchivo, "Fotos");
            }
           
            //string nombre = String.Format("{0:yyyyMMddhhmmss}-DNI.jpg",DateTime.Now);
            //string path = "c:\\" + nombre;
            //pcb.Image.Save(path,ImageFormat.Jpeg);
        }

        private void btnParar_Click(object sender, EventArgs e)
        {
            vd.Cerrar();
        }


        //eventhandler if new frame is ready
        private void VideoNewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try 
            {
                Bitmap img = (Bitmap)eventArgs.Frame.Clone();
                //do processing here
                pcb.Image = img;
            }
            catch (System.InvalidOperationException ex)
            {
                Debug.Print("Error de hilos que no deberia pasar, lo pongo para saber si es que sucede por un tema del visual studio");
                Debug.Print(",o por que las librerias se ejecutan en distintos hilos");
                Debug.Print(" Si este mensaje se escribio quiere decir que es por un tema de librerias y no por hilos de Visual");
            }
        }

        private void frmCamaraWeb_FormClosing(object sender, FormClosingEventArgs e)
        {
            vd.Cerrar();
        }

        private void grbFoto_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnTomarFoto_Click_1(object sender, EventArgs e)
        {
            pcbFoto.Image = pcb.Image;
        }
    }
}
