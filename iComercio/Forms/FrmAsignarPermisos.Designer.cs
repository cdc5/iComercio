namespace iComercio.Forms
{
    partial class FrmAsignarPermisos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAsignarPermisos));
            this.btnQuitarPerfil = new System.Windows.Forms.Button();
            this.btnAsignarPerfil = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.grbPermisosAsignados = new System.Windows.Forms.GroupBox();
            this.lbPermisosAsig = new System.Windows.Forms.ListBox();
            this.grbPermisos = new System.Windows.Forms.GroupBox();
            this.lbPermisos = new System.Windows.Forms.ListBox();
            this.grbUsuarios = new System.Windows.Forms.GroupBox();
            this.dgvPerfiles = new System.Windows.Forms.DataGridView();
            this.perfilIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.creacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.activoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.grbPermisosAsignados.SuspendLayout();
            this.grbPermisos.SuspendLayout();
            this.grbUsuarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerfiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnQuitarPerfil
            // 
            this.btnQuitarPerfil.Location = new System.Drawing.Point(285, 281);
            this.btnQuitarPerfil.Name = "btnQuitarPerfil";
            this.btnQuitarPerfil.Size = new System.Drawing.Size(131, 28);
            this.btnQuitarPerfil.TabIndex = 17;
            this.btnQuitarPerfil.Text = "<";
            this.btnQuitarPerfil.UseVisualStyleBackColor = true;
            this.btnQuitarPerfil.Click += new System.EventHandler(this.btnQuitarPerfil_Click);
            // 
            // btnAsignarPerfil
            // 
            this.btnAsignarPerfil.Location = new System.Drawing.Point(285, 230);
            this.btnAsignarPerfil.Name = "btnAsignarPerfil";
            this.btnAsignarPerfil.Size = new System.Drawing.Size(131, 28);
            this.btnAsignarPerfil.TabIndex = 16;
            this.btnAsignarPerfil.Text = ">";
            this.btnAsignarPerfil.UseVisualStyleBackColor = true;
            this.btnAsignarPerfil.Click += new System.EventHandler(this.btnAsignarPerfil_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Location = new System.Drawing.Point(308, 342);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(91, 25);
            this.btnGrabar.TabIndex = 15;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(308, 393);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(91, 25);
            this.btnCancelar.TabIndex = 14;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // grbPermisosAsignados
            // 
            this.grbPermisosAsignados.Controls.Add(this.lbPermisosAsig);
            this.grbPermisosAsignados.Location = new System.Drawing.Point(450, 203);
            this.grbPermisosAsignados.Name = "grbPermisosAsignados";
            this.grbPermisosAsignados.Size = new System.Drawing.Size(250, 267);
            this.grbPermisosAsignados.TabIndex = 13;
            this.grbPermisosAsignados.TabStop = false;
            this.grbPermisosAsignados.Text = "Permisos Asignados";
            // 
            // lbPermisosAsig
            // 
            this.lbPermisosAsig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbPermisosAsig.FormattingEnabled = true;
            this.lbPermisosAsig.Location = new System.Drawing.Point(3, 16);
            this.lbPermisosAsig.Name = "lbPermisosAsig";
            this.lbPermisosAsig.Size = new System.Drawing.Size(244, 248);
            this.lbPermisosAsig.TabIndex = 1;
            // 
            // grbPermisos
            // 
            this.grbPermisos.Controls.Add(this.lbPermisos);
            this.grbPermisos.Location = new System.Drawing.Point(15, 203);
            this.grbPermisos.Name = "grbPermisos";
            this.grbPermisos.Size = new System.Drawing.Size(237, 264);
            this.grbPermisos.TabIndex = 12;
            this.grbPermisos.TabStop = false;
            this.grbPermisos.Text = "Permisos";
            // 
            // lbPermisos
            // 
            this.lbPermisos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbPermisos.FormattingEnabled = true;
            this.lbPermisos.Location = new System.Drawing.Point(3, 16);
            this.lbPermisos.Name = "lbPermisos";
            this.lbPermisos.Size = new System.Drawing.Size(231, 245);
            this.lbPermisos.TabIndex = 0;
            // 
            // grbUsuarios
            // 
            this.grbUsuarios.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbUsuarios.Controls.Add(this.dgvPerfiles);
            this.grbUsuarios.Location = new System.Drawing.Point(12, 12);
            this.grbUsuarios.Name = "grbUsuarios";
            this.grbUsuarios.Size = new System.Drawing.Size(693, 185);
            this.grbUsuarios.TabIndex = 11;
            this.grbUsuarios.TabStop = false;
            this.grbUsuarios.Text = "Perfiles";
            // 
            // dgvPerfiles
            // 
            this.dgvPerfiles.AllowUserToAddRows = false;
            this.dgvPerfiles.AllowUserToDeleteRows = false;
            this.dgvPerfiles.AutoGenerateColumns = false;
            this.dgvPerfiles.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvPerfiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPerfiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.perfilIDDataGridViewTextBoxColumn,
            this.nombreDataGridViewTextBoxColumn,
            this.descripcionDataGridViewTextBoxColumn,
            this.creacionDataGridViewTextBoxColumn,
            this.activoDataGridViewCheckBoxColumn});
            this.dgvPerfiles.DataSource = this.bindingSource1;
            this.dgvPerfiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPerfiles.Location = new System.Drawing.Point(3, 16);
            this.dgvPerfiles.Name = "dgvPerfiles";
            this.dgvPerfiles.ReadOnly = true;
            this.dgvPerfiles.Size = new System.Drawing.Size(687, 166);
            this.dgvPerfiles.TabIndex = 0;
            this.dgvPerfiles.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPerfiles_RowEnter);
            // 
            // perfilIDDataGridViewTextBoxColumn
            // 
            this.perfilIDDataGridViewTextBoxColumn.DataPropertyName = "PerfilID";
            this.perfilIDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.perfilIDDataGridViewTextBoxColumn.Name = "perfilIDDataGridViewTextBoxColumn";
            this.perfilIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "nombre";
            this.nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            this.nombreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descripcionDataGridViewTextBoxColumn
            // 
            this.descripcionDataGridViewTextBoxColumn.DataPropertyName = "descripcion";
            this.descripcionDataGridViewTextBoxColumn.HeaderText = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.Name = "descripcionDataGridViewTextBoxColumn";
            this.descripcionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // creacionDataGridViewTextBoxColumn
            // 
            this.creacionDataGridViewTextBoxColumn.DataPropertyName = "creacion";
            this.creacionDataGridViewTextBoxColumn.HeaderText = "Creacion";
            this.creacionDataGridViewTextBoxColumn.Name = "creacionDataGridViewTextBoxColumn";
            this.creacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // activoDataGridViewCheckBoxColumn
            // 
            this.activoDataGridViewCheckBoxColumn.DataPropertyName = "activo";
            this.activoDataGridViewCheckBoxColumn.HeaderText = "Activo";
            this.activoDataGridViewCheckBoxColumn.Name = "activoDataGridViewCheckBoxColumn";
            this.activoDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(iComercio.Models.Perfil);
            // 
            // FrmAsignarPermisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 476);
            this.Controls.Add(this.btnQuitarPerfil);
            this.Controls.Add(this.btnAsignarPerfil);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.grbPermisosAsignados);
            this.Controls.Add(this.grbPermisos);
            this.Controls.Add(this.grbUsuarios);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmAsignarPermisos";
            this.Text = "Asignar Permisos A Perfiles";
            this.Load += new System.EventHandler(this.FrmAsignarPermisos_Load);
            this.grbPermisosAsignados.ResumeLayout(false);
            this.grbPermisos.ResumeLayout(false);
            this.grbUsuarios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerfiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnQuitarPerfil;
        private System.Windows.Forms.Button btnAsignarPerfil;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox grbPermisosAsignados;
        private System.Windows.Forms.ListBox lbPermisosAsig;
        private System.Windows.Forms.GroupBox grbPermisos;
        private System.Windows.Forms.ListBox lbPermisos;
        private System.Windows.Forms.GroupBox grbUsuarios;
        private System.Windows.Forms.DataGridView dgvPerfiles;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn perfilIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn creacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn activoDataGridViewCheckBoxColumn;
    }
}