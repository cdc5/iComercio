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
    public partial class FrmPlanes : FRM                                                         //**edu**
    {
        List<PlanesTipo> lplanes;
        Color backColorList = Color.White;
        Color fontColor = Color.Empty;
        Font fontList = new Font("Verdana", 7F, FontStyle.Regular);

        public FrmPlanes()
        {
            InitializeComponent();
        }
        public FrmPlanes(Principal p, RestApi ra)
            : base(p, ra)
        {
            InitializeComponent();
            RecargarEmpYComercio(false);
            Configura_Inicio();
        }
        private void Planes_Load(object sender, EventArgs e)
        {
            fitFormToScreen();
            RecargarEmpYComercio(false);
        }

        private void Prueb_Planes(string cT, decimal Interes, decimal InteresIncr, decimal Gst, decimal GstIncr, decimal GstFijo
                                    ,decimal Comis,decimal ComisIncr, DateTime Fecha_PriVenci)
        {
            fontColor = Color.Empty;
            backColorList = Color.LightSteelBlue;

            decimal Inter_x_cuota;
            decimal Interes_total;
            decimal Valor_total;
            decimal Valor_cuota;
            Decimal ValorNominal = Convert.ToDecimal(txtPValor.Text);
            decimal Valor_Gst;
            decimal Valor_Comis;
            decimal redon_Total = 0;
            decimal redon_Int = 0;

            Fecha_PriVenci = Fecha_PriVenci.AddMonths(1);
            listPruebas.Items.Clear();
            for (int i = 1; i < 21; i++)
            {
                ListViewItem item = new ListViewItem(i.ToString());                     //0
                item.SubItems.Add(cT, fontColor, backColorList, fontList);                                        // tipo
                item.SubItems.Add(i.ToString(), fontColor, backColorList, fontList);                             //cuo

                Inter_x_cuota = (Interes * i) + (InteresIncr * i * (i - 1));
                item.SubItems.Add(Inter_x_cuota.ToString("N2"), fontColor, backColorList, fontList); ;               //tasa

                item.SubItems.Add(ValorNominal.ToString("N2"), fontColor, backColorList, fontList);                    //monto

                Interes_total = (Inter_x_cuota * ValorNominal) / 100;
                item.SubItems.Add(Interes_total.ToString("N2"), fontColor, backColorList, fontList);                                                 //int                       

                Valor_total = Interes_total + ValorNominal;
                item.SubItems.Add(Valor_total.ToString("N2"), fontColor, backColorList, fontList);                                                //total

                Valor_cuota = Valor_total / i;
                Valor_cuota = Convert.ToDecimal(Redondeo(Valor_cuota));
                item.SubItems.Add(Valor_cuota.ToString("N2"), fontColor, backColorList, fontList);                                                //V cuota
                item.SubItems.Add(Fecha_PriVenci.ToShortDateString(), fontColor, backColorList, fontList);                                     //venci

                if (GstFijo == 0)
                {
                    Valor_Gst = (ValorNominal * Gst / 100) + (GstIncr * i * (i - 1));
                }
                else
                {
                    Valor_Gst = GstFijo;
                }
                item.SubItems.Add(Valor_Gst.ToString("N2"), fontColor, backColorList, fontList);                                                //gst
                
                Valor_Comis = (ValorNominal * Comis / 100) + (ComisIncr * i * (i - 1));
                item.SubItems.Add(Valor_Comis.ToString("N2"), fontColor, backColorList, fontList);                                                  //comi
                
                redon_Total = i * Valor_cuota;
                redon_Int = redon_Total - ValorNominal;
                item.SubItems.Add(redon_Int.ToString("N2"), fontColor, backColorList, fontList);                                                //redon

                item.SubItems.Add(redon_Total.ToString("N2"), fontColor, backColorList, fontList);                                                //redon int

                listPruebas.Items.Add(item);
                if (backColorList == Color.White) backColorList = Color.LightSteelBlue; else backColorList = Color.White;
            }
            listPruebas.OwnerDraw = true;
            listPruebas.BackColor = Color.White;
            listPruebas.ForeColor = Color.Black;
            listPruebas.FullRowSelect = true;
            listPruebas.View = View.Details;
        }

        private void Configura_Controles()
        {
            Configura_Colores(bl.pGlob.Comercio.EmpresaID);
            Recorre_Formulario(this);
            this.BackColor = ColorBackColorFrm;
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
            
            List<TipoRetencionPlan> regTR = bl.GetTipoRetencionPlan(BaseID);
            Utilidades.CargarCombo(cmbRetencion, regTR, "Nombre", "TipoRetencionPlanID");

            Asigna_Poder_Mover(grpPlan);
            Asigna_Poder_Mover(grpVencimiento);
            Asigna_Poder_Mover(grpBonifica);
            Asigna_Poder_Mover(grpDetalle);
            grpPruebas.Left = panel1.Left; //edu202009
            grpPruebas.Top = panel1.Top; //edu202009
        }
        private void Configura_Inicio()
        {
            lblMor.Visible = false;
            Configura_Controles();
            panel1.Top = ListPlanes.Top + ListPlanes.Height + 5;            
            panel1.Width = ListPlanes.Width + 100;
            panel1.Left = ListPlanes.Left;
            panel1.Height = this.Height - ListPlanes.Top - ListPlanes.Height - 50;
            panel1.Visible = true;

            //grpPruebas.Width = panel1.Width;
            grpVencimiento.Top = ListPlanes.Top;
            grpDetalle.Top = grpVencimiento.Top;
            grpPlan.Top = grpVencimiento.Top;
            grpPlan.Top = grpVencimiento.Top;
            grpBonifica.Top = grpVencimiento.Top;

            //grpPlan.Left = BtnPLanNvo.Left + BtnPLanNvo.Width + 10; Comentado por Chris
            grpPlan.Left = 428; 
            grpVencimiento.Left =grpPlan.Left ;
            grpDetalle.Left =grpPlan.Left ;
            grpBonifica.Left = grpPlan.Left;

            LblPlan.Text = "";
            Configura_Listas();
            Llena_combos();
            Carga_Planes();
            txtPValor.Text = "1000";
        }

        private void Carga_PlanesXXX()
        {
            decimal nTmp = 0;
            ListDeta.Items.Clear();
            ListVenci.Items.Clear();
            ListBoni.Items.Clear();
            ListPlanes.Items.Clear();

            fontColor = Color.Empty;
            backColorList = Color.LightSteelBlue;
            lplanes = bl.GetPlanesTipos(null, o => o.OrderBy(c => c.NroORden)).ToList();
            foreach (PlanesTipo lplane in lplanes)
            {
                ListViewItem item = new ListViewItem(lplane.PlanesTipoID); // ,0,fontColor, backColorList, fontList);
                item.UseItemStyleForSubItems = false;
                item.SubItems.Add(lplane.PlanesTipoID, fontColor, backColorList, fontList);             //1
                item.SubItems.Add(lplane.TipoAV, fontColor, backColorList, fontList);                //2
                item.SubItems.Add(lplane.PuntoD.ToString(), fontColor, backColorList, fontList);             //3
                item.SubItems.Add(lplane.PuntoH.ToString(), fontColor, backColorList, fontList);             //4
                item.SubItems.Add(lplane.Inter.ToString(), fontColor, backColorList, fontList);             //5
                item.SubItems.Add(lplane.Inter_Incr.ToString(), fontColor, backColorList, fontList);             //6
                item.SubItems.Add(lplane.Gasto.ToString(), fontColor, backColorList, fontList);              //7
                item.SubItems.Add(lplane.Gasto_Incr.ToString(), fontColor, backColorList, fontList);             //8
                if (lplane.GastoFijo != null) nTmp = (decimal)lplane.GastoFijo; else nTmp = 0;
                item.SubItems.Add(nTmp.ToString(), fontColor, backColorList, fontList);             //9

                item.SubItems.Add(lplane.Comis.ToString(), fontColor, backColorList, fontList);             //10
                item.SubItems.Add(lplane.Comis_Incr.ToString(), fontColor, backColorList, fontList);             //11
                item.SubItems.Add(lplane.Notas, fontColor, backColorList, fontList);                         //12
                item.SubItems.Add(lplane.Corte.ToString(), fontColor, backColorList, fontList);             //13
                item.SubItems.Add(lplane.NroORden.ToString(), fontColor, backColorList, fontList);             //
                item.SubItems.Add(lplane.TipoRetencionPlanID, fontColor, backColorList, fontList);             //
                if (backColorList == Color.White) backColorList = Color.LightSteelBlue; else backColorList = Color.White;

                ListPlanes.Items.Add(item);
                ListPlanes.OwnerDraw = true;
                ListPlanes.BackColor = Color.White;
                ListPlanes.ForeColor = Color.Black;
                ListPlanes.FullRowSelect = true;
                ListPlanes.View = View.Details;
            }               
            BtnPLanNvo.Enabled = true;

        }
        private void Configura_Listas()
        {
            ListPlanes.Columns.Add("", 0, HorizontalAlignment.Left);                        //0
            ListPlanes.Columns.Add("ID", 120, HorizontalAlignment.Left);                        //1
            ListPlanes.Columns.Add("Tipo", 40, HorizontalAlignment.Left);                     //2              
            ListPlanes.Columns.Add("Puntos desde", 45, HorizontalAlignment.Right);                    //3
            ListPlanes.Columns.Add("Puntos Hasta", 60, HorizontalAlignment.Right);                    //4
            ListPlanes.Columns.Add("Interes", 60, HorizontalAlignment.Right);               //5
            ListPlanes.Columns.Add("Incremento interes", 65, HorizontalAlignment.Right);                    //6
            ListPlanes.Columns.Add("Gasto", 60, HorizontalAlignment.Right);                 //7
            ListPlanes.Columns.Add("Incremento gasto", 70, HorizontalAlignment.Right);                    //8
            ListPlanes.Columns.Add("Gasto fijo", 60, HorizontalAlignment.Right);                 //9
            ListPlanes.Columns.Add("Comisión", 70, HorizontalAlignment.Right);              //10
            ListPlanes.Columns.Add("Incremento comisión", 70, HorizontalAlignment.Right);                    //11
            ListPlanes.Columns.Add("Notas", 40, HorizontalAlignment.Left);                    //12
            ListPlanes.Columns.Add("Corte", 40, HorizontalAlignment.Right);                    //13
            ListPlanes.Columns.Add("Orden", 40, HorizontalAlignment.Right);                    //14
            ListPlanes.Columns.Add("Retención", 60, HorizontalAlignment.Right);                    //14

            ListDeta.View = View.Details;
            ListDeta.Columns.Add("ID", 40, HorizontalAlignment.Right);                        //0
            ListDeta.Columns.Add("", 0, HorizontalAlignment.Left);                            //1
            ListDeta.Columns.Add("Cuotas desde", 45, HorizontalAlignment.Right);                      //2
            ListDeta.Columns.Add("Cuotas Hasta", 45, HorizontalAlignment.Right);                      //3
            //ListDeta.Columns.Add("Créditos", 50, HorizontalAlignment.Left);
            //ListDeta.Columns.Add("Créditos desde", 60, HorizontalAlignment.Right);
            //ListDeta.Columns.Add("Créditos Hasta", 60, HorizontalAlignment.Right);
            //ListDeta.Columns.Add("Canceldos", 40, HorizontalAlignment.Left);
            //ListDeta.Columns.Add("Canceldos desde", 60, HorizontalAlignment.Right);
            //ListDeta.Columns.Add("Canceldos Hasta", 60, HorizontalAlignment.Right);
            //ListDeta.Columns.Add("Mora", 40, HorizontalAlignment.Left);
            //ListDeta.Columns.Add("Mora desde", 60, HorizontalAlignment.Right);
            //ListDeta.Columns.Add("Mora Hasta", 60, HorizontalAlignment.Right);
            ListDeta.Columns.Add("Valor", 40, HorizontalAlignment.Left);                              //4
            ListDeta.Columns.Add("Valor desde", 90, HorizontalAlignment.Right);                      //5
            ListDeta.Columns.Add("Valor Hasta", 90, HorizontalAlignment.Right);                      //6 
            ListDeta.Columns.Add("Monto máximo", 90, HorizontalAlignment.Right);
            ListDeta.Columns.Add("Fecha Desde", 80, HorizontalAlignment.Right);
            ListDeta.Columns.Add("Fecha Hasta", 80, HorizontalAlignment.Right);
            ListDeta.Columns.Add("Usuario", 70, HorizontalAlignment.Right);
            ListDeta.Columns.Add("Pc", 80, HorizontalAlignment.Right);
            ListDeta.OwnerDraw = true;
            ListDeta.BackColor = Color.White;
            ListDeta.ForeColor = Color.Black;
            ListDeta.FullRowSelect = true;

            ListVenci.View = View.Details;
            ListVenci.Columns.Add("ID", 40, HorizontalAlignment.Right);
            ListVenci.Columns.Add("Días 1° cuota", 60, HorizontalAlignment.Right);    // 30 60
            ListVenci.Columns.Add("T Venci", 60, HorizontalAlignment.Left);                 // * A1
            ListVenci.Columns.Add("Vencimiento", 75, HorizontalAlignment.Right);            //10
            ListVenci.Columns.Add("Corte", 60, HorizontalAlignment.Right);                  //20
            ListVenci.Columns.Add("1 Venci", 60, HorizontalAlignment.Right);
            ListVenci.Columns.Add("1 Corte", 60, HorizontalAlignment.Right);
            ListVenci.Columns.Add("2 Venci", 60, HorizontalAlignment.Right);
            ListVenci.Columns.Add("2 Corte", 60, HorizontalAlignment.Right);
            ListVenci.Columns.Add("Fecha Desde", 80, HorizontalAlignment.Right);
            ListVenci.Columns.Add("Fecha Hasta", 80, HorizontalAlignment.Right);
            ListVenci.Columns.Add("Usuario", 60, HorizontalAlignment.Right);
            ListVenci.Columns.Add("Pc", 80, HorizontalAlignment.Right);
            ListVenci.OwnerDraw = true;
            ListVenci.BackColor = Color.White;
            ListVenci.ForeColor = Color.Black;
            ListVenci.FullRowSelect = true;

            ListBoni.View = View.Details;
            ListBoni.Columns.Add("ID", 60, HorizontalAlignment.Right);
            ListBoni.Columns.Add("Aplica", 90, HorizontalAlignment.Left);
            ListBoni.Columns.Add("% o Cantidad", 60, HorizontalAlignment.Right);
            ListBoni.Columns.Add("Cuotas Desde", 60, HorizontalAlignment.Right);
            ListBoni.Columns.Add("Cuotas Hasta", 60, HorizontalAlignment.Right);
            ListBoni.Columns.Add("", 0, HorizontalAlignment.Right);
            ListBoni.Columns.Add("Mora", 60, HorizontalAlignment.Right);
            ListBoni.Columns.Add("Fecha Alta", 100, HorizontalAlignment.Right);
            ListBoni.Columns.Add("Fecha Venci", 100, HorizontalAlignment.Right);
            ListBoni.Columns.Add("Usuario", 70, HorizontalAlignment.Right);
            ListBoni.Columns.Add("PC", 80, HorizontalAlignment.Right);
            ListBoni.OwnerDraw = true;
            ListBoni.BackColor = Color.White;
            ListBoni.ForeColor = Color.Black;
            ListBoni.FullRowSelect = true;

            ///
            listPruebas.View = View.Details;
            listPruebas.Columns.Add("", 0, HorizontalAlignment.Left);               //0
            listPruebas.Columns.Add("Tipo", 35, HorizontalAlignment.Left);               //1
            listPruebas.Columns.Add("Cuota", 40, HorizontalAlignment.Right);                      //2
            listPruebas.Columns.Add("Tasa", 60, HorizontalAlignment.Right);              //3
            listPruebas.Columns.Add("Monto", 80, HorizontalAlignment.Right);                      //4
            listPruebas.Columns.Add("Inter", 80, HorizontalAlignment.Right);             //5
            listPruebas.Columns.Add("Total", 80, HorizontalAlignment.Right);                      //6
            listPruebas.Columns.Add("Valor Cuota", 90, HorizontalAlignment.Right);       //7
            listPruebas.Columns.Add("Primer Vencimiento", 90, HorizontalAlignment.Left); //8
            //ListPlanes.Columns.Add("Notas", 90, HorizontalAlignment.Left);
            listPruebas.Columns.Add("Gasto", 70, HorizontalAlignment.Right);              //8
            listPruebas.Columns.Add("Comis", 70, HorizontalAlignment.Right);                      //10
            //listPruebas.Columns.Add("IdPlan", 100, HorizontalAlignment.Left);              //
            //listPruebas.Columns.Add("Bonif", 60, HorizontalAlignment.Left);
            //listPruebas.Columns.Add("T Boni", 60, HorizontalAlignment.Left);             //
            listPruebas.Columns.Add("intereses redondeado", 80, HorizontalAlignment.Right);            //edu202009                 //11    
            listPruebas.Columns.Add("Total redondeado", 80, HorizontalAlignment.Right);               //edu202009        //12
        }            
        private void Graba_PlanesDeta()
        {
            bool cr = true;
            bool ca = true;
            bool mo = true;
            bool va = true;
            PlanesDetalle plandeta;
            if (!ChkDetaCred.Checked)
            {
                cr = false;
                TxtDetaCreD.Text = "0";
                TxtDetaCreH.Text = "0";
            } 
            if(!ChkDetaCanc.Checked)
            {
                ca = false;
                TxtDetaCanD.Text = "0";
                TxtDetaCanH.Text = "0";
            }
            if(!ChkDetaMora.Checked)
            {
                mo = false;
                TxtDetaMoraD.Text = "0";
                TxtDetaMoraH.Text = "0";
            }
            if (!ChkDetaValor.Checked)
            {
                va = false;
                TxtDetaValD.Text = "0";
                TxtDetaValH.Text = "0";
            }

            if ( LblDetaNvoModi.Text=="N")
            {
                plandeta = new PlanesDetalle();
                int nNro = 0;
                nNro = bl.ObtenerProximoNumeroDePlanesDeta(BaseID) ;
                plandeta.PlanesDetalleID = nNro;
            } else
            {
                plandeta = bl.GetPlanesDetalleByID(Convert.ToInt16( LblDetalleID.Text), BaseID);
            }
            plandeta.PlanesTipoID = LblPlan.Text;
            plandeta.EmpresaID = BaseID;  // bl.pGlob.Comercio.EmpresaID;
            plandeta.TipoCuota = "T";                                                          //PARA SACAR
            
            plandeta.Cuotas_D = Convert.ToInt16(TxtDetaCuoD.Text);
            plandeta.Cuotas_H= Convert.ToInt16(TxtDetaCuoH.Text);

            plandeta.SiCreditos = cr; // ChkDetaCred.Checked;
            plandeta.nCreditos_D = Convert.ToInt16( TxtDetaCreD.Text);
            plandeta.nCreditos_H = Convert.ToInt16(TxtDetaCreH.Text);

            plandeta.SiCancel = ca; //ChkDetaCanc.Checked;
            plandeta.nCancel_D = Convert.ToInt16(TxtDetaCanD.Text);
            plandeta.nCancel_H = Convert.ToInt16(TxtDetaCanH.Text);

            plandeta.SiMora = mo; //ChkDetaMora.Checked;
            plandeta.nMora_D = Convert.ToInt16(TxtDetaMoraD.Text);
            plandeta.nMora_H = Convert.ToInt16(TxtDetaMoraH.Text);

            plandeta.SiValor = va; //ChkDetaValor.Checked;
           
            decimal nVal = Convert.ToDecimal(TxtDetaValD.Text);
            int nVal2 = Convert.ToInt32(nVal);
            if(va) plandeta.nValor_D = nVal2; else plandeta.nValor_D = 0;
            
            nVal = Convert.ToDecimal(TxtDetaValH.Text);
            nVal2 = Convert.ToInt32(nVal);
            if(va) plandeta.nValor_H = nVal2; else plandeta.nValor_H = 0;

            plandeta.Monto_max = Convert.ToDecimal(TxtDetaMax.Text);

            plandeta.FechaAlta = TxtDetaFechD.Value; // Convert.ToDateTime(TxtFechVenciDesde.Value);
            plandeta.FechaVenci = TxtDetaFechH.Value; // Convert.ToDateTime(TxtFechVenciHasta.Text);
            plandeta.UsuarioID = p.usu.UsuarioID;
            plandeta.UsuarioPC = System.Environment.MachineName;
            plandeta.ComercioID = ComID; // bl.pGlob.Comercio.ComercioID;
            plandeta.EmpresaID = BaseID; // bl.pGlob.Comercio.EmpresaID;

            if (LblDetaNvoModi.Text == "N") bl.AgregarPlanesDetalle(plandeta, BaseID); else  bl.ActualizarPlanesDetalle(plandeta, BaseID);

            MessageBox.Show("Los datos han sido grabados", "Filtro de planes");
            Pone_btn_enable(true);
            grpDetalle.Visible = false;
            lblSombra.Visible = false;
            Carga_Deta_Venci_Boni(LblPlan.Text, true, false, false);
     
        }
        private void Graba_Planes()
        {
            PlanesTipo planes;
            planes = bl.GetPlanesTipoByID(TxtPlanID.Text, BaseID);
            if (LblPLanNvoModi.Text == "N")
            {
                if (planes==null)
                {
                    planes = new PlanesTipo();
                    planes.PlanesTipoID = TxtPlanID.Text;
                } else
                {
                    MessageBox.Show("Ya existe un plan con ese código", "Plan nuevo");
                    return;
                }
            }
            if(chkPlanGst.Checked == false)
            {
                TxtPlanGstFijo.Text = "0";
            }
            else
            {
                if(Convert.ToDecimal(TxtPlanGstFijo.Text) == 0)
                {
                    MessageBox.Show("Marcó gasto fijo sin poner un valor", "Plan nuevo");
                    return;
                }
            }
            switch(cmbRetencion.SelectedValue.ToString())
            {
                case "G":
                    if(Convert.ToDecimal( TxtPlanGst.Text) == 0 && Convert.ToDecimal(TxtPlanGstFijo.Text)==0)
                    {
                        MessageBox.Show("No hay gastos para retener", "Plan nuevo");
                        return;
                    }
                    break;
                case "C":
                    if(CmbPlanTipo.Text.Substring(0, 1) == "V")
                    {
                        MessageBox.Show("No hay cuota adelantada para retener", "Plan nuevo");
                        return;
                    }
                    break;
                case "A":
                    if((Convert.ToDecimal(TxtPlanGst.Text) == 0 && Convert.ToDecimal(TxtPlanGstFijo.Text) == 0))
                    {
                        MessageBox.Show("No hay cuota gasto para retener", "Plan nuevo");
                        return;
                    }
                    if(CmbPlanTipo.Text.Substring(0, 1) == "V")
                    {
                        MessageBox.Show("No hay cuota adelantada para retener", "Plan nuevo");
                        return;
                    }
                    break;

            }
            planes.ComercioID = ComID; // bl.pGlob.Comercio.ComercioID;
            planes.PlanesTipoID = TxtPlanID.Text;
            planes.EmpresaID = BaseID; // bl.pGlob.Comercio.EmpresaID;
            planes.TipoAV = CmbPlanTipo.Text.Substring(0, 1);
            planes.PuntoD = Convert.ToDecimal(TxtPlanPuntoD.Text);
            planes.PuntoH = Convert.ToDecimal(TxtPlanPuntoH.Text);
            planes.Inter = Convert.ToDecimal(TxtPlanInter.Text);
            planes.Inter_Incr = Convert.ToDecimal(TxtPlanInterIncr.Text);
            if(chkPlanGst.Checked) planes.GastoFijo = Convert.ToDecimal(TxtPlanGstFijo.Text); else planes.GastoFijo = 0;


            planes.Gasto = Convert.ToDecimal(TxtPlanGst.Text);
            planes.Gasto_Incr = Convert.ToDecimal(TxtPlanGstIncr.Text);
            planes.Comis = Convert.ToDecimal(TxtPlanComis.Text);
            planes.Comis_Incr = Convert.ToDecimal(TxtPlanComisIncr.Text);
            planes.NroORden = Convert.ToInt16(TxtPlanNroO.Text);
            planes.Corte = Convert.ToInt16(txtPlanCorte.Text);
            planes.Notas = TxtPlanNotas.Text;
            planes.TipoRetencionPlanID = cmbRetencion.SelectedValue.ToString();
            if (LblPLanNvoModi.Text == "N") bl.AgregarPlanesTipo(planes, BaseID); else bl.ActualizarPlanesTipo(planes, BaseID);

            MessageBox.Show("Los datos han sido grabados", "Planes");
            Pone_btn_enable(true);
            grpPlan.Visible = false;
            lblSombra.Visible = false;
            LblPlan.Text = "";
            Carga_Planes();
        }
        private void Graba_PlanesBoni()
        {
            PlanesBonif planboni;
            if (LblBoniNvoModi.Text=="N")
            {
                planboni = new PlanesBonif();
                planboni.PlanesBonifID = bl.ObtenerProximoNumeroDePlanesBonif(BaseID).ToString();
            }
            else
            {
                planboni = bl.GetPlanesBonifByID(LblBoniID.Text, BaseID);
            }

            planboni.PlanesTipoID = LblPlan.Text;
            planboni.TipoBoni = CmbBoniTipo.Text.Substring(0,1);
            planboni.Cuotas_D = Convert.ToInt16(TxtBoniCuo_D.Text);
            planboni.Cuotas_H = Convert.ToInt16(TxtBoniCuo_H.Text);
            planboni.nMora=  Convert.ToInt16(TxtBoniMora.Text);
            planboni.PorBoni = Convert.ToDecimal(TxtBoniPorc.Text );
            planboni.UsuarioID = p.usu.UsuarioID;
            planboni.FechaAlta = TxtBoniFechD.Value;
            planboni.FechaVenci = TxtBoniFechH.Value;
            planboni.TipoCuota = "T";                                                          //PARA SACAR
            planboni.ComercioID = ComID; // bl.pGlob.Comercio.ComercioID;
            planboni.EmpresaID = BaseID; // bl.pGlob.Comercio.EmpresaID;
            if (LblBoniNvoModi.Text == "N") bl.AgregarPlanesBonif(planboni, BaseID); else  bl.ActualizarPlanesBonif(planboni, BaseID);

            MessageBox.Show("Los datos han sido grabados", "Bonificación de planes");
            Pone_btn_enable(true);
            grpBonifica.Visible = false;
            lblSombra.Visible = false;
            Carga_Deta_Venci_Boni(LblPlan.Text, false, false, true);
        }
        private void Graba_PlanesVenci()
        {
            PlanesVenci planvenci;

            if (LblVenciNvoModi.Text == "N")
            {
                planvenci = new PlanesVenci();
                int nNro = 0;
                nNro = bl.ObtenerProximoNumeroDePlanesVenci(BaseID) ;
                planvenci.PlanesVenciID = nNro.ToString();
            }
            else
            {
                planvenci = bl.GetPlanesVenciByID(LblVenciId.Text, BaseID);
            }
            planvenci.PlanesTipoID = LblPlan.Text;
            planvenci.CambiaFecha = false;
            planvenci.DiasPrimerCuota = System.Convert.ToInt16(CmbVenciMes.Text);
            planvenci.TipoVencimiento = CmbVenci.Text;
            planvenci.VenciDia = System.Convert.ToInt16(TxtVenciDia.Text);
            planvenci.VenciCorte = System.Convert.ToInt16(TxtVenciCorte.Text);
            planvenci.Corte1 = 0;
            planvenci.VenDia1 = 0;
            planvenci.Corte2 = System.Convert.ToInt16(TxtVenciCorte2.Text);
            planvenci.Vendia2 = System.Convert.ToInt16(TxtVenciDia2.Text);
            planvenci.Vendia3 = 0;
            planvenci.FechaAlta = TxtFechVenciDesde.Value; // Convert.ToDateTime(TxtFechVenciDesde.Value);
            planvenci.FechaVenci = TxtFechVenciHasta.Value; // Convert.ToDateTime(TxtFechVenciHasta.Text);
            planvenci.UsuarioID = p.usu.UsuarioID;
            planvenci.UsuarioPC = System.Environment.MachineName;
            if (LblVenciNvoModi.Text == "N")  bl.AgregarPlanesVenci(planvenci, BaseID); else bl.ActualizarPlanesVenci(planvenci, BaseID);

            MessageBox.Show("Los datos han sido grabados", "Vencimiento de planes");
            Pone_btn_enable(true);
            grpVencimiento.Visible = false;
            lblSombra.Visible = false;
            Carga_Deta_Venci_Boni(LblPlan.Text, false,true, false);
        }
 
     

        private void Carga_Deta_Venci_Boni(string IDPlan, bool bDeta, bool bVenci, bool bBoni)
        {
            fontColor = Color.Empty;
            backColorList = Color.LightSteelBlue;
            fontList = new Font("Verdana", 8F, FontStyle.Regular);
            if (bDeta)
            {
                BtnDetaModi.Enabled = false;
                ListDeta.Items.Clear();
                List<PlanesDetalle> lPd;
                lPd = bl.Get<PlanesDetalle>(BaseID, c => c.PlanesTipoID == IDPlan).ToList();
                foreach (PlanesDetalle pd in lPd)
                {
                    ListViewItem item = new ListViewItem(pd.PlanesDetalleID.ToString());
                    item.SubItems.Add(pd.TipoCuota, fontColor, backColorList, fontList);       //PARA SACAR
                    item.SubItems.Add(pd.Cuotas_D.ToString(), fontColor, backColorList, fontList);
                    item.SubItems.Add(pd.Cuotas_H.ToString(), fontColor, backColorList, fontList);
                    
                    if (pd.SiValor) item.SubItems.Add("SI", fontColor, backColorList, fontList); else item.SubItems.Add("NO", fontColor, backColorList, fontList);                                                //13
                    item.SubItems.Add(pd.nValor_D.ToString("N2"), fontColor, backColorList, fontList);                      //14
                    item.SubItems.Add(pd.nValor_H.ToString("N2"), fontColor, backColorList, fontList);
                    item.SubItems.Add(pd.Monto_max.ToString("N2"), fontColor, backColorList, fontList);                        //16
                    item.SubItems.Add(pd.FechaAlta.ToShortDateString(), fontColor, backColorList, fontList);
                    item.SubItems.Add(pd.FechaVenci.ToShortDateString(), fontColor, backColorList, fontList);
                    if (pd.FechaVenci < DateTime.Now) item.BackColor = Color.Red;

                    if (pd.Usuario != null) item.SubItems.Add(pd.Usuario.nombre, fontColor, backColorList, fontList); else item.SubItems.Add("", fontColor, backColorList, fontList);
                    item.SubItems.Add(pd.UsuarioPC, fontColor, backColorList, fontList);
                    ListDeta.Items.Add(item);
                    if (backColorList == Color.White) backColorList = Color.LightSteelBlue; else backColorList = Color.White;
                }
            }
            if(bVenci)
            {
                backColorList = Color.LightSteelBlue;
                BtnVenciModi.Enabled = false;
                ListVenci.Items.Clear();
                List<PlanesVenci> lPt;
                lPt = bl.Get<PlanesVenci>(BaseID, c => c.PlanesTipoID==IDPlan).ToList();
                foreach( PlanesVenci pv in lPt)
                {
                    ListViewItem item = new ListViewItem(pv.PlanesVenciID);
                    item.SubItems.Add(pv.DiasPrimerCuota.ToString(), fontColor, backColorList, fontList);    // 30 60
                    item.SubItems.Add(pv.TipoVencimiento, fontColor, backColorList, fontList);                      // * A1
                    item.SubItems.Add(pv.VenciDia.ToString(), fontColor, backColorList, fontList);                  //10
                    item.SubItems.Add(pv.VenciCorte.ToString(), fontColor, backColorList, fontList);       //20
                    item.SubItems.Add(pv.VenDia1.ToString(), fontColor, backColorList, fontList);
                    item.SubItems.Add(pv.Corte1.ToString(), fontColor, backColorList, fontList);
                    item.SubItems.Add(pv.Vendia2.ToString(), fontColor, backColorList, fontList);
                    item.SubItems.Add(pv.Corte2.ToString(), fontColor, backColorList, fontList);
                    item.SubItems.Add(pv.FechaAlta.ToShortDateString(), fontColor, backColorList, fontList);
                    item.SubItems.Add(pv.FechaVenci.ToShortDateString(), fontColor, backColorList, fontList);
                    if(pv.Usuario.nombre != null)   item.SubItems.Add(pv.Usuario.nombre, fontColor, backColorList, fontList); ;
                    item.SubItems.Add(pv.UsuarioPC, fontColor, backColorList, fontList);
                    if (pv.FechaVenci < DateTime.Now)
                    {
                        item.BackColor = Color.Red;
                    }
                    ListVenci.Items.Add(item);
                    if (backColorList == Color.White) backColorList = Color.LightSteelBlue; else backColorList = Color.White;
                }
            }
            if (bBoni)
            {
                backColorList = Color.LightSteelBlue;
                BtnBoniModi.Enabled = false;
                ListBoni.Items.Clear();
                List<PlanesBonif> lPb;
                lPb = bl.Get<PlanesBonif>(BaseID, c => c.PlanesTipoID == IDPlan).ToList();
                foreach (PlanesBonif pv in lPb)
                {
                    ListViewItem item = new ListViewItem(pv.PlanesBonifID);
                    if (pv.TipoBoni == "C")                                                     //1
                    {
                        item.SubItems.Add("% Cuota", fontColor, backColorList, fontList);
                        item.SubItems.Add(pv.PorBoni.ToString("N2"), fontColor, backColorList, fontList);
                    }
                    else if (pv.TipoBoni == "V")
                    {
                        item.SubItems.Add("% V. Nominal", fontColor, backColorList, fontList);
                        item.SubItems.Add(pv.PorBoni.ToString("N2"), fontColor, backColorList, fontList);
                    }
                    else if (pv.TipoBoni == "X")
                    {
                        item.SubItems.Add("X :Cantidad de cuotas", fontColor, backColorList, fontList);
                        item.SubItems.Add(pv.PorBoni.ToString("N0"), fontColor, backColorList, fontList);
                    }                

                    //item.SubItems.Add( pv.PorBoni.ToString("N2"), fontColor, backColorList, fontList);
                    item.SubItems.Add(pv.Cuotas_D.ToString(), fontColor, backColorList, fontList);
                    item.SubItems.Add(pv.Cuotas_H.ToString(), fontColor, backColorList, fontList);      //4
                    item.SubItems.Add(pv.TipoCuota, fontColor, backColorList, fontList);                                                          //PARA SACAR
                    item.SubItems.Add(pv.nMora.ToString(), fontColor, backColorList, fontList);
                    item.SubItems.Add(pv.FechaAlta.ToShortDateString(), fontColor, backColorList, fontList);    //7
                    item.SubItems.Add(pv.FechaVenci.ToShortDateString(), fontColor, backColorList, fontList);
                    if (pv.Usuario != null) item.SubItems.Add(pv.Usuario.apellido, fontColor, backColorList, fontList); else item.SubItems.Add("", fontColor, backColorList, fontList);
                    item.SubItems.Add(pv.UsuarioPC, fontColor, backColorList, fontList);
                    if (pv.FechaVenci < DateTime.Now)
                    {
                        item.BackColor = Color.Red;
                    }


                    ListBoni.Items.Add(item);
                }
            }
        }
    
        private void Pone_btn_enable(bool bEnable)
        {
            BtnDetaNvo.Enabled = bEnable;
            BtnVenciNvo.Enabled = bEnable;
            BtnBoniNvo.Enabled = bEnable;
            BtnPLanNvo.Enabled = bEnable;
            BtnPlanModi.Enabled = bEnable;

            
            if(!bEnable)
            {
                BtnDetaModi.Enabled = bEnable;
                BtnVenciModi.Enabled = bEnable;
                BtnBoniModi.Enabled = bEnable;
            }

            ListPlanes.Enabled = bEnable;
            ListDeta.Enabled = bEnable;
            ListVenci.Enabled = bEnable;
            ListBoni.Enabled = bEnable;
        }
        private void Limpia_grp(string qlimpio)
        {
            if(qlimpio=="PLAN")
            {
                TxtPlanID.Text = "";
                TxtPlanPuntoD.Text = "0";
                TxtPlanPuntoH.Text = "0";
                TxtPlanInter.Text = "0";
                TxtPlanInterIncr.Text = "0";
                TxtPlanGst.Text = "0";
                TxtPlanGstIncr.Text = "0";
                txtPlanCorte.Text = "0";
                TxtPlanGstFijo.Text = "0";
                chkPlanGst.Checked = false;
                TxtPlanGstFijo.Enabled = chkPlanGst.Checked;
                TxtPlanGst.Enabled = !chkPlanGst.Checked;
                TxtPlanGstIncr.Enabled = !chkPlanGst.Checked;
                TxtPlanComis.Text = "0";
                TxtPlanComisIncr.Text = "0";
                //txtPlanCorte.Text = "";
                TxtPlanNotas.Text = "";
                TxtPlanNroO.Text = "0";
                CmbPlanTipo.SelectedIndex = 0;

            }
            if (qlimpio == "VENCI")
            {
                TxtFechVenciDesde.Text = DateTime.Now.ToString();
                TxtFechVenciHasta.Text = DateTime.Now.ToString();
                TxtVenciCorte.Text = "0";
                TxtVenciDia2.Text = "0";
                TxtVenciDia.Text = "0";
                CmbVenci.SelectedIndex = -1;
                LblVenci.Text = "";
                TxtVenciDia2.Text = "0";
                TxtVenciCorte2.Text = "0";
                LblVenciNvoModi.Text = "";
            }
            if (qlimpio == "DETA") 
            {
                TxtDetaCuoD.Text = "0";
                TxtDetaCuoH.Text = "0";
                TxtDetaCreD.Text = "0";
                TxtDetaCreH.Text = "0";
                TxtDetaCanD.Text = "0";
                TxtDetaCanH.Text = "0";
                TxtDetaMoraD.Text = "0";
                TxtDetaMoraH.Text = "0";
                TxtDetaValD.Text = "0";
                TxtDetaValH.Text = "0";

                TxtDetaCreD.Enabled=false;
                TxtDetaCreH.Enabled = false;
                TxtDetaCanD.Enabled = false;
                TxtDetaCanH.Enabled = false;
                TxtDetaMoraD.Enabled = false;
                TxtDetaMoraH.Enabled = false;
                TxtDetaValD.Enabled = false;
                TxtDetaValH.Enabled = false;
                
                TxtDetaMax.Text = "0";
                ChkDetaCred.Checked = false;
                ChkDetaCanc.Checked = false;
                ChkDetaMora.Checked = false;
                ChkDetaValor.Checked = false;
                TxtDetaFechD.Text = DateTime.Now.ToString();
                TxtDetaFechH.Text = DateTime.Now.ToString();
                LblDetalleID.Text = "";
                LblDetaNvoModi.Text = "";
            }
            if (qlimpio == "BONI")
            {
                CmbBoniTipo.SelectedItem = 0;
                TxtBoniPorc.Text = "0";
                TxtBoniCuo_D.Text = "0";
                TxtBoniCuo_H.Text = "0";
                TxtBoniMora.Text = "0";
                TxtBoniFechD.Text = DateTime.Now.ToString();
                TxtBoniFechH.Text = DateTime.Now.ToString();
            }
        }
        private void Llena_combos()
        {
            CmbVenci.Items.Add("*");
            CmbVenci.Items.Add(" ");
            CmbVenci.Items.Add("A2");

            //CmbBoniTipo.Items.Add("Cuota");
            //CmbBoniTipo.Items.Add("V. Nominal");

            CmbBoniTipo.Items.Add("C :% Cuota");
            CmbBoniTipo.Items.Add("V :% V. Nominal");
            CmbBoniTipo.Items.Add("X :Cantidad de cuotas");

            CmbVenciMes.Items.Add("30");
            CmbVenciMes.Items.Add("60");
            CmbVenciMes.Items.Add("90");
            CmbVenciMes.Items.Add("120");

            CmbPlanTipo.Items.Add("Adelantada");
            CmbPlanTipo.Items.Add("Vencida");
        }
     
        private void BtnVenciCancel_Click(object sender, EventArgs e)
        {
            grpVencimiento.Visible = false;
            lblSombra.Visible = false;
            Pone_btn_enable(true);
            ListPlanes.Focus();
        }

        private void BtnModivenci_Click(object sender, EventArgs e)
        {
            Limpia_grp("VENCI");
            LblVenciNvoModi.Text = "M";
            Pone_btn_enable(false);
            lblgrpVencimiento.Text = "Modifica vencimiento : "  + ListVenci.SelectedItems[0].SubItems[0].Text;
            LblVenciId.Text = ListVenci.SelectedItems[0].SubItems[0].Text;
            int index = CmbVenciMes.FindString(ListVenci.SelectedItems[0].SubItems[1].Text);
            CmbVenciMes.SelectedIndex = index;

            index = CmbVenci.FindString(ListVenci.SelectedItems[0].SubItems[2].Text);
            CmbVenci.SelectedIndex = index;

            TxtVenciDia.Text = ListVenci.SelectedItems[0].SubItems[3].Text;
            TxtVenciCorte.Text = ListVenci.SelectedItems[0].SubItems[4].Text;

            TxtFechVenciDesde.Value = Convert.ToDateTime(ListVenci.SelectedItems[0].SubItems[9].Text );
            TxtFechVenciHasta.Value = Convert.ToDateTime(ListVenci.SelectedItems[0].SubItems[10].Text );
            //grpVencimiento.Left = 1000;
            lblSombra.Width = grpVencimiento.Width;
            lblSombra.Height = grpVencimiento.Height - 10;
            lblSombra.Top = grpVencimiento.Top + 15;
            lblSombra.Left = grpVencimiento.Left + 5;
            lblSombra.Visible = true;
            lblSombra.BringToFront();
            grpVencimiento.BringToFront();
            grpVencimiento.Visible = true;
            CmbVenciMes.Focus();
        }

        private void ListVenci_SelectedIndexChanged(object sender, EventArgs e)
        {
            BtnVenciModi.Enabled = true;
        }

        private void ListBoni_SelectedIndexChanged(object sender, EventArgs e)
        {
            BtnBoniModi.Enabled = true;
        }

        private void ListDeta_SelectedIndexChanged(object sender, EventArgs e)
        {
            BtnDetaModi.Enabled = true;
        }

        private void BtnFiltroModi_Click(object sender, EventArgs e)
        {
            Limpia_grp("DETA");
            LblDetaNvoModi.Text = "M";
            Pone_btn_enable(false);
            lblgrpDetalle.Text = "Modifica filtro : " + ListDeta.SelectedItems[0].SubItems[0].Text;
            LblDetalleID.Text = ListDeta.SelectedItems[0].SubItems[0].Text;
            TxtDetaCuoD.Text = ListDeta.SelectedItems[0].SubItems[2].Text;
            TxtDetaCuoH.Text = ListDeta.SelectedItems[0].SubItems[3].Text;
            //if (ListDeta.SelectedItems[0].SubItems[4].Text=="SI")
            //{
            //    ChkDetaCred.Checked = true;
            //    TxtDetaCreD.Text  = ListDeta.SelectedItems[0].SubItems[5].Text;
            //    TxtDetaCreH.Text  = ListDeta.SelectedItems[0].SubItems[6].Text;
            //}
            //if (ListDeta.SelectedItems[0].SubItems[7].Text == "SI")
            //{
            //    ChkDetaCanc.Checked = true;
            //    TxtDetaCanD.Text = ListDeta.SelectedItems[0].SubItems[8].Text;
            //    TxtDetaCanH.Text =  ListDeta.SelectedItems[0].SubItems[9].Text;
            //}
            //if (ListDeta.SelectedItems[0].SubItems[10].Text == "SI")
            //{
            //    ChkDetaMora.Checked = true;
            //    TxtDetaMoraD.Text = ListDeta.SelectedItems[0].SubItems[11].Text;
            //    TxtDetaMoraH.Text =  ListDeta.SelectedItems[0].SubItems[12].Text;
            //}
            if (ListDeta.SelectedItems[0].SubItems[4].Text == "SI")
            {
                ChkDetaValor.Checked = true;
                TxtDetaValD.Text = ListDeta.SelectedItems[0].SubItems[5].Text;
                TxtDetaValH.Text = ListDeta.SelectedItems[0].SubItems[6].Text;
            }
            TxtDetaMax.Text = ListDeta.SelectedItems[0].SubItems[7].Text;

            TxtDetaFechD.Value = Convert.ToDateTime(ListDeta.SelectedItems[0].SubItems[8].Text );
            TxtDetaFechH.Value = Convert.ToDateTime(ListDeta.SelectedItems[0].SubItems[9].Text );
            //grpDetalle.Left = 1000;
            lblSombra.Width = grpDetalle.Width;
            lblSombra.Height = grpDetalle.Height - 10;
            lblSombra.Top = grpDetalle.Top + 15;
            lblSombra.Left = grpDetalle.Left + 5;
            lblSombra.Visible = true;
            lblSombra.BringToFront();
            grpDetalle.BringToFront();
            grpDetalle.Visible = true;
            TxtDetaCuoD.Focus();
        }

        private void BtnFiltroNvo_Click(object sender, EventArgs e)
        {
            Limpia_grp("DETA");
            LblDetaNvoModi.Text = "N";
            Pone_btn_enable(false);
            lblgrpDetalle.Text = "Nuevo filtro : " + LblPlan.Text;
            //grpDetalle.Left = 1000;
            lblSombra.Width = grpDetalle.Width;
            lblSombra.Height = grpDetalle.Height - 10;
            lblSombra.Top = grpDetalle.Top + 15;
            lblSombra.Left = grpDetalle.Left + 5;
            lblSombra.Visible = true;
            grpDetalle.BringToFront();
            grpDetalle.Visible = true;
            TxtDetaCuoD.Focus();
        }

        private void BtnVenciNvo_Click(object sender, EventArgs e)
        {
            Limpia_grp("VENCI");
            LblVenciNvoModi.Text = "N";
            Pone_btn_enable(false);
            lblgrpVencimiento.Text = "Nuevo vencimiento : " + LblPlan.Text ;
            //grpVencimiento.Left = 1000;
            lblSombra.Width = grpVencimiento.Width;
            lblSombra.Height = grpVencimiento.Height - 10;
            lblSombra.Top = grpVencimiento.Top + 15;
            lblSombra.Left = grpVencimiento.Left + 5;
            lblSombra.Visible = true;
            grpVencimiento.BringToFront();
            grpVencimiento.Visible = true;
            CmbVenciMes.Focus();
        }

        private void BtnVenciGrabar_Click(object sender, EventArgs e)
        {
            Graba_PlanesVenci();
            ListPlanes.Focus();
        }

        private void BtnDetaCancel_Click(object sender, EventArgs e)
        {
            grpDetalle.Visible = false;
            lblSombra.Visible = false;
            Pone_btn_enable(true);
            ListPlanes.Focus();
        }

        private void ChkDetaCred_CheckedChanged(object sender, EventArgs e)
        {
            TxtDetaCreD.Enabled = ChkDetaCred.Checked;
            TxtDetaCreH.Enabled = ChkDetaCred.Checked;
        }

        private void ChkDetaCanc_CheckedChanged(object sender, EventArgs e)
        {
            TxtDetaCanD.Enabled = ChkDetaCanc.Checked;
            TxtDetaCanH.Enabled = ChkDetaCanc.Checked;
        }

        private void ChkDetaMora_CheckedChanged(object sender, EventArgs e)
        {
            TxtDetaMoraD.Enabled = ChkDetaMora.Checked;
            TxtDetaMoraH.Enabled = ChkDetaMora.Checked;
        }

        private void ChkDetaValor_CheckedChanged(object sender, EventArgs e)
        {
            TxtDetaValD.Enabled = ChkDetaValor.Checked;
            TxtDetaValH.Enabled = ChkDetaValor.Checked;
        }

        private void BtnDetaGrabar_Click(object sender, EventArgs e)
        {
            Graba_PlanesDeta();
            ListPlanes.Focus();
        }

        private void BtnBoniNvo_Click(object sender, EventArgs e)
        {
            Limpia_grp("BONI");

            LblBoniNvoModi.Text = "N";
            Pone_btn_enable(false);
            //grpBonifica.Left = 1000;
            lblgrpBonifica.Text = "Nueva bonificación : " + LblPlan.Text;
            lblSombra.Width = grpBonifica.Width;
            lblSombra.Height = grpBonifica.Height - 10;
            lblSombra.Top = grpBonifica.Top + 15;
            lblSombra.Left = grpBonifica.Left + 5;
            lblSombra.Visible = true;
            lblSombra.BringToFront();
            grpBonifica.BringToFront();
            lblSombra.Visible = true;
            grpBonifica.Visible = true;
            grpBonifica.Focus();
        }

        private void BtnBoniModi_Click(object sender, EventArgs e)
        {
            Limpia_grp("BONI");
            LblBoniNvoModi.Text = "M";
            Pone_btn_enable(false);

            lblgrpBonifica.Text = "Modifica bonificación : " + ListBoni.SelectedItems[0].SubItems[0].Text;

            LblBoniID.Text = ListBoni.SelectedItems[0].SubItems[0].Text;
            //int index = 0;
            CmbBoniTipo.SelectedIndex = 1;
            if (ListBoni.SelectedItems[0].SubItems[1].Text == "C :% Cuota")
            {
                CmbBoniTipo.SelectedIndex = 0;
            }
            else if (ListBoni.SelectedItems[0].SubItems[1].Text == "V :% V. Nominal")
            {
                CmbBoniTipo.SelectedIndex = 1;
            }

            else if (ListBoni.SelectedItems[0].SubItems[1].Text == "X :Cantidad de cuotas")
            {
                CmbBoniTipo.SelectedIndex = 2;
            }
            TxtBoniPorc.Text = ListBoni.SelectedItems[0].SubItems[2].Text;
            TxtBoniCuo_D.Text = ListBoni.SelectedItems[0].SubItems[3].Text;
            TxtBoniCuo_H.Text = ListBoni.SelectedItems[0].SubItems[4].Text;
            TxtBoniMora.Text = ListBoni.SelectedItems[0].SubItems[6].Text;

            TxtBoniFechD.Value = Convert.ToDateTime(ListBoni.SelectedItems[0].SubItems[7].Text );
            TxtBoniFechH.Value = Convert.ToDateTime(ListBoni.SelectedItems[0].SubItems[8].Text );
            //grpBonifica.Left = 1000;
            lblSombra.Width = grpBonifica.Width;
            lblSombra.Height = grpBonifica.Height - 10;
            lblSombra.Top = grpBonifica.Top + 15;
            lblSombra.Left = grpBonifica.Left + 5;
            lblSombra.Visible = true;
            grpBonifica.BringToFront();
            grpBonifica.Visible = true;
            CmbBoniTipo.Focus();

        }

        private void BtnBoniCancel_Click(object sender, EventArgs e)
        {
            grpBonifica.Visible = false;
            lblSombra.Visible = false;
            Pone_btn_enable(true);
            ListPlanes.Focus();
        }

        private void BtnBoniGrabar_Click(object sender, EventArgs e)
        {
            Graba_PlanesBoni();
            ListPlanes.Focus();
        }

        private void BtnPlanCancel_Click(object sender, EventArgs e)
        {
            grpPlan.Visible = false;
            lblSombra.Visible = false;
            Pone_btn_enable(true);
            ListPlanes.Focus();
        }

        private void BtnPLanNvo_Click(object sender, EventArgs e)
        {
            Limpia_grp("PLAN");
            Pone_btn_enable(false);
            LblPLanNvoModi.Text = "N";
            lblgrpPlan.Text = "Nuevo Plan";

            
            lblSombra.Width = grpPlan.Width;
            lblSombra.Height = grpPlan.Height-10;
            lblSombra.Top = grpPlan.Top + 15;
            lblSombra.Left = grpPlan.Left + 5;
            lblSombra.Visible = true;
            lblSombra.BringToFront();
            grpPlan.BringToFront();
            lblSombra.Visible = true;
            grpPlan.Visible = true;
            TxtPlanID.Focus();
        }

        private void BtnPlanModi_Click(object sender, EventArgs e)
        {
            if (LblPlan.Text == "") return;
            Limpia_grp("PLAN");
            LblPLanNvoModi.Text = "M";
            Pone_btn_enable(false);
            TxtPlanID.Text = ListPlanes.SelectedItems[0].SubItems[0].Text;
            lblgrpPlan.Text = "Modifica Plan : " + ListPlanes.SelectedItems[0].SubItems[0].Text;
            if(ListPlanes.SelectedItems[0].SubItems[2].Text=="A")
            {
                CmbPlanTipo.SelectedIndex = 0;
            } else
            {
                CmbPlanTipo.SelectedIndex = 1;
            }
            TxtPlanPuntoD.Text = ListPlanes.SelectedItems[0].SubItems[3].Text;
            TxtPlanPuntoH.Text = ListPlanes.SelectedItems[0].SubItems[4].Text;
            TxtPlanInter.Text  = ListPlanes.SelectedItems[0].SubItems[5].Text;
            TxtPlanInterIncr.Text = ListPlanes.SelectedItems[0].SubItems[6].Text;
            TxtPlanNroO.Text = ListPlanes.SelectedItems[0].SubItems[14].Text;
            txtPlanCorte.Text = ListPlanes.SelectedItems[0].SubItems[13].Text;

            Busca_En_Combo(cmbRetencion, ListPlanes.SelectedItems[0].SubItems[15].Text);

            if (Convert.ToDecimal(ListPlanes.SelectedItems[0].SubItems[9].Text) > 0)
            {
                TxtPlanGstFijo.Text = ListPlanes.SelectedItems[0].SubItems[9].Text;
                TxtPlanGst.Text = "0";// ListPlanes.SelectedItems[0].SubItems[7].Text;
                TxtPlanGstIncr.Text = "0";//ListPlanes.SelectedItems[0].SubItems[8].Text;
                chkPlanGst.Checked = true;
            }
            else
            {
                TxtPlanGst.Text = ListPlanes.SelectedItems[0].SubItems[7].Text;
                TxtPlanGstIncr.Text = ListPlanes.SelectedItems[0].SubItems[8].Text;
                TxtPlanGstFijo.Text = "0";
                chkPlanGst.Checked = false;
            }
            TxtPlanComis.Text = ListPlanes.SelectedItems[0].SubItems[10].Text;
            TxtPlanComisIncr.Text = ListPlanes.SelectedItems[0].SubItems[11].Text;
            TxtPlanNotas.Text = ListPlanes.SelectedItems[0].SubItems[12].Text;
            lblSombra.Width = grpPlan.Width;
            lblSombra.Height = grpPlan.Height;
            lblSombra.Top = grpPlan.Top + 10;
            lblSombra.Left = grpPlan.Left + 10;
            lblSombra.Visible = true;
            lblSombra.BringToFront();
            grpPlan.BringToFront();
            grpPlan.Visible = true;
            TxtPlanID.Focus();
        }

        private void BtnPlanGrabar_Click(object sender, EventArgs e)
        {
            Graba_Planes();
            ListPlanes.Focus();
        }
        private void cmbVenci_SelectedIndexChanged(object sender, EventArgs e)
        {
            LblVenci.Text = "";
            label9.Visible = false;
            label10.Visible = false;
            TxtVenciDia2.Visible = false;
            TxtVenciCorte2.Visible = false;

            if (CmbVenci.Text == "*")
            {
                LblVenci.Text = "Vence del 1 al [día vencimiento] si la fecha de solicitud es hasta el día [Corte], o 10 de mes subsiguiente si el día de solicitud es mayor al [Corte]";
            }
            else if (CmbVenci.Text == " ")
            {
                LblVenci.Text = "A [Días 1° cuota] días se solicitud, o al 10 de mes subsiguiente si el día de solicitud es mayor al 28";
            }
            else if (CmbVenci.Text == "A1")
            {
                LblVenci.Text = "Vencimiento con 1 (un) corte mensual (igual que *)";
            }
            else if (CmbVenci.Text == "A2")
            {
                LblVenci.Text = "Vencimiento con 2 (dos) cortes mensuales";
                label9.Visible = true;
                label10.Visible = true;
                TxtVenciDia2.Visible = true;
                TxtVenciCorte2.Visible = true;
            }
            else if (CmbVenci.Text == "Z")
            {
                LblVenci.Text = "";
            }
        }
        private void ListPlanes_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            LblPlan.Text = "";
            BtnDetaNvo.Enabled = false;
            BtnVenciNvo.Enabled = false;
            BtnBoniNvo.Enabled = false;
            BtnPlanModi.Enabled = false;
            btnPlanPrueba.Enabled = false;
            foreach (ListViewItem aa in ListPlanes.SelectedItems)
            {
                lblFlechaI.Top = aa.Position.Y + ListPlanes.Top;
                lblFlechaD.Top = lblFlechaI.Top;
                LblPlan.Text = aa.Text;
                Carga_Deta_Venci_Boni(aa.Text, true, true, true);
                BtnDetaNvo.Enabled = true;
                BtnVenciNvo.Enabled = true;
                BtnBoniNvo.Enabled = true;
                BtnPlanModi.Enabled = true;
                btnPlanPrueba.Enabled = true;
            }
        }

        private void btnPrueba_Click(object sender, EventArgs e)
        {
            string cTip = ListPlanes.SelectedItems[0].SubItems[2].Text;
            decimal Interes = Convert.ToDecimal(ListPlanes.SelectedItems[0].SubItems[5].Text);
            decimal InteresIncr = Convert.ToDecimal(ListPlanes.SelectedItems[0].SubItems[6].Text);
            decimal Gst = Convert.ToDecimal(ListPlanes.SelectedItems[0].SubItems[7].Text);
            decimal GstIncr = Convert.ToDecimal(ListPlanes.SelectedItems[0].SubItems[8].Text);
            decimal GstFij = Convert.ToDecimal(ListPlanes.SelectedItems[0].SubItems[9].Text);
            decimal Comis = Convert.ToDecimal(ListPlanes.SelectedItems[0].SubItems[10].Text);
            decimal ComisIncr = Convert.ToDecimal(ListPlanes.SelectedItems[0].SubItems[11].Text);
            Prueb_Planes(cTip, Interes, InteresIncr, Gst, GstIncr,GstFij, Comis, ComisIncr, DateTime.Now);
        }

        private void btnPrueba2_Click(object sender, EventArgs e)
        {
            //grpPlan.Appearance.BorderColor = Color.Red;
            //grpPlan.Appearance.Options.UseBorderColor = true;

            if (!grpPruebas.Visible)
            {
                panel1.Visible = !panel1.Visible;
                grpPruebas.Visible = !grpPruebas.Visible;
                listPruebas.Items.Clear();
            }
            string cTip = CmbPlanTipo.Text.Substring(0, 1);
            decimal Interes = Convert.ToDecimal(TxtPlanInter.Text);
            decimal InteresIncr = Convert.ToDecimal(TxtPlanInterIncr.Text);
            decimal Gst = Convert.ToDecimal(TxtPlanGst.Text);
            decimal GstIncr = Convert.ToDecimal(TxtPlanGstIncr.Text);
            decimal GstFij = Convert.ToDecimal(TxtPlanGstFijo.Text);
            decimal Comis = Convert.ToDecimal(TxtPlanComis.Text);
            decimal ComisIncr = Convert.ToDecimal(TxtPlanComisIncr.Text);
            Prueb_Planes(cTip, Interes, InteresIncr, Gst, GstIncr,GstFij, Comis, ComisIncr, DateTime.Now);
        }

        private void btnPlanPrueba_Click(object sender, EventArgs e)
        {
            listPruebas.Items.Clear();
            panel1.Visible = !panel1.Visible;
            grpPruebas.Visible = !grpPruebas.Visible;
        }

        private void btnPruebaCerrar_Click(object sender, EventArgs e)
        {
            listPruebas.Items.Clear();
            panel1.Visible = !panel1.Visible;
            grpPruebas.Visible = !grpPruebas.Visible;
        }

        private void chkPlanGst_CheckedChanged(object sender, EventArgs e)
        {
            TxtPlanGstFijo.Enabled = chkPlanGst.Checked;
            TxtPlanGst.Enabled = !chkPlanGst.Checked;
            TxtPlanGstIncr.Enabled = !chkPlanGst.Checked;
            if(chkPlanGst.Checked == false) TxtPlanGstFijo.Text = "0";
        }

        private void CmbBoniTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            LblBoni.Text = "";
            label21.Text = "";

            if (CmbBoniTipo.Text == "C :% Cuota")
            {
                LblBoni.Text = "Bonifica un porcentaje de la última cuota";
                label21.Text = "%";
            }
            else if (CmbBoniTipo.Text == "V :% V. Nominal")
            {
                LblBoni.Text = "Bonifica un porcentaje del valor nominal en la última cuota";
                label21.Text = "%";
            }
            else if (CmbBoniTipo.Text == "X :Cantidad de cuotas")
            {
                LblBoni.Text = "Bonifica el total  de la/las cuota/s arriba ingresadas";
                label21.Text = "Cantidad";
            }
        }

        private void grpPlan_Enter(object sender, EventArgs e)
        {

        }

        private void txtPlanCorte_TextChanged(object sender, EventArgs e)
        {

        }

        private void grpPlan_Move(object sender, EventArgs e)
        {
            System.Windows.Forms.Control elControl = (System.Windows.Forms.Control)sender;
            lblSombra.Width = elControl.Width;
            lblSombra.Height = elControl.Height - 10;
            lblSombra.Top = elControl.Top + 15;
            lblSombra.Left = elControl.Left + 5;
        }

        private void FrmPlanes_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F9)
            {
                if (e.Shift)
                {
                    if (bl.LlevaM())
                    {
                        lblMor.Visible = !lblMor.Visible;
                        RecargarEmpYComercio(lblMor.Visible);
                        Carga_Planes();

                    }
                }
            }
        }
        private void Carga_Planes()
        {
            decimal nTmp = 0;
            ListDeta.Items.Clear();
            ListVenci.Items.Clear();
            ListBoni.Items.Clear();
            ListPlanes.Items.Clear();

            fontColor = Color.Empty;
            backColorList = Color.LightSteelBlue;
            //if(lblMor.Visible == false)
            //{
            //    lplanes = bl.GetPlanesTipos(null, o => o.OrderBy(c => c.NroORden)).ToList();
            //}
            //else
            //{
            //    lplanes = bl.Get<PlanesTipo>(BaseID, null, o => o.OrderBy(c => c.NroORden)).ToList();
            //}
            lplanes = bl.Get<PlanesTipo>(BaseID, null, o => o.OrderBy(c => c.NroORden)).ToList();
            foreach (PlanesTipo lplane in lplanes)
            {
                ListViewItem item = new ListViewItem(lplane.PlanesTipoID); // ,0,fontColor, backColorList, fontList);
                item.UseItemStyleForSubItems = false;
                item.SubItems.Add(lplane.PlanesTipoID, fontColor, backColorList, fontList);             //1
                item.SubItems.Add(lplane.TipoAV, fontColor, backColorList, fontList);                //2
                item.SubItems.Add(lplane.PuntoD.ToString(), fontColor, backColorList, fontList);             //3
                item.SubItems.Add(lplane.PuntoH.ToString(), fontColor, backColorList, fontList);             //4
                item.SubItems.Add(lplane.Inter.ToString(), fontColor, backColorList, fontList);             //5
                item.SubItems.Add(lplane.Inter_Incr.ToString(), fontColor, backColorList, fontList);             //6
                item.SubItems.Add(lplane.Gasto.ToString(), fontColor, backColorList, fontList);              //7
                item.SubItems.Add(lplane.Gasto_Incr.ToString(), fontColor, backColorList, fontList);             //8
                if (lplane.GastoFijo != null) nTmp = (decimal)lplane.GastoFijo; else nTmp = 0;
                item.SubItems.Add(nTmp.ToString(), fontColor, backColorList, fontList);             //9

                item.SubItems.Add(lplane.Comis.ToString(), fontColor, backColorList, fontList);             //10
                item.SubItems.Add(lplane.Comis_Incr.ToString(), fontColor, backColorList, fontList);             //11
                item.SubItems.Add(lplane.Notas, fontColor, backColorList, fontList);                         //12
                item.SubItems.Add(lplane.Corte.ToString(), fontColor, backColorList, fontList);             //13
                item.SubItems.Add(lplane.NroORden.ToString(), fontColor, backColorList, fontList);             //
                item.SubItems.Add(lplane.TipoRetencionPlanID, fontColor, backColorList, fontList);             //
                if (backColorList == Color.White) backColorList = Color.LightSteelBlue; else backColorList = Color.White;

                ListPlanes.Items.Add(item);
                ListPlanes.OwnerDraw = true;
                ListPlanes.BackColor = Color.White;
                ListPlanes.ForeColor = Color.Black;
                ListPlanes.FullRowSelect = true;
                ListPlanes.View = View.Details;
            }
            BtnPLanNvo.Enabled = true;

        }
    }
}
