﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iComercio.Rest.RestModels;

namespace iComercio.Models
{
    class TransBajaNotaCD:Operacion
    {
         public TransBajaNotaCD()             
         {
         }


         public TransBajaNotaCD(int OperacionID, string Nombre, string Descripcion) :
                                     base(OperacionID,Nombre,Descripcion)
         {
           
         }

        public async override Task<bool> Enviar(BusinessLayer bl, Transmision tran)
        {
            return false;
        }    
    }
}
