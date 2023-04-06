﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iComercio.Rest.RestModels;
using AutoMapper;

namespace iComercio.Models
{
    public class TransActualizarPago:Operacion
    {
        public TransActualizarPago()             
         {
         }


        public TransActualizarPago(int OperacionID, string Nombre, string Descripcion) :
                                     base(OperacionID,Nombre,Descripcion)
         {
           
         }

         public async override Task<bool> Enviar(BusinessLayer bl, Transmision tran)
         {
            
             return true;
         }     
    }
}
