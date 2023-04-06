using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using iComercio.Models;
using iComercio.Auxiliar;

namespace iComercio.Reportes
{
    public partial class Pagare1 : DevExpress.XtraReports.UI.XtraReport
    {
        public Pagare1()
        {
            InitializeComponent();
            
        }

        public Pagare1(Credito cred,string Lugar, string Fecha, string Tribunales,Image logo,bool esM, string Titulo, string Financia)
        {
            InitializeComponent();
            string lugaryFecha = String.Format("{0},{1}", Lugar, Fecha);
            //Convertir Total a letras
            string Total = String.Format("{0:0.00}",cred.Total);
            string NumALetras;
            //string CuitA4 = "30-709144484-8";
            //string IIBBA4 = "C.M. 901-210802-0";
            //string MailA4 = "acuatro@acuatro.com.ar";
            //string IAA4 = "04/2005";
            xrTitulo.Text = Titulo;
            xrFinancia.Text = Financia;
            DateTime FechaUltimaCuota;
            string FechaAPagar = "";
            string encabezado = String.Format("{1},{2},{3},{0} {4} - {5} {0} CUIT:{6} IIBB:{7} {0} {8}",
                                                Environment.NewLine,cred.Empresa.Domicilio,cred.Empresa.CP,cred.Empresa.Localidad,cred.Empresa.Telefonos,cred.Empresa.Mail,
                                                cred.Empresa.Cuit,cred.Empresa.IIBB,cred.Empresa.IA);
            //String.Format("Avda. Triunvirato 5350,(CF1431FCT),Capital Federal,{0} Tel/Fax 45442224/1871/1994 - credin@credin.com.ar {0} CUIT. Nº:30-65920657-5 IIBB:C.M. 901 191598-5 {0} Responsable Inscripto - I.A:03/1993",
            //                              Environment.NewLine);
            xrLabel3.Text = encabezado;
            
            if (cred.Cuotas != null && cred.Cuotas.Count > 0)
            {
                FechaUltimaCuota = cred.Cuotas.Max(c => c.FechaVencimiento);
                FechaAPagar = String.Format("{0:dd/MM/yyyy}", FechaUltimaCuota);
            }
               
            xrlblLugaryFecha.Text = lugaryFecha;
            NumALetras = NumerosALetras.enletras(Total.ToString());
            xrlblTextoPagare.Text = String.Format( @"Pagaré/mos el {0} sin protesto a {3} o a su orden, la cantidad de PESOS 
{4} ({1}) con más los intereses desde la fecha de emisión hasta la de su efectivo pago a la tasa convenida del ___% mensual. Dejo/amos expresamente aclarado que en mi/nuestro carácter de librador/es, y de conformidad con lo dispuesto en el 
art.36 del Dec. Ley 5965/63, se amplía el plazo de presentación y protesto hasta un máximo de diez años a contar desde la fecha del libramiento. A todos sus efectos se pacta como única Jurisdicción los Tribunales Ordinarios de {2}",
            FechaAPagar, Total, Tribunales, cred.Empresa.Nombre, NumALetras);
            xrlblLugarPagadero.Text = String.Format("{0} {1}","Pagaderos en",Tribunales);
            xrlblComCredito.Text = String.Format("{0}-{1}", cred.ComercioID, cred.CreditoID);
            //xrPictureBox1.Image = logo;

            //*Domicilio dom = cred.Cliente.UltimoDomicilioCliente;

            if (cred.Cliente.EmpresaLaboral == "")
            {
                xrLabel80.Text = cred.Cliente.Profesion.ToString();
            }
            else
            {
                xrLabel80.Text = cred.Cliente.EmpresaLaboral;
            }
                           

            if (esM)
            {
                xrTitulo.Text = "";
                xrFinancia.Text = "";
                xrLabel3.Text = "";
            }

            bindingSource1.DataSource = cred;
            this.DataSource = bindingSource1;
            
        }

    }
}
