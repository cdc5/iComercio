using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iComercio.Rest.RestModels;
using AutoMapper;

namespace iComercio.Models
{
    public class TransArchivo : Operacion
    {
        public TransArchivo()             
         {
         }

        public TransArchivo(int OperacionID, string Nombre, string Descripcion) :
                                     base(OperacionID,Nombre,Descripcion)
        {
        }

        public async override Task<bool> Enviar(BusinessLayer bl, Transmision tran)
        {
            int EmpresaID = System.Convert.ToInt32(tran.EmpresaID);
            int ComercioID = System.Convert.ToInt32(tran.ComercioID);
            string nombreArchivo = tran.EntidadID;
            string rutaArchivo = tran.EntidadID2;
            string claseArchivo = tran.EntidadID3;
            
            FileUploadResult fur =  await bl.TransmitirAchivo(EmpresaID, ComercioID, nombreArchivo, rutaArchivo, claseArchivo);
            if (fur != null)
                return true;
            return false;
            
            
        }    
    }
}
