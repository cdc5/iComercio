using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iComercio.Models;
namespace iComercio.Forms
{
    public partial class FrmRevision : FRM
    {
        Color backColorList = Color.White;
        Color fontColor = Color.Empty;
        Font fontList = new Font("Verdana", 8F, FontStyle.Regular);


        public FrmRevision()
        {
            InitializeComponent();
        }

        private void FrmRevision_Load(object sender, EventArgs e)
        {
            //Configura_Inicio();
        }
        public FrmRevision(Principal p, string queHace)
            : base(p)
        {
            InitializeComponent();
            Configura_Inicio();
        }
        private void Arregla_Altas()
        {
            RecargarEmpYComercio(false);
            int nDiaCorte = cmbSEMANA.SelectedIndex;
            Credito regCred;
            int nCredito = 0;
            DateTime fFechaSoli;
            DateTime fFechaAviso;
            DateTime fFechaNVA;
            DateTime dFechaCorte;
            DateTime fFechacc;
            DateTime fFechaCuentaC = DateTime.Now.AddYears(-1);
            CuentaCorriente cc = new CuentaCorriente();
            int nMov = 0;
            string cREtencion = "N";
            CuentaCorrienteCorte regCtaCte;
            regCtaCte = bl.Get<CuentaCorrienteCorte>(bl.pGlob.EmpresaID, c => c.EmpresaID == bl.pGlob.EmpresaID && c.ComercioID == bl.pGlob.Comercio.ComercioID
                            , o => o.OrderBy(c => c.Fecha), "", 1).FirstOrDefault();
            if(regCtaCte != null)
            {
                fFechaCuentaC = regCtaCte.Fecha;
            }

            for(int nF = 0; nF < listBusca.Items.Count; nF++)
            {
                nCredito = Convert.ToInt32( listBusca.Items[nF].SubItems[0].Text);
                regCred = bl.Get<Credito>(c => c.ComercioID == bl.pGlob.Comercio.ComercioID && c.CreditoID == nCredito).FirstOrDefault();
                if(regCred == null)
                {
                    listBusca.Items[nF].SubItems[9].Text = "No encontrado";
                }
                listBusca.Items[nF].SubItems[9].Text = "Arreglando";
                Application.DoEvents();


                fFechaSoli = regCred.FechaSolicitud;
                if(fFechaSoli <= fFechaCuentaC)
                {
                    fFechaSoli = FechaLote(fFechaSoli, nDiaCorte);
                }

                fFechaAviso = regCred.FechaAviso;
                dFechaCorte = fFechaSoli.AddDays(Convert.ToDouble(regCred.Corte));
                cREtencion = "N";
                if(chkRetencion.Checked)
                {
                    if(regCred.Gasto > 0 && regCred.TipoCuotaID == "A")
                    {
                        cREtencion = "A";
                    }else if(regCred.Gasto > 0)
                    {
                        cREtencion = "G";
                    }else if(regCred.TipoCuotaID == "A")
                    {
                        cREtencion = "C";
                    }

                }

                if(fFechaAviso.ToShortDateString() != dFechaCorte.ToShortDateString())
                {
                    regCred.FechaAviso = dFechaCorte;
                    if(chkRetencion.Checked) regCred.TipoRetencionPlanID = cREtencion;
                        bl.Actualizar<Credito>(regCred);
                    listBusca.Items[nF].SubItems[10].Text = "ARREGLADO";
                }
                //5
                nMov = bl.pGlob.TmCredOtorEfec.TipoMovimientoID;
                cc = bl.Get<CuentaCorriente>(c => c.CreditoID == nCredito && c.TipoMovimientoID == nMov).FirstOrDefault();
                if(cc == null)
                {
                    cc = bl.ImputarCreditoACuentaCorriente(BaseID, regCred);
                    
                }else
                {
                    fFechacc = (DateTime)cc.FechaAviso;
                    if(fFechacc.ToShortDateString() != dFechaCorte.ToShortDateString())
                    {
                        cc.FechaAviso = dFechaCorte;
                        bl.Actualizar<CuentaCorriente>(cc);
                        listBusca.Items[nF].SubItems[11].Text = "ARREGLADO";
                    }
                }
                //6
                if(regCred.TipoCuotaID == "A")
                {
                    nMov = bl.pGlob.TmCuotaAdelantada.TipoMovimientoID;
                    cc = bl.Get<CuentaCorriente>(c => c.CreditoID == nCredito && c.TipoMovimientoID == nMov).FirstOrDefault();
                    if(regCred.TipoRetencionPlanID == "C" || regCred.TipoRetencionPlanID == "A")
                    {
                        fFechaNVA = dFechaCorte;
                    }
                    else fFechaNVA = fFechaSoli;
                    if(cc == null)
                    {
                        bl.ImputarCuotaAdelantadaACuentaCorriente(BaseID, regCred, fFechaNVA);
                    }
                    else
                    {
                        fFechacc = (DateTime)cc.FechaAviso;
                        if(fFechacc.ToShortDateString() != fFechaNVA.ToShortDateString())
                        {
                            cc.FechaAviso = fFechaNVA;
                            bl.Actualizar<CuentaCorriente>(cc);
                            listBusca.Items[nF].SubItems[12].Text = "ARREGLADO";

                        }
                    }
                }
                    //7
                if(regCred.Gasto > 0)
                {
                    nMov = bl.pGlob.TmGasDescCredOtor.TipoMovimientoID;
                    cc = bl.Get<CuentaCorriente>(c => c.CreditoID == nCredito && c.TipoMovimientoID == nMov).FirstOrDefault();
                    if(regCred.TipoRetencionPlanID == "G" || regCred.TipoRetencionPlanID == "A")
                    {
                        fFechaNVA = dFechaCorte;
                    }
                    else fFechaNVA = fFechaSoli;
                    if(cc == null)
                    {
                        bl.ImputarGastoCreditoACuentaCorriente(BaseID, regCred, fFechaNVA);
                    }
                    else
                    {
                        fFechacc = (DateTime)cc.FechaAviso;
                        if(fFechacc.ToShortDateString() != fFechaNVA.ToShortDateString())
                        {
                            cc.FechaAviso = fFechaNVA;
                            bl.Actualizar<CuentaCorriente>(cc);
                            listBusca.Items[nF].SubItems[13].Text = "ARREGLADO";
                        }
                    }

                }


                listBusca.Items[nF].SubItems[9].Text = "LISTO";
                Application.DoEvents();
            }
            //lblMsg.Text = "Terminado";
        }
        private DateTime FechaLote(DateTime ffecha, int nNvo)
        {
            DateTime date = ffecha;
            int diaSemana = (int)ffecha.DayOfWeek;
            if(nNvo == diaSemana)
            {

            }
            else if(nNvo > diaSemana)
            {
                date = date.AddDays(nNvo - (int)ffecha.DayOfWeek);
            }
            else
            {
                date = date.AddDays(nNvo - ((int)ffecha.DayOfWeek) + 7);
            }

            return date;
        }
        private void Busca_Altas()
        {
            int nDiaCorte = cmbSEMANA.SelectedIndex;
            listBusca.Items.Clear();
            listBusca.Visible = false;
            //lblAguarde.Text = "AGUARDE  ";
            panel1.Enabled = false;
            Application.DoEvents();

            List<Credito> regCreditoList;

            DateTime fD = Convert.ToDateTime(txtDesde.Value.ToShortDateString());
            DateTime fH = Convert.ToDateTime(txtHasta.Value.ToShortDateString());
            //Int32 nCobrEncon = 0;
            fH = fH.AddDays(1).AddTicks(-1);
            fontList = new Font("Verdana", 8F, FontStyle.Regular);
            fontColor = Color.Empty;
            backColorList = Color.LightSteelBlue;
            ListViewItem item;
            regCreditoList = bl.GetCreditos(c => c.FechaSolicitud >= fD && c.FechaSolicitud <= fH && c.EmpresaID == bl.pGlob.Comercio.EmpresaID && c.ComercioID == bl.pGlob.Comercio.ComercioID, or => or.OrderBy(o => o.FechaSolicitud)).ToList();
            if(regCreditoList.Count == 0)
            {
                panel1.Enabled = true;
                lblMsg.Text = "No se encontraron créditos";
                listBusca.Visible = true;
                return;
            }
            DateTime fFechaCuentaC = DateTime.Now.AddYears(-1) ;
            CuentaCorrienteCorte regCtaCte = bl.Get<CuentaCorrienteCorte>(bl.pGlob.EmpresaID, c => c.EmpresaID == bl.pGlob.EmpresaID && c.ComercioID == bl.pGlob.Comercio.ComercioID
                , o => o.OrderBy(c => c.Fecha), "", 1).FirstOrDefault();
            if(regCtaCte != null)
            {
                fFechaCuentaC = regCtaCte.Fecha;
            }



            int nMov = 0;
            CuentaCorriente cc = new CuentaCorriente();

            DateTime fFechaSoli;
            DateTime fFechaAviso;

            DateTime fFechacc;
            DateTime fFechaNVA;

            DateTime dFechaCorte;
            foreach(Credito Cred in regCreditoList)
            {
                fFechaSoli = Cred.FechaSolicitud;
                if( fFechaSoli <= fFechaCuentaC)
                {
                    fFechaSoli = FechaLote(fFechaSoli, nDiaCorte);
                }
                   
                fFechaAviso = Cred.FechaAviso;
                item = new ListViewItem(Cred.CreditoID.ToString());//0
                item.UseItemStyleForSubItems = false;
                
                item.SubItems.Add(Cred.FechaSolicitud.ToShortDateString(), fontColor, backColorList, fontList);//1
                item.SubItems.Add(Cred.FechaAviso.ToShortDateString(), fontColor, backColorList, fontList);//2

                dFechaCorte = fFechaSoli.AddDays(Convert.ToDouble(Cred.Corte));
                item.SubItems.Add(dFechaCorte.ToShortDateString(), fontColor, backColorList, fontList);//3
                
                //4
                
                if(Cred.FechaAviso.ToShortDateString() != dFechaCorte.ToShortDateString())
                {
                    item.SubItems.Add("MAL");//4
                }
                else item.SubItems.Add("OK");//4

                //5
                nMov = bl.pGlob.TmCredOtorEfec.TipoMovimientoID;
                cc = bl.Get<CuentaCorriente>(c => c.CreditoID == Cred.CreditoID && c.TipoMovimientoID == nMov).FirstOrDefault();
                if(cc == null)
                {
                    item.SubItems.Add("NO");
                }else
                {
                    fFechacc = (DateTime)cc.FechaAviso;
                    if(fFechacc.ToShortDateString() != dFechaCorte.ToShortDateString())
                    {
                        item.SubItems.Add("FECHA");
                    }else item.SubItems.Add("OK");
                }

                //6
                if(Cred.TipoCuotaID == "A")
                {
                    nMov = bl.pGlob.TmCuotaAdelantada.TipoMovimientoID;
                    cc = bl.Get<CuentaCorriente>(c => c.CreditoID == Cred.CreditoID && c.TipoMovimientoID == nMov).FirstOrDefault();
                    if(cc == null)
                    {
                        item.SubItems.Add("NO");
                    }
                    else
                    {
                        fFechacc = (DateTime)cc.FechaAviso;
                        if(Cred.TipoRetencionPlanID == "C" || Cred.TipoRetencionPlanID == "A")
                        {
                            fFechaNVA = dFechaCorte;
                        }
                        else fFechaNVA = fFechaSoli;

                        if(fFechacc.ToShortDateString() != fFechaNVA.ToShortDateString())
                        {
                            item.SubItems.Add("FECHA");
                        }
                        else item.SubItems.Add("OK");
                    }
                } else item.SubItems.Add("");


                //7
                if(Cred.Gasto > 0)
                {
                    nMov = bl.pGlob.TmGasDescCredOtor.TipoMovimientoID;
                    cc = bl.Get<CuentaCorriente>(c => c.CreditoID == Cred.CreditoID && c.TipoMovimientoID == nMov).FirstOrDefault();
                    if(cc == null)
                    {
                        item.SubItems.Add("NO");
                    }
                    else
                    {
                        fFechacc = (DateTime)cc.FechaAviso;
                        if(Cred.TipoRetencionPlanID == "G" || Cred.TipoRetencionPlanID == "A")
                        {
                            fFechaNVA = dFechaCorte;
                        }
                        else fFechaNVA = fFechaSoli;

                        if(fFechacc.ToShortDateString() != fFechaNVA.ToShortDateString())
                        {
                            item.SubItems.Add("FECHA");
                        }
                        else item.SubItems.Add("OK");
                    }
                } else item.SubItems.Add("");

                //8
                item.SubItems.Add("c");
                
                item.SubItems.Add("");//9
                item.SubItems.Add("");//10
                item.SubItems.Add("");//11
                item.SubItems.Add("");//12
                item.SubItems.Add("");//13
                item.SubItems.Add("");//14
                listBusca.Items.Add(item);
                if(backColorList == Color.White) backColorList = Color.LightSteelBlue; else backColorList = Color.White;

            }

            BtnBusca.Text = "Otro";
            listBusca.Visible = true;
            panel1.Enabled = true;
        }
        private void Configura_Inicio()
        {
            listBusca.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(lista_Dibuja_Encabezado);
            listBusca.DrawSubItem += lista_DrawSubItem;
            this.BackColor = ColorBackColorFrm;
            Recorre_Formulario(this);
            cmbBusca.Items.Add("Imputaciones cuenta corriente");
            cmbBusca.SelectedIndex = 0;
            cmbQueBusca.Items.Add("Altas");
            cmbQueBusca.Items.Add("Cobranzas");
            cmbQueBusca.SelectedIndex = 0;
            cargadias();
        }
        private void cargadias()
        {
            foreach(var weekDay in Enum.GetValues(typeof(DayOfWeek)))
                cmbSEMANA.Items.Add($"{weekDay}");
            cmbSEMANA.SelectedIndex = 0;
        }
        private void Prepara_Arreglo()
        {
            if(listBusca.Items.Count == 0) return;
            if(cmbBusca.SelectedIndex == 0)
            {
                if(cmbQueBusca.SelectedIndex == 0)
                {
                    Arregla_Altas();
                }
            }
        }
        private void Comienza()
        {
            Configura_Listas();
            if(cmbBusca.SelectedIndex == 0)
            {
                if(cmbQueBusca.SelectedIndex == 0)
                {
                    Busca_Altas();
                }
            }
        }
        private void Configura_Listas()
        {
            if(cmbBusca.SelectedIndex == 0 && cmbQueBusca.SelectedIndex == 0)
            {
                listBusca.Visible = false;
                listBusca.Columns.Clear();
                listBusca.View = View.Details;
                listBusca.Columns.Add("CREDITO", 80, HorizontalAlignment.Right);  //0 para el orden
                listBusca.Columns.Add("SOLICITUD",80, HorizontalAlignment.Right);  //1 empre
                listBusca.Columns.Add("FECHA AVISO CRED", 80, HorizontalAlignment.Right);  //2
                listBusca.Columns.Add("FECHA AVISO CORTE", 80, HorizontalAlignment.Right);  //3

                listBusca.Columns.Add("FECH EN CRED", 80, HorizontalAlignment.Right);  //4
                
                
                listBusca.Columns.Add("CC CRED", 80, HorizontalAlignment.Right);  //5
                listBusca.Columns.Add("CC ADEL", 80, HorizontalAlignment.Right);  //6
                listBusca.Columns.Add("CC GST", 80, HorizontalAlignment.Right);  //7
                listBusca.Columns.Add("CC COMI",80, HorizontalAlignment.Right);  //8

                listBusca.Columns.Add("Estado", 80, HorizontalAlignment.Right);  //9
                
                listBusca.Columns.Add("FECH EN CRED", 80, HorizontalAlignment.Right);  //10
                listBusca.Columns.Add("arreglo CC CRED", 80, HorizontalAlignment.Right);  //11
                listBusca.Columns.Add("arreglo CC ADEL", 80, HorizontalAlignment.Right);  //12
                listBusca.Columns.Add("arreglo CC GST", 80, HorizontalAlignment.Right);  //13
                listBusca.Columns.Add("arreglo CC COMI", 80, HorizontalAlignment.Right);  //14
            }

            listBusca.OwnerDraw = true;
            listBusca.GridLines = false;
            listBusca.FullRowSelect = true;
            listBusca.Visible = true; 
        }

        private void BtnBusca_Click(object sender, EventArgs e)
        {
            if(BtnBusca.Text == "Buscar")
            {
                Comienza();
            }
            else
            {
                BtnBusca.Text = "Buscar";
                listBusca.Columns.Clear();
            }
        }

        private void btnArreglo_Click(object sender, EventArgs e)
        {
            if(BtnBusca.Text == "Buscar") return;
            Prepara_Arreglo();
        }
    }
}
