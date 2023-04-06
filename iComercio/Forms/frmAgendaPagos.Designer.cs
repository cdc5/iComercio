namespace iComercio.Forms
{
    partial class frmAgendaPagos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAgendaPagos));
            this.grp = new DevExpress.XtraEditors.GroupControl();
            this.grv = new DevExpress.XtraGrid.GridControl();
            this.pagoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEmpresaID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmpresa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colComercioID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colComercio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPagoID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSolicitudFondoID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSolicitudFondo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCapID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCapDetalleID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCapDetalle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFFID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFFDetalleID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFFDetalle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporte = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grp)).BeginInit();
            this.grp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pagoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // grp
            // 
            this.grp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grp.Controls.Add(this.grv);
            this.grp.Location = new System.Drawing.Point(13, 13);
            this.grp.Name = "grp";
            this.grp.Size = new System.Drawing.Size(1035, 441);
            this.grp.TabIndex = 0;
            this.grp.Text = "Pagos";
            // 
            // grv
            // 
            this.grv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grv.Cursor = System.Windows.Forms.Cursors.Default;
            this.grv.DataSource = this.pagoBindingSource;
            this.grv.Location = new System.Drawing.Point(11, 25);
            this.grv.MainView = this.gridView1;
            this.grv.Name = "grv";
            this.grv.Size = new System.Drawing.Size(1019, 411);
            this.grv.TabIndex = 0;
            this.grv.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // pagoBindingSource
            // 
            this.pagoBindingSource.DataSource = typeof(iComercio.Models.Pago);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colEmpresaID,
            this.colEmpresa,
            this.colComercioID,
            this.colComercio,
            this.colPagoID,
            this.colSolicitudFondoID,
            this.colSolicitudFondo,
            this.colCapID,
            this.colCapDetalleID,
            this.colCapDetalle,
            this.colFFID,
            this.colFFDetalleID,
            this.colFFDetalle,
            this.colFecha,
            this.colImporte});
            this.gridView1.GridControl = this.grv;
            this.gridView1.Name = "gridView1";
            // 
            // colEmpresaID
            // 
            this.colEmpresaID.FieldName = "EmpresaID";
            this.colEmpresaID.Name = "colEmpresaID";
            this.colEmpresaID.Visible = true;
            this.colEmpresaID.VisibleIndex = 0;
            // 
            // colEmpresa
            // 
            this.colEmpresa.FieldName = "Empresa";
            this.colEmpresa.Name = "colEmpresa";
            this.colEmpresa.Visible = true;
            this.colEmpresa.VisibleIndex = 1;
            // 
            // colComercioID
            // 
            this.colComercioID.FieldName = "ComercioID";
            this.colComercioID.Name = "colComercioID";
            this.colComercioID.Visible = true;
            this.colComercioID.VisibleIndex = 2;
            // 
            // colComercio
            // 
            this.colComercio.FieldName = "Comercio";
            this.colComercio.Name = "colComercio";
            this.colComercio.Visible = true;
            this.colComercio.VisibleIndex = 3;
            // 
            // colPagoID
            // 
            this.colPagoID.FieldName = "PagoID";
            this.colPagoID.Name = "colPagoID";
            this.colPagoID.Visible = true;
            this.colPagoID.VisibleIndex = 4;
            // 
            // colSolicitudFondoID
            // 
            this.colSolicitudFondoID.FieldName = "SolicitudFondoID";
            this.colSolicitudFondoID.Name = "colSolicitudFondoID";
            this.colSolicitudFondoID.Visible = true;
            this.colSolicitudFondoID.VisibleIndex = 5;
            // 
            // colSolicitudFondo
            // 
            this.colSolicitudFondo.FieldName = "SolicitudFondo";
            this.colSolicitudFondo.Name = "colSolicitudFondo";
            this.colSolicitudFondo.Visible = true;
            this.colSolicitudFondo.VisibleIndex = 6;
            // 
            // colCapID
            // 
            this.colCapID.FieldName = "CapID";
            this.colCapID.Name = "colCapID";
            this.colCapID.Visible = true;
            this.colCapID.VisibleIndex = 7;
            // 
            // colCapDetalleID
            // 
            this.colCapDetalleID.FieldName = "CapDetalleID";
            this.colCapDetalleID.Name = "colCapDetalleID";
            this.colCapDetalleID.Visible = true;
            this.colCapDetalleID.VisibleIndex = 8;
            // 
            // colCapDetalle
            // 
            this.colCapDetalle.FieldName = "CapDetalle";
            this.colCapDetalle.Name = "colCapDetalle";
            this.colCapDetalle.Visible = true;
            this.colCapDetalle.VisibleIndex = 9;
            // 
            // colFFID
            // 
            this.colFFID.FieldName = "FFID";
            this.colFFID.Name = "colFFID";
            this.colFFID.Visible = true;
            this.colFFID.VisibleIndex = 10;
            // 
            // colFFDetalleID
            // 
            this.colFFDetalleID.FieldName = "FFDetalleID";
            this.colFFDetalleID.Name = "colFFDetalleID";
            this.colFFDetalleID.Visible = true;
            this.colFFDetalleID.VisibleIndex = 11;
            // 
            // colFFDetalle
            // 
            this.colFFDetalle.FieldName = "FFDetalle";
            this.colFFDetalle.Name = "colFFDetalle";
            this.colFFDetalle.Visible = true;
            this.colFFDetalle.VisibleIndex = 12;
            // 
            // colFecha
            // 
            this.colFecha.FieldName = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.Visible = true;
            this.colFecha.VisibleIndex = 13;
            // 
            // colImporte
            // 
            this.colImporte.FieldName = "Importe";
            this.colImporte.Name = "colImporte";
            this.colImporte.Visible = true;
            this.colImporte.VisibleIndex = 14;
            // 
            // frmAgendaPagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 466);
            this.Controls.Add(this.grp);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAgendaPagos";
            this.Text = "Pagos";
            this.Load += new System.EventHandler(this.frmPagos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grp)).EndInit();
            this.grp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pagoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grp;
        private DevExpress.XtraGrid.GridControl grv;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource pagoBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpresaID;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpresa;
        private DevExpress.XtraGrid.Columns.GridColumn colComercioID;
        private DevExpress.XtraGrid.Columns.GridColumn colComercio;
        private DevExpress.XtraGrid.Columns.GridColumn colPagoID;
        private DevExpress.XtraGrid.Columns.GridColumn colSolicitudFondoID;
        private DevExpress.XtraGrid.Columns.GridColumn colSolicitudFondo;
        private DevExpress.XtraGrid.Columns.GridColumn colCapID;
        private DevExpress.XtraGrid.Columns.GridColumn colCapDetalleID;
        private DevExpress.XtraGrid.Columns.GridColumn colCapDetalle;
        private DevExpress.XtraGrid.Columns.GridColumn colFFID;
        private DevExpress.XtraGrid.Columns.GridColumn colFFDetalleID;
        private DevExpress.XtraGrid.Columns.GridColumn colFFDetalle;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha;
        private DevExpress.XtraGrid.Columns.GridColumn colImporte;
    }
}