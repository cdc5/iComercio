using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iComercio.DAL;
using iComercio.Auxiliar;

namespace iComercio.Models
{
    public class Perfil 
    {
        public int PerfilID { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public DateTime creacion { get; set; }
        public bool activo { get; set; }

        //public virtual ICollection<UsuarioPerfil> UsuariosPerfiles { get; set; }
        public virtual ObservableListSource<Usuario> Usuarios { get; set; }
        public virtual ObservableListSource<Permiso> Permisos { get; set; }

        

     /*   private UnitOfWork uow;
                
        public Perfil()
        {
            this.uow = new UnitOfWork();
        }

        public Perfil(UnitOfWork uow)
        {
            this.uow = uow;
        }*/

        public Perfil()
        {
            
        }
       

       public Perfil(int PerfilID, string nombre, string descripcion, DateTime creacion, bool activo) 
        {
            this.PerfilID = PerfilID;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.creacion = creacion;
            this.activo = activo;
        }
     
    }
}
