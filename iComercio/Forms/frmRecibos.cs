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
using Credin;
namespace iComercio.Forms
{
    public partial class frmRecibos : FRM
    {
        TipoMovimiento tm;
        SolicitudFondo solfon;
        CuentaBancaria origen;
        CuentaBancaria destino;
        Cheque cheque;
        CuentaCorriente cc;
        bool generaTransDep = false;
        Comercio ComAdh;
        int? ComAdhEmpID = null;
        int? ComAdhComID = null;
        bool esM;
        
        public frmRecibos(Principal p,BusinessLayer bl): base(p,bl)
        {
            InitializeComponent();
            this.p = p;
            this.bl = bl;
        }

        public frmRecibos(Principal p, BusinessLayer bl,bool esM) : base(p, bl)
        {
            InitializeComponent();
            this.p = p;
            this.bl = bl;
            this.esM = esM;
        }

        private void frmRecibos_Load(object sender, EventArgs e)
        {
            RecargarEmpYComercio(esM);
            ConfiguraControles();
            CargarMovimientos();
            CargarComerciosAdheridos();       
        }

     
        public void ConfigurarControlesInicio()
        {
            Utilidades.RedimensionarControl(this, true, this.Width, 400);
            Utilidades.RedimensionarControl(grbRecibos, true, grbRecibos.Width, 200);
            Utilidades.PosicionarControl(grbRecibos, true, 10, 10);
            Utilidades.RedimensionarControl(grbTransDep, true, grbTransDep.Width, 100);
            Utilidades.PosicionarControl(grbTransDep, true, 10, 210);
            Utilidades.PosicionarControl(btnAgregar, true, 552, 310);  
            
        }

        private void ConfiguraControles()
        {
            //Configura_Colores();
            btnScan.Visible = true;
            this.BackColor = ColorBackColorFrm;
            Recorre_Formulario(this);
            btnScan.Enabled = false;
            btnOtro.Enabled = false;
            lblID.Text = "0";
            //ConfigurarControlesInicio();
            this.txtImporte.KeyPress += new System.Windows.Forms.KeyPressEventHandler(PuntoAComa_KeyPress);
        }
        
        private void CargarMovimientos()
        {
            Utilidades.CargarCombo(cmbMovimientos, bl.GetMovimientosRec(), "Nombre", "TipoMovimientoID",0);
        }

        private void CargarComerciosAdheridos()
        {
            Utilidades.CargarCombo(cmbComAdh, bl.GetComerciosAdheridos(BaseID), "NumeroYNombre", "ComercioID", 0);
        }
        

        private void cmbMovimientos_SelectedIndexChanged(object sender, EventArgs e)
        {
            tm = (TipoMovimiento)cmbMovimientos.SelectedItem;
            if (tm!=null)
            {
                lblTipoMovimiento.Text = tm.ClaseMovimiento.Nombre;
                SeleccionarSegunMovimiento(tm);
            }
            btnOtro.Top = btnAgregar.Top;
            btnScan.Top = btnAgregar.Top;
            btnOtro.Left = btnAgregar.Left - btnOtro.Width - 5;
            btnScan.Left = btnOtro.Left - btnScan.Width - 5;

        }

        public void SeleccionarSegunMovimiento(TipoMovimiento tm)
        {
            LimpiarCampos();
            cheque = null;
            origen = null;
            destino = null;
            generaTransDep = false;
            if (tm.TipoMovimientoID == bl.pGlob.TmRetBcoCaja.TipoMovimientoID)
            {
                List<SolicitudFondo> solfons = bl.GetSolicitudesDeFondos(s=>s.ConceptoFondosID == bl.pGlob.ExtBan.ConceptoFondosID
                                                                         && s.EstadoID == bl.pGlob.SolicitudFondoConfirmada.EstadoID).ToList();

                Utilidades.CargarCombo(cmbReferencia, solfons, "InfoParaRecibos", "SolicitudFondoID",0);
                MostrarTransferenciaDepositoExtraccion();
                generaTransDep = false;
            }
            if (tm.TipoMovimientoID == bl.pGlob.TmDepCobRec.TipoMovimientoID)
            {
                MostrarTransferenciaDepositoCobranza(Com);
                generaTransDep = true;                
            }
            if (tm.TipoMovimientoID == bl.pGlob.TmDepCobComAdh.TipoMovimientoID || tm.TipoMovimientoID == bl.pGlob.TmPagoCom.TipoMovimientoID)
            {
                MostrarTransferenciaDepositoComercioAdh(Com);
                generaTransDep = true;
            }
            if (tm.TipoMovimientoID == bl.pGlob.TmIngCobComAdh.TipoMovimientoID)
            {
                MostrarTransferenciaDepositoComercioAdh(Com);
                generaTransDep = true;
            }
            if (tm.TipoMovimientoID == bl.pGlob.TmCobPorDepBanc.TipoMovimientoID)
            {
                MostrarTransferenciaDepositoCobranza(Com);
                generaTransDep = true;
            }
            if (tm.TipoMovimientoID == bl.pGlob.TmRetEfecCaja.TipoMovimientoID)
            {
                MostrarTransferenciaRetEfectivo(Com);
                generaTransDep = true;
            }
            //if (tm.TipoMovimientoID == bl.pGlob.TmValDepABco.TipoMovimientoID)
            //{
            //    generaTransDep = true;
            //}           
        }
        
        private void MostrarTransferenciaDepositoComercioAdh(Comercio Com)
        {

            MostrarTransferenciaDepositoCobranza(Com);
            Utilidades.MostrarControles(false, lblReferencia, cmbReferencia);
            Utilidades.PosicionarControl(lblComAdh, true, 20, 91);
            Utilidades.PosicionarControl(cmbComAdh, true, 104, 91);
            Utilidades.PosicionarControl(lblNotas, true, 21, 124);
            Utilidades.PosicionarControl(txtNotas, true, 104, 121);
            Utilidades.RedimensionarControl(this, true, 660, 325);
            Utilidades.RedimensionarControl(grbRecibos, true, 622, 200);
            Utilidades.PosicionarControl(grbTransDep, true, 10, 210);
        }             

        private void MostrarTransferenciaDepositoCobranza(Comercio Com)
        {
            cmbReferencia.DataSource = null;
            Utilidades.RedimensionarControl(this, true, 660, 310);
            Utilidades.PosicionarControl(lblNotas, true, 20, 91);
            Utilidades.PosicionarControl(txtNotas, true, 104,91);
            Utilidades.MostrarControles(false, lblOrigen, cmbOrigen, txtCheque, lblNCheque, lblTransDep,
                                        lblTransDep, lblcheque, cmbCheque,lblReferencia, cmbReferencia,lblComAdh,cmbComAdh);
            Utilidades.RedimensionarControl(grbRecibos, true, 622, 180);
            Utilidades.PosicionarControl(grbTransDep, true, 10, 190);
            Utilidades.RedimensionarControl(grbTransDep, true, 622, 60);
            Utilidades.PosicionarControl(lblDestino, true, 18, 32);
            Utilidades.PosicionarControl(cmbDestino, true, 106, 32);
            Utilidades.PosicionarControl(btnAgregar, true, 552, 255);
            Utilidades.PosicionarControl(lblNotas, true, 20, 91);
            Utilidades.PosicionarControl(txtNotas, true, 104, 91);
            Utilidades.CargarCombo(cmbDestino, bl.GetCuentasBancariasParaDeposito(Com).OrderBy(c=>c.orden).ToList(), "sCuentaBancaria", "CuentaBancariaID", 0);
        }


        private void MostrarTransferenciaRetEfectivo(Comercio Com)
        {
            cmbReferencia.DataSource = null;
            Utilidades.RedimensionarControl(this, true, 660, 250);
            Utilidades.PosicionarControl(lblNotas, true, 20, 91);
            Utilidades.PosicionarControl(txtNotas, true, 104, 91);
            Utilidades.MostrarControles(false, lblOrigen, cmbOrigen, txtCheque, lblNCheque, lblTransDep,
                                        lblTransDep, lblcheque, cmbCheque, lblReferencia, cmbReferencia, lblComAdh, cmbComAdh,lblDestino,cmbDestino,grbTransDep);
            Utilidades.RedimensionarControl(grbRecibos, true, 622, 180);
            //Utilidades.PosicionarControl(grbTransDep, true, 10, 190);
            //Utilidades.RedimensionarControl(grbTransDep, true, 622, 60);
            //Utilidades.PosicionarControl(lblDestino, true, 18, 32);
            //Utilidades.PosicionarControl(cmbDestino, true, 106, 32);
            Utilidades.PosicionarControl(btnAgregar, true, 552,188);
            Utilidades.PosicionarControl(lblNotas, true, 20, 91);
            Utilidades.PosicionarControl(txtNotas, true, 104, 91);
           // Utilidades.CargarCombo(cmbDestino, bl.GetCuentasBancariasParaDeposito(Com).ToList(), "sCuentaBancaria", "CuentaBancariaID", 0);
        }

        private void MostrarTransferenciaDepositoExtraccion()
        {
            Utilidades.RedimensionarControl(this, true, 660, 375);
            Utilidades.MostrarControles(false,lblDestino, cmbDestino, txtCheque,lblNCheque,lblTransDep, lblTransDep);
            Utilidades.RedimensionarControl(grbRecibos, true, 622, 200);
            Utilidades.PosicionarControl(grbTransDep, true, 10, 210);
            Utilidades.RedimensionarControl(grbTransDep, true, 622, 100);
            Utilidades.PosicionarControl(lblOrigen, true, 18, 32);
            Utilidades.PosicionarControl(cmbOrigen, true, 106, 32);
            Utilidades.PosicionarControl(lblcheque, true, 18, 62);
            Utilidades.PosicionarControl(cmbCheque, true, 106, 62);
            Utilidades.PosicionarControl(btnAgregar, true, 552, 315);
            Utilidades.PosicionarControl(lblReferencia, true, 20, 91);
            Utilidades.PosicionarControl(cmbReferencia, true, 104, 91);
            Utilidades.PosicionarControl(lblNotas, true, 21, 124);
            Utilidades.PosicionarControl(txtNotas, true, 104, 121);
            Utilidades.PosicionarControl(cmbComAdh, false, 104, 121);
            Utilidades.PosicionarControl(lblComAdh, false, 104, 121);

            //Utilidades.CargarCombo(cmbOrigen,bl.GetCuentasBancariasCentral().ToList(),"sCuentaBancaria" ,"CuentaBancariaID",0);            
        }

        private void cmbOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            origen = (CuentaBancaria)cmbOrigen.SelectedItem;
            if (origen != null)
            {
                List<Chequera> Chequeras = origen.Chequeras.Where(c => c.Cheques != null).ToList();
                List<Cheque> cheques = Chequeras.SelectMany(c => c.Cheques).Where(c=>c.EstadoID != bl.pGlob.ChequeUtilizado.EstadoID).ToList();
                Utilidades.CargarCombo(cmbCheque, cheques, "sCheque", "ChequeID",0);
            }            
        }

        private void cmbReferencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            solfon = (SolicitudFondo)cmbReferencia.SelectedItem;
            if (solfon != null)
            {
                if (tm.TipoMovimientoID == bl.pGlob.TmRetBcoCaja.TipoMovimientoID && solfon.ConceptoFondosID == bl.pGlob.ExtBan.ConceptoFondosID)
                {
                    PrepararControlesDesdeSolicitud(solfon);
                }

            }
        }

        private void PrepararControlesDesdeSolicitud(SolicitudFondo sf)
        {
            txtImporte.Text = sf.Importe.ToString();
            CuentaBancaria cb =bl.Get<CuentaBancaria>(sf.EmpresaID.Value,c=>c.EmpresaID == sf.EmpresaID && c.CuentaBancariaID == sf.CuentaBancariaID).OrderBy(c=>c.orden).FirstOrDefault();
            if (cb != null)
            {
                Utilidades.CargarComboGeneric<CuentaBancaria>(cmbOrigen, cb, "sCuentaBancaria", "CuentaBancariaID", 0);
                Utilidades.CargarComboGeneric<Cheque>(cmbCheque, solfon.Cheque, "sCheque", "ChequeID", 0);
            }
            else
            {
                MessageBox.Show("No se encuentra la Cuenta Bancaria para la solicitud de referencia, comprobar Cuentas Bancarias","Error");
            }
            
        }

        private void btnCargarInfoDummy_Click(object sender, EventArgs e)
        {
            bl.CargarDummyInfo();
        }

        private bool ValidarRecibo()
        {
            if (txtImporte.Text != null && txtImporte.Text != String.Empty)
                return true;
            else
                MessageBox.Show("Por favor ingrese un importe",Properties.Resources.Advertencia);
            return false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
           

            TransferenciasDepositos transDep = null;
            int? Comprobante = null;
            decimal importe;
            if (ValidarRecibo())
            {
                if (txtComprobante.Text != null && txtComprobante.Text != String.Empty )
                {
                    Comprobante = System.Convert.ToInt32(txtComprobante.Text);
                }
                importe = System.Convert.ToDecimal(txtImporte.Text);


                Recibo rec = bl.GrabarRecibo(Com, Comprobante, importe, dtpFecha.Value, txtNotas.Text, solfon,
                    bl.pGlob.SolicitudFondoConfirmadaYFonRet, bl.pGlob.Provisorio, p.usu,
                    generaTransDep, origen, destino, cheque, tm, ComAdhEmpID,ComAdhComID,null,null,null);

                //Recibo rec = new Recibo();
                //rec.EmpresaID = bl.pGlob.Comercio.EmpresaID;
                //rec.ComercioID = bl.pGlob.Comercio.ComercioID;
                //if (txtComprobante.Text != null && txtComprobante.Text != String.Empty  )
                //    rec.Comprobante = System.Convert.ToInt32(txtComprobante.Text);
                //if (txtImporte.Text != null && txtImporte.Text != String.Empty)
                //    rec.Importe = System.Convert.ToDecimal(txtImporte.Text);
                //rec.Fecha = dtpFecha.Value;
                //rec.Notas = txtNotas.Text;
                //if (solfon != null)
                //{
                //    rec.SolicitudFondoID = solfon.SolicitudFondoID;
                //    solfon.EstadoID = bl.pGlob.SolicitudFondoConfirmadaYFonRet.EstadoID;
                //    bl.Actualizar<SolicitudFondo>(solfon);
                //}
                    
                //rec.FechaIngreso = DateTime.Now;
                //rec.UsuarioID = p.usu.UsuarioID;
                //rec.Host = System.Environment.MachineName;
                //rec.EstadoID = bl.pGlob.Provisorio.EstadoID;
                //if (generaTransDep)
                //{
                //    transDep = GrabarTransferenciaDeposito(rec, origen, destino, cheque);
                //    rec.TransferenciasDepositosEmpId = transDep.EmpresaID;
                //    rec.TransferenciasDepositos = transDep;
                //}
                //if (tm != null)
                //{
                //    rec.TipoMovimientoID = tm.TipoMovimientoID;
                //    cc = bl.ImputarCuentaCorriente(Com,rec, transDep, tm, rec.Importe);
                //    //Agregar imputacion de transferencia y recibo a cuenta corriente. 
                //    //y en Ifinan agregar campos de cuentacorriente para recibo y transferencia.
                //}                
                
                //if (ComAdh != null)
                //{
                //    rec.ComercioAdheridoEmpresaID = ComAdh.EmpresaID;
                //    rec.ComercioAdheridoComercioID = ComAdh.ComercioID;
                //}

                //bl.AgregarTransaccional<Recibo>(rec.EmpresaID,rec);
                //if (cheque != null)
                //{
                //    cheque.EstadoID = bl.pGlob.ChequeUtilizado.EstadoID;
                //    bl.ActualizarTransaccional<Cheque>(cheque.EmpresaID.Value,cheque);
                //}
                
                //bl.Grabar(rec.EmpresaID);

                //List<Transmision> ltrans = new List<Transmision>();
                //ltrans = bl.Transmision<Recibo>(ltrans, rec, Com, bl.pGlob.TransAltaRecibo, bl.pGlob.UriRecibos);
                //ltrans = bl.Transmision<CuentaCorriente>(ltrans, cc, Com, bl.pGlob.TransImputacionCC, bl.pGlob.UriRecibos);
                //if (transDep != null)
                //    ltrans = bl.Transmision<TransferenciasDepositos>(ltrans, transDep, Com, bl.pGlob.TransAltaTransDep, bl.pGlob.UriRecibos);
                //bl.GrabarTransmisiones(rec.EmpresaID, ltrans);
                
                if (solfon != null)
                    bl.Transmision<SolicitudFondo>(solfon, Com, bl.pGlob.TransActualizarSolicitudFondos, bl.pGlob.UriSolicitarFondos);
               
                bl.Grabar();

                //TransmisionConfirmarSolicitudDeFondo(solfon);               
                
                
                MessageBox.Show(String.Format("Se ha agregado el recibo {0}", rec.ReciboID));
                lblID.Text = rec.ReciboID.ToString();
                btnAgregar.Enabled = false;
                btnOtro.Enabled = true;
                btnScan.Enabled = true;
                grbRecibos.Enabled = false;
                grbTransDep.Enabled = false;
                LimpiarCampos();

            }            
        }

        private void LimpiarCampos()
        {
            txtImporte.Clear();
            txtComprobante.Clear();
            txtNotas.Clear();
            dtpFecha.Value = DateTime.Now;
            cmbOrigen.DataSource = null;
            cmbDestino.DataSource = null;
            cmbCheque.DataSource = null;
            ComAdh = null;
            solfon = null;
            origen = null;
            destino = null;
            cheque = null;
            cc = null;
        }

        private void CargarTransferenciaDeposito()
        {

        }
        
        private TransferenciasDepositos GrabarTransferenciaDeposito(Recibo rec, CuentaBancaria origen, CuentaBancaria destino, Cheque cheq)
        {
            TransferenciasDepositos transDep = new TransferenciasDepositos();
            transDep.ComercioID = rec.ComercioID;
            transDep.ComercioEmpresaID = rec.EmpresaID;
            transDep.EmpresaID = rec.EmpresaID;
            transDep.Fecha = rec.Fecha;
            transDep.Importe = rec.Importe;
            transDep.MonedaID = bl.pGlob.Peso.MonedaID;
            transDep.Notas = rec.Notas;
            transDep.NumTransferencia = rec.Comprobante.ToString();
            transDep.UsuarioID = rec.UsuarioID;
            transDep.Host = System.Environment.MachineName;
            transDep.MedioDePagoID = bl.pGlob.TransferenciaBancaria.MedioDePagoID;
            transDep.TipoTransferenciaDepositoID = bl.pGlob.ttdComercio.TipoTransferenciaDepositoID;
            transDep.EstadoID = bl.pGlob.Pendiente.EstadoID;
            if (origen != null)
            {
                transDep.CuentaOrigenCbID = origen.CuentaBancariaID;
                transDep.CuentaOrigenEmpresaID = origen.EmpresaID;
            }
            if (destino != null)
            {
                transDep.CuentaDestinoCbID = destino.CuentaBancariaID;
                transDep.CuentaDestinoEmpresaID = destino.EmpresaID;
            }
            if (cheq != null)
            {
                //transDep.cheque = cheq;
                transDep.ChequeEmpID = cheq.EmpresaID;
                transDep.ChequeCbID = cheq.CuentaBancariaID;
                transDep.ChequeNumChequera = cheq.ChequeraID;
                transDep.ChequeNumCheque = cheq.ChequeID;
                transDep.MedioDePagoID = bl.pGlob.Cheque.MedioDePagoID;
            }
            bl.AgregarTransaccional<TransferenciasDepositos>(transDep.EmpresaID,transDep);
            return transDep;
        }

        private void cmbCheque_SelectedIndexChanged(object sender, EventArgs e)
        {
            cheque = (Cheque)cmbCheque.SelectedItem;
        }

        private void cmbDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            destino = (CuentaBancaria)cmbDestino.SelectedItem;
        }

        private void cmbComAdh_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComAdh = (Comercio)cmbComAdh.SelectedItem;
            if (ComAdh != null)
            {
                ComAdhComID = ComAdh.ComercioID;
                ComAdhEmpID = ComAdh.EmpresaID;
            }
            {
                ComAdhComID = null;
                ComAdhEmpID = null;
            }
        }

        private void txtImporte_Leave(object sender, EventArgs e)
        {

        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            if(lblID.Text != null && lblID.Text != String.Empty && lblID.Text != "0")
            {
                frmScan frmScan = new frmScan(p, bl, Convert.ToInt32(lblID.Text), "REC", "Recibo", false, "REC"); 
                frmScan.Show();
            }
        }

        private void btnOtro_Click(object sender, EventArgs e)
        {
            lblID.Text ="0";
            btnAgregar.Enabled = true;
            btnOtro.Enabled = false;
            btnScan.Enabled = false;
            grbRecibos.Enabled = true;
            grbTransDep.Enabled = true;
        }

       
    }
}
