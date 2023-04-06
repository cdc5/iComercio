namespace iComercio.Forms
{
    partial class FrmConsultaCobranzas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConsultaCobranzas));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblMor = new System.Windows.Forms.Label();
            this.txtHasta = new System.Windows.Forms.DateTimePicker();
            this.txtDesde = new System.Windows.Forms.DateTimePicker();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.cmbBusca = new System.Windows.Forms.ComboBox();
            this.listBusca = new System.Windows.Forms.ListView();
            this.lblFlechaI = new System.Windows.Forms.Label();
            this.lblFlechaD = new System.Windows.Forms.Label();
            this.BtnBusca = new System.Windows.Forms.Button();
            this.lblMsg = new System.Windows.Forms.Label();
            this.btnExportar = new System.Windows.Forms.Button();
            this.lblAguarde = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblMor);
            this.panel1.Controls.Add(this.txtHasta);
            this.panel1.Controls.Add(this.txtDesde);
            this.panel1.Controls.Add(this.lblBuscar);
            this.panel1.Controls.Add(this.cmbBusca);
            this.panel1.Location = new System.Drawing.Point(15, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(445, 54);
            this.panel1.TabIndex = 0;
            // 
            // lblMor
            // 
            this.lblMor.BackColor = System.Drawing.Color.Black;
            this.lblMor.Location = new System.Drawing.Point(206, 22);
            this.lblMor.Name = "lblMor";
            this.lblMor.Size = new System.Drawing.Size(6, 22);
            this.lblMor.TabIndex = 46;
            // 
            // txtHasta
            // 
            this.txtHasta.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.txtHasta.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtHasta.Location = new System.Drawing.Point(325, 22);
            this.txtHasta.Name = "txtHasta";
            this.txtHasta.Size = new System.Drawing.Size(99, 22);
            this.txtHasta.TabIndex = 2;
            // 
            // txtDesde
            // 
            this.txtDesde.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.txtDesde.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDesde.Location = new System.Drawing.Point(220, 22);
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
            this.listBusca.TabIndex = 5;
            this.listBusca.UseCompatibleStateImageBehavior = false;
            this.listBusca.View = System.Windows.Forms.View.Tile;
            this.listBusca.SelectedIndexChanged += new System.EventHandler(this.listBusca_SelectedIndexChanged);
            this.listBusca.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBusca_MouseDoubleClick);
            // 
            // lblFlechaI
            // 
            this.lblFlechaI.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblFlechaI.AutoSize = true;
            this.lblFlechaI.BackColor = System.Drawing.Color.Transparent;
            this.lblFlechaI.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFlechaI.ForeColor = System.Drawing.Color.Red;
            this.lblFlechaI.Location = new System.Drawing.Point(-2, 88);
            this.lblFlechaI.Name = "lblFlechaI";
            this.lblFlechaI.Size = new System.Drawing.Size(15, 15);
            this.lblFlechaI.TabIndex = 49;
            this.lblFlechaI.Text = ">";
            // 
            // lblFlechaD
            // 
            this.lblFlechaD.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblFlechaD.AutoSize = true;
            this.lblFlechaD.BackColor = System.Drawing.Color.Transparent;
            this.lblFlechaD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFlechaD.ForeColor = System.Drawing.Color.Red;
            this.lblFlechaD.Location = new System.Drawing.Point(871, 88);
            this.lblFlechaD.Name = "lblFlechaD";
            this.lblFlechaD.Size = new System.Drawing.Size(15, 15);
            this.lblFlechaD.TabIndex = 50;
            this.lblFlechaD.Text = "<";
            // 
            // BtnBusca
            // 
            this.BtnBusca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBusca.Location = new System.Drawing.Point(466, 18);
            this.BtnBusca.Name = "BtnBusca";
            this.BtnBusca.Size = new System.Drawing.Size(117, 36);
            this.BtnBusca.TabIndex = 1;
            this.BtnBusca.Text = "Buscar";
            this.BtnBusca.UseVisualStyleBackColor = true;
            this.BtnBusca.Click += new System.EventHandler(this.BtnBusca_Click);
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
            this.lblMsg.TabIndex = 52;
            this.lblMsg.Tag = "XXXXB";
            this.lblMsg.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            // lblAguarde
            // 
            this.lblAguarde.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAguarde.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblAguarde.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAguarde.Location = new System.Drawing.Point(90, 182);
            this.lblAguarde.Name = "lblAguarde";
            this.lblAguarde.Size = new System.Drawing.Size(705, 23);
            this.lblAguarde.TabIndex = 92;
            this.lblAguarde.Visible = false;
            // 
            // FrmConsultaCobranzas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(885, 387);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.BtnBusca);
            this.Controls.Add(this.lblFlechaD);
            this.Controls.Add(this.lblFlechaI);
            this.Controls.Add(this.listBusca);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblAguarde);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FrmConsultaCobranzas";
            this.Text = "Consultar Cobranzas";
            this.Load += new System.EventHandler(this.FrmConsultaCobranzas_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmConsultaCobranzas_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.ComboBox cmbBusca;
        private System.Windows.Forms.DateTimePicker txtHasta;
        private System.Windows.Forms.DateTimePicker txtDesde;
        private System.Windows.Forms.ListView listBusca;
        private System.Windows.Forms.Label lblFlechaI;
        private System.Windows.Forms.Label lblFlechaD;
        private System.Windows.Forms.Button BtnBusca;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Label lblAguarde;
        private System.Windows.Forms.Label lblMor;
    }
}