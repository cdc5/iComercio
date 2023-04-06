namespace iComercio.Forms
{
    partial class frmCapDetalle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCapDetalle));
            this.grpDetalle = new DevExpress.XtraEditors.GroupControl();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.chkFinalizado = new System.Windows.Forms.CheckBox();
            this.capDetalleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtDetalle = new System.Windows.Forms.TextBox();
            this.txtImportePago = new System.Windows.Forms.TextBox();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblCapV = new DevExpress.XtraEditors.LabelControl();
            this.lblFinalizado = new DevExpress.XtraEditors.LabelControl();
            this.lblDetalle = new DevExpress.XtraEditors.LabelControl();
            this.lblImportePago = new DevExpress.XtraEditors.LabelControl();
            this.lblImporte = new DevExpress.XtraEditors.LabelControl();
            this.lblFechaVen = new DevExpress.XtraEditors.LabelControl();
            this.lblCap = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.grpDetalle)).BeginInit();
            this.grpDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.capDetalleBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // grpDetalle
            // 
            this.grpDetalle.Controls.Add(this.btnGrabar);
            this.grpDetalle.Controls.Add(this.chkFinalizado);
            this.grpDetalle.Controls.Add(this.txtDetalle);
            this.grpDetalle.Controls.Add(this.txtImportePago);
            this.grpDetalle.Controls.Add(this.txtImporte);
            this.grpDetalle.Controls.Add(this.dtpFecha);
            this.grpDetalle.Controls.Add(this.lblCapV);
            this.grpDetalle.Controls.Add(this.lblFinalizado);
            this.grpDetalle.Controls.Add(this.lblDetalle);
            this.grpDetalle.Controls.Add(this.lblImportePago);
            this.grpDetalle.Controls.Add(this.lblImporte);
            this.grpDetalle.Controls.Add(this.lblFechaVen);
            this.grpDetalle.Controls.Add(this.lblCap);
            this.grpDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDetalle.Location = new System.Drawing.Point(0, 0);
            this.grpDetalle.Name = "grpDetalle";
            this.grpDetalle.Size = new System.Drawing.Size(400, 129);
            this.grpDetalle.TabIndex = 12;
            this.grpDetalle.Text = "Detalle";
            this.grpDetalle.Paint += new System.Windows.Forms.PaintEventHandler(this.grpDetalle_Paint);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Location = new System.Drawing.Point(273, 40);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 24;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // chkFinalizado
            // 
            this.chkFinalizado.AutoSize = true;
            this.chkFinalizado.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.capDetalleBindingSource, "Finalizado", true));
            this.chkFinalizado.Location = new System.Drawing.Point(252, 47);
            this.chkFinalizado.Name = "chkFinalizado";
            this.chkFinalizado.Size = new System.Drawing.Size(15, 14);
            this.chkFinalizado.TabIndex = 23;
            this.chkFinalizado.UseVisualStyleBackColor = true;
            // 
            // capDetalleBindingSource
            // 
            this.capDetalleBindingSource.DataSource = typeof(iComercio.Models.CapDetalle);
            // 
            // txtDetalle
            // 
            this.txtDetalle.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.capDetalleBindingSource, "Detalle", true));
            this.txtDetalle.Location = new System.Drawing.Point(118, 99);
            this.txtDetalle.Name = "txtDetalle";
            this.txtDetalle.Size = new System.Drawing.Size(270, 20);
            this.txtDetalle.TabIndex = 22;
            // 
            // txtImportePago
            // 
            this.txtImportePago.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.capDetalleBindingSource, "ImportePago", true));
            this.txtImportePago.Location = new System.Drawing.Point(269, 70);
            this.txtImportePago.Name = "txtImportePago";
            this.txtImportePago.Size = new System.Drawing.Size(70, 20);
            this.txtImportePago.TabIndex = 21;
            // 
            // txtImporte
            // 
            this.txtImporte.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.capDetalleBindingSource, "Importe", true));
            this.txtImporte.Location = new System.Drawing.Point(118, 70);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(70, 20);
            this.txtImporte.TabIndex = 20;
            // 
            // dtpFecha
            // 
            this.dtpFecha.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.capDetalleBindingSource, "FechaVencimiento", true));
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(118, 43);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(70, 20);
            this.dtpFecha.TabIndex = 19;
            // 
            // lblCapV
            // 
            this.lblCapV.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.capDetalleBindingSource, "CapID", true));
            this.lblCapV.Location = new System.Drawing.Point(118, 26);
            this.lblCapV.Name = "lblCapV";
            this.lblCapV.Size = new System.Drawing.Size(18, 13);
            this.lblCapV.TabIndex = 18;
            this.lblCapV.Text = "777";
            // 
            // lblFinalizado
            // 
            this.lblFinalizado.Location = new System.Drawing.Point(195, 47);
            this.lblFinalizado.Name = "lblFinalizado";
            this.lblFinalizado.Size = new System.Drawing.Size(51, 13);
            this.lblFinalizado.TabIndex = 17;
            this.lblFinalizado.Text = "Finalizado:";
            // 
            // lblDetalle
            // 
            this.lblDetalle.Location = new System.Drawing.Point(19, 102);
            this.lblDetalle.Name = "lblDetalle";
            this.lblDetalle.Size = new System.Drawing.Size(37, 13);
            this.lblDetalle.TabIndex = 16;
            this.lblDetalle.Text = "Detalle:";
            // 
            // lblImportePago
            // 
            this.lblImportePago.Location = new System.Drawing.Point(194, 73);
            this.lblImportePago.Name = "lblImportePago";
            this.lblImportePago.Size = new System.Drawing.Size(69, 13);
            this.lblImportePago.TabIndex = 15;
            this.lblImportePago.Text = "Importe Pago:";
            // 
            // lblImporte
            // 
            this.lblImporte.Location = new System.Drawing.Point(18, 73);
            this.lblImporte.Name = "lblImporte";
            this.lblImporte.Size = new System.Drawing.Size(42, 13);
            this.lblImporte.TabIndex = 14;
            this.lblImporte.Text = "Importe:";
            // 
            // lblFechaVen
            // 
            this.lblFechaVen.Location = new System.Drawing.Point(17, 43);
            this.lblFechaVen.Name = "lblFechaVen";
            this.lblFechaVen.Size = new System.Drawing.Size(93, 13);
            this.lblFechaVen.TabIndex = 13;
            this.lblFechaVen.Text = "Fecha Vencimiento:";
            // 
            // lblCap
            // 
            this.lblCap.Location = new System.Drawing.Point(18, 24);
            this.lblCap.Name = "lblCap";
            this.lblCap.Size = new System.Drawing.Size(38, 13);
            this.lblCap.TabIndex = 12;
            this.lblCap.Text = "N° Cap:";
            // 
            // frmCapDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 129);
            this.Controls.Add(this.grpDetalle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCapDetalle";
            this.Text = "Cap - Detalle";
            this.Load += new System.EventHandler(this.frmCapDetalle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpDetalle)).EndInit();
            this.grpDetalle.ResumeLayout(false);
            this.grpDetalle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.capDetalleBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource capDetalleBindingSource;
        private DevExpress.XtraEditors.GroupControl grpDetalle;
        private System.Windows.Forms.TextBox txtDetalle;
        private System.Windows.Forms.TextBox txtImportePago;
        private System.Windows.Forms.TextBox txtImporte;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private DevExpress.XtraEditors.LabelControl lblCapV;
        private DevExpress.XtraEditors.LabelControl lblFinalizado;
        private DevExpress.XtraEditors.LabelControl lblDetalle;
        private DevExpress.XtraEditors.LabelControl lblImportePago;
        private DevExpress.XtraEditors.LabelControl lblImporte;
        private DevExpress.XtraEditors.LabelControl lblFechaVen;
        private DevExpress.XtraEditors.LabelControl lblCap;
        public System.Windows.Forms.CheckBox chkFinalizado;
        private System.Windows.Forms.Button btnGrabar;

    }
}