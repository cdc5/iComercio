using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.Advanced;
using PdfSharp.Pdf.Internal;
using PdfSharp.Pdf.AcroForms;
using PdfSharp.Pdf.IO;
using PdfSharp.Pdf.Security;
using System.Diagnostics;


namespace iComercio.Auxiliar
{
    public class PDF
    {
        static public MemoryStream CrearPDF()
        {
            /*Creacion del documento */
            PdfDocument pdfDocu = new PdfDocument();
            pdfDocu.Info.Title = "PRUEBA PARA GENERAR UN PDF";
            pdfDocu.Info.Author = "CHRISTIANCITO";
            pdfDocu.Info.Subject = "PRUEBAAAA";

            PdfPage pag = pdfDocu.AddPage();
            pag.Width = XUnit.FromMillimeter(200);
            pag.Height = XUnit.FromMillimeter(200);

            XGraphics gfx = XGraphics.FromPdfPage(pag);


            /* Dibujo */
            XColor strokeColor = XColors.DarkBlue;
            XColor fillColor = XColors.AliceBlue;
            strokeColor.A = 0.8;
            fillColor.A = 0.8;

            XSize size = gfx.PageSize;
            XGraphicsPath path = new XGraphicsPath();
            /*gfx.DrawString("Hello, World!", new XFont("Verdana",14), XBrushes.Black,
            new XRect(0, size.Height / 3.5, size.Width,0), XStringFormats.Center);*/
            path.AddString("Credin", new XFontFamily("Verdana"), XFontStyle.BoldItalic, 60,
                            new XRect(0, size.Height / 3.5, size.Width, 0), XStringFormats.Center);
            XPen pen = new XPen(strokeColor, 5);
            XBrush brush = new XSolidBrush(fillColor);

            gfx.DrawPath(new XPen(pen.Color, 3), brush, path);

            /*            PdfDocument inputDocument1 = PdfReader.Open("a", PdfDocumentOpenMode.Import);*/


            MemoryStream stream = new MemoryStream();
            pdfDocu.Save(stream, false);
            return stream;

        }

        static public MemoryStream CrearAutorizacion(string empresa, string tipoAut, string aplicacion, int numRecep, string receptoria,
                                                     long numAut, long numOP, DateTime FechaOP, DateTime FechaCaja, string codCaja,
                                                     decimal importe, string observaciones,string rutaArchivoBase)
        {
            try
            {
                PdfDocument formatoAut = PdfReader.Open(rutaArchivoBase, PdfDocumentOpenMode.Import);
                PdfDocument aut = new PdfDocument();

                /* Copiamos la página del formato */
                PdfPage pag = aut.AddPage(formatoAut.Pages[0]);

                /* Agregamos a mano los campos que queremos completar */

                XGraphics gfx = XGraphics.FromPdfPage(pag);
                XSize size = gfx.PageSize;
                XColor strokeColor = XColors.DarkBlue;
                XColor fillColor = XColors.Black;
                strokeColor.A = 0.8;
                fillColor.A = 0.8;
                XPen pen = new XPen(strokeColor, 5);
                XBrush brush = new XSolidBrush(fillColor);
                XFont fontTitulos = new XFont("Arial Narrow", 18, XFontStyle.Bold);
                XFont fontEmpresa = new XFont("Arial Narrow", 22, XFontStyle.Bold);
                XFont font = new XFont("Arial Narrow", 11);

                gfx.DrawString(empresa, fontEmpresa, brush, new XRect(98, 70, empresa.Length, 0));
                gfx.DrawString(tipoAut, fontTitulos, brush, new XRect(98, 90, tipoAut.Length, 0));
                gfx.DrawString(receptoria, fontTitulos, brush, new XRect(245, 112, receptoria.Length, 0));
                gfx.DrawString(aplicacion, fontTitulos, brush, new XRect(195, 134, tipoAut.Length, 0));
                gfx.DrawString(String.Format("{0}-{1}", numRecep, numAut.ToString("0")), font, brush, new XRect(92, 186, numAut.ToString("0,0").Length, 0));
                gfx.DrawString(numOP.ToString("0,0"), font, brush, new XRect(150, 186, numOP.ToString("0,0").Length, 0));
                gfx.DrawString(FechaOP.ToShortDateString(), font, brush, new XRect(203, 186, FechaOP.ToShortDateString().Length, 0));
                gfx.DrawString(FechaCaja.ToShortDateString(), font, brush, new XRect(268, 186, FechaCaja.ToShortDateString().Length, 0));
                gfx.DrawString(codCaja, font, brush, new XRect(330, 186, codCaja.Length, 0));
                gfx.DrawString(importe.ToString("0.00"), font, brush, new XRect(425, 186, importe.ToString("0.00").Length, 0));
                gfx.DrawString(observaciones, font, brush, new XRect(90, 235, observaciones.Length, 0));

                /*agregar a mano donde van lo pasado */
                /*  PdfString empresa = new PdfString("CREDIN");
                  formatoAut.AcroForm.Fields["Empresa"].Value = empresa;*/
                /*formatoAut.AcroForm.Elements["/NeedAppearances"] = new PdfBoolean(true);*/
                /*formatoAut.AcroForm.Fields["TituloTipoAut"] = "CREDIN";
                formatoAut.AcroForm.Fields["Receptoria"] = "Receptoria";
                formatoAut.AcroForm.Fields["TipoAut"] = "CREDIN";
                formatoAut.AcroForm.Fields["NumAut"] = "CREDIN";
                formatoAut.AcroForm.Fields["NumOP"] = "CREDIN";
                formatoAut.AcroForm.Fields["FechaOP"] = "CREDIN";
                formatoAut.AcroForm.Fields["FechaCaja"] = "CREDIN";
                formatoAut.AcroForm.Fields["CodCaja"] = "CREDIN";
                formatoAut.AcroForm.Fields["CodCaja"] = "CREDIN";
                formatoAut.AcroForm.Fields["CodCaja"] = "CREDIN";*/


                /*      formatoAut.SecuritySettings.DocumentSecurityLevel = PdfDocumentSecurityLevel.None;
                      formatoAut.SecuritySettings.PermitAccessibilityExtractContent = true;
                      formatoAut.SecuritySettings.PermitAnnotations = true;
                      formatoAut.SecuritySettings.PermitAssembleDocument = true;
                      formatoAut.SecuritySettings.PermitExtractContent = true;
                      formatoAut.SecuritySettings.PermitFormsFill = true;
                      formatoAut.SecuritySettings.PermitFullQualityPrint = true;
                      formatoAut.SecuritySettings.PermitModifyDocument = true;
                      formatoAut.SecuritySettings.PermitPrint = true;
            
                      */
                /*  MemoryStream stream = new MemoryStream();
                  formatoAut.Save(stream, false);*/
                /*formatoAut.Close();*/
                MemoryStream stream = new MemoryStream();
                aut.Save(stream, false);
                return stream;

            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
            }
            return null;
        }


        static public MemoryStream CrearAutorizacionExtBan(string empresa, string tipoAut, string aplicacion, int numRecep, string receptoria,
                                                     long numAut, long numOP, DateTime FechaOP, string cheque,
                                                     string cuentaBancaria, string impCont, decimal importe, string observaciones, 
                                                    string rutaArchivoBase)
        {
            PdfDocument formatoAut = PdfReader.Open(rutaArchivoBase, PdfDocumentOpenMode.Import);
            PdfDocument aut = new PdfDocument();

            /* Copiamos la página del formato */
            PdfPage pag = aut.AddPage(formatoAut.Pages[0]);

            /* Agregamos a mano los campos que queremos completar */

            XGraphics gfx = XGraphics.FromPdfPage(pag);
            XSize size = gfx.PageSize;
            XColor strokeColor = XColors.DarkBlue;
            XColor fillColor = XColors.Black;
            strokeColor.A = 0.8;
            fillColor.A = 0.8;
            XPen pen = new XPen(strokeColor, 5);
            XBrush brush = new XSolidBrush(fillColor);
            XFont fontTitulos = new XFont("Arial Narrow", 16, XFontStyle.Bold);
            XFont fontEmpresa = new XFont("Arial Narrow", 22, XFontStyle.Bold);
            XFont font = new XFont("Arial Narrow", 11);
            XFont fontCB = new XFont("Arial Narrow", 8);

            gfx.DrawString(empresa, fontEmpresa, brush, new XRect(80, 60, empresa.Length, 0));
            //gfx.DrawString(tipoAut, fontTitulos, brush, new XRect(98, 90, tipoAut.Length, 0));
            gfx.DrawString(receptoria, fontTitulos, brush, new XRect(240, 105, receptoria.Length, 0));
            gfx.DrawString(aplicacion, fontTitulos, brush, new XRect(190, 125, tipoAut.Length, 0));
            gfx.DrawString(String.Format("{0}-{1}", numRecep, numAut.ToString("0")), font, brush, new XRect(145, 155, numAut.ToString("0,0").Length, 0));
            gfx.DrawString(numOP.ToString("0,0"), font, brush, new XRect(145, 170, numOP.ToString("0,0").Length, 0));
            gfx.DrawString(FechaOP.ToShortDateString(), font, brush, new XRect(145, 184, FechaOP.ToShortDateString().Length, 0));
            gfx.DrawString(FechaOP.ToShortDateString(), font, brush, new XRect(145, 200, FechaOP.ToShortDateString().Length, 0));
            //gfx.DrawString(FechaCaja.ToShortDateString(), font, brush, new XRect(268, 186, FechaCaja.ToShortDateString().Length, 0));
            //gfx.DrawString(codCaja, font, brush, new XRect(330, 186, codCaja.Length, 0));
            gfx.DrawString(cheque, font, brush, new XRect(320, 155, importe.ToString("0.00").Length, 0));
            gfx.DrawString(cuentaBancaria, fontCB, brush, new XRect(320, 170, importe.ToString("0.00").Length, 0));
            gfx.DrawString(impCont, font, brush, new XRect(320, 184, importe.ToString("0.00").Length, 0));
            gfx.DrawString(importe.ToString("0.00"), font, brush, new XRect(320, 200, importe.ToString("0.00").Length, 0));
            gfx.DrawString(observaciones, font, brush, new XRect(80, 235, observaciones.Length, 0));

            MemoryStream stream = new MemoryStream();
            aut.Save(stream, false);
            return stream;

        }

    }
}
