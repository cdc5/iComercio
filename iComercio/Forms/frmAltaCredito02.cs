using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using iComercio.Rest;                       //RestApi
using iComercio.Models;                     // modelos(cred, cuot, etc)
using iComercio.DAL;                      //<MorosoEnCamara>
using Credin;
using iComercio.Auxiliar;

namespace iComercio.Forms
{
    public partial class frmAltaCredito02 : FRM
    {

        

        CuentaBancariaCliente cbc = null;
        int nIdUsuarioAvalo = 0;

        int nDocumento;
        string cDocumento;
        double nPuntaje;
        string cApellido = "";
        string cNombre = "";
        decimal nSueldo = 0;
        decimal nValorNominal = 0;
        string cProfesion;
        string cProfesion2;
        string cLaboralCli;
        int NroInforme = 0;

        int nDocumentoAdi;
        string cDocumentoAdi;
        int nDocumentoGar;
        string cDocumentoGar;

        bool bEsNuevo = false;
        bool bEsNuevoAdi = false;
        bool bEsNuevoGar = false;

        string cFiltrado = "";
        int nBoniCant = 0;
        bool bCambiaPlanes = false;

        Color backColorList = Color.White;
        Color fontColor = Color.Empty;
        Font fontList = new Font("Verdana", 7F, FontStyle.Regular);


        Cliente regCliente = null;
        Cliente regAdiGar = null;
        
        bool bPasaCli = false;
        bool bPasaPlan = false;
        bool bCamara = false;
        bool bSueldo = false;
        bool bDeuda = false;
        bool bPasaAdi = false;
        bool bPasaGar = false;

        //      Variables para el calculo de puntaje
        int nCreditos = 0;
        decimal nDeudaPorCred = 0;
        decimal nMora = 0;
        TimeSpan difFech;
        int nCuot_mora = 0;
        decimal nDeudaTot = 0;
        decimal nDeudaAtras = 0;
        int nCreditosSinCan = 0;
        decimal nMoraTot = 0;
        decimal nDeudaMes = 0;
        int nCreditosCan = 0;

        //bool EsMM = false;

        public frmAltaCredito02(Principal p, BusinessLayer bl, int nDoc, string cDoc, double nPunt, string cApe,
                                                    string cNomb, decimal nSueldoNvo, decimal nValorNominalSol, string cProf1, string cProf2,
                                                    int NroInformeContel, bool adicional, bool gar1, bool gar2, bool sGar, bool EsMM, string cLaboral)
            : base(p)
        {
            InitializeComponent();
            //this.EsMM = EsMM;
            RecargarEmpYComercio(false);   //edusaca
            nDocumento = nDoc;
            cDocumento = cDoc;
            nPuntaje = nPunt;
            cApellido = cApe;
            cNombre = cNomb;
            nSueldo = nSueldoNvo;
            nValorNominal = nValorNominalSol;
            cProfesion = cProf1;
            cProfesion2 = cProf2;
            cLaboralCli = cLaboral;
            NroInforme = NroInformeContel;

            txtPlanVN.Text = nValorNominal.ToString();
            Configura_Inicio();
            chkAdi.Checked = adicional;
            opGar0.Checked = sGar;
            opGar1.Checked = gar1;
            opGar2.Checked = gar2;
            Busca_Cliente();
            
        }
        private void Busca_Garante()
        {
            bEsNuevoGar = true;
            bPasaGar = false;


            lblMsgGar.Text = "";
            Limpia_controles(panelGar01);
            Limpia_controles(panelGar02);
            Limpia_controles(panelGar03);
            Limpia_controles(panelGar04);
            if (opGar1.Checked == false) return;
            if (txtGarDocu.Text == "") txtGarDocu.Text = "0";
            if (txtGarDocu.Text == "0") return;
            nDocumentoGar = Convert.ToInt32(txtGarDocu.Text);
            cDocumentoGar = cmbGarDoc.Text;

            btnGrabaCredito.Enabled = false;

            bCamara = ObtenerMorosoEnCamara(nDocumentoGar);
            //if (bCamara) lblAdiNombCompletoFrm.ForeColor = Color.Red;
            regAdiGar = bl.Get<Cliente>(BaseID, c => c.Documento == nDocumentoGar && c.TipoDocumentoID == cDocumentoGar).FirstOrDefault();
            if (regAdiGar != null)
            {
                LLena_Datos_Gar(regAdiGar);

                bEsNuevoGar = false;
            }
            else
            {
                btnGar.Text = "Ingresar datos garante";
                lblError.Text = "Ingrese datos del nuevo garante";
                lblError.Visible = true;
            }
            bPasaGar = Valida_Garante();
            Valida_Todo();
            txtNotasCred.Enabled = btnGrabaCredito.Enabled;
            lblMsgGar.Visible = true;
        }
        private void LLena_Datos_Gar(Cliente per)
        {
            DateTime fTmp;
            decimal dTmp;
            string cTmp = "";
            //lblCalcLabo.Text = cProfesion;
            lblGarNombre.Text = per.NombreCompleto;
            lblGarSexo.Text = per.Sexo.Nombre;
            fTmp = Convert.ToDateTime(per.FechaNacimiento);
            lblGarfNaci.Text = fTmp.ToShortDateString();
            if (per.UltimaNota != null) lblGarNotas.Text = per.UltimaNota.Detalle;

            if (per.Profesion != null)
            {
                if (per.Profesion.ProfesionPadre != null) cTmp = per.Profesion.ProfesionPadre.Nombre;
                lblGarLabo01.Text = cTmp;
                lblGarLabo02.Text = per.Profesion.Nombre;

            }


            dTmp = Convert.ToDecimal(per.Sueldo);
            lblGarSueldo.Text = dTmp.ToString("N2");
            //lblCalcSueldo.Text = dTmp.ToString("N2");
            lblGarEmpresa.Text = per.EmpresaLaboral;
            lblGarLegajo.Text = per.Legajo;


            Domicilio perD = per.Domicilios.Where(d => d.ClaseDatoID == 1).OrderByDescending(o => o.Fecha).FirstOrDefault();
            if (perD != null)
            {
                lblGarDomicilio.Text = perD.DomicilioCompleto;
                if (perD.Provincia != null) lblGarProvincia.Text = perD.Provincia.Nombre; // bl.GetProvinciaSTR(1, (int)perD.pro_id);
                if (perD.Localidad != null) lblGarLocalidad.Text = perD.Localidad.Nombre; // bl.GetLocalidadSTR(1, (int)perD.loc_id);
                lblGarComplemento.Text = perD.Complemento;
            }
            lblMsgGar.Text = "REVISAR DATOS";
            btnGar.Text = "Modificar datos garante";
            lblGarTel01.Text = per.UltimoTelefonoSTR(ParametrosGlobales.EstadoVigenteID, 1);
            lblGarTel02.Text = per.UltimoTelefonoSTR(ParametrosGlobales.EstadoVigenteID, 2);
            if (per.UltimoMailCliente != null) lblGarMail.Text = per.UltimoMailCliente.Direccion; // bl.BuscarMailTxt(1, Convert.ToInt32(txtDocuBusca.Text), CmbDocuBusca.Text);

            perD = per.Domicilios.Where(d => d.ClaseDatoID == 2).OrderByDescending(o => o.Fecha).FirstOrDefault();
            if (perD != null)
            {
                lblGarDomicilioLab.Text = perD.DomicilioCompleto;
                if (perD.Provincia != null) lblGarProvinciaLab.Text = perD.Provincia.Nombre; // bl.GetProvinciaSTR(1, (int)perD.pro_id);
                if (perD.Localidad != null) lblGarLocalidadLab.Text = perD.Localidad.Nombre; // bl.GetLocalidadSTR(1, (int)perD.loc_id);
                lblGarComplementoLab.Text = perD.Complemento;
            }


            //lblCliPunta.Text = bl.BuscaPuntaje(1, Convert.ToInt32(txtDocuBusca.Text), CmbDocuBusca.Text).ToString();
        }
        private bool Valida_Garante()
        {

            bool bPasa = true;
            //panelPlanes.Enabled = false;
            lblError.Visible = false;
            lblGarNombre.BackColor = Color.White;
            lblGarfNaci.BackColor = Color.White;
            lblGarSexo.BackColor = Color.White;
            lblGarMail.BackColor = Color.White;
            lblGarLabo01.BackColor = Color.White;
            lblGarLabo02.BackColor = Color.White;

            lblGarSueldo.BackColor = Color.White;

            lblGarDomicilio.BackColor = Color.White;
            lblGarProvincia.BackColor = Color.White;
            lblGarLocalidad.BackColor = Color.White;
            lblGarTel01.BackColor = Color.White;

            lblGarEmpresa.BackColor = Color.White;
            lblGarLegajo.BackColor = Color.White;
            lblGarTel02.BackColor = Color.White;

            lblGarDomicilioLab.BackColor = Color.White;
            lblGarProvinciaLab.BackColor = Color.White;
            lblGarLocalidadLab.BackColor = Color.White;

            if (lblGarNombre.Text == "") { lblGarNombre.BackColor = Color.OrangeRed; bPasa = false; }
            if (lblGarfNaci.Text == "") { lblGarfNaci.BackColor = Color.OrangeRed; bPasa = false; }
            if (lblGarSexo.Text == "") { lblGarSexo.BackColor = Color.OrangeRed; bPasa = false; }
            if (lblGarMail.Text == "") { lblGarMail.BackColor = Color.OrangeRed; bPasa = false; }


            if (lblGarLabo02.Text == "") { lblGarLabo02.BackColor = Color.OrangeRed; bPasa = false; }
            if (lblGarLabo01.Text == "") { lblGarLabo01.BackColor = Color.OrangeRed; bPasa = false; }


            if (lblCliSueldo.Text == "" || Convert.ToDecimal(lblCliSueldo.Text) == 0) { lblCliSueldo.BackColor = Color.OrangeRed; bPasa = false; }

            if (lblCliDomicilio.Text == "") { lblCliDomicilio.BackColor = Color.OrangeRed; bPasa = false; }
            if (lblGarProvincia.Text == "") { lblGarProvincia.BackColor = Color.OrangeRed; bPasa = false; }
            if (lblGarLocalidad.Text == "") { lblGarLocalidad.BackColor = Color.OrangeRed; bPasa = false; }
            if (lblGarTel01.Text == "" || lblGarTel01.Text.Length < 8) { lblGarTel01.BackColor = Color.OrangeRed; bPasa = false; }




            if (lblGarLabo01.Text != "SIN EMPLEO" && lblGarLabo01.Text != "JUBILADO")
            {
                if (lblGarEmpresa.Text == "") { lblGarEmpresa.BackColor = Color.OrangeRed; bPasa = false; }
                if (lblGarLegajo.Text == "") { lblGarLegajo.BackColor = Color.OrangeRed; bPasa = false; }
                if (lblGarTel02.Text == "") { lblGarTel02.BackColor = Color.OrangeRed; bPasa = false; }

                if (lblGarDomicilioLab.Text == "") { lblGarDomicilioLab.BackColor = Color.OrangeRed; bPasa = false; }

                if (lblGarProvinciaLab.Text == "") { lblGarProvinciaLab.BackColor = Color.OrangeRed; bPasa = false; }
                if (lblGarLocalidadLab.Text == "") { lblGarLocalidadLab.BackColor = Color.OrangeRed; bPasa = false; }


            }

            if (bPasa == false)
            {
                lblError.Text = "Revise datos del garante";
                lblError.Visible = true;

            }

            return bPasa;
            //panelPlanes.Enabled = true;
        }
        private bool Valida_Adicional()
        {

            bool bPasa = true;
            //panelPlanes.Enabled = false;
            lblError.Visible = false;
            lblCliNombre.BackColor = Color.White;
            lblClifNaci.BackColor = Color.White;
            lblCliSexo.BackColor = Color.White;
            lblAdiMail.BackColor = Color.White;
            lblAdiLabo01.BackColor = Color.White;
            lblAdiLabo02.BackColor = Color.White;

            lblAdiSueldo.BackColor = Color.White;

            lblAdiDomicilio.BackColor = Color.White;
            lblAdiProvincia.BackColor = Color.White;
            lblAdiLocalidad.BackColor = Color.White;
            lblAdiTel01.BackColor = Color.White;

            lblAdiEmpresa.BackColor = Color.White;
            lblAdiLegajo.BackColor = Color.White;
            lblAdiTel02.BackColor = Color.White;

            lblAdiDomicilioLab.BackColor = Color.White;
            lblAdiProvinciaLab.BackColor = Color.White;
            lblAdiLocalidadLab.BackColor = Color.White;

            if (lblAdiNombre.Text == "") { lblAdiNombre.BackColor = Color.OrangeRed; bPasa = false; }
            if (lblAdifNaci.Text == "") { lblAdifNaci.BackColor = Color.OrangeRed; bPasa = false; }
            if (lblAdiSexo.Text == "") { lblAdiSexo.BackColor = Color.OrangeRed; bPasa = false; }
            if (lblAdiMail.Text == "") { lblAdiMail.BackColor = Color.OrangeRed; bPasa = false; }


            if (lblAdiLabo02.Text == "") { lblAdiLabo02.BackColor = Color.OrangeRed; bPasa = false; }
            if (lblAdiLabo01.Text == "") { lblAdiLabo01.BackColor = Color.OrangeRed; bPasa = false; }


            if (lblCliSueldo.Text == "" || Convert.ToDecimal(lblCliSueldo.Text) == 0) { lblCliSueldo.BackColor = Color.OrangeRed; bPasa = false; }

            if (lblCliDomicilio.Text == "") { lblCliDomicilio.BackColor = Color.OrangeRed; bPasa = false; }
            if (lblAdiProvincia.Text == "") { lblAdiProvincia.BackColor = Color.OrangeRed; bPasa = false; }
            if (lblAdiLocalidad.Text == "") { lblAdiLocalidad.BackColor = Color.OrangeRed; bPasa = false; }
            if (lblAdiTel01.Text == "" || lblAdiTel01.Text.Length < 8) { lblAdiTel01.BackColor = Color.OrangeRed; bPasa = false; }




            if (lblAdiLabo01.Text != "SIN EMPLEO" && lblAdiLabo01.Text != "JUBILADO")
            {
                if (lblAdiEmpresa.Text == "") { lblAdiEmpresa.BackColor = Color.OrangeRed; bPasa = false; }
                if (lblAdiLegajo.Text == "") { lblAdiLegajo.BackColor = Color.OrangeRed; bPasa = false; }
                if (lblAdiTel02.Text == "") { lblAdiTel02.BackColor = Color.OrangeRed; bPasa = false; }

                if (lblAdiDomicilioLab.Text == "") { lblAdiDomicilioLab.BackColor = Color.OrangeRed; bPasa = false; }

                if (lblAdiProvinciaLab.Text == "") { lblAdiProvinciaLab.BackColor = Color.OrangeRed; bPasa = false; }
                if (lblAdiLocalidadLab.Text == "") { lblAdiLocalidadLab.BackColor = Color.OrangeRed; bPasa = false; }


            }

            if (bPasa == false)
            {
                lblError.Text = "Revise datos del adicional";
                lblError.Visible = true;

            }

            return bPasa;
            //panelPlanes.Enabled = true;
        }
        private void Busca_Cliente()
        {
            bEsNuevoAdi = true;
            bPasaGar = false;
            btnGrabaCredito.Enabled = false;

            lblMsgCli.Text = "";
            Limpia_controles(panelCli01);
            Limpia_controles(panelCli02);
            Limpia_controles(panelCli03);
            Limpia_controles(panelCli04);


            bCamara = ObtenerMorosoEnCamara(nDocumento);
            if (bCamara) lblCliNombCompletoFrm.ForeColor = Color.Red;

            
            regCliente = bl.Get<Cliente>(BaseID, c => c.Documento == nDocumento && c.TipoDocumentoID == cDocumento).FirstOrDefault();
            if (regCliente != null)
            {
                LLena_Datos_Cli(regCliente);
                Busca_Datos_Creditos();
                if (nDeudaAtras > 0) bDeuda = true;
                bEsNuevo = false;
            }
            else
            {
                btnCliente.Text = "Ingresar datos cliente";
                lblError.Text = "Ingrese datos del nuevo cliente";
                lblError.Visible = true;
                bEsNuevo = true;
            }
            bPasaCli = Valida_Cliente();
            Valida_Todo();
            txtNotasCred.Enabled = btnGrabaCredito.Enabled;
            if (bPasaCli == false) tabla.SelectTab("tabPage2");
            lblMsgCli.Visible = true;
        }
        private void LLena_Datos_Cli(Cliente per)
        {
            DateTime fTmp;
            decimal dTmp;
            string cTmp = "";
            //lblCalcLabo.Text = cProfesion;
            lblCliNombre.Text = per.NombreCompleto;
            lblCliNombCompletoFrm.Text = lblCliNombre.Text;
            if(per.Sexo != null) lblCliSexo.Text = per.Sexo.Nombre;
            fTmp = Convert.ToDateTime(per.FechaNacimiento);
            lblClifNaci.Text = fTmp.ToShortDateString();
            if (per.UltimaNota != null) lblCliNotas.Text = per.UltimaNota.Detalle;

            if (per.Profesion != null)
            {
                if (per.Profesion.ProfesionPadre != null) cTmp = per.Profesion.ProfesionPadre.Nombre;
                lblCliLabo01.Text = cTmp;
                lblCliLaboFrm.Text = cTmp;
                cLaboralCli = cTmp;
                lblCliLabo02.Text = regCliente.Profesion.Nombre;
                if(per.Profesion!= null) cProfesion = per.Profesion.ProfesionPadreID;
            }


            dTmp = Convert.ToDecimal(per.Sueldo);
            lblCliSueldo.Text = dTmp.ToString("N2");
            lblCalcSueldo.Text = dTmp.ToString("N2");
            lblCliSueldoFrm.Text = dTmp.ToString("N2");
            lblCliEmpresa.Text = per.EmpresaLaboral;
            lblCliLegajo.Text = per.Legajo;

            lblCalcLabo.Text = cProfesion;
            Domicilio perD = per.Domicilios.Where(d => d.ClaseDatoID == 1 && d.EstadoID == ParametrosGlobales.EstadoVigenteID).OrderByDescending(o => o.Fecha).FirstOrDefault();
            if (perD != null)
            {
                lblCliDomicilio.Text = perD.DomicilioCompleto;
                if (perD.Provincia != null) lblCliProvincia.Text = perD.Provincia.Nombre; // bl.GetProvinciaSTR(1, (int)perD.pro_id);
                if (perD.Localidad != null) lblCliLocalidad.Text = perD.Localidad.Nombre; // bl.GetLocalidadSTR(1, (int)perD.loc_id);
                lblCliComplemento.Text = perD.Complemento;
            }
            lblMsgCli.Text = "Revisar datos del clientes si están resaltados";
            btnCliente.Text = "Modificar datos cliente";
            lblCliTel01.Text = per.UltimoTelefonoSTR(ParametrosGlobales.EstadoVigenteID, 1);
            lblCliTel02.Text = per.UltimoTelefonoSTR(ParametrosGlobales.EstadoVigenteID, 2);
            if (per.UltimoMailCliente != null) lblCliMail.Text = per.UltimoMailCliente.Direccion; // bl.BuscarMailTxt(1, Convert.ToInt32(txtDocuBusca.Text), CmbDocuBusca.Text);

            perD = per.Domicilios.Where(d => d.ClaseDatoID == 2 && d.EstadoID == ParametrosGlobales.EstadoVigenteID).OrderByDescending(o => o.Fecha).FirstOrDefault();
            if (perD != null)
            {
                lblCliDomicilioLab.Text = perD.DomicilioCompleto;
                if (perD.Provincia != null) lblCliProvinciaLab.Text = perD.Provincia.Nombre; // bl.GetProvinciaSTR(1, (int)perD.pro_id);
                if (perD.Localidad != null) lblCliLocalidadLab.Text = perD.Localidad.Nombre; // bl.GetLocalidadSTR(1, (int)perD.loc_id);
                lblCliComplementoLab.Text = perD.Complemento;
            }



        }
        private void Busca_Adicional()
        {
            bEsNuevoAdi = true;
            bPasaAdi = false;
            

            lblMsgAdi.Text = "";
            Limpia_controles(panelAdi01);
            Limpia_controles(panelAdi02);
            Limpia_controles(panelAdi03);
            Limpia_controles(panelAdi04);
            if (chkAdi.Checked == false) return;
            if (txtAdiDocu.Text == "") txtAdiDocu.Text = "0";
            if (txtAdiDocu.Text == "0") return;
            nDocumentoAdi = Convert.ToInt32(txtAdiDocu.Text);
            cDocumentoAdi = cmbAdiDoc.Text;

            btnGrabaCredito.Enabled = false;

            bCamara = ObtenerMorosoEnCamara(nDocumentoAdi);
            //if (bCamara) lblAdiNombCompletoFrm.ForeColor = Color.Red;
            regAdiGar = bl.Get<Cliente>(BaseID, c => c.Documento == nDocumentoAdi && c.TipoDocumentoID == cDocumentoAdi).FirstOrDefault();
            if (regAdiGar != null)
            {
                LLena_Datos_Adi(regAdiGar);

                bEsNuevoAdi = false;
            }
            else
            {
                btnAdi.Text = "Ingresar datos adicional";
                lblError.Text = "Ingrese datos del nuevo adicional";
                lblError.Visible = true;
            }
            bPasaAdi = Valida_Adicional();
            Valida_Todo();
            txtNotasCred.Enabled = btnGrabaCredito.Enabled;
            lblMsgAdi.Visible = true;
        }
        private void LLena_Datos_Adi(Cliente per)
        {
            DateTime fTmp;
            decimal dTmp;
            string cTmp="";
            //lblCalcLabo.Text = cProfesion;
            lblAdiNombre.Text = per.NombreCompleto;
            lblAdiSexo.Text = per.Sexo.Nombre; 
            fTmp = Convert.ToDateTime(per.FechaNacimiento);
            lblAdifNaci.Text = fTmp.ToShortDateString();
            if (per.UltimaNota != null) lblAdiNotas.Text = per.UltimaNota.Detalle;

            if (per.Profesion != null)
            {
                if (per.Profesion.ProfesionPadre != null) cTmp = per.Profesion.ProfesionPadre.Nombre;
                lblAdiLabo01.Text = cTmp;
                lblAdiLabo02.Text = per.Profesion.Nombre;
                
            }


            dTmp = Convert.ToDecimal(per.Sueldo);
            lblAdiSueldo.Text = dTmp.ToString("N2");
            
            lblAdiEmpresa.Text = per.EmpresaLaboral;
            lblAdiLegajo.Text = per.Legajo;


            Domicilio perD = per.Domicilios.Where(d => d.ClaseDatoID == 1).OrderByDescending(o => o.Fecha).FirstOrDefault();
            if (perD != null)
            {
                lblAdiDomicilio.Text = perD.DomicilioCompleto;
                if(perD.Provincia!=null) lblAdiProvincia.Text = perD.Provincia.Nombre; // bl.GetProvinciaSTR(1, (int)perD.pro_id);
                if(perD.Localidad!=null) lblAdiLocalidad.Text = perD.Localidad.Nombre; // bl.GetLocalidadSTR(1, (int)perD.loc_id);
                lblAdiComplemento.Text = perD.Complemento;
            }
            lblMsgAdi.Text = "REVISAR DATOS";
            btnAdi.Text = "Modificar datos adicional";
            lblAdiTel01.Text = per.UltimoTelefonoSTR(ParametrosGlobales.EstadoVigenteID, 1);
            lblAdiTel02.Text = per.UltimoTelefonoSTR(ParametrosGlobales.EstadoVigenteID, 2);
            if (per.UltimoMailCliente != null) lblAdiMail.Text = per.UltimoMailCliente.Direccion; // bl.BuscarMailTxt(1, Convert.ToInt32(txtDocuBusca.Text), CmbDocuBusca.Text);

            perD = per.Domicilios.Where(d => d.ClaseDatoID == 2).OrderByDescending(o => o.Fecha).FirstOrDefault();
            if (perD != null)
            {
                lblAdiDomicilioLab.Text = perD.DomicilioCompleto;
                if (perD.Provincia != null) lblAdiProvinciaLab.Text = perD.Provincia.Nombre; // bl.GetProvinciaSTR(1, (int)perD.pro_id);
                if (perD.Localidad != null) lblAdiLocalidadLab.Text = perD.Localidad.Nombre; // bl.GetLocalidadSTR(1, (int)perD.loc_id);
                lblAdiComplementoLab.Text = perD.Complemento;
            }


            //lblCliPunta.Text = bl.BuscaPuntaje(1, Convert.ToInt32(txtDocuBusca.Text), CmbDocuBusca.Text).ToString();
        }
        private bool Valida_Cliente()
        {

            bool bPasa = true;
            //panelPlanes.Enabled = false;
            lblError.Visible = false;
            lblCliNombre.BackColor = Color.White;
            lblClifNaci.BackColor = Color.White;
            lblCliSexo.BackColor = Color.White;
            lblCliMail.BackColor = Color.White;
            lblCliLabo01.BackColor = Color.White;
            lblCliLabo02.BackColor = Color.White;

            lblCliSueldo.BackColor = Color.White;

            lblCliDomicilio.BackColor = Color.White;
            lblCliProvincia.BackColor = Color.White;
            lblCliLocalidad.BackColor = Color.White;
            lblCliTel01.BackColor = Color.White;

            lblCliEmpresa.BackColor = Color.White;
            lblCliLegajo.BackColor = Color.White;
            lblCliTel02.BackColor = Color.White;

            lblCliDomicilioLab.BackColor = Color.White;
            lblCliProvinciaLab.BackColor = Color.White;
            lblCliLocalidadLab.BackColor = Color.White;

            if (lblCliNombre.Text == "") { lblCliNombre.BackColor = Color.OrangeRed; bPasa = false; }
            if (lblClifNaci.Text == "") { lblClifNaci.BackColor = Color.OrangeRed; bPasa = false; }
            if (lblCliSexo.Text == "") { lblCliSexo.BackColor = Color.OrangeRed; bPasa = false; }
            //if (lblCliMail.Text == "") { lblCliMail.BackColor = Color.OrangeRed; bPasa = false; }


            if (lblCliLabo02.Text == "") { lblCliLabo02.BackColor = Color.OrangeRed; bPasa = false; }
            if (lblCliLabo01.Text == "") { lblCliLabo01.BackColor = Color.OrangeRed; bPasa = false; }
            

            if (lblCliSueldo.Text == "" || Convert.ToDecimal(lblCliSueldo.Text) == 0) { lblCliSueldo.BackColor = Color.OrangeRed; } // bPasa = false; }

            if (lblCliDomicilio.Text == "" || lblCliDomicilio.Text.Length < 6) { lblCliDomicilio.BackColor = Color.OrangeRed; bPasa = false; }
            if (lblCliProvincia.Text == "") { lblCliProvincia.BackColor = Color.OrangeRed; bPasa = false; }
            if (lblCliLocalidad.Text == "") { lblCliLocalidad.BackColor = Color.OrangeRed; bPasa = false; }
            if (lblCliTel01.Text == "" || lblCliTel01.Text.Length < 8) { lblCliTel01.BackColor = Color.OrangeRed; bPasa = false; }


            if (lblCliSueldo.Text != lblCliSueldoFrm.Text) { lblCliSueldo.BackColor = Color.OrangeRed; bPasa = false; }


            if (lblCliLabo01.Text != "SIN EMPLEO" && lblCliLabo01.Text != "JUBILADO" )
            {
                if (lblCliEmpresa.Text == "") { lblCliEmpresa.BackColor = Color.OrangeRed; bPasa = false; }
                if (lblCliLegajo.Text == "") { lblCliLegajo.BackColor = Color.OrangeRed; bPasa = false; }
                if (lblCliTel02.Text == "") { lblCliTel02.BackColor = Color.OrangeRed; bPasa = false; }

                if (lblCliDomicilioLab.Text == "") { lblCliDomicilioLab.BackColor = Color.OrangeRed; bPasa = false; }

                if (lblCliProvinciaLab.Text == "") { lblCliProvinciaLab.BackColor = Color.OrangeRed; bPasa = false; }
                if (lblCliLocalidadLab.Text == "") { lblCliLocalidadLab.BackColor = Color.OrangeRed; bPasa = false; }

            
            }
            //if (lblCliLabo01.Text != cLaboralCli) { lblCliLabo01.BackColor = Color.OrangeRed; bPasa = false; }

            if (bPasa == false)
            {
                lblError.Text = "Revise datos del cliente";
                lblError.Visible = true;
                
            }

            return bPasa;
            //panelPlanes.Enabled = true;
        }
        private void Configura_Inicio()
        {
            Configura_Listas();
            LimpiaTodo();
            Configura_Controles();
            lblCliNombCompletoFrm.Text = cApellido + " " + cNombre;
            lblCliDocuFrm.Text = nDocumento.ToString("N0");
            lblCliCodDocuFrm.Text = cDocumento;
            lblCliLaboFrm.Text = cLaboralCli; // cProfesion2;
            lblCliSueldoFrm.Text = nSueldo.ToString("N2");
            btnGrabaCredito.Enabled = false;
            //btnContinuar.Enabled = false;
            lblError.Visible = false;
             lblMor.Visible = false;  //if(EsMM)
        }
        private void Configura_Controles()
        {
            this.BackColor = ColorBackColorFrm;
            Recorre_Formulario(this);
            ListFiltrados.Top = ListPlanes.Top;
            ListFiltrados.Left = ListPlanes.Left;
            ListFiltrados.Width = ListPlanes.Width;
            ListFiltrados.Height = ListPlanes.Height;
            ListFiltrados.Visible = false;
            grpPuntaje.Visible = false;

            lblValiSueldo.Text = "";
            lblValiGar.Text = "";
            lblValiDeudaAtr.Text = "";
            lblValiCliente.Text = "";
            lblValiCamara.Text = "";
            lblValiAdi.Text = "";

            lblValiDeudaAtr.Left= Dame_Left(lblValiCamara);
            lblValiSueldo.Left = Dame_Left(lblValiDeudaAtr);
            lblValiCliente.Left = Dame_Left(lblValiSueldo);
            lblValiGar.Left = Dame_Left(lblValiCliente);
            lblValiAdi.Left = Dame_Left(lblValiGar);
            lblValiOtro.Left = Dame_Left(lblValiAdi);
            lblPlanAvalado.Left = Dame_Left(lblValiOtro);
            Utilidades.CargarCombo(cmbAdiDoc, bl.GetTiposDocumento().ToList(), "TipoDocumentoID", "TipoDocumentoID");
            Utilidades.CargarCombo(cmbGarDoc, bl.GetTiposDocumento().ToList(), "TipoDocumentoID", "TipoDocumentoID");
            if (cmbAdiDoc.Items.Count > 0) cmbAdiDoc.SelectedIndex = 1;
            if (cmbGarDoc.Items.Count > 0) cmbGarDoc.SelectedIndex = 1;
            Centrar_Control(this, grpPuntaje);
            //this.Parent.Controls.Add(panelPru);
            panelPru.Parent = this;
            Centrar_Control(this, panelPru);
            panelPru.BringToFront();
            lblNroCredito.Text = "";
        
        }
        private void opGar0_CheckedChanged(object sender, EventArgs e)
        {
            panelGarante.Enabled = !opGar0.Checked;
            //if(opGar0.Checked)
            //{
            //    panelGarante.Enabled = false;
            //}
        }

        private void chkAdi_CheckedChanged(object sender, EventArgs e)
        {
            panelAdicional.Enabled = chkAdi.Checked;
        }

        private void btnPlanes_Click(object sender, EventArgs e)
        {
            if (btnPlanes.Text == "Ver planes")
            {
                bCambiaPlanes = false; 
                Busca_Planes();
                Mira_Pru();
            }
            else
            {
                LimpiaVerPlan();

            }
        }
        private bool Busca_Permiso(string qq)
        {
            FrmClave frmclave = new FrmClave(p, this.bl, qq);
            frmclave.ShowDialog();
            if (p.usuIDAutorizado != 0) return true;
            return false;
        }
        private void Busca_Planes()    //eduardo cambio
        {
            listCuotas.Items.Clear(); 
            if (Valida() == false) return;
            decimal nTmp1 = 0;
            decimal nTmp2 = 0;
            decimal nValorBoniXcuota = 0;

            bool bPasaP = true;
            DateTime Fecha_PriVenci;

            decimal Interes = 0;
            decimal InteresIncr;
            decimal Gst;
            decimal GstIncr;
            decimal Comis;
            decimal ComisIncr;

            decimal Inter_x_cuota;
            decimal Interes_total;

            decimal Valor_total;
            decimal Valor_cuota;
            decimal Valor_Gst;
            decimal Valor_Comis;
            bool bTieneBoni = false;
            decimal nPorBoni = 0;
            List<PlanesTipo> regPlanesTipoList = null;

            regPlanesTipoList = bl.Get<PlanesTipo>(BaseID, null, pl => pl.OrderBy(pla => pla.NroORden)).ToList();


            if (regPlanesTipoList.Count == 0) return;   //ACA msg error

            decimal ValorNominal = Convert.ToDecimal(txtPlanVN.Text);
            decimal ValorSueldo = Convert.ToDecimal(lblCliSueldoFrm.Text);


            foreach (PlanesTipo planT in regPlanesTipoList)
            {
                bPasaP = false;
                if (bCambiaPlanes)
                {
                    bPasaP = true;
                    //if (planT.PuntoD <= nPuntaje) if (planT.PuntoH >= nPuntaje) bPasaP = true;
                }
                else
                {
                    if (Convert.ToDouble( planT.PuntoD) <= nPuntaje) if (Convert.ToDouble(planT.PuntoH) >= nPuntaje) bPasaP = true;
                }
                if (bPasaP)
                {
                    //if (planT.planesvenci.Count > 0)
                    //{
                    for (int i = 1; i < 21; i++)                //ACA hay que ver hasta cuantas cuotas dar
                    {
                        Fecha_PriVenci = Primer_Vencimiento(planT);     //primer vencimiento por 

                        if (ChkVenci.Visible && ChkVenci.Checked)
                        {
                            if (Fecha_PriVenci >= TxtFechVenci.Value)   //nuevo vencimiento y re-calculo de interes
                            {
                                Interes = planT.Inter;
                                InteresIncr = planT.Inter_Incr;
                            }
                            else
                            {
                                TimeSpan nDiaCh = TxtFechVenci.Value - Fecha_PriVenci;
                                int nDiaP = i * 30;

                                decimal nIntDia = planT.Inter / nDiaP;
                                int nDiaTot = nDiaP + Convert.ToInt16(nDiaCh.Days);
                                Interes = nDiaTot * nIntDia;
                                //************************************************
                                nIntDia = planT.Inter_Incr / nDiaP;
                                nDiaTot = nDiaP + Convert.ToInt16(nDiaCh.Days);
                                InteresIncr = nDiaTot * nIntDia;
                            }
                            Fecha_PriVenci = TxtFechVenci.Value;
                        }
                        else                                               // intereses normales
                        {
                            Interes = planT.Inter;
                            InteresIncr = planT.Inter_Incr;
                        }

                        Interes = decimal.Round(Interes, 2);
                        InteresIncr = decimal.Round(InteresIncr, 2);

                        Gst = planT.Gasto;
                        GstIncr = planT.Gasto_Incr;
                        Comis = planT.Comis;
                        ComisIncr = planT.Comis_Incr;

                        ListViewItem item = new ListViewItem(planT.TipoAV);                                         // tipo
                        item.SubItems.Add(i.ToString());                                                                //cuota

                        Inter_x_cuota = (Interes * i) + (InteresIncr * i * (i - 1));
                        item.SubItems.Add(Inter_x_cuota.ToString());                                             //tasa

                        item.SubItems.Add(ValorNominal.ToString());                                          //monto

                        Interes_total = (Inter_x_cuota * ValorNominal) / 100;
                        item.SubItems.Add(Interes_total.ToString());                                         // int

                        Valor_total = Interes_total + ValorNominal;
                        item.SubItems.Add(Valor_total.ToString());                                           //total

                        Valor_cuota = Valor_total / i;
                        Valor_cuota = Convert.ToDecimal(Redondeo(Valor_cuota));
                        item.SubItems.Add(Valor_cuota.ToString("N2"));                                         //valor cuota

                        item.SubItems.Add(String.Format("{0:dd/MM/yyyy}", Fecha_PriVenci));                                         //fecha pri vencimiento

                        item.SubItems.Add(""); //planT.Notas);                                         //notas

                        if (planT.GastoFijo == 0)
                        {
                            Valor_Gst = (ValorNominal * Gst / 100) + (GstIncr * i * (i - 1));
                        }
                        else
                        {
                            Valor_Gst = (decimal)planT.GastoFijo;
                        }
                        item.SubItems.Add(Valor_Gst.ToString("N2"));                                         //gasto 9
                        Valor_Comis = (ValorNominal * Comis / 100) + (ComisIncr * i * (i - 1));
                        item.SubItems.Add(Valor_Comis.ToString());                                         //comisición 10

                        item.SubItems.Add(planT.PlanesTipoID);                                         //idplan 11

                        bTieneBoni = false;                                          //BONIFICACIONES
                        nBoniCant = 0;
                        nPorBoni = 0;
                        nValorBoniXcuota = 0;
                        if (planT.planesbonif.Count > 0)
                        {
                            foreach (PlanesBonif planboni in planT.planesbonif)
                            {
                                if (planboni.FechaVenci >= DateTime.Now)
                                {
                                    if (i >= planboni.Cuotas_D && i <= planboni.Cuotas_H)   // && planboni.TipoCuota == lplane.TipoAV)
                                    {
                                        nTmp1 = Calcula_importe_Boni(planboni, ValorNominal, Valor_cuota);
                                        nValorBoniXcuota = nTmp1;
                                        nPorBoni = planboni.PorBoni;
                                        if (planboni.TipoBoni == "X")
                                        {
                                            nTmp2 = nValorBoniXcuota * nPorBoni;
                                            item.SubItems.Add(nTmp2.ToString("N2"));
                                        }
                                        else
                                        {
                                            item.SubItems.Add(nTmp1.ToString("N2"));
                                        }
                                        //bonif 12
                                        item.SubItems.Add(planboni.TipoBoni);                                   //13                               //tipo bonif
                                        // 100;  // planboni.PorBoni;
                                        if (planboni.TipoBoni == "X")
                                        {
                                            nPorBoni = planboni.PorBoni;// 100;  // planboni.PorBoni;
                                        }
                                        else
                                        {
                                            nPorBoni = planboni.PorBoni;
                                        }


                                        bTieneBoni = true;
                                    }
                                }
                            }
                        }
                        if (!bTieneBoni)
                        {
                            item.SubItems.Add("0");                 //12
                            item.SubItems.Add("");                  //13
                        }                                                         // FIN BONIFICACIONES
                        item.SubItems.Add(Convert.ToString(i * Valor_cuota));                              //total redondeado 14

                        item.Font = fontList;


                        if (planT.TipoAV == "A" && i == 1)
                        {
                            //NO LO MUESTRA
                        }
                        else
                        {
                            if (Filtra_Planes(planT.planesdetalle.ToList(), i, planT.TipoAV, Valor_cuota))
                            {
                                item.ForeColor = fontColor;
                                if (planT.TipoAV == "A") item.BackColor = Color.Cyan;
                                item.SubItems.Add(planT.Notas); //"Bien");                          //notas 15

                                item.SubItems.Add(planT.Inter.ToString());          //16
                                item.SubItems.Add(planT.Inter_Incr.ToString());          //17
                                item.SubItems.Add(planT.Gasto.ToString());          //18
                                item.SubItems.Add(planT.Gasto_Incr.ToString());          //19
                                item.SubItems.Add(planT.GastoFijo.ToString());          //20
                                item.SubItems.Add(planT.Comis.ToString());          //21
                                item.SubItems.Add(planT.Comis_Incr.ToString());          //22
                                item.SubItems.Add(planT.TipoRetencionPlanID); //23 edu202109 
                                //item.SubItems.Add("N");                             //23// edu202109
                                item.SubItems.Add("30");                            //24
                                item.SubItems.Add(nPorBoni.ToString());             //25
                                item.SubItems.Add(nBoniCant.ToString());             //26
                                item.SubItems.Add(planT.Corte.ToString());             //27
                                item.SubItems.Add(nValorBoniXcuota.ToString());             //28

                                ListPlanes.Items.Add(item);
                            }
                            else
                            {

                                item.BackColor = Color.LightCoral;
                                if (planT.TipoAV == "A") item.BackColor = Color.LightCoral;
                                item.SubItems.Add(cFiltrado);
                                ListFiltrados.Items.Add(item);
                            }
                        }

                    }
                    //}
                }

                btnPlanes.Text = "Cambiar importe";
                txtPlanVN.Enabled = false;
                ChkVenci.Enabled = false;
                TxtFechVenci.Enabled = false;
                chkAdi.Enabled = false;
                opGar0.Enabled = false;
                opGar1.Enabled = false;
            }


        }
        private bool Filtra_Planes(List<PlanesDetalle> regPlanesDetalleList, int ncuota, string tcuota, decimal ValCuot)
        {
            bool bPasoCuota = true;
            bool bPasoValor = true;
            bool bPasoValorMax = true;
            cFiltrado = "";
            if (regPlanesDetalleList.Count > 0)
            {
                foreach (PlanesDetalle pd in regPlanesDetalleList)
                {
                    bPasoCuota = false;                //                                                     CUOTAS
                    if (ncuota >= pd.Cuotas_D && ncuota <= pd.Cuotas_H) bPasoCuota = true;  // else  cFiltrado = "Filtro Cuotas";

                    if (bPasoCuota)
                    {
                        if (pd.SiValor)                                                        // entre valores
                        {
                            bPasoValor = false;
                            cFiltrado = "Filtro valor";
                            if (Convert.ToDecimal(txtPlanVN.Text) >= pd.nValor_D && Convert.ToDecimal(txtPlanVN.Text) <= pd.nValor_H) bPasoValor = true;
                        }


                        if (pd.Monto_max > 0)                                                        // valor maximo
                        {
                            bPasoValorMax = false;
                            if (Convert.ToDecimal(txtPlanVN.Text) <= pd.Monto_max) bPasoValorMax = true; else cFiltrado = "Filtro valor max";
                        }
                        if (!bPasoValor || !bPasoValorMax) return false; else return true;
                    }


                }
            }
            else
            {
                return true;
            }

            //decimal nTmp3 = 0;
            //nTmp3 = Convert.ToDecimal(bl.pGlob.Comercio.PorSueldo);



            return false;
        }

        private decimal Calcula_importe_Boni(PlanesBonif pboni, decimal VN, decimal VC)
        {
            decimal qBoni = 0;
            nBoniCant = 0;
            if (pboni.TipoBoni == "C")
            {
                if (pboni.PorBoni == 100)
                {
                    qBoni = VC;
                }
                else
                {
                    qBoni = VC * pboni.PorBoni / 100;
                }
                nBoniCant = 1;
            }
            else if (pboni.TipoBoni == "V")
            {
                qBoni = VN * pboni.PorBoni / 100;
                nBoniCant = 1;
            }
            else if (pboni.TipoBoni == "X")
            {
                qBoni = VC; // *pboni.PorBoni;
                nBoniCant = (int)(pboni.PorBoni);

            }
            return qBoni;
        }
        private DateTime Primer_Vencimiento(PlanesTipo UnPlan)
        {
            DateTime PriVenci;
            //int nAno = 1;
            //int nMes = 1;
            int nDia = 10;
            int nCorte = 20;
            int CuantosMeses = 1;

            //bool bNormal = false;

            string cTipoVenci;
            int nV = UnPlan.planesvenci.Count;

            CuantosMeses = 1;
            PriVenci = DateTime.Now.AddMonths(CuantosMeses);

            if (nV == 0)
            {
                //nDia = DateTime.Now.Day;
                //bNormal = true;
            }
            else
            {
                if (UnPlan.planesvenci[0].DiasPrimerCuota > 0)      // cuantos meses es el primer venci
                {
                    CuantosMeses = UnPlan.planesvenci[0].DiasPrimerCuota / 30;
                }
                else
                {
                    CuantosMeses = 1;
                }

                nDia = DateTime.Now.Day; // UnPlan.planesvenci[0].VenciDia;
                nCorte = UnPlan.planesvenci[0].VenciCorte;
                PriVenci = DateTime.Now.AddMonths(CuantosMeses);
                cTipoVenci = UnPlan.planesvenci[0].TipoVencimiento;
                if (cTipoVenci == "*" || cTipoVenci == "A1")
                {
                    if (nDia <= nCorte)
                    {
                        nDia = UnPlan.planesvenci[0].VenciDia;
                        return PriVenci = Convert.ToDateTime(nDia + "/" + PriVenci.Month + "/" + PriVenci.Year);
                    }
                    else
                    {
                        nDia = 10;
                        PriVenci = PriVenci.AddMonths(1);
                        return PriVenci = Convert.ToDateTime(nDia + "/" + PriVenci.Month + "/" + PriVenci.Year);
                    }
                }
                else if (cTipoVenci == " ")
                {
                    if (nDia <= 28)
                    {
                        return PriVenci;
                    }
                    else
                    {
                        PriVenci = PriVenci.AddMonths(1);
                        return PriVenci = Convert.ToDateTime(10 + "/" + PriVenci.Month + "/" + PriVenci.Year);
                    }
                }

                else if (cTipoVenci == "A2")
                {
                    if (nDia <= nCorte)
                    {
                        return PriVenci = Convert.ToDateTime(nCorte + "/" + PriVenci.Month + "/" + PriVenci.Year);
                    }
                    else if (nDia <= UnPlan.planesvenci[0].Vendia2)
                    {
                        nCorte = UnPlan.planesvenci[0].Vendia2;
                        return PriVenci = Convert.ToDateTime(nCorte + "/" + PriVenci.Month + "/" + PriVenci.Year);
                    }
                    else if (nDia > UnPlan.planesvenci[0].Vendia2)
                    {
                        PriVenci = PriVenci.AddMonths(1);
                        nDia = 1;
                        return PriVenci = Convert.ToDateTime(nDia + "/" + PriVenci.Month + "/" + PriVenci.Year);

                    }
                }
            }
            return PriVenci;


        }
        private bool Valida()
        {
            ListPlanes.Items.Clear();
            ListFiltrados.Items.Clear();
            ListFiltrados.Visible = false;
            ListPlanes.Visible = true;
            lblValida.Text = "";
            if (Convert.ToDecimal(txtPlanVN.Text) == 0)
            {
                lblValida.Text = "Ingrese importe";
                return false;
            }
            if (Convert.ToDecimal(lblCliSueldoFrm.Text) == 0)
            {
                lblValida.Text = "No cargó el sueldo";
                return false;

            }
            if (TxtFechVenci.Visible)
            {
                int nDias = bl.Calcula_dias_mora(DateTime.Now, TxtFechVenci.Value);
                if (nDias > 45)
                {
                    lblValida.Text = "El nuevo vencimiento no puede ser superar los 45 días";
                    return false;
                }
                if (nDias < 0)
                {
                    lblValida.Text = "El nuevo vencimiento no puede ser inferior a hoy";
                    return false;
                }

            }
            return true;
        }
        private void LimpiaTodo()
        {
            lblValida.Text = "";
            ListFiltrados.Visible = false;
            ListPlanes.Visible = true;
            listCuotas.Items.Clear();
            Limpia_controles(grpPlan);
            Limpia_controles(panelAdicional);
            Limpia_controles(panelGarante);
            panelAdicional.Enabled = false;
            panelGarante.Enabled = false;
            TxtFechVenci.Visible = false;
            TxtFechVenci.Value = DateTime.Now;
            TxtFechVenci.Visible = false;
            lblPlanAvalado.Visible = false;
            panelPru.Visible = false;
        }
        private void LimpiaVerPlan()
        {
            btnPlanes.Text = "Ver planes";
            //lblMor.Visible = false;
            ListPlanes.Items.Clear();
            ListFiltrados.Items.Clear();
            ListFiltrados.Visible = false;
            listCuotas.Items.Clear();
            ListPlanes.Enabled = true;
            Limpia_controles(grpPlan);
            txtPlanVN.Enabled = true;
            ChkVenci.Enabled = true;
            chkAdi.Enabled = true;
            opGar0.Enabled = true;
            opGar1.Enabled = true;
            TxtFechVenci.Enabled = true;
            //btnContinuar.Enabled = false;
            btnGrabaCredito.Enabled = false;
            txtNotasCred.Enabled = btnGrabaCredito.Enabled;
            lblPlanAvalado.Visible = false;

        }

        private void ChkVenci_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkVenci.Checked == true) TxtFechVenci.Visible = true; else TxtFechVenci.Visible = false;
        }
        private void Configura_Listas()
        {

            listCuotas.View = View.Details;
            listCuotas.Columns.Add("Cuota", 40, HorizontalAlignment.Right);               //0
            listCuotas.Columns.Add("Vencimiento", 80, HorizontalAlignment.Right);               //0
            listCuotas.Columns.Add("Valor Cuota", 80, HorizontalAlignment.Right);               //0
            listCuotas.Columns.Add("", 0, HorizontalAlignment.Left);               //0
            listCuotas.Columns.Add("Bonif", 80, HorizontalAlignment.Right);               //0
            listCuotas.OwnerDraw = true;

            ListPlanes.View = View.Details;
            ListPlanes.Columns.Add("Tipo", 35, HorizontalAlignment.Left);               //0
            ListPlanes.Columns.Add("Cuota", 40, HorizontalAlignment.Right);
            ListPlanes.Columns.Add("", 0, HorizontalAlignment.Right);              //2Tasa
            ListPlanes.Columns.Add("", 0, HorizontalAlignment.Right);               //Monto
            ListPlanes.Columns.Add("", 0, HorizontalAlignment.Right);             //4  Inter
            ListPlanes.Columns.Add("", 0, HorizontalAlignment.Right);               //Total
            ListPlanes.Columns.Add("Valor Cuota", 75, HorizontalAlignment.Right);       //6
            ListPlanes.Columns.Add("Primer Vencimiento", 80, HorizontalAlignment.Left); //7
            ListPlanes.Columns.Add("", 0, HorizontalAlignment.Left);            //Notas
            ListPlanes.Columns.Add("Gasto", 60, HorizontalAlignment.Right);              //9
            ListPlanes.Columns.Add("", 0, HorizontalAlignment.Right);               //Comis
            ListPlanes.Columns.Add("IdPlan", 100, HorizontalAlignment.Left);              //11
            ListPlanes.Columns.Add("Bonif", 75, HorizontalAlignment.Right);
            ListPlanes.Columns.Add("T Boni", 0, HorizontalAlignment.Left);             //13
            ListPlanes.Columns.Add("", 0, HorizontalAlignment.Right);                   //Total redondeado
            ListPlanes.Columns.Add("notas", 75, HorizontalAlignment.Left);

            ListPlanes.Columns.Add("", 0, HorizontalAlignment.Left);             //16
            ListPlanes.Columns.Add("", 0, HorizontalAlignment.Left);             //17
            ListPlanes.Columns.Add("", 0, HorizontalAlignment.Left);             //18
            ListPlanes.Columns.Add("", 0, HorizontalAlignment.Left);             //19
            ListPlanes.Columns.Add("", 0, HorizontalAlignment.Left);             //20
            ListPlanes.Columns.Add("", 0, HorizontalAlignment.Left);             //21
            ListPlanes.Columns.Add("", 0, HorizontalAlignment.Left);             //22
            ListPlanes.Columns.Add("", 0, HorizontalAlignment.Left);             //23
            ListPlanes.Columns.Add("", 0, HorizontalAlignment.Left);             //24
            ListPlanes.Columns.Add("", 0, HorizontalAlignment.Left);             //25
            ListPlanes.Columns.Add("", 0, HorizontalAlignment.Left);             //26  cantidad de cuotas bonificadas
            ListPlanes.Columns.Add("", 0, HorizontalAlignment.Left);                //27 corte
            ListPlanes.Columns.Add("", 0, HorizontalAlignment.Left);                //28 porboni
            //************************************************************************************************
            //************************************************************************************************
            ListFiltrados.View = View.Details;
            ListFiltrados.Columns.Add("Tipo", 40, HorizontalAlignment.Left);               //0
            ListFiltrados.Columns.Add("Cuota", 50, HorizontalAlignment.Right);
            ListFiltrados.Columns.Add("", 0, HorizontalAlignment.Right);              //2
            ListFiltrados.Columns.Add("", 0, HorizontalAlignment.Right);
            ListFiltrados.Columns.Add("", 0, HorizontalAlignment.Right);             //4
            ListFiltrados.Columns.Add("", 0, HorizontalAlignment.Right);
            ListFiltrados.Columns.Add("Valor Cuota", 80, HorizontalAlignment.Right);       //5
            ListFiltrados.Columns.Add("Primer Vencimiento", 90, HorizontalAlignment.Left); //6
            ListFiltrados.Columns.Add("", 0, HorizontalAlignment.Left);
            ListFiltrados.Columns.Add("Gasto", 60, HorizontalAlignment.Right);              //8
            ListFiltrados.Columns.Add("", 0, HorizontalAlignment.Left);
            ListFiltrados.Columns.Add("IdPlan", 140, HorizontalAlignment.Left);              //10
            ListFiltrados.Columns.Add("Bonif", 80, HorizontalAlignment.Right);
            ListFiltrados.Columns.Add("T Boni", 60, HorizontalAlignment.Left);             //12
            ListFiltrados.Columns.Add("T", 0, HorizontalAlignment.Left);
            ListFiltrados.Columns.Add("notas", 140, HorizontalAlignment.Left);
            //************************************************************************************************   
        }

        private void frmAltaCredito02_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {

                case Keys.Escape:
                    grpPuntaje.Visible = false;
                    panelPru.Visible = false;
                    lblSombra.Visible = false;
                    break;

                case Keys.F3:
                    ListFiltrados.Visible = !ListFiltrados.Visible;
                    break;
                case Keys.F4:
                    lblSombra.Width = grpPuntaje.Width;
                    lblSombra.Height = grpPuntaje.Height - 3;
                    lblSombra.Top = grpPuntaje.Top + 10;
                    lblSombra.Left = grpPuntaje.Left + 7;
                    lblSombra.BringToFront();
                    grpPuntaje.BringToFront();
                    grpPuntaje.Visible = !grpPuntaje.Visible;
                    //grpCuotas.Visible = !grpPuntaje.Visible;
                    lblSombra.Visible = grpPuntaje.Visible;
                    //lblSombra2.Visible = grpCuotas.Visible;
                    break;

                case Keys.F5: //eduardo cambio
                    bCambiaPlanes = false;
                    if (Abre_Para_Avalar())
                    {
                        if (lblPlanAvalado.Visible) bCambiaPlanes = true;
                        LimpiaVerPlan(); // Limpia(false);
                        if (bCambiaPlanes) lblPlanAvalado.Visible = true;
                        Busca_Planes();
                    }


                    break;
                case Keys.F9:
                    if (e.Shift)
                    {
                        if (bl.LlevaM())
                        {
                            if (lblMor.Visible)
                            {
                                lblMor.Visible = false;
                            }
                            else
                            {
                                lblMor.Visible = true;

                            }
                            RecargarEmpYComercio(lblMor.Visible);
                            if (btnPlanes.Text != "Ver planes")
                            {
                                Busca_Planes();
                                Mira_Pru();
                            }
                        }


                            //if (btnPlanes.Text == "Ver planes") return;
                        //    if (lblMor.Visible)
                        //{
                        //    lblMor.Visible = false;
                        //}
                        //else
                        //{
                        //    if (bl.LlevaM())
                        //    {
                        //        lblMor.Visible = true;
                        //        if (btnPlanes.Text != "Ver planes")
                        //        {
                        //            Busca_Planes();
                        //            Mira_Pru();
                        //        }
                        //    }
                        //}
                        RecargarEmpYComercio(lblMor.Visible);
                    }
                    break;
                case Keys.F10:
                    if (bl.LlevaM())
                    {
                        if (e.Shift) panelPru.Visible = true;
                    }
                    break;
                case Keys.F12:
                    if (btnGrabaCredito.Enabled) break;
                    //if (btnContinuar.Enabled) break;
                    if (btnPlanes.Text == "Ver planes") break;
                    if (listCuotas.Items.Count == 0) break;
                    Abre_Para_Avalar();
                    txtNotasCred.Enabled = btnGrabaCredito.Enabled;
                    break;

            }
        }
        private bool Abre_Para_Avalar()
        {
            if (btnGrabaCredito.Enabled) return false;
            lblPlanAvalado.Visible = false;
            btnGrabaCredito.Enabled = Busca_Permiso("Avalar");
            if (btnGrabaCredito.Enabled)
            {
                nIdUsuarioAvalo = p.usuIDAutorizado;
                lblPlanAvalado.Visible = true;
            }
            return btnGrabaCredito.Enabled;
        }

        private void ListPlanes_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblValida.Text = "";
            bPasaPlan = false;
            btnGrabaCredito.Enabled = false;
            txtNotasCred.Enabled = btnGrabaCredito.Enabled;
            lblPlanAvalado.Visible = false;
            foreach (ListViewItem aa in ListPlanes.SelectedItems)
            {
                Valida_Planes(aa);
                Llena_Cuotas(aa);
                btnGrabaCredito.Enabled= Valida_Todo();
                txtNotasCred.Enabled = btnGrabaCredito.Enabled;
            }
        }
        private void Valida_Planes(ListViewItem lItem)
        {
            btnGrabaCredito.Enabled = false;
            txtNotasCred.Enabled = btnGrabaCredito.Enabled;
            lblValida.Text = "";
            decimal nTmp1 = 0;
            decimal nTmp2 = 0;
            decimal nTmp3 = 0;
            bSueldo = false;
            nTmp1 = ((decimal)bl.pGlob.Comercio.PorSueldo * Convert.ToDecimal(lblCliSueldoFrm.Text)) / 100;

            nTmp3 = Convert.ToDecimal(lItem.SubItems[6].Text);
            nTmp2 = nTmp3 + nDeudaMes;
            if (nTmp2 > nTmp1)
            {
                bSueldo = true;
                lblValida.Text = "Sueldo";
            }
            if (bCamara) lblValida.Text = lblValida.Text + " - " + "Cámara";
            if (bDeuda) lblValida.Text = lblValida.Text + " - " + "Deuda";
            if (lblValida.Text == "") btnGrabaCredito.Enabled = true;
            txtNotasCred.Enabled = btnGrabaCredito.Enabled;
        }
        private void btnCliente_Click(object sender, EventArgs e)
        {
            string cNM = "M";
            if(bEsNuevo)
            {
                cNM = "N";
            }
            frmClienteNVO frm = new frmClienteNVO(this.p, cNM, nDocumento, cDocumento, lblMor.Visible);
            frm.WindowState = FormWindowState.Normal;
            frm.ShowDialog();
            bl = new BusinessLayer();
            Busca_Cliente();
        }

        //private void btnContinuar_Click(object sender, EventArgs e)
        //{
        //    if (Valida_Todo()) btnGrabaCredito.Enabled = true;
        //    //if (bPasaCli && bPasaPlan) btnGrabaCredito.Enabled = true;
        //}
        private void Busca_Datos_Creditos()
        {
            nCreditos = 0;
            nCreditosCan = 0;
            nCreditosSinCan = 0;
            nMoraTot = 0;
            nDeudaTot = 0;
            nDeudaAtras = 0;
            nDeudaMes = 0;
            if (regCliente != null)
            {
                
                //List<Credito> regCreditosList;
                //regCreditosList = regCliente.Creditos
                if (regCliente.Creditos.Count > 0)
                {
                    Calcula_Datos_Creditos(regCliente.Creditos.ToList());
                }

                if (regCliente.CreditosAdi.Count > 0)
                {
                    Calcula_Datos_Creditos(regCliente.CreditosAdi.ToList());
                }

                if (regCliente.CreditosGar1.Count > 0)
                {
                    Calcula_Datos_Creditos(regCliente.CreditosGar1.ToList());
                }
                if (regCliente.CreditosGar2.Count > 0)
                {
                    Calcula_Datos_Creditos(regCliente.CreditosGar2.ToList());
                }
                if (regCliente.CreditosGar3.Count > 0)
                {
                    Calcula_Datos_Creditos(regCliente.CreditosGar3.ToList());
                }

                if (nMoraTot > 0 && nCreditos > 0) nMoraTot = nMoraTot / nCreditos;

                lblCalcCred.Text = nCreditos.ToString();
                lblCalcCan.Text = nCreditosCan.ToString();
                lblCalcSinCan.Text = nCreditosSinCan.ToString();
                lblCalcMora.Text = Convert.ToInt16(nMoraTot).ToString(); // nMoraTot.ToString();
                lblCalcDeuda.Text = nDeudaTot.ToString();
                lblCalcDeudaAtras.Text = nDeudaAtras.ToString();
                lblCalcDeudaMensual.Text = nDeudaMes.ToString();

                //if (nCreditos > 0) Calcula_puntaje();
            }
            Calcula_puntaje();
        }
        private void Calcula_Datos_Creditos(List<Credito> ListCreditos)
        {
            foreach (Credito Cred in ListCreditos)
            {
                nCreditos++;
                nDeudaPorCred = 0;
                nMora = 0;
                nCuot_mora = 0;
                DateTime PriVenci = DateTime.Now.AddMonths(1);
                foreach (Cuota cuo in Cred.Cuotas)
                {
                    if (cuo.Importe - cuo.ImportePago > 0)
                    {
                        nDeudaTot = nDeudaTot + (cuo.Importe - cuo.ImportePago);
                        nDeudaPorCred = nDeudaPorCred + (cuo.Importe - cuo.ImportePago);
                        if (cuo.FechaVencimiento <= DateTime.Now) nDeudaAtras = nDeudaAtras + (cuo.Importe - cuo.ImportePago);


                        if (cuo.FechaVencimiento.Year == PriVenci.Year && cuo.FechaVencimiento.Month == PriVenci.Month) nDeudaMes = nDeudaMes + cuo.Importe;

                        difFech = DateTime.Now - cuo.FechaVencimiento;
                        nMora = nMora + difFech.Days;
                        nCuot_mora++; // = nCuot_mora + 1;
                    }
                    else
                    {
                        if (cuo.FechaUltimoPago != null)
                        {
                            if (cuo.FechaUltimoPago > cuo.FechaVencimiento)
                            {
                                difFech = Convert.ToDateTime(cuo.FechaUltimoPago) - cuo.FechaVencimiento;
                                nMora = nMora + difFech.Days;
                                nCuot_mora++;// = nCuot_mora + 1;
                            }
                        }
                    }

                }
                if (nDeudaPorCred > 0) nCreditosSinCan++; else nCreditosCan++;

                if (nMora > 0 && nCuot_mora > 0)
                {
                    nMoraTot = nMoraTot + Convert.ToInt16(nMora / nCuot_mora);
                }
            }
        }
        private bool Calcula_puntaje()
        {
            nPuntaje=bl.CalculaPuntaje(1, Convert.ToDouble(lblCalcSueldo.Text), Convert.ToInt32(lblCalcCred.Text), Convert.ToInt32(lblCalcCan.Text), Convert.ToInt32(lblCalcMora.Text), lblCalcLabo.Text);
            lblCalcPunta.Text = nPuntaje.ToString();
            lblCliPuntajeFrm.Text = lblCalcPunta.Text;

            return true;
        }
        private bool Calcula_puntajeXXXX()
        {
            double nTmp = 0;
            decimal nTmp1 = 0;
            string cTmp = "";
            PlanesParam regPlanesParam;
            double nPuntIngre = 0;
            double nPuntCred = 0;
            double nPuntCanc = 0;
            double nPuntMora = 0;
            double nPuntLabo = 0;

            //regPlanesParamList = bl.GetPlanesParams(c => c.Param2 == "INGRESOS", p => p.OrderBy(pl => pl.Orden)).ToList();
            List<PlanesParam> regPlanesParamList = null;
            if (Busca_Parametros("INGRESOS", ref regPlanesParamList) == false) return false;
            nTmp = 0;
            nTmp1 = Convert.ToDecimal(lblCalcSueldo.Text);
            foreach (PlanesParam lplparam in regPlanesParamList)
            {
                if (lplparam.Desde <= nTmp1 && lplparam.Hasta >= nTmp1)
                {
                    lblParamSueldo.Text = lplparam.Valor.ToString();
                    regPlanesParam = bl.Get<PlanesParam>(c => c.Param1 == "INGRESOS").FirstOrDefault();
                    nTmp = (regPlanesParam.Valor * lplparam.Valor); ///100;
                    nPuntIngre = nTmp / 100;
                    if (regPlanesParam != null) lblPuntaSueldo.Text = nPuntIngre.ToString();
                }
            }

            if (Busca_Parametros("CREDITOS", ref regPlanesParamList) == false) return false;
            nTmp = 0;
            nTmp1 = Convert.ToDecimal(lblCalcCred.Text);
            foreach (PlanesParam lplparam in regPlanesParamList)
            {
                if (lplparam.Desde <= nTmp1 && lplparam.Hasta >= nTmp1)
                {
                    lblParamCred.Text = lplparam.Valor.ToString();
                    regPlanesParam = bl.Get<PlanesParam>(c => c.Param1 == "CREDITOS").FirstOrDefault();
                    nTmp = (regPlanesParam.Valor * lplparam.Valor); ///100;
                    nPuntCred = nTmp / 100;
                    if (regPlanesParam != null) lblPuntaCred.Text = nPuntCred.ToString();
                }
            }

            if (Busca_Parametros("CANCELADOS", ref regPlanesParamList) == false) return false;
            nTmp = 0;
            nTmp1 = Convert.ToDecimal(lblCalcCan.Text);
            foreach (PlanesParam lplparam in regPlanesParamList)
            {
                if (lplparam.Desde <= nTmp1 && lplparam.Hasta >= nTmp1)
                {
                    lblParamCan.Text = lplparam.Valor.ToString();
                    regPlanesParam = bl.Get<PlanesParam>(c => c.Param1 == "CANCELADOS").FirstOrDefault();
                    nTmp = (regPlanesParam.Valor * lplparam.Valor); ///100;
                    nPuntCanc = nTmp / 100;
                    if (regPlanesParam != null) lblPuntaCan.Text = nPuntCanc.ToString();
                }
            }

            if (Busca_Parametros("MOROSIDAD", ref regPlanesParamList) == false) return false;
            nTmp = 0;
            nTmp1 = Convert.ToDecimal(lblCalcMora.Text);
            foreach (PlanesParam lplparam in regPlanesParamList)
            {
                if (lplparam.Desde <= nTmp1 && lplparam.Hasta >= nTmp1)
                {
                    lblParamMora.Text = lplparam.Valor.ToString();
                    regPlanesParam = bl.Get<PlanesParam>(c => c.Param1 == "MOROSIDAD").FirstOrDefault();
                    nTmp = (regPlanesParam.Valor * lplparam.Valor); ///100;
                    nPuntMora = nTmp / 100;
                    if (regPlanesParam != null) lblPuntaMora.Text = nPuntMora.ToString();
                }
            }


            if (!Busca_Parametros("LABORAL", ref regPlanesParamList)) return false;
            nTmp = 0;
            cTmp = lblCalcLabo.Text;
            foreach (PlanesParam lplparam in regPlanesParamList)
            {
                if (lplparam.Param1 == cTmp)
                {
                    lblParamLabo.Text = lplparam.Valor.ToString();
                    regPlanesParam = bl.Get<PlanesParam>(c => c.Param1 == "LABORAL").FirstOrDefault();
                    nTmp = (regPlanesParam.Valor * lplparam.Valor); ///100;
                    nPuntLabo = nTmp / 100;
                    if (regPlanesParam != null) lblPuntaLabo.Text = nPuntLabo.ToString();
                }
            }
            nPuntaje = nPuntIngre + nPuntCred + nPuntCanc + nPuntMora + nPuntLabo;

            lblCalcPunta.Text = nPuntaje.ToString();
            lblCliPuntajeFrm.Text = lblCalcPunta.Text;

            return true;
        }
        private bool Busca_Parametros(string qParam, ref List<PlanesParam> regPlanesParamList)
        {
            regPlanesParamList = bl.Get<PlanesParam>(BaseID, c => c.Param2 == qParam, p => p.OrderBy(pl => pl.Orden)).ToList();
            if (regPlanesParamList.Count == 0)
            {
                //ACA ERROR
                return false;
            }
            return true;
        }
        private bool Valida_Todo()
        {
            btnGrabaCredito.Enabled = false;
            lblValiSueldo.Text = "";
            lblValiDeudaAtr.Text = "";
            lblValiCliente.Text = "";
            lblValiCamara.Text = "";

            lblValiGar.Text = "";
            lblValiAdi.Text = "";

            if (bSueldo) lblValiSueldo.Text = "Sueldo";
            if (bDeuda) lblValiDeudaAtr.Text = "Deuda";
            if (bCamara) lblValiCamara.Text = "Cámara";

            if (bPasaCli == false) lblValiCliente.Text = "Datos cliente";
            if(chkAdi.Checked) if (bPasaAdi == false) lblValiAdi.Text = "Datos adicional";
            if (opGar1.Checked) if (bPasaGar == false) lblValiGar.Text = "Datos garante";


            if (lblPlanAvalado.Visible)
            {
                if (lblValiCliente.Text == "" && lblValiGar.Text == "" && lblValiAdi.Text == "") return true;
            }
            else
            {
                if (lblValiSueldo.Text == "" && lblValiDeudaAtr.Text == "" && lblValiCliente.Text == "" && lblValiCamara.Text == "" && lblValiGar.Text == "" && lblValiAdi.Text == "")
                {
                    if (bPasaPlan) return true;
                }
            }
            return false;

        }
        private void Llena_Cuotas(ListViewItem lItem)
        {
            Limpia_controles(grpPlan);

            fontColor = Color.Empty;
            backColorList = Color.LightSteelBlue;
            fontList = new Font("Verdana", 8F, FontStyle.Regular);
            listCuotas.Items.Clear();
            int nDesde = 0;
            decimal nAPagar = 0;
            if (lItem.SubItems[0].Text == "A") nDesde = 2; else nDesde = 1;

            DateTime FechVenci = Convert.ToDateTime(lItem.SubItems[7].Text);

            decimal nTmp1 = 0;
            int nCuotas = Convert.ToInt16(lItem.SubItems[1].Text);
            decimal nValCuota = Convert.ToDecimal(lItem.SubItems[6].Text);
            nTmp1 = Convert.ToDecimal(lItem.SubItems[14].Text);
            decimal nValInt = (nTmp1 - Convert.ToDecimal(txtPlanVN.Text)) / nCuotas;


            decimal nBoni = Convert.ToDecimal(lItem.SubItems[28].Text);
            lblPlanBoniValorXcuota.Text = lItem.SubItems[28].Text;
            nBoniCant = Convert.ToInt16(lItem.SubItems[26].Text);

            lblPlanBoniValor.Text = "0";

            for (int i = nDesde; i <= nCuotas; i++)
            {
                ListViewItem item = new ListViewItem(i.ToString());
                item.SubItems.Add(String.Format("{0:dd/MM/yyyy}", FechVenci), fontColor, backColorList, fontList);
                item.SubItems.Add(nValCuota.ToString(), fontColor, backColorList, fontList);
                item.SubItems.Add(nValInt.ToString("N2"), fontColor, backColorList, fontList);
                if (nBoniCant == 1)
                {
                    if (i == nCuotas) item.SubItems.Add(nBoni.ToString("N2"), fontColor, backColorList, fontList); else item.SubItems.Add("0", fontColor, backColorList, fontList);
                }
                else if (nBoniCant > 1)
                {
                    if (i > nCuotas - nBoniCant) item.SubItems.Add(nBoni.ToString("N2"), fontColor, backColorList, fontList); else item.SubItems.Add("0", fontColor, backColorList, fontList);
                }


                listCuotas.Items.Add(item);
                FechVenci = FechVenci.AddMonths(1);
                if (backColorList == Color.White) backColorList = Color.LightSteelBlue; else backColorList = Color.White;

            }

            lblPlanCuotas.Text = nCuotas.ToString();
            if (lItem.SubItems[0].Text == "A")
            {
                lblPlanTipo.Text = "Adelantada";
                nAPagar = nValCuota;
            }
            else
            {
                lblPlanTipo.Text = "Vencida";
            }
            lblPlanTipoAV.Text = lItem.SubItems[0].Text;
            lblPlanValorCuotas.Text = nValCuota.ToString();
            lblPlanBoniTipo.Text = lItem.SubItems[13].Text;
            lblPlanBoniPorcen.Text = lItem.SubItems[25].Text;
            lblPlanBoniValor.Text = lItem.SubItems[12].Text;
            //            lblPlanBoniValor.Text = Convert.ToString(Convert.ToDouble(lblPlanBoniValor.Text) + Convert.ToDouble(lItem.SubItems[12].Text));

            nTmp1 = nValInt * nCuotas;
            lblPlanInteresImp.Text = nTmp1.ToString();
            lblPlanPrimerVenci.Text = lItem.SubItems[7].Text;
            lblPlanGastoImp.Text = lItem.SubItems[9].Text;
            nAPagar = nAPagar + Convert.ToDecimal(lItem.SubItems[9].Text);
            lblPlanComisionImp.Text = lItem.SubItems[10].Text;
            lblPlanTasa.Text = lItem.SubItems[16].Text;
            lblPlanTasaIncr.Text = lItem.SubItems[17].Text;
            lblPlanGastoInt.Text = lItem.SubItems[18].Text;
            lblPlanGastoIncr.Text = lItem.SubItems[19].Text;
            lblPlanGastoFijo.Text = lItem.SubItems[20].Text;
            lblPlanComisionInt.Text = lItem.SubItems[21].Text;
            lblPlanComisionIncr.Text = lItem.SubItems[22].Text;

            lblPlanRetencion.Text = lItem.SubItems[23].Text;
            lblPlanDiasVenci.Text = lItem.SubItems[24].Text;
            lblPlanAPagar.Text = nAPagar.ToString("N2");
            lblPlanCorte.Text = lItem.SubItems[27].Text;
            lblPlanID.Text = lItem.SubItems[11].Text;
            bPasaPlan = true;
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

        private void opGar1_CheckedChanged(object sender, EventArgs e)
        {
            panelGarante.Enabled = opGar1.Checked;
        }

        private void btnGrabaCredito_Click(object sender, EventArgs e)
        {
            if (lblNroCredito.Text != "") return;
            if (Valida_Todo() == false) return;
            Graba_Credito();
 
        }
        private void Graba_Credito()
        {
            CreditoAnulado credAnul;

            DateTime dFechaCorte = DateTime.Now;
            DateTime dFechaAviso = DateTime.Now; 


            DialogResult res = MessageBox.Show("¿Dar alta?", "Alta de crédito", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (res == DialogResult.Cancel)
            {
                return;
            }

            int nRoCredito = 1;
            int nCuotas = 0;
            if (lblMor.Visible)
            {
                if (Mira_Cliente() == false)
                {
                    MessageBox.Show("ERROR al grabar el cliente", "Cliente P");
                    return;
                }
            }
            Credito regCredito;
            regCredito = bl.GetDal(BaseID).context.Creditos.Where(c => c.EmpresaID == BaseID
                    && c.ComercioID == ComID).OrderByDescending(o => o.CreditoID).FirstOrDefault();
            //regCredito = bl.Get<Credito>(BaseID,c => c.EmpresaID == BaseID
            //        && c.ComercioID == ComID).OrderByDescending(o => o.CreditoID).FirstOrDefault();

            if (regCredito != null)
            {
                nRoCredito = regCredito.CreditoID + 1;
            }
            else
            {
                nRoCredito = bl.pGlob.Configuracion.NumCredInicial;
            }

            credAnul = bl.Get<CreditoAnulado>(BaseID,c => c.EmpresaID == BaseID && c.ComercioID == ComID,
                                              o => o.OrderByDescending(ca => ca.CreditoID), "", 1).FirstOrDefault();

            if (credAnul != null)
            {
                if (credAnul.CreditoID >= nRoCredito)
                    nRoCredito = credAnul.CreditoID + 1;
            }

            regCredito = new Credito();
            regCredito.EmpresaID = BaseID; //  bl.pGlob.Comercio.EmpresaID;//cambio
            regCredito.ComercioID = ComID;
            regCredito.CreditoID = nRoCredito;
            regCredito.Documento = nDocumento;// System.Convert.ToInt32(lblCliDocuFrm.Text);
            regCredito.TipoDocumentoID = lblCliCodDocuFrm.Text;

            regCredito.ValorNominal = Convert.ToDecimal(txtPlanVN.Text);
            regCredito.ValorCuota = Convert.ToDecimal(lblPlanValorCuotas.Text);
            regCredito.FechaSolicitud = DateTime.Now;

            regCredito.Interes = Convert.ToDecimal(lblPlanInteresImp.Text);
            regCredito.Gasto = Convert.ToDecimal(lblPlanGastoImp.Text);
            regCredito.Comision = Convert.ToDecimal(lblPlanComisionImp.Text);

            regCredito.Cancelado = false;

            if (Convert.ToInt32(txtGarDocu.Text) > 0)
            {
                regCredito.Garante1 = Convert.ToInt32(txtGarDocu.Text);
                regCredito.TipoDocumentoIDG1 = cmbGarDoc.Text;
            }
            if (Convert.ToInt32(txtAdiDocu.Text) > 0)
            {
                regCredito.Adicional = Convert.ToInt32(txtAdiDocu.Text);
                regCredito.TipoDocumentoIDAdi = cmbAdiDoc.Text;
            }
            if (nIdUsuarioAvalo > 0) regCredito.usuarioAvalID = nIdUsuarioAvalo;
            if (lblPlanAvalado.Visible) regCredito.Avalado = true;
            regCredito.TipoCuotaID = lblPlanTipoAV.Text;
            regCredito.CantidadCuotas = Convert.ToInt16(lblPlanCuotas.Text);
            nCuotas = Convert.ToInt16(lblPlanCuotas.Text);
            regCredito.NroInformeContel = NroInforme;

            regCredito.UsuarioID = p.usu.UsuarioID;
            regCredito.PcComer = System.Environment.MachineName;
            regCredito.FechaComer = DateTime.Now;
            if (lblPlanBoniTipo.Text != "")
            {
                regCredito.TipoBonificacionID = lblPlanBoniTipo.Text;
                regCredito.PorcentajeBonificacion = Convert.ToDecimal(lblPlanBoniPorcen.Text);
                regCredito.ValorBonificacion = Convert.ToDecimal(lblPlanBoniValor.Text);    //edumal
            }

            regCredito.TasaPlan = Convert.ToDecimal(lblPlanTasa.Text);
            regCredito.IncrementoPlan = Convert.ToDecimal(lblPlanTasaIncr.Text);
            regCredito.GastoPlan = Convert.ToDecimal(lblPlanGastoInt.Text);
            regCredito.GastoIncrementoPlan = Convert.ToDecimal(lblPlanGastoIncr.Text);
            if (lblPlanGastoFijo.Text != "") regCredito.GastoFijo = true;// (lblPlanGastoFijo.Text);
            regCredito.ComisionPlan = Convert.ToDecimal(lblPlanComisionInt.Text);
            regCredito.ComisionIncrementoPlan = Convert.ToDecimal(lblPlanComisionIncr.Text);
            regCredito.TipoRetencionPlanID = lblPlanRetencion.Text; //  "N";  EDU202109
            regCredito.NombrePlan = lblPlanID.Text;
            regCredito.Puntaje = (decimal) nPuntaje;

            regCredito.DiasVenciPrimerCuota = Convert.ToInt16(lblPlanDiasVenci.Text);

            //regCredito.AvisoDePagoID = 0;
            regCredito.Corte = Convert.ToInt16(lblPlanCorte.Text);
            dFechaCorte = dFechaCorte.AddDays(Convert.ToDouble(lblPlanCorte.Text));
            regCredito.FechaAviso = dFechaCorte;

            if (cbc != null)
            {
                if (String.IsNullOrEmpty(txtCuit.Text) || txtCuit.Text == "0")
                {
                    MessageBox.Show("Debe ingresar un N° de CUIT Valido");
                    return;
                }
                else if (txtCuit.Text.Length > 15)
                {
                    MessageBox.Show("EL Nº de CUIT no puede superar 15 dígitos");
                    return;
                }
                regCredito.NumCuentaBancaria = cbc.NumCuentaBancaria;
                regCredito.FechaDesdeDebito = DateTime.Now;

                regCliente.Cuit = txtCuit.Text;
                bl.Actualizar<Cliente>(regCliente);
                bl.Transmision<Cliente>(regCliente, Com, bl.pGlob.TransAgregarCliente, bl.pGlob.UriClientes);
            }

            //ACA BEGIN
            //bl.Transmision<Cliente>(regCliente, Com, bl.pGlob.TransAgregarCliente, bl.pGlob.UriClientes);
            //bl.AgregarCredito(regCredito);
            bl.AgregarTransaccional<Credito>(BaseID, regCredito);

            //            bl.ImputarSolicitudFondoACuentaCorriente()

            int nDesde = 1;
            if (lblPlanTipoAV.Text == "A") nDesde = 2;
            DateTime FechVenci = Convert.ToDateTime(lblPlanPrimerVenci.Text);
            Cuota regCuota = new Cuota();
            for (int n = nDesde; n <= nCuotas; n++)
            {
                regCuota = new Cuota();
                regCuota.CuotaID = n;
                regCuota.EmpresaID = BaseID; // bl.pGlob.Comercio.EmpresaID;   //cambio
                regCuota.ComercioID = ComID;
                regCuota.CreditoID = nRoCredito;
                regCuota.Documento = nDocumento;// System.Convert.ToInt32(lblCliDocuFrm.Text);
                regCuota.TipoDocumentoID = lblCliCodDocuFrm.Text;
                regCuota.Importe = Convert.ToDecimal(lblPlanValorCuotas.Text);
                regCuota.Interes = Convert.ToDecimal(lblPlanInteresImp.Text) / nCuotas;
                regCuota.ImportePago = 0;
                regCuota.ImportePagoPunitorios = 0;
                regCuota.FechaVencimiento = FechVenci; // Convert.ToDateTime(lblPlanPrimerVenci.Text);
                regCuota.TipoCuotaID = lblPlanTipoAV.Text;
                regCuota.CantidadCuotas = Convert.ToInt16(lblPlanCuotas.Text);

                if (nBoniCant == 1)
                {
                    if (n == nCuotas) regCuota.ValorBonificacion = Convert.ToDecimal(lblPlanBoniValorXcuota.Text);
                }
                else if (nBoniCant > 1)
                {
                    if (n > nCuotas - nBoniCant) regCuota.ValorBonificacion = Convert.ToDecimal(lblPlanBoniValorXcuota.Text);
                }
                else
                {
                    regCuota.ValorBonificacion = 0;
                }

                bl.AgregarTransaccional<Cuota>(BaseID, regCuota);
                FechVenci = FechVenci.AddMonths(1);
            }

            //TipoAval  regAvales
            if (nIdUsuarioAvalo > 0)
            {
                List<TipoAval> regTipoAvalList = bl.Get<TipoAval>(BaseID).ToList();
                if (regTipoAvalList.Count == 0)
                {
                    //ACA mensaje de error o algo
                }

                if (bCamara) Graba_Avales("Cámara", nRoCredito, regTipoAvalList);
                if (bSueldo) Graba_Avales("Sueldo", nRoCredito, regTipoAvalList);
                //if (bDeuda) Graba_Avales("Sueldo", nRoCredito);

                if (bCambiaPlanes) Graba_Avales("Cambia plan", nRoCredito, regTipoAvalList); //eduardo cambio

                if (nDeudaAtras > 0) Graba_Avales("Crédito moroso", nRoCredito, regTipoAvalList);

                //if (nDeudaTot > nDeudaAtras) Graba_Avales("Crédito abierto", nRoCredito);
                if (nDeudaTot > nDeudaAtras) Graba_Avales("Crédito anterior", nRoCredito, regTipoAvalList);//eduardo cambio
            }

            //ACA END BEGIN
            txtNotasCred.Enabled = false;
            btnGrabaCredito.Enabled = false;
            btnDebitoDirecto.Enabled = false;
            //btnContinuar.Enabled = false;
            btnPlanes.Enabled = false;
            List<CuentaCorriente> ccs = new List<CuentaCorriente>();
            List<Transmision> lTrans = new List<Transmision>();
            CuentaCorriente cc;


            cc = bl.ImputarCreditoACuentaCorriente(BaseID, regCredito);
            ccs.Add(cc);
            if (regCredito.Gasto > 0)
            {
                if (lblPlanRetencion.Text == "G" || lblPlanRetencion.Text == "A") dFechaAviso = DateTime.Now; else dFechaAviso = dFechaCorte;
                cc = bl.ImputarGastoCreditoACuentaCorriente(BaseID, regCredito, dFechaAviso);
                ccs.Add(cc);
            }

            if (lblPlanTipoAV.Text == "A")
            {
                if (lblPlanRetencion.Text == "C" || lblPlanRetencion.Text == "A") dFechaAviso = DateTime.Now; else dFechaAviso = dFechaCorte;
                cc = bl.ImputarCuotaAdelantadaACuentaCorriente(BaseID, regCredito, dFechaAviso);
                ccs.Add(cc); 
            }

            if (regCredito.Comision > 0) 
            {
                cc = bl.ImputarComisionCreditoACuentaCorriente(BaseID, regCredito);
                ccs.Add(cc);
            }

            if (txtNotasCred != null && txtNotasCred.Text != String.Empty)
            {
                Nota NotaCred = new Nota();
                NotaCred.Fecha = DateTime.Now;
                NotaCred.EmpresaID = regCredito.EmpresaID;
                NotaCred.ComercioID = regCredito.ComercioID;
                NotaCred.Detalle = txtNotasCred.Text;
                NotaCred.UsuarioID = p.usu.UsuarioID;
                NotaCred.CreditoID = regCredito.CreditoID;
                bl.AgregarTransaccional<Nota>(BaseID, NotaCred);
            }

            bl.Grabar(BaseID);

            int? GrupoTransmision = null;
            GrupoTransmision = bl.Transmision<Credito>(regCredito, bl.GetComercio(BaseID), bl.pGlob.TransAltaCredito, bl.pGlob.UriCreditos, GrupoTransmision);
            foreach (CuentaCorriente item in ccs)
            {
                GrupoTransmision = bl.Transmision<CuentaCorriente>(item, bl.GetComercio(BaseID), bl.pGlob.TransImputacionCC, bl.pGlob.UriAltaCobranza, GrupoTransmision);
            }
            bl.Grabar(BaseID);

            //Impresión
            bl.ImprimirAlta(regCredito, lblMor.Visible);



            lblNroCredito.Text = nRoCredito.ToString("N0");
            MessageBox.Show("Crédito  " + nRoCredito.ToString() + "  Grabado", this.Text);
        }
        private int Graba_Avales(string qAvalo, int nCredAval, List<TipoAval> regTipoAvalList)
        {
            CreditoAval regCreditoAvalNvo;
            foreach (TipoAval ta in regTipoAvalList)
            {
                if (ta.Nombre == qAvalo)
                {
                    regCreditoAvalNvo = new CreditoAval();
                    regCreditoAvalNvo.EmpresaID = BaseID;
                    regCreditoAvalNvo.ComercioID = ComID; // bl.pGlob.Comercio.ComercioID;
                    regCreditoAvalNvo.CreditoID = nCredAval;
                    regCreditoAvalNvo.TipoAvalID = ta.TipoAvalID;
                    regCreditoAvalNvo.UsuarioID = nIdUsuarioAvalo;
                    bl.AgregarTransaccional<CreditoAval>(BaseID, regCreditoAvalNvo);
                    return 1;
                }
            }

            return 0;
        }
        private void btnDebitoDirecto_Click(object sender, EventArgs e)
        {
            frmCuentasBancariasCliente frmcbc = new frmCuentasBancariasCliente(this.p, this.bl, regCliente);
            frmcbc.ShowDialog();
            frmcbc.Close();
            if (frmcbc.cbcSel != null)
            {
                cbc = frmcbc.cbcSel;
                txtDebitoDir.Text = cbc.NumCuentaBancaria;
            }
                
        }

        private void btnEliminarCuenta_Click(object sender, EventArgs e)
        {
            cbc = null;
            txtDebitoDir.Text = "";
        }

        private void txtAdiDocu_Leave(object sender, EventArgs e)
        {
            Busca_Adicional();
        }

        private void btnAdi_Click(object sender, EventArgs e)
        {
            string cNM = "M";
            if (bEsNuevoAdi)
            {
                cNM = "N";
            }
            frmClienteNVO frm = new frmClienteNVO(this.p, cNM, nDocumentoAdi, cDocumentoAdi, lblMor.Visible);//edu202208
            frm.WindowState = FormWindowState.Normal;
            frm.ShowDialog();
            bl = new BusinessLayer();
            Busca_Adicional();
        }

        private void txtGarDocu_Leave(object sender, EventArgs e)
        {
            Busca_Garante();
        }

        private void btnGar_Click(object sender, EventArgs e)
        {
            string cNM = "M";
            if (bEsNuevoGar)
            {
                cNM = "N";
            }
            frmClienteNVO frm = new frmClienteNVO(this.p, cNM, nDocumentoGar, cDocumentoGar, lblMor.Visible);//edu202208
            frm.WindowState = FormWindowState.Normal;
            frm.ShowDialog();
            bl = new BusinessLayer();
            Busca_Garante();
        }

        private bool Mira_Cliente()
        {
            bool esNuevo = true;
            if (lblMor.Visible == false) return false;
            regCliente = bl.Get<Cliente>(1, c => c.Documento == nDocumento && c.TipoDocumentoID == cDocumento).FirstOrDefault();  //EDU2023
            RecargarEmpYComercio(true);
            Cliente regCliPru = bl.GetDal(99).Get<Cliente>( c => c.Documento == nDocumento && c.TipoDocumentoID == cDocumento).FirstOrDefault();
            if(regCliPru == null)
            {
                regCliPru = new Cliente();
                regCliPru.Documento = regCliente.Documento;
                regCliPru.TipoDocumentoID = regCliente.TipoDocumentoID;
            }
            else
            {
                esNuevo = false;
            }
            regCliPru.Puntaje = regCliente.Puntaje;
            regCliPru.EstadoID = regCliente.EstadoID;
            regCliPru.Sueldo = regCliente.Sueldo;
            regCliPru.Apellido = regCliente.Apellido;
            regCliPru.Nombre = regCliente.Nombre;
            regCliPru.SexoID = regCliente.SexoID;
            regCliPru.FechaNacimiento = regCliente.FechaNacimiento;
            regCliPru.FechaAlta = regCliente.FechaAlta;
            regCliPru.ProfesionID = regCliente.ProfesionID;
            regCliPru.TipoComoConocioID = regCliente.TipoComoConocioID;
            regCliPru.EmpresaLaboral = regCliente.EmpresaLaboral;
            regCliPru.Sueldo = regCliente.Sueldo;
            regCliPru.Legajo = regCliente.Legajo;
            if (esNuevo)
            {
                bl.Agregar(99, regCliPru);
            }else
            {
                bl.Actualizar(99, regCliPru);
                
            }
           
            ////////////////////////////////////////////////////////////////////////////DOMICILIO
            esNuevo = true;
            Domicilio RegDomLst = bl.GetDomicilios(c => c.Documento == nDocumento && c.TipoDocumentoID == cDocumento && c.ClaseDatoID == 1 && c.EstadoID == ParametrosGlobales.EstadoVigenteID, o=>o.OrderByDescending(oo=>oo.Fecha)).FirstOrDefault();
            if (RegDomLst != null)
            {
                Domicilio RegDomLstN = new Domicilio();
                RegDomLstN = bl.GetDal(99).Get<Domicilio>(c => c.Documento == nDocumento && c.TipoDocumentoID == cDocumento && c.ClaseDatoID == 1 && c.EstadoID == ParametrosGlobales.EstadoVigenteID, o => o.OrderByDescending(oo => oo.Fecha)).FirstOrDefault();
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
            }

            ////////////////////////////////////////////////////////////////////////////TELEFONO
            esNuevo = true;
            Telefono RegtelLst = bl.Get<Telefono>(c => c.Documento == nDocumento && c.TipoDocumentoID == cDocumento && c.ClaseDatoID == 1 && c.EstadoID == ParametrosGlobales.EstadoVigenteID, o => o.OrderByDescending(oo => oo.Fecha)).FirstOrDefault();
            if (RegtelLst != null)
            {
                Telefono regTelefono = new Telefono();
                regTelefono = bl.GetDal(99).Get<Telefono>(c => c.Documento == nDocumento && c.TipoDocumentoID == cDocumento && c.ClaseDatoID == 1 && c.EstadoID == ParametrosGlobales.EstadoVigenteID, o => o.OrderByDescending(oo => oo.Fecha)).FirstOrDefault();
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
            ////////////////////////////////////////////////////////////////////////////TELEFONO
            esNuevo = true;
            Mail RegMailLst = bl.Get<Mail>(c => c.Documento == nDocumento && c.TipoDocumentoID == cDocumento && c.ClaseDatoID == 1 && c.EstadoID == ParametrosGlobales.EstadoVigenteID, o => o.OrderByDescending(oo => oo.Fecha)).FirstOrDefault();
            if (RegMailLst != null)
            {
                Mail regMail;
                regMail = bl.GetDal(99).Get<Mail>(c => c.Documento == nDocumento && c.TipoDocumentoID == cDocumento && c.ClaseDatoID == 1 && c.EstadoID == ParametrosGlobales.EstadoVigenteID, o => o.OrderByDescending(oo => oo.Fecha)).FirstOrDefault();
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
            }
            bl.Transmision<Cliente>(regCliPru, Com, bl.pGlob.TransAgregarCliente, bl.pGlob.UriClientes);
            bl.Grabar(99);
            return true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        
        private void Mira_Pru()
        {
            if (bl.LlevaM() == false) return;
            if (lblMor.Visible) return;
            if(bl.LlevaMA() )
            {
                lblMor.Visible = Cuenta_pru();
            }
        }
        private bool Cuenta_pru()
        {
            lblPru01.Text = "0";
            lblPru02.Text = "0";
            if (bl.LlevaM() == false) return false;
            List<Credito> regCreditoList;
            DateTime fD;
            DateTime fH;
            fD = Convert.ToDateTime(1 + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
            fH = fD.AddMonths(1);
            fH = fH.AddDays(-1);
            int nComerMor = 0;
            decimal nValorNominalFinan = 0;
            decimal nValorNominalPru = 0;
            regCreditoList = bl.Get<Credito>(bl.pGlob.EmpresaID, c => c.FechaSolicitud >= fD && c.FechaSolicitud <= fH
                         && c.EmpresaID == bl.pGlob.Comercio.EmpresaID && c.ComercioID == bl.pGlob.Comercio.ComercioID,
                        or => or.OrderBy(o => o.FechaSolicitud)).ToList();
            foreach (Credito Cred in regCreditoList)
            {
                nValorNominalFinan = nValorNominalFinan + Cred.ValorNominal;
            }
            lblPru01.Text = nValorNominalFinan.ToString("N2");
            Comercio regComercioPru = bl.Get<Comercio>(bl.pGlob.EmpresaMID, c => c.Principal == true).FirstOrDefault();
            if (regComercioPru == null) return false;
            nComerMor = regComercioPru.ComercioID;

            regCreditoList = bl.Get<Credito>(bl.pGlob.EmpresaMID, c => c.FechaSolicitud >= fD && c.FechaSolicitud <= fH
                        && c.EmpresaID == bl.pGlob.EmpresaMID && c.ComercioID == nComerMor,
                        or => or.OrderBy(o => o.FechaSolicitud)).ToList();

            foreach (Credito Cred in regCreditoList)
            {
                nValorNominalPru = nValorNominalPru + Cred.ValorNominal;
            }
            lblPru02.Text = nValorNominalPru.ToString("N2");
            if (nValorNominalPru >= bl.pGlob.Configuracion.nLlevaMorMax) return false;
           
            decimal nPorcenFinan = 0;
            decimal nPorcenMor = 0;
            if (nValorNominalFinan + nValorNominalPru == 0)
            {
                nPorcenFinan = 0;
                nPorcenMor = 0;
            }
            else
            {
                nPorcenFinan = (nValorNominalFinan * 100) / (nValorNominalFinan + nValorNominalPru);
                nPorcenMor = 100 - nPorcenFinan;
            }


            if (nPorcenFinan > bl.pGlob.Configuracion.nLlevaMorPorcentFinan)
            {
                return true;
            }

            if (nPorcenFinan == 0)
            {
                return  false;
            }

            return true;
        }
    }


}
