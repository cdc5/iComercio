namespace iComercio.Forms
{
    partial class frmTransmisiones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTransmisiones));
            this.CDEntreFechas = new DevExpress.XtraEditors.GroupControl();
            this.btnEnviarCDEF = new System.Windows.Forms.Button();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.lblDesde = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.bg = new System.ComponentModel.BackgroundWorker();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnEnviarREEF = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpHastaErr = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDesdeErr = new System.Windows.Forms.DateTimePicker();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btnEnviarRTEF = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpHastaTod = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpDesdeTod = new System.Windows.Forms.DateTimePicker();
            this.grpRevision = new DevExpress.XtraEditors.GroupControl();
            this.btnRestrablecer = new System.Windows.Forms.Button();
            this.btnRevisarYEnviar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpRTH = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpRTD = new System.Windows.Forms.DateTimePicker();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.lbLog = new System.Windows.Forms.ListBox();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.button1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpHastaCob = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpDesdeCob = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.CDEntreFechas)).BeginInit();
            this.CDEntreFechas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpRevision)).BeginInit();
            this.grpRevision.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            this.SuspendLayout();
            // 
            // CDEntreFechas
            // 
            this.CDEntreFechas.Controls.Add(this.btnEnviarCDEF);
            this.CDEntreFechas.Controls.Add(this.lblHasta);
            this.CDEntreFechas.Controls.Add(this.dtpHasta);
            this.CDEntreFechas.Controls.Add(this.lblDesde);
            this.CDEntreFechas.Controls.Add(this.dtpDesde);
            this.CDEntreFechas.Location = new System.Drawing.Point(12, 95);
            this.CDEntreFechas.Name = "CDEntreFechas";
            this.CDEntreFechas.Size = new System.Drawing.Size(415, 71);
            this.CDEntreFechas.TabIndex = 0;
            this.CDEntreFechas.Text = "Control Diario Entre Fechas";
            // 
            // btnEnviarCDEF
            // 
            this.btnEnviarCDEF.Location = new System.Drawing.Point(311, 36);
            this.btnEnviarCDEF.Name = "btnEnviarCDEF";
            this.btnEnviarCDEF.Size = new System.Drawing.Size(93, 23);
            this.btnEnviarCDEF.TabIndex = 4;
            this.btnEnviarCDEF.Text = "Enviar";
            this.btnEnviarCDEF.UseVisualStyleBackColor = true;
            this.btnEnviarCDEF.Click += new System.EventHandler(this.btnEnviarCDEF_Click);
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(163, 41);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(38, 13);
            this.lblHasta.TabIndex = 3;
            this.lblHasta.Text = "Hasta:";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(210, 38);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(95, 20);
            this.dtpHasta.TabIndex = 2;
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Location = new System.Drawing.Point(14, 40);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(41, 13);
            this.lblDesde.TabIndex = 1;
            this.lblDesde.Text = "Desde:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(61, 37);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(95, 20);
            this.dtpDesde.TabIndex = 0;
            // 
            // bg
            // 
            this.bg.WorkerReportsProgress = true;
            this.bg.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bg_DoWork);
            this.bg.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bg_RunWorkerCompleted);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnEnviarREEF);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.dtpHastaErr);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.dtpDesdeErr);
            this.groupControl1.Location = new System.Drawing.Point(13, 172);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(415, 68);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Retransmitir Erróneas";
            // 
            // btnEnviarREEF
            // 
            this.btnEnviarREEF.Location = new System.Drawing.Point(311, 37);
            this.btnEnviarREEF.Name = "btnEnviarREEF";
            this.btnEnviarREEF.Size = new System.Drawing.Size(93, 23);
            this.btnEnviarREEF.TabIndex = 4;
            this.btnEnviarREEF.Text = "Retransmitir";
            this.btnEnviarREEF.UseVisualStyleBackColor = true;
            this.btnEnviarREEF.Click += new System.EventHandler(this.btnEnviarREEF_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(163, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Hasta:";
            // 
            // dtpHastaErr
            // 
            this.dtpHastaErr.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHastaErr.Location = new System.Drawing.Point(210, 38);
            this.dtpHastaErr.Name = "dtpHastaErr";
            this.dtpHastaErr.Size = new System.Drawing.Size(95, 20);
            this.dtpHastaErr.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Desde:";
            // 
            // dtpDesdeErr
            // 
            this.dtpDesdeErr.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesdeErr.Location = new System.Drawing.Point(61, 37);
            this.dtpDesdeErr.Name = "dtpDesdeErr";
            this.dtpDesdeErr.Size = new System.Drawing.Size(95, 20);
            this.dtpDesdeErr.TabIndex = 0;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.btnEnviarRTEF);
            this.groupControl2.Controls.Add(this.label3);
            this.groupControl2.Controls.Add(this.dtpHastaTod);
            this.groupControl2.Controls.Add(this.label4);
            this.groupControl2.Controls.Add(this.dtpDesdeTod);
            this.groupControl2.Location = new System.Drawing.Point(13, 246);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(415, 81);
            this.groupControl2.TabIndex = 2;
            this.groupControl2.Text = "Retransmitir Todas";
            // 
            // btnEnviarRTEF
            // 
            this.btnEnviarRTEF.Location = new System.Drawing.Point(311, 37);
            this.btnEnviarRTEF.Name = "btnEnviarRTEF";
            this.btnEnviarRTEF.Size = new System.Drawing.Size(93, 23);
            this.btnEnviarRTEF.TabIndex = 4;
            this.btnEnviarRTEF.Text = "Retransmitir";
            this.btnEnviarRTEF.UseVisualStyleBackColor = true;
            this.btnEnviarRTEF.Click += new System.EventHandler(this.btnEnviarRTEF_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(163, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Hasta:";
            // 
            // dtpHastaTod
            // 
            this.dtpHastaTod.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHastaTod.Location = new System.Drawing.Point(210, 38);
            this.dtpHastaTod.Name = "dtpHastaTod";
            this.dtpHastaTod.Size = new System.Drawing.Size(95, 20);
            this.dtpHastaTod.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Desde:";
            // 
            // dtpDesdeTod
            // 
            this.dtpDesdeTod.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesdeTod.Location = new System.Drawing.Point(61, 37);
            this.dtpDesdeTod.Name = "dtpDesdeTod";
            this.dtpDesdeTod.Size = new System.Drawing.Size(95, 20);
            this.dtpDesdeTod.TabIndex = 0;
            // 
            // grpRevision
            // 
            this.grpRevision.Controls.Add(this.btnRestrablecer);
            this.grpRevision.Controls.Add(this.btnRevisarYEnviar);
            this.grpRevision.Controls.Add(this.label5);
            this.grpRevision.Controls.Add(this.dtpRTH);
            this.grpRevision.Controls.Add(this.label6);
            this.grpRevision.Controls.Add(this.dtpRTD);
            this.grpRevision.Location = new System.Drawing.Point(13, 12);
            this.grpRevision.Name = "grpRevision";
            this.grpRevision.Size = new System.Drawing.Size(414, 74);
            this.grpRevision.TabIndex = 3;
            this.grpRevision.Text = "Revisión de Transmisiones";
            // 
            // btnRestrablecer
            // 
            this.btnRestrablecer.Location = new System.Drawing.Point(316, 49);
            this.btnRestrablecer.Name = "btnRestrablecer";
            this.btnRestrablecer.Size = new System.Drawing.Size(93, 23);
            this.btnRestrablecer.TabIndex = 5;
            this.btnRestrablecer.Text = "Restablecer";
            this.btnRestrablecer.UseVisualStyleBackColor = true;
            this.btnRestrablecer.Click += new System.EventHandler(this.btnRestrablecer_Click);
            // 
            // btnRevisarYEnviar
            // 
            this.btnRevisarYEnviar.Location = new System.Drawing.Point(316, 25);
            this.btnRevisarYEnviar.Name = "btnRevisarYEnviar";
            this.btnRevisarYEnviar.Size = new System.Drawing.Size(93, 23);
            this.btnRevisarYEnviar.TabIndex = 4;
            this.btnRevisarYEnviar.Text = "Revisar y Enviar";
            this.btnRevisarYEnviar.UseVisualStyleBackColor = true;
            this.btnRevisarYEnviar.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(163, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Hasta:";
            // 
            // dtpRTH
            // 
            this.dtpRTH.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpRTH.Location = new System.Drawing.Point(210, 38);
            this.dtpRTH.Name = "dtpRTH";
            this.dtpRTH.Size = new System.Drawing.Size(95, 20);
            this.dtpRTH.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Desde:";
            // 
            // dtpRTD
            // 
            this.dtpRTD.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpRTD.Location = new System.Drawing.Point(61, 37);
            this.dtpRTD.Name = "dtpRTD";
            this.dtpRTD.Size = new System.Drawing.Size(95, 20);
            this.dtpRTD.TabIndex = 0;
            // 
            // groupControl3
            // 
            this.groupControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl3.Controls.Add(this.lbLog);
            this.groupControl3.Location = new System.Drawing.Point(435, 12);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(728, 404);
            this.groupControl3.TabIndex = 4;
            this.groupControl3.Text = "Log";
            // 
            // lbLog
            // 
            this.lbLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbLog.FormattingEnabled = true;
            this.lbLog.Location = new System.Drawing.Point(6, 25);
            this.lbLog.Name = "lbLog";
            this.lbLog.Size = new System.Drawing.Size(717, 368);
            this.lbLog.TabIndex = 0;
            // 
            // groupControl4
            // 
            this.groupControl4.Controls.Add(this.button1);
            this.groupControl4.Controls.Add(this.label7);
            this.groupControl4.Controls.Add(this.dtpHastaCob);
            this.groupControl4.Controls.Add(this.label8);
            this.groupControl4.Controls.Add(this.dtpDesdeCob);
            this.groupControl4.Location = new System.Drawing.Point(16, 333);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(411, 81);
            this.groupControl4.TabIndex = 5;
            this.groupControl4.Text = "Sumar Cobranzas a Cuotas";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(311, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Recalcular";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(163, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Hasta:";
            // 
            // dtpHastaCob
            // 
            this.dtpHastaCob.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHastaCob.Location = new System.Drawing.Point(210, 38);
            this.dtpHastaCob.Name = "dtpHastaCob";
            this.dtpHastaCob.Size = new System.Drawing.Size(95, 20);
            this.dtpHastaCob.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Desde:";
            // 
            // dtpDesdeCob
            // 
            this.dtpDesdeCob.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesdeCob.Location = new System.Drawing.Point(61, 37);
            this.dtpDesdeCob.Name = "dtpDesdeCob";
            this.dtpDesdeCob.Size = new System.Drawing.Size(95, 20);
            this.dtpDesdeCob.TabIndex = 0;
            // 
            // frmTransmisiones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1175, 428);
            this.Controls.Add(this.groupControl4);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.grpRevision);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.CDEntreFechas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTransmisiones";
            this.Text = "Transmisiones";
            this.Load += new System.EventHandler(this.frmTransmisiones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CDEntreFechas)).EndInit();
            this.CDEntreFechas.ResumeLayout(false);
            this.CDEntreFechas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpRevision)).EndInit();
            this.grpRevision.ResumeLayout(false);
            this.grpRevision.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            this.groupControl4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl CDEntreFechas;
        private System.Windows.Forms.Button btnEnviarCDEF;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.ComponentModel.BackgroundWorker bg;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Button btnEnviarREEF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpHastaErr;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpDesdeErr;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.Button btnEnviarRTEF;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpHastaTod;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpDesdeTod;
        private DevExpress.XtraEditors.GroupControl grpRevision;
        private System.Windows.Forms.Button btnRevisarYEnviar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpRTH;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpRTD;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private System.Windows.Forms.ListBox lbLog;
        private System.Windows.Forms.Button btnRestrablecer;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpHastaCob;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpDesdeCob;
    }
}