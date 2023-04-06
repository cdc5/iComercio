using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Credin;
using iComercio.Models;
using System.IO;

namespace iComercio.Forms
{
    public partial class frmClienteNVO : FRM
    {
        bool bGrabo = false;
        bool bGraboPru = false;
        BindingSource profesionesBs = new BindingSource();
        BindingSource complementoBs;
        Cliente regCliente = null;
        string cQueHago;
        int nDocuBusca;
        string cDocuBusca;
        Color backColorList = Color.White;
        int nRDP = 0;
        int nRDL = 0;
        int nRTP = 0;
        int nRTL = 0;
        int nRM = 0;
        bool EsMM = false;
        public frmClienteNVO(Principal p, string cQueHace, int nDocu, string cDocu, bool bEsPru):base(p)
        {
            InitializeComponent();
            EsMM = bEsPru;
            cQueHago = cQueHace;
            Configura_Inicio();
            nDocuBusca = nDocu;
            cDocuBusca = cDocu;
            if(cQueHago == "M")
            {

                txtBuscaDoc.Text = nDocu.ToString();
                Busca_En_Combo(cmbTipoDni, cDocu);
                
                if (nDocu == 0)
                {
                    cmbTipoDni.SelectedIndex = 1;
                    txtBuscaDoc.Select();
                    txtBuscaDoc.Focus();
                }
                else
                {
                    BuscaPrimero();
                    txtCliApellido.Select();
                    txtCliApellido.Focus();
                }
            }
            else if(cQueHago == "N")
            {
                if (nDocuBusca > 0)
                {
                    txtBuscaDoc.Text = nDocu.ToString();
                    Busca_En_Combo(cmbTipoDni, cDocu);
                    BuscaPrimero();
                    txtCliApellido.Select();
                    txtCliApellido.Focus();
                }
                else
                {
                    txtBuscaDoc.Select();
                    txtBuscaDoc.Focus();
                }
            }

        }

        private void Busca_Cliente(int nDocu, string cDocu)
        {
            if (nDocu == 0)
            {
                txtBuscaDoc.Focus();
                return;
            }
            bl = new BusinessLayer();
            regCliente = bl.Get<Cliente>(c => c.Documento == nDocu && c.TipoDocumentoID == cDocu).FirstOrDefault();
            if (regCliente != null)

            {
                LlenaDatos_cliente();
            }
        }

        private void LlenaDatos_cliente()
        {
            if (regCliente == null) return;

            decimal nTmp1 = 0;
            txtCliNombre.Text = regCliente.Nombre;
            txtCliApellido.Text = regCliente.Apellido;
            if (regCliente.FechaNacimiento != null)
            {
                TxtCliNaci.Value = (DateTime)regCliente.FechaNacimiento;            //Convert.ToDateTime
                int nAnos = Que_Edad_Tiene(TxtCliNaci.Value, DateTime.Now);
                lblEdad.Text = nAnos.ToString() + " años";
            }
            if (regCliente.Profesion != null && regCliente.Profesion.ProfesionPadreID != null)
                Busca_En_Combo(cmbProfesion, regCliente.Profesion.ProfesionPadreID);
            if (regCliente.Profesion != null && regCliente.Profesion.ProfesionID != null)
                Busca_En_Combo(cmbComplemento, regCliente.Profesion.ProfesionID);
            if (regCliente.SexoID != null)
                Busca_En_Combo(cmbCliSexo, regCliente.SexoID);
            if (regCliente.TipoComoConocioID != null)
                Busca_En_Combo(cmbCliConocio, regCliente.TipoComoConocioID);

            if (regCliente.Sueldo != null) nTmp1 = (decimal)regCliente.Sueldo; else nTmp1 = 0;
            txtSueldo.Text = nTmp1.ToString("N2");
            txtEmpresa.Text = regCliente.EmpresaLaboral;
            txtLegajo.Text = regCliente.Legajo;
            txtCuit.Text = regCliente.Cuit;
            btnDomiModificar.Enabled = false;
            btnDomiModificarL.Enabled = false;
            btnTelModi.Enabled = false;
            btnTelModiL.Enabled = false;

            LLenaDatosDomicilio(1, gridDomi);
            LLenaDatosDomicilio(2, gridDomiL);
            LlenaDatosTelefono(1, gridTelf);
            LlenaDatosTelefono(2, gridTelfL);
            LlenaDatosMail();
            picFoto.Image = bl.BuscarFotosDni(txtBuscaDoc.Text); //;(txtBuscaDoc.Text, ref rutasFoto);
            //LlenaImagenes();

            //CambiaBotones(true);
            BtnBusca.Text = "Otro";
            //lblCliExiste.Text = "SI";
            panelBuscar.Enabled = false;
            Pone_Enable(true);
            tabla.SelectTab(0); // ("tabDatos");
            //lblTit.Text = "Datos personales";
            txtCliApellido.Focus();

        }

        private void Configura_Inicio()
        {
            if (cQueHago == "M")
            {
                this.Text = "Modificar datos del cliente";
            }else
            {
                this.Text = "Ingresar nuevo cliente";
            }
            //bl = new BusinessLayer();
            lblMor.Visible = EsMM;
            RecargarEmpYComercio(false); //dEDUSACA
            Configura_Colores(bl.pGlob.Comercio.EmpresaID);
            Recorre_Formulario(this);
            this.BackColor = ColorBackColorFrm;
            Utilidades.CargarCombo(cmbTipoDni, bl.GetTiposDocumento().ToList(), "TipoDocumentoID", "TipoDocumentoID");
            Configura_listas();
            Limpia();
            Configura_Controles();
            txtBuscaDoc.Text = "0";
            cmbTipoDni.SelectedIndex = 1;
            Pone_Enable(false);
        }

        private void Pone_Enable(bool p)
        {
            panelDomi.Enabled = p;
            panelTel.Enabled = p;
            panelMail.Enabled = p;
            panelDatos.Enabled = p;
        }

        private void Configura_Controles()
        {
            profesionesBs.DataSource = bl.GetProfesionesPadres(BaseID, null, null, "ProfesionPadre");
            complementoBs = new BindingSource(profesionesBs, "SubProfesiones");
            Utilidades.CargarCombo(cmbTipoDni, bl.GetTiposDocumento().ToList(), "TipoDocumentoID", "TipoDocumentoID");
            Utilidades.CargarCombo(cmbProfesion, profesionesBs, "Nombre", "ProfesionID");
            Utilidades.CargarCombo(cmbComplemento, complementoBs, "Nombre", "ProfesionID");
            Utilidades.CargarCombo(cmbCliSexo, bl.GetSexos().ToList(), "Nombre", "SexoID");
            Utilidades.CargarCombo(cmbCliConocio, bl.GetTiposComoConocio().ToList(), "Nombre", "TipoComoConocioID");
            cmbCliConocio.SelectedIndex = 0;
            Asigna_Poder_Mover(panelDomicilio02);
            Centrar_Control(this, panelDomicilio02);
            Asigna_Poder_Mover(panelTelefono02);
            Centrar_Control(this, panelTelefono02);
            Asigna_Poder_Mover(panelMail02);
            Centrar_Control(this, panelMail02);
            BindingSource provinciasBs = new BindingSource();
            BindingSource localidadesBs;

            provinciasBs.DataSource = bl.Get<Provincia>(BaseID, null, null, "");
            localidadesBs = new BindingSource(provinciasBs, "Localidades");

            Utilidades.CargarCombo(cmbDomProv, provinciasBs, "Nombre", "ProvinciaID");
            Utilidades.CargarCombo(cmbDomLoc, localidadesBs, "Nombre", "LocalidadID");
            int nEstID = 18;                                                            // aca buscar el estado general
            Utilidades.CargarCombo(cmbDomEst, bl.Get<Estado>(BaseID, e => e.TipoEstadoID == nEstID
                                    && e.EstadoID != bl.pGlob.Eliminado.EstadoID).ToList(), "Nombre", "EstadoID");
            Utilidades.CargarCombo(cmbTelEstado, bl.Get<Estado>(BaseID, e => e.TipoEstadoID == nEstID
                                    && e.EstadoID != bl.pGlob.Eliminado.EstadoID).ToList(), "Nombre", "EstadoID");

            Utilidades.CargarCombo(cmbMailEstado, bl.Get<Estado>(BaseID, e => e.TipoEstadoID == nEstID
                                    && e.EstadoID != bl.pGlob.Eliminado.EstadoID).ToList(), "Nombre", "EstadoID");

            bGrabo = false;
            bGraboPru = false;
        }

        private void Limpia()
        {
            bGrabo = false;
            bGraboPru = false;
            panelDomicilio02.Visible = false;
            panelTelefono02.Visible = false;
            panelMail02.Visible = false;
            lblSombra.Visible = false;
            
            nRDP = 0;
            nRDL = 0;
            nRTP = 0;
            nRTL = 0;
            nRM = 0;
            picFoto.Image = null;
            LimpiaPestañas(true);

            //throw new NotImplementedException();
        }
        private void MuestraFoto(string cImagen)
        {
            if (File.Exists(cImagen))
            {
                if (new FileInfo(cImagen).Length != 0)
                {
                    Image img;
                    using (var bmpTemp = new Bitmap(cImagen))
                    {
                        img = new Bitmap(bmpTemp);
                        picFoto.Image = img;
                    }
                }
            }
        }
        private void LimpiaPestañas(bool bPersona = false)
        {
            if (bPersona) LimpiaPestaña(tabDatos);
            LimpiaPestaña(tabDomi);
            LimpiaPestaña(tabTel);
            LimpiaPestaña(tabMail);

        }
        private void LimpiaPestaña(Control ctr)
        {
            Limpia_controles(ctr);
        }
        private void Configura_listas()
        {
            Configura_Grid(gridDomi);
            Configura_Grid(gridDomiL);
            Configura_GridTel(gridTelf);
            Configura_GridTel(gridTelfL);
            ConfiguraMail();
            //throw new NotImplementedException();
        }

        private int Que_Edad_Tiene(DateTime fNaci, DateTime fHoy)
        {
            int nAnos = fHoy.Year - fNaci.Year;
            DateTime fNva = Convert.ToDateTime(fNaci.Day + "/" + fNaci.Month + "/" + fHoy.Year);
            if (fNva > fHoy) nAnos--;
            return nAnos;
        }

        private void frmClienteNVO_Load(object sender, EventArgs e)
        {
            Recorre_Formularios(this);
            //this.WindowState = FormWindowState.Normal;
        }

        private void Configura_GridTel(DataGridView grid)
        {
            int nCol = 0;
            GridConfigInicio(grid, 6);

            GridAgregarCol(grid, nCol, "Fecha", 70, "I"); nCol++; //0
            GridAgregarCol(grid, nCol, "Cod área", 70, "D"); nCol++; //1
            GridAgregarCol(grid, nCol, "Número", 150, "D"); nCol++; //2
            GridAgregarCol(grid, nCol, "Celular", 40, "C"); nCol++; //2
            GridAgregarCol(grid, nCol, "Notas", 400, "I"); nCol++; //3
            GridAgregarCol(grid, nCol, "", 0, "I"); nCol++; //4
            grid.Visible = true;
            GridConfigFinal(grid, Color.DarkGray, 8, FontStyle.Regular);

        }
        private void ConfiguraMail()
        {
            int nCol = 0;
            GridConfigInicio(gridMail, 4);

            GridAgregarCol(gridMail, nCol, "Fecha", 70, "I"); nCol++; //0
            GridAgregarCol(gridMail, nCol, "Mail", 250, "I"); nCol++; //1
            GridAgregarCol(gridMail, nCol, "Notas", 250, "I"); nCol++; //2
            gridMail.Visible = true;
            GridConfigFinal(gridMail, Color.DarkGray, 8, FontStyle.Regular);
        }
        private void Configura_Grid(DataGridView grid)
        {
            int nCol = 0;
            GridConfigInicio(grid, 13);

            GridAgregarCol(grid, nCol, "Fecha", 65, "I"); nCol++; //0
            GridAgregarCol(grid, nCol, "Calle", 180, "I"); nCol++; //1
            GridAgregarCol(grid, nCol, "Nro", 40, "D"); nCol++; //2
            GridAgregarCol(grid, nCol, "Dpo", 40, "I"); nCol++; //3
            GridAgregarCol(grid, nCol, "Piso", 40, "D"); nCol++; //4
            GridAgregarCol(grid, nCol, "Provincia", 100, "I"); nCol++; //5
            GridAgregarCol(grid, nCol, "Localidad", 150, "I"); nCol++; //6
            GridAgregarCol(grid, nCol, "Cod post", 60, "I"); nCol++; //7
            GridAgregarCol(grid, nCol, "Complemento", 150, "I"); nCol++; //8
            GridAgregarCol(grid, nCol, "Notas", 200, "I"); nCol++; //9

            GridAgregarCol(grid, nCol, "", 0, "I"); nCol++; //10
            GridAgregarCol(grid, nCol, "", 0, "I"); nCol++; //11
            GridAgregarCol(grid, nCol, "", 0, "I"); nCol++; //12

            grid.Visible = true;
            GridConfigFinal(grid, Color.DarkGray, 8, FontStyle.Regular);

        }
        private void EstaCliente()
        {
            bl = new BusinessLayer();
            regCliente = bl.Get<Cliente>(c => c.Documento == nDocuBusca && c.TipoDocumentoID == cDocuBusca).FirstOrDefault();
            if (regCliente != null)
            {
                MessageBox.Show("El documento ya existe","Clientes");
                return;
            }
            panelDatos.Enabled = true;
            panelBuscar.Enabled = false;
            BtnBusca.Text = "Otro";
            txtCliApellido.Focus();


        }
        private void BuscaPrimero()
        {
            nDocuBusca = Convert.ToInt32(txtBuscaDoc.Text);
            cDocuBusca = cmbTipoDni.Text;
            if (BtnBusca.Text == "Buscar")
            {
                if (cQueHago == "N")
                {
                    if (txtBuscaDoc.Text == "") txtBuscaDoc.Text = "0";
                    //nDocuBusca = Convert.ToInt32(txtBuscaDoc.Text);
                    //cDocuBusca = cmbTipoDni.Text;
                    if (nDocuBusca == 0) return;
                    EstaCliente();
                }
                else
                {
                    Busca_Cliente(nDocuBusca, cDocuBusca);
                }
            }
            else
            {
                Limpia();
                Pone_Enable(false);
                BtnBusca.Text = "Buscar";
                panelBuscar.Enabled = true;
                txtBuscaDoc.Focus();
            }
        }
        private void BtnBusca_Click(object sender, EventArgs e)
        {
            BuscaPrimero();
        }

        private void LLenaDatosDomicilio(int nTipo, DataGridView grid)
        {
            grid.Rows.Clear();

            if (txtBuscaDoc.Text == "0" || txtBuscaDoc.Text == "") return;
            int nd = Convert.ToInt32(txtBuscaDoc.Text);
            //string cd = CmbDocuBusca.Text;
            
            //List<PerDomicilio> RegDomLst = bl.BuscaDomicilios(1, nd, cd, nTipo);
            int clsd = 0;

            if (nTipo == 1)
            {
                clsd = bl.pGlob.DatoCliente.ClaseDatoID;
            }
            else
            {
                clsd = bl.pGlob.DatoEmpresa.ClaseDatoID;
            }

          List<Domicilio> RegDomLst = bl.GetDomicilios(c => c.Documento == nDocuBusca && c.TipoDocumentoID == cDocuBusca && c.ClaseDatoID == clsd && c.EstadoID == ParametrosGlobales.EstadoVigenteID).ToList();
            //  List<Domicilio> RegDomLst = regCliente.Domicilios.Where(c=> c.ClaseDatoID == clsd && c.EstadoID == ParametrosGlobales.EstadoVigenteID).ToList();
            if (RegDomLst.Count == 0)
            {
                return;
            }



            int nFila = 0;
            int nCol = 0;
            DateTime fTmp;
            string cTmp;
            string cTmp1;
            string cTmp2;
            int nTmp = 0;
            backColorList = Color.White;
            Localidad RLoc;

            foreach (Domicilio dom in RegDomLst)
            {
                RLoc = new Localidad();
                grid.Rows.Add();
                grid.Rows[nFila].DefaultCellStyle.BackColor = backColorList;
                fTmp = (DateTime)dom.Fecha;
                grid.Rows[nFila].Cells[nCol].Value = fTmp.ToShortDateString(); nCol++; //0

                if (dom.Direccion != null) cTmp = dom.Direccion; else cTmp = "";
                grid.Rows[nFila].Cells[nCol].Value = cTmp; nCol++; //0


                if (dom.Numero != null) cTmp = dom.Numero; else cTmp = "";
                grid.Rows[nFila].Cells[nCol].Value = cTmp; nCol++; //0
                if (dom.Departamento != null) cTmp = dom.Departamento; else cTmp = "";
                grid.Rows[nFila].Cells[nCol].Value = cTmp; nCol++; //0
                if (dom.Piso != null) cTmp = dom.Piso; else cTmp = "";
                grid.Rows[nFila].Cells[nCol].Value = cTmp; nCol++; //0 

                //************************************
                cTmp = "";
                cTmp1 = "";
                cTmp2 = "";
                if (dom.LocalidadID != null && dom.Localidad != null)
                {
                    cTmp = dom.Localidad.Nombre;
                    if (dom.Localidad.CodPostal != null) cTmp1 = dom.Localidad.CodPostal;
                }

                if (dom.ProvinciaID != null && dom.Provincia != null) cTmp2 = dom.Provincia.Nombre;
                grid.Rows[nFila].Cells[nCol].Value = cTmp2; nCol++; //0
                grid.Rows[nFila].Cells[nCol].Value = cTmp; nCol++; //0
                grid.Rows[nFila].Cells[nCol].Value = cTmp1; nCol++; //0





                //if (dom.ProvinciaID != null) nTmp = (int)dom.ProvinciaID; else nTmp = 0;
                
                //grid.Rows[nFila].Cells[nCol].Value = bl.getp(1, nTmp); nCol++; //0
                
                
                //cTmp = "";
                //cTmp2 = "";
                //if (dom.loc_id != null) RLoc = bl.GetLocalidad(1, (int)dom.loc_id);
                //if (RLoc != null)
                //{
                //    cTmp = RLoc.loc_nombre;
                //    cTmp2 = RLoc.loc_cod_postal;
                //}
                
                
                
                //grid.Rows[nFila].Cells[nCol].Value = cTmp; nCol++; //0
                //grid.Rows[nFila].Cells[nCol].Value = cTmp2; nCol++; //0


                //************************************
                grid.Rows[nFila].Cells[nCol].Value = dom.Complemento; nCol++; //0
                grid.Rows[nFila].Cells[nCol].Value = dom.NotasDomicilio; nCol++; //0

                grid.Rows[nFila].Cells[nCol].Value = dom.DomicilioID; ; nCol++; //
                if (dom.ProvinciaID != null) nTmp = (int)dom.ProvinciaID; else nTmp = 0;
                grid.Rows[nFila].Cells[nCol].Value = nTmp.ToString(); nCol++; //
                if (dom.LocalidadID != null) nTmp = (int)dom.LocalidadID; else nTmp = 0;
                grid.Rows[nFila].Cells[nCol].Value = nTmp.ToString(); nCol++; //

                grid.Rows[nFila].DefaultCellStyle.Font = new System.Drawing.Font("Helvetica", 7, FontStyle.Regular);

                if (backColorList == Color.White) backColorList = Color.LightGray; else backColorList = Color.White;
                nCol = 0;
                nFila++;
            }

        }

        private void gridDomi_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (gridDomi.Rows.Count > 0) btnDomiModificar.Enabled = true; else btnDomiModificar.Enabled = false;
            nRDP = e.RowIndex;
        }

        private void gridDomiL_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (gridDomiL.Rows.Count > 0) btnDomiModificarL.Enabled = true; else btnDomiModificarL.Enabled = false;
            nRDL = e.RowIndex;
        }

        private void LlenaDatosTelefono(int nTipo, DataGridView grid)
        {
            grid.Rows.Clear();
            int clsd = 0;
            if (txtBuscaDoc.Text == "0" || txtBuscaDoc.Text == "") return;
            int nd = Convert.ToInt32(txtBuscaDoc.Text);
            //string cd = CmbDocuBusca.Text;
            //bl = new BusinessLayer();

            if (nTipo == 1)
            {
                clsd = bl.pGlob.DatoCliente.ClaseDatoID;
            }
            else
            {
                clsd = bl.pGlob.DatoEmpresa.ClaseDatoID;

            }

            List<Telefono> REgTelList = bl.GetTelefonos(t => t.Documento == nDocuBusca && t.TipoDocumentoID == cDocuBusca && t.ClaseDatoID == clsd && t.EstadoID == ParametrosGlobales.EstadoVigenteID).ToList();



            //List<PerTelefono> REgTelList = bl.BuscaTelefonos(1, nd, cd, nTipo);
            if (REgTelList.Count == 0)
            {
                return;
            }
            int nFila = 0;
            int nCol = 0;
            DateTime fTmp;

            string cTmp;
            backColorList = Color.White;

            foreach (Telefono tel in REgTelList)
            {
                grid.Rows.Add();
                grid.Rows[nFila].DefaultCellStyle.BackColor = backColorList;
                if (tel.Fecha != null)
                {
                    fTmp = (DateTime)tel.Fecha;
                    grid.Rows[nFila].Cells[nCol].Value = fTmp.ToShortDateString(); nCol++; //0
                }
                else { grid.Rows[nFila].Cells[nCol].Value = ""; nCol++; }//0

                if (tel.CodArea != null) cTmp = tel.CodArea; else cTmp = "";
                grid.Rows[nFila].Cells[nCol].Value = cTmp; nCol++; //1

                if (tel.Numero != null) cTmp = tel.Numero; else cTmp = "";
                grid.Rows[nFila].Cells[nCol].Value = cTmp; nCol++; //2

                if (tel.esCelular == true) cTmp = "SI"; else cTmp = "NO";
                grid.Rows[nFila].Cells[nCol].Value = cTmp; nCol++;

                if (tel.Nota != null) cTmp = tel.Nota; else cTmp = "";
                grid.Rows[nFila].Cells[nCol].Value = cTmp; nCol++; //3

                grid.Rows[nFila].Cells[nCol].Value = tel.TelefonoID.ToString(); ; nCol++; //3
                grid.Rows[nFila].DefaultCellStyle.Font = new System.Drawing.Font("Helvetica", 7, FontStyle.Regular);

                if (backColorList == Color.White) backColorList = Color.LightGray; else backColorList = Color.White;
                nCol = 0;
                nFila++;
            }

        }

        private void LlenaDatosMail()
        {
            gridMail.Rows.Clear();
            if (txtBuscaDoc.Text == "0" || txtBuscaDoc.Text == "") return;
            int nd = Convert.ToInt32(txtBuscaDoc.Text);

            int nFila = 0;
            int nCol = 0;
            DateTime fTmp;
            string cTmp;
            List<Mail> regMaiL = bl.GetMails(t => t.Documento == nDocuBusca && t.TipoDocumentoID == cDocuBusca && t.EstadoID == ParametrosGlobales.EstadoVigenteID).ToList();
            foreach (Mail Correo in regMaiL)
            {
                    gridMail.Rows.Add();
                    gridMail.Rows[nFila].DefaultCellStyle.BackColor = backColorList;
                    if (Correo.Fecha != null)
                    {
                        fTmp = (DateTime)Correo.Fecha;
                        gridMail.Rows[nFila].Cells[nCol].Value = fTmp.ToShortDateString(); nCol++; //0
                    }
                    else { gridMail.Rows[nFila].Cells[nCol].Value = ""; nCol++; }//0

                    if (Correo.Direccion != null) cTmp = Correo.Direccion; else cTmp = "";
                    gridMail.Rows[nFila].Cells[nCol].Value = cTmp; nCol++; //1

                    if (Correo.Nota != null) cTmp = Correo.Nota; else cTmp = "";
                    gridMail.Rows[nFila].Cells[nCol].Value = cTmp; nCol++; //2


                    gridMail.Rows[nFila].Cells[nCol].Value = Correo.MailID.ToString(); ; nCol++; //3
                    gridMail.Rows[nFila].DefaultCellStyle.Font = new System.Drawing.Font("Helvetica", 7, FontStyle.Regular);

                    if (backColorList == Color.White) backColorList = Color.LightGray; else backColorList = Color.White;
                    nCol = 0;
                    nFila++;
                
            }
        }

        private void gridTelf_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (gridTelf.Rows.Count > 0) btnTelModi.Enabled = true; else btnTelModi.Enabled = false;
            nRTP = e.RowIndex;
        }

        private void gridTelfL_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (gridTelfL.Rows.Count > 0) btnTelModiL.Enabled = true; else btnTelModiL.Enabled = false;
            nRTL = e.RowIndex;
        }

        private void gridMail_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (gridMail.Rows.Count > 0) btnMailModi.Enabled = true; else btnMailModi.Enabled = false;
            nRM = e.RowIndex;
        }

        private void btnGrabaPer_Click(object sender, EventArgs e)
        {
            if (btnGrabaPer.Text == "Grabar")
            {
                VerificaPersona();
            }
        }

        private void VerificaPersona()
        {
            if (txtBuscaDoc.Text == "0")
            {
                txtBuscaDoc.SelectAll();
                txtBuscaDoc.Focus();
                txtBuscaDoc.BackColor = Color.Orange;
                return;
            }
            if (txtCliApellido.Text == "")
            {
                txtCliApellido.SelectAll();
                txtCliApellido.Focus();
                txtCliApellido.BackColor = Color.Orange;
                return;
            }
            if (txtCliNombre.Text == "")
            {
                txtCliNombre.SelectAll();
                txtCliNombre.Focus();
                txtCliNombre.BackColor = Color.Orange;
                return;
            }
            if (cmbComplemento.Text == "")
            {
                cmbComplemento.SelectAll();
                cmbComplemento.Focus();
                cmbComplemento.BackColor = Color.Orange;
                return;
            }
            if (txtSueldo.Text == "0" || txtSueldo.Text == "")
            {
                txtSueldo.SelectAll();
                txtSueldo.Focus();
                txtSueldo.BackColor = Color.Orange;
                return;

            }
            if (cmbProfesion.SelectedValue.ToString() == "PRI" || cmbProfesion.SelectedValue.ToString() == "PUB")
            {
                if (txtEmpresa.Text == "")
                {
                    txtEmpresa.SelectAll();
                    txtEmpresa.Focus();
                    txtEmpresa.BackColor = Color.Orange;
                    return;
                }
            }


            if(Graba_Modificacion())
            {
                panelDomi.Enabled = true;
                panelTel.Enabled = true;
                panelMail.Enabled = true;
            }
        }

        private void Graba_Nuevo()
        {
            
        }
        private void Graba_Modificacion_Pru(int doc, string cdoc)
        {
            //if (lblMor.Visible == false) return;
            if (bl.LlevaM() == false) return;
            Cliente regClienteNVO;
            string cQueHagoM = "M";
            regClienteNVO = bl.dalPrueba.Get<Cliente>( c => c.Documento == doc && c.TipoDocumentoID == cdoc).FirstOrDefault();
            if (regClienteNVO == null)
            {
                cQueHagoM = "N";
            }
            if (cQueHagoM == "N")
            {
                regClienteNVO = new Cliente();

                regClienteNVO.Documento = Convert.ToInt32(txtBuscaDoc.Text);
                regClienteNVO.TipoDocumentoID = cmbTipoDni.Text;

                regClienteNVO.Puntaje = 0;
                regClienteNVO.EstadoID = 82;
                regClienteNVO.Sueldo = 0;
            }
            regClienteNVO.Apellido = txtCliApellido.Text;
            regClienteNVO.Nombre = txtCliNombre.Text;
            regClienteNVO.SexoID = cmbCliSexo.SelectedValue.ToString();
            regClienteNVO.FechaNacimiento = TxtCliNaci.Value;
            regClienteNVO.FechaAlta = DateTime.Now;
            regClienteNVO.ProfesionID = cmbComplemento.SelectedValue.ToString();
            regClienteNVO.TipoComoConocioID = cmbCliConocio.SelectedValue.ToString();

            regClienteNVO.EmpresaLaboral = txtEmpresa.Text;
            regClienteNVO.Sueldo = Convert.ToDecimal(txtSueldo.Text);
            regClienteNVO.Legajo = txtLegajo.Text;
            if (cQueHagoM == "N")
            {
                bl.Agregar(99, regClienteNVO); //   Cliente(regClienteNVO);
            }
            else
            {
                bl.Actualizar(99, regClienteNVO); // Cliente(regClienteNVO);
                //bl.Transmision<Cliente>(regClienteNVO, bl.pGlob.Comercio, bl.pGlob.TransActualizarCliente, bl.pGlob.UriClientes);
            }
            if (bGraboPru == false)
            {
                Comercio ComerP = bl.dalPrueba.Get<Comercio>(c => c.Principal == true).FirstOrDefault();
                bl.Transmision<Cliente>(regClienteNVO, ComerP, bl.pGlob.TransAgregarCliente, bl.pGlob.UriClientes);
                bl.Grabar(99);
                bGraboPru = true;
            }

            
            //MessageBox.Show("Datos grabados");
            //return true;

        }
        private bool Graba_Modificacion()
        {
            int doc = Convert.ToInt32(txtBuscaDoc.Text);
            string cdoc = cmbTipoDni.Text;
            
            Cliente regClienteNVO;
             if (cQueHago == "N")
             {
                 regClienteNVO = new Cliente();

                 regClienteNVO.Documento = Convert.ToInt32(txtBuscaDoc.Text);
                 regClienteNVO.TipoDocumentoID = cmbTipoDni.Text;
                 
                 regClienteNVO.Puntaje = 0;
                 regClienteNVO.EstadoID = 82;
                 regClienteNVO.Sueldo = 0;
             }
             else
             {
                 regClienteNVO = bl.Get<Cliente>(c => c.Documento == doc && c.TipoDocumentoID == cdoc).FirstOrDefault();
                 if (regClienteNVO == null)
                 {
                     MessageBox.Show("ERROR - Nro de documento no encontrado" + Environment.NewLine + doc.ToString(), "Modificación de cliente");
                     return false;
                 }
             }
             regClienteNVO.Apellido = txtCliApellido.Text;
             regClienteNVO.Nombre = txtCliNombre.Text;
             regClienteNVO.SexoID = cmbCliSexo.SelectedValue.ToString();
             regClienteNVO.FechaNacimiento = TxtCliNaci.Value;
             regClienteNVO.FechaAlta = DateTime.Now;
             regClienteNVO.ProfesionID = cmbComplemento.SelectedValue.ToString();
             regClienteNVO.TipoComoConocioID = cmbCliConocio.SelectedValue.ToString();

            regClienteNVO.EmpresaLaboral = txtEmpresa.Text;
            regClienteNVO.Sueldo = Convert.ToDecimal(txtSueldo.Text);
            regClienteNVO.Legajo = txtLegajo.Text;
            regClienteNVO.Cuit = txtCuit.Text;
            if (cQueHago == "N")
            {
               bl.AgregarCliente(regClienteNVO);
                 //bl.Transmision<Cliente>(regClienteNVO, bl.pGlob.Comercio, bl.pGlob.TransAgregarCliente, bl.pGlob.UriClientes);
            }
            else
            {
                bl.ActualizarCliente(regClienteNVO);
            }
            if(bGrabo == false) bl.Transmision<Cliente>(regClienteNVO, bl.pGlob.Comercio, bl.pGlob.TransAgregarCliente, bl.pGlob.UriClientes);
            bGrabo = true;
            bl.Grabar();
            Graba_Modificacion_Pru(doc, cdoc);
            MessageBox.Show("Datos grabados");
            return true;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDomiNuevo_Click(object sender, EventArgs e)
        {
            PreparaDomicilioNuevo(1, "particular");
        }
        private void PreparaDomicilioNuevo(int nTipo, string cQue)
        {
            lblDomi01.Text = "Nuevo domicilio " + cQue;
            lblDomTipo.Text = nTipo.ToString();
            lblDomID.Text = "0";
            LimpiaPestaña(panelDomicilio02);
            tabla.Enabled = false;
            panel2.Enabled = false;
            //MuestraPanelDomicilio();
            MuestraPanelConSombra(panelDomicilio02, lblSombra, txtDomCalle);
        }

        private void btnDomCerrar_Click(object sender, EventArgs e)
        {
            tabla.Enabled = true;
            panel2.Enabled = true;

            lblSombra.Visible = false;
            panelDomicilio02.Visible = false;
        }

        private void btnDomGrabar_Click(object sender, EventArgs e)
        {
            if (lblDomID.Text == "0") GrabaDomicilio(true); else GrabaDomicilio(false);
        }
        private void GrabaDomicilio(bool bNuevo)
        {
            if ((int)cmbDomEst.SelectedValue == ParametrosGlobales.EstadoVigenteID)
            {
                if (txtDomCalle.Text == "")
                {
                    txtDomCalle.SelectAll();
                    txtDomCalle.Focus();
                    txtDomCalle.BackColor = Color.Orange;
                    return;
                }
                if (cmbDomProv.Text == "")
                {
                    cmbDomProv.SelectAll();
                    cmbDomProv.Focus();
                    cmbDomProv.BackColor = Color.Orange;
                    return;
                }
                if (cmbDomLoc.Text == "")
                {
                    cmbDomLoc.SelectAll();
                    cmbDomLoc.Focus();
                    cmbDomLoc.BackColor = Color.Orange;
                    return;
                }
            }
            Graba_Domicilios(bNuevo);
            {
                //if (txtDomCodPost.Text != "" && (txtDomCodPost.Text != cmbDomCpostal.Text)) Grabaciones.GrabaCodigoPostal(1, Convert.ToInt16(cmbDomProv.SelectedValue), Convert.ToInt32(cmbDomLoc.SelectedValue), txtDomCodPost.Text);
                MessageBox.Show("Datos grabados");
                lblSombra.Visible = false;
                panelDomicilio02.Visible = false;
                tabla.Enabled = true;
                panel2.Enabled = true;
                bl = new BusinessLayer();
                if (lblDomTipo.Text == "1") LLenaDatosDomicilio(1, gridDomi); else LLenaDatosDomicilio(2, gridDomiL);
            }
        }
      
        private void Graba_Domicilios(bool bNuevo)
        {
            Domicilio regDomicilio;
            Localidad loc = (Localidad)cmbDomLoc.SelectedItem;
            if (bNuevo)
            {
                regDomicilio = new Domicilio();
                regDomicilio.Documento = Convert.ToInt32(txtBuscaDoc.Text);
                regDomicilio.TipoDocumentoID = cmbTipoDni.Text;

                regDomicilio.ClaseDatoID = Convert.ToInt16(lblDomTipo.Text);
                //if (dondeVengo == "PARTICULAR") regDomicilio.ClaseDatoID = bl.pGlob.DatoCliente.ClaseDatoID;
                //else regDomicilio.ClaseDatoID = bl.pGlob.DatoEmpresa.ClaseDatoID;
            }else
            {
                regDomicilio = bl.GetByID<Domicilio>(BaseID, Convert.ToInt32(lblDomID.Text));
            }
            regDomicilio.EmpresaID = BaseID;
            regDomicilio.ComercioID = ComID;
            regDomicilio.Direccion = txtDomCalle.Text;
            if (txtDomNro.Text != "0") regDomicilio.Numero = txtDomNro.Text; else regDomicilio.Numero = null;
            if (txtDomPiso.Text != "0") regDomicilio.Piso = txtDomPiso.Text; else regDomicilio.Piso = null;
            regDomicilio.Departamento = txtDomDpto.Text;
            regDomicilio.Complemento = txtDomComplemento.Text;
            regDomicilio.NotasDomicilio = txtDomNotas.Text;
            regDomicilio.LocalidadID = (int)cmbDomLoc.SelectedValue;
            regDomicilio.ProvinciaID = (int)cmbDomProv.SelectedValue;
            regDomicilio.UsuarioID = p.usu.UsuarioID;
            regDomicilio.Fecha = DateTime.Now;
            regDomicilio.PcComer = System.Environment.MachineName;
            regDomicilio.PaisId = bl.pGlob.Argentina.PaisID;

            if (bNuevo)
            {
                regDomicilio.EstadoID = (int)bl.pGlob.Vigente.EstadoID;
                bl.Agregar<Domicilio>(regDomicilio.EmpresaID.Value, regDomicilio);
            }
            else
            {
                regDomicilio.EstadoID = (int)cmbDomEst.SelectedValue; // (int)bl.pGlob.Vigente.EstadoID;
                bl.Actualizar<Domicilio>(regDomicilio.EmpresaID.Value, regDomicilio);
            }
            GrabaTrans(Convert.ToInt32(txtBuscaDoc.Text), cmbTipoDni.Text);
            bl.Grabar(BaseID); 
            Graba_Domicilio_Pru(regDomicilio);


            /* Agrego los codigos postales temporalmente mediante las receptorias y comercios hasta que estén todos cargados, o hasta que los cargue
             * en la base todos por afuera
             */
            //if (loc != null && ComID == bl.pGlob.ComercioID)  //ARREGLAT
            //{
            //    if (txtDomCodPost.Text != "")
            //    {
            //        //loc.CodPostal = txtDomCodPost.Text;
            //        //bl.Actualizar<Localidad>(regDomicilio.EmpresaID.Value, loc);
            //    }
            //}

           
        }

        private void btnDomiNuevoL_Click(object sender, EventArgs e)
        {
            PreparaDomicilioNuevo(2, "laboral");
        }

        private void btnDomiModificar_Click(object sender, EventArgs e)
        {
            PreparaDomicilioModi(1, gridDomi, nRDP, "Particular");
        }

        private void btnDomiModificarL_Click(object sender, EventArgs e)
        {
            PreparaDomicilioModi(2, gridDomiL, nRDL, "Laboral");
        }
        private void PreparaDomicilioModi(int nTipo, DataGridView grid, int nFila, string cQue)
        {

            if (grid.Rows.Count == 0) return;
            LimpiaPestaña(panelDomicilio02);
            cmbDomCpostal.DataSource = null;
            txtDomCalle.Text = grid.Rows[nFila].Cells[1].Value.ToString();
            txtDomNro.Text = grid.Rows[nFila].Cells[2].Value.ToString();
            txtDomDpto.Text = grid.Rows[nFila].Cells[3].Value.ToString();
            txtDomPiso.Text = grid.Rows[nFila].Cells[4].Value.ToString();
            if(grid.Rows[nFila].Cells[8].Value!=null) txtDomComplemento.Text = grid.Rows[nFila].Cells[8].Value.ToString();

            if (grid.Rows[nFila].Cells[9].Value != null) txtDomNotas.Text = grid.Rows[nFila].Cells[9].Value.ToString();

            Busca_En_Combo_Value(cmbDomProv, grid.Rows[nFila].Cells[11].Value.ToString());
            
            
            
            
            //CargaLocalidades(cmbDomLoc, bl, (int)cmbDomProv.SelectedValue);
            
            
            Busca_En_Combo_Value(cmbDomLoc, grid.Rows[nFila].Cells[12].Value.ToString());
            
            //CargaCodPostales(cmbDomCpostal, bl, (int)cmbDomProv.SelectedValue);
            if (cmbDomCpostal.Items.Count > 0) cmbDomCpostal.SelectedIndex = cmbDomLoc.SelectedIndex;
            cmbDomCpostal.Refresh();
            if (cmbDomCpostal.Items.Count > 0) txtDomCodPost.Text = cmbDomCpostal.Text;
            if (txtDomCodPost.Text == "") txtDomCodPost.Text = "0";
            
            
            
            tabla.Enabled = false;
            panel2.Enabled = false;
            lblDomID.Text = grid.Rows[nFila].Cells[10].Value.ToString();
            lblDomi01.Text = "Modificar domicilio " + cQue;
            lblDomTipo.Text = nTipo.ToString();
            //MuestraPanelDomicilio();
            MuestraPanelConSombra(panelDomicilio02, lblSombra, txtDomCalle);


        }

        private void panelDomicilio02_Move(object sender, EventArgs e)
        {
            System.Windows.Forms.Control elControl = (System.Windows.Forms.Control)sender;
            lblSombra.Width = elControl.Width - 2;
            lblSombra.Height = elControl.Height;// -10;
            lblSombra.Top = elControl.Top + 3;
            lblSombra.Left = elControl.Left + 5;
        }

        private void btnTelNvo_Click(object sender, EventArgs e)
        {
            PreparaTelefonoNuevo(1);
        }

        private void btnTelNvoL_Click(object sender, EventArgs e)
        {
            PreparaTelefonoNuevo(2);
        }
        private void PreparaTelefonoNuevo(int nTipo)
        {
            lblTel01.Text = "Nuevo teléfono particular";
            lblTelTipo.Text = nTipo.ToString();
            lblTelID.Text = "0";
            LimpiaPestaña(panelTelefono02);
            tabla.Enabled = false;
            panel2.Enabled = false;
            MuestraPanelConSombra(panelTelefono02, lblSombra, txtTelArea);
        }

        private void MuestraPanelTelef()
        {
            lblSombra.Width = panelTelefono02.Width;
            lblSombra.Height = panelTelefono02.Height - 10;
            lblSombra.Top = panelTelefono02.Top + 15;
            lblSombra.Left = panelTelefono02.Left + 5;
            lblSombra.BringToFront();
            tabla.Enabled = false;
            panel2.Enabled = false;
            lblSombra.Visible = true;
            panelTelefono02.BringToFront();
            panelTelefono02.Visible = true;
            txtTelArea.SelectAll();
            txtTelArea.Focus();
        }

        private void btnTelModi_Click(object sender, EventArgs e)
        {
            PreparaTelefonoModi(1, gridTelf, nRTP, "Particular");
        }

        private void btnTelModiL_Click(object sender, EventArgs e)
        {
            PreparaTelefonoModi(2, gridTelfL, nRTL, "Laboral");
        }
        private void PreparaTelefonoModi(int nTipo, DataGridView grid, int nFila, string cQue)
        {
            if (grid.Rows.Count == 0) return;
            LimpiaPestaña(panelTelefono02);
            txtTelArea.Text = grid.Rows[nFila].Cells[1].Value.ToString();
            txtTelNro.Text = grid.Rows[nFila].Cells[2].Value.ToString();
            if (grid.Rows[nFila].Cells[3].Value.ToString() == "SI") chkTelCel.Checked = true;
            txtTelNotas.Text = grid.Rows[nFila].Cells[4].Value.ToString();

            lblTelID.Text = grid.Rows[nFila].Cells[5].Value.ToString();
            lblTel01.Text = "Modificar teléfono " + cQue;
            lblTelTipo.Text = nTipo.ToString();
            cmbTelEstado.SelectedIndex = 0;
            tabla.Enabled = false;
            panel2.Enabled = false;
            //MuestraPanelTelef();
            MuestraPanelConSombra(panelTelefono02, lblSombra, txtTelArea);
        }

        private void btnTelCerrar_Click(object sender, EventArgs e)
        {
            tabla.Enabled = true;
            panel2.Enabled = true;
            lblSombra.Visible = false;
            panelTelefono02.Visible = false;
        }

        private void btnTelGraba_Click(object sender, EventArgs e)
        {
            if (lblTelID.Text == "0") GrabaTelefono(true); else GrabaTelefono(false);
        }
        private void GrabaTelefono(bool bNuevo)
        {
            if ((int)cmbTelEstado.SelectedValue == ParametrosGlobales.EstadoVigenteID)
            {
                if (txtTelArea.Text == "")
                {
                    txtTelArea.SelectAll();
                    txtTelArea.Focus();
                    txtTelArea.BackColor = Color.Orange;
                    return;
                }
                if (txtTelNro.Text == "")
                {
                    txtTelNro.SelectAll();
                    txtTelNro.Focus();
                    txtTelNro.BackColor = Color.Orange;
                    return;
                }
            }
            if( Graba_Telefono(bNuevo))
            {
                MessageBox.Show("Datos grabados");

                lblSombra.Visible = false;
                panelTelefono02.Visible = false;
                tabla.Enabled = true;
                panel2.Enabled = true;
                bl = new BusinessLayer();
                if (lblTelTipo.Text == "1") LlenaDatosTelefono(1, gridTelf); else LlenaDatosTelefono(2, gridTelfL);
            }
        }
        private void  Graba_Telefono_Pru(Telefono RegtelLst)
        {
            if (lblMor.Visible == false) return;
            if (bl.LlevaM() == false) return;
            bool esNuevo = true;
            int nDocumento = RegtelLst.Documento;
            string cDocumento = RegtelLst.TipoDocumentoID;
            int nClaseDatoID = RegtelLst.ClaseDatoID;
            if (RegtelLst != null)
            {
                Telefono regTelefono = new Telefono();
                regTelefono = bl.GetDal(99).Get<Telefono>(c => c.Documento == nDocumento && c.TipoDocumentoID == cDocumento && c.ClaseDatoID == nClaseDatoID && c.EstadoID == ParametrosGlobales.EstadoVigenteID, o => o.OrderByDescending(oo => oo.Fecha)).FirstOrDefault();
                if (regTelefono != null) esNuevo = false;
                if (esNuevo)
                {
                    regTelefono = new Telefono();
                    regTelefono.Documento = nDocumento;
                    regTelefono.TipoDocumentoID = cDocumento;

                }
                regTelefono.ClaseDatoID = RegtelLst.ClaseDatoID;
                regTelefono.EmpresaID = BaseID;
                regTelefono.ComercioID = ComID;
                regTelefono.CodArea = RegtelLst.CodArea;
                regTelefono.Numero = RegtelLst.Numero;
                regTelefono.esCelular = RegtelLst.esCelular;
                regTelefono.Nota = RegtelLst.Nota;
                regTelefono.UsuarioID = p.usu.UsuarioID;
                regTelefono.Fecha = DateTime.Now;
                regTelefono.PcComer = System.Environment.MachineName;
                regTelefono.EstadoID = RegtelLst.EstadoID;
                if (esNuevo)
                {
                    bl.Agregar<Telefono>(99, regTelefono);
                }
                else
                {
                    bl.Actualizar<Telefono>(99, regTelefono);
                }
            }
            GrabaTransPru(nDocumento, cDocumento);
            bl.Grabar(99);
        }
        private bool    Graba_Telefono(bool bNuevo)
        {
            Telefono regTelefono;
            if (bNuevo)
            {
                regTelefono = new Telefono();
                regTelefono.Documento = Convert.ToInt32(txtBuscaDoc.Text);
                regTelefono.TipoDocumentoID = cmbTipoDni.Text;
                regTelefono.ClaseDatoID = Convert.ToInt16(lblTelTipo.Text);
            }
            else
            {
                regTelefono = bl.GetTelefonoByID(Convert.ToInt32(lblTelID.Text));
            }
            regTelefono.EmpresaID = BaseID;
            regTelefono.ComercioID = ComID;
            regTelefono.CodArea = txtTelArea.Text;
            regTelefono.Numero = txtTelNro.Text;
            regTelefono.esCelular = chkTelCel.Checked;
            regTelefono.Nota = txtTelNotas.Text;
            regTelefono.UsuarioID = p.usu.UsuarioID;
            regTelefono.Fecha = DateTime.Now;
            regTelefono.PcComer = System.Environment.MachineName;
            regTelefono.EstadoID = (int)cmbTelEstado.SelectedValue;

            if (bNuevo)
            {
                bl.Agregar<Telefono>(BaseID, regTelefono);
            }
            else
            {
                bl.Actualizar<Telefono>(BaseID, regTelefono);
            }
            GrabaTrans(Convert.ToInt32(txtBuscaDoc.Text), cmbTipoDni.Text);
            bl.Grabar(BaseID);
            Graba_Telefono_Pru(regTelefono);
            return true;
        }
        private void Graba_Domicilio_Pru(Domicilio RegDomLst)
        {
            if (lblMor.Visible == false) return;
            if (bl.LlevaM() == false) return;
            bool esNuevo = true;
            int nDocumento = RegDomLst.Documento;
            string cDocumento = RegDomLst.TipoDocumentoID;
            int nClaseDatoID = RegDomLst.ClaseDatoID;
            Domicilio RegDomLstN = new Domicilio();
            RegDomLstN = bl.GetDal(99).Get<Domicilio>(c => c.Documento == nDocumento && c.TipoDocumentoID == cDocumento && c.ClaseDatoID == nClaseDatoID && c.EstadoID == ParametrosGlobales.EstadoVigenteID, o => o.OrderByDescending(oo => oo.Fecha)).FirstOrDefault();
            if (RegDomLstN != null) esNuevo = false;

            if (esNuevo)
            {
                RegDomLstN = new Domicilio();
                RegDomLstN.Documento = nDocumento;
                RegDomLstN.TipoDocumentoID = cDocumento;
            }
            RegDomLstN.ClaseDatoID = RegDomLst.ClaseDatoID;
            RegDomLstN.EmpresaID = BaseID;
            RegDomLstN.ComercioID = ComID;
            RegDomLstN.Direccion = RegDomLst.Direccion;
            RegDomLstN.Numero = RegDomLst.Numero;
            RegDomLstN.Piso = RegDomLst.Piso;
            RegDomLstN.Departamento = RegDomLst.Departamento;
            RegDomLstN.Complemento = RegDomLst.Complemento;
            RegDomLstN.NotasDomicilio = RegDomLst.NotasDomicilio;
            RegDomLstN.LocalidadID = RegDomLst.LocalidadID;
            RegDomLstN.ProvinciaID = RegDomLst.ProvinciaID;
            RegDomLstN.UsuarioID = RegDomLst.UsuarioID;
            RegDomLstN.Fecha = RegDomLst.Fecha;
            RegDomLstN.PcComer = RegDomLst.PcComer;
            RegDomLstN.PaisId = RegDomLst.PaisId;
            RegDomLstN.EstadoID = RegDomLst.EstadoID;
            if (esNuevo)
            {
                bl.Agregar<Domicilio>(99, RegDomLstN);
            }
            else
            {
                bl.Actualizar<Domicilio>(99, RegDomLstN);
            }
            GrabaTransPru(Convert.ToInt32(txtBuscaDoc.Text), cmbTipoDni.Text);
            bl.Grabar(99);

        }

        private void btnMailNvo_Click(object sender, EventArgs e)
        {
            PreparaMailNuevo();
        }
        private void PreparaMailNuevo()
        {
            lblMail.Text = "Nueva dirección de mail";
            lblMailID.Text = "0";
            txtMailDir.Text = "";
            txtMailNotas.Text = "";
            cmbMailEstado.SelectedIndex = 0;
            tabla.Enabled = false;
            panel2.Enabled = false;
            MuestraPanelConSombra(panelMail02, lblSombra, txtMailDir);
        }

        private void btnMailModi_Click(object sender, EventArgs e)
        {
            PreparaMailModi(nRM);
        }
        private void PreparaMailModi(int nFila)
        {
            if (gridMail.Rows.Count == 0) return;

            lblMail.Text = "Modificar dirección de mail";
            lblMailID.Text = gridMail.Rows[nFila].Cells[3].Value.ToString();
            txtMailDir.Text = gridMail.Rows[nFila].Cells[1].Value.ToString();
            txtMailNotas.Text = gridMail.Rows[nFila].Cells[2].Value.ToString();
            cmbMailEstado.SelectedIndex = 0;
            MuestraPanelConSombra(panelMail02, lblSombra, txtMailDir);

        }

        private void btnMailCerrar_Click(object sender, EventArgs e)
        {
            tabla.Enabled = true;
            panel2.Enabled = true;
            lblSombra.Visible = false;
            panelMail02.Visible = false;
        }

        private void btnMailGraba_Click(object sender, EventArgs e)
        {
            if (lblMailID.Text == "0") GrabaMail(true); else GrabaMail(false);
        }
        private void GrabaMail(bool bNuevo)
        {
            if ((int)cmbMailEstado.SelectedValue == ParametrosGlobales.EstadoVigenteID)
            { 
                if (txtMailDir.Text == "")
                {
                    txtMailDir.SelectAll();
                    txtMailDir.Focus();
                    txtMailDir.BackColor = Color.Orange;
                    return;
                }
                if (txtMailDir.Text.IndexOf("@", 0) + 1 == 0)
                {
                    txtMailDir.SelectAll();
                    txtMailDir.Focus();
                    txtMailDir.BackColor = Color.Orange;
                    return;
                }
                if (txtMailDir.Text.IndexOf(".", 0) == -1)
                {
                    txtMailDir.SelectAll();
                    txtMailDir.Focus();
                    txtMailDir.BackColor = Color.Orange;
                    return;
                }
            }
            //if (Grabaciones.GrabaMail(1, bNuevo, Convert.ToInt32(txtDocuBusca.Text), CmbDocu.Text
            //                , txtMailDir.Text, txtMailNotas.Text
            //                , DateTime.Now
            //                , usuario.nUsuario, Convert.ToInt16(cmbMailEstado.SelectedValue), 1
            //                , usuario.cUsuario, Convert.ToInt32(lblMailID.Text)))
            if (Graba_Mail(bNuevo))
            {
                MessageBox.Show("Datos grabados");

                lblSombra.Visible = false;
                panelMail02.Visible = false;
                //tabla.Enabled = true;
                //panel2.Enabled = true;
                bl = new BusinessLayer();
                LlenaDatosMail();
                tabla.Enabled = true;
                panel2.Enabled = true;
            }
        }
        private void Graba_Mail_Pru(Mail RegMailLst)
        {
            if (lblMor.Visible == false) return;
            if (bl.LlevaM() == false) return;
            bool esNuevo = true;
            int nDocumento = RegMailLst.Documento;
            string cDocumento = RegMailLst.TipoDocumentoID;
            int nClaseDatoID = RegMailLst.ClaseDatoID;
            if (RegMailLst != null)
            {
                Mail regMail;
                regMail = bl.GetDal(99).Get<Mail>(c => c.Documento == nDocumento && c.TipoDocumentoID == cDocumento && c.ClaseDatoID == nClaseDatoID && c.EstadoID == ParametrosGlobales.EstadoVigenteID, o => o.OrderByDescending(oo => oo.Fecha)).FirstOrDefault();
                if (regMail != null) esNuevo = false;
                if (esNuevo)
                {
                    regMail = new Mail();
                    regMail.Documento = nDocumento;
                    regMail.TipoDocumentoID = cDocumento;
                }
                regMail.ClaseDatoID = 1;
                regMail.EmpresaID = BaseID;
                regMail.ComercioID = ComID;
                regMail.Direccion = RegMailLst.Direccion;
                regMail.Nota = RegMailLst.Nota;
                regMail.UsuarioID = p.usu.UsuarioID;
                regMail.Fecha = DateTime.Now;
                regMail.PcComer = System.Environment.MachineName;
                regMail.EstadoID = RegMailLst.EstadoID;
                if (esNuevo)
                {
                    bl.Agregar<Mail>(99, regMail);
                }
                else
                {
                    bl.Actualizar<Mail>(99, regMail);
                }
                GrabaTransPru(nDocumento, cDocumento);
                bl.Grabar(99);
            }
        }
        private bool Graba_Mail(bool bNuevo)
        {
            Mail regMail;
            if (bNuevo)
            {
                regMail = new Mail();
                regMail.Documento = Convert.ToInt32(txtBuscaDoc.Text);
                regMail.TipoDocumentoID = cmbTipoDni.Text;
                //regMail.ClaseDatoID = 1; // Convert.ToInt32(lblMailID.Text);
                //if (dondeVengo == "PARTICULAR") regMail.ClaseDatoID = bl.pGlob.DatoCliente.ClaseDatoID; else regMail.ClaseDatoID = bl.pGlob.DatoEmpresa.ClaseDatoID;
                //regMail.EstadoID = (int)bl.pGlob.Vigente.EstadoID;// edu nvo004
            }
            else
            {
                regMail = bl.GetMailByID(Convert.ToInt32(lblMailID.Text));
            }
            regMail.ClaseDatoID = 1;
            regMail.EmpresaID = BaseID;
            regMail.ComercioID = ComID;
            regMail.Direccion = txtMailDir.Text;
            regMail.Nota = txtMailNotas.Text;
            regMail.UsuarioID = p.usu.UsuarioID;
            regMail.Fecha = DateTime.Now;
            regMail.PcComer = System.Environment.MachineName;
            regMail.EstadoID = (int)cmbMailEstado.SelectedValue;
            if (bNuevo)
            {
                bl.Agregar<Mail>(regMail.EmpresaID.Value, regMail);
            }
            else
            {
                bl.Actualizar<Mail>(regMail.EmpresaID.Value, regMail);
            }
            GrabaTrans(Convert.ToInt32(txtBuscaDoc.Text), cmbTipoDni.Text);
            bl.Grabar(BaseID);
            Graba_Mail_Pru(regMail);
            return true;
        }

        private void btnFoto_Click(object sender, EventArgs e)
        {
            frmCamaraWeb frmWebCam = new frmCamaraWeb(p, bl, Convert.ToInt32(txtBuscaDoc.Text), cmbTipoDni.Text, lblMor.Visible);
            frmWebCam.ShowDialog();
            picFoto.Image = bl.BuscarFotosDni(txtBuscaDoc.Text); //;
        }

        private void txtCliApellido_Leave(object sender, EventArgs e)
        {
            this.AMayusculas(txtCliApellido);
        }

        private void txtCliApellido_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCliNombre_Leave(object sender, EventArgs e)
        {
            this.AMayusculas(txtCliNombre);
        }

        private void txtDomCalle_Leave(object sender, EventArgs e)
        {
            this.AMayusculas(txtDomCalle);
        }

        private void txtMailDir_TextChanged(object sender, EventArgs e)
        {
            this.AMinusculas(txtMailDir);
        }

        private void GrabaTransPru(int doc, string cdoc)
        {
            if (bGraboPru) return;
            Cliente regClienteNVO = bl.dalPrueba.Get<Cliente>(c => c.Documento == doc && c.TipoDocumentoID == cdoc).FirstOrDefault();
            Comercio ComerP = bl.dalPrueba.Get<Comercio>(c => c.Principal == true).FirstOrDefault();
            bl.Transmision<Cliente>(regClienteNVO, ComerP, bl.pGlob.TransAgregarCliente, bl.pGlob.UriClientes);
            bGraboPru = true;
        }
        private void GrabaTrans(int doc, string cdoc)
        {
            if (bGrabo) return;
            Cliente regClienteNVO = bl.Get<Cliente>(c => c.Documento == doc && c.TipoDocumentoID == cdoc).FirstOrDefault();
            Comercio ComerP = bl.Get<Comercio>(c => c.Principal == true).FirstOrDefault();
            bl.Transmision<Cliente>(regClienteNVO, ComerP, bl.pGlob.TransAgregarCliente, bl.pGlob.UriClientes);
            bGrabo = true;
        }

        private void gridTelf_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
