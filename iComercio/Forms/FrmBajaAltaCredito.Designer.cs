namespace iComercio.Forms
{
    partial class FrmBajaCredito
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBajaCredito));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBuscaCred = new System.Windows.Forms.TextBox();
            this.txtBuscaComer = new System.Windows.Forms.TextBox();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCliCodD = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblCreEst = new System.Windows.Forms.Label();
            this.lblCliDocu = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCliNombre = new System.Windows.Forms.Label();
            this.txtBajaMotivo = new System.Windows.Forms.TextBox();
            this.btnAnula = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCreSoli = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblCreCuotas = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblCreValorNom = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblCreValorCuotas = new System.Windows.Forms.Label();
            this.lblMor = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.lblMor);
            this.panel1.Controls.Add(this.lbl);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtBuscaCred);
            this.panel1.Controls.Add(this.txtBuscaComer);
            this.panel1.Location = new System.Drawing.Point(8, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(216, 48);
            this.panel1.TabIndex = 64;
            // 
            // lbl
            // 
            this.lbl.BackColor = System.Drawing.Color.Transparent;
            this.lbl.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.ForeColor = System.Drawing.Color.Maroon;
            this.lbl.Location = new System.Drawing.Point(16, 6);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(97, 16);
            this.lbl.TabIndex = 3;
            this.lbl.Tag = "XXXXXF";
            this.lbl.Text = "Crédito";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(120, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 16);
            this.label1.TabIndex = 5;
            this.label1.Tag = "XXXXXF";
            this.label1.Text = "Comercio";
            // 
            // txtBuscaCred
            // 
            this.txtBuscaCred.AcceptsReturn = true;
            this.txtBuscaCred.AcceptsTab = true;
            this.txtBuscaCred.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscaCred.Location = new System.Drawing.Point(15, 20);
            this.txtBuscaCred.MaxLength = 10;
            this.txtBuscaCred.Name = "txtBuscaCred";
            this.txtBuscaCred.Size = new System.Drawing.Size(98, 22);
            this.txtBuscaCred.TabIndex = 0;
            this.txtBuscaCred.Tag = "N";
            this.txtBuscaCred.Text = "0";
            this.txtBuscaCred.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtBuscaComer
            // 
            this.txtBuscaComer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscaComer.Location = new System.Drawing.Point(120, 20);
            this.txtBuscaComer.Name = "txtBuscaComer";
            this.txtBuscaComer.Size = new System.Drawing.Size(72, 22);
            this.txtBuscaComer.TabIndex = 1;
            this.txtBuscaComer.Tag = "N";
            this.txtBuscaComer.Text = "0";
            this.txtBuscaComer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBuscar.Location = new System.Drawing.Point(230, 15);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(117, 36);
            this.BtnBuscar.TabIndex = 63;
            this.BtnBuscar.Text = "Buscar";
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Maroon;
            this.label5.Location = new System.Drawing.Point(397, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(182, 16);
            this.label5.TabIndex = 82;
            this.label5.Tag = "XXXXXF";
            this.label5.Text = "Documento";
            // 
            // lblCliCodD
            // 
            this.lblCliCodD.BackColor = System.Drawing.Color.White;
            this.lblCliCodD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCliCodD.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblCliCodD.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliCodD.ForeColor = System.Drawing.Color.Black;
            this.lblCliCodD.Location = new System.Drawing.Point(503, 135);
            this.lblCliCodD.Name = "lblCliCodD";
            this.lblCliCodD.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.lblCliCodD.Size = new System.Drawing.Size(58, 22);
            this.lblCliCodD.TabIndex = 89;
            this.lblCliCodD.Tag = "";
            this.lblCliCodD.Text = "DNI";
            this.lblCliCodD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Maroon;
            this.label9.Location = new System.Drawing.Point(395, 70);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(173, 16);
            this.label9.TabIndex = 86;
            this.label9.Tag = "XXXXXF";
            this.label9.Text = "Estado";
            // 
            // lblCreEst
            // 
            this.lblCreEst.BackColor = System.Drawing.Color.White;
            this.lblCreEst.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCreEst.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblCreEst.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreEst.ForeColor = System.Drawing.Color.Black;
            this.lblCreEst.Location = new System.Drawing.Point(396, 86);
            this.lblCreEst.Name = "lblCreEst";
            this.lblCreEst.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.lblCreEst.Size = new System.Drawing.Size(165, 22);
            this.lblCreEst.TabIndex = 85;
            this.lblCreEst.Tag = "";
            this.lblCreEst.Text = "Eduardo Héctor Palermo Pinto";
            this.lblCreEst.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCliDocu
            // 
            this.lblCliDocu.BackColor = System.Drawing.Color.White;
            this.lblCliDocu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCliDocu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblCliDocu.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliDocu.ForeColor = System.Drawing.Color.Black;
            this.lblCliDocu.Location = new System.Drawing.Point(398, 135);
            this.lblCliDocu.Name = "lblCliDocu";
            this.lblCliDocu.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.lblCliDocu.Size = new System.Drawing.Size(102, 22);
            this.lblCliDocu.TabIndex = 81;
            this.lblCliDocu.Tag = "";
            this.lblCliDocu.Text = "00.000.000";
            this.lblCliDocu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Maroon;
            this.label4.Location = new System.Drawing.Point(8, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(385, 16);
            this.label4.TabIndex = 80;
            this.label4.Tag = "XXXXXF";
            this.label4.Text = "Nombre";
            // 
            // lblCliNombre
            // 
            this.lblCliNombre.BackColor = System.Drawing.Color.White;
            this.lblCliNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCliNombre.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblCliNombre.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliNombre.ForeColor = System.Drawing.Color.Black;
            this.lblCliNombre.Location = new System.Drawing.Point(8, 135);
            this.lblCliNombre.Name = "lblCliNombre";
            this.lblCliNombre.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.lblCliNombre.Size = new System.Drawing.Size(385, 22);
            this.lblCliNombre.TabIndex = 79;
            this.lblCliNombre.Tag = "";
            this.lblCliNombre.Text = "Eduardo Héctor Palermo Pinto";
            this.lblCliNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBajaMotivo
            // 
            this.txtBajaMotivo.AcceptsReturn = true;
            this.txtBajaMotivo.AcceptsTab = true;
            this.txtBajaMotivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBajaMotivo.Location = new System.Drawing.Point(8, 231);
            this.txtBajaMotivo.MaxLength = 100;
            this.txtBajaMotivo.Name = "txtBajaMotivo";
            this.txtBajaMotivo.Size = new System.Drawing.Size(423, 22);
            this.txtBajaMotivo.TabIndex = 90;
            this.txtBajaMotivo.Tag = "";
            // 
            // btnAnula
            // 
            this.btnAnula.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnula.Location = new System.Drawing.Point(441, 217);
            this.btnAnula.Name = "btnAnula";
            this.btnAnula.Size = new System.Drawing.Size(120, 36);
            this.btnAnula.TabIndex = 91;
            this.btnAnula.Text = "Anular";
            this.btnAnula.UseVisualStyleBackColor = true;
            this.btnAnula.Click += new System.EventHandler(this.btnAnula_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(8, 217);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 14);
            this.label3.TabIndex = 92;
            this.label3.Tag = "XXXXXF";
            this.label3.Text = "Motivo";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(8, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 16);
            this.label2.TabIndex = 94;
            this.label2.Tag = "XXXXXF";
            this.label2.Text = "F. Solicitud";
            // 
            // lblCreSoli
            // 
            this.lblCreSoli.BackColor = System.Drawing.Color.White;
            this.lblCreSoli.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCreSoli.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblCreSoli.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreSoli.ForeColor = System.Drawing.Color.Black;
            this.lblCreSoli.Location = new System.Drawing.Point(8, 86);
            this.lblCreSoli.Name = "lblCreSoli";
            this.lblCreSoli.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.lblCreSoli.Size = new System.Drawing.Size(95, 22);
            this.lblCreSoli.TabIndex = 93;
            this.lblCreSoli.Tag = "";
            this.lblCreSoli.Text = "99/99/9999";
            this.lblCreSoli.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Maroon;
            this.label10.Location = new System.Drawing.Point(223, 70);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 16);
            this.label10.TabIndex = 96;
            this.label10.Tag = "XXXXXF";
            this.label10.Text = "Cuotas";
            // 
            // lblCreCuotas
            // 
            this.lblCreCuotas.BackColor = System.Drawing.Color.White;
            this.lblCreCuotas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCreCuotas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblCreCuotas.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreCuotas.ForeColor = System.Drawing.Color.Black;
            this.lblCreCuotas.Location = new System.Drawing.Point(223, 86);
            this.lblCreCuotas.Name = "lblCreCuotas";
            this.lblCreCuotas.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.lblCreCuotas.Size = new System.Drawing.Size(51, 22);
            this.lblCreCuotas.TabIndex = 95;
            this.lblCreCuotas.Tag = "";
            this.lblCreCuotas.Text = "9999";
            this.lblCreCuotas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Maroon;
            this.label12.Location = new System.Drawing.Point(109, 70);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(110, 16);
            this.label12.TabIndex = 98;
            this.label12.Tag = "XXXXXF";
            this.label12.Text = "Valor Nominal";
            // 
            // lblCreValorNom
            // 
            this.lblCreValorNom.BackColor = System.Drawing.Color.White;
            this.lblCreValorNom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCreValorNom.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblCreValorNom.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreValorNom.ForeColor = System.Drawing.Color.Black;
            this.lblCreValorNom.Location = new System.Drawing.Point(109, 86);
            this.lblCreValorNom.Name = "lblCreValorNom";
            this.lblCreValorNom.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.lblCreValorNom.Size = new System.Drawing.Size(110, 22);
            this.lblCreValorNom.TabIndex = 97;
            this.lblCreValorNom.Tag = "";
            this.lblCreValorNom.Text = "99.999.999.99";
            this.lblCreValorNom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Maroon;
            this.label14.Location = new System.Drawing.Point(280, 70);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(110, 16);
            this.label14.TabIndex = 100;
            this.label14.Tag = "XXXXXF";
            this.label14.Text = "Valor cuotas";
            // 
            // lblCreValorCuotas
            // 
            this.lblCreValorCuotas.BackColor = System.Drawing.Color.White;
            this.lblCreValorCuotas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCreValorCuotas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblCreValorCuotas.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreValorCuotas.ForeColor = System.Drawing.Color.Black;
            this.lblCreValorCuotas.Location = new System.Drawing.Point(280, 86);
            this.lblCreValorCuotas.Name = "lblCreValorCuotas";
            this.lblCreValorCuotas.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.lblCreValorCuotas.Size = new System.Drawing.Size(110, 22);
            this.lblCreValorCuotas.TabIndex = 99;
            this.lblCreValorCuotas.Tag = "";
            this.lblCreValorCuotas.Text = "99.999.999.99";
            this.lblCreValorCuotas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMor
            // 
            this.lblMor.BackColor = System.Drawing.Color.Black;
            this.lblMor.Location = new System.Drawing.Point(191, 20);
            this.lblMor.Name = "lblMor";
            this.lblMor.Size = new System.Drawing.Size(6, 22);
            this.lblMor.TabIndex = 44;
            // 
            // FrmBajaCredito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 287);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lblCreValorCuotas);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lblCreValorNom);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblCreCuotas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblCreSoli);
            this.Controls.Add(this.txtBajaMotivo);
            this.Controls.Add(this.btnAnula);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblCliCodD);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblCreEst);
            this.Controls.Add(this.lblCliDocu);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblCliNombre);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BtnBuscar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FrmBajaCredito";
            this.Text = "FrmBajaAltaCredito";
            this.Load += new System.EventHandler(this.FrmBajaAltaCredito_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmBajaCredito_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBuscaCred;
        private System.Windows.Forms.TextBox txtBuscaComer;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblCliCodD;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblCreEst;
        private System.Windows.Forms.Label lblCliDocu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCliNombre;
        private System.Windows.Forms.TextBox txtBajaMotivo;
        private System.Windows.Forms.Button btnAnula;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCreSoli;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblCreCuotas;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblCreValorNom;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblCreValorCuotas;
        private System.Windows.Forms.Label lblMor;
    }
}