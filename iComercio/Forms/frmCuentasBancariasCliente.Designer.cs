namespace iComercio.Forms
{
    partial class frmCuentasBancariasCliente
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
            System.Windows.Forms.Label documentoLabel1;
            System.Windows.Forms.Label nombreLabel;
            System.Windows.Forms.Label nombreCompletoLabel;
            System.Windows.Forms.Label numCuentaBancariaLabel;
            System.Windows.Forms.Label nombreLabel1;
            System.Windows.Forms.Label cBULabel;
            System.Windows.Forms.Label descripcionLabel;
            System.Windows.Forms.Label nombreLabel2;
            System.Windows.Forms.Label fechaAltaLabel;
            System.Windows.Forms.Label notasLabel;
            System.Windows.Forms.Label aliasLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCuentasBancariasCliente));
            this.grpCliente = new DevExpress.XtraEditors.GroupControl();
            this.nombreCompletoTextBox = new System.Windows.Forms.TextBox();
            this.clienteBs = new System.Windows.Forms.BindingSource(this.components);
            this.nombreTextBox = new System.Windows.Forms.TextBox();
            this.documentoTextBox = new System.Windows.Forms.TextBox();
            this.cbcbs = new System.Windows.Forms.BindingSource(this.components);
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnModificarCuenta = new System.Windows.Forms.Button();
            this.btnNueva = new System.Windows.Forms.Button();
            this.btnSeleccionarCuenta = new System.Windows.Forms.Button();
            this.btnAgregarCuenta = new System.Windows.Forms.Button();
            this.btnEliminarCuenta = new System.Windows.Forms.Button();
            this.aliasTextBox = new System.Windows.Forms.TextBox();
            this.notasTextBox = new System.Windows.Forms.TextBox();
            this.fechaAltaDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.descripcionTextBox = new System.Windows.Forms.TextBox();
            this.cbuTextBox = new System.Windows.Forms.TextBox();
            this.BancoComboBox = new System.Windows.Forms.ComboBox();
            this.numCuentaBancariaTextBox = new System.Windows.Forms.TextBox();
            this.lbcbc = new System.Windows.Forms.ListBox();
            this.cuentaBancariaClienteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            documentoLabel1 = new System.Windows.Forms.Label();
            nombreLabel = new System.Windows.Forms.Label();
            nombreCompletoLabel = new System.Windows.Forms.Label();
            numCuentaBancariaLabel = new System.Windows.Forms.Label();
            nombreLabel1 = new System.Windows.Forms.Label();
            cBULabel = new System.Windows.Forms.Label();
            descripcionLabel = new System.Windows.Forms.Label();
            nombreLabel2 = new System.Windows.Forms.Label();
            fechaAltaLabel = new System.Windows.Forms.Label();
            notasLabel = new System.Windows.Forms.Label();
            aliasLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grpCliente)).BeginInit();
            this.grpCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clienteBs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbcbs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cuentaBancariaClienteBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // documentoLabel1
            // 
            documentoLabel1.AutoSize = true;
            documentoLabel1.Location = new System.Drawing.Point(186, 32);
            documentoLabel1.Name = "documentoLabel1";
            documentoLabel1.Size = new System.Drawing.Size(65, 13);
            documentoLabel1.TabIndex = 3;
            documentoLabel1.Text = "Documento:";
            // 
            // nombreLabel
            // 
            nombreLabel.AutoSize = true;
            nombreLabel.Location = new System.Drawing.Point(14, 32);
            nombreLabel.Name = "nombreLabel";
            nombreLabel.Size = new System.Drawing.Size(86, 13);
            nombreLabel.TabIndex = 4;
            nombreLabel.Text = "Tipo Documento";
            // 
            // nombreCompletoLabel
            // 
            nombreCompletoLabel.AutoSize = true;
            nombreCompletoLabel.Location = new System.Drawing.Point(313, 32);
            nombreCompletoLabel.Name = "nombreCompletoLabel";
            nombreCompletoLabel.Size = new System.Drawing.Size(94, 13);
            nombreCompletoLabel.TabIndex = 5;
            nombreCompletoLabel.Text = "Nombre Completo:";
            // 
            // numCuentaBancariaLabel
            // 
            numCuentaBancariaLabel.AutoSize = true;
            numCuentaBancariaLabel.Location = new System.Drawing.Point(249, 30);
            numCuentaBancariaLabel.Name = "numCuentaBancariaLabel";
            numCuentaBancariaLabel.Size = new System.Drawing.Size(22, 13);
            numCuentaBancariaLabel.TabIndex = 1;
            numCuentaBancariaLabel.Text = "N°:";
            // 
            // nombreLabel1
            // 
            nombreLabel1.AutoSize = true;
            nombreLabel1.Location = new System.Drawing.Point(249, 114);
            nombreLabel1.Name = "nombreLabel1";
            nombreLabel1.Size = new System.Drawing.Size(41, 13);
            nombreLabel1.TabIndex = 3;
            nombreLabel1.Text = "Banco:";
            // 
            // cBULabel
            // 
            cBULabel.AutoSize = true;
            cBULabel.Location = new System.Drawing.Point(249, 61);
            cBULabel.Name = "cBULabel";
            cBULabel.Size = new System.Drawing.Size(32, 13);
            cBULabel.TabIndex = 5;
            cBULabel.Text = "CBU:";
            // 
            // descripcionLabel
            // 
            descripcionLabel.AutoSize = true;
            descripcionLabel.Location = new System.Drawing.Point(249, 212);
            descripcionLabel.Name = "descripcionLabel";
            descripcionLabel.Size = new System.Drawing.Size(66, 13);
            descripcionLabel.TabIndex = 7;
            descripcionLabel.Text = "Descripcion:";
            // 
            // nombreLabel2
            // 
            nombreLabel2.AutoSize = true;
            nombreLabel2.Location = new System.Drawing.Point(249, 180);
            nombreLabel2.Name = "nombreLabel2";
            nombreLabel2.Size = new System.Drawing.Size(43, 13);
            nombreLabel2.TabIndex = 9;
            nombreLabel2.Text = "Estado:";
            // 
            // fechaAltaLabel
            // 
            fechaAltaLabel.AutoSize = true;
            fechaAltaLabel.Location = new System.Drawing.Point(249, 148);
            fechaAltaLabel.Name = "fechaAltaLabel";
            fechaAltaLabel.Size = new System.Drawing.Size(61, 13);
            fechaAltaLabel.TabIndex = 11;
            fechaAltaLabel.Text = "Fecha Alta:";
            // 
            // notasLabel
            // 
            notasLabel.AutoSize = true;
            notasLabel.Location = new System.Drawing.Point(249, 243);
            notasLabel.Name = "notasLabel";
            notasLabel.Size = new System.Drawing.Size(38, 13);
            notasLabel.TabIndex = 13;
            notasLabel.Text = "Notas:";
            // 
            // aliasLabel
            // 
            aliasLabel.AutoSize = true;
            aliasLabel.Location = new System.Drawing.Point(249, 87);
            aliasLabel.Name = "aliasLabel";
            aliasLabel.Size = new System.Drawing.Size(32, 13);
            aliasLabel.TabIndex = 15;
            aliasLabel.Text = "Alias:";
            // 
            // grpCliente
            // 
            this.grpCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpCliente.Controls.Add(nombreCompletoLabel);
            this.grpCliente.Controls.Add(this.nombreCompletoTextBox);
            this.grpCliente.Controls.Add(nombreLabel);
            this.grpCliente.Controls.Add(this.nombreTextBox);
            this.grpCliente.Controls.Add(documentoLabel1);
            this.grpCliente.Controls.Add(this.documentoTextBox);
            this.grpCliente.Location = new System.Drawing.Point(13, 13);
            this.grpCliente.Name = "grpCliente";
            this.grpCliente.Size = new System.Drawing.Size(619, 78);
            this.grpCliente.TabIndex = 0;
            this.grpCliente.Text = "Cliente";
            // 
            // nombreCompletoTextBox
            // 
            this.nombreCompletoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clienteBs, "NombreCompleto", true));
            this.nombreCompletoTextBox.Location = new System.Drawing.Point(316, 48);
            this.nombreCompletoTextBox.Name = "nombreCompletoTextBox";
            this.nombreCompletoTextBox.Size = new System.Drawing.Size(292, 20);
            this.nombreCompletoTextBox.TabIndex = 2;
            // 
            // clienteBs
            // 
            this.clienteBs.DataSource = typeof(iComercio.Models.Cliente);
            // 
            // nombreTextBox
            // 
            this.nombreTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clienteBs, "TipoDocumento.Nombre", true));
            this.nombreTextBox.Location = new System.Drawing.Point(17, 48);
            this.nombreTextBox.Name = "nombreTextBox";
            this.nombreTextBox.Size = new System.Drawing.Size(166, 20);
            this.nombreTextBox.TabIndex = 0;
            // 
            // documentoTextBox
            // 
            this.documentoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clienteBs, "Documento", true));
            this.documentoTextBox.Location = new System.Drawing.Point(189, 48);
            this.documentoTextBox.Name = "documentoTextBox";
            this.documentoTextBox.Size = new System.Drawing.Size(120, 20);
            this.documentoTextBox.TabIndex = 1;
            // 
            // cbcbs
            // 
            this.cbcbs.DataSource = typeof(iComercio.Models.CuentaBancariaCliente);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.btnModificarCuenta);
            this.groupControl1.Controls.Add(this.btnNueva);
            this.groupControl1.Controls.Add(this.btnSeleccionarCuenta);
            this.groupControl1.Controls.Add(this.btnAgregarCuenta);
            this.groupControl1.Controls.Add(this.btnEliminarCuenta);
            this.groupControl1.Controls.Add(aliasLabel);
            this.groupControl1.Controls.Add(this.aliasTextBox);
            this.groupControl1.Controls.Add(notasLabel);
            this.groupControl1.Controls.Add(this.notasTextBox);
            this.groupControl1.Controls.Add(fechaAltaLabel);
            this.groupControl1.Controls.Add(this.fechaAltaDateTimePicker);
            this.groupControl1.Controls.Add(nombreLabel2);
            this.groupControl1.Controls.Add(this.cmbEstado);
            this.groupControl1.Controls.Add(descripcionLabel);
            this.groupControl1.Controls.Add(this.descripcionTextBox);
            this.groupControl1.Controls.Add(cBULabel);
            this.groupControl1.Controls.Add(this.cbuTextBox);
            this.groupControl1.Controls.Add(nombreLabel1);
            this.groupControl1.Controls.Add(this.BancoComboBox);
            this.groupControl1.Controls.Add(numCuentaBancariaLabel);
            this.groupControl1.Controls.Add(this.numCuentaBancariaTextBox);
            this.groupControl1.Controls.Add(this.lbcbc);
            this.groupControl1.Location = new System.Drawing.Point(12, 97);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(620, 420);
            this.groupControl1.TabIndex = 7;
            this.groupControl1.Text = "Cuentas";
            // 
            // btnModificarCuenta
            // 
            this.btnModificarCuenta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModificarCuenta.Enabled = false;
            this.btnModificarCuenta.Image = global::iComercio.Properties.Resources._285638___pencil1;
            this.btnModificarCuenta.Location = new System.Drawing.Point(521, 346);
            this.btnModificarCuenta.Name = "btnModificarCuenta";
            this.btnModificarCuenta.Size = new System.Drawing.Size(38, 33);
            this.btnModificarCuenta.TabIndex = 17;
            this.btnModificarCuenta.UseVisualStyleBackColor = true;
            this.btnModificarCuenta.Click += new System.EventHandler(this.btnModificarCuenta_Click);
            // 
            // btnNueva
            // 
            this.btnNueva.Location = new System.Drawing.Point(508, 317);
            this.btnNueva.Name = "btnNueva";
            this.btnNueva.Size = new System.Drawing.Size(95, 23);
            this.btnNueva.TabIndex = 16;
            this.btnNueva.Text = "Nueva Cuenta";
            this.btnNueva.UseVisualStyleBackColor = true;
            this.btnNueva.Click += new System.EventHandler(this.btnNueva_Click);
            // 
            // btnSeleccionarCuenta
            // 
            this.btnSeleccionarCuenta.Location = new System.Drawing.Point(6, 386);
            this.btnSeleccionarCuenta.Name = "btnSeleccionarCuenta";
            this.btnSeleccionarCuenta.Size = new System.Drawing.Size(237, 23);
            this.btnSeleccionarCuenta.TabIndex = 14;
            this.btnSeleccionarCuenta.Text = "Seleccionar Cuenta";
            this.btnSeleccionarCuenta.UseVisualStyleBackColor = true;
            this.btnSeleccionarCuenta.Click += new System.EventHandler(this.btnSeleccionarCuenta_Click);
            // 
            // btnAgregarCuenta
            // 
            this.btnAgregarCuenta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarCuenta.Enabled = false;
            this.btnAgregarCuenta.Image = global::iComercio.Properties.Resources._1646001___add_create_new_plus;
            this.btnAgregarCuenta.Location = new System.Drawing.Point(565, 346);
            this.btnAgregarCuenta.Name = "btnAgregarCuenta";
            this.btnAgregarCuenta.Size = new System.Drawing.Size(38, 33);
            this.btnAgregarCuenta.TabIndex = 12;
            this.btnAgregarCuenta.UseVisualStyleBackColor = true;
            this.btnAgregarCuenta.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnEliminarCuenta
            // 
            this.btnEliminarCuenta.Enabled = false;
            this.btnEliminarCuenta.Image = global::iComercio.Properties.Resources._1646012___cancel_delete_error_exit_remov;
            this.btnEliminarCuenta.Location = new System.Drawing.Point(249, 346);
            this.btnEliminarCuenta.Name = "btnEliminarCuenta";
            this.btnEliminarCuenta.Size = new System.Drawing.Size(33, 33);
            this.btnEliminarCuenta.TabIndex = 13;
            this.btnEliminarCuenta.UseVisualStyleBackColor = true;
            this.btnEliminarCuenta.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // aliasTextBox
            // 
            this.aliasTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.aliasTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cbcbs, "Alias", true));
            this.aliasTextBox.Location = new System.Drawing.Point(360, 80);
            this.aliasTextBox.Name = "aliasTextBox";
            this.aliasTextBox.Size = new System.Drawing.Size(243, 20);
            this.aliasTextBox.TabIndex = 6;
            // 
            // notasTextBox
            // 
            this.notasTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.notasTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cbcbs, "Notas", true));
            this.notasTextBox.Location = new System.Drawing.Point(360, 240);
            this.notasTextBox.Multiline = true;
            this.notasTextBox.Name = "notasTextBox";
            this.notasTextBox.Size = new System.Drawing.Size(243, 73);
            this.notasTextBox.TabIndex = 11;
            // 
            // fechaAltaDateTimePicker
            // 
            this.fechaAltaDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.cbcbs, "FechaAlta", true));
            this.fechaAltaDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechaAltaDateTimePicker.Location = new System.Drawing.Point(360, 142);
            this.fechaAltaDateTimePicker.Name = "fechaAltaDateTimePicker";
            this.fechaAltaDateTimePicker.Size = new System.Drawing.Size(95, 20);
            this.fechaAltaDateTimePicker.TabIndex = 8;
            // 
            // cmbEstado
            // 
            this.cmbEstado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(360, 177);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(243, 21);
            this.cmbEstado.TabIndex = 9;
            this.cmbEstado.SelectedIndexChanged += new System.EventHandler(this.cmbEstado_SelectedIndexChanged);
            // 
            // descripcionTextBox
            // 
            this.descripcionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.descripcionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cbcbs, "Descripcion", true));
            this.descripcionTextBox.Location = new System.Drawing.Point(360, 209);
            this.descripcionTextBox.Name = "descripcionTextBox";
            this.descripcionTextBox.Size = new System.Drawing.Size(243, 20);
            this.descripcionTextBox.TabIndex = 10;
            // 
            // cbuTextBox
            // 
            this.cbuTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbuTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cbcbs, "CBU", true));
            this.cbuTextBox.Location = new System.Drawing.Point(360, 54);
            this.cbuTextBox.Name = "cbuTextBox";
            this.cbuTextBox.Size = new System.Drawing.Size(243, 20);
            this.cbuTextBox.TabIndex = 5;
            // 
            // BancoComboBox
            // 
            this.BancoComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BancoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BancoComboBox.FormattingEnabled = true;
            this.BancoComboBox.Location = new System.Drawing.Point(360, 111);
            this.BancoComboBox.Name = "BancoComboBox";
            this.BancoComboBox.Size = new System.Drawing.Size(243, 21);
            this.BancoComboBox.TabIndex = 7;
            this.BancoComboBox.SelectedIndexChanged += new System.EventHandler(this.BancoComboBox_SelectedIndexChanged);
            // 
            // numCuentaBancariaTextBox
            // 
            this.numCuentaBancariaTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numCuentaBancariaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cbcbs, "NumCuentaBancaria", true));
            this.numCuentaBancariaTextBox.Location = new System.Drawing.Point(360, 27);
            this.numCuentaBancariaTextBox.Name = "numCuentaBancariaTextBox";
            this.numCuentaBancariaTextBox.Size = new System.Drawing.Size(243, 20);
            this.numCuentaBancariaTextBox.TabIndex = 4;
            // 
            // lbcbc
            // 
            this.lbcbc.DataSource = this.cuentaBancariaClienteBindingSource;
            this.lbcbc.DisplayMember = "sCuentaBancaria";
            this.lbcbc.FormattingEnabled = true;
            this.lbcbc.Location = new System.Drawing.Point(5, 24);
            this.lbcbc.Name = "lbcbc";
            this.lbcbc.Size = new System.Drawing.Size(238, 355);
            this.lbcbc.TabIndex = 3;
            this.lbcbc.ValueMember = "NumCuentaBancaria";
            this.lbcbc.SelectedIndexChanged += new System.EventHandler(this.lbcbc_SelectedIndexChanged);
            // 
            // cuentaBancariaClienteBindingSource
            // 
            this.cuentaBancariaClienteBindingSource.DataSource = typeof(iComercio.Models.CuentaBancariaCliente);
            // 
            // frmCuentasBancariasCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 529);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.grpCliente);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCuentasBancariasCliente";
            this.Text = "Cuentas Bancarias Cliente";
            this.Load += new System.EventHandler(this.frmCuentasBancariasCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpCliente)).EndInit();
            this.grpCliente.ResumeLayout(false);
            this.grpCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clienteBs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbcbs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cuentaBancariaClienteBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grpCliente;
        private System.Windows.Forms.TextBox nombreTextBox;
        private System.Windows.Forms.BindingSource cbcbs;
        private System.Windows.Forms.TextBox documentoTextBox;
        private System.Windows.Forms.TextBox nombreCompletoTextBox;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.TextBox aliasTextBox;
        private System.Windows.Forms.TextBox notasTextBox;
        private System.Windows.Forms.DateTimePicker fechaAltaDateTimePicker;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.TextBox descripcionTextBox;
        private System.Windows.Forms.TextBox cbuTextBox;
        private System.Windows.Forms.ComboBox BancoComboBox;
        private System.Windows.Forms.TextBox numCuentaBancariaTextBox;
        private System.Windows.Forms.ListBox lbcbc;
        private System.Windows.Forms.BindingSource cuentaBancariaClienteBindingSource;
        private System.Windows.Forms.BindingSource clienteBs;
        private System.Windows.Forms.Button btnAgregarCuenta;
        private System.Windows.Forms.Button btnEliminarCuenta;
        private System.Windows.Forms.Button btnSeleccionarCuenta;
        private System.Windows.Forms.Button btnNueva;
        private System.Windows.Forms.Button btnModificarCuenta;
    }
}