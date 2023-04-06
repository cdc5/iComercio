namespace iComercio.Forms
{
    partial class FrmNotasCliCred
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNotasCliCred));
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCartel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtCliNota = new System.Windows.Forms.TextBox();
            this.grpBuscar = new DevExpress.XtraEditors.GroupControl();
            this.lblNotaCodDocu = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblNotaNomb = new System.Windows.Forms.Label();
            this.lblNotaDocu = new System.Windows.Forms.Label();
            this.lblNotaCred = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl = new System.Windows.Forms.Label();
            this.lblNotaCom = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpBuscar)).BeginInit();
            this.grpBuscar.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.Desktop;
            this.label4.Location = new System.Drawing.Point(646, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(7, 284);
            this.label4.TabIndex = 52;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Desktop;
            this.label2.Location = new System.Drawing.Point(6, 280);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(645, 9);
            this.label2.TabIndex = 51;
            // 
            // lblCartel
            // 
            this.lblCartel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblCartel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblCartel.ForeColor = System.Drawing.Color.Blue;
            this.lblCartel.Location = new System.Drawing.Point(3, 3);
            this.lblCartel.Name = "lblCartel";
            this.lblCartel.Size = new System.Drawing.Size(638, 26);
            this.lblCartel.TabIndex = 500;
            this.lblCartel.Tag = "XXXXB";
            this.lblCartel.Text = "Nueva nota";
            this.lblCartel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.txtCliNota);
            this.panel1.Controls.Add(this.lblCartel);
            this.panel1.Controls.Add(this.grpBuscar);
            this.panel1.Location = new System.Drawing.Point(-1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(648, 282);
            this.panel1.TabIndex = 33;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnGrabar);
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Location = new System.Drawing.Point(445, 126);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(163, 141);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            // 
            // btnGrabar
            // 
            this.btnGrabar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrabar.Location = new System.Drawing.Point(20, 19);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(117, 36);
            this.btnGrabar.TabIndex = 1;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(20, 94);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(117, 36);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtCliNota
            // 
            this.txtCliNota.AcceptsReturn = true;
            this.txtCliNota.AcceptsTab = true;
            this.txtCliNota.BackColor = System.Drawing.Color.White;
            this.txtCliNota.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCliNota.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCliNota.Location = new System.Drawing.Point(16, 136);
            this.txtCliNota.Multiline = true;
            this.txtCliNota.Name = "txtCliNota";
            this.txtCliNota.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCliNota.Size = new System.Drawing.Size(423, 131);
            this.txtCliNota.TabIndex = 0;
            this.txtCliNota.Text = "AAAAA";
            // 
            // grpBuscar
            // 
            this.grpBuscar.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.grpBuscar.Controls.Add(this.lblNotaCodDocu);
            this.grpBuscar.Controls.Add(this.label3);
            this.grpBuscar.Controls.Add(this.lblNotaNomb);
            this.grpBuscar.Controls.Add(this.lblNotaDocu);
            this.grpBuscar.Controls.Add(this.lblNotaCred);
            this.grpBuscar.Controls.Add(this.label1);
            this.grpBuscar.Controls.Add(this.lbl);
            this.grpBuscar.Controls.Add(this.lblNotaCom);
            this.grpBuscar.Location = new System.Drawing.Point(9, 47);
            this.grpBuscar.Name = "grpBuscar";
            this.grpBuscar.Size = new System.Drawing.Size(623, 76);
            this.grpBuscar.TabIndex = 23;
            // 
            // lblNotaCodDocu
            // 
            this.lblNotaCodDocu.BackColor = System.Drawing.Color.White;
            this.lblNotaCodDocu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNotaCodDocu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblNotaCodDocu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblNotaCodDocu.ForeColor = System.Drawing.Color.Black;
            this.lblNotaCodDocu.Location = new System.Drawing.Point(545, 49);
            this.lblNotaCodDocu.Name = "lblNotaCodDocu";
            this.lblNotaCodDocu.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lblNotaCodDocu.Size = new System.Drawing.Size(54, 22);
            this.lblNotaCodDocu.TabIndex = 29;
            this.lblNotaCodDocu.Text = "DNI";
            this.lblNotaCodDocu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(12, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 15);
            this.label3.TabIndex = 25;
            this.label3.Tag = "XXXXXF";
            this.label3.Text = "Nombre:";
            // 
            // lblNotaNomb
            // 
            this.lblNotaNomb.BackColor = System.Drawing.Color.White;
            this.lblNotaNomb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNotaNomb.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblNotaNomb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblNotaNomb.ForeColor = System.Drawing.Color.Black;
            this.lblNotaNomb.Location = new System.Drawing.Point(70, 49);
            this.lblNotaNomb.Name = "lblNotaNomb";
            this.lblNotaNomb.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lblNotaNomb.Size = new System.Drawing.Size(360, 22);
            this.lblNotaNomb.TabIndex = 28;
            this.lblNotaNomb.Text = "Eduardo Héctor Palermo Pinto";
            this.lblNotaNomb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNotaDocu
            // 
            this.lblNotaDocu.BackColor = System.Drawing.Color.White;
            this.lblNotaDocu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNotaDocu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblNotaDocu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblNotaDocu.ForeColor = System.Drawing.Color.Black;
            this.lblNotaDocu.Location = new System.Drawing.Point(436, 49);
            this.lblNotaDocu.Name = "lblNotaDocu";
            this.lblNotaDocu.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lblNotaDocu.Size = new System.Drawing.Size(111, 22);
            this.lblNotaDocu.TabIndex = 27;
            this.lblNotaDocu.Text = "00.000.000";
            this.lblNotaDocu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblNotaCred
            // 
            this.lblNotaCred.BackColor = System.Drawing.Color.White;
            this.lblNotaCred.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNotaCred.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblNotaCred.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblNotaCred.ForeColor = System.Drawing.Color.Black;
            this.lblNotaCred.Location = new System.Drawing.Point(193, 18);
            this.lblNotaCred.Name = "lblNotaCred";
            this.lblNotaCred.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lblNotaCred.Size = new System.Drawing.Size(98, 22);
            this.lblNotaCred.TabIndex = 25;
            this.lblNotaCred.Text = "00.000.000";
            this.lblNotaCred.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(4, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 5;
            this.label1.Tag = "XXXXXF";
            this.label1.Text = "Comercio:";
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lbl.ForeColor = System.Drawing.Color.Black;
            this.lbl.Location = new System.Drawing.Point(141, 25);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(49, 15);
            this.lbl.TabIndex = 3;
            this.lbl.Tag = "XXXXXF";
            this.lbl.Text = "Crédito:";
            // 
            // lblNotaCom
            // 
            this.lblNotaCom.BackColor = System.Drawing.Color.White;
            this.lblNotaCom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNotaCom.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblNotaCom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblNotaCom.ForeColor = System.Drawing.Color.Black;
            this.lblNotaCom.Location = new System.Drawing.Point(70, 18);
            this.lblNotaCom.Name = "lblNotaCom";
            this.lblNotaCom.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lblNotaCom.Size = new System.Drawing.Size(65, 22);
            this.lblNotaCom.TabIndex = 500;
            this.lblNotaCom.Text = "1001";
            this.lblNotaCom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FrmNotasCliCred
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(655, 292);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmNotasCliCred";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ingreso de notas";
            this.Load += new System.EventHandler(this.FrmNotasCliCred_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpBuscar)).EndInit();
            this.grpBuscar.ResumeLayout(false);
            this.grpBuscar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grpBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Label lblNotaCodDocu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblNotaNomb;
        private System.Windows.Forms.Label lblNotaDocu;
        private System.Windows.Forms.Label lblNotaCred;
        private System.Windows.Forms.Label lblNotaCom;
        private System.Windows.Forms.TextBox txtCliNota;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblCartel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
    }
}