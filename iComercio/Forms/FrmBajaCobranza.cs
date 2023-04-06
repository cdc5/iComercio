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
    public partial class FrmBajaCobranza : FRM                                                         //**edu**
    {
        Color backColorList = Color.White;
        Color fontColor = Color.Empty;
        Font fontList = new Font("Verdana", 10F, FontStyle.Regular);

        Cuota regCuota = null;
        List<Cobranza> regCobranzaList = null;
        Cobranza regCobMod = null;
        RefinanciacionCobranza regRefinanciacionCobranza = null;
        RefinanciacionCuota regRefinanciacionCuota = null;
        List<RefinanciacionCuota> regRefinanciacionCuotaList = null;
        Refinanciacion regRefinanciacion = null;
        NotasCD regNotaCD = null;

        int nEmpre=0;
        int nComer = 0;
        int nCred =0;
        int nCuota=0;
        int nDocumento = 0;
        string cDocumento = "";

        bool bMuestra = false;
            

        public FrmBajaCobranza()
        {
            InitializeComponent();
        }

        private void FrmBajaCobranza_Load(object sender, EventArgs e)
        {
            lblMor.Visible = false;
            RecargarEmpYComercio(lblMor.Visible);
        }
        public FrmBajaCobranza(Principal p)
            : base(p)
        {
            bl = new BusinessLayer();
            InitializeComponent();
            Configura_Inicio();
        }

        private void Anula_Cobranza_Refinanciada(int EmpresaID)
        {
            
            List<Transmision> ltrans = new List<Transmision>();
            int nError = 0;
            int nRefCobID = Convert.ToInt32(lblCobrRefi.Text);
            string cReg = "";
            if (listRefinanCobr.Items.Count == 1) cReg = "una cobranza"; else cReg = listRefinanCobr.Items.Count + " cobranzas";

            DialogResult res = MessageBox.Show("La cobranza es un refinanciación" + Environment.NewLine
                        + " El  pago corresponde a " + cReg + Environment.NewLine 
                        + Environment.NewLine + "¿Continuar?", this.Text
                        , MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (res == DialogResult.Cancel) return;

            Buscame_de_todo(EmpresaID, "RefinanciacionCobranza", 0, 0, nRefCobID, 0);
            if (regRefinanciacionCobranza  == null) return;                                         //ACA msg error
            Buscame_de_todo(EmpresaID, "RefinanciacionCuota", regRefinanciacionCobranza.RefinanciacionID
                            , regRefinanciacionCobranza.RefinanciacionCuotaID
                            , regRefinanciacionCobranza.RefinanciacionCobranzaID,0);
            if (regRefinanciacionCuota == null) return;                                          //ACA msg error
            Buscame_de_todo(EmpresaID, "Refinanciacion", regRefinanciacionCobranza.RefinanciacionID
                            , regRefinanciacionCobranza.RefinanciacionCuotaID
                            , regRefinanciacionCobranza.RefinanciacionCobranzaID,0);
            if (regRefinanciacion == null) return;                                               //ACA msg error
            Buscame_de_todo(EmpresaID, "Cobranza_L", 0, 0, regRefinanciacionCobranza.RefinanciacionCobranzaID, 0);
            if (regCobranzaList.Count == 0) return ;                                                //ACA msg error

            //                                                                                                   //ACA BEGIN
           
            int BaseID = regRefinanciacionCobranza.EmpresaID;
            ltrans = bl.Transmision(ltrans, bl.GetComercio(BaseID), bl.pGlob.TransBajaRefinanciacionCobranza, bl.pGlob.UriRefinanciacionCobranza);
            int nNroRef = Baja_CuotaRef_CobranzaRef(ref ltrans);
            
            foreach (Cobranza cob in regCobranzaList)
            {
                nError = Baja_Cuota_Cobranza(cob.EmpresaID,cob.CobranzaID, nNroRef, cob.CuotaID, ref ltrans);
                if (nError == 0) break;
            }

            if (nError == 0)
            {
                                                                                                                //ACA ROLL
                return;
            }
            Credito RegCredito = bl.GetCreditos(c => c.EmpresaID == nEmpre && c.ComercioID == nComer
                                                && c.CreditoID == nCred).FirstOrDefault();
            if(RegCredito==null)
            {
                                                                                                                //ACA ROLL
                return;
            }
            RegCredito.Cancelado = false;
            bl.ActualizarTransaccional<Credito>(RegCredito.EmpresaID,RegCredito);

            //                                                                                       //ACA UN END BEGIN

            bl.Grabar(RegCredito.EmpresaID);
            bl.GrabarTransmisiones(RegCredito.EmpresaID,ltrans);

            MessageBox.Show("Cobranza anulada", this.Text);
            Limpia();
            Busca_Cobranzas();

        }

        private int Baja_CuotaRef_CobranzaRef(ref List<Transmision> ltrans)
        {
            int nCobraIDNvo = 1;
            if (regRefinanciacionCuota.Importe < (regRefinanciacionCuota.ImportePago-regRefinanciacionCobranza.ImportePago))
            {
                MessageBox.Show("ERROR - No se puede anular la refinanciación" + Environment.NewLine + "(error : BCCR-00001)", this.Text);
                return 0;
            }
            nCobraIDNvo = Busca_Ultimo_ID_Cobranza(nEmpre,nComer,ComID,true, regRefinanciacionCobranza.RefinanciacionID);
            
            regRefinanciacionCuota.ImportePago = regRefinanciacionCuota.ImportePago - regRefinanciacionCobranza.ImportePago;
            regRefinanciacionCuota.ImportePagoPunitorios = regRefinanciacionCuota.ImportePagoPunitorios - regRefinanciacionCobranza.ImportePagoPunitorios;
            
            RefinanciacionCobranza regCobRefNvo = new RefinanciacionCobranza();
            regCobRefNvo.EmpresaID=regRefinanciacionCobranza.EmpresaID;
            regCobRefNvo.ComercioID=regRefinanciacionCobranza.ComercioID;
            regCobRefNvo.CreditoID=regRefinanciacionCobranza.CreditoID;
            regCobRefNvo.RefinanciacionID = regRefinanciacionCobranza.RefinanciacionID;
            regCobRefNvo.RefinanciacionCuotaID = regRefinanciacionCobranza.RefinanciacionCuotaID;
            regCobRefNvo.RefinanciacionCobranzaID = nCobraIDNvo;
            regCobRefNvo.Documento = regRefinanciacionCobranza.Documento;
            regCobRefNvo.TipoDocumentoID = regRefinanciacionCobranza.TipoDocumentoID;
            regCobRefNvo.ImportePago = regRefinanciacionCobranza.ImportePago * -1;
            regCobRefNvo.ImportePagoPunitorios = regRefinanciacionCobranza.ImportePagoPunitorios * -1;
            regCobRefNvo.FechaPago = regRefinanciacionCobranza.FechaPago;
            regCobRefNvo.FechaVencimiento = regRefinanciacionCobranza.FechaVencimiento;
            regCobRefNvo.TipoPagoID = regRefinanciacionCobranza.TipoPagoID;
            regCobRefNvo.GestionID = bl.pGlob.Comercio.ComercioID;
            regCobRefNvo.PagoRev = true;
            regCobRefNvo.FechaPago = DateTime.Now;
            regCobRefNvo.RefinanciacionCobranzaIDRev = regRefinanciacionCobranza.RefinanciacionCobranzaID;

            regRefinanciacionCobranza.PagoRev = true;
            regRefinanciacionCobranza.FechaRev = DateTime.Now;

            bl.ActualizarTransaccional<RefinanciacionCuota>(regRefinanciacionCuota.EmpresaID,regRefinanciacionCuota);
            bl.AgregarTransaccional<RefinanciacionCobranza>(regCobRefNvo.EmpresaID,regCobRefNvo);
            bl.ActualizarTransaccional<RefinanciacionCobranza>(regCobRefNvo.EmpresaID,regRefinanciacionCobranza);

            Comercio com = bl.GetComercio(regCobRefNvo.EmpresaID);
            ltrans = bl.Transmision<RefinanciacionCobranza>(ltrans, regCobRefNvo, com, bl.pGlob.TransAltaRefinanciacionCobranza, bl.pGlob.UriRefinanciacionCobranza);
            ltrans = bl.Transmision<RefinanciacionCuota>(ltrans, regRefinanciacionCuota, com, bl.pGlob.TransActualizarRefinanciacionCuota, bl.pGlob.UriRefinanciacionCobranza);
            ltrans = bl.Transmision<RefinanciacionCobranza>(ltrans, regRefinanciacionCobranza, com, bl.pGlob.TransActualizarRefinanciacionCobranza, bl.pGlob.UriRefinanciacionCobranza);
                        
            return nCobraIDNvo;
        }

        private int Baja_Cuota_Cobranza(int EmpresaID,int nID, int nRefNvo,int nRefCuotaCobr,ref List<Transmision> ltrans)
        {
            
            int nCobraIDNvo = 1;
            Buscame_de_todo(EmpresaID,"Cobranza_S",0 ,nRefCuotaCobr,0,nID);
            Buscame_de_todo(EmpresaID,"Cuota",0,0,0,regCobMod.CuotaID);
            if (regCuota.Importe < (regCuota.ImportePago - regCobMod.ImportePago))
            {
                MessageBox.Show("ERROR - No se puede anular la cobranza" + Environment.NewLine + "(error : BCCB-00001)", this.Text);
                return 0 ;
            }
            
            nCobraIDNvo = AnulaCobranza(regCuota, regCobMod, nRefNvo,false, ref ltrans);
            return nCobraIDNvo;
        }

        private int Busca_Ultimo_ID_Cobranza(int EmpresaID,int ComercioID,int GestionID,bool Ref, int nRef)
        {
            int nn = 1;
            if (Ref)
            {
                List<RefinanciacionCobranza> RegTmp = bl.Get<RefinanciacionCobranza>(EmpresaID, c => c.EmpresaID == EmpresaID && c.ComercioID == ComercioID
                                                                                    && c.CreditoID == nCred && c.RefinanciacionID == nRef,
                                                                                    cc => cc.OrderBy(ccc => ccc.RefinanciacionCobranzaID)).ToList();
                foreach (RefinanciacionCobranza cob in RegTmp)
                {
                    if (cob.RefinanciacionCobranzaID >= nn) nn = cob.RefinanciacionCobranzaID + 1;
                }
            }
            else
            {

                Cobranza regCobNvo = bl.GetDal(EmpresaID).context.Cobranzas.Where(c => c.EmpresaID == EmpresaID && c.ComercioID == ComercioID &&
                                                                                  c.GestionID == GestionID).OrderByDescending(o => o.CobranzaID).FirstOrDefault();
                if (regCobNvo != null) nn = regCobNvo.CobranzaID + 1;
            }
            return nn;
        }

        private void Buscame_de_todo(int BaseID,string qBusco,int nRefiID, int nRefiCuotaID, int nRefiCobraID, int nIDBusq)
        {
            int nTmp1 = 0;
            switch ( qBusco)
            {
                case "RefinanciacionCobranza":
                    regRefinanciacionCobranza = bl.Get<RefinanciacionCobranza>(BaseID,r => r.EmpresaID == nEmpre 
                            && r.ComercioID == nComer
                            && r.CreditoID == nCred 
                            && r.RefinanciacionCobranzaID == nRefiCobraID).FirstOrDefault();
                    break;
                case "RefinanciacionCuota":
                    regRefinanciacionCuota = bl.Get<RefinanciacionCuota>(BaseID, r => r.EmpresaID == nEmpre && r.ComercioID == nComer
                            && r.CreditoID == nCred && r.RefinanciacionID == nRefiID
                            && r.RefinanciacionCuotaID == nRefiCuotaID).FirstOrDefault();
                    break;
                case "RefinanciacionCuota_L":
                    regRefinanciacionCuotaList = bl.Get<RefinanciacionCuota>(BaseID, r => r.EmpresaID == nEmpre && r.ComercioID == nComer
                            && r.CreditoID == nCred && r.RefinanciacionID == nRefiID).ToList();  //&& r.RefinanciacionCuotaID == nRefiCuotaID
                    break;

                case "Refinanciacion":
                    regRefinanciacion = bl.Get<Refinanciacion>(BaseID, r => r.EmpresaID == nEmpre && r.ComercioID == nComer
                            && r.CreditoID == nCred && r.RefinanciacionID == nRefiID).FirstOrDefault();
                    break;
                case "Cobranza_L": //Lista Ordenada por cuota descendiente
                    regCobranzaList = bl.Get<Cobranza>(BaseID, c => c.EmpresaID == nEmpre && c.ComercioID == nComer && c.CreditoID == nCred
                            &&  c.RefinanciacionCobranzaID == nRefiCobraID, cc => cc.OrderByDescending(ccc => ccc.CuotaID)).ToList();
                    break;
                case "Cobranza_F": //Lista Ordenada por cobranza ascendiente
                    regCobranzaList = bl.Get<Cobranza>(BaseID, c => c.EmpresaID == nEmpre && c.ComercioID == nComer && c.CreditoID == nCred
                            && c.CuotaID == nIDBusq, cc => cc.OrderBy(ccc => ccc.CobranzaID)).ToList();
                    break;
                case "Cobranza_S": //Cobranza directamente bus
                    nTmp1 = Convert.ToInt16(lblCobrGstion.Text);
                    regCobMod = bl.Get<Cobranza>(BaseID, c => c.EmpresaID == nEmpre && c.ComercioID == nComer && c.CreditoID == nCred
                            && c.CuotaID == nRefiCuotaID && c.CobranzaID == nIDBusq
                            && c.GestionID==nTmp1).FirstOrDefault();                           //&& c.CuotaID == nCuota 
                    break;
                case "Cuota":
                    regCuota = bl.Get<Cuota>(BaseID, c => c.EmpresaID == nEmpre && c.ComercioID == nComer && c.CreditoID == nCred
                        && c.CuotaID == nIDBusq).FirstOrDefault();
                      break;
                case "NotasCD":
                      regNotaCD = bl.Get<NotasCD>(BaseID, n => n.EmpresaID == nEmpre && n.ComercioID == nComer && n.CreditoID == nCred
                                        && n.NotaCDID == nIDBusq).FirstOrDefault();
                    break;

            }
        }
        
        private void  Anula_Cobranza()
        {
            bool bNotaCD = false;
            int nRefID = Convert.ToInt32(lblRefiId.Text);
            int nCobrID = Convert.ToInt32(lblCobrID.Text);
            int nCobrGestion=Convert.ToInt32(lblCobrGstion.Text);
            bl = new BusinessLayer();
            List<Transmision> ltrans = new List<Transmision>();

            int BaseID = bl.GetEmpresa(lblMor.Visible).EmpresaID.Value;
            regCuota = bl.Get<Cuota>(BaseID,c => c.EmpresaID == nEmpre && c.ComercioID == nComer && c.CreditoID == nCred
                                    && c.CuotaID == nCuota).FirstOrDefault();
            if(regCuota==null)
            {
                MessageBox.Show("ERROR - No se encontró la cuota" + Environment.NewLine + "(error : BCOB-00001)", this.Text);
                    return;
            }
            Cobranza regCobMod = bl.Get<Cobranza>(BaseID,c => c.EmpresaID == nEmpre && c.ComercioID == nComer && c.CreditoID == nCred
                    && c.CuotaID == nCuota && c.CobranzaID == nCobrID && c.GestionID == nCobrGestion).FirstOrDefault();
            if (regCobMod == null)
            {
                MessageBox.Show("ERROR - No se encontró la cobranza" + Environment.NewLine + "(error : BCOB-00002)", this.Text);
                return;
            }

            if(txtBajaMotivo.Text=="")
            {
                MessageBox.Show("El dato no puede quedar vacio", this.Text);
                txtBajaMotivo.Focus();
                return;
            }
            DialogResult res;

            if (lblCobrRefi.Text != "0" && lblCobrRefi.Text != "" && grpRefi.Visible)
            {
                Anula_Cobranza_Refinanciada(BaseID);
                return;
            }

            if(lblCobrNotaCD.Text!="")
            {
               res = MessageBox.Show("La cobranza tiene una nota de crédito por " + lblCobrNotaCD.Text
                        + Environment.NewLine + "¿Continuar?",this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
               if (res == DialogResult.Cancel) return;
               bNotaCD = true;
            }
            else if(grpAdelanto.Visible && lblRefiId.Text !="0")
            {
                res = MessageBox.Show("Anular la cobranza por " + lblCobrTotal.Text + Environment.NewLine + " y cancelar la refinanciación nro: " +lblRefiId.Text
                         , this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (res == DialogResult.Cancel) return;
            }
            else
            {
                res = MessageBox.Show("Anular la cobranza por " + lblCobrTotal.Text
                         , this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (res == DialogResult.Cancel) return;
            }

            if(regCuota.Importe < (regCuota.ImportePago-regCobMod.ImportePago))
            {
                MessageBox.Show("ERROR - No se puede anular la cobranza" + Environment.NewLine + "(error : BCOB-00003)", this.Text);
                return;
            }


            /*Compacté este codigo repetido que se usa en baja_cobranza de refi */
            AnulaCobranza(regCuota, regCobMod, regCobMod.RefinanciacionCobranzaID,bNotaCD, ref ltrans);
                  
            
            //CREDITO
            Credito regCreditoModi = bl.Get<Credito>(BaseID,c => c.EmpresaID == nEmpre && c.ComercioID == nComer
                                && c.CreditoID == nCred).FirstOrDefault();
            if (regCreditoModi==null)
            {
                            //ACA error
            }
            regCreditoModi.RefinanciacionID = 0;
            bl.ActualizarTransaccional<Credito>(regCreditoModi.EmpresaID,regCreditoModi);
            //                                                          ACA UN END BEGIN
            bl.Grabar(BaseID);
            bl.GrabarTransmisiones(BaseID,ltrans);
            MessageBox.Show("Cobranza anulada", this.Text);
            Limpia();
            Busca_Cobranzas();
        }

        private int AnulaCobranza(Cuota regCuota, Cobranza regCobMod, int nRefNvo,bool bNotaCD,ref List<Transmision> ltrans)
        {

            int nNotaCD = 0;
            NotasCD regNotaCDNvo = null;
            CuentaCorriente cc;
            CuentaCorriente ccDeb = null;
            Comercio com = bl.GetComercio(regCobMod.EmpresaID);
            Cobranza ultiCobAnterior;

            ltrans = bl.Transmision(ltrans, com, bl.pGlob.TransBajaCobranza, bl.pGlob.UriAltaCobranza);
            //NotaCD
            if (bNotaCD)
            {
                int nID = 0;                                            //ACA VER SI BUSCAMOS POR EMPRESA
                nNotaCD = Convert.ToInt16(lblCobrNotaCDId.Text);
                Buscame_de_todo(regCobMod.EmpresaID,"NotasCD", 0, 0, 0, nNotaCD);
                //regNotaCD = bl.GetNotasCD(n => n.NotaCDID == nNotaCD && n.EmpresaID == nEmpre).FirstOrDefault();
                if (regNotaCD == null)
                {
                    MessageBox.Show("ERROR - No se encontró la nota de crédito" + Environment.NewLine + "(error : BCOB-00004)", this.Text);
                    return 0;
                }
                List<NotasCD> nn = bl.Get<NotasCD>(regCobMod.EmpresaID,c => c.EmpresaID == nEmpre && c.ComercioID == nComer).ToList();
                foreach (NotasCD not in nn)
                {
                    if (not.NotaCDID >= nID) nID = not.NotaCDID + 1;
                }

                regNotaCDNvo = new NotasCD();
                regNotaCDNvo.EmpresaID = nEmpre;
                regNotaCDNvo.NotaCDID = nID;
                regNotaCDNvo.ComercioID = regNotaCD.ComercioID;
                regNotaCDNvo.CreditoID = regNotaCD.CreditoID;
                regNotaCDNvo.CuotaID = regNotaCD.CuotaID;
                regNotaCDNvo.CobranzaID = regNotaCD.CobranzaID;
                regNotaCDNvo.TipoNota = "DEBITO";
                regNotaCDNvo.Importe = regNotaCD.Importe;
                regNotaCDNvo.Fecha = DateTime.Now;
                regNotaCDNvo.Documento = nDocumento;
                regNotaCDNvo.TipoDocumentoID = cDocumento;
                //regNotaCDNvo.Detalle = "Anulación de cobranza";
                regNotaCDNvo.GestionID = bl.pGlob.Comercio.ComercioID;
                regNotaCDNvo.UsuarioID = p.usu.UsuarioID;
                regNotaCDNvo.PcComer = System.Environment.MachineName;
                regNotaCDNvo.Notas = "Anulación de cobranza";
                regNotaCDNvo.Detalle = "ANULADA";  //edunvo 202201
                bl.AgregarTransaccional<NotasCD>(regNotaCDNvo.EmpresaID,regNotaCDNvo);
               
                //cc = bl.ImputarAnulacionNotaDeCreditoACuentaCorriente(regNotaCDNvo);
                
                if (regNotaCD.Notas == "Pago anticipado")//eduardo cambio
                {
                    cc = bl.ImputarAnulacionDescuentoCobranzaPorCancelaciónAnticipadoACuentaCorriente(nEmpre, regNotaCD, DateTime.Now);
                }
                else //if (regNotaCD.Notas == "Pago bonificado")//eduardo cambio
                {
                    cc = bl.ImputarAnulacionDescuentoCobranzaPorPromocionBonificadaACuentaCorriente(nEmpre, regNotaCD, DateTime.Now);
                }

                bl.Grabar(regNotaCDNvo.EmpresaID);
                ltrans = bl.Transmision<NotasCD>(ltrans, regNotaCDNvo, com, bl.pGlob.TransBajaNotaCD, bl.pGlob.UriAltaCobranza);
                ltrans = bl.Transmision<CuentaCorriente>(ltrans, cc, com, bl.pGlob.TransImputacionCC, bl.pGlob.UriAltaCobranza);
            }

            int nCobraIDNvo = 1;
            nCobraIDNvo = Busca_Ultimo_ID_Cobranza(nEmpre, nComer, ComID, false, 0);
            
            regCuota.ImportePago = regCuota.ImportePago - regCobMod.ImportePago;
            regCuota.ImportePagoPunitorios = regCuota.ImportePagoPunitorios - regCobMod.ImportePagoPunitorios;
            
            if (regCuota.ImportePago == 0)
            {
                regCuota.FechaUltimoPago = null;   
            }
            else
            {
                ultiCobAnterior = bl.Get<Cobranza>(regCuota.EmpresaID, c => c.EmpresaID == regCuota.EmpresaID && c.ComercioID == regCuota.ComercioID
                                                     && c.CreditoID == regCuota.CreditoID && c.CuotaID == regCuota.CuotaID && c.CobranzaID != regCobMod.CobranzaID).FirstOrDefault();
                if (ultiCobAnterior != null)
                {
                    regCuota.FechaUltimoPago = ultiCobAnterior.FechaPago; 
                }
                else
                {
                    regCuota.FechaUltimoPago = null;   
                }
            }


            //cobranza
            Cobranza regCobNvo = new Cobranza();
            regCobNvo.EmpresaID = regCobMod.EmpresaID;
            regCobNvo.ComercioID = regCobMod.ComercioID;
            regCobNvo.CreditoID = regCobMod.CreditoID;
            regCobNvo.CuotaID = regCobMod.CuotaID;
            regCobNvo.CobranzaID = nCobraIDNvo;
            regCobNvo.Documento = nDocumento;
            regCobNvo.TipoDocumentoID = cDocumento;
            regCobNvo.ImportePago = regCobMod.ImportePago * -1;
            if (regCobMod.ImportePagoPunitorios > 0) regCobNvo.ImportePagoPunitorios = regCobMod.ImportePagoPunitorios * -1;
            else regCobNvo.ImportePagoPunitorios = 0;
            regCobNvo.Interes = regCobMod.Interes * -1;
            regCobNvo.PunitoriosCalc = regCobMod.PunitoriosCalc * -1;
            regCobNvo.FechaPago = DateTime.Now;  // regCobMod.FechaPago;
            regCobNvo.FechaVencimiento = regCobMod.FechaVencimiento;
            regCobNvo.TipoPagoID = "N";
            regCobNvo.TipoBonificacionID = regCobMod.TipoBonificacionID;
            regCobNvo.PorcentajeBonificacion = regCobMod.PorcentajeBonificacion;
            regCobNvo.Motivo = txtBajaMotivo.Text;
            regCobNvo.PagoRev = true;
            regCobNvo.FechaRev = DateTime.Now;
            regCobNvo.GestionEmpresaID = com.EmpresaID;
            regCobNvo.GestionID = com.ComercioID;
            regCobNvo.RefinanciacionCobranzaID = nRefNvo; // regCobMod.RefinanciacionCobranzaID;  
            regCobNvo.UsuarioID = p.usu.UsuarioID;
            regCobNvo.PcComer = System.Environment.MachineName;
            regCobNvo.CobranzaIDRev = regCobMod.CobranzaID;

            regCobMod.PagoRev = true;
            regCobMod.FechaRev = DateTime.Now;

            regCuota.Credito.Cancelado = false;
            
            bl.ActualizarTransaccional<Cuota>(regCuota.EmpresaID,regCuota);
            bl.AgregarTransaccional<Cobranza>(regCobNvo.EmpresaID,regCobNvo);
            bl.ActualizarTransaccional<Cobranza>(regCobMod.EmpresaID,regCobMod);
            bl.ActualizarTransaccional<Credito>(regCuota.EmpresaID, regCuota.Credito);
            
            //Hay que agregar los movimientos de cuenta corriente aca
            cc = bl.ImputarAnulacionCobranzaACuentaCorriente(regCobNvo);

            Recibo rec = bl.Get<Recibo>(regCobMod.EmpresaID, r => r.EmpresaID == Com.EmpresaID && r.ComercioID == Com.ComercioID
                                        && r.CobranzaID == regCobMod.CobranzaID  && r.CuotaID == regCobMod.CuotaID &&  r.CreditoID == regCobMod.CreditoID
                                        && bl.pGlob.TmCobPorDebito.TipoMovimientoID == r.TipoMovimientoID)
                                        .FirstOrDefault();
            
            ccDeb = bl.AnularRecibo(rec, regCobMod);          

            bl.Grabar(regCobNvo.EmpresaID);

            //No cambiar el orden porque sino bajarefinanciacioncobranza no lo va a leer bien.
            ltrans = bl.Transmision<Cuota>(ltrans, regCuota, com, bl.pGlob.TransActualizarCuota, bl.pGlob.UriAltaCobranza);
            ltrans = bl.Transmision<Cobranza>(ltrans, regCobNvo, com, bl.pGlob.TransAltaCobranza, bl.pGlob.UriAltaCobranza);
            ltrans = bl.Transmision<Cobranza>(ltrans, regCobMod, com, bl.pGlob.TransActualizarCobranza, bl.pGlob.UriAltaCobranza);
            ltrans = bl.Transmision<CuentaCorriente>(ltrans, cc, com, bl.pGlob.TransImputacionCC, bl.pGlob.UriAltaCobranza);
            if (ccDeb != null)
              ltrans = bl.Transmision<CuentaCorriente>(ltrans, ccDeb, com, bl.pGlob.TransImputacionCC, bl.pGlob.UriAltaCobranza);
            
            return nCobraIDNvo;
        }


        private void Busca_Cobranzas()
        {
            if (txtBuscaComer.Text == "0") return;
            if (txtBuscaCred.Text == "0") return;
            if (txtBuscaCuota.Text == "0") return;
            int nCantCuota = 0;
            decimal nDeudaCuota = 0;
            nEmpre =  BaseID;
            nComer = Convert.ToInt16(txtBuscaComer.Text);
            nCred =Convert.ToInt32(txtBuscaCred.Text);
            nCuota = Convert.ToInt16(txtBuscaCuota.Text);
            regCuota = null;
            regCobranzaList = null;
            regCobMod = null;
            regRefinanciacionCobranza = null;
            regRefinanciacionCuota = null;
            regRefinanciacionCuotaList = null;
            regRefinanciacion = null;
            regNotaCD = null;

            bl = new BusinessLayer();

            Buscame_de_todo(nEmpre,"Cobranza_F", 0, 0, 0, nCuota);
            if(regCobranzaList.Count==0)
            {
                MessageBox.Show("La cuota no tiene cobranzas", this.Text);
                return;
            }

            lblEmpresaID.Text = regCobranzaList[0].EmpresaID.ToString();
            lblCliNombre.Text = regCobranzaList[0].Cliente.NombreCompleto;
            lblCliDocu.Text = regCobranzaList[0].Cliente.Documento.ToString("N0");
            nDocumento = regCobranzaList[0].Cliente.Documento;
            cDocumento = regCobranzaList[0].Cliente.TipoDocumentoID;
            lblCliCodD.Text = regCobranzaList[0].Cliente.TipoDocumentoID;
            lblCredSoli.Text = regCobranzaList[0].Credito.FechaSolicitud.ToShortDateString();
            lblCredCuotas.Text = regCobranzaList[0].Credito.CantidadCuotas.ToString();

            foreach(Cuota cuo in regCobranzaList[0].Credito.Cuotas)
            {
                if (cuo.CuotaID > nCuota)
                {
                    if (cuo.Deuda < cuo.Importe) nCantCuota++;
                }
                    nDeudaCuota = nDeudaCuota + cuo.Deuda;
            }
            if(nCantCuota>0)
            {
                MessageBox.Show("El Crédito tiene cuotas posteriores pagas", this.Text);
                return;
            }
            if (nDeudaCuota == 0) lblCredEst.Text = "Cancelado"; else lblCredEst.Text = "Sin cancelar";

            LLenadatos_Cobranza();
            panel1.Enabled = false;
            BtnBuscar.Text = "Cancelar";
            txtBajaMotivo.Enabled = true;
            lblFlechaD.Visible = true;
            lblFlechaI.Visible = true;
            bMuestra = true;
        }
        private void LLenadatos_Cobranza()
        {
            decimal nPag = 0;
            string cUsuN = "";
            int nRefiCobranza = 0;
            backColorList = Color.LightSteelBlue;

            foreach(Cobranza cob in regCobranzaList)
            {
                ListViewItem item = new ListViewItem(cob.CobranzaID.ToString());
                item.UseItemStyleForSubItems = false;
                item.SubItems.Add(cob.CuotaID.ToString(), fontColor, backColorList, fontList);             //1
                item.SubItems.Add(cob.FechaPago.ToShortDateString(), fontColor, backColorList, fontList);
                item.SubItems.Add(cob.ImportePago.ToString("N2"), fontColor, backColorList, fontList);             //3
                nPag = nPag + cob.ImportePago;
                item.SubItems.Add(cob.ImportePagoPunitorios.ToString("N2"), fontColor, backColorList, fontList);
                item.SubItems.Add(cob.ImporteTotal.ToString("N2"), fontColor, backColorList, fontList);             //5

                item.SubItems.Add(cob.GestionID.ToString(), fontColor, backColorList, fontList);
                if (cob.Usuario != null) cUsuN = cob.Usuario.nombre;
                item.SubItems.Add(cUsuN, fontColor, backColorList, fontList);             //7
                item.SubItems.Add(cob.FechaVencimiento.ToShortDateString(), fontColor, backColorList, fontList);
                cUsuN = "";
                if (cob.TipoPago != null) cUsuN = cob.TipoPago.Nombre;
                item.SubItems.Add(cUsuN, fontColor, backColorList, fontList);             //9

                if (cob.PagoRev == true)
                {
                    item.SubItems.Add("A", fontColor, backColorList, fontList);             //10
                    item.SubItems.Add(cob.FechaRev.Value.ToShortDateString(), fontColor, backColorList, fontList);             //11
                }
                else
                {
                    item.SubItems.Add("", fontColor, backColorList, fontList);             //10
                    item.SubItems.Add("", fontColor, backColorList, fontList);             //11
                }
                
                item.SubItems.Add(cob.TipoPagoID, fontColor, backColorList, fontList);  //12
                if(cob.TipoPagoID=="D")
                {
                    if (cob.Credito.RefinanciacionID != null) 
                        Busca_Adelanto_Refi(cob.EmpresaID,(int)cob.Credito.RefinanciacionID);
                }
                NotasCD not = bl.GetNotasCD(n => n.EmpresaID == nEmpre && n.ComercioID == nComer && n.CreditoID == nCred
                            && n.CobranzaID == cob.CobranzaID).FirstOrDefault();
                if (not!=null )
                {
                    item.SubItems.Add(not.Importe.ToString("N2"), fontColor, backColorList, fontList);         //13
                    item.SubItems.Add(not.NotaCDID.ToString(), fontColor, backColorList, fontList);          //14
                }else
                {
                    item.SubItems.Add("", fontColor, backColorList, fontList);             //13
                    item.SubItems.Add("", fontColor, backColorList, fontList);             //14
                }
                //if (cob.RefinanciacionCobranzaID != null) // && cob.RefinanciacionCobranzaID >0)
                //{
                if(cob.RefinanciacionCobranzaID >0)
                { 
                    nRefiCobranza = Busca_Refinanciacion_Cobranza(cob.EmpresaID ,cob.ComercioID
                                                            ,cob.CreditoID, cob.RefinanciacionCobranzaID,false);
                    item.SubItems.Add(nRefiCobranza.ToString(), fontColor, backColorList, fontList);             //15
                }
                //}
                else
                {
                    item.SubItems.Add("", fontColor, backColorList, fontList);             //15
                }
                item.SubItems.Add(cob.FechaPago.ToShortTimeString(), fontColor, backColorList, fontList);  //16
                item.SubItems.Add(cob.GestionID.ToString(), fontColor, backColorList, fontList);  //1
                listCobranzas.Items.Add(item);
                if (backColorList == Color.White) backColorList = Color.LightSteelBlue; else backColorList = Color.White;
            }
        }
        private int Busca_Refinanciacion_Cobranza(int nRefEmpre, int nRefComer, int nRefCred, int nRefCobra, bool bMuestraR)
        {
            int nCuotaAnt = 0;
            //btnAnula.Top = listCobranzas.Top;
            listRefinanCobr.Items.Clear();
            grpRefi.Visible = false;
            grpAdelanto.Visible = false;
            Color backColorList2 = Color.LightSteelBlue;
            Buscame_de_todo(nRefEmpre,"RefinanciacionCobranza", 0, 0, nRefCobra, 0);
            //regRefinanciacionCobranza = bl.GetRefinanciacionCobranzas(r => r.EmpresaID == nRefEmpre && r.ComercioID == nRefComer
            //                               && r.CreditoID == nRefCred && r.RefinanciacionCobranzaID == nRefCobra).FirstOrDefault();
            if (regRefinanciacionCobranza != null)
            {
                if (bMuestraR)
                {
                    backColorList2 = Color.LightCoral;
                    decimal nTmp1 = 0;
                    string cTmp1 = "";
                    
                    
                    ListViewItem item = new ListViewItem(regRefinanciacionCobranza.RefinanciacionCobranzaID.ToString());
                    item.UseItemStyleForSubItems = false;
                    item.SubItems.Add(regRefinanciacionCobranza.RefinanciacionCuotaID.ToString(), fontColor, backColorList2, fontList);
                    item.SubItems.Add(regRefinanciacionCobranza.FechaPago.ToShortDateString(), fontColor, backColorList2, fontList);
                    item.SubItems.Add(regRefinanciacionCobranza.ImportePago.ToString("N2"), fontColor, backColorList2, fontList);             //3
                    item.SubItems.Add(regRefinanciacionCobranza.ImportePagoPunitorios.ToString("N2"), fontColor, backColorList2, fontList);
                    nTmp1 = regRefinanciacionCobranza.ImportePago + regRefinanciacionCobranza.ImportePagoPunitorios;
                    item.SubItems.Add(nTmp1.ToString("N2"), fontColor, backColorList2, fontList);             //5
                    item.SubItems.Add(regRefinanciacionCobranza.GestionID.ToString(), fontColor, backColorList2, fontList);
                    item.SubItems.Add(regRefinanciacionCobranza.FechaVencimiento.ToShortDateString(), fontColor, backColorList2, fontList);
                    if (regRefinanciacionCobranza.PagoRev == true) cTmp1 = "N";
                    item.SubItems.Add(cTmp1, fontColor, backColorList2, fontList);
                    listRefinan.Items.Add(item);
                                                    // busca las cobranza(s) que generó ese pago refinanciado
                    regCobranzaList = bl.Get<Cobranza>(nRefEmpre, c => c.EmpresaID == nRefEmpre && c.ComercioID == nRefComer && c.CreditoID == nCred
                            && c.RefinanciacionCobranzaID == nRefCobra ,cc=>cc.OrderBy(ccc=>ccc.CobranzaID) ).ToList();
                    if (regCobranzaList.Count == 0) return 0;
                    nTmp1 = 0;
                    backColorList2 = Color.LightSteelBlue;
                    foreach(Cobranza cob in regCobranzaList)
                    {
                        item = new ListViewItem(cob.CobranzaID.ToString());
                        item.UseItemStyleForSubItems = false;
                        item.SubItems.Add(cob.CuotaID.ToString(), fontColor, backColorList2, fontList);             //1
                        item.SubItems.Add(cob.FechaPago.ToShortDateString(), fontColor, backColorList2, fontList);
                        item.SubItems.Add(cob.ImportePago.ToString("N2"), fontColor, backColorList2, fontList);             //3
                        nTmp1 = nTmp1 + cob.ImportePago;
                        item.SubItems.Add(cob.ImportePagoPunitorios.ToString("N2"), fontColor, backColorList2, fontList);
                        item.SubItems.Add(cob.ImporteTotal.ToString("N2"), fontColor, backColorList2, fontList);             //5
                        item.SubItems.Add(cob.GestionID.ToString(), fontColor, backColorList2, fontList);
                        if (cob.TipoPago != null) cTmp1 = cob.TipoPago.Nombre; else cTmp1 = "";
                        item.SubItems.Add(cTmp1, fontColor, backColorList2, fontList);             //9
                        item.SubItems.Add(cob.FechaVencimiento.ToShortDateString(), fontColor, backColorList2, fontList);
                        if (cob.PagoRev == true)
                        {
                            item.SubItems.Add("A", fontColor, backColorList2, fontList);             //10
                            item.SubItems.Add(cob.FechaRev.Value.ToShortDateString(), fontColor, backColorList2, fontList);             //11
                        }
                        else
                        {
                            item.SubItems.Add("", fontColor, backColorList2, fontList);             //10
                            item.SubItems.Add("", fontColor, backColorList2, fontList);             //11
                        }
                        item.SubItems.Add(cob.TipoPagoID, fontColor, backColorList2, fontList);  //12
                        listRefinanCobr.Items.Add(item); 

                        if (cob.CuotaID < nCuota) nCuotaAnt = cob.CuotaID;
                    }


                    if(bMuestra) grpRefi.Visible = true;
                    //btnAnula.Top = listRefinan.Top + grpRefi.Top;
                }
                if (nCuotaAnt > 0)
                {
                    Buscame_de_todo(nRefEmpre,"Cuota", 0, 0, 0, nCuota);
                    Buscame_de_todo(nRefEmpre,"Cobranza_L", 0, 0, nRefCobra, nCuota);
                    if (regCuota.ImportePago - regCobranzaList[0].ImportePago > 0) nRefCobra = 0;
                }
                    
                    if(nRefCobra>0)
                    {
                        Buscame_de_todo(nRefEmpre,"RefinanciacionCuota", regRefinanciacionCobranza.RefinanciacionID
                                                    , regRefinanciacionCobranza.RefinanciacionCuotaID+1
                                                    , 0, 0);
                        if(regRefinanciacionCuota==null)                                //
                        {
                                                                                            //ACA msg error o  nada
                        }
                        else
                        {
                            if (regRefinanciacionCuota.ImportePago > 0) nRefCobra = 0;
                        }
                    }


                return nRefCobra;
            }
            return 0;
        }
        private void Configura_Inicio()
        {
            Configura_Controles();
            Configura_listas();
            this.Text = "Anulación de cobranzas";
            Limpia();
        }
        private void Limpia()
        {
            bMuestra = false;
            nEmpre = 0;
            nComer = 0;
            nCred = 0;
            nCuota = 0;
            nDocumento = 0;
            cDocumento = "";

            lblRefiId.Text = "0";
            listCobranzas.Items.Clear();
            lblFlechaD.Visible = false;
            lblFlechaI.Visible = false; 
            lblCliNombre.Text = "";
            lblCliDocu.Text = "";
            lblCredSoli.Text = "";
            lblCredCuotas.Text = "";
            lblCredEst.Text = "";
            txtBajaMotivo.Text = "";
            txtBajaMotivo.Enabled = false;
            btnAnula.Enabled = false;

            lblCobrFecha.Text = "";
            lblCobrHora.Text = "";
            lblCobrImp.Text = "";
            lblCobrPuni.Text = "";
            lblCobrUsu.Text = "";
            lblCobrTotal.Text = "";
            lblCobrID.Text = "";
            lblCobrNotaCD.Text = "";
            lblCobrNotaCDId.Text = "";
            lblCobrTipo.Text = "";
            lblCobrRefi.Text = "";
            lblCobrGstion.Text = "0";

            listRefinan.Items.Clear();
            listRefinanCobr.Items.Clear();
            grpRefi.Visible = false;
            grpAdelanto.Visible = false;
            //btnAnula.Top = listCobranzas.Top;
            panel1.Enabled = true;
            BtnBuscar.Text = "Buscar";
            txtBuscaCred.Focus();
        }
        private void Configura_listas()
        {
            listCobranzas.View = View.Details;
            listCobranzas.Columns.Add("", 0, HorizontalAlignment.Right);                    //CobranzaID
            listCobranzas.Columns.Add("Cuota", 40, HorizontalAlignment.Right);              //1         CuotaID
            listCobranzas.Columns.Add("Fecha pago", 90, HorizontalAlignment.Right);         
            listCobranzas.Columns.Add("Importe", 85, HorizontalAlignment.Right);              //3
            listCobranzas.Columns.Add("Punitorios", 85, HorizontalAlignment.Right);
            listCobranzas.Columns.Add("Total", 85, HorizontalAlignment.Right);             //5
            listCobranzas.Columns.Add("Gestión", 65, HorizontalAlignment.Right);
            listCobranzas.Columns.Add("Usuario", 65, HorizontalAlignment.Center);             //7
            listCobranzas.Columns.Add("Fecha vencimiento", 90, HorizontalAlignment.Right);
            listCobranzas.Columns.Add("Tipo de pago", 120, HorizontalAlignment.Left);             //9
            listCobranzas.Columns.Add("", 30, HorizontalAlignment.Left);             //10        PagoRev
            listCobranzas.Columns.Add("", 0, HorizontalAlignment.Left);             //11        FechaRev
            listCobranzas.Columns.Add("", 0, HorizontalAlignment.Left);             //12        TipoPagoID
            listCobranzas.Columns.Add("NC", 65, HorizontalAlignment.Left);             //13     NC Importe
            listCobranzas.Columns.Add("", 0, HorizontalAlignment.Left);             //14        NotaCDID
            listCobranzas.Columns.Add("", 0, HorizontalAlignment.Left);             //  15  REFINANCOBRANZAID
            listCobranzas.Columns.Add("", 0, HorizontalAlignment.Left);             // 16 hora
            listCobranzas.Columns.Add("", 0, HorizontalAlignment.Left);             // 17 gestion
            listCobranzas.OwnerDraw = true;
            listCobranzas.GridLines = false;
            listCobranzas.FullRowSelect = true;



            listRefinan.View = View.Details;
            listRefinan.Columns.Add("", 0, HorizontalAlignment.Right);                    //CobranzaID
            listRefinan.Columns.Add("Cuota", 40, HorizontalAlignment.Right);              //1         CuotaID
            listRefinan.Columns.Add("Fecha pago", 90, HorizontalAlignment.Right);
            listRefinan.Columns.Add("Importe", 85, HorizontalAlignment.Right);              //3
            listRefinan.Columns.Add("Punitorios", 85, HorizontalAlignment.Right);
            listRefinan.Columns.Add("Total", 85, HorizontalAlignment.Right);             //5
            listRefinan.Columns.Add("Gestión", 65, HorizontalAlignment.Right);
            listRefinan.Columns.Add("Fecha vencimiento", 90, HorizontalAlignment.Right); //7
            listRefinan.Columns.Add("", 0, HorizontalAlignment.Left);             //8
            listRefinan.Columns.Add("", 0, HorizontalAlignment.Left);             //9        PagoRev
            listRefinan.OwnerDraw = true;
            listRefinan.GridLines = false;
            listRefinan.FullRowSelect = true;


            listRefinanCobr.View = View.Details;
            listRefinanCobr.Columns.Add("", 0, HorizontalAlignment.Right);                    //CobranzaID
            listRefinanCobr.Columns.Add("Cuota", 40, HorizontalAlignment.Right);              //1         CuotaID
            listRefinanCobr.Columns.Add("Fecha pago", 90, HorizontalAlignment.Right);
            listRefinanCobr.Columns.Add("Importe", 85, HorizontalAlignment.Right);              //3
            listRefinanCobr.Columns.Add("Punitorios", 85, HorizontalAlignment.Right);
            listRefinanCobr.Columns.Add("Total", 85, HorizontalAlignment.Right);             //5
            listRefinanCobr.Columns.Add("Gestión", 65, HorizontalAlignment.Right);
            listRefinanCobr.Columns.Add("Tipo de pago", 120, HorizontalAlignment.Center);             //7
            listRefinanCobr.Columns.Add("Fecha vencimiento", 90, HorizontalAlignment.Right);
            listRefinanCobr.Columns.Add("", 0, HorizontalAlignment.Left);             //9
            listRefinanCobr.Columns.Add("", 0, HorizontalAlignment.Left);             //10        PagoRev
            listRefinanCobr.Columns.Add("", 0, HorizontalAlignment.Left);             //11        FechaRev
            listRefinanCobr.Columns.Add("", 0, HorizontalAlignment.Left);             //12        TipoPagoID
            listRefinanCobr.Columns.Add("NC", 65, HorizontalAlignment.Left);             //13     NC Importe
            listRefinanCobr.Columns.Add("", 0, HorizontalAlignment.Left);             //14        NotaCDID
            listRefinanCobr.Columns.Add("", 0, HorizontalAlignment.Left);             //  15  REFINANCOBRANZAID
            listRefinanCobr.OwnerDraw = true;
            listRefinanCobr.GridLines = false;
            listRefinanCobr.FullRowSelect = true;
        
        }
        private void Configura_Controles()
        {


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
                    }

                }
            }
            grpAdelanto.Top = grpRefi.Top;
            //grpAdelanto.Left = grpRefi.Left;
            grpAdelanto.Visible = false;
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            BtnBuscar.Enabled = false;
            if (BtnBuscar.Text == "Buscar")
            {
                Busca_Cobranzas();
            }else
            {
                Limpia();
            }
            BtnBuscar.Enabled = true;
        }

        private void listCobranzas_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAnula.Enabled = false;
            grpRefi.Visible = false;
            grpAdelanto.Visible = false;
            lblCobrFecha.Text = "";
            lblCobrHora.Text = "";
            lblCobrImp.Text = "";
            lblCobrPuni.Text = "";
            lblCobrUsu.Text = "";
            lblCobrTotal.Text = "";
            lblCobrID.Text = "";
            lblCobrNotaCD.Text = "";
            lblCobrNotaCDId.Text = "";
            lblCobrTipo.Text = "";
            lblCobrRefi.Text = "";
            lblCobrGstion.Text = "0";
            if (!bMuestra) return;
            foreach (ListViewItem aa in listCobranzas.SelectedItems)
            {
                listRefinan.Items.Clear();
                listRefinanCobr.Items.Clear();
                int bR = 1;
                lblFlechaI.Top = aa.Position.Y + listCobranzas.Top;
                lblFlechaD.Top = lblFlechaI.Top;
                //if (aa.SubItems[12].Text == "B") return;
                if (aa.SubItems[10].Text == "A") return;

                lblCobrFecha.Text = aa.SubItems[2].Text;
                lblCobrHora.Text = aa.SubItems[16].Text;
                lblCobrImp.Text = aa.SubItems[3].Text;
                lblCobrPuni.Text = aa.SubItems[4].Text;
                lblCobrTotal.Text = aa.SubItems[5].Text;
                lblCobrUsu.Text = aa.SubItems[7].Text;
                lblCobrID.Text = aa.SubItems[0].Text;
                lblCobrNotaCD.Text = aa.SubItems[13].Text;
                lblCobrNotaCDId.Text = aa.SubItems[14].Text;
                lblCobrTipo.Text = aa.SubItems[9].Text;
                lblCobrRefi.Text = aa.SubItems[15].Text;
                lblCobrGstion.Text = aa.SubItems[17].Text;
                if (aa.SubItems[15].Text != "0" && aa.SubItems[15].Text != "")
                {
                    bR=Busca_Refinanciacion_Cobranza(nEmpre, Convert.ToInt16(txtBuscaComer.Text)
                                                , Convert.ToInt32(txtBuscaCred.Text), Convert.ToInt16(aa.SubItems[15].Text), true);
                    lblCartel.Text = "Cobranza refinanciada";
                    if (bR > 0) btnAnula.Enabled = true;
                }
                if (aa.SubItems[12].Text=="D")
                {
                    if (lblRefiId.Text != "0") {
                        Busca_Adelanto_Refi(nEmpre,Convert.ToInt16(lblRefiId.Text));
                    }
                    else btnAnula.Enabled = true;

                }
                else { btnAnula.Enabled = true; }
                
            }
        }
        private void Busca_Adelanto_Refi(int EmpresaID,int nRef)
        {
            if (nRef == 0) return;
            
            lblCartel2.Text = "Adelanto de refinanciación";
            Buscame_de_todo(EmpresaID,"Refinanciacion", nRef, 0, 0,0);
            if (regRefinanciacion == null) return;
            lblRefiId.Text = regRefinanciacion.RefinanciacionID.ToString();
            lblRefiFecha.Text = regRefinanciacion.FechaSolicitud.ToShortDateString();
            lblRefiCuotas.Text = regRefinanciacion.CantidadCuotas.ToString();
            lblRefiValorCuota.Text = regRefinanciacion.ValorCuota.ToString();
            //btnAnula.Top = grpAdelanto.Top;
            if (!bMuestra) return;
            grpAdelanto.Visible = true;
            btnAnula.Enabled = Puede_Anular_Cobranza(EmpresaID,"ADELANTO");

        }
        private void btnAnula_Click(object sender, EventArgs e)
        {
            Anula_Cobranza();
        }
        private bool Puede_Anular_Cobranza(int EmpresaID,string qMierdaBusca)
        {
            decimal nTmp1 = 0;
            if (qMierdaBusca == "ADELANTO")
            {
                if (grpAdelanto.Visible && Convert.ToInt16(lblRefiId.Text) > 0)
                {
                    Buscame_de_todo(EmpresaID,"RefinanciacionCuota_L", Convert.ToInt16(lblRefiId.Text), 0, 0, 0);
                    if (regRefinanciacionCuotaList.Count == 0) return false;
                    foreach (RefinanciacionCuota refiCuo in regRefinanciacionCuotaList)
                    {
                        nTmp1 = nTmp1 + refiCuo.ImportePago;
                    }
                    if (nTmp1 > 0) return false;
                }
            }
            return true;
        }

        private void FrmBajaCobranza_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                if (e.Shift)
                {
                    if (bl.LlevaM())
                    {
                        lblMor.Visible = true;
                        RecargarEmpYComercio(lblMor.Visible);
                    }
                }
            }
        }
    }
}
