namespace iComercio.Forms
{
    partial class frmScan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmScan));
            this.grb = new DevExpress.XtraEditors.GroupControl();
            this.btnEnvioIma = new System.Windows.Forms.Button();
            this.lblIma = new System.Windows.Forms.Label();
            this.btnImaSiguiente = new DevExpress.XtraEditors.SimpleButton();
            this.btnImaAnterior = new DevExpress.XtraEditors.SimpleButton();
            this.listBusca = new System.Windows.Forms.ListView();
            this.panelIma = new System.Windows.Forms.Panel();
            this.picIma = new System.Windows.Forms.PictureBox();
            this.lblRuta = new System.Windows.Forms.Label();
            this.grbNombre = new DevExpress.XtraEditors.GroupControl();
            this.lblMor = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCliNombre = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCliDocu = new System.Windows.Forms.Label();
            this.scan = new System.Windows.Forms.Button();
            this.grbScan = new DevExpress.XtraEditors.GroupControl();
            this.panelScan = new System.Windows.Forms.Panel();
            this.pictureScan = new System.Windows.Forms.PictureBox();
            this.Devices = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.lblNombCompleto = new System.Windows.Forms.Label();
            this.btnEnvio = new System.Windows.Forms.Button();
            this.btnAcciones = new System.Windows.Forms.Button();
            this.grpAcciones = new System.Windows.Forms.GroupBox();
            this.lblAdd = new System.Windows.Forms.Label();
            this.lblAccPath = new System.Windows.Forms.Label();
            this.lblAccNombre = new System.Windows.Forms.Label();
            this.btnAccGrabar = new System.Windows.Forms.Button();
            this.btnAccCerrar = new System.Windows.Forms.Button();
            this.picImaNvo = new System.Windows.Forms.PictureBox();
            this.btnDir = new System.Windows.Forms.Button();
            this.lblDir = new System.Windows.Forms.Label();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.bgLista = new System.ComponentModel.BackgroundWorker();
            this.panelSoli = new System.Windows.Forms.Panel();
            this.lblSoliTit = new System.Windows.Forms.Label();
            this.lblSoli = new System.Windows.Forms.Label();
            this.btnSoliCancel = new System.Windows.Forms.Button();
            this.btnSoliGrabar = new System.Windows.Forms.Button();
            this.Ops3 = new System.Windows.Forms.RadioButton();
            this.Ops2 = new System.Windows.Forms.RadioButton();
            this.Ops1 = new System.Windows.Forms.RadioButton();
            this.lblSombra = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grb)).BeginInit();
            this.grb.SuspendLayout();
            this.panelIma.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grbNombre)).BeginInit();
            this.grbNombre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grbScan)).BeginInit();
            this.grbScan.SuspendLayout();
            this.panelScan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureScan)).BeginInit();
            this.grpAcciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImaNvo)).BeginInit();
            this.panelSoli.SuspendLayout();
            this.SuspendLayout();
            // 
            // grb
            // 
            this.grb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grb.Controls.Add(this.btnEnvioIma);
            this.grb.Controls.Add(this.lblIma);
            this.grb.Controls.Add(this.btnImaSiguiente);
            this.grb.Controls.Add(this.btnImaAnterior);
            this.grb.Controls.Add(this.listBusca);
            this.grb.Controls.Add(this.panelIma);
            this.grb.Controls.Add(this.lblRuta);
            this.grb.Location = new System.Drawing.Point(4, 82);
            this.grb.Name = "grb";
            this.grb.Size = new System.Drawing.Size(583, 606);
            this.grb.TabIndex = 58;
            this.grb.Text = "Imágenes";
            this.grb.Paint += new System.Windows.Forms.PaintEventHandler(this.grb_Paint);
            // 
            // btnEnvioIma
            // 
            this.btnEnvioIma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnvioIma.Location = new System.Drawing.Point(473, 0);
            this.btnEnvioIma.Name = "btnEnvioIma";
            this.btnEnvioIma.Size = new System.Drawing.Size(105, 23);
            this.btnEnvioIma.TabIndex = 74;
            this.btnEnvioIma.Text = "Enviar imagen";
            this.btnEnvioIma.UseVisualStyleBackColor = true;
            this.btnEnvioIma.Visible = false;
            this.btnEnvioIma.Click += new System.EventHandler(this.btnEnvioIma_Click);
            // 
            // lblIma
            // 
            this.lblIma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblIma.BackColor = System.Drawing.Color.Transparent;
            this.lblIma.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblIma.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIma.Location = new System.Drawing.Point(266, 562);
            this.lblIma.Name = "lblIma";
            this.lblIma.Size = new System.Drawing.Size(269, 23);
            this.lblIma.TabIndex = 73;
            this.lblIma.Tag = "XXXXXF";
            this.lblIma.Text = "imagenes";
            this.lblIma.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnImaSiguiente
            // 
            this.btnImaSiguiente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnImaSiguiente.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnImaSiguiente.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImaSiguiente.Appearance.Options.UseBackColor = true;
            this.btnImaSiguiente.Appearance.Options.UseFont = true;
            this.btnImaSiguiente.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.btnImaSiguiente.Location = new System.Drawing.Point(205, 562);
            this.btnImaSiguiente.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.btnImaSiguiente.Name = "btnImaSiguiente";
            this.btnImaSiguiente.Size = new System.Drawing.Size(29, 28);
            this.btnImaSiguiente.TabIndex = 72;
            this.btnImaSiguiente.Text = ">";
            this.btnImaSiguiente.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnImaSiguiente.Visible = false;
            this.btnImaSiguiente.Click += new System.EventHandler(this.btnImaSiguiente_Click);
            // 
            // btnImaAnterior
            // 
            this.btnImaAnterior.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnImaAnterior.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnImaAnterior.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImaAnterior.Appearance.Options.UseBackColor = true;
            this.btnImaAnterior.Appearance.Options.UseFont = true;
            this.btnImaAnterior.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.btnImaAnterior.Location = new System.Drawing.Point(170, 562);
            this.btnImaAnterior.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.btnImaAnterior.Name = "btnImaAnterior";
            this.btnImaAnterior.Size = new System.Drawing.Size(29, 28);
            this.btnImaAnterior.TabIndex = 71;
            this.btnImaAnterior.Text = "<";
            this.btnImaAnterior.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnImaAnterior.Visible = false;
            this.btnImaAnterior.Click += new System.EventHandler(this.btnImaAnterior_Click);
            // 
            // listBusca
            // 
            this.listBusca.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBusca.BackColor = System.Drawing.SystemColors.Control;
            this.listBusca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBusca.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBusca.FullRowSelect = true;
            this.listBusca.HideSelection = false;
            this.listBusca.Location = new System.Drawing.Point(7, 24);
            this.listBusca.MultiSelect = false;
            this.listBusca.Name = "listBusca";
            this.listBusca.Size = new System.Drawing.Size(145, 535);
            this.listBusca.TabIndex = 70;
            this.listBusca.Tag = "CS";
            this.listBusca.UseCompatibleStateImageBehavior = false;
            this.listBusca.View = System.Windows.Forms.View.Tile;
            this.listBusca.SelectedIndexChanged += new System.EventHandler(this.listBusca_SelectedIndexChanged);
            // 
            // panelIma
            // 
            this.panelIma.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelIma.Controls.Add(this.picIma);
            this.panelIma.Location = new System.Drawing.Point(164, 24);
            this.panelIma.Name = "panelIma";
            this.panelIma.Size = new System.Drawing.Size(414, 535);
            this.panelIma.TabIndex = 69;
            // 
            // picIma
            // 
            this.picIma.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picIma.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picIma.Location = new System.Drawing.Point(6, 3);
            this.picIma.Name = "picIma";
            this.picIma.Size = new System.Drawing.Size(408, 529);
            this.picIma.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picIma.TabIndex = 69;
            this.picIma.TabStop = false;
            this.picIma.Click += new System.EventHandler(this.picIma_Click);
            this.picIma.DoubleClick += new System.EventHandler(this.picIma_DoubleClick);
            // 
            // lblRuta
            // 
            this.lblRuta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRuta.BackColor = System.Drawing.Color.Transparent;
            this.lblRuta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRuta.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRuta.Location = new System.Drawing.Point(0, 588);
            this.lblRuta.Name = "lblRuta";
            this.lblRuta.Size = new System.Drawing.Size(564, 18);
            this.lblRuta.TabIndex = 67;
            this.lblRuta.Tag = "XXXXXF";
            this.lblRuta.Text = "Nombre";
            // 
            // grbNombre
            // 
            this.grbNombre.Controls.Add(this.lblMor);
            this.grbNombre.Controls.Add(this.label3);
            this.grbNombre.Controls.Add(this.lblCliNombre);
            this.grbNombre.Controls.Add(this.label2);
            this.grbNombre.Controls.Add(this.lblCliDocu);
            this.grbNombre.Location = new System.Drawing.Point(4, 9);
            this.grbNombre.Name = "grbNombre";
            this.grbNombre.Size = new System.Drawing.Size(583, 67);
            this.grbNombre.TabIndex = 57;
            this.grbNombre.Text = "Cliente";
            this.grbNombre.Paint += new System.Windows.Forms.PaintEventHandler(this.grbNombre_Paint);
            // 
            // lblMor
            // 
            this.lblMor.BackColor = System.Drawing.Color.Black;
            this.lblMor.Location = new System.Drawing.Point(496, 40);
            this.lblMor.Name = "lblMor";
            this.lblMor.Size = new System.Drawing.Size(10, 22);
            this.lblMor.TabIndex = 1011;
            this.lblMor.Visible = false;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(386, 16);
            this.label3.TabIndex = 18;
            this.label3.Tag = "XXXXXF";
            this.label3.Text = "Nombre";
            // 
            // lblCliNombre
            // 
            this.lblCliNombre.BackColor = System.Drawing.Color.White;
            this.lblCliNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCliNombre.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblCliNombre.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliNombre.ForeColor = System.Drawing.Color.Black;
            this.lblCliNombre.Location = new System.Drawing.Point(7, 40);
            this.lblCliNombre.Name = "lblCliNombre";
            this.lblCliNombre.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.lblCliNombre.Size = new System.Drawing.Size(385, 22);
            this.lblCliNombre.TabIndex = 17;
            this.lblCliNombre.Tag = "";
            this.lblCliNombre.Text = "Eduardo Héctor Palermo Pinto";
            this.lblCliNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(404, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 16);
            this.label2.TabIndex = 15;
            this.label2.Tag = "XXXXXF";
            this.label2.Text = "Documento";
            // 
            // lblCliDocu
            // 
            this.lblCliDocu.BackColor = System.Drawing.Color.White;
            this.lblCliDocu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCliDocu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblCliDocu.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliDocu.ForeColor = System.Drawing.Color.Black;
            this.lblCliDocu.Location = new System.Drawing.Point(404, 40);
            this.lblCliDocu.Name = "lblCliDocu";
            this.lblCliDocu.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lblCliDocu.Size = new System.Drawing.Size(92, 22);
            this.lblCliDocu.TabIndex = 16;
            this.lblCliDocu.Tag = "";
            this.lblCliDocu.Text = "00.000.000";
            this.lblCliDocu.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // scan
            // 
            this.scan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.scan.Location = new System.Drawing.Point(593, 543);
            this.scan.Name = "scan";
            this.scan.Size = new System.Drawing.Size(75, 23);
            this.scan.TabIndex = 3;
            this.scan.Text = "Escanear";
            this.scan.UseVisualStyleBackColor = true;
            this.scan.Click += new System.EventHandler(this.scan_Click);
            // 
            // grbScan
            // 
            this.grbScan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbScan.Controls.Add(this.panelScan);
            this.grbScan.Location = new System.Drawing.Point(593, 8);
            this.grbScan.Name = "grbScan";
            this.grbScan.Size = new System.Drawing.Size(746, 529);
            this.grbScan.TabIndex = 60;
            this.grbScan.Text = "Imagen escaneada";
            this.grbScan.Paint += new System.Windows.Forms.PaintEventHandler(this.grbScan_Paint);
            // 
            // panelScan
            // 
            this.panelScan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelScan.Controls.Add(this.pictureScan);
            this.panelScan.Location = new System.Drawing.Point(6, 25);
            this.panelScan.Name = "panelScan";
            this.panelScan.Size = new System.Drawing.Size(735, 499);
            this.panelScan.TabIndex = 60;
            // 
            // pictureScan
            // 
            this.pictureScan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureScan.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureScan.Location = new System.Drawing.Point(1, 7);
            this.pictureScan.Name = "pictureScan";
            this.pictureScan.Size = new System.Drawing.Size(729, 489);
            this.pictureScan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureScan.TabIndex = 2;
            this.pictureScan.TabStop = false;
            this.pictureScan.DoubleClick += new System.EventHandler(this.pictureScan_DoubleClick);
            // 
            // Devices
            // 
            this.Devices.FormattingEnabled = true;
            this.Devices.Location = new System.Drawing.Point(593, 559);
            this.Devices.Name = "Devices";
            this.Devices.Size = new System.Drawing.Size(559, 108);
            this.Devices.TabIndex = 4;
            this.Devices.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1158, 633);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 34);
            this.button1.TabIndex = 3;
            this.button1.Text = "Listar Dispositivos";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // btnGrabar
            // 
            this.btnGrabar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGrabar.Location = new System.Drawing.Point(868, 543);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 61;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // lblNombCompleto
            // 
            this.lblNombCompleto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNombCompleto.BackColor = System.Drawing.Color.Transparent;
            this.lblNombCompleto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNombCompleto.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombCompleto.Location = new System.Drawing.Point(669, 548);
            this.lblNombCompleto.Name = "lblNombCompleto";
            this.lblNombCompleto.Size = new System.Drawing.Size(589, 18);
            this.lblNombCompleto.TabIndex = 68;
            this.lblNombCompleto.Tag = "XXXXXF";
            this.lblNombCompleto.Text = "Nombre";
            // 
            // btnEnvio
            // 
            this.btnEnvio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEnvio.Location = new System.Drawing.Point(787, 543);
            this.btnEnvio.Name = "btnEnvio";
            this.btnEnvio.Size = new System.Drawing.Size(75, 23);
            this.btnEnvio.TabIndex = 19;
            this.btnEnvio.Text = "Enviar todas";
            this.btnEnvio.UseVisualStyleBackColor = true;
            this.btnEnvio.Click += new System.EventHandler(this.btnEnvio_Click);
            // 
            // btnAcciones
            // 
            this.btnAcciones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAcciones.Location = new System.Drawing.Point(706, 543);
            this.btnAcciones.Name = "btnAcciones";
            this.btnAcciones.Size = new System.Drawing.Size(75, 23);
            this.btnAcciones.TabIndex = 69;
            this.btnAcciones.Text = "Buscar";
            this.btnAcciones.UseVisualStyleBackColor = true;
            this.btnAcciones.Click += new System.EventHandler(this.btnAcciones_Click);
            // 
            // grpAcciones
            // 
            this.grpAcciones.Controls.Add(this.lblAdd);
            this.grpAcciones.Controls.Add(this.lblAccPath);
            this.grpAcciones.Controls.Add(this.lblAccNombre);
            this.grpAcciones.Controls.Add(this.btnAccGrabar);
            this.grpAcciones.Controls.Add(this.btnAccCerrar);
            this.grpAcciones.Controls.Add(this.picImaNvo);
            this.grpAcciones.Controls.Add(this.btnDir);
            this.grpAcciones.Controls.Add(this.lblDir);
            this.grpAcciones.Location = new System.Drawing.Point(1304, 279);
            this.grpAcciones.Name = "grpAcciones";
            this.grpAcciones.Size = new System.Drawing.Size(638, 496);
            this.grpAcciones.TabIndex = 70;
            this.grpAcciones.TabStop = false;
            this.grpAcciones.Visible = false;
            // 
            // lblAdd
            // 
            this.lblAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblAdd.Location = new System.Drawing.Point(6, 16);
            this.lblAdd.Name = "lblAdd";
            this.lblAdd.Size = new System.Drawing.Size(616, 21);
            this.lblAdd.TabIndex = 75;
            this.lblAdd.Tag = "XXXXB";
            this.lblAdd.Text = "Búsqueda de imágenes";
            this.lblAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAccPath
            // 
            this.lblAccPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAccPath.Location = new System.Drawing.Point(348, 225);
            this.lblAccPath.Name = "lblAccPath";
            this.lblAccPath.Size = new System.Drawing.Size(284, 19);
            this.lblAccPath.TabIndex = 74;
            this.lblAccPath.Text = "label1";
            this.lblAccPath.Visible = false;
            // 
            // lblAccNombre
            // 
            this.lblAccNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAccNombre.Location = new System.Drawing.Point(318, 157);
            this.lblAccNombre.Name = "lblAccNombre";
            this.lblAccNombre.Size = new System.Drawing.Size(284, 19);
            this.lblAccNombre.TabIndex = 73;
            this.lblAccNombre.Text = "label1";
            this.lblAccNombre.Visible = false;
            // 
            // btnAccGrabar
            // 
            this.btnAccGrabar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccGrabar.Location = new System.Drawing.Point(547, 94);
            this.btnAccGrabar.Name = "btnAccGrabar";
            this.btnAccGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnAccGrabar.TabIndex = 72;
            this.btnAccGrabar.Text = "Grabar";
            this.btnAccGrabar.UseVisualStyleBackColor = true;
            this.btnAccGrabar.Click += new System.EventHandler(this.btnAccGrabar_Click);
            // 
            // btnAccCerrar
            // 
            this.btnAccCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccCerrar.Location = new System.Drawing.Point(547, 467);
            this.btnAccCerrar.Name = "btnAccCerrar";
            this.btnAccCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnAccCerrar.TabIndex = 71;
            this.btnAccCerrar.Text = "Cerrar";
            this.btnAccCerrar.UseVisualStyleBackColor = true;
            this.btnAccCerrar.Click += new System.EventHandler(this.btnAccCerrar_Click);
            // 
            // picImaNvo
            // 
            this.picImaNvo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picImaNvo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picImaNvo.Location = new System.Drawing.Point(6, 74);
            this.picImaNvo.Name = "picImaNvo";
            this.picImaNvo.Size = new System.Drawing.Size(509, 416);
            this.picImaNvo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImaNvo.TabIndex = 70;
            this.picImaNvo.TabStop = false;
            // 
            // btnDir
            // 
            this.btnDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDir.Location = new System.Drawing.Point(591, 42);
            this.btnDir.Name = "btnDir";
            this.btnDir.Size = new System.Drawing.Size(31, 29);
            this.btnDir.TabIndex = 1;
            this.btnDir.Text = "...";
            this.btnDir.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDir.UseVisualStyleBackColor = true;
            this.btnDir.Click += new System.EventHandler(this.btnDir_Click);
            // 
            // lblDir
            // 
            this.lblDir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDir.Location = new System.Drawing.Point(6, 52);
            this.lblDir.Name = "lblDir";
            this.lblDir.Size = new System.Drawing.Size(579, 19);
            this.lblDir.TabIndex = 0;
            this.lblDir.Text = "label1";
            // 
            // ofd
            // 
            this.ofd.FileName = "openFileDialog1";
            // 
            // bgLista
            // 
            this.bgLista.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgLista_DoWork);
            this.bgLista.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgLista_RunWorkerCompleted);
            // 
            // panelSoli
            // 
            this.panelSoli.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelSoli.Controls.Add(this.lblSoliTit);
            this.panelSoli.Controls.Add(this.lblSoli);
            this.panelSoli.Controls.Add(this.btnSoliCancel);
            this.panelSoli.Controls.Add(this.btnSoliGrabar);
            this.panelSoli.Controls.Add(this.Ops3);
            this.panelSoli.Controls.Add(this.Ops2);
            this.panelSoli.Controls.Add(this.Ops1);
            this.panelSoli.Location = new System.Drawing.Point(963, 574);
            this.panelSoli.Name = "panelSoli";
            this.panelSoli.Size = new System.Drawing.Size(254, 114);
            this.panelSoli.TabIndex = 76;
            this.panelSoli.Visible = false;
            // 
            // lblSoliTit
            // 
            this.lblSoliTit.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblSoliTit.Location = new System.Drawing.Point(0, 0);
            this.lblSoliTit.Name = "lblSoliTit";
            this.lblSoliTit.Size = new System.Drawing.Size(250, 19);
            this.lblSoliTit.TabIndex = 73;
            this.lblSoliTit.Text = "Grabar solicitud";
            this.lblSoliTit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSoli
            // 
            this.lblSoli.AutoSize = true;
            this.lblSoli.Location = new System.Drawing.Point(3, 18);
            this.lblSoli.Name = "lblSoli";
            this.lblSoli.Size = new System.Drawing.Size(35, 13);
            this.lblSoli.TabIndex = 72;
            this.lblSoli.Text = "label1";
            // 
            // btnSoliCancel
            // 
            this.btnSoliCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSoliCancel.Location = new System.Drawing.Point(154, 75);
            this.btnSoliCancel.Name = "btnSoliCancel";
            this.btnSoliCancel.Size = new System.Drawing.Size(75, 23);
            this.btnSoliCancel.TabIndex = 71;
            this.btnSoliCancel.Text = "Cancelar";
            this.btnSoliCancel.UseVisualStyleBackColor = true;
            this.btnSoliCancel.Click += new System.EventHandler(this.btnSoliCancel_Click);
            // 
            // btnSoliGrabar
            // 
            this.btnSoliGrabar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSoliGrabar.Location = new System.Drawing.Point(154, 36);
            this.btnSoliGrabar.Name = "btnSoliGrabar";
            this.btnSoliGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnSoliGrabar.TabIndex = 70;
            this.btnSoliGrabar.Text = "Grabar";
            this.btnSoliGrabar.UseVisualStyleBackColor = true;
            this.btnSoliGrabar.Click += new System.EventHandler(this.btnSoliGrabar_Click);
            // 
            // Ops3
            // 
            this.Ops3.AutoSize = true;
            this.Ops3.Location = new System.Drawing.Point(44, 84);
            this.Ops3.Name = "Ops3";
            this.Ops3.Size = new System.Drawing.Size(80, 17);
            this.Ops3.TabIndex = 2;
            this.Ops3.TabStop = true;
            this.Ops3.Text = "Solicitud 03";
            this.Ops3.UseVisualStyleBackColor = true;
            this.Ops3.CheckedChanged += new System.EventHandler(this.Ops3_CheckedChanged);
            // 
            // Ops2
            // 
            this.Ops2.AutoSize = true;
            this.Ops2.Location = new System.Drawing.Point(44, 59);
            this.Ops2.Name = "Ops2";
            this.Ops2.Size = new System.Drawing.Size(80, 17);
            this.Ops2.TabIndex = 1;
            this.Ops2.TabStop = true;
            this.Ops2.Text = "Solicitud 02";
            this.Ops2.UseVisualStyleBackColor = true;
            this.Ops2.CheckedChanged += new System.EventHandler(this.Ops2_CheckedChanged);
            // 
            // Ops1
            // 
            this.Ops1.AutoSize = true;
            this.Ops1.Location = new System.Drawing.Point(44, 36);
            this.Ops1.Name = "Ops1";
            this.Ops1.Size = new System.Drawing.Size(80, 17);
            this.Ops1.TabIndex = 0;
            this.Ops1.TabStop = true;
            this.Ops1.Text = "Solicitud 01";
            this.Ops1.UseVisualStyleBackColor = true;
            this.Ops1.CheckedChanged += new System.EventHandler(this.Ops1_CheckedChanged);
            // 
            // lblSombra
            // 
            this.lblSombra.BackColor = System.Drawing.Color.Black;
            this.lblSombra.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSombra.ForeColor = System.Drawing.Color.Black;
            this.lblSombra.Location = new System.Drawing.Point(1239, 594);
            this.lblSombra.Name = "lblSombra";
            this.lblSombra.Size = new System.Drawing.Size(48, 81);
            this.lblSombra.TabIndex = 77;
            this.lblSombra.Visible = false;
            // 
            // frmScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 694);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.panelSoli);
            this.Controls.Add(this.lblSombra);
            this.Controls.Add(this.grpAcciones);
            this.Controls.Add(this.btnAcciones);
            this.Controls.Add(this.btnEnvio);
            this.Controls.Add(this.lblNombCompleto);
            this.Controls.Add(this.Devices);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.grbScan);
            this.Controls.Add(this.grb);
            this.Controls.Add(this.grbNombre);
            this.Controls.Add(this.scan);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmScan";
            this.Text = "Digitalización de imágenes";
            this.Load += new System.EventHandler(this.frmScan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grb)).EndInit();
            this.grb.ResumeLayout(false);
            this.panelIma.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picIma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grbNombre)).EndInit();
            this.grbNombre.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grbScan)).EndInit();
            this.grbScan.ResumeLayout(false);
            this.panelScan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureScan)).EndInit();
            this.grpAcciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picImaNvo)).EndInit();
            this.panelSoli.ResumeLayout(false);
            this.panelSoli.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button scan;
        private DevExpress.XtraEditors.GroupControl grbNombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCliNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCliDocu;
        private DevExpress.XtraEditors.GroupControl grb;
        private System.Windows.Forms.Label lblRuta;
        private DevExpress.XtraEditors.GroupControl grbScan;
        private System.Windows.Forms.Panel panelScan;
        private System.Windows.Forms.PictureBox pictureScan;
        private System.Windows.Forms.ListBox Devices;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.ListView listBusca;
        private System.Windows.Forms.Panel panelIma;
        private System.Windows.Forms.PictureBox picIma;
        private System.Windows.Forms.Label lblNombCompleto;
        private System.Windows.Forms.Button btnEnvio;
        private System.Windows.Forms.Button btnAcciones;
        private System.Windows.Forms.GroupBox grpAcciones;
        private System.Windows.Forms.Button btnDir;
        private System.Windows.Forms.Label lblDir;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.PictureBox picImaNvo;
        private System.Windows.Forms.Button btnAccGrabar;
        private System.Windows.Forms.Button btnAccCerrar;
        private System.Windows.Forms.Label lblAccNombre;
        private System.Windows.Forms.Label lblAccPath;
        private System.Windows.Forms.Label lblAdd;
        private System.ComponentModel.BackgroundWorker bgLista;
        private DevExpress.XtraEditors.SimpleButton btnImaSiguiente;
        private DevExpress.XtraEditors.SimpleButton btnImaAnterior;
        private System.Windows.Forms.Label lblIma;
        private System.Windows.Forms.Button btnEnvioIma;
        private System.Windows.Forms.Label lblMor;
        private System.Windows.Forms.Panel panelSoli;
        private System.Windows.Forms.RadioButton Ops3;
        private System.Windows.Forms.RadioButton Ops2;
        private System.Windows.Forms.RadioButton Ops1;
        private System.Windows.Forms.Button btnSoliCancel;
        private System.Windows.Forms.Button btnSoliGrabar;
        private System.Windows.Forms.Label lblSoli;
        private System.Windows.Forms.Label lblSoliTit;
        private System.Windows.Forms.Label lblSombra;
    }
}