using System;                         ////convert, eventarg, eventhandler
using System.Collections.Generic;         //list<>
using System.Drawing;                  ///font , color
using System.Linq;                      // orderby()
using System.Windows.Forms;               //formWindowsState, listview, musearg, etc
using iComercio.Rest;                       //RestApi
using iComercio.Models;                     // modelos(cred, cuot, etc)



//using System.ComponentModel;
//using System.Data;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
//using System.Data.Entity;
//using iComercio.DAL;
//using iComercio.Delegados;
//using iComercio.ViewModels;
//using iComercio.Auxiliar;
//using Credin;
//using System.Globalization;

namespace iComercio.Forms
{
    public partial class FrmBuscaCliNombre : FRM                                                         //**edu**
    {
        List<Credito> regCreditoList;
        Color backColorList = Color.White;
        Color fontColor = Color.Empty;
        Font fontList = new Font("Verdana", 10F, FontStyle.Regular);
        List<Cliente> regClienteList;
        int nCantLineas = 0;
        int nCuantasLineasCargo = 0;
        public FrmBuscaCliNombre()
        {
            InitializeComponent();

        }

        private void FrmBuscaCliNombre_Load(object sender, EventArgs e)
        {                                   //2°
            lblMor.Visible = false;
            RecargarEmpYComercio(lblMor.Visible);
            Configura_listas();
            Configura_Controles();
            txtBuscaCli.Focus();
            txtBuscaCli.Select();
        }

        public FrmBuscaCliNombre(Principal p, RestApi ra)
            : base(p, ra)
        {                                   //1°
            InitializeComponent();
        }

        private void Busca_Cliente()
        {
            listCliente.Items.Clear();
            if (txtBuscaCli.Text == "") return;
            listCliente.Visible = false;
            
            string cBusca = txtBuscaCli.Text;

            switch(cmbBuscaCli.SelectedIndex)
            {
                case 0:
                    //DateTime Inicio = DateTime.Now;
                    //regClienteList = bl.GetDal(BaseID).context.Clientes.Where(c => c.NombreCompleto.Contains(cBusca)).OrderBy(o => o.Apellido).ToList();
                    regClienteList = bl.Get<Cliente>(BaseID,c => c.NombreCompleto.Contains(cBusca), p => p.OrderBy(o => o.Apellido)).ToList();
                    //DateTime Fin = DateTime.Now;
                    //TimeSpan t = (Fin - Inicio);
                    //MessageBox.Show(String.Format("Tardo:{0}:{1}:{2}", t.Hours, t.Minutes, t.Seconds));
                    break;

                    //regCreditoList = bl.Get<Credito>(c => c.Cliente.NombreCompleto.Contains(cBusca), p => p.OrderBy(o => o.Cliente.NombreCompleto)).ToList();
                    //Llena_lista("Titular");
                    //regCreditoList = bl.Get<Credito>(c => c.Gar1.NombreCompleto.Contains(cBusca), p => p.OrderBy(o => o.Gar1.NombreCompleto)).ToList();
                    //Llena_lista("Garante");
                    //regCreditoList = bl.Get<Credito>(c => c.Gar2.NombreCompleto.Contains(cBusca), p => p.OrderBy(o => o.Gar2.NombreCompleto)).ToList();
                    //Llena_lista("2° Garante");
                    //regCreditoList = bl.Get<Credito>(c => c.Gar3.NombreCompleto.Contains(cBusca), p => p.OrderBy(o => o.Gar3.NombreCompleto)).ToList();
                    //Llena_lista("3° Garante");
                    //regCreditoList = bl.Get<Credito>(c => c.Adi.NombreCompleto.Contains(cBusca), p => p.OrderBy(o => o.Adi.NombreCompleto)).ToList();
                    //Llena_lista("Adicional");
                    //break;
                case 1:
                    regClienteList = bl.Get<Cliente>(BaseID,c => c.Apellido.Contains(cBusca), p => p.OrderBy(o => o.Apellido)).ToList();
                    break;
                //regCreditoList = bl.Get<Credito>(c => c.Cliente.Apellido.Contains(cBusca), p => p.OrderBy(o => o.Cliente.Apellido)).ToList();
                    //Llena_lista("Titular");
                    //regCreditoList = bl.Get<Credito>(c => c.Gar1.Apellido.Contains(cBusca), p => p.OrderBy(o => o.Gar1.Apellido)).ToList();
                    //Llena_lista("Garante");
                    //regCreditoList = bl.Get<Credito>(c => c.Gar2.Apellido.Contains(cBusca), p => p.OrderBy(o => o.Gar2.Apellido)).ToList();
                    //Llena_lista("2° Garante");
                    //regCreditoList = bl.Get<Credito>(c => c.Gar3.Apellido.Contains(cBusca), p => p.OrderBy(o => o.Gar3.Apellido)).ToList();
                    //Llena_lista("3° Garante");
                    //regCreditoList = bl.Get<Credito>(c => c.Adi.Apellido.Contains(cBusca), p => p.OrderBy(o => o.Adi.Apellido)).ToList();
                    //Llena_lista("Adicional");
                    //break;
                case 2:
                    regClienteList = bl.Get<Cliente>(BaseID,c => c.Nombre.Contains(cBusca), p => p.OrderBy(o => o.Nombre)).ToList();
                    break;

                //regCreditoList = bl.Get<Credito>(c => c.Cliente.Nombre.Contains(cBusca), p => p.OrderBy(o => o.Cliente.Nombre)).ToList();
                    //Llena_lista("Titular");
                    //regCreditoList = bl.Get<Credito>(c => c.Gar1.Nombre.Contains(cBusca), p => p.OrderBy(o => o.Gar1.Nombre)).ToList();
                    //Llena_lista("Garante");
                    //regCreditoList = bl.Get<Credito>(c => c.Gar2.Nombre.Contains(cBusca), p => p.OrderBy(o => o.Gar2.Nombre)).ToList();
                    //Llena_lista("2° Garante");
                    //regCreditoList = bl.Get<Credito>(c => c.Gar3.Nombre.Contains(cBusca), p => p.OrderBy(o => o.Gar3.Nombre)).ToList();
                    //Llena_lista("3° Garante");
                    //regCreditoList = bl.Get<Credito>(c => c.Adi.Nombre.Contains(cBusca), p => p.OrderBy(o => o.Adi.Nombre)).ToList();
                    //Llena_lista("Adicional");
                    //break;

            }
            Llena_lista();

            listCliente.Visible = true;
        }
        private void Llena_lista()
        {
            if (regClienteList == null || regClienteList.Count == 0) return;
            nCantLineas = 0;
            ListViewItem item2;
            //Color colordeuda;
            //ListViewItem item;
            //decimal nDeuda = 0;
            //int docu = 0;

            backColorList = Color.White;
            foreach (Cliente cli in regClienteList)
            {
                nCuantasLineasCargo = 0;
                regCreditoList = cli.Creditos.ToList();
                Carga_Creditos(regCreditoList, "Titular", cli.NombreCompleto, cli.Documento, cli.TipoDocumentoID);
                regCreditoList = cli.CreditosAdi.ToList();
                Carga_Creditos(regCreditoList, "Adicional", cli.NombreCompleto, cli.Documento, cli.TipoDocumentoID);
                regCreditoList = cli.CreditosGar1.ToList();
                Carga_Creditos(regCreditoList, "Garante", cli.NombreCompleto, cli.Documento, cli.TipoDocumentoID);
                regCreditoList = cli.CreditosGar2.ToList();
                Carga_Creditos(regCreditoList, "Garante", cli.NombreCompleto, cli.Documento, cli.TipoDocumentoID);
                regCreditoList = cli.CreditosGar2.ToList();
                Carga_Creditos(regCreditoList, "Garante", cli.NombreCompleto, cli.Documento, cli.TipoDocumentoID);
                if (nCuantasLineasCargo==0)
                {
                    nCantLineas++;
                    item2 = new ListViewItem();
                    item2.UseItemStyleForSubItems = false;
                    item2 = new ListViewItem(cli.NombreCompleto);
                    item2.SubItems.Add(cli.Documento.ToString());
                    item2.SubItems.Add(cli.Documento.ToString("N0"));
                    item2.SubItems.Add(cli.TipoDocumentoID);
                    item2.SubItems.Add(cli.NombreCompleto);
                    item2.SubItems.Add("");
                    item2.SubItems.Add("");
                    item2.SubItems.Add("");
                    item2.SubItems.Add("");
                    item2.SubItems.Add("");
                    listCliente.Items.Add(item2);
                }
                if (nCantLineas > 200) break;
            }
            nCantLineas = 0;
            int nD = 0;
            bool bColor = false;
            //if(listCliente.Items.Count==0)
            //{
            //    nCantLineas++;
            //    item = new ListViewItem();
            //    item.UseItemStyleForSubItems = false;
            //    item = new ListViewItem(cNomb);
            //    item.SubItems.Add(nDoc.ToString());
            //    item.SubItems.Add(nDoc.ToString("N0"));
            //    item.SubItems.Add(cDoc);
            //    item.SubItems.Add(cNomb);
            //}
            foreach (ListViewItem lic in listCliente.Items)
            {
                nCantLineas++;
                lic.UseItemStyleForSubItems = false;
                if (lic.SubItems[5].BackColor == Color.Red) bColor = true;
                if (nD == Convert.ToInt32(lic.SubItems[1].Text))
                {
                    lic.SubItems[2].Text = "";
                    lic.SubItems[4].Text = "";
                }
                else
                {
                    nD = Convert.ToInt32(lic.SubItems[1].Text);
                    if (backColorList == Color.White) backColorList = Color.LightBlue; else backColorList = Color.White;
                }
                lic.SubItems[2].BackColor = backColorList;
                lic.SubItems[4].BackColor = backColorList;
                lic.SubItems[5].BackColor = backColorList;
                lic.SubItems[6].BackColor = backColorList;
                lic.SubItems[9].BackColor = backColorList;
                lic.SubItems[2].Font = fontList;
                lic.SubItems[4].Font = fontList;
                lic.SubItems[5].Font = fontList;
                lic.SubItems[6].Font = fontList;
                lic.SubItems[9].Font = fontList;

                if (bColor) lic.SubItems[5].BackColor = Color.Red;
                bColor = false;
            }
        }
        private void Carga_Creditos(List<Credito> credCarga, string tga, string cNomb, int nDoc, string cDoc)
        {
            if (credCarga == null || credCarga.Count == 0) return;
            
            decimal nDeuda = 0;
            int docu = 0;

            Color colordeuda;
            ListViewItem item;
            foreach (Credito cre in credCarga)
            {
                nCantLineas++;
                nCuantasLineasCargo++;
                item = new ListViewItem();
                item.UseItemStyleForSubItems = false;
                item = new ListViewItem(cNomb);
                item.SubItems.Add(nDoc.ToString());
                item.SubItems.Add(nDoc.ToString("N0"));
                item.SubItems.Add(cDoc);
                item.SubItems.Add(cNomb);

                docu = cre.Documento;

                nDeuda = 0;
                foreach (Cuota cu in cre.Cuotas)
                {
                    nDeuda = nDeuda + cu.Deuda;
                }
                colordeuda = backColorList;
                if (nDeuda > 0)
                {
                    colordeuda = Color.Red;
                }
                item.SubItems.Add(cre.CreditoID.ToString("N0"), Color.Empty, colordeuda, new Font("Verdana", 10F, FontStyle.Regular));
                item.SubItems.Add(cre.ComercioID.ToString());
                item.SubItems.Add(cre.CreditoID.ToString());
                item.SubItems.Add(cre.ComercioID.ToString());
                item.SubItems.Add(tga);
                listCliente.Items.Add(item);
            }

        
        }
        private void Llena_lista_XXXX(string tga)
        {
            if (regCreditoList == null || regCreditoList.Count == 0) return;
            int nCantLineas = 0;

            Color colordeuda;
            ListViewItem item;
            decimal nDeuda = 0;
            int docu = 0;
            
            backColorList = Color.White;

            foreach(Credito cre in regCreditoList)
            {
                nCantLineas++;
                item = new ListViewItem();
                item.UseItemStyleForSubItems = false;
                if (tga == "Titular") item = new ListViewItem(cre.Cliente.NombreCompleto);
                if (tga == "Garante") item = new ListViewItem(cre.Cliente.NombreCompleto);
                if (tga == "2° Garante") item = new ListViewItem(cre.Cliente.NombreCompleto);
                if (tga == "3° Garante") item = new ListViewItem(cre.Cliente.NombreCompleto);
                if (tga == "Adicional") item = new ListViewItem(cre.Cliente.NombreCompleto);

                //if (tga == "Titular") item = new ListViewItem(cre.Cliente.Nombre);
                //if (tga == "Garante") item = new ListViewItem(cre.Gar1.Nombre);
                //if (tga == "2° Garante") item = new ListViewItem(cre.Gar2.Nombre);
                //if (tga == "3° Garante") item = new ListViewItem(cre.Gar3.Nombre);
                //if (tga == "Adicional") item = new ListViewItem(cre.Adi.Nombre);


                if (tga=="Titular")
                {
                    item.SubItems.Add(cre.Documento.ToString());
                    item.SubItems.Add(cre.Documento.ToString("N0"));
                    item.SubItems.Add(cre.TipoDocumentoID);
                    item.SubItems.Add(cre.Cliente.NombreCompleto);
                }
                if (tga == "Garante")
                {
                    item.SubItems.Add(cre.Gar1.Documento.ToString());
                    item.SubItems.Add(cre.Gar1.Documento.ToString("N0"));
                    item.SubItems.Add(cre.Gar1.TipoDocumentoID);
                    item.SubItems.Add(cre.Gar1.NombreCompleto);
                }
                if (tga == "2° Garante")
                {
                    item.SubItems.Add(cre.Gar2.Documento.ToString());
                    item.SubItems.Add(cre.Gar2.Documento.ToString("N0"));
                    item.SubItems.Add(cre.Gar2.TipoDocumentoID);
                    item.SubItems.Add(cre.Gar2.NombreCompleto);
                }
                if (tga == "3° Garante")
                {
                    item.SubItems.Add(cre.Gar3.Documento.ToString());
                    item.SubItems.Add(cre.Gar3.Documento.ToString("N0"));
                    item.SubItems.Add(cre.Gar3.TipoDocumentoID);
                    item.SubItems.Add(cre.Gar3.NombreCompleto);
                }
                if (tga == "Adicional")
                {
                    item.SubItems.Add(cre.Adi.Documento.ToString());
                    item.SubItems.Add(cre.Adi.Documento.ToString("N0"));
                    item.SubItems.Add(cre.Adi.TipoDocumentoID);
                    item.SubItems.Add(cre.Adi.NombreCompleto);
                }
                docu = cre.Documento;

                nDeuda = 0;
                foreach(Cuota cu in cre.Cuotas)
                {
                    nDeuda = nDeuda + cu.Deuda;
                }
                colordeuda = backColorList;
                if (nDeuda > 0)
                {
                    colordeuda = Color.Red;
                }
                item.SubItems.Add(cre.CreditoID.ToString("N0"), Color.Empty, colordeuda, new Font("Verdana", 10F, FontStyle.Regular));
                item.SubItems.Add(cre.ComercioID.ToString());
                item.SubItems.Add(cre.CreditoID.ToString());
                item.SubItems.Add(cre.ComercioID.ToString());
                item.SubItems.Add(tga);
                listCliente.Items.Add(item);

                if (nCantLineas > 100) break;
            }
            nCantLineas = 0;
            int nD = 0;
            bool bColor = false;
            foreach (ListViewItem lic in listCliente.Items)
            {
                nCantLineas++;
                lic.UseItemStyleForSubItems = false;
                if (lic.SubItems[5].BackColor == Color.Red) bColor = true;
                if(nD==Convert.ToInt32(lic.SubItems[1].Text))
                {
                    lic.SubItems[2].Text = "";
                    lic.SubItems[4].Text = "";
                } 
                else
                {
                    nD = Convert.ToInt32(lic.SubItems[1].Text);
                    if (backColorList == Color.White)  backColorList = Color.LightBlue; else  backColorList = Color.White;
                }
                lic.SubItems[2].BackColor = backColorList;
                lic.SubItems[4].BackColor = backColorList;
                lic.SubItems[5].BackColor = backColorList;
                lic.SubItems[6].BackColor = backColorList;
                lic.SubItems[9].BackColor = backColorList;
                lic.SubItems[2].Font = fontList;
                lic.SubItems[4].Font = fontList;
                lic.SubItems[5].Font = fontList;
                lic.SubItems[6].Font = fontList;
                lic.SubItems[9].Font = fontList;

                if (bColor) lic.SubItems[5].BackColor = Color.Red;
                bColor = false;
            }
        }
        public void Configura_listas()
        {
            listCliente.View = View.Details;
            listCliente.Columns.Add("",0, HorizontalAlignment.Right);  // orden nombre
            listCliente.Columns.Add("", 0, HorizontalAlignment.Right);      // docu
            listCliente.Columns.Add("Documento", 100, HorizontalAlignment.Right);
            listCliente.Columns.Add("", 0, HorizontalAlignment.Right);          // tipodoc
            listCliente.Columns.Add("Nombre", 400, HorizontalAlignment.Left);
            listCliente.Sorting = SortOrder.Ascending;
            listCliente.Sort();            
            listCliente.Columns.Add("Crédito", 90, HorizontalAlignment.Right);
            listCliente.Columns.Add("Comercio", 80, HorizontalAlignment.Right);
            listCliente.Columns.Add("", 0, HorizontalAlignment.Right);     //Crédito
            listCliente.Columns.Add("",0, HorizontalAlignment.Right);     //Comercio
            listCliente.Columns.Add("T/G/A", 70, HorizontalAlignment.Right);     //Comercio
            listCliente.OwnerDraw = true;
            listCliente.GridLines = false;

            cmbBuscaCli.Items.Add("Apellido y nombre");
            cmbBuscaCli.Items.Add("Apellido");
            cmbBuscaCli.Items.Add("Nombre");
            cmbBuscaCli.SelectedIndex = 0;
            txtBuscaCli.Text = "";
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Busca_Cliente();
            Cursor.Current = Cursors.Default;
        }

        private void listCliente_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           if(e.X < 500)  //listCliente.Columns[6].Width)
           {
               int nndocu = Convert.ToInt32(listCliente.SelectedItems[0].SubItems[1].Text);
               string ccdocu = (listCliente.SelectedItems[0].SubItems[3].Text);
               FrmBuscaCliDocumento frmADocu = new FrmBuscaCliDocumento(p, this.bl, nndocu, ccdocu);
               frmADocu.MdiParent = Principal.ActiveForm;
               frmADocu.WindowState = FormWindowState.Maximized;
               frmADocu.Show();
           } 
           else
           {

               if (listCliente.SelectedItems[0].SubItems[7].Text == "") return;
               int ncredito = Convert.ToInt32( listCliente.SelectedItems[0].SubItems[7].Text);
               int ncomer = Convert.ToInt16(listCliente.SelectedItems[0].SubItems[8].Text);
                frmCobranzaNva frmACob = new frmCobranzaNva(p, this.bl, ncomer, ncredito, lblMor.Visible); ////edu202208
                frmACob.MdiParent = Principal.ActiveForm;
               frmACob.WindowState = FormWindowState.Maximized;
               frmACob.Show();
           }
        }



        private void txtBuscaCli_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                if(txtBuscaCli.Text!="")
                {
                    Busca_Cliente();
                }
            }
        }

        private void cmbBuscaCli_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbBuscaCli.SelectedIndex==0)
            {
                lblBuscar.Text = "Ingrese el apellido";
            }
            else
            {
                lblBuscar.Text = "Ingrese el nombre";
            }
        }

        private void Configura_Controles()
        {

            Configura_Colores(bl.pGlob.Comercio.EmpresaID);
            Recorre_Formulario(this);
            this.BackColor = ColorBackColorFrm;

            txtBuscaCli.Leave += new EventHandler(Evento_LeaveColor);
            txtBuscaCli.Enter += new EventHandler(Evento_EnterColor);
            txtBuscaCli.KeyPress += Txt_PasaConEnter_KeyPress;

            cmbBuscaCli.Leave += new EventHandler(Evento_LeaveColorCmb);
            cmbBuscaCli.Enter += new EventHandler(Evento_EnterColorCmb);
            cmbBuscaCli.KeyPress += Txt_PasaConEnter_KeyPress;

            listCliente.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(lista_Dibuja_Encabezado);
            listCliente.DrawSubItem += lista_DrawSubItem;
        }

        private void listCliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmBuscaCliNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode== Keys.F9)
            {
                if (e.Shift)
                {
                    if (bl.LlevaM())
                    {
                        if (lblMor.Visible ) return;
                        lblMor.Visible = true;
                        RecargarEmpYComercio(lblMor.Visible);

                    }
                }
            }
        }
        
    }
}
