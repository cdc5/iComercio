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
    public partial class FrmPerfiles : FRM
    {
        BindingSource perfilesBindingSource;
        public FrmPerfiles()
        {
            InitializeComponent();
        }


        public FrmPerfiles(Principal p, RestApi ra)
            : base(p, ra)
        {
            InitializeComponent();
           
        }

        private void FrmPerfiles_Load(object sender, EventArgs e)
        {
            perfilesBindingSource = new BindingSource();
            perfilesBindingSource.DataSource = bl.PerfilBindingList();
            dgvPerfiles.DataSource = perfilesBindingSource;
            dgvPerfiles.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CerrarConMensajeDeAdvertencia();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            bl.Grabar();
            CerrarConConfirmacion();
        }
    }
}
