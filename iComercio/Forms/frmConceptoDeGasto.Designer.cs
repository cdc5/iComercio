namespace iComercio.Forms
{
    partial class frmConceptoDeGasto
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConceptoDeGasto));
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblCod = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtBusca = new System.Windows.Forms.TextBox();
            this.cmbBusca = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnModi2 = new System.Windows.Forms.Button();
            this.btnEliminar2 = new System.Windows.Forms.Button();
            this.btnNvoGstSub = new System.Windows.Forms.Button();
            this.dgvGastos2 = new System.Windows.Forms.DataGridView();
            this.Cod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnModi = new System.Windows.Forms.Button();
            this.btnElimina = new System.Windows.Forms.Button();
            this.btnNvoGst = new System.Windows.Forms.Button();
            this.dgvGastos1 = new System.Windows.Forms.DataGridView();
            this.ConceptoGastosID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conceptoGastosIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.queConceptoGastosIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nivelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConceptoGastosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pnlNvoGst = new System.Windows.Forms.Panel();
            this.chkNivelFinal = new System.Windows.Forms.CheckBox();
            this.btnCancelGst = new System.Windows.Forms.Button();
            this.btnGrabaGst = new System.Windows.Forms.Button();
            this.txtDescrip = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGastos2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGastos1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConceptoGastosBindingSource)).BeginInit();
            this.pnlNvoGst.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.ForeColor = System.Drawing.Color.Maroon;
            label1.Location = new System.Drawing.Point(21, 38);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(80, 14);
            label1.TabIndex = 13;
            label1.Text = "Descripción:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.ForeColor = System.Drawing.Color.Maroon;
            label2.Location = new System.Drawing.Point(43, 8);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(58, 14);
            label2.TabIndex = 12;
            label2.Text = "Nombre:";
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.btnCancelar);
            this.panel4.Location = new System.Drawing.Point(12, 365);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(963, 45);
            this.panel4.TabIndex = 5;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.Location = new System.Drawing.Point(865, 8);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(80, 27);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Salir";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblCod
            // 
            this.lblCod.AutoSize = true;
            this.lblCod.Location = new System.Drawing.Point(902, 9);
            this.lblCod.Name = "lblCod";
            this.lblCod.Size = new System.Drawing.Size(35, 13);
            this.lblCod.TabIndex = 4;
            this.lblCod.Text = "label1";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.txtBusca);
            this.panel3.Controls.Add(this.cmbBusca);
            this.panel3.ForeColor = System.Drawing.Color.Transparent;
            this.panel3.Location = new System.Drawing.Point(12, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(963, 44);
            this.panel3.TabIndex = 2;
            // 
            // txtBusca
            // 
            this.txtBusca.Location = new System.Drawing.Point(163, 11);
            this.txtBusca.Name = "txtBusca";
            this.txtBusca.Size = new System.Drawing.Size(318, 20);
            this.txtBusca.TabIndex = 1;
            this.txtBusca.TextChanged += new System.EventHandler(this.txtBusca_TextChanged);
            // 
            // cmbBusca
            // 
            this.cmbBusca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBusca.Font = new System.Drawing.Font("Tahoma", 9F);
            this.cmbBusca.FormattingEnabled = true;
            this.cmbBusca.Location = new System.Drawing.Point(3, 10);
            this.cmbBusca.Name = "cmbBusca";
            this.cmbBusca.Size = new System.Drawing.Size(154, 22);
            this.cmbBusca.TabIndex = 0;
            this.cmbBusca.SelectedIndexChanged += new System.EventHandler(this.cmbBusca_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.btnModi2);
            this.panel2.Controls.Add(this.btnEliminar2);
            this.panel2.Controls.Add(this.btnNvoGstSub);
            this.panel2.Controls.Add(this.dgvGastos2);
            this.panel2.Location = new System.Drawing.Point(500, 62);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(475, 188);
            this.panel2.TabIndex = 1;
            // 
            // btnModi2
            // 
            this.btnModi2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnModi2.ForeColor = System.Drawing.Color.Black;
            this.btnModi2.Location = new System.Drawing.Point(116, 158);
            this.btnModi2.Name = "btnModi2";
            this.btnModi2.Size = new System.Drawing.Size(107, 23);
            this.btnModi2.TabIndex = 8;
            this.btnModi2.Text = "Modficar";
            this.btnModi2.UseVisualStyleBackColor = true;
            this.btnModi2.Click += new System.EventHandler(this.btnModi2_Click);
            // 
            // btnEliminar2
            // 
            this.btnEliminar2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEliminar2.ForeColor = System.Drawing.Color.Black;
            this.btnEliminar2.Location = new System.Drawing.Point(361, 158);
            this.btnEliminar2.Name = "btnEliminar2";
            this.btnEliminar2.Size = new System.Drawing.Size(107, 23);
            this.btnEliminar2.TabIndex = 7;
            this.btnEliminar2.Text = "Eliminar";
            this.btnEliminar2.UseVisualStyleBackColor = true;
            this.btnEliminar2.Click += new System.EventHandler(this.btnEliminar2_Click);
            // 
            // btnNvoGstSub
            // 
            this.btnNvoGstSub.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNvoGstSub.ForeColor = System.Drawing.Color.Black;
            this.btnNvoGstSub.Location = new System.Drawing.Point(3, 158);
            this.btnNvoGstSub.Name = "btnNvoGstSub";
            this.btnNvoGstSub.Size = new System.Drawing.Size(107, 23);
            this.btnNvoGstSub.TabIndex = 6;
            this.btnNvoGstSub.Text = "Nuevo sub gasto";
            this.btnNvoGstSub.UseVisualStyleBackColor = true;
            this.btnNvoGstSub.Click += new System.EventHandler(this.btnNvoGstSub_Click);
            // 
            // dgvGastos2
            // 
            this.dgvGastos2.AllowUserToAddRows = false;
            this.dgvGastos2.AllowUserToDeleteRows = false;
            this.dgvGastos2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGastos2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGastos2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cod,
            this.Nombre2,
            this.Descripcion2});
            this.dgvGastos2.Location = new System.Drawing.Point(2, 3);
            this.dgvGastos2.MultiSelect = false;
            this.dgvGastos2.Name = "dgvGastos2";
            this.dgvGastos2.ReadOnly = true;
            this.dgvGastos2.Size = new System.Drawing.Size(465, 154);
            this.dgvGastos2.TabIndex = 3;
            this.dgvGastos2.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGastos2_CellEnter);
            // 
            // Cod
            // 
            this.Cod.DataPropertyName = "ConceptoGastosID";
            this.Cod.HeaderText = "Cod";
            this.Cod.Name = "Cod";
            this.Cod.ReadOnly = true;
            // 
            // Nombre2
            // 
            this.Nombre2.DataPropertyName = "Nombre";
            this.Nombre2.HeaderText = "Nombre ";
            this.Nombre2.Name = "Nombre2";
            this.Nombre2.ReadOnly = true;
            // 
            // Descripcion2
            // 
            this.Descripcion2.DataPropertyName = "Descripcion";
            this.Descripcion2.HeaderText = "Descripcion";
            this.Descripcion2.Name = "Descripcion2";
            this.Descripcion2.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnModi);
            this.panel1.Controls.Add(this.btnElimina);
            this.panel1.Controls.Add(this.btnNvoGst);
            this.panel1.Controls.Add(this.dgvGastos1);
            this.panel1.Location = new System.Drawing.Point(12, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(475, 292);
            this.panel1.TabIndex = 0;
            // 
            // btnModi
            // 
            this.btnModi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnModi.ForeColor = System.Drawing.Color.Black;
            this.btnModi.Location = new System.Drawing.Point(116, 262);
            this.btnModi.Name = "btnModi";
            this.btnModi.Size = new System.Drawing.Size(107, 23);
            this.btnModi.TabIndex = 7;
            this.btnModi.Text = "Modficar";
            this.btnModi.UseVisualStyleBackColor = true;
            this.btnModi.Click += new System.EventHandler(this.btnModi_Click);
            // 
            // btnElimina
            // 
            this.btnElimina.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnElimina.ForeColor = System.Drawing.Color.Black;
            this.btnElimina.Location = new System.Drawing.Point(363, 262);
            this.btnElimina.Name = "btnElimina";
            this.btnElimina.Size = new System.Drawing.Size(107, 23);
            this.btnElimina.TabIndex = 6;
            this.btnElimina.Text = "Eliminar";
            this.btnElimina.UseVisualStyleBackColor = true;
            this.btnElimina.Click += new System.EventHandler(this.btnElimina_Click);
            // 
            // btnNvoGst
            // 
            this.btnNvoGst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNvoGst.ForeColor = System.Drawing.Color.Black;
            this.btnNvoGst.Location = new System.Drawing.Point(3, 262);
            this.btnNvoGst.Name = "btnNvoGst";
            this.btnNvoGst.Size = new System.Drawing.Size(107, 23);
            this.btnNvoGst.TabIndex = 5;
            this.btnNvoGst.Text = "Nuevo";
            this.btnNvoGst.UseVisualStyleBackColor = true;
            this.btnNvoGst.Click += new System.EventHandler(this.btnNvoGst_Click);
            // 
            // dgvGastos1
            // 
            this.dgvGastos1.AllowUserToAddRows = false;
            this.dgvGastos1.AllowUserToDeleteRows = false;
            this.dgvGastos1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGastos1.AutoGenerateColumns = false;
            this.dgvGastos1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGastos1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ConceptoGastosID,
            this.Nombre,
            this.Descripcion,
            this.conceptoGastosIDDataGridViewTextBoxColumn,
            this.nombreDataGridViewTextBoxColumn,
            this.descripcionDataGridViewTextBoxColumn,
            this.estadoIDDataGridViewTextBoxColumn,
            this.estadoDataGridViewTextBoxColumn,
            this.queConceptoGastosIDDataGridViewTextBoxColumn,
            this.nivelDataGridViewTextBoxColumn});
            this.dgvGastos1.DataSource = this.ConceptoGastosBindingSource;
            this.dgvGastos1.Location = new System.Drawing.Point(3, 3);
            this.dgvGastos1.Name = "dgvGastos1";
            this.dgvGastos1.ReadOnly = true;
            this.dgvGastos1.Size = new System.Drawing.Size(465, 253);
            this.dgvGastos1.TabIndex = 0;
            this.dgvGastos1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGastos1_CellContentClick);
            this.dgvGastos1.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGastos1_CellEnter);
            // 
            // ConceptoGastosID
            // 
            this.ConceptoGastosID.DataPropertyName = "ConceptoGastosID";
            this.ConceptoGastosID.HeaderText = "Id";
            this.ConceptoGastosID.Name = "ConceptoGastosID";
            this.ConceptoGastosID.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Descripcion
            // 
            this.Descripcion.DataPropertyName = "Descripcion";
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            // 
            // conceptoGastosIDDataGridViewTextBoxColumn
            // 
            this.conceptoGastosIDDataGridViewTextBoxColumn.DataPropertyName = "ConceptoGastosID";
            this.conceptoGastosIDDataGridViewTextBoxColumn.HeaderText = "ConceptoGastosID";
            this.conceptoGastosIDDataGridViewTextBoxColumn.Name = "conceptoGastosIDDataGridViewTextBoxColumn";
            this.conceptoGastosIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.conceptoGastosIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            this.nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            this.nombreDataGridViewTextBoxColumn.ReadOnly = true;
            this.nombreDataGridViewTextBoxColumn.Visible = false;
            // 
            // descripcionDataGridViewTextBoxColumn
            // 
            this.descripcionDataGridViewTextBoxColumn.DataPropertyName = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.HeaderText = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.Name = "descripcionDataGridViewTextBoxColumn";
            this.descripcionDataGridViewTextBoxColumn.ReadOnly = true;
            this.descripcionDataGridViewTextBoxColumn.Visible = false;
            // 
            // estadoIDDataGridViewTextBoxColumn
            // 
            this.estadoIDDataGridViewTextBoxColumn.DataPropertyName = "EstadoID";
            this.estadoIDDataGridViewTextBoxColumn.HeaderText = "EstadoID";
            this.estadoIDDataGridViewTextBoxColumn.Name = "estadoIDDataGridViewTextBoxColumn";
            this.estadoIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.estadoIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // estadoDataGridViewTextBoxColumn
            // 
            this.estadoDataGridViewTextBoxColumn.DataPropertyName = "Estado";
            this.estadoDataGridViewTextBoxColumn.HeaderText = "Estado";
            this.estadoDataGridViewTextBoxColumn.Name = "estadoDataGridViewTextBoxColumn";
            this.estadoDataGridViewTextBoxColumn.ReadOnly = true;
            this.estadoDataGridViewTextBoxColumn.Visible = false;
            // 
            // queConceptoGastosIDDataGridViewTextBoxColumn
            // 
            this.queConceptoGastosIDDataGridViewTextBoxColumn.DataPropertyName = "QueConceptoGastosID";
            this.queConceptoGastosIDDataGridViewTextBoxColumn.HeaderText = "QueConceptoGastosID";
            this.queConceptoGastosIDDataGridViewTextBoxColumn.Name = "queConceptoGastosIDDataGridViewTextBoxColumn";
            this.queConceptoGastosIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.queConceptoGastosIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // nivelDataGridViewTextBoxColumn
            // 
            this.nivelDataGridViewTextBoxColumn.DataPropertyName = "Nivel";
            this.nivelDataGridViewTextBoxColumn.HeaderText = "Nivel";
            this.nivelDataGridViewTextBoxColumn.Name = "nivelDataGridViewTextBoxColumn";
            this.nivelDataGridViewTextBoxColumn.ReadOnly = true;
            this.nivelDataGridViewTextBoxColumn.Visible = false;
            // 
            // ConceptoGastosBindingSource
            // 
            this.ConceptoGastosBindingSource.DataSource = typeof(iComercio.Models.ConceptoGastos);
            // 
            // pnlNvoGst
            // 
            this.pnlNvoGst.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlNvoGst.Controls.Add(this.chkNivelFinal);
            this.pnlNvoGst.Controls.Add(label1);
            this.pnlNvoGst.Controls.Add(label2);
            this.pnlNvoGst.Controls.Add(this.btnCancelGst);
            this.pnlNvoGst.Controls.Add(this.btnGrabaGst);
            this.pnlNvoGst.Controls.Add(this.txtDescrip);
            this.pnlNvoGst.Controls.Add(this.txtNombre);
            this.pnlNvoGst.Location = new System.Drawing.Point(500, 256);
            this.pnlNvoGst.Name = "pnlNvoGst";
            this.pnlNvoGst.Size = new System.Drawing.Size(475, 98);
            this.pnlNvoGst.TabIndex = 3;
            this.pnlNvoGst.Visible = false;
            // 
            // chkNivelFinal
            // 
            this.chkNivelFinal.AutoSize = true;
            this.chkNivelFinal.Location = new System.Drawing.Point(137, 69);
            this.chkNivelFinal.Name = "chkNivelFinal";
            this.chkNivelFinal.Size = new System.Drawing.Size(75, 17);
            this.chkNivelFinal.TabIndex = 14;
            this.chkNivelFinal.Text = "Nivel Final";
            this.chkNivelFinal.UseVisualStyleBackColor = true;
            this.chkNivelFinal.CheckedChanged += new System.EventHandler(this.chkNivelFinal_CheckedChanged);
            // 
            // btnCancelGst
            // 
            this.btnCancelGst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelGst.ForeColor = System.Drawing.Color.Black;
            this.btnCancelGst.Location = new System.Drawing.Point(340, 63);
            this.btnCancelGst.Name = "btnCancelGst";
            this.btnCancelGst.Size = new System.Drawing.Size(107, 26);
            this.btnCancelGst.TabIndex = 7;
            this.btnCancelGst.Text = "Cancelar";
            this.btnCancelGst.UseVisualStyleBackColor = true;
            this.btnCancelGst.Click += new System.EventHandler(this.btnCancelGst_Click);
            // 
            // btnGrabaGst
            // 
            this.btnGrabaGst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGrabaGst.ForeColor = System.Drawing.Color.Black;
            this.btnGrabaGst.Location = new System.Drawing.Point(24, 63);
            this.btnGrabaGst.Name = "btnGrabaGst";
            this.btnGrabaGst.Size = new System.Drawing.Size(107, 26);
            this.btnGrabaGst.TabIndex = 6;
            this.btnGrabaGst.Text = "Grabar";
            this.btnGrabaGst.UseVisualStyleBackColor = true;
            this.btnGrabaGst.Click += new System.EventHandler(this.btnGrabaGst_Click);
            // 
            // txtDescrip
            // 
            this.txtDescrip.Location = new System.Drawing.Point(101, 32);
            this.txtDescrip.Name = "txtDescrip";
            this.txtDescrip.Size = new System.Drawing.Size(346, 20);
            this.txtDescrip.TabIndex = 1;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(101, 6);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(346, 20);
            this.txtNombre.TabIndex = 0;
            // 
            // frmConceptoDeGasto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(987, 410);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.lblCod);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlNvoGst);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmConceptoDeGasto";
            this.Text = "Concepto de gastos";
            this.Load += new System.EventHandler(this.frmConceptoDeGasto_Load);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGastos2)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGastos1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConceptoGastosBindingSource)).EndInit();
            this.pnlNvoGst.ResumeLayout(false);
            this.pnlNvoGst.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtBusca;
        private System.Windows.Forms.ComboBox cmbBusca;
        private System.Windows.Forms.Panel pnlNvoGst;
        private System.Windows.Forms.TextBox txtDescrip;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnNvoGst;
        private System.Windows.Forms.Button btnGrabaGst;
        private System.Windows.Forms.BindingSource ConceptoGastosBindingSource;
        private System.Windows.Forms.Button btnCancelGst;
        private System.Windows.Forms.Button btnNvoGstSub;
        private System.Windows.Forms.Label lblCod;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnElimina;
        private System.Windows.Forms.Button btnEliminar2;
        private System.Windows.Forms.DataGridView dgvGastos2;
        private System.Windows.Forms.DataGridView dgvGastos1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConceptoGastosID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn conceptoGastosIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn queConceptoGastosIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nivelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cod;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion2;
        private System.Windows.Forms.Button btnModi;
        private System.Windows.Forms.Button btnModi2;
        private System.Windows.Forms.CheckBox chkNivelFinal;
    }
}