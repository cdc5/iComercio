namespace iComercio.Forms
{
    partial class frmActualizaciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmActualizaciones));
            this.xtabControl = new DevExpress.XtraTab.XtraTabControl();
            this.xTabPagePorFecha = new DevExpress.XtraTab.XtraTabPage();
            this.grpLog = new DevExpress.XtraEditors.GroupControl();
            this.lbLog = new System.Windows.Forms.ListBox();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblHasta = new System.Windows.Forms.Label();
            this.lblDesde = new System.Windows.Forms.Label();
            this.lblComercio = new System.Windows.Forms.Label();
            this.cmbComercio = new System.Windows.Forms.ComboBox();
            this.xTabPagePorCredito = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.lbLogCred = new System.Windows.Forms.ListBox();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.txtCredito = new System.Windows.Forms.TextBox();
            this.lblCredito = new System.Windows.Forms.Label();
            this.btnXCredito = new System.Windows.Forms.Button();
            this.xTabPageAuto = new DevExpress.XtraTab.XtraTabPage();
            this.grpLogAuto = new DevExpress.XtraEditors.GroupControl();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCantRegs = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtAct = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lbLogAuto = new System.Windows.Forms.ListBox();
            this.grpConf = new DevExpress.XtraEditors.GroupControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnAuto = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.xtabControl)).BeginInit();
            this.xtabControl.SuspendLayout();
            this.xTabPagePorFecha.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpLog)).BeginInit();
            this.grpLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.xTabPagePorCredito.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.xTabPageAuto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpLogAuto)).BeginInit();
            this.grpLogAuto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpConf)).BeginInit();
            this.grpConf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // xtabControl
            // 
            this.xtabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xtabControl.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.xtabControl.Appearance.BackColor2 = System.Drawing.SystemColors.Control;
            this.xtabControl.Appearance.BorderColor = System.Drawing.SystemColors.Control;
            this.xtabControl.Appearance.Options.UseBackColor = true;
            this.xtabControl.Appearance.Options.UseBorderColor = true;
            this.xtabControl.AppearancePage.Header.BorderColor = System.Drawing.Color.Silver;
            this.xtabControl.AppearancePage.Header.Options.UseBorderColor = true;
            this.xtabControl.AppearancePage.HeaderActive.BorderColor = System.Drawing.Color.Silver;
            this.xtabControl.AppearancePage.HeaderActive.Options.UseBorderColor = true;
            this.xtabControl.AppearancePage.HeaderDisabled.BorderColor = System.Drawing.Color.Silver;
            this.xtabControl.AppearancePage.HeaderDisabled.Options.UseBorderColor = true;
            this.xtabControl.AppearancePage.HeaderHotTracked.BorderColor = System.Drawing.Color.Silver;
            this.xtabControl.AppearancePage.HeaderHotTracked.Options.UseBorderColor = true;
            this.xtabControl.AppearancePage.PageClient.BorderColor = System.Drawing.Color.Silver;
            this.xtabControl.AppearancePage.PageClient.Options.UseBorderColor = true;
            this.xtabControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.xtabControl.BorderStylePage = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.xtabControl.HeaderAutoFill = DevExpress.Utils.DefaultBoolean.True;
            this.xtabControl.Location = new System.Drawing.Point(14, 3);
            this.xtabControl.Name = "xtabControl";
            this.xtabControl.PaintStyleName = "PropertyView";
            this.xtabControl.SelectedTabPage = this.xTabPagePorFecha;
            this.xtabControl.ShowHeaderFocus = DevExpress.Utils.DefaultBoolean.True;
            this.xtabControl.ShowTabHeader = DevExpress.Utils.DefaultBoolean.True;
            this.xtabControl.Size = new System.Drawing.Size(1008, 528);
            this.xtabControl.TabIndex = 2;
            this.xtabControl.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xTabPagePorFecha,
            this.xTabPagePorCredito,
            this.xTabPageAuto});
            this.xtabControl.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.xtabControl_SelectedPageChanged);
            this.xtabControl.TabIndexChanged += new System.EventHandler(this.xtabControl_TabIndexChanged);
            // 
            // xTabPagePorFecha
            // 
            this.xTabPagePorFecha.Appearance.Header.BackColor2 = System.Drawing.Color.Silver;
            this.xTabPagePorFecha.Appearance.Header.BorderColor = System.Drawing.Color.Silver;
            this.xTabPagePorFecha.Appearance.Header.Options.UseBorderColor = true;
            this.xTabPagePorFecha.Appearance.HeaderActive.BackColor2 = System.Drawing.Color.Silver;
            this.xTabPagePorFecha.Appearance.HeaderActive.BorderColor = System.Drawing.Color.Silver;
            this.xTabPagePorFecha.Appearance.HeaderActive.Options.UseBorderColor = true;
            this.xTabPagePorFecha.Appearance.HeaderDisabled.BackColor2 = System.Drawing.Color.Silver;
            this.xTabPagePorFecha.Appearance.HeaderDisabled.BorderColor = System.Drawing.Color.Silver;
            this.xTabPagePorFecha.Appearance.HeaderDisabled.Options.UseBorderColor = true;
            this.xTabPagePorFecha.Appearance.HeaderHotTracked.BorderColor = System.Drawing.Color.Silver;
            this.xTabPagePorFecha.Appearance.HeaderHotTracked.Options.UseBorderColor = true;
            this.xTabPagePorFecha.Appearance.PageClient.BackColor = System.Drawing.SystemColors.Control;
            this.xTabPagePorFecha.Appearance.PageClient.BorderColor = System.Drawing.Color.Silver;
            this.xTabPagePorFecha.Appearance.PageClient.Options.UseBackColor = true;
            this.xTabPagePorFecha.Appearance.PageClient.Options.UseBorderColor = true;
            this.xTabPagePorFecha.Controls.Add(this.grpLog);
            this.xTabPagePorFecha.Controls.Add(this.groupControl1);
            this.xTabPagePorFecha.Name = "xTabPagePorFecha";
            this.xTabPagePorFecha.Size = new System.Drawing.Size(1004, 504);
            this.xTabPagePorFecha.Text = "Por Fecha";
            // 
            // grpLog
            // 
            this.grpLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpLog.Controls.Add(this.lbLog);
            this.grpLog.Location = new System.Drawing.Point(7, 141);
            this.grpLog.Name = "grpLog";
            this.grpLog.Size = new System.Drawing.Size(990, 360);
            this.grpLog.TabIndex = 3;
            this.grpLog.Text = "Log";
            // 
            // lbLog
            // 
            this.lbLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbLog.FormattingEnabled = true;
            this.lbLog.Location = new System.Drawing.Point(7, 35);
            this.lbLog.Name = "lbLog";
            this.lbLog.Size = new System.Drawing.Size(978, 303);
            this.lbLog.TabIndex = 0;
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.btnActualizar);
            this.groupControl1.Controls.Add(this.dtpHasta);
            this.groupControl1.Controls.Add(this.dtpDesde);
            this.groupControl1.Controls.Add(this.lblHasta);
            this.groupControl1.Controls.Add(this.lblDesde);
            this.groupControl1.Controls.Add(this.lblComercio);
            this.groupControl1.Controls.Add(this.cmbComercio);
            this.groupControl1.Location = new System.Drawing.Point(7, 13);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(990, 122);
            this.groupControl1.TabIndex = 1;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(274, 94);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 4;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(237, 61);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(112, 20);
            this.dtpHasta.TabIndex = 3;
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(76, 61);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(111, 20);
            this.dtpDesde.TabIndex = 3;
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(193, 65);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(38, 13);
            this.lblHasta.TabIndex = 2;
            this.lblHasta.Text = "Hasta:";
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Location = new System.Drawing.Point(16, 65);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(41, 13);
            this.lblDesde.TabIndex = 2;
            this.lblDesde.Text = "Desde:";
            // 
            // lblComercio
            // 
            this.lblComercio.AutoSize = true;
            this.lblComercio.Location = new System.Drawing.Point(16, 37);
            this.lblComercio.Name = "lblComercio";
            this.lblComercio.Size = new System.Drawing.Size(54, 13);
            this.lblComercio.TabIndex = 1;
            this.lblComercio.Text = "Comercio:";
            // 
            // cmbComercio
            // 
            this.cmbComercio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbComercio.FormattingEnabled = true;
            this.cmbComercio.Location = new System.Drawing.Point(76, 34);
            this.cmbComercio.Name = "cmbComercio";
            this.cmbComercio.Size = new System.Drawing.Size(273, 21);
            this.cmbComercio.TabIndex = 0;
            this.cmbComercio.SelectedIndexChanged += new System.EventHandler(this.cmbComercio_SelectedIndexChanged);
            // 
            // xTabPagePorCredito
            // 
            this.xTabPagePorCredito.Appearance.Header.BorderColor = System.Drawing.Color.Silver;
            this.xTabPagePorCredito.Appearance.Header.Options.UseBorderColor = true;
            this.xTabPagePorCredito.Appearance.HeaderActive.BorderColor = System.Drawing.Color.Silver;
            this.xTabPagePorCredito.Appearance.HeaderActive.Options.UseBorderColor = true;
            this.xTabPagePorCredito.Appearance.HeaderDisabled.BorderColor = System.Drawing.Color.Silver;
            this.xTabPagePorCredito.Appearance.HeaderDisabled.Options.UseBorderColor = true;
            this.xTabPagePorCredito.Appearance.HeaderHotTracked.BorderColor = System.Drawing.Color.Silver;
            this.xTabPagePorCredito.Appearance.HeaderHotTracked.Options.UseBorderColor = true;
            this.xTabPagePorCredito.Appearance.PageClient.BackColor = System.Drawing.SystemColors.Control;
            this.xTabPagePorCredito.Appearance.PageClient.BorderColor = System.Drawing.Color.Silver;
            this.xTabPagePorCredito.Appearance.PageClient.Options.UseBackColor = true;
            this.xTabPagePorCredito.Appearance.PageClient.Options.UseBorderColor = true;
            this.xTabPagePorCredito.Controls.Add(this.groupControl4);
            this.xTabPagePorCredito.Controls.Add(this.groupControl2);
            this.xTabPagePorCredito.Name = "xTabPagePorCredito";
            this.xTabPagePorCredito.Size = new System.Drawing.Size(1004, 504);
            this.xTabPagePorCredito.Text = "Por Crédito";
            // 
            // groupControl4
            // 
            this.groupControl4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl4.Controls.Add(this.lbLogCred);
            this.groupControl4.Location = new System.Drawing.Point(7, 146);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(990, 360);
            this.groupControl4.TabIndex = 4;
            this.groupControl4.Text = "Log";
            // 
            // lbLogCred
            // 
            this.lbLogCred.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbLogCred.FormattingEnabled = true;
            this.lbLogCred.Location = new System.Drawing.Point(7, 35);
            this.lbLogCred.Name = "lbLogCred";
            this.lbLogCred.Size = new System.Drawing.Size(978, 303);
            this.lbLogCred.TabIndex = 0;
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl2.Controls.Add(this.txtCredito);
            this.groupControl2.Controls.Add(this.lblCredito);
            this.groupControl2.Controls.Add(this.btnXCredito);
            this.groupControl2.Location = new System.Drawing.Point(7, 12);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(994, 122);
            this.groupControl2.TabIndex = 2;
            // 
            // txtCredito
            // 
            this.txtCredito.Location = new System.Drawing.Point(76, 65);
            this.txtCredito.Name = "txtCredito";
            this.txtCredito.Size = new System.Drawing.Size(121, 20);
            this.txtCredito.TabIndex = 6;
            // 
            // lblCredito
            // 
            this.lblCredito.AutoSize = true;
            this.lblCredito.Location = new System.Drawing.Point(18, 71);
            this.lblCredito.Name = "lblCredito";
            this.lblCredito.Size = new System.Drawing.Size(43, 13);
            this.lblCredito.TabIndex = 5;
            this.lblCredito.Text = "Credito:";
            // 
            // btnXCredito
            // 
            this.btnXCredito.Location = new System.Drawing.Point(274, 63);
            this.btnXCredito.Name = "btnXCredito";
            this.btnXCredito.Size = new System.Drawing.Size(75, 23);
            this.btnXCredito.TabIndex = 4;
            this.btnXCredito.Text = "Actualizar";
            this.btnXCredito.UseVisualStyleBackColor = true;
            this.btnXCredito.Click += new System.EventHandler(this.btnXCredito_Click);
            // 
            // xTabPageAuto
            // 
            this.xTabPageAuto.Appearance.PageClient.BackColor = System.Drawing.SystemColors.Control;
            this.xTabPageAuto.Appearance.PageClient.Options.UseBackColor = true;
            this.xTabPageAuto.Controls.Add(this.grpLogAuto);
            this.xTabPageAuto.Controls.Add(this.grpConf);
            this.xTabPageAuto.Name = "xTabPageAuto";
            this.xTabPageAuto.Size = new System.Drawing.Size(1004, 504);
            this.xTabPageAuto.Text = "Automático";
            // 
            // grpLogAuto
            // 
            this.grpLogAuto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpLogAuto.Controls.Add(this.label8);
            this.grpLogAuto.Controls.Add(this.txtCantRegs);
            this.grpLogAuto.Controls.Add(this.label9);
            this.grpLogAuto.Controls.Add(this.label10);
            this.grpLogAuto.Controls.Add(this.txtAct);
            this.grpLogAuto.Controls.Add(this.label11);
            this.grpLogAuto.Controls.Add(this.lbLogAuto);
            this.grpLogAuto.Location = new System.Drawing.Point(11, 158);
            this.grpLogAuto.Name = "grpLogAuto";
            this.grpLogAuto.Size = new System.Drawing.Size(990, 318);
            this.grpLogAuto.TabIndex = 7;
            this.grpLogAuto.Text = "Log";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(359, 293);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "label8";
            // 
            // txtCantRegs
            // 
            this.txtCantRegs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCantRegs.Location = new System.Drawing.Point(311, 290);
            this.txtCantRegs.Name = "txtCantRegs";
            this.txtCantRegs.Size = new System.Drawing.Size(42, 20);
            this.txtCantRegs.TabIndex = 5;
            this.txtCantRegs.Text = "500";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(228, 294);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Mostrar últimos:";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(145, 294);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Segundos:";
            // 
            // txtAct
            // 
            this.txtAct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtAct.Location = new System.Drawing.Point(97, 291);
            this.txtAct.Name = "txtAct";
            this.txtAct.Size = new System.Drawing.Size(42, 20);
            this.txtAct.TabIndex = 2;
            this.txtAct.Text = "30";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 294);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Actualizar Cada:";
            // 
            // lbLogAuto
            // 
            this.lbLogAuto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbLogAuto.FormattingEnabled = true;
            this.lbLogAuto.Location = new System.Drawing.Point(7, 35);
            this.lbLogAuto.Name = "lbLogAuto";
            this.lbLogAuto.Size = new System.Drawing.Size(978, 238);
            this.lbLogAuto.TabIndex = 0;
            // 
            // grpConf
            // 
            this.grpConf.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpConf.Controls.Add(this.groupControl3);
            this.grpConf.Controls.Add(this.btnAuto);
            this.grpConf.Location = new System.Drawing.Point(11, 12);
            this.grpConf.Name = "grpConf";
            this.grpConf.Size = new System.Drawing.Size(991, 140);
            this.grpConf.TabIndex = 6;
            // 
            // groupControl3
            // 
            this.groupControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl3.Controls.Add(this.label3);
            this.groupControl3.Controls.Add(this.textBox1);
            this.groupControl3.Controls.Add(this.label5);
            this.groupControl3.Controls.Add(this.label6);
            this.groupControl3.Controls.Add(this.textBox2);
            this.groupControl3.Controls.Add(this.label7);
            this.groupControl3.Controls.Add(this.listBox1);
            this.groupControl3.Location = new System.Drawing.Point(209, 243);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(990, 0);
            this.groupControl3.TabIndex = 7;
            this.groupControl3.Text = "Log";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(359, -24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "label3";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox1.Location = new System.Drawing.Point(311, -27);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(42, 20);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "500";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(228, -23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Mostrar últimos:";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(145, -23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Segundos:";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox2.Location = new System.Drawing.Point(97, -26);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(42, 20);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = "30";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, -23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Actualizar Cada:";
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(7, 35);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(978, 4);
            this.listBox1.TabIndex = 0;
            // 
            // btnAuto
            // 
            this.btnAuto.Location = new System.Drawing.Point(911, 112);
            this.btnAuto.Name = "btnAuto";
            this.btnAuto.Size = new System.Drawing.Size(75, 23);
            this.btnAuto.TabIndex = 6;
            this.btnAuto.Text = "Actualizar";
            this.btnAuto.UseVisualStyleBackColor = true;
            this.btnAuto.Click += new System.EventHandler(this.btnAuto_Click);
            // 
            // frmActualizaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 543);
            this.Controls.Add(this.xtabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmActualizaciones";
            this.Text = "Menú de Actualizaciónes";
            this.Load += new System.EventHandler(this.frmActualizaciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtabControl)).EndInit();
            this.xtabControl.ResumeLayout(false);
            this.xTabPagePorFecha.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpLog)).EndInit();
            this.grpLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.xTabPagePorCredito.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            this.xTabPageAuto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpLogAuto)).EndInit();
            this.grpLogAuto.ResumeLayout(false);
            this.grpLogAuto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpConf)).EndInit();
            this.grpConf.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtabControl;
        private DevExpress.XtraTab.XtraTabPage xTabPagePorCredito;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.TextBox txtCredito;
        private System.Windows.Forms.Label lblCredito;
        private System.Windows.Forms.Button btnXCredito;
        private DevExpress.XtraTab.XtraTabPage xTabPageAuto;
        private DevExpress.XtraEditors.GroupControl grpConf;
        private System.Windows.Forms.Button btnAuto;
        private DevExpress.XtraEditors.GroupControl grpLogAuto;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCantRegs;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtAct;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ListBox lbLogAuto;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox listBox1;
        private DevExpress.XtraTab.XtraTabPage xTabPagePorFecha;
        private DevExpress.XtraEditors.GroupControl grpLog;
        private System.Windows.Forms.ListBox lbLog;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.Label lblComercio;
        private System.Windows.Forms.ComboBox cmbComercio;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private System.Windows.Forms.ListBox lbLogCred;

    }
}