using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iComercio.Models;

namespace iComercio.DAL
{
    public interface IUsuarioRepository:IDisposable
    {
        IEnumerable<Usuario> GetUsuarios();
        Usuario GetUsuarioByID(int UsuarioId);
        void InsertUsuario(Usuario usuario);
        void DeleteUsuario(int usuarioID);
        void UpdateUsuario(Usuario usuario);
        void Save();
    }
}
