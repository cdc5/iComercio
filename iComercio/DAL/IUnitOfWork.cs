using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iComercio.DAL
{
    public interface IUnitOfWork: IDisposable
    {
        void Save();
    }
}
