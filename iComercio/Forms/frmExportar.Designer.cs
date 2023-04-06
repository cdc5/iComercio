namespace iComercio.Forms
{
    partial class frmExportar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExportar));
            this.btnImpresora = new System.Windows.Forms.Button();
            this.btnPorta = new System.Windows.Forms.Button();
            this.btnPlani = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOtro = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnImpresora
            // 
            this.btnImpresora.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImpresora.Location = new System.Drawing.Point(6, 103);
            this.btnImpresora.Name = "btnImpresora";
            this.btnImpresora.Size = new System.Drawing.Size(153, 28);
            this.btnImpresora.TabIndex = 7;
            this.btnImpresora.Text = "Impresora";
            this.btnImpresora.UseVisualStyleBackColor = true;
            this.btnImpresora.Click += new System.EventHandler(this.btnImpresora_Click);
            // 
            // btnPorta
            // 
            this.btnPorta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPorta.Location = new System.Drawing.Point(6, 62);
            this.btnPorta.Name = "btnPorta";
            this.btnPorta.Size = new System.Drawing.Size(153, 28);
            this.btnPorta.TabIndex = 6;
            this.btnPorta.Text = "Portapapeles";
            this.btnPorta.UseVisualStyleBackColor = true;
            this.btnPorta.Click += new System.EventHandler(this.btnPorta_Click);
            // 
            // btnPlani
            // 
            this.btnPlani.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlani.Location = new System.Drawing.Point(6, 19);
            this.btnPlani.Name = "btnPlani";
            this.btnPlani.Size = new System.Drawing.Size(153, 28);
            this.btnPlani.TabIndex = 5;
            this.btnPlani.Text = "Planilla";
            this.btnPlani.UseVisualStyleBackColor = true;
            this.btnPlani.Click += new System.EventHandler(this.btnPlani_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(6, 268);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(153, 28);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOtro);
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.btnImpresora);
            this.groupBox1.Controls.Add(this.btnPlani);
            this.groupBox1.Controls.Add(this.btnPorta);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Location = new System.Drawing.Point(9, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(170, 311);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // btnOtro
            // 
            this.btnOtro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOtro.Location = new System.Drawing.Point(6, 145);
            this.btnOtro.Name = "btnOtro";
            this.btnOtro.Size = new System.Drawing.Size(153, 28);
            this.btnOtro.TabIndex = 9;
            this.btnOtro.Text = "Otro";
            this.btnOtro.UseVisualStyleBackColor = true;
            this.btnOtro.Click += new System.EventHandler(this.btnOtro_Click);
            // 
            // frmExportar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(191, 326);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmExportar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmExportar";
            this.Load += new System.EventHandler(this.frmExportar_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnImpresora;
        private System.Windows.Forms.Button btnPorta;
        private System.Windows.Forms.Button btnPlani;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnOtro;
    }
}