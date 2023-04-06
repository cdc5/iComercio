    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Linq.Expressions;
    using iComercio.Auxiliar;

    namespace iComercio.Models
    {
        public interface IBusinessLayer
        {
            IEnumerable<Usuario> GetUsuarios(Expression<Func<Usuario, bool>> filter = null,
                                    Func<IQueryable<Usuario>, IOrderedQueryable<Usuario>> orderBy = null,
                                    string includeProperties = "");
            Usuario GetUsuarioByID(object id);
            void AgregarUsuario(Usuario usu);
            void BorrarUsuario(object id);
            void BorrarUsuario(Usuario usu);
            void ActualizarUsuario(Usuario usu);

            IEnumerable<Perfil> GetPerfiles(Expression<Func<Perfil, bool>> filter = null,
                                    Func<IQueryable<Perfil>, IOrderedQueryable<Perfil>> orderBy = null,
                                    string includeProperties = "");
            Perfil GetPerfilByID(object id);
            void AgregarPerfil(Perfil per);
            void BorrarPerfil(object id);
            void BorrarPerfil(Perfil per);
            void ActualizarPerfil(Perfil per);


            void AsignarPerfilesAUsuario(Usuario usu, IEnumerable<Perfil> per);
            void AsignarPerfilAUsuario(Usuario usu, Perfil per);
            void QuitarPerfilesAUsuario(Usuario usu, IEnumerable<Perfil> perfiles);
            void QuitarPerfilAUsuario(Usuario usu, Perfil per);
        

            IEnumerable<Perfil> GetPerfilesPosiblesParaAsignar(Usuario usu);

            void Grabar();
        }
    }
