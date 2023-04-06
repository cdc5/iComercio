namespace iComercio.Forms
{
    partial class frmCAP2
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
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label conceptoFondosLabel;
            System.Windows.Forms.Label tipoSolicitudLabel;
            System.Windows.Forms.Label fechaPagoLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCAP2));
            this.grbNuevaSolicitud = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDetalleGasto = new System.Windows.Forms.TextBox();
            this.txtImporteCgp = new System.Windows.Forms.TextBox();
            this.dgvCgp = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScgpImporte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnQuitarConcepto = new System.Windows.Forms.Button();
            this.btnAgregarConceptoGasto = new System.Windows.Forms.Button();
            this.cmbCg = new System.Windows.Forms.ComboBox();
            this.cmbCgp = new System.Windows.Forms.ComboBox();
            this.btnAgregarSolicitud = new System.Windows.Forms.Button();
            this.conceptoFondosComboBox = new System.Windows.Forms.ComboBox();
            this.tipoSolicitudComboBox = new System.Windows.Forms.ComboBox();
            this.fechaPagoDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.grb = new System.Windows.Forms.GroupBox();
            this.dgvCgpSF = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCap = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Empresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comercio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConceptoDeFondo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MedioDePago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conceptoGastosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gastoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            conceptoFondosLabel = new System.Windows.Forms.Label();
            tipoSolicitudLabel = new System.Windows.Forms.Label();
            fechaPagoLabel = new System.Windows.Forms.Label();
            this.grbNuevaSolicitud.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCgp)).BeginInit();
            this.grb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCgpSF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.conceptoGastosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gastoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(275, 78);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(76, 13);
            label3.TabIndex = 33;
            label3.Text = "Importe Gasto:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(275, 28);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(89, 13);
            label2.TabIndex = 27;
            label2.Text = "Concepto Gastos";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(275, 55);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(140, 13);
            label1.TabIndex = 25;
            label1.Text = "Concepto Gastos proveedor";
            // 
            // conceptoFondosLabel
            // 
            conceptoFondosLabel.AutoSize = true;
            conceptoFondosLabel.Location = new System.Drawing.Point(18, 81);
            conceptoFondosLabel.Name = "conceptoFondosLabel";
            conceptoFondosLabel.Size = new System.Drawing.Size(94, 13);
            conceptoFondosLabel.TabIndex = 19;
            conceptoFondosLabel.Text = "Concepto Fondos:";
            // 
            // tipoSolicitudLabel
            // 
            tipoSolicitudLabel.AutoSize = true;
            tipoSolicitudLabel.Location = new System.Drawing.Point(18, 55);
            tipoSolicitudLabel.Name = "tipoSolicitudLabel";
            tipoSolicitudLabel.Size = new System.Drawing.Size(74, 13);
            tipoSolicitudLabel.TabIndex = 18;
            tipoSolicitudLabel.Text = "Tipo Solicitud:";
            // 
            // fechaPagoLabel
            // 
            fechaPagoLabel.AutoSize = true;
            fechaPagoLabel.Location = new System.Drawing.Point(18, 28);
            fechaPagoLabel.Name = "fechaPagoLabel";
            fechaPagoLabel.Size = new System.Drawing.Size(68, 13);
            fechaPagoLabel.TabIndex = 16;
            fechaPagoLabel.Text = "Fecha Pago:";
            // 
            // grbNuevaSolicitud
            // 
            this.grbNuevaSolicitud.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbNuevaSolicitud.Controls.Add(this.label4);
            this.grbNuevaSolicitud.Controls.Add(this.txtDetalleGasto);
            this.grbNuevaSolicitud.Controls.Add(label3);
            this.grbNuevaSolicitud.Controls.Add(this.txtImporteCgp);
            this.grbNuevaSolicitud.Controls.Add(this.dgvCgp);
            this.grbNuevaSolicitud.Controls.Add(this.btnQuitarConcepto);
            this.grbNuevaSolicitud.Controls.Add(this.btnAgregarConceptoGasto);
            this.grbNuevaSolicitud.Controls.Add(label2);
            this.grbNuevaSolicitud.Controls.Add(this.cmbCg);
            this.grbNuevaSolicitud.Controls.Add(label1);
            this.grbNuevaSolicitud.Controls.Add(this.cmbCgp);
            this.grbNuevaSolicitud.Controls.Add(this.btnAgregarSolicitud);
            this.grbNuevaSolicitud.Controls.Add(conceptoFondosLabel);
            this.grbNuevaSolicitud.Controls.Add(this.conceptoFondosComboBox);
            this.grbNuevaSolicitud.Controls.Add(tipoSolicitudLabel);
            this.grbNuevaSolicitud.Controls.Add(this.tipoSolicitudComboBox);
            this.grbNuevaSolicitud.Controls.Add(fechaPagoLabel);
            this.grbNuevaSolicitud.Controls.Add(this.fechaPagoDateTimePicker);
            this.grbNuevaSolicitud.Location = new System.Drawing.Point(12, 208);
            this.grbNuevaSolicitud.Name = "grbNuevaSolicitud";
            this.grbNuevaSolicitud.Size = new System.Drawing.Size(1234, 187);
            this.grbNuevaSolicitud.TabIndex = 2;
            this.grbNuevaSolicitud.TabStop = false;
            this.grbNuevaSolicitud.Text = "Nueva Solicitud";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "Detalle del Gasto:";
            // 
            // txtDetalleGasto
            // 
            this.txtDetalleGasto.Location = new System.Drawing.Point(115, 113);
            this.txtDetalleGasto.Multiline = true;
            this.txtDetalleGasto.Name = "txtDetalleGasto";
            this.txtDetalleGasto.Size = new System.Drawing.Size(525, 66);
            this.txtDetalleGasto.TabIndex = 35;
            // 
            // txtImporteCgp
            // 
            this.txtImporteCgp.Location = new System.Drawing.Point(424, 74);
            this.txtImporteCgp.Name = "txtImporteCgp";
            this.txtImporteCgp.Size = new System.Drawing.Size(153, 20);
            this.txtImporteCgp.TabIndex = 34;
            // 
            // dgvCgp
            // 
            this.dgvCgp.AllowUserToAddRows = false;
            this.dgvCgp.AllowUserToDeleteRows = false;
            this.dgvCgp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCgp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCgp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.ScgpImporte});
            this.dgvCgp.Location = new System.Drawing.Point(649, 19);
            this.dgvCgp.Name = "dgvCgp";
            this.dgvCgp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCgp.Size = new System.Drawing.Size(579, 132);
            this.dgvCgp.TabIndex = 32;
            this.dgvCgp.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCgp_CellContentClick);
            // 
            // Nombre
            // 
            this.Nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Nombre.DataPropertyName = "ConceptoGastosProveedor";
            this.Nombre.HeaderText = "Concepto Gasto Proveedor";
            this.Nombre.Name = "Nombre";
            // 
            // ScgpImporte
            // 
            this.ScgpImporte.DataPropertyName = "Importe";
            this.ScgpImporte.HeaderText = "Importe";
            this.ScgpImporte.Name = "ScgpImporte";
            // 
            // btnQuitarConcepto
            // 
            this.btnQuitarConcepto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitarConcepto.ForeColor = System.Drawing.Color.Black;
            this.btnQuitarConcepto.Location = new System.Drawing.Point(616, 71);
            this.btnQuitarConcepto.Name = "btnQuitarConcepto";
            this.btnQuitarConcepto.Size = new System.Drawing.Size(27, 23);
            this.btnQuitarConcepto.TabIndex = 31;
            this.btnQuitarConcepto.Text = "-";
            this.btnQuitarConcepto.UseVisualStyleBackColor = true;
            this.btnQuitarConcepto.Click += new System.EventHandler(this.btnQuitarConcepto_Click);
            // 
            // btnAgregarConceptoGasto
            // 
            this.btnAgregarConceptoGasto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarConceptoGasto.ForeColor = System.Drawing.Color.Black;
            this.btnAgregarConceptoGasto.Location = new System.Drawing.Point(583, 71);
            this.btnAgregarConceptoGasto.Name = "btnAgregarConceptoGasto";
            this.btnAgregarConceptoGasto.Size = new System.Drawing.Size(27, 23);
            this.btnAgregarConceptoGasto.TabIndex = 30;
            this.btnAgregarConceptoGasto.Text = "+";
            this.btnAgregarConceptoGasto.UseVisualStyleBackColor = true;
            this.btnAgregarConceptoGasto.Click += new System.EventHandler(this.btnAgregarConceptoGasto_Click);
            // 
            // cmbCg
            // 
            this.cmbCg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCg.FormattingEnabled = true;
            this.cmbCg.Location = new System.Drawing.Point(424, 20);
            this.cmbCg.Name = "cmbCg";
            this.cmbCg.Size = new System.Drawing.Size(219, 21);
            this.cmbCg.TabIndex = 28;
            this.cmbCg.SelectedIndexChanged += new System.EventHandler(this.cmbCg_SelectedIndexChanged);
            // 
            // cmbCgp
            // 
            this.cmbCgp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCgp.FormattingEnabled = true;
            this.cmbCgp.Location = new System.Drawing.Point(424, 47);
            this.cmbCgp.Name = "cmbCgp";
            this.cmbCgp.Size = new System.Drawing.Size(219, 21);
            this.cmbCgp.TabIndex = 26;
            this.cmbCgp.SelectedIndexChanged += new System.EventHandler(this.cmbCgp_SelectedIndexChanged);
            // 
            // btnAgregarSolicitud
            // 
            this.btnAgregarSolicitud.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarSolicitud.Location = new System.Drawing.Point(1153, 157);
            this.btnAgregarSolicitud.Name = "btnAgregarSolicitud";
            this.btnAgregarSolicitud.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarSolicitud.TabIndex = 24;
            this.btnAgregarSolicitud.Text = "Agregar";
            this.btnAgregarSolicitud.UseVisualStyleBackColor = true;
            this.btnAgregarSolicitud.Click += new System.EventHandler(this.btnAgregarSolicitud_Click);
            // 
            // conceptoFondosComboBox
            // 
            this.conceptoFondosComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.conceptoFondosComboBox.FormattingEnabled = true;
            this.conceptoFondosComboBox.Location = new System.Drawing.Point(118, 78);
            this.conceptoFondosComboBox.Name = "conceptoFondosComboBox";
            this.conceptoFondosComboBox.Size = new System.Drawing.Size(151, 21);
            this.conceptoFondosComboBox.TabIndex = 22;
            // 
            // tipoSolicitudComboBox
            // 
            this.tipoSolicitudComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipoSolicitudComboBox.FormattingEnabled = true;
            this.tipoSolicitudComboBox.Location = new System.Drawing.Point(118, 52);
            this.tipoSolicitudComboBox.Name = "tipoSolicitudComboBox";
            this.tipoSolicitudComboBox.Size = new System.Drawing.Size(151, 21);
            this.tipoSolicitudComboBox.TabIndex = 20;
            // 
            // fechaPagoDateTimePicker
            // 
            this.fechaPagoDateTimePicker.CustomFormat = "dd/mm/yyyy";
            this.fechaPagoDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechaPagoDateTimePicker.Location = new System.Drawing.Point(119, 22);
            this.fechaPagoDateTimePicker.Name = "fechaPagoDateTimePicker";
            this.fechaPagoDateTimePicker.Size = new System.Drawing.Size(151, 20);
            this.fechaPagoDateTimePicker.TabIndex = 17;
            // 
            // grb
            // 
            this.grb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grb.Controls.Add(this.dgvCgpSF);
            this.grb.Controls.Add(this.dgvCap);
            this.grb.Location = new System.Drawing.Point(12, 12);
            this.grb.Name = "grb";
            this.grb.Size = new System.Drawing.Size(1238, 190);
            this.grb.TabIndex = 1;
            this.grb.TabStop = false;
            this.grb.Text = " ";
            this.grb.Enter += new System.EventHandler(this.grb_Enter);
            // 
            // dgvCgpSF
            // 
            this.dgvCgpSF.AllowUserToAddRows = false;
            this.dgvCgpSF.AllowUserToDeleteRows = false;
            this.dgvCgpSF.AllowUserToResizeRows = false;
            this.dgvCgpSF.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCgpSF.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCgpSF.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dgvCgpSF.Location = new System.Drawing.Point(840, 16);
            this.dgvCgpSF.Name = "dgvCgpSF";
            this.dgvCgpSF.ReadOnly = true;
            this.dgvCgpSF.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCgpSF.Size = new System.Drawing.Size(388, 166);
            this.dgvCgpSF.TabIndex = 33;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "sConceptoGastosProveedor";
            this.dataGridViewTextBoxColumn1.HeaderText = "Concepto Gasto Proveedor";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Importe";
            this.dataGridViewTextBoxColumn2.HeaderText = "Importe";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dgvCap
            // 
            this.dgvCap.AllowUserToAddRows = false;
            this.dgvCap.AllowUserToDeleteRows = false;
            this.dgvCap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.FechaPago,
            this.Importe,
            this.Empresa,
            this.Comercio,
            this.ConceptoDeFondo,
            this.MedioDePago,
            this.Estado});
            this.dgvCap.Location = new System.Drawing.Point(3, 16);
            this.dgvCap.MultiSelect = false;
            this.dgvCap.Name = "dgvCap";
            this.dgvCap.ReadOnly = true;
            this.dgvCap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCap.Size = new System.Drawing.Size(831, 166);
            this.dgvCap.TabIndex = 1;
            this.dgvCap.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCap_CellContentClick);
            this.dgvCap.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCap_CellEnter);
            this.dgvCap.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvCap_DataBindingComplete);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "SolicitudFondoID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 43;
            // 
            // FechaPago
            // 
            this.FechaPago.DataPropertyName = "FechaPagoSF";
            this.FechaPago.FillWeight = 120F;
            this.FechaPago.HeaderText = "Fecha Pago";
            this.FechaPago.Name = "FechaPago";
            this.FechaPago.ReadOnly = true;
            this.FechaPago.Width = 83;
            // 
            // Importe
            // 
            this.Importe.DataPropertyName = "Importe";
            this.Importe.HeaderText = "Importe";
            this.Importe.Name = "Importe";
            this.Importe.ReadOnly = true;
            this.Importe.Width = 67;
            // 
            // Empresa
            // 
            this.Empresa.DataPropertyName = "Empresa";
            this.Empresa.FillWeight = 120F;
            this.Empresa.HeaderText = "Empresa";
            this.Empresa.Name = "Empresa";
            this.Empresa.ReadOnly = true;
            this.Empresa.Width = 73;
            // 
            // Comercio
            // 
            this.Comercio.DataPropertyName = "Comercio";
            this.Comercio.HeaderText = "Comercio";
            this.Comercio.Name = "Comercio";
            this.Comercio.ReadOnly = true;
            this.Comercio.Width = 76;
            // 
            // ConceptoDeFondo
            // 
            this.ConceptoDeFondo.DataPropertyName = "ConceptoFondos";
            this.ConceptoDeFondo.HeaderText = "Concepto De Fondos";
            this.ConceptoDeFondo.Name = "ConceptoDeFondo";
            this.ConceptoDeFondo.ReadOnly = true;
            this.ConceptoDeFondo.Width = 90;
            // 
            // MedioDePago
            // 
            this.MedioDePago.DataPropertyName = "MedioDePago";
            this.MedioDePago.HeaderText = "MedioDePago";
            this.MedioDePago.Name = "MedioDePago";
            this.MedioDePago.ReadOnly = true;
            // 
            // Estado
            // 
            this.Estado.DataPropertyName = "Estado";
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            this.Estado.Width = 65;
            // 
            // conceptoGastosBindingSource
            // 
            this.conceptoGastosBindingSource.DataSource = typeof(iComercio.Models.ConceptoGastos);
            // 
            // gastoBindingSource
            // 
            this.gastoBindingSource.DataSource = typeof(iComercio.Models.Gasto);
            // 
            // frmCAP2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 407);
            this.Controls.Add(this.grbNuevaSolicitud);
            this.Controls.Add(this.grb);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCAP2";
            this.Text = " ";
            this.Load += new System.EventHandler(this.frmCAP_Load);
            this.grbNuevaSolicitud.ResumeLayout(false);
            this.grbNuevaSolicitud.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCgp)).EndInit();
            this.grb.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCgpSF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.conceptoGastosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gastoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grb;
        private System.Windows.Forms.DataGridView dgvCap;
        private System.Windows.Forms.GroupBox grbNuevaSolicitud;
        private System.Windows.Forms.ComboBox conceptoFondosComboBox;
        private System.Windows.Forms.ComboBox tipoSolicitudComboBox;
        private System.Windows.Forms.DateTimePicker fechaPagoDateTimePicker;
        private System.Windows.Forms.Button btnAgregarSolicitud;
        private System.Windows.Forms.ComboBox cmbCgp;
        private System.Windows.Forms.BindingSource conceptoGastosBindingSource;
        private System.Windows.Forms.BindingSource gastoBindingSource;
        private System.Windows.Forms.ComboBox cmbCg;
        private System.Windows.Forms.Button btnQuitarConcepto;
        private System.Windows.Forms.Button btnAgregarConceptoGasto;
        private System.Windows.Forms.DataGridView dgvCgp;
        private System.Windows.Forms.TextBox txtImporteCgp;
        private System.Windows.Forms.DataGridView dgvCgpSF;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScgpImporte;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn Importe;
        private System.Windows.Forms.DataGridViewTextBoxColumn Empresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comercio;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConceptoDeFondo;
        private System.Windows.Forms.DataGridViewTextBoxColumn MedioDePago;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDetalleGasto;
    }
}