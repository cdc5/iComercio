namespace iComercio.Forms
{
    partial class FrmCtaCteComun
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCtaCteComun));
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.dgv = new DevExpress.XtraGrid.GridControl();
            this.cuentaCorrienteComunBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDebe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHaber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaldoDiario = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaldo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colprovisorios = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMovimiento1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grbCtaCte = new DevExpress.XtraEditors.GroupControl();
            this.grpTotales = new DevExpress.XtraEditors.GroupControl();
            this.lblDispVentaV = new DevExpress.XtraEditors.LabelControl();
            this.lblDispVenta = new DevExpress.XtraEditors.LabelControl();
            this.lblAutVentaHoyV = new DevExpress.XtraEditors.LabelControl();
            this.lblAutVentaHoy = new DevExpress.XtraEditors.LabelControl();
            this.lblAutVentaAyerV = new DevExpress.XtraEditors.LabelControl();
            this.lblAutVentaAyer = new DevExpress.XtraEditors.LabelControl();
            this.lblAutVentaV = new DevExpress.XtraEditors.LabelControl();
            this.lblRetFFV = new DevExpress.XtraEditors.LabelControl();
            this.lblRetCapV = new DevExpress.XtraEditors.LabelControl();
            this.lblSaldoV = new DevExpress.XtraEditors.LabelControl();
            this.lblAutVenta = new DevExpress.XtraEditors.LabelControl();
            this.lblRetFF = new DevExpress.XtraEditors.LabelControl();
            this.lblRetCap = new DevExpress.XtraEditors.LabelControl();
            this.lblSaldo = new DevExpress.XtraEditors.LabelControl();
            this.btnAct = new System.Windows.Forms.Button();
            this.btnAgregarMovimiento = new System.Windows.Forms.Button();
            this.grbFechas = new DevExpress.XtraEditors.GroupControl();
            this.lblComercio = new System.Windows.Forms.Label();
            this.cmbComercio = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.lblDesde = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cuentaCorrienteComunBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grbCtaCte)).BeginInit();
            this.grbCtaCte.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpTotales)).BeginInit();
            this.grpTotales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grbFechas)).BeginInit();
            this.grbFechas.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.dgv;
            this.gridView2.Name = "gridView2";
            // 
            // dgv
            // 
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgv.DataSource = this.cuentaCorrienteComunBindingSource;
            gridLevelNode1.LevelTemplate = this.gridView2;
            gridLevelNode1.RelationName = "MovimientosDebe";
            gridLevelNode2.LevelTemplate = this.gridView3;
            gridLevelNode2.RelationName = "MovimientosHaber";
            this.dgv.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1,
            gridLevelNode2});
            this.dgv.Location = new System.Drawing.Point(5, 24);
            this.dgv.MainView = this.gridView1;
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(942, 214);
            this.dgv.TabIndex = 0;
            this.dgv.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3,
            this.gridView1,
            this.gridView4,
            this.gridView2});
            // 
            // cuentaCorrienteComunBindingSource
            // 
            this.cuentaCorrienteComunBindingSource.DataSource = typeof(iComercio.Models.CuentaCorrienteComun);
            this.cuentaCorrienteComunBindingSource.CurrentChanged += new System.EventHandler(this.cuentaCorrienteComunBindingSource_CurrentChanged);
            // 
            // gridView3
            // 
            this.gridView3.GridControl = this.dgv;
            this.gridView3.Name = "gridView3";
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFecha,
            this.colDebe,
            this.colHaber,
            this.colSaldoDiario,
            this.colSaldo,
            this.colprovisorios});
            this.gridView1.GridControl = this.dgv;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridView1_RowStyle);
            // 
            // colFecha
            // 
            this.colFecha.FieldName = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.Visible = true;
            this.colFecha.VisibleIndex = 0;
            // 
            // colDebe
            // 
            this.colDebe.FieldName = "Debe";
            this.colDebe.Name = "colDebe";
            this.colDebe.Visible = true;
            this.colDebe.VisibleIndex = 1;
            // 
            // colHaber
            // 
            this.colHaber.FieldName = "Haber";
            this.colHaber.Name = "colHaber";
            this.colHaber.Visible = true;
            this.colHaber.VisibleIndex = 2;
            // 
            // colSaldoDiario
            // 
            this.colSaldoDiario.FieldName = "SaldoDiario";
            this.colSaldoDiario.Name = "colSaldoDiario";
            this.colSaldoDiario.Visible = true;
            this.colSaldoDiario.VisibleIndex = 3;
            // 
            // colSaldo
            // 
            this.colSaldo.FieldName = "Saldo";
            this.colSaldo.Name = "colSaldo";
            this.colSaldo.Visible = true;
            this.colSaldo.VisibleIndex = 4;
            // 
            // colprovisorios
            // 
            this.colprovisorios.FieldName = "provisorios";
            this.colprovisorios.Name = "colprovisorios";
            // 
            // gridView4
            // 
            this.gridView4.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMovimiento1});
            this.gridView4.GridControl = this.dgv;
            this.gridView4.Name = "gridView4";
            // 
            // colMovimiento1
            // 
            this.colMovimiento1.FieldName = "Movimiento";
            this.colMovimiento1.Name = "colMovimiento1";
            this.colMovimiento1.Visible = true;
            this.colMovimiento1.VisibleIndex = 0;
            // 
            // grbCtaCte
            // 
            this.grbCtaCte.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbCtaCte.Controls.Add(this.grpTotales);
            this.grbCtaCte.Controls.Add(this.btnAct);
            this.grbCtaCte.Controls.Add(this.btnAgregarMovimiento);
            this.grbCtaCte.Controls.Add(this.dgv);
            this.grbCtaCte.Location = new System.Drawing.Point(12, 126);
            this.grbCtaCte.Name = "grbCtaCte";
            this.grbCtaCte.Size = new System.Drawing.Size(952, 362);
            this.grbCtaCte.TabIndex = 7;
            this.grbCtaCte.Text = "Cuenta Corriente";
            this.grbCtaCte.Paint += new System.Windows.Forms.PaintEventHandler(this.grbCtaCte_Paint);
            // 
            // grpTotales
            // 
            this.grpTotales.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpTotales.Controls.Add(this.lblDispVentaV);
            this.grpTotales.Controls.Add(this.lblDispVenta);
            this.grpTotales.Controls.Add(this.lblAutVentaHoyV);
            this.grpTotales.Controls.Add(this.lblAutVentaHoy);
            this.grpTotales.Controls.Add(this.lblAutVentaAyerV);
            this.grpTotales.Controls.Add(this.lblAutVentaAyer);
            this.grpTotales.Controls.Add(this.lblAutVentaV);
            this.grpTotales.Controls.Add(this.lblRetFFV);
            this.grpTotales.Controls.Add(this.lblRetCapV);
            this.grpTotales.Controls.Add(this.lblSaldoV);
            this.grpTotales.Controls.Add(this.lblAutVenta);
            this.grpTotales.Controls.Add(this.lblRetFF);
            this.grpTotales.Controls.Add(this.lblRetCap);
            this.grpTotales.Controls.Add(this.lblSaldo);
            this.grpTotales.Location = new System.Drawing.Point(6, 244);
            this.grpTotales.Name = "grpTotales";
            this.grpTotales.Size = new System.Drawing.Size(941, 84);
            this.grpTotales.TabIndex = 3;
            this.grpTotales.Paint += new System.Windows.Forms.PaintEventHandler(this.grpTotales_Paint);
            // 
            // lblDispVentaV
            // 
            this.lblDispVentaV.Location = new System.Drawing.Point(126, 47);
            this.lblDispVentaV.Name = "lblDispVentaV";
            this.lblDispVentaV.Size = new System.Drawing.Size(22, 13);
            this.lblDispVentaV.TabIndex = 13;
            this.lblDispVentaV.Text = "0.00";
            this.lblDispVentaV.Click += new System.EventHandler(this.lblDispVentaV_Click);
            // 
            // lblDispVenta
            // 
            this.lblDispVenta.Location = new System.Drawing.Point(12, 47);
            this.lblDispVenta.Name = "lblDispVenta";
            this.lblDispVenta.Size = new System.Drawing.Size(108, 13);
            this.lblDispVenta.TabIndex = 12;
            this.lblDispVenta.Text = "Disponible Para Venta:";
            // 
            // lblAutVentaHoyV
            // 
            this.lblAutVentaHoyV.Location = new System.Drawing.Point(525, 43);
            this.lblAutVentaHoyV.Name = "lblAutVentaHoyV";
            this.lblAutVentaHoyV.Size = new System.Drawing.Size(22, 13);
            this.lblAutVentaHoyV.TabIndex = 11;
            this.lblAutVentaHoyV.Text = "0.00";
            this.lblAutVentaHoyV.Visible = false;
            // 
            // lblAutVentaHoy
            // 
            this.lblAutVentaHoy.Location = new System.Drawing.Point(348, 43);
            this.lblAutVentaHoy.Name = "lblAutVentaHoy";
            this.lblAutVentaHoy.Size = new System.Drawing.Size(109, 13);
            this.lblAutVentaHoy.TabIndex = 10;
            this.lblAutVentaHoy.Text = "Autorizado Venta Hoy:";
            this.lblAutVentaHoy.Visible = false;
            // 
            // lblAutVentaAyerV
            // 
            this.lblAutVentaAyerV.Location = new System.Drawing.Point(525, 24);
            this.lblAutVentaAyerV.Name = "lblAutVentaAyerV";
            this.lblAutVentaAyerV.Size = new System.Drawing.Size(22, 13);
            this.lblAutVentaAyerV.TabIndex = 9;
            this.lblAutVentaAyerV.Text = "0.00";
            this.lblAutVentaAyerV.Visible = false;
            // 
            // lblAutVentaAyer
            // 
            this.lblAutVentaAyer.Location = new System.Drawing.Point(348, 24);
            this.lblAutVentaAyer.Name = "lblAutVentaAyer";
            this.lblAutVentaAyer.Size = new System.Drawing.Size(171, 13);
            this.lblAutVentaAyer.TabIndex = 8;
            this.lblAutVentaAyer.Text = "Remanente Autorizado Venta Ayer:";
            this.lblAutVentaAyer.Visible = false;
            // 
            // lblAutVentaV
            // 
            this.lblAutVentaV.Location = new System.Drawing.Point(525, 62);
            this.lblAutVentaV.Name = "lblAutVentaV";
            this.lblAutVentaV.Size = new System.Drawing.Size(22, 13);
            this.lblAutVentaV.TabIndex = 7;
            this.lblAutVentaV.Text = "0.00";
            this.lblAutVentaV.Visible = false;
            // 
            // lblRetFFV
            // 
            this.lblRetFFV.Location = new System.Drawing.Point(289, 44);
            this.lblRetFFV.Name = "lblRetFFV";
            this.lblRetFFV.Size = new System.Drawing.Size(22, 13);
            this.lblRetFFV.TabIndex = 6;
            this.lblRetFFV.Text = "0.00";
            this.lblRetFFV.Visible = false;
            // 
            // lblRetCapV
            // 
            this.lblRetCapV.Location = new System.Drawing.Point(289, 24);
            this.lblRetCapV.Name = "lblRetCapV";
            this.lblRetCapV.Size = new System.Drawing.Size(22, 13);
            this.lblRetCapV.TabIndex = 5;
            this.lblRetCapV.Text = "0.00";
            this.lblRetCapV.Visible = false;
            // 
            // lblSaldoV
            // 
            this.lblSaldoV.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldoV.Location = new System.Drawing.Point(124, 28);
            this.lblSaldoV.Name = "lblSaldoV";
            this.lblSaldoV.Size = new System.Drawing.Size(24, 13);
            this.lblSaldoV.TabIndex = 4;
            this.lblSaldoV.Text = "0.00";
            // 
            // lblAutVenta
            // 
            this.lblAutVenta.Location = new System.Drawing.Point(348, 62);
            this.lblAutVenta.Name = "lblAutVenta";
            this.lblAutVenta.Size = new System.Drawing.Size(112, 13);
            this.lblAutVenta.TabIndex = 3;
            this.lblAutVenta.Text = "Autorizado Para Venta:";
            this.lblAutVenta.Visible = false;
            // 
            // lblRetFF
            // 
            this.lblRetFF.Location = new System.Drawing.Point(189, 43);
            this.lblRetFF.Name = "lblRetFF";
            this.lblRetFF.Size = new System.Drawing.Size(71, 13);
            this.lblRetFF.TabIndex = 2;
            this.lblRetFF.Text = "Autorizado FF:";
            this.lblRetFF.Visible = false;
            // 
            // lblRetCap
            // 
            this.lblRetCap.Location = new System.Drawing.Point(189, 24);
            this.lblRetCap.Name = "lblRetCap";
            this.lblRetCap.Size = new System.Drawing.Size(78, 13);
            this.lblRetCap.TabIndex = 1;
            this.lblRetCap.Text = "Autorizado Cap:";
            this.lblRetCap.Visible = false;
            // 
            // lblSaldo
            // 
            this.lblSaldo.Location = new System.Drawing.Point(12, 28);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Size = new System.Drawing.Size(30, 13);
            this.lblSaldo.TabIndex = 0;
            this.lblSaldo.Text = "Saldo:";
            // 
            // btnAct
            // 
            this.btnAct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAct.Location = new System.Drawing.Point(142, 334);
            this.btnAct.Name = "btnAct";
            this.btnAct.Size = new System.Drawing.Size(131, 23);
            this.btnAct.TabIndex = 2;
            this.btnAct.Text = "Actualizar Recibos";
            this.btnAct.UseVisualStyleBackColor = true;
            this.btnAct.Click += new System.EventHandler(this.btnAct_Click);
            // 
            // btnAgregarMovimiento
            // 
            this.btnAgregarMovimiento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAgregarMovimiento.Location = new System.Drawing.Point(5, 334);
            this.btnAgregarMovimiento.Name = "btnAgregarMovimiento";
            this.btnAgregarMovimiento.Size = new System.Drawing.Size(131, 23);
            this.btnAgregarMovimiento.TabIndex = 1;
            this.btnAgregarMovimiento.Text = "Cargar Recibos";
            this.btnAgregarMovimiento.UseVisualStyleBackColor = true;
            this.btnAgregarMovimiento.Click += new System.EventHandler(this.btnAgregarMovimiento_Click);
            // 
            // grbFechas
            // 
            this.grbFechas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbFechas.Controls.Add(this.lblComercio);
            this.grbFechas.Controls.Add(this.cmbComercio);
            this.grbFechas.Controls.Add(this.btnBuscar);
            this.grbFechas.Controls.Add(this.lblHasta);
            this.grbFechas.Controls.Add(this.dtpHasta);
            this.grbFechas.Controls.Add(this.lblDesde);
            this.grbFechas.Controls.Add(this.dtpDesde);
            this.grbFechas.Location = new System.Drawing.Point(12, 12);
            this.grbFechas.Name = "grbFechas";
            this.grbFechas.Size = new System.Drawing.Size(952, 108);
            this.grbFechas.TabIndex = 0;
            this.grbFechas.Text = "Seleccione las opciones";
            // 
            // lblComercio
            // 
            this.lblComercio.AutoSize = true;
            this.lblComercio.Location = new System.Drawing.Point(16, 29);
            this.lblComercio.Name = "lblComercio";
            this.lblComercio.Size = new System.Drawing.Size(54, 13);
            this.lblComercio.TabIndex = 6;
            this.lblComercio.Text = "Comercio:";
            // 
            // cmbComercio
            // 
            this.cmbComercio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbComercio.FormattingEnabled = true;
            this.cmbComercio.Location = new System.Drawing.Point(76, 26);
            this.cmbComercio.Name = "cmbComercio";
            this.cmbComercio.Size = new System.Drawing.Size(249, 21);
            this.cmbComercio.TabIndex = 5;
            this.cmbComercio.SelectedIndexChanged += new System.EventHandler(this.cmbComercio_SelectedIndexChanged);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(250, 80);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(181, 57);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(38, 13);
            this.lblHasta.TabIndex = 3;
            this.lblHasta.Text = "Hasta:";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Checked = false;
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(226, 54);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(99, 20);
            this.dtpHasta.TabIndex = 2;
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Location = new System.Drawing.Point(16, 57);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(41, 13);
            this.lblDesde.TabIndex = 1;
            this.lblDesde.Text = "Desde:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(76, 53);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(99, 20);
            this.dtpDesde.TabIndex = 0;
            // 
            // FrmCtaCteComun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 500);
            this.Controls.Add(this.grbCtaCte);
            this.Controls.Add(this.grbFechas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmCtaCteComun";
            this.Text = "Cuenta Corriente";
            this.Load += new System.EventHandler(this.FrmCtaCteComun_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cuentaCorrienteComunBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grbCtaCte)).EndInit();
            this.grbCtaCte.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpTotales)).EndInit();
            this.grpTotales.ResumeLayout(false);
            this.grpTotales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grbFechas)).EndInit();
            this.grbFechas.ResumeLayout(false);
            this.grbFechas.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grbFechas;
        private System.Windows.Forms.Label lblComercio;
        private System.Windows.Forms.ComboBox cmbComercio;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private DevExpress.XtraEditors.GroupControl grbCtaCte;
        private DevExpress.XtraGrid.GridControl dgv;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource cuentaCorrienteComunBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraGrid.Columns.GridColumn colMovimiento1;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha;
        private DevExpress.XtraGrid.Columns.GridColumn colDebe;
        private DevExpress.XtraGrid.Columns.GridColumn colHaber;
        private DevExpress.XtraGrid.Columns.GridColumn colSaldoDiario;
        private DevExpress.XtraGrid.Columns.GridColumn colSaldo;
        private System.Windows.Forms.Button btnAgregarMovimiento;
        private DevExpress.XtraGrid.Columns.GridColumn colprovisorios;
        private System.Windows.Forms.Button btnAct;
        private DevExpress.XtraEditors.GroupControl grpTotales;
        private DevExpress.XtraEditors.LabelControl lblSaldoV;
        private DevExpress.XtraEditors.LabelControl lblAutVenta;
        private DevExpress.XtraEditors.LabelControl lblRetFF;
        private DevExpress.XtraEditors.LabelControl lblRetCap;
        private DevExpress.XtraEditors.LabelControl lblSaldo;
        private DevExpress.XtraEditors.LabelControl lblAutVentaV;
        private DevExpress.XtraEditors.LabelControl lblRetFFV;
        private DevExpress.XtraEditors.LabelControl lblRetCapV;
        private DevExpress.XtraEditors.LabelControl lblDispVentaV;
        private DevExpress.XtraEditors.LabelControl lblDispVenta;
        private DevExpress.XtraEditors.LabelControl lblAutVentaHoyV;
        private DevExpress.XtraEditors.LabelControl lblAutVentaHoy;
        private DevExpress.XtraEditors.LabelControl lblAutVentaAyerV;
        private DevExpress.XtraEditors.LabelControl lblAutVentaAyer;
    }
}