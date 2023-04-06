namespace iComercio.Forms
{
    partial class frmABMProveedores
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
            System.Windows.Forms.Label web1Label;
            System.Windows.Forms.Label mail2Label;
            System.Windows.Forms.Label mail1Label;
            System.Windows.Forms.Label telefono2Label;
            System.Windows.Forms.Label telefono1Label;
            System.Windows.Forms.Label cpLabel;
            System.Windows.Forms.Label provinciaLabel;
            System.Windows.Forms.Label paisLabel;
            System.Windows.Forms.Label localidadLabel;
            System.Windows.Forms.Label domicilioLabel;
            System.Windows.Forms.Label proveedorIDLabel1;
            System.Windows.Forms.Label descripcionLabel;
            System.Windows.Forms.Label ingresosBrutosLabel;
            System.Windows.Forms.Label codigoContableLabel;
            System.Windows.Forms.Label cuitLabel;
            System.Windows.Forms.Label nombreFantasiaLabel;
            System.Windows.Forms.Label razonSocialLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmABMProveedores));
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.grbSucursales = new System.Windows.Forms.GroupBox();
            this.btnNuevaSucursal = new System.Windows.Forms.Button();
            this.dgvSucursales = new System.Windows.Forms.DataGridView();
            this.ProveedorSucursalID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Domicilio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefono1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Web1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mail1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LocalidadDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProvinciaDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaisDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbProveedor = new System.Windows.Forms.GroupBox();
            this.grbContacto = new System.Windows.Forms.GroupBox();
            this.web1TextBox = new System.Windows.Forms.TextBox();
            this.proveedorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mail2TextBox = new System.Windows.Forms.TextBox();
            this.mail1TextBox = new System.Windows.Forms.TextBox();
            this.telefono2TextBox = new System.Windows.Forms.TextBox();
            this.telefono1TextBox = new System.Windows.Forms.TextBox();
            this.grbDomicilio = new System.Windows.Forms.GroupBox();
            this.cpTextBox = new System.Windows.Forms.TextBox();
            this.provinciaComboBox = new System.Windows.Forms.ComboBox();
            this.paisComboBox = new System.Windows.Forms.ComboBox();
            this.localidadComboBox = new System.Windows.Forms.ComboBox();
            this.domicilioTextBox = new System.Windows.Forms.TextBox();
            this.grbDenominacion = new System.Windows.Forms.GroupBox();
            this.descripcionTextBox = new System.Windows.Forms.TextBox();
            this.ingresosBrutosTextBox = new System.Windows.Forms.TextBox();
            this.codigoContableTextBox = new System.Windows.Forms.TextBox();
            this.cuitTextBox = new System.Windows.Forms.TextBox();
            this.nombreFantasiaTextBox = new System.Windows.Forms.TextBox();
            this.razonSocialTextBox = new System.Windows.Forms.TextBox();
            this.proveedorIDLabel = new System.Windows.Forms.Label();
            this.grbGastos = new System.Windows.Forms.GroupBox();
            this.grbAgregarCgp = new System.Windows.Forms.GroupBox();
            this.btnQuitarConcepto = new System.Windows.Forms.Button();
            this.grbPeriodicidad = new System.Windows.Forms.GroupBox();
            this.txtPeriodicidad = new System.Windows.Forms.TextBox();
            this.rbOtro = new System.Windows.Forms.RadioButton();
            this.rbSemanal = new System.Windows.Forms.RadioButton();
            this.rbMensual = new System.Windows.Forms.RadioButton();
            this.rbDiaria = new System.Windows.Forms.RadioButton();
            this.btnAgregarConceptoGasto = new System.Windows.Forms.Button();
            this.cmbConceptoGasto = new System.Windows.Forms.ComboBox();
            this.dgvCgp = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            web1Label = new System.Windows.Forms.Label();
            mail2Label = new System.Windows.Forms.Label();
            mail1Label = new System.Windows.Forms.Label();
            telefono2Label = new System.Windows.Forms.Label();
            telefono1Label = new System.Windows.Forms.Label();
            cpLabel = new System.Windows.Forms.Label();
            provinciaLabel = new System.Windows.Forms.Label();
            paisLabel = new System.Windows.Forms.Label();
            localidadLabel = new System.Windows.Forms.Label();
            domicilioLabel = new System.Windows.Forms.Label();
            proveedorIDLabel1 = new System.Windows.Forms.Label();
            descripcionLabel = new System.Windows.Forms.Label();
            ingresosBrutosLabel = new System.Windows.Forms.Label();
            codigoContableLabel = new System.Windows.Forms.Label();
            cuitLabel = new System.Windows.Forms.Label();
            nombreFantasiaLabel = new System.Windows.Forms.Label();
            razonSocialLabel = new System.Windows.Forms.Label();
            this.grbSucursales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSucursales)).BeginInit();
            this.grbProveedor.SuspendLayout();
            this.grbContacto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.proveedorBindingSource)).BeginInit();
            this.grbDomicilio.SuspendLayout();
            this.grbDenominacion.SuspendLayout();
            this.grbGastos.SuspendLayout();
            this.grbAgregarCgp.SuspendLayout();
            this.grbPeriodicidad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCgp)).BeginInit();
            this.SuspendLayout();
            // 
            // web1Label
            // 
            web1Label.AutoSize = true;
            web1Label.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            web1Label.ForeColor = System.Drawing.Color.Maroon;
            web1Label.Location = new System.Drawing.Point(37, 80);
            web1Label.Name = "web1Label";
            web1Label.Size = new System.Drawing.Size(46, 14);
            web1Label.TabIndex = 8;
            web1Label.Text = "Web1:";
            // 
            // mail2Label
            // 
            mail2Label.AutoSize = true;
            mail2Label.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            mail2Label.ForeColor = System.Drawing.Color.Maroon;
            mail2Label.Location = new System.Drawing.Point(254, 54);
            mail2Label.Name = "mail2Label";
            mail2Label.Size = new System.Drawing.Size(43, 14);
            mail2Label.TabIndex = 6;
            mail2Label.Text = "Mail2:";
            // 
            // mail1Label
            // 
            mail1Label.AutoSize = true;
            mail1Label.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            mail1Label.ForeColor = System.Drawing.Color.Maroon;
            mail1Label.Location = new System.Drawing.Point(254, 23);
            mail1Label.Name = "mail1Label";
            mail1Label.Size = new System.Drawing.Size(43, 14);
            mail1Label.TabIndex = 4;
            mail1Label.Text = "Mail1:";
            // 
            // telefono2Label
            // 
            telefono2Label.AutoSize = true;
            telefono2Label.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            telefono2Label.ForeColor = System.Drawing.Color.Maroon;
            telefono2Label.Location = new System.Drawing.Point(14, 53);
            telefono2Label.Name = "telefono2Label";
            telefono2Label.Size = new System.Drawing.Size(72, 14);
            telefono2Label.TabIndex = 2;
            telefono2Label.Text = "Telefono2:";
            // 
            // telefono1Label
            // 
            telefono1Label.AutoSize = true;
            telefono1Label.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            telefono1Label.ForeColor = System.Drawing.Color.Maroon;
            telefono1Label.Location = new System.Drawing.Point(14, 26);
            telefono1Label.Name = "telefono1Label";
            telefono1Label.Size = new System.Drawing.Size(72, 14);
            telefono1Label.TabIndex = 0;
            telefono1Label.Text = "Telefono1:";
            // 
            // cpLabel
            // 
            cpLabel.AutoSize = true;
            cpLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            cpLabel.ForeColor = System.Drawing.Color.Maroon;
            cpLabel.Location = new System.Drawing.Point(366, 85);
            cpLabel.Name = "cpLabel";
            cpLabel.Size = new System.Drawing.Size(27, 14);
            cpLabel.TabIndex = 8;
            cpLabel.Text = "Cp:";
            // 
            // provinciaLabel
            // 
            provinciaLabel.AutoSize = true;
            provinciaLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            provinciaLabel.ForeColor = System.Drawing.Color.Maroon;
            provinciaLabel.Location = new System.Drawing.Point(239, 56);
            provinciaLabel.Name = "provinciaLabel";
            provinciaLabel.Size = new System.Drawing.Size(66, 14);
            provinciaLabel.TabIndex = 6;
            provinciaLabel.Text = "Provincia:";
            // 
            // paisLabel
            // 
            paisLabel.AutoSize = true;
            paisLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            paisLabel.ForeColor = System.Drawing.Color.Maroon;
            paisLabel.Location = new System.Drawing.Point(36, 56);
            paisLabel.Name = "paisLabel";
            paisLabel.Size = new System.Drawing.Size(35, 14);
            paisLabel.TabIndex = 4;
            paisLabel.Text = "Pais:";
            // 
            // localidadLabel
            // 
            localidadLabel.AutoSize = true;
            localidadLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            localidadLabel.ForeColor = System.Drawing.Color.Maroon;
            localidadLabel.Location = new System.Drawing.Point(4, 84);
            localidadLabel.Name = "localidadLabel";
            localidadLabel.Size = new System.Drawing.Size(68, 14);
            localidadLabel.TabIndex = 2;
            localidadLabel.Text = "Localidad:";
            // 
            // domicilioLabel
            // 
            domicilioLabel.AutoSize = true;
            domicilioLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            domicilioLabel.ForeColor = System.Drawing.Color.Maroon;
            domicilioLabel.Location = new System.Drawing.Point(6, 23);
            domicilioLabel.Name = "domicilioLabel";
            domicilioLabel.Size = new System.Drawing.Size(65, 14);
            domicilioLabel.TabIndex = 0;
            domicilioLabel.Text = "Domicilio:";
            // 
            // proveedorIDLabel1
            // 
            proveedorIDLabel1.AutoSize = true;
            proveedorIDLabel1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            proveedorIDLabel1.Location = new System.Drawing.Point(173, -1);
            proveedorIDLabel1.Name = "proveedorIDLabel1";
            proveedorIDLabel1.Size = new System.Drawing.Size(140, 14);
            proveedorIDLabel1.TabIndex = 15;
            proveedorIDLabel1.Text = "Código de Proveedor:";
            proveedorIDLabel1.Visible = false;
            // 
            // descripcionLabel
            // 
            descripcionLabel.AutoSize = true;
            descripcionLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            descripcionLabel.ForeColor = System.Drawing.Color.Maroon;
            descripcionLabel.Location = new System.Drawing.Point(347, 54);
            descripcionLabel.Name = "descripcionLabel";
            descripcionLabel.Size = new System.Drawing.Size(46, 14);
            descripcionLabel.TabIndex = 14;
            descripcionLabel.Text = "Notas:";
            // 
            // ingresosBrutosLabel
            // 
            ingresosBrutosLabel.AutoSize = true;
            ingresosBrutosLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ingresosBrutosLabel.ForeColor = System.Drawing.Color.Maroon;
            ingresosBrutosLabel.Location = new System.Drawing.Point(17, 88);
            ingresosBrutosLabel.Name = "ingresosBrutosLabel";
            ingresosBrutosLabel.Size = new System.Drawing.Size(109, 14);
            ingresosBrutosLabel.TabIndex = 13;
            ingresosBrutosLabel.Text = "Ingresos Brutos:";
            // 
            // codigoContableLabel
            // 
            codigoContableLabel.AutoSize = true;
            codigoContableLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            codigoContableLabel.ForeColor = System.Drawing.Color.Maroon;
            codigoContableLabel.Location = new System.Drawing.Point(13, 119);
            codigoContableLabel.Name = "codigoContableLabel";
            codigoContableLabel.Size = new System.Drawing.Size(113, 14);
            codigoContableLabel.TabIndex = 12;
            codigoContableLabel.Text = "Codigo Contable:";
            // 
            // cuitLabel
            // 
            cuitLabel.AutoSize = true;
            cuitLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            cuitLabel.ForeColor = System.Drawing.Color.Maroon;
            cuitLabel.Location = new System.Drawing.Point(86, 55);
            cuitLabel.Name = "cuitLabel";
            cuitLabel.Size = new System.Drawing.Size(36, 14);
            cuitLabel.TabIndex = 11;
            cuitLabel.Text = "Cuit:";
            // 
            // nombreFantasiaLabel
            // 
            nombreFantasiaLabel.AutoSize = true;
            nombreFantasiaLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            nombreFantasiaLabel.ForeColor = System.Drawing.Color.Maroon;
            nombreFantasiaLabel.Location = new System.Drawing.Point(520, 18);
            nombreFantasiaLabel.Name = "nombreFantasiaLabel";
            nombreFantasiaLabel.Size = new System.Drawing.Size(112, 14);
            nombreFantasiaLabel.TabIndex = 10;
            nombreFantasiaLabel.Text = "Nombre Fantasia:";
            // 
            // razonSocialLabel
            // 
            razonSocialLabel.AutoSize = true;
            razonSocialLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            razonSocialLabel.ForeColor = System.Drawing.Color.Maroon;
            razonSocialLabel.Location = new System.Drawing.Point(34, 21);
            razonSocialLabel.Name = "razonSocialLabel";
            razonSocialLabel.Size = new System.Drawing.Size(88, 14);
            razonSocialLabel.TabIndex = 8;
            razonSocialLabel.Text = "Razon Social:";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEliminar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.Location = new System.Drawing.Point(100, 639);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(80, 27);
            this.btnEliminar.TabIndex = 6;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.Location = new System.Drawing.Point(1019, 639);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(80, 27);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Salir";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGrabar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnGrabar.Location = new System.Drawing.Point(12, 639);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(80, 27);
            this.btnGrabar.TabIndex = 5;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // grbSucursales
            // 
            this.grbSucursales.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbSucursales.BackColor = System.Drawing.Color.Transparent;
            this.grbSucursales.Controls.Add(this.btnNuevaSucursal);
            this.grbSucursales.Controls.Add(this.dgvSucursales);
            this.grbSucursales.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbSucursales.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grbSucursales.Location = new System.Drawing.Point(13, 309);
            this.grbSucursales.Name = "grbSucursales";
            this.grbSucursales.Size = new System.Drawing.Size(1088, 173);
            this.grbSucursales.TabIndex = 1;
            this.grbSucursales.TabStop = false;
            this.grbSucursales.Text = "Sucursales";
            // 
            // btnNuevaSucursal
            // 
            this.btnNuevaSucursal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNuevaSucursal.ForeColor = System.Drawing.Color.Black;
            this.btnNuevaSucursal.Location = new System.Drawing.Point(6, 144);
            this.btnNuevaSucursal.Name = "btnNuevaSucursal";
            this.btnNuevaSucursal.Size = new System.Drawing.Size(154, 23);
            this.btnNuevaSucursal.TabIndex = 4;
            this.btnNuevaSucursal.Text = "Nueva Sucursal";
            this.btnNuevaSucursal.UseVisualStyleBackColor = true;
            this.btnNuevaSucursal.Click += new System.EventHandler(this.btnNuevaSucursal_Click);
            // 
            // dgvSucursales
            // 
            this.dgvSucursales.AllowUserToAddRows = false;
            this.dgvSucursales.AllowUserToDeleteRows = false;
            this.dgvSucursales.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSucursales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSucursales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProveedorSucursalID,
            this.Nombre,
            this.Descripcion,
            this.Domicilio,
            this.Telefono1,
            this.Web1,
            this.Mail1,
            this.LocalidadDGV,
            this.ProvinciaDGV,
            this.PaisDGV});
            this.dgvSucursales.Location = new System.Drawing.Point(7, 20);
            this.dgvSucursales.Name = "dgvSucursales";
            this.dgvSucursales.Size = new System.Drawing.Size(1074, 118);
            this.dgvSucursales.TabIndex = 0;
            this.dgvSucursales.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSucursales_CellContentClick);
            this.dgvSucursales.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSucursales_CellContentDoubleClick);
            this.dgvSucursales.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvSucursales_CellMouseDoubleClick);
            // 
            // ProveedorSucursalID
            // 
            this.ProveedorSucursalID.DataPropertyName = "ProveedorSucursalID";
            this.ProveedorSucursalID.HeaderText = "ID";
            this.ProveedorSucursalID.Name = "ProveedorSucursalID";
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            // 
            // Descripcion
            // 
            this.Descripcion.DataPropertyName = "Descripcion";
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.Name = "Descripcion";
            // 
            // Domicilio
            // 
            this.Domicilio.DataPropertyName = "Domicilio";
            this.Domicilio.HeaderText = "Domicilio";
            this.Domicilio.Name = "Domicilio";
            // 
            // Telefono1
            // 
            this.Telefono1.DataPropertyName = "Telefono1";
            this.Telefono1.HeaderText = "Teléfono";
            this.Telefono1.Name = "Telefono1";
            // 
            // Web1
            // 
            this.Web1.DataPropertyName = "Web1";
            this.Web1.HeaderText = "Web";
            this.Web1.Name = "Web1";
            // 
            // Mail1
            // 
            this.Mail1.DataPropertyName = "Mail1";
            this.Mail1.HeaderText = "Mail";
            this.Mail1.Name = "Mail1";
            // 
            // LocalidadDGV
            // 
            this.LocalidadDGV.DataPropertyName = "Localidad";
            this.LocalidadDGV.HeaderText = "Localidad";
            this.LocalidadDGV.Name = "LocalidadDGV";
            // 
            // ProvinciaDGV
            // 
            this.ProvinciaDGV.DataPropertyName = "Provincia";
            this.ProvinciaDGV.HeaderText = "Provincia";
            this.ProvinciaDGV.Name = "ProvinciaDGV";
            // 
            // PaisDGV
            // 
            this.PaisDGV.DataPropertyName = "Pais";
            this.PaisDGV.HeaderText = "País";
            this.PaisDGV.Name = "PaisDGV";
            // 
            // grbProveedor
            // 
            this.grbProveedor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbProveedor.BackColor = System.Drawing.Color.Transparent;
            this.grbProveedor.Controls.Add(this.grbContacto);
            this.grbProveedor.Controls.Add(this.grbDomicilio);
            this.grbProveedor.Controls.Add(this.grbDenominacion);
            this.grbProveedor.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.grbProveedor.Location = new System.Drawing.Point(13, 12);
            this.grbProveedor.Name = "grbProveedor";
            this.grbProveedor.Size = new System.Drawing.Size(1087, 291);
            this.grbProveedor.TabIndex = 0;
            this.grbProveedor.TabStop = false;
            this.grbProveedor.Text = "Código de Proveedor:";
            this.grbProveedor.Enter += new System.EventHandler(this.grbProveedor_Enter);
            // 
            // grbContacto
            // 
            this.grbContacto.Controls.Add(web1Label);
            this.grbContacto.Controls.Add(this.web1TextBox);
            this.grbContacto.Controls.Add(mail2Label);
            this.grbContacto.Controls.Add(this.mail2TextBox);
            this.grbContacto.Controls.Add(mail1Label);
            this.grbContacto.Controls.Add(this.mail1TextBox);
            this.grbContacto.Controls.Add(telefono2Label);
            this.grbContacto.Controls.Add(this.telefono2TextBox);
            this.grbContacto.Controls.Add(telefono1Label);
            this.grbContacto.Controls.Add(this.telefono1TextBox);
            this.grbContacto.Location = new System.Drawing.Point(554, 173);
            this.grbContacto.Name = "grbContacto";
            this.grbContacto.Size = new System.Drawing.Size(486, 108);
            this.grbContacto.TabIndex = 8;
            this.grbContacto.TabStop = false;
            // 
            // web1TextBox
            // 
            this.web1TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.proveedorBindingSource, "Web1", true));
            this.web1TextBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.web1TextBox.Location = new System.Drawing.Point(87, 77);
            this.web1TextBox.Name = "web1TextBox";
            this.web1TextBox.Size = new System.Drawing.Size(391, 22);
            this.web1TextBox.TabIndex = 15;
            // 
            // proveedorBindingSource
            // 
            this.proveedorBindingSource.DataSource = typeof(iComercio.Models.Proveedor);
            // 
            // mail2TextBox
            // 
            this.mail2TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.proveedorBindingSource, "Mail2", true));
            this.mail2TextBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mail2TextBox.Location = new System.Drawing.Point(299, 48);
            this.mail2TextBox.Name = "mail2TextBox";
            this.mail2TextBox.Size = new System.Drawing.Size(179, 22);
            this.mail2TextBox.TabIndex = 14;
            // 
            // mail1TextBox
            // 
            this.mail1TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.proveedorBindingSource, "Mail1", true));
            this.mail1TextBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mail1TextBox.Location = new System.Drawing.Point(299, 16);
            this.mail1TextBox.Name = "mail1TextBox";
            this.mail1TextBox.Size = new System.Drawing.Size(179, 22);
            this.mail1TextBox.TabIndex = 13;
            // 
            // telefono2TextBox
            // 
            this.telefono2TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.proveedorBindingSource, "Telefono2", true));
            this.telefono2TextBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.telefono2TextBox.Location = new System.Drawing.Point(87, 48);
            this.telefono2TextBox.Name = "telefono2TextBox";
            this.telefono2TextBox.Size = new System.Drawing.Size(155, 22);
            this.telefono2TextBox.TabIndex = 12;
            this.telefono2TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.telefono2TextBox.TextChanged += new System.EventHandler(this.telefono2TextBox_TextChanged);
            this.telefono2TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.telefono2TextBox_KeyPress);
            // 
            // telefono1TextBox
            // 
            this.telefono1TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.proveedorBindingSource, "Telefono1", true));
            this.telefono1TextBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.telefono1TextBox.Location = new System.Drawing.Point(87, 18);
            this.telefono1TextBox.Name = "telefono1TextBox";
            this.telefono1TextBox.Size = new System.Drawing.Size(155, 22);
            this.telefono1TextBox.TabIndex = 11;
            this.telefono1TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.telefono1TextBox.TextChanged += new System.EventHandler(this.telefono1TextBox_TextChanged);
            this.telefono1TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.telefono1TextBox_KeyPress);
            // 
            // grbDomicilio
            // 
            this.grbDomicilio.Controls.Add(cpLabel);
            this.grbDomicilio.Controls.Add(this.cpTextBox);
            this.grbDomicilio.Controls.Add(provinciaLabel);
            this.grbDomicilio.Controls.Add(this.provinciaComboBox);
            this.grbDomicilio.Controls.Add(paisLabel);
            this.grbDomicilio.Controls.Add(this.paisComboBox);
            this.grbDomicilio.Controls.Add(localidadLabel);
            this.grbDomicilio.Controls.Add(this.localidadComboBox);
            this.grbDomicilio.Controls.Add(domicilioLabel);
            this.grbDomicilio.Controls.Add(this.domicilioTextBox);
            this.grbDomicilio.Location = new System.Drawing.Point(46, 173);
            this.grbDomicilio.Name = "grbDomicilio";
            this.grbDomicilio.Size = new System.Drawing.Size(499, 108);
            this.grbDomicilio.TabIndex = 7;
            this.grbDomicilio.TabStop = false;
            // 
            // cpTextBox
            // 
            this.cpTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.proveedorBindingSource, "Cp", true));
            this.cpTextBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cpTextBox.Location = new System.Drawing.Point(392, 77);
            this.cpTextBox.Name = "cpTextBox";
            this.cpTextBox.Size = new System.Drawing.Size(96, 22);
            this.cpTextBox.TabIndex = 10;
            // 
            // provinciaComboBox
            // 
            this.provinciaComboBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.provinciaComboBox.FormattingEnabled = true;
            this.provinciaComboBox.Location = new System.Drawing.Point(306, 48);
            this.provinciaComboBox.Name = "provinciaComboBox";
            this.provinciaComboBox.Size = new System.Drawing.Size(182, 22);
            this.provinciaComboBox.TabIndex = 8;
            this.provinciaComboBox.SelectedIndexChanged += new System.EventHandler(this.provinciaComboBox_SelectedIndexChanged);
            // 
            // paisComboBox
            // 
            this.paisComboBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paisComboBox.FormattingEnabled = true;
            this.paisComboBox.Location = new System.Drawing.Point(72, 48);
            this.paisComboBox.Name = "paisComboBox";
            this.paisComboBox.Size = new System.Drawing.Size(160, 22);
            this.paisComboBox.TabIndex = 7;
            this.paisComboBox.SelectedIndexChanged += new System.EventHandler(this.paisComboBox_SelectedIndexChanged);
            // 
            // localidadComboBox
            // 
            this.localidadComboBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.localidadComboBox.FormattingEnabled = true;
            this.localidadComboBox.Location = new System.Drawing.Point(72, 77);
            this.localidadComboBox.Name = "localidadComboBox";
            this.localidadComboBox.Size = new System.Drawing.Size(288, 22);
            this.localidadComboBox.TabIndex = 9;
            this.localidadComboBox.SelectedIndexChanged += new System.EventHandler(this.localidadComboBox_SelectedIndexChanged);
            // 
            // domicilioTextBox
            // 
            this.domicilioTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.proveedorBindingSource, "Domicilio", true));
            this.domicilioTextBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.domicilioTextBox.Location = new System.Drawing.Point(73, 18);
            this.domicilioTextBox.Name = "domicilioTextBox";
            this.domicilioTextBox.Size = new System.Drawing.Size(415, 22);
            this.domicilioTextBox.TabIndex = 6;
            // 
            // grbDenominacion
            // 
            this.grbDenominacion.BackColor = System.Drawing.Color.Transparent;
            this.grbDenominacion.Controls.Add(descripcionLabel);
            this.grbDenominacion.Controls.Add(this.descripcionTextBox);
            this.grbDenominacion.Controls.Add(ingresosBrutosLabel);
            this.grbDenominacion.Controls.Add(this.ingresosBrutosTextBox);
            this.grbDenominacion.Controls.Add(codigoContableLabel);
            this.grbDenominacion.Controls.Add(this.codigoContableTextBox);
            this.grbDenominacion.Controls.Add(cuitLabel);
            this.grbDenominacion.Controls.Add(this.cuitTextBox);
            this.grbDenominacion.Controls.Add(nombreFantasiaLabel);
            this.grbDenominacion.Controls.Add(this.nombreFantasiaTextBox);
            this.grbDenominacion.Controls.Add(razonSocialLabel);
            this.grbDenominacion.Controls.Add(this.razonSocialTextBox);
            this.grbDenominacion.Location = new System.Drawing.Point(27, 19);
            this.grbDenominacion.Name = "grbDenominacion";
            this.grbDenominacion.Size = new System.Drawing.Size(1033, 148);
            this.grbDenominacion.TabIndex = 6;
            this.grbDenominacion.TabStop = false;
            this.grbDenominacion.Enter += new System.EventHandler(this.grbDenominacion_Enter);
            // 
            // descripcionTextBox
            // 
            this.descripcionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.proveedorBindingSource, "Descripcion", true));
            this.descripcionTextBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descripcionTextBox.Location = new System.Drawing.Point(399, 52);
            this.descripcionTextBox.Multiline = true;
            this.descripcionTextBox.Name = "descripcionTextBox";
            this.descripcionTextBox.Size = new System.Drawing.Size(597, 82);
            this.descripcionTextBox.TabIndex = 5;
            // 
            // ingresosBrutosTextBox
            // 
            this.ingresosBrutosTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.proveedorBindingSource, "IngresosBrutos", true));
            this.ingresosBrutosTextBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ingresosBrutosTextBox.Location = new System.Drawing.Point(127, 83);
            this.ingresosBrutosTextBox.Name = "ingresosBrutosTextBox";
            this.ingresosBrutosTextBox.Size = new System.Drawing.Size(151, 22);
            this.ingresosBrutosTextBox.TabIndex = 3;
            this.ingresosBrutosTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ingresosBrutosTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ingresosBrutosTextBox_KeyPress);
            // 
            // codigoContableTextBox
            // 
            this.codigoContableTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.proveedorBindingSource, "CodigoContable", true));
            this.codigoContableTextBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codigoContableTextBox.Location = new System.Drawing.Point(127, 114);
            this.codigoContableTextBox.Name = "codigoContableTextBox";
            this.codigoContableTextBox.Size = new System.Drawing.Size(151, 22);
            this.codigoContableTextBox.TabIndex = 4;
            this.codigoContableTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.codigoContableTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.codigoContableTextBox_KeyPress);
            // 
            // cuitTextBox
            // 
            this.cuitTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.proveedorBindingSource, "Cuit", true));
            this.cuitTextBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cuitTextBox.Location = new System.Drawing.Point(127, 50);
            this.cuitTextBox.Name = "cuitTextBox";
            this.cuitTextBox.Size = new System.Drawing.Size(152, 22);
            this.cuitTextBox.TabIndex = 2;
            this.cuitTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.cuitTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cuitTextBox_KeyPress);
            // 
            // nombreFantasiaTextBox
            // 
            this.nombreFantasiaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.proveedorBindingSource, "NombreFantasia", true));
            this.nombreFantasiaTextBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombreFantasiaTextBox.Location = new System.Drawing.Point(634, 13);
            this.nombreFantasiaTextBox.Name = "nombreFantasiaTextBox";
            this.nombreFantasiaTextBox.Size = new System.Drawing.Size(364, 22);
            this.nombreFantasiaTextBox.TabIndex = 1;
            // 
            // razonSocialTextBox
            // 
            this.razonSocialTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.proveedorBindingSource, "RazonSocial", true));
            this.razonSocialTextBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.razonSocialTextBox.Location = new System.Drawing.Point(127, 15);
            this.razonSocialTextBox.Name = "razonSocialTextBox";
            this.razonSocialTextBox.Size = new System.Drawing.Size(382, 22);
            this.razonSocialTextBox.TabIndex = 0;
            // 
            // proveedorIDLabel
            // 
            this.proveedorIDLabel.AutoSize = true;
            this.proveedorIDLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.proveedorBindingSource, "ProveedorID", true));
            this.proveedorIDLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.proveedorIDLabel.Location = new System.Drawing.Point(325, -1);
            this.proveedorIDLabel.Name = "proveedorIDLabel";
            this.proveedorIDLabel.Size = new System.Drawing.Size(43, 14);
            this.proveedorIDLabel.TabIndex = 16;
            this.proveedorIDLabel.Text = "label1";
            this.proveedorIDLabel.Visible = false;
            // 
            // grbGastos
            // 
            this.grbGastos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbGastos.BackColor = System.Drawing.Color.Transparent;
            this.grbGastos.Controls.Add(this.grbAgregarCgp);
            this.grbGastos.Controls.Add(this.dgvCgp);
            this.grbGastos.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbGastos.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grbGastos.Location = new System.Drawing.Point(13, 480);
            this.grbGastos.Name = "grbGastos";
            this.grbGastos.Size = new System.Drawing.Size(1081, 161);
            this.grbGastos.TabIndex = 17;
            this.grbGastos.TabStop = false;
            this.grbGastos.Text = "Concepto de Gastos";
            // 
            // grbAgregarCgp
            // 
            this.grbAgregarCgp.Controls.Add(this.btnQuitarConcepto);
            this.grbAgregarCgp.Controls.Add(this.grbPeriodicidad);
            this.grbAgregarCgp.Controls.Add(this.btnAgregarConceptoGasto);
            this.grbAgregarCgp.Controls.Add(this.cmbConceptoGasto);
            this.grbAgregarCgp.Location = new System.Drawing.Point(377, 21);
            this.grbAgregarCgp.Name = "grbAgregarCgp";
            this.grbAgregarCgp.Size = new System.Drawing.Size(683, 132);
            this.grbAgregarCgp.TabIndex = 7;
            this.grbAgregarCgp.TabStop = false;
            this.grbAgregarCgp.Text = "Agregar Concepto de Gasto";
            this.grbAgregarCgp.Enter += new System.EventHandler(this.grbAgregarCgp_Enter);
            // 
            // btnQuitarConcepto
            // 
            this.btnQuitarConcepto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnQuitarConcepto.ForeColor = System.Drawing.Color.Black;
            this.btnQuitarConcepto.Location = new System.Drawing.Point(290, 51);
            this.btnQuitarConcepto.Name = "btnQuitarConcepto";
            this.btnQuitarConcepto.Size = new System.Drawing.Size(74, 23);
            this.btnQuitarConcepto.TabIndex = 10;
            this.btnQuitarConcepto.Text = "Quitar";
            this.btnQuitarConcepto.UseVisualStyleBackColor = true;
            this.btnQuitarConcepto.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // grbPeriodicidad
            // 
            this.grbPeriodicidad.Controls.Add(this.txtPeriodicidad);
            this.grbPeriodicidad.Controls.Add(this.rbOtro);
            this.grbPeriodicidad.Controls.Add(this.rbSemanal);
            this.grbPeriodicidad.Controls.Add(this.rbMensual);
            this.grbPeriodicidad.Controls.Add(this.rbDiaria);
            this.grbPeriodicidad.Location = new System.Drawing.Point(7, 50);
            this.grbPeriodicidad.Name = "grbPeriodicidad";
            this.grbPeriodicidad.Size = new System.Drawing.Size(278, 76);
            this.grbPeriodicidad.TabIndex = 9;
            this.grbPeriodicidad.TabStop = false;
            this.grbPeriodicidad.Text = "Periodicidad";
            // 
            // txtPeriodicidad
            // 
            this.txtPeriodicidad.Enabled = false;
            this.txtPeriodicidad.Location = new System.Drawing.Point(144, 44);
            this.txtPeriodicidad.Name = "txtPeriodicidad";
            this.txtPeriodicidad.Size = new System.Drawing.Size(74, 22);
            this.txtPeriodicidad.TabIndex = 4;
            // 
            // rbOtro
            // 
            this.rbOtro.AutoSize = true;
            this.rbOtro.Location = new System.Drawing.Point(88, 45);
            this.rbOtro.Name = "rbOtro";
            this.rbOtro.Size = new System.Drawing.Size(50, 18);
            this.rbOtro.TabIndex = 3;
            this.rbOtro.Text = "Dias";
            this.rbOtro.UseVisualStyleBackColor = true;
            // 
            // rbSemanal
            // 
            this.rbSemanal.AutoSize = true;
            this.rbSemanal.Location = new System.Drawing.Point(6, 45);
            this.rbSemanal.Name = "rbSemanal";
            this.rbSemanal.Size = new System.Drawing.Size(76, 18);
            this.rbSemanal.TabIndex = 2;
            this.rbSemanal.Text = "Semanal";
            this.rbSemanal.UseVisualStyleBackColor = true;
            // 
            // rbMensual
            // 
            this.rbMensual.AutoSize = true;
            this.rbMensual.Location = new System.Drawing.Point(86, 21);
            this.rbMensual.Name = "rbMensual";
            this.rbMensual.Size = new System.Drawing.Size(75, 18);
            this.rbMensual.TabIndex = 1;
            this.rbMensual.Text = "Mensual";
            this.rbMensual.UseVisualStyleBackColor = true;
            // 
            // rbDiaria
            // 
            this.rbDiaria.AutoSize = true;
            this.rbDiaria.Checked = true;
            this.rbDiaria.Location = new System.Drawing.Point(6, 21);
            this.rbDiaria.Name = "rbDiaria";
            this.rbDiaria.Size = new System.Drawing.Size(59, 18);
            this.rbDiaria.TabIndex = 0;
            this.rbDiaria.TabStop = true;
            this.rbDiaria.Text = "Diaria";
            this.rbDiaria.UseVisualStyleBackColor = true;
            this.rbDiaria.CheckedChanged += new System.EventHandler(this.rbDiaria_CheckedChanged);
            // 
            // btnAgregarConceptoGasto
            // 
            this.btnAgregarConceptoGasto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAgregarConceptoGasto.ForeColor = System.Drawing.Color.Black;
            this.btnAgregarConceptoGasto.Location = new System.Drawing.Point(291, 22);
            this.btnAgregarConceptoGasto.Name = "btnAgregarConceptoGasto";
            this.btnAgregarConceptoGasto.Size = new System.Drawing.Size(73, 23);
            this.btnAgregarConceptoGasto.TabIndex = 8;
            this.btnAgregarConceptoGasto.Text = "Agregar";
            this.btnAgregarConceptoGasto.UseVisualStyleBackColor = true;
            this.btnAgregarConceptoGasto.Click += new System.EventHandler(this.btnAgregarConceptoGasto_Click);
            // 
            // cmbConceptoGasto
            // 
            this.cmbConceptoGasto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbConceptoGasto.FormattingEnabled = true;
            this.cmbConceptoGasto.Location = new System.Drawing.Point(6, 22);
            this.cmbConceptoGasto.Name = "cmbConceptoGasto";
            this.cmbConceptoGasto.Size = new System.Drawing.Size(279, 22);
            this.cmbConceptoGasto.TabIndex = 7;
            this.cmbConceptoGasto.SelectedIndexChanged += new System.EventHandler(this.cmbConceptoGasto_SelectedIndexChanged);
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
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn1});
            this.dgvCgp.Location = new System.Drawing.Point(6, 21);
            this.dgvCgp.Name = "dgvCgp";
            this.dgvCgp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCgp.Size = new System.Drawing.Size(359, 132);
            this.dgvCgp.TabIndex = 0;
            this.dgvCgp.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCgp_CellContentClick);
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Nombre";
            this.dataGridViewTextBoxColumn2.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Estado";
            this.dataGridViewTextBoxColumn3.HeaderText = "Estado";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Periodicidad";
            this.dataGridViewTextBoxColumn1.HeaderText = "Periodicidad";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // frmABMProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 671);
            this.Controls.Add(this.grbGastos);
            this.Controls.Add(this.proveedorIDLabel);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(proveedorIDLabel1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.grbSucursales);
            this.Controls.Add(this.grbProveedor);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmABMProveedores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proveedores";
            this.Load += new System.EventHandler(this.frmABMProveedores_Load);
            this.grbSucursales.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSucursales)).EndInit();
            this.grbProveedor.ResumeLayout(false);
            this.grbContacto.ResumeLayout(false);
            this.grbContacto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.proveedorBindingSource)).EndInit();
            this.grbDomicilio.ResumeLayout(false);
            this.grbDomicilio.PerformLayout();
            this.grbDenominacion.ResumeLayout(false);
            this.grbDenominacion.PerformLayout();
            this.grbGastos.ResumeLayout(false);
            this.grbAgregarCgp.ResumeLayout(false);
            this.grbPeriodicidad.ResumeLayout(false);
            this.grbPeriodicidad.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCgp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbProveedor;
        private System.Windows.Forms.GroupBox grbSucursales;
        private System.Windows.Forms.GroupBox grbDenominacion;
        private System.Windows.Forms.TextBox nombreFantasiaTextBox;
        private System.Windows.Forms.BindingSource proveedorBindingSource;
        private System.Windows.Forms.TextBox razonSocialTextBox;
        private System.Windows.Forms.GroupBox grbDomicilio;
        private System.Windows.Forms.GroupBox grbContacto;
        private System.Windows.Forms.ComboBox provinciaComboBox;
        private System.Windows.Forms.ComboBox paisComboBox;
        private System.Windows.Forms.ComboBox localidadComboBox;
        private System.Windows.Forms.TextBox domicilioTextBox;
        private System.Windows.Forms.TextBox codigoContableTextBox;
        private System.Windows.Forms.TextBox cuitTextBox;
        private System.Windows.Forms.TextBox ingresosBrutosTextBox;
        private System.Windows.Forms.TextBox descripcionTextBox;
        private System.Windows.Forms.TextBox web1TextBox;
        private System.Windows.Forms.TextBox mail2TextBox;
        private System.Windows.Forms.TextBox mail1TextBox;
        private System.Windows.Forms.TextBox telefono2TextBox;
        private System.Windows.Forms.TextBox telefono1TextBox;
        private System.Windows.Forms.TextBox cpTextBox;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnNuevaSucursal;
        private System.Windows.Forms.DataGridView dgvSucursales;
        private System.Windows.Forms.Label proveedorIDLabel;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProveedorSucursalID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Domicilio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefono1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Web1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mail1;
        private System.Windows.Forms.DataGridViewTextBoxColumn LocalidadDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProvinciaDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaisDGV;
        private System.Windows.Forms.GroupBox grbGastos;
        private System.Windows.Forms.DataGridView dgvCgp;
        private System.Windows.Forms.GroupBox grbAgregarCgp;
        private System.Windows.Forms.GroupBox grbPeriodicidad;
        private System.Windows.Forms.TextBox txtPeriodicidad;
        private System.Windows.Forms.RadioButton rbOtro;
        private System.Windows.Forms.RadioButton rbSemanal;
        private System.Windows.Forms.RadioButton rbMensual;
        private System.Windows.Forms.RadioButton rbDiaria;
        private System.Windows.Forms.Button btnAgregarConceptoGasto;
        private System.Windows.Forms.ComboBox cmbConceptoGasto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.Button btnQuitarConcepto;
    }
}