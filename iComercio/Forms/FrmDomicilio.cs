using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using iComercio.Models;
using Credin;


//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
//using System.Data.Entity;
//using iComercio.DAL;
//using iComercio.Rest;
//using iComercio.Delegados;
//using iComercio.ViewModels;
//using iComercio.Auxiliar;
//using System.Globalization;

namespace iComercio.Forms
{
    public partial class FrmDomicilio : FRM                                                         //**edu**
    {

        bool bEsPru = false;

        //private ParametrosGlobales pGlob { get; set; }

        //private RestApi ra;
        
        string dondeVengo = "";
        string queGrabo = "";
        int DomID = 0;
        Domicilio regDomicilio;
        Cliente cli;
        //bool EsM = false;
        public bool grabo = false;
        
        BindingSource provinciasBs = new BindingSource();
        BindingSource localidadesBs;

        public FrmDomicilio()
        {
            InitializeComponent();
        }

        private void FrmDomicilio_Load(object sender, EventArgs e)
        {

        }
        public FrmDomicilio(Principal p, BusinessLayer bl,  int Docu, string Nomb, string CodDocu, string deDondeVengo, 
                            string cGraboNM, int DomiID, Cliente cli, bool EsM)
            : base(p)
        {
            InitializeComponent();

            dondeVengo = deDondeVengo;
            queGrabo = cGraboNM;
            if (queGrabo == "M")
            {
                lblCartel.Text = "Modificar domicilio";
                btnBorrar.Visible = true;
            }
            else
            {    
                lblCartel.Text = "Nuevo domicilio";
                btnBorrar.Visible = false;
            }
            DomID = DomiID;

            this.bl = bl;
            this.cli = cli;
            bEsPru = EsM;
            RecargarEmpYComercio(false); //ARREGLAR
            Configura_Inicio();
            lblDomDocu.Text = Docu.ToString();
            lblDomCodDocu.Text = CodDocu.ToString();
            lblDomNomb.Text = Nomb.ToString();
            btnBorrar.Visible = false;
            if (queGrabo == "M") Carga_Domicilio();

            
        }

        private void Carga_Domicilio()
        {
            regDomicilio = bl.GetByID<Domicilio>(BaseID,DomID);
            if (regDomicilio == null) return;
            Localidad regLocalidad;
            txtCalle.Text = regDomicilio.Direccion;
            txtNro.Text = regDomicilio.Numero;
            txtPiso.Text = regDomicilio.Piso;
            txtDpto.Text = regDomicilio.Departamento;
            txtComplemento.Text = regDomicilio.Complemento;
            txtNotas.Text = regDomicilio.NotasDomicilio;
            if (regDomicilio.LocalidadID != null)                       //ACA hay que cambiar
            {
                regLocalidad = bl.Get<Localidad>(BaseID,l => l.LocalidadID == regDomicilio.LocalidadID).FirstOrDefault();
                if (regLocalidad != null)
                {
                    Busca_En_Combo(cmbProvincia, regLocalidad.ProvinciaID.ToString());
                    Busca_En_Combo(cmbLocalidad, regLocalidad.LocalidadID.ToString());
                    if(regLocalidad.CodPostal!=null) //edu nvo002
                    {
                        txtCP.Text = regLocalidad.CodPostal;
                    }
                }
            }
            cmbEstado.Visible = true;
            lblEstado.Visible = true;
            Busca_En_Combo(cmbEstado, regDomicilio.EstadoID.ToString());
            btnBorrar.Visible = true;
        }
        private void Borra_Domicilios()
        {
            regDomicilio.EstadoID = (int)bl.pGlob.Eliminado.EstadoID;
            bl.Actualizar<Domicilio>(regDomicilio.EmpresaID.Value,regDomicilio);
            this.Close();
        }
        private void Graba_Domicilios()
        {
            Localidad loc = (Localidad) cmbLocalidad.SelectedItem;
            if(queGrabo=="N")
            {
                regDomicilio = new Domicilio();
                regDomicilio.Documento = Convert.ToInt32(lblDomDocu.Text);
                regDomicilio.TipoDocumentoID = lblDomCodDocu.Text;
                if (dondeVengo == "PARTICULAR") regDomicilio.ClaseDatoID = bl.pGlob.DatoCliente.ClaseDatoID; 
                                                else regDomicilio.ClaseDatoID=bl.pGlob.DatoEmpresa.ClaseDatoID;
            }
            regDomicilio.EmpresaID = BaseID;
            regDomicilio.ComercioID = ComID;
            regDomicilio.Direccion = txtCalle.Text;
            if (txtNro.Text != "0") regDomicilio.Numero = txtNro.Text; else regDomicilio.Numero = null;
            if (txtPiso.Text != "0") regDomicilio.Piso = txtPiso.Text; else regDomicilio.Piso = null;
            regDomicilio.Departamento = txtDpto.Text;
            regDomicilio.Complemento = txtComplemento.Text;
            regDomicilio.NotasDomicilio = txtNotas.Text;
            regDomicilio.LocalidadID = (int)cmbLocalidad.SelectedValue;
            regDomicilio.ProvinciaID = (int)cmbProvincia.SelectedValue;
            regDomicilio.UsuarioID = p.usu.UsuarioID;
            regDomicilio.Fecha = DateTime.Now;
            regDomicilio.PcComer = System.Environment.MachineName;
            regDomicilio.PaisId = bl.pGlob.Argentina.PaisID;
            
            if (queGrabo == "N")
            {
                regDomicilio.EstadoID = (int)bl.pGlob.Vigente.EstadoID;
                bl.Agregar<Domicilio>(regDomicilio.EmpresaID.Value, regDomicilio);
            }
            else
            {
                regDomicilio.EstadoID = (int)cmbEstado.SelectedValue; // (int)bl.pGlob.Vigente.EstadoID;
                bl.Actualizar<Domicilio>(regDomicilio.EmpresaID.Value, regDomicilio);
            }

            /* Agrego los codigos postales temporalmente mediante las receptorias y comercios hasta que estén todos cargados, o hasta que los cargue
             * en la base todos por afuera
             */
            if (loc != null &&  ComID == bl.pGlob.ComercioID )  //ARREGLAT
            {
                loc.CodPostal = txtCP.Text;
                bl.Actualizar<Localidad>(regDomicilio.EmpresaID.Value, loc);
            }                

            this.Close();
        }

        private bool Valida_Domicilios()
        {
            if(txtCalle.Text=="")
            {
                MessageBox.Show("El dato no puede quedar vacio", "Domicilios");
                txtCalle.Focus();
                return false;
            }
            if (txtCP.Text == "")
            {
                MessageBox.Show("El dato no puede quedar vacio", "Domicilios");
                txtCP.Focus();
                return false;
            }
            if (cmbProvincia.SelectedIndex==-1)
            {
                MessageBox.Show("El dato no puede quedar vacio", "Domicilios");
                cmbProvincia.Focus();
                return false;
            }
            if (cmbLocalidad.SelectedIndex == -1)
            {
                MessageBox.Show("El dato no puede quedar vacio", "Domicilios");
                cmbLocalidad.Focus();
                return false;
            }
            
            return true;
        }
        private void Configura_Inicio()
        {
            provinciasBs.DataSource = bl.Get<Provincia>(BaseID,null, null, "");
            localidadesBs = new BindingSource(provinciasBs, "Localidades");

            Utilidades.CargarCombo(cmbProvincia, provinciasBs, "Nombre", "ProvinciaID");
            Utilidades.CargarCombo(cmbLocalidad, localidadesBs, "Nombre", "LocalidadID");
            int nEstID = 18;                                                            // aca buscar el estado general
            Utilidades.CargarCombo(cmbEstado, bl.Get<Estado>(BaseID,e => e.TipoEstadoID == nEstID
                                    && e.EstadoID != bl.pGlob.Eliminado.EstadoID).ToList(), "Nombre", "EstadoID");
            Configura_Controles();

            Limpia();
        }
        private void Configura_Controles()
        {
            Configura_Colores(bl.pGlob.Comercio.EmpresaID);
            Recorre_Formulario(this);
            this.BackColor = ColorBackColorFrm;

            foreach (Control c in this.Controls)
            {
                foreach (Control childc in c.Controls)
                {
                    if (childc is TextBox)
                    {
                        childc.KeyPress += Txt_PasaConEnter_KeyPress;
                    }
                    if (childc is ComboBox)
                    {
                        childc.KeyPress += Txt_PasaConEnter_KeyPress;
                    }

                }
            }

            //txtNro.KeyPress += KeyPress_Solonumeros;
            //txtNro.Leave += new EventHandler(DejaTxtNum);
            
            //txtPiso.KeyPress += KeyPress_Solonumeros;
            //txtPiso.Leave += new EventHandler(DejaTxtNum);

        }
        private void Limpia()
        {
            txtCalle.Text = "";
            txtNro.Text = "0";
            txtPiso.Text = "";
            txtDpto.Text = "";
            txtComplemento.Text = "";
            txtNotas.Text = "";
            txtCP.Text = "";  // edu 002
            cmbProvincia.SelectedIndex = -1;
            cmbLocalidad.SelectedIndex = -1;
            cmbEstado.Visible = false;
            lblEstado.Visible = false;
            Busca_En_Combo(cmbEstado, bl.pGlob.Vigente.TipoEstadoID.ToString());
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (txtCalle.Text != "")
            { CerrarConMensajeDeAdvertencia(); }
            else { this.Close(); }
        }
        private void Graba_Domicilios_Pru()
        {
            if(bl.LlevaM())
            {
                if(queGrabo == "N")
                {
                    int nDocumento = Convert.ToInt32(lblDomDocu.Text);
                    string cTipoDocumentoID = lblDomCodDocu.Text;
                    Cliente cli = bl.dalPrueba.Get<Cliente>(c => c.Documento == nDocumento && c.TipoDocumentoID == cTipoDocumentoID).FirstOrDefault();
                    if(cli != null)
                    {
                        RecargarEmpYComercio(true);
                        Graba_Domicilios();
                    }
                }
            }
        }
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (Valida_Domicilios())
            {
                Graba_Domicilios();
                Graba_Domicilios_Pru();
                grabo = true;
            }
                
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            Borra_Domicilios();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
