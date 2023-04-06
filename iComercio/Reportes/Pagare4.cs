using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using iComercio.Models;

namespace iComercio.Reportes
{
    public partial class Pagare4 : DevExpress.XtraReports.UI.XtraReport
    {
        public Pagare4()
        {
            InitializeComponent();
        }

        public Pagare4(Credito cred, Image Logo, bool EsM, string Titulo, string Financia)
        {
            InitializeComponent();
            bsCred.DataSource = cred;
            xrTitulo.Text = Titulo;
            xrFinancia.Text = Financia;
            string encabezado = String.Format("{1},{2},{3},{0} {4} - {5} {0} CUIT:{6} IIBB:{7} {0} Responsable Inscripto - I.A:{8}",
                                                Environment.NewLine, cred.Empresa.Domicilio, cred.Empresa.CP, cred.Empresa.Localidad, cred.Empresa.Telefonos, cred.Empresa.Mail,
                                                cred.Empresa.Cuit, cred.Empresa.IIBB, cred.Empresa.IA);
            xrLabel3.Text = encabezado;

            //xrPictureBox1.Image = Logo;
            if (EsM)
            {
                xrTitulo.Text = "";
                xrFinancia.Text = "";
                xrLabel3.Text = "";
                //xrPictureBox1.Image = null;
            }
        }
    }
}
