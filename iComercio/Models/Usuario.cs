using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iComercio.DAL;
using iComercio.Auxiliar;


namespace iComercio.Models
{
    public class Usuario 
    {
        public int UsuarioID { get; set; }
        public string usuario { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string pass { get; set; }
        public DateTime creacion { get; set; }
        public bool activo { get; set; }

        //public virtual ICollection<UsuarioPerfil> UsuariosPerfiles { get; set; }
        public virtual ObservableListSource<Perfil> Perfiles { get; set; }
        

       
        /*private UnitOfWork uow;
        public Usuario()
        {
            this.uow = new UnitOfWork();
        }

        public Usuario(UnitOfWork uow)
        {
            this.uow = uow;
        }*/

        public Usuario()
        {
           
        }

        public Usuario(int UsuarioId,string usuario, string nombre, string apellido, string pass, DateTime creacion, bool activo) 
            {
                this.UsuarioID = UsuarioId;
                this.usuario = usuario;
                this.nombre = nombre;
                this.apellido = apellido;
                this.pass = pass;
                this.creacion = creacion;
                this.activo = activo;
            }


        public bool ValidarUsuario(string nombre, string pass)
        {
            if (this.nombre.Equals(nombre) && this.pass.Equals(pass))
                return true;
            return false;
        }

        

        public List<Permiso> GetPermisos()
        {
            IEnumerable<Permiso> permisos = this.Perfiles.SelectMany(p => p.Permisos);
            return permisos.ToList();

        }

        public List<string> GetPermisosNombres()
        {
            List<string> permisos = GetPermisos().Select(p => p.nombre).ToList();
            return permisos;

        }
        

    }
}
