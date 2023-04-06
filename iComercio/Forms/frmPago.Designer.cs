namespace iComercio.Forms
{
    partial class frmPago
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPago));
            this.btnGrabar = new System.Windows.Forms.Button();
            this.PanelDetalle = new DevExpress.XtraEditors.PanelControl();
            this.grpPago = new DevExpress.XtraEditors.GroupControl();
            this.lblEstado = new System.Windows.Forms.Label();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.cmbSolfon = new System.Windows.Forms.ComboBox();
            this.lblImporte = new System.Windows.Forms.Label();
            this.dtpFechaPago = new System.Windows.Forms.DateTimePicker();
            this.lblFecha = new System.Windows.Forms.Label();
            this.pagoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblFFCAP = new System.Windows.Forms.Label();
            this.cmbFFCap = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblEstadoV = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PanelDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpPago)).BeginInit();
            this.grpPago.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pagoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGrabar
            // 
            this.btnGrabar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGrabar.Location = new System.Drawing.Point(564, 323);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 3;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // PanelDetalle
            // 
            this.PanelDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelDetalle.Location = new System.Drawing.Point(12, 144);
            this.PanelDetalle.Name = "PanelDetalle";
            this.PanelDetalle.Size = new System.Drawing.Size(627, 173);
            this.PanelDetalle.TabIndex = 2;
            this.PanelDetalle.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelDetalle_Paint);
            // 
            // grpPago
            // 
            this.grpPago.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPago.Controls.Add(this.lblEstadoV);
            this.grpPago.Controls.Add(this.label2);
            this.grpPago.Controls.Add(this.lblFFCAP);
            this.grpPago.Controls.Add(this.cmbFFCap);
            this.grpPago.Controls.Add(this.lblEstado);
            this.grpPago.Controls.Add(this.txtImporte);
            this.grpPago.Controls.Add(this.cmbSolfon);
            this.grpPago.Controls.Add(this.lblImporte);
            this.grpPago.Controls.Add(this.dtpFechaPago);
            this.grpPago.Controls.Add(this.lblFecha);
            this.grpPago.Location = new System.Drawing.Point(12, 12);
            this.grpPago.Name = "grpPago";
            this.grpPago.Size = new System.Drawing.Size(627, 126);
            this.grpPago.TabIndex = 0;
            this.grpPago.Text = "Pago";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.BackColor = System.Drawing.Color.Transparent;
            this.lblEstado.Location = new System.Drawing.Point(302, 35);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(43, 13);
            this.lblEstado.TabIndex = 6;
            this.lblEstado.Text = "Estado:";
            // 
            // txtImporte
            // 
            this.txtImporte.Location = new System.Drawing.Point(191, 32);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(87, 20);
            this.txtImporte.TabIndex = 5;
            this.txtImporte.Tag = "D";
            // 
            // cmbSolfon
            // 
            this.cmbSolfon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSolfon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSolfon.FormattingEnabled = true;
            this.cmbSolfon.Location = new System.Drawing.Point(111, 62);
            this.cmbSolfon.Name = "cmbSolfon";
            this.cmbSolfon.Size = new System.Drawing.Size(511, 21);
            this.cmbSolfon.TabIndex = 4;
            // 
            // lblImporte
            // 
            this.lblImporte.AutoSize = true;
            this.lblImporte.BackColor = System.Drawing.Color.Transparent;
            this.lblImporte.Location = new System.Drawing.Point(144, 35);
            this.lblImporte.Name = "lblImporte";
            this.lblImporte.Size = new System.Drawing.Size(45, 13);
            this.lblImporte.TabIndex = 2;
            this.lblImporte.Text = "Importe:";
            // 
            // dtpFechaPago
            // 
            this.dtpFechaPago.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaPago.Location = new System.Drawing.Point(54, 32);
            this.dtpFechaPago.Name = "dtpFechaPago";
            this.dtpFechaPago.Size = new System.Drawing.Size(83, 20);
            this.dtpFechaPago.TabIndex = 1;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.BackColor = System.Drawing.Color.Transparent;
            this.lblFecha.Location = new System.Drawing.Point(7, 35);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(40, 13);
            this.lblFecha.TabIndex = 0;
            this.lblFecha.Text = "Fecha:";
            // 
            // pagoBindingSource
            // 
            this.pagoBindingSource.DataSource = typeof(iComercio.Models.Pago);
            // 
            // lblFFCAP
            // 
            this.lblFFCAP.AutoSize = true;
            this.lblFFCAP.BackColor = System.Drawing.Color.Transparent;
            this.lblFFCAP.Location = new System.Drawing.Point(7, 93);
            this.lblFFCAP.Name = "lblFFCAP";
            this.lblFFCAP.Size = new System.Drawing.Size(52, 13);
            this.lblFFCAP.TabIndex = 8;
            this.lblFFCAP.Text = "FF o CAP";
            // 
            // cmbFFCap
            // 
            this.cmbFFCap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFFCap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFFCap.FormattingEnabled = true;
            this.cmbFFCap.Location = new System.Drawing.Point(111, 90);
            this.cmbFFCap.Name = "cmbFFCap";
            this.cmbFFCap.Size = new System.Drawing.Size(511, 21);
            this.cmbFFCap.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(7, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Solicitud de Fondo:";
            // 
            // lblEstadoV
            // 
            this.lblEstadoV.AutoSize = true;
            this.lblEstadoV.BackColor = System.Drawing.Color.Transparent;
            this.lblEstadoV.Location = new System.Drawing.Point(351, 35);
            this.lblEstadoV.Name = "lblEstadoV";
            this.lblEstadoV.Size = new System.Drawing.Size(58, 13);
            this.lblEstadoV.TabIndex = 11;
            this.lblEstadoV.Text = "ESTADOV";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.Location = new System.Drawing.Point(12, 323);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 4;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // frmPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(651, 353);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.PanelDetalle);
            this.Controls.Add(this.grpPago);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPago";
            this.Text = "Pagos";
            this.Load += new System.EventHandler(this.frmPago_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PanelDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpPago)).EndInit();
            this.grpPago.ResumeLayout(false);
            this.grpPago.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pagoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource pagoBindingSource;
        private DevExpress.XtraEditors.GroupControl grpPago;
        private DevExpress.XtraEditors.PanelControl PanelDetalle;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.TextBox txtImporte;
        private System.Windows.Forms.ComboBox cmbSolfon;
        private System.Windows.Forms.Label lblImporte;
        private System.Windows.Forms.DateTimePicker dtpFechaPago;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Label lblEstadoV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblFFCAP;
        private System.Windows.Forms.ComboBox cmbFFCap;
        private System.Windows.Forms.Button btnEliminar;
    }
}