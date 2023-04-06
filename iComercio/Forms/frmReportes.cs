using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using iComercio.Reportes;
using iComercio.Models;
using DevExpress;
using DevExpress.LookAndFeel;
using DevExpress.XtraReports.UI;


namespace iComercio.Forms
{
    public partial class frmReportes : FRM
    {
        public frmReportes()
        {
            InitializeComponent();
        }

        public frmReportes(Principal p):base(p)
        {
            InitializeComponent();
        }
        private void frmReportes_Load(object sender, EventArgs e)
        {
            //foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            //{
            //    MessageBox.Show(printer);
            //}

            Credito cred = bl.Get<Credito>().First();
            Cobranza cob = bl.Get<Cobranza>().First();

            Pagare1 pg = new Pagare1(cred,"San Nicolas de las quintanas","25/04/1987","La Ciudad de Bariloche",null,false,"CREDIN S.A.","Financia Mandragora");
            Pagare2 pg2 = new Pagare2(cred,null,false,"CREDIN S.A.","Financia Mandragora");
            Pagare3 pg3 = new Pagare3(cred, null, false, "CREDIN S.A.", "Financia Mandragora");
            Pagare4 pg4 = new Pagare4(cred, null, false, "CREDIN S.A.", "Financia Mandragora");

            Reportes.Chequera ch = new Reportes.Chequera(bl,cob, null, false, "CREDIN S.A.", "Financia Mandragora");
            Reportes.Chequera2 ch2 = new Reportes.Chequera2(bl,cob, null, false, "CREDIN S.A.", "Financia Mandragora");
            
            //List<Credito> creds = new List<Credito>();
            //creds.Add(cred);
            //pg.DataSource = creds;
            //pg.ShowPreview();
            //pg2.ShowPreview();
            //pg3.ShowPreview();
            //pg4.ShowPreview();
          
            ch.ShowPreview();
            ch2.ShowPreview();






            //using (ReportPrintTool printTool = new ReportPrintTool(pg))
            //{
            //    printTool.Print("SAM4S GIANT-100");
            //}
            //System.Threading.Thread.Sleep(10000);
            string archivo = "c:\\pagare.pdf";
            string archivoChequera1 = "c:\\chequera1.pdf";
            string archivoChequera2 = "c:\\chequera2.pdf";
            //pg.ExportToPdf(archivo);
            //pg2.ExportToPdf(archivo);
            //pg3.ExportToPdf(archivo);
            //pg4.ExportToPdf(archivo);
            ch.ExportToPdf(archivoChequera1);
            ch2.ExportToPdf(archivoChequera2);

           
            Process.Start(archivoChequera1);
            Process.Start(archivoChequera2);
            
        }

        private void documentViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
