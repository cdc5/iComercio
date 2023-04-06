using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iComercio.DAL;
using iComercio.Auxiliar;

namespace iComercio.Models
{
    public class Permiso
    {
        public int PermisoID { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public DateTime creacion { get; set; }
        public bool activo { get; set; }

        public virtual ObservableListSource<Perfil> Perfiles { get; set; }

        public Permiso() { }
      /*  private UnitOfWork uow;
                
        public Permiso()
        {
            this.uow = new UnitOfWork();
        }

        public Permiso(UnitOfWork uow)
        {
            this.uow = uow;
        }*/
    }
}
