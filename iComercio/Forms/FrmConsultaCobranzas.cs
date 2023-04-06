using System;                         ////convert, eventarg, eventhandler
using System.Collections.Generic;         //list<>
using System.Drawing;                  ///font , color
using System.Linq;                      // orderby()
using System.Windows.Forms;               //formWindowsState, listview, musearg, etc
using iComercio.Rest;                       //RestApi
using iComercio.Models;                     // modelos(cred, cuot, etc)

using iComercio.DAL;

//using Microsoft.Office.Interop.Excel;                     
//<MorosoEnCamara>

namespace iComercio.Forms                           //CAMBIAR NOMBRE DEL FORM POR FrmListadoCobranza
{
    public partial class FrmConsultaCobranzas : FRM
    {

        string QueHago = "";
        Color backColorList = Color.White;
        Color fontColor = Color.Empty;
        int nRecibos;
        decimal dRecibos;
        System.Drawing.Font fontList = new System.Drawing.Font("Verdana", 9F, FontStyle.Regular);
        //System.Drawing.Font 
        //Font fontList = new Font("Verdana", 8F, FontStyle.Regular);
        Recibo regReci;
        public FrmConsultaCobranzas()
        {
            InitializeComponent();
        }

        private void FrmConsultaCobranzas_Load(object sender, EventArgs e)
        {
            lblMor.Visible = false;
            RecargarEmpYComercio(lblMor.Visible);
            cmbBusca.Focus();
            cmbBusca.Select();
            //fitFormToScreen();
        }
        public FrmConsultaCobranzas(Principal p, string queHace)
            : base(p)
        {
            InitializeComponent();
            QueHago = queHace;
            Configura_Inicio();
            RecargarEmpYComercio(false);
        }
        private void BuscaRecibo(Cobranza cob)
        {

            regReci = bl.Get<Recibo>(BaseID, r => r.CreditoID == cob.CreditoID && r.CuotaID == cob.CuotaID && r.CobranzaID == cob.CobranzaID
                                    && (r.TipoMovimientoID == bl.pGlob.TmCobPorDebito.TipoMovimientoID || r.TipoMovimientoID == bl.pGlob.TmAnuCobPorDebito.TipoMovimientoID)).FirstOrDefault();
            if(regReci != null)
            {
                if(regReci.EstadoID != 98)
                {
                    nRecibos++;
                    dRecibos = dRecibos + regReci.Importe;
                }
            }
        }
        private void Manda_Impresora()
        {
            int[] lCol = new int[12];
            string cTit1 = this.Text;
            string cTit2 = "";
            string cImpresora = "";
            if(cmbBusca.SelectedIndex == 0)
            {
                lCol = new int[11];
                lCol[0] = 6;
                lCol[1] = 7;
                lCol[2] = 8;
                lCol[3] = 9;
                lCol[4] = 10;
                lCol[5] = 11;
                lCol[6] = 12;
                lCol[7] = 13;
                lCol[8] = 14;
                lCol[9] = 15;
                //lCol[10] = 16;
                lCol[10] = 17;
                cTit2 = "Desde " + txtDesde.Value.ToShortDateString() + " Hasta " + txtHasta.Value.ToShortDateString();
                cImpresora = bl.GetImpresora("LISTADO COBRANZAS");
            }


            if(cImpresora == "")
            {
                MessageBox.Show("No está configurada la impresora");
                return;
            }
            //lCol[4] = 5;  "Microsoft XPS Document Writer"   "Microsoft Print to PDF"
            EnviaAImpresora ei = new EnviaAImpresora();
            ei.EnviarAImpresora(listBusca, lCol, cImpresora, cTit1, cTit2);
        }
        private void Busca_Morosos2() //eduardo cambio
        {
            listBusca.Items.Clear();
            listBusca.Visible = false;
            lblAguarde.Text = "AGUARDE  ";
            lblAguarde.Visible = true;
            panel1.Enabled = false;
            List<Cuota> regListCuota;
            fontList = new System.Drawing.Font("Verdana", 8F, FontStyle.Regular);
            fontColor = Color.Empty;
            backColorList = Color.LightSteelBlue;
            lblMsg.Text = "Buscando datos";
            DateTime fD = Convert.ToDateTime(1 + "/" + txtDesde.Value.Month + "/" + txtDesde.Value.Year);
            DateTime fUtimo = Convert.ToDateTime(1 + "/" + txtHasta.Value.Month + "/" + txtHasta.Value.Year);
            fUtimo=fUtimo.AddMonths(1);
            DateTime fH = fD;
            fH = fH.AddMonths(1);
            fH = fH.AddDays(-1);
            listBusca.Columns.Add("", 120, HorizontalAlignment.Right);  //
            int nMeses = CalcularMesesDeDiferencia(fD, fUtimo);
            //                                  ENCABEZADOS
            DateTime fNva = fH;
            DateTime fNvaFin;
            for (int n = 1; n <= nMeses; n++)
            {
                AguardeFrm(lblAguarde);
                listBusca.Columns.Add(fNva.Month.ToString() + "/" + fNva.Year.ToString(), 120, HorizontalAlignment.Right);  //
                listBusca.Columns.Add("%", 80, HorizontalAlignment.Right);  //
                
                fNva=fNva.AddMonths(1);
            }
            Agrega_linea("TN", false, (nMeses * 2) + 8);
            Agrega_linea("TN", false, (nMeses * 2) + 8);
            Agrega_linea("TN", false, (nMeses * 2) + 8);
            Agrega_linea("TN", false, (nMeses * 2) + 8);
            Agrega_linea("TN", false, (nMeses * 2) + 8);
            listBusca.Items[0].SubItems[6].Text = "Total";
            listBusca.Items[1].SubItems[6].Text = "Cobrado";
            listBusca.Items[2].SubItems[6].Text = "Morosidad";
            listBusca.Items[3].SubItems[6].Text = "Int. tot.";
            listBusca.Items[4].SubItems[6].Text = "Int. Cobr.";

            listBusca.Items[0].SubItems[6].Font = new System.Drawing.Font("Verdana", 9F, FontStyle.Bold);
            listBusca.Items[1].SubItems[6].Font = new System.Drawing.Font("Verdana", 9F, FontStyle.Bold);
            listBusca.Items[2].SubItems[6].Font = new System.Drawing.Font("Verdana", 9F, FontStyle.Bold);
            listBusca.Items[3].SubItems[6].Font = new System.Drawing.Font("Verdana", 9F, FontStyle.Bold);
            listBusca.Items[4].SubItems[6].Font = new System.Drawing.Font("Verdana", 9F, FontStyle.Bold);

            decimal nTotal = 0;
            decimal nCobrado = 0;
            decimal nInt = 0;
            decimal nIntCobr = 0;
            decimal nTmp = 0;
            decimal nTmp2 = 0;
            fNva = fH;
            for (int n = 1; n <= nMeses * 2; n++)
            {
                AguardeFrm(lblAguarde);
                nTotal = 0;
                nCobrado = 0;
                nTmp = 0;
                nTmp2 = 0;
                nInt = 0;
                nIntCobr = 0;
                fNva = Convert.ToDateTime(1 + "/" + fNva.Month + "/" + fNva.Year);
                fNvaFin = fNva;
                fNvaFin = fNvaFin.AddMonths(1);
                //fNvaFin = fNvaFin.AddDays(-1);
                //regListCuota = bl.GetCuotas(c =>  c.EmpresaID == bl.pGlob.Comercio.EmpresaID &&
                //                            c.ComercioID == bl.pGlob.Comercio.ComercioID &&
                //                            c.FechaVencimiento >= fNva && c.FechaVencimiento < fNvaFin, or => or.OrderBy(o => o.FechaVencimiento)).ToList();
                regListCuota = bl.GetCuotas(BaseID, c => c.EmpresaID == BaseID &&
                                           c.ComercioID == ComID &&
                                           c.FechaVencimiento >= fNva && c.FechaVencimiento < fNvaFin
                                           , or => or.OrderBy(o => o.FechaVencimiento)).ToList();

                if(regListCuota.Count > 0)
                {
                    foreach (Cuota cuo in regListCuota)
                    {
                        nTotal = nTotal + cuo.Importe;
                        nCobrado = nCobrado + cuo.ImportePago;
                        nInt = nInt + cuo.Interes;
                    }
                }
                if(nTotal > 0) nIntCobr = (nCobrado * nInt / nTotal); else nIntCobr = 0;
                listBusca.Items[0].SubItems[n + 6].Text = nTotal.ToString("N2");
                listBusca.Items[1].SubItems[n + 6].Text = nCobrado.ToString("N2");
                nTmp = nTotal - nCobrado;
                listBusca.Items[2].SubItems[n + 6].Text = nTmp.ToString("N2");
                listBusca.Items[2].SubItems[n + 6].Font  = new System.Drawing.Font("Verdana", 8F, FontStyle.Bold);
                listBusca.Items[3].SubItems[n + 6].Text = nInt.ToString("N2");
                listBusca.Items[4].SubItems[n + 6].Text = nIntCobr.ToString("N2");
                n++;
                if (nTotal > 0)
                {
                    nTmp = nCobrado * 100 / nTotal;
                    nTmp2 = 100 - nTmp;
                }
                listBusca.Items[1].SubItems[n + 6].Text = nTmp.ToString("N2");
                listBusca.Items[2].SubItems[n + 6].Text = nTmp2.ToString("N2");
                fNva = fNva.AddMonths(1);
            }
            Agrega_linea("TN", false, (nMeses * 2) + 8);
            listBusca.GridLines = true;
            lblAguarde.Visible = false;
            listBusca.Visible = true;
            BtnBusca.Text = "Otro";
        }

        public int CalcularMesesDeDiferencia(DateTime fechaDesde, DateTime fechaHasta) //eduardo cambio
        {
            return Math.Abs((fechaDesde.Month - fechaHasta.Month) + 12 * (fechaDesde.Year - fechaHasta.Year));
        }

        private void Manda_Excel_01()
        {

            int nC = listBusca.Columns.Count;//columnas
            int nF = listBusca.Items.Count;//filas

            int nCant = 0;
            int nn1 = 0;
            string[, ,,] ConsuCred = new string[nF, nC, 2,2];
            //ENCABEZADOS
            if (cmbBusca.SelectedIndex == 3)
            {
                for (int n = 6; n <= nC - 1; n++)
                {
                    ConsuCred[nCant, nn1, 0, 0] = listBusca.Columns[n].Text;
                    ConsuCred[nCant, nn1, 1, 0] = "E";
                    nn1++;
                }
            }
            else
            {
                ConsuCred[nCant, 0, 0, 0] = listBusca.Columns[6].Text;
                ConsuCred[nCant, 0, 1, 0] = "E";
                ConsuCred[nCant, 1, 0, 0] = listBusca.Columns[7].Text;
                ConsuCred[nCant, 1, 1, 0] = "E";
                ConsuCred[nCant, 2, 0, 0] = listBusca.Columns[8].Text;
                ConsuCred[nCant, 2, 1, 0] = "E";
                ConsuCred[nCant, 3, 0, 0] = listBusca.Columns[9].Text;
                ConsuCred[nCant, 3, 1, 0] = "E";
                ConsuCred[nCant, 4, 0, 0] = listBusca.Columns[10].Text;
                ConsuCred[nCant, 4, 1, 0] = "E";
                ConsuCred[nCant, 5, 0, 0] = listBusca.Columns[11].Text;
                ConsuCred[nCant, 5, 1, 0] = "E";
                ConsuCred[nCant, 6, 0, 0] = listBusca.Columns[12].Text;
                ConsuCred[nCant, 6, 1, 0] = "E";
                ConsuCred[nCant, 7, 0, 0] = listBusca.Columns[13].Text;
                ConsuCred[nCant, 7, 1, 0] = "E";
                ConsuCred[nCant, 8, 0, 0] = listBusca.Columns[14].Text;
                ConsuCred[nCant, 8, 1, 0] = "E";
                ConsuCred[nCant, 9, 0, 0] = listBusca.Columns[15].Text;
                ConsuCred[nCant, 9, 1, 0] = "E";
                ConsuCred[nCant, 10, 0, 0] = listBusca.Columns[16].Text;
                ConsuCred[nCant, 10, 1, 0] = "E";
                ConsuCred[nCant, 11, 0, 0] = listBusca.Columns[17].Text;
                ConsuCred[nCant, 11, 1, 0] = "E";
                ConsuCred[nCant, 12, 0, 0] = listBusca.Columns[18].Text;
                ConsuCred[nCant, 12, 1, 0] = "E";
                ConsuCred[nCant, 13, 0, 0] = listBusca.Columns[19].Text;
                ConsuCred[nCant, 13, 1, 0] = "E";
                ConsuCred[nCant, 14, 0, 0] = listBusca.Columns[20].Text;
                ConsuCred[nCant, 14, 1, 0] = "E";
            }
                
            if (cmbBusca.SelectedIndex == 1 || cmbBusca.SelectedIndex == 2)
            {
                ConsuCred[nCant, 15, 0, 0] = listBusca.Columns[21].Text;
                ConsuCred[nCant, 15, 1, 0] = "E";
                ConsuCred[nCant, 16, 0, 0] = listBusca.Columns[22].Text;
                ConsuCred[nCant, 16, 1, 0] = "E";
            }
            foreach (ListViewItem item in listBusca.Items)
            {

                nCant++;
                if (nCant >= nF) break;
                if (cmbBusca.SelectedIndex == 0)
                {
                    ConsuCred[nCant, 0, 0, 0] = item.SubItems[6].Text;
                    ConsuCred[nCant, 1, 0, 0] = item.SubItems[7].Text;
                    ConsuCred[nCant, 2, 0, 0] = item.SubItems[8].Text;
                    ConsuCred[nCant, 2, 1, 0] = "N";
                    ConsuCred[nCant, 3, 0, 0] = item.SubItems[9].Text;
                    ConsuCred[nCant, 4, 0, 0] = item.SubItems[10].Text;
                    ConsuCred[nCant, 5, 0, 0] = item.SubItems[11].Text;
                    ConsuCred[nCant, 5, 1, 0] = "D";
                    ConsuCred[nCant, 6, 0, 0] = item.SubItems[12].Text;
                    ConsuCred[nCant, 6, 1, 0] = "D";
                    ConsuCred[nCant, 7, 0, 0] = item.SubItems[13].Text;
                    ConsuCred[nCant, 7, 1, 0] = "D";
                    ConsuCred[nCant, 8, 0, 0] = item.SubItems[14].Text;
                    ConsuCred[nCant, 8, 1, 0] = "F";
                    ConsuCred[nCant, 9, 0, 0] = item.SubItems[15].Text;
                    ConsuCred[nCant, 9, 1, 0] = "F";
                    ConsuCred[nCant, 10, 0, 0] = item.SubItems[16].Text;
                    ConsuCred[nCant, 11, 0, 0] = item.SubItems[17].Text;
                    ConsuCred[nCant, 12, 0, 0] = item.SubItems[18].Text;
                    ConsuCred[nCant, 12, 1, 0] = "T";
                    ConsuCred[nCant, 13, 0, 0] = item.SubItems[19].Text;
                    ConsuCred[nCant, 13, 1, 0] = "D";
                    ConsuCred[nCant, 14, 0, 0] = item.SubItems[20].Text;
                }
                if (cmbBusca.SelectedIndex == 1 || cmbBusca.SelectedIndex == 2)
                {
                    ConsuCred[nCant, 0, 0, 0] = item.SubItems[6].Text;
                    ConsuCred[nCant, 0, 1, 0] = "N";
                    ConsuCred[nCant, 1, 0, 0] = item.SubItems[7].Text;
                    ConsuCred[nCant, 1, 1, 0] = "N";
                    ConsuCred[nCant, 2, 0, 0] = item.SubItems[8].Text;
                    ConsuCred[nCant, 3, 0, 0] = "'" + item.SubItems[9].Text;
                    ConsuCred[nCant, 3, 1, 0] = "T";
                    ConsuCred[nCant, 4, 0, 0] = item.SubItems[10].Text;
                    ConsuCred[nCant, 5, 0, 0] = item.SubItems[11].Text;
                    ConsuCred[nCant, 6, 0, 0] = item.SubItems[12].Text;
                    ConsuCred[nCant, 7, 0, 0] = item.SubItems[13].Text;
                    ConsuCred[nCant, 8, 0, 0] = item.SubItems[14].Text;
                    ConsuCred[nCant, 9, 0, 0] = item.SubItems[15].Text;
                    //ConsuCred[nCant, 9, 1, 0] = "D";
                    ConsuCred[nCant, 10, 0, 0] = item.SubItems[16].Text;
                    ConsuCred[nCant, 10, 1, 0] = "D";
                    ConsuCred[nCant, 11, 0, 0] = item.SubItems[17].Text;
                    ConsuCred[nCant, 11, 1, 0] = "D";
                    ConsuCred[nCant, 12, 0, 0] = item.SubItems[18].Text;
                    ConsuCred[nCant, 12, 1, 0] = "D";
                    ConsuCred[nCant, 13, 0, 0] = item.SubItems[19].Text;
                    ConsuCred[nCant, 13, 1, 0] = "D";
                    ConsuCred[nCant, 14, 0, 0] = item.SubItems[20].Text;
                    ConsuCred[nCant, 14, 1, 0] = "F";


                    ConsuCred[nCant, 15, 0, 0] = item.SubItems[21].Text;
                    ConsuCred[nCant, 15, 1, 0] = "";
                    ConsuCred[nCant, 16, 0, 0] = item.SubItems[22].Text;
                    ConsuCred[nCant, 16, 1, 0] = "F";
                }
                if (cmbBusca.SelectedIndex == 3)
                {
                    nn1 = 0;
                    
                    ConsuCred[nCant, nn1, 0, 0] = item.SubItems[6].Text;
                    ConsuCred[nCant, nn1, 1, 0] = "";
                    nn1++;
                    for (int n = 7; n <= nC - 1; n++)
                    {
                        ConsuCred[nCant, nn1, 0, 0] = item.SubItems[n].Text;
                        ConsuCred[nCant, nn1, 1, 0] = "D";
                        nn1++;
                    }

                }
                
            }

            //int nTotalFilas = listBusca.Items.Count;
            //nTotalFilas = ConsuCred.GetLength(0);
            //int nCuantoArray =0;
            ////string aa = ConsuCred[55, 0, 0];
            //string ndoc="";
            //string ncred = "";
            //string nCon = "";
            //string aaaa = "";
            //for (int n = 0; n <= nTotalFilas; n++)
            //{
            //    nCon = ConsuCred[n, 0, 0, 0];
            //    ncred = ConsuCred[n, 1, 0, 0];
            //    ndoc = ConsuCred[n, 2, 0, 0];
            //    ndoc = ConsuCred[n, 1, 1, 0];
            //}


            string cTitulo2 = "Desde " + txtDesde.Value.ToShortDateString() + " Hasta " + txtHasta.Value.ToShortDateString();

            EnviaAExcel ea = new EnviaAExcel();
            ea.EnviaArExcel("Consulta de cobranzas " + cmbBusca.Text, cTitulo2, ConsuCred, p.usu.apellido);

            
            
                
                //Microsoft.Office.Interop.Excel.Application appXls = new Microsoft.Office.Interop.Excel.Application();
            //Workbook wb = appXls.Workbooks.Add(XlSheetType.xlWorksheet);
            //Worksheet ws = (Worksheet)appXls.ActiveSheet;



            //appXls.Visible = false;
            //ws.Cells[1, 1] = p.usu.apellido;
            //ws.Cells[1, 16] = DateTime.Now.ToShortDateString();
            //// = System.Environment.MachineName;
            //if (cmbBusca.SelectedIndex == 0)
            //{
            //    ws.Cells[2, 5] = "Consultas de cobranzas";
            //}
            //else if (cmbBusca.SelectedIndex == 1)
            //{
            //    ws.Cells[2, 5] = "Consultas de morosos";
            //}
            //else if (cmbBusca.SelectedIndex == 2)
            //{
            //    ws.Cells[2, 5] = "Consultas de morosos 1° cuota";
            //}
            //ws.Cells[3, 5] = "del " + txtDesde.Text + " al " + txtHasta.Text;

            //int i = 5;
            //int cc = 2;
            ////ws.Cells[i, cc] = listBusca.Items[2].SubItems[0].Text;
            ////cc++;

            //ws.Cells[i, cc] = "Comercio";
            //cc++;
            //ws.Cells[i, cc] = "Crédito";
            //cc++;
            //ws.Cells[i, cc] = "Documento";
            //cc++;
            //ws.Cells[i, cc] = "Cliente";
            //cc++;
            //ws.Cells[i, cc] = "Cuota";
            //cc++;
            //ws.Cells[i, cc] = "Importe";
            //cc++;
            //ws.Cells[i, cc] = "Punitório";
            //cc++;
            //ws.Cells[i, cc] = "Total";
            //cc++;
            //ws.Cells[i, cc] = "Fecha";
            //cc++;
            //ws.Cells[i, cc] = "Vencimiento";
            //cc++;
            //ws.Cells[i, cc] = "Usuario";
            //cc++;
            //ws.Cells[i, cc] = "T/pago";
            //cc++;
            //ws.Cells[i, cc] = "Puni/calc";
            //cc++;
            //ws.Cells[i, cc] = "Hora";
            //cc++;
            //ws.Cells[i, cc] = "PC";

            //ws.Range["A5" ,"Z5"].Font.Bold = true;
            
            //ws.Range["D1", "D1000"].NumberFormat = "#,##0_);[Red](#,##0)";

            //ws.Range["G1", "G1000"].NumberFormat = "#,##0.00_);[Red](#,##0.00)";
            //ws.Range["H1", "H1000"].NumberFormat = "#,##0.00_);[Red](#,##0.00)";
            //ws.Range["H1", "H1000"].NumberFormat = "#,##0.00_);[Red](#,##0.00)";
            //ws.Range["N1", "N1000"].NumberFormat = "#,##0.00_);[Red](#,##0.00)";

            //i++;

            //foreach (ListViewItem item in listBusca.Items)
            //{

            //    cc = 2;
            //    ws.Cells[i, cc] = item.SubItems[6].Text;
            //    cc++;
            //    ws.Cells[i, cc] = item.SubItems[7].Text;
            //    cc++;
            //    if (item.SubItems[8].Text != "") { ws.Cells[i, cc] = Convert.ToDouble(item.SubItems[8].Text); }
            //    cc++;
            //    ws.Cells[i, cc] = item.SubItems[9].Text;
            //    cc++;
            //    ws.Cells[i, cc] = item.SubItems[10].Text;
            //    cc++;
            //    if (item.SubItems[11].Text != "") { ws.Cells[i, cc] = Convert.ToDecimal(item.SubItems[11].Text); }
            //    cc++;
            //    if (item.SubItems[12].Text != "") { ws.Cells[i, cc] = Convert.ToDecimal(item.SubItems[12].Text); }
            //    cc++;
            //    if (item.SubItems[13].Text != "") { ws.Cells[i, cc] = Convert.ToDecimal(item.SubItems[13].Text); }
            //    cc++;
            //    if (item.SubItems[14].Text != "") ws.Cells[i, cc] = Convert.ToDateTime(item.SubItems[14].Text);
            //    cc++;
            //    if (item.SubItems[15].Text != "") ws.Cells[i, cc] = Convert.ToDateTime(item.SubItems[15].Text);
            //    cc++;
            //    ws.Cells[i, cc] = item.SubItems[16].Text;
            //    cc++;
            //    ws.Cells[i, cc] = item.SubItems[17].Text;
            //    cc++;
            //    if (item.SubItems[18].Text != "") { ws.Cells[i, cc] = Convert.ToDecimal(item.SubItems[18].Text); }
            //    cc++;
            //    ws.Cells[i, cc] = item.SubItems[19].Text;
            //    cc++;
            //    ws.Cells[i, cc] = item.SubItems[20].Text;

            //    i++;
            //}
            //appXls.Visible = true;

        }

        private void Busca_Morosos()
        {
            listBusca.Items.Clear();
            listBusca.Visible = false;
            lblAguarde.Text = "AGUARDE  ";
            lblAguarde.Visible = true;
            panel1.Enabled = false;
            DateTime fD = Convert.ToDateTime(txtDesde.Value.ToShortDateString());
            DateTime fH = Convert.ToDateTime(txtHasta.Value.ToShortDateString());
            ListViewItem item;
            List<Cuota> regListCuota;
            bool bPasa = false;
            string cTmp = "";
            int nDoc=0;
            string cDoc="";
            decimal nTmp=0;
            int nCant = 0;
            decimal nImporte = 0;
            decimal nPunitorio = 0;
            string cTel1 = "";
            string cTel2 = "";
            int nDomi = 0;
            fH = fH.AddDays(1);
            fontList = new System.Drawing.Font("Verdana", 8F, FontStyle.Regular);
            fontColor = Color.Empty;
            backColorList = Color.LightSteelBlue;
            lblMsg.Text = "Buscando datos";
            Localidad regLocalidad = null;
            //regListCuota = bl.GetCuotas(c => (c.Importe - c.ImportePago) > 0  && c.EmpresaID == bl.pGlob.Comercio.EmpresaID && 
            //            c.ComercioID == bl.pGlob.Comercio.ComercioID &&
            //            c.FechaVencimiento >= fD && c.FechaVencimiento < fH, or => or.OrderBy(o => o.FechaVencimiento)).ToList();
            regListCuota = bl.GetCuotas(BaseID, c => (c.Importe - c.ImportePago) > 0 && c.EmpresaID == BaseID &&
                       c.ComercioID == ComID &&
                       c.FechaVencimiento >= fD && c.FechaVencimiento < fH, or => or.OrderBy(o => o.FechaVencimiento)).ToList();

            if(regListCuota.Count == 0)
            {
                lblMsg.Text = "No se encontraron cobranzas";
                listBusca.Visible = true;
                lblAguarde.Visible = false;
                panel1.Enabled = true; ;
                return;
            }
            listBusca.Visible = false;
            
            foreach (Cuota cuo in regListCuota)
            {
                AguardeFrm(lblAguarde);
                bPasa = false;
                if (cmbBusca.SelectedIndex == 1)
                {
                    bPasa = true;
                }
                else if (cmbBusca.SelectedIndex == 2)
                {
                    nTmp=0;
                    foreach(Cuota cc in cuo.Credito.Cuotas)
                    {
                        if (cc.CuotaID != cuo.CuotaID) if (cc.CuotaID < cuo.CuotaID) nTmp = nTmp + cc.Deuda;
                    }
                    if (nTmp == 0) bPasa = true;
                }
                if (bPasa)
                {
                    nCant++;
                    item = new ListViewItem(cuo.CuotaID.ToString());
                    item.UseItemStyleForSubItems = false;
                    item.SubItems.Add(cuo.EmpresaID.ToString(), fontColor, backColorList, fontList);
                    item.SubItems.Add(cuo.ComercioID.ToString(), fontColor, backColorList, fontList);
                    item.SubItems.Add(cuo.CreditoID.ToString(), fontColor, backColorList, fontList);
                    item.SubItems.Add(cuo.Documento.ToString(), fontColor, backColorList, fontList);
                    item.SubItems.Add(cuo.TipoDocumentoID, fontColor, backColorList, fontList);
                    nDoc = cuo.Documento;
                    cDoc = cuo.TipoDocumentoID;
                    item.SubItems.Add(cuo.CreditoID.ToString("N0"), fontColor, backColorList, fontList);
                    if (cuo.Cliente != null) //     if(Cli!=null)
                    {
                        item.SubItems.Add(cuo.Documento.ToString(), fontColor, backColorList, fontList);
                        item.SubItems.Add(cuo.Cliente.NombreCompleto, fontColor, backColorList, fontList);
                        cTmp = cuo.CuotaID.ToString() + "/" + cuo.CantidadCuotas.ToString();
                        item.SubItems.Add(cTmp, fontColor, backColorList, fontList);                     //8
                        cTel1 = "";
                        cTel2 = "";
                        if (cuo.Cliente.Telefonos.Count > 0)  //if (tele.Count > 0)
                        {
                            foreach (Telefono tel in cuo.Cliente.Telefonos)
                            {
                                if (tel.EstadoID == bl.pGlob.Vigente.EstadoID && tel.ClaseDatoID == bl.pGlob.DatoCliente.ClaseDatoID)
                                {
                                    if (cTel1 == "") cTel1 = tel.TelefonoCompleto; else cTel2 = tel.TelefonoCompleto;
                                }
                            }                        
                        }
                        item.SubItems.Add(cTel1, fontColor, backColorList, fontList);
                        item.SubItems.Add(cTel2, fontColor, backColorList, fontList);

                        nDomi = 0;
                        if (cuo.Cliente.Domicilios.Count > 0)   //if (domi != null) 
                        {
                            foreach (Domicilio dom in cuo.Cliente.Domicilios)
                            {
                                if (dom.EstadoID == bl.pGlob.Vigente.EstadoID && dom.ClaseDatoID == bl.pGlob.DatoCliente.ClaseDatoID)
                                {
                                    regLocalidad = bl.GetLocalidades(BaseID, l => l.LocalidadID == dom.LocalidadID).FirstOrDefault();
                                    nDomi++;
                                    item.SubItems.Add(dom.DomicilioCompleto, fontColor, backColorList, fontList); //11
                                    if (regLocalidad != null)
                                    {
                                        item.SubItems.Add(regLocalidad.Nombre, fontColor, backColorList, fontList);
                                        item.SubItems.Add(regLocalidad.Provincia.Nombre, fontColor, backColorList, fontList);
                                        item.SubItems.Add(regLocalidad.CodPostal, fontColor, backColorList, fontList);

                                    }
                                    else
                                    {
                                        item.SubItems.Add("", fontColor, backColorList, fontList);
                                        item.SubItems.Add("", fontColor, backColorList, fontList);
                                        item.SubItems.Add("", fontColor, backColorList, fontList);
                                    }
                                    break;
                                }
                            }
                            if(nDomi==0)
                            {
                                item.SubItems.Add("", fontColor, backColorList, fontList);
                                item.SubItems.Add("", fontColor, backColorList, fontList);//14
                                item.SubItems.Add("", fontColor, backColorList, fontList);
                                item.SubItems.Add("", fontColor, backColorList, fontList);//14
                            }
                        }
                        else
                        {
                            item.SubItems.Add("", fontColor, backColorList, fontList);
                            item.SubItems.Add("", fontColor, backColorList, fontList);
                            item.SubItems.Add("", fontColor, backColorList, fontList);
                            item.SubItems.Add("", fontColor, backColorList, fontList);//14
                        }

                        bool esRefi = cuo.Credito.RefinanciacionID != null;

                        item.SubItems.Add(cuo.Importe.ToString("N2"), fontColor, backColorList, fontList); //15
                        item.SubItems.Add(cuo.Deuda.ToString("N2"), fontColor, backColorList, fontList); //16
                        nImporte = nImporte + cuo.Deuda;
                        nTmp = Calcula_Punitorio(cuo.Deuda, cuo.FechaVencimiento, bl.pGlob.Comercio.Por30.Value, bl.pGlob.Comercio.Por30M.Value, esRefi);
                        item.SubItems.Add(nTmp.ToString("N2"), fontColor, backColorList, fontList);//17
                        nPunitorio = nPunitorio + nTmp;
                        nTmp = nTmp + cuo.Deuda;
                        item.SubItems.Add(nTmp.ToString("N2"), fontColor, backColorList, fontList);//18
                        item.SubItems.Add(cuo.FechaVencimiento.ToShortDateString(), fontColor, backColorList, fontList);//19
                        if (cuo.FechaUltimoPago != null) item.SubItems.Add(cuo.FechaUltimoPago.ToString(), fontColor, backColorList, fontList);//20
                        else { item.SubItems.Add("", fontColor, backColorList, fontList); }
                        item.SubItems.Add(cuo.Credito.FechaSolicitud.ToShortDateString(), fontColor, backColorList, fontList);
                        nTmp = bl.Calcula_dias_mora(cuo.FechaVencimiento, DateTime.Now);
                        item.SubItems.Add(nTmp.ToString("N0"), fontColor, backColorList, fontList);
                    }
                    else
                    {

                    }
                    listBusca.Items.Add(item);
                    if (backColorList == Color.White) backColorList = Color.LightSteelBlue; else backColorList = Color.White;
                }
            }
            Agrega_linea("a", false, listBusca.Columns.Count - 1);
            lblMsg.Text = nCant.ToString("N0") + " cobranzas por " + nImporte.ToString("N2");
            listBusca.Visible = true;
            lblAguarde.Visible = false;
            panel1.Enabled = false;
            BtnBusca.Text = "Otro";

        }
        private void Busca_Cobranzas()
        {
            int nCant = 0;
            decimal nImporte = 0;
            decimal nPunitorio = 0;
            decimal nTotal = 0;
            decimal nCantSuc = 0;
            decimal nImporteSuc = 0;
            decimal nPunitorioSuc = 0;
            decimal nTotalSuc = 0;
            decimal nTmp = 0;
            nRecibos = 0;
            dRecibos = 0;
            listBusca.Visible = false;
            lblAguarde.Text = "AGUARDE  ";
            lblAguarde.Visible = true;
            panel1.Enabled = false;
            listBusca.Items.Clear();
            lblMsg.Text = "Buscando datos";
            List<Cobranza> regCobranzaList;
            List<NotasCD> regListNotasCD;
            DateTime fD = Convert.ToDateTime(txtDesde.Value.ToShortDateString());
            DateTime fH=Convert.ToDateTime(txtHasta.Value.ToShortDateString());
            Int32 nCobrEncon = 0;
            fH = fH.AddDays(1);
            fontList = new System.Drawing.Font("Verdana", 8F, FontStyle.Regular);
            fontColor = Color.Empty;
            backColorList = Color.LightSteelBlue;
            ListViewItem item;
            //regCobranzaList = bl.GetCobranzas(c => c.FechaPago >= fD && c.FechaPago < fH && c.GestionEmpresaID == bl.pGlob.Comercio.EmpresaID && c.GestionID == bl.pGlob.Comercio.ComercioID, or => or.OrderBy(o => o.FechaPago)).ToList();
            regCobranzaList = bl.GetCobranzas(BaseID, c => c.FechaPago >= fD && c.FechaPago < fH && c.GestionEmpresaID == BaseID
                    && c.GestionID == ComID, or => or.OrderBy(o => o.FechaPago)).ToList();
            if(regCobranzaList.Count == 0)
            {
                lblMsg.Text = "No se encontraron cobranzas";
                listBusca.Visible =true ;
                lblAguarde.Visible = false;
                panel1.Enabled = true; ;
                return;
            }
            foreach (Cobranza cobr in regCobranzaList)
            {
                AguardeFrm(lblAguarde);
                BuscaRecibo(cobr);
                nCobrEncon++;
                item = new ListViewItem(cobr.CobranzaID.ToString());
                item.UseItemStyleForSubItems = false;
                item.SubItems.Add(cobr.EmpresaID.ToString(), fontColor, backColorList, fontList);
                item.SubItems.Add(cobr.ComercioID.ToString(), fontColor, backColorList, fontList);
                item.SubItems.Add(cobr.CreditoID.ToString(), fontColor, backColorList, fontList);
                item.SubItems.Add(cobr.Documento.ToString(), fontColor, backColorList, fontList);
                item.SubItems.Add(cobr.TipoDocumentoID, fontColor, backColorList, fontList);
                item.SubItems.Add(cobr.ComercioID.ToString(), fontColor, backColorList, fontList);
                item.SubItems.Add(cobr.CreditoID.ToString("N0"), fontColor, backColorList, fontList);
                item.SubItems.Add(cobr.Documento.ToString("N0"), fontColor, backColorList, fontList);
                item.SubItems.Add(cobr.Cliente.NombreCompleto, fontColor, backColorList, fontList);
                item.SubItems.Add(cobr.CuotaID.ToString(), fontColor, backColorList, fontList);
                item.SubItems.Add(cobr.ImportePago.ToString("N2"), fontColor, backColorList, fontList);
                item.SubItems.Add(cobr.ImportePagoPunitorios.ToString("N2"), fontColor, backColorList, fontList);
                item.SubItems.Add(cobr.ImporteTotal.ToString("N2"), fontColor, backColorList, fontList);
                item.SubItems.Add(cobr.FechaPago.ToShortDateString(), fontColor, backColorList, fontList);
                item.SubItems.Add(cobr.FechaVencimiento.ToShortDateString(), fontColor, backColorList, fontList);
                item.SubItems.Add(bl.TipoCobranza(cobr), fontColor, backColorList, fontList);
                if (cobr.Usuario != null)
                {
                    item.SubItems.Add(cobr.Usuario.nombre, fontColor, backColorList, fontList);
                }
                else { item.SubItems.Add("", fontColor, backColorList, fontList); }
                if (cobr.TipoPago != null) { item.SubItems.Add(cobr.TipoPago.Nombre, fontColor, backColorList, fontList); }
                else { item.SubItems.Add("", fontColor, backColorList, fontList); }
                item.SubItems.Add(cobr.PunitoriosCalc.Value.ToString("N2"), fontColor, backColorList, fontList);
                item.SubItems.Add(cobr.FechaPago.ToShortTimeString(), fontColor, backColorList, fontList);
                item.SubItems.Add(cobr.PcComer, fontColor, backColorList, fontList);
                if(cobr.ComercioID == ComID)  // bl.pGlob.Comercio.ComercioID)
                {
                    nCant++;
                    nImporte = nImporte + cobr.ImportePago;
                    nPunitorio = nPunitorio + cobr.ImportePagoPunitorios;
                    nTotal = nTotal + cobr.ImporteTotal;
                }
                else
                {
                    nCantSuc++;
                    nImporteSuc = nImporteSuc + cobr.ImportePago;
                    nPunitorioSuc = nPunitorioSuc + cobr.ImportePagoPunitorios;
                    nTotalSuc = nTotalSuc + cobr.ImporteTotal;
                }
                listBusca.Items.Add(item);
                if (backColorList == Color.White) backColorList = Color.LightSteelBlue; else backColorList = Color.White;
            }
            listBusca.Visible = true;
            backColorList = Color.White;
            for (int it = 1; it < 2; it++)
            {
                Agrega_linea(it.ToString(),false,21);

            }
            Agrega_linea("T", true, 22);
            lblMsg.Text = "";
            listBusca.Items[listBusca.Items.Count -1].SubItems[9].Text = "Totales";
            nTmp = nCant + nCantSuc;
            listBusca.Items[listBusca.Items.Count - 1].SubItems[10].Text = nTmp.ToString("N0");
            lblMsg.Text = nTmp.ToString("N0") + " cobranzas ";
            nTmp = nImporte + nImporteSuc;
            listBusca.Items[listBusca.Items.Count - 1].SubItems[11].Text = nTmp.ToString("N2");
            nTmp = nPunitorio + nPunitorioSuc;
            listBusca.Items[listBusca.Items.Count - 1].SubItems[12].Text = nTmp.ToString("N2");
            nTmp = nTotal + nTotalSuc;
            listBusca.Items[listBusca.Items.Count - 1].SubItems[13].Text = nTmp.ToString("N2");
            lblMsg.Text = lblMsg.Text + "por pesos: " + nTmp.ToString("N2");

            Agrega_linea("T1", false, 22);
            Agrega_linea("T2", false, 22);
            listBusca.Items[listBusca.Items.Count - 1].SubItems[9].Text = "Cobranzas sucursales";
            listBusca.Items[listBusca.Items.Count - 1].SubItems[10].Text = nCantSuc.ToString("N0");
            listBusca.Items[listBusca.Items.Count - 1].SubItems[11].Text = nImporteSuc.ToString("N2");
            listBusca.Items[listBusca.Items.Count - 1].SubItems[12].Text = nPunitorioSuc.ToString("N2");
            listBusca.Items[listBusca.Items.Count - 1].SubItems[13].Text = nTotalSuc.ToString("N2");
            Agrega_linea("T3", false, 22);
            listBusca.Items[listBusca.Items.Count - 1].SubItems[9].Text = "Cobranzas";
            listBusca.Items[listBusca.Items.Count - 1].SubItems[10].Text = nCant.ToString("N0");
            listBusca.Items[listBusca.Items.Count - 1].SubItems[11].Text = nImporte.ToString("N2");
            listBusca.Items[listBusca.Items.Count - 1].SubItems[12].Text = nPunitorio.ToString("N2");
            listBusca.Items[listBusca.Items.Count - 1].SubItems[13].Text = nTotal.ToString("N2");
            Agrega_linea("T4", false, 22);
            listBusca.Items[listBusca.Items.Count - 1].SubItems[9].Text = "Pago tarjeta";
            listBusca.Items[listBusca.Items.Count - 1].SubItems[10].Text = nRecibos.ToString("N0");
            listBusca.Items[listBusca.Items.Count - 1].SubItems[13].Text = dRecibos.ToString("N2");
            Agrega_linea("T4", false, 22);
            listBusca.Items[listBusca.Items.Count - 1].SubItems[9].Text = "Efectivo";
            //listBusca.Items[listBusca.Items.Count - 1].SubItems[10].Text = nRecibos.ToString("N0");
            nTmp = nTmp - dRecibos;
            listBusca.Items[listBusca.Items.Count - 1].SubItems[13].Text = nTmp.ToString("N2");
            Agrega_linea("T4", false, 22);
            //regListNotasCD = bl.GetNotasCD(n => n.Fecha >= fD && n.Fecha < fH && n.EmpresaID == bl.pGlob.Comercio.EmpresaID && n.GestionID == bl.pGlob.Comercio.ComercioID).ToList();
            regListNotasCD = bl.GetNotasCD(BaseID, n => n.Fecha >= fD && n.Fecha < fH && n.EmpresaID == BaseID 
                                && n.GestionID == ComID).ToList();

            if (regListNotasCD.Count>0)
            {
                decimal nNotas = 0;
                foreach(NotasCD not in regListNotasCD)
                {
                    Agrega_linea(not.NotaCDID.ToString(), false, 22);
                    item = new ListViewItem(not.NotaCDID.ToString());
                    listBusca.Items[listBusca.Items.Count - 1].SubItems[9].Text = "Nota de " + not.TipoNota;
                    listBusca.Items[listBusca.Items.Count - 1].SubItems[10].Text = "Cred.: "; // +not.CreditoID.ToString();
                    listBusca.Items[listBusca.Items.Count - 1].SubItems[11].Text = not.CreditoID.ToString();
                    listBusca.Items[listBusca.Items.Count - 1].SubItems[12].Text = not.ComercioID.ToString(); // not.Fecha.ToShortDateString();
                    if(not.TipoNota=="CREDITO") nTmp = not.Importe * -1; else nTmp = not.Importe;
                    nNotas = nNotas + nTmp;
                    listBusca.Items[listBusca.Items.Count - 1].SubItems[13].Text = nTmp.ToString("N2");
                }
                Agrega_linea("TN", true, 22);
                listBusca.Items[listBusca.Items.Count - 1].SubItems[9].Text = "Total notas";
                listBusca.Items[listBusca.Items.Count - 1].SubItems[13].Text=nNotas.ToString("N2");
                ////////////////////////////////////////////////////////////////////////////////////////

                nTotal = nTotal + nNotas;
                if (nNotas != 0)
                {
                    nTmp = nNotas * -1;
                    lblMsg.Text = lblMsg.Text + "  -  Notas de crédito por " + nTmp.ToString("N2") + "  -  TOTAL " + nTotal.ToString("N2");
                }

                Agrega_linea("TN", false, 22);
                Agrega_linea("T3", true, 22);
                listBusca.Items[listBusca.Items.Count - 1].SubItems[9].Text = "TOTAL";

                listBusca.Items[listBusca.Items.Count - 1].SubItems[13].Text = nTotal.ToString("N2");
                Agrega_linea("T4", false, 22);


                ////////////////////////////////////////////////////////////////////////////////////////

            }
            Agrega_linea("a", false, listBusca.Columns.Count - 1);
            lblAguarde.Visible = false;
            listBusca.Visible = true;
            BtnBusca.Text = "Otro";
        }
        private void Agrega_linea(string cc, bool negrita, int CantCol)
        {

            if (negrita) fontList = new System.Drawing.Font("Verdana", 8F, FontStyle.Bold);
            else
            {
                fontList = new System.Drawing.Font("Verdana", 8F, FontStyle.Regular);

            }
            ListViewItem item = new ListViewItem(cc);
            for (int i = 1; i < CantCol; i++)
            {
                item.SubItems.Add("", fontColor, backColorList, fontList);
            }
            listBusca.Items.Add(item);
        }
        private void Buscar_Todo() //eduardo cambio
        {
            Configura_Listas();
            lblMsg.Text = "";
            if (cmbBusca.SelectedIndex== 0)
            {
                Busca_Cobranzas();
            }
            else if (cmbBusca.SelectedIndex ==1)
            {
                Busca_Morosos();
            }
            else if (cmbBusca.SelectedIndex == 2)
            {
                Busca_Morosos();
            }
            else if (cmbBusca.SelectedIndex == 3)
            {
                Busca_Morosos2();
            }
            if (listBusca.Items.Count > 0) btnExportar.Enabled = true;
            lblFlechaD.Visible = true;
            lblFlechaI.Visible = true; 
        }
        private void Configura_Inicio()
        {
            cmbBusca.Items.Add("Fecha de pago");
            cmbBusca.Items.Add("Morosos");
            cmbBusca.Items.Add("Morosos 1° Cuota");
            cmbBusca.Items.Add("Morosidad");
            cmbBusca.SelectedIndex = 0;
            txtDesde.Value = DateTime.Now;
            txtHasta.Value=DateTime.Now;

            Configura_Controles();
            Configura_Listas();

            lblFlechaD.Visible = false;
            lblFlechaI.Visible = false;
            //switch(QueHago)
            //{
            //    case "Cobranzas"
            //}
            Centrar_Control(this, lblAguarde);
        }
        private void Configura_Listas() //eduardo cambio
        {
            listBusca.Visible = false;
            listBusca.Columns.Clear();
            listBusca.View = View.Details;
            listBusca.Columns.Add("", 0, HorizontalAlignment.Right);  //0 para el orden
            listBusca.Columns.Add("", 0, HorizontalAlignment.Right);  //1 empre
            listBusca.Columns.Add("", 0, HorizontalAlignment.Right);  //2 comer
            listBusca.Columns.Add("", 0, HorizontalAlignment.Right);  //3 cred
            listBusca.Columns.Add("", 0, HorizontalAlignment.Right);  //4 docu
            listBusca.Columns.Add("", 0, HorizontalAlignment.Right);  //5 cod
            //listBusca.Sorting = SortOrder.Ascending;
            //listBusca.Sort();
               
            if (cmbBusca.SelectedIndex== 0)
            {
                listBusca.Columns.Add("Comer", 70, HorizontalAlignment.Right);  //6
                listBusca.Columns.Add("Crédito", 80, HorizontalAlignment.Right);  //7
                listBusca.Columns.Add("Documento", 80, HorizontalAlignment.Right);  //8
                listBusca.Columns.Add("Cliente", 200, HorizontalAlignment.Left);  //9
                listBusca.Columns.Add("Cuota", 50, HorizontalAlignment.Right);  //10
                listBusca.Columns.Add("Importe", 90, HorizontalAlignment.Right);  //11
                listBusca.Columns.Add("Punitório", 90, HorizontalAlignment.Right);  //12
                listBusca.Columns.Add("Total", 95, HorizontalAlignment.Right);  //13
                listBusca.Columns.Add("Fecha", 80, HorizontalAlignment.Right);  //14
                listBusca.Columns.Add("Vencimiento", 80, HorizontalAlignment.Right);  //15
                listBusca.Columns.Add("Tipo Pago", 90, HorizontalAlignment.Left);  //16
                listBusca.Columns.Add("Usuario", 75, HorizontalAlignment.Left);  //17
                listBusca.Columns.Add("Tipo pago", 100, HorizontalAlignment.Left);  //18
                listBusca.Columns.Add("Puni calc", 75, HorizontalAlignment.Right);  //19
                listBusca.Columns.Add("Hora", 50, HorizontalAlignment.Right);  //20
                listBusca.Columns.Add("PC", 90, HorizontalAlignment.Left);  //21
                listBusca.Columns[6].Tag = "N";
                listBusca.Columns[7].Tag = "N";
                listBusca.Columns[8].Tag = "N";

                listBusca.Columns[11].Tag = "D";
                listBusca.Columns[12].Tag = "D";
                listBusca.Columns[13].Tag = "D";
                listBusca.Columns[19].Tag = "D";
            }
            else if (cmbBusca.SelectedIndex == 1 || cmbBusca.SelectedIndex == 2)
            {
                listBusca.Columns.Add("Crédito", 80, HorizontalAlignment.Right);  //7
                listBusca.Columns.Add("Documento", 100, HorizontalAlignment.Left);  //6
                listBusca.Columns.Add("Cliente", 200, HorizontalAlignment.Left);  //6
                listBusca.Columns.Add("Cuota", 50, HorizontalAlignment.Right);  //8
                listBusca.Columns.Add("Télefono", 100, HorizontalAlignment.Right);  //9
                listBusca.Columns.Add("Télefono", 100, HorizontalAlignment.Right);  //10
                listBusca.Columns.Add("Domicilio", 100, HorizontalAlignment.Left);  //11
                listBusca.Columns.Add("Localidad", 100, HorizontalAlignment.Left);  //12
                listBusca.Columns.Add("Provincia", 100, HorizontalAlignment.Left);  //13
                listBusca.Columns.Add("Cod P.", 50, HorizontalAlignment.Left);  //14
                listBusca.Columns.Add("V. cuota", 70, HorizontalAlignment.Right);  //15
                listBusca.Columns.Add("Deuda", 70, HorizontalAlignment.Right);  //16
                listBusca.Columns.Add("Punitorio", 70, HorizontalAlignment.Right);  //17
                listBusca.Columns.Add("Total", 70, HorizontalAlignment.Right);  //18
                listBusca.Columns.Add("Vencimiento", 80, HorizontalAlignment.Left);  //19
                listBusca.Columns.Add("Ult. pago", 80, HorizontalAlignment.Right);  //20
                listBusca.Columns.Add("F. solicitud", 80, HorizontalAlignment.Right);  //21
                listBusca.Columns.Add("Mora", 50, HorizontalAlignment.Right);  //22
            
            }


            listBusca.OwnerDraw = true;
            listBusca.GridLines = false;
            listBusca.FullRowSelect = true;
            listBusca.Visible = true;
        }
        private void Configura_Controles()
        {
            txtDesde.KeyPress += new KeyPressEventHandler(Txt_PasaConEnter_KeyPress);
            txtDesde.KeyPress += new KeyPressEventHandler(Txt_PasaConEnter_KeyPress);
            cmbBusca.KeyPress += new KeyPressEventHandler(Txt_PasaConEnter_KeyPress);
            listBusca.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(lista_Dibuja_Encabezado);
            listBusca.DrawSubItem += lista_DrawSubItem;
            this.BackColor = ColorBackColorFrm;
            Recorre_Formulario(this);
            
        }

        private void BtnBusca_Click(object sender, EventArgs e)
        {
            if (BtnBusca.Text == "Buscar")
            {
                BtnBusca.Enabled = false;
                Buscar_Todo();
                BtnBusca.Enabled = true;
            }
            else
            {
                lblFlechaD.Visible = false;
                lblFlechaI.Visible = false;
                btnExportar.Enabled = false;
                panel1.Enabled=true;
                listBusca.Items.Clear();
                lblMsg.Text = "";
                BtnBusca.Text = "Buscar";
            }
        }

        private void listBusca_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBusca.SelectedItems[0].SubItems[2].Text == "") return;
            int xx = 0;
            if (cmbBusca.SelectedIndex == 0) xx = 189;
            if (cmbBusca.SelectedIndex == 1) xx = 86;
            if (cmbBusca.SelectedIndex == 2) xx = 86;

            if (e.X < xx)  //listCliente.Columns[6].Width)
            {
                int ncredito = Convert.ToInt32(listBusca.SelectedItems[0].SubItems[3].Text);
                int ncomer = Convert.ToInt16(listBusca.SelectedItems[0].SubItems[2].Text);
                frmCobranzaNva frmACob = new frmCobranzaNva(p, this.bl, ncomer, ncredito, lblMor.Visible);
                frmACob.MdiParent = Principal.ActiveForm;
                frmACob.WindowState = FormWindowState.Maximized;
                frmACob.Show();
            }
            else
            {
                int nndocu = Convert.ToInt32(listBusca.SelectedItems[0].SubItems[4].Text);
                string ccdocu = (listBusca.SelectedItems[0].SubItems[5].Text);
                FrmBuscaCliDocumento frmADocu = new FrmBuscaCliDocumento(p, this.bl, nndocu, ccdocu);
                frmADocu.MdiParent = Principal.ActiveForm;
                frmADocu.WindowState = FormWindowState.Maximized;
                frmADocu.Show();
            }
        }

        private void listBusca_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem aa in listBusca.SelectedItems)
            {
                lblFlechaI.Top = aa.Position.Y + listBusca.Top;
                lblFlechaD.Top = lblFlechaI.Top;
                //this.Text = aa.Index.ToString() +"/"+ listBusca.Items.Count.ToString();
            }
        }


        private void btnExportar_Click(object sender, EventArgs e)
        {
            if(listBusca.Items.Count == 0) return;
            frmExportar frmexp; // = new frmExportar(p, false, "", true, true);
            if(cmbBusca.SelectedIndex == 0)
            {
                frmexp = new frmExportar(p, this.BackColor, true, true, true);
            }
            else
            {
                frmexp = new frmExportar(p, this.BackColor, true, true, false);
            }
            frmexp.ShowDialog();
            frmexp.Close();
            if(p.qExporto == "") return;

            if(p.qExporto == "PL")
            {
                Manda_Excel_01();
            }
            else if(p.qExporto == "PI")
            {
                Manda_Impresora();
            }
            else if(p.qExporto == "PP")
            {
                Mando_A_Portapapeles(listBusca, 6);
            }
            
        }

        private void cmbBusca_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtHasta.CustomFormat = null;
            txtDesde.CustomFormat = null; // "dd/mm/yyyyy";
            if (cmbBusca.SelectedIndex==3)
            {
                txtDesde.CustomFormat = "MMM/yyyyy";
                txtHasta.CustomFormat = "MMM/yyyyy";

            }
            txtDesde.Refresh();
            txtHasta.Refresh();
        }

        private void FrmConsultaCobranzas_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F9)
            {
                if(e.Shift)
                {
                    if(BtnBusca.Text != "Buscar") return;
                    if(bl.LlevaM())
                    {
                        lblMor.Visible = !lblMor.Visible;
                        RecargarEmpYComercio(lblMor.Visible);
                    }
                }
            }
        }
    }
}
