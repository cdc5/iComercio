using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Drawing;

namespace iComercio.Models
{
    public class EnviaAImpresora
    {
        public void EnviarAImpresora(ListView lListV, int[] lColumn, string cImpresora, string cTitulo1, string cTitulo2)
        {

            int nFila = 0;
            int nPagina = 0;
            int nLineas = 1;
            //int nTotalFilas = lColumn.GetLength(0) - 1;
            int ntotalColumn = lColumn.GetLength(0) - 1;

            Font fontList = new Font("Verdana", 8F, FontStyle.Regular);

            PrintDocument doc = new PrintDocument();

            PrinterSettings ps = new PrinterSettings();
            PrintDocument recordDoc = new PrintDocument();
            doc.PrinterSettings = ps;

            IEnumerable<PaperSize> paperSizes = ps.PaperSizes.Cast<PaperSize>();
            PaperSize sizeA4 = paperSizes.First<PaperSize>(size => size.Kind == PaperKind.A4); // setting paper size to A4 size
            doc.DefaultPageSettings.PaperSize = sizeA4;
            //doc.DefaultPageSettings.PaperSize = new PaperSize("210 x 297 mm", 800, 800);
            doc.DefaultPageSettings.Landscape = true;
            
            doc.PrinterSettings.PrinterName = cImpresora;
            PrintPreviewDialog ppd = new PrintPreviewDialog { Document = doc };
            ((Form)ppd).WindowState = FormWindowState.Maximized;

            doc.PrintPage += delegate (object ev, PrintPageEventArgs ep)
            {
                int nLeft = ep.MarginBounds.Left;
                int nTop = ep.MarginBounds.Top;

                nPagina++;
                ep.Graphics.DrawString("Página: " + nPagina.ToString(), fontList, Brushes.Black, ep.MarginBounds.Right - 50, nTop + 20);

                ep.Graphics.DrawString(cTitulo1, fontList, Brushes.Black, nLeft, nTop);
                nTop += 25;
                ep.Graphics.DrawString(cTitulo2, fontList, Brushes.Black, nLeft, nTop);
                nTop += 35;

                fontList = new Font("Courier New", 8F, FontStyle.Bold);

                for(int n = 0; n <= ntotalColumn; n++)
                {
                    ep.Graphics.DrawString(lListV.Columns[lColumn[n]].Text, fontList, Brushes.Black, nLeft, nTop);
                    nLeft += lListV.Columns[lColumn[n]].Width;
                }

                ep.Graphics.FillRectangle(Brushes.Black, ep.MarginBounds.Left, nTop + 20, nLeft - 100, 3);
                nLeft = ep.MarginBounds.Left;
                fontList = new Font("Courier New", 8F, FontStyle.Regular);
                nTop += 25;
                
                string cTexto = "";

                while(nFila < lListV.Items.Count)
                {
                    nLeft = ep.MarginBounds.Left;
                    for(int n = 0; n <= ntotalColumn; n++)
                    {
                        cTexto = lListV.Items[nFila].SubItems[lColumn[n]].Text;
                        if(lListV.Columns[lColumn[n]].Tag == "D" || lListV.Columns[lColumn[n]].Tag == "N")
                        {
                            cTexto = cTexto.PadLeft(10, ' ');
                        }
                        else
                        {
                            if(cTexto.Length > 25) cTexto = cTexto.Substring(0, 25);
                        }
                        ep.Graphics.DrawString(cTexto, fontList, Brushes.Black, nLeft, nTop);
                        nLeft += lListV.Columns[lColumn[n]].Width;
                    }
                    nFila++;
                    nLineas++;

                    if(nTop >= doc.DefaultPageSettings.Bounds.Height - 50)
                    {
                        ep.HasMorePages = true;
                        nLineas = 1;
                        break;
                    }
                    else
                    {
                        ep.HasMorePages = false;
                    }
                    nTop += 20;
                }

            };
            ppd.ShowDialog();
        }
    }
}
