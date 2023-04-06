namespace iComercio.Forms
{
    partial class FrmAsignarPerfiles
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAsignarPerfiles));
            this.perfilesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.usuarioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnQuitarPerfil = new System.Windows.Forms.Button();
            this.btnAsignarPerfil = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbPerfilesAsig = new System.Windows.Forms.ListBox();
            this.grbPerfiles = new System.Windows.Forms.GroupBox();
            this.lbPerfiles = new System.Windows.Forms.ListBox();
            this.grbUsuarios = new System.Windows.Forms.GroupBox();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.usuarioIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellidoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.activoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.permisosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.perfilesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usuarioBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.grbPerfiles.SuspendLayout();
            this.grbUsuarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.permisosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // perfilesBindingSource
            // 
            this.perfilesBindingSource.DataMember = "Perfiles";
            this.perfilesBindingSource.DataSource = this.usuarioBindingSource;
            // 
            // usuarioBindingSource
            // 
            this.usuarioBindingSource.DataSource = typeof(iComercio.Models.Usuario);
            // 
            // btnQuitarPerfil
            // 
            this.btnQuitarPerfil.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnQuitarPerfil.Location = new System.Drawing.Point(284, 445);
            this.btnQuitarPerfil.Name = "btnQuitarPerfil";
            this.btnQuitarPerfil.Size = new System.Drawing.Size(131, 28);
            this.btnQuitarPerfil.TabIndex = 10;
            this.btnQuitarPerfil.Text = "<";
            this.btnQuitarPerfil.UseVisualStyleBackColor = true;
            this.btnQuitarPerfil.Click += new System.EventHandler(this.btnQuitarPerfil_Click);
            // 
            // btnAsignarPerfil
            // 
            this.btnAsignarPerfil.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAsignarPerfil.Location = new System.Drawing.Point(284, 391);
            this.btnAsignarPerfil.Name = "btnAsignarPerfil";
            this.btnAsignarPerfil.Size = new System.Drawing.Size(131, 28);
            this.btnAsignarPerfil.TabIndex = 9;
            this.btnAsignarPerfil.Text = ">";
            this.btnAsignarPerfil.UseVisualStyleBackColor = true;
            this.btnAsignarPerfil.Click += new System.EventHandler(this.btnAsignarPerfil_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Location = new System.Drawing.Point(303, 505);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(91, 25);
            this.btnGrabar.TabIndex = 8;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click_1);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(303, 546);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(91, 25);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lbPerfilesAsig);
            this.groupBox1.Location = new System.Drawing.Point(463, 350);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(235, 332);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Perfiles Asignados";
            // 
            // lbPerfilesAsig
            // 
            this.lbPerfilesAsig.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbPerfilesAsig.FormattingEnabled = true;
            this.lbPerfilesAsig.Location = new System.Drawing.Point(3, 16);
            this.lbPerfilesAsig.Name = "lbPerfilesAsig";
            this.lbPerfilesAsig.Size = new System.Drawing.Size(226, 303);
            this.lbPerfilesAsig.TabIndex = 1;
            // 
            // grbPerfiles
            // 
            this.grbPerfiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbPerfiles.Controls.Add(this.lbPerfiles);
            this.grbPerfiles.Location = new System.Drawing.Point(11, 342);
            this.grbPerfiles.Name = "grbPerfiles";
            this.grbPerfiles.Size = new System.Drawing.Size(237, 340);
            this.grbPerfiles.TabIndex = 5;
            this.grbPerfiles.TabStop = false;
            this.grbPerfiles.Text = "Perfiles";
            // 
            // lbPerfiles
            // 
            this.lbPerfiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbPerfiles.FormattingEnabled = true;
            this.lbPerfiles.Location = new System.Drawing.Point(9, 16);
            this.lbPerfiles.Name = "lbPerfiles";
            this.lbPerfiles.Size = new System.Drawing.Size(222, 316);
            this.lbPerfiles.TabIndex = 0;
            // 
            // grbUsuarios
            // 
            this.grbUsuarios.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbUsuarios.Controls.Add(this.dgvUsuarios);
            this.grbUsuarios.Location = new System.Drawing.Point(12, 12);
            this.grbUsuarios.Name = "grbUsuarios";
            this.grbUsuarios.Size = new System.Drawing.Size(688, 326);
            this.grbUsuarios.TabIndex = 4;
            this.grbUsuarios.TabStop = false;
            this.grbUsuarios.Text = "Usuarios";
            this.grbUsuarios.Enter += new System.EventHandler(this.grbUsuarios_Enter);
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AllowUserToDeleteRows = false;
            this.dgvUsuarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUsuarios.AutoGenerateColumns = false;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.usuarioIDDataGridViewTextBoxColumn,
            this.usuarioDataGridViewTextBoxColumn,
            this.nombreDataGridViewTextBoxColumn,
            this.apellidoDataGridViewTextBoxColumn,
            this.activoDataGridViewCheckBoxColumn});
            this.dgvUsuarios.DataSource = this.usuarioBindingSource;
            this.dgvUsuarios.Location = new System.Drawing.Point(3, 16);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.Size = new System.Drawing.Size(679, 304);
            this.dgvUsuarios.TabIndex = 0;
            this.dgvUsuarios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuarios_CellContentClick);
            this.dgvUsuarios.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuarios_RowEnter);
            // 
            // usuarioIDDataGridViewTextBoxColumn
            // 
            this.usuarioIDDataGridViewTextBoxColumn.DataPropertyName = "UsuarioID";
            this.usuarioIDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.usuarioIDDataGridViewTextBoxColumn.Name = "usuarioIDDataGridViewTextBoxColumn";
            this.usuarioIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // usuarioDataGridViewTextBoxColumn
            // 
            this.usuarioDataGridViewTextBoxColumn.DataPropertyName = "usuario";
            this.usuarioDataGridViewTextBoxColumn.HeaderText = "Usuario";
            this.usuarioDataGridViewTextBoxColumn.Name = "usuarioDataGridViewTextBoxColumn";
            this.usuarioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "nombre";
            this.nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            this.nombreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // apellidoDataGridViewTextBoxColumn
            // 
            this.apellidoDataGridViewTextBoxColumn.DataPropertyName = "apellido";
            this.apellidoDataGridViewTextBoxColumn.HeaderText = "Apellido";
            this.apellidoDataGridViewTextBoxColumn.Name = "apellidoDataGridViewTextBoxColumn";
            this.apellidoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // activoDataGridViewCheckBoxColumn
            // 
            this.activoDataGridViewCheckBoxColumn.DataPropertyName = "activo";
            this.activoDataGridViewCheckBoxColumn.HeaderText = "activo";
            this.activoDataGridViewCheckBoxColumn.Name = "activoDataGridViewCheckBoxColumn";
            this.activoDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // permisosBindingSource
            // 
            this.permisosBindingSource.DataSource = typeof(iComercio.Models.Permiso);
            // 
            // FrmAsignarPerfiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 694);
            this.Controls.Add(this.btnQuitarPerfil);
            this.Controls.Add(this.btnAsignarPerfil);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grbPerfiles);
            this.Controls.Add(this.grbUsuarios);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmAsignarPerfiles";
            this.Text = "Asignar Perfiles a Usuarios";
            this.Load += new System.EventHandler(this.FrmUsuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.perfilesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usuarioBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.grbPerfiles.ResumeLayout(false);
            this.grbUsuarios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.permisosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion


       
        private System.Windows.Forms.BindingSource perfilesBindingSource;
        private System.Windows.Forms.BindingSource permisosBindingSource;
        private System.Windows.Forms.GroupBox grbUsuarios;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.GroupBox grbPerfiles;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lbPerfiles;
        private System.Windows.Forms.ListBox lbPerfilesAsig;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Button btnAsignarPerfil;
        private System.Windows.Forms.Button btnQuitarPerfil;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellidoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn activoDataGridViewCheckBoxColumn;
    }
}