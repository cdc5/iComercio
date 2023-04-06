using System;                         ////convert, eventarg, eventhandler
using System.Collections.Generic;         //list<>
using System.Drawing;                  ///font , color
using System.Linq;                      // orderby()
using System.Windows.Forms;               //formWindowsState, listview, musearg, etc
using iComercio.Rest;                       //RestApi
using iComercio.Models;                     // modelos(cred, cuot, etc)

using iComercio.DAL;                      //<MorosoEnCamara>

namespace iComercio.Forms
{
    public partial class FrmRefinanciacion : FRM                                                         //**edu**
    {

        bool bEsPru = false;
        int NumComercioPru = 0;


        public BusinessLayer bl2;
        Credito regCredito;
        Refinanciacion regRefinanciacion;

        int refiEmpre = 0;
        int refiComer = 0;
        int refiCred = 0;
        int nDocu = 0;
        string cDocu = "";
        int nComer = 0;
        //decimal refiDeuda;

        public FrmRefinanciacion()
        {
            InitializeComponent();
        }

        private void FrmRefinanciacion_Load(object sender, EventArgs e)
        {
            
        }
        public FrmRefinanciacion(Principal p,  int Docu, string Nomb, string CodDocu,  int Empre, int Comer, int cred, bool bPru)
            : base(p)
        {
            InitializeComponent();
            this.bl = bl;
            lblMor.Visible = bPru;
            RecargarEmpYComercio(bPru);
            Configura_Inicio();

           
            refiEmpre = Empre;
            refiComer = Comer;
            refiCred = cred;
            lblDocu.Text = Docu.ToString("N0");
            lblCodDocu.Text = CodDocu;
            nDocu = Docu;
            cDocu = CodDocu;
            nComer = Comer;
            lblNomb.Text = Nomb;
            lblCred.Text = refiCred.ToString("N0");

            bEsPru = bPru;
            if(bEsPru)
            {
                lblCom.Text = ComID.ToString();
            }
            else
            {
                lblCom.Text = Comer.ToString("N0");
            }

            Busca_Credito();
            this.Text = "Refinanciación del créditos: " + lblCred.Text;
            txtARefin.Focus();
        }

        private bool Paga_Adelanto(decimal nAdelanto,ref List<Transmision> ltrans)
        {
            List<Cuota> regCuotaList;
            int BaseID = bl.GetEmpresa(bEsPru).EmpresaID.Value;
            Comercio com = bl.GetComercio(BaseID);
            regCuotaList = bl.Get<Cuota>(BaseID,c => c.EmpresaID == refiEmpre && c.ComercioID == refiComer 
                                                        && c.CreditoID == refiCred).ToList();
            
            if (regCuotaList.Count == 0)
            {
                //       mensaje de error
                return false;
            }
            //int bb = 0;
            int nCuota = 0;
            decimal nDeuda = 0;
            decimal nPuni = 0;
            decimal aTmp1 = 0;
            decimal aTmp2 = 0;
            decimal aTmp3=0;
            decimal nPagoACuota = 0;
            decimal nPagoAPuni = 0;
            foreach (Cuota cu in regCuotaList)
            {
                if (cu.Deuda > 0)
                {
                    nCuota = cu.CuotaID;
                    nDeuda = cu.Deuda;
                    nPuni = 0;
                    nPuni = Calcula_Punitorio(cu.Deuda, cu.FechaVencimiento, bl.pGlob.Comercio.Por30.Value, bl.pGlob.Comercio.Por30M.Value,true);
                    break;
                }
            }
            if (nCuota==0)
            {
                //       mensaje de error
                return false;
            }
            if (nAdelanto < nDeuda + nPuni)
            {
                aTmp1 = nDeuda * nAdelanto;
                aTmp2 = nDeuda + nPuni;
                if (nAdelanto < 15) aTmp3 = aTmp1 / aTmp2; else aTmp3 = Redondeo(aTmp1 / aTmp2);
                //aTmp3 = aTmp1 / aTmp2;
                nPagoACuota = aTmp3;
                nPagoAPuni = nAdelanto - aTmp3;
            } else
            {
                nPagoACuota = (decimal.Round( nDeuda) / 2);
                nPagoAPuni = nAdelanto - nPagoACuota;
            }
            Cuota regCuotaPaga;

            regCuotaPaga = bl.Get<Cuota>(BaseID,c => c.EmpresaID == refiEmpre && c.ComercioID == refiComer && c.CreditoID == refiCred && c.CuotaID == nCuota).FirstOrDefault();
           
            if (regCuotaPaga == null)
            {
                //       mensaje de error
                return false;
            }
            int nCobraID = 1;

            bl2 = new BusinessLayer();
            Cobranza cobrPagar;

            cobrPagar = bl2.GetDal(BaseID).context.Cobranzas.Where(c => c.EmpresaID == refiEmpre &&
                            c.ComercioID == refiComer && c.CreditoID == refiCred && c.CuotaID == nCuota &&
                            c.GestionID == refiComer).OrderByDescending(o => o.CobranzaID).FirstOrDefault();
            
           if (cobrPagar != null) nCobraID = cobrPagar.CobranzaID + 1;

            
            regCuotaPaga.ImportePago = regCuotaPaga.ImportePago + nPagoACuota;
            regCuotaPaga.ImportePagoPunitorios = regCuotaPaga.ImportePagoPunitorios + nPagoAPuni;
            regCuotaPaga.FechaUltimoPago = DateTime.Now;
            regCuotaPaga.TipoCuotaID = "A";

            cobrPagar = new Cobranza();
            cobrPagar.EmpresaID =refiEmpre;
            cobrPagar.ComercioID = refiComer;
            cobrPagar.CreditoID = refiCred;
            cobrPagar.CuotaID = nCuota;
            cobrPagar.CobranzaID = nCobraID;
            cobrPagar.Documento =nDocu;
            cobrPagar.TipoDocumentoID = cDocu;
            cobrPagar.ImportePago = nPagoACuota;
            cobrPagar.ImportePagoPunitorios = nPagoAPuni;
            decimal nInteres = (regCuotaPaga.Interes * nPagoACuota) / regCuotaPaga.Importe;
            cobrPagar.Interes = nInteres;
            cobrPagar.PunitoriosCalc = nPagoAPuni;
            cobrPagar.FechaPago = DateTime.Now;
            cobrPagar.FechaVencimiento = regCuotaPaga.FechaVencimiento;
            cobrPagar.TipoPagoID = "D";
            cobrPagar.TipoBonificacionID = "N";
            cobrPagar.PorcentajeBonificacion = 0;
            cobrPagar.PagoRev = false;
            cobrPagar.FechaRev = DateTime.Now;                          ///  PONER NULL
            cobrPagar.GestionEmpresaID = BaseID;                                                            ///
            cobrPagar.GestionID = ComID;
            cobrPagar.RefinanciacionCobranzaID = 0;
            if (p.usuIDAutorizado != 0)
                cobrPagar.UsuarioID = p.usuIDAutorizado;
            else
                cobrPagar.UsuarioID = p.usu.UsuarioID;
            //if (p.usuIDAutorizado == 0) cobrPagar.UsuarioID = p.usu.UsuarioID; else cobrPagar.UsuarioID = p.bPuedeHacerlo;    
            cobrPagar.PcComer = System.Environment.MachineName;
            cobrPagar.Motivo = "Adelanto refinanciación";

            bl.AgregarTransaccional<Cobranza>(cobrPagar.EmpresaID, cobrPagar);
            bl.Grabar(cobrPagar.EmpresaID);
 
            CuentaCorriente cc;
             if(bFormaPago)
             {
                 Abre_FormadePago(nAdelanto, refiEmpre, refiComer, refiCred, nCuota, nCobraID);

             }

             
             bl.ActualizarTransaccional<Cuota>(regCuotaPaga.EmpresaID,regCuotaPaga);
             cc = bl.ImputarCobranzaACuentaCorriente(cobrPagar);
             bl.Grabar(cobrPagar.EmpresaID);
             ltrans = bl.Transmision<Cobranza>(ltrans, cobrPagar, bl.pGlob.Comercio, bl.pGlob.TransAltaCobranza, bl.pGlob.UriRefinanciacion);
             ltrans = bl.Transmision<Cuota>(ltrans, regCuotaPaga, bl.pGlob.Comercio, bl.pGlob.TransActualizarCuota, bl.pGlob.UriRefinanciacion);
             ltrans = bl.Transmision<CuentaCorriente>(ltrans, cc, bl.pGlob.Comercio, bl.pGlob.TransImputacionCC, bl.pGlob.UriAltaCobranza);
             bl.ImprimirCobranza(cobrPagar, bEsPru);
             return true;
        }
        private void Abre_FormadePago(decimal ValorAPagar, int nEmpre, int nComer, int nCred, int nCuot, int nCobr)
        {
            FrmFormaPago frmfp = new FrmFormaPago(p, this.bl, nEmpre, nComer, nCred, nCuot, nCobr, nDocu, cDocu, ValorAPagar, bEsPru);
            frmfp.ShowDialog();
            frmfp.Close();
        }
        private void Busca_Credito()
        {
            bl = new BusinessLayer();
            regCredito = bl.Get<Credito>(BaseID,c => c.EmpresaID == refiEmpre && c.ComercioID == refiComer && c.CreditoID == refiCred).FirstOrDefault();
            if(regCredito==null)
            {
                // mensanaje error
                return;
            }

            decimal nTmp = 0;
            decimal nDeuda = 0;
            int ncuotas = 0;
            decimal nPunitorios = 0;

            foreach (Cuota cuo in regCredito.Cuotas)
            {
                if(cuo.Importe - cuo.ImportePago>0)
                {
                    ncuotas++;
                    nDeuda = nDeuda + (cuo.Importe - cuo.ImportePago);
                    nPunitorios = nPunitorios + Calcula_Punitorio(cuo.Importe - cuo.ImportePago, cuo.FechaVencimiento, bl.pGlob.Comercio.Por30.Value, bl.pGlob.Comercio.Por30M.Value, true);
                }
            }
            lblCuotas.Text = ncuotas.ToString();
            lblDeuda.Text = nDeuda.ToString("N2");
            lblPunitorios.Text = nPunitorios.ToString("N2");
            nTmp = nDeuda + nPunitorios;
            lblTotal.Text = nTmp.ToString("N2");
            txtARefin.Text = nTmp.ToString("N2");
            // ACA LEER LA TABLA DE REFINANCIACIONES DE CENTRAL

        }
        private void Graba_Refinanciacion()
        {
            int RefiID = 0;

            decimal nValc = Convert.ToDecimal(lblValCuota.Text);
            
            DialogResult dr = MessageBox.Show("Refinanciar el crédito " + lblCred.Text + Environment.NewLine
                            + Environment.NewLine + "por " + txtCuota.Text + " cuotas "
                            + "de " + nValc.ToString("N2")
                            + Environment.NewLine + "1° vencimiento el " + txtFechPri.Value.ToShortDateString()  , "Refinanciación", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.No)
            {
                return;
            }

           
            //int BaseID = bl.GetEmpresa(bEsPru).EmpresaID.Value;
            regRefinanciacion = bl.Get<Refinanciacion>(BaseID, c => c.EmpresaID == refiEmpre && c.ComercioID == refiComer).
                                OrderByDescending(o => o.RefinanciacionID).FirstOrDefault();
          
            if (regRefinanciacion == null)
            {
                RefiID++;
            }
            else
            {
                RefiID = regRefinanciacion.RefinanciacionID + 1;
            }
            

            regCredito.RefinanciacionID = RefiID;
            bl.ActualizarTransaccional<Credito>(regCredito.EmpresaID, regCredito);
            
            
            regRefinanciacion = new Refinanciacion();
            regRefinanciacion.EmpresaID = refiEmpre;// bl.pGlob.Comercio.EmpresaID;
            regRefinanciacion.ComercioID = refiComer;// nComer;// bl.pGlob.Comercio.ComercioID;
            regRefinanciacion.CreditoID = refiCred;
            regRefinanciacion.RefinanciacionID = RefiID;
            regRefinanciacion.FechaSolicitud = DateTime.Now;
            regRefinanciacion.ValorNominal = Convert.ToDecimal(lblRestan.Text);
            regRefinanciacion.ValorCuota = Convert.ToDecimal(lblValCuota.Text);
            regRefinanciacion.ValorAdelanto=Convert.ToDecimal(txtAdelanto.Text);
            regRefinanciacion.CantidadCuotas=Convert.ToInt16(txtCuota.Text);
            regRefinanciacion.Interes=Convert.ToDecimal(txtInteres.Text);
            regRefinanciacion.UsuarioID = p.usu.UsuarioID;
            regRefinanciacion.PcComer = System.Environment.MachineName;
            regRefinanciacion.FechaCreacion = DateTime.Now;
            regRefinanciacion.Documento = nDocu;
            regRefinanciacion.TipoDocumentoID = cDocu;
            regRefinanciacion.EstadoID =(int) bl.pGlob.Vigente.EstadoID;

            List<Transmision> ltrans = new List<Transmision>();

            bl.AgregarTransaccional<Refinanciacion>(regRefinanciacion.EmpresaID,regRefinanciacion);

            Comercio com = bl.GetComercio(BaseID);

            ltrans = bl.Transmision<Refinanciacion>(ltrans, regRefinanciacion, com, bl.pGlob.TransAltaRefinanciacion, bl.pGlob.UriRefinanciacion);
            ltrans = bl.Transmision<Credito>(ltrans, regCredito, com, bl.pGlob.TransActualizarCredito, bl.pGlob.UriRefinanciacion);

                        
            RefinanciacionCuota refiCuota; // = new RefinanciacionCuota();
            foreach(ListViewItem iT in listCuotas.Items)
            {
                refiCuota = new RefinanciacionCuota();
                refiCuota.EmpresaID = refiEmpre;// bl.pGlob.Comercio.EmpresaID;
                refiCuota.ComercioID = refiComer;// bl.pGlob.Comercio.ComercioID;
                refiCuota.CreditoID = refiCred;
                refiCuota.RefinanciacionCuotaID = Convert.ToInt16(iT.SubItems[0].Text);
                //refiCuota.RefinanciacionCuotaIDRemoto = 0;
                refiCuota.RefinanciacionID = RefiID;
                refiCuota.Importe = Convert.ToDecimal(iT.SubItems[2].Text);
                refiCuota.ImportePago = 0;
                refiCuota.ImportePagoPunitorios = 0;
                refiCuota.FechaVencimiento = Convert.ToDateTime(iT.SubItems[3].Text);
                refiCuota.CantidadCuotas = Convert.ToInt16(txtCuota.Text);
                refiCuota.Documento = nDocu;
                refiCuota.TipoDocumentoID = cDocu;

                bl.AgregarTransaccional<RefinanciacionCuota>(refiCuota.EmpresaID,refiCuota);
                ltrans = bl.Transmision<RefinanciacionCuota>(ltrans, refiCuota, com, bl.pGlob.TransAltaRefinanciacionCuota, bl.pGlob.UriRefinanciacion);
                bl.Grabar(refiCuota.EmpresaID);

            }
            
            if (Convert.ToDecimal(txtAdelanto.Text) > 0)
            {
                Paga_Adelanto(Convert.ToDecimal(txtAdelanto.Text), ref ltrans);
            }
            
            bl.GrabarTransmisiones(BaseID,ltrans);
            
            this.Close();
        }

        private bool Valida_Refinanciacion()
        {
            if (txtARefin.Text == "") return false;
            if (txtAdelanto.Text == "") return false;
            if (txtInteres.Text == "") return false;
            if (txtCuota.Text == "") return false;
            if (lblValCuota.Text == "") return false;

            if (txtCuota.Text == "0")
            {
                MessageBox.Show("El dato no puede quedar vacio", "Refinanciación");
                txtCuota.Focus();
                return false;
            }
            // etc...
            
            return true;
        }
        private void Calcula_Resto(object sender, EventArgs e)
        {
            listCuotas.Items.Clear();
            lblRestan.ForeColor = Color.Black;
            btnGrabar.Enabled = false;

            if (txtARefin.Text == "") return; // txtARefin.Text = "0";
            if (txtAdelanto.Text == "") return; //txtAdelanto.Text = "0";
            if (txtInteres.Text == "") return; //txtInteres.Text = "0";
            if (txtCuota.Text == "") return; //txtCuota.Text = "0";
            
            if (txtARefin.Text == "0") return;
            if (txtAdelanto.Text == "0") return;
            
            decimal nTmp = Convert.ToDecimal(txtARefin.Text) - Convert.ToDecimal(txtAdelanto.Text);
            if (nTmp<=0)
            {
                lblRestan.Text = "ERROR";
                lblRestan.ForeColor = Color.Red;
                return;
            }
            if(nTmp > Convert.ToDecimal(txtARefin.Text))
            {
                btnGrabar.Enabled = false;
                lblRestan.Text = "ERROR";
                lblRestan.ForeColor = Color.Red;
                return;
            }
            lblRestan.Text = nTmp.ToString("N2");

            lblValCuota.Text = "0";
            if (txtCuota.Text == "0")    return;

            nTmp = (Convert.ToDecimal(lblRestan.Text) * Convert.ToDecimal(txtInteres.Text)) / 100;      // interes
            decimal nTmp2 = Convert.ToDecimal(lblRestan.Text) + nTmp;                                 //v tota
            decimal vCu=Redondeo(nTmp2 / Convert.ToInt16(txtCuota.Text)); 
            lblValCuota.Text=vCu.ToString("N2");

            if (vCu > 0) Llena_Cuotas();

        }

        private void Llena_Cuotas()
        {
            Font fontList = new Font("Verdana", 8F, FontStyle.Regular);
            Color fontColor = Color.Empty;
            Color backColorList = Color.LightSteelBlue;
            DateTime fv = txtFechPri.Value;
            if(txtFechPri.Value> DateTime.Now.AddDays(45))
            {
                MessageBox.Show("El primer vencimiento es mayor a 45 días", "Refinanciación");
                txtFechPri.Focus();
                return;
            }
            for (int cl = 1; cl <= Convert.ToInt16(txtCuota.Text);cl++ )
            {
                ListViewItem item = new ListViewItem(cl.ToString());
                item.UseItemStyleForSubItems = false;
                item.SubItems.Add(cl.ToString(), fontColor, backColorList, fontList);
                item.SubItems.Add(lblValCuota.Text, fontColor, backColorList, fontList);
                item.SubItems.Add(fv.ToShortDateString(), fontColor, backColorList, fontList);
                listCuotas.Items.Add(item);
                    
                if (backColorList == Color.White) backColorList = Color.LightSteelBlue; else backColorList = Color.White;
                fv = fv.AddMonths(1); 
            }
            btnGrabar.Enabled = true;
        }
        //private decimal Calcula_Punitorio(decimal nImporte, DateTime fVenci, decimal nPorce1, decimal nPorce2)
        //{
        //    if (DateTime.Now <= fVenci) return 0;
        //    decimal nTmp1 = 0;
        //    decimal punito1 = 0;
        //    decimal punito2 = 0;
        //    TimeSpan ndias = DateTime.Now - fVenci;
        //    if (ndias.Days < 31)
        //    {
        //        punito1 = (nPorce1 * ndias.Days * nImporte);
        //    }
        //    else
        //    {
        //        punito1 = (nPorce1 * 30 * nImporte);
        //        punito2 = nPorce2 * (ndias.Days - 30) * nImporte;
        //    }
        //    nTmp1 = Convert.ToDecimal(Redondeo(punito1 + punito2));
        //    return nTmp1;
        //}
        private void Configura_Inicio()
        {
            Configura_Controles();
            Configura_listas();
            Limpia();
        }
        private void Configura_Controles()
        {
            foreach (Control childc in this.Controls)
            {
                if (childc is TextBox)
                {
                    childc.Leave += new EventHandler(Evento_LeaveColor);
                    childc.Enter += new EventHandler(Evento_EnterColor);
                    if ((string)childc.Tag == "N")                 //numeros
                    {
                        childc.KeyPress += KeyPress_Solonumeros;
                        childc.Leave += new EventHandler(DejaTxtNum);
                    }
                    if ((string)childc.Tag == "D")              //decimal
                    {
                        childc.KeyPress += KeyPress_Solonumeros;
                        childc.Leave += new EventHandler(DejaTxtDeci);
                    }
                }
            }

            listCuotas.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(lista_Dibuja_Encabezado);
            listCuotas.DrawSubItem += lista_DrawSubItem;
            txtARefin.KeyUp += Calcula_Resto;
            txtAdelanto.KeyUp += Calcula_Resto;
            txtCuota.KeyUp += Calcula_Resto;
            txtInteres.KeyUp += Calcula_Resto;
            txtFechPri.ValueChanged += Calcula_Resto;
        }

        public void Configura_listas()
        {
            listCuotas.View = View.Details;
            listCuotas.Columns.Add("", 0, HorizontalAlignment.Right);
            listCuotas.Columns.Add("Cuota", 40, HorizontalAlignment.Right);
            listCuotas.Columns.Add("Importe", 90, HorizontalAlignment.Right);
            listCuotas.Columns.Add("Vencimiento", 80, HorizontalAlignment.Right);

            listCuotas.OwnerDraw = true;
            listCuotas.GridLines = false;
            listCuotas.FullRowSelect = true;
        }
        private void Limpia()
        {
            txtARefin.Text="0";
            txtAdelanto.Text = "0";
            lblRestan.Text = "0";
            txtInteres.Text = "0";
            decimal nTmp = (decimal)bl.GetComercio(BaseID).IntRef;
            txtInteres.Text = nTmp.ToString("N2");
            txtCuota.Text = "0";
            lblValCuota.Text = "0";
            lblQuienRefi.Text = "";
            txtFechPri.Value = DateTime.Now.AddMonths(1); 
            listCuotas.Items.Clear();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (Valida_Refinanciacion()) 
                Graba_Refinanciacion();
        }

        private void txtARefin_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
