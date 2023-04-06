using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using iComercio.Reportes;
using iComercio.Models;
using iComercio;
using DevExpress;
using DevExpress.LookAndFeel;
using DevExpress.XtraReports.UI;
using System.Windows.Forms;
using iComercio.Exceptions;

namespace iComercio.Models
{
    public class Impresion
    {

        public void ImprimirAlta(Credito cred,string Lugar,string Fecha,string Tribunales,string Impresora
                                ,Image Logo,bool EsM,string Titulo,string Financia,bool ImprimeTalonCom,
                                string ImpresoraDebito ,CuentaBancariaCliente cbc ,CuentaBancaria cb, int cantImpBoni)
        {
            Pagare1 pg = new Pagare1(cred, Lugar, Fecha, Tribunales, Logo, EsM,Titulo, Financia);
            Pagare2 pg2 = new Pagare2(cred, Logo, EsM, Titulo, Financia);
            Pagare3 pg3 = new Pagare3(cred, Logo, EsM, Titulo, Financia);
            Pagare4 pg4 = new Pagare4(cred, Logo, EsM, Titulo, Financia);
            

            using (ReportPrintTool printTool = new ReportPrintTool(pg))
            {
                printTool.Print(Impresora);
            }

            using (ReportPrintTool printTool = new ReportPrintTool(pg2))
            {
                printTool.Print(Impresora);
            }
            
            using (ReportPrintTool printTool = new ReportPrintTool(pg3))
            {
                printTool.Print(Impresora);
            }
            
            if (ImprimeTalonCom)
            {
                using (ReportPrintTool printTool = new ReportPrintTool(pg4))
                {
                    printTool.Print(Impresora);
                }
            }

            if (!String.IsNullOrEmpty(cred.NumCuentaBancaria))
            {
                AutorizacionDebito autd = new AutorizacionDebito(cred, Lugar, Fecha, Logo, EsM, cbc, cb);
                using (ReportPrintTool printTool = new ReportPrintTool(autd))
                {
                    printTool.Print(ImpresoraDebito);
                }
            }

            if (cred.TipoBonificacionID == "X" || cred.TipoBonificacionID == "C")
            {
                Bonificadas boni = new Bonificadas(cred, Lugar, Fecha, Tribunales, Logo, EsM, Titulo, Financia);
                using (ReportPrintTool printTool = new ReportPrintTool(boni))
                {
                    for (int i = 1; i <= cantImpBoni;i++ )
                        printTool.Print(Impresora);
                }
            }

            
        }


        public void ImprimirCobranza(BusinessLayer bl, Cobranza cob,bool EsM,Image Logo, string Impresora, string Titulo,string Financia,bool ImprimeTalonCom)
        {
            try
            {
                Reportes.Chequera ch = new Reportes.Chequera(bl, cob, Logo, EsM, Titulo, Financia);
                using (ReportPrintTool printTool = new ReportPrintTool(ch))
                {
                    printTool.Print(Impresora);
                }

                if (ImprimeTalonCom)
                {
                    Reportes.Chequera2 ch2 = new Reportes.Chequera2(bl, cob, Logo, EsM, Titulo, Financia);
                    using (ReportPrintTool printTool = new ReportPrintTool(ch2))
                    {
                        printTool.Print(Impresora);
                    }
                }
            }
            catch (System.Drawing.Printing.InvalidPrinterException ex)
            {
               // throw new ErrorException(ex.Message);
               MessageBox.Show(ex.Message);
            }          
            
        }

    }
}
