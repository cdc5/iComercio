namespace iComercio.Forms
{
    partial class FrmRevision
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
            if(disposing && (components != null))
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRevision));
            this.cmbBusca = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtDesde = new System.Windows.Forms.DateTimePicker();
            this.txtHasta = new System.Windows.Forms.DateTimePicker();
            this.cmbQueBusca = new System.Windows.Forms.ComboBox();
            this.listBusca = new System.Windows.Forms.ListView();
            this.BtnBusca = new System.Windows.Forms.Button();
            this.lblMsg = new System.Windows.Forms.Label();
            this.btnArreglo = new System.Windows.Forms.Button();
            this.cmbSEMANA = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkRetencion = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbBusca
            // 
            this.cmbBusca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBusca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbBusca.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBusca.FormattingEnabled = true;
            this.cmbBusca.Location = new System.Drawing.Point(12, 12);
            this.cmbBusca.Name = "cmbBusca";
            this.cmbBusca.Size = new System.Drawing.Size(408, 22);
            this.cmbBusca.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtDesde);
            this.panel1.Controls.Add(this.txtHasta);
            this.panel1.Controls.Add(this.cmbQueBusca);
            this.panel1.Location = new System.Drawing.Point(12, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(542, 62);
            this.panel1.TabIndex = 1;
            // 
            // txtDesde
            // 
            this.txtDesde.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.txtDesde.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDesde.Location = new System.Drawing.Point(222, 20);
            this.txtDesde.Name = "txtDesde";
            this.txtDesde.Size = new System.Drawing.Size(99, 22);
            this.txtDesde.TabIndex = 1;
            // 
            // txtHasta
            // 
            this.txtHasta.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.txtHasta.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtHasta.Location = new System.Drawing.Point(341, 20);
            this.txtHasta.Name = "txtHasta";
            this.txtHasta.Size = new System.Drawing.Size(99, 22);
            this.txtHasta.TabIndex = 2;
            // 
            // cmbQueBusca
            // 
            this.cmbQueBusca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQueBusca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbQueBusca.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbQueBusca.FormattingEnabled = true;
            this.cmbQueBusca.Location = new System.Drawing.Point(18, 18);
            this.cmbQueBusca.Name = "cmbQueBusca";
            this.cmbQueBusca.Size = new System.Drawing.Size(185, 22);
            this.cmbQueBusca.TabIndex = 0;
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
            this.listBusca.Location = new System.Drawing.Point(12, 127);
            this.listBusca.MultiSelect = false;
            this.listBusca.Name = "listBusca";
            this.listBusca.Size = new System.Drawing.Size(1086, 273);
            this.listBusca.TabIndex = 61;
            this.listBusca.UseCompatibleStateImageBehavior = false;
            this.listBusca.View = System.Windows.Forms.View.Tile;
            // 
            // BtnBusca
            // 
            this.BtnBusca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBusca.Location = new System.Drawing.Point(569, 50);
            this.BtnBusca.Name = "BtnBusca";
            this.BtnBusca.Size = new System.Drawing.Size(117, 36);
            this.BtnBusca.TabIndex = 62;
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
            this.lblMsg.Location = new System.Drawing.Point(12, 105);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(1086, 19);
            this.lblMsg.TabIndex = 63;
            this.lblMsg.Tag = "XXXXB";
            this.lblMsg.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnArreglo
            // 
            this.btnArreglo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArreglo.Location = new System.Drawing.Point(692, 50);
            this.btnArreglo.Name = "btnArreglo";
            this.btnArreglo.Size = new System.Drawing.Size(117, 36);
            this.btnArreglo.TabIndex = 64;
            this.btnArreglo.Text = "Arreglar";
            this.btnArreglo.UseVisualStyleBackColor = true;
            this.btnArreglo.Click += new System.EventHandler(this.btnArreglo_Click);
            // 
            // cmbSEMANA
            // 
            this.cmbSEMANA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSEMANA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSEMANA.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSEMANA.FormattingEnabled = true;
            this.cmbSEMANA.Location = new System.Drawing.Point(815, 64);
            this.cmbSEMANA.Name = "cmbSEMANA";
            this.cmbSEMANA.Size = new System.Drawing.Size(195, 22);
            this.cmbSEMANA.TabIndex = 71;
            this.cmbSEMANA.Tag = "XE";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(815, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 72;
            this.label1.Text = "Día de rendición";
            // 
            // chkRetencion
            // 
            this.chkRetencion.AutoSize = true;
            this.chkRetencion.Location = new System.Drawing.Point(579, 10);
            this.chkRetencion.Name = "chkRetencion";
            this.chkRetencion.Size = new System.Drawing.Size(109, 17);
            this.chkRetencion.TabIndex = 73;
            this.chkRetencion.Text = "Arreglar retención";
            this.chkRetencion.UseVisualStyleBackColor = true;
            // 
            // FrmRevision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 450);
            this.Controls.Add(this.chkRetencion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbSEMANA);
            this.Controls.Add(this.btnArreglo);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.BtnBusca);
            this.Controls.Add(this.listBusca);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmbBusca);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmRevision";
            this.Text = "FrmRevision";
            this.Load += new System.EventHandler(this.FrmRevision_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbBusca;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbQueBusca;
        private System.Windows.Forms.DateTimePicker txtDesde;
        private System.Windows.Forms.DateTimePicker txtHasta;
        private System.Windows.Forms.ListView listBusca;
        private System.Windows.Forms.Button BtnBusca;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Button btnArreglo;
        private System.Windows.Forms.ComboBox cmbSEMANA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkRetencion;
    }
}