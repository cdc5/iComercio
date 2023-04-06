using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using iComercio.Models;
namespace iComercio.Reportes
{
    public partial class Chequera2 : DevExpress.XtraReports.UI.XtraReport
    {
        public Chequera2()
        {
            InitializeComponent();
        }

        public Chequera2(BusinessLayer bl,Cobranza cob, Image Logo, bool EsM, string Titulo, string Financia)
        {
            InitializeComponent();
            bsCobranza.DataSource = cob;
            xrTitulo.Text = Titulo;
            xrFinancia.Text = Financia;

            string encabezado = String.Format("{1},{2},{3},{0} {4} - {5} {0} CUIT:{6} IIBB:{7} {0} Responsable Inscripto - I.A:{8}",
                                               Environment.NewLine, cob.Empresa.Domicilio, cob.Empresa.CP, cob.Empresa.Localidad, cob.Empresa.Telefonos, cob.Empresa.Mail,
                                               cob.Empresa.Cuit, cob.Empresa.IIBB, cob.Empresa.IA);
            xrLabel3.Text = encabezado;
            xrLabel14.Text = String.Format("{0}/{1}", cob.CuotaID, cob.Credito.CantidadCuotas);


            xrlblObs.Text = bl.Observaciones(cob);
            decimal dTmp = 0;     //EDU2023
            if (cob.TipoBonificacionID != null && cob.TipoBonificacionID != "N")
            {
                xrLabel17.Text = "BONIFICADO";
                xrLabel18.Text = "0";
                xrLabel19.Text = "BONIFICADO";
                if (cob.NotasCD != null)     //EDU2023
                {
                    if (cob.NotasCD[0].Importe > 0)
                    {
                        dTmp = cob.ImporteTotal - cob.NotasCD[0].Importe;
                        xrLabel19.Text = dTmp.ToString("N2");
                    }
                }
            }
            else
            {
                xrLabel17.Text = cob.ImportePago.ToString("0.00");
                xrLabel18.Text = cob.ImportePagoPunitorios.ToString("0.00");
                xrLabel19.Text = cob.ImporteTotal.ToString("0.00");
            }

            //xrPictureBox1.Image = Logo;
            if (EsM)
            {
                xrTitulo.Text = "";
                xrFinancia.Text = "";
                xrLabel3.Text = "";
             //   xrPictureBox1.Image = null;
            }
        }


    }
}
