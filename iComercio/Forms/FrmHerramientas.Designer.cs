namespace iComercio.Forms
{
    partial class FrmHerramientas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHerramientas));
            this.BtnSepara = new System.Windows.Forms.Button();
            this.lblMsg = new System.Windows.Forms.Label();
            this.lblreg = new System.Windows.Forms.Label();
            this.lblCambio = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnSepara
            // 
            this.BtnSepara.Location = new System.Drawing.Point(23, 12);
            this.BtnSepara.Name = "BtnSepara";
            this.BtnSepara.Size = new System.Drawing.Size(165, 31);
            this.BtnSepara.TabIndex = 0;
            this.BtnSepara.Text = "Separar nombre";
            this.BtnSepara.UseVisualStyleBackColor = true;
            this.BtnSepara.Click += new System.EventHandler(this.BtnSepara_Click);
            // 
            // lblMsg
            // 
            this.lblMsg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.Location = new System.Drawing.Point(12, 222);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(584, 30);
            this.lblMsg.TabIndex = 1;
            // 
            // lblreg
            // 
            this.lblreg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblreg.Location = new System.Drawing.Point(20, 46);
            this.lblreg.Name = "lblreg";
            this.lblreg.Size = new System.Drawing.Size(168, 23);
            this.lblreg.TabIndex = 2;
            this.lblreg.Text = "0";
            // 
            // lblCambio
            // 
            this.lblCambio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCambio.Location = new System.Drawing.Point(20, 80);
            this.lblCambio.Name = "lblCambio";
            this.lblCambio.Size = new System.Drawing.Size(168, 23);
            this.lblCambio.TabIndex = 3;
            this.lblCambio.Text = "0";
            // 
            // FrmHerramientas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 261);
            this.Controls.Add(this.lblCambio);
            this.Controls.Add(this.lblreg);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.BtnSepara);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmHerramientas";
            this.Text = "Herramientas";
            this.Load += new System.EventHandler(this.Herramientas_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnSepara;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Label lblreg;
        private System.Windows.Forms.Label lblCambio;
    }
}