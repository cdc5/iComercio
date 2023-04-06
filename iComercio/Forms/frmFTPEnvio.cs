using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace iComercio.Forms
{
    public partial class frmFTPEnvio : FRM
    {
        string[, ] lArchivos;
        string cFTPServer;
        string cFTPUsu;
        string cFTPClave;
        string cFTPDirIma;
        string cFTPDirFoto;
        string cFTPDirCompr;
        string cFTPDirSoli;
        string cFTPDirComprM;
        string cFTPDirSoliM;

        public frmFTPEnvio()
        {
            InitializeComponent();
        }

        private void frmFTPEnvio_Load(object sender, EventArgs e)
        {

        }
        public  frmFTPEnvio(Principal p, string[, ] lLista): base(p)
        {
            InitializeComponent();
            Configura_Inicio();
            lblArchivo.Text ="";
            lblDir.Text = "";
            lArchivos = lLista;

        }

		public  frmFTPEnvio(Principal p, string cArchivoENV, string cDirFTP)
			: base(p)
        {
			InitializeComponent();

            lblArchivo.Text = cArchivoENV;
            lblDir.Text = cDirFTP;
            Configura_Inicio();

		}
        public void MandaArrayArchivos(int nCom)
        {
            string cArchi = "";
            string cDir = "";
            int nEn = 0;
            
            int nTotalFilas = lArchivos.GetLength(0) - 1;
            int nTot = nTotalFilas + 1;
            lblAguarde.Visible = true;
            lblDir.Visible = true;
            lblAguarde.Text = "Creando directorios";
            Application.DoEvents();
            CrearDirectorios(0, nCom);
            if(bl.pGlob.Configuracion.ScanSolicitudes) CrearDirectorios(2, nCom);
            for (int nF = 0; nF <= nTotalFilas; nF++)
            {
                nEn++;
                cArchi = lArchivos[ nF,0];
                cDir = lArchivos[nF, 1];
                lblAguarde.Text = "Enviando archivo ";
                lblArchivo.Text = cArchi;
                lblDir.Text = nEn.ToString() + " / " + nTot.ToString();
                //EnviarFTP("credin.no-ip.info", "comercios", "Arag0rn/", cArchi, cDir);
                EnviarFTP(cFTPServer, cFTPUsu, cFTPClave, cArchi, cDir);
                
            }
            lblAguarde.Visible = false;
            this.Close();

        }
        private void CrearDirectorios(int nQue, int nComer)
        {
            if (nQue == 0)
            {
                CreateFolder(cFTPServer, cFTPUsu, cFTPClave, cFTPDirFoto);
                CreateFolder(cFTPServer, cFTPUsu, cFTPClave, cFTPDirFoto + "/" + LLena_Ceros(bl.pGlob.ComercioID.ToString(), 4));

                CreateFolder(cFTPServer, cFTPUsu, cFTPClave, cFTPDirIma);
                CreateFolder(cFTPServer, cFTPUsu, cFTPClave, cFTPDirIma + "/" + LLena_Ceros(bl.pGlob.ComercioID.ToString(), 4));
            }
            else if (nQue == 1)
            {
                CreateFolder(cFTPServer, cFTPUsu, cFTPClave, cFTPDirCompr);
                CreateFolder(cFTPServer, cFTPUsu, cFTPClave, cFTPDirCompr + "/" + LLena_Ceros(bl.pGlob.ComercioID.ToString(), 4));
                if(bl.LlevaM())
                {
                    CreateFolder(cFTPServer, cFTPUsu, cFTPClave, cFTPDirComprM);
                    CreateFolder(cFTPServer, cFTPUsu, cFTPClave, cFTPDirComprM + "/" + LLena_Ceros(nComer.ToString(), 4));
                }
            }
            else if(nQue == 2)
            {
                CreateFolder(cFTPServer, cFTPUsu, cFTPClave, cFTPDirSoli);
                CreateFolder(cFTPServer, cFTPUsu, cFTPClave, cFTPDirSoli + "/" + LLena_Ceros(bl.pGlob.ComercioID.ToString(), 4));
                if(bl.LlevaM())
                {
                    CreateFolder(cFTPServer, cFTPUsu, cFTPClave, bl.pGlob.Configuracion.rutaFTPSolicitudesMor);
                    CreateFolder(cFTPServer, cFTPUsu, cFTPClave, bl.pGlob.Configuracion.rutaFTPSolicitudesMor + "/" + LLena_Ceros(nComer.ToString(), 4));
                }
            }

        }
        public void MandaArchivo(int nComer)
        {
            lblAguarde.Text = "Enviando archivo ";
            lblAguarde.Visible = true;
            CrearDirectorios(1, nComer);
            EnviarFTP(cFTPServer, cFTPUsu, cFTPClave, lblArchivo.Text, lblDir.Text);
            lblAguarde.Visible = false;

            this.Close();
        }
        private void Configura_Inicio()
        {
            Recorre_Formulario(this);
            Configura_Colores(bl.pGlob.Comercio.EmpresaID);
            this.BackColor = ColorBackColorFrm;
            lblAguarde.Visible = false;
            lblAguarde.Text = ""; // "Enviando archivo";
            this.Text = "Envío de archivos";
            CargaDatosFTP();
  
        }
        private void CargaDatosFTP()
        {
            cFTPServer = bl.pGlob.Configuracion.ftpServer;
            cFTPUsu = bl.pGlob.Configuracion.ftpUsu;
            cFTPClave = bl.pGlob.Configuracion.ftpClave;
            cFTPDirIma = bl.pGlob.Configuracion.rutaFTPImagenes;
            cFTPDirFoto = bl.pGlob.Configuracion.rutaFTPFotos;
            cFTPDirCompr = bl.pGlob.Configuracion.rutaFTPComrp;
            cFTPDirSoli = bl.pGlob.Configuracion.rutaFTPSolicitudes;
        }
        private void EnviarFTP(string strServer, string strUser, string strPassword,
				   string strArchivo, string strDirFTP)
		{
			FtpWebRequest ftpRequest;
            AguardeFrm(lblAguarde);
            // Crea el objeto de conexión del servidor FTP
            ftpRequest = (FtpWebRequest)FtpWebRequest.Create("ftp://" + strServer + "//" + strDirFTP + "/" + Path.GetFileName(strArchivo));

			// Asigna las credenciales
			ftpRequest.Credentials = new NetworkCredential(strUser, strPassword);
			// Asigna las propiedades
			ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;
			ftpRequest.UsePassive = true;
			ftpRequest.UseBinary = true;
			ftpRequest.KeepAlive = false;
			const int cnstIntLengthBuffer = 2048;
            // Lee el archivo y lo envía
            
            try
            {
                using (FileStream stmFile = File.OpenRead(strArchivo))
                { // Obtiene el stream sobre la comunicación FTP
                    using (Stream stmFTP = ftpRequest.GetRequestStream())
                    {
                        byte[] arrBytBuffer = new byte[cnstIntLengthBuffer];
                        int intRead;

                        // Lee y escribe el archivo en el stream de comunicaciones
                        while ((intRead = stmFile.Read(arrBytBuffer, 0, cnstIntLengthBuffer)) != 0)
                        {
                            AguardeFrm(lblAguarde);
                            stmFTP.Write(arrBytBuffer, 0, intRead);
                        }
                        // Cierra el stream FTP
                        stmFTP.Close();
                    }
                    // Cierra el stream del archivo
                    stmFile.Close();
                }
            }
            catch (System.Net.WebException ex)
            {
                throw ex;
            }
            finally
            { this.Close(); }
            
        }
        private void AguardeFrm(Label olabel, int? nCuantos = 0)  
        {
            if (nCuantos == 0) nCuantos = 150;

            if (olabel.Text.Length > nCuantos) olabel.Text = "Enviando archivo "; else olabel.Text = olabel.Text + "|";
            Application.DoEvents();
        }


		
        private static bool CreateFolder(string strServer, string strUser, string strPassword, string folder)
		{
			bool success = false;

			System.Net.FtpWebRequest ftp_web_request = null;
			System.Net.FtpWebResponse ftp_web_response = null;

            string ftp_path = "ftp://" + strServer + "//" + folder;
			try
			{
				ftp_web_request = (FtpWebRequest)WebRequest.Create(ftp_path);
				ftp_web_request.Method = WebRequestMethods.Ftp.MakeDirectory;
                ftp_web_request.Credentials = new NetworkCredential(strUser, strPassword);

				ftp_web_response = (FtpWebResponse)ftp_web_request.GetResponse();

				string ftp_response = ftp_web_response.StatusDescription;
				string status_code = Convert.ToString(ftp_web_response.StatusCode);

				ftp_web_response.Close();

				success = true;
			}
			catch(Exception Ex)
			{
                //string status = Convert.ToString(Ex);

                //MessageBox.Show("ERROR AL CREAR EL DIRECTORIO" + Environment.NewLine + status); //debug
			}

			return success;
		}




        private void button1_Click(object sender, EventArgs e)
        {
            lblAguarde.Text = "Enviando archivo ";
            lblAguarde.Visible = true;
            EnviarFTP("credin.no-ip.info", "comercios", "Arag0rn/", lblArchivo.Text, lblDir.Text);
            lblAguarde.Visible = false;
        }
		


	}
}
        //private void FtpCreateFolderXXXX(string ftpAddress, string ftpUName, string ftpPWord)
        //{
        //    WebRequest ftpRequest = WebRequest.Create("ftp://" + ftpAddress + "/PRUEBAftp");
        //    ftpRequest.Method = WebRequestMethods.Ftp.MakeDirectory;
        //    ftpRequest.Credentials = new NetworkCredential(ftpUName, ftpPWord);
        //}


    //      private void aaaaXXXX(string cArch)
    //        {
    //            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://credin.no-ip.info");
    //            request.Method = WebRequestMethods.Ftp.UploadFile;

    //            // This example assumes the FTP site uses anonymous logon.
    //            request.Credentials = new NetworkCredential("comercios", "Arag0rn/");

    //            // Copy the contents of the file to the request stream.
    //            byte[] fileContents;
    //            using(StreamReader sourceStream = new StreamReader(cArch))
    //            {
    //                fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
    //            }

    //            request.ContentLength = fileContents.Length;

    //            using(Stream requestStream = request.GetRequestStream())
    //            {
    //                requestStream.Write(fileContents, 0, fileContents.Length);
    //            }

    //            using(FtpWebResponse response = (FtpWebResponse)request.GetResponse())
    //            {
    //                Console.WriteLine("Upload File Complete, status {response.StatusDescription}");
    //            }
    //        }


        //private void bbbXXXXX()
        //{
        //    FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create("ftp://" + "credin.no-ip.info//imacli" + "/20200108_145345.jpg");
        //    request.Method = WebRequestMethods.Ftp.UploadFile;
        //    request.Credentials = new NetworkCredential("comercios", "Arag0rn/");
        //    request.UsePassive = true;
        //    request.UseBinary = true;
        //    request.KeepAlive = true;


        //    //RUTA DONDE ESTA HUBICADO EL ARCHIVO
        //    FileStream stream = File.OpenRead(@"c:\20200108_145345.jpg");
        //    byte[] buffer = new byte[stream.Length];
        //    stream.Read(buffer, 0, buffer.Length);
        //    stream.Close();
        //    Stream reqStream = request.GetRequestStream();
        //    reqStream.Write(buffer, 0, buffer.Length);
        //    reqStream.Flush();
        //    reqStream.Close();
        //}