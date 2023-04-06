namespace iComercio.Forms
{
    partial class FrmPlanesConsulta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPlanesConsulta));
            this.lblTipoDni = new System.Windows.Forms.Label();
            this.cmbTipoDni = new System.Windows.Forms.ComboBox();
            this.lblDni = new System.Windows.Forms.Label();
            this.txtDNI = new System.Windows.Forms.TextBox();
            this.grpBusca = new System.Windows.Forms.GroupBox();
            this.txtSueldo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPuntaje = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbComplemento = new System.Windows.Forms.ComboBox();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.lblProfesion = new System.Windows.Forms.Label();
            this.cmbProfesion = new System.Windows.Forms.ComboBox();
            this.BtnBusca = new System.Windows.Forms.Button();
            this.listCuotas = new System.Windows.Forms.ListView();
            this.ListPlanes = new System.Windows.Forms.ListView();
            this.pbFotoDNI = new System.Windows.Forms.PictureBox();
            this.grpBusca.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFotoDNI)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTipoDni
            // 
            this.lblTipoDni.AutoSize = true;
            this.lblTipoDni.Location = new System.Drawing.Point(147, 60);
            this.lblTipoDni.Name = "lblTipoDni";
            this.lblTipoDni.Size = new System.Drawing.Size(31, 13);
            this.lblTipoDni.TabIndex = 54;
            this.lblTipoDni.Tag = "XXXXXF";
            this.lblTipoDni.Text = "Tipo:";
            // 
            // cmbTipoDni
            // 
            this.cmbTipoDni.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoDni.FormattingEnabled = true;
            this.cmbTipoDni.Location = new System.Drawing.Point(186, 56);
            this.cmbTipoDni.Name = "cmbTipoDni";
            this.cmbTipoDni.Size = new System.Drawing.Size(55, 21);
            this.cmbTipoDni.TabIndex = 2;
            // 
            // lblDni
            // 
            this.lblDni.Location = new System.Drawing.Point(16, 59);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(36, 14);
            this.lblDni.TabIndex = 52;
            this.lblDni.Tag = "XXXXXF";
            this.lblDni.Text = "DNI:";
            // 
            // txtDNI
            // 
            this.txtDNI.Location = new System.Drawing.Point(58, 56);
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(88, 20);
            this.txtDNI.TabIndex = 1;
            this.txtDNI.Tag = "NS";
            this.txtDNI.Text = "0";
            this.txtDNI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDNI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDNI_KeyPress);
            this.txtDNI.Leave += new System.EventHandler(this.txtDNI_Leave);
            // 
            // grpBusca
            // 
            this.grpBusca.Controls.Add(this.txtSueldo);
            this.grpBusca.Controls.Add(this.label3);
            this.grpBusca.Controls.Add(this.lblPuntaje);
            this.grpBusca.Controls.Add(this.label2);
            this.grpBusca.Controls.Add(this.label1);
            this.grpBusca.Controls.Add(this.cmbComplemento);
            this.grpBusca.Controls.Add(this.txtImporte);
            this.grpBusca.Controls.Add(this.lblProfesion);
            this.grpBusca.Controls.Add(this.txtDNI);
            this.grpBusca.Controls.Add(this.cmbProfesion);
            this.grpBusca.Controls.Add(this.lblTipoDni);
            this.grpBusca.Controls.Add(this.lblDni);
            this.grpBusca.Controls.Add(this.cmbTipoDni);
            this.grpBusca.Location = new System.Drawing.Point(12, 8);
            this.grpBusca.Name = "grpBusca";
            this.grpBusca.Size = new System.Drawing.Size(858, 91);
            this.grpBusca.TabIndex = 0;
            this.grpBusca.TabStop = false;
            this.grpBusca.Enter += new System.EventHandler(this.grpBusca_Enter);
            // 
            // txtSueldo
            // 
            this.txtSueldo.Location = new System.Drawing.Point(643, 56);
            this.txtSueldo.Name = "txtSueldo";
            this.txtSueldo.Size = new System.Drawing.Size(65, 20);
            this.txtSueldo.TabIndex = 5;
            this.txtSueldo.Tag = "NS";
            this.txtSueldo.Text = "0";
            this.txtSueldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(600, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 14);
            this.label3.TabIndex = 63;
            this.label3.Tag = "XXXXXF";
            this.label3.Text = "Sueldo:";
            // 
            // lblPuntaje
            // 
            this.lblPuntaje.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblPuntaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPuntaje.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPuntaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPuntaje.Location = new System.Drawing.Point(777, 56);
            this.lblPuntaje.Margin = new System.Windows.Forms.Padding(3);
            this.lblPuntaje.Name = "lblPuntaje";
            this.lblPuntaje.Padding = new System.Windows.Forms.Padding(3);
            this.lblPuntaje.Size = new System.Drawing.Size(46, 21);
            this.lblPuntaje.TabIndex = 61;
            this.lblPuntaje.Tag = "";
            this.lblPuntaje.Text = "0";
            this.lblPuntaje.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(725, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 14);
            this.label2.TabIndex = 60;
            this.label2.Tag = "XXXXXF";
            this.label2.Text = "Puntaje:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 14);
            this.label1.TabIndex = 56;
            this.label1.Tag = "XXXXXF";
            this.label1.Text = "Importe:";
            // 
            // cmbComplemento
            // 
            this.cmbComplemento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbComplemento.FormattingEnabled = true;
            this.cmbComplemento.Location = new System.Drawing.Point(452, 56);
            this.cmbComplemento.Name = "cmbComplemento";
            this.cmbComplemento.Size = new System.Drawing.Size(142, 21);
            this.cmbComplemento.TabIndex = 4;
            // 
            // txtImporte
            // 
            this.txtImporte.Location = new System.Drawing.Point(58, 15);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(88, 20);
            this.txtImporte.TabIndex = 0;
            this.txtImporte.Tag = "D";
            this.txtImporte.Text = "0";
            this.txtImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblProfesion
            // 
            this.lblProfesion.AutoSize = true;
            this.lblProfesion.Location = new System.Drawing.Point(247, 60);
            this.lblProfesion.Name = "lblProfesion";
            this.lblProfesion.Size = new System.Drawing.Size(54, 13);
            this.lblProfesion.TabIndex = 58;
            this.lblProfesion.Tag = "XXXXXF";
            this.lblProfesion.Text = "Profesión:";
            // 
            // cmbProfesion
            // 
            this.cmbProfesion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProfesion.FormattingEnabled = true;
            this.cmbProfesion.Location = new System.Drawing.Point(306, 56);
            this.cmbProfesion.Name = "cmbProfesion";
            this.cmbProfesion.Size = new System.Drawing.Size(140, 21);
            this.cmbProfesion.TabIndex = 3;
            // 
            // BtnBusca
            // 
            this.BtnBusca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBusca.Location = new System.Drawing.Point(876, 63);
            this.BtnBusca.Name = "BtnBusca";
            this.BtnBusca.Size = new System.Drawing.Size(117, 36);
            this.BtnBusca.TabIndex = 1;
            this.BtnBusca.Text = "Mostrar";
            this.BtnBusca.UseVisualStyleBackColor = true;
            this.BtnBusca.Click += new System.EventHandler(this.BtnBusca_Click);
            // 
            // listCuotas
            // 
            this.listCuotas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listCuotas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listCuotas.FullRowSelect = true;
            this.listCuotas.HideSelection = false;
            this.listCuotas.Location = new System.Drawing.Point(824, 111);
            this.listCuotas.MultiSelect = false;
            this.listCuotas.Name = "listCuotas";
            this.listCuotas.Size = new System.Drawing.Size(292, 527);
            this.listCuotas.TabIndex = 3;
            this.listCuotas.Tag = "CS";
            this.listCuotas.UseCompatibleStateImageBehavior = false;
            // 
            // ListPlanes
            // 
            this.ListPlanes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ListPlanes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListPlanes.FullRowSelect = true;
            this.ListPlanes.HideSelection = false;
            this.ListPlanes.Location = new System.Drawing.Point(12, 111);
            this.ListPlanes.MultiSelect = false;
            this.ListPlanes.Name = "ListPlanes";
            this.ListPlanes.Size = new System.Drawing.Size(806, 527);
            this.ListPlanes.TabIndex = 2;
            this.ListPlanes.Tag = "CS";
            this.ListPlanes.UseCompatibleStateImageBehavior = false;
            this.ListPlanes.SelectedIndexChanged += new System.EventHandler(this.ListPlanes_SelectedIndexChanged_1);
            // 
            // pbFotoDNI
            // 
            this.pbFotoDNI.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbFotoDNI.Location = new System.Drawing.Point(1118, 8);
            this.pbFotoDNI.Name = "pbFotoDNI";
            this.pbFotoDNI.Size = new System.Drawing.Size(121, 97);
            this.pbFotoDNI.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFotoDNI.TabIndex = 60;
            this.pbFotoDNI.TabStop = false;
            // 
            // FrmPlanesConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1302, 673);
            this.Controls.Add(this.pbFotoDNI);
            this.Controls.Add(this.ListPlanes);
            this.Controls.Add(this.listCuotas);
            this.Controls.Add(this.BtnBusca);
            this.Controls.Add(this.grpBusca);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmPlanesConsulta";
            this.Text = "Consulta de Planes";
            this.Load += new System.EventHandler(this.FrmPlanesConsulta_Load);
            this.grpBusca.ResumeLayout(false);
            this.grpBusca.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFotoDNI)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTipoDni;
        private System.Windows.Forms.ComboBox cmbTipoDni;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.TextBox txtDNI;
        private System.Windows.Forms.GroupBox grpBusca;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtImporte;
        private System.Windows.Forms.ComboBox cmbComplemento;
        private System.Windows.Forms.Label lblProfesion;
        private System.Windows.Forms.ComboBox cmbProfesion;
        private System.Windows.Forms.Button BtnBusca;
        private System.Windows.Forms.Label lblPuntaje;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView listCuotas;
        private System.Windows.Forms.ListView ListPlanes;
        private System.Windows.Forms.PictureBox pbFotoDNI;
        private System.Windows.Forms.TextBox txtSueldo;
        private System.Windows.Forms.Label label3;
    }
}