using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iComercio.Rest;
using iComercio.Rest.RestModels;
using iComercio.Models;
using iComercio.Delegados;
using iComercio.ViewModels;
using iComercio.Auxiliar;
namespace iComercio.Forms
{
    public partial class frmConceptoDeGasto : FRM
    {
        private RestApi ra;
        private ConceptoGastos congst = new ConceptoGastos();
        private ConceptoGastos congstBorra = new ConceptoGastos();
        private int? nCod;
        private int? nCod2;
        private string cNombre;
        private string cNombre2;
        private string cDecrip2;
        private string cDecrip1;
        private bool bActualiza;
        private bool bNivelFinal;
        
        
        public frmConceptoDeGasto()
        {
            InitializeComponent();
        }
        public frmConceptoDeGasto(Principal p, BusinessLayer bl)
            : base(p)
        {
            InitializeComponent();
            this.ra = bl.ra;
            this.bl = bl;
            ConceptoGastosBindingSource.DataSource = congst;
            
        }
        public frmConceptoDeGasto(Principal p, BusinessLayer bl, ConceptoGastos congst)
            : base(p, bl.ra)
        {
            InitializeComponent();
            this.ra = bl.ra;
            this.congst = congst;
            this.bl = bl;
            this.bActualiza = true;
            ConceptoGastosBindingSource.DataSource = congst;
        }

        private void frmConceptoDeGasto_Load(object sender, EventArgs e)
        {
            ActualizaGrid(true,true);
            LedoyFormaAlGrid(dgvGastos1,1);
            LedoyFormaAlGrid(dgvGastos2,2);
            cmbBusca.Items.Add("   Nombre");
            cmbBusca.Items.Add("  Descripción");
            cmbBusca.SelectedIndex = 0;
            cmbBusca.Font = new Font("Tahoma", 10, FontStyle.Bold);
            txtBusca.Font = new Font("Tahoma", 10, FontStyle.Bold);

            // .DataSource =bl.GetProveedores(pro => pro.RazonSocial.ToLower().Contains(txtNombreProv.Text.ToLower()));
        }
        private void ActualizaGrid(bool Grid1, bool Grid2)
        {
            if (Grid1)
            {
                dgvGastos1.DataSource = null;
                dgvGastos1.DataSource = bl.GetConceptoGastosLogico(gst => gst.Nivel == 1);
            }
            if (Grid2)
            {
                dgvGastos2.DataSource = null;
                dgvGastos2.DataSource = bl.GetConceptoGastosLogico(gst => gst.ConceptoGastoPadreID == nCod);
            }
        }


        private void LedoyFormaAlGrid(DataGridView datagrid1, int? qGrid)
        {

            datagrid1.AutoGenerateColumns = false;
            datagrid1.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 10, FontStyle.Bold);
            datagrid1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            datagrid1.ColumnHeadersHeight = 40;
            datagrid1.RowHeadersWidth = 30;

            datagrid1.RowsDefaultCellStyle.BackColor = Color.LightSteelBlue;
            datagrid1.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            datagrid1.RowsDefaultCellStyle.SelectionBackColor = Color.Blue;

            datagrid1.BorderStyle = BorderStyle.Fixed3D;
            datagrid1.AllowUserToAddRows = false;
            datagrid1.AllowUserToDeleteRows = false;
            datagrid1.AllowUserToOrderColumns = true;
            datagrid1.ReadOnly = true;
            datagrid1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            datagrid1.MultiSelect = false;

            datagrid1.Columns[0].Width = 50;
            datagrid1.Columns[1].Width = 170;
            datagrid1.Columns[2].Width = 170;


            if (qGrid == 1)
            {

                //datagrid1.Columns[3].Width = 0;
                //datagrid1.Columns[4].Width = 0;
                //datagrid1.Columns[5].Width = 0;
                //datagrid1.Columns[6].Width = 0;
                //datagrid1.Columns[3].Visible = false;
                //datagrid1.Columns[4].Visible = false;
                //datagrid1.Columns[5].Visible = false;
                //datagrid1.Columns[6].Visible = false;
            }
            else
            {
                datagrid1.Columns[3].Width = 0;
                datagrid1.Columns[4].Width = 0;
                datagrid1.Columns[5].Width = 0;
                datagrid1.Columns[6].Width = 0;
                datagrid1.Columns[3].Visible = false;
                datagrid1.Columns[4].Visible = false;
                datagrid1.Columns[5].Visible = false;
                datagrid1.Columns[6].Visible = false;
            }


            datagrid1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            datagrid1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            datagrid1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //datagrid1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //datagrid1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

           // datagrid1.Columns[3].Width = 170;
            // datagrid1.Columns[5].Width = 200;

            datagrid1.RowsDefaultCellStyle.Font = new Font("Tahoma", 9);
        }

        private void btnNvoGst_Click(object sender, EventArgs e)
        {
            bActualiza = false;
            panel1.Height = panel1.Height - 100; // 188;
            pnlNvoGst.Left = panel1.Left;
            pnlNvoGst.Top = panel1.Top + panel1.Height;
            chkNivelFinal.Enabled = true;
            MuestraPanel(true);
        }

        private void btnGrabaGst_Click(object sender, EventArgs e)
        {
            if (!bActualiza)
            {
                ConceptoGastos congst = new ConceptoGastos();
                congst.Nombre = txtNombre.Text;
                congst.Descripcion = txtDescrip.Text;
                congst.EstadoID = bl.pGlob.ConceptoGastoInicial.EstadoID;
               
                if (pnlNvoGst.Left == panel1.Left)
                {
                    congst.Nivel = 1;
                    congst.NivelFinal = chkNivelFinal.Checked;
                    
                    bl.AgregaConceptoGastos(congst);
                    bl.TransmisionAgregarConceptoGastos(congst,bl.pGlob.Comercio);
                    ActualizaGrid(true,true);
                }
                else
                {
                    congst.Nivel = 2;
                    congst.ConceptoGastoPadreID = nCod;
                    congst.NivelFinal = true;
                    bl.AgregaConceptoGastos(congst);
                    bl.TransmisionAgregarConceptoGastos(congst, bl.pGlob.Comercio);
                    ActualizaGrid(false,true);
                }
                
                MuestraPanel(false);
            } else {
                congst.Nombre = txtNombre.Text;
                congst.Descripcion = txtDescrip.Text;
                congst.NivelFinal = chkNivelFinal.Checked;
                bl.ActualizarConceptoGasto(congst);
                bl.TransmisionActualizarConceptoGastos(congst,bl.pGlob.Comercio);
                if (pnlNvoGst.Left == panel1.Left)
                {
                    ActualizaGrid(true, true);
                }
                else 
                {
                    ActualizaGrid(false, true);
                }
                MuestraPanel(false);
            }

        }
        private void MuestraPanel(bool bMuestro)
        {
            if (bMuestro)
            {
                
                panel1.Enabled = false;
                panel2.Enabled = false; 
                panel3.Enabled = false;
                //dgvGastos1.Enabled = false;
                //dgvGastos2.Enabled = false;
                //ConceptoGastosBindingSource.Clear();
                //ConceptoGastosBindingSource.EndEdit();
                
                //txtNombre.DataBindings.Clear();
                //txtNombre.DataBindings.Add("Text",this.ConceptoGastosBindingSource,"Nombre");
                //txtDescrip.DataBindings.Clear();
                //txtDescrip.DataBindings.Add("Text", this.ConceptoGastosBindingSource, "Descripcion");
                txtNombre.Text = "";
                txtDescrip.Text = "";
                pnlNvoGst.Visible =true ;
            }
            else
            {
                //panel1.Height = panel1.Height + 100;// 299;
                //panel2.Height = panel2.Height + 100;// 299;

                panel1.Height = this.Height  - panel4.Height - 110;
                panel2.Height = this.Height - panel4.Height - 110;
                panel1.Enabled = true;
                panel2.Enabled = true;
                panel3.Enabled = true;
                pnlNvoGst.Visible = false;
                //dgvGastos1.Enabled = true;
                //dgvGastos2.Enabled = true;
            }
        }

        private void btnCancelGst_Click(object sender, EventArgs e)
        {
            MuestraPanel(false);
        }

        private void btnNvoGstSub_Click(object sender, EventArgs e)
        {
            bActualiza = false;
            panel2.Height = panel2.Height - 100;// 188;
            pnlNvoGst.Left = panel2.Left;
            pnlNvoGst.Top = panel2.Top + panel2.Height;
            chkNivelFinal.Enabled = false;
            MuestraPanel(true);
            //txtNombre.Text = "";
            //txtDescrip.Text = "";
            //dgvGastos1.Enabled = false;
            //dgvGastos2.Enabled = false;
            //pnlNvoGst.Visible = true;
        }

     
        private void dgvGastos1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int? ViejoCod;
            ViejoCod = nCod;

            nCod = 0;
            if (e.RowIndex > -1)
            {
                nCod = Convert.ToInt32(dgvGastos1.Rows[e.RowIndex].Cells[0].Value);
                cNombre=Convert.ToString(dgvGastos1.Rows[e.RowIndex].Cells[1].Value);
                cDecrip1 = Convert.ToString(dgvGastos1.Rows[e.RowIndex].Cells[1].Value);
                if (ViejoCod != nCod)
                {
                    dgvGastos2.DataSource = bl.GetConceptoGastosLogico(gst => gst.ConceptoGastoPadreID == nCod);
                }
                congst = (ConceptoGastos)dgvGastos1.Rows[e.RowIndex].DataBoundItem;
               

            }    
            lblCod.Text = Convert.ToString(nCod);
        }


        private void dgvGastos2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            nCod2 = 0;
            if (e.RowIndex > -1)
            {
                nCod2 = Convert.ToInt32(dgvGastos2.Rows[e.RowIndex].Cells[0].Value);
                cNombre2 = Convert.ToString(dgvGastos2.Rows[e.RowIndex].Cells[1].Value);
                cDecrip2 = Convert.ToString(dgvGastos2.Rows[e.RowIndex].Cells[2].Value);
                congst = (ConceptoGastos)dgvGastos2.Rows[e.RowIndex].DataBoundItem;
                chkNivelFinal.Checked = congst.NivelFinal;
             }

        }

        private void txtBusca_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtBusca.Text))
            {
                ActualizaGrid(true,true);
            }
            else
            {
                SeleccionoCmb();
            }
        }

        private void SeleccionoCmb()
        {
            if (cmbBusca.Text == "   Nombre")
            {
                dgvGastos1.DataSource = bl.GetConceptoGastosLogico(pro => pro.Nombre.ToLower().Contains(txtBusca.Text.ToLower()) && pro.Nivel==1);
            }
            else
            {
                dgvGastos1.DataSource = bl.GetConceptoGastosLogico(pro => pro.Descripcion.ToLower().Contains(txtBusca.Text.ToLower()) && pro.Nivel == 1);
            }
            dgvGastos2.DataSource = bl.GetConceptoGastosLogico(gst => gst.ConceptoGastoPadreID == nCod);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbBusca_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtBusca.Text))
            {
                //  ActualizarListado();
            }
            else
            {
                SeleccionoCmb();
            }

        }

        private void btnEliminar2_Click(object sender, EventArgs e)
        {
            if (nCod2 != 0)
            {
                if (Alertas.AlertaDeEliminacion(cNombre2 + Environment.NewLine + "se eliminará"))
                {
                    var congstBorr = bl.GetConceptoGastos(c => c.ConceptoGastosID == nCod2).SingleOrDefault();
                    bl.BorrarConceptoGastoLogico(congstBorr);                    
                    bl.TransmisionEliminarConceptoGastos(congstBorr, bl.pGlob.Comercio);
                    dgvGastos2.DataSource = bl.GetConceptoGastos(gst => gst.ConceptoGastoPadreID == nCod);
                    ActualizaGrid(false, true);
                }
            }
        }
        private void btnElimina_Click(object sender, EventArgs e)
        {
            ConceptoGastos congstBorr = null;
            if (nCod != 0)
            {

                if (Alertas.AlertaDeEliminacion(cNombre + "  se eliminará" + Environment.NewLine +  Environment.NewLine + "Esto eliminará las sub-categorias"))
                {
                    if (dgvGastos2.RowCount > 0)
                    {
                        for (int i = 0; i < Convert.ToInt32(dgvGastos2.RowCount); i++)
                        {
                            nCod2 =Convert.ToInt32( (dgvGastos2.Rows[i].Cells[0].Value));
                            congstBorr = bl.GetConceptoGastos(c => c.ConceptoGastosID == nCod2).SingleOrDefault();
                            bl.BorrarConceptoGastoLogico(congstBorr);
                            bl.TransmisionEliminarConceptoGastos(congstBorr, bl.pGlob.Comercio);
                        }
                    }
                    congstBorr = bl.GetConceptoGastos(c => c.ConceptoGastosID == nCod).SingleOrDefault();
                    bl.BorrarConceptoGastoLogico(congstBorr);
                    bl.TransmisionEliminarConceptoGastos(congstBorr, bl.pGlob.Comercio);
                    ActualizaGrid(true,true);
                }
            }
        }

       

        private void btnModi2_Click(object sender, EventArgs e)
        {
            if (nCod2 != 0)
            {
                bActualiza = true;
                panel2.Height = panel2.Height - 100;// 188;
                pnlNvoGst.Left = panel2.Left;
                pnlNvoGst.Top = panel2.Top + panel2.Height;
                MuestraPanel(true);
                txtNombre.Text = cNombre2;
                txtDescrip.Text = cDecrip2;
                chkNivelFinal.Enabled = false;
                chkNivelFinal.Checked = congst.NivelFinal;
                congst.Nivel = 2;
                congst.ConceptoGastoPadreID = nCod;
                congst.ConceptoGastosID = nCod2;
            }
        }

        private void btnModi_Click(object sender, EventArgs e)
        {
            if (nCod != 0)
            {
                bActualiza = true;
                panel1.Height = panel1.Height - 100;// 188;
                pnlNvoGst.Left = panel1.Left;
                pnlNvoGst.Top = panel1.Top + panel1.Height;
                MuestraPanel(true);
                txtNombre.Text = cNombre;
                txtDescrip.Text = cDecrip1;
                chkNivelFinal.Checked = congst.NivelFinal;
                congst.Nivel = 1;
                congst.ConceptoGastosID = nCod;
            }
        }

        private void chkNivelFinal_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dgvGastos1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    
    }
}
