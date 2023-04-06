using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iComercio.Rest;
using iComercio.Rest.RestModels;
using iComercio.Models;
using iComercio.Delegados;
using iComercio.ViewModels;
using iComercio.Auxiliar;
using Credin;


namespace iComercio.Forms
{
    public partial class frmABMProveedoresSucursales : FRM
    {
        private RestApi ra;
        private ProveedorSucursal suc = new ProveedorSucursal();
        private Proveedor prov;
        private bool bActualiza;
        private Pais pais;
        private Provincia provincia;
        private Localidad localidad;

        private bool bPasa;

        public frmABMProveedoresSucursales()
        {
            InitializeComponent();
        }


        public frmABMProveedoresSucursales(Principal p,BusinessLayer bl,Proveedor prov)
            : base(p, bl.ra)
        {
            InitializeComponent();
            this.ra = bl.ra;
            this.bl = bl;
            this.prov = prov;
            suc.ProveedorID = prov.ProveedorID;
            proveedorSucursalBindingSource.DataSource = suc;

            grbProveedor.Text = prov.RazonSocial;
        }

        public frmABMProveedoresSucursales(Principal p, BusinessLayer bl, ProveedorSucursal suc)
            : base(p, bl.ra)
        {
            InitializeComponent();
            this.ra = bl.ra;
            this.suc = suc;
            this.bl = bl;
            this.bActualiza = true;
            proveedorSucursalBindingSource.DataSource = bl.GetProveedorSucursales(s=>s.ProveedorID == suc.ProveedorID 
                                                                                  && s.ProveedorSucursalID == suc.ProveedorSucursalID).SingleOrDefault();
        }

 

        private void frmABMProveedores_Load(object sender, EventArgs e)
        {
            paisComboBox.DataSource = bl.GetPaises();
            
        }
        private void ValidoParaGrabar()
        {
            //string micadena;

            if (nombreTextBox.Text == "")
            {
                bPasa = false;
                MessageBox.Show("El nombre no puede quedar vacio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            if (mail1TextBox.Text != "")
            {
                if (mail1TextBox.Text.IndexOf("@") == -1)
                {
                    bPasa = false;
                    MessageBox.Show("El mail está mal", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

            }
            if (mail2TextBox.Text != "")
            {
                if (mail2TextBox.Text.IndexOf("@") == -1)
                {
                    bPasa = false;
                    MessageBox.Show("El mail está mal", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

            }
        }
        private void btnGrabar_Click(object sender, EventArgs e)
        {

            bPasa = true;
            ValidoParaGrabar();
            if (bPasa)
            {
                suc.PaisID = pais.PaisID;
                suc.ProvinciaID = provincia.ProvinciaID;
                suc.LocalidadID = localidad.LocalidadID;

                if (!bActualiza)
                {
                    suc.EstadoID = bl.pGlob.ProveedorInicial.EstadoID;
                    bl.AgregaProveedorSucursal(suc);
                    bl.TransmisionAgregarProveedorSucursal(suc, bl.pGlob.Comercio);
                    Alertas.MensajeOKOnly(Properties.Resources.SucursalAgregada, Properties.Resources.SucursalAgregadaTitulo);
                    bActualiza = true;
                }
                else
                {
                    bl.ActualizarProveedorSucursal(suc);
                    bl.TransmisionActualizarProveedorSucursal(suc, bl.pGlob.Comercio);
                    Alertas.MensajeOKOnly(Properties.Resources.SucursalModificada, Properties.Resources.SucursalModificadaTitulo);
                }
                this.Close();
            }
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Alertas.AlertaDeEliminacion())
            {
                bl.BorrarProveedorSucursalLogico(suc);
                bl.TransmisionEliminarProveedorSucursal(suc, bl.pGlob.Comercio);
                Alertas.MensajeOKOnly(Properties.Resources.SucursalEliminada, Properties.Resources.SucursalEliminadaTitulo);
                bActualiza = false;
                this.Close();
            }
        }

        private void paisComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            pais = (Pais)paisComboBox.SelectedItem;
            provinciaComboBox.DataSource = null;
            localidadComboBox.DataSource = null;
            if (pais != null)
                Utilidades.CargarCombo(provinciaComboBox, pais.Provincias, "Nombre", "ProvinciaID",0);
        }

        private void provinciaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            provincia = (Provincia)provinciaComboBox.SelectedItem;
            localidadComboBox.DataSource = null;
            if (provincia != null)
                Utilidades.CargarCombo(localidadComboBox, provincia.Localidades, "Nombre", "ProvinciaID",0);
        }

        private void localidadComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            localidad = (Localidad)localidadComboBox.SelectedItem;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CerrarConMensajeDeAdvertencia();
        }

        private void mail2Label_Click(object sender, EventArgs e)
        {

        }

        private void telefono2TextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void telefono1TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Formato.Solonumeros(e, true);
        }

        private void telefono2TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Formato.Solonumeros(e, true);
        }

       
        

       

        
    }
}
