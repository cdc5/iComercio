using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iComercio.Models;
using iComercio.Auxiliar;
using DevExpress.XtraGrid.Views.Grid;
using Credin;
using iComercio.Rest;
using iComercio.Rest.RestModels;

using iComercio.Delegados;
using iComercio.ViewModels;


namespace iComercio.Forms
{
    public partial class FrmCtaCteComercio : FRM
    {

        Color backColorList = Color.White;
        Color fontColor = Color.Empty;
        Font fontList = new Font("Verdana", 8F, FontStyle.Regular);

        decimal nTot = 0;
        decimal nFavorComer = 0;
        decimal nFavorFinan = 0;
        decimal TmpDeci;

        public FrmCtaCteComercio()
        {
            InitializeComponent();
        }

        private void FrmCtaCteComercio_Load(object sender, EventArgs e)
        {
            RecargarEmpYComercio(false);
            InicializarControles();
        }
        public FrmCtaCteComercio(Principal p, RestApi ra)
            : base(p)
        {
            bl = new BusinessLayer(ra);
            InitializeComponent();
        }
        private void BuscarAgrupa()
        {

        }

        private void Agrega_linea(string cc, bool negrita, int CantCol)
        {

            if (negrita) fontList = new Font("Verdana", 8F, FontStyle.Bold);
            else
            {
                fontList = new Font("Verdana", 8F, FontStyle.Regular);

            }
            ListViewItem item = new ListViewItem(cc);
            for (int i = 1; i < CantCol; i++)
            {
                item.SubItems.Add("", fontColor, backColorList, fontList);
            }
            listBusca.Items.Add(item);
        }
        private void CargaLista(int nTipcc, string cTipcc, string cFecha)
        {
            if (nFavorComer + nFavorFinan == 0) return;
            ListViewItem item;
            item = new ListViewItem(nTipcc.ToString());
            item.UseItemStyleForSubItems = false;
            item.SubItems.Add(cTipcc, fontColor, backColorList, fontList);               // 1
            item.SubItems.Add(cFecha, fontColor, backColorList, fontList);             //2
            item.SubItems.Add("", fontColor, backColorList, fontList);           //3
            item.SubItems.Add("", fontColor, backColorList, fontList);           //4
            item.SubItems.Add("", fontColor, backColorList, fontList);           //5
            item.SubItems.Add("", fontColor, backColorList, fontList);           //6
            if (nFavorComer != 0)
            {
                item.SubItems.Add(nFavorComer.ToString("N2"), fontColor, backColorList, fontList);                  //7
            }
            else
            {
                item.SubItems.Add("", fontColor, backColorList, fontList);                                            //7
            }
            if (nFavorFinan != 0)
            {
                item.SubItems.Add(nFavorFinan.ToString("N2"), fontColor, backColorList, fontList);                    //8
            }
            else
            {
                item.SubItems.Add("", fontColor, backColorList, fontList);                                          //8
            }
            nTot = nTot - nFavorFinan;
            nTot = nTot + nFavorComer;
            if (nTot < 0) fontColor = Color.Red;
            item.SubItems.Add(nTot.ToString("N2"), fontColor, backColorList, fontList);                          //9
            listBusca.Items.Add(item);
            //if (backColorList == Color.White) backColorList = Color.LightSteelBlue; else backColorList = Color.White;//8
            fontColor = Color.Empty;
        }
        private void CargaImporte(CuentaCorriente lcc)
        {
            TmpDeci = lcc.Importe;
            if (lcc.TipoMovimientoID == 822 || lcc.TipoMovimientoID == 823)
            {
                if (lcc.TipoMovimiento.ClaseMovimientoID == 1)
                {
                    nFavorFinan = nFavorFinan + (TmpDeci + (TmpDeci * 21 / 100));
                }
                else
                {
                    nFavorComer = nFavorComer + (TmpDeci + (TmpDeci * 21 / 100));
                }
            }
            else
            {
                if (lcc.TipoMovimiento.ClaseMovimientoID == 1)
                {
                    nFavorFinan = nFavorFinan + TmpDeci;
                }
                else
                {
                    nFavorComer = nFavorComer + TmpDeci;
                }
            }

        }
        private void InicializarControles()
        {
            Configura_Colores(bl.pGlob.Comercio.EmpresaID);
            Recorre_Formulario(this);
            this.Text = "Cuenta corriente";
            grpMovimientos.Visible = false;
            Centrar_Control(this, grpMovimientos);
            Asigna_Poder_Mover(grpMovimientos);
            Asigna_Cambiar_Tamaño(grpMovimientos);
            Configura_listas();
            dtpDesde.Value = DateTime.Now.Date.AddDays(-7);
            listBusca.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(lista_Dibuja_Encabezado);
            listBusca.DrawSubItem += lista_DrawSubItem;
            btnImpre.Enabled = false;
            lblMensa.Text = "";
            chkAgrupa.Checked = true;
        }
        public void Configura_listas()
        {

            listBusca.View = View.Details;
            listBusca.Columns.Add("", 0, HorizontalAlignment.Right);  // 0
            listBusca.Columns.Add("Movimiento", 300, HorizontalAlignment.Left);  // 1
            listBusca.Columns.Add("Fecha", 80, HorizontalAlignment.Center);      //2
            listBusca.Columns.Add("Nro", 80, HorizontalAlignment.Right);      //3
            listBusca.Columns.Add("Cuota", 80, HorizontalAlignment.Right);      //4
            listBusca.Columns.Add("Importe", 80, HorizontalAlignment.Right);      //5
            listBusca.Columns.Add("", 80, HorizontalAlignment.Right);      //6
            listBusca.Columns.Add("A favor comercio", 80, HorizontalAlignment.Right);      //7
            listBusca.Columns.Add("A favor financiera", 80, HorizontalAlignment.Right);      //8
            listBusca.Columns.Add("ARRASTRE", 100, HorizontalAlignment.Right);      //9

            listBusca.OwnerDraw = true;
            listBusca.GridLines = false;

            gridMov.AutoGenerateColumns = false;
            gridMov.Columns.Clear();

            gridMov.ColumnCount = 16;
            gridMov.Columns[0].Name = "Com";
            gridMov.Columns[1].Name = "Fecha aviso";
            gridMov.Columns[2].Name = "Importe";
            gridMov.Columns[3].Name = "Crédito";
            gridMov.Columns[4].Name = "Cuota";
            gridMov.Columns[5].Name = "Nro. cobranza";
            gridMov.Columns[6].Name = "Fecha de carga";
            gridMov.Columns[7].Name = "Solicitud de fondo";
            gridMov.Columns[8].Name = "Orden de pago";
            gridMov.Columns[9].Name = "Nro. transferencia";
            gridMov.Columns[10].Name = "Nro. recibo";
            gridMov.Columns[11].Name = "Nro. gasto";
            gridMov.Columns[12].Name = "";
            gridMov.Columns[13].Name = "";
            gridMov.Columns[14].Name = "Nro pago";
            gridMov.Columns[15].Name = "Notas";


            gridMov.Columns[0].DataPropertyName = "ComercioID";
            gridMov.Columns[1].DataPropertyName = "FechaAviso";
            gridMov.Columns[2].DataPropertyName = "Importe";
            gridMov.Columns[3].DataPropertyName = "CreditoNro"; //edunvo 202110
            gridMov.Columns[4].DataPropertyName = "CuotaID";
            gridMov.Columns[5].DataPropertyName = "CobranzaID";
            gridMov.Columns[6].DataPropertyName = "Fecha";
            gridMov.Columns[7].DataPropertyName = "SolicitudFondoID";
            gridMov.Columns[8].DataPropertyName = "ordpag_id";
            gridMov.Columns[9].DataPropertyName = "TransferenciaID";
            gridMov.Columns[10].DataPropertyName = "ReciboID";
            gridMov.Columns[11].DataPropertyName = "GastoID";
            gridMov.Columns[12].DataPropertyName = "TipoMovimientoID";
            gridMov.Columns[13].DataPropertyName = "icc_id";
            gridMov.Columns[14].DataPropertyName = "PagoID";
            gridMov.Columns[15].DataPropertyName = "icc_notas";

            gridMov.Columns[1].DefaultCellStyle.Format = "dd/MM/yyyy"; //edunvo 202110
            gridMov.Columns[2].DefaultCellStyle.Format = "N2";
            gridMov.Columns[3].DefaultCellStyle.Format = "N0";
            gridMov.Columns[5].DefaultCellStyle.Format = "N0";
            gridMov.Columns[6].DefaultCellStyle.Format = "dd/MM/yyyy"; //edunvo 202110

            gridMov.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridMov.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; //edunvo 202110
            gridMov.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridMov.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridMov.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridMov.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridMov.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; //edunvo 202110
            gridMov.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridMov.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridMov.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridMov.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridMov.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridMov.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            gridMov.Columns[0].Width = 50;
            gridMov.Columns[1].Width = 90;
            gridMov.Columns[2].Width = 80;
            gridMov.Columns[3].Width = 80;
            gridMov.Columns[4].Width = 50;
            gridMov.Columns[5].Width = 70;
            gridMov.Columns[6].Width = 90;
            gridMov.Columns[7].Width = 80;
            gridMov.Columns[8].Width = 80;
            gridMov.Columns[9].Width = 80;
            gridMov.Columns[10].Width = 80;
            gridMov.Columns[11].Width = 80;
            gridMov.Columns[12].Visible = false;
            gridMov.Columns[13].Visible = false;
            gridMov.Columns[15].Width = 150;
            gridMov.Font = new Font("Verdana", 7F, FontStyle.Regular);

            gridMov.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSlateGray;
            gridMov.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //for(int n = 0; n < gridMov.Columns.Count; n++)
            //{
            //    gridMov.Columns[n].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //    gridMov.Columns[n].HeaderCell.Style.Font = new Font("Verdana", 7F, FontStyle.Bold);
            //}
            gridMov.EnableHeadersVisualStyles = false;
            gridMov.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSlateGray;

            gridCobrCred.EnableHeadersVisualStyles = false;
            gridCobrCred.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSlateGray;

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (btnBuscar.Text == "Buscar")
            {
                if (chkAgrupa.Checked)
                {
                    Buscar(true);
                }
                else
                {
                    Buscar(false);
                }

            }
            else
            {
                listBusca.Items.Clear();
                lblMensa.Text = "";
                btnBuscar.Text = "Buscar";
                grpFecha.Enabled = true;
                btnImpre.Enabled = false;
            }
        }
        private void Manda_excel()
        {
            int nC = listBusca.Columns.Count;   //Cantidad columnas
            int nF = listBusca.Items.Count;     //Cantidad filas

            int nCant = 0;

            string[,,,] ConsuCred = new string[nF, nC, 2, 2];   // array de datos

            // carga datos de encabezados de columnas
            ConsuCred[nCant, 0, 0, 0] = listBusca.Columns[1].Text;
            ConsuCred[nCant, 0, 1, 0] = "E";                          // "E" ES PARA LOS ENCABEZADOS
            ConsuCred[nCant, 1, 0, 0] = listBusca.Columns[2].Text;
            ConsuCred[nCant, 1, 1, 0] = "E";
            ConsuCred[nCant, 2, 0, 0] = listBusca.Columns[3].Text;
            ConsuCred[nCant, 2, 1, 0] = "E";
            ConsuCred[nCant, 3, 0, 0] = listBusca.Columns[4].Text;
            ConsuCred[nCant, 3, 1, 0] = "E";
            ConsuCred[nCant, 4, 0, 0] = listBusca.Columns[5].Text;
            ConsuCred[nCant, 4, 1, 0] = "E";
            ConsuCred[nCant, 5, 0, 0] = listBusca.Columns[6].Text;
            ConsuCred[nCant, 5, 1, 0] = "E";
            ConsuCred[nCant, 6, 0, 0] = listBusca.Columns[7].Text;
            ConsuCred[nCant, 6, 1, 0] = "E";
            ConsuCred[nCant, 7, 0, 0] = listBusca.Columns[8].Text;
            ConsuCred[nCant, 7, 1, 0] = "E";
            ConsuCred[nCant, 8, 0, 0] = listBusca.Columns[9].Text;
            ConsuCred[nCant, 8, 1, 0] = "E";

            // carga los datos restantes
            foreach (ListViewItem item in listBusca.Items)
            {
                nCant++;
                if (nCant >= nF) break;
                ConsuCred[nCant, 0, 0, 0] = item.SubItems[1].Text;
                ConsuCred[nCant, 0, 1, 0] = "";
                ConsuCred[nCant, 1, 0, 0] = item.SubItems[2].Text;
                ConsuCred[nCant, 1, 1, 0] = "F";                         // "F" fecha
                ConsuCred[nCant, 2, 0, 0] = item.SubItems[3].Text;
                ConsuCred[nCant, 2, 1, 0] = "T";                            //"T" nro sin decimales
                ConsuCred[nCant, 3, 0, 0] = item.SubItems[4].Text;
                ConsuCred[nCant, 3, 1, 0] = "T";
                ConsuCred[nCant, 4, 0, 0] = item.SubItems[5].Text;
                ConsuCred[nCant, 4, 1, 0] = "D";                            // "D" decimales
                ConsuCred[nCant, 5, 0, 0] = item.SubItems[6].Text;
                ConsuCred[nCant, 5, 1, 0] = "";
                ConsuCred[nCant, 6, 0, 0] = item.SubItems[7].Text;
                ConsuCred[nCant, 6, 1, 0] = "D";
                ConsuCred[nCant, 7, 0, 0] = item.SubItems[8].Text;
                ConsuCred[nCant, 7, 1, 0] = "D";
                ConsuCred[nCant, 8, 0, 0] = item.SubItems[9].Text;
                ConsuCred[nCant, 8, 1, 0] = "D";
            }

            string cTitulo2 = "Desde " + dtpDesde.Value.ToShortDateString() + " Hasta " + dtpHasta.Value.ToShortDateString();
            if (chkAgrupa.Checked)
            {
                cTitulo2 = cTitulo2 + " - agrupado";
            }

            EnviaAExcel ea = new EnviaAExcel();
            ea.EnviaArExcel("Consulta cuenta corriente", cTitulo2, ConsuCred, p.usu.apellido);

        }
        private void btnImpre_Click(object sender, EventArgs e)
        {
            Manda_excel();
        }

        private void listBusca_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void Carga_DatosCta(int nFila)
        {
            if (nFila < 0) return;
            if (listBusca.SelectedItems[0].SubItems[2].Text == "") return;
            //if (grid.Rows[nFila].Cells[2].Value == null) return;
            btnGrp.Visible = false;
            grpMovimientos.Visible = false;
            lblSombra.Visible = false;
            gridCobrCred.Visible = false;
            //gridDetalle.Visible = false;
            gridMov.Width = grpMovimientos.Width - gridMov.Left - 20;
            //lblMsg3.Width = gridMov.Width;
            //gridDetalle.Width = gridMov.Width;
            //gridMov.Height = grpMovimientos.Height - gridMov.Top - btnCierraMov.Height - 30;
            //lblMsg3.Text = "";
            //lblMsg3.Visible = false;
            lblMsg4.Visible = false;
            lblMensa.Text = "Buscando " + listBusca.SelectedItems[0].SubItems[0].Text;   //nCta.ToString() + " - " + gridMov.Rows[nFila].Cells[1].Value.ToString();
            Application.DoEvents();
            lblFecha.Text = listBusca.SelectedItems[0].SubItems[2].Text;
            gridMov.DataSource = null;

            int nCta = Convert.ToInt16(listBusca.SelectedItems[0].SubItems[0].Text);
            //lblCta.Text = nCta.ToString();
            grpMovimientos.Text = "Imputación cuenta corriente: " + nCta + " - " + nCta.ToString();
            DateTime fCuenta = Convert.ToDateTime(listBusca.SelectedItems[0].SubItems[2].Text);
            DateTime fCuentaH = fCuenta.AddDays(1);
            //int nBusca = 0;
            List<CuentaCorriente> movs = new List<CuentaCorriente>();
            //nBusca = 0;
            movs = bl.Get<CuentaCorriente>(bl.pGlob.EmpresaID, c => c.EmpresaID == bl.pGlob.EmpresaID
                                                        && c.FechaAviso >= fCuenta && c.FechaAviso <= fCuentaH
                                                        && c.TipoMovimientoID == nCta,
                                                        q => q.OrderBy(c => c.FechaAviso)).ToList();



            gridMov.DataSource = movs;
            gridMov.Columns[2].DefaultCellStyle.Format = "N2";
            gridMov.Columns[3].DefaultCellStyle.Format = "N0";
            backColorList = Color.White;
            for (int n = 0; n < gridMov.Rows.Count; n++)
            {
                gridMov.Rows[n].DefaultCellStyle.BackColor = backColorList;
                if (backColorList == Color.White) backColorList = Color.LightGray; else backColorList = Color.White;
            }
            lblSombra.Width = grpMovimientos.Width;
            lblSombra.Height = grpMovimientos.Height - 10;
            lblSombra.Top = grpMovimientos.Top + 15;
            lblSombra.Left = grpMovimientos.Left + 5;
            lblSombra.Visible = true;
            grpMovimientos.Visible = true;
            grpMovimientos.BringToFront();

        }
        private void Carga_DetallesCta(int nFila, int nCol)
        {
            //lblMsg.Text = "";
            //gridDetalle.Visible = false;
            gridMov.Width = grpMovimientos.Width - gridMov.Left - 20;
            gridMov.Height = grpMovimientos.Height - gridMov.Top - btnGrpCerrar.Height - 30;
            //lblMsg3.Text = "";
            //lblMsg3.Visible = false;
            lblMsg4.Visible = false;
            Application.DoEvents();
            if (nFila < 0) return;
            if (gridMov.Rows[nFila].Cells[1].Value.ToString() == "") return;
            //gridDetalle.DataSource = null;
            if (gridMov.Rows[nFila].Cells[1].Value == null) return;
            int nCta = Convert.ToInt16(gridMov.Rows[nFila].Cells[12].Value);
            int nTmp = 0;
            if (nCta == 0) return;
            int nComTmp = Convert.ToInt16(gridMov.Rows[nFila].Cells[0].Value);
            switch (nCta)
            {
                //case 610:       //Depósito Cobranza Receptoría
                //    if (nCol == 9)
                //    {
                //        if (gridMov.Rows[nFila].Cells[9].Value == null) return;
                //        nTmp = Convert.ToInt16(gridMov.Rows[nFila].Cells[9].Value);
                //    }
                //    Busca_Transferencia(nTmp, nFila, nCol, nComTmp);
                //    break;
                case 720:       //cobranza por débito
                    //Busca_Transferencia(nTmp, nFila, nCol, nComTmp);
                    break;
                case 725:       //ingreso de cobranza comer adh
                    if (gridMov.Rows[nFila].Cells[9].Value.ToString() == "") return;
                    nTmp = Convert.ToInt16(gridMov.Rows[nFila].Cells[9].Value);
                    //Busca_Transferencia(nTmp, nFila, nCol, nComTmp);
                    break;
                case 100:       //COBRANZAS
                    if (gridMov.Rows[nFila].Cells[1].Value.ToString() == "") return;
                    Busca_Cobranzas(true);
                    break;
                case 13:       //ANULACIO DE COBRANZAS
                    if (gridMov.Rows[nFila].Cells[1].Value.ToString() == "") return;
                    Busca_Cobranzas(false);
                    break;
                case 20:        //ALTAS
                    if (gridMov.Rows[nFila].Cells[1].Value.ToString() == "") return;
                    Busca_Altas();

                    break;
                //case 820:       //Gastos Cuentas a Pagar
                //    if (gridMov.Rows[nFila].Cells[7].Value.ToString() == "") return;
                //    if (nCol == 7) nTmp = Convert.ToInt16(gridMov.Rows[nFila].Cells[7].Value);
                //    if (nCol == 14) nTmp = Convert.ToInt16(gridMov.Rows[nFila].Cells[14].Value);
                //    Busca_SolisitudFondo(nTmp, nCol, nComTmp);
                //    break;
                //case 810:       //Gastos Fondo Fijo
                //    if (gridMov.Rows[nFila].Cells[11].Value.ToString() == "") return;
                //    nTmp = Convert.ToInt16(gridMov.Rows[nFila].Cells[11].Value);
                //    Busca_Gastos(nTmp, nComTmp);
                //    break;
                //case 811:       //anulación Gastos Fondo Fijo
                //    if (gridMov.Rows[nFila].Cells[11].Value.ToString() == "") return;
                //    nTmp = Convert.ToInt16(gridMov.Rows[nFila].Cells[11].Value);
                //    Busca_Gastos(nTmp, nComTmp);
                //    break;
                case 11:        // NOTAS DE CREDITO
                    if (gridMov.Rows[nFila].Cells[1].Value.ToString() == "") return;
                    //Busca_NC();
                    break;
            }

        }
        private void Busca_Altas()
        {
            DateTime fFechaD = Convert.ToDateTime(lblFecha.Text);
            DateTime fFechaH = fFechaD.AddDays(1);
            int nComer = Com.ComercioID; ;
            List<Credito> RegListCred = new List<Credito>();
            List<Credito> RegListCredTmp = new List<Credito>();

            RegListCred = bl.Get<Credito>(bl.pGlob.EmpresaID, c => c.FechaAviso >= fFechaD && c.FechaAviso < fFechaH, o => o.OrderBy(f => f.FechaSolicitud)).ToList();

            if (RegListCred.Count == 0)
            {
                return;
            }
            int nTmp = 0;
            decimal dTmp = 0;

            gridCobrCred.AutoGenerateColumns = false;
            gridCobrCred.Columns.Clear();
            gridCobrCred.ColumnCount = 6;
            gridCobrCred.Columns[0].Name = "Com";
            gridCobrCred.Columns[1].Name = "Fecha solicitud";
            gridCobrCred.Columns[2].Name = "Importe";
            gridCobrCred.Columns[3].Name = "Crédito";
            gridCobrCred.Columns[4].Name = "Gastos";
            gridCobrCred.Columns[5].Name = "Comisión";

            gridCobrCred.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridCobrCred.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridCobrCred.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridCobrCred.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridCobrCred.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            gridCobrCred.Columns[0].Width = 50;
            gridCobrCred.Columns[1].Width = 90;
            gridCobrCred.Columns[2].Width = 80;
            gridCobrCred.Columns[3].Width = 80;
            gridCobrCred.Columns[4].Width = 80;
            gridCobrCred.Columns[5].Width = 80;

            for (int nC = 0; nC < RegListCred.Count; nC++)
            {
                gridCobrCred.Rows.Add();
                gridCobrCred.Rows[nC].Cells[0].Value = RegListCred[nC].ComercioID.ToString();
                gridCobrCred.Rows[nC].Cells[1].Value = RegListCred[nC].FechaSolicitud.ToString();
                dTmp = Convert.ToDecimal(RegListCred[nC].ValorNominal);
                gridCobrCred.Rows[nC].Cells[2].Value = dTmp.ToString("N2");
                nTmp = RegListCred[nC].CreditoID;
                gridCobrCred.Rows[nC].Cells[3].Value = nTmp.ToString("N0");
                dTmp = Convert.ToDecimal(RegListCred[nC].Gasto);
                gridCobrCred.Rows[nC].Cells[4].Value = dTmp.ToString("N2");
                dTmp = Convert.ToDecimal(RegListCred[nC].Comision);
                gridCobrCred.Rows[nC].Cells[5].Value = dTmp.ToString("N2");
            }
            Acomoda_Grids();
            btnGrp.Visible = true;
            btnGrp.Text = "Comprobar";
            gridCobrCred.Visible = true;

        }
        private void Busca_Cobranzas(Boolean bCob)
        {
            DateTime fFechaD = Convert.ToDateTime(lblFecha.Text);
            DateTime fFechaH = fFechaD.AddDays(1);
            int nComer = Com.ComercioID; // Convert.ToInt16(txtBuscaComer.Text);
            List<Cobranza> RegListCobr = new List<Cobranza>();
            List<Cobranza> RegListCobrTmp = new List<Cobranza>();


            if (bCob) RegListCobr = bl.Get<Cobranza>(bl.pGlob.EmpresaID, c => c.FechaPago >= fFechaD && c.FechaPago < fFechaH && c.ImportePago > 0, o => o.OrderBy(f => f.FechaPago)).ToList();
            if (bCob == false) RegListCobr = bl.Get<Cobranza>(bl.pGlob.EmpresaID, c => c.FechaPago >= fFechaD && c.FechaPago < fFechaH && c.ImportePago < 0, o => o.OrderBy(f => f.FechaPago)).ToList();


            if (RegListCobr.Count == 0)
            {
                return;
            }
            int nTmp = 0;
            decimal dTmp = 0;
            gridCobrCred.AutoGenerateColumns = false;
            gridCobrCred.Columns.Clear();
            gridCobrCred.ColumnCount = 7;
            gridCobrCred.Columns[0].Name = "Com";
            gridCobrCred.Columns[1].Name = "Fecha pago";
            gridCobrCred.Columns[2].Name = "Importe";
            gridCobrCred.Columns[3].Name = "Crédito";
            gridCobrCred.Columns[4].Name = "Cuota";
            gridCobrCred.Columns[5].Name = "Nro. cobranza";
            gridCobrCred.Columns[6].Name = "Tipo cobranza";
            gridCobrCred.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridCobrCred.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridCobrCred.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridCobrCred.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridCobrCred.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridCobrCred.Columns[2].DefaultCellStyle.Format = "N2";
            gridCobrCred.Columns[3].DefaultCellStyle.Format = "N0";
            gridCobrCred.Columns[0].Width = 50;
            gridCobrCred.Columns[1].Width = 90;
            gridCobrCred.Columns[2].Width = 80;
            gridCobrCred.Columns[3].Width = 80;
            gridCobrCred.Columns[4].Width = 50;
            gridCobrCred.Columns[5].Width = 70;
            gridCobrCred.Columns[6].Width = 140;
            for (int nC = 0; nC < RegListCobr.Count; nC++)
            {
                gridCobrCred.Rows.Add();
                gridCobrCred.Rows[nC].Cells[0].Value = RegListCobr[nC].ComercioID.ToString();
                gridCobrCred.Rows[nC].Cells[1].Value = RegListCobr[nC].FechaPago.ToString();
                dTmp = Convert.ToDecimal(RegListCobr[nC].ImporteTotal);
                gridCobrCred.Rows[nC].Cells[2].Value = RegListCobr[nC].ImporteTotal; // dTmp.ToString("N2");
                nTmp = RegListCobr[nC].CreditoID;
                gridCobrCred.Rows[nC].Cells[3].Value = nTmp.ToString("N0");
                gridCobrCred.Rows[nC].Cells[4].Value = RegListCobr[nC].CuotaID.ToString();
                nTmp = Convert.ToInt32(RegListCobr[nC].CobranzaID);
                gridCobrCred.Rows[nC].Cells[5].Value = nTmp.ToString();
                gridCobrCred.Rows[nC].Cells[6].Value = RegListCobr[nC].TipoPago.Descripcion;
            }

            Acomoda_Grids();
            btnGrp.Text = "Comprobar";
            btnGrp.Visible = true;

            gridCobrCred.Visible = true;

        }
        private void Acomoda_Grids()
        {
            gridMov.Width = (grpMovimientos.Width / 2) - 10;
            gridCobrCred.Width = gridMov.Width - 10;
            gridCobrCred.Height = gridMov.Height;
            gridCobrCred.Left = gridMov.Left + gridMov.Width + 5;
            backColorList = Color.White;
            for (int n = 0; n < gridCobrCred.Rows.Count; n++)
            {
                gridCobrCred.Rows[n].DefaultCellStyle.BackColor = backColorList;
                if (backColorList == Color.White) backColorList = Color.LightGray; else backColorList = Color.White;
            }
        }
        private void listBusca_DoubleClick(object sender, EventArgs e)
        {
            //if (chkAgrupa.Checked)
            //{
            //    if (listBusca.SelectedItems[0].SubItems[2].Text == "") return;
            //    int nF = Convert.ToInt16(listBusca.SelectedItems[0].SubItems[0].Text);
            //    Carga_DatosCta(nF);
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lblSombra.Visible = false;
            grpMovimientos.Visible = false;
        }

        private void btnGrp_Click(object sender, EventArgs e)
        {
            Comprueba();
        }
        private void Comprueba()
        {
            Boolean bEsta = true;
            lblMsg4.Visible = false;
            lblMsg4.Text = "";
            if (gridMov.Rows.Count == 0) return;
            if (gridCobrCred.Rows.Count == 0) return;
            decimal n1 = 0;
            decimal n2 = 0;
            decimal d1 = 0;
            decimal d2 = 0;
            int nCant = 0;
            int nCant2 = 0;
            if (lblCta.Text == "100")        //cobranzas
            {
                nCant = 0;
                for (int nR = 0; nR < gridMov.Rows.Count; nR++)
                {
                    bEsta = false;
                    for (int nC = 0; nC < gridCobrCred.Rows.Count; nC++)
                    {
                        n1 = Convert.ToDecimal(gridMov.Rows[nR].Cells[3].Value);
                        n2 = Convert.ToDecimal(gridCobrCred.Rows[nC].Cells[3].Value);

                        if (n1 == n2)
                        {
                            n1 = Convert.ToInt16(gridMov.Rows[nR].Cells[4].Value);
                            n2 = Convert.ToInt16(gridCobrCred.Rows[nC].Cells[4].Value);
                            if (n1 == n2)
                            {
                                d1 = Convert.ToDecimal(gridMov.Rows[nR].Cells[2].Value);
                                d2 = Convert.ToDecimal(gridCobrCred.Rows[nC].Cells[2].Value);
                                if (d1 == d2)
                                {
                                    bEsta = true;
                                    break;
                                }
                            }
                        }
                    }
                    if (bEsta == false) gridMov.Rows[nR].Cells[1].Style.BackColor = Color.Red;
                    if (bEsta == false) nCant++;

                }
                for (int nC = 0; nC < gridCobrCred.Rows.Count; nC++)
                {
                    bEsta = false;
                    for (int nR = 0; nR < gridMov.Rows.Count; nR++)
                    {
                        n1 = Convert.ToDecimal(gridMov.Rows[nR].Cells[3].Value);
                        n2 = Convert.ToDecimal(gridCobrCred.Rows[nC].Cells[3].Value);

                        if (n1 == n2)
                        {
                            n1 = Convert.ToInt16(gridMov.Rows[nR].Cells[4].Value);
                            n2 = Convert.ToInt16(gridCobrCred.Rows[nC].Cells[4].Value);
                            if (n1 == n2)
                            {
                                d1 = Convert.ToDecimal(gridMov.Rows[nR].Cells[2].Value);
                                d2 = Convert.ToDecimal(gridCobrCred.Rows[nC].Cells[2].Value);
                                if (d1 == d2)
                                {
                                    bEsta = true;
                                    break;
                                }
                            }
                        }
                    }
                    if (bEsta == false) gridCobrCred.Rows[nC].Cells[1].Style.BackColor = Color.Red;
                    if (bEsta == false) nCant2++;

                }

                if (nCant > 0) lblMsg4.Text = nCant + " Errores en movimientos";
                if (nCant2 > 0) lblMsg4.Text = lblMsg4.Text + " - " + nCant2 + " Errores en cobranzas";
            }
            //****************************************************************
            if (lblCta.Text == "20")        //cobranzas
            {

                for (int nR = 0; nR < gridMov.Rows.Count; nR++)
                {
                    bEsta = false;
                    for (int nC = 0; nC < gridCobrCred.Rows.Count; nC++)
                    {
                        n1 = Convert.ToDecimal(gridMov.Rows[nR].Cells[3].Value);
                        n2 = Convert.ToDecimal(gridCobrCred.Rows[nC].Cells[3].Value);

                        if (n1 == n2)
                        {
                            d1 = Convert.ToDecimal(gridMov.Rows[nR].Cells[2].Value);
                            d2 = Convert.ToDecimal(gridCobrCred.Rows[nC].Cells[2].Value);
                            if (d1 == d2)
                            {
                                bEsta = true;
                                break;
                            }
                        }
                    }
                    if (bEsta == false) gridMov.Rows[nR].Cells[1].Style.BackColor = Color.Red;
                    if (bEsta == false) nCant++;

                }
                for (int nC = 0; nC < gridCobrCred.Rows.Count; nC++)
                {
                    bEsta = false;
                    for (int nR = 0; nR < gridMov.Rows.Count; nR++)
                    {
                        n1 = Convert.ToDecimal(gridMov.Rows[nR].Cells[3].Value);
                        n2 = Convert.ToDecimal(gridCobrCred.Rows[nC].Cells[3].Value);

                        if (n1 == n2)
                        {
                            d1 = Convert.ToDecimal(gridMov.Rows[nR].Cells[2].Value);
                            d2 = Convert.ToDecimal(gridCobrCred.Rows[nC].Cells[2].Value);
                            if (d1 == d2)
                            {
                                bEsta = true;
                                break;
                            }
                        }
                    }
                    if (bEsta == false) gridCobrCred.Rows[nC].Cells[1].Style.BackColor = Color.Red;
                    if (bEsta == false) nCant2++;

                }
                if (nCant > 0) lblMsg4.Text = nCant + " Errores en movimientos";
                if (nCant2 > 0) lblMsg4.Text = lblMsg4.Text + " - " + nCant2 + " Errores en altas";
            }
            if (lblMsg4.Text == "") lblMsg4.Text = "No hay errores";
            lblMsg4.Visible = true;

        }
        private void grpMovimientos_Move(object sender, EventArgs e)
        {
            System.Windows.Forms.Control elControl = (System.Windows.Forms.Control)sender;
            lblSombra.Width = elControl.Width;
            lblSombra.Height = elControl.Height - 10;
            lblSombra.Top = elControl.Top + 15;
            lblSombra.Left = elControl.Left + 5;
        }

        private void grpMovimientos_Resize(object sender, EventArgs e)
        {
            System.Windows.Forms.Control elControl = (System.Windows.Forms.Control)sender;
            lblSombra.Width = elControl.Width;
            lblSombra.Height = elControl.Height - 10;
            lblSombra.Top = elControl.Top + 15;
            lblSombra.Left = elControl.Left + 5;
        }

        private void gridMov_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Carga_DetallesCta(e.RowIndex, e.ColumnIndex);
        }

        private void listBusca_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
        private void BuscarXXXXXX(bool bAgrupa)
        {

            DateTime TmpFech;

            //int nCant;



            int nCuota = 0;

            DateTime fD = Convert.ToDateTime(dtpDesde.Value.ToShortDateString());
            DateTime fH = Convert.ToDateTime(dtpHasta.Value.ToShortDateString());

            fH = fH.AddDays(1);
            fontList = new Font("Verdana", 8F, FontStyle.Regular);
            fontColor = Color.Empty;
            backColorList = Color.LightSteelBlue;
            ListViewItem item;
            // Busca primer fecha de corte
            CuentaCorrienteCorte regCtaCte;
            regCtaCte = bl.Get<CuentaCorrienteCorte>(bl.pGlob.EmpresaID, c => c.EmpresaID == bl.pGlob.EmpresaID && c.ComercioID == bl.pGlob.Comercio.ComercioID
                                                               , o => o.OrderBy(c => c.Fecha), "", 1).FirstOrDefault();
            if (regCtaCte != null)
            {
                if (regCtaCte.Fecha > fD)
                {
                    DialogResult res = MessageBox.Show("La fecha " + fD.ToShortDateString() + Environment.NewLine + "es anterior al primer saldo" + Environment.NewLine +
                            "la fecha debe ser desde " + regCtaCte.Fecha.ToShortDateString()
                            , "Cuenta corriente comercio", MessageBoxButtons.OK);
                    return;
                }
            }



            // BUSCA ANTES DE DESDE
            nTot = 0;
            nFavorFinan = 0;
            nFavorComer = 0;
            DateTime NvaFechDesde = DateTime.Now;
            bool bHaySaldo = false;
            regCtaCte = bl.CuentaCorrienteCorte(bl.pGlob.EmpresaID, bl.pGlob.Comercio.ComercioID, fD); // DateTime.Now);

            if (regCtaCte != null)
            {
                NvaFechDesde = regCtaCte.Fecha;
                if (regCtaCte.Saldo > 0)
                {
                    nFavorComer = regCtaCte.Saldo;
                }
                else if (regCtaCte.Saldo < 0)
                {
                    nFavorFinan = regCtaCte.Saldo;
                }
                nTot = nTot - nFavorFinan;
                nTot = nTot + nFavorComer;
                bHaySaldo = true;
            }
            List<CuentaCorriente> listCc;
            if (bHaySaldo)
            {
                listCc = bl.GetCuentasCorrientes(c => c.FechaAviso > NvaFechDesde && c.FechaAviso < fD && c.EmpresaID == bl.pGlob.Comercio.EmpresaID &&
                        c.TipoMovimiento.CodInter == "S", or => or.OrderBy(o => o.FechaAviso)).ToList();

            }
            else
            {
                listCc = bl.GetCuentasCorrientes(c => c.FechaAviso < fD && c.EmpresaID == bl.pGlob.Comercio.EmpresaID &&
                        c.TipoMovimiento.CodInter == "S", or => or.OrderBy(o => o.FechaAviso)).ToList();

            }

            if (listCc.Count > 0)
            {
                foreach (CuentaCorriente lcc in listCc)
                {
                    nFavorFinan = 0;
                    nFavorComer = 0;
                    if (lcc.TipoMovimiento.ClaseMovimientoID == 1)
                    {
                        nFavorFinan = lcc.Importe;
                    }
                    else
                    {
                        nFavorComer = lcc.Importe;
                    }

                    if (lcc.TipoMovimientoID == 822 || lcc.TipoMovimientoID == 823)
                    {
                        nFavorFinan = nFavorFinan + (nFavorFinan * 21 / 100);
                    }
                    nTot = nTot - nFavorFinan;
                    nTot = nTot + nFavorComer;

                }
            }

            item = new ListViewItem("A");
            item.UseItemStyleForSubItems = false;
            item.SubItems.Add("ARRASTRE", fontColor, backColorList, fontList);                                        //1
            item.SubItems.Add("", fontColor, backColorList, fontList);                                        //2
            item.SubItems.Add("", fontColor, backColorList, fontList);                                        //3
            item.SubItems.Add("", fontColor, backColorList, fontList);                                        //4
            item.SubItems.Add("", fontColor, backColorList, fontList);                                        //5
            item.SubItems.Add("", fontColor, backColorList, fontList);                                        //6
            item.SubItems.Add("", fontColor, backColorList, fontList);                                        //7
            item.SubItems.Add("", fontColor, backColorList, fontList);                                        //8
            if (nTot < 0) fontColor = Color.Red;
            item.SubItems.Add(nTot.ToString("N2"), fontColor, backColorList, fontList);                          //9
            listBusca.Items.Add(item);

            int nTipcc = 0;
            string cFecha = "q";
            string cTipcc = "";

            // BUSCA ENTRE FECHAS
            if (bAgrupa)
            {
                listCc = bl.GetCuentasCorrientes(c => c.FechaAviso >= fD && c.FechaAviso <= fH && c.EmpresaID == bl.pGlob.Comercio.EmpresaID &&
                        c.TipoMovimiento.CodInter == "S").ToList();

                listCc = listCc.OrderBy(o => o.FechaAviso.Value.Date).ThenBy(o => o.TipoMovimientoID).ToList();

                if (listCc.Count > 0)
                {
                    nFavorFinan = 0;
                    nFavorComer = 0;
                    nTipcc = Convert.ToInt16(listCc[0].TipoMovimientoID);
                    cFecha = listCc[0].FechaAviso.Value.ToShortDateString();
                    cTipcc = listCc[0].TipoMovimiento.Nombre;
                    foreach (CuentaCorriente lcc in listCc)
                    {
                        if (cFecha == lcc.FechaAviso.Value.ToShortDateString())
                        {
                            //nFavorFinan = 0;
                            //nFavorComer = 0;
                            if (nTipcc == lcc.TipoMovimientoID)
                            {
                                CargaImporte(lcc);
                            }
                            else //  tipode movimiento
                            {
                                CargaLista(nTipcc, cTipcc, cFecha);
                                cTipcc = lcc.TipoMovimiento.Nombre;
                                nTipcc = Convert.ToInt16(lcc.TipoMovimientoID);
                                nFavorFinan = 0;
                                nFavorComer = 0;
                                CargaImporte(lcc);
                            }//  fin tipode movimiento


                        }
                        else // fecha
                        {
                            CargaLista(nTipcc, cTipcc, cFecha);
                            if (backColorList == Color.White) backColorList = Color.LightSteelBlue; else backColorList = Color.White;//8
                            cFecha = lcc.FechaAviso.Value.ToShortDateString();
                            nTipcc = Convert.ToInt16(lcc.TipoMovimientoID);
                            cTipcc = lcc.TipoMovimiento.Nombre;
                            nFavorFinan = 0;
                            nFavorComer = 0;
                            CargaImporte(lcc);
                        }   // fin fecha
                    }
                    CargaLista(nTipcc, cTipcc, cFecha);
                }

            }
            else
            {

                listCc = bl.GetCuentasCorrientes(c => c.FechaAviso >= fD && c.FechaAviso <= fH && c.EmpresaID == bl.pGlob.Comercio.EmpresaID &&
                        c.TipoMovimiento.CodInter == "S", or => or.OrderBy(o => o.FechaAviso)).ToList();

                if (listCc.Count > 0)
                {
                    backColorList = Color.White;
                    cFecha = listCc[0].FechaAviso.Value.ToShortDateString();
                    foreach (CuentaCorriente lcc in listCc)
                    {
                        nFavorFinan = 0;
                        nFavorComer = 0;
                        item = new ListViewItem(lcc.CuentaCorrienteID.ToString());
                        item.UseItemStyleForSubItems = false;
                        TmpFech = lcc.FechaAviso.Value;

                        item.SubItems.Add(lcc.TipoMovimiento.Nombre, fontColor, backColorList, fontList);               // 1
                        item.SubItems.Add(TmpFech.ToShortDateString(), fontColor, backColorList, fontList);             //2

                        nCuota = 0;
                        if (lcc.CreditoID != null) nCuota = Convert.ToInt32(lcc.CreditoID);
                        item.SubItems.Add(nCuota.ToString(), fontColor, backColorList, fontList);        //3

                        nCuota = 0;
                        if (lcc.CuotaID != null) nCuota = Convert.ToInt16(lcc.CuotaID);

                        item.SubItems.Add(nCuota.ToString(), fontColor, backColorList, fontList);                                        //4

                        TmpDeci = lcc.Importe;
                        item.SubItems.Add(TmpDeci.ToString("N2"), fontColor, backColorList, fontList);                   //5

                        item.SubItems.Add("", fontColor, backColorList, fontList);                                        //6

                        if (lcc.TipoMovimiento.ClaseMovimientoID == 1)
                        {
                            nFavorFinan = TmpDeci;
                        }
                        else
                        {
                            nFavorComer = TmpDeci;
                        }


                        if (lcc.TipoMovimientoID == 822 || lcc.TipoMovimientoID == 823)
                        {
                            nFavorFinan = nFavorFinan + (nFavorFinan * 21 / 100);
                        }

                        if (nFavorComer != 0)
                        {
                            item.SubItems.Add(nFavorComer.ToString("N2"), fontColor, backColorList, fontList);                  //7
                        }
                        else
                        {
                            item.SubItems.Add("", fontColor, backColorList, fontList);                                            //7
                        }
                        if (nFavorFinan != 0)
                        {
                            item.SubItems.Add(nFavorFinan.ToString("N2"), fontColor, backColorList, fontList);                    //8
                        }
                        else
                        {
                            item.SubItems.Add("", fontColor, backColorList, fontList);                                          //8
                        }

                        nTot = nTot - nFavorFinan;
                        nTot = nTot + nFavorComer;
                        if (nTot < 0) fontColor = Color.Red;
                        item.SubItems.Add(nTot.ToString("N2"), fontColor, backColorList, fontList);                          //9
                        listBusca.Items.Add(item);
                        //if (backColorList == Color.White) backColorList = Color.LightSteelBlue; else backColorList = Color.White;//8
                        fontColor = Color.Empty;

                        if (cFecha != lcc.FechaAviso.Value.ToShortDateString())
                        {
                            cFecha = lcc.FechaAviso.Value.ToShortDateString();
                            if (backColorList == Color.White) backColorList = Color.LightSteelBlue; else backColorList = Color.White;
                        }
                    }
                }
            }
            Agrega_linea("T1", false, 10);

            btnBuscar.Text = "Otro";
            grpFecha.Enabled = false;
            btnImpre.Enabled = true;
        }
        private void Buscar(bool bAgrupa)
        {
            DateTime fD = Convert.ToDateTime(dtpDesde.Value.ToShortDateString());
            DateTime fH = Convert.ToDateTime(dtpHasta.Value.ToShortDateString());

            fH = fH.AddDays(1);
            fontList = new Font("Verdana", 8F, FontStyle.Regular);
            
            backColorList = Color.LightSteelBlue;
            CuentaCorrienteCorte regCtaCte;
            regCtaCte = bl.Get<CuentaCorrienteCorte>(bl.pGlob.EmpresaID, c => c.EmpresaID == bl.pGlob.EmpresaID && c.ComercioID == bl.pGlob.Comercio.ComercioID
                                                               , o => o.OrderBy(c => c.Fecha), "", 1).FirstOrDefault();
            if (regCtaCte != null)
            {
                if (regCtaCte.Fecha > fD)
                {
                    DialogResult res = MessageBox.Show("La fecha " + fD.ToShortDateString() + Environment.NewLine + "es anterior al primer saldo" + Environment.NewLine +
                            "la fecha debe ser desde " + regCtaCte.Fecha.ToShortDateString()
                            , "Cuenta corriente comercio", MessageBoxButtons.OK);
                    return;
                }
            }
            regCtaCte = bl.CuentaCorrienteCorte(bl.pGlob.EmpresaID, bl.pGlob.Comercio.ComercioID, fD); // DateTime.Now);
            DateTime NvaFechDesde = DateTime.Now;
            bool bHaySaldo = false;
            nTot = 0;
            if (regCtaCte != null)
            {
                NvaFechDesde = regCtaCte.Fecha;
                if (regCtaCte.Saldo > 0)
                {
                    nFavorComer = regCtaCte.Saldo;
                }
                else if (regCtaCte.Saldo < 0)
                {
                    nFavorFinan = regCtaCte.Saldo;
                }
                nTot = nTot - nFavorFinan;
                nTot = nTot + nFavorComer;
                bHaySaldo = true;
            }

            List<CtaCteComercio> ctacteTot = new List<CtaCteComercio>();
            //BuscaCObr(NvaFechDesde, fH, ref ctacteTot);

            //BuscaAltas(NvaFechDesde, fH, ref ctacteTot);
            BuscaCta(NvaFechDesde, fH, ref ctacteTot);
            ListViewItem item;
            bool bArraste = false;
            if (ctacteTot.Count > 0)
            {
                ctacteTot = ctacteTot.OrderBy(c => c.Ano).ThenBy(cc => cc.Mes).ThenBy(ccc => ccc.dia).ThenBy(t=>t.tpm_id).ToList();
                int nTipcc = 0;
                string cFecha = "q";
                string cTipcc = "";
                nFavorFinan = 0;
                nFavorComer = 0;
                nTipcc = Convert.ToInt16(ctacteTot[0].tpm_id);
                cFecha = ctacteTot[0].Fecha.ToShortDateString();
                cTipcc = ctacteTot[0].Nombre;
                foreach (CtaCteComercio cta in ctacteTot)
                {
                    if (cta.Fecha < fD)
                    {
                        nTot = nTot + cta.SaldoMovCom - cta.SaldoMovFin;
                    }
                    else
                    {
                        if (bArraste == false)
                        {
                            item = new ListViewItem("A");
                            item.UseItemStyleForSubItems = false;
                            item.SubItems.Add("ARRASTRE", fontColor, backColorList, fontList);                                        //1
                            item.SubItems.Add("", fontColor, backColorList, fontList);                                        //2
                            item.SubItems.Add("", fontColor, backColorList, fontList);                                        //3
                            item.SubItems.Add("", fontColor, backColorList, fontList);                                        //4
                            item.SubItems.Add("", fontColor, backColorList, fontList);                                        //5
                            item.SubItems.Add("", fontColor, backColorList, fontList);                                        //6
                            item.SubItems.Add("", fontColor, backColorList, fontList);                                        //7
                            item.SubItems.Add("", fontColor, backColorList, fontList);                                        //8
                            if (nTot < 0) fontColor = Color.Red;
                            item.SubItems.Add(nTot.ToString("N2"), fontColor, backColorList, fontList);                          //9
                            listBusca.Items.Add(item);
                            fontColor = Color.Empty;
                            bArraste = true;
                        }
                        if (bAgrupa)
                        {
                            if (cFecha == cta.Fecha.ToShortDateString())
                            {
                                if (nTipcc == cta.tpm_id)
                                {
                                    nFavorFinan = nFavorFinan + cta.SaldoMovFin;
                                    nFavorComer = nFavorComer + cta.SaldoMovCom;
                                }
                                else
                                {
                                    CargaLista(nTipcc, cTipcc, cFecha);
                                    cTipcc = cta.Nombre;
                                    nTipcc = Convert.ToInt16(cta.tpm_id);
                                    nFavorFinan = cta.SaldoMovFin;
                                    nFavorComer = cta.SaldoMovCom;
                                }
                            }
                            else
                            {
                                CargaLista(nTipcc, cTipcc, cFecha);
                                if (backColorList == Color.White) backColorList = Color.LightSteelBlue; else backColorList = Color.White;//8
                                cFecha = cta.Fecha.ToShortDateString();
                                nTipcc = Convert.ToInt16(cta.tpm_id);
                                cTipcc = cta.Nombre;
                                nFavorFinan = cta.SaldoMovFin;
                                nFavorComer = cta.SaldoMovCom;


                            }
                        }
                    }
                }   //foreach
                CargaLista(nTipcc, cTipcc, cFecha);
            }   //if (ctacteTot.Count > 0)
                        Agrega_linea("T1", false, 10);

            btnBuscar.Text = "Otro";
            grpFecha.Enabled = false;
            btnImpre.Enabled = true;

        }

        private void BuscaCObr(DateTime fD, DateTime fH, ref List<CtaCteComercio> ctacteTot)
        {
            CtaCteComercio ctacteCom;
            List<Cobranza> regCobranzaList;
            List<NotasCD> regListNotasCD;
            regCobranzaList = bl.GetCobranzas(BaseID, c => c.FechaPago >= fD && c.FechaPago < fH && c.GestionEmpresaID == BaseID
                 && c.GestionID == ComID, or => or.OrderBy(o => o.FechaPago)).ToList();
            if (regCobranzaList.Count > 0)
            {
                foreach (Cobranza cob in regCobranzaList)
                {
                    ctacteCom = new CtaCteComercio();
                    ctacteCom.Ano = cob.FechaPago.Year;
                    ctacteCom.Mes = cob.FechaPago.Month;
                    ctacteCom.dia = cob.FechaPago.Day;
                    ctacteCom.Fecha = cob.FechaPago;
                    ctacteCom.tpm_id = 100;
                    ctacteCom.Nombre = "Cobranzas";
                    //dTmpAv = (decimal)cr.VALORNOMINAL - (decimal)cr.GASTO_RETENIDO - (decimal)cr.GASTO_RETENIDO2 - (decimal)cr.CUOTA_RETENIDO - (decimal)cr.CUOTA_RETENIDOA - Convert.ToDecimal(((iva21.Alic) * Convert.ToDecimal(cr.COMISION) / 100) + Convert.ToDecimal(cr.COMISION));
                    ctacteCom.SaldoMovFin = cob.ImporteTotal;
                    ctacteCom.SaldoMovCom = 0;
                    ctacteTot.Add(ctacteCom);
                }
            }
            regListNotasCD = bl.GetNotasCD(BaseID, n => n.Fecha >= fD && n.Fecha < fH && n.EmpresaID == BaseID
                    && n.GestionID == ComID).ToList();
            if (regListNotasCD.Count > 0)
            {
                foreach (NotasCD not in regListNotasCD)
                {
                    ctacteCom = new CtaCteComercio();
                    ctacteCom.Ano = not.Fecha.Year;
                    ctacteCom.Mes = not.Fecha.Month;
                    ctacteCom.dia = not.Fecha.Day;
                    ctacteCom.Fecha = not.Fecha;
                    ctacteCom.tpm_id = 12;
                    ctacteCom.Nombre = "Bonificado";
                    //dTmpAv = (decimal)cr.VALORNOMINAL - (decimal)cr.GASTO_RETENIDO - (decimal)cr.GASTO_RETENIDO2 - (decimal)cr.CUOTA_RETENIDO - (decimal)cr.CUOTA_RETENIDOA - Convert.ToDecimal(((iva21.Alic) * Convert.ToDecimal(cr.COMISION) / 100) + Convert.ToDecimal(cr.COMISION));
                    ctacteCom.SaldoMovFin = 0;
                    ctacteCom.SaldoMovCom = not.Importe;
                    ctacteTot.Add(ctacteCom);
                }
            }
        }

  
        private void BuscaAltas(DateTime fD, DateTime fH, ref List<CtaCteComercio> ctacteTot)
        {
            List<Credito>  regCreditoList = bl.GetCreditos(BaseID, c => c.FechaAviso >= fD && c.FechaAviso <= fH && c.EmpresaID == BaseID && c.ComercioID == ComID,
            or => or.OrderBy(o => o.FechaAviso)).ToList();
            if (regCreditoList.Count > 0)
            {
                CtaCteComercio ctacteCom;
                decimal dVn = 0;
                decimal dCuREt = 0;
                decimal dGstret = 0;
                decimal dComi = 0;
                decimal dTot = 0;

                foreach(Credito cr in regCreditoList)
                {
                    dVn = 0;
                    dGstret = 0;
                    dCuREt = 0;
                    dComi = 0;
                    ctacteCom = new CtaCteComercio();
                    ctacteCom.Ano = cr.FechaAviso.Year;
                    ctacteCom.Mes = cr.FechaAviso.Month;
                    ctacteCom.dia = cr.FechaAviso.Day;
                    ctacteCom.Fecha = cr.FechaAviso;
                    ctacteCom.tpm_id = 10;
                    ctacteCom.Nombre = "Avisos de pago";
                    dVn = cr.ValorNominal;
                    if(cr.TipoRetencionPlanID == "A")
                    {
                        if (cr.TipoCuotaID == "A") dCuREt = cr.ValorCuota;
                        dGstret = cr.Gasto;
                    }else if (cr.TipoRetencionPlanID == "C")
                    {
                        if (cr.TipoCuotaID == "A") dCuREt = cr.ValorCuota;
                    }
                    else if (cr.TipoRetencionPlanID == "G")
                    {
                        dGstret = cr.Gasto;
                    }
                    dComi = cr.Comision * Convert.ToDecimal(lblIVA.Text);
                    dTot = dVn - dCuREt - dGstret- dComi;
                        //dTmpAv = (decimal)cr.VALORNOMINAL - (decimal)cr.GASTO_RETENIDO - (decimal)cr.GASTO_RETENIDO2 - (decimal)cr.CUOTA_RETENIDO - (decimal)cr.CUOTA_RETENIDOA - Convert.ToDecimal(((iva21.Alic) * Convert.ToDecimal(cr.COMISION) / 100) + Convert.ToDecimal(cr.COMISION));
                    ctacteCom.SaldoMovFin = 0;
                    ctacteCom.SaldoMovCom = dTot;
                    ctacteTot.Add(ctacteCom);
                    
                }
            }
        }
        private void BuscaCta(DateTime fD, DateTime fH, ref List<CtaCteComercio> ctacteTot)
        {
            List<CuentaCorriente> listCc;
            //listCc = bl.GetCuentasCorrientes(c => c.FechaAviso > fD && c.FechaAviso < fH && c.EmpresaID == bl.pGlob.Comercio.EmpresaID &&
            //        c.TipoMovimiento.CodInter == "M", or => or.OrderBy(o => o.FechaAviso)).ToList();
            fD = fD.AddDays(1);
            listCc = bl.GetCuentasCorrientes(c => c.FechaAviso >= fD && c.FechaAviso < fH && c.EmpresaID == bl.pGlob.Comercio.EmpresaID , or => or.OrderBy(o => o.FechaAviso)).ToList();

            if (listCc.Count > 0)
            {
                DateTime fAv;
                CtaCteComercio ctacteCom;
                foreach (CuentaCorriente lcc in listCc)
                {
                    fAv =  (DateTime)lcc.FechaAviso;
                    ctacteCom = new CtaCteComercio();
                    ctacteCom.Ano = fAv.Year;
                    ctacteCom.Mes = fAv.Month;
                    ctacteCom.dia = fAv.Day;
                    ctacteCom.Fecha = fAv;
                    ctacteCom.tpm_id = (int)lcc.TipoMovimientoID;
                    ctacteCom.Nombre = "R " + lcc.TipoMovimiento.Nombre;
                    if (lcc.TipoMovimiento.ClaseMovimientoID == 1)
                    {
                        ctacteCom.SaldoMovFin = lcc.Importe;
                    }
                    else
                    {
                        ctacteCom.SaldoMovCom = lcc.Importe;
                    }
                    ctacteTot.Add(ctacteCom);
                }
            }

        }
    }
}
