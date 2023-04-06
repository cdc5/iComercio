namespace iComercio.Forms
{
    partial class frmCamaraWeb
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCamaraWeb));
            this.btnIniciarCaptura = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.btnParar = new System.Windows.Forms.Button();
            this.grbNombre = new DevExpress.XtraEditors.GroupControl();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCliNombre = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCliDocu = new System.Windows.Forms.Label();
            this.grbFoto = new DevExpress.XtraEditors.GroupControl();
            this.pcb = new System.Windows.Forms.PictureBox();
            this.btnTomarFoto = new System.Windows.Forms.Button();
            this.pcbFoto = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.grbNombre)).BeginInit();
            this.grbNombre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grbFoto)).BeginInit();
            this.grbFoto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbFoto)).BeginInit();
            this.SuspendLayout();
            // 
            // btnIniciarCaptura
            // 
            this.btnIniciarCaptura.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnIniciarCaptura.Location = new System.Drawing.Point(7, 260);
            this.btnIniciarCaptura.Name = "btnIniciarCaptura";
            this.btnIniciarCaptura.Size = new System.Drawing.Size(95, 23);
            this.btnIniciarCaptura.TabIndex = 1;
            this.btnIniciarCaptura.Text = "Iniciar Captura";
            this.btnIniciarCaptura.UseVisualStyleBackColor = true;
            this.btnIniciarCaptura.Visible = false;
            this.btnIniciarCaptura.Click += new System.EventHandler(this.btnTomarFoto_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGrabar.Location = new System.Drawing.Point(416, 260);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(95, 23);
            this.btnGrabar.TabIndex = 2;
            this.btnGrabar.Text = "Gabar";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnParar
            // 
            this.btnParar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnParar.Location = new System.Drawing.Point(162, 260);
            this.btnParar.Name = "btnParar";
            this.btnParar.Size = new System.Drawing.Size(95, 23);
            this.btnParar.TabIndex = 3;
            this.btnParar.Text = "Parar";
            this.btnParar.UseVisualStyleBackColor = true;
            this.btnParar.Visible = false;
            this.btnParar.Click += new System.EventHandler(this.btnParar_Click);
            // 
            // grbNombre
            // 
            this.grbNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbNombre.Controls.Add(this.label3);
            this.grbNombre.Controls.Add(this.lblCliNombre);
            this.grbNombre.Controls.Add(this.label2);
            this.grbNombre.Controls.Add(this.lblCliDocu);
            this.grbNombre.Location = new System.Drawing.Point(12, 3);
            this.grbNombre.Name = "grbNombre";
            this.grbNombre.Size = new System.Drawing.Size(516, 67);
            this.grbNombre.TabIndex = 58;
            this.grbNombre.Text = "Cliente";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(385, 16);
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
            this.label2.Location = new System.Drawing.Point(398, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 16);
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
            this.lblCliDocu.Location = new System.Drawing.Point(398, 40);
            this.lblCliDocu.Name = "lblCliDocu";
            this.lblCliDocu.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lblCliDocu.Size = new System.Drawing.Size(92, 22);
            this.lblCliDocu.TabIndex = 16;
            this.lblCliDocu.Tag = "";
            this.lblCliDocu.Text = "00.000.000";
            this.lblCliDocu.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // grbFoto
            // 
            this.grbFoto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbFoto.Controls.Add(this.pcbFoto);
            this.grbFoto.Controls.Add(this.btnTomarFoto);
            this.grbFoto.Controls.Add(this.pcb);
            this.grbFoto.Controls.Add(this.btnGrabar);
            this.grbFoto.Controls.Add(this.btnIniciarCaptura);
            this.grbFoto.Controls.Add(this.btnParar);
            this.grbFoto.Location = new System.Drawing.Point(12, 76);
            this.grbFoto.Name = "grbFoto";
            this.grbFoto.Size = new System.Drawing.Size(516, 289);
            this.grbFoto.TabIndex = 59;
            this.grbFoto.Text = "Foto";
            this.grbFoto.Paint += new System.Windows.Forms.PaintEventHandler(this.grbFoto_Paint);
            // 
            // pcb
            // 
            this.pcb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pcb.Location = new System.Drawing.Point(7, 24);
            this.pcb.Name = "pcb";
            this.pcb.Size = new System.Drawing.Size(250, 230);
            this.pcb.TabIndex = 1;
            this.pcb.TabStop = false;
            // 
            // btnTomarFoto
            // 
            this.btnTomarFoto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTomarFoto.Location = new System.Drawing.Point(261, 260);
            this.btnTomarFoto.Name = "btnTomarFoto";
            this.btnTomarFoto.Size = new System.Drawing.Size(95, 23);
            this.btnTomarFoto.TabIndex = 4;
            this.btnTomarFoto.Text = "Tomar Foto";
            this.btnTomarFoto.UseVisualStyleBackColor = true;
            this.btnTomarFoto.Click += new System.EventHandler(this.btnTomarFoto_Click_1);
            // 
            // pcbFoto
            // 
            this.pcbFoto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pcbFoto.Location = new System.Drawing.Point(261, 24);
            this.pcbFoto.Name = "pcbFoto";
            this.pcbFoto.Size = new System.Drawing.Size(250, 230);
            this.pcbFoto.TabIndex = 5;
            this.pcbFoto.TabStop = false;
            // 
            // frmCamaraWeb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 371);
            this.Controls.Add(this.grbFoto);
            this.Controls.Add(this.grbNombre);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCamaraWeb";
            this.Text = "Foto";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCamaraWeb_FormClosing);
            this.Load += new System.EventHandler(this.frmCamaraWeb_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grbNombre)).EndInit();
            this.grbNombre.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grbFoto)).EndInit();
            this.grbFoto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbFoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnIniciarCaptura;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Button btnParar;
        private DevExpress.XtraEditors.GroupControl grbNombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCliNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCliDocu;
        private DevExpress.XtraEditors.GroupControl grbFoto;
        private System.Windows.Forms.PictureBox pcb;
        private System.Windows.Forms.Button btnTomarFoto;
        private System.Windows.Forms.PictureBox pcbFoto;
    }
}