namespace iComercio.Forms
{
    partial class FrmFFs
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFFs));
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFecha2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetalle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dgv = new DevExpress.XtraGrid.GridControl();
            this.fFBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFFID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMontoFF = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPagado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalGastos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFecha1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPagoID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporte1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSolicitudFondo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grpBusqueda = new DevExpress.XtraEditors.GroupControl();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblN = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblHasta = new System.Windows.Forms.Label();
            this.lblDesde = new System.Windows.Forms.Label();
            this.grbGrilla = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fFBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpBusqueda)).BeginInit();
            this.grpBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grbGrilla)).BeginInit();
            this.grbGrilla.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFecha2,
            this.colDetalle,
            this.colImporte});
            this.gridView2.GridControl = this.dgv;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView2.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView2.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.True;
            this.gridView2.OptionsBehavior.Editable = false;
            // 
            // colFecha2
            // 
            this.colFecha2.FieldName = "Fecha";
            this.colFecha2.Name = "colFecha2";
            this.colFecha2.Visible = true;
            this.colFecha2.VisibleIndex = 0;
            // 
            // colDetalle
            // 
            this.colDetalle.FieldName = "Detalle";
            this.colDetalle.Name = "colDetalle";
            this.colDetalle.Visible = true;
            this.colDetalle.VisibleIndex = 1;
            // 
            // colImporte
            // 
            this.colImporte.FieldName = "Importe";
            this.colImporte.Name = "colImporte";
            this.colImporte.Visible = true;
            this.colImporte.VisibleIndex = 2;
            // 
            // dgv
            // 
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgv.DataSource = this.fFBindingSource;
            gridLevelNode1.LevelTemplate = this.gridView2;
            gridLevelNode2.LevelTemplate = this.gridView3;
            gridLevelNode2.RelationName = "Pagos";
            gridLevelNode1.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode2});
            gridLevelNode1.RelationName = "Items";
            this.dgv.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.dgv.Location = new System.Drawing.Point(5, 24);
            this.dgv.MainView = this.gridView1;
            this.dgv.Name = "dgv";
            this.dgv.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.dgv.Size = new System.Drawing.Size(860, 358);
            this.dgv.TabIndex = 0;
            this.dgv.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.gridView3,
            this.gridView2});
            // 
            // fFBindingSource
            // 
            this.fFBindingSource.DataSource = typeof(iComercio.Models.FF);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFecha,
            this.colFFID,
            this.colMontoFF,
            this.colPagado,
            this.colTotalGastos});
            this.gridView1.GridControl = this.dgv;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // colFecha
            // 
            this.colFecha.FieldName = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.Visible = true;
            this.colFecha.VisibleIndex = 0;
            // 
            // colFFID
            // 
            this.colFFID.FieldName = "FFID";
            this.colFFID.Name = "colFFID";
            this.colFFID.Visible = true;
            this.colFFID.VisibleIndex = 1;
            // 
            // colMontoFF
            // 
            this.colMontoFF.FieldName = "MontoFF";
            this.colMontoFF.Name = "colMontoFF";
            this.colMontoFF.Visible = true;
            this.colMontoFF.VisibleIndex = 2;
            // 
            // colPagado
            // 
            this.colPagado.FieldName = "Pagado";
            this.colPagado.Name = "colPagado";
            this.colPagado.Visible = true;
            this.colPagado.VisibleIndex = 3;
            // 
            // colTotalGastos
            // 
            this.colTotalGastos.FieldName = "TotalGastos";
            this.colTotalGastos.Name = "colTotalGastos";
            this.colTotalGastos.Visible = true;
            this.colTotalGastos.VisibleIndex = 4;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // gridView3
            // 
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFecha1,
            this.colPagoID,
            this.colImporte1,
            this.colSolicitudFondo});
            this.gridView3.GridControl = this.dgv;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView3.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView3.OptionsBehavior.Editable = false;
            // 
            // colFecha1
            // 
            this.colFecha1.FieldName = "Fecha";
            this.colFecha1.Name = "colFecha1";
            this.colFecha1.Visible = true;
            this.colFecha1.VisibleIndex = 0;
            // 
            // colPagoID
            // 
            this.colPagoID.FieldName = "PagoID";
            this.colPagoID.Name = "colPagoID";
            this.colPagoID.Visible = true;
            this.colPagoID.VisibleIndex = 1;
            // 
            // colImporte1
            // 
            this.colImporte1.FieldName = "Importe";
            this.colImporte1.Name = "colImporte1";
            this.colImporte1.Visible = true;
            this.colImporte1.VisibleIndex = 2;
            // 
            // colSolicitudFondo
            // 
            this.colSolicitudFondo.FieldName = "SolicitudFondo";
            this.colSolicitudFondo.Name = "colSolicitudFondo";
            this.colSolicitudFondo.Visible = true;
            this.colSolicitudFondo.VisibleIndex = 3;
            // 
            // grpBusqueda
            // 
            this.grpBusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBusqueda.Controls.Add(this.lblEstado);
            this.grpBusqueda.Controls.Add(this.cmbEstado);
            this.grpBusqueda.Controls.Add(this.btnBuscar);
            this.grpBusqueda.Controls.Add(this.txtID);
            this.grpBusqueda.Controls.Add(this.lblN);
            this.grpBusqueda.Controls.Add(this.dtpHasta);
            this.grpBusqueda.Controls.Add(this.dtpDesde);
            this.grpBusqueda.Controls.Add(this.lblHasta);
            this.grpBusqueda.Controls.Add(this.lblDesde);
            this.grpBusqueda.Location = new System.Drawing.Point(12, 12);
            this.grpBusqueda.Name = "grpBusqueda";
            this.grpBusqueda.Size = new System.Drawing.Size(870, 90);
            this.grpBusqueda.TabIndex = 1;
            this.grpBusqueda.Text = "Búsqueda";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.lblEstado.Location = new System.Drawing.Point(169, 66);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(43, 13);
            this.lblEstado.TabIndex = 8;
            this.lblEstado.Text = "Estado:";
            // 
            // cmbEstado
            // 
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(218, 60);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(286, 21);
            this.cmbEstado.TabIndex = 7;
            this.cmbEstado.SelectedIndexChanged += new System.EventHandler(this.cmbEstado_SelectedIndexChanged);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Location = new System.Drawing.Point(790, 57);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 6;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(218, 30);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(100, 20);
            this.txtID.TabIndex = 5;
            this.txtID.Tag = "N";
            // 
            // lblN
            // 
            this.lblN.AutoSize = true;
            this.lblN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.lblN.Location = new System.Drawing.Point(169, 33);
            this.lblN.Name = "lblN";
            this.lblN.Size = new System.Drawing.Size(22, 13);
            this.lblN.TabIndex = 4;
            this.lblN.Text = "N°:";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(58, 60);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(86, 20);
            this.dtpHasta.TabIndex = 3;
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(58, 31);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(86, 20);
            this.dtpDesde.TabIndex = 2;
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.lblHasta.Location = new System.Drawing.Point(10, 62);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(38, 13);
            this.lblHasta.TabIndex = 1;
            this.lblHasta.Text = "Hasta:";
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.lblDesde.Location = new System.Drawing.Point(10, 33);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(41, 13);
            this.lblDesde.TabIndex = 0;
            this.lblDesde.Text = "Desde:";
            // 
            // grbGrilla
            // 
            this.grbGrilla.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbGrilla.Controls.Add(this.dgv);
            this.grbGrilla.Location = new System.Drawing.Point(12, 108);
            this.grbGrilla.Name = "grbGrilla";
            this.grbGrilla.Size = new System.Drawing.Size(870, 387);
            this.grbGrilla.TabIndex = 2;
            this.grbGrilla.Text = "Búsqueda";
            // 
            // FrmFFs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 507);
            this.Controls.Add(this.grbGrilla);
            this.Controls.Add(this.grpBusqueda);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmFFs";
            this.Text = "FrmFFs";
            this.Load += new System.EventHandler(this.FrmFFs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fFBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpBusqueda)).EndInit();
            this.grpBusqueda.ResumeLayout(false);
            this.grpBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grbGrilla)).EndInit();
            this.grbGrilla.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grpBusqueda;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblN;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.Label lblDesde;
        private DevExpress.XtraEditors.GroupControl grbGrilla;
        private DevExpress.XtraGrid.GridControl dgv;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource fFBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha2;
        private DevExpress.XtraGrid.Columns.GridColumn colDetalle;
        private DevExpress.XtraGrid.Columns.GridColumn colImporte;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha1;
        private DevExpress.XtraGrid.Columns.GridColumn colPagoID;
        private DevExpress.XtraGrid.Columns.GridColumn colImporte1;
        private DevExpress.XtraGrid.Columns.GridColumn colSolicitudFondo;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha;
        private DevExpress.XtraGrid.Columns.GridColumn colFFID;
        private DevExpress.XtraGrid.Columns.GridColumn colMontoFF;
        private DevExpress.XtraGrid.Columns.GridColumn colPagado;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalGastos;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cmbEstado;
    }
}