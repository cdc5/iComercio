using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using System.Data.Entity;
using DevExpress.XtraGrid.Views.Grid;
using iComercio.DAL;
using iComercio.Rest;
using iComercio.Models;
using iComercio.Delegados;
using iComercio.ViewModels;
using iComercio.Auxiliar;
using iComercio.Exceptions;
using Credin;

namespace iComercio.Forms
{
    public partial class FrmPlanesConsulta : FRM
    {
        int nCreditos = 0;
        decimal nMoraTot = 0;
        int nBoniCant = 0;

        decimal nDeudaPorCred = 0;
        decimal nMora = 0;
        int nCuot_mora = 0;
        decimal nDeudaTot = 0;
        decimal nDeudaAtras = 0;
        TimeSpan difFech;
        int nCreditosSinCan = 0;
        int nCreditosCan = 0;
        string cProfesion;
        decimal nPuntaje = 0;
        decimal nDeudaMes = 0;

        Cliente cli = null;
        BindingSource profesionesBs = new BindingSource();
        BindingSource complementoBs;

        Profesion profesion;
        Profesion Complemento;

        List<PlanesParam> regPlanesParamList = null;
        List<PlanesTipo> regPlanesTipoList = null;

        Color backColorList = Color.White;
        Color fontColor = Color.Empty;
        Font fontList = new Font("Verdana", 9F, FontStyle.Regular);
        int dni;

        public FrmPlanesConsulta()
        {
            InitializeComponent();
        }

        private void FrmPlanesConsulta_Load(object sender, EventArgs e)
        {
            fitFormToScreen();
            profesionesBs.DataSource = bl.GetProfesionesPadres(bl.pGlob.Comercio.EmpresaID, null, null, "ProfesionPadre");
            complementoBs = new BindingSource(profesionesBs, "SubProfesiones");
            Utilidades.CargarCombo(cmbTipoDni, bl.GetTiposDocumento().ToList(), "TipoDocumentoID", "TipoDocumentoID");
            Utilidades.CargarCombo(cmbProfesion, profesionesBs, "Nombre", "ProfesionID");
            Utilidades.CargarCombo(cmbComplemento, complementoBs, "Nombre", "ProfesionID");
        }
        public FrmPlanesConsulta(Principal p, RestApi ra)
            : base(p)
        {
            InitializeComponent();

            Configura_Inicio();
        }
        private void BuscaPlanes()
        {
            ListPlanes.Items.Clear();
            DateTime Fecha_PriVenci;

            decimal Interes = 0;
            decimal InteresIncr;
            decimal Gst;
            decimal GstIncr;
            decimal Comis;
            decimal ComisIncr;

            decimal Inter_x_cuota;
            decimal Interes_total;

            decimal Valor_total;
            decimal Valor_cuota;
            decimal Valor_Gst;
            decimal Valor_Comis;
            bool bTieneBoni = false;
            decimal nPorBoni = 0;
            decimal nValorBoniXcuota = 0;
            decimal nTmp1 = 0;
            decimal nTmp2 = 0;
            bool bPasaP = true;

            fontColor = Color.Empty;
            backColorList = Color.LightSteelBlue;
            fontList = new Font("Verdana", 8F, FontStyle.Regular);

            bool bFiltra = false;
            decimal ValorNominal = Convert.ToDecimal(txtImporte.Text);

            if(txtDNI.Text=="0" && lblPuntaje.Text=="0")
            {
                bFiltra = false;
            }
            else
            {
                bFiltra = true;
                
            }
            regPlanesTipoList = bl.Get<PlanesTipo>(bl.pGlob.Comercio.EmpresaID, null, pl => pl.OrderBy(pla => pla.NroORden)).ToList();
            if (regPlanesTipoList.Count == 0) return;   //ACA msg error
            foreach (PlanesTipo planT in regPlanesTipoList)
            {
                //bPasaP = false;

                    if (planT.PuntoD <= nPuntaje) if (planT.PuntoH >= nPuntaje) bPasaP = true;

                if (bPasaP)
                {
                    //if (planT.planesvenci.Count > 0)
                    //{
                    for (int i = 1; i < 21; i++)                //ACA hay que ver hasta cuantas cuotas dar
                    {
                        Fecha_PriVenci = Primer_Vencimiento(planT);     //primer vencimiento por 

                        
                       
                            Interes = planT.Inter;
                            InteresIncr = planT.Inter_Incr;
                       

                        Interes = decimal.Round(Interes, 2);
                        InteresIncr = decimal.Round(InteresIncr, 2);

                        Gst = planT.Gasto;
                        GstIncr = planT.Gasto_Incr;
                        Comis = planT.Comis;
                        ComisIncr = planT.Comis_Incr;

                        ListViewItem item = new ListViewItem(planT.TipoAV);                                         // tipo
                        item.SubItems.Add(i.ToString());                                                                //cuota

                        Inter_x_cuota = (Interes * i) + (InteresIncr * i * (i - 1));
                        item.SubItems.Add(Inter_x_cuota.ToString());                                             //tasa

                        item.SubItems.Add(ValorNominal.ToString());                                          //monto

                        Interes_total = (Inter_x_cuota * ValorNominal) / 100;
                        item.SubItems.Add(Interes_total.ToString());                                         // int

                        Valor_total = Interes_total + ValorNominal;
                        item.SubItems.Add(Valor_total.ToString());                                           //total

                        Valor_cuota = Valor_total / i;
                        Valor_cuota = Convert.ToDecimal(Redondeo(Valor_cuota));
                        item.SubItems.Add(Valor_cuota.ToString("N2"));                                         //valor cuota

                        item.SubItems.Add(String.Format("{0:dd/MM/yyyy}", Fecha_PriVenci));                                         //fecha pri vencimiento

                        item.SubItems.Add(""); //planT.Notas);                                         //notas

                        if (planT.GastoFijo == 0)
                        {
                            Valor_Gst = (ValorNominal * Gst / 100) + (GstIncr * i * (i - 1));
                        }
                        else
                        {
                            Valor_Gst = (decimal)planT.GastoFijo;
                        }
                        item.SubItems.Add(Valor_Gst.ToString("N2"));                                         //gasto 9
                        Valor_Comis = (ValorNominal * Comis / 100) + (ComisIncr * i * (i - 1));
                        item.SubItems.Add(Valor_Comis.ToString());                                         //comisición 10

                        item.SubItems.Add(planT.PlanesTipoID);                                         //idplan 11

                        bTieneBoni = false;                                          //BONIFICACIONES
                        nBoniCant = 0;
                        nPorBoni = 0;
                        nValorBoniXcuota = 0;
                        if (planT.planesbonif.Count > 0)
                        {
                            foreach (PlanesBonif planboni in planT.planesbonif)
                            {
                                if (planboni.FechaVenci >= DateTime.Now)
                                {
                                    if (i >= planboni.Cuotas_D && i <= planboni.Cuotas_H)   // && planboni.TipoCuota == lplane.TipoAV)
                                    {
                                        nTmp1 = Calcula_importe_Boni(planboni, ValorNominal, Valor_cuota);
                                        nValorBoniXcuota = nTmp1;
                                        nPorBoni = planboni.PorBoni;
                                        if (planboni.TipoBoni == "X")
                                        {
                                            nTmp2 = nValorBoniXcuota * nPorBoni;
                                            item.SubItems.Add(nTmp2.ToString("N2"));
                                        }
                                        else
                                        {
                                            item.SubItems.Add(nTmp1.ToString("N2"));
                                        }
                                        //bonif 12
                                        item.SubItems.Add(planboni.TipoBoni);                                   //13                               //tipo bonif
                                        // 100;  // planboni.PorBoni;
                                        if (planboni.TipoBoni == "X")
                                        {
                                            nPorBoni = planboni.PorBoni;// 100;  // planboni.PorBoni;
                                        }
                                        else
                                        {
                                            nPorBoni = planboni.PorBoni;
                                        }


                                        bTieneBoni = true;
                                    }
                                }
                            }
                        }
                        if (!bTieneBoni)
                        {
                            item.SubItems.Add("0");                 //12
                            item.SubItems.Add("");                  //13
                        }                                                         // FIN BONIFICACIONES
                        item.SubItems.Add(Convert.ToString(i * Valor_cuota));                              //total redondeado 14

                        item.Font = fontList;


                        if (planT.TipoAV == "A" && i == 1)
                        {
                            //NO LO MUESTRA
                        }
                        else
                        {
                            if (Filtra_Planes(planT.planesdetalle.ToList(), i, planT.TipoAV, Valor_cuota))
                            {
                                item.ForeColor = fontColor;
                                if (planT.TipoAV == "A") item.BackColor = Color.Cyan;
                                item.SubItems.Add(planT.Notas); //"Bien");                          //notas 15

                                item.SubItems.Add(planT.Inter.ToString());          //16
                                item.SubItems.Add(planT.Inter_Incr.ToString());          //17
                                item.SubItems.Add(planT.Gasto.ToString());          //18
                                item.SubItems.Add(planT.Gasto_Incr.ToString());          //19
                                item.SubItems.Add(planT.GastoFijo.ToString());          //20
                                item.SubItems.Add(planT.Comis.ToString());          //21
                                item.SubItems.Add(planT.Comis_Incr.ToString());          //22
                                item.SubItems.Add(planT.TipoRetencionPlanID); //23 edu202109 
                                //item.SubItems.Add("N");                             //23// edu202109
                                item.SubItems.Add("30");                            //24
                                item.SubItems.Add(nPorBoni.ToString());             //25
                                item.SubItems.Add(nBoniCant.ToString());             //26
                                item.SubItems.Add(planT.Corte.ToString());             //27
                                item.SubItems.Add(nValorBoniXcuota.ToString());             //28

                                ListPlanes.Items.Add(item);
                            }

                        }

                    }
                    //}
                }


            }
            //foreach(PlanesTipo planT in regPlanesTipoList)
            //{
            //    for (int i = 1; i < 21; i++)                //ACA hay que ver hasta cuantas cuotas dar
            //    {
            //        if (txtDNI.Text != "0")
            //        {
            //            //if (lblPuntaje.Text != "0")
            //            //{
            //                bPasaP = false;
            //                if (planT.PuntoD <= nPuntaje) if (planT.PuntoH >= nPuntaje) bPasaP = true;
            //            //}
            //        }
            //        if (bPasaP)
            //        {
            //            Fecha_PriVenci = Primer_Vencimiento(planT);     //primer vencimiento por 

            //            Interes = planT.Inter;
            //            InteresIncr = planT.Inter_Incr;

            //            Interes = decimal.Round(Interes, 2);
            //            InteresIncr = decimal.Round(InteresIncr, 2);

            //            Gst = planT.Gasto;
            //            GstIncr = planT.Gasto_Incr;
            //            Comis = planT.Comis;
            //            ComisIncr = planT.Comis_Incr;

            //            ListViewItem item = new ListViewItem(planT.TipoAV);                                         // tipo
            //            item.SubItems.Add(i.ToString(), fontColor, backColorList, fontList);                                                                //cuota

            //            Inter_x_cuota = (Interes * i) + (InteresIncr * i * (i - 1));
            //            item.SubItems.Add(Inter_x_cuota.ToString(), fontColor, backColorList, fontList);                                             //tasa

            //            item.SubItems.Add(ValorNominal.ToString(), fontColor, backColorList, fontList);                                          //monto

            //            Interes_total = (Inter_x_cuota * ValorNominal) / 100;
            //            item.SubItems.Add(Interes_total.ToString(), fontColor, backColorList, fontList);                                         // int

            //            Valor_total = Interes_total + ValorNominal;
            //            item.SubItems.Add(Valor_total.ToString(), fontColor, backColorList, fontList);                                           //total

            //            Valor_cuota = Valor_total / i;
            //            Valor_cuota = Convert.ToDecimal(Redondeo(Valor_cuota));
            //            item.SubItems.Add(Valor_cuota.ToString("N2"), fontColor, backColorList, fontList);                                         //valor cuota

            //            item.SubItems.Add(String.Format("{0:dd/MM/yyyy}", Fecha_PriVenci), fontColor, backColorList, fontList);                                         //fecha pri vencimiento

            //            item.SubItems.Add("", fontColor, backColorList, fontList); //planT.Notas);                                         //notas

            //            if (planT.GastoFijo == null)
            //            {
            //                Valor_Gst = (ValorNominal * Gst / 100) + (GstIncr * i * (i - 1));
            //            }
            //            else
            //            {
            //                Valor_Gst = (decimal)planT.GastoFijo;
            //            }
            //            item.SubItems.Add(Valor_Gst.ToString("N2"), fontColor, backColorList, fontList);                                         //gasto 9
            //            Valor_Comis = (ValorNominal * Comis / 100) + (ComisIncr * i * (i - 1));
            //            item.SubItems.Add(Valor_Comis.ToString(), fontColor, backColorList, fontList);                                         //comisición 10

            //            item.SubItems.Add(planT.PlanesTipoID, fontColor, backColorList, fontList);                                         //idplan 11

            //            bTieneBoni = false;                                          //BONIFICACIONES
            //            nBoniCant = 0;
            //            nPorBoni = 0;
            //            nValorBoniXcuota = 0;
            //            if (planT.planesbonif.Count > 0)
            //            {
            //                foreach (PlanesBonif planboni in planT.planesbonif)
            //                {
            //                    if (planboni.FechaVenci >= DateTime.Now)
            //                    {
            //                        if (i >= planboni.Cuotas_D && i <= planboni.Cuotas_H)   // && planboni.TipoCuota == lplane.TipoAV)
            //                        {
            //                            nTmp1 = Calcula_importe_Boni(planboni, ValorNominal, Valor_cuota);
            //                            nValorBoniXcuota = nTmp1;
            //                            nPorBoni = planboni.PorBoni;
            //                            if (planboni.TipoBoni == "X")
            //                            {
            //                                nTmp2 = nValorBoniXcuota * nPorBoni;
            //                                item.SubItems.Add(nTmp2.ToString("N2"), fontColor, backColorList, fontList);
            //                            }
            //                            else
            //                            {
            //                                item.SubItems.Add(nTmp1.ToString("N2"), fontColor, backColorList, fontList);
            //                            }
            //                            //bonif 12
            //                            item.SubItems.Add(planboni.TipoBoni, fontColor, backColorList, fontList);                                    //13                               //tipo bonif
            //                            // 100;  // planboni.PorBoni;
            //                            if (planboni.TipoBoni == "X")
            //                            {
            //                                nPorBoni = planboni.PorBoni;// 100;  // planboni.PorBoni;
            //                            }
            //                            else
            //                            {
            //                                nPorBoni = planboni.PorBoni;
            //                            }


            //                            bTieneBoni = true;
            //                        }
            //                    }
            //                }
            //            }
            //            if (!bTieneBoni)
            //            {
            //                item.SubItems.Add("0", fontColor, backColorList, fontList);                  //12
            //                item.SubItems.Add("", fontColor, backColorList, fontList);                   //13
            //            }                                                         // FIN BONIFICACIONES
            //            item.SubItems.Add(Convert.ToString(i * Valor_cuota), fontColor, backColorList, fontList);                              //total redondeado 14

            //            item.Font = fontList;


            //            if (planT.TipoAV == "A" && i == 1)
            //            {
            //                //NO LO MUESTRA
            //            }
            //            else
            //            {
            //                if (Filtra_Planes(planT.planesdetalle.ToList(), i, planT.TipoAV, Valor_cuota))
            //                {
            //                    item.ForeColor = fontColor;
            //                    if (planT.TipoAV == "A") item.BackColor = Color.Cyan;
            //                    item.SubItems.Add(planT.Notas); //"Bien");                          //notas 15

            //                    item.SubItems.Add(planT.Inter.ToString());          //16
            //                    item.SubItems.Add(planT.Inter_Incr.ToString());          //17
            //                    item.SubItems.Add(planT.Gasto.ToString());          //18
            //                    item.SubItems.Add(planT.Gasto_Incr.ToString());          //19
            //                    item.SubItems.Add(planT.GastoFijo.ToString());          //20
            //                    item.SubItems.Add(planT.Comis.ToString());          //21
            //                    item.SubItems.Add(planT.Comis_Incr.ToString());          //22
            //                    item.SubItems.Add(planT.TipoRetencionPlanID); //23 edu202109 
            //                    //item.SubItems.Add("N");                             //23// edu202109
            //                    item.SubItems.Add("30");                            //24
            //                    item.SubItems.Add(nPorBoni.ToString());             //25
            //                    item.SubItems.Add(nBoniCant.ToString());             //26
            //                    item.SubItems.Add(planT.Corte.ToString());             //27
            //                    item.SubItems.Add(nValorBoniXcuota.ToString());             //28

            //                    ListPlanes.Items.Add(item);
            //                }
            //                //item.SubItems.Add(planT.Notas, fontColor, backColorList, fontList);  //"Bien");                          //notas 15

            //                //item.SubItems.Add(planT.Inter.ToString());          //16
            //                //item.SubItems.Add(planT.Inter_Incr.ToString());          //17
            //                //item.SubItems.Add(planT.Gasto.ToString());          //18
            //                //item.SubItems.Add(planT.Gasto_Incr.ToString());          //19
            //                //item.SubItems.Add(planT.GastoFijo.ToString());          //20
            //                //item.SubItems.Add(planT.Comis.ToString());          //21
            //                //item.SubItems.Add(planT.Comis_Incr.ToString());          //22
            //                //item.SubItems.Add("N");                             //23
            //                //item.SubItems.Add("30");                            //24
            //                //item.SubItems.Add(nPorBoni.ToString());             //25
            //                //item.SubItems.Add(nBoniCant.ToString());             //26
            //                //item.SubItems.Add(planT.Corte.ToString());             //27
            //                //item.SubItems.Add(nValorBoniXcuota.ToString());             //28

            //                //ListPlanes.Items.Add(item);
            //                if (backColorList == Color.White) backColorList = Color.LightSteelBlue; else backColorList = Color.White;
            //            }
            //        }
            //    }
            //}




        }
        private bool Filtra_Planes(List<PlanesDetalle> regPlanesDetalleList, int ncuota, string tcuota, decimal ValCuot)
        {
            bool bPasoCuota = true;
            bool bPasoValor = true;
            bool bPasoValorMax = true;
            //cFiltrado = "";
            if (regPlanesDetalleList.Count > 0)
            {
                foreach (PlanesDetalle pd in regPlanesDetalleList)
                {
                    bPasoCuota = false;                //                                                     CUOTAS
                    if (ncuota >= pd.Cuotas_D && ncuota <= pd.Cuotas_H)
                    {
                        bPasoCuota = true;
                        break;

                    }// else  cFiltrado = "Filtro Cuotas";

                    //if (bPasoCuota)
                    //{
                    //    if (pd.SiValor)                                                        // entre valores
                    //    {
                    //        bPasoValor = false;
                    //        cFiltrado = "Filtro valor";
                    //        if (Convert.ToDecimal(txtPlanVN.Text) >= pd.nValor_D && Convert.ToDecimal(txtPlanVN.Text) <= pd.nValor_H) bPasoValor = true;
                    //    }


                    //    if (pd.Monto_max > 0)                                                        // valor maximo
                    //    {
                    //        bPasoValorMax = false;
                    //        if (Convert.ToDecimal(txtPlanVN.Text) <= pd.Monto_max) bPasoValorMax = true; else cFiltrado = "Filtro valor max";
                    //    }
                    //    if (!bPasoValor || !bPasoValorMax) return false; else return true;
                    //}
                    

                }
                return bPasoCuota;
            }
            else
            {
                return true;
            }

            //decimal nTmp3 = 0;
            //nTmp3 = Convert.ToDecimal(bl.pGlob.Comercio.PorSueldo);



            return false;
        }
        //private bool Filtra_Planes(List<PlanesDetalle> regPlanesDetalleList, int ncuota, string tcuota, decimal ValCuot)
        //{
        //    bool bPasoCuota = true;
        //    bool bPasoValor = true;
        //    bool bPasoValorMax = true;
        //    cFiltrado = "";
        //    if (regPlanesDetalleList.Count > 0)
        //    {
        //        foreach (PlanesDetalle pd in regPlanesDetalleList)
        //        {
        //            bPasoCuota = false;                //                                                     CUOTAS
        //            if (ncuota >= pd.Cuotas_D && ncuota <= pd.Cuotas_H) bPasoCuota = true;  // else  cFiltrado = "Filtro Cuotas";

        //            if (bPasoCuota)
        //            {
        //                if (pd.SiValor)                                                        // entre valores
        //                {
        //                    bPasoValor = false;
        //                    cFiltrado = "Filtro valor";
        //                    if (Convert.ToDecimal(txtPlanVN.Text) >= pd.nValor_D && Convert.ToDecimal(txtPlanVN.Text) <= pd.nValor_H) bPasoValor = true;
        //                }


        //                if (pd.Monto_max > 0)                                                        // valor maximo
        //                {
        //                    bPasoValorMax = false;
        //                    if (Convert.ToDecimal(txtPlanVN.Text) <= pd.Monto_max) bPasoValorMax = true; else cFiltrado = "Filtro valor max";
        //                }
        //                if (!bPasoValor || !bPasoValorMax) return false;
        //            }


        //        }
        //    }
        //    else
        //    {
        //        return true;
        //    }

        //    //decimal nTmp3 = 0;
        //    //nTmp3 = Convert.ToDecimal(bl.pGlob.Comercio.PorSueldo);



        //    return true;
        //}
        private decimal Calcula_importe_Boni(PlanesBonif pboni, decimal VN, decimal VC)
        {
            decimal qBoni = 0;
            nBoniCant = 0;
            if (pboni.TipoBoni == "C")
            {
                if (pboni.PorBoni == 100)
                {
                    qBoni = VC;
                }
                else
                {
                    qBoni = VC * pboni.PorBoni / 100;
                }
                nBoniCant = 1;
            }
            else if (pboni.TipoBoni == "V")
            {
                qBoni = VN * pboni.PorBoni / 100;
                nBoniCant = 1;
            }
            else if (pboni.TipoBoni == "X")
            {
                qBoni = VC; // *pboni.PorBoni;
                nBoniCant = (int)(pboni.PorBoni);

            }
            return qBoni;
        }
        //private DateTime Primer_Vencimiento(PlanesTipo UnPlan)
        //{
        //    DateTime PriVenci;
        //    int nAno = 1;
        //    int nMes = 1;
        //    int nDia = 10;
        //    int nCorte = 20;
        //    int CuantosMeses = 1;

        //    bool bNormal = false;

        //    string cTipoVenci;
        //    int nV = UnPlan.planesvenci.Count;

        //    PriVenci = DateTime.Now.AddMonths(CuantosMeses);
        //    if (nV == 0)
        //    {
        //        nDia = DateTime.Now.Day;
        //        bNormal = true;
        //    }
        //    else
        //    {
        //        if (UnPlan.planesvenci[0].DiasPrimerCuota > 0)      // cuantos meses es el primer venci
        //        {
        //            CuantosMeses = UnPlan.planesvenci[0].DiasPrimerCuota / 30;
        //        }

        //        cTipoVenci = UnPlan.planesvenci[0].TipoVencimiento;

        //        if (cTipoVenci == "*" || cTipoVenci == "A1")                                        // un corte 
        //        {
        //            nDia = DateTime.Now.Day; // UnPlan.planesvenci[0].VenciDia;
        //            nCorte = UnPlan.planesvenci[0].VenciCorte;
        //            PriVenci = DateTime.Now.AddMonths(CuantosMeses);
        //            if (nDia > nCorte)
        //            {
        //                nDia = UnPlan.planesvenci[0].VenciDia;   //10;
        //                PriVenci = DateTime.Now.AddMonths(2);
        //            }
        //            return PriVenci = Convert.ToDateTime(nDia + "/" + PriVenci.Month + "/" + PriVenci.Year);
        //        }
        //        else if (cTipoVenci == " ")                                    // 30 dias si no pasa el 28
        //        {

        //            if (DateTime.Now.Day <= 28)
        //            {
        //                PriVenci = DateTime.Now.AddMonths(CuantosMeses);
        //            }
        //            else
        //            {
        //                PriVenci = DateTime.Now.AddMonths(CuantosMeses + 1);
        //                PriVenci = Convert.ToDateTime("10" + "/" + PriVenci.Month + "/" + PriVenci.Year);

        //            }
        //            return PriVenci;
        //        }
        //        else if (cTipoVenci == "A2")                                                      // hay que ver si está bien
        //        {
        //            nDia = DateTime.Now.Day; //UnPlan.planesvenci[0].VenDia1;
        //            PriVenci = DateTime.Now.AddMonths(CuantosMeses);

        //            if (nDia <= UnPlan.planesvenci[0].VenciDia)
        //            {
        //                nDia = UnPlan.planesvenci[0].VenciDia;
        //            }
        //            else if (nDia <= UnPlan.planesvenci[0].Vendia2)
        //            {
        //                nDia = UnPlan.planesvenci[0].Vendia2;
        //            }
        //            return PriVenci = Convert.ToDateTime(nDia + "/" + PriVenci.Month + "/" + PriVenci.Year);
        //        }
        //    }                                       //if (nV >0)

        //    if (bNormal)                         // treinta dias o al 10 del segundo mes si el dia es > 28
        //    {
        //        nMes = DateTime.Now.Month + 1;
        //        nAno = DateTime.Now.Year;
        //        if (nDia > 28)
        //        {
        //            nDia = 10;
        //            nMes = nMes + 1;
        //        }
        //        if (nMes == 13)
        //        {
        //            nMes = 1;
        //            nAno = nAno + 1;
        //        }
        //        else if (nMes == 14)
        //        {
        //            nMes = 2;
        //            nAno = nAno + 1;
        //        }
        //        PriVenci = Convert.ToDateTime(nDia + "/" + nMes + "/" + nAno);
        //    }
        //    return PriVenci;

        //}

        private DateTime Primer_Vencimiento(PlanesTipo UnPlan)
        {
            DateTime PriVenci;
            //int nAno = 1;
            //int nMes = 1;
            int nDia = 10;
            int nCorte = 20;
            int CuantosMeses = 1;

            //bool bNormal = false;

            string cTipoVenci;
            int nV = UnPlan.planesvenci.Count;

            CuantosMeses = 1;
            PriVenci = DateTime.Now.AddMonths(CuantosMeses);

            if (nV == 0)
            {
                //nDia = DateTime.Now.Day;
                //bNormal = true;
            }
            else
            {
                if (UnPlan.planesvenci[0].DiasPrimerCuota > 0)      // cuantos meses es el primer venci
                {
                    CuantosMeses = UnPlan.planesvenci[0].DiasPrimerCuota / 30;
                }
                else
                {
                    CuantosMeses = 1;
                }

                nDia = DateTime.Now.Day; // UnPlan.planesvenci[0].VenciDia;
                nCorte = UnPlan.planesvenci[0].VenciCorte;
                PriVenci = DateTime.Now.AddMonths(CuantosMeses);
                cTipoVenci = UnPlan.planesvenci[0].TipoVencimiento;
                if (cTipoVenci == "*" || cTipoVenci == "A1")
                {
                    if (nDia <= nCorte)
                    {
                        nDia = UnPlan.planesvenci[0].VenciDia;
                        return PriVenci = Convert.ToDateTime(nDia + "/" + PriVenci.Month + "/" + PriVenci.Year);
                    }
                    else
                    {
                        nDia = 10;
                        PriVenci = PriVenci.AddMonths(1);
                        return PriVenci = Convert.ToDateTime(nDia + "/" + PriVenci.Month + "/" + PriVenci.Year);
                    }
                }
                else if (cTipoVenci == " ")
                {
                    if (nDia <= 28)
                    {
                        return PriVenci;
                    }
                    else
                    {
                        PriVenci = PriVenci.AddMonths(1);
                        return PriVenci = Convert.ToDateTime(10 + "/" + PriVenci.Month + "/" + PriVenci.Year);
                    }
                }

                else if (cTipoVenci == "A2")
                {
                    if (nDia <= nCorte)
                    {
                        return PriVenci = Convert.ToDateTime(nCorte + "/" + PriVenci.Month + "/" + PriVenci.Year);
                    }
                    else if (nDia <= UnPlan.planesvenci[0].Vendia2)
                    {
                        nCorte = UnPlan.planesvenci[0].Vendia2;
                        return PriVenci = Convert.ToDateTime(nCorte + "/" + PriVenci.Month + "/" + PriVenci.Year);
                    }
                    else if (nDia > UnPlan.planesvenci[0].Vendia2)
                    {
                        PriVenci = PriVenci.AddMonths(1);
                        nDia = 1;
                        return PriVenci = Convert.ToDateTime(nDia + "/" + PriVenci.Month + "/" + PriVenci.Year);

                    }
                }
            }
            return PriVenci;


        }
        private void Llena_Cuotas(ListViewItem lItem)
        {
            fontColor = Color.Empty;
            backColorList = Color.LightSteelBlue;
            fontList = new Font("Verdana", 8F, FontStyle.Regular);
            listCuotas.Items.Clear();
            int nDesde = 0;
            decimal nAPagar = 0;
            if (lItem.SubItems[0].Text == "A") nDesde = 2; else nDesde = 1;

            DateTime FechVenci = Convert.ToDateTime(lItem.SubItems[7].Text);

            decimal nTmp1 = 0;
            int nCuotas = Convert.ToInt16(lItem.SubItems[1].Text);
            decimal nValCuota = Convert.ToDecimal(lItem.SubItems[6].Text);
            nTmp1 = Convert.ToDecimal(lItem.SubItems[14].Text);
            decimal nValInt = (nTmp1 - Convert.ToDecimal(txtImporte.Text)) / nCuotas;


            decimal nBoni = Convert.ToDecimal(lItem.SubItems[28].Text);
            //lblPlanBoniValorXcuota.Text = lItem.SubItems[28].Text;
            nBoniCant = Convert.ToInt16(lItem.SubItems[26].Text);

            //lblPlanBoniValor.Text = "0";

            for (int i = nDesde; i <= nCuotas; i++)
            {
                ListViewItem item = new ListViewItem(i.ToString());
                item.SubItems.Add(String.Format("{0:dd/MM/yyyy}", FechVenci), fontColor, backColorList, fontList);
                item.SubItems.Add(nValCuota.ToString(), fontColor, backColorList, fontList);
                item.SubItems.Add(nValInt.ToString("N2"), fontColor, backColorList, fontList);
                if (nBoniCant == 1)
                {
                    if (i == nCuotas) item.SubItems.Add(nBoni.ToString(), fontColor, backColorList, fontList); else item.SubItems.Add("0", fontColor, backColorList, fontList);
                }
                else if (nBoniCant > 1)
                {
                    if (i > nCuotas - nBoniCant) item.SubItems.Add(nBoni.ToString(), fontColor, backColorList, fontList); else item.SubItems.Add("0", fontColor, backColorList, fontList);
                }


                listCuotas.Items.Add(item);
                FechVenci = FechVenci.AddMonths(1);
                if (backColorList == Color.White) backColorList = Color.LightSteelBlue; else backColorList = Color.White;

            }

            //lblPlanCuotas.Text = nCuotas.ToString();
            //if (lItem.SubItems[0].Text == "A")
            //{
            //    lblPlanTipo.Text = "Adelantada";
            //    nAPagar = nValCuota;
            //}
            //else
            //{
            //    lblPlanTipo.Text = "Vencida";
            //}
            //lblPlanTipoAV.Text = lItem.SubItems[0].Text;
            //lblPlanValorCuotas.Text = nValCuota.ToString();
            //lblPlanBoniTipo.Text = lItem.SubItems[13].Text;
            //lblPlanBoniPorcen.Text = lItem.SubItems[25].Text;
            //lblPlanBoniValor.Text = lItem.SubItems[12].Text;
            ////            lblPlanBoniValor.Text = Convert.ToString(Convert.ToDouble(lblPlanBoniValor.Text) + Convert.ToDouble(lItem.SubItems[12].Text));

            //nTmp1 = nValInt * nCuotas;
            //lblPlanInteresImp.Text = nTmp1.ToString();
            //lblPlanPrimerVenci.Text = lItem.SubItems[7].Text;
            //lblPlanGastoImp.Text = lItem.SubItems[9].Text;
            //nAPagar = nAPagar + Convert.ToDecimal(lItem.SubItems[9].Text);
            //lblPlanComisionImp.Text = lItem.SubItems[10].Text;
            //lblPlanTasa.Text = lItem.SubItems[16].Text;
            //lblPlanTasaIncr.Text = lItem.SubItems[17].Text;
            //lblPlanGastoInt.Text = lItem.SubItems[18].Text;
            //lblPlanGastoIncr.Text = lItem.SubItems[19].Text;
            //lblPlanGastoFijo.Text = lItem.SubItems[20].Text;
            //lblPlanComisionInt.Text = lItem.SubItems[21].Text;
            //lblPlanComisionIncr.Text = lItem.SubItems[22].Text;

            //lblPlanRetencion.Text = lItem.SubItems[23].Text;
            //lblPlanDiasVenci.Text = lItem.SubItems[24].Text;
            //lblPlanAPagar.Text = nAPagar.ToString("N2");
            //lblPlanCorte.Text = lItem.SubItems[27].Text;

        }
        private void Configura_Inicio()
        {
            Configura_Controles();
            Configura_Listas();
        }
        private void Configura_Controles()
        {
            ListPlanes.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(lista_Dibuja_Encabezado);
            ListPlanes.DrawSubItem += lista_DrawSubItem;
            this.BackColor = ColorBackColorFrm;
            Recorre_Formulario(this);
            Configura_Colores(bl.pGlob.Comercio.EmpresaID);
            txtDNI.Text = "0";
            txtImporte.Text = "0";

            Limpia();
        }
        private void Limpia()
        {
            ListPlanes.Items.Clear();

        }
        private void Configura_Listas()
        {
            listCuotas.View = View.Details;
            listCuotas.Columns.Add("Cuota", 40, HorizontalAlignment.Left);               //0
            listCuotas.Columns.Add("Vencimiento", 80, HorizontalAlignment.Left);               //0
            listCuotas.Columns.Add("Valor Cuota", 80, HorizontalAlignment.Left);               //0
            listCuotas.Columns.Add("", 0, HorizontalAlignment.Left);               //0
            listCuotas.Columns.Add("Bonif", 80, HorizontalAlignment.Left);               //0
            listCuotas.OwnerDraw = true;

            ListPlanes.View = View.Details;
            ListPlanes.Columns.Add("Tipo", 40, HorizontalAlignment.Left);               //0
            ListPlanes.Columns.Add("Cuota", 50, HorizontalAlignment.Right);
            ListPlanes.Columns.Add("", 0, HorizontalAlignment.Right);              //2Tasa
            ListPlanes.Columns.Add("", 0, HorizontalAlignment.Right);               //Monto
            ListPlanes.Columns.Add("", 0, HorizontalAlignment.Right);             //4  Inter
            ListPlanes.Columns.Add("", 0, HorizontalAlignment.Right);               //Total
            ListPlanes.Columns.Add("Valor Cuota", 80, HorizontalAlignment.Right);       //6
            ListPlanes.Columns.Add("Primer Vencimiento", 90, HorizontalAlignment.Left); //7
            ListPlanes.Columns.Add("", 0, HorizontalAlignment.Left);            //Notas
            ListPlanes.Columns.Add("Gasto", 60, HorizontalAlignment.Right);              //9
            ListPlanes.Columns.Add("", 0, HorizontalAlignment.Right);               //Comis
            ListPlanes.Columns.Add("IdPlan", 140, HorizontalAlignment.Left);              //11
            ListPlanes.Columns.Add("Bonif", 80, HorizontalAlignment.Right);
            ListPlanes.Columns.Add("T Boni", 60, HorizontalAlignment.Left);             //13
            ListPlanes.Columns.Add("", 0, HorizontalAlignment.Right);                   //Total redondeado
            ListPlanes.Columns.Add("notas", 140, HorizontalAlignment.Left);
            ListPlanes.OwnerDraw = true;
        }

        private void BtnBusca_Click(object sender, EventArgs e)
        {
            if(BtnBusca.Text=="Mostrar")
            {
                BuscaPlanes();
            }else
            {
                BtnBusca.Text = "Otro";
            }
        }

        private void grpBusca_Enter(object sender, EventArgs e)
        {

        }



        private void ListPlanes_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //lblValida.Text = "";
            foreach (ListViewItem aa in ListPlanes.SelectedItems)
            {
                //Valida_Planes(aa);
                Llena_Cuotas(aa);
            }
        }

        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloNumeros(e);
        }
        private bool ValidarDni(string dni)
        {
            if (dni == "0") return false;
            int dniMax = 150000000;
            int iDni;
            if (int.TryParse(dni, out iDni))
            {
                if (iDni >= dniMax)
                {
                    MessageBox.Show(String.Format("No se puede ingresar un dni Mayor a {0}", dniMax));
                }
                else
                    return true;
            }
            else
            {
                MessageBox.Show(String.Format("El formato introducido no es correcto", dniMax));
            }
            return false;
        }
        private void LimpiarCampos()
        {
            cmbProfesion.SelectedIndex = -1;
            cmbComplemento.SelectedIndex = -1;
            cmbTipoDni.SelectedIndex = -1;
            txtSueldo.Text = "0";
            //TxtSueldo.Text = String.Empty;
            //txtValorNominal.Text = String.Empty;
            //lblCamaraLocal.Text = string.Empty;
            //lblCamaraRemota.Text = string.Empty;
            //rbSGarante.Checked = true;
            //chkAdi.Checked = false;
            //clienteBindingSource.DataSource = null;
            //infoClienteBindingSource.DataSource = null;
            pbFotoDNI.Image = null;
            lblPuntaje.Text = "0";
            nCreditos = 0;
            nPuntaje = 0;
            //lblCamaraLocal.Text = string.Empty;
        }
        private Image BuscarImagen(string dni)
        {
            return bl.BuscarFotosDni(dni);
        }
        private void ObtenerDatosClientes(int dni)
        {
            cli = bl.Get<Cliente>(c => c.Documento == dni).FirstOrDefault();



            if (cli != null)
            {
                cmbTipoDni.SelectedIndex = cmbTipoDni.Items.IndexOf(cli.TipoDocumento);
                CargarProfesion(cli.Profesion);
                txtSueldo.Text = cli.Sueldo.ToString();
                // ObtenerCreditos(cli);                
            }
            else
            {
                cli = new Cliente();
                cli.Documento = dni;
                cli.TipoDocumentoID = "DNI";
               
            }


        }
        private void CargarProfesion(Profesion pro)
        {
            if (pro != null)
            {
                if (pro.ProfesionPadre != null)
                {
                    cmbProfesion.SelectedIndex = cmbProfesion.Items.IndexOf(cli.Profesion.ProfesionPadre);
                    cmbComplemento.SelectedIndex = cmbComplemento.Items.IndexOf(cli.Profesion);
                    cProfesion = cli.ProfesionID;
                }
                else
                {
                    cmbProfesion.SelectedIndex = cmbProfesion.Items.IndexOf(cli.Profesion);
                }
            }
        }
        private void txtDNI_Leave(object sender, EventArgs e)
        {
            LimpiarCampos();
            if (ValidarDni(txtDNI.Text))
            {
                //txtDNI.Enabled = false;
                
                pbFotoDNI.Image = BuscarImagen(txtDNI.Text);
                int.TryParse(txtDNI.Text, out dni);
                ObtenerDatosClientes(dni);
                Busca_Datos_Creditos();
                if (nCreditos > 0) Calcula_puntaje();
            }
        }
        private bool Calcula_puntaje()
        {
            decimal nTmp = 0;
            decimal nTmp1 = 0;
            string cTmp = "";
            PlanesParam regPlanesParam;
            decimal nPuntIngre = 0;
            decimal nPuntCred = 0;
            decimal nPuntCanc = 0;
            decimal nPuntMora = 0;
            decimal nPuntLabo = 0;

            //regPlanesParamList = bl.GetPlanesParams(c => c.Param2 == "INGRESOS", p => p.OrderBy(pl => pl.Orden)).ToList();

            if (Busca_Parametros("INGRESOS") == false) return false;
            nTmp = 0;
            nTmp1 = Convert.ToDecimal(txtSueldo.Text);
            foreach (PlanesParam lplparam in regPlanesParamList)
            {
                if (lplparam.Desde <= nTmp1 && lplparam.Hasta >= nTmp1)
                {
                    //lblParamSueldo.Text = lplparam.Valor.ToString();
                    regPlanesParam = bl.Get<PlanesParam>(c => c.Param1 == "INGRESOS").FirstOrDefault();
                    nTmp = (regPlanesParam.Valor * lplparam.Valor); ///100;
                    nPuntIngre = nTmp / 100;
                    //if (regPlanesParam != null) lblPuntaSueldo.Text = nPuntIngre.ToString();
                }
            }

            if (Busca_Parametros("CREDITOS") == false) return false;
            nTmp = 0;
            nTmp1 = nCreditos; // Convert.ToDecimal(lblCalcCred.Text);
            foreach (PlanesParam lplparam in regPlanesParamList)
            {
                if (lplparam.Desde <= nTmp1 && lplparam.Hasta >= nTmp1)
                {
                    //lblParamCred.Text = lplparam.Valor.ToString();
                    regPlanesParam = bl.Get<PlanesParam>(c => c.Param1 == "CREDITOS").FirstOrDefault();
                    nTmp = (regPlanesParam.Valor * lplparam.Valor); ///100;
                    nPuntCred = nTmp / 100;
                    //if (regPlanesParam != null) lblPuntaCred.Text = nPuntCred.ToString();
                }
            }

            if (Busca_Parametros("CANCELADOS") == false) return false;
            nTmp = 0;
            nTmp1 = nCreditosCan; // Convert.ToDecimal(lblCalcCan.Text);
            foreach (PlanesParam lplparam in regPlanesParamList)
            {
                if (lplparam.Desde <= nTmp1 && lplparam.Hasta >= nTmp1)
                {
                    //lblParamCan.Text = lplparam.Valor.ToString();
                    regPlanesParam = bl.Get<PlanesParam>(c => c.Param1 == "CANCELADOS").FirstOrDefault();
                    nTmp = (regPlanesParam.Valor * lplparam.Valor); ///100;
                    nPuntCanc = nTmp / 100;
                    //if (regPlanesParam != null) lblPuntaCan.Text = nPuntCanc.ToString();
                }
            }

            if (Busca_Parametros("MOROSIDAD") == false) return false;
            nTmp = 0;
            nTmp1 = nMoraTot; // Convert.ToDecimal(lblCalcMora.Text);
            foreach (PlanesParam lplparam in regPlanesParamList)
            {
                if (lplparam.Desde <= nTmp1 && lplparam.Hasta >= nTmp1)
                {
                    //lblParamMora.Text = lplparam.Valor.ToString();
                    regPlanesParam = bl.Get<PlanesParam>(c => c.Param1 == "MOROSIDAD").FirstOrDefault();
                    nTmp = (regPlanesParam.Valor * lplparam.Valor); ///100;
                    nPuntMora = nTmp / 100;
                    //if (regPlanesParam != null) lblPuntaMora.Text = nPuntMora.ToString();
                }
            }


            if (!Busca_Parametros("LABORAL")) return false;
            nTmp = 0;
            //Busca_En_Combo(cmbProfesion, cProfesion);
            cTmp = cProfesion; // lblCalcLabo.Text;
            foreach (PlanesParam lplparam in regPlanesParamList)
            {
                if (lplparam.Param1 == cTmp)
                {
                    //lblParamLabo.Text = lplparam.Valor.ToString();
                    regPlanesParam = bl.Get<PlanesParam>(c => c.Param1 == "LABORAL").FirstOrDefault();
                    nTmp = (regPlanesParam.Valor * lplparam.Valor); ///100;
                    nPuntLabo = nTmp / 100;
                    //if (regPlanesParam != null) lblPuntaLabo.Text = nPuntLabo.ToString();
                }
            }
            nPuntaje = nPuntIngre + nPuntCred + nPuntCanc + nPuntMora + nPuntLabo;

            lblPuntaje.Text = nPuntaje.ToString();
            //lblCliPuntajeFrm.Text = lblCalcPunta.Text;

            return true;
        }
        private bool Busca_Parametros(string qParam)
        {
            regPlanesParamList = bl.Get<PlanesParam>(bl.pGlob.Comercio.EmpresaID, c => c.Param2 == qParam, p => p.OrderBy(pl => pl.Orden)).ToList();
            if (regPlanesParamList.Count == 0)
            {
                //ACA ERROR
                return false;
            }
            return true;
        }
        private void Calcula_Datos_Creditos(List<Credito> ListCreditos)
        {
            foreach (Credito Cred in ListCreditos)
            {
                nCreditos++;
                nDeudaPorCred = 0;
                nMora = 0;
                nCuot_mora = 0;
                DateTime PriVenci = DateTime.Now.AddMonths(1);
                foreach (Cuota cuo in Cred.Cuotas)
                {
                    if (cuo.Importe - cuo.ImportePago > 0)
                    {
                        nDeudaTot = nDeudaTot + (cuo.Importe - cuo.ImportePago);
                        nDeudaPorCred = nDeudaPorCred + (cuo.Importe - cuo.ImportePago);
                        if (cuo.FechaVencimiento <= DateTime.Now) nDeudaAtras = nDeudaAtras + (cuo.Importe - cuo.ImportePago);


                        if (cuo.FechaVencimiento.Year == PriVenci.Year && cuo.FechaVencimiento.Month == PriVenci.Month) nDeudaMes = nDeudaMes + cuo.Importe;

                        difFech = DateTime.Now - cuo.FechaVencimiento;
                        nMora = nMora + difFech.Days;
                        nCuot_mora++; // = nCuot_mora + 1;
                    }
                    else
                    {
                        if (cuo.FechaUltimoPago != null)
                        {
                            if (cuo.FechaUltimoPago > cuo.FechaVencimiento)
                            {
                                difFech = Convert.ToDateTime(cuo.FechaUltimoPago) - cuo.FechaVencimiento;
                                nMora = nMora + difFech.Days;
                                nCuot_mora++;// = nCuot_mora + 1;
                            }
                        }
                    }

                }
                if (nDeudaPorCred > 0) nCreditosSinCan++; else nCreditosCan++;

                if (nMora > 0 && nCuot_mora > 0)
                {
                    nMoraTot = nMoraTot + Convert.ToInt16(nMora / nCuot_mora);
                }
            }


        }
        private void Busca_Datos_Creditos()
        {
            if (cli != null)
            {
                //List<Credito> regCreditosList;
                //regCreditosList = regCliente.Creditos
                if (cli.Creditos.Count > 0)
                {
                    Calcula_Datos_Creditos(cli.Creditos.ToList());
                }

                if (cli.CreditosAdi.Count > 0)
                {
                    Calcula_Datos_Creditos(cli.CreditosAdi.ToList());
                }

                if (cli.CreditosGar1.Count > 0)
                {
                    Calcula_Datos_Creditos(cli.CreditosGar1.ToList());
                }
                if (cli.CreditosGar2.Count > 0)
                {
                    Calcula_Datos_Creditos(cli.CreditosGar2.ToList());
                }
                if (cli.CreditosGar3.Count > 0)
                {
                    Calcula_Datos_Creditos(cli.CreditosGar3.ToList());
                }

                if (nMoraTot > 0 && nCreditos > 0) nMoraTot = nMoraTot / nCreditos;

                //lblCalcCred.Text = nCreditos.ToString();
                //lblCalcCan.Text = nCreditosCan.ToString();
                //lblCalcSinCan.Text = nCreditosSinCan.ToString();
                //lblCalcMora.Text = Convert.ToInt16(nMoraTot).ToString(); // nMoraTot.ToString();
                //lblCalcDeuda.Text = nDeudaTot.ToString();
                //lblCalcDeudaAtras.Text = nDeudaAtras.ToString();
                //lblCalcDeudaMensual.Text = nDeudaMes.ToString();

                

            }

            return;




        }


    }
}
