using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iComercio.Models;
using iComercio.Rest;
using iComercio.Rest.RestModels;
using iComercio.Models;
using iComercio.Delegados;
using iComercio.ViewModels;
using iComercio.Auxiliar;
using Credin;

namespace iComercio.Forms
{
    public partial class frmTransmisiones : FRM
    {
        public event EventHandler<MensajeEventArgs> actualizarBarraDeEstado;
        public event EventHandler actualizarBarraDeEstadoListo;
        string queTransmito;
        List<String> Log = new List<string>();

        public frmTransmisiones()
        {
            InitializeComponent();
        }

        public frmTransmisiones(Principal p): base(p)
        {
            InitializeComponent();
            Inicializar();          
        }

        public frmTransmisiones(Principal p, BusinessLayer bl)
            : base(p, bl)
        {
            InitializeComponent();
            Inicializar();                
        }

        private void Inicializar()
        {
            RecargarEmpYComercio(false);
            Configura_Controles();
        }

        private void Configura_Controles()
        {
            this.BackColor = ColorBackColorFrm;
            Recorre_Formulario(this);
        }

        private void frmTransmisiones_Load(object sender, EventArgs e)
        {
            fitFormToScreen();
        }

        private void btnEnviarCDEF_Click(object sender, EventArgs e)
        {
            queTransmito = "CDEF";
            bg.RunWorkerAsync();           
        }

        private void btnEnviarRTEF_Click(object sender, EventArgs e)
        {
            queTransmito = "RTEF";
            bg.RunWorkerAsync();
        }


              private void btnEnviarREEF_Click(object sender, EventArgs e)
        {
            queTransmito = "REEF";
            bg.RunWorkerAsync();
        }

        private void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            if (queTransmito == "CDEF")
            {
                MensajeEventArgs me = new MensajeEventArgs("Transmitiedo Control Diario Entre Fechas " + dtpDesde.Value.ToShortDateString() +
                                                                    "-" + dtpHasta.Value.ToShortDateString() + "...Espere");
                this.Invoke(actualizarBarraDeEstado, this, me);
                Log.Add(me.mensaje);
                object transmitiendo = new object();
                bl.RealizarTransmisionesControlesDiarios(transmitiendo, dtpDesde.Value, dtpHasta.Value);
            }

            if (queTransmito == "REEF")
            {
                MensajeEventArgs me = new MensajeEventArgs("Retransmitiendo Erróneas Entre Fechas...Espere");
                this.Invoke(actualizarBarraDeEstado, this, me);
                Log.Add(me.mensaje);
                object transmitiendo = new object();
                bl.RetransmitirErroneas(Com,dtpDesdeErr.Value, dtpHastaErr.Value);
             //   bl.RealizarTransmisionesControlesDiarios(transmitiendo, dtpDesde.Value, dtpHasta.Value);
            }     
            
            if (queTransmito == "RTEF")
            {
                MensajeEventArgs me = new MensajeEventArgs("Retransmitiendo Todas Entre Fechas...Espere");
                this.Invoke(actualizarBarraDeEstado, this, me);
                Log.Add(me.mensaje);
                object transmitiendo = new object();
                bl.RetransmitirTodas(Com, dtpDesdeTod.Value, dtpHastaTod.Value);
             //   bl.RealizarTransmisionesControlesDiarios(transmitiendo, dtpDesde.Value, dtpHasta.Value);
            }           
            
        }
        
        private void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lbLog.Items.AddRange(Log.ToArray());
            MensajeEventArgs me = new MensajeEventArgs("Listo");
            this.Invoke(actualizarBarraDeEstado, this, me);
            lbLog.Items.Add(me.mensaje);
            queTransmito = "";
            Log.Clear();            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Log = bl.RevisarTransmisiones(Com, dtpRTD.Value, dtpRTH.Value);
            lbLog.Items.AddRange(Log.ToArray());
            Log.Clear();
            //lbLog.Items.AddRange(Log);
        }

        private void btnRestrablecer_Click(object sender, EventArgs e)
        {
            Log = bl.RestablecerTransRevisadasXSistema(Com, dtpRTD.Value, dtpRTH.Value);
            lbLog.Items.AddRange(Log.ToArray());
            Log.Clear();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Log = bl.ActualizarCuotasDesdeCobranzas(Com, dtpDesdeCob.Value, dtpHastaCob.Value);
            Log.AddRange(bl.ActualizarRefiCuotasDesdeCobranzas(Com, dtpDesdeCob.Value, dtpHastaCob.Value));
            lbLog.Items.AddRange(Log.ToArray());
            Log.Clear();
        }

       
        

      

       
    }
}
