using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Globalization;
using iComercio.Models;
namespace iComercio.Reportes
{
    public partial class Bonificadas : DevExpress.XtraReports.UI.XtraReport
    {
        public Bonificadas()
        {
            InitializeComponent();
        }

        public Bonificadas(Credito cred,string Lugar, string Fecha, string Tribunales,Image logo,bool esM, string Titulo, string Financia)
        {
            InitializeComponent();
            xrTitulo.Text = Titulo;
            string encabezado = String.Format("{1},{2},{3},{0} {4} - {5} {0} CUIT:{6} IIBB:{7} {0} {8}",
                                                Environment.NewLine, cred.Empresa.Domicilio, cred.Empresa.CP, cred.Empresa.Localidad, cred.Empresa.Telefonos, cred.Empresa.Mail,
                                                cred.Empresa.Cuit, cred.Empresa.IIBB, cred.Empresa.IA);
            xrLabel3.Text = encabezado;
            DateTime hoy = DateTime.Now;
            string mes = hoy.ToString("MMMM", CultureInfo.CreateSpecificCulture("es"));
            string lugaryFecha = String.Format("En la ciudad de {0} a los {1} dias del mes de {2} de {3} ", Lugar, hoy.Day, mes,hoy.Year);
            xrLugarYFecha.Text = lugaryFecha;
            if(cred.TipoBonificacionID == "X")
            {
                xrNoti.Text = String.Format(@"Me notifico que el crédito nro {0} de {1} cuotas, con promoción de {2:0} cuota/s bonificada/s del cual soy Titular," +
                                            @" se le aplicará efectivamente dicha bonificación siempre que no haya incurrido en mora en el pago de ninguna de las cuotas" +
                                            @" a lo largo de la vigencia del mismo. En caso de cancelación anticipada, la promoción quedará sin efecto."
                                            , cred.CreditoID, cred.CantidadCuotas, cred.PorcentajeBonificacion);

            }
            else if(cred.TipoBonificacionID == "C")
            {
                xrNoti.Text = String.Format(@"Me notifico que el crédito nro {0} de {1} cuotas, con promoción de pesos {2:00} bonificados en la última cuota del cual soy Titular," +
                                            @" se le aplicará efectivamente dicha bonificación siempre que no haya incurrido en mora en el pago de ninguna de las cuotas" +
                                            @" a lo largo de la vigencia del mismo. En caso de cancelación anticipada, la promoción quedará sin efecto."
                                            , cred.CreditoID, cred.CantidadCuotas, cred.ValorBonificacion);

            }
            if (esM)
            {
                xrTitulo.Text = "";
                //xrFinancia.Text = "";
                xrLabel3.Text = "";
            }
            xrlblComCredito.Text = String.Format("{0}-{1}", cred.ComercioID, cred.CreditoID);
        }

    }
}
