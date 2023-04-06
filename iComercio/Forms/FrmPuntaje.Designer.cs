namespace iComercio.Forms
{
    partial class FrmPuntaje
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPuntaje));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.lblProfesion = new System.Windows.Forms.Label();
            this.cmbProfesion = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TxtPruIngr = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnPruPasa = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtPruCanc = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtPruCred = new System.Windows.Forms.TextBox();
            this.TxtPruMora = new System.Windows.Forms.TextBox();
            this.ListPruebas = new System.Windows.Forms.ListView();
            this.BtnParamGrabar = new System.Windows.Forms.Button();
            this.GrpPorcentaje = new DevExpress.XtraEditors.GroupControl();
            this.LblPorcenSuma = new System.Windows.Forms.Label();
            this.LblPorcenID = new System.Windows.Forms.Label();
            this.LblPorcenParam = new System.Windows.Forms.Label();
            this.BtnPorcenPasar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtPorcen = new System.Windows.Forms.TextBox();
            this.ListPorcentajes = new System.Windows.Forms.ListView();
            this.ListPuntajes = new System.Windows.Forms.ListView();
            this.GrpParamametros = new DevExpress.XtraEditors.GroupControl();
            this.LblParamParam = new System.Windows.Forms.Label();
            this.LblParamP = new System.Windows.Forms.Label();
            this.LblParamID = new System.Windows.Forms.Label();
            this.BtnParamPasar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtParamH = new System.Windows.Forms.TextBox();
            this.lblv = new System.Windows.Forms.Label();
            this.TxtParamD = new System.Windows.Forms.TextBox();
            this.TxtParamValor = new System.Windows.Forms.TextBox();
            this.lblFlechaI = new System.Windows.Forms.Label();
            this.lblFlechaD = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrpPorcentaje)).BeginInit();
            this.GrpPorcentaje.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrpParamametros)).BeginInit();
            this.GrpParamametros.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BorderColor = System.Drawing.Color.DimGray;
            this.groupControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 598.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Strikeout))));
            this.groupControl1.Appearance.FontSizeDelta = 10;
            this.groupControl1.Appearance.Options.UseBorderColor = true;
            this.groupControl1.Appearance.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.AppearanceCaption.ForeColor = System.Drawing.Color.Black;
            this.groupControl1.AppearanceCaption.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.groupControl1.AppearanceCaption.Options.UseBackColor = true;
            this.groupControl1.AppearanceCaption.Options.UseBorderColor = true;
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl1.AppearanceCaption.Options.UseTextOptions = true;
            this.groupControl1.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.groupControl1.Controls.Add(this.lblProfesion);
            this.groupControl1.Controls.Add(this.cmbProfesion);
            this.groupControl1.Controls.Add(this.label10);
            this.groupControl1.Controls.Add(this.TxtPruIngr);
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Controls.Add(this.label4);
            this.groupControl1.Controls.Add(this.label5);
            this.groupControl1.Controls.Add(this.BtnPruPasa);
            this.groupControl1.Controls.Add(this.label6);
            this.groupControl1.Controls.Add(this.label8);
            this.groupControl1.Controls.Add(this.TxtPruCanc);
            this.groupControl1.Controls.Add(this.label9);
            this.groupControl1.Controls.Add(this.TxtPruCred);
            this.groupControl1.Controls.Add(this.TxtPruMora);
            this.groupControl1.Location = new System.Drawing.Point(738, 277);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(441, 172);
            this.groupControl1.TabIndex = 28;
            this.groupControl1.Text = "Prueba de puntajes";
            // 
            // lblProfesion
            // 
            this.lblProfesion.AutoSize = true;
            this.lblProfesion.Location = new System.Drawing.Point(34, 144);
            this.lblProfesion.Name = "lblProfesion";
            this.lblProfesion.Size = new System.Drawing.Size(51, 13);
            this.lblProfesion.TabIndex = 33;
            this.lblProfesion.Tag = "XXXXXF";
            this.lblProfesion.Text = "Profesión";
            // 
            // cmbProfesion
            // 
            this.cmbProfesion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProfesion.FormattingEnabled = true;
            this.cmbProfesion.Location = new System.Drawing.Point(90, 140);
            this.cmbProfesion.Name = "cmbProfesion";
            this.cmbProfesion.Size = new System.Drawing.Size(166, 21);
            this.cmbProfesion.TabIndex = 32;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(34, 121);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 13);
            this.label10.TabIndex = 30;
            this.label10.Tag = "XXXXXF";
            this.label10.Text = "Ingresos:";
            // 
            // TxtPruIngr
            // 
            this.TxtPruIngr.AcceptsReturn = true;
            this.TxtPruIngr.AcceptsTab = true;
            this.TxtPruIngr.Location = new System.Drawing.Point(90, 114);
            this.TxtPruIngr.Name = "TxtPruIngr";
            this.TxtPruIngr.Size = new System.Drawing.Size(65, 20);
            this.TxtPruIngr.TabIndex = 31;
            this.TxtPruIngr.Tag = "N";
            this.TxtPruIngr.Text = "0";
            this.TxtPruIngr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(196, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(222, 19);
            this.label3.TabIndex = 29;
            this.label3.Tag = "XXXXB";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(423, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "n";
            this.label4.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(479, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "n";
            this.label5.Visible = false;
            // 
            // BtnPruPasa
            // 
            this.BtnPruPasa.Enabled = false;
            this.BtnPruPasa.Location = new System.Drawing.Point(262, 139);
            this.BtnPruPasa.Name = "BtnPruPasa";
            this.BtnPruPasa.Size = new System.Drawing.Size(156, 22);
            this.BtnPruPasa.TabIndex = 18;
            this.BtnPruPasa.Text = "Pasar a la lista";
            this.BtnPruPasa.UseVisualStyleBackColor = true;
            this.BtnPruPasa.Click += new System.EventHandler(this.BtnPruPasa_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 16;
            this.label6.Tag = "XXXXXF";
            this.label6.Text = "Cancelados:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(37, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 15;
            this.label8.Tag = "XXXXXF";
            this.label8.Text = "Créditos:";
            // 
            // TxtPruCanc
            // 
            this.TxtPruCanc.Location = new System.Drawing.Point(90, 63);
            this.TxtPruCanc.Name = "TxtPruCanc";
            this.TxtPruCanc.Size = new System.Drawing.Size(65, 20);
            this.TxtPruCanc.TabIndex = 12;
            this.TxtPruCanc.Tag = "N";
            this.TxtPruCanc.Text = "0";
            this.TxtPruCanc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(51, 95);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 5;
            this.label9.Tag = "XXXXXF";
            this.label9.Text = "Mora:";
            // 
            // TxtPruCred
            // 
            this.TxtPruCred.Location = new System.Drawing.Point(90, 37);
            this.TxtPruCred.Name = "TxtPruCred";
            this.TxtPruCred.Size = new System.Drawing.Size(65, 20);
            this.TxtPruCred.TabIndex = 11;
            this.TxtPruCred.Tag = "N";
            this.TxtPruCred.Text = "0";
            this.TxtPruCred.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TxtPruMora
            // 
            this.TxtPruMora.AcceptsReturn = true;
            this.TxtPruMora.AcceptsTab = true;
            this.TxtPruMora.Location = new System.Drawing.Point(90, 88);
            this.TxtPruMora.Name = "TxtPruMora";
            this.TxtPruMora.Size = new System.Drawing.Size(65, 20);
            this.TxtPruMora.TabIndex = 14;
            this.TxtPruMora.Tag = "N";
            this.TxtPruMora.Text = "0";
            this.TxtPruMora.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ListPruebas
            // 
            this.ListPruebas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ListPruebas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListPruebas.FullRowSelect = true;
            this.ListPruebas.Location = new System.Drawing.Point(738, 3);
            this.ListPruebas.MultiSelect = false;
            this.ListPruebas.Name = "ListPruebas";
            this.ListPruebas.Size = new System.Drawing.Size(441, 268);
            this.ListPruebas.TabIndex = 27;
            this.ListPruebas.Tag = "CS";
            this.ListPruebas.UseCompatibleStateImageBehavior = false;
            this.ListPruebas.View = System.Windows.Forms.View.Tile;
            this.ListPruebas.SelectedIndexChanged += new System.EventHandler(this.ListPruebas_SelectedIndexChanged);
            // 
            // BtnParamGrabar
            // 
            this.BtnParamGrabar.Enabled = false;
            this.BtnParamGrabar.Location = new System.Drawing.Point(410, 447);
            this.BtnParamGrabar.Name = "BtnParamGrabar";
            this.BtnParamGrabar.Size = new System.Drawing.Size(93, 22);
            this.BtnParamGrabar.TabIndex = 26;
            this.BtnParamGrabar.Text = "Grabar cambios";
            this.BtnParamGrabar.UseVisualStyleBackColor = true;
            this.BtnParamGrabar.Click += new System.EventHandler(this.BtnParamGrabar_Click);
            // 
            // GrpPorcentaje
            // 
            this.GrpPorcentaje.Appearance.BorderColor = System.Drawing.Color.DimGray;
            this.GrpPorcentaje.Appearance.Font = new System.Drawing.Font("Tahoma", 598.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Strikeout))));
            this.GrpPorcentaje.Appearance.FontSizeDelta = 10;
            this.GrpPorcentaje.Appearance.Options.UseBorderColor = true;
            this.GrpPorcentaje.Appearance.Options.UseFont = true;
            this.GrpPorcentaje.AppearanceCaption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.GrpPorcentaje.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrpPorcentaje.AppearanceCaption.ForeColor = System.Drawing.Color.Black;
            this.GrpPorcentaje.AppearanceCaption.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.GrpPorcentaje.AppearanceCaption.Options.UseBackColor = true;
            this.GrpPorcentaje.AppearanceCaption.Options.UseBorderColor = true;
            this.GrpPorcentaje.AppearanceCaption.Options.UseFont = true;
            this.GrpPorcentaje.AppearanceCaption.Options.UseForeColor = true;
            this.GrpPorcentaje.AppearanceCaption.Options.UseTextOptions = true;
            this.GrpPorcentaje.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.GrpPorcentaje.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.GrpPorcentaje.Controls.Add(this.LblPorcenSuma);
            this.GrpPorcentaje.Controls.Add(this.LblPorcenID);
            this.GrpPorcentaje.Controls.Add(this.LblPorcenParam);
            this.GrpPorcentaje.Controls.Add(this.BtnPorcenPasar);
            this.GrpPorcentaje.Controls.Add(this.label7);
            this.GrpPorcentaje.Controls.Add(this.TxtPorcen);
            this.GrpPorcentaje.Location = new System.Drawing.Point(410, 166);
            this.GrpPorcentaje.Name = "GrpPorcentaje";
            this.GrpPorcentaje.Size = new System.Drawing.Size(250, 87);
            this.GrpPorcentaje.TabIndex = 25;
            this.GrpPorcentaje.Text = "Porcentajes";
            // 
            // LblPorcenSuma
            // 
            this.LblPorcenSuma.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPorcenSuma.Location = new System.Drawing.Point(197, 28);
            this.LblPorcenSuma.Name = "LblPorcenSuma";
            this.LblPorcenSuma.Size = new System.Drawing.Size(39, 15);
            this.LblPorcenSuma.TabIndex = 29;
            this.LblPorcenSuma.Tag = "XXXXXF";
            this.LblPorcenSuma.Text = "0";
            // 
            // LblPorcenID
            // 
            this.LblPorcenID.AutoSize = true;
            this.LblPorcenID.Location = new System.Drawing.Point(232, 45);
            this.LblPorcenID.Name = "LblPorcenID";
            this.LblPorcenID.Size = new System.Drawing.Size(13, 13);
            this.LblPorcenID.TabIndex = 28;
            this.LblPorcenID.Text = "n";
            this.LblPorcenID.Visible = false;
            // 
            // LblPorcenParam
            // 
            this.LblPorcenParam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.LblPorcenParam.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPorcenParam.Location = new System.Drawing.Point(12, 58);
            this.LblPorcenParam.Name = "LblPorcenParam";
            this.LblPorcenParam.Size = new System.Drawing.Size(226, 19);
            this.LblPorcenParam.TabIndex = 27;
            this.LblPorcenParam.Tag = "XXXXB";
            this.LblPorcenParam.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnPorcenPasar
            // 
            this.BtnPorcenPasar.Enabled = false;
            this.BtnPorcenPasar.Location = new System.Drawing.Point(93, 25);
            this.BtnPorcenPasar.Name = "BtnPorcenPasar";
            this.BtnPorcenPasar.Size = new System.Drawing.Size(98, 22);
            this.BtnPorcenPasar.TabIndex = 18;
            this.BtnPorcenPasar.Text = "Pasar a la lista";
            this.BtnPorcenPasar.UseVisualStyleBackColor = true;
            this.BtnPorcenPasar.Click += new System.EventHandler(this.BtnPorcenPasar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 13);
            this.label7.TabIndex = 5;
            this.label7.Tag = "XXXXXF";
            this.label7.Text = "% :";
            // 
            // TxtPorcen
            // 
            this.TxtPorcen.AcceptsReturn = true;
            this.TxtPorcen.AcceptsTab = true;
            this.TxtPorcen.Location = new System.Drawing.Point(37, 25);
            this.TxtPorcen.Name = "TxtPorcen";
            this.TxtPorcen.Size = new System.Drawing.Size(46, 20);
            this.TxtPorcen.TabIndex = 14;
            this.TxtPorcen.Tag = "N";
            this.TxtPorcen.Text = "0";
            this.TxtPorcen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ListPorcentajes
            // 
            this.ListPorcentajes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ListPorcentajes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListPorcentajes.FullRowSelect = true;
            this.ListPorcentajes.Location = new System.Drawing.Point(410, 259);
            this.ListPorcentajes.MultiSelect = false;
            this.ListPorcentajes.Name = "ListPorcentajes";
            this.ListPorcentajes.Size = new System.Drawing.Size(250, 174);
            this.ListPorcentajes.TabIndex = 24;
            this.ListPorcentajes.Tag = "CS";
            this.ListPorcentajes.UseCompatibleStateImageBehavior = false;
            this.ListPorcentajes.View = System.Windows.Forms.View.Tile;
            this.ListPorcentajes.SelectedIndexChanged += new System.EventHandler(this.ListPorcentajes_SelectedIndexChanged);
            // 
            // ListPuntajes
            // 
            this.ListPuntajes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ListPuntajes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ListPuntajes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListPuntajes.FullRowSelect = true;
            this.ListPuntajes.Location = new System.Drawing.Point(0, 3);
            this.ListPuntajes.MultiSelect = false;
            this.ListPuntajes.Name = "ListPuntajes";
            this.ListPuntajes.Size = new System.Drawing.Size(404, 466);
            this.ListPuntajes.TabIndex = 1;
            this.ListPuntajes.Tag = "CS";
            this.ListPuntajes.UseCompatibleStateImageBehavior = false;
            this.ListPuntajes.View = System.Windows.Forms.View.Tile;
            this.ListPuntajes.SelectedIndexChanged += new System.EventHandler(this.ListPuntajes_SelectedIndexChanged);
            // 
            // GrpParamametros
            // 
            this.GrpParamametros.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.GrpParamametros.Appearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.GrpParamametros.Appearance.Font = new System.Drawing.Font("Tahoma", 588.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Strikeout))));
            this.GrpParamametros.Appearance.FontSizeDelta = 10;
            this.GrpParamametros.Appearance.Options.UseBackColor = true;
            this.GrpParamametros.Appearance.Options.UseBorderColor = true;
            this.GrpParamametros.Appearance.Options.UseFont = true;
            this.GrpParamametros.AppearanceCaption.BackColor = System.Drawing.Color.Transparent;
            this.GrpParamametros.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrpParamametros.AppearanceCaption.ForeColor = System.Drawing.Color.Black;
            this.GrpParamametros.AppearanceCaption.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.GrpParamametros.AppearanceCaption.Options.UseBackColor = true;
            this.GrpParamametros.AppearanceCaption.Options.UseBorderColor = true;
            this.GrpParamametros.AppearanceCaption.Options.UseFont = true;
            this.GrpParamametros.AppearanceCaption.Options.UseForeColor = true;
            this.GrpParamametros.AppearanceCaption.Options.UseTextOptions = true;
            this.GrpParamametros.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.GrpParamametros.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.GrpParamametros.Controls.Add(this.LblParamParam);
            this.GrpParamametros.Controls.Add(this.LblParamP);
            this.GrpParamametros.Controls.Add(this.LblParamID);
            this.GrpParamametros.Controls.Add(this.BtnParamPasar);
            this.GrpParamametros.Controls.Add(this.label2);
            this.GrpParamametros.Controls.Add(this.label1);
            this.GrpParamametros.Controls.Add(this.TxtParamH);
            this.GrpParamametros.Controls.Add(this.lblv);
            this.GrpParamametros.Controls.Add(this.TxtParamD);
            this.GrpParamametros.Controls.Add(this.TxtParamValor);
            this.GrpParamametros.Location = new System.Drawing.Point(410, 3);
            this.GrpParamametros.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.GrpParamametros.Name = "GrpParamametros";
            this.GrpParamametros.Size = new System.Drawing.Size(250, 146);
            this.GrpParamametros.TabIndex = 23;
            this.GrpParamametros.Text = "Parámetros";
            // 
            // LblParamParam
            // 
            this.LblParamParam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.LblParamParam.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblParamParam.Location = new System.Drawing.Point(12, 112);
            this.LblParamParam.Name = "LblParamParam";
            this.LblParamParam.Size = new System.Drawing.Size(222, 19);
            this.LblParamParam.TabIndex = 29;
            this.LblParamParam.Tag = "XXXXB";
            this.LblParamParam.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblParamP
            // 
            this.LblParamP.AutoSize = true;
            this.LblParamP.Location = new System.Drawing.Point(146, 63);
            this.LblParamP.Name = "LblParamP";
            this.LblParamP.Size = new System.Drawing.Size(13, 13);
            this.LblParamP.TabIndex = 28;
            this.LblParamP.Text = "n";
            this.LblParamP.Visible = false;
            // 
            // LblParamID
            // 
            this.LblParamID.AutoSize = true;
            this.LblParamID.Location = new System.Drawing.Point(479, 104);
            this.LblParamID.Name = "LblParamID";
            this.LblParamID.Size = new System.Drawing.Size(13, 13);
            this.LblParamID.TabIndex = 27;
            this.LblParamID.Text = "n";
            this.LblParamID.Visible = false;
            // 
            // BtnParamPasar
            // 
            this.BtnParamPasar.Enabled = false;
            this.BtnParamPasar.Location = new System.Drawing.Point(135, 79);
            this.BtnParamPasar.Name = "BtnParamPasar";
            this.BtnParamPasar.Size = new System.Drawing.Size(89, 22);
            this.BtnParamPasar.TabIndex = 18;
            this.BtnParamPasar.Text = "Pasar a la lista";
            this.BtnParamPasar.UseVisualStyleBackColor = true;
            this.BtnParamPasar.Click += new System.EventHandler(this.BtnParamPasar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 16;
            this.label2.Tag = "XXXXXF";
            this.label2.Text = "Hasta:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 15;
            this.label1.Tag = "XXXXXF";
            this.label1.Text = "Desde:";
            // 
            // TxtParamH
            // 
            this.TxtParamH.Location = new System.Drawing.Point(52, 54);
            this.TxtParamH.Name = "TxtParamH";
            this.TxtParamH.Size = new System.Drawing.Size(65, 20);
            this.TxtParamH.TabIndex = 12;
            this.TxtParamH.Tag = "N";
            this.TxtParamH.Text = "0";
            this.TxtParamH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblv
            // 
            this.lblv.AutoSize = true;
            this.lblv.Location = new System.Drawing.Point(12, 84);
            this.lblv.Name = "lblv";
            this.lblv.Size = new System.Drawing.Size(34, 13);
            this.lblv.TabIndex = 5;
            this.lblv.Tag = "XXXXXF";
            this.lblv.Text = "Valor:";
            // 
            // TxtParamD
            // 
            this.TxtParamD.Location = new System.Drawing.Point(52, 28);
            this.TxtParamD.Name = "TxtParamD";
            this.TxtParamD.Size = new System.Drawing.Size(65, 20);
            this.TxtParamD.TabIndex = 11;
            this.TxtParamD.Tag = "N";
            this.TxtParamD.Text = "0";
            this.TxtParamD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TxtParamValor
            // 
            this.TxtParamValor.AcceptsReturn = true;
            this.TxtParamValor.AcceptsTab = true;
            this.TxtParamValor.Location = new System.Drawing.Point(52, 81);
            this.TxtParamValor.Name = "TxtParamValor";
            this.TxtParamValor.Size = new System.Drawing.Size(65, 20);
            this.TxtParamValor.TabIndex = 14;
            this.TxtParamValor.Tag = "N";
            this.TxtParamValor.Text = "0";
            this.TxtParamValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtParamValor.Leave += new System.EventHandler(this.TxtParamValor_Leave);
            // 
            // lblFlechaI
            // 
            this.lblFlechaI.AutoSize = true;
            this.lblFlechaI.BackColor = System.Drawing.Color.Transparent;
            this.lblFlechaI.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFlechaI.ForeColor = System.Drawing.Color.Red;
            this.lblFlechaI.Location = new System.Drawing.Point(720, 9);
            this.lblFlechaI.Name = "lblFlechaI";
            this.lblFlechaI.Size = new System.Drawing.Size(15, 15);
            this.lblFlechaI.TabIndex = 49;
            this.lblFlechaI.Text = ">";
            // 
            // lblFlechaD
            // 
            this.lblFlechaD.AutoSize = true;
            this.lblFlechaD.BackColor = System.Drawing.Color.Transparent;
            this.lblFlechaD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFlechaD.ForeColor = System.Drawing.Color.Red;
            this.lblFlechaD.Location = new System.Drawing.Point(1181, 9);
            this.lblFlechaD.Name = "lblFlechaD";
            this.lblFlechaD.Size = new System.Drawing.Size(15, 15);
            this.lblFlechaD.TabIndex = 50;
            this.lblFlechaD.Text = "<";
            // 
            // FrmPuntaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1209, 481);
            this.Controls.Add(this.lblFlechaD);
            this.Controls.Add(this.lblFlechaI);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.ListPruebas);
            this.Controls.Add(this.BtnParamGrabar);
            this.Controls.Add(this.GrpPorcentaje);
            this.Controls.Add(this.ListPorcentajes);
            this.Controls.Add(this.ListPuntajes);
            this.Controls.Add(this.GrpParamametros);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmPuntaje";
            this.Text = "Puntaje";
            this.Load += new System.EventHandler(this.FrmPuntaje_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrpPorcentaje)).EndInit();
            this.GrpPorcentaje.ResumeLayout(false);
            this.GrpPorcentaje.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrpParamametros)).EndInit();
            this.GrpParamametros.ResumeLayout(false);
            this.GrpParamametros.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView ListPuntajes;
        private DevExpress.XtraEditors.GroupControl GrpParamametros;
        private System.Windows.Forms.Label LblParamP;
        private System.Windows.Forms.Label LblParamID;
        private System.Windows.Forms.Button BtnParamPasar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtParamH;
        private System.Windows.Forms.Label lblv;
        private System.Windows.Forms.TextBox TxtParamD;
        private System.Windows.Forms.TextBox TxtParamValor;
        private System.Windows.Forms.ListView ListPorcentajes;
        private DevExpress.XtraEditors.GroupControl GrpPorcentaje;
        private System.Windows.Forms.Label LblPorcenID;
        private System.Windows.Forms.Label LblPorcenParam;
        private System.Windows.Forms.Button BtnPorcenPasar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtPorcen;
        private System.Windows.Forms.Label LblPorcenSuma;
        private System.Windows.Forms.Label LblParamParam;
        private System.Windows.Forms.Button BtnParamGrabar;
        private System.Windows.Forms.ListView ListPruebas;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BtnPruPasa;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TxtPruCanc;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TxtPruCred;
        private System.Windows.Forms.TextBox TxtPruMora;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TxtPruIngr;
        private System.Windows.Forms.Label lblProfesion;
        private System.Windows.Forms.ComboBox cmbProfesion;
        private System.Windows.Forms.Label lblFlechaI;
        private System.Windows.Forms.Label lblFlechaD;
    }
}