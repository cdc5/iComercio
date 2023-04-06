namespace iComercio.Forms
{
    partial class FrmDomicilio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDomicilio));
            this.lblCP = new System.Windows.Forms.Panel();
            this.txtComplemento = new System.Windows.Forms.TextBox();
            this.cmbLocalidad = new System.Windows.Forms.ComboBox();
            this.txtNotas = new System.Windows.Forms.TextBox();
            this.cmbProvincia = new System.Windows.Forms.ComboBox();
            this.txtDpto = new System.Windows.Forms.TextBox();
            this.txtPiso = new System.Windows.Forms.TextBox();
            this.txtNro = new System.Windows.Forms.TextBox();
            this.txtCalle = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grpBuscar = new DevExpress.XtraEditors.GroupControl();
            this.lblDomNomb = new System.Windows.Forms.Label();
            this.lblDomCodDocu = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDomDocu = new System.Windows.Forms.Label();
            this.lblCartel = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            this.txtCP = new System.Windows.Forms.TextBox();
            this.lblCP.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpBuscar)).BeginInit();
            this.grpBuscar.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCP
            // 
            this.lblCP.BackColor = System.Drawing.Color.Transparent;
            this.lblCP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCP.Controls.Add(this.label66);
            this.lblCP.Controls.Add(this.txtCP);
            this.lblCP.Controls.Add(this.txtComplemento);
            this.lblCP.Controls.Add(this.cmbLocalidad);
            this.lblCP.Controls.Add(this.txtNotas);
            this.lblCP.Controls.Add(this.cmbProvincia);
            this.lblCP.Controls.Add(this.txtDpto);
            this.lblCP.Controls.Add(this.txtPiso);
            this.lblCP.Controls.Add(this.txtNro);
            this.lblCP.Controls.Add(this.txtCalle);
            this.lblCP.Controls.Add(this.groupBox1);
            this.lblCP.Controls.Add(this.cmbEstado);
            this.lblCP.Controls.Add(this.lblEstado);
            this.lblCP.Controls.Add(this.label10);
            this.lblCP.Controls.Add(this.label9);
            this.lblCP.Controls.Add(this.label8);
            this.lblCP.Controls.Add(this.label7);
            this.lblCP.Controls.Add(this.label6);
            this.lblCP.Controls.Add(this.label5);
            this.lblCP.Controls.Add(this.label4);
            this.lblCP.Controls.Add(this.label1);
            this.lblCP.Controls.Add(this.grpBuscar);
            this.lblCP.Location = new System.Drawing.Point(9, 34);
            this.lblCP.Name = "lblCP";
            this.lblCP.Size = new System.Drawing.Size(724, 412);
            this.lblCP.TabIndex = 34;
            this.lblCP.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // txtComplemento
            // 
            this.txtComplemento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComplemento.Location = new System.Drawing.Point(95, 242);
            this.txtComplemento.MaxLength = 100;
            this.txtComplemento.Name = "txtComplemento";
            this.txtComplemento.Size = new System.Drawing.Size(451, 22);
            this.txtComplemento.TabIndex = 6;
            // 
            // cmbLocalidad
            // 
            this.cmbLocalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocalidad.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbLocalidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cmbLocalidad.FormattingEnabled = true;
            this.cmbLocalidad.Location = new System.Drawing.Point(95, 183);
            this.cmbLocalidad.Name = "cmbLocalidad";
            this.cmbLocalidad.Size = new System.Drawing.Size(447, 24);
            this.cmbLocalidad.TabIndex = 5;
            // 
            // txtNotas
            // 
            this.txtNotas.AcceptsReturn = true;
            this.txtNotas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtNotas.BackColor = System.Drawing.Color.White;
            this.txtNotas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtNotas.Location = new System.Drawing.Point(95, 274);
            this.txtNotas.Multiline = true;
            this.txtNotas.Name = "txtNotas";
            this.txtNotas.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtNotas.Size = new System.Drawing.Size(447, 82);
            this.txtNotas.TabIndex = 7;
            this.txtNotas.Text = "AAAAA";
            // 
            // cmbProvincia
            // 
            this.cmbProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProvincia.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbProvincia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cmbProvincia.FormattingEnabled = true;
            this.cmbProvincia.Location = new System.Drawing.Point(95, 152);
            this.cmbProvincia.Name = "cmbProvincia";
            this.cmbProvincia.Size = new System.Drawing.Size(447, 24);
            this.cmbProvincia.TabIndex = 4;
            // 
            // txtDpto
            // 
            this.txtDpto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDpto.Location = new System.Drawing.Point(368, 111);
            this.txtDpto.Name = "txtDpto";
            this.txtDpto.Size = new System.Drawing.Size(80, 22);
            this.txtDpto.TabIndex = 3;
            // 
            // txtPiso
            // 
            this.txtPiso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPiso.Location = new System.Drawing.Point(225, 112);
            this.txtPiso.Name = "txtPiso";
            this.txtPiso.Size = new System.Drawing.Size(80, 22);
            this.txtPiso.TabIndex = 2;
            this.txtPiso.Tag = "N";
            // 
            // txtNro
            // 
            this.txtNro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNro.Location = new System.Drawing.Point(95, 112);
            this.txtNro.Name = "txtNro";
            this.txtNro.Size = new System.Drawing.Size(81, 22);
            this.txtNro.TabIndex = 1;
            this.txtNro.Tag = "N";
            // 
            // txtCalle
            // 
            this.txtCalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCalle.Location = new System.Drawing.Point(95, 77);
            this.txtCalle.MaxLength = 150;
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.Size = new System.Drawing.Size(447, 22);
            this.txtCalle.TabIndex = 0;
            this.txtCalle.Text = "Esto es una dirección";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBorrar);
            this.groupBox1.Controls.Add(this.btnGrabar);
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Location = new System.Drawing.Point(553, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(142, 334);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            // 
            // btnBorrar
            // 
            this.btnBorrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrar.Location = new System.Drawing.Point(12, 58);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(117, 36);
            this.btnBorrar.TabIndex = 41;
            this.btnBorrar.Text = "Eliminar";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Visible = false;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrabar.Location = new System.Drawing.Point(12, 19);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(117, 36);
            this.btnGrabar.TabIndex = 8;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(12, 283);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(117, 36);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // cmbEstado
            // 
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(95, 372);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(150, 24);
            this.cmbEstado.TabIndex = 39;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblEstado.ForeColor = System.Drawing.Color.Blue;
            this.lblEstado.Location = new System.Drawing.Point(44, 378);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(48, 15);
            this.lblEstado.TabIndex = 40;
            this.lblEstado.Tag = "XXXXXF";
            this.lblEstado.Text = "Estado:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label10.ForeColor = System.Drawing.Color.Blue;
            this.label10.Location = new System.Drawing.Point(32, 158);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 15);
            this.label10.TabIndex = 38;
            this.label10.Tag = "XXXXXF";
            this.label10.Text = "Provincia:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label9.ForeColor = System.Drawing.Color.Blue;
            this.label9.Location = new System.Drawing.Point(28, 189);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 15);
            this.label9.TabIndex = 37;
            this.label9.Tag = "XXXXXF";
            this.label9.Text = "Localidad:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label8.ForeColor = System.Drawing.Color.Blue;
            this.label8.Location = new System.Drawing.Point(46, 338);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 15);
            this.label8.TabIndex = 36;
            this.label8.Tag = "XXXXXF";
            this.label8.Text = "Notas:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label7.ForeColor = System.Drawing.Color.Blue;
            this.label7.Location = new System.Drawing.Point(3, 248);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 15);
            this.label7.TabIndex = 35;
            this.label7.Tag = "XXXXXF";
            this.label7.Text = "Complemento:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(327, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 15);
            this.label6.TabIndex = 34;
            this.label6.Tag = "XXXXXF";
            this.label6.Text = "Dpto.:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(189, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 15);
            this.label5.TabIndex = 33;
            this.label5.Tag = "XXXXXF";
            this.label5.Text = "Piso:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(62, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 15);
            this.label4.TabIndex = 32;
            this.label4.Tag = "XXXXXF";
            this.label4.Text = "Nro:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(57, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 31;
            this.label1.Tag = "XXXXXF";
            this.label1.Text = "Calle:";
            // 
            // grpBuscar
            // 
            this.grpBuscar.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.grpBuscar.Controls.Add(this.lblDomNomb);
            this.grpBuscar.Controls.Add(this.lblDomCodDocu);
            this.grpBuscar.Controls.Add(this.label3);
            this.grpBuscar.Controls.Add(this.lblDomDocu);
            this.grpBuscar.Location = new System.Drawing.Point(9, 3);
            this.grpBuscar.Name = "grpBuscar";
            this.grpBuscar.Size = new System.Drawing.Size(711, 51);
            this.grpBuscar.TabIndex = 23;
            // 
            // lblDomNomb
            // 
            this.lblDomNomb.BackColor = System.Drawing.Color.White;
            this.lblDomNomb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDomNomb.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblDomNomb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblDomNomb.ForeColor = System.Drawing.Color.Black;
            this.lblDomNomb.Location = new System.Drawing.Point(86, 18);
            this.lblDomNomb.Name = "lblDomNomb";
            this.lblDomNomb.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lblDomNomb.Size = new System.Drawing.Size(447, 22);
            this.lblDomNomb.TabIndex = 28;
            this.lblDomNomb.Text = "Eduardo Héctor Palermo Pinto";
            this.lblDomNomb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDomCodDocu
            // 
            this.lblDomCodDocu.BackColor = System.Drawing.Color.White;
            this.lblDomCodDocu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDomCodDocu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblDomCodDocu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblDomCodDocu.ForeColor = System.Drawing.Color.Black;
            this.lblDomCodDocu.Location = new System.Drawing.Point(639, 18);
            this.lblDomCodDocu.Name = "lblDomCodDocu";
            this.lblDomCodDocu.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lblDomCodDocu.Size = new System.Drawing.Size(47, 22);
            this.lblDomCodDocu.TabIndex = 29;
            this.lblDomCodDocu.Text = "DNI";
            this.lblDomCodDocu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(27, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 15);
            this.label3.TabIndex = 25;
            this.label3.Tag = "XXXXXF";
            this.label3.Text = "Nombre:";
            // 
            // lblDomDocu
            // 
            this.lblDomDocu.BackColor = System.Drawing.Color.White;
            this.lblDomDocu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDomDocu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblDomDocu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblDomDocu.ForeColor = System.Drawing.Color.Black;
            this.lblDomDocu.Location = new System.Drawing.Point(540, 18);
            this.lblDomDocu.Name = "lblDomDocu";
            this.lblDomDocu.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lblDomDocu.Size = new System.Drawing.Size(100, 22);
            this.lblDomDocu.TabIndex = 27;
            this.lblDomDocu.Text = "00.000.000";
            this.lblDomDocu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCartel
            // 
            this.lblCartel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblCartel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblCartel.ForeColor = System.Drawing.Color.Blue;
            this.lblCartel.Location = new System.Drawing.Point(9, 6);
            this.lblCartel.Name = "lblCartel";
            this.lblCartel.Size = new System.Drawing.Size(724, 25);
            this.lblCartel.TabIndex = 35;
            this.lblCartel.Tag = "XXXXB";
            this.lblCartel.Text = "Modificar domicilio";
            this.lblCartel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label66.ForeColor = System.Drawing.Color.Blue;
            this.label66.Location = new System.Drawing.Point(64, 220);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(24, 13);
            this.label66.TabIndex = 70;
            this.label66.Tag = "XXXXXF";
            this.label66.Text = "CP:";
            // 
            // txtCP
            // 
            this.txtCP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCP.Location = new System.Drawing.Point(94, 216);
            this.txtCP.MaxLength = 100;
            this.txtCP.Name = "txtCP";
            this.txtCP.Size = new System.Drawing.Size(448, 20);
            this.txtCP.TabIndex = 69;
            this.txtCP.Tag = "XXXL";
            // 
            // FrmDomicilio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(745, 458);
            this.Controls.Add(this.lblCartel);
            this.Controls.Add(this.lblCP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmDomicilio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmDomicilio";
            this.Load += new System.EventHandler(this.FrmDomicilio_Load);
            this.lblCP.ResumeLayout(false);
            this.lblCP.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpBuscar)).EndInit();
            this.grpBuscar.ResumeLayout(false);
            this.grpBuscar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel lblCP;
        private System.Windows.Forms.Button btnCancelar;
        private DevExpress.XtraEditors.GroupControl grpBuscar;
        private System.Windows.Forms.Label lblDomCodDocu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblDomNomb;
        private System.Windows.Forms.Label lblDomDocu;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.TextBox txtCalle;
        private System.Windows.Forms.TextBox txtDpto;
        private System.Windows.Forms.TextBox txtComplemento;
        private System.Windows.Forms.TextBox txtPiso;
        private System.Windows.Forms.TextBox txtNro;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbLocalidad;
        private System.Windows.Forms.ComboBox cmbProvincia;
        private System.Windows.Forms.TextBox txtNotas;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Label lblCartel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.TextBox txtCP;
    }
}