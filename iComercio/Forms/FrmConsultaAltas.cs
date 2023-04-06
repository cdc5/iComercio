using System;                         ////convert, eventarg, eventhandler
using System.Collections.Generic;         //list<>
using System.Drawing;                  ///font , color
using System.Linq;                      // orderby()
using System.Windows.Forms;               //formWindowsState, listview, musearg, etc
using iComercio.Rest;                       //RestApi
using iComercio.Models;                     // modelos(cred, cuot, etc)

using iComercio.DAL;                      //<MorosoEnCamara>
using iComercio.Delegados;
namespace iComercio.Forms
{
    public partial class FrmConsultaAltas : FRM
    {

        //public BusinessLayer bl;
        //public event EventHandler<MensajeEventArgs> actualizarBarraDeEstado;
        //public event EventHandler actualizarBarraDeEstadoListo;
        Color backColorList = Color.White;
        Color fontColor = Color.Empty;
        Font fontList = new Font("Verdana", 8F, FontStyle.Regular);

        public FrmConsultaAltas()
        {
            InitializeComponent();
        }

        private void FrmConsultaAltas_Load(object sender, EventArgs e)
        {
            lblMor.Visible = false;    
            RecargarEmpYComercio(lblMor.Visible);
        }
        public FrmConsultaAltas(Principal p, string queHace)
            : base(p)
        {
            InitializeComponent();
            //QueHago = queHace;
            Configura_Inicio();
        }
        private void Manda_Impresora()
        {
            int[] lCol = new int[12];
            string cTit1 = this.Text;
            string cTit2 = "";
            string cImpresora = "";
            if(cmbBusca.SelectedIndex == 0)
            {
                lCol = new int[12];
                lCol[0] = 6;
                lCol[1] = 7;
                lCol[2] = 8; 
                lCol[3] = 9 ;
                lCol[4] = 10;
                lCol[5] =11 ;
                lCol[6] = 12;
                lCol[7] = 13;
                lCol[8] = 14;
                lCol[9] = 15;
                lCol[10] =16 ;
                lCol[11] = 17;
                cTit2= "Desde " + txtDesde.Value.ToShortDateString() + " Hasta " + txtHasta.Value.ToShortDateString();
                cImpresora = bl.GetImpresora("LISTADO ALTAS");
            }


            if(cImpresora == "")
            {
                MessageBox.Show("No está configurada la impresora");
                return;
            }
            //lCol[4] = 5;  "Microsoft XPS Document Writer"   "Microsoft Print to PDF"
            EnviaAImpresora ei = new EnviaAImpresora();
            ei.EnviarAImpresora(listBusca, lCol, cImpresora, cTit1, cTit2);
        }
        private void Busca_NoRenovadores()
        {
            listBusca.Items.Clear();
            listBusca.Visible = false;
            lblAguarde.Text = "AGUARDE  ";
            panel1.Enabled = false;
            Application.DoEvents(); 
            lblMsg.Text = "";
            List<Credito> regCreditoList;
            List<Credito> regCreditoList2;
            Cliente regCLiente;
            fontList = new Font("Verdana", 8F, FontStyle.Regular);
            fontColor = Color.Empty;
            backColorList = Color.LightSteelBlue;
            ListViewItem item;
            int nCantCred = Convert.ToInt16(txtCantCred.Text);
            DateTime fD = Convert.ToDateTime(txtDesde.Value.ToShortDateString());
            DateTime fH = Convert.ToDateTime(txtHasta.Value.ToShortDateString());
            fH = fH.AddDays(1);
            if ( nCantCred == 0) 
            {
                panel1.Enabled = true;
                lblMsg.Text = "Ingrese cantidad de crèditos";
                listBusca.Visible = true;
                return;
            }
            lblMsg.Text = "Buscando datos";
            //regCreditoList = bl.GetCreditos(c => c.FechaSolicitud >= fD && c.FechaSolicitud <= fH 
            //                    && c.EmpresaID == bl.pGlob.Comercio.EmpresaID
            //                    && c.ComercioID == bl.pGlob.Comercio.ComercioID,
            //                    or => or.OrderBy(o => o.FechaSolicitud),
            //                    "Cuotas,Cliente,Cliente.Domicilios,Cliente.Mails,Cliente.Telefonos").ToList();

            regCreditoList = bl.GetCreditos(BaseID, c => c.FechaSolicitud >= fD && c.FechaSolicitud <= fH
                                && c.EmpresaID == BaseID
                                && c.ComercioID == ComID,
                                or => or.OrderBy(o => o.FechaSolicitud),
                                "Cuotas,Cliente,Cliente.Domicilios,Cliente.Mails,Cliente.Telefonos").ToList(); if (regCreditoList.Count == 0)
            {
                panel1.Enabled = true;
                lblMsg.Text = "No se encontraron clientes";
                listBusca.Visible = true;
                return;
            }
            List<Mail> regMailList;
            List<Domicilio> regDirList;
            List<Telefono> regTelList;

            int nCant = 0;
            int[] nCliYaEsta = new int[regCreditoList.Count];
            int nCuantoArray = 0;
            bool bYaEsta = false;
            bool bPasa = true;
            DateTime fSolicitud = DateTime.Now.AddYears(-50);
            
            int nTmp = 0;
            string cTmp = "";
            string cTmp2 = "";
            string cTmp3 = "";
            int nCancel = 0;

            foreach (Credito cre in regCreditoList)
            {
                AguardeFrm(lblAguarde);
                bYaEsta = false;
                bPasa = true;
                for (int n = 0; n < nCuantoArray; n++ )
                {
                    if(nCliYaEsta[n] == cre.Documento)
                    {
                        bYaEsta = true;
                        break;
                    }
                }
                if (bYaEsta == false)
                {
                    nCliYaEsta[nCuantoArray] = cre.Documento;
                    nCuantoArray = nCuantoArray + 1;
                    regCLiente = cre.Cliente;
                    regCreditoList2 = regCLiente.Creditos.OrderByDescending(o => o.FechaSolicitud).ToList();
                    if (regCreditoList2.Count < nCantCred) bPasa = false;
                    if(bPasa)
                    {
                        fSolicitud = DateTime.Now.AddYears(-50);
                        nCancel = 0;
                        foreach (Credito crecli in regCreditoList2)
                        {
                            foreach(Cuota cuo in crecli.Cuotas)
                            {
                                if(cuo.Deuda > 0)
                                {
                                    bPasa = false; break;
                                }
                            }
                            if (fSolicitud < crecli.FechaSolicitud) fSolicitud = crecli.FechaSolicitud;
                            nCancel = nCancel + 1;
                        }
                    }
                    if(bPasa)
                    {
                        nCant = nCant + 1;
                        item = new ListViewItem(cre.Cliente.Documento.ToString());
                        item.UseItemStyleForSubItems = false;
                        item.SubItems.Add(cre.Cliente.Documento.ToString(), fontColor, backColorList, fontList);
                        item.SubItems.Add(cre.Cliente.Documento.ToString(), fontColor, backColorList, fontList);
                        item.SubItems.Add(cre.Cliente.Documento.ToString(), fontColor, backColorList, fontList);
                        item.SubItems.Add(cre.Cliente.Documento.ToString(), fontColor, backColorList, fontList);
                        item.SubItems.Add(cre.Cliente.TipoDocumentoID, fontColor, backColorList, fontList);//5
                        item.SubItems.Add(cre.Cliente.Documento.ToString(), fontColor, backColorList, fontList);
                        item.SubItems.Add(cre.Cliente.NombreCompleto, fontColor, backColorList, fontList);
                        item.SubItems.Add(fSolicitud.ToShortDateString(), fontColor, backColorList, fontList);

                        //************************************************************************************************************

                        cTmp = "";
                        cTmp2 = "";
                        cTmp3 = "";
                        regDirList = regCLiente.Domicilios.OrderByDescending(c => c.Fecha).ToList();
                        foreach (Domicilio dom in regDirList)
                        {
                            if (dom.EstadoID == bl.pGlob.Vigente.EstadoID)
                            {
                                cTmp = dom.DomicilioCompleto;
                                if (dom.Localidad != null) cTmp2 = dom.Localidad.Nombre;
                                if (dom.Complemento != null) cTmp3 = dom.Complemento;
                                break;
                            }
                        }
                        item.SubItems.Add(cTmp, fontColor, backColorList, fontList);//9
                        item.SubItems.Add(cTmp2, fontColor, backColorList, fontList);//10

                        cTmp = "";
                        cTmp2 = "";
                        regTelList = regCLiente.Telefonos.OrderByDescending(t => t.Fecha).ToList();
                        nTmp = 1;
                        foreach (Telefono tel in regTelList)
                        {
                            if (nTmp == 2)
                            {
                                if (tel.EstadoID == bl.pGlob.Vigente.EstadoID)
                                {
                                    cTmp2 = tel.TelefonoCompleto;
                                    break;
                                }
                            }
                            if (nTmp == 1)
                            {
                                if (tel.EstadoID == bl.pGlob.Vigente.EstadoID)
                                {
                                    cTmp = tel.TelefonoCompleto;
                                    nTmp++;
                                }
                            }
                        }
                        item.SubItems.Add(cTmp, fontColor, backColorList, fontList);//11
                        item.SubItems.Add(cTmp2, fontColor, backColorList, fontList);//12
                        item.SubItems.Add(cTmp3, fontColor, backColorList, fontList);//13
                        cTmp = "";
                        regMailList = regCLiente.Mails.OrderByDescending(m => m.Fecha).ToList();
                        foreach (Mail cMail in regMailList)
                        {
                            if (cMail.EstadoID == bl.pGlob.Vigente.EstadoID)
                            {
                                cTmp = cMail.Direccion;
                                break;
                            }
                        }
                        item.SubItems.Add(cTmp, fontColor, backColorList, fontList);//14
                        item.SubItems.Add(nCancel.ToString(), fontColor, backColorList, fontList);//15
                        item.SubItems.Add(regCLiente.Profesion.ProfesionPadre.Nombre, fontColor, backColorList, fontList);//16
                        item.SubItems.Add(regCLiente.Profesion.Nombre, fontColor, backColorList, fontList);//17
                        //************************************************************************************************************
                        listBusca.Items.Add(item);
                        if (backColorList == Color.White) backColorList = Color.LightSteelBlue; else backColorList = Color.White;
                    }
                }
            }
            BtnBusca.Text = "Otro";
            lblMsg.Text = nCant.ToString("N0") + " clients encontrados";
            listBusca.Visible = true;
        }
 

        private void Busca_Clientes()
        {
            listBusca.Items.Clear();
            listBusca.Visible = false;
            lblAguarde.Text = "AGUARDE  ";
            panel1.Enabled = false;
            Application.DoEvents(); 
            List<Credito> regCreditoList;
            List<Cliente> regCLienteList;
            List<Mail> regMailList;
            List<Domicilio> regDirList;
            List<Telefono> regTelList;
            List<Cuota> regCuotasList;
            fontList = new Font("Verdana", 8F, FontStyle.Regular);
            fontColor = Color.Empty;
            backColorList = Color.LightSteelBlue;
            ListViewItem item;
            int nMes = cmbBusca2.SelectedIndex + 1;
            lblMsg.Text = "";
            bl = new BusinessLayer();
            regCLienteList = bl.GetClientes(BaseID, c => c.FechaNacimiento.Value.Month == nMes).ToList();
            if (regCLienteList.Count == 0)
            {
                panel1.Enabled = true;
                lblMsg.Text = "No se encontraron clientes";
                listBusca.Visible = true;
                return;
            }
            int nCant = 0;
            DateTime fNaci;
            string cTmp="";
            string cTmp2="";
            string cTmp3 = "";
            int nTmp = 0;
            int nCancel = 0;
            int nSinCancel = 0;
            bool bCancel = true;
            bool bMuestra = false;
            lblMsg.Text = "Llenando datos en pantalla";
            foreach(Cliente cli in regCLienteList)
            {
                AguardeFrm(lblAguarde);
                nCant++;
                //if (bMuestra) lblMsg.Text = "Llenando datos en pantalla"; else lblMsg.Text = "";
                
                item = new ListViewItem(cli.Documento.ToString());
                item.UseItemStyleForSubItems = false;
                item.SubItems.Add(cli.Documento.ToString(), fontColor, backColorList, fontList);
                item.SubItems.Add(cli.Documento.ToString(), fontColor, backColorList, fontList);
                item.SubItems.Add("", fontColor, backColorList, fontList);
                item.SubItems.Add(cli.Documento.ToString(), fontColor, backColorList, fontList);
                item.SubItems.Add(cli.TipoDocumentoID, fontColor, backColorList, fontList);
                item.SubItems.Add(cli.Documento.ToString(), fontColor, backColorList, fontList);//6
                item.SubItems.Add(cli.NombreCompleto, fontColor, backColorList, fontList);//7
                fNaci= (DateTime)cli.FechaNacimiento;
                item.SubItems.Add(fNaci.ToShortDateString(), fontColor, backColorList, fontList);//8
                cTmp = "";
                cTmp2 = "";
                cTmp3 = "";
                regDirList = cli.Domicilios.OrderByDescending(c=>c.Fecha).ToList();
                foreach(Domicilio dom in regDirList)
                {
                    if(dom.EstadoID == bl.pGlob.Vigente.EstadoID)
                    {
                        cTmp=dom.DomicilioCompleto;
                        if (dom.Localidad != null) cTmp2 = dom.Localidad.Nombre;
                        if (dom.Complemento != null) cTmp3 = dom.Complemento;
                        break;
                    }
                }
                item.SubItems.Add(cTmp, fontColor, backColorList, fontList);//9
                item.SubItems.Add(cTmp2, fontColor, backColorList, fontList);//10

                cTmp = "";
                cTmp2 = "";
                regTelList = cli.Telefonos.OrderByDescending(t => t.Fecha).ToList();
                nTmp = 1;
                foreach(Telefono tel in regTelList)
                {
                    if(nTmp==2)
                    {
                        if (tel.EstadoID == bl.pGlob.Vigente.EstadoID)
                        {
                            cTmp2 = tel.TelefonoCompleto;
                            break;
                        }
                    }                    
                    if (nTmp == 1)
                    {
                        if (tel.EstadoID == bl.pGlob.Vigente.EstadoID)
                        {
                            cTmp = tel.TelefonoCompleto;
                            nTmp++;
                        }
                    }
                }
                item.SubItems.Add(cTmp, fontColor, backColorList, fontList);//11
                item.SubItems.Add(cTmp2, fontColor, backColorList, fontList);//12
                item.SubItems.Add(cTmp3, fontColor, backColorList, fontList);//13
                cTmp = "";
                regMailList = cli.Mails.OrderByDescending(m => m.Fecha).ToList();
                foreach(Mail cMail in regMailList)
                {
                    if (cMail.EstadoID == bl.pGlob.Vigente.EstadoID)
                    {
                        cTmp = cMail.Direccion;
                        break;
                    }
                }
                item.SubItems.Add(cTmp, fontColor, backColorList, fontList);//14

                nCancel = 0;
                nSinCancel = 0;
                regCreditoList = cli.Creditos.ToList();
                foreach(Credito cre in regCreditoList)
                {
                    regCuotasList = cre.Cuotas.ToList();
                    bCancel = true;
                    foreach(Cuota cuo in regCuotasList)
                    {
                        if(cuo.Deuda>0)
                        {
                            nSinCancel++;
                            bCancel = false;
                            break;
                        }
                    }
                    if (bCancel) nCancel++;
                }

                item.SubItems.Add(nCancel.ToString(), fontColor, backColorList, fontList);//15
                item.SubItems.Add(nSinCancel.ToString(), fontColor, backColorList, fontList);//16
                nTmp = nSinCancel + nCancel;
                item.SubItems.Add(nTmp.ToString(), fontColor, backColorList, fontList);//17
                listBusca.Items.Add(item);
                if (backColorList == Color.White) backColorList = Color.LightSteelBlue; else backColorList = Color.White;
                bMuestra = !bMuestra;
            }
            
            BtnBusca.Text = "Otro";
            lblMsg.Text = nCant.ToString("N0") + " clientes encontrados";
            panel1.Enabled = false;
            listBusca.Visible = true;
        }

        private void Busca_Vtas()
        {
            
            listBusca.Items.Clear();
            listBusca.Visible = false;
            lblAguarde.Text = "AGUARDE  ";
            panel1.Enabled = false;
            Application.DoEvents();
            List<Credito> regCreditoList;
            List<Credito> regCreditoList2;
            List<Telefono> regTelefonosList;
            Cliente regCLiente;
            List<Mail> regMailList;
            DateTime fD = Convert.ToDateTime(txtDesde.Value.ToShortDateString());
            DateTime fH = Convert.ToDateTime(txtHasta.Value.ToShortDateString());
            fH = fH.AddDays(1);
            fontList = new Font("Verdana", 8F, FontStyle.Regular);
            fontColor = Color.Empty;
            backColorList = Color.LightSteelBlue;
            ListViewItem item;
            bl = new BusinessLayer();

            DateTime Inicio = DateTime.Now;
            //regCreditoList = bl.GetCreditos(c => c.FechaSolicitud >= fD && c.FechaSolicitud <= fH 
            //                                && c.EmpresaID == bl.pGlob.Comercio.EmpresaID 
            //                                && c.ComercioID == bl.pGlob.Comercio.ComercioID,
            //                                or => or.OrderBy(o => o.FechaSolicitud), 
            //                                "Cuotas,Cliente,Cliente.Domicilios,Cliente.Mails,Cliente.Telefonos").ToList();


            regCreditoList = bl.GetCreditos(BaseID, c => c.FechaSolicitud >= fD && c.FechaSolicitud <= fH
                                            && c.EmpresaID == BaseID
                                            && c.ComercioID == ComID,
                                            or => or.OrderBy(o => o.FechaSolicitud),
                                            "Cuotas,Cliente,Cliente.Domicilios,Cliente.Mails,Cliente.Telefonos").ToList();
            if (regCreditoList.Count == 0)
            {
                panel1.Enabled = true;
                lblMsg.Text = "No se encontraron creditos";
                listBusca.Visible = true;
                return;
            }

            int nCant = 0;
            bool bPasa=false;
            int nTmp;
            string cTmp = "";
            int nCredCancel;
            int nCredSinCancel;
            DateTime fSolicitud=DateTime.Now;
            decimal nDeudaTot = 0;
            decimal nDeuda = 0;
            decimal nDeudaAtras = 0;
            bool bCamara = false;
            DateTime PriVenci = DateTime.Now.AddMonths(1);
            decimal nDeudaMes = 0;
            decimal nMora = 0;
            TimeSpan difFech;
            int nCantCUota = 0;
            decimal nMoraTotal = 0;
            foreach(Credito cre in regCreditoList)
            {
                AguardeFrm(lblAguarde);
                regCLiente = cre.Cliente;
                regCreditoList2 = regCLiente.Creditos.OrderByDescending(o=>o.FechaSolicitud).ToList();

                nCredCancel = 0;
                nCredSinCancel = 0;
                nDeudaMes = 0;
                nMora = 0;
                bPasa = false;
                nDeudaTot = 0;
                nDeudaAtras = 0;
                nMoraTotal = 0;
                if (regCreditoList2[0].FechaSolicitud >= fD && regCreditoList2[0].FechaSolicitud <= fH)
                {
                    fSolicitud = regCreditoList2[0].FechaSolicitud;
                    bPasa = true;
                    foreach (Credito crecli in regCreditoList2)
                    {
                        nDeuda = 0;
                        nCantCUota = 0;
                        nMora = 0;
                        foreach(Cuota cuo in crecli.Cuotas)
                        {
                            if(cuo.Deuda>0)
                            {
                                nDeuda = nDeuda + (cuo.Deuda);
                                if (cuo.FechaVencimiento < DateTime.Now) nDeudaAtras = nDeudaAtras + cuo.Deuda;
                                if (cuo.FechaVencimiento.Year == PriVenci.Year && cuo.FechaVencimiento.Month == PriVenci.Month) nDeudaMes = nDeudaMes + cuo.Importe;

                                difFech = DateTime.Now - cuo.FechaVencimiento;
                                nMora = nMora + difFech.Days;
                                nCantCUota++;

                            }else
                            {
                                if(cuo.FechaUltimoPago!=null)
                                {
                                    if (cuo.FechaUltimoPago > cuo.FechaVencimiento)
                                    {
                                        difFech = Convert.ToDateTime(cuo.FechaUltimoPago) - cuo.FechaVencimiento;
                                        nMora = nMora + difFech.Days;
                                        nCantCUota++;
                                    }
                                }
                            }
                        }
                        if (nDeuda > 0) nCredSinCancel++; else nCredCancel++;
                        nDeudaTot = nDeudaTot + nDeuda;
                        if (nMora > 0 && nCantCUota > 0) nMoraTotal = nMoraTotal + Convert.ToInt16(nMora / nCantCUota);
                    }
                }

                if(bPasa)
                {
                    nCant++;
                    item = new ListViewItem(cre.Cliente.Documento.ToString());
                    item.UseItemStyleForSubItems = false;
                    item.SubItems.Add(cre.Cliente.Documento.ToString(), fontColor, backColorList, fontList);
                    item.SubItems.Add(cre.Cliente.Documento.ToString(), fontColor, backColorList, fontList);
                    item.SubItems.Add(cre.Cliente.Documento.ToString(), fontColor, backColorList, fontList);
                    item.SubItems.Add(cre.Cliente.Documento.ToString(), fontColor, backColorList, fontList);
                    item.SubItems.Add(cre.Cliente.TipoDocumentoID, fontColor, backColorList, fontList);//5
                    item.SubItems.Add(cre.Cliente.Documento.ToString(), fontColor, backColorList, fontList);
                    item.SubItems.Add(cre.Cliente.NombreCompleto, fontColor, backColorList, fontList);
                    item.SubItems.Add(nCredSinCancel.ToString(), fontColor, backColorList, fontList);//8
                    item.SubItems.Add(nCredCancel.ToString(), fontColor, backColorList, fontList);//9
                    nTmp = nCredCancel + nCredSinCancel;
                    item.SubItems.Add(nTmp.ToString(), fontColor, backColorList, fontList);//10
                    item.SubItems.Add(fSolicitud.ToShortDateString(), fontColor, backColorList, fontList);//11
                    if (regCLiente.Telefonos.Count>0)
                    {
                        regTelefonosList = regCLiente.Telefonos.OrderByDescending(t => t.Fecha).ToList();
                        nTmp = 0;
                        foreach(Telefono tel in regTelefonosList)
                        {
                            item.SubItems.Add(tel.TelefonoCompleto, fontColor, backColorList, fontList);//12
                            nTmp++;
                            if (nTmp == 2) break;
                        }
                        if (nTmp == 1) item.SubItems.Add("", fontColor, backColorList, fontList);//13
                    }
                    else
                    {
                        item.SubItems.Add("", fontColor, backColorList, fontList);//12
                        item.SubItems.Add("", fontColor, backColorList, fontList);//13
                    }
                    cTmp = "";
                    if(regCLiente.Profesion != null)
                    {
                        cTmp = regCLiente.Profesion.Nombre;
                    }
                    item.SubItems.Add(cTmp, fontColor, backColorList, fontList);//14
                    bCamara = ObtenerMorosoEnCamara(regCLiente.Documento);
                    if (bCamara)
                    {
                        item.SubItems.Add("SI", fontColor, backColorList, fontList);//15
                    }
                    else
                    {
                        item.SubItems.Add("", fontColor, backColorList, fontList);//15
                    }

                    if(regCLiente.Mails.Count>0)
                    {
                        regMailList = regCLiente.Mails.OrderByDescending(m => m.Fecha).ToList();
                        nTmp = 0;
                        foreach(Mail mai in regMailList)
                        {
                            if(mai.EstadoID == bl.pGlob.Vigente.EstadoID)
                            {
                                item.SubItems.Add(mai.Direccion, fontColor, backColorList, fontList);//16
                                nTmp=1;
                                break;
                            }
                        }
                        if (nTmp == 0) item.SubItems.Add("", fontColor, backColorList, fontList);//16
                    }else
                    {
                        item.SubItems.Add("", fontColor, backColorList, fontList);//16
                    }
                    if (nMoraTotal > 0) nMoraTotal = nMoraTotal / regCreditoList2.Count;
                    item.SubItems.Add( Convert.ToInt16(nMoraTotal).ToString(), fontColor, backColorList, fontList);//17
                    item.SubItems.Add(nDeudaAtras.ToString("N2"), fontColor, backColorList, fontList);//18
                    item.SubItems.Add(nDeudaTot.ToString("N2"), fontColor, backColorList, fontList);//19
                    item.SubItems.Add(nDeudaMes.ToString("N2"), fontColor, backColorList, fontList);//20
                    listBusca.BeginUpdate();
                    listBusca.Items.Add(item);
                    listBusca.EndUpdate();
                    if (backColorList == Color.White) backColorList = Color.LightSteelBlue; else backColorList = Color.White;
                }
            }
            BtnBusca.Text = "Otro";
            lblMsg.Text = nCant.ToString("N0") + " créditos encontrados";
            panel1.Enabled = false;
            listBusca.Visible = true;
        }
        private void Busca_Morosos()
        {
            listBusca.Items.Clear();
            listBusca.Visible = false;
            lblAguarde.Text = "AGUARDE  ";
            panel1.Enabled = false;
            Application.DoEvents(); 
            Telefono Tel;
            Domicilio Dom;
            Mail mail;
            int nCant = 0;
            //int nCuotas = 0;
            int nMora = 0;
            //int nMoraTot = 0;
            string cTmp = "";
            decimal nTmp = 0;
            List<Cuota> regCuotaList;
            //List<Credito> regCreditoList;
            DateTime fD = Convert.ToDateTime(txtDesde.Value.ToShortDateString());
            DateTime fH = Convert.ToDateTime(txtHasta.Value.ToShortDateString());
            fH = fH.AddDays(1);
            fontList = new Font("Verdana", 8F, FontStyle.Regular);
            fontColor = Color.Empty;
            backColorList = Color.LightSteelBlue;
            ListViewItem item;

            //regCuotaList = bl.Get<Cuota>(c => c.FechaVencimiento >= fD && c.FechaVencimiento <= fH && c.Importe > c.ImportePago && c.EmpresaID == bl.pGlob.Comercio.EmpresaID && c.ComercioID == bl.pGlob.Comercio.ComercioID, or => or.OrderBy(o => o.FechaUltimoPago)).ToList();
            regCuotaList = bl.Get<Cuota>(BaseID, c => c.FechaVencimiento >= fD && c.FechaVencimiento <= fH && c.Importe > c.ImportePago 
                            && c.EmpresaID == BaseID && c.ComercioID == ComID
                            , or => or.OrderBy(o => o.FechaUltimoPago)).ToList();
       
            if (regCuotaList.Count == 0)
            {
                panel1.Enabled = true;
                lblMsg.Text = "No se encontraron clientes";
                listBusca.Visible = true;
                return;
            }
            int nCantCuotas = 0;
            bool bPasa = true;
            foreach (Cuota cuo in regCuotaList)
            {
                AguardeFrm(lblAguarde);
                bPasa = false;
                if(op1.Checked)
                { bPasa = true; }

                if (op2.Checked)
                {
                    nCantCuotas=0;
                    foreach(Cuota cuotas in cuo.Credito.Cuotas)
                    {
                        if (cuotas.Deuda > 0)
                        {
                            if (cuotas.FechaVencimiento < DateTime.Now) nCantCuotas++; ;
                        }
                    }
                    if(nCantCuotas ==1) bPasa = true; 
                }
                if (op3.Checked)
                { 
                    bPasa = true;
                    foreach (Cuota cuotas in cuo.Credito.Cuotas.OrderBy(c=> c.CuotaID))
                    {
                        if (cuotas.Deuda > 0)
                        {
                            if (cuotas.FechaVencimiento < DateTime.Now)
                            {
                                if (cuotas.CuotaID < cuo.CuotaID)
                                {
                                    bPasa = false;
                                    break;
                                }
                            }
                        }
                    }
                }

                if (bPasa)
                {
                    nCant++;
                    item = new ListViewItem(cuo.CreditoID.ToString());
                    item.UseItemStyleForSubItems = false;
                    item.SubItems.Add(cuo.EmpresaID.ToString(), fontColor, backColorList, fontList);
                    item.SubItems.Add(cuo.ComercioID.ToString(), fontColor, backColorList, fontList);
                    item.SubItems.Add(cuo.CreditoID.ToString(), fontColor, backColorList, fontList);
                    item.SubItems.Add(cuo.Documento.ToString(), fontColor, backColorList, fontList);
                    item.SubItems.Add(cuo.TipoDocumentoID, fontColor, backColorList, fontList);
                    item.SubItems.Add(cuo.Cliente.NombreCompleto, fontColor, backColorList, fontList); //6
                    item.SubItems.Add(cuo.CreditoID.ToString(), fontColor, backColorList, fontList); //7
                    cTmp = cuo.CuotaID.ToString() + " de " + cuo.CantidadCuotas.ToString();
                    item.SubItems.Add(cTmp, fontColor, backColorList, fontList); //8

                    Dom = cuo.Cliente.UltimoDomicilioCliente;
                    if (Dom != null)
                    {
                        item.SubItems.Add(Dom.DomicilioCompleto, fontColor, backColorList, fontList); //9
                    }
                    else
                    {
                        item.SubItems.Add("", fontColor, backColorList, fontList);//9
                    }
                    Tel = cuo.Cliente.UltimoTelefonoCliente;
                    if (Tel != null)
                    {
                        item.SubItems.Add(Tel.TelefonoCompleto, fontColor, backColorList, fontList);//10
                    }
                    else
                    {
                        item.SubItems.Add("", fontColor, backColorList, fontList);//10

                    }
                    Tel = cuo.Cliente.UltimoTelefonoEmpresa;
                    if (Tel != null)
                    {
                        item.SubItems.Add(Tel.TelefonoCompleto, fontColor, backColorList, fontList);//11
                    }
                    else
                    {
                        item.SubItems.Add("", fontColor, backColorList, fontList);//11

                    }
                    cTmp = "";
                    if (Dom.Localidad != null)
                    {
                        item.SubItems.Add(Dom.Localidad.Nombre, fontColor, backColorList, fontList); //12
                        cTmp = Dom.Localidad.CodPostal;

                    }
                    else
                    {
                        item.SubItems.Add("", fontColor, backColorList, fontList);//12
                    }
                    if (Dom.Provincia != null)
                    {
                        item.SubItems.Add(Dom.Provincia.Nombre, fontColor, backColorList, fontList); //13

                    }
                    else
                    {
                        item.SubItems.Add("", fontColor, backColorList, fontList);//13
                    }
                    item.SubItems.Add(cTmp, fontColor, backColorList, fontList); //14

                    mail = cuo.Cliente.UltimoMailCliente;
                    if (mail != null)
                    {
                        item.SubItems.Add(mail.Direccion, fontColor, backColorList, fontList);//15
                    }
                    else
                    {
                        item.SubItems.Add("", fontColor, backColorList, fontList);//15
                    }

                    nTmp = cuo.Importe;
                    item.SubItems.Add(nTmp.ToString("N2"), fontColor, backColorList, fontList); //16
                    nTmp = cuo.Importe - cuo.ImportePago;
                    item.SubItems.Add(nTmp.ToString("N2"), fontColor, backColorList, fontList); //17
                    nTmp = Calcula_Punitorio(cuo.Importe - cuo.ImportePago, cuo.FechaVencimiento, (decimal)cuo.Comercio.Por30, (decimal)cuo.Comercio.Por30M,false);
                    item.SubItems.Add(nTmp.ToString("N2"), fontColor, backColorList, fontList); //18
                    nTmp = nTmp + (cuo.Importe - cuo.ImportePago);
                    item.SubItems.Add(nTmp.ToString("N2"), fontColor, backColorList, fontList); //19
                    item.SubItems.Add(cuo.FechaVencimiento.ToShortDateString(), fontColor, backColorList, fontList); //20
                    item.SubItems.Add(cuo.FechaUltimoPago.ToString(), fontColor, backColorList, fontList); //20
                    item.SubItems.Add(cuo.Credito.FechaSolicitud.ToShortDateString(), fontColor, backColorList, fontList); //22
                    nMora = bl.Calcula_dias_mora(cuo.FechaVencimiento, DateTime.Now);
                    item.SubItems.Add(nMora.ToString(), fontColor, backColorList, fontList);
                    listBusca.Items.Add(item);
                    if (backColorList == Color.White) backColorList = Color.LightSteelBlue; else backColorList = Color.White;
                }
            }
            Agrega_linea("T1", true, 24);  //eduardo cambio
            lblMsg.Text = nCant.ToString("N0") + " créditos encontrados";
            panel1.Enabled = false;
            listBusca.Visible = true;
            BtnBusca.Text = "Otro";
        }
        private void Manda_Plani_Otros()
        {
            Mando_A_Portapapeles_Grid(Grid, false);
            MessageBox.Show("Datos pegados en el portapapeles" + Environment.NewLine + "Abra un planilla y pegue los datos");
        }
        private void Manda_Excel_02()
        {
            int nC = listBusca.Columns.Count;//columnas
            int nF = listBusca.Items.Count;//filas

            int nCant = 0;

            string[, , ,] ConsuCred = new string[nF, nC, 2, 2];
            if (cmbBusca.SelectedIndex == 0)
            {
                ConsuCred[nCant, 0, 0, 0] = listBusca.Columns[6].Text;
                ConsuCred[nCant, 0, 1, 0] = "E";
                ConsuCred[nCant, 1, 0, 0] = listBusca.Columns[7].Text;
                ConsuCred[nCant, 1, 1, 0] = "E";
                ConsuCred[nCant, 2, 0, 0] = listBusca.Columns[8].Text;
                ConsuCred[nCant, 2, 1, 0] = "E";
                ConsuCred[nCant, 3, 0, 0] = listBusca.Columns[9].Text;
                ConsuCred[nCant, 3, 1, 0] = "E";
                ConsuCred[nCant, 4, 0, 0] = listBusca.Columns[10].Text;
                ConsuCred[nCant, 4, 1, 0] = "E";
                ConsuCred[nCant, 5, 0, 0] = listBusca.Columns[11].Text;
                ConsuCred[nCant, 5, 1, 0] = "E";
                ConsuCred[nCant, 6, 0, 0] = listBusca.Columns[12].Text;
                ConsuCred[nCant, 6, 1, 0] = "E";
                ConsuCred[nCant, 7, 0, 0] = listBusca.Columns[13].Text;
                ConsuCred[nCant, 7, 1, 0] = "E";
                ConsuCred[nCant, 8, 0, 0] = listBusca.Columns[14].Text;
                ConsuCred[nCant, 8, 1, 0] = "E";
                ConsuCred[nCant, 9, 0, 0] = listBusca.Columns[15].Text;
                ConsuCred[nCant, 9, 1, 0] = "E";
                ConsuCred[nCant, 10, 0, 0] = listBusca.Columns[16].Text;
                ConsuCred[nCant, 10, 1, 0] = "E";
                ConsuCred[nCant, 11, 0, 0] = listBusca.Columns[17].Text;
                ConsuCred[nCant, 11, 1, 0] = "E";
                ConsuCred[nCant, 12, 0, 0] = listBusca.Columns[18].Text;
                ConsuCred[nCant, 12, 1, 0] = "E";
                ConsuCred[nCant, 13, 0, 0] = listBusca.Columns[19].Text;
                ConsuCred[nCant, 13, 1, 0] = "E";
                ConsuCred[nCant, 14, 0, 0] = listBusca.Columns[20].Text;
                ConsuCred[nCant, 14, 1, 0] = "E";
                ConsuCred[nCant, 15, 0, 0] = listBusca.Columns[21].Text;
                ConsuCred[nCant, 15, 1, 0] = "E";
                ConsuCred[nCant, 16, 0, 0] = listBusca.Columns[22].Text;
                ConsuCred[nCant, 16, 1, 0] = "E";
            }

            else if (cmbBusca.SelectedIndex == 2)
            {
                ConsuCred[nCant, 0, 0, 0] = listBusca.Columns[6].Text;
                ConsuCred[nCant, 0, 1, 0] = "E";
                ConsuCred[nCant, 1, 0, 0] = listBusca.Columns[7].Text;
                ConsuCred[nCant, 1, 1, 0] = "E";
                ConsuCred[nCant, 2, 0, 0] = listBusca.Columns[8].Text;
                ConsuCred[nCant, 2, 1, 0] = "E";
                ConsuCred[nCant, 3, 0, 0] = listBusca.Columns[9].Text;
                ConsuCred[nCant, 3, 1, 0] = "E";
                ConsuCred[nCant, 4, 0, 0] = listBusca.Columns[10].Text;
                ConsuCred[nCant, 4, 1, 0] = "E";
                ConsuCred[nCant, 5, 0, 0] = listBusca.Columns[11].Text;
                ConsuCred[nCant, 5, 1, 0] = "E";
                ConsuCred[nCant, 6, 0, 0] = listBusca.Columns[12].Text;
                ConsuCred[nCant, 6, 1, 0] = "E";            
            }
            else if (cmbBusca.SelectedIndex == 3)
            {
                ConsuCred[nCant, 0, 0, 0] = listBusca.Columns[6].Text;
                ConsuCred[nCant, 0, 1, 0] = "E";
                ConsuCred[nCant, 1, 0, 0] = listBusca.Columns[7].Text;
                ConsuCred[nCant, 1, 1, 0] = "E";
                ConsuCred[nCant, 2, 0, 0] = listBusca.Columns[8].Text;
                //ConsuCred[nCant, 2, 1, 0] = "E";
                ConsuCred[nCant, 3, 0, 0] = listBusca.Columns[9].Text;
                ConsuCred[nCant, 3, 1, 0] = "E";
                ConsuCred[nCant, 4, 0, 0] = listBusca.Columns[10].Text;
                ConsuCred[nCant, 4, 1, 0] = "E";
                ConsuCred[nCant, 5, 0, 0] = listBusca.Columns[11].Text;
                ConsuCred[nCant, 5, 1, 0] = "E";
                ConsuCred[nCant, 6, 0, 0] = listBusca.Columns[12].Text;
                ConsuCred[nCant, 6, 1, 0] = "E";
                ConsuCred[nCant, 7, 0, 0] = listBusca.Columns[13].Text;
                ConsuCred[nCant, 7, 1, 0] = "E";

                ConsuCred[nCant, 8, 0, 0] = listBusca.Columns[14].Text;
                ConsuCred[nCant, 8, 1, 0] = "E";
                ConsuCred[nCant, 9, 0, 0] = listBusca.Columns[15].Text;
                ConsuCred[nCant, 9, 1, 0] = "E";
                ConsuCred[nCant, 10, 0, 0] = listBusca.Columns[16].Text;
                ConsuCred[nCant, 10, 1, 0] = "E";
                ConsuCred[nCant, 11, 0, 0] = listBusca.Columns[17].Text;
                ConsuCred[nCant, 11, 1, 0] = "E";
                ConsuCred[nCant, 12, 0, 0] = listBusca.Columns[18].Text;
                ConsuCred[nCant, 12, 1, 0] = "E";
                ConsuCred[nCant, 13, 0, 0] = listBusca.Columns[19].Text;
                ConsuCred[nCant, 13, 1, 0] = "E";
                ConsuCred[nCant, 14, 0, 0] = listBusca.Columns[20].Text;
                ConsuCred[nCant, 14, 1, 0] = "E";
                ConsuCred[nCant, 15, 0, 0] = listBusca.Columns[21].Text;
                ConsuCred[nCant, 15, 1, 0] = "E";
                ConsuCred[nCant, 16, 0, 0] = listBusca.Columns[22].Text;
                ConsuCred[nCant, 16, 1, 0] = "E";
                ConsuCred[nCant, 17, 0, 0] = listBusca.Columns[23].Text;
                ConsuCred[nCant, 17, 1, 0] = "E";
            }
            else if (cmbBusca.SelectedIndex == 4)
            {
                ConsuCred[nCant, 0, 0, 0] = listBusca.Columns[6].Text;
                ConsuCred[nCant, 0, 1, 0] = "E";
                ConsuCred[nCant, 1, 0, 0] = listBusca.Columns[7].Text;
                ConsuCred[nCant, 1, 1, 0] = "E";
                ConsuCred[nCant, 2, 0, 0] = listBusca.Columns[8].Text;
                ConsuCred[nCant, 2, 1, 0] = "E";
                ConsuCred[nCant, 3, 0, 0] = listBusca.Columns[9].Text;
                ConsuCred[nCant, 3, 1, 0] = "E";
                ConsuCred[nCant, 4, 0, 0] = listBusca.Columns[10].Text;
                ConsuCred[nCant, 4, 1, 0] = "E";
                ConsuCred[nCant, 5, 0, 0] = listBusca.Columns[11].Text;
                ConsuCred[nCant, 5, 1, 0] = "E";
                ConsuCred[nCant, 6, 0, 0] = listBusca.Columns[12].Text;
                ConsuCred[nCant, 6, 1, 0] = "E";
                ConsuCred[nCant, 7, 0, 0] = listBusca.Columns[13].Text;
                ConsuCred[nCant, 7, 1, 0] = "E";
                ConsuCred[nCant, 8, 0, 0] = listBusca.Columns[14].Text;
                ConsuCred[nCant, 8, 1, 0] = "E";
                ConsuCred[nCant, 9, 0, 0] = listBusca.Columns[15].Text;
                ConsuCred[nCant, 9, 1, 0] = "E";
                ConsuCred[nCant, 10, 0, 0] = listBusca.Columns[16].Text;
                ConsuCred[nCant, 10, 1, 0] = "E";
                ConsuCred[nCant, 11, 0, 0] = listBusca.Columns[17].Text;
                ConsuCred[nCant, 11, 1, 0] = "E";
                ConsuCred[nCant, 12, 0, 0] = listBusca.Columns[18].Text;
                ConsuCred[nCant, 12, 1, 0] = "E";
                ConsuCred[nCant, 13, 0, 0] = listBusca.Columns[19].Text;
                ConsuCred[nCant, 13, 1, 0] = "E";
                ConsuCred[nCant, 14, 0, 0] = listBusca.Columns[20].Text;
                ConsuCred[nCant, 14, 1, 0] = "E";
            }
            else if (cmbBusca.SelectedIndex == 5)
            {
                ConsuCred[nCant, 0, 0, 0] = listBusca.Columns[6].Text;
                ConsuCred[nCant, 0, 1, 0] = "E";
                ConsuCred[nCant, 1, 0, 0] = listBusca.Columns[7].Text;
                ConsuCred[nCant, 1, 1, 0] = "E";
                ConsuCred[nCant, 2, 0, 0] = listBusca.Columns[8].Text;
                ConsuCred[nCant, 2, 1, 0] = "E";
                ConsuCred[nCant, 3, 0, 0] = listBusca.Columns[9].Text;
                ConsuCred[nCant, 3, 1, 0] = "E";
                ConsuCred[nCant, 4, 0, 0] = listBusca.Columns[10].Text;
                ConsuCred[nCant, 4, 1, 0] = "E";
                ConsuCred[nCant, 5, 0, 0] = listBusca.Columns[11].Text;
                ConsuCred[nCant, 5, 1, 0] = "E";
                ConsuCred[nCant, 6, 0, 0] = listBusca.Columns[12].Text;
                ConsuCred[nCant, 6, 1, 0] = "E";
                ConsuCred[nCant, 7, 0, 0] = listBusca.Columns[13].Text;
                ConsuCred[nCant, 7, 1, 0] = "E";
                ConsuCred[nCant, 8, 0, 0] = listBusca.Columns[14].Text;
                ConsuCred[nCant, 8, 1, 0] = "E";
                ConsuCred[nCant, 9, 0, 0] = listBusca.Columns[15].Text;
                ConsuCred[nCant, 9, 1, 0] = "E";
                ConsuCred[nCant, 10, 0, 0] = listBusca.Columns[16].Text;
                ConsuCred[nCant, 10, 1, 0] = "E";
                ConsuCred[nCant, 11, 0, 0] = listBusca.Columns[17].Text;
                ConsuCred[nCant, 11, 1, 0] = "E";
            }
            else if (cmbBusca.SelectedIndex == 6)
            {
                ConsuCred[nCant, 0, 0, 0] = listBusca.Columns[6].Text;
                ConsuCred[nCant, 0, 1, 0] = "E";
                ConsuCred[nCant, 1, 0, 0] = listBusca.Columns[7].Text;
                ConsuCred[nCant, 1, 1, 0] = "E";
                ConsuCred[nCant, 2, 0, 0] = listBusca.Columns[8].Text;
                ConsuCred[nCant, 2, 1, 0] = "E";
                ConsuCred[nCant, 3, 0, 0] = listBusca.Columns[9].Text;
                ConsuCred[nCant, 3, 1, 0] = "E";
                ConsuCred[nCant, 4, 0, 0] = listBusca.Columns[10].Text;
                ConsuCred[nCant, 4, 1, 0] = "E";
                ConsuCred[nCant, 5, 0, 0] = listBusca.Columns[11].Text;
                ConsuCred[nCant, 5, 1, 0] = "E";
                ConsuCred[nCant, 6, 0, 0] = listBusca.Columns[12].Text;
                ConsuCred[nCant, 6, 1, 0] = "E";
                ConsuCred[nCant, 7, 0, 0] = listBusca.Columns[13].Text;
                ConsuCred[nCant, 7, 1, 0] = "E";
                ConsuCred[nCant, 8, 0, 0] = listBusca.Columns[14].Text;
                ConsuCred[nCant, 8, 1, 0] = "E";
                ConsuCred[nCant, 9, 0, 0] = listBusca.Columns[15].Text;
                ConsuCred[nCant, 9, 1, 0] = "E";
                ConsuCred[nCant, 10, 0, 0] = listBusca.Columns[16].Text;
                ConsuCred[nCant, 10, 1, 0] = "E";
                ConsuCred[nCant, 11, 0, 0] = listBusca.Columns[17].Text;
                ConsuCred[nCant, 11, 1, 0] = "E";
            }


            foreach (ListViewItem item in listBusca.Items)
            {
                nCant++;
                if (nCant >= nF) break;

                if (cmbBusca.SelectedIndex == 0)
                {
                    ConsuCred[nCant, 0, 0, 0] = item.SubItems[3].Text;
                    ConsuCred[nCant, 0, 1, 0] = "T";
                    ConsuCred[nCant, 1, 0, 0] = item.SubItems[7].Text;
                    ConsuCred[nCant, 1, 1, 0] = "T";
                    ConsuCred[nCant, 2, 0, 0] = item.SubItems[8].Text;
                    ConsuCred[nCant, 3, 0, 0] = item.SubItems[9].Text;
                    ConsuCred[nCant, 3, 1, 0] = "D";
                    ConsuCred[nCant, 4, 0, 0] = item.SubItems[10].Text;
                    ConsuCred[nCant, 4, 1, 0] = "F";
                    ConsuCred[nCant, 5, 0, 0] = item.SubItems[11].Text;
                    ConsuCred[nCant, 6, 0, 0] = item.SubItems[12].Text;
                    ConsuCred[nCant, 6, 1, 0] = "D";
                    ConsuCred[nCant, 7, 0, 0] = item.SubItems[13].Text;
                    ConsuCred[nCant, 7, 1, 0] = "D";
                    ConsuCred[nCant, 8, 0, 0] = item.SubItems[14].Text;
                    ConsuCred[nCant, 9, 0, 0] = item.SubItems[15].Text;
                    ConsuCred[nCant, 10, 0, 0] = item.SubItems[16].Text;
                    ConsuCred[nCant, 10, 1, 0] = "D";
                    ConsuCred[nCant, 11, 0, 0] = item.SubItems[17].Text;
                    ConsuCred[nCant, 11, 1, 0] = "D";
                    ConsuCred[nCant, 12, 0, 0] = item.SubItems[18].Text;
                    ConsuCred[nCant, 13, 0, 0] = item.SubItems[19].Text;
                    ConsuCred[nCant, 13, 1, 0] = "D";
                    ConsuCred[nCant, 14, 0, 0] = item.SubItems[20].Text;
                    ConsuCred[nCant, 15, 0, 0] = item.SubItems[21].Text;
                    ConsuCred[nCant, 16, 0, 0] = item.SubItems[22].Text;


                }
                else if (cmbBusca.SelectedIndex == 2)
                {
                    ConsuCred[nCant, 0, 0, 0] = item.SubItems[6].Text;
                    ConsuCred[nCant, 0, 1, 0] = "T";
                    ConsuCred[nCant, 1, 0, 0] = item.SubItems[7].Text;
                    ConsuCred[nCant, 1, 1, 0] = "T";
                    ConsuCred[nCant, 2, 0, 0] = item.SubItems[8].Text;
                    ConsuCred[nCant, 3, 0, 0] = item.SubItems[9].Text;
                    ConsuCred[nCant, 5, 0, 0] = item.SubItems[10].Text;
                    ConsuCred[nCant, 5, 1, 0] = "F";

                    ConsuCred[nCant, 6, 0, 0] = item.SubItems[11].Text;

                    ConsuCred[nCant, 7, 0, 0] = item.SubItems[11].Text;
                    ConsuCred[nCant, 7, 1, 0] = "D";

                }
                else if (cmbBusca.SelectedIndex == 1)
                {
                    ConsuCred[nCant, 0, 0, 0] = item.SubItems[6].Text;
                    ConsuCred[nCant, 0, 1, 0] = "T";
                    ConsuCred[nCant, 1, 0, 0] = item.SubItems[7].Text;
                    ConsuCred[nCant, 1, 1, 0] = "T";
                    ConsuCred[nCant, 2, 0, 0] = item.SubItems[8].Text;

                    ConsuCred[nCant, 3, 0, 0] = item.SubItems[9].Text;
                    ConsuCred[nCant, 4, 0, 0] = item.SubItems[10].Text;
                    ConsuCred[nCant, 5, 0, 0] = item.SubItems[11].Text;
                    ConsuCred[nCant, 6, 0, 0] = item.SubItems[12].Text;
                    ConsuCred[nCant, 7, 0, 0] = item.SubItems[13].Text;
                }
                else if (cmbBusca.SelectedIndex == 3)
                {
                    ConsuCred[nCant, 0, 0, 0] = item.SubItems[6].Text;
                    //ConsuCred[nCant, 0, 1, 0] = "T";
                    ConsuCred[nCant, 1, 0, 0] = item.SubItems[7].Text;
                    //ConsuCred[nCant, 1, 1, 0] = "T";
                    ConsuCred[nCant, 2, 0, 0] = item.SubItems[8].Text;
                    ConsuCred[nCant, 3, 0, 0] = item.SubItems[9].Text;
                    ConsuCred[nCant, 5, 0, 0] = item.SubItems[10].Text;
                    ConsuCred[nCant, 6, 0, 0] = item.SubItems[11].Text;
                    //ConsuCred[nCant, 5, 1, 0] = "F";
                    ConsuCred[nCant, 7, 0, 0] = item.SubItems[12].Text;
                    //ConsuCred[nCant, 6, 1, 0] = "D";
                    ConsuCred[nCant, 8, 0, 0] = item.SubItems[13].Text;
                    //ConsuCred[nCant, 7, 1, 0] = "D";
                    ConsuCred[nCant, 9, 0, 0] = item.SubItems[14].Text;
                    ConsuCred[nCant, 11, 0, 0] = item.SubItems[15].Text;
                    ConsuCred[nCant, 12, 0, 0] = item.SubItems[16].Text;
                    ConsuCred[nCant, 12, 1, 0] = "D";
                    ConsuCred[nCant, 13, 0, 0] = item.SubItems[17].Text;
                    ConsuCred[nCant, 13, 1, 0] = "D";
                    ConsuCred[nCant, 14, 0, 0] = item.SubItems[18].Text;
                    ConsuCred[nCant, 14, 1, 0] = "D";
                    ConsuCred[nCant, 15, 0, 0] = item.SubItems[19].Text;
                    ConsuCred[nCant, 15, 1, 0] = "D";
                    ConsuCred[nCant, 16, 0, 0] = item.SubItems[20].Text;
                    ConsuCred[nCant, 16, 1, 0] = "F";
                    ConsuCred[nCant, 17, 0, 0] = item.SubItems[21].Text;
                    ConsuCred[nCant, 17, 1, 0] = "F";
                    ConsuCred[nCant, 18, 0, 0] = item.SubItems[22].Text;
                    ConsuCred[nCant, 18, 1, 0] = "F";
                    ConsuCred[nCant, 19, 0, 0] = item.SubItems[23].Text;
                    //ConsuCred[nCant, 18, 0, 0] = item.SubItems[24].Text;
                    //ConsuCred[nCant, 19, 0, 0] = item.SubItems[25].Text;
                    //ConsuCred[nCant, 20, 0, 0] = item.SubItems[26].Text;
                    //ConsuCred[nCant, 21, 0, 0] = item.SubItems[27].Text;
                    //ConsuCred[nCant, 22, 0, 0] = item.SubItems[28].Text;
                    //ConsuCred[nCant, 23, 0, 0] = item.SubItems[29].Text;

                }
                 else if (cmbBusca.SelectedIndex == 4)
                {
                    ConsuCred[nCant, 0, 0, 0] = item.SubItems[6].Text;
                    //ConsuCred[nCant, 0, 1, 0] = "T";
                    ConsuCred[nCant, 1, 0, 0] = item.SubItems[7].Text;
                    //ConsuCred[nCant, 1, 1, 0] = "T";
                    ConsuCred[nCant, 2, 0, 0] = item.SubItems[8].Text;
                    ConsuCred[nCant, 3, 0, 0] = item.SubItems[9].Text;
                    //ConsuCred[nCant, 3, 1, 0] = "D";
                    ConsuCred[nCant, 4, 0, 0] = item.SubItems[10].Text;
                    ConsuCred[nCant, 5, 0, 0] = item.SubItems[11].Text;
                    ConsuCred[nCant, 5, 1, 0] = "F";
                    ConsuCred[nCant, 6, 0, 0] = item.SubItems[12].Text;
                    //ConsuCred[nCant, 6, 1, 0] = "D";
                    ConsuCred[nCant, 7, 0, 0] = item.SubItems[13].Text;
                    //ConsuCred[nCant, 7, 1, 0] = "D";
                    ConsuCred[nCant, 8, 0, 0] = item.SubItems[14].Text;
                    ConsuCred[nCant, 9, 0, 0] = item.SubItems[15].Text;
                    ConsuCred[nCant, 10, 0, 0] = item.SubItems[16].Text;
                    //ConsuCred[nCant, 10, 1, 0] = "D";
                    ConsuCred[nCant, 11, 0, 0] = item.SubItems[17].Text;
                    ConsuCred[nCant, 11, 1, 0] = "D";
                    ConsuCred[nCant, 12, 0, 0] = item.SubItems[18].Text;
                    ConsuCred[nCant, 12, 1, 0] = "D";
                    ConsuCred[nCant, 13, 0, 0] = item.SubItems[19].Text;
                    ConsuCred[nCant, 13, 1, 0] = "D";
                    ConsuCred[nCant, 14, 0, 0] = item.SubItems[20].Text;
                    ConsuCred[nCant, 14, 1, 0] = "D";
                }
                else if (cmbBusca.SelectedIndex == 5)
                {
                    ConsuCred[nCant, 0, 0, 0] = item.SubItems[6].Text;
                    ConsuCred[nCant, 1, 0, 0] = item.SubItems[7].Text;
                    ConsuCred[nCant, 2, 0, 0] = item.SubItems[8].Text;
                    ConsuCred[nCant, 2, 1, 0] = "F";
                    ConsuCred[nCant, 3, 0, 0] = item.SubItems[9].Text;
                    ConsuCred[nCant, 4, 0, 0] = item.SubItems[10].Text;
                    ConsuCred[nCant, 5, 0, 0] = item.SubItems[11].Text;
                    ConsuCred[nCant, 6, 0, 0] = item.SubItems[12].Text;
                    ConsuCred[nCant, 7, 0, 0] = item.SubItems[13].Text;
                    ConsuCred[nCant, 8, 0, 0] = item.SubItems[14].Text;
                    ConsuCred[nCant, 9, 0, 0] = item.SubItems[15].Text;
                    ConsuCred[nCant, 10, 0, 0] = item.SubItems[16].Text;
                    ConsuCred[nCant, 11, 0, 0] = item.SubItems[17].Text;
                }
                else if (cmbBusca.SelectedIndex == 6)
                {
                    ConsuCred[nCant, 0, 0, 0] = item.SubItems[6].Text;
                    ConsuCred[nCant, 1, 0, 0] = item.SubItems[7].Text;
                    ConsuCred[nCant, 2, 0, 0] = item.SubItems[8].Text;
                    ConsuCred[nCant, 2, 1, 0] = "F";
                    ConsuCred[nCant, 3, 0, 0] = item.SubItems[9].Text;
                    ConsuCred[nCant, 4, 0, 0] = item.SubItems[10].Text;
                    ConsuCred[nCant, 5, 0, 0] = item.SubItems[11].Text;
                    ConsuCred[nCant, 6, 0, 0] = item.SubItems[12].Text;
                    ConsuCred[nCant, 7, 0, 0] = item.SubItems[13].Text;
                    ConsuCred[nCant, 8, 0, 0] = item.SubItems[14].Text;
                    ConsuCred[nCant, 9, 0, 0] = item.SubItems[15].Text;
                    ConsuCred[nCant, 10, 0, 0] = item.SubItems[16].Text;
                    ConsuCred[nCant, 11, 0, 0] = item.SubItems[17].Text;
                }

            }

            string cTitulo2 = "Desde " + txtDesde.Value.ToShortDateString() + " Hasta " + txtHasta.Value.ToShortDateString();

            EnviaAExcel ea = new EnviaAExcel();
            ea.EnviaArExcel("Consulta " + cmbBusca.Text, cTitulo2, ConsuCred, p.usu.apellido);




         }
        private void Busca_Refinanciados()
        {
            listBusca.Items.Clear();
            listBusca.Visible = false;
            lblAguarde.Text = "AGUARDE  ";
            panel1.Enabled = false;
            Application.DoEvents(); 
            int nCant = 0;
            List<Credito> regCreditoList;
            DateTime fD = Convert.ToDateTime(txtDesde.Value.ToShortDateString());
            DateTime fH = Convert.ToDateTime(txtHasta.Value.ToShortDateString());
            //Int32 nCobrEncon = 0;
            fH = fH.AddDays(1);
            fontList = new Font("Verdana", 8F, FontStyle.Regular);
            fontColor = Color.Empty;
            backColorList = Color.LightSteelBlue;
            ListViewItem item;
            //regCreditoList = bl.GetCreditos(c => c.FechaSolicitud >= fD && c.FechaSolicitud <= fH && c.EmpresaID == bl.pGlob.Comercio.EmpresaID && c.ComercioID == bl.pGlob.Comercio.ComercioID && c.RefinanciacionID > 0, or => or.OrderBy(o => o.FechaSolicitud)).ToList();
            regCreditoList = bl.GetCreditos(BaseID, c => c.FechaSolicitud >= fD && c.FechaSolicitud <= fH && c.EmpresaID == BaseID
                        && c.ComercioID == ComID && c.RefinanciacionID > 0, or => or.OrderBy(o => o.FechaSolicitud)).ToList();
            if (regCreditoList.Count == 0)
            {
                panel1.Enabled = true;
                lblMsg.Text = "No se encontraron refinanciaciones";
                listBusca.Visible = true;
                return;
            }
            foreach (Credito Cred in regCreditoList)
            {
                AguardeFrm(lblAguarde);
                nCant++;
                item = new ListViewItem(Cred.CreditoID.ToString());
                item.UseItemStyleForSubItems = false;
                item.SubItems.Add(Cred.EmpresaID.ToString(), fontColor, backColorList, fontList);
                item.SubItems.Add(Cred.ComercioID.ToString(), fontColor, backColorList, fontList);
                item.SubItems.Add(Cred.CreditoID.ToString(), fontColor, backColorList, fontList);
                item.SubItems.Add(Cred.Documento.ToString(), fontColor, backColorList, fontList);
                item.SubItems.Add(Cred.TipoDocumentoID, fontColor, backColorList, fontList);
                item.SubItems.Add(Cred.CreditoID.ToString("N0"), fontColor, backColorList, fontList);
                item.SubItems.Add(Cred.Documento.ToString("N0"), fontColor, backColorList, fontList);
                item.SubItems.Add(Cred.Cliente.NombreCompleto, fontColor, backColorList, fontList);
                item.SubItems.Add(Cred.RefinanciacionID.ToString(), fontColor, backColorList, fontList);
                item.SubItems.Add(Cred.Refinanciaciones[0].FechaCreacion.Value.ToShortDateString(), fontColor, backColorList, fontList);
                item.SubItems.Add(Cred.Refinanciaciones[0].CantidadCuotas.ToString(), fontColor, backColorList, fontList);
                item.SubItems.Add(Cred.Refinanciaciones[0].ValorCuota.ToString("N2"), fontColor, backColorList, fontList);
                listBusca.Items.Add(item);
                if (backColorList == Color.White) backColorList = Color.LightSteelBlue; else backColorList = Color.White;
            }
            lblMsg.Text = nCant.ToString("N0") + " créditos encontrados";
            panel1.Enabled = false;
            listBusca.Visible = true;
            BtnBusca.Text = "Otro";


        }
        private void Busca_Cancelado()
        {
            int nCant = 0;
            int nCuotas = 0;
            int nMora = 0;
            int nMoraTot = 0;
            Telefono Tel;
            Domicilio Dom;
            Mail mail;
            listBusca.Items.Clear();
            listBusca.Visible = false;
            lblAguarde.Text = "AGUARDE  ";
            panel1.Enabled = false;
            lblMsg.Text = "Buscando datos";
            Application.DoEvents(); 
            List<Cuota> regCuotaList;
            DateTime fD = Convert.ToDateTime(txtDesde.Value.ToShortDateString());
            DateTime fH = Convert.ToDateTime(txtHasta.Value.ToShortDateString());
            //Int32 nCobrEncon = 0;
            fH = fH.AddDays(1);
            fontList = new Font("Verdana", 8F, FontStyle.Regular);
            fontColor = Color.Empty;
            backColorList = Color.LightSteelBlue;
            ListViewItem item;
            //regCuotaList = bl.Get<Cuota>(c => c.FechaUltimoPago >= fD && c.FechaUltimoPago <= fH && c.EmpresaID == bl.pGlob.Comercio.EmpresaID && c.ComercioID == bl.pGlob.Comercio.ComercioID && c.CuotaID == c.CantidadCuotas && c.Importe == c.ImportePago, or => or.OrderBy(o => o.FechaUltimoPago)).ToList();
            regCuotaList = bl.Get<Cuota>(BaseID, c => c.FechaUltimoPago >= fD && c.FechaUltimoPago <= fH && c.EmpresaID == BaseID
                                && c.ComercioID == ComID && c.CuotaID == c.CantidadCuotas && c.Importe == c.ImportePago
                                , or => or.OrderBy(o => o.FechaUltimoPago)).ToList();
            if(regCuotaList.Count == 0)
            {
                panel1.Enabled = true;
                lblMsg.Text = "No se encontraron créditos cancelados";
                listBusca.Visible = true;
                return;
            }
            listBusca.Visible = false;
            foreach (Cuota Cred in regCuotaList)
            {
                AguardeFrm(lblAguarde);
                nCant++;
                item = new ListViewItem(Cred.CreditoID.ToString());
                item.UseItemStyleForSubItems = false;
                item.SubItems.Add(Cred.EmpresaID.ToString(), fontColor, backColorList, fontList);
                item.SubItems.Add(Cred.ComercioID.ToString(), fontColor, backColorList, fontList);
                item.SubItems.Add(Cred.CreditoID.ToString(), fontColor, backColorList, fontList);
                item.SubItems.Add(Cred.Documento.ToString(), fontColor, backColorList, fontList);
                item.SubItems.Add(Cred.TipoDocumentoID, fontColor, backColorList, fontList);

                item.SubItems.Add(Cred.CreditoID.ToString("N0"), fontColor, backColorList, fontList);
                item.SubItems.Add(Cred.Credito.Documento.ToString("N0"), fontColor, backColorList, fontList);
                item.SubItems.Add(Cred.Cliente.NombreCompleto, fontColor, backColorList, fontList);

                                                                                                    // TELEFONOS
                Tel=Cred.Cliente.UltimoTelefonoCliente;
                if(Tel != null)
                {
                    item.SubItems.Add(Tel.TelefonoCompleto, fontColor, backColorList, fontList);
                } 
                else
                {
                    item.SubItems.Add("", fontColor, backColorList, fontList);

                }
                Tel=Cred.Cliente.UltimoTelefonoEmpresa;
                if (Tel != null)
                {
                    item.SubItems.Add(Tel.TelefonoCompleto, fontColor, backColorList, fontList);
                }
                else
                {
                    item.SubItems.Add("", fontColor, backColorList, fontList);

                }
                Tel = Cred.Cliente.UltimoTelefonoEmpresa;
                Dom = Cred.Cliente.UltimoDomicilioCliente;                                  // DOMICILIO
                if(Dom != null)
                {
                    item.SubItems.Add(Dom.DomicilioCompleto, fontColor, backColorList, fontList);
                }
                else
                {
                    item.SubItems.Add("", fontColor, backColorList, fontList);
                }

                mail = Cred.Cliente.UltimoMailCliente;                                  // DOMICILIO
                if (mail != null)
                {
                    item.SubItems.Add(mail.Direccion, fontColor, backColorList, fontList);
                }
                else
                {
                    item.SubItems.Add("", fontColor, backColorList, fontList);
                }

                nMora = 0;                                                                      // CALCULO DE MORA
                nCuotas = 0;
                nMoraTot = 0;
                foreach (Cuota cu in Cred.Credito.Cuotas)
                {
                    nCuotas++;
                    if(cu.FechaUltimoPago != null)
                    {
                        nMora = nMora + bl.Calcula_dias_mora(cu.FechaVencimiento, (DateTime)cu.FechaUltimoPago);
                    }
                }
                if (nCuotas > 0) nMoraTot = nMora / nCuotas;

                item.SubItems.Add(nMoraTot.ToString(), fontColor, backColorList, fontList);
                listBusca.Items.Add(item);
                if (backColorList == Color.White) backColorList = Color.LightSteelBlue; else backColorList = Color.White;
            }
            Agrega_linea("T1", true, 22);  //eduardo camb
            lblMsg.Text = nCant.ToString("N0") + " créditos encontrados";
            panel1.Enabled = false;
            listBusca.Visible = true;
            BtnBusca.Text = "Otro";
        }

        private void Busca_Altas()
        {
            
            listBusca.Items.Clear();
            listBusca.Visible = false;
            lblAguarde.Text = "AGUARDE  ";
            panel1.Enabled = false;
            lblMsg.Text = "Buscando datos";
            Application.DoEvents(); 

            List<Credito> regCreditoList;
            List<CreditoAnulado> regCreditoAnuladoList;

            DateTime fD = Convert.ToDateTime(txtDesde.Value.ToShortDateString());
            DateTime fH = Convert.ToDateTime(txtHasta.Value.ToShortDateString());
            fH = fH.AddDays(1).AddTicks(-1);
            fontList = new Font("Verdana", 8F, FontStyle.Regular);
            fontColor = Color.Empty;
            backColorList = Color.LightSteelBlue;
            ListViewItem item;

            decimal nRet = 0;
            decimal nRetTot = 0;
            decimal nValorNominal = 0;
            decimal nValorCuota = 0;
            decimal nFavorComer = 0;
            decimal nFavorFinan = 0;
            decimal nComision = 0;
            decimal nTmp1 = 0;
            string cNR = "";
            int nRenovador=0;
            int nCant = 0;
            int nCantGrid = 0;
            int nTmp = 0;
            decimal nComisNVO = 0;
            decimal nComisRen = 0;
            decimal nComisSolo=0;

            decimal dRetGst = 0;
            decimal dRetCuo = 0;

            nRet = 0;
            nValorNominal = 0;
            nComision = 0;

            //regCreditoList = bl.GetCreditos(c => c.FechaSolicitud >= fD && c.FechaSolicitud <= fH && c.EmpresaID == bl.pGlob.Comercio.EmpresaID && c.ComercioID == bl.pGlob.Comercio.ComercioID, or => or.OrderBy(o => o.FechaSolicitud)).ToList();
            regCreditoList = bl.GetCreditos(BaseID, c => c.FechaSolicitud >= fD && c.FechaSolicitud <= fH && c.EmpresaID == BaseID && c.ComercioID == ComID, 
                        or => or.OrderBy(o => o.CreditoID)).ToList(); 
            if(regCreditoList.Count == 0)
            {
                panel1.Enabled = true;
                lblMsg.Text = "No se encontraron créditos";
                listBusca.Visible = true;
                return;
            }
            listBusca.Visible = false;
            foreach (Credito Cred in regCreditoList)
            {
                AguardeFrm(lblAguarde);
                nComisSolo =0;
                nCant++;
                nRet = 0;
                item = new ListViewItem(Cred.CreditoID.ToString());
                item.UseItemStyleForSubItems = false;
                item.SubItems.Add(Cred.EmpresaID.ToString(), fontColor, backColorList, fontList);
                item.SubItems.Add(Cred.ComercioID.ToString(), fontColor, backColorList, fontList);
                item.SubItems.Add(Cred.CreditoID.ToString(), fontColor, backColorList, fontList);
                item.SubItems.Add(Cred.Documento.ToString(), fontColor, backColorList, fontList);
                item.SubItems.Add(Cred.TipoDocumentoID, fontColor, backColorList, fontList);
                item.SubItems.Add(Cred.CreditoID.ToString("N0"), fontColor, backColorList, fontList);
                item.SubItems.Add(Cred.Documento.ToString("N0"), fontColor, backColorList, fontList);
                item.SubItems.Add(Cred.Cliente.NombreCompleto, fontColor, backColorList, fontList);
                item.SubItems.Add(Cred.ValorNominal.ToString("N2"), fontColor, backColorList, fontList);
                nValorNominal = nValorNominal + Cred.ValorNominal;
                item.SubItems.Add(Cred.FechaSolicitud.ToShortDateString(), fontColor, backColorList, fontList);
                item.SubItems.Add(Cred.CantidadCuotas.ToString(), fontColor, backColorList, fontList);
                item.SubItems.Add(Cred.ValorCuota.ToString("N2"), fontColor, backColorList, fontList);
                nValorCuota = nValorCuota + Cred.ValorCuota;
                item.SubItems.Add(Cred.Gasto.ToString("N2"), fontColor, backColorList, fontList);
                item.SubItems.Add(Cred.TipoCuotaID, fontColor, backColorList, fontList);
                item.SubItems.Add(Cred.TipoRetencionPlanID, fontColor, backColorList, fontList); //17
                if(Cred.Comision>0)
                {
                    nComisSolo= Cred.Comision + (Cred.Comision * 21 / 100);
                    nComision = nComision + nComisSolo;
                }
                else
                {
                    nComisSolo = Cred.Comision;
                    nComision = nComision + nComisSolo;
                }

                switch(Cred.TipoRetencionPlanID)
                {
                    case "N":
                        break;
                    case "A":
                        nRet = nRet + Cred.Gasto;
                        dRetGst = dRetGst + Cred.Gasto;
                        if(Cred.TipoCuotaID == "A")  
                        {
                            nRet = nRet + Cred.ValorCuota;
                            dRetCuo = dRetCuo + Cred.ValorCuota;
                        }
                        break;
                    case "C":
                        if(Cred.TipoCuotaID == "A") 
                        {
                            nRet = nRet + Cred.ValorCuota;
                            dRetCuo = dRetCuo + Cred.ValorCuota;
                        }
                        break;
                    case "G":
                        nRet = nRet + Cred.Gasto;
                        dRetGst = dRetGst + Cred.Gasto;
                        break;
                }
                nTmp1 = Cred.ValorNominal - (nRet + nComisSolo);
                item.SubItems.Add(nTmp1.ToString("N2"), fontColor, backColorList, fontList);
                nFavorComer = nFavorComer + nTmp1;

                nTmp1 = (nRet + nComisSolo);
                item.SubItems.Add(nTmp1.ToString("N2"), fontColor, backColorList, fontList);
                nFavorFinan = nFavorFinan + nTmp1;
                nRetTot = nRetTot + nRet;
                cNR = Es_Cliente_Renovador(Cred.Documento, Cred.TipoDocumentoID, Cred.FechaSolicitud);
                item.SubItems.Add(cNR, fontColor, backColorList, fontList);
                if (cNR == "R")
                {
                    nRenovador++;
                    nComisRen = nComisRen + nComisSolo;
                }
                else
                {
                    nComisNVO = nComisNVO + nComisSolo;
                }
                item.SubItems.Add(nComisSolo.ToString("N2"), fontColor, backColorList, fontList);
                item.SubItems.Add(Cred.FechaSolicitud.AddDays(Cred.Corte).ToShortDateString(), fontColor, backColorList, fontList);
                if(Cred.NombrePlan != null) item.SubItems.Add(Cred.NombrePlan.ToString(), fontColor, backColorList, fontList); else item.SubItems.Add("", fontColor, backColorList, fontList);
                if (!String.IsNullOrEmpty(Cred.NumCuentaBancaria))
                {
                    if (Cred.FechaDesdeDebito != null)
                        item.SubItems.Add(String.Format("Si - desde:{0}",Cred.FechaDesdeDebito.ToShortDateString()), fontColor, backColorList, fontList);
                    else
                        item.SubItems.Add(String.Format("Si", Cred.FechaDesdeDebito.ToShortDateString()), fontColor, backColorList, fontList);
                }
                else item.SubItems.Add(String.Format(""), fontColor, backColorList, fontList);
                listBusca.Items.Add(item);
                if (backColorList == Color.White) backColorList = Color.LightSteelBlue; else backColorList = Color.White;
            
                Grid.Rows.Add();
                Grid.Rows[nCantGrid].Cells[0].Value = "1";
                Grid.Rows[nCantGrid].Cells[1].Value = "0";
                Grid.Rows[nCantGrid].Cells[2].Value = "1";
                Grid.Rows[nCantGrid].Cells[3].Value = Cred.Documento.ToString();
                Grid.Rows[nCantGrid].Cells[4].Value = Cred.Cliente.NombreCompleto;
                Grid.Rows[nCantGrid].Cells[5].Value = Cred.FechaSolicitud.ToShortDateString();
                nTmp1 = Cred.ValorCuota * Cred.CantidadCuotas;
                Grid.Rows[nCantGrid].Cells[6].Value = nTmp1.ToString();
                Grid.Rows[nCantGrid].Cells[7].Value = "1";
                nTmp1 = 1 * nTmp1 /100;
                Grid.Rows[nCantGrid].Cells[8].Value = nTmp1.ToString("N0");
                Grid.Rows[nCantGrid].Cells[9].Value = Cred.CreditoID.ToString();
                nCantGrid++;


            }


            backColorList = Color.White;
            for (int it = 1; it < 2; it++)
            {
                Agrega_linea(it.ToString(), false, 23);
            }

            Agrega_linea("T", true, 23);
            lblMsg.Text = "";
            listBusca.Items[listBusca.Items.Count - 1].SubItems[8].Text = "Totales";
            nTmp = nCant;
            lblMsg.Text = nTmp.ToString("N0") + " créditos ";
            listBusca.Items[listBusca.Items.Count - 1].SubItems[9].Text = nValorNominal.ToString("N2");
            listBusca.Items[listBusca.Items.Count - 1].SubItems[12].Text = nValorCuota.ToString("N2");
            listBusca.Items[listBusca.Items.Count - 1].SubItems[16].Text = nFavorComer.ToString("N2");
            listBusca.Items[listBusca.Items.Count - 1].SubItems[17].Text = nFavorFinan.ToString("N2");
            lblMsg.Text = lblMsg.Text + "por pesos: " + nValorNominal.ToString("N2");

            Agrega_linea("T1", false, 23);
            Agrega_linea("T2", false, 23);
            listBusca.Items[listBusca.Items.Count - 1].SubItems[8].Text = "Gst Retenido";
            listBusca.Items[listBusca.Items.Count - 1].SubItems[9].Text = dRetGst.ToString("N0");
            Agrega_linea("T1", false, 23);
            listBusca.Items[listBusca.Items.Count - 1].SubItems[8].Text = "Cuota Retenida";
            listBusca.Items[listBusca.Items.Count - 1].SubItems[9].Text = dRetCuo.ToString("N0");
            Agrega_linea("T1", false, 23);
            listBusca.Items[listBusca.Items.Count - 1].SubItems[8].Text = "Cred. renovadores";
            listBusca.Items[listBusca.Items.Count - 1].SubItems[9].Text = nRenovador.ToString("N0");
            Agrega_linea("T1", false, 23);
            listBusca.Items[listBusca.Items.Count - 1].SubItems[8].Text = "Cred. nuevos";
            nTmp = nCant - nRenovador;
            listBusca.Items[listBusca.Items.Count - 1].SubItems[9].Text = nTmp.ToString("N0");
            Agrega_linea("T1", false, 23);
            listBusca.Items[listBusca.Items.Count - 1].SubItems[8].Text = "Total altas";
            listBusca.Items[listBusca.Items.Count - 1].SubItems[9].Text = nCant.ToString("N0");
            listBusca.Items[listBusca.Items.Count - 1].SubItems[12].Text = nComision.ToString("N2");
            Agrega_linea("T1", false, 23);
            Agrega_linea("T1", false, 23);

            regCreditoAnuladoList = bl.Get<CreditoAnulado>(BaseID, c => c.FechaSolicitud >= fD && c.FechaSolicitud <= fH && c.EmpresaID == BaseID && c.ComercioID == ComID, or => or.OrderBy(o => o.FechaSolicitud)).ToList();
            //if (regCreditoList.Count == 0)
            //{
            //    return;
            //}

            if (regCreditoAnuladoList.Count > 0)
            {
                backColorList = Color.Blue;
                Agrega_linea("T1", true, 23);
                backColorList = Color.White;
                Agrega_linea("T1", true, 23);
                listBusca.Visible = false;
                listBusca.Items[listBusca.Items.Count - 1].SubItems[8].Text = "Anulaciones de crédito";
                Agrega_linea("T1", false, 23);
                backColorList = Color.LightSteelBlue;
            
                foreach (CreditoAnulado Cred in regCreditoAnuladoList)
                {
                    nComisSolo=0;
                    nCant++;
                    item = new ListViewItem(Cred.CreditoID.ToString());
                    item.UseItemStyleForSubItems = false;
                    item.SubItems.Add(Cred.EmpresaID.ToString(), fontColor, backColorList, fontList);
                    item.SubItems.Add(Cred.ComercioID.ToString(), fontColor, backColorList, fontList);
                    item.SubItems.Add(Cred.CreditoID.ToString(), fontColor, backColorList, fontList);
                    item.SubItems.Add(Cred.Documento.ToString(), fontColor, backColorList, fontList);
                    item.SubItems.Add(Cred.TipoDocumentoID, fontColor, backColorList, fontList);
                    item.SubItems.Add(Cred.CreditoID.ToString("N0"), fontColor, backColorList, fontList);
                    item.SubItems.Add(Cred.Documento.ToString("N0"), fontColor, backColorList, fontList);
                    item.SubItems.Add(Cred.Cliente.NombreCompleto, fontColor, backColorList, fontList);
                    item.SubItems.Add(Cred.ValorNominal.ToString("N2"), fontColor, backColorList, fontList);
                    nValorNominal = nValorNominal + Cred.ValorNominal;
                    item.SubItems.Add(Cred.FechaSolicitud.ToShortDateString(), fontColor, backColorList, fontList);
                    item.SubItems.Add(Cred.CantidadCuotas.ToString(), fontColor, backColorList, fontList);
                    item.SubItems.Add(Cred.ValorCuota.ToString("N2"), fontColor, backColorList, fontList);
                    nValorCuota = nValorCuota + Cred.ValorCuota;
                    item.SubItems.Add(Cred.Gasto.ToString("N2"), fontColor, backColorList, fontList);
                    item.SubItems.Add(Cred.TipoCuotaID, fontColor, backColorList, fontList);
                    item.SubItems.Add(Cred.TipoRetencionPlanID, fontColor, backColorList, fontList); //17
                    item.SubItems.Add("", fontColor, backColorList, fontList);
                    item.SubItems.Add("", fontColor, backColorList, fontList);
                    item.SubItems.Add("", fontColor, backColorList, fontList);
                    item.SubItems.Add("", fontColor, backColorList, fontList);
                    item.SubItems.Add("", fontColor, backColorList, fontList);
                    item.SubItems.Add("", fontColor, backColorList, fontList);
                    item.SubItems.Add("", fontColor, backColorList, fontList);
                    listBusca.Items.Add(item);
                    if (backColorList == Color.White) backColorList = Color.LightSteelBlue; else backColorList = Color.White;


                    Grid.Rows.Add();
                    Grid.Rows[nCantGrid].Cells[0].Value = "1";
                    Grid.Rows[nCantGrid].Cells[1].Value = "0";
                    Grid.Rows[nCantGrid].Cells[2].Value = "1";
                    Grid.Rows[nCantGrid].Cells[3].Value = "1" ;
                    Grid.Rows[nCantGrid].Cells[4].Value = "ANULADO";
                    Grid.Rows[nCantGrid].Cells[5].Value = Cred.FechaSolicitud.ToShortDateString();
                   
                    Grid.Rows[nCantGrid].Cells[6].Value = "1";
                    Grid.Rows[nCantGrid].Cells[7].Value = "1";
                    Grid.Rows[nCantGrid].Cells[8].Value = "1";
                    Grid.Rows[nCantGrid].Cells[9].Value = Cred.CreditoID.ToString();
                    nCantGrid++;

                }
            }
            Agrega_linea("T", false, 23);
            backColorList = Color.Blue;
            Agrega_linea("T", true, 23);
            backColorList = Color.White;
            Agrega_linea("T", true, 23);
            listBusca.Items[listBusca.Items.Count - 1].SubItems[8].Text = "Avisos de pago";
            Agrega_linea("T", false, 23);
            nValorNominal = 0;
            nRet = 0;
            nComision = 0;
            nFavorComer = 0;

            regCreditoList = regCreditoList.OrderBy(d => d.FechaAviso).ToList();
            DateTime fAviso = regCreditoList[0].FechaAviso; // DateTime.Now.AddYears(-20);
            foreach(Credito Cred in regCreditoList)
            {
                if(fAviso.ToShortDateString() == Cred.FechaAviso.ToShortDateString())
                {
                    fAviso = Cred.FechaAviso;
                    nValorNominal = nValorNominal + Cred.ValorNominal;
                    nComision = nComision + Cred.Comision;
                    switch(Cred.TipoRetencionPlanID)
                    {
                        case "N":
                            break;
                        case "A":
                            nRet = nRet + Cred.Gasto;
                            if(Cred.TipoCuotaID == "A"){nRet = nRet + Cred.ValorCuota;}
                            break;
                        case "C":
                            if(Cred.TipoCuotaID == "A"){nRet = nRet + Cred.ValorCuota;}
                            break;
                        case "G":
                            nRet = nRet + Cred.Gasto;
                            break;
                    }
                }
                else
                {
                    nTmp1 = nValorNominal - nRet;
                    if(nComision > 0)
                    {
                        nComision = nComision + (nComision * 21 /100);
                        nTmp1 = nTmp1 - nComision;
                    }
                    nFavorComer = nFavorComer + nTmp1;
                    listBusca.Items[listBusca.Items.Count - 1].SubItems[10].Text = fAviso.ToShortDateString(); ;
                    listBusca.Items[listBusca.Items.Count - 1].SubItems[9].Text = nTmp1.ToString("N0");
                    Agrega_linea("T2", false, 23);
                    nValorNominal = 0;
                    nRet = 0;
                    nComision = 0;
                    fAviso = Cred.FechaAviso;
                    nValorNominal = nValorNominal + Cred.ValorNominal;
                    nComision = nComision + Cred.Comision;
                    switch(Cred.TipoRetencionPlanID)
                    {
                        case "N":
                            break;
                        case "A":
                            nRet = nRet + Cred.Gasto;
                            if(Cred.TipoCuotaID == "A") { nRet = nRet + Cred.ValorCuota; }
                            break;
                        case "C":
                            if(Cred.TipoCuotaID == "A") { nRet = nRet + Cred.ValorCuota; }
                            break;
                        case "G":
                            nRet = nRet + Cred.Gasto;
                            break;
                    }
                }
            }

            if(nValorNominal > 0)
            {
                nTmp1 = nValorNominal - nRet;
                if(nComision > 0)
                {
                    nComision = nComision + (nComision * 21 / 100);
                    nTmp1 = nTmp1 - nComision;
                }
                nFavorComer = nFavorComer + nTmp1;
                listBusca.Items[listBusca.Items.Count - 1].SubItems[10].Text = fAviso.ToShortDateString(); ;
                listBusca.Items[listBusca.Items.Count - 1].SubItems[9].Text = nTmp1.ToString("N0");
            }
            Agrega_linea("T2", true, 23);
            listBusca.Items[listBusca.Items.Count - 1].SubItems[9].Text = nFavorComer.ToString("N0");
            Agrega_linea("T1", true, 23);  //eduardo camb

            Grid.Sort(Grid.Columns[9],0);
            panel1.Enabled = false;
            listBusca.Visible = true;
            BtnBusca.Text = "Otro";
        }
        private void Agrega_linea(string cc, bool negrita, int CantCol)
        {

            if (negrita) fontList = new Font("Verdana", 8F, FontStyle.Bold);
            else
            {
                fontList = new Font("Verdana", 8F, FontStyle.Regular);

            }
            ListViewItem item = new ListViewItem(cc);
            for (int i = 1; i < CantCol; i++)
            {
                item.SubItems.Add("", fontColor, backColorList, fontList);
            }
            listBusca.Items.Add(item);
        }
        private string Es_Cliente_Renovador(int nDocumento, string CDcocumentoID, DateTime fSoli)
        {
            List<Credito> ListCreditoCliList;
            ListCreditoCliList = bl.GetCreditos(c => c.Documento == nDocumento && c.TipoDocumentoID == CDcocumentoID && c.FechaSolicitud < fSoli).ToList();
            if (ListCreditoCliList.Count == 0)
            { 
                return "N";
            }
            return "R";

        }
        private void Configura_Inicio()
        {
            cmbBusca.Items.Add("Solicitud");
            cmbBusca.Items.Add("Cancelados");
            cmbBusca.Items.Add("Refinanciados");
            cmbBusca.Items.Add("Morosos");
            cmbBusca.Items.Add("Vtas. por cliente");
            cmbBusca.Items.Add("Clientes");
            cmbBusca.Items.Add("No renovadores");
            cmbBusca.SelectedIndex = 0;

            LlenaCmb_meses(cmbBusca2, false);
            
            cmbBusca2.SelectedIndex = 0;

            txtCantCred.Text = "0";
            lblCantCred.Visible = false;
            lblUltiFech.Visible = false;

            txtCantCred.Visible = false;
            txtDesde.Value = DateTime.Now;
            txtHasta.Value = DateTime.Now;
            op1.Checked = true;
            Configura_Controles();
            Configura_Listas();

            lblFlechaD.Visible = false;
            lblFlechaI.Visible = false;

           btnExportar.Left = listBusca.Left + listBusca.Width - btnExportar.Width;
            //switch(QueHago)
            //{
            //    case "Cobranzas"
            //}
        }
        private void Buscar_Todo()
        {
            Configura_Listas();
            lblMsg.Text = "";
            if (cmbBusca.SelectedIndex == 0)
            {
                Busca_Altas();
            }
            else if (cmbBusca.SelectedIndex == 1)
            {
                Busca_Cancelado();
            }
            else if (cmbBusca.SelectedIndex == 2)
            {
                Busca_Refinanciados();
            }
            else if (cmbBusca.SelectedIndex == 3)
            {
                Busca_Morosos();
            }
            else if (cmbBusca.SelectedIndex == 4)
            {
                Busca_Vtas();
            } 
            else if (cmbBusca.SelectedIndex == 5)
            {
                Busca_Clientes();
            }
            else if (cmbBusca.SelectedIndex == 6)
            {
                Busca_NoRenovadores();
            }             
            if (listBusca.Items.Count > 0) btnExportar.Enabled = true;
            lblFlechaD.Visible = true;
            lblFlechaI.Visible = true; 
        }
        private void Configura_Controles()
        {
            txtDesde.KeyPress += new KeyPressEventHandler(Txt_PasaConEnter_KeyPress);
            txtDesde.KeyPress += new KeyPressEventHandler(Txt_PasaConEnter_KeyPress);
            cmbBusca.KeyPress += new KeyPressEventHandler(Txt_PasaConEnter_KeyPress);
            txtCantCred.KeyPress += new KeyPressEventHandler(Txt_PasaConEnter_KeyPress);
            //txtCantCred.KeyPress += new KeyPressEventHandler(
            listBusca.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(lista_Dibuja_Encabezado);
            listBusca.DrawSubItem += lista_DrawSubItem;
            this.BackColor = ColorBackColorFrm;
            Recorre_Formulario(this);
        }
        private void Configura_Listas()
        {
            listBusca.Visible = false;
            listBusca.Columns.Clear();
            listBusca.View = View.Details;
            listBusca.Columns.Add("", 0, HorizontalAlignment.Right);  //0 para el orden
            listBusca.Columns.Add("", 0, HorizontalAlignment.Right);  //1 empre
            listBusca.Columns.Add("", 0, HorizontalAlignment.Right);  //2 comer
            listBusca.Columns.Add("", 0, HorizontalAlignment.Right);  //3 cred
            listBusca.Columns.Add("", 0, HorizontalAlignment.Right);  //4 docu
            listBusca.Columns.Add("", 0, HorizontalAlignment.Right);  //5 cod
            //listBusca.Sorting = SortOrder.Ascending;
            //listBusca.Sort();

            if (cmbBusca.SelectedIndex == 0)
            {
                listBusca.Columns.Add("Crédito", 80, HorizontalAlignment.Right);  //6
                listBusca.Columns.Add("Documento", 80, HorizontalAlignment.Right);  //7
                listBusca.Columns.Add("Cliente", 180, HorizontalAlignment.Left);  //8
                listBusca.Columns.Add("V. Nom", 100, HorizontalAlignment.Right);  //9
                listBusca.Columns.Add("F. Soli", 100, HorizontalAlignment.Right);  //10
                listBusca.Columns.Add("Cuota", 40, HorizontalAlignment.Right);  //11
                listBusca.Columns.Add("V. Cuota", 100, HorizontalAlignment.Right);  //12
                listBusca.Columns.Add("Gastos", 80, HorizontalAlignment.Right);  //13
                listBusca.Columns.Add("A/V", 40, HorizontalAlignment.Center);  //14
                listBusca.Columns.Add("Ret", 40, HorizontalAlignment.Center);  //15
                listBusca.Columns.Add("A F/Com", 100, HorizontalAlignment.Right);  //16
                listBusca.Columns.Add("A F/Finan", 100, HorizontalAlignment.Right);  //17
                listBusca.Columns.Add("N/R", 40, HorizontalAlignment.Center);  //18
                listBusca.Columns.Add("Com+IVA", 90, HorizontalAlignment.Right);  //19
                listBusca.Columns.Add("Plazo", 90, HorizontalAlignment.Left);  //20
                listBusca.Columns.Add("Plan", 90, HorizontalAlignment.Left);  //21
                listBusca.Columns.Add("Débito Directo", 150, HorizontalAlignment.Left);  //22
                listBusca.Columns[6].Tag = "N";
                listBusca.Columns[7].Tag = "N";

                listBusca.Columns[9].Tag = "D";
                listBusca.Columns[12].Tag = "D";
                listBusca.Columns[13].Tag = "D";
                listBusca.Columns[16].Tag = "D";
                listBusca.Columns[17].Tag = "D";
                listBusca.Columns[19].Tag = "D";


                Grid.Rows.Clear();
                Grid.Columns.Clear();
                Grid.ColumnCount = 10;
                Grid.Columns[0].Name = "";
                Grid.Columns[1].Name = "";
                Grid.Columns[2].Name = "";
                Grid.Columns[3].Name = "";
                Grid.Columns[4].Name = "";
                Grid.Columns[5].Name = "";
                Grid.Columns[6].Name = "";
                Grid.Columns[7].Name = "";
                Grid.Columns[8].Name = "";
                Grid.Columns[9].Name = "";
                //Grid.Columns[10].Name = "";


            }
            else if (cmbBusca.SelectedIndex == 2)
            {
                listBusca.Columns.Add("Crédito", 80, HorizontalAlignment.Right);  //6
                listBusca.Columns.Add("Documento", 80, HorizontalAlignment.Right);  //7
                listBusca.Columns.Add("Cliente", 200, HorizontalAlignment.Left);  //8
                listBusca.Columns.Add("Nro ref", 100, HorizontalAlignment.Right);  //9
                listBusca.Columns.Add("Fecha ref", 100, HorizontalAlignment.Right);  //10
                listBusca.Columns.Add("cuotas", 80, HorizontalAlignment.Right);  //10
                listBusca.Columns.Add("V. cuota", 100, HorizontalAlignment.Right);  //10

            }
            else if (cmbBusca.SelectedIndex ==1)
            {
                listBusca.Columns.Add("Crédito", 80, HorizontalAlignment.Right);  //6
                listBusca.Columns.Add("Documento", 80, HorizontalAlignment.Right);  //7
                listBusca.Columns.Add("Cliente", 200, HorizontalAlignment.Left);  //8
                listBusca.Columns.Add("Télefono", 200, HorizontalAlignment.Right);  //9
                listBusca.Columns.Add("Télefono", 200, HorizontalAlignment.Right);  //11
                listBusca.Columns.Add("Domicilio", 200, HorizontalAlignment.Left);  //12
                listBusca.Columns.Add("Mail", 200, HorizontalAlignment.Left);  //13
                listBusca.Columns.Add("Pro Mora", 50, HorizontalAlignment.Right);  //14

            }

            else if (cmbBusca.SelectedIndex == 3)
            {
                listBusca.Columns.Add("Titular", 200, HorizontalAlignment.Left);  //6
                listBusca.Columns.Add("Crédito", 80, HorizontalAlignment.Right);  //7
                listBusca.Columns.Add("Cuota", 80, HorizontalAlignment.Right);  //8
                listBusca.Columns.Add("Domicilio", 200, HorizontalAlignment.Left);  //9
                listBusca.Columns.Add("Télefono", 150, HorizontalAlignment.Right);  //10
                listBusca.Columns.Add("Télefono", 150, HorizontalAlignment.Right);  //11
                listBusca.Columns.Add("Localidad", 150, HorizontalAlignment.Left);  //12
                listBusca.Columns.Add("Provincia", 150, HorizontalAlignment.Left);  //13
                listBusca.Columns.Add("Cod post", 80, HorizontalAlignment.Left);  //14
                listBusca.Columns.Add("Mail", 200, HorizontalAlignment.Left);  //15
                listBusca.Columns.Add("V. cuota", 100, HorizontalAlignment.Right);  //16
                listBusca.Columns.Add("Deuda", 100, HorizontalAlignment.Right);  //17
                listBusca.Columns.Add("V. puni", 100, HorizontalAlignment.Right);  //18
                listBusca.Columns.Add("Total", 100, HorizontalAlignment.Right);  //19
                listBusca.Columns.Add("F. venci", 100, HorizontalAlignment.Left);  //20
                listBusca.Columns.Add("Ult. pago", 100, HorizontalAlignment.Left);  //21
                listBusca.Columns.Add("F Soli", 100, HorizontalAlignment.Left);  //22
                listBusca.Columns.Add("Mora", 50, HorizontalAlignment.Right);  //23

            }
            else if (cmbBusca.SelectedIndex == 4)
            {
                listBusca.Columns.Add("Documento", 80, HorizontalAlignment.Right);  //6
                listBusca.Columns.Add("Cliente", 200, HorizontalAlignment.Left);  //7
                listBusca.Columns.Add("Créditos s/cancelar", 60, HorizontalAlignment.Right);  //8
                listBusca.Columns.Add("Créditos canceados", 70, HorizontalAlignment.Right);  //9
                listBusca.Columns.Add("Total", 50, HorizontalAlignment.Right);  //10
                listBusca.Columns.Add("última fecha solicitud", 80, HorizontalAlignment.Left);  //11
                listBusca.Columns.Add("Teléfono", 140, HorizontalAlignment.Left);  //12
                listBusca.Columns.Add("Teléfono", 140, HorizontalAlignment.Left);  //13
                listBusca.Columns.Add("Laboral", 90, HorizontalAlignment.Left);  //14
                listBusca.Columns.Add("Cámara", 50, HorizontalAlignment.Left);  //15
                listBusca.Columns.Add("Mail", 150, HorizontalAlignment.Left);  //16
                listBusca.Columns.Add("Promedio mora", 80, HorizontalAlignment.Right);  //17
                listBusca.Columns.Add("Deuda atrasada", 80, HorizontalAlignment.Right);  //18
                listBusca.Columns.Add("Deuda total", 80, HorizontalAlignment.Right);  //19
                listBusca.Columns.Add("Deuda mensual", 80, HorizontalAlignment.Right);  //20
            }
            else if (cmbBusca.SelectedIndex == 5)
            {
                listBusca.Columns.Add("Documento", 80, HorizontalAlignment.Right);  //6
                listBusca.Columns.Add("Cliente", 200, HorizontalAlignment.Left);  //7
                listBusca.Columns.Add("F. naci", 80, HorizontalAlignment.Left);  //8
                listBusca.Columns.Add("Domicilio", 150, HorizontalAlignment.Left);  //9
                listBusca.Columns.Add("Localidad", 150, HorizontalAlignment.Left);  //10
                listBusca.Columns.Add("Teléfono", 120, HorizontalAlignment.Left);  //11
                listBusca.Columns.Add("Teléfono", 120, HorizontalAlignment.Left);  //12
                listBusca.Columns.Add("Complemento", 120, HorizontalAlignment.Left);  //13
                listBusca.Columns.Add("Mail", 120, HorizontalAlignment.Left);  //14
                listBusca.Columns.Add("Cancelados", 60, HorizontalAlignment.Right);  //15
                listBusca.Columns.Add("Sin cancelar", 60, HorizontalAlignment.Right);  //16
                listBusca.Columns.Add("Total", 60, HorizontalAlignment.Right);  //17
            }
            else if (cmbBusca.SelectedIndex == 6)
            {
                listBusca.Columns.Add("Documento", 80, HorizontalAlignment.Right);  //6
                listBusca.Columns.Add("Cliente", 200, HorizontalAlignment.Left);  //7
                listBusca.Columns.Add("Ult. Solic", 80, HorizontalAlignment.Left);  //8
                listBusca.Columns.Add("Domicilio", 150, HorizontalAlignment.Left);  //9
                listBusca.Columns.Add("Localidad", 150, HorizontalAlignment.Left);  //10
                listBusca.Columns.Add("Teléfono", 120, HorizontalAlignment.Left);  //11
                listBusca.Columns.Add("Teléfono", 120, HorizontalAlignment.Left);  //12
                listBusca.Columns.Add("Complemento", 120, HorizontalAlignment.Left);  //13
                listBusca.Columns.Add("Mail", 120, HorizontalAlignment.Left);  //14
                listBusca.Columns.Add("Créditos", 60, HorizontalAlignment.Right);  //15
                listBusca.Columns.Add("Laboral", 100, HorizontalAlignment.Left);  //16
                listBusca.Columns.Add("Lab. Comp.", 100, HorizontalAlignment.Left);  //17
            }
            listBusca.OwnerDraw = true;
            listBusca.GridLines = false;
            listBusca.FullRowSelect = true;
            listBusca.Visible = true;
        }
        private bool ObtenerMorosoEnCamara(int dni)
        {
            List<MorosoEnCamara> lcam = bl.ObtenerMorosoEnCamara(dni, null);
            if (lcam.Count > 0)
            {
                MorosoEnCamara mcam = lcam.First();
                return true;

            }

            return false;
        }
        private void BtnBusca_Click(object sender, EventArgs e)
        {
            if (BtnBusca.Text == "Buscar")
            {
                BtnBusca.Enabled = false;
                Buscar_Todo();
                BtnBusca.Enabled = true;
            }
            else
            {
                //lblMor.Visible = false;
                //RecargarEmpYComercio(lblMor.Visible);
                lblFlechaD.Visible = false;
                lblFlechaI.Visible = false;
                btnExportar.Enabled = false;
                panel1.Enabled = true;
                listBusca.Items.Clear();
                Grid.Rows.Clear();
                lblMsg.Text = "";
                BtnBusca.Text = "Buscar";
            }
        }

        private void listBusca_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBusca.SelectedItems[0].SubItems[2].Text == "") return;
            int xx = 0;
            if (cmbBusca.SelectedIndex == 0) xx = 86;
            if (cmbBusca.SelectedIndex == 1) xx = 86;
            if (cmbBusca.SelectedIndex == 2) xx = 86;

            if (e.X < xx)  //listCliente.Columns[6].Width)
            {
                int ncredito = Convert.ToInt32(listBusca.SelectedItems[0].SubItems[3].Text);
                int ncomer = Convert.ToInt16(listBusca.SelectedItems[0].SubItems[2].Text);
                frmCobranzaNva frmACob = new frmCobranzaNva(p, this.bl, ncomer, ncredito, false);
                frmACob.MdiParent = Principal.ActiveForm;
                frmACob.WindowState = FormWindowState.Maximized;
                frmACob.Show();
            }
            else
            {
                int nndocu = Convert.ToInt32(listBusca.SelectedItems[0].SubItems[4].Text);
                string ccdocu = (listBusca.SelectedItems[0].SubItems[5].Text);
                FrmBuscaCliDocumento frmADocu = new FrmBuscaCliDocumento(p, this.bl, nndocu, ccdocu);
                frmADocu.MdiParent = Principal.ActiveForm;
                frmADocu.WindowState = FormWindowState.Maximized;
                frmADocu.Show();
            }
        }

        private void listBusca_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem aa in listBusca.SelectedItems)
            {
                lblFlechaI.Top = aa.Position.Y + listBusca.Top;
                lblFlechaD.Top = lblFlechaI.Top;
                this.Text = aa.Index.ToString() + "/" + listBusca.Items.Count.ToString();
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            frmExportar frmexp; // = new frmExportar(p, false, "", true, true);
            if(cmbBusca.SelectedIndex == 0)
            {
                frmexp = new frmExportar(p, this.BackColor, true, true, true, "Sellos");
            }
            else
            {
                frmexp = new frmExportar(p, this.BackColor, true, true, false);
            }
            frmexp.ShowDialog();
            frmexp.Close();
            if(p.qExporto == "") return;
            
            if(p.qExporto == "PL")
            {
                Manda_Excel_02();
            }else if(p.qExporto == "PI")
            {
                Manda_Impresora();
            }
            else if(p.qExporto == "PP")
            {
                Mando_A_Portapapeles(listBusca, 6);
            }
            else if (p.qExporto == "OT")
            {
                Manda_Plani_Otros();
            }
          // 
        }


        private void cmbBusca_SelectedIndexChanged(object sender, EventArgs e)
        {
            op1.Visible = false;
            op2.Visible = false;
            op3.Visible = false;
            cmbBusca2.Visible = false;
            txtDesde.Visible = true;
            txtHasta.Visible = true;
            panel1.Width = Dame_Left(txtHasta) + 10;  //438;
            txtCantCred.Visible = false;
            lblCantCred.Visible = false;
            lblUltiFech.Visible = false;
            if (cmbBusca.SelectedIndex == 0)
            {
                panel1.Width = Dame_Left(txtHasta) + 10;
            }
               else if (cmbBusca.SelectedIndex==3)
            {
                panel1.Width = 590;
                op1.Visible = true;
                op2.Visible = true;
                op3.Visible = true;
            }
            if (cmbBusca.SelectedIndex == 5)
            {
                txtDesde.Visible = false;
                txtHasta.Visible = false;
                cmbBusca2.Visible = true;
            }
            if (cmbBusca.SelectedIndex == 6)
            {
                txtDesde.Visible = true;
                txtHasta.Visible = true;
                lblUltiFech.Visible = true;
                lblUltiFech.Left = txtDesde.Left;
                txtCantCred.Left = txtHasta.Left + txtHasta.Width + 10;
                lblCantCred.Left = txtCantCred.Left;
                txtCantCred.Visible = true;
                lblCantCred.Visible = true;
                panel1.Width = txtCantCred.Left + txtCantCred.Width + 20;
            }
            //else
            //{
            //    panel1.Width = 438;
            //}
            //if(cmbBusca.SelectedIndex==4)
            //{
            //    panel1.Width = 590;
            //    cmbBusca2.Visible = true;
            //}
            BtnBusca.Left = panel1.Left + panel1.Width + 20;
            //btnExportar.Left = Dame_Left(BtnBusca)+20;
        }

        private void FrmConsultaAltas_Resize(object sender, EventArgs e)
        {
            btnExportar.Left = listBusca.Left + listBusca.Width - btnExportar.Width;
        }

        private void listBusca_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            if (listBusca.SelectedItems[0].SubItems[2].Text == "") return;
            int xx = 0;
            if (cmbBusca.SelectedIndex == 0) xx = 189;
            if (cmbBusca.SelectedIndex == 1) xx = 86;
            if (cmbBusca.SelectedIndex == 2) xx = 86;

            if (e.X < xx)  //listCliente.Columns[6].Width)
            {
                int ncredito = Convert.ToInt32(listBusca.SelectedItems[0].SubItems[3].Text);
                int ncomer = Convert.ToInt16(listBusca.SelectedItems[0].SubItems[2].Text);
                frmCobranzaNva frmACob = new frmCobranzaNva(p, this.bl, ncomer, ncredito, false);
                frmACob.MdiParent = Principal.ActiveForm;
                frmACob.WindowState = FormWindowState.Maximized;
                frmACob.Show();
            }
            else
            {
                int nndocu = Convert.ToInt32(listBusca.SelectedItems[0].SubItems[4].Text);
                string ccdocu = (listBusca.SelectedItems[0].SubItems[5].Text);
                FrmBuscaCliDocumento frmADocu = new FrmBuscaCliDocumento(p, this.bl, nndocu, ccdocu);
                frmADocu.MdiParent = Principal.ActiveForm;
                frmADocu.WindowState = FormWindowState.Maximized;
                frmADocu.Show();
            }
        }

        private void FrmConsultaAltas_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F9)
            {
                if(e.Shift)
                {
                    if(BtnBusca.Text != "Buscar") return;
                    if(bl.LlevaM())
                    {
                        lblMor.Visible = !lblMor.Visible;
                        RecargarEmpYComercio(lblMor.Visible);
                    }
                }
            }

        }

        //protected void Mando_A_Portapapeles_Grid(DataGridView aGrid) //, int nColDesde)
        //{
        //    string cCopio = "";
        //    int nC = aGrid.ColumnCount - 1;//columnas
        //    int nF = aGrid.RowCount;//filas
        //    string cBorrar;
        //    //for (int n = 0; n <= nC; n++)
        //    //{
        //    //    if (aGrid.Columns[n].Visible)
        //    //    {
        //    //        cBorrar = aGrid.Columns[n].Name;
        //    //        cBorrar = cBorrar.Replace("\r\n", " ");
        //    //        cCopio = cCopio + cBorrar + "\t";
        //    //    }
        //    //}
        //    //cCopio = cCopio + Environment.NewLine;

        //    //foreach (ListViewItem item in aList.Items)
        //    for (int nR = 0; nR < aGrid.Rows.Count; nR++)
        //    {
        //        //for (int nColum = nColDesde; nColum <= item.SubItems.Count - 1; nColum++)
        //        for (int nColum = 0; nColum < aGrid.ColumnCount; nColum++)
        //        {
        //            if (aGrid.Columns[nColum].Visible)
        //            {
        //                if (aGrid.Rows[nR].Cells[nColum].Value != null)
        //                {
        //                    cBorrar = aGrid.Rows[nR].Cells[nColum].Value.ToString();
        //                }
        //                else
        //                {
        //                    cBorrar = "";
        //                }
        //                cBorrar = cBorrar.Replace("\r\n", " ");
        //                cCopio = cCopio + cBorrar + "\t";
        //            }
        //        }
        //        cCopio = cCopio + Environment.NewLine;
        //    }
        //    Clipboard.SetText(cCopio, TextDataFormat.Text);
        //}
    }
}
