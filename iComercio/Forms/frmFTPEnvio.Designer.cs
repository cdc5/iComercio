namespace iComercio.Forms
{
    partial class frmFTPEnvio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFTPEnvio));
            this.lblAguarde = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lblArchivo = new System.Windows.Forms.Label();
            this.lblDir = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblAguarde
            // 
            this.lblAguarde.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblAguarde.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAguarde.Location = new System.Drawing.Point(44, 80);
            this.lblAguarde.Name = "lblAguarde";
            this.lblAguarde.Size = new System.Drawing.Size(644, 23);
            this.lblAguarde.TabIndex = 91;
            this.lblAguarde.Text = "c";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(619, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 35);
            this.button1.TabIndex = 92;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblArchivo
            // 
            this.lblArchivo.BackColor = System.Drawing.Color.White;
            this.lblArchivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblArchivo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblArchivo.ForeColor = System.Drawing.Color.Black;
            this.lblArchivo.Location = new System.Drawing.Point(119, 9);
            this.lblArchivo.Name = "lblArchivo";
            this.lblArchivo.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lblArchivo.Size = new System.Drawing.Size(475, 22);
            this.lblArchivo.TabIndex = 93;
            this.lblArchivo.Text = "Eduardo Héctor Palermo Pinto";
            this.lblArchivo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDir
            // 
            this.lblDir.BackColor = System.Drawing.Color.White;
            this.lblDir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblDir.ForeColor = System.Drawing.Color.Black;
            this.lblDir.Location = new System.Drawing.Point(119, 36);
            this.lblDir.Name = "lblDir";
            this.lblDir.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lblDir.Size = new System.Drawing.Size(475, 22);
            this.lblDir.TabIndex = 94;
            this.lblDir.Text = "Eduardo Héctor Palermo Pinto";
            this.lblDir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDir.Visible = false;
            // 
            // frmFTPEnvio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 123);
            this.Controls.Add(this.lblDir);
            this.Controls.Add(this.lblArchivo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblAguarde);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmFTPEnvio";
            this.Text = "frmFTPEnvio";
            this.Load += new System.EventHandler(this.frmFTPEnvio_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblAguarde;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblArchivo;
        private System.Windows.Forms.Label lblDir;
    }
}