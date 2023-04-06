using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iComercio.Rest;                    
using iComercio.Models;                  
using iComercio.DAL;
using iComercio.ViewModels;          
using Credin;
using DevExpress.XtraGrid.Views.Grid;
using AutoMapper;

namespace iComercio.Forms
{
    public partial class frmReimpresiones : FRM
    {
        int? dni;
        int? cred;
        Credito credito;
        Cobranza cobranza;

        public frmReimpresiones()
        {
            InitializeComponent();
            
        }

        public frmReimpresiones(Principal p): base(p)
        {
            InitializeComponent();
            Configura_Controles();
        }

        private void Configura_Controles()
        {
            Configura_Colores(bl.pGlob.Comercio.EmpresaID);
            Recorre_Formulario(this);
            this.BackColor = ColorBackColorFrm;
        }

        private void frmReimpresiones_Load(object sender, EventArgs e)
        {
            lblMor.Visible = false;
            RecargarEmpYComercio(false);
            BuscarCreditos(null, null);
        }

        private void BuscarCreditos(int? dni,int? cred)
        {
            int BaseID = bl.GetEmpresa(lblMor.Visible).EmpresaID.Value;
            List<Credito> listCred = null;
            if (dni != null && cred != null)
                listCred = bl.Get<Credito>(BaseID,c => c.Documento == dni && c.CreditoID == cred, x => x.OrderByDescending(c => c.FechaSolicitud),"Cliente").ToList();
            else if (dni != null)
                listCred = bl.Get<Credito>(BaseID,c => c.Documento == dni, x => x.OrderByDescending(c => c.FechaSolicitud)).ToList();
            else if (cred != null)
                listCred = bl.Get<Credito>(BaseID,c => c.CreditoID == cred, x => x.OrderByDescending(c => c.FechaSolicitud)).ToList();
            else
                listCred = bl.Get<Credito>(BaseID, null, x => x.OrderByDescending(c => c.FechaSolicitud), "", 20).ToList();
            gridCreds.DataSource = listCred;
        }

        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
                     
        }

        private void txtCredito_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void txtDni_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDni.Text))
            {
                dni = System.Convert.ToInt32(txtDni.Text);
                BuscarCreditos(dni, cred);
            }
        }

        private void txtCredito_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCredito.Text))
            {
                cred = System.Convert.ToInt32(txtCredito.Text);
                BuscarCreditos(dni, cred);
            }
            
        }

        private void gridCreds_DoubleClick(object sender, EventArgs e)
        {
            ////GridView childView1 = gridView1.GetDetailView(masterRH, 0) as GridView;
            //GridView View = gridCreds.FocusedView as GridView;
            //int rHandle = View.FocusedRowHandle;
            //if (View.Name == "ViewCred")
            //{
            //    credito = (Credito)View.GetRow(rHandle);
            //    bl.ImprimirAlta(credito);
            //}
            //else if (View.Name == "ViewCobranza")
            //{
            //    cobranza = (Cobranza)View.GetRow(rHandle);
            //    bl.ImprimirCobranza(cobranza);
            //}
            
        }

        private void gridCreds_Click(object sender, EventArgs e)
        {

        }

        private void ViewCred_DoubleClick(object sender, EventArgs e)
        {
            GridView View = sender as GridView;
            int rHandle = View.FocusedRowHandle;
            credito = (Credito)View.GetRow(rHandle);
            bl.ImprimirAlta(credito,lblMor.Visible);
        }

        private void ViewCobranza_DoubleClick(object sender, EventArgs e)
        {
            GridView View = sender as GridView;
            int rHandle = View.FocusedRowHandle;
            cobranza = (Cobranza)View.GetRow(rHandle);
            bl.ImprimirCobranza(cobranza,lblMor.Visible);
        }

        private void frmReimpresiones_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                if (e.Shift)
                {
                    if (bl.LlevaM())
                    {
                        lblMor.Visible = !lblMor.Visible;

                    }
                }
            }
        }
            
    }
}
