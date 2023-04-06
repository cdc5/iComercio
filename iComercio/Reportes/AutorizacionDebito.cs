using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using iComercio.Models;
using iComercio.Auxiliar;

namespace iComercio.Reportes
{
    public partial class AutorizacionDebito : DevExpress.XtraReports.UI.XtraReport
    {
        Image logo;
        public AutorizacionDebito()
        {
            InitializeComponent();
        }

        public AutorizacionDebito(Credito cred, string Lugar, string Fecha, Image logo, bool esM, CuentaBancariaCliente cbc, CuentaBancaria cb)
        {
            InitializeComponent();
            this.logo = logo;
            xrLogo.Image = this.logo;
            xrLogo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage;
            string subTitulo = String.Format("{0} – {1} {2} – {3} – Tel./Fax: {4} – e-mail: {5}",
                                                cred.Empresa.Nombre, cred.Empresa.Domicilio, cred.Empresa.CP,
                                                cred.Empresa.Localidad, cred.Empresa.Telefonos, cred.Empresa.Mail);
            xrSubTitulo.Text = subTitulo;
            XrLugar.Text = Lugar;
            xrFecha.Text = Fecha;
            xrTexto1.Text = String.Format(@"En mi carácter de titular de la cuenta debajo detallada, 
autorizo a {0} a debitar de la misma los importes mensuales que surjan de los servicios financieros contratados con dicha empresa.
Declaro estar en conocimiento y en total acuerdo con los importes a debitar.", cred.Empresa.Nombre);
            xrNombre.Text = cred.Cliente.Nombre;
            xrApellido.Text = cred.Cliente.Apellido;
            xrDNI.Text = cred.Cliente.Documento.ToString();
            xrCBU.Text = cbc.CBU;
            xrAlias.Text = cbc.Alias;
            xrBanco.Text = cbc.Banco.Nombre;
            xrCuenta.Text = cbc.NumCuentaBancaria;

            xrEmpresa.Text = cred.Empresa.Nombre;
            xrCuit.Text = cred.Empresa.Cuit;
            xrcbue.Text = cb.Cbu;
            xrBancoE.Text = cb.Banco.Nombre;
            xrCuentaE.Text = cb.NumCuenta;

            xrCondiciones.Text = xrCondiciones.Text.Replace("@EMP1", cred.Empresa.Nombre);
            xrCondiciones.Text = xrCondiciones.Text.Replace("@MAIL1", cred.Empresa.Mail);
            xrCondiciones.Text = xrCondiciones.Text.Replace("@TEL1", cred.Empresa.Telefono1);

            xrRepEmpresa.Text = String.Format("REPRESENTANTE POR {0}", cred.Empresa.Nombre).ToUpper();
        }

        private void TopMargin_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            
        }

        private void OnBeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRPictureBox pic = (XRPictureBox)sender;
            pic.Image = logo;  
            //((XRPictureBox)sender).Image = Image.FromFile("C:\\Test.jpg");
        }


    }
}
