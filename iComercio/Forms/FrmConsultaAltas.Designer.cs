namespace iComercio.Forms
{
    partial class FrmConsultaAltas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConsultaAltas));
            this.listBusca = new System.Windows.Forms.ListView();
            this.btnExportar = new System.Windows.Forms.Button();
            this.lblMsg = new System.Windows.Forms.Label();
            this.BtnBusca = new System.Windows.Forms.Button();
            this.lblFlechaD = new System.Windows.Forms.Label();
            this.lblFlechaI = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblMor = new System.Windows.Forms.Label();
            this.lblUltiFech = new System.Windows.Forms.Label();
            this.lblCantCred = new System.Windows.Forms.Label();
            this.txtCantCred = new System.Windows.Forms.TextBox();
            this.cmbBusca2 = new System.Windows.Forms.ComboBox();
            this.op3 = new System.Windows.Forms.RadioButton();
            this.op2 = new System.Windows.Forms.RadioButton();
            this.op1 = new System.Windows.Forms.RadioButton();
            this.txtHasta = new System.Windows.Forms.DateTimePicker();
            this.txtDesde = new System.Windows.Forms.DateTimePicker();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.cmbBusca = new System.Windows.Forms.ComboBox();
            this.lblAguarde = new System.Windows.Forms.Label();
            this.Grid = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            this.SuspendLayout();
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
            this.listBusca.Location = new System.Drawing.Point(15, 79);
            this.listBusca.MultiSelect = false;
            this.listBusca.Name = "listBusca";
            this.listBusca.Size = new System.Drawing.Size(857, 300);
            this.listBusca.TabIndex = 60;
            this.listBusca.UseCompatibleStateImageBehavior = false;
            this.listBusca.View = System.Windows.Forms.View.Tile;
            this.listBusca.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBusca_MouseDoubleClick_1);
            // 
            // btnExportar
            // 
            this.btnExportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportar.Location = new System.Drawing.Point(755, 18);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(117, 36);
            this.btnExportar.TabIndex = 2;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // lblMsg
            // 
            this.lblMsg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMsg.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.Location = new System.Drawing.Point(15, 57);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(857, 19);
            this.lblMsg.TabIndex = 58;
            this.lblMsg.Tag = "XXXXB";
            this.lblMsg.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // BtnBusca
            // 
            this.BtnBusca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBusca.Location = new System.Drawing.Point(622, 18);
            this.BtnBusca.Name = "BtnBusca";
            this.BtnBusca.Size = new System.Drawing.Size(117, 36);
            this.BtnBusca.TabIndex = 1;
            this.BtnBusca.Text = "Buscar";
            this.BtnBusca.UseVisualStyleBackColor = true;
            this.BtnBusca.Click += new System.EventHandler(this.BtnBusca_Click);
            // 
            // lblFlechaD
            // 
            this.lblFlechaD.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblFlechaD.AutoSize = true;
            this.lblFlechaD.BackColor = System.Drawing.Color.Transparent;
            this.lblFlechaD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFlechaD.ForeColor = System.Drawing.Color.Red;
            this.lblFlechaD.Location = new System.Drawing.Point(868, 83);
            this.lblFlechaD.Name = "lblFlechaD";
            this.lblFlechaD.Size = new System.Drawing.Size(15, 15);
            this.lblFlechaD.TabIndex = 56;
            this.lblFlechaD.Text = "<";
            // 
            // lblFlechaI
            // 
            this.lblFlechaI.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblFlechaI.AutoSize = true;
            this.lblFlechaI.BackColor = System.Drawing.Color.Transparent;
            this.lblFlechaI.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFlechaI.ForeColor = System.Drawing.Color.Red;
            this.lblFlechaI.Location = new System.Drawing.Point(5, 83);
            this.lblFlechaI.Name = "lblFlechaI";
            this.lblFlechaI.Size = new System.Drawing.Size(15, 15);
            this.lblFlechaI.TabIndex = 55;
            this.lblFlechaI.Text = ">";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblMor);
            this.panel1.Controls.Add(this.lblUltiFech);
            this.panel1.Controls.Add(this.lblCantCred);
            this.panel1.Controls.Add(this.txtCantCred);
            this.panel1.Controls.Add(this.cmbBusca2);
            this.panel1.Controls.Add(this.op3);
            this.panel1.Controls.Add(this.op2);
            this.panel1.Controls.Add(this.op1);
            this.panel1.Controls.Add(this.txtHasta);
            this.panel1.Controls.Add(this.txtDesde);
            this.panel1.Controls.Add(this.lblBuscar);
            this.panel1.Controls.Add(this.cmbBusca);
            this.panel1.Location = new System.Drawing.Point(15, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(606, 54);
            this.panel1.TabIndex = 0;
            // 
            // lblMor
            // 
            this.lblMor.BackColor = System.Drawing.Color.Black;
            this.lblMor.Location = new System.Drawing.Point(203, 22);
            this.lblMor.Name = "lblMor";
            this.lblMor.Size = new System.Drawing.Size(6, 22);
            this.lblMor.TabIndex = 45;
            // 
            // lblUltiFech
            // 
            this.lblUltiFech.AutoSize = true;
            this.lblUltiFech.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblUltiFech.ForeColor = System.Drawing.Color.Blue;
            this.lblUltiFech.Location = new System.Drawing.Point(215, 5);
            this.lblUltiFech.Name = "lblUltiFech";
            this.lblUltiFech.Size = new System.Drawing.Size(124, 15);
            this.lblUltiFech.TabIndex = 21;
            this.lblUltiFech.Tag = "XXXXXF";
            this.lblUltiFech.Text = "Fechas último crédito";
            // 
            // lblCantCred
            // 
            this.lblCantCred.AutoSize = true;
            this.lblCantCred.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblCantCred.ForeColor = System.Drawing.Color.Blue;
            this.lblCantCred.Location = new System.Drawing.Point(410, 4);
            this.lblCantCred.Name = "lblCantCred";
            this.lblCantCred.Size = new System.Drawing.Size(48, 15);
            this.lblCantCred.TabIndex = 20;
            this.lblCantCred.Tag = "XXXXXF";
            this.lblCantCred.Text = "Buscar:";
            // 
            // txtCantCred
            // 
            this.txtCantCred.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantCred.Location = new System.Drawing.Point(432, 23);
            this.txtCantCred.Name = "txtCantCred";
            this.txtCantCred.Size = new System.Drawing.Size(67, 22);
            this.txtCantCred.TabIndex = 5;
            this.txtCantCred.Tag = "NN";
            this.txtCantCred.Text = "0";
            this.txtCantCred.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmbBusca2
            // 
            this.cmbBusca2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBusca2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbBusca2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBusca2.FormattingEnabled = true;
            this.cmbBusca2.Location = new System.Drawing.Point(218, 22);
            this.cmbBusca2.Name = "cmbBusca2";
            this.cmbBusca2.Size = new System.Drawing.Size(195, 22);
            this.cmbBusca2.TabIndex = 19;
            // 
            // op3
            // 
            this.op3.AutoSize = true;
            this.op3.Location = new System.Drawing.Point(522, 27);
            this.op3.Name = "op3";
            this.op3.Size = new System.Drawing.Size(60, 17);
            this.op3.TabIndex = 18;
            this.op3.TabStop = true;
            this.op3.Text = "Primera";
            this.op3.UseVisualStyleBackColor = true;
            // 
            // op2
            // 
            this.op2.AutoSize = true;
            this.op2.Location = new System.Drawing.Point(522, 8);
            this.op2.Name = "op2";
            this.op2.Size = new System.Drawing.Size(53, 17);
            this.op2.TabIndex = 17;
            this.op2.TabStop = true;
            this.op2.Text = "Única";
            this.op2.UseVisualStyleBackColor = true;
            // 
            // op1
            // 
            this.op1.AutoSize = true;
            this.op1.Location = new System.Drawing.Point(445, 8);
            this.op1.Name = "op1";
            this.op1.Size = new System.Drawing.Size(55, 17);
            this.op1.TabIndex = 16;
            this.op1.TabStop = true;
            this.op1.Text = "Todos";
            this.op1.UseVisualStyleBackColor = true;
            // 
            // txtHasta
            // 
            this.txtHasta.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.txtHasta.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtHasta.Location = new System.Drawing.Point(323, 22);
            this.txtHasta.Name = "txtHasta";
            this.txtHasta.Size = new System.Drawing.Size(99, 22);
            this.txtHasta.TabIndex = 2;
            // 
            // txtDesde
            // 
            this.txtDesde.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.txtDesde.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDesde.Location = new System.Drawing.Point(218, 22);
            this.txtDesde.Name = "txtDesde";
            this.txtDesde.Size = new System.Drawing.Size(99, 22);
            this.txtDesde.TabIndex = 1;
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblBuscar.ForeColor = System.Drawing.Color.Blue;
            this.lblBuscar.Location = new System.Drawing.Point(10, 4);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(48, 15);
            this.lblBuscar.TabIndex = 15;
            this.lblBuscar.Tag = "XXXXXF";
            this.lblBuscar.Text = "Buscar:";
            // 
            // cmbBusca
            // 
            this.cmbBusca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBusca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbBusca.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBusca.FormattingEnabled = true;
            this.cmbBusca.Location = new System.Drawing.Point(10, 22);
            this.cmbBusca.Name = "cmbBusca";
            this.cmbBusca.Size = new System.Drawing.Size(195, 22);
            this.cmbBusca.TabIndex = 0;
            this.cmbBusca.SelectedIndexChanged += new System.EventHandler(this.cmbBusca_SelectedIndexChanged);
            // 
            // lblAguarde
            // 
            this.lblAguarde.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblAguarde.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAguarde.Location = new System.Drawing.Point(304, 159);
            this.lblAguarde.Name = "lblAguarde";
            this.lblAguarde.Size = new System.Drawing.Size(644, 23);
            this.lblAguarde.TabIndex = 91;
            // 
            // Grid
            // 
            this.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid.Location = new System.Drawing.Point(702, 5);
            this.Grid.Name = "Grid";
            this.Grid.Size = new System.Drawing.Size(62, 26);
            this.Grid.TabIndex = 92;
            this.Grid.Visible = false;
            // 
            // FrmConsultaAltas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 387);
            this.Controls.Add(this.Grid);
            this.Controls.Add(this.listBusca);
            this.Controls.Add(this.lblAguarde);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.BtnBusca);
            this.Controls.Add(this.lblFlechaD);
            this.Controls.Add(this.lblFlechaI);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FrmConsultaAltas";
            this.Text = "Consulta Altas";
            this.Load += new System.EventHandler(this.FrmConsultaAltas_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmConsultaAltas_KeyDown);
            this.Resize += new System.EventHandler(this.FrmConsultaAltas_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Button BtnBusca;
        private System.Windows.Forms.Label lblFlechaD;
        private System.Windows.Forms.Label lblFlechaI;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker txtHasta;
        private System.Windows.Forms.DateTimePicker txtDesde;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.ComboBox cmbBusca;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.ListView listBusca;
        private System.Windows.Forms.RadioButton op3;
        private System.Windows.Forms.RadioButton op2;
        private System.Windows.Forms.RadioButton op1;
        private System.Windows.Forms.ComboBox cmbBusca2;
        private System.Windows.Forms.TextBox txtCantCred;
        private System.Windows.Forms.Label lblCantCred;
        private System.Windows.Forms.Label lblUltiFech;
        private System.Windows.Forms.Label lblAguarde;
        private System.Windows.Forms.Label lblMor;
        private System.Windows.Forms.DataGridView Grid;
    }
}