namespace iComercio.Forms
{
    partial class FrmFF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFF));
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btnAutoCompletar = new System.Windows.Forms.Button();
            this.grpTotales = new DevExpress.XtraEditors.GroupControl();
            this.lblMontoFFV = new DevExpress.XtraEditors.LabelControl();
            this.fFBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblMontoFF = new DevExpress.XtraEditors.LabelControl();
            this.lblTotalGastosV = new DevExpress.XtraEditors.LabelControl();
            this.lblTotalGastos = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblRemantente = new DevExpress.XtraEditors.LabelControl();
            this.cmbConcepto = new System.Windows.Forms.ComboBox();
            this.lblConcepto = new DevExpress.XtraEditors.LabelControl();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.lblNotas = new DevExpress.XtraEditors.LabelControl();
            this.lblFecha = new DevExpress.XtraEditors.LabelControl();
            this.lblCapV = new DevExpress.XtraEditors.LabelControl();
            this.lblCap = new DevExpress.XtraEditors.LabelControl();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.txtNotas = new System.Windows.Forms.TextBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.grvDetalles = new DevExpress.XtraGrid.GridControl();
            this.fFDetalleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDetalle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpTotales)).BeginInit();
            this.grpTotales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fFBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDetalles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fFDetalleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.btnAutoCompletar);
            this.groupControl2.Controls.Add(this.grpTotales);
            this.groupControl2.Controls.Add(this.cmbConcepto);
            this.groupControl2.Controls.Add(this.lblConcepto);
            this.groupControl2.Controls.Add(this.btnEliminar);
            this.groupControl2.Controls.Add(this.lblNotas);
            this.groupControl2.Controls.Add(this.lblFecha);
            this.groupControl2.Controls.Add(this.lblCapV);
            this.groupControl2.Controls.Add(this.lblCap);
            this.groupControl2.Controls.Add(this.btnGrabar);
            this.groupControl2.Controls.Add(this.txtNotas);
            this.groupControl2.Controls.Add(this.dtpFecha);
            this.groupControl2.Controls.Add(this.grvDetalles);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(602, 563);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Paint += new System.Windows.Forms.PaintEventHandler(this.groupControl2_Paint);
            // 
            // btnAutoCompletar
            // 
            this.btnAutoCompletar.Location = new System.Drawing.Point(14, 316);
            this.btnAutoCompletar.Name = "btnAutoCompletar";
            this.btnAutoCompletar.Size = new System.Drawing.Size(89, 23);
            this.btnAutoCompletar.TabIndex = 19;
            this.btnAutoCompletar.Text = "AutoCompletar";
            this.btnAutoCompletar.UseVisualStyleBackColor = true;
            this.btnAutoCompletar.Click += new System.EventHandler(this.btnAutoCompletar_Click);
            // 
            // grpTotales
            // 
            this.grpTotales.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpTotales.Controls.Add(this.lblMontoFFV);
            this.grpTotales.Controls.Add(this.lblMontoFF);
            this.grpTotales.Controls.Add(this.lblTotalGastosV);
            this.grpTotales.Controls.Add(this.lblTotalGastos);
            this.grpTotales.Controls.Add(this.labelControl1);
            this.grpTotales.Controls.Add(this.lblRemantente);
            this.grpTotales.Location = new System.Drawing.Point(12, 349);
            this.grpTotales.Name = "grpTotales";
            this.grpTotales.Size = new System.Drawing.Size(578, 96);
            this.grpTotales.TabIndex = 18;
            this.grpTotales.Paint += new System.Windows.Forms.PaintEventHandler(this.grpTotales_Paint);
            // 
            // lblMontoFFV
            // 
            this.lblMontoFFV.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fFBindingSource, "MontoFF", true));
            this.lblMontoFFV.Location = new System.Drawing.Point(73, 34);
            this.lblMontoFFV.Name = "lblMontoFFV";
            this.lblMontoFFV.Size = new System.Drawing.Size(28, 13);
            this.lblMontoFFV.TabIndex = 22;
            this.lblMontoFFV.Text = "00.00";
            this.lblMontoFFV.Click += new System.EventHandler(this.labelControl6_Click);
            // 
            // fFBindingSource
            // 
            this.fFBindingSource.DataSource = typeof(iComercio.Models.FF);
            // 
            // lblMontoFF
            // 
            this.lblMontoFF.Location = new System.Drawing.Point(8, 34);
            this.lblMontoFF.Name = "lblMontoFF";
            this.lblMontoFF.Size = new System.Drawing.Size(54, 13);
            this.lblMontoFF.TabIndex = 21;
            this.lblMontoFF.Text = "Fondo Fijo:";
            // 
            // lblTotalGastosV
            // 
            this.lblTotalGastosV.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fFBindingSource, "TotalGastos", true));
            this.lblTotalGastosV.Location = new System.Drawing.Point(76, 72);
            this.lblTotalGastosV.Name = "lblTotalGastosV";
            this.lblTotalGastosV.Size = new System.Drawing.Size(28, 13);
            this.lblTotalGastosV.TabIndex = 20;
            this.lblTotalGastosV.Text = "00.00";
            // 
            // lblTotalGastos
            // 
            this.lblTotalGastos.Location = new System.Drawing.Point(8, 72);
            this.lblTotalGastos.Name = "lblTotalGastos";
            this.lblTotalGastos.Size = new System.Drawing.Size(64, 13);
            this.lblTotalGastos.TabIndex = 19;
            this.lblTotalGastos.Text = "Total Gastos:";
            // 
            // labelControl1
            // 
            this.labelControl1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fFBindingSource, "Remanente", true));
            this.labelControl1.Location = new System.Drawing.Point(73, 53);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(28, 13);
            this.labelControl1.TabIndex = 16;
            this.labelControl1.Text = "00.00";
            // 
            // lblRemantente
            // 
            this.lblRemantente.Location = new System.Drawing.Point(8, 53);
            this.lblRemantente.Name = "lblRemantente";
            this.lblRemantente.Size = new System.Drawing.Size(59, 13);
            this.lblRemantente.TabIndex = 15;
            this.lblRemantente.Text = "Remanente:";
            // 
            // cmbConcepto
            // 
            this.cmbConcepto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbConcepto.FormattingEnabled = true;
            this.cmbConcepto.Location = new System.Drawing.Point(364, 35);
            this.cmbConcepto.Name = "cmbConcepto";
            this.cmbConcepto.Size = new System.Drawing.Size(226, 21);
            this.cmbConcepto.TabIndex = 17;
            this.cmbConcepto.SelectedIndexChanged += new System.EventHandler(this.cmbConcepto_SelectedIndexChanged);
            // 
            // lblConcepto
            // 
            this.lblConcepto.Location = new System.Drawing.Point(255, 39);
            this.lblConcepto.Name = "lblConcepto";
            this.lblConcepto.Size = new System.Drawing.Size(103, 13);
            this.lblConcepto.TabIndex = 16;
            this.lblConcepto.Text = "Concepto de Fondos:";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEliminar.Location = new System.Drawing.Point(5, 535);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 15;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // lblNotas
            // 
            this.lblNotas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNotas.Location = new System.Drawing.Point(15, 451);
            this.lblNotas.Name = "lblNotas";
            this.lblNotas.Size = new System.Drawing.Size(32, 13);
            this.lblNotas.TabIndex = 14;
            this.lblNotas.Text = "Notas:";
            // 
            // lblFecha
            // 
            this.lblFecha.Location = new System.Drawing.Point(98, 39);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(33, 13);
            this.lblFecha.TabIndex = 13;
            this.lblFecha.Text = "Fecha:";
            // 
            // lblCapV
            // 
            this.lblCapV.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fFBindingSource, "FFID", true));
            this.lblCapV.Location = new System.Drawing.Point(37, 39);
            this.lblCapV.Name = "lblCapV";
            this.lblCapV.Size = new System.Drawing.Size(6, 13);
            this.lblCapV.TabIndex = 12;
            this.lblCapV.Text = "0";
            // 
            // lblCap
            // 
            this.lblCap.Location = new System.Drawing.Point(15, 39);
            this.lblCap.Name = "lblCap";
            this.lblCap.Size = new System.Drawing.Size(16, 13);
            this.lblCap.TabIndex = 11;
            this.lblCap.Text = "N°:";
            // 
            // btnGrabar
            // 
            this.btnGrabar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGrabar.Location = new System.Drawing.Point(517, 535);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 9;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // txtNotas
            // 
            this.txtNotas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNotas.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fFBindingSource, "Notas", true));
            this.txtNotas.Location = new System.Drawing.Point(57, 451);
            this.txtNotas.Multiline = true;
            this.txtNotas.Name = "txtNotas";
            this.txtNotas.Size = new System.Drawing.Size(535, 78);
            this.txtNotas.TabIndex = 8;
            // 
            // dtpFecha
            // 
            this.dtpFecha.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.fFBindingSource, "Fecha", true));
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(137, 36);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(84, 20);
            this.dtpFecha.TabIndex = 1;
            // 
            // grvDetalles
            // 
            this.grvDetalles.Cursor = System.Windows.Forms.Cursors.Default;
            this.grvDetalles.DataSource = this.fFDetalleBindingSource;
            this.grvDetalles.Location = new System.Drawing.Point(12, 62);
            this.grvDetalles.MainView = this.gridView1;
            this.grvDetalles.Name = "grvDetalles";
            this.grvDetalles.Size = new System.Drawing.Size(580, 281);
            this.grvDetalles.TabIndex = 0;
            this.grvDetalles.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.grvDetalles.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.grvDetalles_ProcessGridKey);
            this.grvDetalles.Click += new System.EventHandler(this.grvDetalles_Click);
            // 
            // fFDetalleBindingSource
            // 
            this.fFDetalleBindingSource.DataSource = typeof(iComercio.Models.FFDetalle);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDetalle,
            this.colImporte,
            this.colFecha});
            this.gridView1.GridControl = this.grvDetalles;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow);
            // 
            // colDetalle
            // 
            this.colDetalle.FieldName = "Detalle";
            this.colDetalle.Name = "colDetalle";
            this.colDetalle.Visible = true;
            this.colDetalle.VisibleIndex = 0;
            // 
            // colImporte
            // 
            this.colImporte.FieldName = "Importe";
            this.colImporte.Name = "colImporte";
            this.colImporte.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Importe", "Total Gastos:{0:##.##}")});
            this.colImporte.Visible = true;
            this.colImporte.VisibleIndex = 1;
            // 
            // colFecha
            // 
            this.colFecha.FieldName = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.Visible = true;
            this.colFecha.VisibleIndex = 2;
            // 
            // FrmFF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 563);
            this.Controls.Add(this.groupControl2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmFF";
            this.Text = "Fondo Fijo";
            this.Load += new System.EventHandler(this.FrmCap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpTotales)).EndInit();
            this.grpTotales.ResumeLayout(false);
            this.grpTotales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fFBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDetalles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fFDetalleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private DevExpress.XtraGrid.GridControl grvDetalles;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colDetalle;
        private DevExpress.XtraGrid.Columns.GridColumn colImporte;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.TextBox txtNotas;
        private DevExpress.XtraEditors.LabelControl lblCap;
        private DevExpress.XtraEditors.LabelControl lblNotas;
        private DevExpress.XtraEditors.LabelControl lblFecha;
        private DevExpress.XtraEditors.LabelControl lblCapV;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.ComboBox cmbConcepto;
        private DevExpress.XtraEditors.LabelControl lblConcepto;
        private DevExpress.XtraEditors.GroupControl grpTotales;
        private DevExpress.XtraEditors.LabelControl lblMontoFFV;
        private DevExpress.XtraEditors.LabelControl lblMontoFF;
        private DevExpress.XtraEditors.LabelControl lblTotalGastosV;
        private DevExpress.XtraEditors.LabelControl lblTotalGastos;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lblRemantente;
        private System.Windows.Forms.BindingSource fFBindingSource;
        private System.Windows.Forms.BindingSource fFDetalleBindingSource;
        private System.Windows.Forms.Button btnAutoCompletar;
    }
}