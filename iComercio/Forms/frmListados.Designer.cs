namespace iComercio.Forms
{
    partial class frmListados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListados));
            this.gc1 = new DevExpress.XtraEditors.GroupControl();
            this.GridLis = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grpBusqueda = new DevExpress.XtraEditors.GroupControl();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.gc1)).BeginInit();
            this.gc1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridLis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpBusqueda)).BeginInit();
            this.grpBusqueda.SuspendLayout();
            this.SuspendLayout();
            // 
            // gc1
            // 
            this.gc1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gc1.Controls.Add(this.GridLis);
            this.gc1.Location = new System.Drawing.Point(12, 111);
            this.gc1.Name = "gc1";
            this.gc1.Size = new System.Drawing.Size(765, 332);
            this.gc1.TabIndex = 0;
            // 
            // GridLis
            // 
            this.GridLis.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridLis.Cursor = System.Windows.Forms.Cursors.Default;
            this.GridLis.Location = new System.Drawing.Point(5, 24);
            this.GridLis.MainView = this.gridView1;
            this.GridLis.Name = "GridLis";
            this.GridLis.Size = new System.Drawing.Size(755, 303);
            this.GridLis.TabIndex = 0;
            this.GridLis.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.GridLis;
            this.gridView1.Name = "gridView1";
            // 
            // grpBusqueda
            // 
            this.grpBusqueda.Controls.Add(this.flowLayoutPanel1);
            this.grpBusqueda.Location = new System.Drawing.Point(12, 5);
            this.grpBusqueda.Name = "grpBusqueda";
            this.grpBusqueda.Size = new System.Drawing.Size(765, 100);
            this.grpBusqueda.TabIndex = 1;
            this.grpBusqueda.Text = "Búsqueda";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(5, 25);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(187, 70);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // frmListados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 455);
            this.Controls.Add(this.grpBusqueda);
            this.Controls.Add(this.gc1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmListados";
            this.Text = "Listado de ";
            this.Load += new System.EventHandler(this.frmListados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gc1)).EndInit();
            this.gc1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridLis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpBusqueda)).EndInit();
            this.grpBusqueda.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gc1;
        private DevExpress.XtraGrid.GridControl GridLis;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.GroupControl grpBusqueda;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}