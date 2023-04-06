using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel; 

namespace iComercio.Models
{
    public class EnviaAExcel
    {

        //lLista    1°  Fila
        //          2°  Columna
        //          3°  Formato     E Encabezado
        //                          D Decimal
        //                          T Numérico s/decimales
        //                          F Fecha
        
        //public void EnviaArExcel(string cTitulo1, string cTitulo2, string[, , ,] lLista, string cUsuario)
        //{
        //    Microsoft.Office.Interop.Excel.Application appXls = new Microsoft.Office.Interop.Excel.Application();
        //    Workbook wb = appXls.Workbooks.Add(XlSheetType.xlWorksheet);
        //    Worksheet ws = (Worksheet)appXls.ActiveSheet;

        //    appXls.Visible = false;

        //    int nTotalFilas = lLista.GetLength(0)-1;
        //    int ntotalColumn = lLista.GetLength(1) - 1;


        //    ws.Cells[1, 1] = cUsuario;
        //    ws.Cells[1, 14] = DateTime.Now.ToShortDateString();

        //    ws.Cells[2, 8] = cTitulo1;
        //    ws.Cells[2, 8].HorizontalAlignment = 3;
        //    ws.Cells[3, 8] = cTitulo2;
        //    ws.Cells[3, 8].HorizontalAlignment = 3;

        //    ws.Range["A2", "Z2"].Font.Bold = true;
        //    ws.Range["A2", "Z2"].Font.Size = 12;
        //    ws.Range["A3", "Z3"].Font.Bold = true;
        //    ws.Range["A3", "Z3"].Font.Size = 12;

        //    //string cTexto = "";
        //    //string cFormato = "";

        //    int nFila = 5;
        //    int nColumn = 2;
        //    //int nCuantoArray = 0;
        //    string cRange="";
        //    int cFila=0;
        //    //appXls.Visible = true;
        //    for (int nF = 0; nF <= nTotalFilas; nF++)
        //    {
        //        nColumn = 2;
        //        for (int nC = 0; nC <= ntotalColumn; nC++)
        //        {
        //            ws.Cells[nF + nFila, nC + nColumn] = lLista[nF, nC, 0,0];
        //            //nColumn++;
        //            if(lLista[nF, nC, 1, 0]!=null || lLista[nF, nC, 1, 0]!="")
        //            {
        //                cFila = nF + nFila;
        //                cRange = QueColumna(nC + nColumn) + cFila.ToString();
        //                if (lLista[nF, nC, 0, 0] != "")
        //                {
        //                    if (lLista[nF, nC, 1, 0] == "T")
        //                    {
        //                        ws.Cells[nF + nFila, nC + nColumn] = Convert.ToDouble(lLista[nF, nC, 0, 0]);
        //                        ws.Range[cRange,cRange].NumberFormat = "#,##0_);[Red](#,##0)";
        //                    }
        //                    if (lLista[nF, nC, 1, 0] == "D")
        //                    {
        //                        ws.Cells[nF + nFila, nC + nColumn] = Convert.ToDecimal(lLista[nF, nC, 0, 0]);
        //                        ws.Range[cRange, cRange].NumberFormat = "#,##0.00_);[Red](#,##0.00)";

        //                    }
        //                    if (lLista[nF, nC, 1, 0] == "F")
        //                    {

        //                        ws.Cells[nF + nFila, nC + nColumn] = Convert.ToDateTime(lLista[nF, nC, 0, 0]);
        //                        //ws.Range[cRange, cRange].NumberFormat = "#,##0_);[Red](#,##0)";

        //                    }
        //                    if (lLista[nF, nC, 1, 0] == "E")
        //                    {
        //                        ws.Range[cRange, cRange].Font.Bold = true;
        //                        ws.Cells[nF + nFila, nC + nColumn].HorizontalAlignment =3;
                              
        //                       //ws.Cells[nF + nFila, nC + nColumn].HorizontalAlignment = 0;
        //                     // ws.Cells[nF + nFila, nC + nColumn].HorizontalAlignment = 1;

        //                    }
        //                }

        //            }
        //            //ws.Cells[nF + nFila, nC + nColumn] = lLista[nF, nC, 0];
        //            //nColumn++;
        //            //ws.Cells[nF + nFila, nC + nColumn] = lLista[nF, nC, 0];
        //            //nColumn++;
        //            //ws.Cells[nF + nFila, nC + nColumn] = lLista[nF, nC, 0];
        //            //nColumn++;
        //        }
                
                

        //        //cTexto = lLista[n, 0,0];
        //        //cFormato = lLista[n, 0,0];
        //        //if(n==0)
        //        //{

        //        //}
        //    }
        //    appXls.Visible = true;

        //}

        public void EnviaArExcel(string cTitulo1, string cTitulo2, string[, , ,] lLista, string cUsuario) //eduardo camb
        {


            Microsoft.Office.Interop.Excel.Application appXls = new Microsoft.Office.Interop.Excel.Application();
            Workbook wb = appXls.Workbooks.Add(XlSheetType.xlWorksheet);
            Worksheet ws = (Worksheet)appXls.ActiveSheet;
            ws.PageSetup.Orientation = XlPageOrientation.xlLandscape;
            //ws.PageSetup.FitToPagesWide = true;
            //ws.PageSetup.Zoom = false;
            //ws.PageSetup.FitToPagesTall = 1;
            //ws.PageSetup.FitToPagesWide =1;
            appXls.Visible = false;

            int nTotalFilas = lLista.GetLength(0) - 1;
            int ntotalColumn = lLista.GetLength(1) - 1;


            ws.Cells[1, 1] = cUsuario;
            ws.Cells[1, 14] = DateTime.Now.ToShortDateString();

            ws.Cells[2, 8] = cTitulo1;
            ws.Cells[2, 8].HorizontalAlignment = 3;
            ws.Cells[3, 8] = cTitulo2;
            ws.Cells[3, 8].HorizontalAlignment = 3;

            ws.Range["A2", "Z2"].Font.Bold = true;
            ws.Range["A2", "Z2"].Font.Size = 12;
            ws.Range["A3", "Z3"].Font.Bold = true;
            ws.Range["A3", "Z3"].Font.Size = 12;

            //string cTexto = "";
            //string cFormato = "";

            int nFila = 5;
            int nColumn = 2;
            //int nCuantoArray = 0;
            string cRange = "";
            int cFila = 0;
            string cQueDato = "";
            //appXls.Visible = true;
            for (int nF = 0; nF <= nTotalFilas; nF++)
            {
                nColumn = 2;
                for (int nC = 0; nC <= ntotalColumn; nC++)
                {
                    cQueDato = "";
                     try
                    {                   
                        ws.Cells[nF + nFila, nC + nColumn] = lLista[nF, nC, 0, 0];
                        cQueDato = lLista[nF, nC, 0, 0];
                    //nColumn++;

                        if (lLista[nF, nC, 1, 0] != null || lLista[nF, nC, 1, 0] != "")
                        {

                            cFila = nF + nFila;
                            cRange = QueColumna(nC + nColumn) + cFila.ToString();
                            if (lLista[nF, nC, 0, 0] != "")
                            {
                                if (lLista[nF, nC, 1, 0] == "T")
                                {
                                    ws.Cells[nF + nFila, nC + nColumn] = lLista[nF, nC, 0, 0];// Convert.ToDouble(lLista[nF, nC, 0, 0]);
                                    ws.Range[cRange, cRange].NumberFormat = "#,##0_);[Red](#,##0)";
                                }
                                if (lLista[nF, nC, 1, 0] == "D")
                                {
                                    ws.Cells[nF + nFila, nC + nColumn] = Convert.ToDecimal(lLista[nF, nC, 0, 0]);
                                    ws.Range[cRange, cRange].NumberFormat = "#,##0.00_);[Red](#,##0.00)";

                                }
                                if (lLista[nF, nC, 1, 0] == "F")
                                {

                                    ws.Cells[nF + nFila, nC + nColumn] = Convert.ToDateTime(lLista[nF, nC, 0, 0]);

                                }
                                if (lLista[nF, nC, 1, 0] == "E")
                                {
                                    ws.Range[cRange, cRange].Font.Bold = true;
                                    ws.Cells[nF + nFila, nC + nColumn].HorizontalAlignment = 3;

                                }
                            }
                        }
                    }
                    catch { }
                }
            }
            appXls.Visible = true;

        }
        private string QueColumna(int nCol)
        {
            string cCol = "";
            switch (nCol)
            {
                case 1:
                    cCol = "A";
                    break;
                case 2:
                    cCol= "B";
                    break;
                case 3:
                    cCol= "C";
                    break;
                case 4:
                    cCol= "D";
                    break;
                case 5:
                    cCol= "E";
                    break;
                case 6:
                    cCol= "F";
                    break;
                case 7:
                    cCol= "G";
                    break;
                case 8:
                    cCol= "H";
                    break;
                case 9:
                    cCol= "I";
                    break;
                case 10:
                    cCol= "J";
                    break;
                case 11:
                    cCol= "K";
                    break;
                case 12:
                    cCol= "L";
                    break;
                case 13:
                    cCol= "M";
                    break;
                case 14:
                    cCol= "N";
                    break;
                case 15:
                    cCol= "O";
                    break;
                case 16:
                    cCol= "P";
                    break;
                case 17:
                    cCol= "Q";
                    break;
                case 18:
                    cCol= "R";
                    break;
                case 19:
                    cCol= "S";
                    break;
                case 20:
                    cCol= "T";
                    break;
                case 21:
                    cCol= "U";
                    break;
                case 22:
                    cCol= "V";
                    break;
                case 23:
                    cCol= "W";
                    break;
                case 24:
                    cCol= "X";
                    break;
                case 25:
                    cCol= "Y";
                    break;
                case 26:
                    cCol= "Z";
                    break;


            }

            return cCol;
        }
    }
}
