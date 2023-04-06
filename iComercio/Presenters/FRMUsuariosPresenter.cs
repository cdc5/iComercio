using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iComercio.Forms;
using iComercio.ViewModels;
using iComercio.Models;
using iComercio.Auxiliar;


namespace iComercio.Presenters
{
    public class FRMUsuariosPresenter
    {

    /*    private FrmUsuarios frmUsuarios;
        private FrmUsuariosViewModel viewModel;

        public FRMUsuariosPresenter(FrmUsuarios frmUsuarios)
        {
            this.frmUsuarios = frmUsuarios;
            IEnumerable<Usuario> usuarios = this.frmUsuarios.bl.GetUsuarios(null, null, "Perfiles");
            this.viewModel = new FrmUsuariosViewModel(new Usuario(),usuarios, null, null);
            frmUsuarios.MostrarUsuarios(this.viewModel);
        }

        public void AsignarPerfilAUsuario(Usuario usu, Perfil per)
        {
            usu.Perfiles.Add(per);
        }

        public void QuitarPerfilAUsuario(Usuario usu, Perfil per)
        {
            usu.Perfiles.Remove(per);
        }

        public void Grabar()
        {
            frmUsuarios.LeerEntrada();
            IEnumerable<Usuario> usuarios = viewModel.usuarios;
            frmUsuarios.bl.Grabar();
        }

        public void Actualizar(Usuario usu)
        {
            this.viewModel.perfilesAsig = frmUsuarios.bl.GetPerfilesPosiblesParaAsignar(usu);
            frmUsuarios.MostrarUsuarios(this.viewModel);
        }*/
    }
}
