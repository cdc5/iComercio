using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iComercio.Rest;
using iComercio.Models;
using iComercio.Delegados;
using iComercio.ViewModels;

namespace iComercio.Forms
{
    public partial class FrmAgregarSolicitudFondo : FRM
    {
        public FrmAgregarSolicitudFondo(Principal p, RestApi ra): base(p, ra)
        {
            InitializeComponent();
        }

        private void FrmAgregarSolicitudFondo_Load(object sender, EventArgs e)
        {
            tipoSolicitudComboBox.DataSource = bl.GetTiposSolicitud();
            tipoSolicitudComboBox.DisplayMember = "Nombre";
            conceptoFondosComboBox.DataSource = bl.GetConceptosFondos();
            conceptoFondosComboBox.DisplayMember = "Nombre";
        }

        private async void cmdAceptar_Click(object sender, EventArgs e)
        {
            
            SolicitudFondo sf = new SolicitudFondo();
            sf.Importe = System.Convert.ToDecimal(importeTextBox.Text);
            sf.EmpresaID = bl.pGlob.Empresa.EmpresaID;
            sf.Empresa = bl.pGlob.Empresa;
            sf.ComercioID = bl.pGlob.Comercio.ComercioID;
            sf.MonedaID = bl.pGlob.Peso.MonedaID;
            sf.Comercio = bl.pGlob.Comercio;
            sf.FechaPago = fechaPagoDateTimePicker.Value;
            sf.FechaRealizacion = DateTime.Now;
            sf.EstadoID = bl.pGlob.SolicitudFondoPendResolTesoreria.EstadoID;
            TipoSolicitud ts = (TipoSolicitud)tipoSolicitudComboBox.SelectedItem;
            ConceptoFondos cf = (ConceptoFondos)conceptoFondosComboBox.SelectedItem;
            sf.TipoSolicitudID = ts.TipoSolicitudID;
            sf.ConceptoFondosID = cf.ConceptoFondosID;
            sf.MedioDePagoID = cf.MedioDePagoID;
            bl.AgregarSolicitudesDeFondos(sf);
            sf = await bl.AgregarTransmisionSolicitudDeFondo(sf);
            this.Close();
            
       //     bl.TransmitirSolicitudDeFondo(s);
        }

        private void importeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Validar.SoloMoneda(e);
        }

        private void importeTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tipoSolicitudComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
