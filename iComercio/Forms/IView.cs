using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iComercio.Models;

namespace iComercio.Forms
{
    public interface IView
    {
        IBusinessLayer bl();
        
    }
}
