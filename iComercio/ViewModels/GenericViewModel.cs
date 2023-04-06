using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iComercio.ViewModels
{
    class GenericViewModel
    {
        private readonly object objeto;

        public GenericViewModel(object objeto)
        {
            this.objeto = objeto;
        }
    }
}
