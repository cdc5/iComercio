namespace iComercio.Forms
{
    partial class FrmCaps
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCaps));
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDetalle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaVencimiento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImportePago = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFinalizado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.dgv = new DevExpress.XtraGrid.GridControl();
            this.capBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCapID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNotas = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSolicitudFondo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPagado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFecha1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPagoID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSolicitudFondo1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporte1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEstado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grpBusqueda = new DevExpress.XtraEditors.GroupControl();
            this.btnImagen = new System.Windows.Forms.Button();
            this.lblCapDetaID = new System.Windows.Forms.Label();
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
            this.btnCargarPago = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.capBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
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
            this.colDetalle,
            this.colFechaVencimiento,
            this.colImporte,
            this.colImportePago,
            this.colFinalizado});
            this.gridView2.GridControl = this.dgv;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView2.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView2.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.True;
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView2_FocusedRowChanged);
            this.gridView2.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.gridView2_BeforeLeaveRow);
            this.gridView2.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView2_ValidateRow);
            this.gridView2.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridView2_RowUpdated);
            // 
            // colDetalle
            // 
            this.colDetalle.FieldName = "Detalle";
            this.colDetalle.Name = "colDetalle";
            this.colDetalle.OptionsColumn.AllowEdit = false;
            this.colDetalle.Visible = true;
            this.colDetalle.VisibleIndex = 0;
            // 
            // colFechaVencimiento
            // 
            this.colFechaVencimiento.FieldName = "FechaVencimiento";
            this.colFechaVencimiento.Name = "colFechaVencimiento";
            this.colFechaVencimiento.OptionsColumn.AllowEdit = false;
            this.colFechaVencimiento.Visible = true;
            this.colFechaVencimiento.VisibleIndex = 1;
            // 
            // colImporte
            // 
            this.colImporte.FieldName = "Importe";
            this.colImporte.Name = "colImporte";
            this.colImporte.OptionsColumn.AllowEdit = false;
            this.colImporte.Visible = true;
            this.colImporte.VisibleIndex = 2;
            // 
            // colImportePago
            // 
            this.colImportePago.FieldName = "ImportePago";
            this.colImportePago.Name = "colImportePago";
            this.colImportePago.Visible = true;
            this.colImportePago.VisibleIndex = 3;
            // 
            // colFinalizado
            // 
            this.colFinalizado.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colFinalizado.FieldName = "Finalizado";
            this.colFinalizado.Name = "colFinalizado";
            this.colFinalizado.Visible = true;
            this.colFinalizado.VisibleIndex = 4;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // dgv
            // 
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgv.DataSource = this.capBindingSource;
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
            this.dgv.Size = new System.Drawing.Size(944, 298);
            this.dgv.TabIndex = 0;
            this.dgv.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.gridView3,
            this.gridView2});
            this.dgv.Click += new System.EventHandler(this.dgv_Click);
            // 
            // capBindingSource
            // 
            this.capBindingSource.DataSource = typeof(iComercio.Models.Cap);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFecha,
            this.colCapID,
            this.colTotal,
            this.colNotas,
            this.colSolicitudFondo,
            this.colPagado});
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
            this.colFecha.OptionsColumn.AllowEdit = false;
            this.colFecha.Visible = true;
            this.colFecha.VisibleIndex = 1;
            // 
            // colCapID
            // 
            this.colCapID.FieldName = "CapID";
            this.colCapID.Name = "colCapID";
            this.colCapID.OptionsColumn.AllowEdit = false;
            this.colCapID.Visible = true;
            this.colCapID.VisibleIndex = 0;
            // 
            // colTotal
            // 
            this.colTotal.FieldName = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.OptionsColumn.AllowEdit = false;
            this.colTotal.Visible = true;
            this.colTotal.VisibleIndex = 2;
            // 
            // colNotas
            // 
            this.colNotas.FieldName = "Notas";
            this.colNotas.Name = "colNotas";
            this.colNotas.OptionsColumn.AllowEdit = false;
            this.colNotas.Visible = true;
            this.colNotas.VisibleIndex = 3;
            // 
            // colSolicitudFondo
            // 
            this.colSolicitudFondo.FieldName = "SolicitudFondo";
            this.colSolicitudFondo.Name = "colSolicitudFondo";
            this.colSolicitudFondo.OptionsColumn.AllowEdit = false;
            this.colSolicitudFondo.Visible = true;
            this.colSolicitudFondo.VisibleIndex = 4;
            // 
            // colPagado
            // 
            this.colPagado.FieldName = "Pagado";
            this.colPagado.Name = "colPagado";
            this.colPagado.Visible = true;
            this.colPagado.VisibleIndex = 5;
            // 
            // gridView3
            // 
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFecha1,
            this.colPagoID,
            this.colSolicitudFondo1,
            this.colImporte1,
            this.colEstado});
            this.gridView3.GridControl = this.dgv;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView3.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView3.OptionsBehavior.Editable = false;
            this.gridView3.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView3_FocusedRowChanged);
            this.gridView3.DoubleClick += new System.EventHandler(this.gridView3_DoubleClick);
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
            // colSolicitudFondo1
            // 
            this.colSolicitudFondo1.FieldName = "SolicitudFondo";
            this.colSolicitudFondo1.Name = "colSolicitudFondo1";
            this.colSolicitudFondo1.Visible = true;
            this.colSolicitudFondo1.VisibleIndex = 2;
            // 
            // colImporte1
            // 
            this.colImporte1.FieldName = "Importe";
            this.colImporte1.Name = "colImporte1";
            this.colImporte1.Visible = true;
            this.colImporte1.VisibleIndex = 3;
            // 
            // colEstado
            // 
            this.colEstado.FieldName = "Estado";
            this.colEstado.Name = "colEstado";
            this.colEstado.Visible = true;
            this.colEstado.VisibleIndex = 4;
            // 
            // grpBusqueda
            // 
            this.grpBusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBusqueda.Controls.Add(this.btnImagen);
            this.grpBusqueda.Controls.Add(this.lblCapDetaID);
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
            this.grpBusqueda.Size = new System.Drawing.Size(954, 93);
            this.grpBusqueda.TabIndex = 0;
            this.grpBusqueda.Text = "Búsqueda";
            // 
            // btnImagen
            // 
            this.btnImagen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImagen.Image = global::iComercio.Properties.Resources.zoom;
            this.btnImagen.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnImagen.Location = new System.Drawing.Point(766, 55);
            this.btnImagen.Name = "btnImagen";
            this.btnImagen.Size = new System.Drawing.Size(89, 32);
            this.btnImagen.TabIndex = 13;
            this.btnImagen.Text = "Ver imagen";
            this.btnImagen.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnImagen.UseVisualStyleBackColor = true;
            this.btnImagen.Click += new System.EventHandler(this.btnImagen_Click);
            // 
            // lblCapDetaID
            // 
            this.lblCapDetaID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCapDetaID.AutoSize = true;
            this.lblCapDetaID.Location = new System.Drawing.Point(701, 74);
            this.lblCapDetaID.Name = "lblCapDetaID";
            this.lblCapDetaID.Size = new System.Drawing.Size(13, 13);
            this.lblCapDetaID.TabIndex = 12;
            this.lblCapDetaID.Text = "0";
            this.lblCapDetaID.Visible = false;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.lblEstado.Location = new System.Drawing.Point(169, 63);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(43, 13);
            this.lblEstado.TabIndex = 10;
            this.lblEstado.Text = "Estado:";
            // 
            // cmbEstado
            // 
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(218, 59);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(286, 21);
            this.cmbEstado.TabIndex = 9;
            this.cmbEstado.SelectedIndexChanged += new System.EventHandler(this.cmbEstado_SelectedIndexChanged);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Location = new System.Drawing.Point(861, 55);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(88, 33);
            this.btnBuscar.TabIndex = 6;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(218, 31);
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
            this.grbGrilla.Controls.Add(this.btnCargarPago);
            this.grbGrilla.Controls.Add(this.dgv);
            this.grbGrilla.Location = new System.Drawing.Point(12, 111);
            this.grbGrilla.Name = "grbGrilla";
            this.grbGrilla.Size = new System.Drawing.Size(954, 352);
            this.grbGrilla.TabIndex = 1;
            this.grbGrilla.Text = "Búsqueda";
            // 
            // btnCargarPago
            // 
            this.btnCargarPago.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCargarPago.Location = new System.Drawing.Point(5, 324);
            this.btnCargarPago.Name = "btnCargarPago";
            this.btnCargarPago.Size = new System.Drawing.Size(75, 23);
            this.btnCargarPago.TabIndex = 1;
            this.btnCargarPago.Text = "Nuevo Pago";
            this.btnCargarPago.UseVisualStyleBackColor = true;
            this.btnCargarPago.Click += new System.EventHandler(this.btnNuevoPago_Click);
            // 
            // FrmCaps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 469);
            this.Controls.Add(this.grbGrilla);
            this.Controls.Add(this.grpBusqueda);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmCaps";
            this.Text = "Informes de Cuentas A Pagar";
            this.Load += new System.EventHandler(this.FrmCaps_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.capBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
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
        private DevExpress.XtraEditors.GroupControl grbGrilla;
        private DevExpress.XtraGrid.GridControl dgv;
        private System.Windows.Forms.BindingSource capBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colCapID;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha;
        private DevExpress.XtraGrid.Columns.GridColumn colTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colNotas;
        private DevExpress.XtraGrid.Columns.GridColumn colSolicitudFondo;
        private DevExpress.XtraGrid.Columns.GridColumn colPagado;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblN;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.Label lblDesde;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn colDetalle;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaVencimiento;
        private DevExpress.XtraGrid.Columns.GridColumn colImporte;
        private DevExpress.XtraGrid.Columns.GridColumn colImportePago;
        private System.Windows.Forms.Button btnCargarPago;
        private DevExpress.XtraGrid.Columns.GridColumn colFinalizado;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha1;
        private DevExpress.XtraGrid.Columns.GridColumn colPagoID;
        private DevExpress.XtraGrid.Columns.GridColumn colSolicitudFondo1;
        private DevExpress.XtraGrid.Columns.GridColumn colImporte1;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cmbEstado;
        private DevExpress.XtraGrid.Columns.GridColumn colEstado;
        private System.Windows.Forms.Button btnImagen;
        private System.Windows.Forms.Label lblCapDetaID;
    }
}