using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iComercio.Models;
using iComercio.Auxiliares;

namespace iComercio.Forms
{
    public partial class frmCuentasBancariasCliente : FRM
    {
        CuentaBancariaCliente cbc;
        public CuentaBancariaCliente cbcSel;
        Banco banco;
        Estado estado;
        Cliente cli;
        CuentaBancariaCliente cbcN;

        public frmCuentasBancariasCliente()
        {
            InitializeComponent();
        }
        public frmCuentasBancariasCliente(Principal p,BusinessLayer bl,Cliente cli): base(p,bl)
        {
            InitializeComponent();
            ConfigurarControles();
            CargarBancos();
            CargarEstados();
            CargarCliente(cli);
        }

        private void ConfigurarControles()
        {
            btnModificarCuenta.Location = btnAgregarCuenta.Location;
        }

        private void CargarCuentasBancariasCliente(Cliente cli)
        {
            
        }

        private void CargarCliente(Cliente cli)
        {
            this.cli = cli;
            clienteBs.DataSource = cli;
            lbcbc.DataSource = cli.CuentasBancariasCliente.Where(c=>c.EstadoID != bl.pGlob.Eliminado.EstadoID).ToList();                        
        }
        
        private void CargarBancos()
        {
            Utilidades.CargarCombo(BancoComboBox,bl.Get<Banco>(),"Nombre","BancoID");
        }

        private void CargarEstados()
        {
            Utilidades.CargarCombo(cmbEstado, bl.GetEstadosGenerales(p.Emp.EmpresaID.Value), "Nombre", "EstadoID");
        }

        private void frmCuentasBancariasCliente_Load(object sender, EventArgs e)
        {
        }

        private void lbcbc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ListBox)sender).SelectedIndex != -1)
            {
                cbc = (CuentaBancariaCliente)lbcbc.SelectedItem;
                if (cbc != null)
                {
                    cbcbs.DataSource = cbc;
                    BancoComboBox.SelectedItem = ((List<Banco>)BancoComboBox.DataSource).Find(x=>x.BancoID == cbc.BancoID);
                    cmbEstado.SelectedItem = ((List<Estado>)cmbEstado.DataSource).Find(x => x.EstadoID == cbc.EstadoID);                     
                }
                Utilidades.HabilitarYMostrarControles(true, btnEliminarCuenta, btnModificarCuenta);
                Utilidades.HabilitarYMostrarControles(false, btnAgregarCuenta);
            }
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (cbc != null)
            {
                DialogResult dr = MessageBox.Show("Desea Eliminar la cuenta seleccionada","Advertencia",MessageBoxButtons.YesNo);
                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    bl.EliminarCuentaBancariaCliente(p.Emp, cbc);
                    bl.Transmision<Cliente>(cli, bl.pGlob.Comercio, bl.pGlob.TransAgregarCliente, bl.pGlob.UriClientes);
                    bl.Grabar();
                    CargarCliente(cli);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cli.CuentasBancariasCliente.Any(c => c.NumCuentaBancaria == numCuentaBancariaTextBox.Text))
            {
                MessageBox.Show("La cuenta ya se encuentra registrada");
            }
            else
            {
                cbcN.BancoID = banco.BancoID;
                cbcN.Alias = aliasTextBox.Text;
                cbcN.CBU = cbuTextBox.Text;
                cbcN.NumCuentaBancaria = numCuentaBancariaTextBox.Text;
                cbcN.Descripcion = descripcionTextBox.Text;
                cbcN.Documento = cli.Documento;
                cbcN.TipoDocumentoID = cli.TipoDocumentoID;
                cbcN.EstadoID = estado.EstadoID;
                cbcN.FechaAlta = fechaAltaDateTimePicker.Value;
                cbcN.MonedaID = bl.pGlob.Peso.MonedaID;
                cbcN.Notas = notasTextBox.Text;
                bl.Agregar<CuentaBancariaCliente>(cbcN);
                bl.Transmision<Cliente>(cli, bl.pGlob.Comercio, bl.pGlob.TransAgregarCliente, bl.pGlob.UriClientes);
                bl.Grabar();

                //cli.CuentasBancariasCliente.Add(cbcN);
                //bl.Actualizar<Cliente>(cli);
            }

            CargarCliente(cli);
            btnAgregarCuenta.Enabled = false;
           
        }

        private void btnSeleccionarCuenta_Click(object sender, EventArgs e)
        {
            if (cbc != null)
            {
                MessageBox.Show(String.Format("Se utilizará la cuenta:{0}", cbc.NumCuentaBancaria));
                cbcSel = cbc;
            }
                
            else
                MessageBox.Show("No se ha seleccionado ninguna cuenta");
            this.Close();
        }

        private void BancoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            banco = (Banco)BancoComboBox.SelectedItem;             
        }

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            estado = (Estado)cmbEstado.SelectedItem;
        }

        private void btnNueva_Click(object sender, EventArgs e)
        {
            Utilidades.HabilitarYMostrarControles(true, btnAgregarCuenta);
            Utilidades.HabilitarYMostrarControles(false, btnEliminarCuenta,btnModificarCuenta);
            lbcbc.SelectedIndex = -1;
            cbcN = new CuentaBancariaCliente();            
            cbcbs.DataSource = cbcN;            
        }

        private void btnModificarCuenta_Click(object sender, EventArgs e)
        {
            if (cbc != null)
            {
                cbc.BancoID = banco.BancoID;
                cbc.EstadoID = estado.EstadoID;
                bl.Actualizar<CuentaBancariaCliente>(cbc);
                bl.Transmision<Cliente>(cli, bl.pGlob.Comercio, bl.pGlob.TransAgregarCliente, bl.pGlob.UriClientes);
                bl.Grabar();
                CargarCliente(cli);
                MessageBox.Show(String.Format("Se Ha actualizado la cuenta: {0}", cbc.NumCuentaBancaria));
            }
            else
                MessageBox.Show("No se ha seleccionado ninguna cuenta");

        }
    }
}
