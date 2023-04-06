namespace iComercio.Forms
{
    partial class FrmBuscaCliNombre
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBuscaCliNombre));
            this.listCliente = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.cmbBuscaCli = new System.Windows.Forms.ComboBox();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.txtBuscaCli = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblMor = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listCliente
            // 
            this.listCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listCliente.BackColor = System.Drawing.SystemColors.Control;
            this.listCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listCliente.FullRowSelect = true;
            this.listCliente.GridLines = true;
            this.listCliente.HideSelection = false;
            this.listCliente.Location = new System.Drawing.Point(2, 73);
            this.listCliente.MultiSelect = false;
            this.listCliente.Name = "listCliente";
            this.listCliente.Size = new System.Drawing.Size(768, 572);
            this.listCliente.TabIndex = 3;
            this.listCliente.UseCompatibleStateImageBehavior = false;
            this.listCliente.View = System.Windows.Forms.View.Tile;
            this.listCliente.SelectedIndexChanged += new System.EventHandler(this.listCliente_SelectedIndexChanged);
            this.listCliente.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listCliente_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(338, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 17);
            this.label1.TabIndex = 13;
            this.label1.Tag = "XXXXXF";
            this.label1.Text = "Buscar por";
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscar.Location = new System.Drawing.Point(1, 14);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(136, 17);
            this.lblBuscar.TabIndex = 12;
            this.lblBuscar.Tag = "XXXXXF";
            this.lblBuscar.Text = "Ingrese el nombre";
            // 
            // cmbBuscaCli
            // 
            this.cmbBuscaCli.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBuscaCli.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbBuscaCli.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBuscaCli.FormattingEnabled = true;
            this.cmbBuscaCli.Location = new System.Drawing.Point(343, 34);
            this.cmbBuscaCli.Name = "cmbBuscaCli";
            this.cmbBuscaCli.Size = new System.Drawing.Size(209, 22);
            this.cmbBuscaCli.TabIndex = 1;
            this.cmbBuscaCli.SelectedIndexChanged += new System.EventHandler(this.cmbBuscaCli_SelectedIndexChanged);
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBuscar.Location = new System.Drawing.Point(560, 23);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(201, 36);
            this.BtnBuscar.TabIndex = 2;
            this.BtnBuscar.Text = "Buscar";
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // txtBuscaCli
            // 
            this.txtBuscaCli.AcceptsReturn = true;
            this.txtBuscaCli.AcceptsTab = true;
            this.txtBuscaCli.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscaCli.Location = new System.Drawing.Point(3, 34);
            this.txtBuscaCli.Name = "txtBuscaCli";
            this.txtBuscaCli.Size = new System.Drawing.Size(325, 23);
            this.txtBuscaCli.TabIndex = 0;
            this.txtBuscaCli.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscaCli_KeyPress);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.lblMor);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtBuscaCli);
            this.panel1.Controls.Add(this.lblBuscar);
            this.panel1.Controls.Add(this.BtnBuscar);
            this.panel1.Controls.Add(this.cmbBuscaCli);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(768, 68);
            this.panel1.TabIndex = 24;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lblMor
            // 
            this.lblMor.BackColor = System.Drawing.Color.Black;
            this.lblMor.Location = new System.Drawing.Point(328, 34);
            this.lblMor.Name = "lblMor";
            this.lblMor.Size = new System.Drawing.Size(10, 23);
            this.lblMor.TabIndex = 43;
            // 
            // FrmBuscaCliNombre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 646);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listCliente);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FrmBuscaCliNombre";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar cliente por nombre";
            this.Load += new System.EventHandler(this.FrmBuscaCliNombre_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmBuscaCliNombre_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.TextBox txtBuscaCli;
        private System.Windows.Forms.ComboBox cmbBuscaCli;
        private System.Windows.Forms.ListView listCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblMor;
    }
}