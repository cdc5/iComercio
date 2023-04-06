namespace iComercio.Forms
{
    partial class frmReimpresiones
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode3 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReimpresiones));
            this.ViewCobranza = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFechaPago = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCuotaID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCobranzaID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaVencimiento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImportePago = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCreds = new DevExpress.XtraGrid.GridControl();
            this.creditoBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.ViewCred = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFechaSolicitud = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDocumento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreditoID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colComercio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValorNominal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.xTab = new DevExpress.XtraTab.XtraTabControl();
            this.xTabCreditos = new DevExpress.XtraTab.XtraTabPage();
            this.lblMor = new System.Windows.Forms.Label();
            this.lblDni = new System.Windows.Forms.Label();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.lblCredito = new System.Windows.Forms.Label();
            this.txtCredito = new System.Windows.Forms.TextBox();
            this.grbListados = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.ViewCobranza)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCreds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.creditoBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ViewCred)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xTab)).BeginInit();
            this.xTab.SuspendLayout();
            this.xTabCreditos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grbListados)).BeginInit();
            this.grbListados.SuspendLayout();
            this.SuspendLayout();
            // 
            // ViewCobranza
            // 
            this.ViewCobranza.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFechaPago,
            this.colCuotaID,
            this.colCobranzaID,
            this.colFechaVencimiento,
            this.colImportePago});
            this.ViewCobranza.GridControl = this.gridCreds;
            this.ViewCobranza.Name = "ViewCobranza";
            this.ViewCobranza.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.ViewCobranza.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.ViewCobranza.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.False;
            this.ViewCobranza.OptionsBehavior.Editable = false;
            this.ViewCobranza.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.ViewCobranza.DoubleClick += new System.EventHandler(this.ViewCobranza_DoubleClick);
            // 
            // colFechaPago
            // 
            this.colFechaPago.FieldName = "FechaPago";
            this.colFechaPago.Name = "colFechaPago";
            this.colFechaPago.Visible = true;
            this.colFechaPago.VisibleIndex = 2;
            // 
            // colCuotaID
            // 
            this.colCuotaID.FieldName = "CuotaID";
            this.colCuotaID.Name = "colCuotaID";
            this.colCuotaID.Visible = true;
            this.colCuotaID.VisibleIndex = 0;
            // 
            // colCobranzaID
            // 
            this.colCobranzaID.FieldName = "CobranzaID";
            this.colCobranzaID.Name = "colCobranzaID";
            this.colCobranzaID.Visible = true;
            this.colCobranzaID.VisibleIndex = 1;
            // 
            // colFechaVencimiento
            // 
            this.colFechaVencimiento.FieldName = "FechaVencimiento";
            this.colFechaVencimiento.Name = "colFechaVencimiento";
            this.colFechaVencimiento.Visible = true;
            this.colFechaVencimiento.VisibleIndex = 3;
            // 
            // colImportePago
            // 
            this.colImportePago.FieldName = "ImportePago";
            this.colImportePago.Name = "colImportePago";
            this.colImportePago.Visible = true;
            this.colImportePago.VisibleIndex = 4;
            // 
            // gridCreds
            // 
            this.gridCreds.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridCreds.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridCreds.DataSource = this.creditoBindingSource1;
            gridLevelNode1.LevelTemplate = this.ViewCobranza;
            gridLevelNode2.RelationName = "NotasCD";
            gridLevelNode3.RelationName = "Notas";
            gridLevelNode1.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode2,
            gridLevelNode3});
            gridLevelNode1.RelationName = "Cobranzas";
            this.gridCreds.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridCreds.Location = new System.Drawing.Point(6, 37);
            this.gridCreds.MainView = this.ViewCred;
            this.gridCreds.Name = "gridCreds";
            this.gridCreds.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox1});
            this.gridCreds.ShowOnlyPredefinedDetails = true;
            this.gridCreds.Size = new System.Drawing.Size(764, 348);
            this.gridCreds.TabIndex = 0;
            this.gridCreds.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.ViewCred,
            this.gridView3,
            this.ViewCobranza});
            this.gridCreds.Click += new System.EventHandler(this.gridCreds_Click);
            this.gridCreds.DoubleClick += new System.EventHandler(this.gridCreds_DoubleClick);
            // 
            // creditoBindingSource1
            // 
            this.creditoBindingSource1.DataSource = typeof(iComercio.Models.Credito);
            // 
            // ViewCred
            // 
            this.ViewCred.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFechaSolicitud,
            this.colDocumento,
            this.colCreditoID,
            this.colComercio,
            this.colValorNominal});
            this.ViewCred.GridControl = this.gridCreds;
            this.ViewCred.Name = "ViewCred";
            this.ViewCred.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.ViewCred.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.ViewCred.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.False;
            this.ViewCred.OptionsBehavior.Editable = false;
            this.ViewCred.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.ViewCred.DoubleClick += new System.EventHandler(this.ViewCred_DoubleClick);
            // 
            // colFechaSolicitud
            // 
            this.colFechaSolicitud.FieldName = "FechaSolicitud";
            this.colFechaSolicitud.Name = "colFechaSolicitud";
            this.colFechaSolicitud.Visible = true;
            this.colFechaSolicitud.VisibleIndex = 3;
            // 
            // colDocumento
            // 
            this.colDocumento.FieldName = "Documento";
            this.colDocumento.Name = "colDocumento";
            this.colDocumento.Visible = true;
            this.colDocumento.VisibleIndex = 0;
            // 
            // colCreditoID
            // 
            this.colCreditoID.FieldName = "CreditoID";
            this.colCreditoID.Name = "colCreditoID";
            this.colCreditoID.Visible = true;
            this.colCreditoID.VisibleIndex = 1;
            // 
            // colComercio
            // 
            this.colComercio.FieldName = "Comercio";
            this.colComercio.Name = "colComercio";
            this.colComercio.Visible = true;
            this.colComercio.VisibleIndex = 2;
            // 
            // colValorNominal
            // 
            this.colValorNominal.FieldName = "ValorNominal";
            this.colValorNominal.Name = "colValorNominal";
            this.colValorNominal.Visible = true;
            this.colValorNominal.VisibleIndex = 4;
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            // 
            // gridView3
            // 
            this.gridView3.GridControl = this.gridCreds;
            this.gridView3.Name = "gridView3";
            // 
            // xTab
            // 
            this.xTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xTab.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.xTab.BorderStylePage = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.xTab.Location = new System.Drawing.Point(5, 24);
            this.xTab.LookAndFeel.SkinName = "Seven Classic";
            this.xTab.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.xTab.Name = "xTab";
            this.xTab.PaintStyleName = "PropertyView";
            this.xTab.SelectedTabPage = this.xTabCreditos;
            this.xTab.Size = new System.Drawing.Size(770, 408);
            this.xTab.TabIndex = 0;
            this.xTab.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xTabCreditos});
            // 
            // xTabCreditos
            // 
            this.xTabCreditos.Controls.Add(this.lblMor);
            this.xTabCreditos.Controls.Add(this.lblDni);
            this.xTabCreditos.Controls.Add(this.txtDni);
            this.xTabCreditos.Controls.Add(this.lblCredito);
            this.xTabCreditos.Controls.Add(this.txtCredito);
            this.xTabCreditos.Controls.Add(this.gridCreds);
            this.xTabCreditos.Name = "xTabCreditos";
            this.xTabCreditos.Size = new System.Drawing.Size(770, 388);
            this.xTabCreditos.Text = "Creditos";
            // 
            // lblMor
            // 
            this.lblMor.BackColor = System.Drawing.Color.Black;
            this.lblMor.Location = new System.Drawing.Point(177, 9);
            this.lblMor.Name = "lblMor";
            this.lblMor.Size = new System.Drawing.Size(7, 20);
            this.lblMor.TabIndex = 1002;
            this.lblMor.Visible = false;
            // 
            // lblDni
            // 
            this.lblDni.AutoSize = true;
            this.lblDni.Location = new System.Drawing.Point(16, 12);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(29, 13);
            this.lblDni.TabIndex = 4;
            this.lblDni.Text = "DNI:";
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(51, 9);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(126, 20);
            this.txtDni.TabIndex = 3;
            this.txtDni.Tag = "NN";
            this.txtDni.TextChanged += new System.EventHandler(this.txtDni_TextChanged);
            this.txtDni.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDni_KeyPress);
            // 
            // lblCredito
            // 
            this.lblCredito.AutoSize = true;
            this.lblCredito.Location = new System.Drawing.Point(192, 12);
            this.lblCredito.Name = "lblCredito";
            this.lblCredito.Size = new System.Drawing.Size(43, 13);
            this.lblCredito.TabIndex = 2;
            this.lblCredito.Text = "Credito:";
            // 
            // txtCredito
            // 
            this.txtCredito.Location = new System.Drawing.Point(241, 9);
            this.txtCredito.Name = "txtCredito";
            this.txtCredito.Size = new System.Drawing.Size(126, 20);
            this.txtCredito.TabIndex = 1;
            this.txtCredito.Tag = "NN";
            this.txtCredito.TextChanged += new System.EventHandler(this.txtCredito_TextChanged);
            this.txtCredito.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCredito_KeyPress);
            // 
            // grbListados
            // 
            this.grbListados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbListados.Controls.Add(this.xTab);
            this.grbListados.Location = new System.Drawing.Point(12, 12);
            this.grbListados.Name = "grbListados";
            this.grbListados.Size = new System.Drawing.Size(780, 437);
            this.grbListados.TabIndex = 1;
            // 
            // frmReimpresiones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 461);
            this.Controls.Add(this.grbListados);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmReimpresiones";
            this.Text = "Impresiones";
            this.Load += new System.EventHandler(this.frmReimpresiones_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmReimpresiones_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.ViewCobranza)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCreds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.creditoBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ViewCred)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xTab)).EndInit();
            this.xTab.ResumeLayout(false);
            this.xTabCreditos.ResumeLayout(false);
            this.xTabCreditos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grbListados)).EndInit();
            this.grbListados.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xTab;
        private DevExpress.XtraTab.XtraTabPage xTabCreditos;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Label lblCredito;
        private System.Windows.Forms.TextBox txtCredito;
        private DevExpress.XtraGrid.GridControl gridCreds;
        private DevExpress.XtraGrid.Views.Grid.GridView ViewCobranza;
        private DevExpress.XtraGrid.Views.Grid.GridView ViewCred;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraEditors.GroupControl grbListados;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaPago;
        private DevExpress.XtraGrid.Columns.GridColumn colCuotaID;
        private DevExpress.XtraGrid.Columns.GridColumn colCobranzaID;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaVencimiento;
        private DevExpress.XtraGrid.Columns.GridColumn colImportePago;
        private System.Windows.Forms.BindingSource creditoBindingSource1;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaSolicitud;
        private DevExpress.XtraGrid.Columns.GridColumn colDocumento;
        private DevExpress.XtraGrid.Columns.GridColumn colCreditoID;
        private DevExpress.XtraGrid.Columns.GridColumn colComercio;
        private DevExpress.XtraGrid.Columns.GridColumn colValorNominal;
        private System.Windows.Forms.Label lblMor;
    }
}