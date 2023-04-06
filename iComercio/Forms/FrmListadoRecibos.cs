using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iComercio.Models;
using iComercio.Auxiliar;
using DevExpress.XtraGrid.Views.Grid;
using Credin;
using iComercio.Rest;
using iComercio.Rest.RestModels;
//using iComercio.Models;
using iComercio.Delegados;
using iComercio.ViewModels;
//using iComercio.Auxiliar;

namespace iComercio.Forms
{
            
    public partial class FrmListadoRecibos : FRM
    {
        Comercio comer;
        Color backColorList = Color.White;
        Color fontColor = Color.Empty;
        Font fontList = new Font("Verdana", 8F, FontStyle.Regular);
        string cDonde;

        public FrmListadoRecibos()
        {
            InitializeComponent();
        }
        public FrmListadoRecibos(Principal p, RestApi ra, string cDondeVoy)
            : base(p)
        {
            //bl = new BusinessLayer(ra);
            InitializeComponent();
            cDonde = cDondeVoy;
        }
        private void FrmCtaCteAnula_Load(object sender, EventArgs e)
        {
            RecargarEmpYComercio(false);
            InicializarControles();
            //Buscar();
        }
        private void Busca_Caps()
        {
            listBusca.Items.Clear();
            backColorList = Color.LightSteelBlue;
            string rutaArchivo = "";
            DateTime dFech;
            decimal nDec = 0;
            ListViewItem item;
            DateTime fD = Convert.ToDateTime(dtpDesde.Value.Day + "/" + dtpDesde.Value.Month + "/" + dtpDesde.Value.Year);
            DateTime fH = Convert.ToDateTime(dtpHasta.Value.Day + "/" + dtpHasta.Value.Month + "/" + dtpHasta.Value.Year);
            fH = fH.AddDays(1);

            List<CapDetalle> ListCaps;
            ListCaps = bl.Get<CapDetalle>(c => c.EmpresaID == bl.pGlob.EmpresaID && c.ComercioID== bl.pGlob.ComercioID
                                        && c.FechaVencimiento >= fD && c.FechaVencimiento < fH
                                        && c.Cap.EstadoID == bl.pGlob.Vigente.EstadoID, or => or.OrderBy(o => o.CapDetalleID)).ToList(); 

            foreach(CapDetalle caps in ListCaps)
            {
                item = new ListViewItem(caps.CapDetalleID.ToString());
                item.SubItems.Add(caps.CapID.ToString(), fontColor, backColorList, fontList);  //1
                item.SubItems.Add(caps.CapDetalleID.ToString(), fontColor, backColorList, fontList);  //1
                dFech = Convert.ToDateTime(caps.FechaVencimiento);
                item.SubItems.Add(dFech.ToShortDateString(), fontColor, backColorList, fontList);//2
                nDec = Convert.ToDecimal(caps.Importe);
                item.SubItems.Add(nDec.ToString("N2"), fontColor, backColorList, fontList);//3
                nDec = Convert.ToDecimal(caps.ImportePago);
                item.SubItems.Add(nDec.ToString("N2"), fontColor, backColorList, fontList);//4
                nDec = Convert.ToDecimal(caps.PendientePago);
                item.SubItems.Add(nDec.ToString("N2"), fontColor, backColorList, fontList);//5
                item.SubItems.Add(caps.Detalle, fontColor, backColorList, fontList);//6
                                                                                    //item.SubItems.Add(caps, fontColor, backColorList, fontList);//6
                rutaArchivo = RutaArchivo(bl.pGlob.Configuracion.rutaComprIma, "CAP", caps.CapDetalleID.ToString()); //7


                //if(Auxiliares.Utilidades.ExisteArchivo(rutaArchivo)) item.SubItems.Add("SI", fontColor, backColorList, fontList); else item.SubItems.Add("", fontColor, backColorList, fontList);
                if (Auxiliares.Utilidades.EstaArchivo(rutaArchivo)) item.SubItems.Add("SI", fontColor, backColorList, fontList); else item.SubItems.Add("", fontColor, backColorList, fontList);


                item.SubItems.Add(caps.CapDetalleID.ToString(), fontColor, backColorList, fontList); //8
                listBusca.Items.Add(item);
                if(backColorList == Color.White) backColorList = Color.LightSteelBlue; else backColorList = Color.White;

            }
            lblMensa.Text = ListCaps.Count.ToString() + " detalles encontrados";
            listBusca.Visible = true;

            grpFecha.Enabled = false;
            btnBuscar.Text = "Otro";
        }
        private void Busca_Gastos()
        {
            listBusca.Items.Clear();
            backColorList = Color.LightSteelBlue;
            string rutaArchivo = "";
            DateTime dFech;
            decimal nDec = 0;
            ListViewItem item;
            DateTime fD = Convert.ToDateTime(dtpDesde.Value.Day + "/" + dtpDesde.Value.Month + "/" + dtpDesde.Value.Year);
            DateTime fH = Convert.ToDateTime(dtpHasta.Value.Day + "/" + dtpHasta.Value.Month + "/" + dtpHasta.Value.Year);
            fH = fH.AddDays(1);
            List<Gasto> ListGastos;
            ListGastos = bl.Get<Gasto>(g => g.EmpresaID == bl.pGlob.EmpresaID && g.ComercioID == bl.pGlob.ComercioID && g.Fecha >= fD 
                                       && g.Fecha < fH, or => or.OrderBy(o => o.GastoID)).ToList();
            listBusca.Visible = false;
            foreach(Gasto rec in ListGastos)
            {
                item = new ListViewItem(rec.GastoID.ToString());
                item.SubItems.Add(rec.GastoID.ToString(), fontColor, backColorList, fontList);  //1
                dFech = Convert.ToDateTime(rec.Fecha);
                item.SubItems.Add(dFech.ToShortDateString(), fontColor, backColorList, fontList);//2
                nDec = Convert.ToDecimal(rec.Importe);
                item.SubItems.Add(nDec.ToString("N2"), fontColor, backColorList, fontList);//3
                item.SubItems.Add(rec.Descripcion, fontColor, backColorList, fontList);//4
                item.SubItems.Add(rec.Estado.Descripcion, fontColor, backColorList, fontList);//5

                rutaArchivo = RutaArchivo(bl.pGlob.Configuracion.rutaComprIma, "GST", rec.GastoID.ToString());


                //if(Auxiliares.Utilidades.ExisteArchivo(rutaArchivo)) item.SubItems.Add("SI", fontColor, backColorList, fontList); else item.SubItems.Add("", fontColor, backColorList, fontList);
                if (Auxiliares.Utilidades.EstaArchivo(rutaArchivo)) item.SubItems.Add("SI", fontColor, backColorList, fontList); else item.SubItems.Add("", fontColor, backColorList, fontList);

                item.SubItems.Add(rec.GastoID.ToString(), fontColor, backColorList, fontList);
                listBusca.Items.Add(item);
                if(backColorList == Color.White) backColorList = Color.LightSteelBlue; else backColorList = Color.White;
            }

            lblMensa.Text = ListGastos.Count.ToString() + " gastos encontrados";
            listBusca.Visible = true;
            //if(cDonde == "RecAnula")
            //{
            //    btnAnula.Enabled = true;
            //    grpFecha.Enabled = false;

            //}

            grpFecha.Enabled = false;
            btnBuscar.Text = "Otro";


        }
        private void Configura_Inicio()
        {
            
            //grpBusca.Visible = false;
            grpFecha.Visible = false;
            btnAnula.Visible = false;
            btnNuevo.Visible = false;
            grpFecha.Visible = true;
            dtpDesde.Value = DateTime.Now.Date.AddDays(-7);            
            if (cDonde == "RecAnula")
            {

                this.Text = "Listado de recibos por fecha";
                Utilidades.CargarComboGeneric<Comercio>(cmbComercio, Com, "Nombre", "ComercioID");
                
                btnAnula.Visible = true;
                btnAnula.Enabled = false;
                //btnNuevo.Enabled = false;
            }else if (cDonde == "RECIBOS")
            {
                //grpBusca.Top = grpFecha.Top;
                //grpBusca.Left = grpFecha.Left;
                //grpBusca.Visible = true;
                this.Text = "Listado de comprobantes";
                lblComercio.Text = "Comprobante";
                //txtDesde.Value = DateTime.Now.Date.AddDays(-7);
                cmbComercio.Items.Add("Recibos");
                cmbComercio.Items.Add("Gastos");
                cmbComercio.Items.Add("Caps");
                cmbComercio.SelectedIndex = 0;
            }
            listBusca.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(lista_Dibuja_Encabezado);
            listBusca.DrawSubItem += lista_DrawSubItem;
            Configura_listas();
            
            lblMensa.Text = "";
            
        }
        private void InicializarControles()
        {
            Configura_Colores(bl.pGlob.Comercio.EmpresaID);
            Recorre_Formulario(this);
            this.BackColor = ColorBackColorFrm;
            
            Configura_Inicio();
        }

        private void Graba()
        {
            //BusinessLayer bl2;
            TransferenciasDepositos transDep = null;
            TipoMovimiento tm;
            CuentaCorriente cc;
            Recibo rec = new Recibo();
            //bl2 = new BusinessLayer();
            int nr = Convert.ToInt16(label6.Text);
            tm = bl.Get<TipoMovimiento>(BaseID, t => t.TipoMovimientoID == nr).FirstOrDefault();
            if (tm == null)
            {
                MessageBox.Show(String.Format("No se encontró el movimiento", nr.ToString()));
                return;
            }
            int nReciA = System.Convert.ToInt32(label1.Text);
            decimal nImporte = System.Convert.ToDecimal(label2.Text);
            Recibo recA = bl.Get<Recibo>(BaseID, r => r.ReciboID == nReciA && r.Importe == nImporte).FirstOrDefault();
            if(recA == null)
            {
                MessageBox.Show("ERROR - al buscar el recibo");
                return;
            }
            rec.EmpresaID = BaseID; // bl.pGlob.Comercio.EmpresaID;
            rec.ComercioID = ComID; // bl.pGlob.Comercio.ComercioID;

            rec.Comprobante = System.Convert.ToInt32(label1.Text);
            rec.Importe = System.Convert.ToDecimal(label2.Text);
            rec.Fecha = DateTime.Now;
            rec.Notas = "Anulacion recibo " + label1.Text;
            rec.FechaIngreso = DateTime.Now;
            rec.UsuarioID = p.usu.UsuarioID;
            rec.Host = System.Environment.MachineName;
            rec.EstadoID = bl.pGlob.Provisorio.EstadoID;
            

            rec.TipoMovimientoID = tm.TipoMovimientoID;
            if(recA.CreditoID != null) rec.CreditoID = recA.CreditoID;
            if(recA.CuotaID != null) rec.CuotaID = recA.CuotaID;
            if(recA.CobranzaID != null) rec.CobranzaID = recA.CobranzaID;
            if(recA.ComercioAdheridoComercioID != null) rec.ComercioAdheridoComercioID = recA.ComercioAdheridoComercioID;
            if(recA.ComercioAdheridoEmpresaID != null) rec.ComercioAdheridoEmpresaID = recA.ComercioAdheridoEmpresaID;

            rec.ReciboIDAnula = System.Convert.ToInt32(label1.Text);
            cc = bl.ImputarCuentaCorriente(Com, rec, transDep, tm, rec.Importe);
            //Agregar imputacion de transferencia y recibo a cuenta corriente. 
            //y en Ifinan agregar campos de cuentacorriente para recibo y transferencia.
            bl.AgregarTransaccional<Recibo>(rec.EmpresaID, rec);
                
            bl.Grabar(rec.EmpresaID);

            List<Transmision> ltrans = new List<Transmision>();
            ltrans = bl.Transmision<Recibo>(ltrans, rec, Com, bl.pGlob.TransAltaRecibo, bl.pGlob.UriRecibos);
            ltrans = bl.Transmision<CuentaCorriente>(ltrans, cc, Com, bl.pGlob.TransImputacionCC, bl.pGlob.UriRecibos);
            if (transDep != null)
                ltrans = bl.Transmision<TransferenciasDepositos>(ltrans, transDep, Com, bl.pGlob.TransAltaTransDep, bl.pGlob.UriRecibos);
            bl.GrabarTransmisiones(rec.EmpresaID, ltrans);
                
            //if (solfon != null)
            //    bl.Transmision<SolicitudFondo>(solfon, Com, bl.pGlob.TransActualizarSolicitudFondos, bl.pGlob.UriSolicitarFondos);
               
            bl.Grabar();
            MessageBox.Show(String.Format("Se ha agregado el recibo {0}", rec.ReciboID));
        }
        private void Anula()
        {
            string cMsg = "";
            cMsg = "Anular el recibo " + label1.Text + Environment.NewLine;
            cMsg = cMsg + label5.Text + " por " + label2.Text;
            DialogResult res = MessageBox.Show(cMsg, "Anulación de recibo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (res == DialogResult.Cancel)
            {
                return ;
            }
            Graba();
            Buscar();
            //

        }
        private void Buscar()
        {
            listBusca.Items.Clear();
            backColorList = Color.LightSteelBlue;
            string rutaArchivo = "";
            ListViewItem item;
            DateTime dFech;
            decimal nDec = 0;
            string cTmp = "";

            DateTime fD = Convert.ToDateTime(dtpDesde.Value.Day+ "/" + dtpDesde.Value.Month + "/" + dtpDesde.Value.Year);
            DateTime fH = Convert.ToDateTime(dtpHasta.Value.Day + "/" + dtpHasta.Value.Month + "/" + dtpHasta.Value.Year);
            fH = fH.AddDays(1);
            //bl = new BusinessLayer();
            List<Recibo> listRecibo;
            if (cDonde == "RecAnula")
            {
                listRecibo = bl.Get<Recibo>(BaseID, r => r.EmpresaID == BaseID && r.ComercioID == ComID && r.Fecha >= fD && r.Fecha < fH , or => or.OrderBy(o => o.ReciboID)).ToList();

            }
            else{
                listRecibo = bl.Get<Recibo>(BaseID, r => r.EmpresaID == BaseID && r.ComercioID == ComID && r.Fecha >= fD && r.Fecha < fH, or => or.OrderBy(o => o.ReciboID)).ToList();

            }

            //List<Recibo> listRecibo = bl.Get<Recibo>(r => r.EmpresaID == comer.EmpresaID && r.ComercioID == comer.ComercioID && r.Fecha >= dtpDesde.Value && r.Fecha <= dtpHasta.Value, or => or.OrderBy(o => o.ReciboID)).ToList();
            if (listRecibo.Count == 0)
            {
                return;
            }
            listBusca.Visible = false;
            foreach(Recibo rec in listRecibo)
            {
                item = new ListViewItem(rec.ReciboID.ToString());

                item.SubItems.Add(rec.ReciboID.ToString("N0"), fontColor, backColorList, fontList);
                item.SubItems.Add(rec.ComercioID.ToString(), fontColor, backColorList, fontList);
                dFech =Convert.ToDateTime( rec.Fecha);
                item.SubItems.Add(dFech.ToShortDateString(), fontColor, backColorList, fontList);
                nDec = Convert.ToDecimal(rec.Importe);
                item.SubItems.Add(nDec.ToString("N2"), fontColor, backColorList, fontList);

                item.SubItems.Add(rec.TipoMovimientoID.ToString(), fontColor, backColorList, fontList);

                cTmp = rec.TipoMovimiento.Descripcion;
                if(rec.TipoMovimiento.ClaseMovimiento.Descripcion == "Egreso")
                {
                    item.SubItems.Add(cTmp, Color.Red, backColorList, fontList);
                }
                else
                {
                    item.SubItems.Add(cTmp, fontColor, backColorList, fontList);
                }

                item.SubItems.Add(rec.Comprobante.ToString(), fontColor, backColorList, fontList);

                item.SubItems.Add(rec.Notas, fontColor, backColorList, fontList);

                item.SubItems.Add(rec.Host, fontColor, backColorList, fontList);
                item.SubItems.Add(rec.Usuario.nombre, fontColor, backColorList, fontList);
                item.SubItems.Add(rec.TipoMovimiento.TipoMovIDAnula.ToString(), fontColor, backColorList, fontList);
                if (cDonde == "RECIBOS")
                {
                    if(rec.ComercioID == bl.pGlob.ComercioID)
                    {
                        rutaArchivo = RutaArchivo(bl.pGlob.Configuracion.rutaComprIma, "REC", rec.ReciboID.ToString());
                    }
                    else
                    {
                        rutaArchivo = RutaArchivo(bl.pGlob.Configuracion.rutaComprImaMor, "REC", rec.ReciboID.ToString());
                    }
                    //if (Auxiliares.Utilidades.ExisteArchivo(rutaArchivo)) item.SubItems.Add("SI", fontColor, backColorList, fontList); else item.SubItems.Add("", fontColor, backColorList, fontList);
                    if (Auxiliares.Utilidades.EstaArchivo(rutaArchivo)) item.SubItems.Add("SI", fontColor, backColorList, fontList); else item.SubItems.Add("", fontColor, backColorList, fontList);

                    item.SubItems.Add(rec.ReciboID.ToString(), fontColor, backColorList, fontList);
                }
                listBusca.Items.Add(item);
                if (backColorList == Color.White) backColorList = Color.LightSteelBlue; else backColorList = Color.White;
            }
            lblMensa.Text = listRecibo.Count.ToString() + " recibos encontrados";
            listBusca.Visible = true;
            if (cDonde == "RecAnula")
            {
                btnAnula.Enabled = true;
                grpFecha.Enabled = false;
                
            }
            grpFecha.Enabled = false;
            btnBuscar.Text = "Otro";
        }
        private string RutaArchivo(string cRuta, string cTipo, string nCompr)
        {
            string cArch = "";
            cArch = cTipo + "_" + nCompr + ".Jpg";
            return String.Format("{0}\\{1}", cRuta, cArch);
        }
        public void Configura_listas()
        {

            listBusca.View = View.Details;
            if (cDonde == "RecAnula")
            {
                listBusca.Columns.Add("", 0, HorizontalAlignment.Right);  // 0
                listBusca.Columns.Add("Recibo nro.", 80, HorizontalAlignment.Right);  // 0
                listBusca.Columns.Add("Comercio", 80, HorizontalAlignment.Right);      //1
                listBusca.Columns.Add("Fecha", 80, HorizontalAlignment.Center);      //2
                listBusca.Columns.Add("Importe", 80, HorizontalAlignment.Right);      //
                listBusca.Columns.Add("Movimiento cta", 80, HorizontalAlignment.Right);      //
                listBusca.Columns.Add("Movimiento", 250, HorizontalAlignment.Left);      //
                listBusca.Columns.Add("Comprobante nro", 80, HorizontalAlignment.Right);      //
                listBusca.Columns.Add("Notas", 200, HorizontalAlignment.Left);      //
                listBusca.Columns.Add("PC", 100, HorizontalAlignment.Left);      //
                listBusca.Columns.Add("Usuario", 80, HorizontalAlignment.Left);      //
                listBusca.Columns.Add("", 0, HorizontalAlignment.Right);      //
                listBusca.Columns.Add("", 0, HorizontalAlignment.Right);      //
                listBusca.Columns.Add("", 0, HorizontalAlignment.Right);      //
                listBusca.Columns.Add("", 0, HorizontalAlignment.Right);      //
            }
            else if (cDonde == "RECIBOS")
            {
                listBusca.Items.Clear();
                listBusca.Clear();
                if(cmbComercio.SelectedIndex == 0)
                {
                    listBusca.Columns.Add("", 0, HorizontalAlignment.Right);  // 0
                    listBusca.Columns.Add("Recibo nro.", 80, HorizontalAlignment.Right);  // 0
                    listBusca.Columns.Add("Comercio", 80, HorizontalAlignment.Right);      //1
                    listBusca.Columns.Add("Fecha", 80, HorizontalAlignment.Center);      //2
                    listBusca.Columns.Add("Importe", 80, HorizontalAlignment.Right);      //
                    listBusca.Columns.Add("Movimiento cta", 80, HorizontalAlignment.Right);      //
                    listBusca.Columns.Add("Movimiento", 350, HorizontalAlignment.Left);      //
                    listBusca.Columns.Add("Comprobante nro", 80, HorizontalAlignment.Right);      //
                    listBusca.Columns.Add("Notas", 200, HorizontalAlignment.Left);      //
                    listBusca.Columns.Add("PC", 100, HorizontalAlignment.Left);      //
                    listBusca.Columns.Add("Usuario", 80, HorizontalAlignment.Left);      //
                    listBusca.Columns.Add("", 0, HorizontalAlignment.Right);      //
                    listBusca.Columns.Add("Imagen", 80, HorizontalAlignment.Center);      //
                    listBusca.Columns.Add("", 0, HorizontalAlignment.Right);      //
                    listBusca.Columns.Add("", 0, HorizontalAlignment.Right);      //
                }
                else if(cmbComercio.SelectedIndex == 1)
                {
                    listBusca.Columns.Add("", 0, HorizontalAlignment.Right);  // 0
                    listBusca.Columns.Add("Gasto nro.", 80, HorizontalAlignment.Right);  // 1
                    listBusca.Columns.Add("Fecha", 80, HorizontalAlignment.Center);      //2
                    listBusca.Columns.Add("Importe", 80, HorizontalAlignment.Right);      //3
                    listBusca.Columns.Add("Descripción", 350, HorizontalAlignment.Left);      //4
                    listBusca.Columns.Add("Estado", 80, HorizontalAlignment.Left);      //5
                    //listBusca.Columns.Add("Comprobante nro", 80, HorizontalAlignment.Right);      //6
                    listBusca.Columns.Add("Imagen", 80, HorizontalAlignment.Center);      //7
                    listBusca.Columns.Add("", 0, HorizontalAlignment.Right);      //8
                    listBusca.Columns.Add("",0, HorizontalAlignment.Right);      //
                }
                else if(cmbComercio.SelectedIndex == 2)
                {
                    listBusca.Columns.Add("", 0, HorizontalAlignment.Right);  // 0
                    listBusca.Columns.Add("Caps nro.", 80, HorizontalAlignment.Right);  // 1
                    listBusca.Columns.Add("Detalle nro.", 80, HorizontalAlignment.Right);  // 1
                    listBusca.Columns.Add("Fecha", 80, HorizontalAlignment.Left);      //2
                    listBusca.Columns.Add("Importe", 80, HorizontalAlignment.Right);      //3
                    listBusca.Columns.Add("Importe pagado", 80, HorizontalAlignment.Right);      //4
                    listBusca.Columns.Add("Importe pendiente", 80, HorizontalAlignment.Right);      //5
                    listBusca.Columns.Add("Detalle", 250, HorizontalAlignment.Left);      //6
                    
                    listBusca.Columns.Add("Imagen", 80, HorizontalAlignment.Center);      //7
                    listBusca.Columns.Add("", 0, HorizontalAlignment.Right);      //8
                    /*listBusca.Columns.Add("", 0, HorizontalAlignment.Right);      //*/
                }
            }
            listBusca.OwnerDraw = true;
            listBusca.GridLines = false;
        }
        private void Busca_Todo()
        {
            if(cDonde == "RecAnula")
            {
                Buscar();
            }
            else if(cDonde == "RECIBOS")
            {
                if(cmbComercio.SelectedIndex == 0)
                {
                    Buscar();
                }
                else if(cmbComercio.SelectedIndex == 1)
                {
                    Busca_Gastos();
                }else if(cmbComercio.SelectedIndex == 2)
                {
                    Busca_Caps();
                }
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if(btnBuscar.Text == "Buscar")
            {
                Busca_Todo();
            }
            else
            {
                listBusca.Items.Clear();
                lblMensa.Text = "";
                btnBuscar.Text = "Buscar";
                grpFecha.Enabled = true;
                btnAnula.Enabled = false;
                btnNuevo.Enabled = false;
            }
        }

        private void cmbComercio_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMor.Visible = false;
            RecargarEmpYComercio(lblMor.Visible);

            if(cDonde == "RecAnula") comer = (Comercio)cmbComercio.SelectedItem;
            if(cDonde == "RECIBOS") Configura_listas();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAnula_Click(object sender, EventArgs e)
        {
            Anula();
        }

        private void listBusca_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cDonde != "RecAnula") return;
            label1.Text = "";
            label2.Text = "";
            label3.Text = "";
            label4.Text = "";
            label5.Text = "";
            label6.Text = "";
            btnAnula.Enabled = false;
            foreach (ListViewItem aa in listBusca.SelectedItems)
            {
                if (aa.SubItems[5].Text == "48" || aa.SubItems[5].Text == "50"
                    || aa.SubItems[5].Text == "400" || aa.SubItems[5].Text == "620"
                    || aa.SubItems[5].Text == "701" || aa.SubItems[5].Text == "56"
                    || aa.SubItems[5].Text == "58" || aa.SubItems[5].Text == "60"
                    || aa.SubItems[5].Text == "610" || aa.SubItems[5].Text == "801"
                    || aa.SubItems[5].Text == "820") // || aa.SubItems[5].Text == "720")
                {

                    label1.Text = aa.Text;
                    label2.Text = aa.SubItems[4].Text;
                    label3.Text = aa.SubItems[5].Text;
                    label4.Text = aa.SubItems[7].Text;
                    label5.Text = aa.SubItems[6].Text;
                    switch (aa.SubItems[5].Text)
                    {
                        case "48":
                            label6.Text = "49";
                            break;
                        case "50":
                            label6.Text = "51";
                            break;
                        case "400":
                            label6.Text = "52";
                            break;
                        case "620":
                            label6.Text = "54";
                            break;
                        case "701":
                            label6.Text = "55";
                            break;
                        case "56":
                            label6.Text = "57";
                            break;
                        case "58":
                            label6.Text = "59";
                            break;
                        case "60":
                            label6.Text = "61";
                            break;
                        case "610":
                            label6.Text = "611";
                            break;
                        case "801":
                            label6.Text = "811";
                            break;
                        case "820":
                            label6.Text = "821";
                            break;
                        //case "720":
                        //    label6.Text = "722";
                        //    break;
                    }
                    btnAnula.Enabled = true;
//                    lblMensa.Text = aa.SubItems[5].Text; // aa.Text;
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

        }

        private void listBusca_DoubleClick(object sender, EventArgs e)
        {
            if(cDonde == "RecAnula") return;
            frmScan frmScan;
            if(cmbComercio.SelectedIndex == 0)
            {
                frmScan = new frmScan(p, bl, Convert.ToInt32(listBusca.SelectedItems[0].SubItems[13].Text), "REC", "Recibos", lblMor.Visible, "REC");
                frmScan.Show();
            }
            else if(cmbComercio.SelectedIndex == 1)
            {
                frmScan = new frmScan(p, bl, Convert.ToInt32(listBusca.SelectedItems[0].SubItems[7].Text), "GST", "Gastos", false, "GST");
                frmScan.Show();
            }
            else if(cmbComercio.SelectedIndex == 2)
            {
                frmScan = new frmScan(p, bl, Convert.ToInt32(listBusca.SelectedItems[0].SubItems[9].Text), "CAP", "CAPS", false, "CAP");
                frmScan.Show();
            }
            //int nID= Convert.ToInt32(listBusca.SelectedItems[0].SubItems[nCol].Text);
            
            

        }

        private void FrmListadoRecibos_KeyDown(object sender, KeyEventArgs e)
        {
            if(cDonde == "RECIBOS") // || cDonde == "RecAnula")
            {
                if(cmbComercio.SelectedIndex == 0)
                {
                    if(e.KeyCode == Keys.F9)
                    {
                        if(e.Shift)
                        {
                            if(bl.LlevaM())
                            {
                                lblMor.Visible = !lblMor.Visible;
                                RecargarEmpYComercio(lblMor.Visible);


                            }
                        }
                    }

                }
            }
        }
    }
}
