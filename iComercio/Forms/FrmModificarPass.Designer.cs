namespace iComercio.Forms
{
    partial class FrmModificarPass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmModificarPass));
            this.lblNuevaCont = new System.Windows.Forms.Label();
            this.txtNuevoPass = new System.Windows.Forms.TextBox();
            this.txtRepetirPass = new System.Windows.Forms.TextBox();
            this.lblRepetirContraseña = new System.Windows.Forms.Label();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNuevaCont
            // 
            this.lblNuevaCont.AutoSize = true;
            this.lblNuevaCont.Location = new System.Drawing.Point(12, 18);
            this.lblNuevaCont.Name = "lblNuevaCont";
            this.lblNuevaCont.Size = new System.Drawing.Size(99, 13);
            this.lblNuevaCont.TabIndex = 0;
            this.lblNuevaCont.Text = "Nueva Contraseña:";
            // 
            // txtNuevoPass
            // 
            this.txtNuevoPass.Location = new System.Drawing.Point(119, 15);
            this.txtNuevoPass.Name = "txtNuevoPass";
            this.txtNuevoPass.PasswordChar = '*';
            this.txtNuevoPass.Size = new System.Drawing.Size(190, 20);
            this.txtNuevoPass.TabIndex = 1;
            // 
            // txtRepetirPass
            // 
            this.txtRepetirPass.Location = new System.Drawing.Point(119, 45);
            this.txtRepetirPass.Name = "txtRepetirPass";
            this.txtRepetirPass.PasswordChar = '*';
            this.txtRepetirPass.Size = new System.Drawing.Size(190, 20);
            this.txtRepetirPass.TabIndex = 3;
            // 
            // lblRepetirContraseña
            // 
            this.lblRepetirContraseña.AutoSize = true;
            this.lblRepetirContraseña.Location = new System.Drawing.Point(12, 48);
            this.lblRepetirContraseña.Name = "lblRepetirContraseña";
            this.lblRepetirContraseña.Size = new System.Drawing.Size(101, 13);
            this.lblRepetirContraseña.TabIndex = 2;
            this.lblRepetirContraseña.Text = "Repetir Contraseña:";
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(156, 71);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 4;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(237, 71);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // ModificarPass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 101);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.txtRepetirPass);
            this.Controls.Add(this.lblRepetirContraseña);
            this.Controls.Add(this.txtNuevoPass);
            this.Controls.Add(this.lblNuevaCont);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ModificarPass";
            this.Text = "Modificar Contraseña";
            this.Load += new System.EventHandler(this.ModificarPass_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNuevaCont;
        private System.Windows.Forms.TextBox txtNuevoPass;
        private System.Windows.Forms.TextBox txtRepetirPass;
        private System.Windows.Forms.Label lblRepetirContraseña;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnCancelar;
    }
}