namespace iComercio.Forms
{
    partial class FrmCap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCap));
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.cmbConcepto = new System.Windows.Forms.ComboBox();
            this.lblConcepto = new DevExpress.XtraEditors.LabelControl();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.lblNotas = new DevExpress.XtraEditors.LabelControl();
            this.lblFecha = new DevExpress.XtraEditors.LabelControl();
            this.capBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblCapV = new DevExpress.XtraEditors.LabelControl();
            this.lblCap = new DevExpress.XtraEditors.LabelControl();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.txtNotas = new System.Windows.Forms.TextBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.grvDetalles = new DevExpress.XtraGrid.GridControl();
            this.capDetalleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDetalle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.capBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDetalles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.capDetalleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl2
            // 
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
            this.groupControl2.Size = new System.Drawing.Size(602, 485);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Paint += new System.Windows.Forms.PaintEventHandler(this.groupControl2_Paint);
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
            this.btnEliminar.Location = new System.Drawing.Point(5, 450);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 15;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // lblNotas
            // 
            this.lblNotas.Location = new System.Drawing.Point(15, 389);
            this.lblNotas.Name = "lblNotas";
            this.lblNotas.Size = new System.Drawing.Size(32, 13);
            this.lblNotas.TabIndex = 14;
            this.lblNotas.Text = "Notas:";
            // 
            // lblFecha
            // 
            this.lblFecha.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.capBindingSource, "CapID", true));
            this.lblFecha.Location = new System.Drawing.Point(98, 39);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(33, 13);
            this.lblFecha.TabIndex = 13;
            this.lblFecha.Text = "Fecha:";
            // 
            // capBindingSource
            // 
            this.capBindingSource.DataSource = typeof(iComercio.Models.Cap);
            // 
            // lblCapV
            // 
            this.lblCapV.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.capBindingSource, "CapID", true));
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
            this.btnGrabar.Location = new System.Drawing.Point(517, 450);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 9;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // txtNotas
            // 
            this.txtNotas.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.capBindingSource, "Notas", true));
            this.txtNotas.Location = new System.Drawing.Point(57, 389);
            this.txtNotas.Multiline = true;
            this.txtNotas.Name = "txtNotas";
            this.txtNotas.Size = new System.Drawing.Size(535, 48);
            this.txtNotas.TabIndex = 8;
            // 
            // dtpFecha
            // 
            this.dtpFecha.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.capBindingSource, "Fecha", true));
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(137, 36);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(84, 20);
            this.dtpFecha.TabIndex = 1;
            // 
            // grvDetalles
            // 
            this.grvDetalles.Cursor = System.Windows.Forms.Cursors.Default;
            this.grvDetalles.DataSource = this.capDetalleBindingSource;
            this.grvDetalles.Location = new System.Drawing.Point(12, 62);
            this.grvDetalles.MainView = this.gridView1;
            this.grvDetalles.Name = "grvDetalles";
            this.grvDetalles.Size = new System.Drawing.Size(580, 310);
            this.grvDetalles.TabIndex = 0;
            this.grvDetalles.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.grvDetalles.Click += new System.EventHandler(this.grvDetalles_Click);
            this.grvDetalles.DoubleClick += new System.EventHandler(this.grvDetalles_DoubleClick);
            // 
            // capDetalleBindingSource
            // 
            this.capDetalleBindingSource.DataSource = typeof(iComercio.Models.CapDetalle);
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
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
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
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Importe", "Total:{0:##.##}")});
            this.colImporte.Visible = true;
            this.colImporte.VisibleIndex = 1;
            // 
            // colFecha
            // 
            this.colFecha.FieldName = "FechaVencimiento";
            this.colFecha.Name = "colFecha";
            this.colFecha.Visible = true;
            this.colFecha.VisibleIndex = 2;
            // 
            // FrmCap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 485);
            this.Controls.Add(this.groupControl2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmCap";
            this.Text = "Informe de Cuentas A Pagar";
            this.Load += new System.EventHandler(this.FrmCap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.capBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDetalles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.capDetalleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private DevExpress.XtraGrid.GridControl grvDetalles;
        private System.Windows.Forms.BindingSource capDetalleBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colDetalle;
        private DevExpress.XtraGrid.Columns.GridColumn colImporte;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.TextBox txtNotas;
        private System.Windows.Forms.BindingSource capBindingSource;
        private DevExpress.XtraEditors.LabelControl lblCap;
        private DevExpress.XtraEditors.LabelControl lblNotas;
        private DevExpress.XtraEditors.LabelControl lblFecha;
        private DevExpress.XtraEditors.LabelControl lblCapV;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.ComboBox cmbConcepto;
        private DevExpress.XtraEditors.LabelControl lblConcepto;
    }
}