using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iComercio.Forms;
using iComercio.ViewModels;
using iComercio.Auxiliar;
using iComercio.Models;

namespace iComercio.Presenters
{
    public class GenericPresenter
    {
        private IView view;
        
        public GenericPresenter(IView view)
        {
            this.view = view;
            
            
        }
    }
}
