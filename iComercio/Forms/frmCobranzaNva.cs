using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iComercio.Models;
using iComercio.Rest;
using System.Diagnostics; 


namespace iComercio.Forms
{
    public partial class frmCobranzaNva : FRM
    {
        public BusinessLayer bl2;
        bool bCambiaMinimo = false;
        bool bBoni = false;
        int nGriCob = 0;
        bool bAbogado = false;
        public bool bonificaManual = false;
        //Comercio regComercioPru;
        Comercio regComercio;
        Credito regCredito;
        List<Cuota> regCuotaList = null;
        List<Cobranza> regCobranzaList;
        Refinanciacion regRefinanciacion;
        decimal nPor30 = 0;
        decimal nPor30M = 0;
        decimal nIntADel = 0;

        bool bEsPru = false;
        int nCreditoPagar;
        int nComercioPagar;
        int NumComercio = 0;

        Color backColorList = Color.White;
        Color fontColor = Color.Empty;
        ToolTip toolTipC = new ToolTip();
        ToolTip toolTipA = new ToolTip();
        string[,] aCrediBusco;
        int nCuantoArray = 0;

        string[] cImagenesSoli;
        int nImagenesSoli = 0;

        public frmCobranzaNva(Principal p, RestApi ra, bool bPru)
            : base(p, ra)
        {                                               // 1° solo
            InitializeComponent();
            RecargarEmpYComercio(bPru);
            Configura_Inicio();
            txtBuscaCred.Focus();
            txtBuscaCred.Select();

        }
        public frmCobranzaNva()
        {
            InitializeComponent();
        }
        public frmCobranzaNva(Principal p, bool bPru, string[,] crediTodo, int nIndice)
            : base(p)
        {
            InitializeComponent();
            bl = new BusinessLayer();
            RecargarEmpYComercio(bPru);
            Configura_Inicio();
            aCrediBusco = crediTodo;
            nCuantoArray = nIndice;
            btnAdel.Visible = true;
            btnAtras.Visible = true;
            lblMsgCreds.Visible = true;
            BtnBusca.Enabled = false;
            Recorre_Creditos("", true);

        }

        public frmCobranzaNva(Principal p, BusinessLayer bl, int ComerExt, int CredExt, bool bPru)
            : base(p)
        {
            InitializeComponent();
            bl = new BusinessLayer();
            RecargarEmpYComercio(bPru);
            bEsPru = bPru;
            Configura_Inicio();
            txtBuscaCred.Text = CredExt.ToString();
            nCreditoPagar = CredExt;       //**EDU MOR**//
            nComercioPagar = ComerExt;       //**EDU MOR**//
            if (bPru)        //**EDU MOR**//
            {
                txtBuscaCom.Text = NumComercio.ToString();
                BtnBusca.Enabled = false;
                lblMor.Visible = true;
            }
            else
            {
                txtBuscaCom.Text = ComerExt.ToString();
            }

            //btnAdel.Visible = false;
            //btnAtras.Visible = false;

            Buscar_Credito(nCreditoPagar, nComercioPagar);       //**EDU MOR**//

        }
        private void Llena_Cred_Com()
        {
            listSelec.Items.Clear();
            backColorList = Color.White;
            int qBc = Convert.ToInt32(txtBuscaCred.Text);
            List<Credito> bcred = bl.Get<Credito>(c => c.CreditoID == qBc, p => p.OrderBy(o => o.CreditoID).ThenBy(o => o.ComercioID)).ToList();
            if (bcred.Count == 0)
            {
                MessageBox.Show("Crédito no encontrado", "Cobranzas");
                txtBuscaCred.Focus();
                return;
            }
            else
            {
                foreach (Credito cr in bcred)
                {
                    if (bcred.Count == 1)
                    {
                        txtBuscaCom.Text = cr.ComercioID.ToString();
                        Buscar_Credito(Convert.ToInt32(txtBuscaCred.Text), Convert.ToInt32(txtBuscaCom.Text));
                        return;
                    }

                    ListViewItem item2 = new ListViewItem(cr.CreditoID.ToString());
                    item2.UseItemStyleForSubItems = false;
                    item2.SubItems.Add(cr.ComercioID.ToString());
                    item2.SubItems.Add(cr.CreditoID.ToString(), fontColor, backColorList, new Font("Verdana", 8F, FontStyle.Bold));
                    item2.SubItems.Add(cr.ComercioID.ToString(), fontColor, backColorList, new Font("Verdana", 8F, FontStyle.Bold));
                    listSelec.Items.Add(item2);

                    if (backColorList == Color.White) backColorList = Color.LightBlue; else backColorList = Color.White;

                }
                listSelec.OwnerDraw = true;
                listSelec.FullRowSelect = true;
                listSelec.View = View.Details;

                lblSombra.Width = panelSelectComer.Width;
                lblSombra.Height = panelSelectComer.Height - 10;
                lblSombra.Top = panelSelectComer.Top + 15;
                lblSombra.Left = panelSelectComer.Left + 5;
                lblSombra.Visible = true;
                panelSelectComer.Visible = true;
                panelSelectComer.BringToFront();
            }
        }
        private void Buscar_Credito(int nCred, int nComer)
        {
            //bool bpaso = false;
            //Limpia();
            gridCuotas.Rows.Clear();
            if (nCred == 0 && nComer == 0)
            {
                txtBuscaCred.Focus();
                return;
            }
            if (nCred == 0)
            {
                txtBuscaCred.Focus();
                return;
            }
            bl = new BusinessLayer();
            if (bEsPru) lblMor.Visible = true;
            if (nCred > 0 && nComer == 0)
            {
                Llena_Cred_Com();
                return;
            }
            //////////////////////////////////////////////////////////////////////////////////////
            if (bEsPru)        //**EDU MOR**//
            {
                regComercio = new Comercio();
                regComercio = bl.dalPrueba.Get<Comercio>(c => c.ComercioID == nComer).FirstOrDefault();
                if (regComercio == null)
                {
                    MessageBox.Show("Comercio no encontrado", "Cobranzas");
                    txtBuscaCom.Focus();
                    return;
                }

            }
            else
            {
                regComercio = bl.Get<Comercio>(c => c.ComercioID == nComer).FirstOrDefault();
                if (regComercio == null)
                {
                    MessageBox.Show("Comercio no encontrado", "Cobranzas");

                    txtBuscaCom.Focus();
                    return;
                }
            }
            if (regComercio.Por30 != null) nPor30 = regComercio.Por30.Value; else nPor30 = Com.Por30.Value;
            if (regComercio.Por30M != null) nPor30M = regComercio.Por30M.Value; else nPor30M = Com.Por30.Value;
            lblComNombre.Text = regComercio.Nombre;
            nIntADel = Convert.ToDecimal(regComercio.IntAde); 
            ///////////////////////////////////////////////////////////////////////////////////////////////////////
            if (bEsPru)
            {
                regCredito = bl.dalPrueba.Get<Credito>(c => c.EmpresaID == BaseID
                                               && c.ComercioID == nComer && c.CreditoID == nCred).FirstOrDefault();
            }
            else
            {
                regCredito = bl.Get<Credito>(BaseID, c => c.EmpresaID == BaseID
                                               && c.ComercioID == nComer && c.CreditoID == nCred).FirstOrDefault();
            }
            if (regCredito == null)
            {
                MessageBox.Show("Crédito no encontrado", "Cobranzas");
                txtBuscaCred.Focus();
                return;
            }
            Llena_Datos();
            Llena_Cuotas();
            Llena_Cobranzas(nComer, nCred);
            Llena_NotasCD();
            Llena_Refinanciacion();
            if (bl.pGlob.Configuracion.ScanSolicitudes) panelIma.Visible = true; else panelIma.Visible = false;
            Busca_Imagenes();

            BtnImprimir.Visible = true;
            BtnBusca.Text = "Otro";
            panelBuscar.Enabled = false;
        }
        private void Llena_nota()
        {
            txtCredNotas.Text = "";
            bl = new BusinessLayer();
            List<Nota> regNota;
            if (bEsPru)
            {
                regNota = bl.dalPrueba.GetNotas(n => n.EmpresaID == regCredito.EmpresaID
                        && n.ComercioID == regCredito.ComercioID
                        && n.CreditoID == regCredito.CreditoID, nn => nn.OrderByDescending(c => c.Fecha)).ToList();
            }
            else
            {
                regNota = bl.GetNotas(n => n.EmpresaID == regCredito.EmpresaID
                                    && n.ComercioID == regCredito.ComercioID
                                    && n.CreditoID == regCredito.CreditoID, nn => nn.OrderByDescending(c => c.Fecha)).ToList();
            }

            foreach (Nota not in regNota)
            {
                txtCredNotas.Text = txtCredNotas.Text + not.Fecha + " " + not.Usuario.nombre + ": " + not.Detalle;
                txtCredNotas.Text = txtCredNotas.Text + Environment.NewLine + Environment.NewLine;
            }
            btnCredNotas.Enabled = true;
            return;
        }
        private void Llena_Datos()
        {
            //lblCredCuotas.Text = regCredito.CantidadCuotas.ToString();

            lblCliNombCompleto.Text = regCredito.Cliente.NombreCompleto;
            lblCliDocu.Text = regCredito.Documento.ToString();
            lblCliCodDocu.Text = regCredito.TipoDocumentoID;

            lblCreFecha.Text = regCredito.FechaSolicitud.ToShortDateString();
            lblCreValor.Text = regCredito.ValorNominal.ToString();
            lblCreImpCuota.Text = regCredito.ValorCuota.ToString();

            if (regCredito.AbogadoID != null && regCredito.AbogadoID > 0)
            {
                lblMsgAbogado.Text = "Abogado";
                Pone_toolTip("ABOGADO", regCredito.AbogadoID + " " + regCredito.Abogado.Nombre + Environment.NewLine + regCredito.FechaAbogado.ToShortDateString() + " tel:" + regCredito.Abogado.Telefono1);
                bAbogado = true;
            }

            if(regCredito.TipoCuota != null) lblOtroAV.Text = regCredito.TipoCuota.Nombre;
            lblOtroCuotas.Text = regCredito.CantidadCuotas.ToString();
            lblOtroGst.Text = regCredito.Gasto.ToString();
            lblOtroInf.Text = regCredito.NroInformeContel.ToString();


            if ((regCredito.TipoBonificacionID != "" || regCredito.TipoBonificacionID != null)
                        && regCredito.ValorBonificacion != null)
            {
                string Boni = regCredito.TipoBonificacionID;
                if (regCredito.PorcentajeBonificacion != null)
                {
                    Boni += " " + regCredito.PorcentajeBonificacion.Value.ToString();
                }
                if (regCredito.ValorBonificacion != null)
                {
                    Boni += " - " + regCredito.ValorBonificacion.Value.ToString("N2");
                }
                lblOtroBoni.Text = Boni;
                //regCredito.ValorBonificacion.Value.ToString("N2"); // +" " + regCredito.TipoBonificacion.Descripcion;
            }




            lblOtroNC.Text = "";
            lblOtroNCPorq.Text = "";
            lblOtroPc.Text = regCredito.PcComer;
            lblOtroUsu.Text = regCredito.Usuario.nombre;
            if (regCredito.UsuarioAval != null)
            {
                lblOtroUsuAval1.Text = regCredito.UsuarioAval.nombre;
                    
                if (regCredito.usuarioAvalID > 0)
                {
                    lblOtroUsuAval1.Text = regCredito.UsuarioAval.nombre;
                }
            
            }
            foreach (CreditoAval ca in regCredito.CreditoAvales)
            {
                lblOtroAval.Text = lblOtroAval.Text + ca.Tipoaval.Nombre;
                if (lblOtroAval.Text != "") lblOtroAval.Text = lblOtroAval.Text + Environment.NewLine;
            }

            if (regCredito.Garante1 != null)
            {
                lblGarDocu.Text = regCredito.Garante1.ToString();
                if(regCredito.Gar1!=null)
                {
                    lblGarNombCompleto.Text = regCredito.Gar1.NombreCompleto;
                    lblGarCodDocu.Text = regCredito.TipoDocumentoIDG1;
                }
            }

            if (regCredito.Adicional != null)
            {
                lblAdiDocu.Text = regCredito.Adicional.ToString();
                if (regCredito.Adi != null)
                {
                    lblAdiNombCompleto.Text = regCredito.Adi.NombreCompleto;
                    lblAdiCodDocu.Text = regCredito.TipoDocumentoIDAdi;
                }
            }

            Llena_nota();
            if (!string.IsNullOrEmpty(regCredito.NumCuentaBancaria))
            {
                labelddV.Text = String.Format("Debito Directo - ", regCredito.FechaDesdeDebito.ToShortDateString());
                lblDD.Left = btnPagar.Left;
                lblDD.Top = btnPagar.Top;
                btnPagar.Enabled = false;
                btnPagar.Visible = false;
                lblDD.Visible = true;
            }
        }

        private void Llena_Cuotas()
        {
            regCuotaList = regCredito.Cuotas.OrderBy(o => o.CuotaID).ToList();
            DateTime fTmp;
            decimal dTmp;
            int nTmp = 0;
            int nFila = 0;
            int nCol = 0;
            decimal dDeudaCuota = 0;
            decimal dDeudaPuni = 0;
            decimal dDeudaFecha = 0;
            decimal dDeudaTotal = 0;
            decimal dDeudaCuotaTot = 0;
            decimal nMoraTotal = 0;
            int nCuotasVenci = 0;
            int nFilaBoni = 0;
            string cTipoBoni = "";

            backColorList = Color.White;
            foreach (Cuota c in regCuotaList)
            {
                gridCuotas.Rows.Add();

                if( c.Deuda > 0)
                {
                    if (lblCredVenci.Text == "") lblCredVenci.Text = c.FechaVencimiento.ToShortDateString();
                }
                
                if (c.FechaVencimiento < DateTime.Now && c.Deuda > 0)
                {
                    gridCuotas.Rows[nFila].DefaultCellStyle.BackColor = Color.LightCoral;
                    dDeudaCuota = dDeudaCuota + c.Importe;
                    
                }
                else
                {
                    gridCuotas.Rows[nFila].DefaultCellStyle.BackColor = backColorList;
                }


                gridCuotas.Rows[nFila].Cells[nCol].Value = c.CuotaID.ToString(); nCol++; //0

                fTmp = c.FechaVencimiento;
                gridCuotas.Rows[nFila].Cells[nCol].Value = fTmp.ToShortDateString(); nCol++; //1

                dTmp = c.Importe;
                gridCuotas.Rows[nFila].Cells[nCol].Value = dTmp.ToString("N2"); nCol++; //2

                dTmp = c.ImportePago;
                gridCuotas.Rows[nFila].Cells[nCol].Value = dTmp.ToString("N2"); nCol++; //3

                dTmp = c.Deuda;
                dDeudaCuotaTot = dDeudaCuotaTot + dTmp;
                gridCuotas.Rows[nFila].Cells[nCol].Value = dTmp.ToString("N2"); nCol++; //4

                dTmp = Calcula_Punitorio(c.Deuda, c.FechaVencimiento, nPor30, nPor30M, false);
                gridCuotas.Rows[nFila].Cells[nCol].Value = dTmp.ToString("N2"); nCol++; //5
                dDeudaPuni = dDeudaPuni + dTmp;

                dTmp = dTmp + c.Deuda;
                gridCuotas.Rows[nFila].Cells[nCol].Value = dTmp.ToString("N2"); nCol++; //6
                if (dTmp > 0) gridCuotas.Rows[nFila].Cells[nCol - 1].Style.Font = new Font("Verdana", 7F, FontStyle.Bold);

                if (fTmp < DateTime.Now)
                {
                    dDeudaFecha = dDeudaFecha + dTmp;
                }
                dDeudaTotal = dDeudaTotal + dTmp;

                gridCuotas.Rows[nFila].Cells[nCol].Value = dDeudaTotal.ToString("N2"); nCol++; //7
                
                nTmp = 0;
                if (c.FechaUltimoPago != null)
                {
                    fTmp = Convert.ToDateTime(c.FechaUltimoPago);
                    gridCuotas.Rows[nFila].Cells[nCol].Value = fTmp.ToShortDateString(); nCol++; //8

                    nTmp = bl.Calcula_dias_mora(c.FechaVencimiento, fTmp);   // calcurar MORA
                }
                else
                {
                    gridCuotas.Rows[nFila].Cells[nCol].Value = ""; nCol++; //8
                    if (c.FechaVencimiento < DateTime.Now) nTmp = bl.Calcula_dias_mora(c.FechaVencimiento, DateTime.Now);   // calcurar MORA
                }

                if (c.FechaVencimiento < DateTime.Now)
                {
                    nMoraTotal = nMoraTotal + nTmp;
                    nCuotasVenci++;
                }
                gridCuotas.Rows[nFila].Cells[nCol].Value = nTmp.ToString("N0"); nCol++; //9
                dTmp = c.ValorBonificacion;
                if (dTmp > 0 && nFilaBoni == 0)
                {
                    nFilaBoni = nFila;
                    if (dTmp != c.Importe) cTipoBoni = "P"; else cTipoBoni = "C";

                }
                gridCuotas.Rows[nFila].Cells[nCol].Value = dTmp.ToString("N2"); nCol++; //10
                if (dTmp > 0)
                {
                    gridCuotas.Rows[nFila].Cells[nCol].Value = "B"; nCol++; //11
                }
                else
                {
                    gridCuotas.Rows[nFila].Cells[nCol].Value = ""; nCol++; //11
                }
                dTmp = c.Interes;
                gridCuotas.Rows[nFila].Cells[nCol].Value = dTmp.ToString("N2"); nCol++; //12

                if (backColorList == Color.White) backColorList = Color.LightGray; else backColorList = Color.White;
                nFila++;
                nCol = 0;

            }
            lblCredDeudaTotal.Text = dDeudaTotal.ToString();
            lblCredDeuda.Text = dDeudaCuotaTot.ToString();
            lblCredPuni.Text = dDeudaPuni.ToString();
            if (dDeudaTotal == 0)
            {
                lblMsgCancelado.Text = "Cancelado";
            }
            else
            {
                if (regCredito.Comercio.PuedeCobrar == true)
                {
                    if (string.IsNullOrEmpty(regCredito.NumCuentaBancaria))
                    {
                        btnPagar.Visible = true;
                        btnPagar.Enabled = true;
                    }
                    else
                    {
                        lblDD.Visible = true;
                        btnPagar.Visible = false;
                        btnPagar.Enabled = false;
                    }
                    if (regCredito.RefinanciacionID == null || regCredito.RefinanciacionID == 0)   //*nvo
                    {
                        if (bl.pGlob.Comercio.Refinancia == true)                   // ACA PERMISO PARA REFINANCIAR DEL COMERCIO
                        {
                            btnRefi.Visible = true;
                            //btnRefi.Enabled = true;
                        }
                    }

                }
            
                //gridCuotas.Visible = true;
            }
            if (nCuotasVenci > 0)
            {
                //lblCredMora.Text = (nMoraTotal / nCuotasVenci).ToString();
            }
            if (nFilaBoni > 0)
            {
                if (cTipoBoni == "C") gridCuotas.Rows[nFilaBoni - 1].Cells[11].Value = "X"; //else gridCuotas.Rows[nFilaBoni - 1].Cells[11].Value = "";
            }
            lblCreDeudaFecha.Text = dDeudaFecha.ToString("N2");
        }

        private void Configura_Inicio()
        {
            Configura_Controles();
            NumComercio = Com.ComercioID;
            this.Text = "Pago de cuotas"; // +NumComercio.ToString();
            txtBuscaCom.Text = NumComercio.ToString();
            Congigura_listas();
        }

        private void Configura_Controles()
        {
            Configura_Colores(bl.pGlob.Comercio.EmpresaID);
            Recorre_Formulario(this);
            this.BackColor = ColorBackColorFrm;
            Limpia_controles(panelBuscar);
            Centrar_Control(this, panelPagar);

            Centrar_Control(this, panelSelectComer);
            Asigna_Poder_Mover(panelSelectComer);
            Asigna_Poder_Mover(panelPagar);
            Centrar_Control(this, panelAyuda);
            Asigna_Poder_Mover(panelAyuda);
            gridRefinan.Top = gridCuotas.Top;
            gridRefinan.Left = gridCuotas.Left;
            listAntiCuotas.Width = panelAnticip.Width;
            Limpia();
            tabControl1.SelectedTab = tabPage1;


            lblAyuda.Text = "F2:  Paga varias cuotas" + Environment.NewLine +
                           "F3:  Pago anticipado" + Environment.NewLine +
                           "F4:  Cambia punitórios" + Environment.NewLine +
                           "F6:  Arreglo de pagos" + Environment.NewLine +
                           "F7:  Quita punitório" + Environment.NewLine +
                           "F8:  Permite Bonificar" + Environment.NewLine +
                           "F9 En Arreglo de pagos: Permite cambiar Mínimo" + Environment.NewLine +
                           "F10: Muestra cálculo anticipado" + Environment.NewLine +
                           "F11: Permite pago de crédito con Débito Directo" + Environment.NewLine +
                           "F12: Autoriza pago en abogado" + Environment.NewLine +
                           "SHIFT + F5: Cancela Refinancación"; // + Environment.NewLine +

        }
        private void Congigura_listas()
        {
            int nCol = 0;
            ////////////////////////////////////////////////////////////////////////////////    CUOTAS VARIAS
            nCol = 0;
            GridConfigInicio(gridPagoVarias, 13);
            GridAgregarCol(gridPagoVarias, nCol, "Cuota", 50, "D"); nCol++; //0
            GridAgregarCol(gridPagoVarias, nCol, "Importe", 65, "D"); nCol++; //1
            GridAgregarCol(gridPagoVarias, nCol, "Punitorios", 65, "D"); nCol++; //2
            GridAgregarCol(gridPagoVarias, nCol, "Bonificado", 65, "D"); nCol++; //3
            GridAgregarCol(gridPagoVarias, nCol, "Total", 65, "D"); nCol++; //4
            GridAgregarCol(gridPagoVarias, nCol, "Pago cuota", 65, "D"); nCol++; //5   
            GridAgregarCol(gridPagoVarias, nCol, "Pago punitorios", 65, "D"); nCol++; //6    
            GridAgregarCol(gridPagoVarias, nCol, "Bonificado", 65, "D"); nCol++; //7    
            GridAgregarCol(gridPagoVarias, nCol, "Total pago", 65, "D"); nCol++; //8 7    
            GridAgregarCol(gridPagoVarias, nCol, "tipo", 100, "I"); nCol++; //9 8
            GridAgregarCol(gridPagoVarias, nCol, "venci", 0, "I"); nCol++; //10 9
            GridAgregarCol(gridPagoVarias, nCol, "", 0, "I"); nCol++; //11 10
            GridAgregarCol(gridPagoVarias, nCol, "Acumulado", 0, "I"); nCol++; //12 11
            GridConfigFinal(gridPagoVarias, Color.DarkGray, 7, FontStyle.Regular);
            ////////////////////////////////////////////////////////////////////////////////    CUOTAS
            nCol = 0;
            GridConfigInicio(gridCuotas, 13);
            GridAgregarCol(gridCuotas, nCol, "Cuota", 50, "D"); nCol++; //0
            GridAgregarCol(gridCuotas, nCol, "Vencimiento", 70, "D"); nCol++; //1
            GridAgregarCol(gridCuotas, nCol, "Importe", 65, "D"); nCol++; //2
            GridAgregarCol(gridCuotas, nCol, "Pagado", 65, "D"); nCol++; //3
            GridAgregarCol(gridCuotas, nCol, "Deuda", 65, "D"); nCol++; //4
            GridAgregarCol(gridCuotas, nCol, "Punitorios", 65, "D"); nCol++; //5
            GridAgregarCol(gridCuotas, nCol, "Total", 65, "D"); nCol++; //6
            GridAgregarCol(gridCuotas, nCol, "Acumulado", 65, "D"); nCol++; //7
            GridAgregarCol(gridCuotas, nCol, "Fecha pago", 70, "D"); nCol++; //8
            GridAgregarCol(gridCuotas, nCol, "Mora", 60, "D"); nCol++; //9
            GridAgregarCol(gridCuotas, nCol, "Bonificado", 65, "D"); nCol++; //10
            GridAgregarCol(gridCuotas, nCol, "", 0, "I"); nCol++; //11
            GridAgregarCol(gridCuotas, nCol, "", 0, "I"); nCol++; //12
            GridConfigFinal(gridCuotas, Color.DarkGray, 7, FontStyle.Regular);

            ////////////////////////////////////////////////////////////////////////////////    COBRANZAS
            nCol = 0;
            GridConfigInicio(GridCobranzas, 10);
            GridAgregarCol(GridCobranzas, nCol, "Tipo pago", 100, "T"); nCol++; //0
            GridAgregarCol(GridCobranzas, nCol, "Cuota", 50, "D", "N"); nCol++; //1
            GridAgregarCol(GridCobranzas, nCol, "Pago cuota", 75, "D", "D"); nCol++; //2
            GridAgregarCol(GridCobranzas, nCol, "Pago punitorios", 75, "D", "D"); nCol++; //3
            GridAgregarCol(GridCobranzas, nCol, "Bonificado", 75, "D", "D"); nCol++; //4
            GridAgregarCol(GridCobranzas, nCol, "Total", 75, "D", "D"); nCol++; //5
            GridAgregarCol(GridCobranzas, nCol, "Fecha de pago", 75, "D", "F"); nCol++; //6   
            GridAgregarCol(GridCobranzas, nCol, "Días mora", 65, "D", "N"); nCol++; //7    
            GridAgregarCol(GridCobranzas, nCol, "Usuario", 80, "I"); nCol++; //8 
            GridAgregarCol(GridCobranzas, nCol, "", 0, "I"); nCol++; //9


            GridConfigFinal(GridCobranzas, Color.DarkGray, 7, FontStyle.Regular);
            ////////////////////////////////////////////////////////////////////////////////    REFIN
            nCol = 0;
            GridConfigInicio(gridRefinan, 13);
            GridAgregarCol(gridRefinan, nCol, "Cuota ref.", 50, "D"); nCol++; //0
            GridAgregarCol(gridRefinan, nCol, "Vencimiento", 70, "D"); nCol++; //1
            GridAgregarCol(gridRefinan, nCol, "Importe", 65, "D"); nCol++; //2
            GridAgregarCol(gridRefinan, nCol, "Pagado", 65, "D"); nCol++; //3
            GridAgregarCol(gridRefinan, nCol, "Deuda", 65, "D"); nCol++; //4
            GridAgregarCol(gridRefinan, nCol, "Punitorios", 65, "D"); nCol++; //5
            GridAgregarCol(gridRefinan, nCol, "Total", 65, "D"); nCol++; //6
            GridAgregarCol(gridRefinan, nCol, "Acumulado", 65, "D"); nCol++; //7
            GridAgregarCol(gridRefinan, nCol, "Fecha pago", 70, "D"); nCol++; //8
            GridAgregarCol(gridRefinan, nCol, "Mora", 60, "D"); nCol++; //9
            GridAgregarCol(gridRefinan, nCol, "", 0, "D"); nCol++; //10
            GridAgregarCol(gridRefinan, nCol, "", 0, "I"); nCol++; //11
            GridAgregarCol(gridRefinan, nCol, "", 0, "I"); nCol++; //12
            GridConfigFinal(gridRefinan, Color.DarkGray, 7, FontStyle.Regular);

            //////////////////////////////////////////////////////////////////////////////// 
            listSelec.View = View.Details;
            listSelec.Columns.Add("", 0, HorizontalAlignment.Right);
            listSelec.Columns.Add("", 0, HorizontalAlignment.Right);
            listSelec.Columns.Add("Crédito", 80, HorizontalAlignment.Right);
            listSelec.Columns.Add("Comercio", 80, HorizontalAlignment.Right);

            //////////////////////////////////////////////////////////////////////////////// 
            listAntiCuotas.View = View.Details;
            listAntiCuotas.Columns.Add("Cuota", 40, HorizontalAlignment.Right);             //1
            listAntiCuotas.Columns.Add("Importe", 60, HorizontalAlignment.Right);             //2
            listAntiCuotas.Columns.Add("Puni", 60, HorizontalAlignment.Right);             //3
            listAntiCuotas.Columns.Add("capital", 60, HorizontalAlignment.Right);           //4
            listAntiCuotas.Columns.Add("Int Nvo", 60, HorizontalAlignment.Right);             //5
            listAntiCuotas.Columns.Add("Suma", 80, HorizontalAlignment.Right);              //6


        }

        private void BtnBusca_Click(object sender, EventArgs e)
        {
            if (BtnBusca.Text == "Buscar")
            {
                nCreditoPagar = Convert.ToInt32(txtBuscaCred.Text);       //**EDU MOR**//
                nComercioPagar = Convert.ToInt32(txtBuscaCom.Text);       //**EDU MOR**//       
                Buscar_Credito(nCreditoPagar, nComercioPagar);
            }
            else
            {
                Limpia();
                tabControl1.SelectedTab = tabPage1;
                panelBuscar.Enabled = true;
                BtnBusca.Text = "Buscar";
                txtBuscaCred.Focus();
            }
        }

        private void Limpia()
        {
            bonificaManual = false;
            bCambiaMinimo = false;
            lblDD.Visible = false;
            Limpia_controles(panelCli);
            Limpia_controles(panelCobranzas);
            Limpia_controles(panelOtros);
            Limpia_controles(panelRefin);
            Limpia_controles(panelAnticip);
            Limpia_controles(panelArreglo);
            lblComNombre.Text = "";
            listAntiCuotas.Visible = false;

            panelSelectComer.Visible = false;
            panelPagar.Visible = false;
            lblSombra.Visible = false;
            lblPagQueHace.Text = "";
            gridCuotas.Rows.Clear();
            GridCobranzas.Rows.Clear();
            gridRefinan.Rows.Clear();
            gridRefinan.Visible = false;
            gridCuotas.Visible = true;

            //                              MENSAJES
            lblMsgAbogado.Text = "";
            lblMsgCamara.Text = "";
            lblMsgCancelado.Text = "";
            lblMsgTarjeta.Text = "";
            lblMsgRefinan.Text = "";
            Pone_toolTip("", "");
            lblRefinanciaActivo.Text = "";
            btnRefiMuestra.Text = "Ver cuotas";
            bAbogado = false;

            btnPagar.Visible = false;
            btnRefi.Visible = false;
            BtnImprimir.Visible = false;
            btnRefiMuestra.Visible = false;
            tabControl1.Enabled = true;

            picSoli.Image = null;
            cImagenesSoli = null;
            nImagenesSoli = 0;
            lblIma.Text = "";
            lblImaNombre.Text = "";
            panelIma.Visible = false;

            lblPuedeBoni.Text = "0";
            Application.DoEvents();
            //tabControl1.SelectedTab = tabPage1;
        }
        private void Pone_toolTip(string qTool, string qMsg)
        {
            if (qTool == "")
            {
                toolTipC.RemoveAll();
                toolTipC.ShowAlways = false;
                toolTipA.RemoveAll();
                toolTipA.ShowAlways = false;
                return;
            }
            toolTipA.AutoPopDelay = 5000;
            toolTipA.InitialDelay = 10;
            toolTipA.ReshowDelay = 500;
            toolTipA.ShowAlways = true;
            toolTipA.UseAnimation = true;
            toolTipA.IsBalloon = true;
            if (qTool == "CAMARA")
            {
                //toolTipC.AutoPopDelay = 5000;
                //toolTipC.InitialDelay = 10;
                //toolTipC.ReshowDelay = 500;
                //toolTipC.ShowAlways = true;
                //toolTipC.UseAnimation = true;
                //toolTipC.IsBalloon = true;
                toolTipC.SetToolTip(this.lblMsgCamara, qMsg);
            }
            if (qTool == "ABOGADO")
            {
                toolTipA.SetToolTip(this.lblMsgAbogado, qMsg);
            }
            if (qTool == "REFINANCIADO")
            {
                toolTipA.SetToolTip(this.lblMsgRefinan, qMsg);
            }
        }
        private void panelSelectComer_Move(object sender, EventArgs e)
        {
            System.Windows.Forms.Control elControl = (System.Windows.Forms.Control)sender;
            lblSombra.Width = elControl.Width;
            lblSombra.Height = elControl.Height - 10;
            lblSombra.Top = elControl.Top + 15;
            lblSombra.Left = elControl.Left + 5;
        }

        private void btnSelecCancel_Click(object sender, EventArgs e)
        {
            lblSombra.Visible = false;
            panelSelectComer.Visible = false;
        }

        private void listSelec_DoubleClick(object sender, EventArgs e)
        {
            foreach (ListViewItem aa in listSelec.SelectedItems)
            {
                txtBuscaCom.Text = aa.SubItems[1].Text;
                lblSombra.Visible = false;
                panelSelectComer.Visible = false;
                Buscar_Credito(Convert.ToInt32(aa.SubItems[0].Text), Convert.ToInt16(aa.SubItems[1].Text));
            }
        }

        private void panelOtros_Paint(object sender, PaintEventArgs e)
        {

        }
        private void Llena_Cobranzas(int nComer, int nCred)
        {
            //List<Cobranza> regCobranzaList;
            GridCobranzas.Rows.Clear();
            if (bEsPru)        //**EDU MOR**//
            {
                regCobranzaList = bl.dalPrueba.Get<Cobranza>(c => c.EmpresaID == BaseID
                                && c.ComercioID == nComer && c.CreditoID == nCred,
                                p => p.OrderBy(o => o.CuotaID).ThenBy(o => o.FechaPago)).ToList();
            }
            else
            {
                regCobranzaList = bl.Get<Cobranza>(c => c.EmpresaID == regComercio.EmpresaID
                                && c.ComercioID == nComer && c.CreditoID == nCred,
                                p => p.OrderBy(o => o.CuotaID).ThenBy(o => o.FechaPago)).ToList();

            } 
            if (regCobranzaList == null || regCobranzaList.Count == 0)
            {
                //BtnImprimir.Enabled = false;
                BtnImprimir.Visible = false;
                return;
            }
            //List<A_Plus_Cobranzas_Credito_Result> cob = bl.BuscaCobranzasPorCredito(1, nCred, nDocu, cDocu);
            if (regCobranzaList.Count == 0) return;
            int nFila = 0;
            int nCol = 0;
            decimal dTmp = 0;
            DateTime fTmp;
            decimal nPag = 0;
            decimal dPuni = 0;
            decimal dBoni = 0;
            decimal dTotal = 0;
            int nCuo = 0;
            int nTmp = 0;
            decimal dNC = 0;
            backColorList = Color.White;
            nCuo = (int)regCobranzaList[0].CuotaID;
            bool befec = false;
            bool bTarj = false;
            string cTmp;
            string cUsuN;

            foreach (Cobranza co in regCobranzaList)
            {
                if (nCuo != co.CuotaID)
                {
                    if (nPag == Convert.ToDecimal(lblCreImpCuota.Text)) backColorList = Color.LightSteelBlue; else backColorList = Color.LightCoral;
                    GridCobranzas.Rows.Add();
                    GridCobranzas.Rows[nFila].DefaultCellStyle.BackColor = Color.LightSteelBlue;
                    GridCobranzas.Rows[nFila].DefaultCellStyle.Font = new Font("Verdana", 7F, FontStyle.Bold);
                    GridCobranzas.Rows[nFila].Cells[nCol].Value = "TOTAL cuota"; nCol++; //0
                    GridCobranzas.Rows[nFila].Cells[nCol].Value = nCuo.ToString(); nCol++; //1
                    GridCobranzas.Rows[nFila].Cells[nCol].Value = nPag.ToString("N2"); nCol++; //2
                    GridCobranzas.Rows[nFila].Cells[nCol].Value = dPuni.ToString("N2"); nCol++; //3
                    GridCobranzas.Rows[nFila].Cells[nCol].Value = dBoni.ToString("N2"); nCol++; //4
                    GridCobranzas.Rows[nFila].Cells[nCol].Value = dTotal.ToString("N2"); nCol++; //5
                    if (nPag != Convert.ToDecimal(lblCreImpCuota.Text)) GridCobranzas.Rows[nFila].Cells[2].Style.BackColor = Color.LightCoral;
                    

                    nFila++;
                    nCuo = (int)co.CuotaID;
                    nCol = 0;
                    nPag = 0;
                    dPuni = 0;
                    dBoni = 0;
                    dTotal = 0;
                }
                GridCobranzas.Rows.Add();
                GridCobranzas.Rows[nFila].DefaultCellStyle.BackColor = Color.White;
                GridCobranzas.Rows[nFila].DefaultCellStyle.Font = new Font("Verdana", 7F, FontStyle.Regular);
                cUsuN = "";
                if (co.TipoPago != null) cUsuN = co.TipoPago.Nombre;

                cUsuN += "-" + bl.TipoCobranza(co);
                GridCobranzas.Rows[nFila].Cells[nCol].Value = cUsuN; nCol++; // parametrosBase.TiposPagos(co.TIPOPAG); nCol++; //0
                
                GridCobranzas.Rows[nFila].Cells[nCol].Value = co.CuotaID.ToString(); nCol++; //1
                nPag = nPag + (decimal)co.ImportePago;
                dTmp = (decimal)co.ImportePago;
                GridCobranzas.Rows[nFila].Cells[nCol].Value = dTmp.ToString("N2"); nCol++; //2
                dTmp = (decimal)co.ImportePagoPunitorios;
                dPuni = dPuni + dTmp;
                GridCobranzas.Rows[nFila].Cells[nCol].Value = dTmp.ToString("N2"); nCol++; //3
                dNC = 0;

                if(co.TipoBonificacionID !=null)
                {
                    dNC = dNotaCD(co);
                }
                 dBoni = dBoni + dNC;
                GridCobranzas.Rows[nFila].Cells[nCol].Value = dNC.ToString("N2"); nCol++; //4
                dTmp = (decimal)co.ImportePago + (decimal)co.ImportePagoPunitorios - dNC;
                dTotal = dTotal + dTmp;
                GridCobranzas.Rows[nFila].Cells[nCol].Value = dTmp.ToString("N2"); nCol++; //5
                fTmp = (DateTime)co.FechaPago;
                GridCobranzas.Rows[nFila].Cells[nCol].Value = fTmp.ToShortDateString(); nCol++; //6
                nTmp = bl.Calcula_dias_mora((DateTime)co.FechaVencimiento, (DateTime)co.FechaPago);   // calcurar MORA
                GridCobranzas.Rows[nFila].Cells[nCol].Value = nTmp.ToString(); nCol++; //7
                GridCobranzas.Rows[nFila].Cells[nCol].Value = co.Usuario.nombre; nCol++; //8


                cTmp = "";
                if (befec) cTmp = "Efectivo";
                if (bTarj) cTmp = cTmp + " Tarjeta";
                GridCobranzas.Rows[nFila].Cells[nCol].Value = co.CobranzaID.ToString(); ; nCol++; //9
                nFila++;
                nCol = 0;
            }

            GridCobranzas.Rows.Add();
            GridCobranzas.Rows[nFila].DefaultCellStyle.BackColor = Color.LightSteelBlue;
            GridCobranzas.Rows[nFila].DefaultCellStyle.Font = new Font("Verdana", 7F, FontStyle.Bold);
            GridCobranzas.Rows[nFila].Cells[nCol].Value = "TOTAL cuota"; nCol++; //0
            GridCobranzas.Rows[nFila].Cells[nCol].Value = nCuo.ToString(); nCol++; //1
            GridCobranzas.Rows[nFila].Cells[nCol].Value = nPag.ToString("N2"); nCol++; //2
            GridCobranzas.Rows[nFila].Cells[nCol].Value = dPuni.ToString("N2"); nCol++; //3
            GridCobranzas.Rows[nFila].Cells[nCol].Value = dBoni.ToString("N2"); nCol++; //4
            GridCobranzas.Rows[nFila].Cells[nCol].Value = dTotal.ToString("N2"); nCol++; //5
            if (nPag != Convert.ToDecimal(lblCreImpCuota.Text)) GridCobranzas.Rows[nFila].Cells[2].Style.BackColor = Color.LightCoral;
        }
        private decimal dNotaCD(Cobranza co)
        {
            decimal Not = 0;
            List<NotasCD> regNota;
            if (bEsPru)
            {
                regNota = bl.dalPrueba.GetNotasCD(n => n.EmpresaID == regCredito.EmpresaID
                                                        && n.CreditoID == regCredito.CreditoID
                                                        && n.ComercioID == regCredito.ComercioID
                                                        && n.CobranzaID == co.CobranzaID , nn => nn.OrderByDescending(c => c.Fecha)).ToList();
            }
            else
            {
                regNota = bl.GetNotasCD(n => n.EmpresaID == regCredito.EmpresaID
                                                        && n.CreditoID == regCredito.CreditoID
                                                        && n.ComercioID == regCredito.ComercioID
                                                        && n.CobranzaID == co.CobranzaID, nn => nn.OrderByDescending(c => c.Fecha)).ToList();
            }
            foreach (NotasCD cCD in regNota)
            {
                Not = Not + cCD.Importe;
            }
            return Not;
        }
        private void Llena_NotasCD()
        {
            List<NotasCD> regNota;
            decimal nNotas = 0;
            decimal nNotasTot = 0;
            if (bEsPru)
            {
                regNota = bl.dalPrueba.GetNotasCD(n => n.EmpresaID == regCredito.EmpresaID
                                                        && n.CreditoID == regCredito.CreditoID
                                                        && n.ComercioID == regCredito.ComercioID
                                                        , nn => nn.OrderByDescending(c => c.Fecha)).ToList();
            }
            else
            {
                regNota = bl.GetNotasCD(n => n.EmpresaID == regCredito.EmpresaID
                                                        && n.CreditoID == regCredito.CreditoID
                                                        && n.ComercioID == regCredito.ComercioID
                                                        , nn => nn.OrderByDescending(c => c.Fecha)).ToList();
            }
            foreach (NotasCD cCD in regNota) // nn)
            {
                nNotas = 0;
                if (cCD.TipoNota == "CREDITO") nNotas = nNotas + cCD.Importe; else nNotas = nNotas - cCD.Importe;
                if (lblOtroNC.Text == "")
                {
                    lblOtroNC.Text = cCD.TipoNota + ": " + nNotas.ToString("N2");
                }
                else
                {
                    lblOtroNC.Text = lblOtroNC.Text + Environment.NewLine + cCD.TipoNota + ": " + nNotas.ToString("N2");
                }
                nNotasTot = nNotasTot + nNotas;
                lblOtroNCPorq.Text = nNotasTot.ToString("N2");
            }
        }
        private void Llena_Refinanciacion()
        {

            regRefinanciacion = bl.Get<Refinanciacion>(Com.EmpresaID, r => r.EmpresaID == regCredito.EmpresaID && r.ComercioID == regCredito.ComercioID
                            && r.CreditoID == regCredito.CreditoID && r.EstadoID == bl.pGlob.Vigente.EstadoID).FirstOrDefault();

            if (regRefinanciacion == null) return;

            backColorList = Color.White;

            lblMsgRefinan.Text = "Refinanciado";
            int nTmp = 0;
            DateTime fTmp;
            decimal dTmp;
            int nFila = 0;
            int nCol = 0;
            decimal dDeudaCuota = 0;
            decimal nMoraTotal = 0;
            int nCuotasVenci = 0;
            decimal dDeudaTotal = 0;
            decimal dDeudaFecha = 0;
            decimal dDeudaPuni = 0;
            foreach (RefinanciacionCuota c in regRefinanciacion.RefinanciacionCuotas)
            {
                gridRefinan.Rows.Add();
                if (c.FechaVencimiento < DateTime.Now && c.Deuda > 0)
                {
                    //gridRefinan.Rows[nFila].DefaultCellStyle.BackColor = Color.LightCoral;
                    dDeudaCuota = dDeudaCuota + c.Importe;
                }
                //else
                //{
                    gridRefinan.Rows[nFila].DefaultCellStyle.BackColor = backColorList;
                //}


                gridRefinan.Rows[nFila].Cells[nCol].Value = c.RefinanciacionCuotaID.ToString(); nCol++; //0

                fTmp = c.FechaVencimiento;
                gridRefinan.Rows[nFila].Cells[nCol].Value = fTmp.ToShortDateString(); nCol++; //1

                dTmp = c.Importe;
                gridRefinan.Rows[nFila].Cells[nCol].Value = dTmp.ToString("N2"); nCol++; //2

                dTmp = c.ImportePago;
                gridRefinan.Rows[nFila].Cells[nCol].Value = dTmp.ToString("N2"); nCol++; //3

                dTmp = c.Deuda;
                gridRefinan.Rows[nFila].Cells[nCol].Value = dTmp.ToString("N2"); nCol++; //4

                dTmp = Calcula_Punitorio(c.Deuda, c.FechaVencimiento, nPor30, nPor30M, true);
                gridRefinan.Rows[nFila].Cells[nCol].Value = dTmp.ToString("N2"); nCol++; //5
                dDeudaPuni = dDeudaPuni + dTmp;

                dTmp = dTmp + c.Deuda;
                gridRefinan.Rows[nFila].Cells[nCol].Value = dTmp.ToString("N2"); nCol++; //6
                if (dTmp > 0) gridRefinan.Rows[nFila].Cells[nCol - 1].Style.Font = new Font("Verdana", 7F, FontStyle.Bold);

                if (fTmp < DateTime.Now)
                {
                    dDeudaFecha = dDeudaFecha + dTmp;
                }
                dDeudaTotal = dDeudaTotal + dTmp;

                gridRefinan.Rows[nFila].Cells[nCol].Value = dDeudaTotal.ToString("N2"); nCol++; //7

                nTmp = 0;
                if (c.FechaUltimoPago != null)
                {
                    fTmp = Convert.ToDateTime(c.FechaUltimoPago);
                    gridRefinan.Rows[nFila].Cells[nCol].Value = fTmp.ToShortDateString(); nCol++; //8

                    nTmp = bl.Calcula_dias_mora(c.FechaVencimiento, fTmp);   // calcurar MORA
                }
                else
                {
                    gridRefinan.Rows[nFila].Cells[nCol].Value = ""; nCol++; //8
                    if (c.FechaVencimiento < DateTime.Now) nTmp = bl.Calcula_dias_mora(c.FechaVencimiento, DateTime.Now);   // calcurar MORA
                }

                if (c.FechaVencimiento < DateTime.Now)
                {
                    nMoraTotal = nMoraTotal + nTmp;
                    nCuotasVenci++;
                }


                //dTmp = 0;   // calcurar MORA   FALTA
                gridRefinan.Rows[nFila].Cells[nCol].Value = nTmp.ToString("N0"); nCol++; //9
                //dTmp = c.ValorBonificacion;
                //if (dTmp > 0 && nFilaBoni == 0)
                //{
                //    nFilaBoni = nFila;
                //    if (dTmp != c.Importe) cTipoBoni = "P"; else cTipoBoni = "C";

                //}
                dTmp = 0;
                gridRefinan.Rows[nFila].Cells[nCol].Value = dTmp.ToString("N2"); nCol++; //10
                if (dTmp > 0)
                {
                    gridRefinan.Rows[nFila].Cells[nCol].Value = "B"; nCol++; //11
                }
                else
                {
                    gridRefinan.Rows[nFila].Cells[nCol].Value = ""; nCol++; //11
                }
                ////dTmp = c.Interes;
                gridRefinan.Rows[nFila].Cells[nCol].Value = dTmp.ToString("N2"); nCol++; //12

                if (backColorList == Color.White) backColorList = Color.LawnGreen; else backColorList = Color.White;
                nFila++;
                nCol = 0;
            }
            Pone_toolTip("REFINANCIADO"
                 ,"Ref: " + regRefinanciacion.RefinanciacionID + " Imp: " + regRefinanciacion.ValorNominal.ToString("N2")
                   + Environment.NewLine + regRefinanciacion.CantidadCuotas + " cuotas de: " + regRefinanciacion.ValorCuota.ToString("N2")
                   + Environment.NewLine + regRefinanciacion.Usuario.nombre);


                //    , regCredito.AbogadoID + " " + regCredito.Abogado.Nombre + Environment.NewLine + regCredito.FechaAbogado.ToShortDateString() + " tel:" + regCredito.Abogado.Telefono1);

            //lblOtroRefi.Text = "Ref: " + regRefinanciacion.RefinanciacionID + " Imp: " + regRefinanciacion.ValorNominal.ToString("N2")
            //       + Environment.NewLine + regRefinanciacion.CantidadCuotas + " cuotas de: " + regRefinanciacion.ValorCuota.ToString("N2")
            //       + Environment.NewLine + regRefinanciacion.Usuario.nombre; ;
            btnRefiMuestra.Visible = true;
            if (dDeudaTotal > 0)
            {
                //if (nDeudaT > 0)
                //{
                    gridCuotas.Visible = false;
                    gridRefinan.Visible = true;
                    //lblRefinanciaActivo.Text = regRefinanciacion.Estado.Nombre;// "Activo";
                    lblRefinanciaActivo.Text = bl.pGlob.Vigente.Nombre;

                //}
            }
            else
            {
                btnRefiMuestra.Text = "Ver refinanciación";
            }

        }

        private void btnRefiMuestra_Click(object sender, EventArgs e)
        {
            if (btnRefiMuestra.Text == "Ver cuotas")
            {
                btnRefiMuestra.Text = "Ver refinanciación";
                gridCuotas.Visible = true;
                gridRefinan.Visible = false;
            }
            else
            {
                btnRefiMuestra.Text = "Ver cuotas";
                gridCuotas.Visible = false;
                gridRefinan.Visible = true;
            }
        }

        private void btnCliModi_Click(object sender, EventArgs e)
        {
            if (lblCliDocu.Text == "" || lblCliDocu.Text == "0") return;
            Abre_Cliente(Convert.ToInt32(lblCliDocu.Text), lblCliCodDocu.Text);
        }
        private void Abre_Cliente(int nDocumento, string cDocumento)
        {
            frmClienteNVO frm = new frmClienteNVO(this.p, "M", nDocumento, cDocumento, lblMor.Visible);
            frm.WindowState = FormWindowState.Normal;
            frm.ShowDialog();
        }

        private void btnGarModi_Click(object sender, EventArgs e)
        {
            if (lblGarDocu.Text == "" || lblGarDocu.Text == "0") return;
            Abre_Cliente(Convert.ToInt32(lblGarDocu.Text), lblGarCodDocu.Text);
        }

        private void btnAdiModi_Click(object sender, EventArgs e)
        {
            if (lblAdiDocu.Text == "" || lblAdiDocu.Text == "0") return;
            Abre_Cliente(Convert.ToInt32(lblAdiDocu.Text), lblAdiCodDocu.Text);

        }

        private void frmCobranzaNva_KeyDown(object sender, KeyEventArgs e)
        {
            panelAyuda.Visible = false;
            lblSombra2.Visible = false;
            switch (e.KeyCode)
            {
                case Keys.F1:
                    Muestra_Ayuda();
                    break;
                case Keys.F2:                                               //VARIAS
                    if (panelPagar.Visible == false) return;
                    Prepara_PagoVarias();
                    break;
                case Keys.F3:                                           //"Pago anticipado"
                    if (panelPagar.Visible == false) return;
                    if (Busca_Permiso(bl.pGlob.Configuracion.permPagoAnticipado))
                    {
                        Prepara_Pago_Anticipado();
                    }
                    break;
                case Keys.F4:                                                       // CAMBIA PUNITORIOS
                    if (panelPagar.Visible == false || lblPagQueHace.Text != "NORMAL") return;
                    if (Busca_Permiso(bl.pGlob.Configuracion.permCambiaPunitorios))
                    {
                        lblPagoQue.Text = "Cambia punitórios";
                        Configura_Que_Paga(lblPagoQue.Text);
                    }
                    break;
                case Keys.F6:                                                                        //"Arreglos de pago"
                    if (panelPagar.Visible == false) return;
                    if (Busca_Permiso(bl.pGlob.Configuracion.permArregloPagos))
                    {
                        Prepara_Pago_Arreglo();
                    }
                    break;
                case Keys.F7:
                    if (panelPagar.Visible == false || lblPagQueHace.Text != "NORMAL") return;
                    if (Busca_Permiso(bl.pGlob.Configuracion.permQuitaPunitorios))
                    {
                        lblPagoQue.Text = "Quitar punitórios";
                        Configura_Que_Paga(lblPagoQue.Text);
                    }
                    break;
                case Keys.F8:                                                               //PERMITE BONIFICAR
                    lblPuedeBoni.Text = "0";
                    if (Busca_Permiso(bl.pGlob.Configuracion.permPermiteBonificar))
                    {
                        lblPuedeBoni.Text = "1";
                        this.bonificaManual = true;
                        btnPagar_Click(sender, e);
                        this.bonificaManual = false;
                    }
                    break;
                case Keys.F9:  
                    if (panelPagar.Visible == true)
                    {
                        bCambiaMinimo = false;
                        if (Busca_Permiso(bl.pGlob.Configuracion.permCambiaMinimo)) 
                        {
                            bCambiaMinimo = true;
                        }
                    }
                    break;
                case Keys.F10:
                    if (panelPagar.Visible)
                    {
                        listAntiCuotas.Visible = !listAntiCuotas.Visible;
                    }
                    break;
                case Keys.F11:
                    if (!string.IsNullOrEmpty(regCredito.NumCuentaBancaria))
                    {
                        if (Busca_Permiso(bl.pGlob.Configuracion.permCancelaRefi))  //cdc nvo_04/12/2019
                        {
                            btnPagar.Enabled = true;
                            btnPagar.Visible = true;
                            lblDD.Visible = false;
                        }
                    }
                    break;
                case Keys.F5:
                    if (e.Shift)
                    {
                        if (lblMsgRefinan.Text == "") return;
                        //if (Busca_Permiso(bl.pGlob.Configuracion.permCancelaRefi))
                        //{
                            Cancela_Refinanciacion();
                        //}
                    }
                    break;
                case Keys.Escape:
                    panelAyuda.Visible = false;
                    lblSombra2.Visible = false;
                    listAntiCuotas.Visible = false;
                    //if (panelPagar.Visible == false) return;
                    //lblPagoQue.Text = "Normal";
                    break;
            }

        }

        private void Muestra_Ayuda()
        {
            if (panelAyuda.Visible == false)
            {
                MuestraPanelConSombra(panelAyuda, lblSombra2, lblAyuda);
                //lblSombra2.Visible = false;
                return;
            }
            else
            {
                lblSombra2.Visible = false;
                panelAyuda.Visible = false;
            }
        }
        private void Recorre_Creditos(string cDesde, bool bPri = false)
        {
            if (bPri == false)
            {
                if (cDesde == "")
                {
                    nCuantoArray = 0;
                }
                else if (cDesde == "AD")
                {
                    nCuantoArray++;
                }
                else if (cDesde == "AT")
                {
                    if (nCuantoArray > 0)
                    {
                        nCuantoArray--;
                    }
                    else
                    {
                        nCuantoArray = (aCrediBusco.Length / 4) - 1;        //**EDU MOR**//
                    }
                }

                if (nCuantoArray > (aCrediBusco.Length / 4) - 1) nCuantoArray = 0;        //**EDU MOR**//
            }
            bEsPru = false;
            int aCred = Convert.ToInt32(aCrediBusco[nCuantoArray, 1]);
            int aComer = Convert.ToInt32(aCrediBusco[nCuantoArray, 2]);
            if (aCrediBusco[nCuantoArray, 3] == "M") bEsPru = true;

            int nTmp = nCuantoArray + 1;
            int nTmp2 = (aCrediBusco.Length / 4);        //**EDU MOR**//
            lblMsgCreds.Text = nTmp.ToString() + "/" + nTmp2.ToString();

            txtBuscaCred.Text = aCred.ToString();

            if (bEsPru)        //**EDU MOR**//
            {
                lblMor.Visible = true;
                txtBuscaCom.Text = Com.ComercioID.ToString();
            }
            else
            {
                lblMor.Visible = false;
                txtBuscaCom.Text = aComer.ToString();
            }        //**EDU MOR**//
            Limpia();
            nCreditoPagar = aCred;       //**EDU MOR**//
            nComercioPagar = aComer;       //**EDU MOR**//
            Buscar_Credito(aCred, aComer);
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            Recorre_Creditos("AT");
        }

        private void btnAdel_Click(object sender, EventArgs e)
        {
            Recorre_Creditos("AD");
        }

        private void BtnImprimirCobr_Click(object sender, EventArgs e)
        {
            Imprime_Cobr(false);
        }

        private void Imprime_Cobr(bool Soli)
        {
            List<Cobranza> cobSels = null;
            Dictionary<int, string> QueImprimo = new Dictionary<int, string>();
            if (Soli)
            {
                QueImprimo.Add(-1, "CREDITO");

            }
            else
            {

                QueImprimo.Add(0, "TODAS LAS COBRANZAS");
                int nCuotaID = Convert.ToInt16(GridCobranzas.Rows[nGriCob].Cells[1].Value);
                cobSels = regCobranzaList.FindAll(c => c.CuotaID == nCuotaID).OrderBy(c => c.FechaPago).ToList();
                foreach (Cobranza cob in cobSels)
                {
                    QueImprimo.Add(cob.CobranzaID, String.Format("COBR. :{0} {1} {2}", cob.CuotaID, cob.FechaPago.ToShortDateString(), cob.ImporteTotal));
                }
            }
            QueImprimo.Add(2, "CANCELAR");
            frmQueImprimo frmQI = new frmQueImprimo(this.p, this.bl, QueImprimo);
            frmQI.ShowDialog();

            if (frmQI.resp != null)
            {
                int[] QueImprimoArr = QueImprimo.Keys.ToArray();
                if (frmQI.resp == 2)
                {
                    return;
                }
                if (frmQI.resp == QueImprimoArr[0])//CREDITO
                {
                    bl.ImprimirAlta(regCredito, lblMor.Visible);
                }
                else if (frmQI.resp == QueImprimoArr[1])//TODAS LAS COBRANZAS
                {
                    foreach (Cobranza cob in cobSels)
                    {
                        bl.ImprimirCobranza(cob, lblMor.Visible);
                    }
                }
                else //IMPRIME COBRANZA SELECCIONADA
                {
                    Cobranza cob = cobSels.Find(c => c.CobranzaID == frmQI.resp.Value);
                    bl.ImprimirCobranza(cob, lblMor.Visible);
                }
            }            
        }

        private void GridCobranzas_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (GridCobranzas.Rows.Count > 0) BtnImprimirCobr.Enabled = true; else BtnImprimirCobr.Enabled = false;
            nGriCob = e.RowIndex;
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            Imprime_Cobr(true);
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            Prepara_Pago();
        }

        private void btnPagCerrar_Click(object sender, EventArgs e)
        {
            panelPagar.Visible = false;
            lblSombra.Visible = false;
            tabControl1.Enabled = true;
        }
        private void Prepara_Pago()
        {
            if (bAbogado)
            {
                MessageBox.Show("Crédito en abogado", "Abogado");
                return;
            }
            if (Busca_Permiso("cobranza") == true)
            {
                if (lblRefinanciaActivo.Text == bl.pGlob.Vigente.Nombre)
                {
                    Prepara_Pago_Refinanciado();
                    return;
                }
                Prepara_pago2();
            }


        }
        private void Prepara_pago2()
        {
            int nCuotaBonificada = 0;
            int nTmp0 = 0;
            decimal npu = 0;
            decimal dTmp = 0;
            int TolBoni = 0;
            lblPagoCuota.Text = "0";
            lblPagoImporte.Text = "0";
            lblPagoPunitorio.Text = "0";
            lblPagoTotal.Text = "0";
            txtPagoAPagar.Text = "0";
            lblPagoQue.Text = "";
            lblgrpPagar.Text = "";
            lblPagoMsg2.Text = "";
            lblPagoMsg.Text = "";
            lblPagoBoni.Text = "0";
            lblPagoBoni.Visible = false;
            lblPagoBoniM.Visible = false;
            lblCuotasBonificadas.Visible = false;
            lblCuotasBonificadas.Text = "";
            lblPagTit.Text = "";
            if (regCredito.TipoBonificacionID == "X")
            {
                nCuotaBonificada = regCredito.CantidadCuotas - Convert.ToInt32(regCredito.PorcentajeBonificacion);
            }
            else if (regCredito.TipoBonificacionID == "V" || regCredito.TipoBonificacionID == "C")
            {
                if (regCredito.PorcentajeBonificacion == 100)
                {
                    nCuotaBonificada = regCredito.CantidadCuotas - 1;
                }
                else
                {
                    nCuotaBonificada = regCredito.CantidadCuotas;
                }
            }
            foreach (Cuota cu in regCuotaList)
            {
                if (cu.Deuda > 0)
                {
                    lblPagoCuota.Text = cu.CuotaID.ToString();
                    lblPagoImporte.Text = Convert.ToString(cu.Deuda); // ToString();
                    lblPagoCalcImp.Text = Convert.ToString(cu.Deuda); // ToString();
                    npu = Calcula_Punitorio(cu.Deuda, cu.FechaVencimiento, nPor30, nPor30M, false);
                    lblPagoPunitorio.Text = npu.ToString("N2");
                    lblPagoCalcPuni.Text = npu.ToString("N2");
                    dTmp = cu.Deuda + npu;
                    lblPagoTotal.Text = dTmp.ToString("N2"); // Convert.ToString(cu.Deuda + npu);
                    txtPagoAPagar.Text = dTmp.ToString("N2"); // Convert.ToString(cu.Deuda + npu);

                    //if(cu.ValorBonificacion>0)
                    if (nCuotaBonificada == cu.CuotaID)
                    {
                        // if (bl.Calcula_dias_mora(cu.FechaVencimiento,DateTime.Now) <= Com.ToleranciaBoni)
                        if (Com.ToleranciaBoni != null)
                            TolBoni = Com.ToleranciaBoni.Value;
                        if (bl.PuedeBonificar(cu.Credito, TolBoni, nCuotaBonificada) || bonificaManual)
                        {
                            if (nCuotaBonificada == cu.CuotaID)
                            {
                                if (regCredito.TipoBonificacionID == "V" || regCredito.TipoBonificacionID == "C")
                                {
                                    lblPagoBoni.Text = cu.ValorBonificacion.ToString();
                                    lblPagoBoni.Visible = true;
                                    lblPagoBoniM.Visible = true;
                                }
                                else if (regCredito.TipoBonificacionID == "X")
                                {
                                    nTmp0 = Convert.ToInt32(regCredito.PorcentajeBonificacion);
                                    lblCuotasBonificadas.Text = "Cuotas bonificadas: " + nTmp0.ToString();
                                    lblCuotasBonificadas.Visible = true;
                                    lblPagoBoni.Text = regCredito.ValorBonificacion.ToString();
                                    lblPagoBoni.Visible = true;
                                    lblPagoBoniM.Visible = true;
                                }
                            }
                        }else
                        {
                            lblCuotasBonificadas.Text = "No se bonificará elcrédito. Tolerancia " + TolBoni.ToString() + "días";
                            lblCuotasBonificadas.Visible = true;
                        }
                    }
                    lblgrpPagar.Text = "pago cuota " + cu.CuotaID.ToString();
                    lblPagTit.Text = "pago cuota " + cu.CuotaID.ToString();
                    //lblSombra.Width = grpPagar.Width;
                    //lblSombra.Height = grpPagar.Height - 10;
                    //lblSombra.Top = grpPagar.Top + 15;
                    //lblSombra.Left = grpPagar.Left + 5;
                    //lblSombra.Visible = true;
                    //grpPagar.Visible = true;
                    //grpPagar.BringToFront();

                    lblPagoMsg.Text = "Cancela cuota";
                    lblPagQueHace.Text = "NORMAL";
                    //txtPagoAPagar.Focus();
                    tablaPagar.SelectTab("tabNormal");
                    MuestraPanelConSombra(panelPagar, lblSombra, txtPagoAPagar);
                    tabControl1.Enabled = false;
                    break;
                }
            }
             lblPagoQue.Text = "Normal";
            //btnPagar.Enabled = false;
        }
        private bool Busca_Permiso(string qq)
        {
            if (bl.pGlob.Configuracion.AutenticaCobranza
               || qq == bl.pGlob.Configuracion.permCancelaRefi
               || qq == bl.pGlob.Configuracion.permHabilitaPagoDebitoDirecto
               || qq == bl.pGlob.Configuracion.permArregloPagos
               || qq == bl.pGlob.Configuracion.permCambiaMinimo
               || qq == bl.pGlob.Configuracion.permCambiaPunitorios
               || qq == bl.pGlob.Configuracion.permPagoAnticipado
               || qq == bl.pGlob.Configuracion.permPermiteBonificar
               || qq == bl.pGlob.Configuracion.permQuitaPunitorios)
            {
                FrmClave frmclave = new FrmClave(p, this.bl, qq);
                frmclave.ShowDialog();
                if (p.usuIDAutorizado != 0)
                    return true;
                return false;
            }
            else
            {
                p.usuIDAutorizado = p.usu.UsuarioID;
                return true;
            }
        }

        private void txtPagoAPagar_KeyUp(object sender, KeyEventArgs e)
        {
            Calcula_Imp_Puni();
            lblgrpPagar.Text = "";
            if (Convert.ToDecimal(txtPagoAPagar.Text) > Convert.ToDecimal(lblPagoTotal.Text))
            {
                lblgrpPagar.Text = "Pago mayor cuota";
            }
            else lblgrpPagar.Text = "";   
        }
        private void Calcula_Imp_Puni()
        {
            decimal aTmp1 = 0;
            decimal aTmp2 = 0;
            decimal aTmp3 = 0;

            BtnPagoPagar.Enabled = false;
            lblPagoCalcImp.Text = "0";
            lblPagoCalcPuni.Text = "0";
            lblPagoMsg.Text = "Ingrese importe";
            lblPagoBoni.Visible = false;
            lblCuotasBonificadas.Visible = false;
            if (txtPagoAPagar.Text == "" || txtPagoAPagar.Text == null)
            {
                txtPagoAPagar.Text = "0";
                return;
            }
            try
            {
                decimal CalcImp = Convert.ToDecimal(txtPagoAPagar.Text);
                if (CalcImp == 0) return;
                if (CalcImp > Convert.ToDecimal(lblPagoTotal.Text))
                {
                    if (lblPagoQue.Text != "Cambia punitórios")
                    {
                        lblPagoCalcImp.Text = lblPagoImporte.Text;
                        aTmp1 = CalcImp - Convert.ToDecimal(lblPagoCalcImp.Text);   //Convert.ToDecimal(lblPagoTotal.Text);
                        lblPagoCalcPuni.Text = aTmp1.ToString("N2");
                        lblPagoMsg.Text = "Cancela cuota";
                        BtnPagoPagar.Enabled = true;
                        return;
                    }
                    else
                    {
                        lblPagoCalcImp.Text = lblPagoImporte.Text;

                        aTmp1 = Convert.ToDecimal(txtPagoAPagar.Text) - Convert.ToDecimal(lblPagoCalcImp.Text);
                        lblPagoCalcPuni.Text = aTmp1.ToString();
                    }
                }
                if (CalcImp == Convert.ToDecimal(lblPagoTotal.Text))
                {
                    lblPagoCalcImp.Text = lblPagoImporte.Text;
                    lblPagoCalcPuni.Text = lblPagoPunitorio.Text;
                    if (lblPagoBoni.Text != "0")
                    {
                        lblPagoBoni.Visible = true;
                        lblCuotasBonificadas.Visible = true;
                    }
                    lblPagoMsg.Text = "Cancela cuota";
                    BtnPagoPagar.Enabled = true;
                    return;
                }
                else if (CalcImp > Convert.ToDecimal(lblPagoTotal.Text))
                {
                    if (lblPagoQue.Text == "Cambia punitórios")
                    {
                        lblPagoMsg.Text = "Cancela cuota";
                        BtnPagoPagar.Enabled = true;
                        return;
                    }

                }

                if (Convert.ToDecimal(lblPagoPunitorio.Text) > 0)
                {

                    aTmp1 = Convert.ToDecimal(lblPagoImporte.Text) * CalcImp;
                    aTmp2 = Convert.ToDecimal(lblPagoImporte.Text) + Convert.ToDecimal(lblPagoPunitorio.Text);
                    if (CalcImp < 15)
                    {
                        aTmp3 = Convert.ToDecimal((aTmp1 / aTmp2));
                    }
                    else
                    {
                        aTmp3 =Convert.ToDecimal(Redondeo_Abajo(aTmp1 / aTmp2));
                    }
                    lblPagoCalcImp.Text = aTmp3.ToString("N2");
                    aTmp1 = CalcImp - aTmp3;
                    lblPagoCalcPuni.Text = aTmp1.ToString("N2");
                    lblPagoMsg.Text = "Pago a cuenta";
                }
                else
                {
                    lblPagoCalcImp.Text = CalcImp.ToString("N2");
                    aTmp1 = 0; // CalcImp - aTmp3;
                    lblPagoCalcPuni.Text = aTmp1.ToString("N2");
                    lblPagoMsg.Text = "Pago a cuenta";
                }

                BtnPagoPagar.Enabled = true;
                return;
            }
            catch
            { BtnPagoPagar.Enabled = false; }
        }
        private void Configura_Que_Paga(string qP)
        {
            decimal cuantoPago = 0;
            decimal cuantoPuni = 0;
            decimal cuantoCuota = 0;
            switch (qP)
            {
                case "Cambia punitórios":
                    cuantoCuota = Convert.ToDecimal(lblPagoImporte.Text);
                    cuantoPago = (Convert.ToDecimal(lblPagoImporte.Text) + Convert.ToDecimal(lblPagoTotal.Text)) / 2; // + (Convert.ToDecimal()) / 2;
                    cuantoPago = Convert.ToDecimal(Redondeo(cuantoPago));
                    cuantoPuni = Convert.ToDecimal((cuantoPago - Convert.ToDecimal(lblPagoImporte.Text)));
                    if (tabRefin.Visible)
                    {
                        //lblPagoQueR.Text = "Cambia punitórios";
                    }
                    else
                    {
                        lblPagoMin.Text = cuantoPuni.ToString("N2");
                        lblPagoMsg2.Text = "Pago mínimo: " + Redondeo(cuantoPago);
                        lblPagoPunitorio.Text = cuantoPuni.ToString("N2");
                        lblPagoTotal.Text = cuantoPago.ToString("N2");
                        //cuantoPago = cuantoPuni + cuantoPago;
                        txtPagoAPagar.Text = cuantoPago.ToString("N2");
                    }
                    break;
                case "Quitar punitórios":
                    if (tabRefin.Visible)
                    {
                        //lblPagoQueR.Text = "Sin punitorios";
                        //lblPagoPunitorioR.Text = "0";
                        //lblPagoTotalR.Text = lblPagoImporteR.Text;
                        //lblPagoCalcPuniR.Text = "0";
                        //txtPagoAPagarR.Text = lblPagoImporteR.Text;
                    }
                    else
                    {
                        lblPagoMin.Text = cuantoPuni.ToString("N2");
                        lblPagoMsg2.Text = "Sin punitorios";
                        lblPagoPunitorio.Text = "0";
                        lblPagoTotal.Text = lblPagoImporte.Text;
                    }
                    break;
            }
        }

        private void Prepara_Pago_Refinanciado()
        {
            decimal npu = 0;
            if (regRefinanciacion == null) return;
            lblPagoCuotaR.Text = "0";
            lblPagoImporteR.Text = "0";
            lblPagoPunitorioR.Text = "0";
            lblPagoTotalR.Text = "0";
            txtPagoAPagarR.Text = "0";
            lblPagoQueR.Text = "";

            lblgrpRefi.Text = "";
            lblPagoQueR.Text = "";
            lblPagoMsg2R.Text = "";
            lblPagoMsgR.Text = "";

            foreach (RefinanciacionCuota cu in regRefinanciacion.RefinanciacionCuotas)
            {
                if (cu.Deuda > 0)
                {
                    lblPagoCuotaR.Text = cu.RefinanciacionCuotaID.ToString();
                    lblPagoImporteR.Text = Convert.ToString(cu.Deuda); // ToString();
                    lblPagoCalcImpR.Text = Convert.ToString(cu.Deuda); // ToString();
                    lblRefEmp.Text = cu.EmpresaID.ToString();
                    lblRefComer.Text = cu.ComercioID.ToString();
                    lblRefCred.Text = cu.RefinanciacionID.ToString();


                    npu = Calcula_Punitorio(cu.Deuda, cu.FechaVencimiento, nPor30, nPor30M, true);
                    lblPagoPunitorioR.Text = npu.ToString("N2");
                    lblPagoCalcPuniR.Text = npu.ToString("N2");
                    lblPagoTotalR.Text = Convert.ToString(cu.Deuda + npu);
                    txtPagoAPagarR.Text = Convert.ToString(cu.Deuda + npu);



                    lblgrpRefi.Text = "Pago cuota refinanciada " + cu.RefinanciacionCuotaID.ToString();
                    lblPagQueHace.Text = "REFINAN";
                    lblPagTit.Text = "Pago refinanciado";
                    tablaPagar.SelectTab("tabRefin");
                    MuestraPanelConSombra(panelPagar, lblSombra, txtPagoAPagarR);
                    tabControl1.Enabled = false;
                    //txtPagoAPagarR.Focus();
                    break;
                }
            }
            lblPagoQueR.Text = "Normal";
            btnPagar.Enabled = false;
            Calcula_Imp_Puni_Refinanciado();
        }
        private void Calcula_Imp_Puni_Refinanciado()
        {
            decimal aTmp1 = 0;
            decimal aTmp2 = 0;
            decimal aTmp3 = 0;

            BtnPagoPagarR.Enabled = false;
            lblPagoCalcImpR.Text = "0";
            lblPagoCalcPuniR.Text = "0";
            lblPagoMsgR.Text = "Ingrese importe";
            if (txtPagoAPagarR.Text == "" || txtPagoAPagarR.Text == null) return;

            try
            {
                decimal CalcImp = Convert.ToDecimal(txtPagoAPagarR.Text);
                if (CalcImp == 0) return;
                if (lblPagoQueR.Text == "Cambia punitórios")
                {
                    lblPagoCalcImpR.Text = lblPagoImporteR.Text;
                    aTmp1 = Convert.ToDecimal(txtPagoAPagarR.Text) - Convert.ToDecimal(lblPagoCalcImpR.Text);
                    lblPagoCalcPuniR.Text = aTmp1.ToString();

                    if (CalcImp > Convert.ToDecimal(lblPagoImporteR.Text))
                    {
                        lblPagoMsgR.Text = "Cancela cuota";
                        BtnPagoPagarR.Enabled = true;
                        return;
                    }
                    if (CalcImp < Convert.ToDecimal(lblPagoImporteR.Text))
                    {
                        lblPagoMsgR.Text = "Pago menor cuota";
                        return;
                    }
                    if (CalcImp == Convert.ToDecimal(lblPagoImporteR.Text))
                    {
                        lblPagoCalcImpR.Text = lblPagoImporteR.Text;
                        lblPagoCalcPuniR.Text = "0";
                        lblPagoMsgR.Text = "Cancela cuota";
                        BtnPagoPagarR.Enabled = true;
                        return;

                    }
                }
                else
                {
                    if (lblPagoQueR.Text == "Sin punitorios")
                    {
                        if (CalcImp > Convert.ToDecimal(lblPagoImporteR.Text))
                        {
                            lblPagoMsgR.Text = "Pago mayor cuota";
                            return;
                        }
                        if (CalcImp < Convert.ToDecimal(lblPagoImporteR.Text))
                        {
                            lblPagoCalcImpR.Text = txtPagoAPagarR.Text;
                            lblPagoMsgR.Text = "Pago a cuenta";
                            //return;
                        }
                        if (CalcImp == Convert.ToDecimal(lblPagoImporteR.Text))
                        {
                            lblPagoCalcImpR.Text = lblPagoImporteR.Text;
                            lblPagoCalcPuniR.Text = "0";
                            lblPagoMsgR.Text = "Cancela cuota";
                            BtnPagoPagarR.Enabled = true;
                            return;

                        }
                    }
                }
                if (CalcImp > Convert.ToDecimal(lblPagoTotalR.Text))
                {
                    lblPagoMsgR.Text = "Pago mayor cuota";
                    return;
                }
                if (lblPagoQueR.Text == "Cambia punitórios")
                {
                }
                else
                {
                    if (CalcImp == Convert.ToDecimal(lblPagoTotalR.Text))
                    {
                        lblPagoCalcImpR.Text = lblPagoImporteR.Text;
                        lblPagoCalcPuniR.Text = lblPagoPunitorioR.Text;
                        lblPagoMsgR.Text = "Cancela cuota";
                        BtnPagoPagarR.Enabled = true;
                        return;
                    }

                    aTmp1 = Convert.ToDecimal(lblPagoImporteR.Text) * CalcImp;
                    aTmp2 = Convert.ToDecimal(lblPagoImporteR.Text) + Convert.ToDecimal(lblPagoPunitorioR.Text);
                    if (CalcImp < 15)
                    {
                        aTmp3 = Convert.ToDecimal((aTmp1 / aTmp2));
                    }
                    else
                    {
                        aTmp3 = Convert.ToDecimal(Redondeo_Abajo(aTmp1 / aTmp2));
                    }

                    lblPagoCalcImpR.Text = aTmp3.ToString("N2");
                    aTmp1 = CalcImp - aTmp3;
                    lblPagoCalcPuniR.Text = aTmp1.ToString("N2");
                    lblPagoMsgR.Text = "Pago a cuenta";
                }
                BtnPagoPagarR.Enabled = true;
                return;
            }
            catch
            { }
        }

        private void txtPagoAPagarR_KeyUp(object sender, KeyEventArgs e)
        {
            Calcula_Imp_Puni_Refinanciado();
        }
        //private void Prepara_PagoVariasXXXX()
        //{
        //    lblVariasCancelar.Text = "0";
        //    if (lblPuedeBoni.Text == "1") return;
        //    decimal dAcumulado = 0;
        //    decimal dApagar = 0;
        //    gridPagoVarias.Rows.Clear();
        //    txtPagoVarias.Text = "0";
        //    int nFila = 0;
        //    int TolBoni = 0;
        //    backColorList = Color.White;
        //    decimal dPorCuota = 0;
        //    decimal dPorPuni = 0;
        //    decimal dPorBoni = 0;
        //    decimal dTotal = 0;

        //    foreach (DataGridViewRow d in gridCuotas.Rows)
        //    {
        //        if (Convert.ToDecimal(d.Cells[4].Value) > 0)
        //        {
        //            gridPagoVarias.Rows.Add();
        //            gridPagoVarias.Rows[nFila].DefaultCellStyle.BackColor = backColorList;
        //            gridPagoVarias.Rows[nFila].Cells[0].Value = d.Cells[0].Value;    //cuota
        //            gridPagoVarias.Rows[nFila].Cells[1].Value = d.Cells[4].Value;   //deuda cuota
        //            gridPagoVarias.Rows[nFila].Cells[2].Value = d.Cells[5].Value;   //punitorios
        //            gridPagoVarias.Rows[nFila].Cells[3].Value = d.Cells[10].Value;   //punitorios
        //            dPorCuota = Convert.ToDecimal(d.Cells[4].Value);
        //            dPorPuni = Convert.ToDecimal(d.Cells[5].Value);
        //            dPorBoni = Convert.ToDecimal(d.Cells[10].Value);
        //            dApagar = 0;
        //            if (lblPuedeBoni.Text == "1") bonificaManual = true;
        //            if (Convert.ToDecimal(d.Cells[10].Value) > 0)
        //            {
        //                if (Com.ToleranciaBoni != null)
        //                    TolBoni = Com.ToleranciaBoni.Value;
        //                if (bl.PuedeBonificar(regCredito, TolBoni, Convert.ToInt16(d.Cells[0].Value.ToString())) || bonificaManual)
        //                {
        //                    gridPagoVarias.Rows[nFila].Cells[3].Value = d.Cells[10].Value;
        //                }
        //                else
        //                {
        //                    dApagar = Convert.ToDecimal(d.Cells[4].Value) + Convert.ToDecimal(d.Cells[5].Value);
        //                }

        //            }
        //            else if (Convert.ToDecimal(d.Cells[10].Value) == 0)
        //            {
        //                dApagar = Convert.ToDecimal(d.Cells[6].Value);
        //            }
        //            else
        //            {
        //                dApagar = Convert.ToDecimal(d.Cells[6].Value);// -Convert.ToDecimal(d.Cells[10].Value);
        //            }
        //            dAcumulado = dAcumulado + dApagar;
        //            gridPagoVarias.Rows[nFila].Cells[4].Value = dApagar.ToString("N2");


        //            gridPagoVarias.Rows[nFila].Cells[5].Value = "0";
        //            gridPagoVarias.Rows[nFila].Cells[6].Value = "0";
        //            gridPagoVarias.Rows[nFila].Cells[7].Value = "0";   //aca
        //            gridPagoVarias.Rows[nFila].Cells[8].Value = "0";   //aca
        //            gridPagoVarias.Rows[nFila].Cells[9].Value = "";
        //            gridPagoVarias.Rows[nFila].Cells[10].Value = d.Cells[1].Value;
        //            gridPagoVarias.Rows[nFila].Cells[11].Value = d.Cells[11].Value;
        //            gridPagoVarias.Rows[nFila].Cells[12].Value = dAcumulado.ToString("N2");
        //            if (backColorList == Color.White) backColorList = Color.LightGray; else backColorList = Color.White;
        //            nFila++;
        //            //nCol = 0;

        //        }
        //    }

        //    lblVariasCancelar.Text = dAcumulado.ToString("N2");
        //    lblPagTit.Text = "Pago varias cuotas";
        //    lblPagQueHace.Text = "VARIAS";
        //    tablaPagar.SelectTab("tabVarias");
        //    //MuestraPanelConSombra(panelPagar, lblSombra, txtPagoVarias);
        //    tabControl1.Enabled = false;
        //    //Auxiliar.Formatos.MuestraPanelConSombra(panelVarias, lblSombra, txtPagoVarias);
        //}
        private void Prepara_Pago_Anticipado()
        {
            int nCuantasCan = 0;
            int nCuantasSCan = 0;
            TimeSpan ndias;
            decimal CapPorCuota = regCredito.ValorNominal / regCredito.CantidadCuotas;
            decimal nAPagar = 0;
            decimal nDescuento = 0;
            decimal nTmp1 = 0;
            decimal nTmp2 = 0;
            decimal nTmp3 = 0;
            int nCuotas = 0;
            decimal nPun = 0;
            decimal nSumaImpNvo = 0;
            btnModAnti.Text = "Modificar";
            txtApagarMod.Visible = false;
            txtApagarMod.Enabled = false;

            Font nvaFuente = new Font("Verdana", 7.25F, FontStyle.Regular);
            backColorList = Color.White;
            listAntiCuotas.Items.Clear();
            foreach (Cuota cu in regCuotaList)
            {

                nAPagar = cu.Deuda; // cu.Importe - cu.ImportePago;
                if (nAPagar == 0)
                {
                    nCuantasCan++;
                }
                else
                {
                    nCuotas++;
                    nPun = 0;
                    ndias = cu.FechaVencimiento - DateTime.Now;
                    //1
                    ListViewItem item = new ListViewItem(cu.CuotaID.ToString());
                    item.UseItemStyleForSubItems = false;
                    //2
                    item.SubItems.Add(nAPagar.ToString("N2"), fontColor, backColorList, nvaFuente);
                    //3
                    nPun = Calcula_Punitorio(cu.Deuda, cu.FechaVencimiento, nPor30, nPor30M, false);
                    item.SubItems.Add(nPun.ToString("N2"), fontColor, backColorList, nvaFuente);
                    if (ndias.Days > 30)
                    {
                        nCuantasSCan++;
                        //4
                        item.SubItems.Add(CapPorCuota.ToString("N2"), fontColor, backColorList, nvaFuente);
                        //5
                        nTmp1 = (CapPorCuota * nIntADel) / 100;
                        item.SubItems.Add(nTmp1.ToString("N2"), fontColor, backColorList, nvaFuente);
                       //6    Descuento = valcuota - ( capital + (Capital * int / 100))
                        nTmp2 = CapPorCuota + nTmp1;
                        //nDescuento = nDescuento + nTmp2;
                        nDescuento = nDescuento + (cu.Importe - nTmp2);
                        //nTmp3 = cu.Importe - nTmp2;
                        nTmp3 = nTmp2;
                        item.SubItems.Add(nTmp3.ToString("N2"), fontColor, backColorList, nvaFuente);
                        nSumaImpNvo = nSumaImpNvo + nTmp3;
                    }
                    else
                    {
                        //nCuantasSCan++;
                        //4
                        item.SubItems.Add("0", fontColor, backColorList, nvaFuente);
                        //5
                        item.SubItems.Add("0", fontColor, backColorList, nvaFuente);
                        //6
                        nTmp2 = cu.Deuda + nPun;
                        item.SubItems.Add(nTmp2.ToString("N2"), fontColor, backColorList, nvaFuente);
                        nSumaImpNvo = nSumaImpNvo + nTmp2;
                    }
                    listAntiCuotas.Items.Add(item);
                    if (backColorList == Color.White) backColorList = Color.LightSteelBlue; else backColorList = Color.White;
                }
            }

            int CuotasMinimas = Com.CantCuoArr ?? 0;
            if (nCuantasCan < CuotasMinimas)
            {
                MessageBox.Show("Debe tener " + CuotasMinimas.ToString() + " cuotas canceladas", "Cobranzas");
                return;
            }

            if (nCuantasSCan < 1)
            {
                MessageBox.Show("No hay cuotas para pagar con anticipación", "Cobranzas");
                return;
            }
            Agrega_linea("a1", true, 6);
            listAntiCuotas.Items[listAntiCuotas.Items.Count - 1].SubItems[4].Text = "% " + nIntADel.ToString("N2");
            listAntiCuotas.Items[listAntiCuotas.Items.Count - 1].SubItems[5].Text = nSumaImpNvo.ToString("N2");
            listAntiCuotas.OwnerDraw = true;
            listAntiCuotas.BackColor = Color.White;
            listAntiCuotas.ForeColor = Color.Black;
            listAntiCuotas.FullRowSelect = true;
            listAntiCuotas.View = View.Details;

            //
            lblAntiCuotas.Text = nCuotas.ToString();
            lblAntiDeuda.Text = lblCredDeudaTotal.Text;




            nTmp1 = Redondeo(nSumaImpNvo); // Convert.ToDecimal(lblCredDeudaTotal.Text) - nDescuento;
            //nTmp1 = Redondeo(nTmp1);
            nDescuento = Convert.ToDecimal(lblCredDeudaTotal.Text) -  nTmp1;
            lblAntiDescuento.Text = nDescuento.ToString("N2");
            
            
            lblAntiAPagar.Text = nTmp1.ToString("N2");
            txtApagarMod.Text = nTmp1.ToString("N2");
            
            
            listAntiCuotas.Visible = false;
            //grpPagar.Visible = false;
            btnModAnti.Enabled = true;
            txtApagarMod.Enabled = true;
            //lblSombra.Width = grpPagarAnticip.Width - 10;
            //lblSombra.Height = grpPagarAnticip.Height - 10;
            //lblSombra.Top = grpPagarAnticip.Top + 15;
            //lblSombra.Left = grpPagarAnticip.Left + 5;
            //lblSombra.Visible = false;
            //grpPagarAnticip.Visible = true;
            lblPagoMsg.Text = "Cancela crédito";
            lblPagTit.Text = "Pago anticipado";
            lblPagQueHace.Text = "ANTICIPADO";
            tablaPagar.SelectTab("tabAnticip");
            //MuestraPanelConSombra(panelPagar, lblSombra, btnAntiPagar);
            tabControl1.Enabled = false;
            return;
        }
        private void Agrega_linea(string cc, bool negrita, int CantCol)
        {
            Font fontList;
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

            listAntiCuotas.Items.Add(item);
        }

        private void btnModAnti_Click(object sender, EventArgs e)
        {
            if (btnModAnti.Text == "Modificar")
            {
                btnModAnti.Text = "Aceptar";
                txtApagarMod.Visible = true;
                txtApagarMod.Enabled = true;
            }
            else
            {
                if (ValidarModiAnticipo())
                {
                    btnModAnti.Text = "Modificar";
                    txtApagarMod.Visible = false;
                    txtApagarMod.Enabled = false;
                }

            }
        }
        private bool ValidarModiAnticipo()
        {
            decimal descuento;
            decimal aPagar;
            decimal aPagarMod;
            decimal DeudaTotal;

            aPagar = System.Convert.ToDecimal(lblAntiAPagar.Text);
            aPagarMod = System.Convert.ToDecimal(txtApagarMod.Text);
            descuento = System.Convert.ToDecimal(lblAntiDescuento.Text);
            DeudaTotal = System.Convert.ToDecimal(lblCredDeudaTotal.Text);
            if (aPagarMod < aPagar)
            {
                MessageBox.Show("El importe a pagar no puede ser menor que el capital más el interes establecido por arreglo de anticipo");
                return false;
            }
            else if (aPagarMod > DeudaTotal)
            {
                MessageBox.Show("El importe a pagar no puede ser mayor que la deuda total");
                return false;
            }

            lblAntiAPagar.Text = aPagarMod.ToString();
            lblAntiDescuento.Text = (DeudaTotal - aPagarMod).ToString();
            return true;
        }

        private void txtPagoVarias_KeyUp(object sender, KeyEventArgs e)
        {
            Calcula_pago_Varias();
        }
        private void Calcula_pago_Varias()
        {
            lblVariasError.Text = "";
            btnVariasPagar.Enabled = false;
            lblVariasNotas.Text = "";
            foreach (DataGridViewRow d in gridPagoVarias.Rows)
            {
                d.Cells[5].Value = "0";   //"Pago cuota"
                d.Cells[6].Value = "0";   //Pago punitorios
                d.Cells[7].Value = "0";   //Bonificado
                d.Cells[8].Value = "0";   //Total pago"
                d.Cells[9].Value = "";   //tipo
                d.DefaultCellStyle.ForeColor = Color.Black;
            }
            if (txtPagoVarias.Text == "" || txtPagoVarias.Text == null)
            {
                txtPagoVarias.Text = "0";
                return;
            }
            decimal dCuantoPaga = Convert.ToDecimal(txtPagoVarias.Text);
            if (dCuantoPaga == 0)
            {
                lblVariasError.Text = "Ingrese el importe";
                return;
            }
            decimal dQueda = dCuantoPaga;
            int nItem = 1;
            decimal dTotal = 0;
            decimal dCuantoPagoItem = 0;
            decimal dTotalGral = 0;

            decimal dTotalParaCancelar = Convert.ToDecimal(lblVariasCancelar.Text);
            bBoni = false;
            if (dCuantoPaga >= dTotalParaCancelar)
            {
                Asigna_Pago_Cancela(dCuantoPaga);
                dTotalGral = dTotalParaCancelar;
                lblVariasError.Text = "Cancela crédito";
                if (bBoni) lblVariasNotas.Text = "Cancela crédito - Bonificado"; else lblVariasNotas.Text = "Cancela crédito";
            }
            else
            {



                foreach (DataGridViewRow it in gridPagoVarias.Rows)
                {
                    if (nItem == 1)
                    {
                        dTotal = Convert.ToDecimal(it.Cells[4].Value);     // total de cuota a pagar
                        if (dTotal >= dQueda)
                        {
                            lblVariasError.Text = "El importe debe ser mayor a la deuda de la primer cuota";
                            return;
                        }
                    }
                    if (dQueda == 0) break;
                     dCuantoPagoItem = Asigna_Pago(it, dQueda, nItem == gridPagoVarias.Rows.Count);
                    dQueda = dQueda - dCuantoPagoItem;
                    dTotalGral = dTotalGral + dCuantoPagoItem;



                    lblVariasError.Text = dTotalGral.ToString("N2");
                    nItem++;
                }
            }
            if (dTotalGral == dCuantoPaga)
            {
                btnVariasPagar.Enabled = true;

            }

        }
        private decimal Asigna_Pago(DataGridViewRow LItem, decimal dCuantoQueda, bool bCancela)
        {
            decimal dCuantoPago = 0;
            decimal dPorCuota = Convert.ToDecimal(LItem.Cells[1].Value);
            decimal dPorPuni = Convert.ToDecimal(LItem.Cells[2].Value);
            decimal dPorBoni = Convert.ToDecimal(LItem.Cells[3].Value);
            decimal dPorTotal = Convert.ToDecimal(LItem.Cells[4].Value);
            decimal aTmp1 = 0;
            decimal aTmp2 = 0;
            decimal aTmp3 = 0;
            //"Pago cuota", 65, "D"); nCol++; //5  
            // "Pago punitorios", 65, "D"); nCol++; //6    
            //"Bonificado", 65, "D"); nCol++; //7    
            //"Total pago", 65, "D"); nCol++; //8
            if (dPorBoni > 0)
            {
                bCancela = true;
            }

            if (dPorTotal <= dCuantoQueda)         //pago cuota
            {
                if (bCancela == false)
                {
                    LItem.Cells[5].Value = dPorCuota.ToString("N2");
                    LItem.Cells[6].Value = dPorPuni.ToString("N2");
                    LItem.Cells[7].Value = dPorBoni.ToString("N2");
                    dCuantoPago = dPorCuota + dPorPuni - dPorBoni;
                    LItem.Cells[8].Value = dCuantoPago.ToString("N2");
                    LItem.Cells[9].Value = "Pago cuota";
                    if (dPorBoni > 0) LItem.Cells[9].Value = "Bonificado";
                }
                else
                {
                    if (dPorBoni == 0)
                    {
                        LItem.Cells[5].Value = dPorCuota.ToString("N2");
                        dCuantoPago = dPorCuota;
                        dCuantoQueda = dCuantoQueda - dPorCuota;
                        LItem.Cells[7].Value = dPorBoni.ToString("N2");

                        LItem.Cells[6].Value = dCuantoQueda.ToString("N2");
                        dCuantoPago = dCuantoPago + dCuantoQueda;
                        LItem.Cells[8].Value = dCuantoPago.ToString("N2");
                    }
                    else
                    {
                        LItem.Cells[5].Value = dPorCuota.ToString("N2");
                        dCuantoPago = dPorCuota;
                        dCuantoQueda = dCuantoQueda - dPorCuota;


                        LItem.Cells[6].Value = dCuantoQueda.ToString("N2");
                        dCuantoPago = dCuantoPago + dCuantoQueda;
                        LItem.Cells[8].Value = dCuantoPago.ToString("N2");
                        if (dCuantoPago > dPorTotal)
                        {
                            LItem.Cells[9].Value = "Pago mayor cuota";
                            lblVariasNotas.Text = "Pago mayor cuota - verifique el importe";
                        }
                    }


                    if (dCuantoPago > dPorTotal)
                    {
                        LItem.Cells[9].Value = "Pago mayor cuota";
                        lblVariasNotas.Text = "Pago mayor cuota - verifique el importe";
                    }
                }
            }
            else
            {
                if (dPorPuni == 0)   //Sin punitorios
                {
                    LItem.Cells[5].Value = dCuantoQueda.ToString("N2");
                    dCuantoPago = dCuantoQueda;
                    dCuantoQueda = dCuantoQueda - dPorCuota;
                    LItem.Cells[8].Value = dCuantoPago.ToString("N2");
                    LItem.Cells[9].Value = "Pago a cuenta";
                }
                else
                {
                    aTmp1 = Convert.ToDecimal(LItem.Cells[1].Value) * dCuantoQueda;
                    aTmp2 = Convert.ToDecimal(LItem.Cells[1].Value) + Convert.ToDecimal(LItem.Cells[2].Value);
                    if (dCuantoQueda < 15)
                    {
                        aTmp3 = Convert.ToDecimal((aTmp1 / aTmp2));
                    }
                    else
                    {
                        aTmp3 = Convert.ToDecimal(Redondeo(aTmp1 / aTmp2));
                    }
                    if (aTmp3 < 1) aTmp3 = 1;
                    LItem.Cells[5].Value = aTmp3.ToString("N2");
                    dCuantoPago = aTmp3;
                    aTmp1 = dCuantoQueda - aTmp3;
                    LItem.Cells[6].Value = aTmp1.ToString("N2");
                    dCuantoPago = dCuantoPago + aTmp1;
                    LItem.Cells[8].Value = dCuantoPago.ToString("N2");
                    LItem.Cells[9].Value = "Pago a cuenta";
                }

            }
            LItem.DefaultCellStyle.ForeColor = Color.Black;
            if (dCuantoPago > dPorTotal)
            {
                LItem.Cells[9].Value = "Pago mayor cuota";
                lblVariasNotas.Text = "Pago mayor cuota - verifique el importe";
                //LItem.Cells[8] .Style.Font = new Font("Verdana", 7F, FontStyle.Bold);
                LItem.DefaultCellStyle.ForeColor = Color.Red;
            }
            LItem.Cells[9].Style.Font = new Font("Verdana", 7F, FontStyle.Bold);
            return dCuantoPago;
        }
        private void Asigna_Pago_Cancela(decimal dTotalParaCancelar)
        {
            int nFila = 1;
            decimal dCuantoPago = 0;
            decimal dPorCuota = 0;  //Convert.ToDecimal(LItem.Cells[1].Value);
            decimal dPorPuni = 0;  // Convert.ToDecimal(LItem.Cells[2].Value);
            decimal dPorBoni = 0;  // Convert.ToDecimal(LItem.Cells[3].Value);
            decimal dPorTotal = 0;  // Convert.ToDecimal(LItem.Cells[4].Value);
            decimal dCuantoQueda = dTotalParaCancelar;
            foreach (DataGridViewRow it in gridPagoVarias.Rows)
            {

                dPorCuota = Convert.ToDecimal(it.Cells[1].Value);
                dPorPuni = Convert.ToDecimal(it.Cells[2].Value);
                dPorBoni = Convert.ToDecimal(it.Cells[3].Value);
                dPorTotal = Convert.ToDecimal(it.Cells[4].Value);
                dCuantoPago = dCuantoPago + dPorTotal;
                dCuantoQueda = dCuantoQueda - dPorTotal;
                if (dPorBoni > 0) it.Cells[9].Value = "Bonificada"; else it.Cells[9].Value = "Pago cuota";
                if (nFila == gridPagoVarias.Rows.Count)
                {
                    if (dCuantoQueda == 0)
                    {
                        it.Cells[5].Value = it.Cells[1].Value;
                        it.Cells[6].Value = it.Cells[2].Value;
                        it.Cells[7].Value = it.Cells[3].Value;
                        it.Cells[8].Value = it.Cells[4].Value;
                        if (dPorBoni > 0) it.Cells[9].Value = "Bonificada"; else it.Cells[9].Value = "Pago cuota";
                    }
                    else
                    {
                        dPorPuni = dPorPuni + dCuantoQueda;
                        it.Cells[5].Value = it.Cells[1].Value;
                        it.Cells[6].Value = dPorPuni.ToString("N2");
                        it.Cells[7].Value = it.Cells[3].Value;
                        it.Cells[8].Value = it.Cells[4].Value;
                        it.Cells[9].Value = "Pago mayor cuota";
                        lblVariasNotas.Text = "Pago mayor cuota - verifique el importe";
                    }
                }
                else
                {
                    it.Cells[5].Value = it.Cells[1].Value;
                    it.Cells[6].Value = it.Cells[2].Value;
                    it.Cells[7].Value = it.Cells[3].Value;
                    it.Cells[8].Value = it.Cells[4].Value;
                    if (dPorBoni > 0) it.Cells[9].Value = "Bonificada"; else it.Cells[9].Value = "Pago cuota";
                }

                it.Cells[9].Style.Font = new Font("Verdana", 7F, FontStyle.Bold);

                nFila++;
            }
            if (dPorBoni > 0) bBoni = true;
        }
        //private void lblVariasNotas_Click(object sender, EventArgs e)
        //{
            
        //}

        private void txtPagoVarias_TextChanged(object sender, EventArgs e)
        {

        }

        private void Prepara_Pago_Arreglo()
        {
            //decimal nPun = 0;
            lblArregloCuota.Text = lblOtroCuotas.Text;
            lblArregloImporte.Text = lblCredDeuda.Text;// lblCredDeudaTotal.Text;
            lblArregloPunitorio.Text = lblCredPuni.Text;
            lblArregloTotal.Text = lblCredDeudaTotal.Text;
            txtArregloAPagar.Text = lblCredDeudaTotal.Text;
            DateTime FechaPri = Convert.ToDateTime(lblCredVenci.Text);
            int nMeses = Math.Abs((DateTime.Now.Month - FechaPri.Month) + 12 * (DateTime.Now.Year - FechaPri.Year));
            opArreglo01.Enabled = false;
            opArreglo02.Enabled = false;
            opArreglo03.Enabled = false;
            if (Convert.ToDecimal(lblCredPuni.Text) > 0)
            {
                //if(Convert.ToDateTime(lblCredPriFechVen.Text) < DateTime.Now)
                if (nMeses >= bl.pGlob.Configuracion.nArregloMeses)
                {
                    opArreglo03.Checked = true;
                    Calcula_Arreglo_Porcentaje();
                    //nPun = Redondeo((Convert.ToDecimal(lblArregloImporte.Text) + (Convert.ToDecimal(lblArregloImporte.Text) + Convert.ToDecimal(lblArregloPunitorio.Text))) / 2);
                    //lblArregloMin.Text = nPun.ToString("N2");
                    //lblArregloMinimo.Text = "Pago mínimo : " + lblArregloMin.Text;
                }
                else
                {
                    lblArregloMin.Text = lblArregloTotal.Text;
                    lblArregloMinimo.Text = "No cumple con los requisitos para el descuento"; //. Pago mínimo : " + lblArregloMin.Text;
                    MessageBox.Show("No cumple con los requisitos para el descuento", "Arreglo de pagos");
                    return;
                }
            }
            else
            {
                lblArregloMin.Text = lblArregloTotal.Text;
                lblArregloMinimo.Text = "No cumple con los requisitos para el descuento."; // Pago descuento : " + lblArregloMin.Text;
                MessageBox.Show("No cumple con los requisitos para el descuento", "Arreglo de pagos");
                return;
            }
            //grpPagar.Visible = false;
            //grpPagarAnticip.Visible = false;
            //lblSombra.Width = grpArreglo.Width;
            //lblSombra.Height = grpArreglo.Height - 10;
            //lblSombra.Top = grpArreglo.Top + 15;
            //lblSombra.Left = grpArreglo.Left + 5;
            //lblSombra.Visible = true;
            //lblSombra.BringToFront();
            lblPagoMsg.Text = "Cancela crédito";
            lblPagTit.Text = "Arreglo de pago";
            lblPagQueHace.Text = "ARREGLO";
            tablaPagar.SelectTab("tabArreglo");
            //MuestraPanelConSombra(panelArreglo, lblSombra, txtArregloAPagar);
            Calcula_Imp_Puni_Arreglo();
            tabControl1.Enabled = false;

            
        }
        private void Calcula_Imp_Puni_Arreglo()
        {
            btnArregloPagar.Enabled = false;
            lblArregloMsg.Text = "Ingrese importe";
            if (txtArregloAPagar.Text == "" || txtArregloAPagar.Text == null)
            {
                return;
            }
            try
            {
                decimal CalcImp = Convert.ToDecimal(txtArregloAPagar.Text);

                if (CalcImp == 0) return;

                if (CalcImp > Convert.ToDecimal(lblArregloTotal.Text))
                {
                    lblArregloMsg.Text = "Pago mayor cuota";
                    return;
                }
                if (bCambiaMinimo == false) 
                {
                    CalcImp = Convert.ToDecimal(lblArregloMin.Text); 
                }
                else
                {
                    CalcImp = Convert.ToDecimal(lblArregloImporte.Text);
                }
                if (Convert.ToDecimal(txtArregloAPagar.Text) < CalcImp)
                {
                    lblArregloMsg.Text = "Pago menor al arreglo de pagos";
                    return;
                }  


                lblArregloMsg.Text = "Cancela crédito";
                btnArregloPagar.Enabled = true;
                return;
            }
            catch { }
        }
        private void Calcula_Arreglo_Porcentaje()
        {
            decimal dDeuda = (Convert.ToDecimal(lblArregloImporte.Text) + (Convert.ToDecimal(lblArregloImporte.Text) + Convert.ToDecimal(lblArregloPunitorio.Text)));
            decimal dArreglo = dDeuda;
            decimal dPorcen = 50;
            opArreglo01.Enabled = true;
            opArreglo02.Enabled = true;
            opArreglo03.Enabled = true;
            if (opArreglo01.Checked) //   ( nOp == 1)
            {
                if (bl.pGlob.Configuracion.dArreglo01 > 0) dPorcen = bl.pGlob.Configuracion.dArreglo01;
            }
            else if (opArreglo02.Checked) //  (nOp == 2)
            {
                if (bl.pGlob.Configuracion.dArreglo02 > 0) dPorcen = bl.pGlob.Configuracion.dArreglo02;
            }
            else if (opArreglo03.Checked) //  (nOp == 3)
            {
                if (bl.pGlob.Configuracion.dArreglo03 > 0) dPorcen = bl.pGlob.Configuracion.dArreglo03;
            }
            dArreglo = dDeuda * dPorcen / 100;
            dArreglo = Redondeo(dArreglo);
            if (dArreglo > Convert.ToDecimal(lblCredDeudaTotal.Text))
            {
                dArreglo = Convert.ToDecimal(lblCredDeudaTotal.Text);
            }

            lblArregloMin.Text = dArreglo.ToString("N2");
            lblArregloMinimo.Text = "Pago mínimo : " + lblArregloMin.Text;
            txtArregloAPagar.Text = lblArregloMin.Text;

        }

        private void opArreglo01_CheckedChanged(object sender, EventArgs e)
        {
            if (opArreglo01.Checked == false) return;
            Calcula_Arreglo_Porcentaje();
            Calcula_Imp_Puni_Arreglo();
        }

        private void opArreglo02_CheckedChanged(object sender, EventArgs e)
        {
            if (opArreglo02.Checked == false) return;
            Calcula_Arreglo_Porcentaje();
            Calcula_Imp_Puni_Arreglo();
        }

        private void opArreglo03_CheckedChanged(object sender, EventArgs e)
        {
            if (opArreglo03.Checked == false) return;
            Calcula_Arreglo_Porcentaje();
            Calcula_Imp_Puni_Arreglo();
        }

        private void txtArregloAPagar_KeyUp(object sender, KeyEventArgs e)
        {
            Calcula_Imp_Puni_Arreglo();
        }

        private void panelAyuda_Move(object sender, EventArgs e)
        {
            System.Windows.Forms.Control elControl = (System.Windows.Forms.Control)sender;
            lblSombra2.Width = elControl.Width;
            lblSombra2.Height = elControl.Height - 10;
            lblSombra2.Top = elControl.Top + 15;
            lblSombra2.Left = elControl.Left + 5;

        }


        private void BtnPagoPagar_Click(object sender, EventArgs e)
        {
            Manda_Pagar();

        }

        private void Manda_Pagar()
        {
            List<Transmision> ltrans = new List<Transmision>();
            decimal ValorPagoTotal = 0;
            int bb = 0;
            if (lblPagoBoni.Visible && lblPagoBoni.Text != "0")
            {
                if (regCredito.TipoBonificacionID == "X")
                {
                    bb = Paga_Cuota(lblPagoQue.Text, regCredito.EmpresaID, Convert.ToUInt16(lblPagoCuota.Text), nComercioPagar,
                            Convert.ToInt32(txtBuscaCred.Text), Convert.ToDecimal(lblPagoCalcImp.Text), Convert.ToDecimal(lblPagoCalcPuni.Text),
                            Convert.ToDecimal(lblPagoPunitorio.Text), true, 0, ref ltrans,
                            true, 0, regCredito.TipoBonificacionID, Convert.ToInt32(regCredito.PorcentajeBonificacion));
                    ValorPagoTotal = Convert.ToDecimal(lblPagoCalcImp.Text) + Convert.ToDecimal(lblPagoCalcPuni.Text);
                    if (bb > 0)
                    {
                        int nNvaCuota = Convert.ToUInt16(lblPagoCuota.Text);
                        nNvaCuota++;
                        for (int n = nNvaCuota; n <= regCredito.CantidadCuotas; n++)
                        {
                            if (nNvaCuota <= regCredito.CantidadCuotas)
                            {
                                if (bb > 0)
                                {
                                    Paga_Cuota(lblPagoQue.Text, regCredito.EmpresaID, n, nComercioPagar,
                                    Convert.ToInt32(txtBuscaCred.Text), regCredito.ValorCuota, 0, 0, false, 0, ref ltrans,
                                    true, regCredito.ValorCuota, regCredito.TipoBonificacionID, Convert.ToInt32(regCredito.PorcentajeBonificacion));
                                }
                            }
                        }
                    }

                }
                else if (regCredito.TipoBonificacionID == "C" || regCredito.TipoBonificacionID == "V")
                {
                    bb = Paga_Cuota(lblPagoQue.Text, regCredito.EmpresaID, Convert.ToUInt16(lblPagoCuota.Text), nComercioPagar,
                            Convert.ToInt32(txtBuscaCred.Text), Convert.ToDecimal(lblPagoCalcImp.Text), Convert.ToDecimal(lblPagoCalcPuni.Text),
                            Convert.ToDecimal(lblPagoPunitorio.Text), true, 0, ref ltrans,
                            true, Convert.ToDecimal(lblPagoBoni.Text), regCredito.TipoBonificacionID, Convert.ToInt32(regCredito.PorcentajeBonificacion));
                    ValorPagoTotal = Convert.ToDecimal(lblPagoCalcImp.Text) + Convert.ToDecimal(lblPagoCalcPuni.Text) - Convert.ToDecimal(lblPagoBoni.Text);
                }
            }
            else
            {
                bb = Paga_Cuota(lblPagoQue.Text, regCredito.EmpresaID, Convert.ToUInt16(lblPagoCuota.Text), nComercioPagar,
                            Convert.ToInt32(txtBuscaCred.Text), Convert.ToDecimal(lblPagoCalcImp.Text), Convert.ToDecimal(lblPagoCalcPuni.Text),
                            Convert.ToDecimal(lblPagoPunitorio.Text), true, 0, ref ltrans);
                if (bb == 0) return;
                ValorPagoTotal = Convert.ToDecimal(lblPagoCalcImp.Text) + Convert.ToDecimal(lblPagoCalcPuni.Text);
            }

            int BaseID = bl.GetEmpresa(bEsPru).EmpresaID.Value;
            bl.Grabar(BaseID);


            if (bFormaPago)
            {
                Abre_FormadePago(ValorPagoTotal, regCredito.EmpresaID, nComercioPagar, Convert.ToInt32(txtBuscaCred.Text), Convert.ToUInt16(lblPagoCuota.Text), bb);
            }

            bl.GrabarTransmisiones(BaseID, ltrans);

            if (bb > 0)
            {
                Limpia();
                Buscar_Credito(nCreditoPagar, nComercioPagar);
            }

        }
        private void Abre_FormadePago(decimal ValorAPagar, int nEmpre, int nComer, int nCred, int nCuot, int nCobr)
        {
            bool bEsPru = false;
            if (lblMor.Visible) bEsPru = true;
            FrmFormaPago frmfp = new FrmFormaPago(p, this.bl, nEmpre, nComer, nCred, nCuot, nCobr, regCredito.Documento,
                                  regCredito.TipoDocumentoID, ValorAPagar, bEsPru);
            frmfp.ShowDialog();
            frmfp.Close();
        }
        private int Paga_Cuota(string qpaga, int nEmprePaga, int nCuoPaga, int nComerPaga, int nCredPaga,
                                decimal ImpPaga, decimal PuniPaga, decimal PuniCalc, bool cMsg, int nRef, ref List<Transmision> ltrans,
                                bool bBonifica = false, decimal nImporteBonificado = 0, string cTipoBonifica = "", int nPorBonifica = 0)
        {
            Operacion op = bl.pGlob.TransAltaCobranza;
            string uri = bl.pGlob.UriAltaCobranza;
            string nTipPago = "C";
            decimal nInteres = 0;
            string cQpaga = "";
            string cBoni = "";
            decimal nBoni = 0;
            decimal NvoImporte = 0;
            Cuota cuoPaga = null;        //**EDU MOR**//

            int BaseID = bl.GetEmpresa(bEsPru).EmpresaID.Value;
            Comercio com = bl.GetComercio(bEsPru);

            cuoPaga = bl.Get<Cuota>(BaseID, c => c.EmpresaID == nEmprePaga && c.ComercioID == nComerPaga
                                           && c.CreditoID == nCredPaga && c.CuotaID == nCuoPaga).FirstOrDefault();

            if (cuoPaga == null)
            {
                MessageBox.Show("ERROR al buscar el crédito" + Environment.NewLine + "(error : COB-00003)", "Cobranzas");
                return 0;
            }

            if (qpaga == "Normal")
            {
                if ((cuoPaga.Deuda) - ImpPaga == 0)
                {
                    nTipPago = "C";
                    cQpaga = "Cancelar cuota: ";
                }
                else
                {
                    nTipPago = "A";
                    PuniCalc = PuniPaga;
                    cQpaga = "Ingresar el pago a cuenta a la cuota: ";
                    nBoni = 0;
                    bBonifica = false;
                }
            }
            else if (qpaga == "Quitar punitórios")
            {
                nTipPago = "P";
                cQpaga = lblPagoMsg.Text + " cuota: ";// "Cancelar cuota: ";
            }
            else if (qpaga == "Cambia punitórios")
            {
                nTipPago = "Q";
                cQpaga = lblPagoMsg.Text + " cuota: ";// "Cancelar cuota: ";
            }
            else if (qpaga == "Pago anticipado")
            {
                nTipPago = "T";
                nBoni = 0;
                bBonifica = false;
            }
            else if (qpaga == "Arreglo")
            {
                nTipPago = "G";
                nBoni = 0;
                bBonifica = false;
            }
            else if (qpaga == "Refinanciado")
            {
                nTipPago = "R";
                nBoni = 0;
                bBonifica = false;
            }
            if (cuoPaga.ImportePago + ImpPaga > cuoPaga.Importe)
            {
                MessageBox.Show("ERROR" + Environment.NewLine + "Comuníquese con central" + Environment.NewLine + "(error : COB-00001)", "Cobranzas");
                return 0;
            }

            if (bBonifica)
            {
                if (cTipoBonifica == "X")
                {
                    op = bl.pGlob.TransAltaCobranzas;
                    uri = bl.pGlob.UriAltaCobranzas;
                    NvoImporte = ImpPaga - nBoni;
                    cBoni = Environment.NewLine + "CANCELA EL CREDITO" + Environment.NewLine + Environment.NewLine + "crédito bonificado por: " + nPorBonifica.ToString() + " cuotas" + Environment.NewLine +
                                                    "Total a pagar: " + NvoImporte.ToString("N2");
                    nBoni = nImporteBonificado;


                }
                else if (cTipoBonifica == "C" || cTipoBonifica == "V")
                {
                    nBoni = nImporteBonificado; 
                    NvoImporte = ImpPaga - nBoni;
                    cBoni = Environment.NewLine + "CANCELA EL CREDITO" + Environment.NewLine + Environment.NewLine + "Cuota bonificada por: " + lblPagoBoni.Text + Environment.NewLine +
                                                    "Total a pagar: " + NvoImporte.ToString("N2");
                }

            }
            if (nBoni > 0) nTipPago = "B";
            if (cMsg)
            {
                DialogResult res = MessageBox.Show(cQpaga + nCuoPaga.ToString() + cBoni, "Cobranzas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (res == DialogResult.Cancel)
                {
                    return 0;
                }
            }
            int nCobraID = 1;

            cuoPaga.ImportePago = cuoPaga.ImportePago + ImpPaga;
            cuoPaga.ImportePagoPunitorios = cuoPaga.ImportePagoPunitorios + PuniPaga;
            cuoPaga.FechaUltimoPago = DateTime.Now;

            bl2 = new BusinessLayer();
            Cobranza cobrPagar = null;        //**EDU MOR**//

            cobrPagar = bl2.GetDal(BaseID).context.Cobranzas.Where(c => c.EmpresaID == nEmprePaga &&
                       c.ComercioID == nComerPaga && 
                       c.GestionID == ComID).OrderByDescending(o => o.CobranzaID).FirstOrDefault();

            if (cobrPagar != null) nCobraID = cobrPagar.CobranzaID + 1;
            Cobranza cobrPagarNvo = new Cobranza();

            
            cobrPagarNvo.EmpresaID = nEmprePaga;
            cobrPagarNvo.ComercioID = nComerPaga;
            cobrPagarNvo.CreditoID = nCredPaga;
            cobrPagarNvo.CuotaID = nCuoPaga;
            cobrPagarNvo.CobranzaID = nCobraID;
            cobrPagarNvo.Documento = regCredito.Documento;
            cobrPagarNvo.TipoDocumentoID = regCredito.TipoDocumentoID;
            cobrPagarNvo.ImportePago = ImpPaga;
            cobrPagarNvo.ImportePagoPunitorios = PuniPaga;
            nInteres = (cuoPaga.Interes * ImpPaga) / cuoPaga.Importe;
            cobrPagarNvo.Interes = nInteres;
            cobrPagarNvo.PunitoriosCalc = PuniCalc;
            cobrPagarNvo.FechaPago = DateTime.Now;
            cobrPagarNvo.FechaVencimiento = cuoPaga.FechaVencimiento;
            cobrPagarNvo.TipoPagoID = nTipPago;

            if (nImporteBonificado == 0)
            {
                cobrPagarNvo.TipoBonificacionID = null;
                cobrPagarNvo.PorcentajeBonificacion = 0;
            }
            else
            {
                cobrPagarNvo.TipoBonificacionID = cTipoBonifica;
                cobrPagarNvo.PorcentajeBonificacion = nPorBonifica;
                cobrPagarNvo.NotasBoni = cBoni;
                cobrPagarNvo.TipoBonificacion = bl.Get<TipoBonificacion>(BaseID, t => t.TipoBonificacionID == cobrPagarNvo.TipoBonificacionID).FirstOrDefault();
            }

            cobrPagarNvo.PagoRev = false;
            //cobrPagarNvo.FechaRev = DateTime.Now;                          ///  PONER NULL
            cobrPagarNvo.GestionEmpresaID = Com.EmpresaID;
            cobrPagarNvo.GestionID = Com.ComercioID;  
            cobrPagarNvo.RefinanciacionCobranzaID = nRef;
            cobrPagarNvo.UsuarioID = p.usuIDAutorizado;
            cobrPagarNvo.PcComer = System.Environment.MachineName;

            if (cuoPaga.CuotaID == cuoPaga.Credito.CantidadCuotas)
            {
                if (cuoPaga.Deuda == 0)
                {
                    cuoPaga.Credito.Cancelado = true;
                    bl.ActualizarTransaccional<Credito>(BaseID, cuoPaga.Credito);
                }
            }

            bl.AgregarTransaccional<Cobranza>(BaseID, cobrPagarNvo);
            bl.ActualizarTransaccional<Cuota>(BaseID, cuoPaga);

            CuentaCorriente cc;
            if (cobrPagarNvo.ImporteTotal >= 0)
            {
                cc = bl.ImputarCobranzaACuentaCorriente(BaseID, cobrPagarNvo);
            }
            else
            {
                cc = bl.ImputarDescPuniRefiACuentaCorriente(BaseID, cobrPagarNvo);
            }

            bl.Grabar(BaseID);
            ltrans = bl.Transmision<Cobranza>(ltrans, cobrPagarNvo, com, op, uri);
            ltrans = bl.Transmision<CuentaCorriente>(ltrans, cc, com, bl.pGlob.TransImputacionCC, uri);


            if (nBoni > 0)
                Graba_NotaCD(nCuoPaga, nCobraID, nBoni, "Pago bonificado", ref ltrans);
            cobrPagarNvo = bl.Get<Cobranza>(BaseID, x => x.ComercioID == cobrPagarNvo.ComercioID && x.CreditoID == cobrPagarNvo.CreditoID
                                                     && x.CuotaID == cobrPagarNvo.CuotaID && x.CobranzaID == cobrPagarNvo.CobranzaID,null,"Cliente").SingleOrDefault();

            bl.ImprimirCobranza(cobrPagarNvo, bEsPru);
            return nCobraID;
        }
        private int Graba_NotaCD(int nCuotaND, int nCobranzaND, decimal nImporteND, string cCausa, ref List<Transmision> ltrans)
        {
            int nID = 1;
            int nCom = nComercioPagar; 
            int nCredi = Convert.ToInt32(txtBuscaCred.Text);
            NotasCD notaIdNvo = null;        //**EDU MOR**//

            notaIdNvo = bl2.GetDal(Com.EmpresaID).context.NotasCD.Where(c => c.EmpresaID == Com.EmpresaID && c.ComercioID == nCom).OrderByDescending(o => o.NotaCDID).FirstOrDefault();

            if (notaIdNvo != null) nID = notaIdNvo.NotaCDID + 1;

            NotasCD notaCD = new NotasCD();
            notaCD.EmpresaID = Com.EmpresaID;
            notaCD.NotaCDID = nID;
            notaCD.Importe = nImporteND; 
            notaCD.Fecha = DateTime.Now;
            notaCD.TipoNota = "CREDITO";
            notaCD.ComercioID = nCom;
            notaCD.CreditoID = nCredi;
            notaCD.CuotaID = nCuotaND;
            notaCD.CobranzaID = nCobranzaND; 
            notaCD.Documento = regCredito.Documento;
            notaCD.TipoDocumentoID = regCredito.TipoDocumentoID;
            notaCD.GestionID = Com.ComercioID; 
            notaCD.UsuarioID = p.usuIDAutorizado;
            notaCD.PcComer = System.Environment.MachineName;
            notaCD.Notas = cCausa;
            if (cCausa == "Pago anticipado") notaCD.Detalle = "ANTICIPADO"; else notaCD.Detalle = "BONIFICADO";

            int BaseID = bl.GetEmpresa(bEsPru).EmpresaID.Value;
            Comercio com = bl.GetComercio(bEsPru);
            CuentaCorriente cc;

            bl.AgregarTransaccional<NotasCD>(BaseID, notaCD);
            bl.Grabar(BaseID);

            if (cCausa == "Pago anticipado")
            {
                ltrans = bl.Transmision<NotasCD>(ltrans, notaCD, com, bl.pGlob.TransPagoAnticipadoNotaCD, bl.pGlob.UriAltaCobranza);
                cc = bl.ImputarDescuentoCobranzaPorCancelaciónAnticipadoACuentaCorriente(BaseID, notaCD);
            }
            else
            {
                ltrans = bl.Transmision<NotasCD>(ltrans, notaCD, com, bl.pGlob.TransAltaNotaCD, bl.pGlob.UriAltaCobranza);
                cc = bl.ImputarDescuentoCobranzaPorPromocionBonificadaACuentaCorriente(BaseID, notaCD);
            }
            bl.Grabar(BaseID);
            ltrans = bl.Transmision<CuentaCorriente>(ltrans, cc, com, bl.pGlob.TransImputacionCC, bl.pGlob.UriAltaCobranza);

            return nID;
        }

        private void btnVariasPagar_Click(object sender, EventArgs e)
        {
            Manda_Pagar_Varias();
        }
        private void Manda_Pagar_Varias() 
        {
            int BaseID = bl.GetEmpresa(bEsPru).EmpresaID.Value;
            DialogResult res = MessageBox.Show("¿Pagar las cuotas?" + Environment.NewLine + Environment.NewLine + ""
                                + "  $ " + txtPagoVarias.Text, "Pago cuotas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (res == DialogResult.Cancel) return;
            List<Transmision> lTrans;
            int nCuot = 0;
            decimal dImp = 0;
            decimal dPuni = 0;
            decimal dBoni = 0;
            decimal dPuniCal=0;
            bool bBoni = false;
            int bb = 0;
            decimal ValorPagoTotal = Convert.ToDecimal(txtPagoVarias.Text);
            foreach (DataGridViewRow d in gridPagoVarias.Rows)
            {
                bBoni = false;
                nCuot = Convert.ToInt16(d.Cells[0].Value.ToString());
                dImp = Convert.ToDecimal(d.Cells[5].Value.ToString());
                dPuni = Convert.ToDecimal(d.Cells[6].Value.ToString());
                dPuniCal = Convert.ToDecimal(d.Cells[2].Value.ToString());
                if (d.Cells[7].Value != null) dBoni = Convert.ToDecimal(d.Cells[7].Value.ToString()); else dBoni = 0;
                if(dBoni > 0) bBoni=true;
                if (dImp + dPuni > 0)
                {
                    lTrans = new List<Transmision>();
                    bb = Paga_Cuota("Normal", regCredito.EmpresaID, nCuot, nComercioPagar, nCreditoPagar,
                                 dImp, dPuni, dPuniCal, false, 0, ref lTrans, bBoni, dBoni, regCredito.TipoBonificacionID, Convert.ToInt32(regCredito.PorcentajeBonificacion));
                    bl.Grabar(BaseID);
                    bl.GrabarTransmisiones(BaseID, lTrans);
                    if (bb == 0) break;
                }
            }
            if (bFormaPago)
            {
                Abre_FormadePago(ValorPagoTotal, regCredito.EmpresaID, nComercioPagar, Convert.ToInt32(txtBuscaCred.Text), nCuot, bb);
            }
            MessageBox.Show("Pago realizado", "Pago de cuotas");



            if (bb > 0)
            {
                Limpia();
                Buscar_Credito(nCreditoPagar, nComercioPagar);
            }
        }

        private void BtnPagoPagarR_Click(object sender, EventArgs e)
        {
            Manda_Pagar_Refinanciado();
        }
        private void Manda_Pagar_Refinanciado()
        {
            int bb = 0;
            decimal nCuantoQueda = 0;
            decimal aTmp1 = 0;
            decimal aTmp2 = 0;
            decimal aTmp3 = 0;
            int nCuo = 0;
            decimal nDeuda = 0;
            decimal nPunitorio = 0;
            bool bCancelaRef = false;
            decimal nPagoACuota = 0;
            decimal nPagoAPuni = 0;

            int nRefEmpre = Convert.ToInt16(lblRefEmp.Text);
            int nRefComer = Convert.ToInt16(lblRefComer.Text);
            int nRefCred = Convert.ToInt32(txtBuscaCred.Text);
            int nRefRef = Convert.ToInt32(lblRefCred.Text);
            int nRefCuota = Convert.ToInt16(lblPagoCuotaR.Text);
            int nRefCobra = 1;

            DialogResult res = MessageBox.Show("¿Pagar la cuota refianciada?" + Environment.NewLine + Environment.NewLine +
                                               "     $ " + txtPagoAPagarR.Text, "Pago refinanciado", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (res == DialogResult.Cancel) return;

            if (lblPagoCuotaR.Text == regRefinanciacion.CantidadCuotas.ToString())      // SI CANCELA REFI
            {
                if (lblPagoMsgR.Text == "Cancela cuota") bCancelaRef = true;
            }

            nCuantoQueda = Convert.ToDecimal(txtPagoAPagarR.Text);
            RefinanciacionCuota regRefinanciacionCuota;
            if (bEsPru)
            {
                regRefinanciacionCuota = bl.dalPrueba.GetRefinanciacionCuotas(r => r.EmpresaID == nRefEmpre &&
                                        r.ComercioID == nRefComer && r.CreditoID == nRefCred &&
                                        r.RefinanciacionID == nRefRef && r.RefinanciacionCuotaID == nRefCuota).FirstOrDefault();

            }
            else
            {
                regRefinanciacionCuota = bl.GetRefinanciacionCuotas(r => r.EmpresaID == nRefEmpre &&
                                                        r.ComercioID == nRefComer && r.CreditoID == nRefCred &&
                                                        r.RefinanciacionID == nRefRef && r.RefinanciacionCuotaID == nRefCuota).FirstOrDefault();

            }

            if (regRefinanciacionCuota == null)
            {
                return;
            }
            //                                                                      ACUALIZA LA CUOTA REFINANCIADA
            regRefinanciacionCuota.ImportePago = regRefinanciacionCuota.ImportePago + Convert.ToDecimal(lblPagoCalcImpR.Text);
            regRefinanciacionCuota.ImportePagoPunitorios = regRefinanciacionCuota.ImportePagoPunitorios + Convert.ToDecimal(lblPagoCalcPuniR.Text);
            regRefinanciacionCuota.FechaUltimoPago = DateTime.Now;


            int BaseID = bl.GetEmpresa(bEsPru).EmpresaID.Value;
            List<Transmision> lTrans = new List<Transmision>();
            List<RefinanciacionCobranza> regRefinanciacionCobranza;

            bl.ActualizarTransaccional<RefinanciacionCuota>(BaseID, regRefinanciacionCuota);
            lTrans = bl.Transmision(lTrans, bl.GetComercio(BaseID), bl.pGlob.TransAltaRefinanciacionCobranza, bl.pGlob.UriRefinanciacionCobranza);
            lTrans = bl.Transmision<RefinanciacionCuota>(lTrans, regRefinanciacionCuota, bl.GetComercio(BaseID), bl.pGlob.TransActualizarRefinanciacionCuota, bl.pGlob.UriRefinanciacionCobranza);

            regRefinanciacionCobranza = bl.GetDal(BaseID).GetRefinanciacionCobranzas(r => r.EmpresaID == nRefEmpre &&
                                        r.ComercioID == nRefComer && r.CreditoID == nRefCred &&
                                        r.RefinanciacionID == nRefRef).ToList();

            //BUSCA NVO ID DE REFICOBRANZA
            if (regRefinanciacionCobranza.Count > 0)
            {
                foreach (RefinanciacionCobranza recob in regRefinanciacionCobranza)
                {
                    if (recob.RefinanciacionCobranzaID >= nRefCobra) nRefCobra = recob.RefinanciacionCobranzaID + 1;
                }
            }

            //AGREGA NUEVA REFCOBRANZA
            RefinanciacionCobranza regRefinanciacionCobranzaNVA = new RefinanciacionCobranza();
            regRefinanciacionCobranzaNVA.RefinanciacionCobranzaID = nRefCobra;
            regRefinanciacionCobranzaNVA.RefinanciacionCuotaID = nRefCuota;
            regRefinanciacionCobranzaNVA.RefinanciacionID = nRefRef;
            regRefinanciacionCobranzaNVA.CreditoID = nRefCred;
            regRefinanciacionCobranzaNVA.ComercioID = nRefComer;
            regRefinanciacionCobranzaNVA.EmpresaID = nRefEmpre;
            regRefinanciacionCobranzaNVA.Documento = regCredito.Documento;
            regRefinanciacionCobranzaNVA.TipoDocumentoID = regCredito.TipoDocumentoID;
            regRefinanciacionCobranzaNVA.ImportePago = Convert.ToDecimal(lblPagoCalcImpR.Text);
            regRefinanciacionCobranzaNVA.ImportePagoPunitorios = Convert.ToDecimal(lblPagoCalcPuniR.Text);
            regRefinanciacionCobranzaNVA.PunitoriosCalc = Convert.ToDecimal(lblPagoPunitorioR.Text);
            regRefinanciacionCobranzaNVA.FechaPago = DateTime.Now;
            regRefinanciacionCobranzaNVA.FechaVencimiento = regRefinanciacionCuota.FechaVencimiento;
            regRefinanciacionCobranzaNVA.TipoPagoID = "C";
            regRefinanciacionCobranzaNVA.PagoRev = false;
            regRefinanciacionCobranzaNVA.GestionID = Com.ComercioID; // NumComercio;       //**EDU MOR**//

            bl.AgregarTransaccional<RefinanciacionCobranza>(BaseID, regRefinanciacionCobranzaNVA);
            lTrans = bl.Transmision<RefinanciacionCobranza>(lTrans, regRefinanciacionCobranzaNVA, Com, bl.pGlob.TransAltaRefinanciacionCobranza, bl.pGlob.UriRefinanciacionCobranza);


            foreach (Cuota cu in regCredito.Cuotas)
            {
                nPagoACuota = 0;
                nPagoAPuni = 0;

                if (bCancelaRef)
                {

                    if (cu.Deuda > 0)
                    {
                        nCuo = cu.CuotaID;
                        nDeuda = cu.Deuda;
                        nPagoACuota = nDeuda;
                        nCuantoQueda = nCuantoQueda - nDeuda;

                        if (nCuo == cu.Credito.CantidadCuotas)
                        {
                            nPagoAPuni = nCuantoQueda;
                        }
                        else
                        {
                            nPagoAPuni = 0;
                        }

                        bb = Paga_Cuota("Refinanciado", regCredito.EmpresaID, nCuo, cu.ComercioID,
                        cu.CreditoID, nPagoACuota, nPagoAPuni, nPagoAPuni, false, nRefCobra, ref lTrans);
                        bl.Grabar(BaseID);
                        if (bb == 0) break;
                    }
                }
                else
                {
                    if (nCuantoQueda > 0)                            // lo que queda del importe a pagar
                    {
                        if (cu.Deuda > 0)                             // cuota con deuda
                        {
                            nCuo = cu.CuotaID;
                            nDeuda = cu.Deuda;
                            nPunitorio = Calcula_Punitorio(nDeuda, cu.FechaVencimiento, Com.Por30.Value, Com.Por30M.Value, true);

                            if (nCuo == cu.CantidadCuotas)
                            {
                                if (bCancelaRef)                                         //cancelar todo
                                {
                                    nPagoACuota = nDeuda;
                                    nCuantoQueda = nCuantoQueda - nDeuda;
                                    nPagoAPuni = nCuantoQueda;
                                    nCuantoQueda = 0;
                                }
                                else
                                {
                                    if (nCuantoQueda > nDeuda)
                                    {
                                        nPagoACuota = decimal.Round(nDeuda / 2);
                                        nCuantoQueda = nCuantoQueda - nPagoACuota - nPunitorio;
                                        nPagoAPuni = nPunitorio + nCuantoQueda;
                                        nCuantoQueda = 0;
                                    }
                                    else
                                    {
                                        // edu nvo005
                                        aTmp1 = nDeuda * nCuantoQueda;
                                        aTmp2 = nDeuda + nPunitorio;
                                        if (nCuantoQueda < 15) aTmp3 = aTmp1 / aTmp2; else aTmp3 = Redondeo(aTmp1 / aTmp2);
                                        if (aTmp3 > nDeuda) aTmp3 = nDeuda;
                                        nPagoACuota = aTmp3;
                                        nPagoAPuni = nCuantoQueda - aTmp3;
                                        //??
                                    }
                                }
                            }
                            else
                            {
                                if (nCuantoQueda >= nDeuda + nPunitorio)
                                {
                                    nPagoACuota = nDeuda;
                                    nPagoAPuni = nPunitorio;
                                }
                                else
                                {
                                    aTmp1 = nDeuda * nCuantoQueda;
                                    aTmp2 = nDeuda + nPunitorio;
                                    if (nCuantoQueda < 15) aTmp3 = aTmp1 / aTmp2; else aTmp3 = Redondeo(aTmp1 / aTmp2);
                                    if (aTmp3 > nDeuda) aTmp3 = nDeuda;
                                    nPagoACuota = aTmp3;
                                    nPagoAPuni = nCuantoQueda - aTmp3;
                                }
                            }
                            bb = Paga_Cuota("Refinanciado", regCredito.EmpresaID, nCuo, cu.ComercioID,
                                            cu.CreditoID, nPagoACuota, nPagoAPuni, nPagoAPuni, false, nRefCobra, ref lTrans);

                            bl.Grabar(BaseID);

                            if (bb == 0) break;
                            if (nCuantoQueda > 0) nCuantoQueda = nCuantoQueda - (nPagoACuota + nPagoAPuni);
                        }
                    }                                               // lo que queda del importe a pagar
                    else
                    {
                        break;
                    }
                }

            }
            if (bFormaPago)
            {
                Abre_FormadePago(Convert.ToDecimal(txtPagoAPagarR.Text), regCredito.EmpresaID, regCredito.ComercioID, Convert.ToInt32(txtBuscaCred.Text), nCuo, bb);
            }

            bl.GrabarTransmisiones(BaseID, lTrans);

            if (bb > 0)
            {
                MessageBox.Show("Pago realizado", "Crédito refinanciado");
                Limpia();
                Buscar_Credito(nCreditoPagar, nComercioPagar); //**EDU MOR**//
            }
        }
        private void Cancela_Refinanciacion()
        {
            //Cancelarefinanciacion

            if (Busca_Permiso(bl.pGlob.Configuracion.permCancelaRefi))
            {
                DialogResult res = MessageBox.Show("¿Cancelar la refinanciación?", "Crédito refinanciado", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (res == DialogResult.Cancel) return;
                int nCred = Convert.ToInt32(txtBuscaCred.Text);       //**EDU MOR**//
                int nComer = Convert.ToInt32(txtBuscaCom.Text);       //**EDU MOR**//       

                if (bEsPru)
                {
                    regCredito = bl.dalPrueba.Get<Credito>(c => c.EmpresaID == BaseID
                                                   && c.ComercioID == nComer && c.CreditoID == nCred).FirstOrDefault();
                }
                else
                {
                    regCredito = bl.Get<Credito>(BaseID, c => c.EmpresaID == BaseID
                                                   && c.ComercioID == nComer && c.CreditoID == nCred).FirstOrDefault();
                }
                if (regCredito == null)
                {

                }
                else
                {
                    if (regRefinanciacion != null)
                    {
                        regCredito.RefinanciacionID = null;
                        regRefinanciacion.EstadoID = bl.pGlob.Eliminado.EstadoID;
                        regRefinanciacion.FechaComerAnula = DateTime.Now;
                        int BaseID = bl.GetEmpresa(bEsPru).EmpresaID.Value;

                        bl.ActualizarTransaccional<Credito>(BaseID, regCredito);
                        bl.ActualizarTransaccional<Refinanciacion>(BaseID, regRefinanciacion);
                        bl.Grabar(BaseID);
                        List<Transmision> ltrans = new List<Transmision>();
                        ltrans = bl.Transmision<Refinanciacion>(ltrans, regRefinanciacion, bl.GetComercio(BaseID), bl.pGlob.TransBajaRefinanciacion, bl.pGlob.UriRefinanciacion);
                        bl.GrabarTransmisiones(BaseID, ltrans);

                        MessageBox.Show("Refinanciación cancelada", "Crédito refinanciado");
                        Limpia();
                        Buscar_Credito(nCreditoPagar, nComercioPagar);
                    }
                }
            }
        }

        private void btnRefi_Click(object sender, EventArgs e)
        {
            if (bAbogado)
            {
                MessageBox.Show("Crédito en abogado", "Abogado");
                return;
            }
            // IR A CLAVES Y PERMISOS PARA MOSTRAR LA PANTALLA REFINANCIACION
            FrmRefinanciacion frmRefi = new FrmRefinanciacion(this.p, regCredito.Documento, regCredito.Cliente.NombreCompleto, regCredito.TipoDocumentoID
                                        , regCredito.EmpresaID, regCredito.ComercioID, regCredito.CreditoID, lblMor.Visible);
            frmRefi.ShowDialog();
            frmRefi.Close();
            Limpia();

            Buscar_Credito(nCreditoPagar, nComercioPagar);
        }

        private void btnAntiPagar_Click(object sender, EventArgs e)
        {
            Manda_Pagar_Anti();
        }
        private void Manda_Pagar_Anti()
        {
            int nCuot = 0;
            decimal nImp = 0;
            decimal nPuni = 0;
            int bb = 0;
            decimal ValorPagoTotal = 0;
            int BaseID = bl.GetEmpresa(bEsPru).EmpresaID.Value;

            DialogResult res = MessageBox.Show("¿Cancelar el crédito?" + Environment.NewLine + "por" + Environment.NewLine + "$ "
                                + lblAntiAPagar.Text, "Pago anticipado", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (res == DialogResult.Cancel) return;

            ValorPagoTotal = Convert.ToDecimal(lblAntiAPagar.Text);
            List<Transmision> lTrans = new List<Transmision>();
            lTrans = bl.Transmision(lTrans, bl.GetComercio(BaseID), bl.pGlob.TransAltaPagoAnticipado, bl.pGlob.UriPagoAnticipado);

            foreach (ListViewItem aa in listAntiCuotas.Items)
            {
                if (aa.SubItems[0].Text == "a1") break;
                nCuot = Convert.ToInt16(aa.SubItems[0].Text);
                nImp = Convert.ToDecimal(aa.SubItems[1].Text);
                nPuni = Convert.ToDecimal(aa.SubItems[2].Text);

                bb = Paga_Cuota("Pago anticipado", regCredito.EmpresaID, nCuot, nComercioPagar, nCreditoPagar,
                             nImp, nPuni, nPuni, false, 0, ref lTrans);
                if (bb == 0) break;
            }

            if (bb > 0) Graba_NotaCD(nCuot, bb, Convert.ToDecimal(lblAntiDescuento.Text), "Pago anticipado", ref lTrans);
            if (bFormaPago)
            {
                Abre_FormadePago(ValorPagoTotal, regCredito.EmpresaID, nComercioPagar, Convert.ToInt32(txtBuscaCred.Text), nCuot, bb);
            }
            MessageBox.Show("Pago realizado", "Pago anticipado");
            bl.Grabar(BaseID); //**EDU MOR**//   YA ESTA
            bl.GrabarTransmisiones(BaseID, lTrans);


            if (bb > 0)
            {
                Limpia();
                Buscar_Credito(nCreditoPagar, nComercioPagar);//**EDU MOR**//  
            }
        }

        private void btnArregloPagar_Click(object sender, EventArgs e)
        {
            Manda_Pagar_Arreglo();
        }
        private void Manda_Pagar_Arreglo()
        {
            DialogResult res = MessageBox.Show("¿Cancelar el crédito?" + Environment.NewLine + "por" + Environment.NewLine + "$ " +
                                                txtArregloAPagar.Text, "Arreglo de pago", MessageBoxButtons.OKCancel,
                                                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (res == DialogResult.Cancel) return;

            decimal nPagoQueda = 0;
            decimal nPago = 0;
            decimal nPagoPuni = 0;
            decimal nPagoCalc = 0;
            int nPagoCuota = 0;
            int bb = 0;
            decimal ValorPagoTotal = 0;

            nPagoQueda = Convert.ToDecimal(txtArregloAPagar.Text);
            ValorPagoTotal = Convert.ToDecimal(txtArregloAPagar.Text);
            List<Transmision> lTrans = new List<Transmision>();
            lTrans = bl.Transmision(lTrans, Com, bl.pGlob.TransAltaArregloCancelacion, bl.pGlob.UriArregloCancelacion);
            int nCuotaCuota = 0;

            foreach (Cuota cu in regCuotaList)
            {
                nCuotaCuota++;  //edu20211203
                if (cu.Deuda > 0)
                {
                    if (cu.Importe - cu.ImportePago > 0)
                    {

                    }
                    nPagoCuota = cu.CuotaID;
                    nPago = cu.Deuda;
                    nPagoPuni = 0;
                    nPagoCalc = Calcula_Punitorio(cu.Deuda, cu.FechaVencimiento, Com.Por30.Value, Com.Por30M.Value, false);
                    nPagoQueda = nPagoQueda - nPago;
                    if (cu.CuotaID == cu.Credito.CantidadCuotas || nCuotaCuota == regCuotaList.Count()) nPagoPuni = nPagoQueda;//edu20211203

                    bb = Paga_Cuota("Arreglo", regCredito.EmpresaID, nPagoCuota, nComercioPagar, nCreditoPagar,
                        nPago, nPagoPuni, nPagoCalc, false, 0, ref lTrans);
                    if (bb == 0) break;
                }
            }
            if (bFormaPago)
            {
                Abre_FormadePago(ValorPagoTotal, regCredito.EmpresaID, nComercioPagar, Convert.ToInt32(txtBuscaCred.Text), Convert.ToUInt16(lblPagoCuota.Text), bb);
            }


            int BaseID = bl.GetEmpresa(bEsPru).EmpresaID.Value;
            bl.Grabar(BaseID);
            bl.GrabarTransmisiones(BaseID, lTrans);

            if (bb > 0)
            {
                MessageBox.Show("Pago realizado", "Arreglo de pago");
                Limpia();
                Buscar_Credito(nCreditoPagar, nComercioPagar);
            }
            // aca un end begin

        }
        private void Prepara_PagoVarias()
        {
            lblVariasCancelar.Text = "0";
            //if (lblPuedeBoni.Text == "1") return;
            decimal dAcumulado = 0;
            decimal dApagar = 0;
            gridPagoVarias.Rows.Clear();
            txtPagoVarias.Text = "0";
            int nFila = 0;
            int TolBoni = 0;
            backColorList = Color.White;
            decimal dPorCuota = 0;
            decimal dPorPuni = 0;
            decimal dPorBoni = 0;
            //decimal dTotal = 0;

            foreach (DataGridViewRow d in gridCuotas.Rows)
            {
                if (Convert.ToDecimal(d.Cells[4].Value) > 0)
                {
                    gridPagoVarias.Rows.Add();
                    gridPagoVarias.Rows[nFila].DefaultCellStyle.BackColor = backColorList;
                    gridPagoVarias.Rows[nFila].Cells[0].Value = d.Cells[0].Value;    //cuota
                    //gridPagoVarias.Rows[nFila].Cells[1].Value = d.Cells[4].Value;   //deuda cuota
                    //gridPagoVarias.Rows[nFila].Cells[2].Value = d.Cells[5].Value;   //punitorios
                    //gridPagoVarias.Rows[nFila].Cells[3].Value = d.Cells[10].Value;   //boni
                    dPorCuota = Convert.ToDecimal(d.Cells[4].Value);
                    dPorPuni = Convert.ToDecimal(d.Cells[5].Value);
                    dPorBoni = Convert.ToDecimal(d.Cells[10].Value);
                    
                    if (lblPuedeBoni.Text == "1") bonificaManual = true;

                    if (dPorBoni == 0)
                    {
                        gridPagoVarias.Rows[nFila].Cells[1].Value = d.Cells[4].Value;   //deuda cuota
                        gridPagoVarias.Rows[nFila].Cells[2].Value = d.Cells[5].Value;   //punitorios
                        gridPagoVarias.Rows[nFila].Cells[3].Value = d.Cells[10].Value;   //boni
                        gridPagoVarias.Rows[nFila].Cells[4].Value = d.Cells[6].Value;   //total
                        dApagar = dPorCuota + dPorPuni - dPorBoni;

                    }
                    else
                    {
                        if (Com.ToleranciaBoni != null) TolBoni = Com.ToleranciaBoni.Value;
                        if (bl.PuedeBonificar(regCredito, TolBoni, Convert.ToInt16(d.Cells[0].Value.ToString())) || bonificaManual)
                        {
                            dPorPuni = 0;
                            dApagar = dPorCuota - dPorBoni;
                        }
                        else
                        {
                            dPorBoni = 0;
                            dApagar = dPorCuota + dPorPuni;
                        }
                        gridPagoVarias.Rows[nFila].Cells[1].Value = dPorCuota;// d.Cells[4].Value;   //deuda cuota
                        gridPagoVarias.Rows[nFila].Cells[2].Value = dPorPuni; // d.Cells[5].Value;   //punitorios
                        gridPagoVarias.Rows[nFila].Cells[3].Value = dPorBoni; // d.Cells[10].Value;   //boni
                        gridPagoVarias.Rows[nFila].Cells[4].Value = dApagar; // d.Cells[6].Value;   //total
                    }

                    dAcumulado = dAcumulado + dApagar;




                    //if (Convert.ToDecimal(d.Cells[10].Value) > 0)
                    //{
                    //    if (Com.ToleranciaBoni != null)
                    //        TolBoni = Com.ToleranciaBoni.Value;
                    //    if (bl.PuedeBonificar(regCredito, TolBoni, Convert.ToInt16(d.Cells[0].Value.ToString())) || bonificaManual)
                    //    {
                    //        gridPagoVarias.Rows[nFila].Cells[3].Value = d.Cells[10].Value;
                    //    }
                    //    else
                    //    {
                    //        dApagar = Convert.ToDecimal(d.Cells[4].Value) + Convert.ToDecimal(d.Cells[5].Value);
                    //    }

                    //}
                    //else if (Convert.ToDecimal(d.Cells[10].Value) == 0)
                    //{
                    //    dApagar = Convert.ToDecimal(d.Cells[6].Value);
                    //}
                    //else
                    //{
                    //    dApagar = Convert.ToDecimal(d.Cells[6].Value);// -Convert.ToDecimal(d.Cells[10].Value);
                    //}
                    
                    //gridPagoVarias.Rows[nFila].Cells[4].Value = dApagar.ToString("N2");


                    gridPagoVarias.Rows[nFila].Cells[5].Value = "0";
                    gridPagoVarias.Rows[nFila].Cells[6].Value = "0";
                    gridPagoVarias.Rows[nFila].Cells[7].Value = "0";   //aca
                    gridPagoVarias.Rows[nFila].Cells[8].Value = "0";   //aca
                    gridPagoVarias.Rows[nFila].Cells[9].Value = "";
                    gridPagoVarias.Rows[nFila].Cells[10].Value = d.Cells[1].Value;
                    gridPagoVarias.Rows[nFila].Cells[11].Value = d.Cells[11].Value;
                    gridPagoVarias.Rows[nFila].Cells[12].Value = dAcumulado.ToString("N2");
                    if (backColorList == Color.White) backColorList = Color.LightGray; else backColorList = Color.White;
                    nFila++;
                    //nCol = 0;

                }
            }

            lblVariasCancelar.Text = dAcumulado.ToString("N2");
            lblPagTit.Text = "Pago varias cuotas";
            lblPagQueHace.Text = "VARIAS";
            tablaPagar.SelectTab("tabVarias");
            //MuestraPanelConSombra(panelPagar, lblSombra, txtPagoVarias);
            tabControl1.Enabled = false;
            txtPagoVarias.Focus();
            //Auxiliar.Formatos.MuestraPanelConSombra(panelVarias, lblSombra, txtPagoVarias);
        }
        private void Busca_Imagenes()
        {
            if (bl.pGlob.Configuracion.ScanSolicitudes == false) return;
            nImagenesSoli = 0;
            lblIma.Text = "Buscando...";
            lblImaNombre.Text = "";
            cImagenesSoli = bl.BuscarSolicitudesImagen(nComercioPagar.ToString(), nCreditoPagar.ToString());
            if (cImagenesSoli != null && cImagenesSoli.Length > 0)
            {
                int nIma1 = 0;
                int nIma2 = 0;
                Image ima = bl.BuscarImagen(cImagenesSoli[nImagenesSoli]);
                picSoli.Image = ima;
                lblImaNombre.Text = cImagenesSoli[nImagenesSoli];
                nIma1 = nImagenesSoli + 1;
                nIma2 = cImagenesSoli.Length;
                lblIma.Text = nIma1.ToString() + " / " + nIma2.ToString();
            }
            else
            {
                lblIma.Text = "0/0";
            }


        }

        private void btnImaAnterior_Click(object sender, EventArgs e)
        {
            if (cImagenesSoli != null && cImagenesSoli.Length > 0)
            {
                if (cImagenesSoli.Length == 1) return;
                int nIma1 = 0;
                int nIma2 = cImagenesSoli.Length;
                if (nImagenesSoli == 0)
                {
                    nImagenesSoli = cImagenesSoli.Length - 1;
                }
                else
                {
                    nImagenesSoli = nImagenesSoli - 1;
                }
                Image ima = bl.BuscarImagen(cImagenesSoli[nImagenesSoli]);
                picSoli.Image = ima;
                nIma1 = nImagenesSoli + 1;
                lblIma.Text = nIma1.ToString() + " / " + nIma2.ToString();
                lblImaNombre.Text = cImagenesSoli[nImagenesSoli];
            }
        }

        private void btbImaSiguiente_Click(object sender, EventArgs e)
        {
            if (cImagenesSoli != null && cImagenesSoli.Length > 0)
            {
                if (cImagenesSoli.Length == 1) return;
                int nIma1 = 0;
                int nIma2 = cImagenesSoli.Length;
                if (nImagenesSoli == cImagenesSoli.Length - 1)
                {
                    nImagenesSoli = 0;
                }
                else
                {
                    nImagenesSoli++;
                }
                Image ima = bl.BuscarImagen(cImagenesSoli[nImagenesSoli]);
                picSoli.Image = ima;
                nIma1 = nImagenesSoli + 1;
                lblIma.Text = nIma1.ToString() + " / " + nIma2.ToString();
                lblImaNombre.Text = cImagenesSoli[nImagenesSoli];
            }
        }

        private void picSoli_DoubleClick(object sender, EventArgs e)
        {
            if (lblImaNombre.Text == "") return;
            Process.Start(lblImaNombre.Text);
        }

        private void GridCobranzas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (GridCobranzas.Rows[e.RowIndex].Cells[9].Value == null) return;
            //int ncredi = Convert.ToInt32(GridCobranzas.Rows[e.RowIndex].Cells[2].Value);
            int CuotaID= Convert.ToInt32(GridCobranzas.Rows[e.RowIndex].Cells[1].Value);
            int CobID= Convert.ToInt32(GridCobranzas.Rows[e.RowIndex].Cells[9].Value);
            Cobranza cobSel = regCobranzaList.FindAll(c => c.CuotaID == CuotaID
                                               && c.CobranzaID == CobID).OrderBy(c => c.FechaPago).SingleOrDefault();
            if (cobSel != null)
            {
                if (bl.EsCobranzaPorDebito(cobSel))
                {
                    DialogResult dr = MessageBox.Show("¿Desea convertir el pago a Efectivo?", "Débito a Efectivo", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        bl.ConvertirCobranzaAEfectivo(cobSel, Com);
                    }
                }
                else
                {
                    DialogResult dr = MessageBox.Show("¿Desea convertir el pago a Débito?", "Efectivo a Débito", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        bl.ConvertirCobranzaADebito(cobSel, Com);
                    }
                }


            }

        }

        private void btnCredNotas_Click(object sender, EventArgs e)
        {
            bool bEsPru = false;
            if (lblMor.Visible) bEsPru = true;
            FrmNotasCliCred frmNot = new FrmNotasCliCred(p, this.bl, Convert.ToInt32(txtBuscaCom.Text), regCredito.CreditoID, 0,
                                regCredito.Documento, lblCliNombCompleto.Text, regCredito.TipoDocumentoID, "CREDITO", bEsPru);
            frmNot.ShowDialog();
            frmNot.Close();
            Llena_nota();
        }

        private void frmCobranzaNva_Load(object sender, EventArgs e)
        {

        }
    }
}
