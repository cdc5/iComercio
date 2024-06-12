using System;                         ////convert, eventarg, eventhandler
using System.Collections.Generic;         //list<>
using System.Drawing;                  ///font , color
using System.Linq;                      // orderby(), select()
using System.Windows.Forms;               //formWindowsState, listview, musearg, etc
using iComercio.Rest;                       //RestApi
using iComercio.Models;                     // modelos(cred, cuot, etc)
using System.Diagnostics;
using iComercio.DAL;                            //MOROSOS
using Credin;                                   //UTILIDADES

//using System.ComponentModel;
//using System.Data;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
//using System.Data.Entity;

//using iComercio.Delegados;
//using iComercio.ViewModels;
//using iComercio.Auxiliar;

//using System.Globalization;

namespace iComercio.Forms
{
    public partial class FrmBuscaCliDocumento : FRM                   //edu202208                                      
    {
        
        List<Credito> regCreditoListPru;
        Cliente regClientePru = null;

        Color backColorList = Color.White;
        Font fontList = new Font("Verdana", 7F, FontStyle.Regular);

        List<Credito> regCreditoList;
        Cliente regCliente = null;

        ToolTip toolTipC = new ToolTip();
        ToolTip toolTipA = new ToolTip();

        int nCliDocu = 0;
        string cCliDocu = "";

        decimal nDeudaA = 0;
        decimal nDeudaT = 0;
        string cAbogado = "";

        List<string> rutasFoto = new List<string>();
        List<string> rutasImagen = new List<string>();

        int nFilaCredito = 0;

        public FrmBuscaCliDocumento()
        {
            InitializeComponent();
        }
        public FrmBuscaCliDocumento(Principal p, BusinessLayer bl, int nDocu, string cDocu)
            : base(p)
        {
            InitializeComponent();
            lblMor.Visible = false;
            RecargarEmpYComercio(lblMor.Visible);
            Configura_Inicio();
            txtBuscaDoc.Text = nDocu.ToString();
            Busca_En_Combo(cmbTipoDni, cDocu);
            Busca_Cliente(nDocu, cDocu);
        }

        public FrmBuscaCliDocumento(Principal p, RestApi ra)
            : base(p, ra)
        {
            InitializeComponent();
            lblMor.Visible = false;
            RecargarEmpYComercio(lblMor.Visible);
            Configura_Inicio();
            txtBuscaDoc.Text = "0";
        }

        private void FrmBuscaCliDocumento_Load(object sender, EventArgs e)
        {
            txtBuscaDoc.Focus();
            txtBuscaDoc.Select();
        }
        private void Configura_Controles()
        {
            Configura_Colores(bl.pGlob.Comercio.EmpresaID);
            Recorre_Formulario(this);
            this.BackColor = ColorBackColorFrm;
            listCreditos.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left));
        }
        private void Manda_a_Creditos()               
        {
            if (listCreditos.Items.Count == 0) return;
            int nCant = 0;
            foreach(ListViewItem it in listCreditos.Items)
            {
                if(it.SubItems[11].Text == "") nCant++;
            }
            string[,,] ConsuCreditos = new string[nCant, nCant, nCant];
            string[,] ConsuCred = new string[nCant, 4];
            nCant = 0;
            foreach(ListViewItem it in listCreditos.Items)
            {
                if(it.SubItems[11].Text == "")
                {
                    ConsuCred[nCant, 0] = it.SubItems[10].Text;
                    ConsuCred[nCant, 1] = it.SubItems[2].Text;
                    ConsuCred[nCant, 2] = it.SubItems[3].Text;
                    ConsuCred[nCant, 3] = it.SubItems[11].Text;
                    nCant++;
                }
            }
            frmCobranzaNva frmACob = new frmCobranzaNva(p, false, ConsuCred, nFilaCredito);
            frmACob.MdiParent = Principal.ActiveForm;
            frmACob.WindowState = FormWindowState.Normal;
            frmACob.Show();
        }

        private void Busca_Cliente_Mor(int nDocu, string cDocu)      
        {
            regClientePru = bl.Get<Cliente>(BaseID, c => c.Documento == nDocu && c.TipoDocumentoID == cDocu).FirstOrDefault();
            if (regClientePru == null)
            {
                return;
            }
            
            lblMor.Visible = true;
            
            regCreditoList = regClientePru.Creditos.ToList();
            if(regCreditoList.Count > 0) Llena_Creditos("Titular",true);
            regCreditoList = regClientePru.CreditosGar1.ToList();
            if (regCreditoList.Count > 0) Llena_Creditos("Garante", true);
            regCreditoList = regClientePru.CreditosGar2.ToList();
            if (regCreditoList.Count > 0) Llena_Creditos("2° Garante", true);
            regCreditoList = regClientePru.CreditosGar3.ToList();
            if (regCreditoList.Count > 0) Llena_Creditos("3° Garante", true);
            regCreditoList = regClientePru.CreditosAdi.ToList();
            if (regCreditoList.Count > 0) Llena_Creditos("Adicional", true);
        }
        private void Busca_Cliente(int nDocu , string cDocu)
        {
            listCreditos.Items.Clear();
            if (nDocu == 0)
            {
                txtBuscaDoc.Focus();
                return;
            }
            listCreditos.Items.Clear(); 
            bl = new BusinessLayer();
            nCliDocu = nDocu;
            cCliDocu = cDocu;
            regCliente = bl.Get<Cliente>(BaseID, c => c.Documento == nDocu && c.TipoDocumentoID == cDocu).FirstOrDefault();

            
            if(regCliente == null)
            {
                txtBuscaDoc.Focus();
                return;
            }

            regCreditoList = regCliente.Creditos.ToList();
            if (regCreditoList.Count > 0) Llena_Creditos("Titular");
            regCreditoList = regCliente.CreditosGar1.ToList();
            if (regCreditoList.Count > 0) Llena_Creditos("Garante");
            regCreditoList = regCliente.CreditosGar2.ToList();
            if (regCreditoList.Count > 0) Llena_Creditos("2° Garante");
            regCreditoList = regCliente.CreditosGar3.ToList();
            if (regCreditoList.Count > 0) Llena_Creditos("3° Garante");
            regCreditoList = regCliente.CreditosAdi.ToList();
            if (regCreditoList.Count > 0) Llena_Creditos("Adicional");

            Llenadatos_cliente(regCliente);
            ObtenerMorosoEnCamara(nDocu);
 
            if(lblCliNombre.Text=="")
            {
                MessageBox.Show("Cliente no encontrado", this.Text);
                return;
            }
            Mira_Deuda();
            btnBuscar.Text = "Otro";
            this.Text = "Busqueda por documento " + nDocu.ToString("N0") + " " + lblCliNombre.Text;
            Pone_Enable(true);
        }
        private void Mira_Deuda()
        {
            if (nDeudaT == 0)
            {
                lblMsgCancelado.Text = "Sin deuda con la financiera";
                lblMsgCancelado.ForeColor = Color.Black;
            }
            else
            {
                lblMsgCancelado.Text = "tiene créditos sin cancelar";
                lblMsgCancelado.ForeColor = Color.Maroon;
                if (nDeudaA > 0)
                {
                    lblMsgCancelado.Text = "Tiene deuda con la financiera";
                    lblMsgCancelado.ForeColor = Color.Red;
                }
            }

            if (cAbogado != "")
            {
                lblMsgAbogado.Text = "Abogado";
                Pone_toolTip("ABOGADO", cAbogado);
            }
        }
        private void Llena_Creditos(string qEs, bool esMor  =false)
        {
            if (regCreditoList == null) return;
            Color colordeuda;
            ListViewItem item;
            decimal nDeuda = 0;
            string cFecha = "";
            int nCanCuot = 0;
            int nDias = 0;
            TimeSpan nd;
            decimal nTmp = 0;
            backColorList = Color.White;

            foreach(Credito cre in regCreditoList)
            {

                nDeuda = 0;
                cFecha = cre.FechaSolicitud.ToString("yyyyyMMdd");
                item = new ListViewItem(cFecha);
                item.UseItemStyleForSubItems = true;
                item.SubItems.Add(cre.FechaSolicitud.ToShortDateString());//, Color.Empty, backColorList, fontList;

                item.SubItems.Add(cre.CreditoID.ToString());//, Color.Empty, backColorList, fontList);

                item.SubItems.Add(cre.ComercioID.ToString());//, Color.Empty, backColorList, fontList);
                
                item.SubItems.Add(cre.CreditoID.ToString("N0"));//, Color.Empty, backColorList, fontList);

                //if (esMor)
                //{
                //    item.SubItems.Add("801");//, Color.Empty, backColorList, fontList);
                //}
                //else
                //{
                    item.SubItems.Add(cre.ComercioID.ToString("N0"));//, Color.Empty, backColorList, fontList);
                //}
                nDias = 0;
                nCanCuot = 0;
                nTmp = 0;
                foreach (Cuota cu in cre.Cuotas)
                {
                    
                    if(cu.FechaVencimiento< DateTime.Now)
                    {
                        if(cu.Deuda >0)
                        {
                            nDeudaA = nDeudaA + cu.Deuda;
                        }
                    }
                    nDeuda = nDeuda + cu.Deuda;
                    nDeudaT = nDeudaT + nDeuda;
                    if(cu.FechaUltimoPago!=null)
                    {
                        nd = Convert.ToDateTime( cu.FechaUltimoPago)- cu.FechaVencimiento ;
                        nDias = nDias + nd.Days;
                        nCanCuot++;
                    }
                }

                colordeuda = backColorList;
                if (nDeuda > 0)
                {
                    colordeuda = Color.Red;
                    item.SubItems.Add(nDeuda.ToString("N2"), Color.Empty, colordeuda, fontList);
                }
                else
                {
                    item.SubItems.Add("Cancelado");//, Color.Empty, backColorList, fontList);
                }

                // Vnominal
                item.SubItems.Add(cre.ValorNominal.ToString("N2"));
                // dias mora
                if(nDias!=0 && nCanCuot !=0)
                {
                    nTmp = nDias / nCanCuot;
                }

                item.SubItems.Add(nTmp.ToString("N0"));

                item.SubItems.Add(qEs);//, Color.Empty, backColorList, fontList);
                item.SubItems.Add(cre.EmpresaID.ToString());
                if (esMor) item.SubItems.Add("M"); else item.SubItems.Add("");
                
                listCreditos.Items.Add(item);
            
                if (cre.AbogadoID>0)
                {
                    cAbogado = cAbogado + cre.CreditoID + ": " + cre.AbogadoID + " " + cre.FechaAbogado.ToShortDateString() + Environment.NewLine;
                }
            }
            listCreditos.OwnerDraw = true;
            listCreditos.FullRowSelect = true;
            listCreditos.View = View.Details;

            //return;

            int nD = 0;
            bool bColor = false;
            foreach (ListViewItem lic in listCreditos.Items)
            {
                lic.UseItemStyleForSubItems = false;
                if (lic.SubItems[6].BackColor == Color.Red)
                {
                    bColor = true;
                }
                if (nD == Convert.ToInt32(lic.SubItems[2].Text))
                {
                    //lic.SubItems[3].Text = "";
                }
                else
                {
                    nD = Convert.ToInt32(lic.SubItems[2].Text);
                    if (backColorList == Color.White)
                    {
                        backColorList = Color.LightBlue;
                    }
                    else
                    {
                        backColorList = Color.White;
                    }
                }
                lic.SubItems[1].BackColor = backColorList;
                lic.SubItems[4].BackColor = backColorList;
                lic.SubItems[5].BackColor = backColorList;
                lic.SubItems[6].BackColor = backColorList;
                lic.SubItems[7].BackColor = backColorList;
                lic.SubItems[8].BackColor = backColorList;
                lic.SubItems[9].BackColor = backColorList;

                lic.SubItems[1].Font = fontList;
                lic.SubItems[4].Font = fontList;
                lic.SubItems[5].Font = fontList;
                lic.SubItems[6].Font = fontList;
                lic.SubItems[7].Font = fontList;
                lic.SubItems[8].Font = fontList;
                lic.SubItems[9].Font = fontList;

                if (bColor) lic.SubItems[6].BackColor = Color.Red;
                bColor = false;
            }
        }
        private void Llenadatos_cliente(Cliente Reg)
        {
            if (Reg == null)
            {
                return;
            }
            string cTmp = "";
            lblCliNombre.Text = Reg.NombreCompleto;

            if (Reg.SexoID != null) lblCliSexo.Text = Reg.SexoID;   //lblCliSexo.Text = regCliente.Sexo.Nombre;
            lblCliFNaci.Text = Reg.FechaNacimiento.ToString();
            if (Reg.Profesion != null)
            {
                if (Reg.Profesion.ProfesionPadre != null) cTmp = Reg.Profesion.ProfesionPadre.Nombre;
                lblCliLaboral.Text = cTmp;
            }
            if (Reg.Tarjeta == true)
            {
                lblMsgTarjeta.Text = "Tarjeta";
            }
            Busca_Tel_Dir(); 
            Llena_Notas(Reg);
            btnCliModi.Enabled = true;
            Llena_Imagenes();
        }

        private void Busca_Tel_Dir() // edu nvo001
        {
            string Num = "";

            int clsd = 0;
            clsd = bl.pGlob.DatoCliente.ClaseDatoID;
            //string cTmp = "";  // edu nvo00
            Telefono regTelef;
            regTelef = bl.GetTelefonos(t => t.Documento == nCliDocu && t.TipoDocumentoID == cCliDocu && t.ClaseDatoID == clsd && t.EstadoID == ParametrosGlobales.EstadoVigenteID, o => o.OrderByDescending(p => p.Fecha)).FirstOrDefault();
            
            if (regTelef != null)
            {
                lblCliTelef.Text = regTelef.CodArea + " " + regTelef.Numero;
            }

            Domicilio regDomi;
            regDomi = bl.GetDomicilios(t => t.Documento == nCliDocu && t.TipoDocumentoID == cCliDocu && t.ClaseDatoID == clsd && t.EstadoID == ParametrosGlobales.EstadoVigenteID, 
                                       o => o.OrderByDescending(p => p.Fecha)).FirstOrDefault();
            
            if (regDomi != null)
            {
                if (regDomi.Direccion != null)
                {
            
                    if (regDomi.Numero != null)
                    {
                        Num = regDomi.Numero.ToString();
                    }
                    lblCliDomi.Text = "" + regDomi.Direccion + " " + Num;
                }
                    
                if (regDomi.Localidad != null) lblCliLoc.Text = regDomi.Localidad.Nombre;
                
                if (regDomi.Provincia != null) lblCliLoc.Text = lblCliLoc.Text + " " + regDomi.Provincia.Nombre;

            }

        }
        
        private void Llena_Notas(Cliente Reg)   //**EDU MOR**//
        {
            txtCliNota.Text = "";

            string cNombre = "";
            
            if (Reg != null)
            {
                if (Reg.Notas.Count > 0)
                {
                    List<Nota> regNota = Reg.Notas.OrderByDescending(c => c.Fecha).ToList();
                    
                    foreach (Nota not in regNota)
                    {
                        if (not.Usuario != null) cNombre = not.Usuario.nombre; else cNombre = "    ";
                        txtCliNota.Text = txtCliNota.Text + not.Fecha + " " + cNombre + ": -" + not.Detalle;
                        txtCliNota.Text = txtCliNota.Text + Environment.NewLine + Environment.NewLine;
                    }
                    return;
                }
            }
            return;
        }
        private void Llena_Imagenes()
        {
           
            picFoto.Image = bl.BuscarFotosDni(txtBuscaDoc.Text, ref rutasFoto);
            picFirma.Image = bl.BuscarUnaImagenDni(txtBuscaDoc.Text, "FIR", ref rutasImagen);
        }

        private void Pone_Enable(bool bEna)
        {
            panelBuscar.Enabled = !bEna;
            listCreditos.Enabled = bEna;
            panel1.Enabled = bEna;
            btnCreditos.Enabled = bEna;
            btnTarjeta.Enabled = bEna;
            btnScanner.Enabled = bEna;
            btnAlta.Enabled = bEna;
            btnSalir.TabStop = bEna;
            btnFoto.Enabled = bEna;

        }
        private void Limpia()
        {
            
            //                              variables
            nCliDocu = 0;
            cCliDocu = "";
            nFilaCredito = 0;
            
            this.Text = "Buscar cliente por documento";
            listCreditos.Items.Clear();
            cmbTipoDni.SelectedItem = 0;

            //                              CLIENTE
            lblCliNombre.Text = "";
            lblCliSexo.Text = "";
            lblCliFNaci.Text = "";
            txtCliNota.Text = "";
            lblCliLaboral.Text = "";
            btnCliModi.Enabled = false;
            picFoto.Image = null;
            picFirma.Image = null;
            
            lblCliDomi.Text = "";  
            lblCliTelef.Text = ""; 
            lblCliLoc.Text = "";
            //                              MENSAJES
            lblMsgAbogado.Text = "";
            lblMsgCamara.Text = "";
            lblMsgCancelado.Text = "";
            lblMsgTarjeta.Text = "";
            Pone_toolTip("", "");

            //                              variable
            nDeudaA = 0;
            nDeudaT = 0;
            cAbogado = "";

            lblMor.Visible = false;      //**EDU MOR**//
            RecargarEmpYComercio(lblMor.Visible); 

        }
        private void ObtenerMorosoEnCamara(int dni)
        {
            List<MorosoEnCamara> regCamara = bl.ObtenerMorosoEnCamara(dni, null);
            if (regCamara.Count > 0)
            {
                MorosoEnCamara mcam = regCamara.First();
                lblMsgCamara.Text = "Cámara";
                Pone_toolTip("CAMARA", mcam.APNOCA + Environment.NewLine + mcam.nombreEntidad);
            }
        }
        private void Pone_toolTip(string qTool, string qMsg)
        {
            if (qTool == "")
            {
                toolTipC.RemoveAll();
                toolTipC.ShowAlways = false;
                toolTipA.RemoveAll();
                toolTipA.ShowAlways = false;
                return;
            }

            if (qTool == "CAMARA")
            {
                toolTipC.AutoPopDelay = 5000;
                toolTipC.InitialDelay = 10;
                toolTipC.ReshowDelay = 500;
                toolTipC.ShowAlways = true;
                toolTipC.UseAnimation = true;
                toolTipC.IsBalloon = true;
                toolTipC.SetToolTip(this.lblMsgCamara, qMsg);
            }
            if (qTool == "ABOGADO")
            {
                toolTipA.AutoPopDelay = 5000;
                toolTipA.InitialDelay = 10;
                toolTipA.ReshowDelay = 500;
                toolTipA.ShowAlways = true;
                toolTipA.UseAnimation = true;
                toolTipA.IsBalloon = true;
                toolTipA.SetToolTip(this.lblMsgAbogado, qMsg);
            }
        }
        private void Configura_Inicio()
        {
            Configura_Controles();
            Utilidades.CargarCombo(cmbTipoDni, bl.GetTiposDocumento().ToList(), "TipoDocumentoID", "TipoDocumentoID");
            Configura_listas();
            Limpia();
            Pone_Enable(false);
            txtBuscaDoc.Text = "0";
            cmbTipoDni.SelectedIndex = 1;
            txtBuscaDoc.Focus();

        }
        private void Configura_listas()
        {
            listCreditos.View = View.Details;
            listCreditos.Columns.Add("", 0, HorizontalAlignment.Right);
            listCreditos.Sorting = SortOrder.Descending;
            listCreditos.Sort();                 
            listCreditos.Columns.Add("Fecha", 80, HorizontalAlignment.Right);

            listCreditos.Columns.Add("", 0, HorizontalAlignment.Right); //cre
            listCreditos.Columns.Add("", 0, HorizontalAlignment.Right);   //com
            listCreditos.Columns.Add("Crédito", 80, HorizontalAlignment.Right);
            listCreditos.Columns.Add("Comercio", 55, HorizontalAlignment.Right);
            listCreditos.Columns.Add("Estado", 80, HorizontalAlignment.Right);
            listCreditos.Columns.Add("V nominal", 80, HorizontalAlignment.Right);
            listCreditos.Columns.Add("Mora", 40, HorizontalAlignment.Right);
            listCreditos.Columns.Add("T/G/A", 55, HorizontalAlignment.Right);
            listCreditos.Columns.Add("", 0, HorizontalAlignment.Right);             //empresa   10
            listCreditos.Columns.Add("", 0, HorizontalAlignment.Right);             //esmor   11
            listCreditos.OwnerDraw = true;
            listCreditos.GridLines = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (btnBuscar.Text == "Buscar")
            {
                Busca_Cliente(Convert.ToInt32(txtBuscaDoc.Text), cmbTipoDni.Text);
            }
            else
            {
                Limpia();
                Pone_Enable(false);
                panelBuscar.Enabled = true;
                btnBuscar.Text = "Buscar";
                txtBuscaDoc.Focus();

            }

        }


        private void btnCliModi_Click(object sender, EventArgs e) //1
        {
            frmClienteNVO frm = new frmClienteNVO(this.p, "M", Convert.ToInt32(txtBuscaDoc.Text), cmbTipoDni.Text, lblMor.Visible); //edu202208
            frm.MdiParent = p;
            frm.Show();

        }



        private void listCreditos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listCreditos.SelectedItems[0].SubItems[11].Text == "")
            {
                Manda_a_Creditos();

                return;
            }
            else
            {
                int ncredito = Convert.ToInt32(listCreditos.SelectedItems[0].SubItems[2].Text);
                int ncomer = Convert.ToInt16(listCreditos.SelectedItems[0].SubItems[3].Text);
                bool bEsPru = false;
                if (listCreditos.SelectedItems[0].SubItems[11].Text != "") bEsPru = true;
                frmCobranzaNva frmACob = new frmCobranzaNva(p, this.bl, ncomer, ncredito, bEsPru);
                frmACob.MdiParent = p;
                frmACob.WindowState = FormWindowState.Maximized;
                frmACob.Show();
            }
        }

        private void listCreditos_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnCliNotas_Click(object sender, EventArgs e)
        {
            bool bEsPru = false;
            if (listCreditos.SelectedItems.Count > 0)
            {
                if (listCreditos.SelectedItems[0].SubItems[11].Text != "") bEsPru = true;
            }
            FrmNotasCliCred frmNot = new FrmNotasCliCred(p, this.bl, bl.pGlob.Comercio.ComercioID, 0, 0,
                        Convert.ToInt32(txtBuscaDoc.Text), lblCliNombre.Text, cmbTipoDni.Text, "DOCUMENTO", bEsPru);
            frmNot.ShowDialog();
            frmNot.Close();
            Llena_Notas(regCliente);  
        }

        private void btnCreditos_Click(object sender, EventArgs e)
        {
            Manda_a_Creditos();
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            if (bl.pGlob.Configuracion.BlockedVentas ?? false)
            {
                MessageBox.Show("No es posible realizar alta de créditos, consulte con casa central");
                return;
            }

            frmAltaCredito02 frmDarAlta = new frmAltaCredito02(p, this.bl, nCliDocu, cCliDocu, 0, regCliente.Apellido, 
                                regCliente.Nombre, (decimal)regCliente.Sueldo,0,
                                regCliente.Profesion.ProfesionPadreID, regCliente.Profesion.ProfesionID,2,false,false,false,false,lblMor.Visible, lblCliLaboral.Text);
            frmDarAlta.WindowState = FormWindowState.Maximized;
            frmDarAlta.MdiParent = Principal.ActiveForm;

            frmDarAlta.Show();
        }

        private void btnScanner_Click(object sender, EventArgs e)
        {
            frmScan frmScan = new frmScan(p, bl, regCliente.Documento, regCliente.TipoDocumento.TipoDocumentoID, regCliente.ToString(), lblMor.Visible, "CLIENTE");
            frmScan.MdiParent = Principal.ActiveForm;
            frmScan.Show();
        }



        private void btnFoto_Click(object sender, EventArgs e)
        {
            frmCamaraWeb frmWebCam = new frmCamaraWeb(p, bl, regCliente.Documento, regCliente.Nombre,lblMor.Visible);
            frmWebCam.Show();
        }

        private void panelBtn_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmBuscaCliDocumento_KeyDown(object sender, KeyEventArgs e)  //**EDU MOR**//
        {
            if(e.KeyCode== Keys.F9)
            {
                if (e.Shift)
                {
                    if (bl.LlevaM())
                    {
                        if(lblMor.Visible) return;
                        //lblMor.Visible = true;

                        RecargarEmpYComercio(true);
                        Busca_Cliente_Mor(Convert.ToInt32(txtBuscaDoc.Text), cmbTipoDni.Text);

                    }
                }
            }
        }
        private void picFoto_Click(object sender, EventArgs e)
        {
            if (rutasFoto.Count() > 0)
                Process.Start(rutasFoto[0]);
        }

        private void picFirma_Click(object sender, EventArgs e)
        {
            if (rutasImagen.Count() > 0)
                Process.Start(rutasImagen[0]);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void listCreditos_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            nFilaCredito = e.ItemIndex;
            this.Text = nFilaCredito.ToString();
        }
    }
}
