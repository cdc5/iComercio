using System;
using System.Linq;
using System.Windows.Forms;
using iComercio.Models;
using Credin;
using System.Collections.Generic;
using iComercio.Rest;                               

//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
//using System.Data.Entity;
//using iComercio.DAL;

//using iComercio.Delegados;
//using iComercio.ViewModels;
//using iComercio.Auxiliar;
//using System.Globalization;

namespace iComercio.Forms
{
    public partial class FrmNotasCliCred : FRM                                                         //**edu**
    {
        //**EDU MOR**//
        bool bEsPru = false;
        //**EDU MOR**//


        //private RestApi ra;                         //Pa' que lo quiero???
        string dondeVengo = "";
        public bool grabo = false;

        public FrmNotasCliCred()
        {
            InitializeComponent();
        }

        private void FrmNotasCliCred_Load(object sender, EventArgs e)
        {
            txtCliNota.Focus();
        }
        public FrmNotasCliCred(Principal p, RestApi ra)
            : base(p, ra)
        {                                               // 1°
            InitializeComponent();
            Limpia();
        }
        public FrmNotasCliCred (Principal p, BusinessLayer bl, int ComerExt, int CredExt, int Cuot, int Docu,string Nomb,  string CodDocu, string deDondeVengo,  bool bPru )
            : base(p)
        {
            InitializeComponent();

            this.bl = bl;
            RecargarEmpYComercio(bPru);
            Limpia();
            Configura_Controles();
            lblNotaCom.Text = ComerExt.ToString();
            lblNotaCred.Text = CredExt.ToString();
            //lblNotaCuo.Text = Cuot.ToString();
            lblNotaDocu.Text = Docu.ToString();
            lblNotaCodDocu.Text = CodDocu.ToString();
            lblNotaNomb.Text = Nomb.ToString();
            dondeVengo = deDondeVengo;
            label3.Top = label1.Top;
            lblNotaNomb.Top = label3.Top;
            lblNotaDocu.Top = label3.Top;
            lblNotaCodDocu.Top = label3.Top;
            if (dondeVengo == "CREDITO")
            {
                label3.Visible=false;
                lblNotaNomb.Visible=false;
                lblNotaDocu.Visible=false;
                lblNotaCodDocu.Visible = false;
            }
            else if (dondeVengo == "DOCUMENTO")
            {
                label1.Visible = false;
                lblNotaCom.Visible=false;
                lbl.Visible = false;
                lblNotaCred.Visible = false;
            }

            bEsPru = bPru; //11

            txtCliNota.Focus();


        }
        private void Configura_Controles()
        {
            Configura_Colores(bl.pGlob.Comercio.EmpresaID);
            Recorre_Formulario(this);
         //this.Opacity=0.5;
            panel1.BackColor = ColorBackColorFrm;
            this.BackColor = ColorTransparente; // ColorBackColorFrm;
            this.TransparencyKey = ColorTransparente; // ColorBackColorFrm;
           
             //  this.BackColor = ColorBackColorFrm;
        }
        private int Graba_Nota()
        {

            if (txtCliNota.Text == "") return 0;

            Nota notNVA = new Nota();
            //Nota notNVA2 = new Nota();
            //notNVA.NotaID = nID;
            notNVA.EmpresaID = BaseID;
            notNVA.ComercioID = Convert.ToInt16(lblNotaCom.Text);
            
            if(dondeVengo =="CREDITO")
            {
                notNVA.CreditoID = Convert.ToInt32(lblNotaCred.Text);
            }
            else if (dondeVengo == "DOCUMENTO")
            {
                notNVA.Documento = Convert.ToInt32(lblNotaDocu.Text);
                notNVA.TipoDocumentoID = lblNotaCodDocu.Text;
            }
            notNVA.Detalle = txtCliNota.Text;
            notNVA.UsuarioID = p.usu.UsuarioID;
            notNVA.Fecha = DateTime.Now;
            bl.Agregar<Nota>(BaseID, notNVA);   
       

               
            

            ////**EDU MOR**//
            //if (bEsPru)
            //{
            //    bl = new BusinessLayer();
            //    if (Busca_Cliente_Pru(Convert.ToInt32(lblNotaDocu.Text), lblNotaCodDocu.Text))
            //    {
            //        bl.Desacoplar<Nota>(BaseID, notNVA);
            //        notNVA.ComercioID = Busca_Comercio_Prueba(); 
            //        notNVA.NotaID = null;
            //        if (dondeVengo == "DOCUMENTO") bl.Agregar<Nota>(bl.pGlob.EmpresaMID, notNVA);
            //        if (dondeVengo == "CREDITO")
            //        {
            //            if (Busca_Credito_Pru(Convert.ToInt32(notNVA.ComercioID), Convert.ToInt32(lblNotaCred.Text)))
            //            {
            //                bl.Agregar<Nota>(bl.pGlob.EmpresaMID, notNVA);
            //            }
            //        }


            //        //bl.dalPrueba.AgregarNota(notNVA);
            //    }
            //}
            return notNVA.NotaID.Value;
        }

        private bool Busca_Credito_Pru(int nComer, int nCred)
        {

            Credito RegCredito = bl.dalPrueba.Get<Credito>(c => c.ComercioID == nComer && c.CreditoID == nCred).FirstOrDefault();
            if (RegCredito != null) return true;
            return false;
        }

        private bool Busca_Cliente_Pru(int nDoc, string cDoc)   //REPITE
        {
            Cliente regBuscaClientePru = bl.dalPrueba.Get<Cliente>(c => c.Documento == nDoc && c.TipoDocumentoID == cDoc).FirstOrDefault();
            if (regBuscaClientePru != null) return true;
            return false;
        }

        private int Busca_Comercio_Prueba()     //11
        {
            int nComer = 0;
            Comercio regComercioPru = null;
            regComercioPru = bl.dalPrueba.Get<Comercio>().FirstOrDefault();
            if (regComercioPru != null)
            {
                nComer = regComercioPru.ComercioID;
            }
            return nComer;
        }

        private void Limpia()
        {
            lblNotaCom.Text = "0";
            lblNotaCred.Text = "0";
            //lblNotaCuo.Text = "0";
            lblNotaDocu.Text = "0";
            lblNotaCodDocu.Text = "";
            lblNotaNomb.Text = "";
            txtCliNota.Text = "";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (txtCliNota.Text != "")
            { CerrarConMensajeDeAdvertencia(); }
            else { this.Close(); }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if(Graba_Nota() > 0)
            {
                grabo = true;
                this.Close();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
