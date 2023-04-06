using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iComercio.Delegados;

namespace iComercio.Forms
{
    public partial class frmBarraProgreso : FRM
    {
        bool bContinuo = false;
        
        public frmBarraProgreso(Principal p,string titulo, bool bContinuo) :base(p.Emp.EmpresaID.Value)
        {
            InitializeComponent();
            this.Text = titulo;
            this.lblProgreso.Text = titulo;
            this.Left = 500;
            this.Top = 400;
            this.BringToFront();
            this.bContinuo = bContinuo;
            //DesdeDondeViene.actualizarBarraDeEstadoEvent += FrmBarraProgreso_actualizarBarraDeEstadoEvent;
        }

        public void ActualizarBarraProgreso(int valor)
        {
            pb.Value = valor;                    
        }
       
        private void frmBarraProgreso_Load(object sender, EventArgs e)
        {
            if (bContinuo)
                pb.Style = ProgressBarStyle.Marquee;
            else
                pb.Style = ProgressBarStyle.Blocks;
        }

        private void FrmBarraProgreso_actualizarBarraDeEstadoEvent(object sender, MensajeEventArgs e)
        {
            pb.Value = e.ValorProgressBar;            
        }

        
    }
}
