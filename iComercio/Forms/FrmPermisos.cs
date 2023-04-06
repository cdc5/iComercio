using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iComercio.Rest;
using iComercio.Rest.RestModels;
using iComercio.Models;
using iComercio.Delegados;
using iComercio.ViewModels;
using iComercio.Auxiliar;
 

namespace iComercio.Forms
{
    public partial class FrmPermisos : FRM
    {

        BindingSource permisosBindingSource;
        public FrmPermisos()
        {
            InitializeComponent();
        }

         public FrmPermisos(Principal p, RestApi ra)
            : base(p, ra)
        {
            InitializeComponent();
        }

        private void FrmPermisos_Load(object sender, EventArgs e)
        {
            permisosBindingSource = new BindingSource();
            permisosBindingSource.DataSource = bl.PermisoBindingList();
            dgvPermisos.DataSource = permisosBindingSource;
            dgvPermisos.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            bl.Grabar();
            CerrarConConfirmacion();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CerrarConMensajeDeAdvertencia();
        }
    }
}
