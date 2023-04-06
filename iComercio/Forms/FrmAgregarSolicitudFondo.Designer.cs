namespace iComercio.Forms
{
    partial class FrmAgregarSolicitudFondo
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
            System.Windows.Forms.Label importeLabel;
            System.Windows.Forms.Label conceptoFondosLabel;
            System.Windows.Forms.Label tipoSolicitudLabel;
            System.Windows.Forms.Label fechaPagoLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAgregarSolicitudFondo));
            this.cmdCancelar = new System.Windows.Forms.Button();
            this.cmdAceptar = new System.Windows.Forms.Button();
            this.grbSolicitarFondos = new System.Windows.Forms.GroupBox();
            this.importeTextBox = new System.Windows.Forms.TextBox();
            this.nuevaSolicitudFondoViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.conceptoFondosComboBox = new System.Windows.Forms.ComboBox();
            this.tipoSolicitudComboBox = new System.Windows.Forms.ComboBox();
            this.fechaPagoDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.nuevaSolicitudFondoViewModelBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            importeLabel = new System.Windows.Forms.Label();
            conceptoFondosLabel = new System.Windows.Forms.Label();
            tipoSolicitudLabel = new System.Windows.Forms.Label();
            fechaPagoLabel = new System.Windows.Forms.Label();
            this.grbSolicitarFondos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuevaSolicitudFondoViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuevaSolicitudFondoViewModelBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // importeLabel
            // 
            importeLabel.AutoSize = true;
            importeLabel.Location = new System.Drawing.Point(21, 39);
            importeLabel.Name = "importeLabel";
            importeLabel.Size = new System.Drawing.Size(45, 13);
            importeLabel.TabIndex = 14;
            importeLabel.Text = "Importe:";
            // 
            // conceptoFondosLabel
            // 
            conceptoFondosLabel.AutoSize = true;
            conceptoFondosLabel.Location = new System.Drawing.Point(21, 122);
            conceptoFondosLabel.Name = "conceptoFondosLabel";
            conceptoFondosLabel.Size = new System.Drawing.Size(94, 13);
            conceptoFondosLabel.TabIndex = 13;
            conceptoFondosLabel.Text = "Concepto Fondos:";
            // 
            // tipoSolicitudLabel
            // 
            tipoSolicitudLabel.AutoSize = true;
            tipoSolicitudLabel.Location = new System.Drawing.Point(21, 95);
            tipoSolicitudLabel.Name = "tipoSolicitudLabel";
            tipoSolicitudLabel.Size = new System.Drawing.Size(74, 13);
            tipoSolicitudLabel.TabIndex = 12;
            tipoSolicitudLabel.Text = "Tipo Solicitud:";
            // 
            // fechaPagoLabel
            // 
            fechaPagoLabel.AutoSize = true;
            fechaPagoLabel.Location = new System.Drawing.Point(20, 68);
            fechaPagoLabel.Name = "fechaPagoLabel";
            fechaPagoLabel.Size = new System.Drawing.Size(68, 13);
            fechaPagoLabel.TabIndex = 2;
            fechaPagoLabel.Text = "Fecha Pago:";
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancelar.Location = new System.Drawing.Point(230, 175);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(69, 25);
            this.cmdCancelar.TabIndex = 23;
            this.cmdCancelar.Text = "Cancelar";
            this.cmdCancelar.UseVisualStyleBackColor = true;
            this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click);
            // 
            // cmdAceptar
            // 
            this.cmdAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdAceptar.Location = new System.Drawing.Point(148, 175);
            this.cmdAceptar.Name = "cmdAceptar";
            this.cmdAceptar.Size = new System.Drawing.Size(69, 25);
            this.cmdAceptar.TabIndex = 22;
            this.cmdAceptar.Text = "Aceptar";
            this.cmdAceptar.UseVisualStyleBackColor = true;
            this.cmdAceptar.Click += new System.EventHandler(this.cmdAceptar_Click);
            // 
            // grbSolicitarFondos
            // 
            this.grbSolicitarFondos.Controls.Add(importeLabel);
            this.grbSolicitarFondos.Controls.Add(this.importeTextBox);
            this.grbSolicitarFondos.Controls.Add(conceptoFondosLabel);
            this.grbSolicitarFondos.Controls.Add(this.conceptoFondosComboBox);
            this.grbSolicitarFondos.Controls.Add(tipoSolicitudLabel);
            this.grbSolicitarFondos.Controls.Add(this.tipoSolicitudComboBox);
            this.grbSolicitarFondos.Controls.Add(fechaPagoLabel);
            this.grbSolicitarFondos.Controls.Add(this.fechaPagoDateTimePicker);
            this.grbSolicitarFondos.Location = new System.Drawing.Point(12, 12);
            this.grbSolicitarFondos.Name = "grbSolicitarFondos";
            this.grbSolicitarFondos.Size = new System.Drawing.Size(294, 156);
            this.grbSolicitarFondos.TabIndex = 21;
            this.grbSolicitarFondos.TabStop = false;
            this.grbSolicitarFondos.Text = "Nueva Solicitud de Fondos";
            // 
            // importeTextBox
            // 
            this.importeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.nuevaSolicitudFondoViewModelBindingSource, "importe", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "C2"));
            this.importeTextBox.Location = new System.Drawing.Point(121, 36);
            this.importeTextBox.Name = "importeTextBox";
            this.importeTextBox.Size = new System.Drawing.Size(166, 20);
            this.importeTextBox.TabIndex = 15;
            this.importeTextBox.TextChanged += new System.EventHandler(this.importeTextBox_TextChanged);
            this.importeTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.importeTextBox_KeyPress);
            // 
            // nuevaSolicitudFondoViewModelBindingSource
            // 
            this.nuevaSolicitudFondoViewModelBindingSource.DataSource = typeof(iComercio.ViewModels.NuevaSolicitudFondoViewModel);
            // 
            // conceptoFondosComboBox
            // 
            this.conceptoFondosComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.nuevaSolicitudFondoViewModelBindingSource, "ConceptoFondos", true));
            this.conceptoFondosComboBox.FormattingEnabled = true;
            this.conceptoFondosComboBox.Location = new System.Drawing.Point(121, 119);
            this.conceptoFondosComboBox.Name = "conceptoFondosComboBox";
            this.conceptoFondosComboBox.Size = new System.Drawing.Size(166, 21);
            this.conceptoFondosComboBox.TabIndex = 14;
            // 
            // tipoSolicitudComboBox
            // 
            this.tipoSolicitudComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.nuevaSolicitudFondoViewModelBindingSource, "TipoSolicitud", true));
            this.tipoSolicitudComboBox.FormattingEnabled = true;
            this.tipoSolicitudComboBox.Location = new System.Drawing.Point(121, 92);
            this.tipoSolicitudComboBox.Name = "tipoSolicitudComboBox";
            this.tipoSolicitudComboBox.Size = new System.Drawing.Size(166, 21);
            this.tipoSolicitudComboBox.TabIndex = 13;
            this.tipoSolicitudComboBox.SelectedIndexChanged += new System.EventHandler(this.tipoSolicitudComboBox_SelectedIndexChanged);
            // 
            // fechaPagoDateTimePicker
            // 
            this.fechaPagoDateTimePicker.CustomFormat = "dd/mm/yyyy";
            this.fechaPagoDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.nuevaSolicitudFondoViewModelBindingSource, "FechaPago", true));
            this.fechaPagoDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechaPagoDateTimePicker.Location = new System.Drawing.Point(121, 62);
            this.fechaPagoDateTimePicker.Name = "fechaPagoDateTimePicker";
            this.fechaPagoDateTimePicker.Size = new System.Drawing.Size(166, 20);
            this.fechaPagoDateTimePicker.TabIndex = 3;
            // 
            // nuevaSolicitudFondoViewModelBindingSource1
            // 
            this.nuevaSolicitudFondoViewModelBindingSource1.DataSource = typeof(iComercio.ViewModels.NuevaSolicitudFondoViewModel);
            // 
            // FrmAgregarSolicitudFondo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 212);
            this.Controls.Add(this.cmdCancelar);
            this.Controls.Add(this.cmdAceptar);
            this.Controls.Add(this.grbSolicitarFondos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmAgregarSolicitudFondo";
            this.Text = "Nueva Solicitud de Fondos";
            this.Load += new System.EventHandler(this.FrmAgregarSolicitudFondo_Load);
            this.grbSolicitarFondos.ResumeLayout(false);
            this.grbSolicitarFondos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuevaSolicitudFondoViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuevaSolicitudFondoViewModelBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource nuevaSolicitudFondoViewModelBindingSource;
        private System.Windows.Forms.GroupBox grbSolicitarFondos;
        private System.Windows.Forms.DateTimePicker fechaPagoDateTimePicker;
        private System.Windows.Forms.ComboBox conceptoFondosComboBox;
        private System.Windows.Forms.ComboBox tipoSolicitudComboBox;
        private System.Windows.Forms.TextBox importeTextBox;
        private System.Windows.Forms.Button cmdAceptar;
        private System.Windows.Forms.Button cmdCancelar;
        private System.Windows.Forms.BindingSource nuevaSolicitudFondoViewModelBindingSource1;
    }
}