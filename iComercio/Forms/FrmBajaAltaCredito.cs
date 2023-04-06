using System;                         ////convert, eventarg, eventhandler
using System.Collections.Generic;         //list<>
using System.Drawing;                  ///font , color
using System.Linq;                      // orderby()
using System.Windows.Forms;               //formWindowsState, listview, musearg, etc
using iComercio.Rest;                       //RestApi
using iComercio.Models;                     // modelos(cred, cuot, etc)

using iComercio.DAL;                      //<MorosoEnCamara>
using AutoMapper;

namespace iComercio.Forms
{
    public partial class FrmBajaCredito : FRM
    {
        Color backColorList = Color.White;
        Color fontColor = Color.Empty;
        Font fontList = new Font("Verdana", 10F, FontStyle.Regular);

        int nEmpre = 0;
        int nComer = 0;
        int nCred = 0;

        List<Cobranza> regCobranzaList = null;
        List<Cuota> regCuotaList = null;
        Credito regCredito=null;

        public FrmBajaCredito()
        {
            InitializeComponent();
        }
        public FrmBajaCredito(Principal p)
            : base(p)
        {
            bl = new BusinessLayer();
            InitializeComponent();
            Configura_Inicio();
        }
        private void Busca_Credito()
        {
            btnAnula.Enabled = false;
            bool bPasa = true;
            decimal nPago=0;
            
            if (txtBuscaComer.Text == "0") return;
            if (txtBuscaCred.Text == "0") return;

            nEmpre = BaseID; // bl.pGlob.Comercio.EmpresaID;
            nComer = Convert.ToInt16(txtBuscaComer.Text);
            nCred = Convert.ToInt32(txtBuscaCred.Text);

            if(lblMor.Visible)
            {
                if(nComer != ComID) bPasa = false;
            }
            else
            {
                if(nComer != bl.pGlob.Comercio.ComercioID) bPasa = false;
            }

            if(bPasa == false)
            {
                MessageBox.Show("El número de comercio no corresponde", this.Text);
                nEmpre = 0;
                nComer = 0;
                nCred = 0;
                return;
            }
            bl = new BusinessLayer();
            regCredito= bl.GetCreditos(BaseID, c => c.EmpresaID == nEmpre && c.ComercioID == nComer
                               && c.CreditoID == nCred).FirstOrDefault();
            if(regCredito==null)
            {
                MessageBox.Show("Crédito no encontrado", this.Text);
                nEmpre = 0;
                nComer = 0;
                nCred = 0;
                return;
            }

            //regCuotaList = bl.GetCuotas(c => c.EmpresaID == nEmpre && c.ComercioID == nComer && c.CreditoID == nCred, cc => cc.OrderByDescending(ccc => ccc.CuotaID)).ToList();
            if (regCredito.Cuotas.Count==0)
            {
                MessageBox.Show("ERROR -  AL BUSCAR LAS CUOTAS", this.Text);
                nEmpre = 0;
                nComer = 0;
                nCred = 0;
                return;
            }

            lblCreSoli.Text = regCredito.FechaSolicitud.ToShortDateString() ;
            lblCreValorNom.Text = regCredito.ValorNominal.ToString();
            lblCreCuotas.Text = regCredito.CantidadCuotas.ToString();
            lblCreValorCuotas.Text = regCredito.ValorCuota.ToString();

            lblCliNombre.Text = regCredito.Cliente.NombreCompleto;
            lblCliDocu.Text = regCredito.Documento.ToString();
            lblCliCodD.Text = regCredito.TipoDocumentoID;


            foreach (Cuota cuo in regCredito.Cuotas)
            {
                if (cuo.ImportePago!=0)
                {
                    nPago = nPago +  cuo.ImportePago;
                }
            }
            if (nPago != 0)
            {
                MessageBox.Show("ERROR -  El crédito tiene pagos aplicados", this.Text);
                nEmpre = 0;
                nComer = 0;
                nCred = 0;
                lblCreEst.Text = "CUOTAS PAGAS";
                return;
            }

            lblCreEst.Text = "BIEN";
            BtnBuscar.Text = "Otro";
            btnAnula.Enabled = true;
            txtBajaMotivo.Enabled = true;
            txtBuscaComer.Enabled = false;
            txtBuscaCred.Enabled = false;

        }
        private void Configura_Inicio()
        {
            Configura_Controles();
            Configura_listas();
            this.Text = "Baja de crédito";
            Limpia();
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
        }

        private void Configura_listas()
        {

        }
        private void Limpia()
        {
            txtBuscaComer.Text = bl.pGlob.Comercio.ComercioID.ToString();
            lblCliNombre.Text = "";
            lblCliDocu.Text = "";
            lblCreEst.Text = "";
            txtBajaMotivo.Text = "";
            txtBajaMotivo.Enabled = false;
            lblCreSoli.Text = "";
            lblCreCuotas.Text = "";
            lblCreValorCuotas.Text = "";
            lblCreValorNom.Text = "";
            lblCreEst.Text = "";
            btnAnula.Enabled = false;
            nEmpre = 0;
            nComer = 0;
            nCred = 0;

            txtBuscaComer.Enabled = true;
            txtBuscaCred.Enabled = true;
        }

        private void FrmBajaAltaCredito_Load(object sender, EventArgs e)
        {
            lblMor.Visible = false;
            RecargarEmpYComercio(lblMor.Visible);

        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            BtnBuscar.Enabled = false;
            if (BtnBuscar.Text == "Buscar")
            {
                Busca_Credito();
            }
            else
            {
                Limpia();
                BtnBuscar.Text = "Buscar";
            }
            BtnBuscar.Enabled = true;
        }

        private void btnAnula_Click(object sender, EventArgs e)
        {
            AnularCredito(regCredito);
        }

        private bool TieneCobranzasSinAnular(Cuota cuota)
        {
            foreach (var cob in cuota.Cobranzas)
            {
                var cuotaAnulada = cuota.Cobranzas.Any(c => c.ImportePago == cob.ImportePago * -1);
                if (!cuotaAnulada)
                    return true;
            }
            return false;
        }

        private bool TienenCobranzasSinAnular(IEnumerable<Cuota> cuotas)
        {
            foreach (var cuota in cuotas)
            {
                if (TieneCobranzasSinAnular(cuota))
                    return true;
            }
            return false;
        }

        private void AnularCredito(Credito RegCredito)
        {
            bool tieneCobSinAnular = TienenCobranzasSinAnular(regCredito.Cuotas);
            if (tieneCobSinAnular)
            {
                MessageBox.Show("El crédito tiene cobranzas sin anular, por favor anular las cobranzas antes de anular el crédito.");
                return;
            }

            List<CuentaCorriente> ccs = new List<CuentaCorriente>();
            CuentaCorriente cc;
            CreditoAnulado credAnul = Mapper.Map<Credito,CreditoAnulado>(RegCredito);
            credAnul.Motivo = txtBajaMotivo.Text;
            credAnul.FechaComercioAnula = DateTime.Now;
            credAnul.UsuarioIDAnula = p.usu.UsuarioID;
            credAnul.PcComerAnula = Environment.MachineName;
            bl.AgregarTransaccional<CreditoAnulado>(credAnul.EmpresaID,credAnul);

            DateTime NvaFecha = regCredito.FechaAviso;//eduardo cambio

            if (regCredito.FechaAviso < DateTime.Now)//eduardo cambio
            {
                NvaFecha = DateTime.Now;
            }
            cc = bl.ImputarAnulacionCreditoACuentaCorriente(RegCredito.EmpresaID, RegCredito, NvaFecha);//eduardo cambio
            ccs.Add(cc);
            if(credAnul.TipoCuotaID == "A")
            {
                cc = bl.ImputarAnulacionCuotaAdelantadaACuentaCorriente(RegCredito, NvaFecha);
                ccs.Add(cc);
            }
            if (regCredito.Gasto > 0)
            {
                cc = bl.ImputarAnulacionGastoCreditoACuentaCorriente(RegCredito, NvaFecha);//eduardo cambio
                ccs.Add(cc);
            }
            
            if (regCredito.Comision > 0)//eduardo cambio
            {
                cc = bl.ImputarAnulacionComisionCreditoACuentaCorriente(RegCredito.EmpresaID, RegCredito, NvaFecha);
                ccs.Add(cc);
            }
            int ccID = 0;

            int com = RegCredito.ComercioID;
            int cre = RegCredito.CreditoID;
            int emp = RegCredito.EmpresaID;
            //List<CuentaCorriente> listCc = bl.GetCuentasCorrientes( c => c.EmpresaID == emp && c.ComercioID == com && c.CreditoID == cre && (c.TipoMovimientoID == 20
            //                                                            || c.TipoMovimientoID == 13
            //                                                            || c.TipoMovimientoID == 100)).ToList();

            //List<CuentaCorriente> listCc = bl.Get<CuentaCorriente>(BaseID, c => c.EmpresaID == emp && c.ComercioID == com && c.CreditoID == cre && (c.TipoMovimientoID == 20 
            //                                                            || c.TipoMovimientoID == 13 
            //                                                            || c.TipoMovimientoID == 100)).ToList();
            List<CuentaCorriente> listCc = bl.Get<CuentaCorriente>(BaseID, c => c.EmpresaID == emp && c.ComercioID == com && c.CreditoID == cre ).ToList();
            if (listCc.Count > 0)
            {
                //ccID = Convert.ToInt32(listCc[0].CuentaCorrienteID);
                //CuentaCorriente ccAct = Mapper.Map<CuentaCorriente, CuentaCorriente>(listCc[0]);
                //ccAct.CreditoID = null;
                //bl.ActualizarCuentaCorriente(ccAct);

                foreach (CuentaCorriente cuo in listCc)
                {
                    ccID = Convert.ToInt32(cuo.CuentaCorrienteID);
                    CuentaCorriente ccAct = Mapper.Map<CuentaCorriente, CuentaCorriente>(cuo);
                    ccAct.CreditoID = null;
                    ccAct.CuotaID = null;
                    ccAct.CobranzaID = null;
                    bl.ActualizarCuentaCorriente(BaseID, ccAct);
                }

            }

            if (!RegCredito.Cuotas.Any(c => c.Cobranzas.Any()))
                bl.BorrarRangeTransaccional<Cuota>(regCredito.EmpresaID,regCredito.Cuotas.ToList());

            for (int i = 0;i < regCredito.Notas.Count ;i++ )
                bl.BorrarTransaccional<Nota>(BaseID, regCredito.Notas[i]);
                

            bl.BorrarTransaccional<Credito>(regCredito.EmpresaID,regCredito);
            ccs.Add(cc);
            bl.Grabar(regCredito.EmpresaID);
            List<Transmision> ltrans = new List<Transmision>();
          
            ltrans = bl.Transmision<CreditoAnulado>(ltrans, credAnul, bl.GetComercio(regCredito.EmpresaID), bl.pGlob.TransBajaCredito, bl.pGlob.UriCreditos);
            bl.GrabarTransmisiones(regCredito.EmpresaID, ltrans);
            MessageBox.Show(String.Format("El crédito {0} se ha anulado correctamente.", RegCredito.CreditoID), this.Text);
            btnAnula.Enabled = false;

         }

        private void FrmBajaCredito_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F9)
            {
                if(e.Shift)
                {
                    if(bl.LlevaM())
                    {
                        lblMor.Visible = true;
                        RecargarEmpYComercio(lblMor.Visible);
                    }
                }
            }
        }
    }
}
