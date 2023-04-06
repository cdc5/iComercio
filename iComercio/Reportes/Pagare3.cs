using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using DevExpress.XtraReports.UI;
using iComercio.Models;


namespace iComercio.Reportes
{
    public partial class Pagare3 : DevExpress.XtraReports.UI.XtraReport
    {
        public Pagare3()
        {
            InitializeComponent();
        }

        public Pagare3(Credito cred, Image Logo, bool EsM, string Titulo, string Financia)
        {
            InitializeComponent();
            xrTitulo.Text = Titulo;
            xrFinancia.Text = Financia;
            string encabezado = String.Format("{1},{2},{3},{0} {4} - {5} {0} CUIT:{6} IIBB:{7} {0} {8}",
                                                Environment.NewLine, cred.Empresa.Domicilio, cred.Empresa.CP, cred.Empresa.Localidad, cred.Empresa.Telefonos, cred.Empresa.Mail,
                                                cred.Empresa.Cuit, cred.Empresa.IIBB, cred.Empresa.IA);
            xrLabel3.Text = encabezado;
            string LeyendaComercio = String.Format("ESTIMADO CLIENTE {0} le agradece su visita", cred.Comercio.Nombre);
            string proximosVencimientos = "";
            cred.Cuotas.ToList().ForEach(c => proximosVencimientos = ProximosVencimientos(proximosVencimientos, c));
            xrLeyendaComercio.Text = LeyendaComercio;
            xrlblProxVenc.Text = proximosVencimientos;
            bsCred.DataSource = cred;
            //xrPictureBox1.Image = Logo;

            if (EsM)
            {
                xrTitulo.Text = "";
                xrFinancia.Text = "";
               // xrPictureBox1.Image = null;
                xrLabel3.Text = "";
            }
                
        }

        public string ProximosVencimientos(string proxVenc,Cuota c)
        {
            proxVenc = String.Format("{0} {4} * {1} {2} {3}", proxVenc, c.Importe.ToString(), c.FechaVencimiento.ToShortDateString(), Environment.NewLine,c.CuotaID);
            return proxVenc;
        }
    }
}
