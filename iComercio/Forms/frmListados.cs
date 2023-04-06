using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using iComercio.Models;
using DevExpress.XtraGrid.Columns;
using System.Linq.Expressions;
using iComercio.Auxiliar;

namespace iComercio.Forms
{
   

    public partial class frmListados : FRM
    {
        public frmListados(Principal p):base(p)
        {
            InitializeComponent();
            this.p = p;
        }

        public frmListados()
        {
            InitializeComponent();
        }

        // x=>x.fechaDesde > Fecha && x.fechaHasta < FechaHasta
        private void Filtros<T>() where T:class
        {
            //var lambda1 = Expression.Lambda<Func<MyEntity, bool>>(Expression.AndAlso(
            //    new SwapVisitor(e1.Parameters[0], e2.Parameters[0]).Visit(e1.Body),
            //    e2.Body), e2.Parameters);
            List<Filtro<T>> filtros = new List<Filtro<T>>();
            foreach (var filtro in filtros)
            {
                //if (filtro.Tipo is DateTime)                    
            }
        }

        //private Expression<Func<T, bool>> ArmarConsulta<T>(List<Filtro<T>> Filtros) where T : class
        //{
        //    Expression<Func<T, bool>> e;
        //    if (Filtros.Count == 1)
        //    {
        //        return Filtros[0].Condicion;
        //    }
        //}

        private List<GridColumn> CargarColumnas()
        {
            List<GridColumn> ColumnasAMostrar = new List<GridColumn>();

            GridColumn gc = new GridColumn();
            gc.FieldName = "CreditoID";
            gc.Visible = true;
            gc.Caption = "ID";
            ColumnasAMostrar.Add(gc);

            gc = new GridColumn();
            gc.FieldName = "ComercioID";
            gc.Visible = true;
            gc.Caption = "Comercio";
            ColumnasAMostrar.Add(gc);

            gc = new GridColumn();
            gc.FieldName = "Empresa";
            gc.Visible = true;
            gc.Caption = "Empresa";
            ColumnasAMostrar.Add(gc);

            gc = new GridColumn();
            gc.FieldName = "Documento";
            gc.Visible = true;
            gc.Caption = "Documento";
            ColumnasAMostrar.Add(gc);

            gc = new GridColumn();
            gc.FieldName = "TipoDocumentoID";
            gc.Visible = true;
            gc.Caption = "TipoDocumentoID";
            ColumnasAMostrar.Add(gc);

            gc = new GridColumn();
            gc.FieldName = "ValorNominal";
            gc.Visible = true;
            gc.Caption = "ValorNominal";
            ColumnasAMostrar.Add(gc);

            gc = new GridColumn();
            gc.FieldName = "ValorCuota";
            gc.Visible = true;
            gc.Caption = "ValorCuota";
            ColumnasAMostrar.Add(gc);

            gc = new GridColumn();
            gc.FieldName = "FechaSolicitud";
            gc.Visible = true;
            gc.Caption = "FechaSolicitud";
            ColumnasAMostrar.Add(gc);

            return ColumnasAMostrar;
        }
       
        private void frmListados_Load(object sender, EventArgs e)
        {
            OrdenarLabels();
            List<Credito> lCred = bl.Get<Credito>(null,null,"",20).ToList();
            List<GridColumn> ColumnasAMostrar = CargarColumnas();     
            CargarListado<Credito>(lCred, ColumnasAMostrar);
        }

        private void CargarListado<T>(List<T> Lista, List<GridColumn> ColumnasAMostrar) where T : class
        {
            GridLis.DataSource = Lista;
            GridLis.ShowOnlyPredefinedDetails = true;
            GridView vw = (GridView)GridLis.MainView;
            vw.Columns.Clear();
            foreach (var gc in ColumnasAMostrar)
            {
                vw.Columns.Add(gc);
            }
        }


        private void OrdenarLabels()//Prueba
        {
            List<string> labels=new List<string>();
            labels.Add("If");
            labels.Add("variable");
            labels.Add("=");
            labels.Add("5");
            for (int i = 0; i < labels.Count; i++)
            {
                Label lbl = new Label();
                lbl.Text = labels[i];
                flowLayoutPanel1.Controls.Add(lbl);
            }
        }


        public class Filtro<T> where T : class
        {
            public string Campo { get; set; }
            public Type Tipo { get; set; }
            public Expression<Func<T, bool>> Condicion { get; set; }
        }
    }
}
