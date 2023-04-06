namespace iComercio.Forms
{
    partial class frmRecibos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecibos));
            this.btnAgregar = new System.Windows.Forms.Button();
            this.grbTransDep = new DevExpress.XtraEditors.GroupControl();
            this.btnCargarInfoDummy = new System.Windows.Forms.Button();
            this.txtCheque = new System.Windows.Forms.TextBox();
            this.lblNCheque = new System.Windows.Forms.Label();
            this.txtTransDep = new System.Windows.Forms.TextBox();
            this.lblcheque = new System.Windows.Forms.Label();
            this.lblTransDep = new System.Windows.Forms.Label();
            this.cmbCheque = new System.Windows.Forms.ComboBox();
            this.lblDestino = new System.Windows.Forms.Label();
            this.cmbDestino = new System.Windows.Forms.ComboBox();
            this.lblOrigen = new System.Windows.Forms.Label();
            this.cmbOrigen = new System.Windows.Forms.ComboBox();
            this.grbRecibos = new DevExpress.XtraEditors.GroupControl();
            this.lblComAdh = new System.Windows.Forms.Label();
            this.cmbComAdh = new System.Windows.Forms.ComboBox();
            this.txtComprobante = new System.Windows.Forms.TextBox();
            this.lblComprobante = new System.Windows.Forms.Label();
            this.lblReferencia = new System.Windows.Forms.Label();
            this.cmbReferencia = new System.Windows.Forms.ComboBox();
            this.txtNotas = new System.Windows.Forms.TextBox();
            this.lblNotas = new System.Windows.Forms.Label();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.lblImporte = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblTipoMovimiento = new System.Windows.Forms.Label();
            this.lblCuenta = new System.Windows.Forms.Label();
            this.cmbMovimientos = new System.Windows.Forms.ComboBox();
            this.btnScan = new System.Windows.Forms.Button();
            this.btnOtro = new System.Windows.Forms.Button();
            this.lblID = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grbTransDep)).BeginInit();
            this.grbTransDep.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grbRecibos)).BeginInit();
            this.grbRecibos.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregar.Location = new System.Drawing.Point(552, 402);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 12;
            this.btnAgregar.Text = "Grabar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // grbTransDep
            // 
            this.grbTransDep.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbTransDep.Controls.Add(this.btnCargarInfoDummy);
            this.grbTransDep.Controls.Add(this.txtCheque);
            this.grbTransDep.Controls.Add(this.lblNCheque);
            this.grbTransDep.Controls.Add(this.txtTransDep);
            this.grbTransDep.Controls.Add(this.lblcheque);
            this.grbTransDep.Controls.Add(this.lblTransDep);
            this.grbTransDep.Controls.Add(this.cmbCheque);
            this.grbTransDep.Controls.Add(this.lblDestino);
            this.grbTransDep.Controls.Add(this.cmbDestino);
            this.grbTransDep.Controls.Add(this.lblOrigen);
            this.grbTransDep.Controls.Add(this.cmbOrigen);
            this.grbTransDep.Location = new System.Drawing.Point(10, 210);
            this.grbTransDep.Name = "grbTransDep";
            this.grbTransDep.Size = new System.Drawing.Size(617, 183);
            this.grbTransDep.TabIndex = 1;
            this.grbTransDep.Text = "Transferencias y Depósitos";
            // 
            // btnCargarInfoDummy
            // 
            this.btnCargarInfoDummy.Location = new System.Drawing.Point(525, 154);
            this.btnCargarInfoDummy.Name = "btnCargarInfoDummy";
            this.btnCargarInfoDummy.Size = new System.Drawing.Size(75, 23);
            this.btnCargarInfoDummy.TabIndex = 2;
            this.btnCargarInfoDummy.Text = "Cargar Info";
            this.btnCargarInfoDummy.UseVisualStyleBackColor = true;
            this.btnCargarInfoDummy.Visible = false;
            this.btnCargarInfoDummy.Click += new System.EventHandler(this.btnCargarInfoDummy_Click);
            // 
            // txtCheque
            // 
            this.txtCheque.Location = new System.Drawing.Point(106, 154);
            this.txtCheque.Name = "txtCheque";
            this.txtCheque.Size = new System.Drawing.Size(130, 20);
            this.txtCheque.TabIndex = 11;
            // 
            // lblNCheque
            // 
            this.lblNCheque.AutoSize = true;
            this.lblNCheque.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.lblNCheque.Location = new System.Drawing.Point(29, 157);
            this.lblNCheque.Name = "lblNCheque";
            this.lblNCheque.Size = new System.Drawing.Size(62, 13);
            this.lblNCheque.TabIndex = 15;
            this.lblNCheque.Text = "Nº Cheque:";
            // 
            // txtTransDep
            // 
            this.txtTransDep.Location = new System.Drawing.Point(106, 123);
            this.txtTransDep.Name = "txtTransDep";
            this.txtTransDep.Size = new System.Drawing.Size(130, 20);
            this.txtTransDep.TabIndex = 10;
            // 
            // lblcheque
            // 
            this.lblcheque.AutoSize = true;
            this.lblcheque.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.lblcheque.Location = new System.Drawing.Point(44, 93);
            this.lblcheque.Name = "lblcheque";
            this.lblcheque.Size = new System.Drawing.Size(47, 13);
            this.lblcheque.TabIndex = 7;
            this.lblcheque.Text = "Cheque:";
            // 
            // lblTransDep
            // 
            this.lblTransDep.AutoSize = true;
            this.lblTransDep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.lblTransDep.Location = new System.Drawing.Point(17, 126);
            this.lblTransDep.Name = "lblTransDep";
            this.lblTransDep.Size = new System.Drawing.Size(74, 13);
            this.lblTransDep.TabIndex = 13;
            this.lblTransDep.Text = "Nº Trans/Dep";
            // 
            // cmbCheque
            // 
            this.cmbCheque.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCheque.FormattingEnabled = true;
            this.cmbCheque.Location = new System.Drawing.Point(106, 90);
            this.cmbCheque.Name = "cmbCheque";
            this.cmbCheque.Size = new System.Drawing.Size(494, 21);
            this.cmbCheque.TabIndex = 9;
            this.cmbCheque.SelectedIndexChanged += new System.EventHandler(this.cmbCheque_SelectedIndexChanged);
            // 
            // lblDestino
            // 
            this.lblDestino.AutoSize = true;
            this.lblDestino.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.lblDestino.Location = new System.Drawing.Point(45, 65);
            this.lblDestino.Name = "lblDestino";
            this.lblDestino.Size = new System.Drawing.Size(46, 13);
            this.lblDestino.TabIndex = 5;
            this.lblDestino.Text = "Destino:";
            // 
            // cmbDestino
            // 
            this.cmbDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDestino.FormattingEnabled = true;
            this.cmbDestino.Location = new System.Drawing.Point(106, 62);
            this.cmbDestino.Name = "cmbDestino";
            this.cmbDestino.Size = new System.Drawing.Size(494, 21);
            this.cmbDestino.TabIndex = 8;
            this.cmbDestino.SelectedIndexChanged += new System.EventHandler(this.cmbDestino_SelectedIndexChanged);
            // 
            // lblOrigen
            // 
            this.lblOrigen.AutoSize = true;
            this.lblOrigen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.lblOrigen.Location = new System.Drawing.Point(50, 35);
            this.lblOrigen.Name = "lblOrigen";
            this.lblOrigen.Size = new System.Drawing.Size(41, 13);
            this.lblOrigen.TabIndex = 3;
            this.lblOrigen.Text = "Origen:";
            // 
            // cmbOrigen
            // 
            this.cmbOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrigen.FormattingEnabled = true;
            this.cmbOrigen.Location = new System.Drawing.Point(106, 32);
            this.cmbOrigen.Name = "cmbOrigen";
            this.cmbOrigen.Size = new System.Drawing.Size(494, 21);
            this.cmbOrigen.TabIndex = 7;
            this.cmbOrigen.SelectedIndexChanged += new System.EventHandler(this.cmbOrigen_SelectedIndexChanged);
            // 
            // grbRecibos
            // 
            this.grbRecibos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbRecibos.Controls.Add(this.lblComAdh);
            this.grbRecibos.Controls.Add(this.cmbComAdh);
            this.grbRecibos.Controls.Add(this.txtComprobante);
            this.grbRecibos.Controls.Add(this.lblComprobante);
            this.grbRecibos.Controls.Add(this.lblReferencia);
            this.grbRecibos.Controls.Add(this.cmbReferencia);
            this.grbRecibos.Controls.Add(this.txtNotas);
            this.grbRecibos.Controls.Add(this.lblNotas);
            this.grbRecibos.Controls.Add(this.txtImporte);
            this.grbRecibos.Controls.Add(this.lblImporte);
            this.grbRecibos.Controls.Add(this.lblFecha);
            this.grbRecibos.Controls.Add(this.dtpFecha);
            this.grbRecibos.Controls.Add(this.lblTipoMovimiento);
            this.grbRecibos.Controls.Add(this.lblCuenta);
            this.grbRecibos.Controls.Add(this.cmbMovimientos);
            this.grbRecibos.Location = new System.Drawing.Point(10, 4);
            this.grbRecibos.Name = "grbRecibos";
            this.grbRecibos.Size = new System.Drawing.Size(617, 200);
            this.grbRecibos.TabIndex = 0;
            this.grbRecibos.Text = "Recibos";
            // 
            // lblComAdh
            // 
            this.lblComAdh.AutoSize = true;
            this.lblComAdh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.lblComAdh.Location = new System.Drawing.Point(38, 105);
            this.lblComAdh.Name = "lblComAdh";
            this.lblComAdh.Size = new System.Drawing.Size(54, 13);
            this.lblComAdh.TabIndex = 15;
            this.lblComAdh.Text = "Comercio:";
            this.lblComAdh.Visible = false;
            // 
            // cmbComAdh
            // 
            this.cmbComAdh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbComAdh.FormattingEnabled = true;
            this.cmbComAdh.Location = new System.Drawing.Point(104, 101);
            this.cmbComAdh.Name = "cmbComAdh";
            this.cmbComAdh.Size = new System.Drawing.Size(496, 21);
            this.cmbComAdh.TabIndex = 14;
            this.cmbComAdh.Visible = false;
            this.cmbComAdh.SelectedIndexChanged += new System.EventHandler(this.cmbComAdh_SelectedIndexChanged);
            // 
            // txtComprobante
            // 
            this.txtComprobante.Location = new System.Drawing.Point(417, 35);
            this.txtComprobante.Name = "txtComprobante";
            this.txtComprobante.Size = new System.Drawing.Size(94, 20);
            this.txtComprobante.TabIndex = 3;
            this.txtComprobante.Tag = "NXXL";
            // 
            // lblComprobante
            // 
            this.lblComprobante.AutoSize = true;
            this.lblComprobante.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.lblComprobante.Location = new System.Drawing.Point(344, 38);
            this.lblComprobante.Name = "lblComprobante";
            this.lblComprobante.Size = new System.Drawing.Size(73, 13);
            this.lblComprobante.TabIndex = 13;
            this.lblComprobante.Text = "Comprobante:";
            // 
            // lblReferencia
            // 
            this.lblReferencia.AutoSize = true;
            this.lblReferencia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.lblReferencia.Location = new System.Drawing.Point(30, 92);
            this.lblReferencia.Name = "lblReferencia";
            this.lblReferencia.Size = new System.Drawing.Size(62, 13);
            this.lblReferencia.TabIndex = 12;
            this.lblReferencia.Text = "Referencia:";
            // 
            // cmbReferencia
            // 
            this.cmbReferencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReferencia.FormattingEnabled = true;
            this.cmbReferencia.Location = new System.Drawing.Point(104, 88);
            this.cmbReferencia.Name = "cmbReferencia";
            this.cmbReferencia.Size = new System.Drawing.Size(496, 21);
            this.cmbReferencia.TabIndex = 5;
            this.cmbReferencia.SelectedIndexChanged += new System.EventHandler(this.cmbReferencia_SelectedIndexChanged);
            // 
            // txtNotas
            // 
            this.txtNotas.Location = new System.Drawing.Point(104, 121);
            this.txtNotas.Multiline = true;
            this.txtNotas.Name = "txtNotas";
            this.txtNotas.Size = new System.Drawing.Size(496, 74);
            this.txtNotas.TabIndex = 6;
            // 
            // lblNotas
            // 
            this.lblNotas.AutoSize = true;
            this.lblNotas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.lblNotas.Location = new System.Drawing.Point(54, 125);
            this.lblNotas.Name = "lblNotas";
            this.lblNotas.Size = new System.Drawing.Size(38, 13);
            this.lblNotas.TabIndex = 7;
            this.lblNotas.Text = "Notas:";
            // 
            // txtImporte
            // 
            this.txtImporte.Location = new System.Drawing.Point(238, 35);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(94, 20);
            this.txtImporte.TabIndex = 2;
            this.txtImporte.Tag = "D";
            this.txtImporte.Leave += new System.EventHandler(this.txtImporte_Leave);
            // 
            // lblImporte
            // 
            this.lblImporte.AutoSize = true;
            this.lblImporte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.lblImporte.Location = new System.Drawing.Point(192, 38);
            this.lblImporte.Name = "lblImporte";
            this.lblImporte.Size = new System.Drawing.Size(45, 13);
            this.lblImporte.TabIndex = 5;
            this.lblImporte.Text = "Importe:";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.lblFecha.Location = new System.Drawing.Point(52, 36);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(40, 13);
            this.lblFecha.TabIndex = 4;
            this.lblFecha.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(104, 35);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(82, 20);
            this.dtpFecha.TabIndex = 1;
            // 
            // lblTipoMovimiento
            // 
            this.lblTipoMovimiento.AutoSize = true;
            this.lblTipoMovimiento.BackColor = System.Drawing.SystemColors.Control;
            this.lblTipoMovimiento.Location = new System.Drawing.Point(518, 63);
            this.lblTipoMovimiento.Name = "lblTipoMovimiento";
            this.lblTipoMovimiento.Size = new System.Drawing.Size(82, 13);
            this.lblTipoMovimiento.TabIndex = 2;
            this.lblTipoMovimiento.Text = "TipoMovimiento";
            // 
            // lblCuenta
            // 
            this.lblCuenta.AutoSize = true;
            this.lblCuenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.lblCuenta.Location = new System.Drawing.Point(28, 64);
            this.lblCuenta.Name = "lblCuenta";
            this.lblCuenta.Size = new System.Drawing.Size(64, 13);
            this.lblCuenta.TabIndex = 1;
            this.lblCuenta.Text = "Movimiento:";
            // 
            // cmbMovimientos
            // 
            this.cmbMovimientos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMovimientos.FormattingEnabled = true;
            this.cmbMovimientos.Location = new System.Drawing.Point(104, 60);
            this.cmbMovimientos.Name = "cmbMovimientos";
            this.cmbMovimientos.Size = new System.Drawing.Size(413, 21);
            this.cmbMovimientos.TabIndex = 4;
            this.cmbMovimientos.SelectedIndexChanged += new System.EventHandler(this.cmbMovimientos_SelectedIndexChanged);
            // 
            // btnScan
            // 
            this.btnScan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnScan.Location = new System.Drawing.Point(390, 402);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(75, 23);
            this.btnScan.TabIndex = 16;
            this.btnScan.Text = "Escanear";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Visible = false;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // btnOtro
            // 
            this.btnOtro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOtro.Location = new System.Drawing.Point(471, 402);
            this.btnOtro.Name = "btnOtro";
            this.btnOtro.Size = new System.Drawing.Size(75, 23);
            this.btnOtro.TabIndex = 13;
            this.btnOtro.Text = "Otro";
            this.btnOtro.UseVisualStyleBackColor = true;
            this.btnOtro.Click += new System.EventHandler(this.btnOtro_Click);
            // 
            // lblID
            // 
            this.lblID.Location = new System.Drawing.Point(155, 413);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(122, 12);
            this.lblID.TabIndex = 17;
            this.lblID.Text = "label1";
            this.lblID.Visible = false;
            // 
            // frmRecibos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 433);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.btnScan);
            this.Controls.Add(this.btnOtro);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.grbTransDep);
            this.Controls.Add(this.grbRecibos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRecibos";
            this.Text = "Recibos";
            this.Load += new System.EventHandler(this.frmRecibos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grbTransDep)).EndInit();
            this.grbTransDep.ResumeLayout(false);
            this.grbTransDep.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grbRecibos)).EndInit();
            this.grbRecibos.ResumeLayout(false);
            this.grbRecibos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grbRecibos;
        private System.Windows.Forms.TextBox txtNotas;
        private System.Windows.Forms.Label lblNotas;
        private System.Windows.Forms.TextBox txtImporte;
        private System.Windows.Forms.Label lblImporte;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblTipoMovimiento;
        private System.Windows.Forms.Label lblCuenta;
        private System.Windows.Forms.ComboBox cmbMovimientos;
        private DevExpress.XtraEditors.GroupControl grbTransDep;
        private System.Windows.Forms.Label lblcheque;
        private System.Windows.Forms.ComboBox cmbCheque;
        private System.Windows.Forms.Label lblDestino;
        private System.Windows.Forms.ComboBox cmbDestino;
        private System.Windows.Forms.Label lblOrigen;
        private System.Windows.Forms.ComboBox cmbOrigen;
        private System.Windows.Forms.Label lblReferencia;
        private System.Windows.Forms.ComboBox cmbReferencia;
        private System.Windows.Forms.TextBox txtCheque;
        private System.Windows.Forms.Label lblNCheque;
        private System.Windows.Forms.TextBox txtTransDep;
        private System.Windows.Forms.Label lblTransDep;
        private System.Windows.Forms.TextBox txtComprobante;
        private System.Windows.Forms.Label lblComprobante;
        private System.Windows.Forms.Button btnCargarInfoDummy;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label lblComAdh;
        private System.Windows.Forms.ComboBox cmbComAdh;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.Button btnOtro;
        private System.Windows.Forms.Label lblID;
    }
}