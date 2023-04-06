using System;
using System.Linq;
using System.Windows.Forms;
using iComercio.Models;
using Credin;
using System.Collections.Generic;
using System.Drawing;
using iComercio.Rest;


//using System.ComponentModel;
//using System.Data;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
//using System.Data.Entity;
//using iComercio.DAL;
//using iComercio.Delegados;
//using iComercio.ViewModels;
//using iComercio.Auxiliar;
//using System.Globalization;
//using System.Drawing.Drawing2D;

namespace iComercio.Forms
{
    public partial class FrmPuntaje : FRM                                                         //**edu**
    {
        List<PlanesParam> lparam;
        BindingSource profesionesBs = new BindingSource();
        
        Color backColorList = Color.White;
        Color fontColor = Color.Empty;
        Font fontList = new Font("Verdana", 10F, FontStyle.Regular);
        bool EsM;

        public FrmPuntaje()
        {
            InitializeComponent();
        }
        public FrmPuntaje (Principal p, RestApi ra, bool EsM)
            : base(p, ra)
        {
            InitializeComponent();
            this.EsM = EsM;
            RecargarEmpYComercio(EsM);
        }
        private void FrmPuntaje_Load(object sender, EventArgs e)
        {
            Configura_Inicio();
            fitFormToScreen();
        }
        private void Configura_Inicio()
        {
            Configura_Controles();
            Configura_Listas();
            Llena_Parametros();
            LLena_prueba_puntajes();
        }
        private void Configura_Controles()
        {
            Configura_Colores(bl.pGlob.Comercio.EmpresaID);
            Recorre_Formulario(this);
            this.BackColor = ColorBackColorFrm;
            Recorre_Formulario(this);
            foreach (Control c in this.Controls)
            {
                foreach (Control childc in c.Controls)
                {
                    if (childc is TextBox)
                    {
                        childc.Leave += new EventHandler(Evento_LeaveColor);
                        childc.Enter += new EventHandler(Evento_EnterColor);
                        childc.KeyPress += Txt_PasaConEnter_KeyPress;

                    }
                    if (childc is ComboBox)
                    {
                        childc.KeyPress += Txt_PasaConEnter_KeyPress;
                    }
                }
            }

        }

        private double Calcula_Puntaje(int nIngreso, int nCred, int nCancel, decimal nMora, string cLabo)
        {
            double Pun_Ingresos = 0;
            double Pun_Creditos = 0;
            double Pun_Cancelados = 0;
            double Pun_Morosidad = 0;
            double Pun_Laboral = 0;

            double nPorIngr = 0;
            double nPorCred = 0;
            double nPorCanc = 0;
            double nPorMora = 0;
            double nPorLabo = 0;
            foreach (ListViewItem ap in ListPorcentajes.Items)
            {
                if (ap.SubItems[2].Text == "INGRESOS")
                {
                    nPorIngr = Convert.ToDouble(ap.SubItems[1].Text);
                }
                if (ap.SubItems[2].Text == "CREDITOS")
                {
                    nPorCred = Convert.ToDouble(ap.SubItems[1].Text);
                }
                if (ap.SubItems[2].Text == "CANCELADOS")
                {
                    nPorCanc = Convert.ToDouble(ap.SubItems[1].Text);
                }
                if (ap.SubItems[2].Text == "MOROSIDAD")
                {
                    nPorMora = Convert.ToDouble(ap.SubItems[1].Text);
                }
                if (ap.SubItems[2].Text == "LABORAL")
                {
                    nPorLabo = Convert.ToDouble(ap.SubItems[1].Text);
                }
            }

            foreach (ListViewItem aa in ListPuntajes.Items)
            { 
                if(aa.SubItems[4].Text=="INGRESOS")
                {
                    if (Convert.ToInt32(aa.SubItems[1].Text) <= nIngreso && Convert.ToInt32(aa.SubItems[2].Text) >= nIngreso)
                    {
                        Pun_Ingresos = (Convert.ToDouble(aa.SubItems[3].Text) * nPorIngr) / 100;
                        break;
                    }
                }
            }

            foreach (ListViewItem aa in ListPuntajes.Items)
            {
                if (aa.SubItems[4].Text == "CREDITOS")
                {
                    if (Convert.ToInt16(aa.SubItems[1].Text) <= nCred && Convert.ToInt16(aa.SubItems[2].Text) >= nCred)
                    {
                        Pun_Creditos = (Convert.ToDouble(aa.SubItems[3].Text) * nPorCred) / 100;
                        break;
                    }
                }
            }
            if (nCred > 0)
            {
                foreach (ListViewItem aa in ListPuntajes.Items)
                {
                    if (aa.SubItems[4].Text == "CANCELADOS")
                    {
                        if (Convert.ToInt16(aa.SubItems[1].Text) <= nCancel && Convert.ToInt16(aa.SubItems[2].Text) >= nCancel)
                        {
                            Pun_Cancelados = (Convert.ToDouble(aa.SubItems[3].Text) * nPorCanc) / 100;
                            break;
                        }
                    }
                }
                if (Pun_Creditos > 0)
                {
                    foreach (ListViewItem aa in ListPuntajes.Items)
                    {
                        if (aa.SubItems[4].Text == "MOROSIDAD")
                        {
                            if (Convert.ToInt16(aa.SubItems[1].Text) <= nMora && Convert.ToInt16(aa.SubItems[2].Text) >= nMora)
                            {
                                Pun_Morosidad = (Convert.ToDouble(aa.SubItems[3].Text) * nPorMora) / 100;
                                break;
                            }
                        }
                    }
                }
            }
            foreach (ListViewItem aa in ListPuntajes.Items)
            {
                if (aa.SubItems[4].Text == "LABORAL")
                {
                    if (aa.SubItems[5].Text == cLabo)  // && aa.SubItems[1].Text >= cLabo)
                    {
                        Pun_Laboral = (Convert.ToDouble(aa.SubItems[3].Text) * nPorLabo) / 100;
                        break;
                    }
                }
            }

            return Pun_Ingresos + Pun_Creditos + Pun_Cancelados + Pun_Morosidad + Pun_Laboral;
        }
        
        private void Prepara_Puntaje()
        {
            double nPunta = 0;
            int nIngr = 0;
            int nCred = 0;
            int nCancel = 0;
            decimal nMor = 0;
            string cLab = "";

            foreach (ListViewItem aa in ListPruebas.Items)
            {
                nCred = Convert.ToInt16(aa.SubItems[1].Text);
                nCancel = Convert.ToInt16(aa.SubItems[2].Text);
                nMor = Convert.ToDecimal(aa.SubItems[3].Text);
                nIngr = Convert.ToInt32(aa.SubItems[4].Text);
                cLab = aa.SubItems[5].Text;
                nPunta = Calcula_Puntaje(nIngr, nCred, nCancel, nMor, cLab);
                aa.SubItems[6].Text = nPunta.ToString();
            }
        }


        private void Grabar_Cambios()
        {
            bool bGraba = false;
            int nCambios = 0;
            PlanesParam plaparam;
            if (BtnParamPasar.Enabled)
            {
                
                foreach (ListViewItem aa in ListPuntajes.Items)
                {
                    bGraba = false;    
                    plaparam = bl.GetPlanesParamByID(Convert.ToInt16(aa.Text));
                    if (plaparam.Desde.ToString() != aa.SubItems[1].Text)
                    {
                        bGraba = true;
                        plaparam.Desde = Convert.ToInt32(aa.SubItems[1].Text);
                    }
                    if (plaparam.Hasta.ToString() != aa.SubItems[2].Text)
                    {
                        bGraba = true;
                        plaparam.Hasta = Convert.ToInt32(aa.SubItems[2].Text);
                    }
                    if (plaparam.Valor.ToString() != aa.SubItems[3].Text)
                    {
                        bGraba = true;
                        plaparam.Valor = Convert.ToInt16(aa.SubItems[3].Text);
                    }
                    if (bGraba)
                    {
                        bl.ActualizarPlanesParam(plaparam);
                        nCambios++;
                    }
                }
            }

            if (BtnPorcenPasar.Enabled)
            {
                foreach (ListViewItem aa in ListPorcentajes.Items)
                {
                    bGraba = false;
                    plaparam = bl.GetPlanesParamByID(Convert.ToInt16(aa.Text));
                    if (plaparam.Valor.ToString() != aa.SubItems[1].Text)
                    {
                        bGraba = true;
                        plaparam.Valor = Convert.ToInt16(aa.SubItems[1].Text);
                    }
                    if (bGraba)
                    {
                        bl.ActualizarPlanesParam(plaparam);
                        nCambios++;
                    }
                }
            }

            if(nCambios>0)
            {
                MessageBox.Show(  "Cambios realizados: " + nCambios , "Puntajes de planes");
                BtnParamGrabar.Enabled = false;
                BtnParamPasar.Enabled = false;
                BtnPorcenPasar.Enabled = false;
                Llena_Parametros();

            }

        }
        private void PasarDatosList()
        {
            if(Convert.ToInt16(TxtParamValor.Text)<11)
            {
                ListPuntajes.SelectedItems[0].SubItems[1].Text = TxtParamD.Text;
                ListPuntajes.SelectedItems[0].SubItems[2].Text = TxtParamH.Text;
                ListPuntajes.SelectedItems[0].SubItems[3].Text = TxtParamValor.Text;
                ListPuntajes.SelectedItems[0].SubItems[3].BackColor = Color.Red;
                if(Convert.ToInt16(LblPorcenSuma.Text)==100) BtnParamGrabar.Enabled = true;
            }

        }
        private void PasaDatosPorcen(bool bCarga)
        {
            if(bCarga) ListPorcentajes.SelectedItems[0].SubItems[1].Text = TxtPorcen.Text;
            int nSuma = 0;
            LblPorcenSuma.ForeColor = Color.Black;
            foreach (ListViewItem aa in ListPorcentajes.Items)
            {
                nSuma =nSuma + Convert.ToInt16( aa.SubItems[1].Text);
            }
            LblPorcenSuma.Text = nSuma.ToString();
            if (nSuma != 100)
            {
                LblPorcenSuma.ForeColor = Color.Red;
                BtnParamGrabar.Enabled = false;
            }
            else { BtnParamGrabar.Enabled = true; }
        }

        private void Llena_Parametros()
        {
            ListPuntajes.Items.Clear();
            ListPorcentajes.Items.Clear();
            int nCambio = 1;
            //bool bColor = false;
            string cAplica = "";
            //Color qcolor;
            backColorList = Color.White;
            Font fontList = new Font("Verdana", 10F, FontStyle.Regular);

            lparam = bl.Get<PlanesParam>().ToList();
            if (lparam.Count == 0) return;

            cAplica = lparam[0].Param2;
            foreach (PlanesParam lpara in lparam)
            {
                if (lpara.Param2 != "PORCENTAJE")
                {
                    if (cAplica != lpara.Param2)
                    {
                        cAplica = lpara.Param2;
                        nCambio++;
                    }
                    if ((nCambio % 2) == 0) backColorList = Color.LightSteelBlue; else  backColorList = Color.White;

                    ListViewItem item = new ListViewItem(lpara.PlanesParamId.ToString());
                    item.UseItemStyleForSubItems = false;
                    item.SubItems.Add(lpara.Desde.ToString(), fontColor, backColorList, fontList);
                    item.SubItems.Add(lpara.Hasta.ToString(), fontColor, backColorList, fontList);
                    item.SubItems.Add(lpara.Valor.ToString(), fontColor, backColorList, fontList);
                    item.SubItems.Add(lpara.Param2.ToString(), fontColor, backColorList, fontList);
                    item.SubItems.Add(lpara.Param1.ToString(), fontColor, backColorList, fontList);
                    item.SubItems.Add(lpara.Orden.ToString(), fontColor, backColorList, fontList);
                    item.BackColor = backColorList;

                    ListPuntajes.Items.Add(item);
                }
                else
                {
                    ListViewItem item2 = new ListViewItem(lpara.PlanesParamId.ToString());
                    item2.UseItemStyleForSubItems = false;
                    item2.SubItems.Add(lpara.Valor.ToString(), fontColor, backColorList, fontList);
                    item2.SubItems.Add(lpara.Param1, fontColor, backColorList, fontList);
                    if (backColorList == Color.White) backColorList = Color.LightSteelBlue; else backColorList = Color.White;
                    ListPorcentajes.Items.Add(item2);

                }
            }                                               //foreach (PlanesParam lpara in lparam)

            PasaDatosPorcen(false);
            ListPuntajes.OwnerDraw = true;
            ListPuntajes.FullRowSelect = true;
            ListPuntajes.View = View.Details;

            ListPorcentajes.OwnerDraw = true;
            ListPorcentajes.FullRowSelect = true;
            ListPorcentajes.View = View.Details;
        }

        private void LLena_prueba_puntajes()
        {
            fontColor = Color.Empty;
            backColorList = Color.LightSteelBlue;
            fontList = new Font("Verdana", 9F, FontStyle.Regular);

            ListViewItem item = new ListViewItem("1");
            item.UseItemStyleForSubItems = false;
            item.SubItems.Add("1", fontColor, backColorList, fontList);
            item.SubItems.Add("1", fontColor, backColorList, fontList);
            item.SubItems.Add("0", fontColor, backColorList, fontList);
            item.SubItems.Add("50000", fontColor, backColorList, fontList);
            item.SubItems.Add("JUB", fontColor, backColorList, fontList);
            item.SubItems.Add("0", fontColor, backColorList, fontList);
            ListPruebas.Items.Add(item);
            //                                                                                      2
            if (backColorList == Color.White) backColorList = Color.LightSteelBlue; else backColorList = Color.White;
            item = new ListViewItem("2");
            item.UseItemStyleForSubItems = false;
            item.SubItems.Add("6", fontColor, backColorList, fontList);
            item.SubItems.Add("6", fontColor, backColorList, fontList);
            item.SubItems.Add("0", fontColor, backColorList, fontList);
            item.SubItems.Add("50000", fontColor, backColorList, fontList);
            item.SubItems.Add("JUB", fontColor, backColorList, fontList);
            item.SubItems.Add("0", fontColor, backColorList, fontList);
            ListPruebas.Items.Add(item);
            //                                                                                      3
            if (backColorList == Color.White) backColorList = Color.LightSteelBlue; else backColorList = Color.White;
            item = new ListViewItem("3");
            item.UseItemStyleForSubItems = false;
            item.SubItems.Add("12", fontColor, backColorList, fontList);
            item.SubItems.Add("12", fontColor, backColorList, fontList);
            item.SubItems.Add("0", fontColor, backColorList, fontList);
            item.SubItems.Add("50000", fontColor, backColorList, fontList);
            item.SubItems.Add("JUB", fontColor, backColorList, fontList);
            item.SubItems.Add("0", fontColor, backColorList, fontList);
            ListPruebas.Items.Add(item);

            //                                                                                      4
            if (backColorList == Color.White) backColorList = Color.LightSteelBlue; else backColorList = Color.White;
            item = new ListViewItem("4");
            item.UseItemStyleForSubItems = false;
            item.SubItems.Add("1", fontColor, backColorList, fontList);
            item.SubItems.Add("1", fontColor, backColorList, fontList);
            item.SubItems.Add("30", fontColor, backColorList, fontList);
            item.SubItems.Add("50000", fontColor, backColorList, fontList);
            item.SubItems.Add("JUB", fontColor, backColorList, fontList);
            item.SubItems.Add("0", fontColor, backColorList, fontList);
            ListPruebas.Items.Add(item);

            //                                                                                      5
            if (backColorList == Color.White) backColorList = Color.LightSteelBlue; else backColorList = Color.White;
            item = new ListViewItem("5");
            item.UseItemStyleForSubItems = false;
            item.SubItems.Add("6", fontColor, backColorList, fontList);
            item.SubItems.Add("6", fontColor, backColorList, fontList);
            item.SubItems.Add("30", fontColor, backColorList, fontList);
            item.SubItems.Add("50000", fontColor, backColorList, fontList);
            item.SubItems.Add("JUB", fontColor, backColorList, fontList);
            item.SubItems.Add("0", fontColor, backColorList, fontList);
            ListPruebas.Items.Add(item);

            //                                                                                      6
            if (backColorList == Color.White) backColorList = Color.LightSteelBlue; else backColorList = Color.White;
            item = new ListViewItem("6");
            item.UseItemStyleForSubItems = false;
            item.SubItems.Add("12", fontColor, backColorList, fontList);
            item.SubItems.Add("12", fontColor, backColorList, fontList);
            item.SubItems.Add("30", fontColor, backColorList, fontList);
            item.SubItems.Add("50000", fontColor, backColorList, fontList);
            item.SubItems.Add("JUB", fontColor, backColorList, fontList);
            item.SubItems.Add("0", fontColor, backColorList, fontList);
            ListPruebas.Items.Add(item);

            //                                                                                      7
            if (backColorList == Color.White) backColorList = Color.LightSteelBlue; else backColorList = Color.White;
            item = new ListViewItem("7");
            item.UseItemStyleForSubItems = false;
            item.SubItems.Add("10", fontColor, backColorList, fontList);
            item.SubItems.Add("8", fontColor, backColorList, fontList);
            item.SubItems.Add("30", fontColor, backColorList, fontList);
            item.SubItems.Add("50000", fontColor, backColorList, fontList);
            item.SubItems.Add("JUB", fontColor, backColorList, fontList);
            item.SubItems.Add("0", fontColor, backColorList, fontList);
            ListPruebas.Items.Add(item);
            //                                                                                      8
            if (backColorList == Color.White) backColorList = Color.LightSteelBlue; else backColorList = Color.White; ;
            item = new ListViewItem("8");
            item.UseItemStyleForSubItems = false;
            item.SubItems.Add("25", fontColor, backColorList, fontList);
            item.SubItems.Add("24", fontColor, backColorList, fontList);
            item.SubItems.Add("30", fontColor, backColorList, fontList);
            item.SubItems.Add("50000", fontColor, backColorList, fontList);
            item.SubItems.Add("JUB", fontColor, backColorList, fontList);
            item.SubItems.Add("0", fontColor, backColorList, fontList);
            ListPruebas.Items.Add(item);
            //                                                                                      9
            if (backColorList == Color.White) backColorList = Color.LightSteelBlue; else backColorList = Color.White;
            item = new ListViewItem("9");
            item.UseItemStyleForSubItems = false;
            item.SubItems.Add("25", fontColor, backColorList, fontList);
            item.SubItems.Add("25", fontColor, backColorList, fontList);
            item.SubItems.Add("0", fontColor, backColorList, fontList);
            item.SubItems.Add("50000", fontColor, backColorList, fontList);
            item.SubItems.Add("JUB", fontColor, backColorList, fontList);
            item.SubItems.Add("0", fontColor, backColorList, fontList);
            ListPruebas.Items.Add(item);
            //                                                                                      10
            if (backColorList == Color.White) backColorList = Color.LightSteelBlue; else backColorList = Color.White;
            item = new ListViewItem("10");
            item.UseItemStyleForSubItems = false;
            item.SubItems.Add("40", fontColor, backColorList, fontList);
            item.SubItems.Add("40", fontColor, backColorList, fontList);
            item.SubItems.Add("10", fontColor, backColorList, fontList);
            item.SubItems.Add("50000", fontColor, backColorList, fontList);
            item.SubItems.Add("JUB", fontColor, backColorList, fontList);
            item.SubItems.Add("0", fontColor, backColorList, fontList);
            ListPruebas.Items.Add(item);

            
            ListPruebas.OwnerDraw = true;
            ListPruebas.FullRowSelect = true;
            ListPruebas.View = View.Details;

            Prepara_Puntaje();
        }
        private void Configura_Listas()
        {
            profesionesBs.DataSource = bl.GetProfesionesPadres(BaseID,null, null, "ProfesionPadre");
            Utilidades.CargarCombo(cmbProfesion, profesionesBs, "Nombre", "ProfesionID");

            ListPuntajes.View = View.Details;
            ListPuntajes.Columns.Add("", 0, HorizontalAlignment.Right);
            ListPuntajes.Columns.Add("Desde", 65, HorizontalAlignment.Right);
            ListPuntajes.Columns.Add("Hasta", 65, HorizontalAlignment.Right);
            ListPuntajes.Columns.Add("Valor", 40, HorizontalAlignment.Right);
            ListPuntajes.Columns.Add("Aplica", 100, HorizontalAlignment.Left);
            ListPuntajes.Columns.Add("Detalle", 70, HorizontalAlignment.Right);
            ListPuntajes.Columns.Add("Orden", 45, HorizontalAlignment.Right);
            //ListPuntajes.Columns.Add("ID", 40, HorizontalAlignment.Right);
            ListPuntajes.OwnerDraw = true;

            ListPorcentajes.View = View.Details;
            ListPorcentajes.Columns.Add("", 0, HorizontalAlignment.Right);
            ListPorcentajes.Columns.Add("%", 80, HorizontalAlignment.Right);
            ListPorcentajes.Columns.Add("Aplica", 160, HorizontalAlignment.Left);
            ListPorcentajes.OwnerDraw = true;


            ListPruebas.View = View.Details;
            ListPruebas.Columns.Add("", 0, HorizontalAlignment.Right);
            ListPruebas.Columns.Add("Créditos", 65, HorizontalAlignment.Right);
            ListPruebas.Columns.Add("Cancelados", 80, HorizontalAlignment.Right);
            ListPruebas.Columns.Add("Mora", 65, HorizontalAlignment.Right);
            ListPruebas.Columns.Add("Ingresos", 65, HorizontalAlignment.Left);
            ListPruebas.Columns.Add("Laboral", 65, HorizontalAlignment.Left);
            ListPruebas.Columns.Add("Puntaje", 65, HorizontalAlignment.Left);
            ListPruebas.OwnerDraw = true;
        
        }

 

        private void ListPuntajes_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            TxtParamD.Text = "0";
            TxtParamH.Text = "0";
            TxtParamValor.Text = "0";
            LblParamID.Text = "";
            LblParamP.Text = "";
            BtnParamPasar.Enabled = false;
            foreach (ListViewItem aa in ListPuntajes.SelectedItems)
            {
                LblParamID.Text=aa.Text;
                LblParamP.Text = aa.SubItems[4].Text;
                TxtParamD.Text = aa.SubItems[1].Text;
                TxtParamH.Text = aa.SubItems[2].Text;
                TxtParamValor.Text = aa.SubItems[3].Text;
                LblParamParam.Text = aa.SubItems[4].Text;
                BtnParamPasar.Enabled = true;
            }
        }

    

        private void ListPorcentajes_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            BtnPorcenPasar.Enabled = false;
            TxtPorcen.Text = "=";
            LblPorcenID.Text = "";
            LblPorcenParam.Text = "";
            foreach (ListViewItem aa in ListPorcentajes.SelectedItems)
            {
                LblPorcenID.Text = aa.Text;
                LblPorcenParam.Text = aa.SubItems[2].Text;
                TxtPorcen.Text = aa.SubItems[1].Text;
                BtnPorcenPasar.Enabled = true;
            }
        }

        private void BtnPorcenPasar_Click(object sender, System.EventArgs e)
        {
            PasaDatosPorcen(true);
            //BtnParamGrabar.Enabled = true;
            Prepara_Puntaje();
        }

        private void BtnParamPasar_Click(object sender, System.EventArgs e)
        {
            PasarDatosList();
            //BtnParamGrabar.Enabled = true;
            Prepara_Puntaje();
        }

        private void BtnParamGrabar_Click(object sender, System.EventArgs e)
        {
            Grabar_Cambios();
        }
      

        private void BtnPruPasa_Click(object sender, EventArgs e)
        {
            Carga_Pru_Datos();
            Prepara_Puntaje();
            ListPruebas.Focus();
        }
        private void Carga_Pru_Datos()
        {
            ListPruebas.SelectedItems[0].SubItems[1].Text = TxtPruCred.Text;
            ListPruebas.SelectedItems[0].SubItems[2].Text = TxtPruCanc.Text;
            ListPruebas.SelectedItems[0].SubItems[3].Text = TxtPruMora.Text;
            ListPruebas.SelectedItems[0].SubItems[4].Text = TxtPruIngr.Text;
            ListPruebas.SelectedItems[0].SubItems[5].Text = cmbProfesion.SelectedValue.ToString();
        }
        private void ListPruebas_SelectedIndexChanged(object sender, EventArgs e)
        {
            BtnPruPasa.Enabled = false;
            foreach (ListViewItem aa in ListPruebas.SelectedItems)
            {
                lblFlechaI.Top = aa.Position.Y + ListPruebas.Top;
                lblFlechaD.Top = lblFlechaI.Top;
                TxtPruCred.Text = aa.SubItems[1].Text;
                TxtPruCanc.Text = aa.SubItems[2].Text;
                TxtPruMora.Text = aa.SubItems[3].Text;
                TxtPruIngr.Text = aa.SubItems[4].Text;

                for (int i = 0; i < cmbProfesion.Items.Count; i++)
                {
                    if(cmbProfesion.Items[i].ToString() == aa.SubItems[5].Text)
                    {

                    }
                    cmbProfesion.SelectedIndex = i;
                    if(cmbProfesion.SelectedValue.ToString()==aa.SubItems[5].Text)
                    {
                        break;
                    }
                }
                    //cmbProfesion.SelectedIndex = cmbProfesion.Items.IndexOf(aa.SubItems[5].Text);

                BtnPruPasa.Enabled = true;
            }
        }

        private void TxtParamValor_Leave(object sender, EventArgs e)
        {
            if(Convert.ToInt16(TxtParamValor.Text)>10)
            { BtnParamPasar.Enabled = false; }
            else
            { BtnParamPasar.Enabled = true; }

        }
    }
}
