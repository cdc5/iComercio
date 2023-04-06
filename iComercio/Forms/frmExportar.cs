using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iComercio.Forms
{
    public partial class frmExportar : Form
    {
        Principal p;
        public frmExportar()
        {
            InitializeComponent();
        }

        private void frmExportar_Load(object sender, EventArgs e)
        {

        }
        public frmExportar(Principal _p, Color ColorBak, 
                                        Boolean bPlani = false
                                      , Boolean bCopiar = false
                                      , Boolean bImpresora = false
                                      , string cOtro = ""
                                        )
        {
            InitializeComponent();
            btnPlani.Visible = bPlani;
            btnPorta.Visible = bCopiar;
            btnImpresora.Visible = bImpresora;
            if (cOtro != "")
            {
                btnOtro.Visible = true;
                btnOtro.Text = cOtro;
            }
            else btnOtro.Visible = false;
            p = _p;
            this.BackColor = ColorBak;
        }

        private void btnPlani_Click(object sender, EventArgs e)
        {
            
            p.qExporto = "PL";
            this.Close();
        }

        private void btnPorta_Click(object sender, EventArgs e)
        {
            p.qExporto = "PP";
            this.Close();
        }

        private void btnImpresora_Click(object sender, EventArgs e)
        {
            p.qExporto = "PI";
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            p.qExporto = "";
            this.Close();
        }

        private void btnOtro_Click(object sender, EventArgs e)
        {
            p.qExporto = "OT";
            this.Close();

        }
    }
}
