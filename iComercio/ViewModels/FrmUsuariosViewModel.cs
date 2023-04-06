using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iComercio.Models;
using iComercio.Auxiliar;

namespace iComercio.ViewModels
{
    public  class FrmUsuariosViewModel
    {
        public Usuario usuario { get; set; }
        public IEnumerable<Usuario> usuarios {get;set;}
        public IEnumerable<Perfil> perfilesDisp { get ; set; }
        public IEnumerable<Perfil> perfilesAsig { get; set; }

        public FrmUsuariosViewModel(Usuario usuario,IEnumerable<Usuario> usuarios, IEnumerable<Perfil> perfilesDisp, IEnumerable<Perfil> perfilesAsig)
        {
            this.usuario = usuario;
            this.usuarios = usuarios;
            this.perfilesDisp = perfilesDisp;
            this.perfilesAsig = perfilesAsig;
        }

        

        


    }
}
