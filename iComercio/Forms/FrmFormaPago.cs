using System;                         ////convert, eventarg, eventhandler
using System.Collections.Generic;         //list<>
using System.Drawing;                  ///font , color
using System.Linq;                      // orderby()
using System.Windows.Forms;               //formWindowsState, listview, musearg, etc
using iComercio.Rest;                       //RestApi
using iComercio.Models;                     // modelos(cred, cuot, etc)

namespace iComercio.Forms
{
    public partial class FrmFormaPago : FRM
    {
        decimal ValorPago = 0;
        bool bEsPru = false;
        int nEmprePaga = 0;
        int nComerPaga = 0;
        int nCredPaga = 0;
        int nCuotaPaga = 0;
        int nCobraPaga = 0;
        int nDocumento = 0;
        
        string cDocumento = "";
        bool EsM;
        bool Grabado = false;
        decimal importeTarjeta;
        decimal importeEfectivo;
        decimal importeTotal;


        public FrmFormaPago()
        {
            InitializeComponent();
        }

        private void FrmFormaPago_Load(object sender, EventArgs e)
        {
            importeTarjeta = Convert.ToDecimal(txtTarjeta.Text);
            importeEfectivo = Convert.ToDecimal(txtEFectivo.Text);
            importeTotal = Convert.ToDecimal(txtTotal.Text);
        }
        public FrmFormaPago(Principal p, BusinessLayer bl, int nEmpre, int nComer, int nCred, int nCuot, int nCobr,
                            int nDoc, string cDoc, decimal ValorTotal, bool bPru)
            : base(p)
        {
            bl = new BusinessLayer();
            this.EsM = bPru;
            RecargarEmpYComercio(EsM);
            InitializeComponent();
            ValorPago = ValorTotal;
            nEmprePaga = nEmpre;
            nComerPaga = nComer;
            nCredPaga = nCred;
            nCuotaPaga = nCuot;
            nCobraPaga = nCobr;
            nDocumento = nDoc;
            cDocumento = cDoc;
            bEsPru = bPru;
            Configura_Inicio();
        }

        private void Configura_Inicio()
        {
            Configura_Controles();
            bAceptaFOrmaPago = false;
            txtEFectivo.Text = ValorPago.ToString("N2");
            txtTarjeta.Text = "0";
            txtTotal.Text = ValorPago.ToString("N2");

        }
        private void Configura_Controles()
        {
            Configura_Colores(bl.pGlob.Comercio.EmpresaID);
            Recorre_Formulario(this);
            this.BackColor = ColorBackColorFrm;
        }
        private void Calcula_Pago()
        {
            btnGrabar.Enabled = false;
            if (txtEFectivo.Text == "" || txtEFectivo.Text == null) return;
            if (txtTarjeta.Text == "" || txtTarjeta.Text == null) return;

            importeTarjeta = Convert.ToDecimal(txtTarjeta.Text);
            importeEfectivo = Convert.ToDecimal(txtEFectivo.Text);
            importeTotal = Convert.ToDecimal(txtTotal.Text);

            decimal nV = importeEfectivo + importeTarjeta;
            
            txtTotal.Text = nV.ToString();

            if (importeEfectivo + importeTarjeta == ValorPago)
            {
                btnGrabar.Enabled = true;
            }
            //else
            //{
            //    MessageBox.Show("El importe en efectivo más el importe en tarjeta debe ser igual al importe total");
            //}
        }

        private void txtEFectivo_KeyUp(object sender, KeyEventArgs e)
        {
            Calcula_Pago();
        }

        private void txtTarjeta_KeyUp(object sender, KeyEventArgs e)
        {
            Calcula_Pago();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            bAceptaFOrmaPago = false;
            this.Close();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            GrabarRecibo();
        }

        public void GrabarRecibo()
        {
            string Mens = "";
            if (importeEfectivo + importeTarjeta == ValorPago)
            {
                   Mens = String.Format("Se Registrará, una cobranza en" + Environment.NewLine + 
                                            " Efectivo por {0:00.00}, " + Environment.NewLine + 
                                            "   débito por {1:00.00}" + Environment.NewLine+ " ¿desea continuar?", 
                                        importeEfectivo, importeTarjeta);
                   DialogResult dr = MessageBox.Show(Mens, "Registro del pago", MessageBoxButtons.YesNo);
                   if (dr == System.Windows.Forms.DialogResult.Yes)
                   {
                       if (importeTarjeta > 0)
                       {
                           //CuentaCorriente cc;
                           bl.GrabarRecibo(Com, null, importeTarjeta, DateTime.Now, null, null, null, bl.pGlob.Provisorio,
                                           p.usu, false, null, null, null, bl.pGlob.TmCobPorDebito, nEmprePaga, nComerPaga,
                                           nCredPaga, nCuotaPaga, nCobraPaga);
                       }
                       Grabado = true;
                       this.Close();
                   }                
            }
            else
            {
                 Mens = String.Format(@"El importe en Efectivo por {0:00.00}, más el importe en débito por {1:00.00} 
                                            deben sumar {2:00.00}. El importe de {3:00.00} es incorrecto", 
                                            importeEfectivo, importeTarjeta,ValorPago, importeEfectivo+importeTarjeta);
                 MessageBox.Show(Mens, "Registro del pago", MessageBoxButtons.OK);
            }
        }

        private void FrmFormaPago_FormClosing(object sender, FormClosingEventArgs e)
        {
                if (btnGrabar.Enabled == false)
                {
                    MessageBox.Show("No puede ingresar un importe menor que el importe de pago");
                    e.Cancel = true;
                    return;
                }
                if (!Grabado)
                {
                   string Mens = String.Format("Se Registrará, una cobranza en Efectivo por {0:00.00}, y en débito por {1:00.00}, ¿desea continuar?", importeEfectivo, importeTarjeta);
                   DialogResult dr = MessageBox.Show(Mens, "Registro del pago", MessageBoxButtons.YesNo);
                   if (dr == System.Windows.Forms.DialogResult.Yes) 
                   {
                       GrabarRecibo();
                       e.Cancel = false;
                    }
                   else
                   {
                       e.Cancel = true;
                   }

                }
        }
    }
}
