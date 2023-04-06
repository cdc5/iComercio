namespace iComercio.Forms
{
    partial class FrmListadoRecibos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmListadoRecibos));
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMensa = new System.Windows.Forms.Label();
            this.btnAnula = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.listBusca = new System.Windows.Forms.ListView();
            this.grpFecha = new System.Windows.Forms.GroupBox();
            this.lblComercio = new System.Windows.Forms.Label();
            this.cmbComercio = new System.Windows.Forms.ComboBox();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.lblDesde = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblMor = new System.Windows.Forms.Label();
            this.grpFecha.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(846, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 85;
            this.label6.Text = "Comercio:";
            this.label6.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(683, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 84;
            this.label5.Text = "Comercio:";
            this.label5.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(683, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 83;
            this.label4.Text = "Comercio:";
            this.label4.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(683, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 82;
            this.label3.Text = "Comercio:";
            this.label3.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(683, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 81;
            this.label2.Text = "Comercio:";
            this.label2.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(683, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 80;
            this.label1.Text = "Comercio:";
            this.label1.Visible = false;
            // 
            // lblMensa
            // 
            this.lblMensa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMensa.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblMensa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMensa.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensa.ForeColor = System.Drawing.Color.Blue;
            this.lblMensa.Location = new System.Drawing.Point(12, 87);
            this.lblMensa.Name = "lblMensa";
            this.lblMensa.Size = new System.Drawing.Size(921, 26);
            this.lblMensa.TabIndex = 79;
            this.lblMensa.Tag = "XXXXBF";
            this.lblMensa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAnula
            // 
            this.btnAnula.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAnula.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnula.Location = new System.Drawing.Point(12, 354);
            this.btnAnula.Name = "btnAnula";
            this.btnAnula.Size = new System.Drawing.Size(92, 26);
            this.btnAnula.TabIndex = 14;
            this.btnAnula.Text = "Anular";
            this.btnAnula.UseVisualStyleBackColor = true;
            this.btnAnula.Click += new System.EventHandler(this.btnAnula_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.Location = new System.Drawing.Point(110, 354);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(92, 26);
            this.btnNuevo.TabIndex = 13;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(373, 18);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(206, 26);
            this.btnBuscar.TabIndex = 11;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(841, 354);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(92, 26);
            this.btnSalir.TabIndex = 12;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
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
            this.listBusca.GridLines = true;
            this.listBusca.HideSelection = false;
            this.listBusca.Location = new System.Drawing.Point(12, 116);
            this.listBusca.MultiSelect = false;
            this.listBusca.Name = "listBusca";
            this.listBusca.Size = new System.Drawing.Size(921, 232);
            this.listBusca.TabIndex = 4;
            this.listBusca.UseCompatibleStateImageBehavior = false;
            this.listBusca.View = System.Windows.Forms.View.Tile;
            this.listBusca.SelectedIndexChanged += new System.EventHandler(this.listBusca_SelectedIndexChanged);
            this.listBusca.DoubleClick += new System.EventHandler(this.listBusca_DoubleClick);
            // 
            // grpFecha
            // 
            this.grpFecha.Controls.Add(this.lblMor);
            this.grpFecha.Controls.Add(this.lblComercio);
            this.grpFecha.Controls.Add(this.cmbComercio);
            this.grpFecha.Controls.Add(this.lblHasta);
            this.grpFecha.Controls.Add(this.dtpHasta);
            this.grpFecha.Controls.Add(this.lblDesde);
            this.grpFecha.Controls.Add(this.dtpDesde);
            this.grpFecha.Location = new System.Drawing.Point(13, 9);
            this.grpFecha.Name = "grpFecha";
            this.grpFecha.Size = new System.Drawing.Size(354, 74);
            this.grpFecha.TabIndex = 0;
            this.grpFecha.TabStop = false;
            // 
            // lblComercio
            // 
            this.lblComercio.AutoSize = true;
            this.lblComercio.Location = new System.Drawing.Point(6, 16);
            this.lblComercio.Name = "lblComercio";
            this.lblComercio.Size = new System.Drawing.Size(54, 13);
            this.lblComercio.TabIndex = 13;
            this.lblComercio.Text = "Comercio:";
            // 
            // cmbComercio
            // 
            this.cmbComercio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbComercio.FormattingEnabled = true;
            this.cmbComercio.Location = new System.Drawing.Point(78, 13);
            this.cmbComercio.Name = "cmbComercio";
            this.cmbComercio.Size = new System.Drawing.Size(249, 21);
            this.cmbComercio.TabIndex = 12;
            this.cmbComercio.SelectedIndexChanged += new System.EventHandler(this.cmbComercio_SelectedIndexChanged);
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(183, 44);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(38, 13);
            this.lblHasta.TabIndex = 10;
            this.lblHasta.Text = "Hasta:";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Checked = false;
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(228, 41);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(99, 20);
            this.dtpHasta.TabIndex = 9;
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Location = new System.Drawing.Point(6, 44);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(41, 13);
            this.lblDesde.TabIndex = 8;
            this.lblDesde.Text = "Desde:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(78, 40);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(99, 20);
            this.dtpDesde.TabIndex = 7;
            // 
            // lblMor
            // 
            this.lblMor.BackColor = System.Drawing.Color.Black;
            this.lblMor.Location = new System.Drawing.Point(327, 13);
            this.lblMor.Name = "lblMor";
            this.lblMor.Size = new System.Drawing.Size(8, 22);
            this.lblMor.TabIndex = 1010;
            this.lblMor.Visible = false;
            // 
            // FrmListadoRecibos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 389);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblMensa);
            this.Controls.Add(this.btnAnula);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.listBusca);
            this.Controls.Add(this.grpFecha);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FrmListadoRecibos";
            this.Text = "Anulación de Recibos";
            this.Load += new System.EventHandler(this.FrmCtaCteAnula_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmListadoRecibos_KeyDown);
            this.grpFecha.ResumeLayout(false);
            this.grpFecha.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpFecha;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.ListView listBusca;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnAnula;
        private System.Windows.Forms.Label lblMensa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblComercio;
        private System.Windows.Forms.ComboBox cmbComercio;
        private System.Windows.Forms.Label lblMor;
    }
}