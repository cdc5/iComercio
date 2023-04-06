using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using iComercio.Rest;
using iComercio.Rest.RestModels;
using iComercio.Models;
using iComercio.Delegados;
using iComercio.ViewModels;
using iComercio.Auxiliar;



namespace iComercio.Forms
{
    public partial class FrmSolicitarFondos : FRM
    {
       // public ActualizarBarraDeEstadoDelegado actualizarBarraDeEstadoDelegado;
      
        public event EventHandler<MensajeEventArgs> actualizarBarraDeEstado;
        public event EventHandler actualizarBarraDeEstadoListo;

        private DateTime fechaHasta = DateTime.Now;
        private DateTime fechaDesde;

        private BindingSource sfBindingSource = new BindingSource();

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private RestApi ra;

        public FrmSolicitarFondos()
        {
            InitializeComponent();
            RecargarEmpYComercio(false);
        }

        public FrmSolicitarFondos(Principal p, RestApi ra)
            : base(p, ra)
        {
            InitializeComponent();
            this.ra = ra;
            RecargarEmpYComercio(false);
        }

        private void FrmSolicitarFondos_Load(object sender, EventArgs e)
        {
            cmbEstado.DataSource = bl.GetEstados(es => es.TipoEstadoID == 6,null);
            cmbEstado.DisplayMember = "Nombre";
            cmbEstado.ValueMember = "EstadoID";
            fechaDesde = fechaHasta.AddDays(-bl.pGlob.Configuracion.solfonDiasParaAtras);
            CustomizeGrid(dgvSolicitudesFondos);
            Actualizar();
            
        }

        private  void button1_Click(object sender, EventArgs e)
        {
            BuscarSolicitudes();
        }

        private void BuscarSolicitudes()
        {
            BusinessLayer bla = new BusinessLayer();
            List<SolicitudFondo> sfs = bla.GetSolicitudesDeFondosYEnEstadoNoFinal(bl.pGlob.Comercio, fechaDesde, fechaHasta).ToList();
            sfBindingSource.DataSource = sfs;            
            sfBindingSource.ResetBindings(false);
            dgvSolicitudesFondos.DataSource = sfBindingSource;

            
        }

        private void AgregarBotonesSegunEstado(DataGridView dgv)  
        {

            foreach (DataGridViewRow dgr in dgv.Rows)
            {
                var item = (SolicitudFondo)dgr.DataBoundItem;
                if (item != null)
                {
                    if ( item.EstadoID == bl.pGlob.SolicitudFondoAutorizada.EstadoID 
                         &&  !bl.isSolicitudFondosConfirmadaEnReceptoria(item))
                    {
                        DataGridViewButtonCell btnCell = new DataGridViewButtonCell();
                        btnCell.Value = "Confirmar";
                        dgr.Cells["Confirmar"] = btnCell;
                    }
                    else if (item.EstadoID == bl.pGlob.SolicitudFondoConfirmada.EstadoID) 
                    {
                        DataGridViewButtonCell btnCell = new DataGridViewButtonCell();
                        btnCell.Value = "Ver OP";
                        dgr.Cells["OP"] = btnCell;
                    }
                }
            }
        }

        private void Actualizar()
        {
            Estado est = (Estado)cmbEstado.SelectedItem;
            ActualizarInfoObjetivos(bl.pGlob.Comercio, fechaDesde,fechaHasta, est);
            
        }

        private async void ActualizarInfoObjetivos(Comercio com, DateTime fechaDesde, DateTime fechaHasta,Estado est)
        {
            if (bl.pGlob.Configuracion.TransmisionHabilitada)
            {
                using (BusinessLayer bla = new BusinessLayer())
                {
                    bla.ra = ra;
                    MensajeEventArgs me = new MensajeEventArgs("Cargando");
                    actualizarBarraDeEstado(this, me);

                    SolicitarFondos sfvm = await bla.SolicitarFondos(com, fechaDesde, fechaHasta, null);
                    bla.CompararYActualizarSolicitudesFondos(com, fechaDesde, fechaHasta, sfvm.SolicitudesDeFondos);

                    infoObjetivosBindingSource.DataSource = sfvm.infoObjetivos;
                    //dgvSolicitudesFondos.DataSource = sfvm.SolicitudesDeFondos;
                    //object solfons = await ra.GetSolicitudesFondosAsync(com,fechaDesde,fechaHasta,est);
                }
            }
            BuscarSolicitudes();
            actualizarBarraDeEstadoListo(this, EventArgs.Empty);
            
        }

        
        private  void grbInfoObjetivos_Enter(object sender, EventArgs e)
        {
            
        }

        private void porcObjVentasLabel1_Click(object sender, EventArgs e)
        {
            
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmAgregarSolicitudFondo frmAsf = new FrmAgregarSolicitudFondo(p, bl.ra);
            frmAsf.ShowDialog();
            BuscarSolicitudes();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {           

            Actualizar();
        }

        private void objetivoVentasLabel1_Click(object sender, EventArgs e)
        {

        }

        private void grbVenta_Enter(object sender, EventArgs e)
        {

        }

        private void dtpFechaDesde_ValueChanged(object sender, EventArgs e)
        {

        }


        private void grbListaSol_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
                Actualizar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (bl.pGlob.Configuracion.TransmisionHabilitada)
                RealizarTransmisiones(p.transmitiendo);
        }

        private async void RealizarTransmisiones(object transmitiendo)
        {

            //bool result = await Task.Run(() => bl.RealizarTransmisiones(transmitiendo)); para .net 4.5.1
            bool result =  await Task.Factory.StartNew( () => bl.RealizarTransmisiones(transmitiendo,Emp.EmpresaID.Value), //para .net 4.0
                                                        CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default);
        }

        private void dgvSolicitudesFondos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.RowIndex > -1) && (e.ColumnIndex > -1))
            {
                DataGridView dgv = (DataGridView)sender;
                if ((dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].GetType().Equals(typeof(DataGridViewButtonCell))))
                {
                    DataGridViewButtonCell buttonCell =
                        (DataGridViewButtonCell)dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];

                    SolicitudFondo solfon = (SolicitudFondo)dgv.Rows[e.RowIndex].DataBoundItem;
                    SolicitudFondo sf = bl.GetSolicitudesDeFondos(s => s.SolicitudFondoID == solfon.SolicitudFondoID
                                        && s.EmpresaID == solfon.EmpresaID && s.ComercioID == solfon.ComercioID).FirstOrDefault();
                    if (e.ColumnIndex == dgv.Columns["Confirmar"].Index)
                    {
                        log.Info("Enviando Confirmacion de solicitud:" + sf.SolicitudFondoIDRemoto);
                        bl.ActualizarSolicitudDeFondos(sf);
                        bl.TransmisionConfirmarSolicitudDeFondo(sf);
                        bl.ImputarSolicitudFondoACuentaCorriente(sf);
                    }
                    else if (e.ColumnIndex == dgv.Columns["OP"].Index)
                    {
                        bl.VisualizarOP(sf);
                    }
                }
                BuscarSolicitudes();
            }      
        }

        private void CustomizeGrid(DataGridView dgv)
        {
            CustomizeColumns(dgv);
        }

        private void CustomizeColumns(DataGridView dgv)
        {
            dgv.AutoGenerateColumns = false;
            //DataGridViewDisableButtonColumn acciones = new DataGridViewDisableButtonColumn();
            //DataGridViewButtonColumn acciones = new DataGridViewButtonColumn();
            DataGridViewTextBoxColumn acciones = new DataGridViewTextBoxColumn();
            acciones.Name = "Confirmar";
            dgv.Columns.Add(acciones);
            DataGridViewTextBoxColumn op = new DataGridViewTextBoxColumn();
            op.Name = "OP";
            dgv.Columns.Add(op);
            
            /* Ancho de columna */
            dgv.Columns[0].Width = 50;
            dgv.Columns[1].Width = 80;
            dgv.Columns[2].Width = 100;
            dgv.Columns[3].Width = 100;
            dgv.Columns[4].Width = 150;
            dgv.Columns[5].Width = 150;
            dgv.Columns[6].Width = 100;
            dgv.Columns[7].Width = 100;
            dgv.Columns[8].Width = 200;
            dgv.Columns[9].Width = 100;
            dgv.Columns[10].Width = 100;

        }

        private void dgvSolicitudesFondos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            AgregarBotonesSegunEstado(dgvSolicitudesFondos);
        }

        private void dgvSolicitudesFondos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void grbValoresARendir_Enter(object sender, EventArgs e)
        {

        }

        private void grbDias_Enter(object sender, EventArgs e)
        {

        }

        private void grbCobranzas_Enter(object sender, EventArgs e)
        {

        }

        private void btnEliminarOP_Click(object sender, EventArgs e)
        {
            
        }

        

        //Esto tendría que funcionar pero por algun otro evento que se tiene que cargar antes o algo no esta funcionando, no importa, seguir intentandolo mas adelante
   /*     private void dgvSolicitudesFondos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Compare the column to the column you want to format
            if (this.dgvSolicitudesFondos.Columns[e.ColumnIndex].Name == "Acciones")
            {
                
                //get the IChessitem you are currently binding, using the index of the current row to access the datasource
                SolicitudFondo item = (SolicitudFondo)this.dgvSolicitudesFondos.Rows[e.RowIndex].DataBoundItem;
                //check the condition
                try 
                {

                    if (item != null)
                    { 

                        //if (item.estadoid == bl.pglob.solicitudfondoautorizada.estadoid)
                        //    {
                                var btnCell = new DataGridViewButtonCell();
                                btnCell.Value = "Boton" + e.RowIndex;
                                this.dgvSolicitudesFondos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = null;
                                this.dgvSolicitudesFondos.Rows[e.RowIndex].Cells[e.ColumnIndex] = new DataGridViewButtonCell(); 
                                //e.CellStyle.BackColor = Color.Green;
                            //}
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }*/

      

       
    }
}
